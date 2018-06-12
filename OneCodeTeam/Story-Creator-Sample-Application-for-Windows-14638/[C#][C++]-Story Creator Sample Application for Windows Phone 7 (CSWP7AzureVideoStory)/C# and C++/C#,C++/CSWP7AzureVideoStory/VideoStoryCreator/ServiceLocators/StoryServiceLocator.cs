/****************************** Module Header ******************************\
* Module Name:	StoryServiceLocator.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* This doesn't actually implement the service locator pattern.
* But this class encapsulates all logic to access the REST service,
* so UI components no longer have direct dependencies on the service.
* This is kind of dependency injection.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Xml.Linq;
using VideoStoryCreator.Models;
using VideoStoryCreator.Helpers;

namespace VideoStoryCreator.ServiceLocators
{
    public class StoryServiceLocator
    {
        // The base URI of our cloud REST service.
        // Change to your cloud service address if you want to test aginst cloud.
        //private string _baseServiceUri = "http://127.0.0.1:81/stories";
        private string _baseServiceUri = "http://storycreator.cloudapp.net/stories";
        private string _storyID;

        // The following fileds are used when uploading the photos to blob storage.
        // We need to wait until all photos are uploaded, and then commit the story.
        private int _allPhotoCount = 0;
        private int _uploadedPhotoCount = 0;
        private bool _uploadFailed = false;
        private object _lockObject = new object();

        public event EventHandler StoryUploaded;

        public void UploadStory()
        {
            // Create and upload the story configuration file.
            XDocument storyConfig = PersistenceHelper.SerializeStory();
            WebClient webClient = new WebClient();
            webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(UploadConfigCompleted);
            webClient.UploadStringAsync(new Uri(this._baseServiceUri), storyConfig.ToString());
        }

        void UploadConfigCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // TODO: Log errors...
                MessageBox.Show("Cannot connect to the service at the moment. Please try again later.");
            }
            else
            {
                try
                {
                    // The response is an xml document containing the blob SAS for each photo.
                    XDocument resultXDoc = XDocument.Parse(e.Result);
                    this._storyID = resultXDoc.Root.Attribute("ID").Value;
                    var photoElements = resultXDoc.Root.Elements("Photo");

                    lock (this._lockObject)
                    {
                        this._allPhotoCount = photoElements.Count();
                    }

                    // Create a background thread, which waits until all photos are uploaded.
                    // Then it commits the story.
                    Thread thread = new Thread(new ThreadStart(this.WaitUntilAllPhotosUploaded));
                    thread.Start();

                    foreach (var photoElement in photoElements)
                    {
                        string name = photoElement.Attribute("Name").Value;
                        string blobUri = photoElement.Attribute("Uri").Value;

                        // Find the photo in the current story.
                        Photo photo = App.MediaCollection.Where(p => p.Name == name).FirstOrDefault();
                        if (photo == null)
                        {
                            throw new InvalidOperationException("Cannot find the photo.");
                        }
                        if (photo.ResizedImageStream == null)
                        {
                            photo.ResizedImageStream = BitmapHelper.GetResizedImage(photo.Name);
                        }

                        // Upload the photo to blob.
                        photo.ResizedImageStream.Position = 0;

                        RetryPolicy policy = new RetryPolicy(blobUri);
                        policy.RequestAddress = blobUri;
                        policy.Initialize = new Action(() =>
                        {
                            policy.Request.Method = "PUT";
                        });
                        policy.RequestCallback = new AsyncCallback((requestStreamResult) =>
                        {
                            Stream requestStream = policy.Request.EndGetRequestStream(requestStreamResult);
                            byte[] buffer = new byte[photo.ResizedImageStream.Length];
                            photo.ResizedImageStream.Position = 0;
                            photo.ResizedImageStream.Read(buffer, 0, buffer.Length);
                            requestStream.Write(buffer, 0, buffer.Length);
                            requestStream.Close();
                        });

                        policy.ResponseCallback = new AsyncCallback((responseResult) =>
                            {
                                HttpWebResponse response = (HttpWebResponse)policy.Request.EndGetResponse(responseResult);
                                if (response.StatusCode != HttpStatusCode.Created)
                                {
                                    throw new InvalidOperationException("Uploading photo to blob storage failed.");
                                }
                                lock (this._lockObject)
                                {
                                    this._uploadedPhotoCount++;
                                }
                            });
                        policy.MakeRequest();
                    }
                }
                catch
                {
                    // TODO: Log errors...

                    lock (this._lockObject)
                    {
                        this._uploadFailed = true;
                    }
                    MessageBox.Show("Cannot upload photos at the moment. Please try again later.");
                }
            }
        }

        /// <summary>
        /// Should be invoked on a background thread
        /// Waits until all photos are uploaded.
        /// Then it commits the story.
        /// </summary>
        private void WaitUntilAllPhotosUploaded()
        {
            while (true)
            {
                lock (this._lockObject)
                {
                    // All photos have been uploaded or something went wrong. So break the wait.
                    if ((this._allPhotoCount == this._uploadedPhotoCount) || (this._uploadFailed == true))
                    {
                        break;
                    }
                }
                Thread.Sleep(3000);
            }
            if (!this._uploadFailed)
            {
                string requestUri = this._baseServiceUri + "/" + this._storyID + "?commit=true";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                request.Method = "PUT";
                request.BeginGetRequestStream((requestStreamResult) =>
                {
                    Stream requestStream = request.EndGetRequestStream(requestStreamResult);

                    // No request body is needed.
                    requestStream.Close();
                    request.BeginGetResponse((responseResult) =>
                    {
                        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(responseResult);
                        if (response.StatusCode != HttpStatusCode.NoContent)
                        {
                            throw new InvalidOperationException("Uploading photo to blob storage failed.");
                        }
                        else
                        {
                            if (this.StoryUploaded != null)
                            {
                                this.StoryUploaded(this, EventArgs.Empty);
                            }
                        }
                    }, null);
                }, null);
            }
        }
    }
}
