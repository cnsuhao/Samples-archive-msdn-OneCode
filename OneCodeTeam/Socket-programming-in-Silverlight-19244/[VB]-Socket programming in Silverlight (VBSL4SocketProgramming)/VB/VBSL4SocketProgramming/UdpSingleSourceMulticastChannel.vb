'**************************** Module Header ******************************\
' Module Name: UdpSingleSourceMulticastChannel.vb
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
' This class use to create a SSM client.
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

Public Class UdpSingleSourceMulticastChannel
    Implements IDisposable
    Private SSMClient As UdpSingleSourceMulticastClient
    Private byteBuffer As Byte()
    Private serverIP As IPAddress
    Private targetIP As IPAddress
    Private port As Integer
    Public IsJoinBroadcast As Boolean
    Public IsReceived As Boolean
    Public Event AfterOpen As EventHandler
    Public Event BeforeReceived As EventHandler(Of UdpConvertMessageEvent)
    Public Event BeforeCloseSSM As EventHandler

    ''' <summary>
    ''' Constructor method. Define a buffer bytes variable,
    ''' server IP, group IP, port, and a SSM client.
    ''' </summary>
    ''' <param name="serverIP"></param>
    ''' <param name="targetIP"></param>
    ''' <param name="port"></param>
    ''' <param name="messageSize"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal serverIP As IPAddress, ByVal targetIP As IPAddress, ByVal port As Integer, ByVal messageSize As Integer)
        Me.serverIP = serverIP
        Me.targetIP = targetIP
        Me.port = port
        byteBuffer = New Byte(messageSize - 1) {}
        SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)
    End Sub

    ''' <summary>
    ''' Connect to SSM server method.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Open()
        If Me.isJoinBroadcast Then
            Return
        End If
        If SSMClient Is Nothing Then
            SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)
        End If
        Dim callBack As New AsyncCallback(AddressOf OpenCallBack)
        SSMClient.BeginJoinGroup(callBack, Nothing)
    End Sub

    Private Sub OpenCallBack(ByVal result As IAsyncResult)
        SSMClient.EndJoinGroup(result)
        Me.isJoinBroadcast = True
        Me.isReceived = True
        Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)
    End Sub

    Private Sub OpenInvoke()
        RaiseEvent AfterOpen(Me, EventArgs.Empty)
        Me.Received()
    End Sub

    ''' <summary>
    ''' Receive message from ASM server method.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Received()
        If Not Me.isJoinBroadcast Then
            Return
        End If
        If Me.isReceived Then
        Array.Clear(byteBuffer, 0, byteBuffer.Length)
            SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length,
                 Function(result)
                     If Me.isJoinBroadcast Then
                         SSMClient.EndReceiveFromSource(result, sourcePoint)
                         Deployment.Current.Dispatcher.BeginInvoke(
                             Function()
                                 If Me.isJoinBroadcast Then
                                     RaiseEvent BeforeReceived(Me, New UdpConvertMessageEvent(byteBuffer, New IPEndPoint(serverIP, sourcePoint)))
                                     Me.Received()
                                     Return vbEmpty
                                 Else
                                     Return vbEmpty
                                 End If
                             End Function
                         )
                         Return vbEmpty
                     Else
                         Return vbEmpty
                     End If
                 End Function, Nothing)
        End If
    End Sub
    Dim sourcePoint As Integer
    ''' <summary>
    ''' Close the connection event.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        Me.isJoinBroadcast = False
        RaiseEvent BeforeCloseSSM(Me, EventArgs.Empty)
        Dispose(True)
    End Sub
    ' To detect redundant calls
    Private disposedValue As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If SSMClient IsNot Nothing Then
                    SSMClient.Dispose()
                    SSMClient = Nothing
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
