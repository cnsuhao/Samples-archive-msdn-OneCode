'**************************** Module Header ******************************\
' Module Name:	MainWindow.xaml.vb
' Project:	VBAzureTableStorageClassLibaryWithStoreApp
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to use latest Azure Storage SDK with Windows Store APP.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports Microsoft.WindowsAzure.Storage.Table
Imports System.Runtime.Serialization
Imports Windows.UI.Xaml.Navigation
Imports Microsoft.WindowsAzure.Storage.Auth

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238


Public Class TodoItem
    Inherits TableEntity
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

    <DataMember(Name:="IsComplete")> _
    Public Property IsComplete() As Boolean
        Get
            Return m_IsComplete
        End Get
        Set(value As Boolean)
            m_IsComplete = value
        End Set
    End Property
    Private m_IsComplete As Boolean

End Class

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Page
    Private todoItemList As New List(Of TodoItem)()

   

    ''' <summary>
    ''' Get the latest query results.
    ''' </summary>
    Private Async Function UpdateListView() As Task
        Await App.table.CreateIfNotExistsAsync()
        Dim continuationToken As TableContinuationToken = Nothing

        Dim query As TableQuery(Of TodoItem) = New TableQuery(Of TodoItem)().Where(TableQuery.GenerateFilterConditionForBool("IsComplete", QueryComparisons.Equal, False))

        Dim todoItemList = Await App.table.ExecuteQuerySegmentedAsync(query, continuationToken)
        lvwTodoItems.ItemsSource = todoItemList
    End Function

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
        Await UpdateListView()
    End Sub

    ''' <summary>
    ''' Save the a new todo item to Azure table storage.
    ''' </summary>
    Private Async Function btnSave_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim item = New TodoItem() With {
            .PartitionKey = "default",
            .RowKey = DateTime.Now.ToString("yyyyMMddHHmmss"),
            .IsComplete = False,
            .Message = tbMessage.Text
        }

        Try

            Dim insertOperation As TableOperation = TableOperation.Insert(item)
            Await App.table.ExecuteAsync(insertOperation)

            lbState.Text += DateTime.Now.ToString() & ": Save message successfully!" & vbLf
            todoItemList.Add(item)

            Await UpdateListView()

        Catch ex As Exception
            lbState.Text = ex.Message
        End Try

    End Function

    ''' <summary>
    ''' Delete a new item in new table storage.
    ''' </summary>
    ''' <param name="sender"></param>
    Private Async Function btnDelete_Click(sender As Object, e As RoutedEventArgs) As Task
        If lvwTodoItems.SelectedIndex <> -1 Then
            Dim item = TryCast(lvwTodoItems.SelectedItem, TodoItem)
            Try
                Dim deleteOperation As TableOperation = TableOperation.Delete(item)
                Await App.table.ExecuteAsync(deleteOperation)

                lbState.Text += DateTime.Now.ToString() & ": Delete message successfully!" & vbLf
                todoItemList.Remove(item)

                Await UpdateListView()

            Catch ex As Exception
                lbState.Text = ex.Message
            End Try
        End If
    End Function

    ''' <summary>
    ''' Change the complete filed in table storage to true, and this item won't list in
    ''' listview. 
    ''' </summary>
    Private Async Function btnComplete_Click(sender As Object, e As RoutedEventArgs) As Task
        If lvwTodoItems.SelectedIndex <> -1 Then
            Dim item = TryCast(lvwTodoItems.SelectedItem, TodoItem)
            item.IsComplete = True

            Try
                item.IsComplete = True
                Await App.table.ExecuteAsync(TableOperation.Merge(item))

                lbState.Text += String.Format("{0}: {1} is complete!" & vbLf, DateTime.Now.ToString(), item.Message)
                todoItemList.Remove(item)
                Await UpdateListView()

            Catch ex As Exception
                lbState.Text = ex.Message
            End Try
        End If
    End Function
End Class
