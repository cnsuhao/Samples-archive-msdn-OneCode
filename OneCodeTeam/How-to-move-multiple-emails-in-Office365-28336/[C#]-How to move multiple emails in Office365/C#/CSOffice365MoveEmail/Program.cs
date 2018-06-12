/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365MoveEmail
Copyright (c) Microsoft Corporation.

In this sample, we will demonstrate how to move the emails into the destination 
folder in the office 365.
We can move the emails to the specific folder to manage them. So we can follow 
these steps to implement it:
1. Create a search folder to collect the emails;
2. Get the search folder and destination folder;
3. Move the emails;

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
using System.Collections.Generic;
using System.Linq;

namespace CSOffice365MoveEmail
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

            String subjectString = InputSubjectString();

            // Use the EmailMessageSchema.Subject to filter the emails.
            Dictionary<PropertyDefinition, String> filters = new Dictionary<PropertyDefinition, string>();
            filters[EmailMessageSchema.Subject] = subjectString;

            String folderName = "Subject contains for moving email";

            // Delete the duplicate folder.
            DeleteFolder(service, WellKnownFolderName.SearchFolders, folderName);

            // Create the search folder named "Subject contains" to get the emails that received in last 30 days
            CreateSearchFolder(service, filters, folderName,WellKnownFolderName.Inbox);
            Console.WriteLine("Create the search folder.");
            Console.WriteLine();

            // Get the search folder.
            SearchFilter filter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName);
            SearchFolder searchFolder = GetFolder(service, filter,
                WellKnownFolderName.SearchFolders) as SearchFolder;
            Console.WriteLine("Get the specific search folder.");
            Console.WriteLine();

            // Get the destination folder
            Folder folder = CreateFolder(service, WellKnownFolderName.Inbox, "DestinationFolder");
            Console.WriteLine("Get the destination folder.");
            Console.WriteLine();

            MoveEmailMessages(searchFolder, folder);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        private static SearchFolder CreateSearchFolder(ExchangeService service, Dictionary<PropertyDefinition, String> filters,
            String displayName,WellKnownFolderName rootFolder)
        {
            // Search the eamils in last 30 days
            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now;

            return CreateSearchFolder(service, startDate, endDate, filters, displayName,rootFolder);
        }

        /// <summary>
        /// This method creates and sets the search folder.
        /// </summary>
        private static SearchFolder CreateSearchFolder(ExchangeService service, DateTime startDate,DateTime endDate,
            Dictionary<PropertyDefinition, String> filters, String displayName,WellKnownFolderName rootFolder)
        {
            if (service == null)
            {
                return null;
            }

            SearchFilter.SearchFilterCollection filterCollection =
                new SearchFilter.SearchFilterCollection(LogicalOperator.And);

           if(startDate==null||endDate==null||DateTime.Compare(startDate,endDate)>0)
           {
               return null;
           }

            SearchFilter startDateFilter =
                new SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate);
            SearchFilter endDateFilter =
                new SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated, endDate);
            filterCollection.Add(startDateFilter);
            filterCollection.Add(endDateFilter);
           
            SearchFilter itemClassFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, "IPM.Note");
            filterCollection.Add(itemClassFilter);

            // Set the other filters.
            if (filters != null)
            {
                foreach (PropertyDefinition property in filters.Keys)
                {
                    SearchFilter searchFilter = new SearchFilter.ContainsSubstring(property, filters[property]);
                    filterCollection.Add(searchFilter);
                }
            }

            FolderId folderId = new FolderId(rootFolder);

            Boolean isDuplicateFoler = true;
            SearchFilter duplicateFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, displayName);
            SearchFolder searchFolder =
                GetFolder(service, duplicateFilter, WellKnownFolderName.SearchFolders) as SearchFolder;

            // If there isn't the specific search folder, we create a new one.
            if (searchFolder == null)
            {
                searchFolder = new SearchFolder(service);
                isDuplicateFoler = false;
            }
            searchFolder.SearchParameters.RootFolderIds.Add(folderId);
            searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Shallow;
            searchFolder.SearchParameters.SearchFilter = filterCollection;

            if (isDuplicateFoler)
            {
                searchFolder.Update();
            }
            else
            {
                searchFolder.DisplayName = displayName;

                searchFolder.Save(WellKnownFolderName.SearchFolders);
            }

            return searchFolder;
        }

        private static void MoveEmailMessages(SearchFolder searchFolder, Folder folder)
        {
            if (searchFolder == null)
            {
                return;
            }

            const Int32 pageSize = 50;
            ItemView itemView = new ItemView(pageSize);

            PropertySet propertySet = new PropertySet(BasePropertySet.IdOnly,FolderSchema.DisplayName);
            folder.Load(propertySet);
            Console.WriteLine("Move the eamils to the folder-{0}",folder.DisplayName);

            FindItemsResults<Item> findResults = null;
            do
            {
                findResults = searchFolder.FindItems(itemView);

                foreach (Item item in findResults.Items)
                {
                    if (item is EmailMessage)
                    {
                        EmailMessage email = item as EmailMessage;
                        email.Move(folder.Id);
                        Console.WriteLine("Move the email:{0}", email.Subject);
                    }
                }

                itemView.Offset += pageSize;
            } while (findResults.MoreAvailable);
        }

        private static String InputSubjectString()
        {
            Console.WriteLine("Please input the string that the email's subject contains to filter the emails:");
            String subjectString = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(subjectString))
            {
                Console.WriteLine("Please input the vaild strings");
                subjectString = InputSubjectString();
            }

            return subjectString;
        }

        private static Folder GetFolder(ExchangeService service, SearchFilter filter, WellKnownFolderName folder)
        {
            if (service == null)
            {
                return null;
            }

            PropertySet propertySet = new PropertySet(BasePropertySet.IdOnly);

            FolderView folderView = new FolderView(5);
            folderView.PropertySet = propertySet;

            FindFoldersResults searchResults = service.FindFolders(folder,
                filter, folderView);

            return searchResults.FirstOrDefault();
        }

        private static void DeleteFolder(ExchangeService service, WellKnownFolderName parentFolder, String folderName)
        {
            SearchFilter searchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName);

            Folder folder = GetFolder(service, searchFilter, parentFolder);

            if (folder != null)
            {
                Console.WriteLine("Delete the folder '{0}'", folderName);
                folder.Delete(DeleteMode.HardDelete);
                Console.WriteLine();
            }
        }

        private static Folder CreateFolder(ExchangeService service, WellKnownFolderName parentFolder, String folderName)
        {
            SearchFilter filter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName);
            Folder folder = GetFolder(service, filter,parentFolder);

            if (folder == null)
            {
                folder = new Folder(service);
                folder.DisplayName = folderName;
                folder.FolderClass = "IPF.MyCustomFolderClass";
                folder.Save(parentFolder);
                Console.WriteLine("Create the folder-{0}",folderName);
            }

            return folder;
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
