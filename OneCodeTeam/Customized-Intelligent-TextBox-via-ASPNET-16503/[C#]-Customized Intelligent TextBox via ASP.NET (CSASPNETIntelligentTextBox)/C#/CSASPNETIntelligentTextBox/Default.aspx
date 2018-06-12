<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETIntelligentTextBox.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
	#ulCss
	 {
	     list-style-type:none;
	     padding-right: 5px; 
	     padding-left: 5px; 
	     float: left; 
	     padding-bottom: 0px; 
	     margin: 3px; 
	     width: 150px; 
	     padding-top: 5px;   
	}
	#ulCss li
	 { 
	     border-right: #000 1px solid; 
	     padding-right: 2px; 
	     border-top: #000 1px solid; 
	     padding-left: 2px; 
	     font-size: 14px; 
	     margin-bottom: 5px; 
	     padding-bottom: 2px; 
	     border-left: #000 1px solid; 
	     width: 145px; 
	     cursor: pointer; 
	     padding-top: 2px; 
	     border-bottom: #000 1px solid; 
	     font-family: verdana, tahoma, arial;
	 }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function CallPageMethod() {
            PageMethods.ReturnHtmlString(document.getElementById("tbInput").value, success, failed);
        }
        function success(result) {
            var info = document.getElementById("recommandWordList");
            info.innerHTML = "<ul id='ulCss'>" + result + "</ul>";
        }
        function failed(error) {
            var info = document.getElementById("recommandWordList");
            info.innerHTML = "";
        }
        function getValue(li) {
            var textBox = document.getElementById("tbInput");
            var value = li.innerText;
            textBox.value = value;
        }
    </script>
        <div>
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
            <asp:HyperLink ID="hypLink" runat="server" NavigateUrl="~/WordAddPage.aspx">Click here to add new word</asp:HyperLink>
            <br />
        <input type="text" id="tbInput" onkeyup="CallPageMethod();" />
            <asp:Label ID="lbMessage" runat="server" 
                Text="input your word in TextBox and click the item of word list to select one"></asp:Label>
    </div>
    <div id="recommandWordList"></div>
    </form>

</body>
</html>
