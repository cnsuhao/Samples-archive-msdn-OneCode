/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365GetDelegates
Copyright (c) Microsoft Corporation.

Currently, you can easily get delegates in Outlook. But you find this feature 
is not available in Outlook Web App (OWA). In this application, we will 
demonstrate how get the delegate information of multi accounts.
1. Get the accounts that users input
2. Set the ImpersonatedUserId property if the login account has the 
impersonation permission.
3. Get all the delegate information of the accounts. 

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

namespace CSO365GetDelegates
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

            GetDelegates(service, user.Account);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Get the delegate information of the accounts that users input
        /// </summary>
        static void GetDelegates(ExchangeService service, String currentAddress)
        {
            do
            {
                service.ImpersonatedUserId = null;
                // If we have the impersonation permission, we can impersonate the other accounts 
                // to get the delegate information, or we can only get the delegate information of 
                // the login account. 
                Console.WriteLine("Please input the user identity you want to get the "+
                    "information of delegate(or you can directly press Enter to get delegates"+
                    " of current account):");
                String inputInfo = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(inputInfo))
                {
                    // You can input the "EXIT" to exit.
                    if (inputInfo.ToUpper().CompareTo("EXIT") == 0)
                    {
                        return;
                    }

                    String[] identities = inputInfo.Split(',');

                    foreach (String identity in identities)
                    {
                        // If the user identity is valid, we will set it as the ImpersonatedUserId.
                        NameResolutionCollection nameResolutions = 
                            service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
                        if (nameResolutions.Count != 1)
                        {
                            Console.WriteLine("{0} is invalid user identity.", identity);
                        }
                        else
                        {
                            String emailAddress = nameResolutions[0].Mailbox.Address;
                            service.ImpersonatedUserId = 
                                new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                            GetAccountDelegates(service, emailAddress);
                        }
                    }
                }
                else
                {
                    // We can also directly press Enter to get the delegate information of the 
                    // login account.
                    GetAccountDelegates(service, currentAddress);
                }
            } while (true);
        }

        /// <summary>
        /// Get the delegate information of the specific account.
        /// </summary>
        static void GetAccountDelegates(ExchangeService service, String emailAddress, params UserId[] userIds)
        {
            var emailBox = new Mailbox(emailAddress);

            DelegateInformation result = service.GetDelegates(emailBox, true, userIds);

            foreach (var response in result.DelegateUserResponses)
            {
                if (response.ErrorCode != ServiceError.NoError)
                {
                    Console.WriteLine(response.ErrorMessage);
                }
                else
                {
                    Console.WriteLine("{0,-30}:{1}", "Identity", emailAddress);
                    Console.WriteLine("{0,-30}:{1}", "MeetingRequestsDeliveryScope", 
                        result.MeetingRequestsDeliveryScope);
                    Console.WriteLine("{0,-30}:{1}", "DelegateUser", 
                        response.DelegateUser.UserId.PrimarySmtpAddress);
                    Console.WriteLine("{0,-30}:{1}", "ReceiveCopiesOfMeetingMessages", 
                        response.DelegateUser.ReceiveCopiesOfMeetingMessages);
                    Console.WriteLine("{0,-30}:{1}", "ViewPrivateItems", 
                        response.DelegateUser.ViewPrivateItems);
                    Console.WriteLine("{0,-30}:{1}", "CalendarFolderPermissionLevel", 
                        response.DelegateUser.Permissions.CalendarFolderPermissionLevel);
                    Console.WriteLine("{0,-30}:{1}", "TasksFolderPermissionLevel", 
                        response.DelegateUser.Permissions.TasksFolderPermissionLevel);
                    Console.WriteLine("{0,-30}:{1}", "InboxFolderPermissionLevel", 
                        response.DelegateUser.Permissions.InboxFolderPermissionLevel);
                    Console.WriteLine("{0,-30}:{1}", "ContactsFolderPermissionLevel", 
                        response.DelegateUser.Permissions.ContactsFolderPermissionLevel);
                    Console.WriteLine("{0,-30}:{1}", "NotesFolderPermissionLevel", 
                        response.DelegateUser.Permissions.NotesFolderPermissionLevel);
                    Console.WriteLine("{0,-30}:{1}", "JournalFolderPermissionLevel", 
                        response.DelegateUser.Permissions.JournalFolderPermissionLevel);

                    Console.WriteLine();
                }
            }
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
