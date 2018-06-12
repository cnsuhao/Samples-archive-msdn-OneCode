/****************************** Module Header ******************************\
Module Name:  ImageListExtension.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.

Utility class for the extensions of ImageList type

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Windows.Forms;

namespace Microsoft.OneCode.Utilities
{
    /// <summary>
    ///  Extensions for the ImageList type.
    /// </summary>
    internal static class ImageListExtension
    {
        /// <summary>
        /// Get the ImageList icon index for the usage of TreeView.
        ///  If the icon do not exist, leverage GetSmallIconByFileType utility 
        ///  to retrieve icons associated with the registered file types.
        /// </summary>
        /// <param name="imageList">ImageList type to extend</param>
        /// <param name="fileExtension">
        /// File extensions, support "unknown", "folder" and other ".*" extensions.
        /// </param>
        /// <returns>the icon Index in the ImageList</returns>
        public static int GetImageListIndex(this ImageList imageList, 
            string fileExtension = "")
        {
            if (!imageList.Images.ContainsKey(fileExtension))
            {
                imageList.Images.Add(fileExtension, 
                    IconUtilities.GetSmallIconByFileType(fileExtension));
            }

            return imageList.Images.IndexOfKey(fileExtension);
        }
    }
}
