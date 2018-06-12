'***************************** Module Header ******************************\
' Module Name:  MainPage.vb
' Project:      VBWindowsStoreAppShareWriteableBitmap
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to share WriteableBitmap image in Windows Store app.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Windows.ApplicationModel.DataTransfer
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Navigation
Imports Windows.Graphics.Imaging
Imports System.Runtime.InteropServices.WindowsRuntime

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Dim dataTransferManager As DataTransferManager
    Dim image As WriteableBitmap
    Dim file As StorageFile

#Region "Common methods"

    Private Async Sub Footer_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Sub


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

#Region "Load image file to image control"
    ' Use FileOpenPicker to pick an image and display it in UI
    Private Async Sub LoadButton_Click(sender As Object, e As RoutedEventArgs)
        If Me.EnsureUnsnapped() Then
            Dim openPicker As New FileOpenPicker()
            openPicker.ViewMode = PickerViewMode.Thumbnail
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
            openPicker.FileTypeFilter.Add(".jpg")
            openPicker.FileTypeFilter.Add(".jpeg")
            openPicker.FileTypeFilter.Add(".png")

            file = Await openPicker.PickSingleFileAsync()
            Using stream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
                image = New WriteableBitmap(1, 1)
                image.SetSource(stream)
                WriteableBitmapImage.Source = image
            End Using
            ShareButton.IsEnabled = True
        End If
    End Sub

    Friend Function EnsureUnsnapped() As Boolean
        ' FilePicker APIs will not work if the application is in a snapped state.
        ' If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
        Dim unsnapped As Boolean = ((ApplicationView.Value <> ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
        If Not unsnapped Then
            NotifyUser("Cannot unsnap the sample.")
        End If

        Return unsnapped
    End Function
#End Region

#Region "Register share contract and unregister share contract"
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        Me.dataTransferManager = dataTransferManager.GetForCurrentView()
        AddHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        RemoveHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
    End Sub
#End Region

    Private Async Sub OnDataRequested(sender As DataTransferManager, e As DataRequestedEventArgs)
        Dim deferral As DataRequestDeferral = e.Request.GetDeferral()

        Dim requestData As DataPackage = e.Request.Data
        requestData.Properties.Title = "Share WriteableBitmap Image Sample"
        requestData.Properties.Description = "This sample demonstrates how to share WriteableBitmap image in Windows Store app."

        ' This stream is to create a bitmap image later
        Dim stream As IRandomAccessStream = New InMemoryRandomAccessStream()

        ' Determin which type of BitmapEncoder we should create
        Dim encoderId As Guid
        If file IsNot Nothing Then
            Select Case file.FileType
                Case ".png"
                    encoderId = BitmapEncoder.PngEncoderId
                    Exit Select
                Case ".bmp"
                    encoderId = BitmapEncoder.BmpEncoderId
                    Exit Select
                Case Else
                    encoderId = BitmapEncoder.JpegEncoderId
                    Exit Select
            End Select

            Dim encoder As BitmapEncoder = Await BitmapEncoder.CreateAsync(encoderId, stream)
            Dim pixelStream As Stream = image.PixelBuffer.AsStream()
            Dim pixels As Byte() = New Byte(pixelStream.Length - 1) {}
            Await pixelStream.ReadAsync(pixels, 0, pixels.Length)
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, CUInt(image.PixelWidth), CUInt(image.PixelHeight), 96.0, 96.0, _
                pixels)

            requestData.SetBitmap(RandomAccessStreamReference.CreateFromStream(stream))
            Await encoder.FlushAsync()
        End If

        deferral.Complete()
    End Sub

    Private Sub ShareButton_Click(sender As Object, e As RoutedEventArgs)
        dataTransferManager.ShowShareUI()
    End Sub

End Class
