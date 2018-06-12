/****************************** Module Header ******************************\
* Module Name: Default2.aspx.cs
* Project:     CSASPNETModifySessionStateSection
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to modify sessionState section in the Web.Config
* file at run time. Customers always wants to know how to modify web.config in
* code-behind page, thus, we provide two methods in this sample code to access
* configuration file of web application. Remember if you change the Web.Config file,
* the Asp.net application will restart, so please use it carefully.
* 
* This page use WebConfigurationManager class to access and modify web.config 
* file. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Text;

namespace CSASPNETModifySessionStateSection
{
    public partial class Default2 : System.Web.UI.Page
    {
        // Define common variables, public string and Configuration instance.
        public string strDisplay = string.Empty;
        Configuration manager;

        /// <summary>
        /// Load current web.config information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                SystemWebSectionGroup sections = manager.GetSectionGroup("system.web") as SystemWebSectionGroup;
                string cookieName = sections.SessionState.CookieName;
                if (!cookieName.Equals(string.Empty))
                {
                    tbCookieName.Text = cookieName;
                }
                else
                {
                    lbError.Text = "Session Name value is empty.";
                }

                TimeSpan timeout = sections.SessionState.Timeout;
                double minutes = timeout.TotalMinutes;
                if (!timeout.Equals(string.Empty) && minutes > 0)
                {
                    tbCookieTimeOut.Text = minutes.ToString();
                }
                else
                {
                    lbError.Text = "Session Timeout value is incorrect.";
                }
            }
        }

        /// <summary>
        /// Use WebConfigurationManager instance to get and set session state properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyByXml_Click(object sender, EventArgs e)
        {
            try
            {
                manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                SystemWebSectionGroup sections = manager.GetSectionGroup("system.web") as SystemWebSectionGroup;

                StringBuilder strbDisplay = new StringBuilder();
                strbDisplay.Append("Forward Settings:<br />");
                strbDisplay.Append("Session TimeOut: ");
                strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString());
                strbDisplay.Append("(m) <br />");
                strbDisplay.Append("Session cookieName: ");
                strbDisplay.Append(sections.SessionState.CookieName);
                strDisplay = strbDisplay.ToString();

                string strMin = tbCookieTimeOut.Text.Trim();
                string strName = tbCookieName.Text.Trim();
                if (strName == string.Empty)
                {
                    strDisplay = String.Empty;
                    lbError.Text = "Cookie Name is null.";
                    return;
                }
                double intMin;
                if (double.TryParse(strMin, out intMin))
                {
                    sections.SessionState.CookieName = strName;
                    sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin);
                    manager.Save();
                    lbError.Text = "Save Web config file success, please can open web.config file for value checking.";
                }
                else
                {
                    strDisplay = String.Empty;
                    lbError.Text = "Session Timeout value must be an integer number.";
                }
            }
            catch (Exception ex)
            {
                strDisplay = String.Empty;
                Response.Write(ex.Message);
            }
        }
    }
}