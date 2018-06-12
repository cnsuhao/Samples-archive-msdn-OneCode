<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default2.aspx.vb" Inherits="VBLoadAndExecuteDynamicJS.Default21" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Load JavaScript resources dynamically and asynchronoyusly.</title>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService1.asmx" />
        </Services>
    </asp:ScriptManager>
    <hr />
    <div>
        <table border="0" cellpadding="10" cellspacing="10">
            <tr>
                <td>
                    <input id="Button1" type="button" value="Load Script stored on Internal Server" style="width: 100%"
                        onclick="javascript: LoadAndExecuteDynamicJS('DynamicScript.js');" />
                </td>
            </tr>
            <tr>
                <td>
                    <input id="Button2" type="button" value="Call Script stored on Internal Server" style="width: 100%"
                        onclick="javascript: Hello();" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function LoadAndExecuteDynamicJS(src1) {
            var wsp = VBLoadAndExecuteDynamicJS.WebService1;
            wsp.LoadScript(src1, CallBackFunction);
        }

        function CallBackFunction(result) {
            $("head").append($("<script type='text/javascript' />").attr("src", result));
            alert('Script loaded');
            // Do something interesting here.
        }
    </script>

    </form>
</body>
</html>
