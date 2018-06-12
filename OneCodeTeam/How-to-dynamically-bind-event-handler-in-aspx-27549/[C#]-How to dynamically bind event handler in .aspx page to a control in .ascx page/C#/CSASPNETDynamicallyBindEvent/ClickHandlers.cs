/****************************** Module Header ******************************\
* Module Name: ClickHandlers.cs
* Project:     CSASPNETDynamicallyBindEvent
* Copyright (c) Microsoft Corporation.
* 
* This is a Handler class.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CSASPNETDynamicallyBindEvent
{
    public class ClickHandlers
    {
        XElement root = XElement.Load(HttpContext.Current.Server.MapPath("SourceFile.xml"));
        public void ResponseImageURL(object sender, EventArgs e)
        {
            var lbtn = (LinkButton)sender;
            string lbtnID = lbtn.ID;

            var images = root.Element("Images");
            var imageElements = images.Elements("Image");
            var imageURL = (from i in imageElements
                            where i.Element("ID").Value == lbtnID
                            select i.Element("URL")).First().Value;
                           
            System.Web.HttpContext.Current.Response.Write(string.Format("The {0}'s absolute path is:{1}",lbtn.Text,imageURL));
        }


        public void ResponseImageID(object sender, EventArgs e)
        {
            var lbtn = (LinkButton)sender;          
            System.Web.HttpContext.Current.Response.Write(string.Format("The {0}'s ID:{1}", lbtn.Text, lbtn.ID));

        }
    }
}