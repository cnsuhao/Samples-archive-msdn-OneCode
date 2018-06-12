/****************************** Module Header ******************************\
* Module Name: OnlineUserList.aspx.cs
* Project:     CSASPNETOnlineUserListMemberShip
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to show an online user list via Membership.
* In many websites, managers want to collect statistics of online users, 
* The sample can check if the user is online and his(her) last activity
* time, creation time and much useful information.
* 
* This page use to show online users list and total online users number.
* you can make them login or log out.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CSASPNETOnlineUserList
{
    public partial class OnlineUserList : System.Web.UI.Page
    {
        // Define MemberShipUserCollections to store users.
        public MembershipUserCollection OnlineUsers = new MembershipUserCollection();
        public MembershipUserCollection AllUsers = new MembershipUserCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GridViewDataBind();
            }
        }

        /// <summary>
        /// Re-bind GridView control with online users.
        /// </summary>
        private void GridViewDataBind()
        {
            AllUsers = Membership.GetAllUsers();
            foreach (MembershipUser user in AllUsers)
            {
                if (user.IsOnline)
                {
                    OnlineUsers.Add(user);
                }
            }
            int OnlineUserCount = OnlineUsers.Count;
            lbMemberCount.Text = OnlineUserCount.ToString();
            gvwOnlineUserList.DataSource = OnlineUsers;
            gvwOnlineUserList.DataBind();
        }

        /// <summary>
        /// Log out specified user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvwOnlineUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "LogOutEvent")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string userName = gvwOnlineUserList.Rows[index].Cells[0].Text;
                MembershipUser user = Membership.GetUser(userName);
                if (user != null)
                {
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetExpires(DateTime.Now);
                    user.LastActivityDate=DateTime.Now.AddYears(-1);
                    Membership.UpdateUser(user);
                    this.GridViewDataBind();
                }
            }
        }

        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterUserInfo.aspx");
        }

        /// <summary>
        /// Login users.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbLoginUserName.Text.Trim();
            string passWord = tbLoginPassWord.Text.Trim();
            if (ValidateString.validateString(userName) && ValidateString.validateString(passWord))
            {
                MembershipUser user = Membership.GetUser(userName);
                if (user != null)
                {
                    if (user.IsOnline)
                    {
                        lbMessage.Text = "The user has been logined.";
                        return;
                    }
                    if (Membership.ValidateUser(userName, passWord))
                    {
                        lbMessage.Text = "Login successfully!";
                        this.GridViewDataBind();
                        Response.Redirect("~/OnlineUserList.aspx");
                    }
                    else
                    {
                        lbMessage.Text = "Login failed! Pass word or user name is incorrect";
                    }
                }
                else
                {
                    lbMessage.Text = "Login failed! Can not find your user name.";
                }
            }
            else
            {
                lbMessage.Text = "Please input your user name and pass word.";
            }
        }
    }
}