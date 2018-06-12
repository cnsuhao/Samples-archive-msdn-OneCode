/****************************** Module Header ******************************\
Module Name:  ReportViewerCredentials.cs
Project:      AzureSQLReportingServices_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access SQL Azure Reporting Service and
get data by authenticated username/password by ReportViewer control and 
non-ReportViewer clients (such as MVC project). The ReportViewer control
with server report will help use send request to SQL Azure with credentials
message, but in MVC role, we need to send request and analysis XML by code.

This class is used to create forms credentials.

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
using System.Security.Principal;
using Microsoft.Reporting.WebForms;
using System.Net;

namespace AzureSQLReportingServices_WebRole
{
    [Serializable]
    public class ReportViewerCredentials : IReportServerCredentials
    {
        private string reportUser;
        private string reportPassword;
        private string reportDomain;

        /// <summary>
        /// ReportViewerCredentials structure method.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        public ReportViewerCredentials(string user, string password, string domain)
        {
            this.reportUser = user;
            this.reportPassword = password;
            this.reportDomain = domain;
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = this.reportUser;
            password = this.reportPassword;
            authority = this.reportDomain;

            return true;
        }

        public WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            get { return null; }
        }
    }


}