/****************************** Module Header ******************************\
* Module Name: HomeController.cs
* Project:     CSAzureJSLogging
* Copyright (c) Microsoft Corporation
*
* HomeController
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System.Web.Mvc;

namespace CSAzureJSLogging.Controllers
{
     
    public class HomeController : Controller
    {   
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}