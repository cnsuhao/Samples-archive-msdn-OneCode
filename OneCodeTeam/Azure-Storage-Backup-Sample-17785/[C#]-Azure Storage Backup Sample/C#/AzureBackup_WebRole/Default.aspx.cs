/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      AzureBackup_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to backup Azure Storage in Cloud. Though 
Windows Azure Platform have 3 copies for our data, but this is only physical
backup, if a logical errors occurred that all copies of storage would been
modified, so this sample shows how to protect our important data with code.

This page is used to help your backup your data in blob storage and table 
storage. Click upload button to upload sample data in storage, then input
your source storage and copies storage (Blob container or table) in related 
TextBox control, then you can view them with REST Service or tools (Azure
Storage Explorer or Server Explorer).

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
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using TableStorageManager;
using Microsoft.WindowsAzure.StorageClient;
using System.Net;
using System.Data.Services.Client;

namespace AzureBackup_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        private CloudStorageAccount account;
        List<string> nameList = new List<string>() { "MSDN.jpg", "Microsoft.jpg" };
        protected void Page_Load(object sender, EventArgs e)
        {
            lbBackup.Text = string.Empty;
            lbContent.Text = string.Empty;
            account = CloudStorageAccount.FromConfigurationSetting("StorageConnections");
        }

        /// <summary>
        /// Upload resources to Storage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                FileDataSource source = new FileDataSource("files");
                CloudBlobClient client = account.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference("blob");
                container.CreateIfNotExist();
                var permission = container.GetPermissions();
                permission.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permission);
                bool flag = false;

                foreach (string name in nameList)
                {
                    if (!source.FileExists(name, "image"))
                    {
                        flag = true;
                        CloudBlob blob = container.GetBlobReference(name);
                        string path = string.Format("{0}/{1}", "Files", name);
                        blob.UploadFile(Server.MapPath(path));

                        FileEntity entity = new FileEntity("image");
                        entity.FileName = name;
                        entity.FileUrl = blob.Uri.ToString();
                        source.AddFile(entity);
                        lbContent.Text += String.Format("The image file {0} is uploaded successes. <br />", name);
                    }
                }
                if (!flag)
                    lbContent.Text = "You had uploaded these resources. The blob container name is 'blob', table name is 'files'";
                else
                    lbContent.Text += "The blob container name is 'blob', The table name is 'files'";
            }
            catch (Exception ex)
            {
                lbContent.Text = ex.Message;
            }
        }



        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbSource.Text.Trim().Equals(string.Empty) && tbCopies.Text.Trim().Equals(string.Empty))
                {
                    lbBackup.Text = "Source TextBox and Copies TextBox can not be empty";
                    return;
                }

                string sourceContainerName = tbSource.Text.Trim();
                string copiesContainerName = tbCopies.Text.Trim();
                CloudBlobClient client = account.CreateCloudBlobClient();

                CloudBlobContainer sourceContainer = client.GetContainerReference(sourceContainerName);
                if (!StorageManager.CheckIfExists(sourceContainer))
                {
                    lbBackup.Text = "The source blob container is not exists";
                    return;
                }
                CloudBlobContainer copiesContainer = client.GetContainerReference(copiesContainerName);
                copiesContainer.CreateIfNotExist();
                var permission = copiesContainer.GetPermissions();
                permission.PublicAccess = BlobContainerPublicAccessType.Container;
                copiesContainer.SetPermissions(permission);


                foreach (var blob in sourceContainer.ListBlobs())
                {
                    string uri = blob.Uri.AbsolutePath;
                    string[] matches = new string[] { "blob/" };
                    string FileName = uri.Split(matches, StringSplitOptions.None)[1].Substring(0);
                    CloudBlob sourceBlob = sourceContainer.GetBlobReference(FileName);
                    CloudBlob copiesBlob = copiesContainer.GetBlobReference(FileName);
                    copiesBlob.CopyFromBlob(sourceBlob);
                    lbBackup.Text += String.Format("The image file {0} is backup successes. Copies container name is {1} <br />", FileName, copiesContainerName);
                }
            }
            catch (StorageClientException ex)
            {
                if (ex.ExtendedErrorInformation.ErrorCode.Equals("OutOfRangeInput"))
                    lbBackup.Text = "Please check your blob container name.";
                else
                    lbBackup.Text = ex.Message;
            }
            catch (Exception all)
            {
                lbBackup.Text = all.Message;
            }
        }



        protected void btnBackupTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTabelSource.Text.Trim().Equals(string.Empty) && tbTableCopies.Text.Trim().Equals(string.Empty))
                {
                    lbBackupTable.Text = "Source TextBox and Copies TextBox can not be empty";
                    return;
                }

                string sourceTableName = tbTabelSource.Text.Trim();
                string copiesTableName = tbTableCopies.Text.Trim();
                CloudTableClient client = account.CreateCloudTableClient();


                if (!client.DoesTableExist(sourceTableName))
                {
                    lbBackupTable.Text = "The source table is not exists";
                    return;
                }

                FileDataSource tableDataSource = new FileDataSource(sourceTableName);
                List<FileEntity> sourceList = tableDataSource.GetAllEntities().ToList<FileEntity>();
                client.DeleteTableIfExist(copiesTableName);
                FileDataSource tableDataCopies = new FileDataSource(copiesTableName);
                tableDataCopies.AddNumbersOfFiles(sourceList);
                lbBackupTable.Text = String.Format("The source table {0} is backup successes. Copies table name is {1}", sourceTableName, copiesTableName);
            }
            catch (StorageClientException ex)
            {
                if (ex.ExtendedErrorInformation.ErrorCode.Equals("OutOfRangeInput"))
                    lbBackupTable.Text = "Please check your blob container name.";
                else
                    lbBackupTable.Text = ex.Message;
            }
            catch (Exception all)
            {
                lbBackupTable.Text = all.Message;
            }
        }
    }
}