/****************************** Module Header ******************************\
Module Name:  Content.aspx.cs
Project:      CSASPNETCompressFilesIntoSingleZip
Copyright (c) Microsoft Corporation.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;  

namespace CSASPNETCompressFilesIntoSingleZip
{
    public partial class Content : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Listing the files in the gridview. Folder path is confiigured in web.config
            if (!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString()));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    files.Add(new ListItem(Path.GetFileName(filePath), filePath));

                }
                gdvFolderContents.DataSource = files;
                gdvFolderContents.DataBind();
            }
            
             
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {            
            List<string> filesToCompress = new List<string>();

            foreach (GridViewRow gdvRow in gdvFolderContents.Rows)
            {
                CheckBox chkSelectedTemp = new CheckBox();
                chkSelectedTemp = (CheckBox)gdvRow.FindControl("chkSelect");
                if (chkSelectedTemp != null && chkSelectedTemp.Checked == true)
                {
                    filesToCompress.Add(gdvRow.Cells[2].Text);
                }
            }

            if (filesToCompress.Count > 0)
            {
                //Creating Object of class to compress and download as a zip
                CompressionArchive CompressSelectedFiles = new CompressionArchive();

                // Compress to a zip file
                CompressSelectedFiles.CompressToZipArchive(filesToCompress);

                Cache["TempFileName"] = CompressSelectedFiles.TempZipFilePath; 

                // Sends the Zip over HTTP
                CompressSelectedFiles.DownloadFile();

            }

        }
    }
}