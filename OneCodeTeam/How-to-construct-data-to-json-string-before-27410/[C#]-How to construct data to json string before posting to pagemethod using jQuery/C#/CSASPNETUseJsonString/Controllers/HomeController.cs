/***************************** Module Header ******************************\
* Module Name:	HomeController.cs
* Project:		CSASPNETUseJsonString
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to post complex data to MVC server side using json string.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using CSASPNETUseJsonString.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSASPNETUseJsonString.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult saveUserInfos(string data)
        {
            try
            {
                var userInfoList = JsonConvert.DeserializeObject<IEnumerable<UserInfo>>(data);
                // Save these data to Your DB

                return Json("Data successfully saved.");
            }
            catch (JsonReaderException e)
            {

                return Json(e.Message);
            }
        }

    }
}
