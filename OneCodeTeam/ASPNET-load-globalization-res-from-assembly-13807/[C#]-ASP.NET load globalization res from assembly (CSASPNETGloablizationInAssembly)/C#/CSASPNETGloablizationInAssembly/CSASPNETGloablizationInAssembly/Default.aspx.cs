/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETGloablizationInAssembly
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to access resource files that has compiled in 
* class library or dll file. So we can not use GetGlobalResourceObject function
* to get it, here we give an effective way to get specific resources from
* compiled file and then apply resource value in whole application.
* 
* In this page, we use ResoueceManager and Assembly to achieve this goal. 
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
using System.Resources;
using System.Globalization;
using CSASPNETGloablizationInAssemblyResource;

namespace CSASPNETGloablizationInAssembly
{
    /// <summary>
    /// This project class is used to access resource files from class 
    /// library, and render the correct content with current culture.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        public string strContent = string.Empty;
        public string strUrl = string.Empty;
        public string strLink = string.Empty;
        const string strBaseName = "CSASPNETGloablizationInAssemblyResource.LanguageResource";

        // Get ResourceManager instance by assembly resource type.
        ResourceManager manager = new ResourceManager(strBaseName, typeof(LanguageResource).Assembly);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CultureInfo culture = new CultureInfo(Context.Request.UserLanguages[0]);

                string strTitle = manager.GetString("Title", culture);
                string strAuthor = manager.GetString("Author", culture);
                this.strContent = manager.GetString("Content", culture);
                this.strUrl = manager.GetString("Url", culture);
                this.strLink = manager.GetString("Link", culture);
                lbTitle.Text = strTitle;
                lbAuthor.Text = strAuthor;
                bool flag = false;

                for (int i = 0; i < ddlLanguage.Items.Count; i++)
                {
                    if (ddlLanguage.Items[i].Value == culture.Name.ToLower())
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    ddlLanguage.SelectedValue = culture.Name.ToLower();
                }
                else
                {
                    ddlLanguage.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Add built-in language items of DropDownList control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ddlLanguage.Items.Add(new ListItem("United State", "en-us"));
            ddlLanguage.Items.Add(new ListItem("France", "fr-fr"));
            ddlLanguage.Items.Add(new ListItem("中国", "zh-cn"));
        }

        /// <summary>
        /// Change page culture and content by DropDownList SelectedValue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string languageCode = ddlLanguage.SelectedValue;
            CultureInfo currentCulture = this.GetLanguageSpecifically(languageCode);
            lbTitle.Text = manager.GetString("Title", currentCulture);
            lbAuthor.Text = manager.GetString("Author", currentCulture);
            this.strContent = manager.GetString("Content", currentCulture);
            this.strLink = manager.GetString("Link", currentCulture);
            this.strUrl = manager.GetString("Url", currentCulture);
        }

        public CultureInfo GetLanguageSpecifically(string languageCode)
        {
            CultureInfo culture = new CultureInfo(languageCode);
            return culture;
        }
    }
}