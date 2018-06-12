/****************************** Module Header ******************************\
* Module Name:    ModalDialog.ascx.cs
* Project:        CSSharePointRefreshParentPage
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to close the sharepoint modal dialog and
* refresh the parent page using Server side API.
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using Microsoft.SharePoint;
using Microsoft.SharePoint.ApplicationPages;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;

namespace CSSharePointRefreshParentPage.ModalDialogWebPart
{
    public partial class ModalDialogWebPartUserControl : UserControl
    {
        private const string JSBlockKeySiteProperties = "JSBlockKeyManageSiteProperties";
        private const string JSBlockSitePropertiesFormatString = @"var ADD_SITE_PROPERTY_URL = ""{0}"";";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;

            SPWeb web = SPContext.Current.Web;

            // JS Block for concatenating SiteProperty Url
            if (!cs.IsClientScriptBlockRegistered(typeof(Page), JSBlockKeySiteProperties))
            {
                string scriptBlock = String.Format(JSBlockSitePropertiesFormatString, 
                    String.Format(web.Url + "/_layouts/CloseModalDialogRefreshParentPage/AddSiteProperty.aspx?Source={0}",
                    web.Url + "/" + SPContext.Current.File.Url));

                cs.RegisterClientScriptBlock(typeof(Page), JSBlockKeySiteProperties, scriptBlock, true);
            }

            // Get the PropertyKey list
            ArrayList keyList = new ArrayList();
            foreach (string key in web.AllProperties.Keys)
            {
                keyList.Add(key);
            }

            keyList.Sort();

            // Get the Property list
            ArrayList propertyList = new ArrayList();
            foreach (string key in keyList)
            {
                propertyList.Add(new { Name = key, Value = web.GetProperty(key).ToString() });
            }

            // Bind to GridView
            SitePropertiesGridView.DataSource = propertyList;
            SitePropertiesGridView.DataBind();
        }

        /// <summary>
        /// Get edit SiteProperty Url
        /// </summary>
        /// <param name="propertyNameUrlEncoded">propertyName</param>
        /// <returns></returns>
        public static string GetEditSitePropertyUrl(string propertyNameUrlEncoded)
        {
            SPWeb web = SPContext.Current.Web;
            return String.Format(web.Url + "/_layouts/CloseModalDialogRefreshParentPage/EditSiteProperty.aspx?property={0}&Source={1}", propertyNameUrlEncoded, web.Url + "/" + SPContext.Current.File.Url);
        }
    }
}
