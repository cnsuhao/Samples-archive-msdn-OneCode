/****************************** Module Header ******************************\
Module Name:  FileEntity.cs
Project:      TableStorageManager
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to backup Azure Storage in Cloud. Though 
Windows Azure Platform have 3 copies for our data, but this is only physical
backup, if a logical errors occurred that all copies of storage would been
modified, so this sample shows how to protect our important data with code.

This is a table storage entity class, it includes some basic properties:
FileName,
FileUrl

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;

namespace TableStorageManager
{
    public class FileEntity : TableServiceEntity
    {
        /// <summary>
        /// No parameters constructor
        /// </summary>
        public FileEntity()
        {
            PartitionKey = "all";
            RowKey = string.Format("{0:10}-{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid()).Replace("-", "");
        }

        /// <summary>
        /// With parameters constructor
        /// </summary>
        /// <param name="partitionKey"></param>
        public FileEntity(string partitionKey)
        {
            PartitionKey = partitionKey;
            RowKey = string.Format("{0:10}-{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid()).Replace("-", "");
        }

        public string FileName
        {
            get;
            set;
        }

        public string FileUrl
        {
            get;
            set;
        }
    }
}
