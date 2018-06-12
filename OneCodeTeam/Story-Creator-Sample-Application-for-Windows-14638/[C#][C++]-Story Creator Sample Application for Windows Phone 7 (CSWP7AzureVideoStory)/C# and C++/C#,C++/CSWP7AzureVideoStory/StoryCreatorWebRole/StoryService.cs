/****************************** Module Header ******************************\
* Module Name:	StoryService.cs
* Project: StoryCreatorWebRole
* Copyright (c) Microsoft Corporation.
* 
* A WCF REST service built with Web API.
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
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.StorageClient;
using StoryDataModel;

namespace StoryCreatorWebRole
{
    [ServiceContract]
    public class StoryService
    {
        /// <summary>
        /// Create a new story resource.
        /// </summary>
        [WebInvoke(Method = "POST", UriTemplate = "")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            // Make sure the storage account is ready.
            if (Global.StorageAccount == null)
            {
                if (!Global.InitializeStorage())
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest,
                        "The service is unavailable at the moment. Please try again later.");
                }
            }

            try
            {
                // Request body.
                XDocument docSource = XDocument.Parse(request.Content.ReadAsString());

                // Response body.
                XDocument docResult = new XDocument(new XElement("Story"));
                ;
                var photos = docSource.Root.Elements("Photo");
                int photoElementsCount = photos.Count();
                if (photos.Count() < 2)
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest, "A story requires at least 2 photos.");
                }

                int photoCount = 0;
                try
                {
                    photoCount = int.Parse(docSource.Root.Attribute("PhotoCount").Value);
                }
                catch
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest,
                        "The request body is not well formatted. The required attribute PhotoCount of element Story is either missing or incorrect.");
                }

                if (photoElementsCount != photoCount)
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest,
                        "The request body is not well formatted. The value of PhotoCount doesn't equal to count of the Photo elements.");
                }

                CloudBlobClient blobClient = new CloudBlobClient(Global.StorageAccount.BlobEndpoint, Global.StorageAccount.Credentials);
                CloudBlobContainer container = blobClient.GetContainerReference("videostories");

                // The unique ID that represents the story.
                string id = Guid.NewGuid().ToString();
                CloudBlob configBlob = container.GetBlobReference(id + ".xml");
                docResult.Root.Add(new XAttribute("ID", id));

                foreach (XElement photo in photos)
                {
                    string name = photo.Attribute("Name").Value;

                    // Construct SAS. The start time is set to 1 minute earlier,
                    // to make sure the client is able to upload the blob.
                    CloudBlob blob = container.GetBlobReference(id + "/" + name);
                    string sas = blob.GetSharedAccessSignature(new SharedAccessPolicy()
                    {
                        Permissions = SharedAccessPermissions.Write,
                        SharedAccessStartTime = DateTime.Now.AddMinutes(-1d),
                        SharedAccessExpiryTime = DateTime.Now.AddHours(0.5)
                    });

                    // Create an empty blob, so clients can upload to the correct blob.
                    blob.UploadText("");

                    // Modify the original configuration. Add URI without SAS.
                    photo.Add(new XAttribute("Uri", blob.Uri.AbsoluteUri));

                    // Add the Photo element to the response, including SAS.
                    string fullUri = blob.Uri.AbsoluteUri + sas;
                    docResult.Root.Add(new XElement("Photo", new XAttribute("Name", name), new XAttribute("Uri", fullUri)));
                }

                // Store the config in blob storage.
                configBlob.UploadText(docSource.ToString());

                Trace.Write("Story configuraion created: " + configBlob.Uri, "Information");

                // Return the success response.
                return this.CreateXmlResponse(HttpStatusCode.Created, docResult.ToString());
            }
            catch (XmlException)
            {
                return this.CreateStringResponse(HttpStatusCode.BadRequest,
                    "The request body is not a well formatted xml document.");
            }
            catch (StorageClientException ex)
            {
                Trace.Write("Error dealing with blob: " + ex.Message, "Error");
                return this.CreateStringResponse(HttpStatusCode.InternalServerError,
                    "The service is unavailable at the moment. Please try again later.");
            }
        }

        /// <summary>
        /// Update a story resource.
        /// Currently the only update is to commit the story (indicates we can start to encode the video).
        /// </summary>
        [WebInvoke(Method = "PUT", UriTemplate = "{id}?commit={commit}")]
        public HttpResponseMessage Put(HttpRequestMessage request, string id, bool? commit)
        {
            // Make sure the storage account is ready.
            if (Global.StorageAccount == null)
            {
                if (!Global.InitializeStorage())
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest,
                        "The service is unavailable at the moment. Please try again later.");
                }
            }
            if (string.IsNullOrEmpty(id))
            {
                return this.CreateStringResponse(HttpStatusCode.BadRequest, "Required parameter id is missing.");
            }
            if (commit == null || !commit.Value)
            {
                return this.CreateStringResponse(HttpStatusCode.BadRequest, "Currently only \"commit=true\" option is supported.");
            }

            try
            {
                CloudBlobClient blobClient = new CloudBlobClient(Global.StorageAccount.BlobEndpoint, Global.StorageAccount.Credentials);
                CloudBlobContainer container = blobClient.GetContainerReference("videostories");
                CloudBlob configBlob = container.GetBlobReference(id + ".xml");

                // We do not actually need those attributes. We simply check if the blob exists or not.
                // If the blob doesn't exist, a StorageClientException will be thrown, so we jump to the catch block.
                configBlob.FetchAttributes();

                // Add the job to queue.
                CloudQueueClient queueClient = new CloudQueueClient(Global.StorageAccount.QueueEndpoint, Global.StorageAccount.Credentials);
                CloudQueue queue = queueClient.GetQueueReference("videostories");
                queue.AddMessage(new CloudQueueMessage(id));

                // Return an empty successful message.
                return this.CreateStringResponse(HttpStatusCode.NoContent, "");

            }
            catch (StorageClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.CreateStringResponse(HttpStatusCode.NotFound, "The requested story does not exist.");
                }

                // General error, trace and return a genric message.
                Trace.Write("Error dealing with blob: " + ex.Message, "Error");
                return this.CreateStringResponse(HttpStatusCode.InternalServerError,
                    "The service is unavailable at the moment. Please try again later.");
            }
        }

        [WebGet(UriTemplate = "")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            // Make sure the storage account is ready.
            if (Global.StorageAccount == null)
            {
                if (!Global.InitializeStorage())
                {
                    return this.CreateStringResponse(HttpStatusCode.BadRequest,
                        "The service is unavailable at the moment. Please try again later.");
                }
            }

            try
            {
                StoryDataContext storyDataContext = new StoryDataContext(Global.StorageAccount.TableEndpoint.AbsoluteUri, Global.StorageAccount.Credentials);
                
                // Query the table storage.
                var query = from s in storyDataContext.Stories select s;

                // convert the result to a simplified class that doesn't contain partition/row key.
                List<Story> stories = new List<Story>();
                foreach (StoryDataModel.Story s in query)
                {
                    stories.Add(new Story() { Name = s.Name, VideoUri = s.VideoUri });
                }
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Story>));
                using (MemoryStream stream = new MemoryStream())
                {
                    jsonSerializer.WriteObject(stream, stories);
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();
                        return this.CreateJsonResponse(HttpStatusCode.OK, result);
                    }
                }
            }
            catch (StorageClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.CreateStringResponse(HttpStatusCode.NotFound, "The requested story does not exist.");
                }

                // General error, trace and return a genric message.
                Trace.Write("Error dealing with table service: " + ex.Message, "Error");
                return this.CreateStringResponse(HttpStatusCode.InternalServerError,
                    "The service is unavailable at the moment. Please try again later.");
            }
            catch (DataServiceQueryException ex2)
            {
                Trace.Write("Error dealing with table service: " + ex2.Message, "Error");
                return this.CreateStringResponse(HttpStatusCode.InternalServerError,
                    "The service is unavailable at the moment. Please try again later.");
            }
        }

        private HttpResponseMessage CreateStringResponse(HttpStatusCode statusCode, string body)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = statusCode;
            response.Content = new StringContent(body);
            return response;
        }

        private HttpResponseMessage CreateXmlResponse(HttpStatusCode statusCode, string body)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = statusCode;
            response.Content = new StringContent(body, Encoding.UTF8, "text/xml");
            return response;
        }

        private HttpResponseMessage CreateJsonResponse(HttpStatusCode statusCode, string body)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = statusCode;
            response.Content = new StringContent(body, Encoding.UTF8, "application/json");
            return response;
        }
    }
}