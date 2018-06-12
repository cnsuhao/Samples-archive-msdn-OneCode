/**************************** Module Header ********************************\
* Module Name:    BlobStorageHelper.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* BlobStorageHelper Class.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

public class BlobStorageHelper
{
    public static async Task UploadBlob(Stream fileStream, string fileName, string blobUrl, string containerName)
    {
        fileStream.Position = 0;

        var sasUri = new Uri(blobUrl);

        //// Our credential for the upload is our SAS token 
        StorageCredentials cred = new StorageCredentials(sasUri.Query.Substring(1));

        CloudBlobContainer container = new CloudBlobContainer(new Uri(string.Format("https://{0}/{1}", sasUri.Host, containerName)), cred);

        CloudBlockBlob blobFromSASCredential = container.GetBlockBlobReference(fileName);
        await blobFromSASCredential.UploadFromStreamAsync(fileStream);
    }
}