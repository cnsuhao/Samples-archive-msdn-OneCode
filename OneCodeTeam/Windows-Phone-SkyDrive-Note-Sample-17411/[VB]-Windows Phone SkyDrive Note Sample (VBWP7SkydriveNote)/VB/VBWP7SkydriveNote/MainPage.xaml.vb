'***************************** Module Header ******************************\
'* Module Name:  MainPage.xaml.vb
'* Project:		VBWP7SkydriveNote
'* Copyright (c) Microsoft Corporation.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports Microsoft.Phone.Controls

Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO


Partial Public Class MainPage
    Inherits PhoneApplicationPage

    Public Shared Function CreateTestList() As List(Of Note)
        Dim list As New List(Of Note)()
        Dim note As New Note()

        'Get files from isolated store.
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Dim filesName = store.GetFileNames()
        If filesName.Length > 0 Then
            For Each fileName As String In filesName
                If fileName = "__ApplicationSettings" Then
                    Continue For
                End If
                Using file = store.OpenFile(fileName, FileMode.Open)
                    note = DirectCast(serializer.Deserialize(file), Note)
                    list.Add(note)
                End Using
            Next
        End If

        store.Dispose()
        Return list
    End Function

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        listBox_NoteList.ItemsSource = CreateTestList()
    End Sub

    Private Sub listBox_NoteList_Hold(sender As Object, e As GestureEventArgs)
        'Get item data.
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        'Get element data.
        Dim listBox As ListBox = TryCast(sender, ListBox)
        Dim selectedItem = listBox.SelectedItem

        MessageBox.Show(item.Title)
    End Sub

    Private Sub listBox_NoteList_Tap(sender As Object, e As GestureEventArgs)
        'Get item data
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        If item Is Nothing Then
            Return
        End If

        Dim urlWithData As String = String.Format("/MyNote.xaml?NoteId={0}", item.NoteID)
        NavigationService.Navigate(New Uri(urlWithData, UriKind.Relative))
    End Sub

    Private Sub btn_NewNote_Click(sender As Object, e As RoutedEventArgs)
        'Navigate to MyNote.xaml page
        NavigationService.Navigate(New Uri("/MyNote.xaml", UriKind.Relative))
    End Sub

End Class

Public Class Note
    Public Property NoteID() As Guid
        Get
            Return m_NoteID
        End Get
        Set(value As Guid)
            m_NoteID = Value
        End Set
    End Property
    Private m_NoteID As Guid
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property CreatedDate() As DateTime
        Get
            Return m_CreatedDate
        End Get
        Set(value As DateTime)
            m_CreatedDate = Value
        End Set
    End Property
    Private m_CreatedDate As DateTime
    Public Property Content() As String
        Get
            Return m_Content
        End Get
        Set(value As String)
            m_Content = Value
        End Set
    End Property
    Private m_Content As String
    Public Property LastEditTime() As DateTime
        Get
            Return m_LastEditTime
        End Get
        Set(value As DateTime)
            m_LastEditTime = Value
        End Set
    End Property
    Private m_LastEditTime As DateTime
End Class

