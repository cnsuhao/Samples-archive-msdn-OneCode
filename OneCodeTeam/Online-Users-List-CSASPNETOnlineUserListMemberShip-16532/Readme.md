# Online Users List (CSASPNETOnlineUserListMemberShip)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Session
## IsPublished
* True
## ModifiedDate
* 2012-04-20 03:33:35
## Description
======================================================================== CSASPNETOnlineUserListMemberShip Overview ======================================================================== /////////////////////////////////////////////////////////////////////////////
 Use: The project illustrates how to show an online user list via Membership. In many websites, managers want to collect statistics of online users, the sample can check if the user is online and his(her) last activity time, creation time and much useful information.
 ///////////////////////////////////////////////////////////////////////////// Demo the Sample. Please follow these demonstration steps below. Step 1: Open the CSASPNETOnlineUserListMemberShip.sln. Step 2: Expand the CSASPNETOnlineUserListMemberShip web application
 and press Ctrl &#43; F5 to show the OnlineUserList.aspx page. Step 3: You will see a GridView control on the page, please click &quot;User Register&quot; button go to RegisterUserInfo.aspx page. Step 4: Create some user accounts and return OnlineUserList.aspx page. Step
 5: You can find the new register users displayed in the list. You can make them log out or login. After 15 minutes without activity, the users will sign out automatically. Step 5: Validation finished. /////////////////////////////////////////////////////////////////////////////
 Code Logical: Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETOnlineUserListMemberShip&quot;. Step 2. Add two web forms and named them as &quot;OnlineUserList.aspx&quot;, &quot;RegisterUserInfo.aspx&quot;
 in root directory. Step 3. Create a class file named it as &quot;ValidateString.cs&quot;. Step 4. Add a GridView, two buttons, and some text on the OnlineUserList.aspx page. Managers can get all online users' name, last activity time, is online, etc on this page. They
 can also make users log out or login. GridView data bind event: [code] /// &lt;summary&gt; /// Re-bind GridView control with online users. /// &lt;/summary&gt; private void GridViewDataBind() { AllUsers = Membership.GetAllUsers(); foreach (MembershipUser user in AllUsers)
 { if (user.IsOnline) { OnlineUsers.Add(user); } } int OnlineUserCount = OnlineUsers.Count; lbMemberCount.Text = OnlineUserCount.ToString(); gvwOnlineUserList.DataSource = OnlineUsers; gvwOnlineUserList.DataBind(); } [/code] Step 5. Add log out and login events
 code like this: Login event: [code] /// &lt;summary&gt; /// Login users. /// &lt;/summary&gt; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; protected void btnLogin_Click(object sender, EventArgs e) { string userName = tbLoginUserName.Text.Trim(); string
 passWord = tbLoginPassWord.Text.Trim(); if (ValidateString.validateString(userName) && ValidateString.validateString(passWord)) { MembershipUser user = Membership.GetUser(userName); if (user != null) { if (user.IsOnline) { lbMessage.Text = &quot;The user have been
 logined.&quot;; return; } if (Membership.ValidateUser(userName, passWord)) { lbMessage.Text = &quot;Login successfully!&quot;; this.GridViewDataBind(); Response.Redirect(&quot;~/OnlineUserList.aspx&quot;); } else { lbMessage.Text = &quot;Login failed! Pass word or user name is incorrect&quot;;
 } } else { lbMessage.Text = &quot;Login failed! Can not find your user name.&quot;; } } else { lbMessage.Text = &quot;Please input your user name and pass word.&quot;; } } [/code] Log out event: [code] /// &lt;summary&gt; /// Log out specified user. /// &lt;/summary&gt; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
 /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; protected void gvwOnlineUserList_RowCommand(object sender, GridViewCommandEventArgs e) { if (e.CommandName == &quot;LogOutEvent&quot;) { int index = int.Parse(e.CommandArgument.ToString()); string userName = gvwOnlineUserList.Rows[index].Cells[0].Text;
 MembershipUser user = Membership.GetUser(userName); if (user != null) { Response.Cache.SetCacheability(HttpCacheability.NoCache); Response.Cache.SetExpires(DateTime.Now); user.LastActivityDate=DateTime.Now.AddYears(-1); Membership.UpdateUser(user); this.GridViewDataBind();
 } } } [/code] Step 6. Write validate methods in ValidateString.cs class file, this file use to validate e-mail string and normal string, you can find the these methods in sample's ValidateString.cs file. Step 7. Add user register method in RegisterUserInfo.aspx
 page like this: [code] MembershipCreateStatus status = new MembershipCreateStatus(); MembershipUser user = Membership.CreateUser(userName, passWord, userEmail, question, answer, true, out status); if (status == MembershipCreateStatus.Success) { AllUsers.Add(user);
 lbMessage.Text = &quot;Congratulations! Registration complete. Please go to OnlineUserList page.&quot;; } else { Response.Write(status.ToString()); } [/code] Step 8. Build the application and you can debug it. /////////////////////////////////////////////////////////////////////////////
 References: MSDN: Membership Class http://msdn.microsoft.com/en-us/library/system.web.security.membership.aspx MSDN: MembershipUser Class http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.aspx MSDN: MembershipUserCollection Class http://msdn.microsoft.com/en-us/library/system.web.security.membershipusercollection.aspx
 MSDN: MembershipUser.IsOnline Property http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.isonline.aspx MSDN: MembershipUser.LastActivityDate Property http://msdn.microsoft.com/en-us/library/system.web.security.membershipuser.lastactivitydate.aspx
 ///////////////////////////////////////////////////////////////////////////// 