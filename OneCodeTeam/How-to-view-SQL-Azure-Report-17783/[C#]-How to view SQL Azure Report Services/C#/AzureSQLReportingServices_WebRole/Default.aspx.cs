/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      AzureSQLReportingServices_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access SQL Azure Reporting Service and
get data by authenticated username/password by ReportViewer control and 
non-ReportViewer clients (such as MVC project). The ReportViewer control
with server report will help use send request to SQL Azure with credentials
message, but in MVC role, we need to send request and analysis XML by code.

This page is normal WebRole page. We need provide username/password/domain 
to ReportViewer control.

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
using System.Configuration;

namespace AzureSQLReportingServices_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get username/password/domain from web.config and send form credential to SQL Azure reporting service.
            if (!this.IsPostBack)
            {
                string user = ConfigurationManager.AppSettings["sqlAzureRSUser"];
                string password = ConfigurationManager.AppSettings["sqlAzureRSPassword"];
                string domain = ConfigurationManager.AppSettings["sqlAzureRSDomain"];
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportViewerCredentials(user, password, domain);
                this.ReportViewer1.ServerReport.Refresh();
            }
        }
    }
}