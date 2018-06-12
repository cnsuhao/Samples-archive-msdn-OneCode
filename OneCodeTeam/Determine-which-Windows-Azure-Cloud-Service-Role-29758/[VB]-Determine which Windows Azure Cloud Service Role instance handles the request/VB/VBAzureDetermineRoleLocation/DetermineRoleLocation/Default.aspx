<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DetermineRoleLocation._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbTitle" runat="server" Text="Handle request Virtual Machine information:"></asp:Label>
        <br/>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">Role Name:</td>
                <td class="auto-style1"><asp:Label ID="lbRoleName" runat="server" Text="Label"></asp:Label></td>              
            </tr>
            <tr>
                <td>Deployment Name:</td>
                 <td><asp:Label ID="lbDeploymentName" runat="server" Text="Label"></asp:Label></td>      
            </tr>
            <tr>
                <td>Hosted Service Name:</td>
                 <td><asp:Label ID="lbHostServiceName" runat="server" Text="Label"></asp:Label></td>                   
            </tr>
            <tr>
                <td>Region/Affinity Group:</td>
             <td><asp:Label ID="lbRegionOrGroup" runat="server" Text="Label"></asp:Label></td>      
            </tr>
             <tr>
                <td>Deployment Slot:</td>
                 <td><asp:Label ID="lbslot" runat="server" Text="Label"></asp:Label></td>      
            </tr>
        </table>

    </div>
    </form>
</body>
</html>

