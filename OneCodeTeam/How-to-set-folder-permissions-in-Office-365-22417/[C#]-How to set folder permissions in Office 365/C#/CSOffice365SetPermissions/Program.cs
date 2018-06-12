/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSOffice365SetPermissions
Copyright (c) Microsoft Corporation.

In this sample, we will demonstrate how to set the permissions in the 
folder of Office 365 Exchange Online so that the customers can share their 
folders with the other customers.
We will finish the following steps in the sample:
1. Add two permissions into the Calendar folder;
2. Update one permission in the Calendar;
3. Remove two permissions from the Calendar.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace CSOffice365SetPermissions
{
    class Program
    {
        private static UserId[] users = new UserId[2];

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

            // Get the Calendar folder.
            SearchFilter.RelationalFilter searchFilter =
                new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "Calendar");
            Folder calendar = GetFolder(service, searchFilter);

            if (calendar != null)
            {
                Console.WriteLine("It's success to bind the Calendar folder.");
                Console.WriteLine();

                // Load the Permissions property of Calendar.
                PropertySet propertySet = new PropertySet(FolderSchema.Permissions);
                calendar.Load(propertySet);
            }
            else
            {
                Console.WriteLine("Failed to get the Calendar folder.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Before any operations:");
            OutputFolderPermissionInformation(calendar);

            InputTwoUsers();

            AddFolderPermission(calendar);
            Console.WriteLine("After add two permissions:");
            OutputFolderPermissionInformation(calendar);

            UpdateFolderPermission(calendar, users[0]);
            Console.WriteLine("After update one permission:");
            OutputFolderPermissionInformation(calendar);

            RemoveFolderPermission(calendar);
            Console.WriteLine("After remove two permissions:");
            OutputFolderPermissionInformation(calendar);

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// This method will add two permissions.
        /// </summary>
        private static void AddFolderPermission(Folder folder)
        {
            FolderPermission[] newPermissions =
            {
                new FolderPermission(users[0] , FolderPermissionLevel.None),
                new FolderPermission(users[1] ,FolderPermissionLevel.Editor)
            };

            // We can't add duplicate permissions. So if we want to add one permission 
            // and there's permission belong to the same user, we should first remove it.
            FolderPermission permission =
                (from op in folder.Permissions
                 join np in newPermissions on
                 String.IsNullOrEmpty(op.UserId.PrimarySmtpAddress) ? null : op.UserId.PrimarySmtpAddress.ToUpper()
                 equals np.UserId.PrimarySmtpAddress.ToUpper()
                 select op).FirstOrDefault();

            if (permission != null)
            {
                RemoveFolderPermission(folder);
            }

            folder.Permissions.AddRange(newPermissions);
            folder.Update();

            Console.WriteLine("It's success to add two permissions.");
        }

        /// <summary>
        /// This method will update one permission
        /// </summary>
        private static void UpdateFolderPermission(Folder folder, UserId user)
        {
            // We should first get the permission that we want to update.
            FolderPermission permission = (from op in folder.Permissions
                                           where String.Compare(op.UserId.PrimarySmtpAddress,
                                           user.PrimarySmtpAddress, true) == 0
                                           select op).FirstOrDefault();

            if (permission == null)
            {
                Console.WriteLine("The permission of {0} is null.", user.PrimarySmtpAddress);
                return;
            }

            // We can change the properties of Permission.
            permission.PermissionLevel = FolderPermissionLevel.Reviewer;
            permission.ReadItems = FolderPermissionReadAccess.FullDetails;
            permission.IsFolderVisible = true;
            permission.EditItems = PermissionScope.None;

            folder.Update();

            Console.WriteLine("It's success to update the permission.");
        }

        /// <summary>
        /// This method will remove two permissions.
        /// </summary>
        private static void RemoveFolderPermission(Folder folder)
        {
            // We should first get all the permissions that we want to remove.
            IList<FolderPermission> permissions =
                (from op in folder.Permissions
                 join u in users on
                 String.IsNullOrEmpty(op.UserId.PrimarySmtpAddress) ? null : op.UserId.PrimarySmtpAddress.ToUpper()
                 equals u.PrimarySmtpAddress.ToUpper()
                 select op).ToList();

            foreach (FolderPermission permission in permissions)
            {
                if (folder.Permissions.Remove(permission))
                {
                    folder.Update();
                    Console.WriteLine("It's success to remove the permission of {0}.",
                        permission.UserId.PrimarySmtpAddress);
                }
                else
                {
                    Console.WriteLine("Failed to remove the permission of {0}.",
                        permission.UserId.PrimarySmtpAddress);
                }
            }
        }

        private static void OutputFolderPermissionInformation(Folder folder)
        {
            Console.WriteLine("All the Permissions:");

            foreach (FolderPermission permission in folder.Permissions)
            {
                Console.WriteLine("{0,-20} {1}", permission.PermissionLevel, permission.UserId.PrimarySmtpAddress);
            }

            Console.WriteLine();
        }

        private static void InputTwoUsers()
        {
            Console.WriteLine("Please input two user e-mail address:");
            Console.Write("First Address:");
            String firstAddress = Console.ReadLine();
            Console.Write("Second Address:");
            String secondAddress = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(firstAddress) || String.IsNullOrWhiteSpace(secondAddress))
            {
                Console.WriteLine("Address cannot be null.");
                InputTwoUsers();
                return;
            }

            UserId firstUser = new UserId(firstAddress);
            UserId secondUser = new UserId(secondAddress);

            users[0] = firstUser;
            users[1] = secondUser;

            Console.WriteLine("It's success to add two users.");
            Console.WriteLine();
        }

        private static Folder GetFolder(ExchangeService service, SearchFilter.RelationalFilter filter)
        {
            PropertySet propertySet = new PropertySet(BasePropertySet.IdOnly);

            FolderView folderView = new FolderView(5);
            folderView.PropertySet = propertySet;

            FindFoldersResults searchResults = searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView);

            return searchResults.FirstOrDefault();
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
