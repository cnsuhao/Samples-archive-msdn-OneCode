/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      ServeFilesFromBlobStorageWebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates a way to serve files from storage via a web role.
A file from blob storage(such as http://xxx.cloudapp.net/files/File1) can be
reached as the normal files in your application by relative path ("files/File1").
And this http module can also filter some specify types files.

The page is used to show some link examples.

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
using System.Text;

namespace ServeFilesFromBlobStorageWebRole
{
    public partial class Default : System.Web.UI.Page
    {
        private static CloudStorageAccount account;
        public string embedString = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                account = CloudStorageAccount.FromConfigurationSetting("StorageConnections");
                FileDataSource source = new FileDataSource();
                IEnumerable<FileEntity> list = source.GetAllEntities();
                StringBuilder sb = new StringBuilder();
                if (list.Count() > 0)
                {
                    sb.Append("Then please check them: <br />");
                    foreach (FileEntity entity in list)
                    {
                        sb.Append("<a href='File/");
                        sb.Append(entity.FileName);
                        sb.Append("' target='_blank'>");
                        sb.Append(entity.FileName);
                        sb.Append("</a>");
                        sb.Append("<br />");
                    }

 
                }
                sb.Append("<a href='HTMLSamoke.htm' target='_blank' >HTML resource (No available)</a><br />");
                sb.Append("<a href='HTMLSamoke.jpg' target='_blank' >HTML resource (No resources)</a>");
                embedString = sb.ToString();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileUploadPage.aspx");
        }
    }
}