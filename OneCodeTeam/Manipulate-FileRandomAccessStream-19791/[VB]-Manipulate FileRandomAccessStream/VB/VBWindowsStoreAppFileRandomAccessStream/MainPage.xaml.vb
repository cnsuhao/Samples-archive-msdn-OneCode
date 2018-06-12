'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppFileRandomAccessStream
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to manipulate file with FileRandomAccessStream.
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
Imports Windows.Security.Cryptography
Imports Windows.Storage.Streams
Imports System.Text.RegularExpressions
Imports Windows.UI


' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Dim sampleData As String = "The Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' needs. Our goal is to provide typical code samples for all Microsoft development technologies, and reduce developers' efforts in solving typical programming tasks. Our team listens to developers' pains in MSDN forums, social media and various developer communities. We write code samples based on developers' frequently asked programming tasks, and allow developers to download them with a short code sample publishing cycle. Additionally, our team offers a free code sample request service. This service is a proactive way for our developer community to obtain code samples for certain programming tasks directly from Microsoft."

    Dim streamSize As ULong

    Dim folder As StorageFolder = KnownFolders.DocumentsLibrary

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


#Region "Create a file in Documents folder"
    ''' <summary>
    ''' Create a file in Documents folder
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub btnCreate_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim file As StorageFile = Await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting)
            Dim buffer = CryptographicBuffer.ConvertStringToBinary(sampleData, BinaryStringEncoding.Utf8)
            Using stream As FileRandomAccessStream = DirectCast(Await file.OpenAsync(FileAccessMode.ReadWrite), FileRandomAccessStream)
                Await stream.WriteAsync(buffer)
                streamSize = stream.Size
            End Using
            Await LoadFileContent()
            svContent.Visibility = Visibility.Visible
            btnSave.Visibility = Visibility.Visible
            btnAppend.IsEnabled = True
            txtInsertData.IsEnabled = True
            txtPosition.IsEnabled = True
            tbHint.Text = "(0-" & streamSize & ")"
            tbOutput.Text = "Creating 'sample.txt' file in Documents folder successully! "
        Catch ex As Exception
            NotifyUser(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Save the file"
    ''' <summary>
    ''' Save the file 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(tbContent.Text) Then
            Try
                Dim file As StorageFile = Await folder.GetFileAsync("sample.txt")
                Dim buffer = CryptographicBuffer.ConvertStringToBinary(tbContent.Text, BinaryStringEncoding.Utf8)
                Using stream As FileRandomAccessStream = DirectCast(Await file.OpenAsync(FileAccessMode.ReadWrite), FileRandomAccessStream)
                    Await stream.WriteAsync(buffer)
                    streamSize = stream.Size
                End Using
                tbOutput.Text = "Saving file successully!"
                tbHint.Foreground = New Windows.UI.Xaml.Media.SolidColorBrush(Colors.Black)
                tbHint.Text = "(0-" & streamSize & ")"
            Catch ex As Exception
                NotifyUser(ex.ToString())
            End Try
        Else
            NotifyUser("The content is empty!")
        End If

    End Sub
#End Region

#Region "Insert data to specific position of the file"
    ''' <summary>
    ''' Insert data to specific position of the file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub btnInsert_Click(sender As Object, e As RoutedEventArgs)
        If DataValidation() Then
            tbHint.Foreground = New Windows.UI.Xaml.Media.SolidColorBrush(Colors.Black)
            Dim position As ULong = Convert.ToUInt64(txtPosition.Text)
            Dim insertData As String = txtInsertData.Text

            Try
                Dim file As StorageFile = Await folder.GetFileAsync("sample.txt")
                Using stream As FileRandomAccessStream = DirectCast(Await file.OpenAsync(FileAccessMode.ReadWrite), FileRandomAccessStream)
                    Dim remainData As String = tbContent.Text.Substring(CInt(position))
                    Dim buffer = CryptographicBuffer.ConvertStringToBinary(insertData & remainData, BinaryStringEncoding.Utf8)
                    stream.Seek(position)
                    Await stream.WriteAsync(buffer)
                    streamSize = stream.Size
                End Using

                Await LoadFileContent()
                svContent.ScrollToVerticalOffset(svContent.ExtentHeight)
                svContent.Visibility = Visibility.Visible
                btnSave.Visibility = Visibility.Visible
                tbOutput.Text = "Inserting content successully!"

                tbHint.Text = "(0-" & streamSize & ")"
            Catch ex As Exception
                NotifyUser(ex.ToString())
            End Try
        Else
            tbOutput.Text = "Failed to insert data."
        End If
    End Sub

#End Region

#Region "Load content from the file"
    ''' <summary>
    ''' Load content from the file
    ''' </summary>
    ''' <returns></returns>
    Private Async Function LoadFileContent() As Task
        Try
            Dim file As StorageFile = Await folder.GetFileAsync("sample.txt")
            Using stream As FileRandomAccessStream = DirectCast(Await file.OpenAsync(FileAccessMode.ReadWrite), FileRandomAccessStream)

                Dim inputStream = stream.GetInputStreamAt(0)
                Using reader As New DataReader(inputStream)
                    Dim size As UInteger = Await reader.LoadAsync(CUInt(stream.Size))
                    tbContent.Text = reader.ReadString(size)
                End Using
            End Using
        Catch ex As Exception
            NotifyUser(ex.ToString())
        End Try
    End Function
#End Region

#Region "Common methods"

    Private Async Sub Footer_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Sub


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

    Private Function DataValidation() As Boolean
        Dim bValid As Boolean = True
        Dim data As String = txtInsertData.Text
        Dim position As String = txtPosition.Text
        Dim reg As New Regex("^[0-9]*$")

        If String.IsNullOrEmpty(data) OrElse String.IsNullOrEmpty(position) Then
            bValid = False
            tbHint.Text = "complete input."
            tbHint.Foreground = New SolidColorBrush(Colors.Red)
            tbHint.Visibility = Visibility.Visible
        ElseIf Not reg.IsMatch(position) OrElse Convert.ToUInt64(position) > streamSize Then
            bValid = False
            tbHint.Text = "Valid range:(0-" & streamSize & ")"
            tbHint.Foreground = New SolidColorBrush(Colors.Red)
            tbHint.Visibility = Visibility.Visible
        End If

        Return bValid
    End Function


End Class
