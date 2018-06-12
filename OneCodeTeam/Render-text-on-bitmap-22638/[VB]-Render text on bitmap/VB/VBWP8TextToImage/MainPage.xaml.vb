'****************************** Module Header ******************************\
' Module Name:    MainPage.aspx.vb
' Project:        VBWP8TextToImage
' Copyright (c) Microsoft Corporation
'
' This demo shows how to draw text to Image then display it or save it to hub.
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
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Windows.Resources
Imports System.IO.IsolatedStorage
Imports Microsoft.Xna.Framework.Media

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape
    End Sub

    ''' <summary>
    '''  Draw text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnDraw_Click(sender As Object, e As RoutedEventArgs)
        Using mem As New MemoryStream()
            Dim img As New BitmapImage()
            Dim r As StreamResourceInfo = System.Windows.Application.GetResourceStream(New Uri("test.jpg", UriKind.Relative))
            img.SetSource(r.Stream)

            Dim wb As New WriteableBitmap(img)
            Dim tb As New TextBlock()
            tb.FontSize = 40
            tb.Text = tbInput.Text + vbCr & vbLf & "This is test text"

            ' TranslateTransform
            Dim tf As New TranslateTransform()
            tf.X = 100
            tf.Y = 100
            wb.Render(tb, tf)
            wb.Invalidate()

            wb.SaveJpeg(mem, wb.PixelWidth, wb.PixelHeight, 0, 100)
            mem.Seek(0, System.IO.SeekOrigin.Begin)

            ' Show image.
            Dim bn As New BitmapImage()
            bn.SetSource(mem)
            img2.Source = bn

            ' Save image.
            Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                Dim strImageName As [String] = "demo.jpg"   ' File name.

                If iso.FileExists(strImageName) Then
                    iso.DeleteFile(strImageName)
                End If

                Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
                    ' Encode WriteableBitmap object to a JPEG stream.
                    Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85)
                    isostream.Close()
                End Using

                Using fileStream As IsolatedStorageFileStream = iso.OpenFile(strImageName, FileMode.Open, FileAccess.Read)
                    Dim mediaLibrary As New MediaLibrary()
                    Dim pic As Picture = mediaLibrary.SavePicture(strImageName, fileStream)
                    fileStream.Close()
                End Using
            End Using
        End Using
    End Sub

End Class