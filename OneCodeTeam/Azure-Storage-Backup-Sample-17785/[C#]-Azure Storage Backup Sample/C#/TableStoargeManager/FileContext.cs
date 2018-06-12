/****************************** Module Header ******************************\
Module Name:  FileContext.cs
Project:      TableStorageManager
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to backup Azure Storage in Cloud. Though 
Windows Azure Platform have 3 copies for our data, but this is only physical
backup, if a logical errors occurred that all copies of storage would been
modified, so this sample shows how to protect our important data with code.

The FileContext class is used to create queries for table services. You can 
also add paging method for table storage.

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
using Microsoft.WindowsAzure;

namespace TableStorageManager
{
    public class FileContext : TableServiceContext
    {
        public FileContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {

        }

        /// <summary>
        /// Get all entities of table storage "files".
        /// </summary>
        public IEnumerable<FileEntity> GetEntities
        {
            get
            {
                var list = this.CreateQuery<FileEntity>("files");
                return list;
            }
        }

        /// <summary>
        /// Get all entities of table storage "files_backup".
        /// </summary>
        public IEnumerable<FileEntity> GetBackupEntities
        {
            get
            {
                var list = this.CreateQuery<FileEntity>("files_backup");
                return list;
            }
        }
    }
}
