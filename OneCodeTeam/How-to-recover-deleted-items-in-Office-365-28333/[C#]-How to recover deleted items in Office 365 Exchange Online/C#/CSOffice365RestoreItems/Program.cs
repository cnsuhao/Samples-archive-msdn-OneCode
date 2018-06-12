/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365RestoreItems
Copyright (c) Microsoft Corporation.

Outlook Web App(OWA) currently allows us to recover deleted items. But it is 
inconvenient to recover large number of deleted items. Additionally, we may 
need to recover items of specific type. In this sample, we will demonstrate 
how to recover deleted items in Office 365 Exchange Online.
We can recover deleted items from the following folders:
1. DeletedItems: The Deleted Items folder.
2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
   have been soft-deleted from the Deleted Items folder.
3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
   have been hard-deleted from the Deleted Items folder.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CSOffice365RestoreItems
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

            // Restore the folders under DeletedItems.
            RestoreFolders(service, WellKnownFolderName.DeletedItems, null);
            Console.WriteLine();

            // Restore the items under DeletedItems in last two weeks.
            DateTime endDate=DateTime.Now;
            DateTime startDate=endDate.AddDays(-14);
            RestoreItems(service,WellKnownFolderName.DeletedItems,null,startDate,endDate);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Restore the folders from the rootFolder.
        /// </summary>
        /// <param name="rootFolder">
        /// We recover deleted folders from the following folders:
        /// 1. DeletedItems: The Deleted Items folder.
        /// 2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
        /// have been soft-deleted from the Deleted Items folder.
        /// 3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
        /// have been hard-deleted from the Deleted Items folder.
        /// </param>
        /// <param name="displayName">We can restore the specific folders by DisplayName property of the folders</param>
        private static void RestoreFolders(ExchangeService service,WellKnownFolderName rootFolder,
            String displayName)
        {
            if (rootFolder != WellKnownFolderName.DeletedItems && 
                rootFolder != WellKnownFolderName.RecoverableItemsDeletions && 
                rootFolder != WellKnownFolderName.RecoverableItemsPurges)
            {
                return;
            }

            SearchFilter searchFilter = null;
            if (String.IsNullOrWhiteSpace(displayName))
            {
                searchFilter = new SearchFilter.Exists(FolderSchema.DisplayName);
            }
            else
            {
                searchFilter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName,displayName);
            }

            // Get all the subfolders from the rootFolder
            List<Folder> folders = GetFolders(service, searchFilter, rootFolder, false, 
                PropertySet.FirstClassProperties);

            foreach (Folder folder in folders)
            {
                Console.WriteLine(folder.FolderClass);

                // Move folder and the subfolders to the specific folder.
                switch (folder.FolderClass)
                {
                    case "IPF.Appointment": 
                        folder.Move(WellKnownFolderName.Calendar);
                        Console.WriteLine("Move Folder-{0}-to Calendar", folder.DisplayName);
                        break;
                    case "IPF.Contact":
                        folder.Move(WellKnownFolderName.Contacts);
                        Console.WriteLine("Move Folder-{0}-to Contacts", folder.DisplayName);
                        break;
                    case "IPF.Journal":
                        folder.Move(WellKnownFolderName.Journal);
                        Console.WriteLine("Move Folder-{0}-to Journal", folder.DisplayName);
                        break;
                    case "IPF.Note":
                        folder.Move(WellKnownFolderName.Inbox);
                        Console.WriteLine("Move Folder-{0}-to Inbox", folder.DisplayName);
                        break;
                    case "IPF.StickyNote":
                        folder.Move(WellKnownFolderName.Notes);
                        Console.WriteLine("Move Folder-{0}-to Notes", folder.DisplayName);
                        break;
                    case "IPF.Task":
                        folder.Move(WellKnownFolderName.Tasks);
                        Console.WriteLine("Move Folder-{0}-to Tasks", folder.DisplayName);
                        break;
                    default:
                        folder.Move(WellKnownFolderName.Root);
                        Console.WriteLine("Move Folder-{0}-to Root", folder.DisplayName);
                        break;
                }
            }
        }

        /// <summary>
        /// Restore the items from the rootFolder.
        /// </summary>
        /// <param name="rootFolder">
        /// We recover deleted items from the following folders:
        /// 1. DeletedItems: The Deleted Items folder.
        /// 2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that 
        /// have been soft-deleted from the Deleted Items folder.
        /// 3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that 
        /// have been hard-deleted from the Deleted Items folder.
        /// </param>
        /// <param name="subject">We can restore the specific items by Subject property of the items</param>
        /// <param name="startDate">We can restore the specific items by LastModifiedTime 
        /// property of the items, and the startDate defines the start time.</param>
        /// <param name="endDate">We can restore the specific items by LastModifiedTime
        /// property of the items, and the endDate defines the end time.</param>
        private static void RestoreItems(ExchangeService service, WellKnownFolderName rootFolder, 
            String subject,DateTime startDate,DateTime endDate)
        {
            if (rootFolder != WellKnownFolderName.DeletedItems && 
                rootFolder != WellKnownFolderName.RecoverableItemsDeletions && 
                rootFolder != WellKnownFolderName.RecoverableItemsPurges)
            {
                return;
            }

            SearchFilter.SearchFilterCollection filterCollection = 
                new SearchFilter.SearchFilterCollection(LogicalOperator.And);

            SearchFilter subjectFilter = null;
            if (String.IsNullOrWhiteSpace(subject))
            {
                subjectFilter = new SearchFilter.Exists(ItemSchema.Subject);
            }
            else
            {
                subjectFilter = new SearchFilter.ContainsSubstring(ItemSchema.Subject, subject);
            }

            SearchFilter startTimeFilter = 
                new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.LastModifiedTime, startDate);
            SearchFilter endTimeFilter = 
                new SearchFilter.IsLessThanOrEqualTo(ItemSchema.LastModifiedTime, endDate);

            filterCollection.Add(subjectFilter);
            filterCollection.Add(startTimeFilter);
            filterCollection.Add(endTimeFilter);

            // Get all the items from the rootFolder
            List<Item> items = 
                GetItems(service, filterCollection, rootFolder,PropertySet.FirstClassProperties);

            foreach (Item item in items)
            {
                Console.WriteLine(item.ItemClass);

                // Move the item to the specific folder.
                switch (item.ItemClass)
                {
                    case "IPM.Appointment":
                        item.Move(WellKnownFolderName.Calendar);
                        Console.WriteLine("Move Item-{0}-to Calendar",item.Subject);
                        break;
                    case "IPM.Contact":
                        item.Move(WellKnownFolderName.Contacts);
                        Console.WriteLine("Move Item-{0}-to Contacts", item.Subject);
                        break;
                    case "IPM.Activity":
                        item.Move(WellKnownFolderName.Journal);
                        Console.WriteLine("Move Item-{0}-to Journal", item.Subject);
                        break;
                    case "IPM.Note":
                        if (item.IsFromMe)
                        {
                            item.Move(WellKnownFolderName.SentItems);
                            Console.WriteLine("Move Item-{0}-to SentItems", item.Subject);
                        }
                        else
                        {
                            item.Move(WellKnownFolderName.Inbox);
                            Console.WriteLine("Move Item-{0}-to Inbox", item.Subject);
                        }
                        break;
                    case "IPM.StickyNote":
                        item.Move(WellKnownFolderName.Notes);
                        Console.WriteLine("Move Item-{0}-to Notes", item.Subject);
                        break;
                    case "IPM.Task":
                        item.Move(WellKnownFolderName.Tasks);
                        Console.WriteLine("Move Item-{0}-to Tasks", item.Subject);
                        break;
                    default:
                        item.Move(WellKnownFolderName.Inbox);
                        Console.WriteLine("Move Item-{0}-to Inbox", item.Subject);
                        break;
                }
            }
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

        private static List<Item> GetItems(ExchangeService service, SearchFilter filter,
WellKnownFolderName folder, PropertySet propertySet)
        {
            if (service == null)
            {
                return null;
            }

            List<Item> items = new List<Item>();

            if (propertySet == null)
            {
                propertySet = new PropertySet(BasePropertySet.IdOnly);
            }

            const Int32 pageSize = 10;
            ItemView itemView = new ItemView(pageSize);
            itemView.PropertySet = propertySet;

            FindItemsResults<Item> searchResults = null;
            do
            {
                searchResults = service.FindItems(folder,
                    filter, itemView);
                items.AddRange(searchResults.Items);

                itemView.Offset += pageSize;
            } while (searchResults.MoreAvailable);

            return items;
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
