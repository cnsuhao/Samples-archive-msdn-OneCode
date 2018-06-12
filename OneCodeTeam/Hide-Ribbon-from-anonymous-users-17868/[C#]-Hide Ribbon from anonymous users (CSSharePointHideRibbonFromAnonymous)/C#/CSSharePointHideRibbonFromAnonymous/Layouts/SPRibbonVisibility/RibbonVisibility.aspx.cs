/****************************** Module Header ******************************\
Module Name:  RibbonVisibilitySettings.cs
Project:      CSSharePointHideRibbonFromAnonymous
Copyright (c) Microsoft Corporation.

Operation of the hide ribbon from Anonymous.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Web.UI;
using System.Text;

namespace RibbonVisibility.Layouts
{
    public partial class RibbonVisibilitySettings : LayoutsPageBase
    {

        SPWeb _web = null;

        #region Properties
        private String selectedValue
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("{0};", chkAnonymous.Checked.ToString());
                return builder.ToString();
            }

        }

        private string redirectUrl
        {
            get
            {
                if (Request.QueryString["Source"] != null)
                    return Request.QueryString["Source"];
                return String.Empty;
            }
        }
        private SPWeb currentSPWeb = SPContext.Current.Web;

        #endregion

        #region override
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _web = currentSPWeb;
                if (!IsPostBack)
                {
                    ApplyInitialValue();
                }
            }
            catch (Exception ex)
            {
                this.Controls.Clear();
                this.Controls.Add(new LiteralControl("Error : " + ex.Message));
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        public override void Dispose()
        {
            if (_web != null)
                _web.Dispose();
        }
        #endregion override

        #region Event Handlers
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ApplyValue(_web, selectedValue, chkApplyToChildren.Checked);
            DoRedirect();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DoRedirect();
        }
        #endregion Event Handlers

        #region Private
        protected string GetValues()
        {
            if (_web.Properties.ContainsKey(Helper.Constants.KEY))
                return _web.Properties[Helper.Constants.KEY];
            else
                return String.Empty;
        }

        protected void ApplyInitialValue()
        {
            string values = GetValues();
            if (string.IsNullOrEmpty(values))
            {
                return;
            }   

            chkAnonymous.Checked = Boolean.Parse(values.Split(';')[0]);
        }

        protected void DoRedirect()
        {
            if (redirectUrl != String.Empty)
                SPUtility.Redirect(redirectUrl, SPRedirectFlags.Default, HttpContext.Current);
            else
                SPUtility.Redirect(SPContext.Current.Web.Url + "/_layouts/settings.aspx", SPRedirectFlags.Default, HttpContext.Current);
        }

        private void ApplyValue(SPWeb web, string value, bool recursive)
        {
            bool allowunsafe = _web.AllowUnsafeUpdates;
            web.AllowUnsafeUpdates = true;

            try
            {
                string accountid = selectedValue;
                if (web.Properties.ContainsKey(Helper.Constants.KEY))
                    web.Properties[Helper.Constants.KEY] = value;
                else
                    web.Properties.Add(Helper.Constants.KEY, value);

                web.Properties.Update();
            }
            finally
            {
                web.AllowUnsafeUpdates = allowunsafe;
            }

            if (recursive)
                foreach (SPWeb subweb in web.Webs)
                    ApplyValue(subweb, Helper.Constants.INHERITS, recursive);
        }
        #endregion

    }
}
