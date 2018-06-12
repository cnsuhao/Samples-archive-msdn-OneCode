/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365GetFolderStatistics
Copyright (c) Microsoft Corporation.

Some of you find your Outlook is frozen when receiving emails. One workaround 
is moving the large emails to a new folder to allow Outlook finish the 
synchronization. But before moving these large emails, we need to identify 
these large email messages and find a proper destination folder for these 
emails. In this sample, we will demonstrate how to get the statistics of the 
folders and the subfolders.
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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CSOffice365GetFolderStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback =
CallbackMethods.CertificateValidationCallBack;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            // Get the information of the account.
            UserInfo user = new UserInfo();
            service.Credentials = new WebCredentials(user.Account, user.Pwd);

            // Set the url of server.
            if (!AutodiscoverUrl(service, user))
            {
                return;
            }
            Console.WriteLine();

            // Get the statistics of the folders in Inbox. 
            String folderName = "Inbox";
            // Email is the large email if it's more than 1 MB.
            GetFoldersStatistics(service, folderName, 1024 * 1024);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        private static void GetFoldersStatistics(ExchangeService service,
            String folderName, Int32 largeSize)
        {
            // The PidTagMessageSizeExtended extended property will return the size 
            // of the folder and the subfolders.
            const Int32 pidTagMessageSizeExtended = 3592;
            ExtendedPropertyDefinition exPropFolderSize =
                new ExtendedPropertyDefinition(pidTagMessageSizeExtended, MapiPropertyType.Integer);
            // The PR_FOLDER_PATHNAME extended property will return the path of the folder.
            const Int32 PR_FOLDER_PATHNAME = 26293;
            ExtendedPropertyDefinition exPropDefPathName =
                new ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String);

            PropertySet folderPropertySet =
                new PropertySet(BasePropertySet.IdOnly, FolderSchema.DisplayName,
                    FolderSchema.ChildFolderCount, FolderSchema.TotalCount);
            folderPropertySet.Add(exPropFolderSize);
            folderPropertySet.Add(exPropDefPathName);

            SearchFilter rootFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Inbox");

            // First get the root folders.
            List<Folder> rootFolders = GetFolders(service, rootFilter,
                WellKnownFolderName.MsgFolderRoot, false, folderPropertySet);
            Console.WriteLine("Get the root folders.");
            Console.WriteLine();

            Console.WriteLine("{0,-11} {1,-20} {2,-8} {3,-9} {4,-14} {5,-11}",
                "DisplayName", "Path", "Size(MB)", "ItemCount", "HasAttachments", "LargeEmails");

            foreach (Folder root in rootFolders)
            {
                // Get the statics of the root folders.
                GetItemsStatics(root, largeSize);

                List<Folder> subFolders = GetFolders(root, null, true, folderPropertySet);

                foreach (Folder folder in subFolders)
                {
                    GetItemsStatics(folder, largeSize);
                }
            }
        }

        private static void GetItemsStatics(Folder folder, Int32 largeSize)
        {
            PropertySet itemPropertySet =
                new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject,
                    ItemSchema.Size, ItemSchema.HasAttachments);

            const Int32 pageSize = 100;

            SearchFilter.SearchFilterCollection filters =
    new SearchFilter.SearchFilterCollection(LogicalOperator.Or);

            // Get the emails that is larger or have the attachments
            SearchFilter filterAttachment = new SearchFilter.IsEqualTo(ItemSchema.HasAttachments, true);
            SearchFilter filterLargeEmail = new SearchFilter.IsGreaterThan(ItemSchema.Size, largeSize);
            filters.Add(filterAttachment);
            filters.Add(filterLargeEmail);

            ItemView itemView = new ItemView(pageSize);
            itemView.PropertySet = itemPropertySet;
            itemView.Traversal = ItemTraversal.Shallow;

            FindItemsResults<Item> searchResults = null;
            List<Item> items = new List<Item>();

            do
            {
                searchResults = folder.FindItems(filters, itemView);
                items.AddRange(searchResults.Items);

                itemView.Offset += pageSize;
            } while (searchResults.MoreAvailable);

            // The number of the emails that have the attachments.
            Int32 itemsWithAttachmentNum = (from i in items
                                            where i.HasAttachments
                                            select i).Count();

            // The number of the large emails.
            Int32 largeItemNum = (from i in items
                                  where i.Size > largeSize
                                  select i).Count();

            Double sizeInMb =
                Double.Parse(folder.ExtendedProperties[0].Value.ToString()) / (1024 * 1024);
            Console.WriteLine("{0,-11} {1,-20} {2,-8:N2} {3,-9} {4,-14} {5,-11}",
                folder.DisplayName, folder.ExtendedProperties[1].Value, sizeInMb,
                folder.TotalCount, itemsWithAttachmentNum, largeItemNum);
        }

        private static List<Folder> GetFolders(ExchangeService service, SearchFilter filter,
    WellKnownFolderName folder, Boolean isDeep, PropertySet propertySet)
        {
            if (service == null)
            {
                return null;
            }

            List<Folder> folders = new List<Folder>();

            if (propertySet == null)
            {
                propertySet = new PropertySet(BasePropertySet.IdOnly);
            }

            const Int32 pageSize = 10;
            FolderView folderView = new FolderView(pageSize);
            folderView.PropertySet = propertySet;
            if (isDeep)
            {
                folderView.Traversal = FolderTraversal.Deep;
            }

            FindFoldersResults searchResults = null;
            do
            {
                searchResults = service.FindFolders(folder,
                    filter, folderView);
                folders.AddRange(searchResults.Folders);

                folderView.Offset += pageSize;
            } while (searchResults.MoreAvailable);

            return folders;
        }

        private static List<Folder> GetFolders(Folder root, SearchFilter filter,
            Boolean isDeep, PropertySet propertySet)
        {
            if (root == null)
            {
                return null;
            }

            List<Folder> folders = new List<Folder>();

            if (propertySet == null)
            {
                propertySet = new PropertySet(BasePropertySet.IdOnly);
            }

            const Int32 pageSize = 10;
            FolderView folderView = new FolderView(pageSize);
            folderView.PropertySet = propertySet;
            if (isDeep)
            {
                folderView.Traversal = FolderTraversal.Deep;
            }

            FindFoldersResults searchResults = null;
            do
            {
                searchResults = root.FindFolders(filter, folderView);
                folders.AddRange(searchResults.Folders);

                folderView.Offset += pageSize;
            } while (searchResults.MoreAvailable);

            return folders;
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
