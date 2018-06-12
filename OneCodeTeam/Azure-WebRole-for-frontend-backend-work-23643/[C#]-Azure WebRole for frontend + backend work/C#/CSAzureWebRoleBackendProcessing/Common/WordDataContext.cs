/****************************** Module Header ******************************\
* Project Name:   CSAzureWebRoleBackendProcessing
* Module Name:    Common
* File Name:      WordDataContext.cs
* Copyright (c) Microsoft Corporation
*
* This class represents a System.Data.Services.Client.DataServiceContext object 
* for use with the Windows Azure Table service.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace CSAzureWebRoleBackendProcessing.Common
{
    public class WordDataContext : TableServiceContext
    {
        public WordDataContext(CloudTableClient client)
            : base(client)
        { }

        public IQueryable<WordEntry> WordEntry
        {
            get
            {
                return this.CreateQuery<WordEntry>("WordEntry");
            }
        }
    }
}