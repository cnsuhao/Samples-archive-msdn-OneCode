/****************************** Module Header ******************************\
* Module Name:	Global.cs
* Project: StoryCreatorWebRole
* Copyright (c) Microsoft Corporation.
* 
* The Global.asax file. Used to initialize Azure storage.
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
using System.Web.Routing;
using Microsoft.ApplicationServer.Http.Activation;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace StoryCreatorWebRole
{
    public class Global : System.Web.HttpApplication
    {
        internal static CloudStorageAccount StorageAccount;

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapServiceRoute<StoryService>("stories");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeStorage();
        }

        /// <summary>
        /// Intitialize the Azure storage.
        /// If not running in Compute Emulator or the cloud,
        /// we use Storage Emulator.
        /// Supress CA2122 as RoleEnvironment.IsAvailable should not introduce any security issues.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static bool InitializeStorage()
        {
            try
            {
                // For test purpose only, if we do not run the service in compute emulator, we always use dev storage.
                if (RoleEnvironment.IsAvailable)
                {
                    CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                    {
                        configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
                    });
                    StorageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                }
                else
                {
                    StorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
                }

                CloudBlobClient blobClient = new CloudBlobClient(StorageAccount.BlobEndpoint, StorageAccount.Credentials);
                CloudBlobContainer container = blobClient.GetContainerReference("videostories");
                container.CreateIfNotExist();
                CloudQueueClient queueClient = new CloudQueueClient(StorageAccount.QueueEndpoint, StorageAccount.Credentials);
                CloudQueue queue = queueClient.GetQueueReference("videostories");
                queue.CreateIfNotExist();
                CloudTableClient tableClient = new CloudTableClient(StorageAccount.TableEndpoint.AbsoluteUri, StorageAccount.Credentials);
                tableClient.CreateTableIfNotExist("Stories");
                return true;
            }
            catch (Exception ex)
            {
                Trace.Write("Error initializing storage: " + ex.Message, "Error");
                return false;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}