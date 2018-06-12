/****************************** Module Header ******************************\
* Module Name: TableSASController.cs
* Project:     CSAzureJSLogging
* Copyright (c) Microsoft Corporation
*
* TableSASController
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
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Globalization;
using System.Web.Http;

namespace CSAzureJSLogging.Controllers
{
    /// <summary>
    /// SAS Entity
    /// </summary>
    public class SAS
    {
        private string sasTokenUrl;

        public string SASTokenUrl
        {
            get { return sasTokenUrl; }
            set { sasTokenUrl = value; }
        }
        
    }

    public class TableSASController : ApiController
    {
        private CloudStorageAccount account = AzureClient.StorageAccount;

        //Get api/tablesas
        public SAS Get()
        {           
            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("log");
            table.CreateIfNotExists();
            SAS s=new SAS();
            s.SASTokenUrl=GetSasForTable(table);

            return s;
        }

        /// <summary>
        /// Generate a table SAS
        /// </summary>
        /// <param name="table">CloudTable</param>
        /// <returns>The SAS string for the CloudTable specified</returns>
        private static string GetSasForTable(CloudTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("Table can't be null");
            }

            string sas = table.GetSharedAccessSignature(
                new SharedAccessTablePolicy()
                {
                    Permissions = SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Add | SharedAccessTablePermissions.Delete,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
                },
                null, /* accessPolicyIdentifier */
                null, /* startPartitionKey */
                null, /* startRowKey */
                null, /* endPartitionKey */
                null);  /* endRowKey */

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", table.Uri, sas);
        }
        
    }
}
