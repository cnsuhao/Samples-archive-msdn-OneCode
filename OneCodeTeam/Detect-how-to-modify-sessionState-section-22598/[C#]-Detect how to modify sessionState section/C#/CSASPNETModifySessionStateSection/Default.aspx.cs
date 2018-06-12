/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETModifySessionStateSection
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to modify sessionState section in the Web.Config
* file at run time. Customers always wants to know how to modify web.config in
* code-behind page, thus, we provide two methods in this sample code to access
* configuration file of web application. Remember if you change the Web.Config file,
* the Asp.net application will restart, so please use it carefully.
* 
* This page use XmlDocument class to access and modify web.config file. 
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
using System.Xml;
using System.Text;

namespace CSASPNETModifySessionStateSection
{
    public partial class Default : System.Web.UI.Page
    {
        // Define common variables, public string, web.config file path and XmlDocument instance.
        public string strDisplay = string.Empty;
        protected string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\Web.Config";
        XmlDocument document = new XmlDocument();

        /// <summary>
        /// Load current web.config information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                document.Load(configPath);
                XmlNode nodeSession = document.SelectSingleNode("/configuration/system.web/sessionState");
                XmlElement elementSession = (XmlElement)nodeSession;

                string strTimeOut = elementSession.Attributes["timeout"].Value;
                int value=0;
                if (int.TryParse(strTimeOut, out value) && value > 0)
                {
                    tbCookieTimeOut.Text = strTimeOut;
                }
                else
                {
                    lbError.Text = "Session Timeout value is incorrect.";
                }

                string strCookieName = elementSession.Attributes["cookieName"].Value;
                if (strCookieName != string.Empty)
                {
                    tbCookieName.Text = strCookieName;
                }
                else
                {
                    lbError.Text = "Session Name value is empty.";
                }
            }
        }

        /// <summary>
        /// Use XmlDocument instance to modify Session properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyByXml_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder strbDisplay = new StringBuilder();
                document.Load(configPath);
                XmlNode nodeSession = document.SelectSingleNode("/configuration/system.web/sessionState");
                XmlElement elementSession = (XmlElement)nodeSession;
                strbDisplay.Append("Forward Settings:<br />");
                strbDisplay.Append("Session TimeOut: ");
                strbDisplay.Append(elementSession.Attributes["timeout"].Value);
                strbDisplay.Append("<br />");
                strbDisplay.Append("Session cookieName: ");
                strbDisplay.Append(elementSession.Attributes["cookieName"].Value);
                strDisplay = strbDisplay.ToString();

                string strMin = tbCookieTimeOut.Text.Trim();
                string strName = tbCookieName.Text.Trim();
                if (strName == string.Empty)
                {
                    strDisplay = String.Empty;
                    lbError.Text = "Cookie Name is null.";
                    return;
                }
                int intMin;
                if (int.TryParse(strMin, out intMin))
                {
                    elementSession.Attributes["cookieName"].Value = strName;
                    elementSession.Attributes["timeout"].Value = intMin.ToString();
                    document.Save(configPath);
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