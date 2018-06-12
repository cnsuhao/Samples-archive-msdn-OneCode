/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365SortTasks
Copyright (c) Microsoft Corporation.

We can sort the task list items in Outlook, but the feature isn’t implemented 
in Outlook Web App (OWA). In this sample, we will demonstrate how to sort 
task list items by categories in Office 365 Exchange Online.
We will add the category name as a prefix in the Subject property of a task 
item so that we can use sort by Subject to sort by category.

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

namespace CSOffice365SortTasks
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

            SortTasksByCategories(service, null);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// This method will rename the tasks so that we can sort the tasks by the categories.
        /// </summary>
        private static void SortTasksByCategories(ExchangeService service,String folderName)
        {
            SearchFilter.SearchFilterCollection filters = 
                new SearchFilter.SearchFilterCollection(LogicalOperator.And);

            if (!String.IsNullOrEmpty(folderName))
            {
                SearchFilter searchFilterName = 
                    new SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName);
                filters.Add(searchFilterName);
            }

            //Get the Task folders.
            SearchFilter searchFilterClass = 
                new SearchFilter.IsEqualTo(FolderSchema.FolderClass, "IPF.Task");
            filters.Add(searchFilterClass);

            List<Folder> taskFolders = 
                GetFolders(service, filters, WellKnownFolderName.Root, true);

            foreach (var folder in taskFolders)
            {
                PropertySet propertySet = new PropertySet(FolderSchema.DisplayName);
                folder.Load(propertySet);
                Console.WriteLine("Rename the tasks in {0}:",folder.DisplayName);

                const Int32 pageSize = 50;
                ItemView itemView = new ItemView(pageSize);

                FindItemsResults<Item> findResults = null;
                do
                {
                    findResults = folder.FindItems(itemView);
                    foreach (Item item in findResults.Items)
                    {
                        // If the item is the task, rename the item.
                        if (item is Task)
                        {
                            RenameTask(item as Task);
                        }
                    }

                    itemView.Offset += pageSize;
                } while (findResults.MoreAvailable);
            }
        }

        /// <summary>
        /// Add the category of the task as the prefix of task's subject.
        /// </summary>
        private static void RenameTask(Task task)
        {
            if (!(task is Task))
            {
                return;
            }

          String preCategory="["+ task.Categories[0].ToString()+"]";

          if (!task.Subject.Contains(preCategory))
          {
              task.Subject = preCategory + task.Subject;
              task.Update(ConflictResolutionMode.AutoResolve);
              Console.WriteLine("Rename task as {0}",task.Subject);
          }
        }

        /// <summary>
        /// Get the folders in the specific folder.
        /// </summary>
        private static List<Folder> GetFolders(ExchangeService service, SearchFilter filter, 
            WellKnownFolderName folder,Boolean isDeep)
        {
            if (service == null)
            {
                return null;
            }

            List<Folder> folders = new List<Folder>();
            
            PropertySet propertySet = new PropertySet(BasePropertySet.IdOnly);

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
