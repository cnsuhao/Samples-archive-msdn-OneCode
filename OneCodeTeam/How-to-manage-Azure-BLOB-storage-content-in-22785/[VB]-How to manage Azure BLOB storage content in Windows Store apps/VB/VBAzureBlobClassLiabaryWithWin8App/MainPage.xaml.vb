'**************************** Module Header ******************************\
' Module Name:	MainPage.xaml.vb
' Project:		VBAzureBlobClassLiabaryWithWin8App
' Copyright (c) Microsoft Corporation.
' 
' Windows Azure storage class library now supports windows store app.
' This sample will show you how to operate Azure blob storage in your store app, 
' including upload/download/delete file from blob storage.
'
' MainPage.xaml.vb
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports Windows.UI.Xaml.Navigation
Imports Microsoft.WindowsAzure.Storage.Blob
Imports Windows.Storage.Pickers
Imports Windows.Storage

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Page
    Private temporaryFolder As Windows.Storage.StorageFolder = ApplicationData.Current.TemporaryFolder

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
        Await refreshListview()
    End Sub

    ''' <summary>
    ''' Refresh the Listview.
    ''' </summary>
    Private Async Function refreshListview() As Task
        Await App.container.CreateIfNotExistsAsync()
        Dim token As BlobContinuationToken = Nothing
        Try
            Dim blobSSegmented = Await App.container.ListBlobsSegmentedAsync(token)
            lvwBlobs.ItemsSource = blobSSegmented.Results
        Catch ex As Exception
            lbState.Text += (ex.Message + vbLf)
        End Try
    End Function

    ''' <summary>
    ''' Select a image file, and save it to Azure blob.
    ''' </summary>
    Private Async Function btnSave_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim openPicker As New FileOpenPicker()
        openPicker.ViewMode = PickerViewMode.Thumbnail
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".png")
        openPicker.FileTypeFilter.Add(".jpeg")

        Dim file As StorageFile = Await openPicker.PickSingleFileAsync()
        If file IsNot Nothing Then
            Using fileStream = Await file.OpenSequentialReadAsync()
                Try
                    Await App.container.CreateIfNotExistsAsync()
                    Dim blob = App.container.GetBlockBlobReference(file.Name)
                    Await blob.DeleteIfExistsAsync()
                    Await blob.UploadFromStreamAsync(fileStream)
                    lbState.Text += (DateTime.Now.ToString() & ": Save picture '") + file.Name & "' successfully!" & vbLf
                    Await refreshListview()
                Catch ex As Exception
                    lbState.Text += (ex.Message + vbLf)
                End Try
            End Using
        End If
    End Function

    ''' <summary>
    ''' Delete the Item in blob.
    ''' </summary>
    Private Async Function btnDelete_Click(sender As Object, e As RoutedEventArgs) As Task
        If lvwBlobs.SelectedIndex <> -1 Then
            Dim item = TryCast(lvwBlobs.SelectedItem, CloudBlockBlob)
            Try
                Dim blob = App.container.GetBlockBlobReference(item.Name)
                Await blob.DeleteIfExistsAsync()
                imgBlobItem.Source = Nothing
            Catch ex As Exception
                lbState.Text += (ex.Message + vbLf)
            End Try

            Await refreshListview()
            lbState.Text += Convert.ToString(DateTime.Now.ToString() + item.Name) & " has been removed from blob" & vbLf
        End If
    End Function


    ''' <summary>
    ''' Download file from blob, save it to tempfolder and show it in screen.
    ''' </summary>
    Private Async Function lvwBlobs_ItemClick(sender As Object, e As ItemClickEventArgs) As Task
        Dim item = TryCast(e.ClickedItem, CloudBlockBlob)
        Dim blob = App.container.GetBlockBlobReference(item.Name)
        Dim file As StorageFile
        Try
            file = Await temporaryFolder.CreateFileAsync(item.Name, CreationCollisionOption.ReplaceExisting)

            Using fileStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
                Await blob.DownloadToStreamAsync(fileStream)
            End Using

            ' Make sure it's an image file.
            imgBlobItem.Source = New BitmapImage(New Uri(file.Path))
        Catch ex As Exception
            lbState.Text += (ex.Message + vbLf)
        End Try
    End Function
End Class
