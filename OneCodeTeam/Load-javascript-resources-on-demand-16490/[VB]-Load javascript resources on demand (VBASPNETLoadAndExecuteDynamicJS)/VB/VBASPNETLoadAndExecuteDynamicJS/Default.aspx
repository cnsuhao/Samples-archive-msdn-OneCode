<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBLoadAndExecuteDynamicJS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Load JavaScript resources dynamically and asynchronoyusly.</title>
    
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        function LoadAndExecuteDynamicJS(src1) {

            $.ajax({
                type: "POST",
                url: "Service1.svc/LoadScript",
                data: JSON.stringify({ source: src1 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                $("head").append($("<script type='text/javascript' />").attr("src", msg.d));
                    alert('Script loaded');                  
                    // Do something interesting here.
                }
            });
        }

        function LoadExternalDynamicJS() {

            var head = document.getElementsByTagName('head')[0];
            var script = document.createElement('script');
            script.type = 'text/javascript';
            script.src = document.getElementById('Text1').value;
            head.appendChild(script);
            alert('External Script added');

        }       
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/Service1.svc" />
        </Services>
    </asp:ScriptManager>
    <hr />
    <div>
        <table border="0" cellpadding="10" cellspacing="10">
            <tr>
                <td>
                    <input id="Button1" type="button" value="Load Script stored on Internal Server" style="width: 100%"
                        onclick="javascript:LoadAndExecuteDynamicJS('DynamicScript.js');" />
                </td>
            </tr>
            <tr>
                <td>
                    <input id="Button2" type="button" value="Call Script stored on Internal Server" style="width: 100%"
                        onclick="javascript:Hello();" />
                </td>
            </tr>
            <tr>
                <td>
                    <input id="Text1" type="text" value="External Script URL" style="width: 100%" />
                </td>
                <td>
                    <input id="Button3" type="button" value="Add script to the page" onclick="javascript:LoadExternalDynamicJS();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
