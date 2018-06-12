/****************************** Module Header ******************************\
Module Name:  IISHandler.cs
Project:      CSAzureUrlRouting_WebRole
Copyright (c) Microsoft Corporation.
 
This sample demonstrates how to use URL routing in Azure application. As we know, 
URL Routing is a common technology in ASP.NET and MVC applications, customers 
also want to know how to migrate to the original project to Windows Azure Platform. 

The IISHandler is used to handle application is deployed on IIS. 

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
using System.Web.Routing;

namespace CSAzureUrlRouting_WebRole
{
    public class IISHandler : UrlRoutingHandler
    {
        protected override void VerifyAndProcessRequest(IHttpHandler httpHandler, HttpContextBase httpContext)
        {
            
        }
    }
}