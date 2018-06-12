/****************************** Module Header ******************************\
* Module Name:    AddSiteProperty.aspx.cs
* Project:        CSSharePointRefreshParentPage
* Copyright (c) Microsoft Corporation
*
* Add SiteProperty page
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
using Microsoft.SharePoint.ApplicationPages;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace CSSharePointRefreshParentPage.Layouts.CloseModalDialogRefreshParentPage
{
    public partial class AddSiteProperty : LayoutsPageBase
    {
        string strSource = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            strSource = Request.QueryString["Source"];
        }

        /// <summary>
        /// Add Property to web
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OKButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            // Get propertyName and propertyValue.
            string propertyName = NameInputFormTextBox.Text.Trim();
            string propertyValue = ValueInputFormTextBox.Text.Trim();

            if (String.IsNullOrEmpty(propertyName))
            {
                NameErrorLabel.Text = "Site property name cannot be empty.";
                return;
            }

            try
            {
                if (Web.GetProperty(propertyName) != null)
                {
                    NameErrorLabel.Text = "Site property name already exists.";
                    return;
                }

                Web.AddProperty(propertyName, propertyValue);
                Web.Update();
            }
            catch (Exception ex)
            {
                throw new SPException(ex.Message);
            }

            // Refresh the page when the dialog is closed by writing JS directly to the
            // http Response object that will close the dialog.         
            if (SPContext.Current.IsPopUI)
            {
                Response.Clear();
                Response.Write(String.Format(@"<script language=""javascript"" type=""text/javascript"">window.frameElement.commonModalDialogClose(1, ""{0}"");</script>", "Site property is successfully added."));
                Response.End();
            }
            else
            {
                SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, this.Context);
            }
        }


        protected override bool RequireSiteAdministrator
        {
            get
            {
                return true;
            }
        }
    }
}