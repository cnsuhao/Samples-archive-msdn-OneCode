/****************************** Module Header ******************************\
Module Name:  BlobTextViewer.aspx.cs
Project:      CSAzureRetrieveDiagnosticsMessages
Copyright (c) Microsoft Corporation.
 
This programe will show you how to retrieve diagnostics message and transfer them 
to Azure storage. And also it will show you how to view both logs in Table and logs
in blob.
 

This page shows the xml message in the blob log file.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Threading;
using System.IO;
using System.Text;

namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public partial class BlobTextViewer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["containerName"] != null && Request.QueryString["blobFileName"] != null)
            {
                string containerName = Request.QueryString["containerName"].ToString();
                string blobFileName = Request.QueryString["blobFileName"].ToString();
                try
                {
                    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    CloudBlobClient blobClient = account.CreateCloudBlobClient();

                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                    CloudBlob cloudBlob = blobContainer.GetBlobReference(blobFileName);

                    string text = cloudBlob.DownloadText();
                    StringWriter stringWriter = new StringWriter();
                    stringWriter.WriteLine(text);
                    Response.ContentType = "text/plain";
                    Response.AddHeader("Content-disposition", "attachment; filename="+blobFileName+".txt");
                    Response.Clear();
                    using (StreamWriter writer = new StreamWriter(Response.OutputStream, Encoding.UTF8))
                    {
                        writer.Write(stringWriter.ToString());
                    }
                    Response.End();
                }
                //Response.End() will cause this exception. Should be ignore.
                catch(ThreadAbortException ex)
                {
                }
                catch
                {
                    Response.Write("This blob file isn't a valiable text file.");
                }

            }
            else
            {
                Response.Write("Please choose right file in BlobDirectoryExplorer.aspx");
            }    
        }
  
    }

    
}