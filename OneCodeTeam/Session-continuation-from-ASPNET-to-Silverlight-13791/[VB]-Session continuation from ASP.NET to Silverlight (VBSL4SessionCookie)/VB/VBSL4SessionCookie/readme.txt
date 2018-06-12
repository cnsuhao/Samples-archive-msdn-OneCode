=============================================================================
       Sivlerlight APPLICATION: VBSL4SessionCookie Overview
=============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:  

This sample demonstrates a simple technique to preserve ASP.NET session ID 
from a web page hosting a Silverlight component making a client WebRequest to 
another web page on the same site.  Normally, the WebRequest will not by 
default preserve session id, and this can be frustrating for a Silverlight 
developer.  But by appending the Session ID cookie manually to the request, 
passing it into the Silverlight component through a parameter on the calling 
web page, the session can in fact be preserved.


/////////////////////////////////////////////////////////////////////////////
Demo:

To see the sample, run the code and launch VBSL4SessionCookieTestPage.aspx 
and VerifySessionMaintained.aspx. It demonstrates preserving ASP.NET session 
ID from a web page hosting a Silverlight component making a client WebRequest 
to another web page on the same site.  

In MainPage.xaml.vb of VBSL4SessionCookie, commenting out the following line 
will demonstrate the session ID being lost in the resulting web client request. 
[Note]
    This sample can only preserve Asp.net session ID when cookie is enabled,
So please persist cookieLess property value is false.
[/Note] 

   wr.CookieContainer.Add(New Uri("http://localhost:7777"), 
             New Cookie("ASP.NET_SessionID", session))

/////////////////////////////////////////////////////////////////////////////
Implementation:

VBSL4SessionCookieTestPage.aspx simply launches the Silverlight component 
which is built into the VBSL4SessionCookie.xap, in the ClientBin directory of 
the output, and passes a parameter which includes the ASP.NET Session ID, on 
line 83 of VBSL4SessionCookieTestPage.aspx.  This originating web page also 
displays its current session ID so the user can see and compare to confirm 
that indeed, the session ID will match what is reported from the Silverlight 
request as well.

When the Silverlight component start, the code in MainPage.xaml.vb is 
invoked, and creates a WebRequest used to load 
VerifySessionStateMaintained.aspx, another web page on the web site from 
which the original .aspx was loaded.  The WebRequest appends a cookie for the 
ASP.NET_SessionID, providing the parameter value that was originally passed 
via URL to the Silverlight component.

Finally, the VerifySessionStateMaintained.aspx page is loaded and returned to 
the WebRequest.  This page simply returns a line of text confirming the 
Session ID of its current session.

The Silverlight component just outputs the text returned from 
VerifySessionStateMaintained.aspx, when it is received, so the user can 
compare the session ID of the original web page, alongside that of the page 
called from within Silverlight, to verify they are the same.

Following steps below for creating this sample:

Step 1. Create a C# "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSSL4SessionCookie".
		Please also create a Web application.

Step 2. Create a VerifyManintained page in "CSSL4SessionCookie.Web" application,
        and output session ID on the page.

Step 3. Add a TextBlock control on MainPage.xaml, we need create HttpWebRequest 
        instance for getting session ID from web request.
		The code as shown below:
		[code]
Partial Public Class MainPage
    Inherits UserControl
    Private wr As HttpWebRequest
    Private output As String

    Public Sub New()
        InitializeComponent()
        Dim url As String = Application.Current.Host.Source.OriginalString

        ' In this case, we simply pass one parameter into Silverlight with 
        ' no other text, so we retrieve the whole query string after the '?' 
        ' to obtain the session ID passed in.
        Dim session As String = url.Substring(url.IndexOf("?") + 1)

        ' This sample just calls a simple .aspx page that returns only a 
        ' message with the session ID. In order to avoid webpage caching, 
        ' a time ticks string is appended to the URL query string.
        ' The same technique can be used for any web service call, though.
        wr = WebRequest.CreateHttp("http://localhost:64024/VerifySessionMaintained.aspx" & "?" & DateTime.Now.Ticks)

        ' Set up a cookie container we will use to store the session cookie.
        wr.CookieContainer = New CookieContainer()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Commenting out the following line will demonstrate the session ID ''
        '   being lost in the resulting web client request.                 ''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        wr.CookieContainer.Add(New Uri("http://localhost:64024"), New Cookie("ASP.NET_SessionID", session))


        wr.BeginGetResponse(New AsyncCallback(AddressOf Callback), Nothing)
    End Sub

    Public Sub Callback(ByVal res As IAsyncResult)
        ' Retrieve the response from the server.
        Dim wres As WebResponse = wr.EndGetResponse(res)
        Dim buffer As Byte() = New Byte(wres.ContentLength - 1) {}
        wres.GetResponseStream().Read(buffer, 0, buffer.Length)
        output = UTF8Encoding.UTF8.GetString(buffer, 0, buffer.Length)

        ' Dispatch a call to the UI thread to update the textbox content with our response.
        Dispatcher.BeginInvoke(New Action(AddressOf UpdateTextbox))
    End Sub

    Private Sub UpdateTextbox()
        SampleTextBlock.Text = output
    End Sub
End Class
		[/code]

/////////////////////////////////////////////////////////////////////////////
References:  

For more information about Silverlight, go to 
http://www.silverlight.net/.  

For more information about ASP.NET session state, go to 
http://msdn.microsoft.com/en-us/library/ms972429.aspx.

For more information about using the WebRequest, go to 
http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx.


/////////////////////////////////////////////////////////////////////////////