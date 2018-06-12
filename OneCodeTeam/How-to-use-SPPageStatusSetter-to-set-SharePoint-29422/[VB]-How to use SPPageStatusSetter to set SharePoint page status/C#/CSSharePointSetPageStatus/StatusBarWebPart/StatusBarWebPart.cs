/****************************** Module Header ******************************\
 * Module Name:  StatusBarWebPart.cs
 * Project:      CSSharePointSetPageStatus
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample will show you how to add page status to an application page
 * and from list event receiver. 
 * This is custom web part.
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
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CSSharePointSetPageStatus.StatusBarWebPart
{
    [ToolboxItemAttribute(false)]
    public class StatusBarWebPart : WebPart
    {
        SPPageStatusSetter statusBar;
        string strMessage;

        public StatusBarWebPart()
        {
            this.Message = string.Empty;
        }

        [Category("Custom Properties")]
        [Browsable(false)]

        public string Message
        {
            get
            {
                return strMessage;
            }
            set
            {
                strMessage = value;
            }
        }

        protected override void CreateChildControls()
        {
            statusBar = new SPPageStatusSetter();
            statusBar.AddStatus("Action", Message, SPPageStatusColor.Blue);          
                    
            if (!string.IsNullOrEmpty(Message))
            {
                Controls.Add(statusBar);
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("Status Bar demo");
            RenderChildren(writer);
        }
    }
}
