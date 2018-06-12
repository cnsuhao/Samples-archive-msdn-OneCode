/****************************** Module Header ******************************\
Module Name:  InstanceControllerService.cs
Project:      WorkerRole1
Copyright (c) Microsoft Corporation.
 
This application shows how to run your cmd script or other executable
file on each worker role instance.

Implement the WCF contract.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using InstanceController.Interface;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Diagnostics;
using System.ServiceModel;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;


namespace WorkerRole1
{
    public class InstanceControllerService:IInstanceController
    {
        /// <summary>
        /// Store temp file path
        /// </summary>
        private string _filePath = null;

        /// <summary>
        /// Get every instance internal endpoint.
        /// </summary>
        /// <returns></returns>
        public List<string> GetInstanceInternalEndPoint()
        {
            List<string> EndPointList = new List<string>();
            Trace.Write("Method start");
            var workerInstances = RoleEnvironment.Roles["WorkerRole1"].Instances;
            Trace.Write(string.Format("This App has {0} instance", workerInstances.Count));
            try
            {
                foreach (var instance in workerInstances)
                {
                    EndPointList.Add(instance.InstanceEndpoints["InternalEndPoint"].IPEndpoint.ToString());
                }
                return EndPointList;
            }
            catch (Exception e)
            {

                EndPointList.Add(e.ToString());
                return EndPointList;
            }
            
        }

        /// <summary>
        /// Use this method run the file on your each instance
        /// </summary>
        /// <param name="Container"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool RunScriptOnEveryInstance(string Container,string FileName)
        {
            var internalEndpointList = GetInstanceInternalEndPoint();
            try
            {
                foreach (var internalEndpoint in internalEndpointList)
                {

                    BasicHttpBinding binding = new BasicHttpBinding();
                    using (ChannelFactory<IInstanceController> channel = new ChannelFactory<IInstanceController>(binding, string.Format("http://{0}/InternalService", internalEndpoint)))
                    {
                        IInstanceController proxy = channel.CreateChannel();
                        proxy.RunExecutableFile(Container, FileName);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                //TODO: Add your logic here.
                return false;
            }   
        }

        /// <summary>
        /// Download the file from blob storage, then excute it in local.
        /// </summary>
        /// <param name="Container">blob container name</param>
        /// <param name="FileName">file name</param>
        public void RunExecutableFile(string Container, string FileName)
        {
            DownLoadFileFromBlob(Container, FileName);
            if (_filePath != null)
            {
                try
                {
                    System.Diagnostics.Process.Start(_filePath);
                    
                }
                catch
                {
                    throw new NotSupportedException("The file is not a excutable file");
                }
            }
            else
            {
                throw new NullReferenceException("Can't get the file from blob.");
            }
        }

        /// <summary>
        /// Download the file from blob storage, and store the temp file path.
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <param name="FileName"></param>
        public void DownLoadFileFromBlob(string ContainerName, string FileName)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
            string directoryPath = CreateTempDirectory();
            _filePath = directoryPath + "\\" + FileName;
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(_filePath))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        /// <summary>
        /// Create a Temp file path to store the file download from blob.
        /// </summary>
        /// <returns>temp path</returns>
        private string CreateTempDirectory()
        {
            while (true)
            {
                string path = Path.GetRandomFileName();
                string directoryPath = Path.Combine(Path.GetTempPath(), path);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Directory.CreateDirectory(path);
                    return directoryPath;
                }
            }
        } 
    }
}
