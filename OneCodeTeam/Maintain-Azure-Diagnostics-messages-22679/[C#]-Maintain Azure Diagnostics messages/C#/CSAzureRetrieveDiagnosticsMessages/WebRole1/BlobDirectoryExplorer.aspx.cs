/****************************** Module Header ******************************\
Module Name:  BlobTextViewer.aspx.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 

This page show the blob storage structure.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public partial class BlobDirectoryExplorer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var statusMessage = string.Empty;
                try
                {
                    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    CloudBlobClient blobClient = account.CreateCloudBlobClient();
                    CloudBlobContainer rootContainer = blobClient.GetContainerReference("/");

                    TreeNode node = new TreeNode("Root");
                    node.Value = rootContainer.Uri.ToString();

                    var containers = blobClient.ListContainers();

                    // Create sub node to treeview.
                    foreach (CloudBlobContainer BlobContainer in containers)
                    {
                        TreeNode containerNode = new TreeNode(BlobContainer.Name);
                        containerNode.Value = BlobContainer.Uri.ToString();
                        node.ChildNodes.Add(containerNode);

                        IEnumerable<IListBlobItem> blobItems = BlobContainer.ListBlobs();

                        foreach (IListBlobItem blobItem in blobItems)
                        {
                            if (blobItem is CloudBlobDirectory)
                                this.CreatTreeNodeItem(containerNode, blobItem as CloudBlobDirectory);
                            else
                                this.CreatTreeNodeItem(containerNode, blobItem as CloudBlob);
                        }
                    }

                    this.tvBlobDirectory.Nodes.Add(node);

                }
                catch (System.IO.PathTooLongException pathTooLongEx)
                {
                    statusMessage = pathTooLongEx.Message;
                }
                catch (Exception ex)
                {
                    statusMessage = "Unable to connect to the table storage server. Please check that the service is running.<br>"
                                     + ex.Message;
                }
                this.status.Text = statusMessage;
            }
        }

        /// <summary>
        /// Create blob structure treeview.
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="BlobItem"></param>
        private void CreatTreeNodeItem(TreeNode Node, object BlobItem)
        {
            TreeNode subNode = null;
            if (BlobItem is CloudBlobDirectory)
            {
                CloudBlobDirectory blobDirectory = BlobItem as CloudBlobDirectory;

                string[] path = Path.GetDirectoryName(blobDirectory.Uri.AbsolutePath).Split(new string[] { "%20", @"\" }, StringSplitOptions.RemoveEmptyEntries);
                subNode = new TreeNode(path[path.Length - 1]);
                subNode.Value = blobDirectory.Uri.ToString();
                

                IEnumerable<IListBlobItem> blobItems = blobDirectory.ListBlobs();

                foreach (var Item in blobItems)
                {
                    if (Item is CloudBlobDirectory)
                    {
                        CreatTreeNodeItem(subNode, Item as CloudBlobDirectory);

                    }
                    else
                    {
                        CreatTreeNodeItem(subNode, Item as CloudBlob);
                    }
                }
            }

            else
            {
                CloudBlob Item = BlobItem as CloudBlob;

                subNode = new TreeNode(Path.GetFileName(Item.Uri.AbsolutePath) + "-" + Item.Uri.AbsoluteUri);
                subNode.Value = Item.Uri.ToString();                               
                subNode.NavigateUrl = "~/BlobTextViewer.aspx?containerName=" + Item.Container.Name
                                    + "&blobFileName=" + Item.Name;
            }
            Node.ChildNodes.Add(subNode);
        }
    }
}