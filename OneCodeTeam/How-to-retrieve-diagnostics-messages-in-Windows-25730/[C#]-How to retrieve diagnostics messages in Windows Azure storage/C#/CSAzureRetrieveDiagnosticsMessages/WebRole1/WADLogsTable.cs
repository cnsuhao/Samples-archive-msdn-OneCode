/****************************** Module Header ******************************\
Module Name:  WADLogsTable.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 
WADLogsTable entity, in this example, we defined this entity
for Windows Azure logs which store in Azure Table storage WADLogsTable.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class WADLogsTable
        : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    {
        public string Message { get; set; }

        public Int64 EventTickCount { get; set; }

        public string DeploymentId { get; set; }

        public string Role { get; set; }

        public string RoleInstance { get; set; }

        public int Level { get; set; }

        public int EventId { get; set; }

        public int Pid { get; set; }

        public int Tid { get; set; }
    }
}