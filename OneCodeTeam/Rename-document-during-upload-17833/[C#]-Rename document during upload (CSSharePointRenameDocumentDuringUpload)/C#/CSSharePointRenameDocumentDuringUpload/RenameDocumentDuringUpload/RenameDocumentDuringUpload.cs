/****************************** Module Header ******************************\
* Module Name:    RenameDocumentDuringUpload.cs
* Project:        CSSharePointRenameDocumentDuringUpload
* Copyright (c) Microsoft Corporation
*
* The sample code will show you how to rename the document using event receiver during upload. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace CSSharePointRenameDocumentDuringUpload.RenameDocumentDuringUpload
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class RenameDocumentDuringUpload : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            var eventHandlerClassName = this.GetType().FullName;

            // Trace Information
            Trace.TraceInformation("[TIES]: Entering event handler " + eventHandlerClassName);
            try
            {
                // Sets the value that indicates whether event firing is enabled to false
                EventFiringEnabled = false;

                // This url should be like:sharepointlist/filename (for example: books/mybook.doc)
                string url = properties.AfterUrl;
                
                // Define a new url (for example: books/ ID_mybook.doc).      
                string newUrl = string.Empty;

                // Get the file
                SPFile file = properties.ListItem.File;
             
                newUrl = properties.ListTitle + "/" + CleanupFileName(file.Name);

                // Rename the document by moving the file to a specified destination url
                file.MoveTo(newUrl,true);

                // Trace Information
                Trace.TraceInformation("[TIES]: Leaving event handler " + eventHandlerClassName);
            }
            catch (Exception ex)
            {
                // Trace Information
                Trace.TraceInformation("[TIES]: Error in event handler " + eventHandlerClassName + ex.Message + ex.StackTrace);
                properties.Cancel = true;
                properties.ErrorMessage = "Error in event";
            }
            finally
            {
                // Sets the value that indicates whether event firing is enabled to true
                EventFiringEnabled = true;
            }
        }

        /// <summary>
        /// Clean up FileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string CleanupFileName(string fileName)
        {
            // Special Characters Not Allowed: ~ " # % & * : < > ? / \ { | }      
            if (!string.IsNullOrEmpty(fileName))
            {
                // Regex to Replace the Special Character
                fileName = Regex.Replace(fileName, @"[~#'%&*:<>?/\{|}\n]", "");

                if (fileName.Contains("\""))
                {
                    fileName = fileName.Replace("\"", "");
                }

                if (fileName.StartsWith(".", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = fileName.TrimStart(new char[] { '.' });
                    fileName = fileName.TrimEnd(new char[] { '.' });
                }
                if (fileName.IndexOf("..", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    fileName = fileName.Replace("..", "");
                }
                fileName = fileName.Replace("/n", string.Empty);
            }          

            return (Guid.NewGuid()) + fileName;
        }

    }
}
