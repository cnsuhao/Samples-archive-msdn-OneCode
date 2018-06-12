'***************************** Module Header ******************************\
' Module Name:  MyNote.xaml.vb
' Project:		VBWP8SkydriveNote
' Copyright (c) Microsoft Corporation.
' 
' This demo shows how to backup Note to Skydrive.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports Microsoft.Live
Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO
Partial Public Class MyNote
    Inherits PhoneApplicationPage
    Private note As Note

    'The isDeleteNote field is used to identify if the navigation action
    'is caused by delete, if yes, then, the note will not be saved. 
    Private isDeleteNote As Boolean = False
    Private fileName As String
    Private noteId As String

    Private client As LiveConnectClient
    Private session As LiveConnectSession

    Public Sub New()
        InitializeComponent()
        isDeleteNote = False
    End Sub

    ''' <summary>
    ''' Called when this page becomes the active page. 
    ''' </summary>
    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        ShowNote()
        isDeleteNote = False
    End Sub

    ''' <summary>
    ''' Called just before navigating away from this page. 
    ''' </summary>
    Protected Overrides Sub OnNavigatedFrom(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedFrom(e)
        NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.Relative))
    End Sub

    ''' <summary>
    ''' Called when page is navigating away. 
    ''' </summary>
    Protected Overrides Sub OnNavigatingFrom(e As System.Windows.Navigation.NavigatingCancelEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As RoutedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub

    Private Sub CreateNewNote()
        note = New Note()
        note.NoteID = Guid.NewGuid()
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now

        noteId = note.NoteID.ToString()

        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & ".txt")
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub

    Private Sub ShowNote()
        'Get the page id
        If Me.NavigationContext.QueryString.Count < 1 Then
            CreateNewNote()
            Return
        End If
        noteId = Me.NavigationContext.QueryString("NoteId").ToString()
        fileName = noteId & ".txt"

        'Deserialized the note base on the id. 
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Using file = store.OpenFile(fileName, FileMode.Open)
            note = DirectCast(serializer.Deserialize(file), Note)
        End Using

        txtBox_noteTitle.Text = note.Title
        txtBox_Content.Text = note.Content

        store.Dispose()
    End Sub

    Private Sub SaveNote()
        fileName = noteId & ".txt"
        note.NoteID = New Guid(noteId)
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now

        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & ".txt")
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub

    Private Sub DeleteNote()
        Dim idString As String = noteId
        fileName = idString & ".txt"
        Using store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            If store.FileExists(fileName) Then
                store.DeleteFile(fileName)
            End If
        End Using

        isDeleteNote = True
        NavigationService.Navigate(New Uri("/MainPage.xaml", UriKind.Relative))
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As RoutedEventArgs)
        DeleteNote()
    End Sub

    Private Sub btn_Upload_SessionChanged(sender As Object, e As Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()

        If e.Status = LiveConnectSessionStatus.Connected Then
            session = e.Session
            client = New LiveConnectClient(session)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show("Connected")
                                       Return Nothing
                                   End Function)

            client = New LiveConnectClient(session)

            'Get files from isolated store
            Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            Dim fileStream As IsolatedStorageFileStream = store.OpenFile(fileName, FileMode.Open)

            'Upload files to document folder by friendly name.
            AddHandler client.UploadCompleted, AddressOf UploadCompleted

            client.UploadAsync("me/skydrive/my_documents", fileName, fileStream, OverwriteOption.Overwrite)
        End If

        If e.[Error] IsNot Nothing Then
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(e.[Error].Message)
                                       Return Nothing
                                   End Function)
        End If
    End Sub

    Private Sub UploadCompleted(sender As Object, e As Microsoft.Live.LiveOperationCompletedEventArgs)
        If e.[Error] Is Nothing Then
            Dim fileInfo As IDictionary(Of String, Object) = e.Result
            Dim fileId As String = fileInfo("id").ToString()
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(fileId)
                                       Return Nothing
                                   End Function)
        Else
            Dim errorMessage As String = "Error calling API: " & Convert.ToString(e.[Error].Message)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(errorMessage)
                                       Return Nothing
                                   End Function)
        End If
    End Sub

End Class
