/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365GetInboxRules
Copyright (c) Microsoft Corporation.

Currently, most of you manage email messages by inbox rules. Especially, 
when you become an owner of a shared mailbox, you find the former owner created 
a lot of inbox rules to manage email messages efficiently. But you need to modify 
these inbox rules to meet the new business needs. Before changing these inbox 
rules, you want to find a solution to document these inbox rules in case something 
goes wrong. But you don't have an out-of-box solution.
In this application, we will demonstrate how to get Inbox rules in Office 365:
1. Get the accounts that users input
2. Set the ImpersonatedUserId property if the login account has the impersonation 
permission.
3. Get Inbox rules of the accounts. 
 
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

namespace CSO365GetInboxRules
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

            GetInboxRules(service, user.Account);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Get the Inbox rules of the accounts that users input
        /// </summary>
        static void GetInboxRules(ExchangeService service, String currentAddress)
        {
            do
            {
                service.ImpersonatedUserId = null;
                // If we have the impersonation permission, we can impersonate the other accounts 
                // to get the Inbox rules, or we can only get the Inbox rules of the login account. 
                Console.WriteLine("Please input the user identity you want to get the " +
                    "Inbox rules(or you can directly press Enter to get Inbox rules");
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
                            GetAccountGetInboxRules(service, emailAddress);
                        }
                    }
                }
                else
                {
                    // We can also directly press Enter to get the Inbox rules of the 
                    // login account.
                    GetAccountGetInboxRules(service, currentAddress);
                }
            } while (true);
        }

        /// <summary>
        /// Get the Inbox rules of the specific account.
        /// </summary>
        static void GetAccountGetInboxRules(ExchangeService service, String emailAddress,
            params UserId[] userIds)
        {
            var emailBox = new Mailbox(emailAddress);

            RuleCollection rules = service.GetInboxRules(emailAddress);

            if (rules.Count <= 0)
            {
                Console.WriteLine("There's no rule for the account {0}.", emailAddress);
                Console.WriteLine();
            }
            else
            {
                foreach (Rule rule in rules)
                {
                    Console.WriteLine("{0,-20}:{1}", "Account Identity", emailAddress);
                    Console.WriteLine("{0,-20}:{1}", "Id", rule.DisplayName);
                    Console.WriteLine("{0,-20}:{1}", "Priority", rule.Priority);
                    Console.WriteLine("{0,-20}:{1}", "IsEnabled", rule.IsEnabled);
                    Console.WriteLine("{0,-20}:{1}", "IsNotSupported", rule.IsNotSupported);
                    Console.WriteLine("{0,-20}:{1}", "IsInError", rule.IsInError);
                    Console.WriteLine("{0,-20}:{1}", "Conditions", rule.Conditions);
                    Console.WriteLine("{0,-20}:{1}", "Actions", rule.Actions);
                    Console.WriteLine("{0,-20}:{1}", "Account Identity", rule.Exceptions);

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
