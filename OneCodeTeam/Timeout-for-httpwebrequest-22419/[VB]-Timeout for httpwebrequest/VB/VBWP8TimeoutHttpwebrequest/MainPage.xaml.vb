'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8TimeoutHttpwebrequest
' Copyright (c) Microsoft Corporation
'
' This sample will demo how to set Timeout for httpwebrequest. 
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
Imports System.Text
Imports System.IO

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Public Shared strRequestUri As String = "http://www.contoso.com"    ' Test URL
    Private ReadOnly timeoutMilliseconds As Integer = 5 * 1000          ' 5 seconds timeout
    Public Shared allDone As New ManualResetEvent(False)                ' ManualResetEvent instance
    Const BUFFER_SIZE As Integer = 1024                                 ' Size of receive buffer.
    Shared stringContent As String                                      ' Response string.

    ' Constructor
    Public Sub New()
        InitializeComponent()

        AddHandler Loaded, AddressOf MainPage_Loaded
    End Sub

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        Dim t As New Thread(New ThreadStart(AddressOf mainDelegate))
        t.IsBackground = True
        t.Start()
    End Sub

    Public Sub mainDelegate()
        Dim tr As Thread = Thread.CurrentThread
        Dim strResult As String = String.Empty
        ' Store message.
        Try
            Dim uri As New Uri(strRequestUri)
            ' Create a HttpWebrequest object to the desired URL.
            Dim myHttpWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)

            ' Create an instance of the RequestState and assign the previous myHttpWebRequest1
            ' object to it's request field.  
            Dim myRequestState As New RequestState()
            myRequestState.request = myHttpWebRequest

            ' Set the event to nonsignaled state.
            allDone.Reset()

            ' Start the asynchronous request.
            Dim result As IAsyncResult = DirectCast(myHttpWebRequest.BeginGetResponse(New AsyncCallback(AddressOf RespCallback), myRequestState), IAsyncResult)

            Dim isSuccess As Boolean = allDone.WaitOne(timeoutMilliseconds)

            If isSuccess Then
                ' Request succeeded before the timeout                  
                UpdateUIThread(tbResult, "Loaded Successful!")
                UpdateUIThread(tbResult, stringContent)
            Else
                ' allDone wasn't signaled by ReadCallback; the request timed out   
                If myHttpWebRequest IsNot Nothing Then
                    myHttpWebRequest.Abort()
                    ' Return an error, etc.   
                    UpdateUIThread(tbResult, "Loaded failed!")
                    Return
                End If
            End If
        Catch e As WebException
            strResult += "Exception raised!" & vbLf
            strResult += "Message: "
            strResult += e.Message
            strResult += vbLf & "Status: "
            strResult += e.Status
        Catch e As Exception
            strResult += vbLf & "Exception raised!" & vbLf
            strResult += "Message: "
            strResult += e.Message
        Finally
            UpdateUIThread(tbResult, strResult)
        End Try
    End Sub


    ''' <summary>
    ''' AsyncCallback delegate that is invoked when the asynchronous response is complete. 
    ''' </summary>
    ''' <param name="asynchronousResult"></param>
    Private Sub RespCallback(asynchronousResult As IAsyncResult)
        Try
            ' State of request is asynchronous.
            Dim myRequestState As RequestState = DirectCast(asynchronousResult.AsyncState, RequestState)
            Dim myHttpWebRequest2 As HttpWebRequest = myRequestState.request
            myRequestState.response = DirectCast(myHttpWebRequest2.EndGetResponse(asynchronousResult), HttpWebResponse)

            ' Read the response into a Stream object.
            Dim responseStream As Stream = myRequestState.response.GetResponseStream()
            myRequestState.streamResponse = responseStream

            ' Begin the Reading of the contents of the HTML page and print it to the console.
            Dim asynchronousInputRead As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, New AsyncCallback(AddressOf ReadCallBack), myRequestState)
        Catch e As WebException
            ' Need to handle the exception
            UpdateUIThread(tbResult, e.Message)
        Catch e As Exception
            UpdateUIThread(tbResult, e.Message)
        End Try

    End Sub

    ''' <summary>
    ''' AsyncCallback delegate that is invoked when the asynchronous read is complete. 
    ''' </summary>
    ''' <param name="asyncResult"></param>
    Private Sub ReadCallBack(asyncResult As IAsyncResult)
        Try
            Dim myRequestState As RequestState = DirectCast(asyncResult.AsyncState, RequestState)
            Dim responseStream As Stream = myRequestState.streamResponse
            Dim read As Integer = responseStream.EndRead(asyncResult)

            ' Read the HTML page and then do something with it
            If read > 0 Then
                myRequestState.requestData.Append(Encoding.UTF8.GetString(myRequestState.BufferRead, 0, read))
                Dim asynchronousResult As IAsyncResult = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, New AsyncCallback(AddressOf ReadCallBack), myRequestState)
            Else
                If myRequestState.requestData.Length > 1 Then
                    ' do something with the response stream here

                    ' UpdateUIThread(tbResult, stringContent);
                    stringContent = myRequestState.requestData.ToString()
                End If

                responseStream.Close()
                ' Signal the main thread to continue.
                allDone.[Set]()
            End If
        Catch e As WebException
            ' Need to handle the exception
            UpdateUIThread(tbResult, e.Message)
        Catch e As Exception
            ' Need to handle the exception
            UpdateUIThread(tbResult, e.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Write message to the UI thread.
    ''' </summary>
    ''' <param name="textBlock">The control to update.</param>
    ''' <param name="strTip">The message to show.</param>
    Private Sub UpdateUIThread(textBlock As TextBlock, strTip As String)
        Deployment.Current.Dispatcher.BeginInvoke(Sub() textBlock.Text = textBlock.Text + vbLf & strTip)
    End Sub
End Class

''' <summary>
''' This class stores the State of the request.
''' </summary>
Public Class RequestState
    Const BUFFER_SIZE As Integer = 1024
    Public requestData As StringBuilder
    Public BufferRead As Byte()
    Public request As HttpWebRequest
    Public response As HttpWebResponse
    Public streamResponse As Stream

    Public Sub New()
        BufferRead = New Byte(BUFFER_SIZE - 1) {}
        requestData = New StringBuilder("")
        request = Nothing
        streamResponse = Nothing
    End Sub
End Class
