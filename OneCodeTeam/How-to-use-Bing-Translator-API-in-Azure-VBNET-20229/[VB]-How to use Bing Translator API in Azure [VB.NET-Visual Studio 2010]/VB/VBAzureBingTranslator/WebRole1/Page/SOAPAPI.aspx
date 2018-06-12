<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SOAPAPI.aspx.vb" Inherits="VBTranslatorForAzure.SOAPAPI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:LinkButton ID="Back" runat="server" PostBackUrl="~/Default.aspx">Back to default</asp:LinkButton></p>
    <h2>Chinese translator using bing translate SOAP API</h2>
         <p>
              This sample shows how to use the microsoft Translator SOAP API AddTranslation Method.</p>
    <p>
              For more details about this API, please refer to
              <a href="http://msdn.microsoft.com/en-us/library/ff512435.aspx">Microsoft 
              translator SOAP interface</a>.</p>
    <p>
              Please input English words, and click Translate button.</p>
    <p>
              You will get Chinese translation.</p>
    <p>
              Root url:<a href="http://api.microsofttranslator.com/V2/Soap.svc">http://api.microsofttranslator.com/V2/Soap.svc</a></p>
    <p>
              &nbsp;</p>
         <p>
             <asp:TextBox ID="tbNeedTranslate" runat="server"  
                 ></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     
         </p>
         <p>
             <asp:Button ID="btnTranslate" runat="server" onclick="btnTranslate_Click" 
                 Text="Translate" />
         </p>
    <p>
             &nbsp;</p>
         <p>Here is your translation:</p>
         <p>
             <asp:Literal ID="lblEntitySet" runat="server"></asp:Literal>
    </p>
    </form>
</body>
</html>
