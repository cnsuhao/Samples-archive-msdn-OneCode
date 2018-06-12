'***************************** Module Header ******************************\
' Module Name:  MainPage.vb
' Project:      VBWindowsStoreAppSaveCollection
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to save a collection of objects to local storage.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Windows.Storage
Imports System.Text.RegularExpressions
Imports Windows.UI

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    'The collection will be saved
    Dim itemCollection As New ObservableCollection(Of Person)()
    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Async Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))
        Dim localFile As StorageFile
        Try
            localFile = Await ApplicationData.Current.LocalFolder.GetFileAsync("localData.xml")
        Catch ex As FileNotFoundException
            localFile = Nothing
            NotifyUser(ex.Message)
        End Try
        If localFile IsNot Nothing Then
            Dim localData As String = Await FileIO.ReadTextAsync(localFile)

            itemCollection = ObjectSerializer(Of ObservableCollection(Of Person)).FromXml(localData)
        End If
        gvData.ItemsSource = itemCollection
    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="Common.SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Async Sub SaveState(pageState As Dictionary(Of String, Object))
        Try
            Dim localData As String = ObjectSerializer(Of ObservableCollection(Of Person)).ToXml(itemCollection)

            If Not String.IsNullOrEmpty(localData) Then
                Dim localFile As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync("localData.xml", CreationCollisionOption.ReplaceExisting)
                Await FileIO.WriteTextAsync(localFile, localData)
            End If
        Catch ex As Exception
            NotifyUser(ex.Message)
        End Try

    End Sub

#Region "Common methods"

    Private Async Function Footer_Click(sender As Object, e As RoutedEventArgs) As Task
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Function


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs)
        If DataValidation() Then
            tbHint.Visibility = Visibility.Collapsed
            Dim person As New Person()
            person.Name = txtName.Text
            person.Age = Convert.ToInt32(txtAge.Text)
            itemCollection.Add(person)
            svContent.ScrollToVerticalOffset(svContent.ExtentHeight)
        End If
    End Sub

    ''' <summary>
    ''' Check if the information is valid
    ''' </summary>
    ''' <returns></returns>
    Private Function DataValidation() As Boolean
        Dim bValid As Boolean = True
        Dim name As String = txtName.Text
        Dim age As String = txtAge.Text
        Dim reg As New Regex("^[0-9]*$")

        If String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(age) Then
            bValid = False
            tbHint.Text = "Name/Age can be empty."
            tbHint.Visibility = Visibility.Visible
        ElseIf Not reg.IsMatch(age) OrElse Convert.ToInt32(age) > 120 Then
            bValid = False
            tbHint.Text = "Age should be a number between 0 to 120"
            tbHint.Visibility = Visibility.Visible
        End If

        Return bValid
    End Function

    Private Sub btnGo_Click(sender As Object, e As RoutedEventArgs)
        Frame.Navigate(GetType(SecondPage))
    End Sub

End Class
