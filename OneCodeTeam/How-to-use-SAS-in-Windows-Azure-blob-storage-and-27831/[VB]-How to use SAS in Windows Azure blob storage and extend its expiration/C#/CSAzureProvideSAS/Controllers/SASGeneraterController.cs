/****************************** Module Header ******************************\
* Module Name: SASGeneraterController.cs
* Project:     SASGeneraterController
* Copyright (c) Microsoft Corporation.
* 
* To secure your Windows Azure storage, you need to generate SAS token to assign 
* user permission for CRUD. This sample will demonstrate how to generate SAS
* by using Web API, and get the SAS from client.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace CSAzureProvideSAS.Controllers
{
    public class SASGeneraterController : ApiController
    {
 
        string storageAccountName = "<Storage Account>";
        string storageAccountKey = "<Storage Key>";
        string tableName = "<Storage Table Name>";

        // Post api/SASGenerater/PatitionKey
        public string Post([FromBody] string partitionKey)
        {
            StorageCredentials credentials = new StorageCredentials(storageAccountName, storageAccountKey);
            CloudStorageAccount account = new CloudStorageAccount(credentials, true);
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference(tableName);

            SharedAccessTablePolicy policy = new SharedAccessTablePolicy()
            {

                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(
                300.00),
                Permissions = SharedAccessTablePermissions.Add
                    | SharedAccessTablePermissions.Query
                    | SharedAccessTablePermissions.Update
                    | SharedAccessTablePermissions.Delete
            };

            string sasToken = table.GetSharedAccessSignature(policy, null, partitionKey, null, partitionKey, null);
            return sasToken;         
        }
    }
}
