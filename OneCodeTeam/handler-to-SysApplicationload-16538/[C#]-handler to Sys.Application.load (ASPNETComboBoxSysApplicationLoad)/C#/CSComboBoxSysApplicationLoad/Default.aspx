<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSComboBoxSysApplicationLoad.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:ComboBox ID="ComboBox1" runat="server">
            <asp:ListItem>Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
        </asp:ComboBox>
        <asp:TextBox ID="TextBox1" Text="I am a TextBox." runat="server"></asp:TextBox>
    </div>
    </form>

    <script type="text/javascript">
        var loader = function () {
            var inputs = document.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                var input = inputs[i];

                if (input.getAttribute('type') == 'text') {
                    alert(input.value);
                }
            }
        }
        loader();
        //Sys.Application.add_load(loader);
    
    </script>
</body>
</html>
