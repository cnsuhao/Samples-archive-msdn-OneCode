/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSSharePointGetListIDFromListUrl
* Copyright (c) Microsoft Corporation
*
* The sample will show you how to get the list ID, name from the list url by 
* using web service. In this sample, we use Lists.GetListCollection Method 
* of list web Services. It will return a System.Xml.XmlNode object. You can 
* get the value of the attribute “DefaultViewUrl” and append it to site url. 
* After that, you should compare the url with your list url, and then find the 
* list ID value.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System.Xml;
using CSSPGetListIDFromListUrl.ServiceReference1;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CSSharePointGetListIDFromListUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            String baseUrl = "http://Yoursite"; // Your own site        
            string strListUrl = string.Empty;   // The specified URL

            Lists wsLists = new Lists();    // List web service
            wsLists.Url = baseUrl + "/sites/subsite/_vti_bin/Lists.asmx";   // Url
            wsLists.Credentials = System.Net.CredentialCache.DefaultCredentials;    // Credentials

            // Get ListCollection
            XmlNode xn = wsLists.GetListCollection();

            // An instance of XmlNodeReader
            XmlNodeReader xnr = new XmlNodeReader(xn);

            // Load XElement
            XElement listMetadatas = XElement.Load(xnr);

            // Search collection of elements
            IEnumerable<XElement> childElements = from el in listMetadatas.Elements()
                                                  select el;

            #region DocumentLib
            Console.WriteLine("-----------------------DocumentLib--------------------------");

            strListUrl = "http://Yoursite/sites/subsite/folder1";   // root URL of the library 
            GetIdAndName(childElements, baseUrl, strListUrl);
            Console.WriteLine("-------------------------------------------------");

            strListUrl = "http://Yoursite/sites/subsite/folder1/Forms/AllItems.aspx";    // The initialview
            GetIdAndName(childElements, baseUrl, strListUrl);

            Console.WriteLine("-------------------------------------------------");

            strListUrl = "http://Yoursite/sites/subsite/folder1/Forms/testview.aspx";   // New DefaultView
            GetIdAndName(childElements, baseUrl, strListUrl);
            #endregion

            #region Lists
            Console.WriteLine("-----------------------list--------------------------");

            strListUrl = "http://Yoursite/sites/subsite/Lists/contacts1";   // root URL of the list 
            GetIdAndName(childElements, baseUrl, strListUrl);

            Console.WriteLine("-------------------------------------------------");

            strListUrl = "http://Yoursite/sites/subsite/Lists/contacts1/AllItems.aspx"; // The initialview
            GetIdAndName(childElements, baseUrl, strListUrl);
            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// Get Id and name by the specified URL
        /// </summary>
        /// <param name="childElements">All list Elements</param>
        /// <param name="baseUrl">Your own site</param>
        /// <param name="strListUrl">the specified URL</param>
        private static void GetIdAndName(IEnumerable<XElement> childElements, string baseUrl, string strListUrl)
        {
            // Temporarily store the url of default view.    
            string strCurrentUrl = string.Empty;

            foreach (XElement el in childElements)
            {
                // Get url by appending the DefaultViewUrl to site url.
                strCurrentUrl = baseUrl + el.Attribute("DefaultViewUrl").Value;

                // If current url contains the specified url. 
                if ((strCurrentUrl).Contains(strListUrl))
                {
                    Console.WriteLine("ID:" + el.Attribute("ID").Value);
                    Console.WriteLine("Title:" + el.Attribute("Title").Value);
                    Console.WriteLine("DefaultViewUrl:" + el.Attribute("DefaultViewUrl").Value);
                }
            }
        }
    }
}
