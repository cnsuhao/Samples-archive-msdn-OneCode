/****************************** Module Header ******************************\
Module Name:  XmlHandler.cs
Project:      CSASPNETIntelligentErrorPage
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to create the intelligent error page in 
Asp.net application. In this sample, we add a custom 404 error page and find 
the similar local resources, then display them in error page. In this way, 
we will improve the user-experience, since users don’t need to face a boring 
and helpless error page any more.

The XmlHandler class will get data from xml file. It also includes some basic
methods of the sample code.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace CSASPNETIntelligentErrorPage
{
    public class XmlHandler
    {
        DataTable tabItems = new DataTable();
        string xmlPath = string.Empty;
        public XmlHandler(string url)
        {
            this.xmlPath = url;
            DataColumn dcName = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn dcCategory = new DataColumn("Category", Type.GetType("System.String"));
            DataColumn dcUrl = new DataColumn("Path", Type.GetType("System.String"));
            tabItems.Columns.Add(dcName);
            tabItems.Columns.Add(dcCategory);
            tabItems.Columns.Add(dcUrl);
        }

        public DataTable GetOpenData()
        {
            tabItems.Clear();
            XDocument document = XDocument.Load(xmlPath);
            var items = from item in document.Descendants("Item")
                        where item.Attribute("open").Value == "1"
                        select
                        item;
            foreach (var item in items)
            {
                DataRow dr = tabItems.NewRow();
                dr["Name"] = item.Element("Name").Value;
                dr["Category"] = item.Element("Category").Value;
                dr["Path"] = item.Element("Path").Value;
                tabItems.Rows.Add(dr);
            }
            return tabItems;
        }

        public DataTable GetDataItemByName(string name)
        {
            tabItems.Clear();
            XDocument document = XDocument.Load(xmlPath);
            var items = from item in document.Descendants("Item")
                        where item.Element("Category").Value.ToLower().Contains(name.ToLower())
                        || item.Element("Name").Value.ToLower().Contains(name.ToLower())
                        select new ItemModel
                        {
                            Name = item.Element("Name").Value,
                            Category = item.Element("Category").Value,
                            Url = item.Element("Path").Value
                        };
            foreach (var item in items)
            {
                DataRow dr = tabItems.NewRow();
                dr["Name"] = item.Name;
                dr["Category"] = item.Category;
                dr["Path"] = item.Url;
                tabItems.Rows.Add(dr);
            }
            return tabItems;
        }
    }
}