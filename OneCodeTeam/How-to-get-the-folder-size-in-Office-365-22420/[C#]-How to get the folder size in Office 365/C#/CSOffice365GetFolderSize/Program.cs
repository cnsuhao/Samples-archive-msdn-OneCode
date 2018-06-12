/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365GetFolderSize
Copyright (c) Microsoft Corporation.

In this sample, we will demonstrate how to get the size of the folders and 
the subfolders.
In this sample, we will use two extended properties:
1. PidTagMessageSize(Property ID: 0x0E08);
2. PR_FOLDER_PATHNAME (Property ID: 0x66B5).

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Exchange.WebServices.Data;

namespace CSOffice365GetFolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = CallbackMethods.CertificateValidationCallBack;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            // Get the information of the account.
            UserInfo user = new UserInfo();
            service.Credentials = new WebCredentials(user.Account, user.Pwd);

            // Set the url of server.
            if (!AutodiscoverUrl(service, user))
            {
                return;
            }

            // Define the search filter.
            SearchFilter.RelationalFilter searchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Inbox");
            Console.WriteLine("{0,-15}{1,-30}{2,-10}", "DisplayName", "PathName", "Size(MB)");
            GetFoldersSize(service, searchFilter);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        private static void GetFoldersSize(ExchangeService service, SearchFilter.RelationalFilter filter)
        {
            GetFoldersSize(service, filter, null);
        }

        private static void GetFoldersSize(ExchangeService service, Folder folder)
        {
            GetFoldersSize(service, null, folder);
        }

        /// <summary>
        /// We will get size of the folder and the subfolders in this method.
        /// </summary>
        private static void GetFoldersSize(ExchangeService service, SearchFilter.RelationalFilter filter, Folder folder)
        {
            if (filter == null && folder == null)
            {
                return;
            }

            // The PidTagMessageSizeExtended extended property will return the size of the folder and the subfolders.
            const Int32 PidTagMessageSizeExtended = 3592;
            ExtendedPropertyDefinition exPropFolderSize =
                new ExtendedPropertyDefinition(PidTagMessageSizeExtended, MapiPropertyType.Integer);

            // The PR_FOLDER_PATHNAME extended property will return the path of the folder.
            const Int32 PR_FOLDER_PATHNAME = 26293;
            ExtendedPropertyDefinition exPropPathName =
                new ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String);

            PropertySet properSet =
                new PropertySet(BasePropertySet.IdOnly, FolderSchema.ChildFolderCount, FolderSchema.DisplayName);
            properSet.Add(exPropFolderSize);
            properSet.Add(exPropPathName);

            const Int32 pageSize = 50;
            var folderView = new FolderView(pageSize);
            folderView.PropertySet = properSet;

            FindFoldersResults searchResults = null;

            do
            {
                if (filter != null)
                {
                    // If we set the filter, we just first get the root folder.
                    searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView);
                }
                else if (folder != null)
                {
                    // If we get the folder, we can use FolderTraversal.Deep to get all the subfolders.
                    folderView.Traversal = FolderTraversal.Deep;
                    searchResults = folder.FindFolders(folderView);
                }

                foreach (Folder f in searchResults.Folders)
                {
                    float size = float.Parse(f.ExtendedProperties[0].Value.ToString()) / 1048576;
                    Console.WriteLine("{0,-15}{1,-30}{2,-10:N2}", f.DisplayName, f.ExtendedProperties[1].Value, size);

                    if (filter != null)
                    {
                        // After we got the root folder, we show also get the subfolders.
                        GetFoldersSize(service, f);
                    }
                }

                folderView.Offset += pageSize;
            } while (searchResults.MoreAvailable);
        }

        private static Boolean AutodiscoverUrl(ExchangeService service, UserInfo user)
        {
            Boolean isSuccess = false;

            try
            {
                Console.WriteLine("Connecting the Exchange Online......");
                service.AutodiscoverUrl(user.Account, CallbackMethods.RedirectionUrlValidationCallback);
                Console.WriteLine();
                Console.WriteLine("It's success to connect the Exchange Online.");

                isSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("There's an error.");
                Console.WriteLine(e.Message);
            }

            return isSuccess;
        }
    }
}
