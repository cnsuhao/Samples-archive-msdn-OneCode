'***************************** Module Header ******************************\
' Module Name:	MainWindow.xaml.vb
' Project:		VBAzureMobileServiceWithTableStorage
' Copyright (c) Microsoft Corporation.
'
' This sample shows how to use table storage with windows Azure mobile service.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Runtime.Serialization
Imports Microsoft.WindowsAzure.MobileServices

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

#Region "Entity Class"
''' <summary>
''' This class name should equal to the table name you created on Azure mobile service.
''' </summary>
Public Class ShortMessage
    Public Property Id() As Long
        Get
            Return m_Id
        End Get
        Set(value As Long)
            m_Id = value
        End Set
    End Property
    Private m_Id As Long

    <DataMember(Name:="PartitionKey")> _
    Public Property PartitionKey() As String
        Get
            Return m_PartitionKey
        End Get
        Set(value As String)
            m_PartitionKey = value
        End Set
    End Property
    Private m_PartitionKey As String

    <DataMember(Name:="RowKey")> _
    Public Property RowKey() As String
        Get
            Return m_RowKey
        End Get
        Set(value As String)
            m_RowKey = value
        End Set
    End Property
    Private m_RowKey As String

    <DataMember(Name:="Timestamp")> _
    Public Property Timestamp() As DateTime
        Get
            Return m_Timestamp
        End Get
        Set(value As DateTime)
            m_Timestamp = value
        End Set
    End Property
    Private m_Timestamp As DateTime

    <DataMember(Name:="Name")> _
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String

    <DataMember(Name:="Message")> _
    Public Property Message() As String
        Get
            Return m_Message
        End Get
        Set(value As String)
            m_Message = value
        End Set
    End Property
    Private m_Message As String

    <DataMember(Name:="IsRead")> _
    Public Property IsRead() As Boolean
        Get
            Return m_IsRead
        End Get
        Set(value As Boolean)
            m_IsRead = value
        End Set
    End Property
    Private m_IsRead As Boolean
End Class
#End Region

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Private ReadOnly shortMessageTable As IMobileServiceTable(Of ShortMessage) = App.MobileService.GetTable(Of ShortMessage)()
    Private ShortMessageView As MobileServiceCollectionView(Of ShortMessage)

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how tr3his page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        RefreshListView()
    End Sub

#Region "Event"

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        If tbName.Text <> "" AndAlso tbMessage.Text <> "" Then
            Dim message = New ShortMessage()
            message.Name = tbName.Text
            message.Message = tbMessage.Text
            InsertNewMessage(message)
        Else
            lbState.Text = "Name Or Message shouldn't be empty"
        End If

    End Sub

    Private Sub appbtnDelete_Click(sender As Object, e As RoutedEventArgs)
        Dim message = TryCast(lvwNewMessages.SelectedItem, ShortMessage)
        If message IsNot Nothing Then
            DeleteNewMessage(message)
        End If

    End Sub

    Private Sub appbtnUpdate_Click(sender As Object, e As RoutedEventArgs)
        Dim message = TryCast(lvwNewMessages.SelectedItem, ShortMessage)
        If message IsNot Nothing Then

            UpdateNewMessage(message)
        End If

    End Sub
#End Region

#Region "Method"

    ''' <summary>
    ''' Get New message by RefreshListView() token
    ''' </summary>
    Private Sub RefreshListView()
        ShortMessageView = shortMessageTable.ToCollectionView()

        lvwNewMessages.ItemsSource = ShortMessageView
    End Sub


    ''' <summary>
    ''' Insert the message into a table storage.
    ''' </summary>
    Private Async Sub InsertNewMessage(message As ShortMessage)
        Try
            Await shortMessageTable.InsertAsync(message)
            lbState.Text = "New message has been left"
            tbMessage.Text = ""
            tbName.Text = ""

            ShortMessageView.Add(message)
        Catch generatedExceptionName As Exception
            lbState.Text = "There is something error when leaving message, please try it again."
        End Try
    End Sub

    ''' <summary>
    ''' Delete the selected message. 
    ''' </summary>
    Private Async Sub DeleteNewMessage(message As ShortMessage)
        Try
            message.Id = Long.Parse(message.RowKey)
            Await shortMessageTable.DeleteAsync(message)

            ShortMessageView.Remove(message)
            lbState.Text = "This item has been deleted."
        Catch ex As Exception
            lbState.Text = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Update the selected message, mark it as read.
    ''' </summary>
    Private Async Sub UpdateNewMessage(message As ShortMessage)

        message.Id = Long.Parse(message.RowKey)
        message.IsRead = True
        Try
            Await shortMessageTable.UpdateAsync(message)
            ShortMessageView.Remove(message)
            lbState.Text = "Selected item has been marked as read."
        Catch ex As Exception
            lbState.Text = ex.Message
        End Try
    End Sub
#End Region

End Class
