<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AJAXAPI.aspx.vb" Inherits="VBTranslatorForAzure.AJAXAPI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    var languageFrom = "en";
    var languageTo = "zh-CHS";
    var text = "";
    function translate() {
        PageMethods.GetAccessToken(OnSucceeded, OnFailed);
    }
    function OnSucceeded(result, usercontext, methodName) {
        text = document.getElementById('<%= tbNeedTranslate.ClientID %>').value;
        window.mycallback = function (response) {
            document.getElementById('<%= lblEntitySet.ClientID %>').innerHTML = response;
        }

        var newscript = document.createElement("script");
        newscript.src = "http://api.microsofttranslator.com/V2/Ajax.svc/Translate?oncomplete=mycallback&appId=Bearer " + encodeURIComponent(result.access_token) + "&from=" + languageFrom + "&to=" + languageTo + "&text=" + text;
        document.getElementsByTagName("head")[0].appendChild(newscript);
    }
    function OnFailed(error, userContext, methodName) {
        alert("You have some error when create a access token!");
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true"/> 
    <p>
        <asp:LinkButton ID="Back" runat="server" PostBackUrl="~/Default.aspx">Back to default</asp:LinkButton></p>
    <h2>Chinese translator using bing translate AJAX API</h2>
         <p>
              This sample shows how to use the AJAX API in microsoft Translator.</p>
         <p>
              For more details about this interface, please refer to
              <a href="http://msdn.microsoft.com/en-us/library/ff512404.aspx">Microsoft 
              translator AJAX interface</a>:</p>
         <p>
              Please input English words, and click Translate button.</p>
         <p>
              You will get Chinese translation.</p>
         <p>
              Root url:http://api.microsofttranslator.com/V2/Ajax.svc </p>
         <p>
         </p>
         <p>
             <asp:TextBox ID="tbNeedTranslate" runat="server"/>          
         </p>
         <p>
             <asp:Button ID="btnTranslate" runat="server" OnClientClick="translate();return false;"
                 Text="Translate"  />
         </p>
         <p>
             Here is your translation:</p>
         <p>
            <asp:Label ID="lblEntitySet" runat="server"></asp:Label>
         </p>
    </form>
</body>
</html>