<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GetCountries.aspx.vb"
    Inherits="VBASPNETJqueryFilterLoadDynamicContent.GetCountries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="tableCountries">
            <asp:Repeater ID="rptCountries" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>
                            ProvinceName
                        </th>
                        <th>
                            CountyId
                        </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ProvinceName")%>
                        </td>
                        <td>
                            <%# Eval("countryID")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
