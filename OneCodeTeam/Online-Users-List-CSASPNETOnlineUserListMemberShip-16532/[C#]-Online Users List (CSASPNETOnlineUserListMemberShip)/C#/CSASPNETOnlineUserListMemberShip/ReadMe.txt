========================================================================
              CSASPNETOnlineUserListMemberShip Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to show an online user list via Membership.
In many websites, managers want to collect statistics of online users, 
the sample can check if the user is online and his(her) last activity time, 
creation time and much useful information.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETOnlineUserListMemberShip.sln.

Step 2: Expand the CSASPNETOnlineUserListMemberShip web application and press 
        Ctrl + F5 to show the OnlineUserList.aspx page.

Step 3: You will see a GridView control on the page, please click "User 
        Register" button go to RegisterUserInfo.aspx page.

Step 4: Create some user accounts and return OnlineUserList.aspx page.

Step 5: You can find the new register users displayed in the list. You 
        can make them log out or login. After 15 minutes without activity,
	    the users will sign out automatically.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETOnlineUserListMemberShip".

Step 2. Add two web forms and named them as "OnlineUserList.aspx",
        "RegisterUserInfo.aspx" in root directory.

Step 3. Create a class file named it as "ValidateString.cs".

Step 4. Add a GridView, two buttons, and some text on the OnlineUserList.aspx
        page. Managers can get all online users' name, last activity time, is
		online, etc on this page. They can also make users log out or login.

		GridView data bind event:
		[code]
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
	    [/code]

Step 5. Add log out and login events code like this:

        Login event:
        [code]
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
                        lbMessage.Text = "The user have been logined.";
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
		[/code]

		Log out event:
		[code]
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
		[/code]

Step 6. Write validate methods in ValidateString.cs class file, this file use
        to validate e-mail string and normal string, you can find the these
		methods in sample's ValidateString.cs file.

Step 7. Add user register method in RegisterUserInfo.aspx page like this:
        [code]
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
		[/code]

Step 8. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Membership Class
http://msdn.microsoft.com/en-us/library/system.web.security.membership.aspx

MSDN: MembershipUser Class
http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.aspx

MSDN: MembershipUserCollection Class
http://msdn.microsoft.com/en-us/library/system.web.security.membershipusercollection.aspx

MSDN: MembershipUser.IsOnline Property 
http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.isonline.aspx

MSDN: MembershipUser.LastActivityDate Property 
http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.lastactivitydate.aspx
/////////////////////////////////////////////////////////////////////////////