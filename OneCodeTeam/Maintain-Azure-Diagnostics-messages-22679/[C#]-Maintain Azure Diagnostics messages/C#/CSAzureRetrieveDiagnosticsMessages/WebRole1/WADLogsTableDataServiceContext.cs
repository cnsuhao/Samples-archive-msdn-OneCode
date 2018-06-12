/****************************** Module Header ******************************\
Module Name:  WADLogsTableDataServiceContext.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.

This WCF service will return a queryable collection.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class WADLogsTableDataServiceContext
        : TableServiceContext
    {
        public WADLogsTableDataServiceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }


        public IQueryable<WADLogsTable> WADLogs
        {
            get
            {
                return this.CreateQuery<WADLogsTable>("WADLogsTable");
            }
        }
    }
}
