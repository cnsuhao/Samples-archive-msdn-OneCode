/****************************** Module Header ******************************\
* Module Name:    EditSiteProperty.aspx.cs
* Project:        CSSharePointRefreshParentPage
* Copyright (c) Microsoft Corporation
*
* Edit SiteProperty page
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
    public partial class EditSiteProperty : LayoutsPageBase
    {
        // Source url
        string strSource = string.Empty;

        // Property Name
        string propertyName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            strSource = Request.QueryString["Source"];
            propertyName = Request.QueryString["Property"];

            if (!Page.IsPostBack)
            {                
                if (Web.GetProperty(propertyName) == null)
                {
                    throw new SPException("Site property not found.");
                }

                if (!(Web.GetProperty(propertyName) is String))
                {
                    OKButton.Enabled = false;
                }

                string propertyValue = Web.GetProperty(propertyName).ToString();
                NameInputFormTextBox.Text = propertyName;
                ValueInputFormTextBox.Text = propertyValue;
            }
        }

        /// <summary>
        /// Update property Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OKButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string propertyValue = ValueInputFormTextBox.Text.Trim();

            try
            {
                if (propertyName == "MyTest") // This is a test
                {
                    Web.SetProperty(propertyName, propertyValue);
                    Web.Update();
                }

            }
            catch (Exception ex)
            {
                throw new SPException(ex.Message);
            }

            string strMsg = "Site property is successfully updated.";
            ModalDialogClose(strMsg);

        }

        /// <summary>
        /// Close the Modal Dialog
        /// </summary>
        /// <param name="strMsg">Tip</param>
        protected void ModalDialogClose(string strMsg)
        {
            if (SPContext.Current.IsPopUI)
            {
                // Refresh the page when the dialog is closed by writing JS directly to the
                // http Response object that will close the dialog. 
                Response.Clear();
                Response.Write(String.Format(@"<script language=""javascript"" type=""text/javascript"">window.frameElement.commonModalDialogClose(1, ""{0}"");</script>", strMsg));
                Response.End();
            }
            else
            {
                SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, Context);
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