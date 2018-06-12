/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365AddDelegates
Copyright (c) Microsoft Corporation.

Currently, you can easily add delegates in Outlook. But you may find this feature 
is not available in Outlook Web App (OWA). In this application, we will 
demonstrate how to add multi delegates in Office 365 Exchange Online.
1. Get the addresses of delegates;
2. Get the addresses of primary accounts;
3. Set the ImpersonatedUserId property if the login account has the impersonation 
permission.
4. Add all the delegates into all the primary accounts.

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
using System.Reflection;
using System.Collections.ObjectModel;

namespace CSO365AddDelegates
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

            // We can set any delegate permission in AddDelegates method, but now we specify 
            // the CalendarFolderPermissionLevel property.
            AddDelegates(service, user.Account, "CalendarFolderPermissionLevel",
                DelegateFolderPermissionLevel.Reviewer);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Add multi delegates to the multi accounts
        /// </summary>
        static void AddDelegates(ExchangeService service, String currentAddress,
            String permissionLevelName, DelegateFolderPermissionLevel permissionLevel)
        {
            do
            {
                Console.WriteLine("Please input the user identity(s) that were used as the delegates:");

                String delegateInfo = Console.ReadLine();

                // We get the addresses related to the identities of delegates.
                List<String> delegateIdentities = new List<string>();
                if (!String.IsNullOrWhiteSpace(delegateInfo))
                {
                    // You can input the "EXIT" to exit.
                    if (delegateInfo.ToUpper().CompareTo("EXIT") == 0)
                    {
                        return;
                    }

                    foreach (String delegateIdentity in delegateInfo.Split(','))
                    {
                        NameResolutionCollection nameResolutions =
    service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
                        if (nameResolutions.Count != 1)
                        {
                            Console.WriteLine("{0} is invalid user identity as the delegate.",
                                delegateIdentity);
                        }
                        else
                        {
                            delegateIdentities.Add(nameResolutions[0].Mailbox.Address);
                        }
                    }

                    if (delegateIdentities.Count == 0)
                    {
                        Console.WriteLine("There's not any valid user identity as the delegate.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("The delegates cannot be null!");
                    continue;
                }

                // If we have the impersonation permission, we can impersonate the other accounts 
                // to add delegates, or we can only add delegates to the login account. 
                Console.WriteLine("Please input the user identity you want to set the " +
                    "delegates(or you can directly press Enter to set delegates in current account):");
                String primaryInfo = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(primaryInfo))
                {
                    // You can input the "EXIT" to exit.
                    if (primaryInfo.ToUpper().CompareTo("EXIT") == 0)
                    {
                        return;
                    }

                    String[] primaryIdentities = primaryInfo.Split(',');

                    foreach (String primaryIdentity in primaryIdentities)
                    {
                        // If the user identity is valid, we will set it as the ImpersonatedUserId.
                        NameResolutionCollection nameResolutions =
                     service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
                        if (nameResolutions.Count != 1)
                        {
                            Console.WriteLine("{0} is invalid user identity.", primaryIdentity);
                        }
                        else
                        {
                            String emailAddress = nameResolutions[0].Mailbox.Address;
                            service.ImpersonatedUserId =
                                new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);

                            foreach (String delegateIdentity in delegateIdentities)
                            {
                                AddAccountDelegates(service, emailAddress, delegateIdentity, 
                                    permissionLevelName, permissionLevel);
                            }
                        }
                    }
                }
                else
                {
                    // We can also directly press Enter to add the delegates to the login account. 
                    foreach (String delegateIdentity in delegateIdentities)
                    {
                        AddAccountDelegates(service, currentAddress, delegateIdentity, 
                            permissionLevelName, permissionLevel);
                    }
                }

                service.ImpersonatedUserId = null;
                Console.WriteLine();
            } while (true);
        }

        /// <summary>
        /// Add the delegate to the specific account.
        /// </summary>
        static void AddAccountDelegates(ExchangeService service, String primaryAddress, 
            String delegateAddress, String permissionLevelName, 
            DelegateFolderPermissionLevel permissionLevel)
        {
            DelegateUser delegateUser = new DelegateUser(delegateAddress);

            // Set the permission property of the delegate user.
            foreach (PropertyInfo property in typeof(DelegatePermissions).GetProperties())
            {
                if (String.Compare(property.Name, permissionLevelName) == 0)
                {
                    property.SetValue(delegateUser.Permissions, permissionLevel);
                    break;
                }
            }

            Mailbox emailBox = new Mailbox(primaryAddress);
            Collection<DelegateUserResponse> responses = service.AddDelegates(emailBox, 
                MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe, delegateUser);
            foreach (DelegateUserResponse response in responses)
            {
                Console.WriteLine("Add {0} as the delegate to the account {1}:{2}", 
                    delegateAddress, primaryAddress, response.Result);
                Console.WriteLine();
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
