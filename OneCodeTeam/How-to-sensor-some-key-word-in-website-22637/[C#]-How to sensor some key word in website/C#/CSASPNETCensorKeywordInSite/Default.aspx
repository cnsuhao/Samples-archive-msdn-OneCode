<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETCensorKeywordInSite._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
    <div>
        <asp:TextBox ID="tbText" runat="server" Height="151px" TextMode="MultiLine" Width="475px"></asp:TextBox>
        <br />
        <asp:Button ID="btnClientCheck" runat="server" Text="ClientCheck" OnClientClick="javascript:LoadAndExecuteDynamicJS();" />
        <br />
        <asp:Button ID="btnEnter" runat="server" Text="ServerCheckAndOutPut" OnClick="btnEnter_Click" />
        Output:
        <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
        <div id="divMsg">
        </div>

        <script type="text/javascript" language="javascript">
            function LoadAndExecuteDynamicJS() {
                var wsp = CSASPNETCensorKeywordInSite.WebService1;
                wsp.LoadScript(CallBackFunction);
            }

            function CallBackFunction(result) {
                var strText = "" + document.getElementById('tbText').value;
                strText = strText.replace(/(\s)*/gi, ""); //Remove space
                strText = strText.toLowerCase();              
                    
                var strs = new Array();
                strs = result.toLowerCase().split("|");
                var msg = "";
                try {                
                    for (i = 0; i < strs.length; i++) {                      
                        if (strText.indexOf(strs[i]) > -1) {
                            msg = msg + "," + strs[i];
                        }
                    }
                    if (msg.length > 0) {
                        alert("Your input has the following illegal characters:" + msg.substring(1,msg.length));
                    }                  
                }
                catch (e) {
                    alert(e);
                }
            }
        </script>

    </div>
    </form>
</body>
</html>
