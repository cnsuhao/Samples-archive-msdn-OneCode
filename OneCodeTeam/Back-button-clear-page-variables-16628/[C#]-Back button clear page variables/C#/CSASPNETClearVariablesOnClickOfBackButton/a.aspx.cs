/****************************** Module Header ******************************\
* Module Name:    a.aspx.cs
* Project:        CSASPNETClearVariablesOnClickOfBackButton
* Copyright (c) Microsoft Corporation
*
*  The CSASPNETClearVariablesOnClickOfBackButton sample demonstrates how to clear variables on click of Back button to previous page on browser
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETClearVariablesOnClickOfBackButton
{
    public partial class a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear out the session variable.
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text.Trim()) && !string.IsNullOrEmpty(tbPwd.Text.Trim()))
            {
                Session["uName"] = tbName.Text;
                Session["uPwd"] = tbPwd.Text;
                Response.Redirect("b.aspx");
            }
        }
    }
}
