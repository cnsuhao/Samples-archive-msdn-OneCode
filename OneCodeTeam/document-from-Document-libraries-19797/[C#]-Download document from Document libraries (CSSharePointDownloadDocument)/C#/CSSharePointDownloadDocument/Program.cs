/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSSharePointDownloadDocument
* Copyright (c) Microsoft Corporation
*
* This demo will demonstrate how to download the documents from SharePoint
* document libraries across site collection in an easy fashion.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using System.IO;

namespace CSSharePointDownloadDocument
{
    class Program
    {

        private static void Main(string[] args)
        {
            // Path to download the files
            string strDownloadPath = @"C:\MyDownloadFolder\";
            string url = "http://Site_Url"; 
            using (SPSite oSiteCollection = new SPSite(url))
            {
                SPWebCollection collWebsites = oSiteCollection.AllWebs;
                Console.WriteLine("Websites Count: {0}", collWebsites.Count);
                Console.WriteLine(" ");
                string rootwebtitle = oSiteCollection.RootWeb.Title;
                foreach (SPWeb oWebsite in collWebsites)
                {
                    Console.WriteLine("Site : " + oWebsite.Title);
                   
                    string websiteurl = oWebsite.Url;
                    string framedUrl = websiteurl.Replace(oSiteCollection.Url, "");
                    string path = strDownloadPath + "\\" + rootwebtitle + framedUrl.Replace('/', '\\');
                    Directory.CreateDirectory(path);
                    DownloadDocs(oWebsite.Url, path);
                    oWebsite.Dispose();
                    Console.WriteLine("--------------------");
                }
            }
            Console.WriteLine("Please click enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Add the OOTB document library name to a list, document library in this list will not be downloaded.
        /// According to the specified url circulation Site list, and then obtain the document
        /// library and compared with the OOTB document libraries's name list;
        /// If the document library's name does not exist in the OOTB list, download the document library.
        /// </summary>
        /// <param name="siteURL">Site URL</param>
        /// <param name="sitepath">Site Path</param>
        private static void DownloadDocs(string siteURL, string sitepath)
        {
            // List of OOTB document libraries - These doc libraries will not be downloaded
            List<string> ootbLib = new List<string>();
            ootbLib.Add("Converted Forms");
            ootbLib.Add("Form Templates");
            ootbLib.Add("Images");
            ootbLib.Add("List Template Gallery");
            ootbLib.Add("Master Page Gallery");
            ootbLib.Add("Pages");
            ootbLib.Add("Reporting Templates");
            ootbLib.Add("Site Collection Documents");
            ootbLib.Add("Site Collection Images");
            ootbLib.Add("Site Template Gallery");
            ootbLib.Add("Style Library");
            ootbLib.Add("Web Part Gallery");

            // Open site
            using (SPSite oSite = new SPSite(siteURL))
            {
                // Open web
                using (SPWeb oWeb = oSite.OpenWeb())
                {
                    // Loop site lists
                    foreach (SPList list in oWeb.Lists)
                    {
                        // Storage path
                        string actpath = sitepath + "\\" + list.Title + "\\";

                        // Obtain the document library by list.BaseType
                        if (list.BaseType == SPBaseType.DocumentLibrary)
                        {
                            // Determine whether the document library is OOTB document library or not
                            if (!ootbLib.Exists(delegate(string p) { return p.Trim() == list.Title; }))
                            {
                                Console.WriteLine("Downloading from Library ::" + list.Title);
                                Directory.CreateDirectory(actpath);
                                TraverseAllListItems(list, actpath);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Traverse all ListItems and download
        /// </summary>
        /// <param name="list">List of operation</param>
        /// <param name="path">Storage path</param>
        private static void TraverseAllListItems(SPList list, string path)
        {
            SPQuery qry = new SPQuery();
            qry.ViewAttributes = "Scope=\"Recursive\"";

            try
            {
                SPListItemCollection ic = list.GetItems(qry);

                foreach (SPListItem subitem in ic)
                {                   
                    string itemurl = subitem.Url;
                    int index = itemurl.IndexOf("/");
                    string subpath = itemurl.Substring(index + 1);
                    string finalpath = path + subpath;
                    finalpath = finalpath.Replace(subitem.Name, "");
                    finalpath = finalpath.Replace("/", "\\");
                    Console.WriteLine(finalpath);
                    Directory.CreateDirectory(finalpath);
                    byte[] binFile = subitem.File.OpenBinary();
                    System.IO.FileStream fstream = System.IO.File.Create(finalpath + "\\" + subitem.Name);
                    fstream.Write(binFile, 0, binFile.Length);
                    fstream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}