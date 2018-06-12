'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8ImageFromIsolatedStorage
' Copyright (c) Microsoft Corporation
'
' This sample willl demo how to load an Image from Isolated Storage and display
' it on the Device
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Resources
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Net
Imports Microsoft.Phone.Controls
Imports System.Diagnostics

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' ImageName
    Dim strImageName As String = "defaultName.png"
    ' ImagePath
    Dim strPath As String = String.Empty

    ' Constructor
    Public Sub New()
        InitializeComponent()
        ' Loading local or network picture.
        CreateImage()

        ' Sample code to localize the ApplicationBar
        LoadImageFromIsolatedStorage()
    End Sub

    ''' <summary>
    ''' Loading local or network picture. According to whether it contains the http protocol
    ''' to determine whether the image from the web server.
    ''' </summary>
    Private Sub CreateImage()
        ' Local Image
        strPath = "WP8Logo.png"
        ' Network Image
        ' strPath = "http://i.s-microsoft.com/global/ImageStore/PublishingImages/logos/hp/logo-lg-1x.png"

        If strPath.Contains("http://") Then
            strImageName = strPath.Substring(strPath.LastIndexOf("/") + 1)
            SaveImageToIsolatedStorage(1)
        Else
            strImageName = strPath
            SaveImageToIsolatedStorage(0)
        End If
    End Sub

    ''' <summary>
    ''' Save image to IsolatedStorage.
    ''' </summary>
    ''' <param name="flag">1:web server;0:Local</param>
    Private Sub SaveImageToIsolatedStorage(flag As Integer)
        If flag = 1 Then
            ' Use WebClient to download web server's images.
            Dim webClientImg As New WebClient()
            AddHandler webClientImg.OpenReadCompleted, New OpenReadCompletedEventHandler(AddressOf client_OpenReadCompleted)
            webClientImg.OpenReadAsync(New Uri(strPath, UriKind.Absolute))
        Else
            ' Use Uri to get local images.
            Dim sri As StreamResourceInfo = Nothing
            Dim uri As New Uri(strPath, UriKind.Relative)
            sri = Application.GetResourceStream(uri)

            ' Save the local image's stream into a jpeg picture.
            SaveToJpeg(sri.Stream)
        End If
    End Sub

    ''' <summary>
    ''' Save stream to jpeg when the asynchronous resource-read operation is completed.
    ''' </summary>
    ''' <param name="sender">WebClient</param>
    ''' <param name="e">OpenReadCompleted Event</param>
    Private Sub client_OpenReadCompleted(sender As Object, e As OpenReadCompletedEventArgs)
        ' Save the returned image stream into a jpeg picture.
        SaveToJpeg(e.Result)
    End Sub

    ''' <summary>
    ''' Save stream to Jpeg.First, determine and delete the file with the same name
    ''' in IsolatedStorage, and then create a new one.
    ''' </summary>
    ''' <param name="stream">The stream of local image or network image</param>
    Private Sub SaveToJpeg(stream As Stream)
        Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            If iso.FileExists(strImageName) Then
                iso.DeleteFile(strImageName)
            End If

            Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
                Dim bitmap As New BitmapImage()
                bitmap.SetSource(stream)
                Dim wb As New WriteableBitmap(bitmap)

                ' Encode WriteableBitmap object to a JPEG stream.
                Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85)
                isostream.Close()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Sample code for loading image from IsolatedStorage
    ''' </summary> 
    Private Sub LoadImageFromIsolatedStorage()
        ' The image will be read from isolated storage into the following byte array
        Dim data As Byte()

        ' Read the entire image in one go into a byte array
        Try
            Using isf As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                ' Open the file - error handling omitted for brevity
                ' Note: If the image does not exist in isolated storage the following exception will be generated:
                ' System.IO.IsolatedStorage.IsolatedStorageException was unhandled 
                ' Message=Operation not permitted on IsolatedStorageFileStream 
                Using isfs As IsolatedStorageFileStream = isf.OpenFile(strImageName, FileMode.Open, FileAccess.Read)
                    ' Allocate an array large enough for the entire file
                    data = New Byte(isfs.Length - 1) {}

                    ' Read the entire file and then close it
                    isfs.Read(data, 0, data.Length)
                    isfs.Close()
                End Using
            End Using

            ' Create memory stream and bitmap
            Dim ms As New MemoryStream(data)
            Dim bi As New BitmapImage()

            ' Set bitmap source to memory stream
            bi.SetSource(ms)

            ' Create an image UI element – Note: this could be declared in the XAML instead
            Dim image As New Image()

            ' Set size of image to bitmap size for this demonstration
            image.Height = bi.PixelHeight
            image.Width = bi.PixelWidth

            ' Assign the bitmap image to the image’s source
            image.Source = bi

            ' Add the image to the grid in order to display the bit map
            ContentPanel.Children.Add(image)
        Catch e As Exception
            ' handle the exception
            Debug.WriteLine(e.Message)
        End Try
    End Sub
End Class