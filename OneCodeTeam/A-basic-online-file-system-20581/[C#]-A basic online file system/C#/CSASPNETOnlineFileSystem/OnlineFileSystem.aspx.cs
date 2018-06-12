/****************************** Module Header ******************************\
* Module Name:  OnlineFileSystem.aspx.cs
* Project:	    CSASPNETOnlineFileSystem
* Copyright (c) Microsoft Corporation.
* 
* This is the main form of this application. It is used to initialize the UI and 
* handle the events.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace CSASPNETOnlineFileSystem
{
    public partial class OnlineFileSystem : System.Web.UI.Page
    {
        // The root path on the server
        public static string RootPath;

        // The current operation path
        public static string CurrentLocation;

        protected void Page_Load(object sender, EventArgs e)
        {
            RootPath = ConfigurationManager.AppSettings["RootPath"];

            if (!Page.IsPostBack)
            {
                CurrentLocation = RootPath;

                if (!Directory.Exists(RootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }

                ShowFolderItems();
            }

            ShowCurrentLocation();
        }

        protected void gvFileSystem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                if (e.Row.RowState == DataControlRowState.Normal ||
                    e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add(
                        "onclick", "javascript:return confirm('Are you sure you want " + 
                        "to delete the " + ((e.Row.Cells[3].Text == "Folder") ? 
                        "Folder" : "File") + " :\"" +
                        ((LinkButton)e.Row.Cells[0].Controls[0]).Text + "\"?')");
                } 
            } 
        }

        protected void gvFileSystem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            CurrentLocation = gvFileSystem.DataKeys[0].Values[2].ToString();

            lbMessage.Text = "";

            // Delete file or folder
            if (e.CommandName == "DeleteFileOrFolder") 
            {
                if (gvFileSystem.DataKeys[rowIndex].Values[0].ToString() == "Folder")
                {
                    lbMessage.Text = OCDIOObject.DeleteFolder(
                        gvFileSystem.DataKeys[rowIndex].Values[1].ToString());
                }
                else
                {
                    lbMessage.Text = OCDIOObject.DeleteFile(
                        gvFileSystem.DataKeys[rowIndex].Values[1].ToString());
                }

                ShowFolderItems();
                ShowCurrentLocation();
            }

            // Open the folder or download the file
            if (e.CommandName == "Open")
            {
                if (gvFileSystem.DataKeys[rowIndex].Values[0].ToString() == "Folder")
                {
                    CurrentLocation = CurrentLocation + "\\" +
                        gvFileSystem.DataKeys[rowIndex].Values[3].ToString();

                    ShowFolderItems();
                    ShowCurrentLocation();
                }
                else
                {
                    OCDIOObject.DownloadFile(
                        gvFileSystem.DataKeys[rowIndex].Values[1].ToString());
                }
            }

            // Rename the folder or the file
            if (e.CommandName == "Rename")
            {
                pnlRename.Visible = true;
                lbOldName.Text = gvFileSystem.DataKeys[rowIndex].Values[3].ToString();
                lbOldName.ToolTip = gvFileSystem.DataKeys[rowIndex].Values[1].ToString();
                pnlRename.ToolTip = gvFileSystem.DataKeys[rowIndex].Values[0].ToString();
                tbNewName.Focus();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            // The file Extension
            string fileExtension = string.Empty;

            // The choosed file name
            string fileName = string.Empty;

            // The new file name in the server
            string newFileName = string.Empty;

            // Check if choosed a file
            if (!fuChooseFile.HasFile)
            {
                lbMessage.Text = "Please choose the file you want to upload. " +
                                 "Note: The file size cannot be zero.";
                return;
            }


            fileExtension = Path.GetExtension(fuChooseFile.FileName);
            fileName = string.Format("{0}\\{1}", CurrentLocation,
                (string.IsNullOrEmpty(fileExtension) ? fuChooseFile.FileName : 
                fuChooseFile.FileName.Replace(fileExtension, "")));

            if (fileExtension.ToLower() == ".exe" || fileExtension.ToLower() == ".msi")
            {
                lbMessage.Text =
                    "The file you want to upload cannot be a .exe or .msi file.";
                return;
            }

            newFileName = fileName;

            // Check file size
            if (fuChooseFile.PostedFile.ContentLength >= 1024*1024*40)
            {
                lbMessage.Text =
                    "The file you want to upload cannot be larger than 40 MB.";
                return;
            }

            try
            {
                // If there is already a file with the same name in the system,rename 
                // and then upload the file .
                int i = 0;
                while (File.Exists(newFileName + fileExtension))
                { 
                    i++;
                    newFileName = string.Format(fileName + "({0})", i);
                }

                fuChooseFile.SaveAs(newFileName + fileExtension);

                lbMessage.Text =
                    string.Format("The file \"{0}\" was uploaded successfully!", 
                    Path.GetFileName( fileName));

                ShowFolderItems();
            }
            catch (HttpException he)
            {
                lbMessage.Text = 
                    string.Format("File {0} upload failed because of the following error:{1}.", 
                    fuChooseFile.PostedFile.FileName, he.Message);
            }
        }

        protected void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (tbNewFolderName.Text == "")
            {
                lbMessage.Text = "Please input a folder name!";
                return;
            }

            lbMessage.Text = OCDIOObject.CreateFolder(
                string.Format("{0}\\{1}", CurrentLocation, tbNewFolderName.Text));
            tbNewFolderName.Text = "";

            ShowFolderItems();
        }

        protected void lbtnFolder_Click(object sender, EventArgs e)
        {
            CurrentLocation = ((LinkButton)sender).ToolTip.Replace(
                "FileServerRoot", RootPath);
            this.Init += new EventHandler(lbtnFolder_Click);

            ShowFolderItems();
            ShowCurrentLocation();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            pnlRename.Visible = false;
            lbMessage.Text = "";
        }

        protected void btnRename_Click(object sender, EventArgs e)
        {
            if (tbNewName.Text == "")
            {
                lbMessage.Text = "Please input the new name of the file or folder.";
                return;
            }
            if (pnlRename.ToolTip == "Folder")
            {
                lbMessage.Text = OCDIOObject.RenameFolder(lbOldName.ToolTip,
                    tbNewName.Text);
            }
            else
            {
                lbMessage.Text = OCDIOObject.RenameFile(lbOldName.ToolTip,
                    tbNewName.Text);
            }
            tbNewName.Text = "";
            pnlRename.Visible = false;

            ShowFolderItems();
        }

        private void ShowFolderItems()
        {
            gvFileSystem.AutoGenerateColumns = false;
            this.gvFileSystem.DataSource =
                    OCDIOObject.GetAllItemsInTheDirectory(CurrentLocation);

            gvFileSystem.DataBind();
        }

        private void ShowCurrentLocation()
        {
            string[] strArrayLocation = CurrentLocation.Replace(
                RootPath,"FileServerRoot").Split('\\');

            Panel panelCurrentLocation = (Panel)FindControl("pnlCurrentLocation");
            panelCurrentLocation.Controls.Clear();

            for (int i = 0; i < strArrayLocation.Length; i++)
            {
                LinkButton lbtnFolder = new LinkButton();
                lbtnFolder.Text = strArrayLocation[i];
                lbtnFolder.ID = string.Format("lbtnFolder{0}", i);
                lbtnFolder.Click += new EventHandler(lbtnFolder_Click);
                string path = strArrayLocation[0];
                for (int j = 1; j <= i; j++)
                {
                    path = path + "\\" + strArrayLocation[j];
                }
                lbtnFolder.ToolTip = path;
                panelCurrentLocation.Controls.Add(lbtnFolder);

                Label lbFolder = new Label();
                lbFolder.Text = " \\ ";
                panelCurrentLocation.Controls.Add(lbFolder);
            }

        }
    }
}