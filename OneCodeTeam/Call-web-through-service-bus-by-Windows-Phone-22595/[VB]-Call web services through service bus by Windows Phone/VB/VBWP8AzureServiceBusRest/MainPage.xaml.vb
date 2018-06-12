'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8AzureServiceBusRest
' Copyright (c) Microsoft Corporation
'
' This sample demonstrates how to use the Windows Azure Service Bus on
' Windows Phone. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Diagnostics

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Your Service Namespace
    Shared serviceNamespace As String = "[Your Service Namespace]"
    Shared baseAddress As String = String.Empty
    Shared token As String = String.Empty
    Const sbHostName As String = "servicebus.windows.net"
    Const acsHostName As String = "accesscontrol.windows.net"
    ' Your issuer name
    Shared issuerName As String = "[Your issuer name]"
    ' Your issuer secret
    Shared issuerSecret As String = "[Your issuer secret]"
    ' Note that the realm used when requesting a token uses the HTTP scheme, even though
    ' calls to the service are always issued over HTTPS
    Shared realm As String = String.Empty

    ' Constructor
    Public Sub New()
        InitializeComponent()

        AddHandler Loaded, AddressOf MainPage_Loaded
    End Sub

    ''' <summary>
    ''' Update UI.
    ''' </summary>
    ''' <param name="textBlock">TextBlock</param>
    ''' <param name="strTip">Text to display.</param>
    Private Sub UpdateUIThread(textBlock As TextBlock, strTip As String)
        Deployment.Current.Dispatcher.BeginInvoke(Sub() textBlock.Text = strTip)
    End Sub

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        baseAddress = "https://" & serviceNamespace & "." & sbHostName & "/"
        Try
            Dim acsEndpoint As String = "https://" & serviceNamespace & "-sb." & acsHostName & "/WRAPv0.9/"
            realm = "http://" & serviceNamespace & "." & sbHostName & "/"

            Dim postdata As String = "wrap_name=" & Uri.EscapeDataString(issuerName) & _
                "&wrap_password=" & Uri.EscapeDataString(issuerSecret) & _
                "&wrap_scope=" & Uri.EscapeDataString(realm)

            Dim strResponse As String = Await post(acsEndpoint, postdata)
            Dim responseProperties = strResponse.Split("&"c)
            Dim tokenProperty = responseProperties(0).Split("="c)
            token = Uri.UnescapeDataString(tokenProperty(1))
            token = "WRAP access_token=""" & token & """"
            UpdateUIThread(tbDebug, token)

            Dim queueName As String = "Queue" & Guid.NewGuid().ToString()
            CreateQueue(queueName, token)
            SendMessage(queueName, "msg1")
            ReceiveMessage(queueName)

            GetResources("$Resources/Queues")
        Catch we As WebException
            Using response As HttpWebResponse = TryCast(we.Response, HttpWebResponse)
                If response IsNot Nothing Then
                    Debug.WriteLine(New StreamReader(response.GetResponseStream()).ReadToEnd())
                Else
                    Debug.WriteLine(we.ToString())
                End If
            End Using
        End Try
    End Sub

    ''' <summary>
    ''' Generate Token.
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    Private Async Function post(url As String, postdata As String) As Task(Of String)
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(New Uri(url)), HttpWebRequest)
        request.ContentType = "application/x-www-form-urlencoded"
        request.Method = "POST"

        Dim data As Byte() = Encoding.UTF8.GetBytes(postdata)
        request.ContentLength = data.Length

        Using requestStream = Await Task(Of Stream).Factory.FromAsync(AddressOf request.BeginGetRequestStream, AddressOf request.EndGetRequestStream, request)
            Await requestStream.WriteAsync(data, 0, data.Length)
        End Using

        '' Start the asynchronous operation to get the response 

        Dim responseObject As WebResponse = Await Task(Of WebResponse).Factory.FromAsync(AddressOf request.BeginGetResponse, AddressOf request.EndGetResponse, request)
        Dim responseStream = responseObject.GetResponseStream()
        Dim sr = New StreamReader(responseStream)
        Dim received As String = Await sr.ReadToEndAsync()

        Return received
    End Function

    ''' <summary>
    ''' Create Queue.
    ''' </summary>
    ''' <param name="queueName"></param>
    ''' <param name="token"></param>
    Private Sub CreateQueue(queueName As String, token As String)
        ' Create the URI of the new Queue, note that this uses the HTTPS scheme
        Dim queueAddress = baseAddress & queueName
        Dim webClient As New WebClient()
        webClient.Headers(HttpRequestHeader.Authorization) = token

        ' Prepare the body of the create queue request
        Dim putData = "<entry xmlns=""http://www.w3.org/2005/Atom"">" & vbCr & vbLf & _
            "<title type=""text"">" & queueName & "</title>" & vbCr & vbLf & _
            " <content type=""application/xml"">" & vbCr & vbLf & _
            "  <QueueDescription xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.microsoft.com/netservices/2010/10/servicebus/connect"" />" _
            & vbCr & vbLf & "    </content>" & vbCr & vbLf & _
            "</entry>"
        Debug.WriteLine(vbLf & "Creating queue {0}", queueAddress)
        AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_CreateQueueCompleted)

        webClient.UploadStringAsync(New Uri(queueAddress), "PUT", putData, token)
    End Sub

    ''' <summary>
    ''' Send Message.
    ''' </summary>
    ''' <param name="relativeAddress"></param>
    ''' <param name="body"></param>
    Private Sub SendMessage(relativeAddress As String, body As String)
        Dim fullAddress As String = baseAddress & relativeAddress & "/messages" & "?timeout=60"

        Dim webClient As New WebClient()
        webClient.Headers(HttpRequestHeader.Authorization) = token

        Debug.WriteLine(vbLf & "Sending message {0} - to address {1}", body, fullAddress)
        AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_UploadStringCompleted)

        webClient.UploadStringAsync(New Uri(fullAddress), "POST", body, token)
    End Sub

    Private Sub webClient_UploadStringCompleted(sender As Object, e As UploadStringCompletedEventArgs)
        If e.[Error] IsNot Nothing Then
            Return
        End If
        Debug.WriteLine(e.Result)
    End Sub

    Private Sub webClient_CreateQueueCompleted(sender As Object, e As UploadStringCompletedEventArgs)
        If e.[Error] IsNot Nothing Then
            Return
        End If
        Debug.WriteLine(e.Result)
    End Sub

    ''' <summary>
    ''' Receive Message.
    ''' </summary>
    ''' <param name="relativeAddress"></param>
    Private Sub ReceiveMessage(relativeAddress As String)
        Dim fullAddress As String = baseAddress & relativeAddress & "/messages/head" & "?timeout=60"
        DownloadData(fullAddress, String.Format(vbLf & "Retrieving message from {0}", fullAddress))
    End Sub

    ''' <summary>
    ''' Get an Atom feed with all the queues in the namespace
    ''' </summary>
    ''' <param name="relativeAddress"></param>
    Private Shared Sub GetResources(relativeAddress As String)
        Dim fullAddress As String = baseAddress & relativeAddress
        DownloadData(fullAddress, String.Format(vbLf & "Getting resources from {0}", fullAddress))
    End Sub

    ''' <summary>
    ''' Download Data.
    ''' </summary>
    ''' <param name="fullAddress">Uri string.</param>
    ''' <param name="strMessage">Tip message.</param>
    Private Shared Sub DownloadData(fullAddress As String, strMessage As String)
        Dim webClient As New WebClient()
        webClient.Headers(HttpRequestHeader.Authorization) = token

        Debug.WriteLine(strMessage)
        AddHandler webClient.DownloadStringCompleted, New DownloadStringCompletedEventHandler(AddressOf DownloadStringCompletedEventArgs)

        webClient.DownloadStringAsync(New Uri(fullAddress))
    End Sub

    Private Shared Sub DownloadStringCompletedEventArgs(sender As Object, e As DownloadStringCompletedEventArgs)
        If e.[Error] IsNot Nothing Then
            Return
        End If
        Debug.WriteLine(e.Result)
    End Sub
End Class
