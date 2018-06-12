/****************************** Module Header ******************************\
* Module Name:    PageMethodTest.aspx.cs
* Project:        CSASPNETStaticCodeByPageMethod
* Copyright (c) Microsoft Corporation
*
* This page is used to call server side function without web service .
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace CSASPNETStaticCodeByPageMethod
{
    public partial class PageMethodTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string sayHello(string name)
        {
            return "Hello," + name;
        }

        [WebMethod]
        public static object getData(TestUser t)
        {
            return new
            {
                Name = t.Name + "-Test",
                Value = t.Phone
            };
        }

        public class TestUser 
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public IList<string> Phone { get; set; }
        }       
    }
}
