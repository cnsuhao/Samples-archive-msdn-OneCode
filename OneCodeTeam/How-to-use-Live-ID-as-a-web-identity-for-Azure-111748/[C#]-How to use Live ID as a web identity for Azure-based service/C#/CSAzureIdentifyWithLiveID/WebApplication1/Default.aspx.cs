/****************************** Module Header ******************************\
* Module Name:	Default.aspx.cs
* Project:		CSAzureIdentifyWithLiveID
* Copyright (c) Microsoft Corporation.
* 
* Default page
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                hlkLogin.Visible = false;
                lblUserName.Visible = true;
                lblUserName.Text = "Welcome! "+Session["UserName"].ToString();
            }
            else
            {
                hlkLogin.Visible = true;
                lblUserName.Visible = false;
            }

        }
    }
}