<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineUserList.aspx.cs" Inherits="CSASPNETOnlineUserList.OnlineUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css"> 
   .black
   { 
       display: none; 
       position: absolute; 
       top: 0%;
       left: 0%;
       width: 100%; 
       height: 100%;
       background-color: black; 
       z-index:1001;
       -moz-opacity: 0.8;
       opacity:.70; 
   } 
   .white
   {
        display: none; 
        position: absolute; 
        top: 30%; 
        left: 30%; 
        width: 30%; 
        height: 25%; 
        padding: 16px; 
        border: 3px solid blue; 
        background-color: white;
        z-index:1002; 
        overflow: auto;
   }
   </style>
   <script type="text/javascript" language="javascript">
       function openWindow() {
           document.getElementById('light').style.display = 'block';
           document.getElementById('fade').style.display = 'block';
           var loginButton = document.getElementById('btnLogin');
           loginButton.focus();
       }

       function closeWindow() {
           document.getElementById('light').style.display = 'none';
           document.getElementById('fade').style.display = 'none';
       } 
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Check online user list by Membership<br />
        <br />
     <strong>There are </strong>
     <asp:Label ID="lbMemberCount" runat="server" Style="position: static" 
            Font-Bold="True"></asp:Label>
     <strong>online users now</strong>
     <br />
     <br />
     <asp:GridView ID="gvwOnlineUserList" runat="server" Font-Bold="True" 
            AutoGenerateColumns="False" onrowcommand="gvwOnlineUserList_RowCommand" >
        <Columns>        
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:CheckBoxField DataField="IsOnline" HeaderText="Is Online" />      
            <asp:BoundField DataField="IsApproved" HeaderText="Is Approved" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />
            <asp:BoundField DataField="LastActivityDate" HeaderText="Last Activity Time" />
            <asp:BoundField DataField="LastLockoutDate" HeaderText="Last Lockout Date" />
            <asp:ButtonField HeaderText="Log Out" Text="Log out "
                SortExpression="0" ButtonType="Button" CommandName="LogOutEvent" />
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />           
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /> 
        <EmptyDataTemplate>            
            No User Online        
        </EmptyDataTemplate> 
    </asp:GridView>
        <br />
        <input type="button" id="btnLoginUser" value="User Login" 
            onclick="openWindow()" tabindex="0" />
    &nbsp;
        <asp:Button ID="btnRegisterUser" runat="server" Text="User Register" 
            onclick="btnRegisterUser_Click" TabIndex="1" />
        <br />
        <br />
        <asp:Label ID="lbMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    <br /> 
    </div>  
   <div id="light" class="white">
   <center>
   <strong>User Login</strong>
   <br />
   <br />
   <br />
       <asp:Label ID="lbLoginUserName" runat="server" Text="User Name:"></asp:Label>   
       <asp:TextBox ID="tbLoginUserName" runat="server"></asp:TextBox><br /><br />
       <asp:Label ID="lbLoginPassWord" runat="server" Text="Pass Word:"></asp:Label>
       <asp:TextBox ID="tbLoginPassWord" TextMode="Password" runat="server"></asp:TextBox><br /><br />
   <br />
       <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" 
          OnClientClick="closeWindow()"  style="height: 26px" />
       <input type="button" id="btnClose" value="Close" onclick="closeWindow()" />
   </center>
   </div>
    <div id="fade" class="black"></div>
    </form>
</body>
</html>
    