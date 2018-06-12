/****************************** Module Header ******************************\
Module Name:  RibbonVisibilityControl.cs
Project:      CSSharePointHideRibbonFromAnonymous
Copyright (c) Microsoft Corporation.

The Delegate Control of the Project.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace RibbonVisibility.ControlTemplates
{
    public partial class RibbonVisibilityControl : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string values = GetValues();
            if (values == String.Empty || values == Helper.Constants.INHERITS)
            { 
                return;
            }

            bool hideForAnonymous = Boolean.Parse(values.Split(';')[0]);
            
            // Check whether the user is anonymous or not.
            if (SPContext.Current.Web.CurrentUser == null)
            {
                if (hideForAnonymous)
                    InjectScript();
                else
                    return;
            }
        }

        private string GetValues()
        {
            SPWeb web = SPContext.Current.Web;

            while (web != null)
            {
                string value = GetValues(web);
                if (value != Helper.Constants.INHERITS)
                {
                    return value;
                }
                else
                    web = web.ParentWeb;
            }

            return string.Empty;
        }

        private string GetValues(SPWeb web)
        {
            if (web.Properties.ContainsKey(Helper.Constants.KEY))
                return web.Properties[Helper.Constants.KEY];
            else
                return Helper.Constants.INHERITS;
        }
     
        private void InjectScript()
        {
            string scriptfile = "/_controltemplates/SPRibbonVisibility/RibbonVisibility.js"; 

            ScriptManager.RegisterClientScriptInclude(this, typeof(RibbonVisibilityControl), "SPRibbonVisibility", scriptfile);
        }
    }
}
