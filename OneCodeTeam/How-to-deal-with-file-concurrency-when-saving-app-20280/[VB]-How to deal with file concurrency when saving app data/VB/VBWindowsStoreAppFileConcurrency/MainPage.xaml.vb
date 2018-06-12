'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppFileConcurrency
' Copyright (c) Microsoft Corporation.
'  
' This sample demonstrates how to deal with file access concurrency when save app data
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Threading
Imports Windows.Storage

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Dim filename As String = "test.txt"

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))

    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="Common.SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of String, Object))

    End Sub

#Region "Common methods"

    Private Async Function Footer_Click(sender As Object, e As RoutedEventArgs) As Task
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Function


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

    ''' <summary>
    ''' When writting data to the file, the 'Save' button is not enabled, this is to prevent reentrancy.
    ''' Before saving data, we have 3 sceconds delay, this is easy to see the currency control, only one
    ''' thread can access the file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Function saveButton_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim semaphore As SemaphoreSlim = getSemaphore(filename)
        Await semaphore.WaitAsync()
        Try
            Dim storageFolder = KnownFolders.DocumentsLibrary
            Dim file As StorageFile = Await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting)
            Dim content As String = dataTextBox.Text
            If Not String.IsNullOrEmpty(content) Then
                saveButton.IsEnabled = False
                Await Task.Delay(TimeSpan.FromSeconds(3))
                Await FileIO.WriteTextAsync(file, content)
            End If
            saveButton.IsEnabled = True
        Catch ex As Exception
            NotifyUser(ex.ToString())
        Finally
            semaphore.Release()
        End Try
    End Function

    Private Async Function loadButton_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim semaphore As SemaphoreSlim = getSemaphore(filename)
        Await semaphore.WaitAsync()
        Try
            Dim storageFolder = KnownFolders.DocumentsLibrary
            Dim file As StorageFile = Await storageFolder.GetFileAsync(filename)
            Dim content As String = Await FileIO.ReadTextAsync(file)
            If Not String.IsNullOrEmpty(content) Then
                dataTextBlock.Text = content
            End If
        Catch ex As Exception
            NotifyUser(ex.ToString())
        Finally
            semaphore.Release()
        End Try
    End Function

    ' A Dictionary to store SemaphoreSlim instances
    Private Shared ReadOnly semaphores As New Dictionary(Of String, SemaphoreSlim)()

    ''' <summary>
    ''' Get a SemaphoreSlim instance. If the instance is already exist, return the exist one, otherwise, create a new
    ''' instance and return it.
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    Private Shared Function getSemaphore(filename As String) As SemaphoreSlim
        If semaphores.ContainsKey(filename) Then
            Return semaphores(filename)
        End If

        Dim semaphore = New SemaphoreSlim(1)
        semaphores(filename) = semaphore
        Return semaphore
    End Function

    Private Sub dataTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        dataInputScrollViewer.ScrollToVerticalOffset(dataInputScrollViewer.ExtentHeight)
    End Sub


End Class
