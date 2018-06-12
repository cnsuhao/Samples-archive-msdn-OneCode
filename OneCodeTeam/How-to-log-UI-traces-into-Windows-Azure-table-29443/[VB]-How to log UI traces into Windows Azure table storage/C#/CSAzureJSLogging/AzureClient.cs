/****************************** Module Header ******************************\
* Module Name: HomeController.cs
* Project:     CSAzureJSLogging
* Copyright (c) Microsoft Corporation
*
* HomeController
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace CSAzureJSLogging
{
    public class AzureClient
    {
       
        public static CloudStorageAccount StorageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("{Your-Storage-Account}", "{Your-Storage-Acccount-Key}"), false);

        /// <summary>
        /// Enable Table Service CORS
        /// Make sure log table can be use.
        /// </summary>
        public static void TableServiceInitialization() 
        {
            CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();

            // Aslo check the log table make sure it has been created.
            CloudTable table = tableClient.GetTableReference("log");
            table.CreateIfNotExists();
            ServiceProperties tableServiceProperties = new ServiceProperties();
            tableServiceProperties.HourMetrics = null;
            tableServiceProperties.MinuteMetrics = null;
            tableServiceProperties.Logging = null;

            // Enable and Configure CORS
            ConfigureCors(tableServiceProperties);
            tableClient.SetServiceProperties(tableServiceProperties);
        }

        /// <summary>
        /// Adds CORS rule to the service properties.
        /// </summary>
        /// <param name="serviceProperties">ServiceProperties</param>
        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List<string>() { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }
    }
}