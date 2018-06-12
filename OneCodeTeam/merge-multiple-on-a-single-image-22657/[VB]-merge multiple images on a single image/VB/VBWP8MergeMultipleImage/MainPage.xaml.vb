'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8MergeMultipleImage
' Copyright (c) Microsoft Corporation
'
' This sample will demo how to merge multiple images into a single image.
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
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.IO.IsolatedStorage
Imports System.Windows.Media.Imaging
Imports Microsoft.Xna.Framework.Media
Imports System.Windows.Resources
Imports System.IO

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnMerge_Click(sender As Object, e As RoutedEventArgs)
        ' Image list.
        Dim files As String() = New String() {"2.jpg", "test.jpg", "3.jpg", "4.jpg", "5.jpg", "test.jpg"}

        ' BitmapImage list.
        Dim images As New List(Of BitmapImage)()

        ' Final width.
        Dim width As Integer = 0

        ' Final height.
        Dim height As Integer = 0

        For Each image As String In files
            ' Create a Bitmap from the file and add it to the list                
            Dim img As New BitmapImage()
            Dim r As StreamResourceInfo = System.Windows.Application.GetResourceStream(New Uri(image, UriKind.Relative))
            img.SetSource(r.Stream)

            Dim wb As New WriteableBitmap(img)
            ' Update the size of the final bitmap
            width = If(wb.PixelWidth > width, wb.PixelWidth, width)
            height = If(wb.PixelHeight > height, wb.PixelHeight, height)

            images.Add(img)
        Next

        ' Create a bitmap to hold the combined image 
        Dim finalImage As New BitmapImage()
        Dim sri As StreamResourceInfo = System.Windows.Application.GetResourceStream(New Uri("White.jpg", UriKind.Relative))
        finalImage.SetSource(sri.Stream)
        Dim wbFinal As New WriteableBitmap(finalImage)

        Using mem As New MemoryStream()
            ' Parameter for Translate.X
            Dim tempWidth As Integer = 0

            ' Parameter for Translate.Y
            Dim tempHeight As Integer = 0

            For Each item As BitmapImage In images
                Dim image As New Image()
                image.Height = item.PixelHeight
                image.Width = item.PixelWidth
                image.Source = item

                ' TranslateTransform                      
                Dim tf As New TranslateTransform()
                tf.X = tempWidth
                tf.Y = tempHeight
                wbFinal.Render(image, tf)

                tempHeight += item.PixelHeight
            Next

            wbFinal.Invalidate()
            wbFinal.SaveJpeg(mem, width, height, 0, 100)
            mem.Seek(0, System.IO.SeekOrigin.Begin)

            ' Show image.               
            img2.Source = wbFinal
        End Using

        ' Save image.
        Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            Dim strImageName As [String] = "demo.jpg"
            ' File name.
            If iso.FileExists(strImageName) Then
                iso.DeleteFile(strImageName)
            End If

            Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
                ' Encode WriteableBitmap object to a JPEG stream.
                Extensions.SaveJpeg(wbFinal, isostream, wbFinal.PixelWidth, wbFinal.PixelHeight, 0, 85)
            End Using

            Using fileStream As IsolatedStorageFileStream = iso.OpenFile(strImageName, FileMode.OpenOrCreate, FileAccess.Read)
                Dim mediaLibrary As New MediaLibrary()
                Dim pic As Picture = mediaLibrary.SavePicture(strImageName, fileStream)
            End Using
        End Using
    End Sub

End Class