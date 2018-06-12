/****************************** Module Header ******************************\
Module Name:  Person.cs
Project:      AzureSQLReportingSerivces_MVC4Role
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access SQL Azure Reporting Service and
get data by authenticated username/password by ReportViewer control and 
non-ReportViewer clients (such as MVC project). The ReportViewer control
with server report will help use send request to SQL Azure with credentials
message, but in MVC role, we need to send request and analysis XML by code.

Person entity class.

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

namespace AzureSQLReportingSerivces_MVC4Role
{
    public class Person
    {
        public string Name
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }
    }
}