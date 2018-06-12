/****************************** Module Header ******************************\
* Module Name: ImageController.ascx.cs
* Project:     CSASPNETDynamicallyBindEvent
* Copyright (c) Microsoft Corporation.
* 
* This user control will first load SourceFile.xml then dynamically create 
* linkbutton based on the SourceFile.xml's records.
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
using System.Reflection;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CSASPNETDynamicallyBindEvent
{
    public partial class ImageController : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {        
                XElement root = XElement.Load(Server.MapPath("~/SourceFile.xml"));
                var images = root.Element("Images");
                var imageElements = images.Elements("Image");
                foreach (var imageElement in imageElements)
                {
                    var lbtn = new LinkButton();

                    // Use image Name as linkButton Text
                    var strArray=imageElement.Element("URL").Value.Split('/');
                    lbtn.Text =strArray[strArray.Length-1];
                   
                    // Bind click event with reflection method
                    lbtn.Click += (ibtnSender, imageClickArgs) => {
                        Type clickHandlerType = typeof(ClickHandlers);
                        ConstructorInfo constructor = clickHandlerType.GetConstructor(Type.EmptyTypes);
                        Object clickHandlerObject = constructor.Invoke(new Object[] { });

                        var method = clickHandlerType.GetMethod(imageElement.Element("ClickHandler").Value);
                        Object[] addHandlerArgs = { ibtnSender,imageClickArgs };
                        method.Invoke(clickHandlerObject, addHandlerArgs);
                    };

                    lbtn.ID = imageElement.Element("ID").Value;
                    
                    pnlImages.Controls.Add(lbtn);
            }
        } 
    }
}