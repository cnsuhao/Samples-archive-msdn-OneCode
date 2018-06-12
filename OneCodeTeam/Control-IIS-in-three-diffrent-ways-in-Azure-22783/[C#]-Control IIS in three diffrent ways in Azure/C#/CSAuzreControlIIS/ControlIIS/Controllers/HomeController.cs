/****************************** Module Header ******************************\
Module Name:  HomeController.cs
Project:     ControlIIS
Copyright (c) Microsoft Corporation.
 
As we know, cloud service can full control IIS. If someone want to change IIS, 
they will probably first think about using startup script, since it has been 
documented in Azure training kit.
That's a good way but not the only way.
Actually we can use site class and Configuration config to achieve that.
This sample will show you how can we control IIS by two different ways in Azure
Cloud service.

This class will show you some good ways
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.Web.Administration;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlIIS;

namespace ControlIIS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult ShowDetails()
        {
            using (ServerManager manager = new ServerManager())
            {
                Site webSite = manager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"];

                Configuration config = manager.GetApplicationHostConfiguration();
                string AppPoolName = webSite.Applications[0].ApplicationPoolName;

                ConfigurationSection applicationPoolsSection = config.GetSection("system.applicationHost/applicationPools");
                ConfigurationElementCollection applicationPoolsCollection = applicationPoolsSection.GetCollection();
                ConfigurationElement addElement = ConfigurationUtiltiy.FindElement(applicationPoolsCollection, "add", "name", AppPoolName);

                // Get Current Site server's Pipeline mode by configurationSection.
                if (addElement == null) throw new InvalidOperationException("Element not found!");
                if (addElement["managedPipelineMode"].ToString() == "0")
                    ViewBag.CurrentServerPipelineMode = "Intergrate";
                else
                    ViewBag.CurrentServerPipelineMode = "Classic";

                // Get the site name on instance IIS.
                ViewBag.ServerName = manager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].Name;   
            }
            return View();
        }

    }
}
