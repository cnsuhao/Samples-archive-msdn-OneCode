/****************************** Module Header ******************************\
* Module Name:	WorkerRole.cs
* Project: VideoEncodingWorkerRole
* Copyright (c) Microsoft Corporation.
* 
* The Worker Role that encodes the video.
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using StoryDataModel;

namespace VideoEncodingWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobContainer _container;
        private CloudQueue _queue;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("VideoEncodingWorkerRole entry point called", "Information");

            // Obtain the local storage paths.
            string localStorageRoot = RoleEnvironment.GetLocalResource("PhotoStore").RootPath;
            string diagnosticsRoot = RoleEnvironment.GetLocalResource("DiagnosticStore").RootPath;
            while (true)
            {
                try
                {
                    // Get a message from the queue.
                    CloudQueueMessage message = this._queue.GetMessage(TimeSpan.FromMinutes(20d));
                    if (message != null)
                    {
                        string storyID = message.AsString;

                        // This story can't be encoded...
                        if (message.DequeueCount > 3)
                        {
                            Trace.Write("The story " + storyID + " has been unable to be processed for too many times.", "Error");
                            this._queue.DeleteMessage(message);
                        }
                        else
                        {
                            Trace.Write("Begin to process story " + storyID + ".", "Information");

                            string storyFolderPath = Path.Combine(localStorageRoot, storyID);
                            Directory.CreateDirectory(storyFolderPath);

                            // Download the xml configuration file.
                            CloudBlob blob = this._container.GetBlobReference(storyID + ".xml");
                            string config = blob.DownloadText();
                            XDocument xdoc = XDocument.Parse(config);
                            string storyName = xdoc.Root.Attribute("Name").Value;
                            foreach (var photo in xdoc.Root.Elements("Photo"))
                            {
                                // Download the photo, and save it in local storage.
                                string photoBlobUri = photo.Attribute("Uri").Value;
                                CloudBlob photoBlob = this._container.GetBlobReference(photoBlobUri);
                                string localPhotoFilePath = Path.Combine(localStorageRoot, storyID, photo.Attribute("Name").Value);
                                photoBlob.DownloadToFile(localPhotoFilePath);

                                // Modify the Name of the photo to include the full path.
                                photo.Attribute("Name").Value = localPhotoFilePath;
                            }

                            // Save the config file to local storage.
                            string configFilePath = Path.Combine(localStorageRoot, storyID + ".xml");
                            xdoc.Save(configFilePath, SaveOptions.None);

                            // Encode the video.
                            string outputFilePath = Path.Combine(localStorageRoot, storyID + ".mp4");
                            string logFilePath = Path.Combine(diagnosticsRoot, storyID + ".log");
                            int hr = NativeMethods.EncoderVideo(configFilePath, outputFilePath, logFilePath);
                            if (hr != 0)
                            {
                                Trace.Write("Error when encoding the story " + storyID + ". HRESULT from the native component is: " + hr + ".", "Error");
                            }
                            else
                            {
                                // Upload the result video to blob.
                                string blobName = storyID + "/";
                                blobName += string.IsNullOrEmpty(storyName) ? storyID : storyName;
                                blobName += ".mp4";
                                CloudBlob outputBlob = this._container.GetBlobReference(blobName);
                                outputBlob.UploadFile(outputFilePath);
                                outputBlob.Properties.ContentType = "video/mp4";
                                outputBlob.SetProperties();

                                StoryDataContext storyDataContext = new StoryDataContext(
                                    this._storageAccount.TableEndpoint.AbsoluteUri,
                                    this._storageAccount.Credentials);
                                storyDataContext.AddObject("Stories", new Story(storyID, storyName, outputBlob.Uri.AbsoluteUri));
                                storyDataContext.SaveChanges();

                                // Delete the local files.
                                File.Delete(configFilePath);
                                File.Delete(outputFilePath);
                                foreach (string fileName in Directory.GetFiles(storyFolderPath))
                                {
                                    File.Delete(fileName);
                                }
                                Directory.Delete(storyFolderPath);

                                this._queue.DeleteMessage(message);

                                // TODO: Should we delete the story's config file and photos from blob?

                                Trace.Write("Story " + storyID + " successfully encoded.", "Information");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.Write("Error processing story: " + ex.Message);
                }

                Thread.Sleep(10000);
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            // Intilialize the storage if they haven't been intialized already.
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
            });
            this._storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            CloudBlobClient blobClient = new CloudBlobClient(this._storageAccount.BlobEndpoint, this._storageAccount.Credentials);
            this._container = blobClient.GetContainerReference("videostories");
            this._container.CreateIfNotExist();
            this._container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });
            CloudQueueClient queueClient = new CloudQueueClient(this._storageAccount.QueueEndpoint, this._storageAccount.Credentials);
            this._queue = queueClient.GetQueueReference("videostories");
            this._queue.CreateIfNotExist();
            CloudTableClient tableClient = new CloudTableClient(this._storageAccount.TableEndpoint.AbsoluteUri, this._storageAccount.Credentials);
            tableClient.CreateTableIfNotExist("Stories");

            // Configure dianostics.
            var config = DiagnosticMonitor.GetDefaultInitialConfiguration();
            config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(10d);
            config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(10d);
            config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(10d);
            config.Directories.DataSources.Add(new DirectoryConfiguration()
            {
                Path = RoleEnvironment.GetLocalResource("DiagnosticStore").RootPath,
                Container = "videostorydiagnosticstore",
                DirectoryQuotaInMB = 200
            });
            config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(10d);
            Microsoft.WindowsAzure.Diagnostics.CrashDumps.EnableCollection(true);
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", config);
            RoleEnvironment.Changing += new EventHandler<RoleEnvironmentChangingEventArgs>(RoleEnvironment_Changing);

            return base.OnStart();
        }

        private void RoleEnvironment_Changing(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.OfType<RoleEnvironmentConfigurationSettingChange>().Count() > 0)
            {
                e.Cancel = true;
            }
        }
    }
}
