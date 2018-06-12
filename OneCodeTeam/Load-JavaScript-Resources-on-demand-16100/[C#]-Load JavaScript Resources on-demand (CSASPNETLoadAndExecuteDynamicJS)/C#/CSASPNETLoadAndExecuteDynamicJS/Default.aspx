<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CSASPNETLoadAndExecuteDynamicJS._Default" %>
    
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <script type="text/javascript">
     function LoadAndExecuteDynamicJS(src1) {
         
         $.ajax({
             type: "POST",
             url: "Service1.svc/LoadScript",
             data: JSON.stringify({ source: src1 }),
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (msg) {
                 $("head").append($("<script type='text/javascript' />").attr("src", msg.d));
                 alert('Script loaded');
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
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
<Services>
<asp:ServiceReference Path="~/Service1.svc" />

</Services>
</asp:ScriptManager>

        <hr/>

        <div>
        <table border="0" cellpadding="10" cellspacing="10">
            
            <tr><td><input id="Button1" type="button" value="Load Script stored on Internal Server" style="width:100%" onclick="javascript:LoadAndExecuteDynamicJS('DynamicScript.js');" /></td></tr>
            <tr><td><input id="Button2" type="button" value="Call Script stored on Internal Server" style="width:100%" onclick="javascript:Hello();" /></td></tr>
            <tr><td><input id="Text1" type="text" value="External Script URL" style="width:100%"/></td>
            <td><input id="Button3" type="button" value="Add script to the page" onclick="javascript:LoadExternalDynamicJS();"/></td></tr>
            </table>
        </div>   

</asp:Content>
