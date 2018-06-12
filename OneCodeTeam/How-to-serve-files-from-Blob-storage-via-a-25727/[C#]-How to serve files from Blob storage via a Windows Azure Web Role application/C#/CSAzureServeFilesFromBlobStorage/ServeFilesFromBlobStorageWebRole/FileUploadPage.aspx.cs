/****************************** Module Header ******************************\
Module Name:  FileUploadPage.aspx.cs
Project:      ServeFilesFromBlobStorageWebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates a way to serve files from storage via a web role.
A file from blob storage (such as http://xxx.cloudapp.net/files/File1) can be 
reached as the normal files in your application by relative path ("files/File1"). 
And this http module can also filter some files of specific types. 

This page is used to upload some existing resources. It requires your
cloud account and key.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using TableStorageManager;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;

namespace ServeFilesFromBlobStorageWebRole
{
    public partial class FileUploadPage : System.Web.UI.Page
    {
        private static CloudStorageAccount account;
        public List<FileEntity> files = new List<FileEntity>();
        protected void Page_Load(object sender, EventArgs e)
        {
            account = CloudStorageAccount.FromConfigurationSetting("StorageConnections");
        }

        /// <summary>
        /// Upload existing resources. ("Files" folder)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            FileDataSource source = new FileDataSource();
            List<string> nameList = new List<string>() { "Files/Microsoft.jpg", "Files/MSDN.jpg", "Files/Site.css" };
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("container");
            container.CreateIfNotExist();
            var permission = container.GetPermissions();
            permission.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permission);
            bool flag = false;
            
            foreach (string name in nameList)
            {
                if (name.Substring(name.LastIndexOf('.') + 1).Equals("jpg") && File.Exists(Server.MapPath(name)))
                {
                    if (!source.FileExists(name, "image"))
                    {
                        flag = true;
                        CloudBlob blob = container.GetBlobReference(name);
                        blob.UploadFile(Server.MapPath(name));

                        FileEntity entity = new FileEntity("image");
                        entity.FileName = name;
                        entity.FileUrl = blob.Uri.ToString();
                        source.AddFile(entity);
                        lbContent.Text += String.Format("The image file {0} is uploaded successfully. <br />", name);
                    }
                }
                else if (name.Substring(name.LastIndexOf('.') + 1).Equals("css") && File.Exists(Server.MapPath(name)))
                {
                    if (!source.FileExists(name, "css"))
                    {
                        flag = true;
                        CloudBlob blob = container.GetBlobReference(name);
                        blob.UploadFile(Server.MapPath(name));

                        FileEntity entity = new FileEntity("css");
                        entity.FileName = name;
                        entity.FileUrl = blob.Uri.ToString();
                        source.AddFile(entity);
                        lbContent.Text += String.Format("The css file {0} is uploaded successfully. <br />", name);
                    }
                }
            }

            if (!flag)
            {
                lbContent.Text = "You have uploaded these resources";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}