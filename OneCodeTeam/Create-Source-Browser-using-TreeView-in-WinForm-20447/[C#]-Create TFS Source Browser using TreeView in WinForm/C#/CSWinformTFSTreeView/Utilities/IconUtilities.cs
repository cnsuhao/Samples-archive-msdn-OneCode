/****************************** Module Header ******************************\
Module Name:  IconUtilities.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.

Utility class to help get registered file type associated icons

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Microsoft.OneCode.Utilities
{
    /// <summary>
    /// Icon Utilities
    /// </summary>
    internal sealed class IconUtilities
    {
        /// <summary>
        /// Get the small icon associated with registered file types.
        /// </summary>
        /// <param name="fileType">
        /// Support "unknown", "folder" and other ".*" extensions.
        /// </param>
        /// <returns>
        /// Icons that associated with file extensions.
        /// </returns>
        internal static Icon GetSmallIconByFileType(string fileType)
        {
            // Parameter check is in the GetIconPathFromClassesRoot
            string regIconString = GetIconPathFromClassesRoot(fileType);

            string[] fileIcon = regIconString.Split(new char[] { ',' });

            // undefined icon
            if (fileIcon.Length != 2)
            {
                fileIcon = new string[] { Path.Combine(Environment.SystemDirectory,
                    "shell32.dll"), "2" };
            }

            IntPtr[] hIconSmall = new IntPtr[] { IntPtr.Zero };
            Icon extractedIcon = null;
            try
            {
                int readIconCount = NativeMethods.ExtractIconEx(fileIcon[0],
                    int.Parse(fileIcon[1]), null, hIconSmall, 1);
                if (readIconCount > 0 && hIconSmall[0] != IntPtr.Zero)
                {
                    extractedIcon = (Icon)Icon.FromHandle(hIconSmall[0]).Clone();
                }
            }
            catch (COMException)
            {
                // Unexpected type, use default icon instead.
            }
            finally
            {
                foreach (IntPtr ptr in hIconSmall)
                {
                    if (ptr != IntPtr.Zero)
                    {
                        NativeMethods.DestroyIcon(ptr);
                    }
                }
            }

            return extractedIcon ?? GetSmallIconByFileType("");
        }

        /// <summary>
        /// Get the icon path from the Classes Root Registry per the file extension
        /// </summary>
        /// <param name="fileExtention">
        /// Support "unknown", "folder" and other ".*" extensions.
        /// </param>
        /// <returns>
        /// The icon path such as 
        /// "C:\Program Files\Microsoft Visual Studio 10.0\VC#\VCSPackages\csproj.dll,1"
        /// </returns>
        private static string GetIconPathFromClassesRoot(string fileExtention)
        {
            string regIconPath = String.Empty;
            const string unknownFileTypeIcon = @"shell32.dll,0";
            const string folderFileTypeIcon = @"shell32.dll,3";
            const string folderStr = "folder";
            const string unknownStr = "unknown";
            const string defaultIconStr = "DefaultIcon";
            const string defaultRegValue = "";
            const char extensionPrefix = '.';

            if (String.IsNullOrEmpty(fileExtention)
                || String.Compare(fileExtention, unknownStr, 
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Path.Combine(Environment.SystemDirectory, unknownFileTypeIcon);
            }

            if (String.Compare(fileExtention, folderStr, 
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Path.Combine(Environment.SystemDirectory, folderFileTypeIcon);
            }

            if (fileExtention[0] == extensionPrefix)
            {
                RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(fileExtention,
                    false);
                if (regKey != null)
                {
                    string regFileTypePath = regKey.GetValue("") as string;
                    regKey.Close();

                    if (!String.IsNullOrEmpty(regFileTypePath))
                    {
                        regKey = Registry.ClassesRoot.OpenSubKey(
                            Path.Combine(regFileTypePath, defaultIconStr), false);
                        if (regKey != null)
                        {
                            regIconPath = regKey.GetValue(defaultRegValue) as String;
                            regKey.Close();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(regIconPath))
            {
                regIconPath = Path.Combine(Environment.SystemDirectory, 
                    unknownFileTypeIcon);
            }

            return regIconPath;
        }
    }
}
