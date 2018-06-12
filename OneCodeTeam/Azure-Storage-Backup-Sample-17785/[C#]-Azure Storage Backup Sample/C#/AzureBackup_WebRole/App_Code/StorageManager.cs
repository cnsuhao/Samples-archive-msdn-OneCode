/****************************** Module Header ******************************\
Module Name:  StorageManager.cs
Project:      AzureBackup_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to backup Azure Storage in Cloud. Though 
Windows Azure Platform have 3 copies for our data, but this is only physical
backup, if a logical errors occurred that all copies of storage would been
modified, so this sample shows how to protect our important data with code.

The StorageManager class is used to check BlobContainer and Blob is exists.

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
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureBackup_WebRole
{
    public class StorageManager
    {
        /// <summary>
        /// Check CloudBlobContainer is exists.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static bool CheckIfExists(CloudBlobContainer container)
        {
            try
            {
                container.FetchAttributes();
                return true;
            }
            catch (StorageClientException e)
            {
                if (e.ErrorCode == StorageErrorCode.ResourceNotFound)
                    return false;
                else
                    throw;
            }
        }

        /// <summary>
        /// Check CloudBlob is exists.
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        public static bool CheckIfExists(CloudBlob blob)
        {
            try
            {
                blob.FetchAttributes();
                return true;
            }
            catch (StorageClientException e)
            {
                if (e.ErrorCode == StorageErrorCode.ResourceNotFound)
                    return false;
                else
                    throw;
            }
        }
    }
}