/****************************** Module Header ******************************\
* Module Name:	Callback.aspx.cs
* Project:		CSAzureIdentifyWithLiveID
* Copyright (c) Microsoft Corporation.
* 
* The callback handler. Configure ACS to 
* redirect to this page after the user signs in.
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
using System.Security.Claims;


namespace WebApplication1
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserName = System.Security.Claims.ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name).Value;           
            if (UserName!=null)
            {
                Session["UserName"] = UserName;
                Response.Redirect("Default.aspx");
            }     
        }
    }
}