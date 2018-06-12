/*********************************** Console Application Main() Source  ***********************************\
Module Name:  CSListServiceSPN.Main
Project:      CSListServiceSPN
Copyright (c) Microsoft Corporation.

 * CSListServiceSPN project shows how to list all the Service Principal Names SPNs of any Service.
 * It will search the Domain acvounts for the specific Service SPN or will list all SPNs of any Service across all accounts.
 
This is the code behind of the markeup file which interfaces the user.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Collections;

namespace CSListServiceSPN
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // *************Printing out the usage **********************
                Console.WriteLine(" Search Service Principal Name for any Service in a Domain Account ( DNS, Computer etc)");
                Console.WriteLine(" Enter the type of Service (HTTP, MSSQLSvc, HOST etc: ");
                // Read the Service Type from Console
                string ServiceType = Console.ReadLine();

                Console.WriteLine(" Enter the partial Name of the Domain Account in which you want to search the SPN. Leave it blank to look in all domain accounts: ");
                // Read the sAMACcountName from the Console 
                string AccountName = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Searching..................");
                // Call the ListSPN inside the foreach... and print the returned ArrayList
                foreach (string value in ListSPN(ServiceType, AccountName))
                    Console.WriteLine(value);

                Console.WriteLine("------------End-------------");
            }
            catch (Exception ex)
            { Console.WriteLine("Error :" + ex.InnerException + ex.Message); }

        }


        /****
         * <Summary>
         * 
         * This function will search the SPNs based on Servicetype and optional AccountName
         * Funtion ListSPN (string ServiceType, string AccoutName)
         * <param name="ServiceType">the Servicetype for which the SPNs has to be listed Ex: HTTP, HOST, MSSQLSvc
         * <param name="AccountName"> optional sAMAccoutName of the domain account for which the SPNs are to be searched.
         * */
        static ArrayList ListSPN(string ServiceType, string AccountName="")
        {
            //Arry list object for holding the final result to be returned.
            ArrayList SPNs = new ArrayList();

            // string object for the ldap filter for using with DirectoryServer 
            string spnfilter = "(servicePrincipalName={0}/*)";
            spnfilter = String.Format(spnfilter, ServiceType);

            //Directory entry object for the domain for searcher
            System.DirectoryServices.DirectoryEntry domain = new DirectoryEntry();

            //DirectorySercher object for searching the SPNs
            System.DirectoryServices.DirectorySearcher searcher = new DirectorySearcher();
            searcher.SearchRoot = domain;
            searcher.PageSize = 1000;
            searcher.Filter = spnfilter;

            //fire the search and collect the result back
            SearchResultCollection results = searcher.FindAll();

            // main loop for iterating through the result items
            foreach (SearchResult result in results)
            {
                //  Convert the result item to DirectoryEntry object 
                DirectoryEntry account = result.GetDirectoryEntry();

                //Compare the item's sAMAccountName with the "Accountname" parameter
                //if the "AccountName" paramenter is empty or null, it results all accounts.
                if (account.Properties["sAMAccountName"].Value.ToString().Contains(AccountName))
                {
                    //Loop through the collection of SPNs in the filterter DirectoryEntry object 
                    foreach (string spn in account.Properties["servicePrincipalName"])
                    {
                        //if the SPN contains the ServiceType, add to the ArrayList
                        if (spn.Contains(ServiceType))
                        {
                            SPNs.Add(spn);
                        }
                    }
                }

            }


            //Return the final ArrayList to the main 
            return SPNs;

        }

            

           
            
        
    }
        
    }

