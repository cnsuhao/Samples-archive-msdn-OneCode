Imports System.Text

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