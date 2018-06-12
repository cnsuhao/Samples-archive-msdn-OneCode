<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CSASPNETUserConsent.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

        <asp:DropDownList ID="ddl" runat="server">
            <asp:ListItem>Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="newitem" runat="server"></asp:TextBox>

        <asp:Button ID="bymodalpopup" 
            Text="Add by ModalPopupExtender" 
            runat="server" />

        <asp:Panel ID="popup" runat="server" style="border: 1px #ccc solid; padding: 10px;">
            <p>Add new item to the DropDownList?</p>
            <asp:Button ID="ok"
                Text="OK" 
                OnClick="ok_Click"
                runat="server" />
            <asp:Button ID="cancel" runat="server" Text="Cancel" />
        </asp:Panel>
            
        <asp:ModalPopupExtender ID="ModalPopupExtender1"
            TargetControlID="bymodalpopup"
            PopupControlID="popup"
            runat="server">
        </asp:ModalPopupExtender>

    </div>
    </form>
</body>
</html>