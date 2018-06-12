<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETReloadPartContent._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="jquery-1.4.1.min.js" type="text/javascript"></script>

    <script language="JavaScript" type="text/javascript">
        function refreshConsole() {
            $.ajax({
                type: "POST",
                url: "refresh.aspx",
                success: function(data) {
                    $("#target").html(data);
                }
            });
        }

        $(document).ready(function() {
            refreshConsole();
        });
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    This is the main page.
    <div>
        <div id="target">
        </div>
    </div>
    </form>
</body>
</html>
