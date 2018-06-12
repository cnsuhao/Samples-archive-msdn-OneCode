/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      AzureNTierWebRoleWithSession_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
which uses Entity Framework (SQL Azure database) as the Data Access Layer.
And Business layer can call DAL class instances and methods, web role application
will call BLL method to load the data come from database. This sample also shows
how to implement a User Session Handling (With Azure Cache Service).

The default page loads the data from BLL method, and loads the user information from 
Azure Cache Service.

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
using BusinessLayer;
using DataAccessLayer;

namespace AzureNTierWebRoleWithSession_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        public BusinessManager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load user name from Azure Cache Service.
            if (Session["user"] != null)
            {
                UserEntity user = new UserEntity();
                user = Session["user"] as UserEntity;
                lbUser.Text = user.UserName;
            }

            // Load TestTable data from BLL.
            manager = new BusinessManager();
            if (!Page.IsPostBack)
            {
                gvwDataSource.DataSource = manager.GetData();
                gvwDataSource.DataBind();
            }
        }
    }
}