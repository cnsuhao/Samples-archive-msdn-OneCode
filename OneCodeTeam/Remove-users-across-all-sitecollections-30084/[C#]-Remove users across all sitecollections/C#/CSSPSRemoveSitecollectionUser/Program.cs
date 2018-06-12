/****************************** Module Header ******************************\
 * Module Name:  Program.cs
 * Project:      CSSPSRemoveSitecollectionUser
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample will show you how to remove users across all sitecollections 
 * within one web application. 
 *
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
namespace CSSPSRemoveSitecollectionUser
{
    class Program
    {
        // The list of Users that will be deleted.
        static string[] usernameList = { "i:0#.w|ad\\seiya", "i:0#.w|ad\\allending" };
        // Your WebApplication Url.
        static string strApplicationUrl = "http://" + System.Environment.MachineName;

        public static void Main()
        {
            try
            {
                // Get the WebApplication by Url.
                SPWebApplication webApp = SPWebApplication.Lookup(new Uri(strApplicationUrl));
                // Output the app name.
                Console.WriteLine("Web Application:" + webApp.Name);

                // Loop all sites from the WebApplication.
                foreach (SPSite siteColl in webApp.Sites)
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("Site Collection: " + siteColl.Url);
                    Console.WriteLine("===============================================");

                    // Get all subsite of current site.
                    SPWebCollection collWebsites = siteColl.AllWebs;
                    if (collWebsites != null)
                    {
                        // Loop SPWeb of current web's SiteColection.
                        foreach (SPWeb web in collWebsites)
                        {
                            Console.WriteLine("Checking Web : " + web.Url);
                           
                            if (web.HasUniqueRoleAssignments)
                            {
                                // Directly remove user list.
                                web.Users.RemoveCollection(usernameList);

                                // While removing users, writing log or take other actions.
                                //foreach (string user in usernameList)
                                //{
                                //    var l = web.AllUsers.Cast<SPUser>().AsQueryable().Where(usr => usr.LoginName.ToUpper().Equals(user.ToUpper()));
                                //    if (l.Count() > 0)
                                //    {
                                //        web.AllUsers.Remove(user);
                                //        Console.WriteLine("User: " + user + " Successfully removed from Site ");
                                //    }
                                //    else
                                //    {
                                //        Console.WriteLine("User: " + user + " Does not exist on Site ");
                                //    }
                                //}

                            }
                            Console.WriteLine("=================================================");
                            web.Dispose();
                        }
                    }
                    siteColl.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            Console.WriteLine("Program completed; please click enter to exit");
            Console.Read();
        }
    }
}
