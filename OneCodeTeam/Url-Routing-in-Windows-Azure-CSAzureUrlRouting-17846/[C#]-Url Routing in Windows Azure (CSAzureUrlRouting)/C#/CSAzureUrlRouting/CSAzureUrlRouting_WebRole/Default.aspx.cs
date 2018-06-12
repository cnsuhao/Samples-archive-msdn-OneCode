/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      CSAzureUrlRouting_WebRole
Copyright (c) Microsoft Corporation.
 
This sample demonstrates how to use URL routing in Azure application. As we know, 
URL Routing is a common technology in ASP.NET and MVC applications, customers 
also want to know how to migrate to the original project to Windows Azure Platform.

This page is used to add some test URLs for testing.

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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CSAzureUrlRouting_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        public string FilePath;

        /// <summary>
        /// Add test links on Default.aspx page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<a href='{0}'>page1</a> <br />", "page/pageresources/page1.aspx"));
            sb.Append(string.Format("<a href='{0}'>page2</a> <br />", "page/pageresources/page2.aspx"));
            sb.Append(string.Format("<a href='{0}'>page3</a> <br />", "page/pageresources2/page3.aspx"));
            sb.Append(string.Format("<a href='{0}'>page4</a> <br />", "page/pageresources2/page4.aspx"));
            sb.Append(string.Format("<a href='{0}'>sample1</a> <br />", "sample/sample/sample1.aspx"));
            sb.Append(string.Format("<a href='{0}'>sample2</a> <br />", "sample/sample/sample2.aspx"));
            FilePath = sb.ToString();
        }
    }
}