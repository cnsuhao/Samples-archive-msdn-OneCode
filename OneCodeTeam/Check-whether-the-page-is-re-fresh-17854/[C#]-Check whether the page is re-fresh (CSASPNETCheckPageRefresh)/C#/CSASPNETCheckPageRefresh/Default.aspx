<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETCheckPageRefresh._Default" %>

<%@ Register Src="CheckRefreshUserControl.ascx" TagName="CheckRefreshUserControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:CheckRefreshUserControl ID="CheckRefreshUserControl1" runat="server" />
        <table>
            <caption>
                Order Pay</caption>
            <tr>
                <td>
                    OrderNo
                </td>
                <td>
                    20120409001
                </td>
            </tr>
            <tr>
                <td>
                    Money
                </td>
                <td>
                    $1
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Pay" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
