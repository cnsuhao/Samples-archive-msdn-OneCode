<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GetProvinces.aspx.vb"
    Inherits="VBASPNETJqueryFilterLoadDynamicContent.GetProvinces" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="Script/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            var countryId = $("#<%= drpCountries.ClientID %>").val();

            $("#DivCountries").load("GetCountries.aspx?countryID=" + countryId + " #tableCountries");

        }); 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        Select a county:<asp:DropDownList ID="drpCountries" runat="server" AutoPostBack="true">
            <asp:ListItem>China</asp:ListItem>
            <asp:ListItem>US</asp:ListItem>
            <asp:ListItem>UK</asp:ListItem>
        </asp:DropDownList>
        <br />
        <div id="DivCountries">
        </div>
    </div>
    </form>
</body>
</html>
