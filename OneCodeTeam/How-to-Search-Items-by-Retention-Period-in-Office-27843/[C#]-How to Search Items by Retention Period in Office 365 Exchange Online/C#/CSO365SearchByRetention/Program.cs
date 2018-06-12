/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365SearchByRetention
Copyright (c) Microsoft Corporation.

Now we can easily search email messages by retention policy in Outlook. But 
this feature is not available in Outlook Web App(OWA). In this application, 
we demonstrate how to search email messages with retention policy enabled in 
Office 365 Exchange Online by using Exchange Web Service Managed API.
We use the following extend properties to search and get the information: 
1. PidTagRetentionPeriod (Property ID:0x301A);
2. PidTagRetentionDate (Property ID:0x301C).

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

namespace CSO365SearchByRetention
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the Retention Period that you want to search(Split by Space):");
            List<Int32> searchPeriods=GetRetentionPeriod();
            Console.WriteLine();

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

            SearchByRetentionPeriod(service, WellKnownFolderName.Inbox,searchPeriods);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Search the Items by the retention period
        /// </summary>
        private static void SearchByRetentionPeriod(ExchangeService service, WellKnownFolderName rootFolder,
            List<Int32> periods)
        {
            // Use two extend properties to get the retention period and the expire date.
            const Int32 pidTagRetentionPeriod = 12314;
            ExtendedPropertyDefinition exPropRetentionPeriod = 
                new ExtendedPropertyDefinition(pidTagRetentionPeriod, MapiPropertyType.Integer);

            const Int32 pidTagRetentionDate = 12316;
            ExtendedPropertyDefinition exPropRetentionDate = 
                new ExtendedPropertyDefinition(pidTagRetentionDate, MapiPropertyType.SystemTime);

            PropertySet propertySet = 
                new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.Subject, EmailMessageSchema.ParentFolderId);

            propertySet.Add(exPropRetentionPeriod);
            propertySet.Add(exPropRetentionDate);

            SearchFilter.SearchFilterCollection searchFilterCollection = new SearchFilter.SearchFilterCollection();

            // If specify the retention periods, we can set the search filter by them.
            if (periods != null)
            {
                searchFilterCollection.LogicalOperator = LogicalOperator.Or;

                foreach (Int32 period in periods)
                {
                    SearchFilter.IsEqualTo searchFilter = new SearchFilter.IsEqualTo(exPropRetentionPeriod, period);
                    searchFilterCollection.Add(searchFilter);
                }
            }
            else
            {
                SearchFilter searchFilter = new SearchFilter.Exists(exPropRetentionPeriod);
                searchFilterCollection.Add(searchFilter);
            }

            ItemView itemView = new ItemView(100);
            itemView.PropertySet = propertySet;

            // Use search folder to search.
            SearchFolder searchFolder = new SearchFolder(service);
            searchFolder.SearchParameters.RootFolderIds.Add(rootFolder);
            searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep;
            searchFolder.SearchParameters.SearchFilter = searchFilterCollection;
            searchFolder.DisplayName = DateTime.Now.ToString("yyyyMMddhhmmss");
            searchFolder.Save(WellKnownFolderName.SearchFolders);

            FindItemsResults<Item> findResults = null;
            Dictionary<String,String> mailboxFolderNames=new Dictionary<String,String>();
            Console.WriteLine("Following are the search results:");
            Console.WriteLine("Subject             FolderName     RententionPeriod  ExpireDateTime");
            do
            {
                findResults=searchFolder.FindItems(itemView);

                foreach (Item findResult in findResults)
                {
                    Object rPeriod = findResult.ExtendedProperties[0].Value;
                    Object expireDateTime = findResult.ExtendedProperties[1].Value;

                    if (!mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId))
                    {
                        Folder folder = Folder.Bind(service, findResult.ParentFolderId);
                        mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName);
                    }


                    String folderName = mailboxFolderNames[findResult.ParentFolderId.UniqueId];

                    Console.WriteLine("{0,-20}{1,-15}{2,-18}{3}", findResult.Subject, folderName, rPeriod, expireDateTime);
                }
            } while (findResults.MoreAvailable);


            searchFolder.Delete(DeleteMode.HardDelete);
        }

        /// <summary>
        /// Get the retention period that the users input.
        /// </summary>
        private static List<Int32> GetRetentionPeriod()
        {
            Boolean isNumber = true;
            do
            {
                isNumber = true;
                String retentionPeriod = Console.ReadLine();

                // '*' means to get all the Items that were applied the retention policy, or means get 
                // the Items in specific retention periods.
                if (String.Compare(retentionPeriod.Trim(), "*") != 0)
                {
                    String[] periods = retentionPeriod.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    List<Int32> searchPeriods = new List<int>();

                    foreach (String period in periods)
                    {
                        Int32 periodValue;
                        if (Int32.TryParse(period, out periodValue))
                        {
                            searchPeriods.Add(periodValue);
                        }
                        else
                        {
                            Console.WriteLine("Please input numbers!");
                            isNumber = false;
                            break;
                        }
                    }
                   
                    if (isNumber)
                    {
                        return searchPeriods;
                    }
                }
            } while (!isNumber);

            return null;
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
