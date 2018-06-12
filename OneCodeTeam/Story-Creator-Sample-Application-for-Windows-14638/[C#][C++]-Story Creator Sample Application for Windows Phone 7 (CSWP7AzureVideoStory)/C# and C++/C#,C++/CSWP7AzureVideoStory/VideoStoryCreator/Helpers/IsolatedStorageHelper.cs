/****************************** Module Header ******************************\
* Module Name:	IsolatedStorageHelper.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A helper class that performs I/O against isolated storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.IO;
using System.IO.IsolatedStorage;

namespace VideoStoryCreator
{
    public static class IsolatedStorageHelper
    {
        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="name">The name of the file to be deleted.</param>
        public static void DeleteFile(string name)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStore.FileExists(name))
            {
                userStore.DeleteFile(name);
            }
        }

        /// <summary>
        /// Rename the file.
        /// First create a new file and copy the contents of the original file.
        /// Then delete the original file.
        /// </summary>
        public static void RenameFile(string originalName, string newName)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStore.FileExists(originalName))
            {
                using (FileStream originalFileStream = userStore.OpenFile(originalName, System.IO.FileMode.Open))
                {
                    using (FileStream newFileStream = userStore.CreateFile(newName))
                    {
                        byte[] buffer = new byte[originalFileStream.Length];
                        originalFileStream.Read(buffer, 0, buffer.Length);
                        newFileStream.Write(buffer, 0, buffer.Length);
                    }
                }
                userStore.DeleteFile(originalName);
            }
        }

        /// <summary>
        /// Checks if the file with the specified name already exists.
        /// </summary>
        public static bool FileExists(string name)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForApplication();
            return userStore.FileExists(name);
        }
    }
}
