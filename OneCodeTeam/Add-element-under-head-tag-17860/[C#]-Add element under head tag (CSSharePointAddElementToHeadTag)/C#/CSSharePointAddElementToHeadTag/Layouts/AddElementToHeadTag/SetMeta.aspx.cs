/****************************** Module Header ******************************\
* Module Name:    SetMeta.aspx.cs
* Project:        CSSharePointAddElementToHeadTag
* Copyright (c) Microsoft Corporation
*
* This page is used to set the custom Meta information.
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace AddElementToHeadTag.Layouts.AddElementToHeadTag
{
    public partial class SetMeta : LayoutsPageBase
    {
        // Current web
        SPWeb myWeb = SPContext.Current.Web;

        // Keyword
        string strCustomMetaKey = string.Empty;

        // Description
        string strCustomMetaDescription = string.Empty;

        // Set the Meta for the specified page
        protected void cmdAddMeta_Click(object sender, EventArgs e)
        {            
            string strPage = tbPageName.Text.Trim();
            SPFile file = myWeb.GetFile("/SitePages/" + strPage + "");
            if (file.Exists)
            {
                strCustomMetaKey = strPage + "-CustomMetaKey";
                strCustomMetaDescription = strPage + "-CustomMetaDescription";

                // Custom Meta
                SetOrModifyCustomMeta(tbKey.Text, tbDescription.Text);

                myWeb.Update();

                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage,
                 this.Context);
            }
            else
            {
                ltrMsg.Text = "No Such file Exists";
            }         
        }

        // Set the Default Meta
        protected void cmdAddDefaultMeta_Click(object sender, EventArgs e)
        {
            strCustomMetaKey = "Default-CustomMetaKey";
            strCustomMetaDescription = "Default-CustomMetaDescription";

            SetOrModifyCustomMeta(tbDefaultKey.Text, tbDefaultDescription.Text);

            myWeb.Update();

            SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage,
             this.Context);
        }

        /// <summary>
        /// Use the value to add or modify the Meta information in AllProperties.
        /// </summary>
        /// <param name="strKey">New keyword</param>
        /// <param name="strDescription">New description</param>
        private void SetOrModifyCustomMeta(string strKey, string strDescription)
        {
            // Add or modify the keyword.
            if (string.IsNullOrEmpty(SPContext.Current.Web.GetProperty(strCustomMetaKey) as string))
            {
                myWeb.AllProperties.Add(strCustomMetaKey, strKey);
            }
            else
            {
                myWeb.AllProperties[strCustomMetaKey] = strKey;
            }

            // Add or modify the description.
            if (string.IsNullOrEmpty(myWeb.GetProperty(strCustomMetaDescription) as string))
            {
                myWeb.AllProperties.Add(strCustomMetaDescription, strDescription);
            }
            else
            {
                myWeb.AllProperties[strCustomMetaDescription] = strDescription;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            cmdAddMeta.Click += new EventHandler(cmdAddMeta_Click);
            cmdAddDefaultMeta.Click += new EventHandler(cmdAddDefaultMeta_Click);
        }

        protected override void OnPreRender(EventArgs e)
        {
            // Initialize the default meta information.
            tbDefaultKey.Text = myWeb.GetProperty("Default-CustomMetaKey") as string;
            tbDefaultDescription.Text = myWeb.GetProperty("Default-CustomMetaDescription") as string;
        }
    }
}
