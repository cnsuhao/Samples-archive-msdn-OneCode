/****************************** Module Header ******************************\
* Project Name:   CSAzureWebRoleBackendProcessing
* Module Name:    Common
* File Name:      WordEntry.cs
* Copyright (c) Microsoft Corporation
*
* This class represents an entity in Table storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;

using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace CSAzureWebRoleBackendProcessing.Common
{
    public class WordEntry : TableServiceEntity
    {
        public WordEntry()
        {
            PartitionKey = "";
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        public string Content { get; set; }
        public bool IsProcessed { get; set; }
    }
}