/****************************** Module Header ******************************\
Module Name:  ErrorPage.aspx.cs
Project:      CSASPNETIntelligentErrorPage
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to create the intelligent error page in 
Asp.net application. In this sample, we add a custom 404 error page and find 
the similar local resources, then display them in error page. In this way, 
we will improve the user-experience, since users don’t need to face a boring 
and helpless error page any more.

This page is a custom 404 error page and it can find similar local resources
by file name.
 
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
using System.Data;

namespace CSASPNETIntelligentErrorPage
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        const string xmlPath = "~/App_Data/XmlData.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.QueryString["aspxerrorpath"].ToString();
            string fileFullName = path.Substring(path.LastIndexOf('/') + 1);
            string fileName = fileFullName.Substring(0,fileFullName.LastIndexOf('.'));
            XmlHandler handler = new XmlHandler(Server.MapPath(xmlPath));
            DataTable tab = new DataTable();
            tab = handler.GetDataItemByName(fileName);
            lvwPageList.DataSource = tab;
            lvwPageList.DataBind();
        }
    }
}