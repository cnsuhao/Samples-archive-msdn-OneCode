/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365SearchSharedMailbox
Copyright (c) Microsoft Corporation.

Currently, Outlook Web App doesn't allow you to search calendar items in a 
shared mailbox. But some of you require this feature for some reasons. In 
this sample, we will demonstrate how to search calendar items from shared 
mailbox:
1. Get the shared mailbox that users input
2. Get the search filter, such as the start date, end date, subject.
3. Set the ImpersonatedUserId property if the login account has the impersonation 
permission.
4. Search the items in the shared mailbox. 

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

namespace CSO365SearchSharedMailbox
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

            GetSharedMailboxItems(service, user.Account);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Search the calendar items in Shared Mailbox
        /// </summary>
        static void GetSharedMailboxItems(ExchangeService service, String currentAddress)
        {
            do
            {
                service.ImpersonatedUserId = null;
                // If we have the impersonation permission, we can impersonate the shared mailbox 
                // to search the calendar items.
                Console.WriteLine("Please input the Shared Mailbox identity you want to get the " +
                    "items");
                String identity = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(identity))
                {
                    // You can input the "EXIT" to exit.
                    if (identity.ToUpper().CompareTo("EXIT") == 0)
                    {
                        return;
                    }

                    // If the shared mailbox identity is valid, we will set it as the ImpersonatedUserId.
                    NameResolutionCollection nameResolutions =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, false);
                    if (nameResolutions.Count != 1)
                    {
                        Console.WriteLine("{0} is invalid Shared Mailbox identity.", identity);
                        Console.WriteLine();
                    }
                    else
                    {
                        String emailAddress = nameResolutions[0].Mailbox.Address;

                        Console.WriteLine();
                        Console.WriteLine("Please input the start date(15 days before today is the defined date.):");
                        String startDate = Console.ReadLine();
                        Console.WriteLine("Please input the end dateI(30 days after start date is the defined date.):");
                        String endDate = Console.ReadLine();

                        Console.WriteLine("Please input the subject that you want to search(Press Enter directly to get all the itmes):");
                        String searchSubject = Console.ReadLine();
                        Console.WriteLine();

                        service.ImpersonatedUserId =
                            new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                        GetSharedMailboxCalendarItems(service, emailAddress, searchSubject, 
                            startDate, endDate);
                    }
                }
                else
                {
                    Console.WriteLine("Identity cannot be null.");
                }
            } while (true);
        }

        /// <summary>
        /// Search the calendar items in Shared Mailbox
        /// </summary>
        static void GetSharedMailboxCalendarItems(ExchangeService service, String emailAddress, 
            String searchSubject, String startDate, String endDate)
        {
            // If the date is invaild, we will set 15 days before today as the start date.
            DateTime startSearchDate;
            startSearchDate =
                DateTime.TryParse(startDate, out startSearchDate) ? startSearchDate : DateTime.Now.AddDays(-15);
            // If the date is invaild, we will set 30 days after the start date as the end date.
            DateTime endSearchDate;
            endSearchDate =
                DateTime.TryParse(endDate, out endSearchDate) && endSearchDate >= startSearchDate ?
                endSearchDate : startSearchDate.AddDays(30);

            FolderId folderId = new FolderId(WellKnownFolderName.Calendar);

            SearchFilter.SearchFilterCollection searchFilterCollection = 
                new SearchFilter.SearchFilterCollection();
            searchFilterCollection.LogicalOperator = LogicalOperator.And;

            // If you want search the specified subject, you can define the filter; or you will get all
            // the items that contain the Subject schema.
            if (String.IsNullOrWhiteSpace(searchSubject))
            {
                SearchFilter searchFilter = new SearchFilter.Exists(AppointmentSchema.Subject);
                searchFilterCollection.Add(searchFilter);
            }
            else
            {
                SearchFilter searchFilter = 
                    new SearchFilter.ContainsSubstring(AppointmentSchema.Subject, searchSubject);
                searchFilterCollection.Add(searchFilter);
            }

            SearchFilter startDateFilter = 
                new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.DateTimeCreated, startSearchDate);
            SearchFilter endDateFilter = 
                new SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.DateTimeCreated, endSearchDate);

            searchFilterCollection.Add(startDateFilter);
            searchFilterCollection.Add(endDateFilter);

            ItemView itemView = new ItemView(100);
            itemView.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

            FindItemsResults<Item> findItems=null;
            Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-10}","Subject","Start","End","Duration");
            do
            {
                findItems=service.FindItems(folderId,searchFilterCollection,itemView);
                foreach (Item item in findItems)
                {
                    Console.Write(
                        "{0,-20}",item.Subject.Length>18?item.Subject.Substring(0,15)+"...":item.Subject);
                    
                    if (item is Appointment)
                    {
                        Appointment appointment = item as Appointment;
                        Console.Write("{0,-25}", appointment.Start);
                        Console.Write("{0,-25}", appointment.End);
                        Console.Write("{0,-10}", appointment.Duration);
                    }
                    Console.WriteLine();
                }
            }while(findItems.MoreAvailable);

            Console.WriteLine();

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
