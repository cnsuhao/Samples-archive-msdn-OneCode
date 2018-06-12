/****************************** Module Header ******************************\
* Module Name: RegisterUserInfo.aspx.cs
* Project:     CSASPNETOnlineUserListMemberShip
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to show an online user list via Membership.
* In many websites, managers want to collect statistics of online users, 
* The sample can check if the user is online and his(her) last activity
* time, creation time and much useful information.
* 
* This page use to register users.
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
    public partial class RegisterUserInfo : System.Web.UI.Page
    {
        public MembershipUserCollection AllUsers = new MembershipUserCollection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Create users via Membership.CreateUser() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in Page.Form.Controls)
                {
                    if (control is TextBox)
                    {
                        if(!ValidateString.validateString(((TextBox)control).Text.Trim()))
                        {
                            lbMessage.Text = ((TextBox)control).ID + " is empty.";
                            return;
                        }
                    }
                }
                string userName = tbUserName.Text.Trim();
                string passWord = tbPassWord.Text.Trim();
                string repeatePass = tbRepeatePass.Text.Trim();
                string userEmail = tbUserEmail.Text.Trim();
                string question = tbQuestion.Text.Trim();
                string answer = tbAnswer.Text.Trim();
                if (passWord != repeatePass)
                {
                    lbMessage.Text = "Passwords do not match.";
                    return;
                }
                if (!ValidateString.validateEmailString(userEmail))
                {
                    lbMessage.Text = "e-mail format is incorrect, please change another one.";
                    return;
                }
                MembershipCreateStatus status = new MembershipCreateStatus();
                MembershipUser user = Membership.CreateUser(userName, passWord, userEmail, question, answer, true, out status);
                if (status == MembershipCreateStatus.Success)
                {
                    AllUsers.Add(user);
                    lbMessage.Text = "Congratulations! Registration complete. Please go to OnlineUserList page.";
                }
                else
                {
                    Response.Write(status.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// Reset input information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in Page.Form.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OnlineUserList.aspx");
        }
    }
}