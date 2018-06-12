'**************************** Module Header ******************************\
' Module Name: Demo.xaml.vb
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
' This page use to send and receive messages from server application.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports VBSL4SocketProgramming.My.Resources

Partial Public Class Demo
    Inherits Page

    ' Define two UDP channels for sending and receiving the message from server or other clients.
    Private udpSSMChannel As UdpSingleSourceMulticastChannel
    Private udpASMChannel As UdpAnySourceMulticastChannel
    Private isPause As Boolean = False

    Public Sub New()

        ' Initialize the UDP channel with resource files, There you can add 
        ' user-defined event for connect server, send or receive message.
        InitializeComponent()

        ' SSM(UdpSingleSourceMulticast) channel.
        udpSSMChannel = New UdpSingleSourceMulticastChannel(IPAddress.Parse(IPConfig.YourIP), IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.SSMLocalPort), 2048)
        AddHandler udpSSMChannel.AfterOpen, AddressOf AfterOpeningSSMEvent
        AddHandler udpSSMChannel.BeforeReceived, AddressOf BeforeReceivedSSMEvent
        AddHandler udpSSMChannel.BeforeCloseSSM, AddressOf BeforeCloseSSMEvent
        udpSSMChannel.Open()

        ' ASM(UdpAnySourceMulticast) channel.
        udpASMChannel = New UdpAnySourceMulticastChannel(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.ASMLocalPort), 2048)
        AddHandler udpASMChannel.OpeningEvent, AddressOf OpeningASMEvent
        AddHandler udpASMChannel.ReceivedEvent, AddressOf ReceivedASMEvent
        AddHandler udpASMChannel.ClosingEvent, AddressOf ClosingASMEvent
        udpASMChannel.Open()

    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    ' Connect ASM server event. 
    Private Sub OpeningASMEvent(ByVal obj As Object, ByVal e As EventArgs)
        lstAllMsg.Items.Insert(0, "Connect ASM server")
    End Sub

    ' Receive message from ASM server event.
    Private Sub ReceivedASMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)
        Dim message As String = String.Format("{0} - Come from：{1}", e.BufferMessage.TrimEnd(ControlChars.NullChar), e.EndPoint.ToString())
        lstAllMsg.Items.Insert(0, message)
    End Sub

    ' Close ASM server event.
    Private Sub ClosingASMEvent(ByVal obj As Object, ByVal e As EventArgs)
        lstAllMsg.Items.Insert(0, "Disconnect ASM server")
    End Sub

    ' Connect SSM server event
    Private Sub AfterOpeningSSMEvent(ByVal obj As Object, ByVal e As EventArgs)
        lstAllMsg.Items.Insert(0, "Connect SSM server")
    End Sub

    ' Receive message from SSM server event.
    Private Sub BeforeReceivedSSMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)
        Dim message As String = [String].Format("Come from {0} : {1}", e.EndPoint, e.BufferMessage)
        lstAllMsg.Items.Insert(0, message)
        If Me.isPause Then
            lstAllMsg.Items.Insert(0, "The broadcast had been paused.")
        End If
    End Sub

    ' Close SSM server event.
    Private Sub BeforeCloseSSMEvent(ByVal obj As Object, ByVal e As EventArgs)
        lstAllMsg.Items.Insert(0, "Disconnect SSM server")
    End Sub

    ''' <summary>
    ''' Send message from the client-side to other client-sides
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim strSendText As String = tbSendMessage.Text
        If strSendText.Trim() = [String].Empty Then
            lstAllMsg.Items.Insert(0, "You can not send empty message")
            Return
        End If
        Dim sendMessage As String = [String].Format("The message {0}:", strSendText)
        udpASMChannel.Send(sendMessage)
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If udpASMChannel.IsJoined <> False AndAlso udpSSMChannel.IsJoinBroadcast <> False Then
            If Me.isPause Then
                btnPause.Content = "Pause broadcast"
                Me.isPause = False
                udpASMChannel.IsReceived = True
                udpSSMChannel.isReceived = True
                udpSSMChannel.Received()
                lstAllMsg.Items.Insert(0, "The broadcast had been resumed.")
            Else
                btnPause.Content = "Resume broadcast"
                Me.isPause = True
                udpASMChannel.IsReceived = False
                udpSSMChannel.isReceived = False
            End If
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        udpSSMChannel.Close()
        udpASMChannel.Close()
    End Sub
End Class
