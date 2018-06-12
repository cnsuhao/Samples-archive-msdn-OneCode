<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNETCodeFirstCRUDInGridView.Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>School Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Verdana" 
            Font-Size="0.8em" PathSeparator=" : ">
            <CurrentNodeStyle ForeColor="#333333" />
            <NodeStyle Font-Bold="True" ForeColor="#990000" />
            <PathSeparatorStyle Font-Bold="True" ForeColor="#990000" />
            <RootNodeStyle Font-Bold="True" ForeColor="#FF8000" />
        </asp:SiteMapPath>
        <p ALIGN="center">
        <H3>School Management System (using CodeFirst) Sample</H3>
       <a href="Students.aspx" target="_self">Go To Students page</a>
       <br />
       <br />
       <a href="Courses.aspx" target="_self">Go To Courses page</a>
       <br />
       <br />
       <a href="CourseChoice.aspx" target="_self">Go To Course Choice pages</a>
    </div>
    </form>
</body>
</html>
