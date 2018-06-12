'**************************** Module Header ******************************\
' Module Name: UdpAnySourceMulticastChannel.vb
' Project:     VBSL4SocketProgramming
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use Socket achieve MultiCast function
' in Silverlight. We demonstrate ISM and SSM in this sample, The 
' application includes a console application as server side and a 
' Silverlight application as client side, the server will broadcast
' messages to client sides and client sides can also send messages 
' to other users.
'
' This class use to create a ISM client.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports System.Net.Sockets
Imports System.Text

Public Class UdpAnySourceMulticastChannel
    Implements IDisposable

    Private AsmClient As UdpAnySourceMulticastClient
    Private bufferVariable As Byte()
    Public IsJoined As Boolean
    Public IsReceived As Boolean = True
    Public Event ReceivedEvent As EventHandler(Of UdpConvertMessageEvent)
    Public Event OpeningEvent As EventHandler
    Public Event ClosingEvent As EventHandler

    ''' <summary>
    ''' Constructor method. Define a buffer bytes variable and an ASM client. 
    ''' </summary>
    ''' <param name="ipAddress"></param>
    ''' <param name="port"></param>
    ''' <param name="maxMessageSize"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ipAddress As IPAddress, ByVal port As Integer, ByVal maxMessageSize As Integer)
        bufferVariable = New Byte(maxMessageSize - 1) {}
        AsmClient = New UdpAnySourceMulticastClient(ipAddress, port)
    End Sub

    ''' <summary>
    '''  Handle receive message from server event.
    ''' </summary>
    ''' <param name="ipSource"></param>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub Received(ByVal ipSource As IPEndPoint, ByVal message As Byte())
        RaiseEvent ReceivedEvent(Me, New UdpConvertMessageEvent(message, ipSource))
    End Sub

    ''' <summary>
    ''' Handle connect to server event.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Opening()
        RaiseEvent OpeningEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handle close the connection event.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Closing()
        RaiseEvent ClosingEvent(Me, EventArgs.Empty)
    End Sub

    Public Sub Close()
        Me.IsJoined = False
        Me.Closing()
        Dispose(True)
    End Sub

    ''' <summary>
    ''' Connect to ASM server method.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Open()
        If Not IsJoined Then
            Dim callBack As New AsyncCallback(AddressOf OpenEvent)
            AsmClient.BeginJoinGroup(callBack, Nothing)
        End If
    End Sub

    Private Sub OpenEvent(ByVal result As IAsyncResult)
        AsmClient.EndJoinGroup(result)
        Me.IsJoined = True
        Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)
    End Sub

    Private Sub OpenInvoke()
        Me.Opening()
        Me.Receive()
    End Sub

    ''' <summary>
    ''' Receive message method.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Receive()
        If IsJoined Then
            If IsReceived Then
                Array.Clear(bufferVariable, 0, bufferVariable.Length)
                Dim callBack As New AsyncCallback(AddressOf ReciveCallBack)
                AsmClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, Nothing)
            End If
        End If
    End Sub

    Dim fromIP As IPEndPoint = Nothing
    Public Sub ReciveCallBack(ByVal result As IAsyncResult)
        If IsJoined Then
            If IsReceived Then
                AsmClient.EndReceiveFromGroup(result, fromIP)
                Deployment.Current.Dispatcher.BeginInvoke(AddressOf ReceiveInvoke)
            End If
        End If
    End Sub
    Public Sub ReceiveInvoke()
        If IsJoined Then
            If IsReceived Then
                Me.Received(fromIP, bufferVariable)
                Me.Receive()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Send message method.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub Send(ByVal message As String)
        If IsJoined Then
            Dim sendMessage As Byte() = Encoding.UTF8.GetBytes(message)
            Dim callBack As New AsyncCallback(AddressOf SendInvoke)
            AsmClient.BeginSendToGroup(sendMessage, 0, sendMessage.Length, callBack, Nothing)
        End If
    End Sub

    Public Sub SendInvoke(ByVal result)
        AsmClient.EndSendToGroup(result)
    End Sub
    ' To detect redundant calls
    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If AsmClient IsNot Nothing Then
                    AsmClient.Dispose()
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
