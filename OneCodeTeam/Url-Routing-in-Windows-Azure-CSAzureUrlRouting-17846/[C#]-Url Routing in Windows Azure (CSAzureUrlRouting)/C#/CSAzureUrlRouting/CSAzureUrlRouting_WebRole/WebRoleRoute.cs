/****************************** Module Header ******************************\
Module Name:  WebRoleRoute.vb
Project:      VBAzureUrlRouting_WebRole
Copyright (c) Microsoft Corporation.
 
This sample demonstrates how to use URL routing in Azure application. As we know, 
URL Routing is a common technology in ASP.NET and MVC applications, customers 
also want to know how to migrate to the original project to Windows Azure Platform. 

The RouteHandler class receives URL parameters, and then checks if the folder name 
is in specific namespace, and if the file path exists.

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
using System.Web.Compilation;
using System.Web.UI;
using System.IO;
using System.Xml.Linq;

namespace CSAzureUrlRouting_WebRole
{
    public class WebRoleRoute : IRouteHandler
    {
        public WebRoleRoute()
        {
            
        }

        /// <summary>
        /// Check URLs from requests.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string root = requestContext.RouteData.Values["root"].ToString().ToLower();
            string name = requestContext.RouteData.Values["name"].ToString().ToLower();
            string directory = requestContext.RouteData.Values["directory"].ToString().ToLower();
            string page = string.Format("~/{0}/{1}", directory, name);
            string xmlPath = requestContext.HttpContext.Server.MapPath("~/App_Data/Routing.xml");
            if(!IsInRoot(directory,root, xmlPath))
                return BuildManager.CreateInstanceFromVirtualPath("~/NoHandler.aspx", typeof(Page)) as IHttpHandler;
            if(File.Exists(requestContext.HttpContext.Server.MapPath(page)))
            {
                IHttpHandler handler = BuildManager.CreateInstanceFromVirtualPath(page, typeof(Page)) as IHttpHandler;
                return handler;
            }
            else
            {
                return BuildManager.CreateInstanceFromVirtualPath("~/NoHandler.aspx", typeof(Page)) as IHttpHandler;
            }
        }

        /// <summary>
        /// Check directory name is in root node (XML file).
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="root"></param>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        private bool IsInRoot(string directory, string root, string xmlPath)
        {
            XDocument document = XDocument.Load(xmlPath);
            var list = from e in document.Descendants(root).Descendants("add")
                       where directory.Equals(e.Value)
                       select e;
            if (list.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}