/****************************** Module Header ******************************\
* Module Name:  CommonUse.cs
* Project:	    CSASPNETOnlineFileSystem
* Copyright (c) Microsoft Corporation.
* 
* Formats a file size to string
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


namespace CSASPNETOnlineFileSystem
{
    internal class CommonUse
    {
        /// <summary>
        /// Format the file size
        /// </summary>
        /// <param name="fileLength">The file size</param>
        /// <returns>Formated file size</returns>
        public static string FormatFileSize(long fileLength)
        {

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0}(bytes)",fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0}KB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0}MB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            if (fileLength / 1024 < 1)
            {
                return string.Format("{0}GB", fileLength);
            }
            else
            {
                fileLength = fileLength / 1024;
            }

            return string.Format("{0}TB", fileLength);

        }
    }
}