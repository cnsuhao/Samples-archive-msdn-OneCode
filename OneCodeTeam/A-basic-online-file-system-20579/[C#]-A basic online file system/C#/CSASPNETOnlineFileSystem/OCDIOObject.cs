/****************************** Module Header ******************************\
* Module Name:  OCDIOObject.cs
* Project:	    CSASPNETOnlineFileSystem
* Copyright (c) Microsoft Corporation.
* 
* The class OCDIOObject supplies following features:
* 1. Create a folder
* 2. Delete a folder  
* 3. Rename a folder
* 4. Delete a file
* 5. Rename a file
* 6. Download a file
* 7. Get all files and subfolders of a folder
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Data;
using System.IO;

namespace CSASPNETOnlineFileSystem
{
    internal class OCDIOObject
    {
        private static FileInfo FileInformation;
        private static DirectoryInfo DirInformation;

        #region OCDIOObject Metheds

        /// <summary>
        /// Create a folder 
        /// </summary>
        /// <param name="folderPath">The name of folder you want to create</param>
        /// <returns>The result of the create folder operation</returns>
        public static string CreateFolder(string folderPath)
        {
            // The old folder name
            string folderName = string.Empty;

            try
            {
                DirInformation = new DirectoryInfo(folderPath);

                folderName = DirInformation.Name;

                // The folder location
                string folderLocation = folderPath.Substring(0,
                    folderPath.LastIndexOf('\\') + 1); 

                if (Directory.Exists(folderPath))
                {
                    return string.Format(
                        "There is already a folder with the name \"{0}\" in the" + 
                        " location \"{1}\".", folderName, folderLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }
            
            
                Directory.CreateDirectory(folderPath);
            }
            catch (System.ArgumentException agEx)
            {
                return string.Format(
                    "Failed to create the folder, because " +
                    "of the following error: <br>{0}", agEx.Message);
            }
            catch (PathTooLongException ptlEx)
            {
                return string.Format(
                    "Failed to create the folder, because " +
                    "of the following error: <br>{0}", ptlEx.Message);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                return string.Format(
                    "Failed to create the folder, because " +
                    "of the following error: <br>{0}", dnfEx.Message);
            }

            return string.Format("The folder \"{0}\" was created successfully!", 
                folderName);
        }

        /// <summary>
        /// Delete a folder
        /// </summary>
        /// <param name="folderPath">The name of folder you want to delete</param>
        /// <returns>The result of the delete folder operation</returns>
        public static string DeleteFolder(string folderPath)
        {
            // The folder name
            string folderName = string.Empty;
            
            try
            {
                DirInformation = new DirectoryInfo(folderPath);

                folderName = DirInformation.Name;

                // The folder location
                string folderLocation = folderPath.Substring(0,
                        folderPath.LastIndexOf('\\') + 1);

                if (!Directory.Exists(folderPath))
                {
                    return string.Format(
                        "There is no folder with the name \"{0}\" in the" +
                        " location \"{1}\".", 
                        folderName, folderLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }

                Directory.Delete(folderPath,true);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                return string.Format("Failed to delete the folder, because " +
                    "of the following error: <br>{0}", dnfEx.Message);
            }

            return string.Format(
                "The folder \"{0}\" was deleted successfully!", folderName);
        }

        /// <summary>
        /// Rename the folder
        /// </summary>
        /// <param name="folderPath">The folder path</param>
        /// <param name="newName">New folder name</param>
        /// <returns>The result of the rename folder operation</returns>
        public static string RenameFolder(string folderPath,string newName)
        {

            // The old folder name
            string folderName = string.Empty;

            // The full path of the folder
            string newFolderPath = string.Empty;

            // The folder location
            string folderLocation = string.Empty;

            try
            {
                DirInformation = new DirectoryInfo(folderPath);

                folderName = DirInformation.Name;
                newFolderPath = folderPath.Substring(0,
                        folderPath.LastIndexOf('\\') + 1) + newName;
                folderLocation = folderPath.Substring(0, 
                    folderPath.LastIndexOf('\\') + 1);


                if (!Directory.Exists(folderPath))
                {
                    return string.Format(
                        "There is no folder with the name \"{0}\" in the" + 
                        " location \"{1}\".", folderName, folderLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }

                if (folderName.Equals(newName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return "The new folder name you input is same with the old " + 
                        "one(The folder name is not case sensitive).";
                }

                if (Directory.Exists(newFolderPath))
                { 
                    return string.Format(
                        "There is already a folder with the name \"{0}\" " + 
                        "in the location \"{1}\".",
                        newName, folderLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }

                Directory.Move(folderPath,
                    folderPath.Substring(0,folderPath.LastIndexOf('\\') + 1 ) 
                    + newName);
            }
            catch(System.ArgumentException agEx)
            {
                return string.Format(
                    "Failed to rename the folder, because " +
                    "of the following error: <br>{0}", agEx.Message);
            }
            catch (PathTooLongException ptlEx)
            {
                return string.Format(
                    "Failed to rename the folder, because " +
                    "of the following error: <br>{0}", ptlEx.Message);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                return string.Format(
                    "Failed to rename the folder, because " +
                    "of the following error: <br>{0}", dnfEx.Message);
            }

            return string.Format(
                "The folder \"{0}\" was renamed to \"{1}\" successfully!",
                folderName, newName);
        }

        /// <summary>
        /// Delete the file 
        /// </summary>
        /// <param name="filePath">The name of the file that you want to delete </param>
        /// <returns>The result of the delete file operation</returns>
        public static string DeleteFile(string filePath)
        {
            // The old name of the file
            string fileName = string.Empty;

            // The file location
            string fileLocation = string.Empty;

            try
            {
                FileInformation = new FileInfo(filePath);

                fileName = FileInformation.Name;

                fileLocation = filePath.Substring(0,
                    filePath.LastIndexOf('\\') + 1);

                if (!File.Exists(filePath))
                {
                    return string.Format(
                        "There is not a file with the name \"{0}\" in the location \"{1}\".", 
                        fileName, fileLocation);
                }

                File.Delete(filePath);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                return string.Format("Failed to delete the file, because " +
                    "of the following error: <br>{0}", dnfEx.Message);
            }

            return string.Format("The file \"{0}\" was deleted successfully!",
                FileInformation.Name );
        }

        /// <summary>
        /// Rename a file
        /// </summary>
        /// <param name="filePath">The full file path</param>
        /// <param name="newName">New file name</param>
        /// <returns>The result of the rename file operation</returns>
        public static string RenameFile(string filePath,string newName)
        {
            // The old name of the file
            string fileName = string.Empty;

            // The file extension
            string fileExtension = string.Empty;

            // The new full path of the file
            string newFilePath = string.Empty;

            // The file location
            string fileLocation = string.Empty;

            try
            {
                FileInformation = new FileInfo(filePath);
                fileName = FileInformation.Name;
                fileExtension = FileInformation.Extension;
                newFilePath = filePath.Substring(0,
                    filePath.LastIndexOf('\\') + 1) + newName + fileExtension;
                fileLocation = filePath.Substring(0,
                    filePath.LastIndexOf('\\') + 1);


                if (!File.Exists(filePath))
                {
                    return string.Format("There is not a file with the name  \"{0}\"" + 
                        " in the location \"{1}\".",fileName, fileLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }

                if (fileName.Equals(newName, System.StringComparison.OrdinalIgnoreCase)) 
                {
                     return "The new file name you input is same with the old " + 
                        "one(The file name is not case sensitive).";
                }

                if (File.Exists(newFilePath))
                { 
                    return string.Format("There is already a file with the name \"{0}" +
                        "\" in the location \"{1}\".", newName, fileLocation.Replace(
                            OnlineFileSystem.RootPath, "FileServerRoot"));
                }

                File.Move(filePath,filePath.Substring(0, 
                    filePath.LastIndexOf('\\') + 1) + newName + fileExtension);
            }
            catch (System.ArgumentException agEx)
            {
                return string.Format(
                    "Failed to rename the file, because " +
                    "of the following error: <br>{0}", agEx.Message);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                return string.Format("Failed to rename the file, because " +
                    "of the following error: <br>{0}", dnfEx.Message);
            }
            catch (PathTooLongException ptlEx)
            {
                return string.Format(
                    "Failed to rename the file, because " +
                    "of the following error: <br>{0}", ptlEx.Message);
            }

            return string.Format("The file \"{0}\" was renamed to \"{1}" +
                 "\" successfully!", FileInformation.Name, newName);
        }

        /// <summary>
        /// Download the file
        /// </summary>
        /// <param name="filePath">The file path</param>
        public static void DownloadFile(string filePath)
        {
            FileInformation = new FileInfo(filePath);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + 
                FileInformation.Name + ";");
            response.TransmitFile(filePath);
            response.Flush();
            response.End();
        }

        /// <summary>
        /// Get all files and subfolders of the folder
        /// </summary>
        /// <param name="folderPath">The name of the folder from which you want to get 
        /// files and folders</param>
        /// <returns>All files and subfolders in the folder</returns>
        public static DataTable GetAllItemsInTheDirectory(string folderPath)
        {
            DataTable dtAllItems = new DataTable();

            dtAllItems.Columns.Add("Type");
            dtAllItems.Columns.Add("Name");
            dtAllItems.Columns.Add("Size");
            dtAllItems.Columns.Add("UploadTime");
            dtAllItems.Columns.Add("Location");
            dtAllItems.Columns.Add("FullPath");

            // Get all subfolder in the folder <folderPath>
            string[] subFolders = Directory.GetDirectories(folderPath);
            foreach (string subFolderPath in subFolders)
            {
                DirectoryInfo subFolder = new DirectoryInfo(subFolderPath);
                dtAllItems.Rows.Add("Folder",
                                    subFolder.Name,
                                    "",
                                    subFolder.CreationTime.ToString(),
                                    subFolder.Parent.FullName,
                                    subFolder.FullName);
            }

            // Get all files in the folder <folderPath>
            string[] files = Directory.GetFiles(folderPath);
            foreach (string filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                dtAllItems.Rows.Add(
                    file.Name.LastIndexOf('.') < 0 ? "" : 
                    file.Name.Substring(file.Name.LastIndexOf('.')).ToUpper(),
                    file.Name,
                    CommonUse.FormatFileSize((long)file.Length),
                    file.CreationTime.ToString(),
                    file.DirectoryName,
                    file.FullName);
            }

            return dtAllItems;
        }

        #endregion

    }
}