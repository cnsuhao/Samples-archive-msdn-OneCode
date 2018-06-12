/****************************** Module Header ******************************\
* Module Name:    b.aspx.cs
* Project:        CSASPNETClearVariablesOnClickOfBackButton
* Copyright (c) Microsoft Corporation
*
* A page will show the data enter in a.aspx.
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
    public partial class b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!string.IsNullOrEmpty(Session["uName"] as string))
            {
                Response.Write(Session["uName"].ToString());
            }
            Response.Write("<br/>");
            if (!string.IsNullOrEmpty(Session["uPwd"] as string))
            {
                Response.Write(Session["uPwd"].ToString());
            }
        }
    }
}
