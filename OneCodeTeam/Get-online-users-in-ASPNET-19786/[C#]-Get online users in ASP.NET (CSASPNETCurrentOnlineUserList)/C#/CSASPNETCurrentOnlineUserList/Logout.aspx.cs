﻿/**************************** Module Header ********************************\
* Module Name:    Logout.aspx.cs
* Project:        CSASPNETCurrentOnlineUserList
* Copyright (c) Microsoft Corporation
*
* The Membership.GetNumberOfUsersOnline Method can get the number of online
* users,however many asp.net projects are not using membership.This project
* shows how to display a list of current online users' information without 
* using membership provider.

* This page is for signing out.  

* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Web.UI.WebControls;

namespace CSASPNETCurrentOnlineUserList
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize the datatable which used to store the information
            // of current online user.
            DataTableForCurrentOnlineUser _onlinetable = new DataTableForCurrentOnlineUser();
            if (this.Session["Ticket"] != null)
            {
                // Log out.
                _onlinetable.Logout(this.Session["Ticket"].ToString());
                this.Session.Clear();
            }
        }
    }
}