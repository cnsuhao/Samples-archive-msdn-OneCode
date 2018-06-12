===========================================================================
            VBASPNETDetectBrowserCloserEvent Project Overview
===========================================================================

Summary:

As we know, HTTP is a stateless protocol, the browser doesn't keep connecting
to the server. When user try to close the browser using alt-f4, browser close(X) 
and right click on browser and close -> this all is done and is working fine,
it's not possible to tell the server that the browser is closed. The sample
demonstrates how to detect the browser close event with iframe.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample.

Step1: Browse the Default.aspx page from the sample. It will display the current
online clientlist.

Step2: Browse the Default.aspx page again
[Note]
If use IE, you should click File -> New Session, and then copy the address to the new 
window's address bar.It is best to browse the page on another computer or other browser.
[/Note]
You will see two records on the page. The other page will auto-refresh after 
several seconds, and it will also show two records.

Step3: Please close one of the page. After several seconds, you will see there is
only one record on the page.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step1: Create a VB ASP.NET Empty Web Application in Visual Studio 2010.

Step2: Add a VB class file which named 'ClientInfo' in Visual Studio 2010.
You can find the complete code in ClientInfo.vb file.

Step3: Add a Global Application class file which named 'Global' in Visual 
Studio 2010.You can find the complete code in Global.asax file. It is used
to detect the browser whether closed, and will auto delete off-line client.

Step4: Open the VB behind code view to write timer_Elapsed event.
You can find the complete version in the Global.asax.vb file.
[code]
Sub timer_Elapsed(ByVal sender As Object, ByVal e As EventArgs)
    Dim client As New ClientInfo
    Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))

    For i As Integer = 0 To clientList.Count - 1
        If clientList(i).RefreshTime < DateTime.Now.AddSeconds(0 - 5) Or
            clientList(i).ActiveTime < DateTime.Now.AddMinutes(0 - 20) Then
            client = ClientInfo.GetClientInfoByClientInfo(clientList, clientList(i).ClientID)
            clientList.Remove(client)
        End If
    Next

    Application("ClientInfo") = clientList
End Sub
[/code]

Step5: Add a Default ASP.NET page into the Web Application as the page
which used to display the online client.

Step6: Add a ScriptManager, a UpdatePanel, a Timer and a iframe into the 
page as the .aspx code below.
[code]
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="3000">
        </asp:Timer>
    </div>
    </form>
    <iframe id="Detect" src="DetectBrowserClosePage.aspx" style="border-width: 0px; border-style:none;
        width: 0px; height: 0px; overflow: hidden"></iframe>
</body>
</html>
[/code]

Step7: Open the VB behind code view to write Page_Load function.
You can find the complete version in the Default.aspx.vb file.
[code]
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim client As New ClientInfo
    Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))
    client = ClientInfo.GetClientInfoByClientInfo(clientList, Me.Session.SessionID)

    client.ActiveTime = DateTime.Now

    For i As Integer = 0 To clientList.Count - 1
        Response.Write(CStr(clientList(i).ClientID))
        Response.Write("<br />")
    Next
End Sub
[/code]

Step8: Add a DetectBrowserClosePage ASP.NET page into the Web Application as the page
which as the iframe for Default.aspx.

Step9: Set the page refresh per second as the .aspx code below.

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <meta http-equiv="refresh" content="1" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>

Step10: Open the VB behind code view to write Page_Load function.
You can find the complete version in the DetectBrowserClosePage.aspx.vb file.
[code]
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim client As New ClientInfo
    Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))
    client = ClientInfo.GetClientInfoByClientInfo(clientList, Me.Session.SessionID)

    '' Update the RefreshTime
    client.RefreshTime = DateTime.Now
End Sub
[/code]
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: 
# ASP.NET Session State
http://msdn.microsoft.com/en-us/library/ms178581(VS.100).aspx
/////////////////////////////////////////////////////////////////////////////