/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365SetRetentionPolicy
Copyright (c) Microsoft Corporation.

Currently, you can easily set email messages with retention policy enabled in 
Outlook and Outlook Web App. But you may find it is not very convenient to set 
retention policy for email messages in a specific time range. In this 
application, we will demonstrate how to set retention policy for email 
messages in office 365:
1. Select the email messages you want to apply the retention policy to;
2. Choose the retention policy you want to set for the email messages;
3. Set the retention policy for the email messages.

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
using System.IO;

namespace CSO365SetRetentionPolicy
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback =
CallbackMethods.CertificateValidationCallBack;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);

            // Get the information of the account.
            UserInfo user = new UserInfo();
            service.Credentials = new WebCredentials(user.Account, user.Pwd);

            // Set the url of server.
            if (!AutodiscoverUrl(service, user))
            {
                return;
            }
            Console.WriteLine();

            DateTime today = DateTime.Now;
            SetRetentionPolicyTags(service, user.Account, null, today.AddDays(-30), today,
                null, null, null);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Select the email message basing the subject, start date, end date, from, displayTo, displayCc
        /// </summary>
        private static List<Item> SearchEmailMessages(ExchangeService service, String subject,
            DateTime startDate, DateTime endDate, String from, String displayTo, String displayCc)
        {
            PropertySet itemPropertySet =
                new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.PolicyTag);

            SearchFilter.SearchFilterCollection searchFilterCollection =
                new SearchFilter.SearchFilterCollection(LogicalOperator.And);

            SearchFilter startDateFilter =
                new SearchFilter.IsGreaterThanOrEqualTo(EmailMessageSchema.DateTimeCreated, startDate);
            SearchFilter endDateFilter =
                new SearchFilter.IsLessThanOrEqualTo(EmailMessageSchema.DateTimeCreated, endDate);
            // Just select the email message items.
            SearchFilter itemClassFilter =
                new SearchFilter.IsEqualTo(EmailMessageSchema.ItemClass, "IPM.Note");
            searchFilterCollection.Add(startDateFilter);
            searchFilterCollection.Add(endDateFilter);
            searchFilterCollection.Add(itemClassFilter);

            if (!String.IsNullOrWhiteSpace(subject))
            {
                SearchFilter subjectFilter =
                    new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, subject);
                searchFilterCollection.Add(subjectFilter);
            }

            if (!String.IsNullOrWhiteSpace(from))
            {
                SearchFilter fromFilter =
                    new SearchFilter.ContainsSubstring(EmailMessageSchema.From, from);
                searchFilterCollection.Add(fromFilter);
            }

            if (!String.IsNullOrWhiteSpace(displayTo))
            {
                SearchFilter displayToFilter =
                    new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayTo, displayTo);
                searchFilterCollection.Add(displayToFilter);
            }

            if (!String.IsNullOrWhiteSpace(displayCc))
            {
                SearchFilter displayCcFilter =
                    new SearchFilter.ContainsSubstring(EmailMessageSchema.DisplayCc, displayCc);
                searchFilterCollection.Add(displayCcFilter);
            }

            List<Item> items = GetItems(service, searchFilterCollection, WellKnownFolderName.Inbox, itemPropertySet);

            Console.WriteLine("{0,-30}{1}", "Subject", "PolicyTag");
            foreach (Item item in items)
            {
                Console.WriteLine("{0,-30}{1}", item.Subject, item.PolicyTag);
            }
            Console.WriteLine();

            return items;
        }

        /// <summary>
        /// Return the retention policy that the users choose.
        /// </summary>
        private static RetentionPolicyTag GetRetentionPolicyTag(ExchangeService service, String userAddress)
        {
            service.GetPasswordExpirationDate(userAddress);

            if (service.ServerInfo.MajorVersion < 15)
            {
                Console.WriteLine("This version of Exchange does't support PolicyTag.");
                return null;
            }

            GetUserRetentionPolicyTagsResponse getUserRetentionPolicyTagsResponse =
                service.GetUserRetentionPolicyTags();

            if (getUserRetentionPolicyTagsResponse.ErrorCode != ServiceError.NoError)
            {
                Console.WriteLine("Error:{0}", getUserRetentionPolicyTagsResponse.ErrorMessage);
                return null;
            }

            RetentionPolicyTag[] retentionPolicyTags =
                getUserRetentionPolicyTagsResponse.RetentionPolicyTags;

            do
            {
                Int32 policyTagsCount = -1;
                foreach (RetentionPolicyTag retentionPolicyTag in retentionPolicyTags)
                {
                    policyTagsCount++;
                    Console.WriteLine("{0,-3}: {1}", policyTagsCount, retentionPolicyTag.DisplayName);
                }

                Console.Write("Please choose the Retention Policy Tag which you want to set for the email messages(0-{0}):",
                    policyTagsCount);
                String selectedPolicyTag = Console.ReadLine();
                Int32 selectedPolicyTagNum = -1;

                if (Int32.TryParse(selectedPolicyTag, out selectedPolicyTagNum) &&
                    selectedPolicyTagNum >= 0 && selectedPolicyTagNum <= policyTagsCount)
                {
                    return retentionPolicyTags[selectedPolicyTagNum];
                }
            } while (true);

        }

        /// <summary>
        /// Set the retention policy for the selected email messages.
        /// </summary>
        private static void SetRetentionPolicyTags(ExchangeService service, String userAddress,
            String subject, DateTime startDate, DateTime endDate, String from, String displayTo,
            String displayCc)
        {
            Console.WriteLine("Email messages before setting Retention Policy");
            List<Item> items = SearchEmailMessages(service, subject, startDate, endDate, from,
                displayTo, displayCc);

            Console.WriteLine("Retention Policy Tags:");
            RetentionPolicyTag retentionPolicyTag = GetRetentionPolicyTag(service, userAddress);
            Console.WriteLine();

            if (retentionPolicyTag != null)
            {
                Console.WriteLine("Setting the Retention Policy...");
                PolicyTag policyTag = new PolicyTag(true, retentionPolicyTag.RetentionId);

                foreach (Item item in items)
                {
                    item.PolicyTag = policyTag;
                    item.Update(ConflictResolutionMode.AlwaysOverwrite);
                }
            }
            else
            {
                return;
            }
            Console.WriteLine();

            Console.WriteLine("Email messages after setting Retention Policy:");
            SearchEmailMessages(service, subject, startDate, endDate, from, displayTo, displayCc);
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
                Console.WriteLine("Connect the Exchange Online successfully.");

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
