'***************************** Module Header ******************************\
' Module Name:	MainWindow.xaml.vb
' Project:		VBAuzreTaskBasedServiceBus
' Copyright (c) Microsoft Corporation.
'
' This sample shows the new feature in Windows Azure Service Bus Client SDK 2.0.
' The SDK APIs have improved to offer System.Threading.Tasks.Task based versions 
' of all asynchronous APIs. 
' This means that you can write asynchronous code that mere mortals can read.
'
' MainWindow.xaml.vb
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports Microsoft.ServiceBus
Imports Microsoft.ServiceBus.Messaging

Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
        initializeControls()
    End Sub

    ''' <summary>
    ''' Initialize all controls which need to get data from service bus.
    ''' </summary>
    Public Async Function initializeControls() As Task
        cbxChooseRetrieveMessageQueue.IsEnabled = False
        cbxChooseSendMessageQueue.IsEnabled = False
        Dim manager As NamespaceManager = NamespaceManager.Create()
        Dim queueNameList As New List(Of String)()
        Dim Queues = Await manager.GetQueuesAsync()
        lstQueues.Items.Clear()
        For Each queue In Queues
            queueNameList.Add(queue.Path)
            lstQueues.Items.Add(String.Format("{0}" & vbTab & vbTab & vbTab & "length={1}", queue.Path, queue.MessageCount))
        Next
        cbxChooseSendMessageQueue.ItemsSource = queueNameList
        cbxChooseRetrieveMessageQueue.ItemsSource = queueNameList
        cbxChooseSendMessageQueue.IsEnabled = True
        cbxChooseRetrieveMessageQueue.IsEnabled = True

    End Function
    ''' <summary>
    ''' Create new service bus queue use Async method.
    ''' </summary>
    Private Async Sub btnCreateNewQueue_Click(sender As Object, e As RoutedEventArgs)
        btnCreateNewQueue.IsEnabled = False
        Dim manager As NamespaceManager = NamespaceManager.Create()
        If txtCreateQueue.Text <> "" AndAlso (Not Await (manager.QueueExistsAsync(txtCreateQueue.Text))) Then
            Await manager.CreateQueueAsync(txtCreateQueue.Text)
        End If
        Await initializeControls()
        btnCreateNewQueue.IsEnabled = True
        txtCreateQueue.Text = Nothing
    End Sub

    ''' <summary>
    ''' Send message to service bus queue use Async method.
    ''' </summary>
    Private Async Sub btnSendMessage_Click(sender As Object, e As RoutedEventArgs)
        btnSendMessage.IsEnabled = False
        Dim client As QueueClient = QueueClient.Create(cbxChooseSendMessageQueue.SelectedValue.ToString())
        If txtSendMessage.Text IsNot Nothing Then

            Await client.SendAsync(New BrokeredMessage(txtSendMessage.Text))


            Await initializeControls()
        End If
        btnSendMessage.IsEnabled = True
    End Sub

    ''' <summary>
    ''' Retrieve service bus message use Async method.
    ''' </summary>
    Private Async Sub btnRetrieveMessage_Click(sender As Object, e As RoutedEventArgs)
        btnRetrieveMessage.IsEnabled = False
        Dim client As QueueClient = QueueClient.Create(cbxChooseRetrieveMessageQueue.SelectedValue.ToString(), ReceiveMode.ReceiveAndDelete)

        Dim receivedMessage As BrokeredMessage = Await client.ReceiveAsync()
        If receivedMessage IsNot Nothing Then
            txtDetails.Text = String.Format("Message Content:" & vbLf & "{0}" & vbLf & vbLf, receivedMessage.GetBody(Of String)())

            txtDetails.Text += ("BrokeredMessage Properties" & vbLf & String.Format("Size" & vbTab & "{0}" & vbLf, receivedMessage.Size) & String.Format("MessageId" & vbTab & "{0}" & vbLf, receivedMessage.MessageId) & String.Format("TimeToLive" & vbTab & "{0}" & vbLf, receivedMessage.TimeToLive) & String.Format("EnqueuedTimeUtc" & vbTab & "{0}" & vbLf, receivedMessage.EnqueuedTimeUtc) & String.Format("ExpiresAtUtc" & vbTab & "{0}" & vbLf, receivedMessage.ExpiresAtUtc))
        End If
        Await initializeControls()
        btnRetrieveMessage.IsEnabled = True
    End Sub
End Class
