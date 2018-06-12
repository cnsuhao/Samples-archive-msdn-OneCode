/****************************** Module Header ******************************\
* Module Name: Program.cs
* Project:     TestClient
* Copyright (c) Microsoft Corporation.
* 
* This project is designed for verifying the SAS token here.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Token formate should like this: "?se=2013-09-28T14%3A35%3A34Z&sr=c&sp=rwdl&sig=GHnBW...";
            string sasToken = "YOUR SAS TOKEN";
            string accountName = "YOU STORAGE ACCOUNT NAME";

            // First create a File in Azure storage container

            Uri blobUri = new Uri(string.Format("https://{0}.blob.core.windows.net/generateazuretablesas/myblob.txt",accountName));
            Uri blobUri1 = new Uri(string.Format("https://{0}.blob.core.windows.net/generateazuretablesas/myblob1.txt", accountName));
            Uri containerUri = new Uri(string.Format("https://{0}.blob.core.windows.net/generateazuretablesas/", accountName));

            // Create credentials with the SAS token. The SAS token was created in previous example.
            StorageCredentials credential = new StorageCredentials(sasToken);

            CreateBlob(blobUri, credential);
            CreateBlob(blobUri1, credential);
            WriteBlob(blobUri, credential);
            DeleteBlob(blobUri, credential);
            ListBlobs(containerUri, credential);
            Console.ReadLine();
        }

        static void CreateBlob(Uri blobUri, StorageCredentials credential)
        {
            // Create a new blob.
            CloudBlockBlob blob = new CloudBlockBlob(blobUri, credential);
            try
            {
                // Upload the blob. 
                // If the blob does not yet exist, it will be created. 
                // If the blob does exist, its existing content will be overwritten.
                var fileStream = generateStreamFromString("This is a new text file create by TestClient");
                    blob.UploadFromStream(fileStream);
                    Console.WriteLine("Create blob successfully! Blob URI:\n{0} ", blobUri.ToString());
                
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                Console.WriteLine("Create blob failed, please check your credential, make sure it's right.");
               
            }
            
        }

        static void WriteBlob(Uri blobUri, StorageCredentials credential)
        {
            // Write an exist blob.
            CloudBlockBlob blob = new CloudBlockBlob(blobUri, credential);
            try
            {
                
                using (Stream stream = blob.OpenWrite())
                {
                    string line="this is a new line over written by WriteBlob method";
                    byte[] buffer = Encoding.Default.GetBytes(line);  
                    stream.Write(buffer,0, buffer.Length);
                }
                Console.WriteLine("Write blob successfully! Blob URI:\n{0}", blobUri.ToString());
                
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine("Write blob failed, please check your credential, make sure it's right.");
            }
        }

        static void DeleteBlob(Uri blobUri, StorageCredentials credential)
        {
            CloudBlockBlob blob = new CloudBlockBlob(blobUri, credential);
            try
            {
                if (blob.DeleteIfExists())
                {
                    Console.WriteLine("Delete Blob successfully! Blob URI:\n{0}", blobUri.ToString());
                }
                else
                {
                    Console.WriteLine("The blob doens't exist. Blob URI:\n{0}", blobUri.ToString());
                }
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                Console.WriteLine("Delete blob failed, please check your credential, make sure it's right.");
            }
        }

        static void ListBlobs(Uri containerUri, StorageCredentials credential)
        {
            Console.WriteLine("List contianer start");
            try
            {
                CloudBlobContainer container = new CloudBlobContainer(containerUri, credential);
                foreach (var item in container.ListBlobs(null, true))
                {
                    
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
                    }
                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob pageBlob = (CloudPageBlob)item;
                        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory directory = (CloudBlobDirectory)item;
                        Console.WriteLine("Directory: {0}", directory.Uri);
                    }
                }
                Console.WriteLine("List container successfully!");
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                Console.WriteLine("List blobs failed, please check your credential, make sure it's right.");
            }    
        }       

        static Stream generateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
