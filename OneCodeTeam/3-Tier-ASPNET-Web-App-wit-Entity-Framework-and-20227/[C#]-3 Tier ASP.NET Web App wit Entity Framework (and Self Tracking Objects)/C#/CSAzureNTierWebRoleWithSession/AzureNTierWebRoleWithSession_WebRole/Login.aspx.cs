/****************************** Module Header ******************************\
Module Name:  Login.aspx.cs
Project:      AzureNTierWebRoleWithSession_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
This sample also shows how to implement a User Session Handling (With Azure Cache Service).

The login page demonstrates a simple login function to record user's basic information
in cache.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AzureNTierWebRoleWithSession_WebRole
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User login function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Trim() == "default" && tbPassword.Text.Trim() == "123")
            {
                UserEntity user = new UserEntity();
                user.UserName = tbUsername.Text.Trim();
                user.PassWord = tbPassword.Text.Trim();
                Session["user"] = user;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbContent.Text = "Username or password is invalid.";
            }
        }
    }
}