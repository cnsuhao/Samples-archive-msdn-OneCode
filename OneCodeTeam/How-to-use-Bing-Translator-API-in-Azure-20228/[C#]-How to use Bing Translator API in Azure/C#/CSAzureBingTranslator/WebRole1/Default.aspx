<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TranslatorForAzure.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:LinkButton ID="LinkButton2" runat="server" 
            PostBackUrl="~/Page/HTTPAPI.aspx">Using bing translate HTTP API</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Page/AJAXAPI.aspx">Using bing translate AJAX API</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" 
            PostBackUrl="~/Page/SOAPAPI.aspx">Using bing translate SOAP API</asp:LinkButton>
    </div>
    </form>
</body>
</html>
