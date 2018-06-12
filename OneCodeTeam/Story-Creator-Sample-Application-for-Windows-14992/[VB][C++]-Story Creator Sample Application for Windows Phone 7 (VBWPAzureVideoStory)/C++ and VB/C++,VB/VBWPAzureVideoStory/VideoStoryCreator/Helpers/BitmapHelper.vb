'********************************* Module Header *********************************\
' Module Name: BitmapHelper.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A helper class that resized the images.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/




Imports System.IO
Imports Microsoft.Xna.Framework.Media
Imports System.Windows.Media.Imaging

Public NotInheritable Class BitmapHelper
    ' Currently we hard code the target resolution.
    ' Consider to support user configuration in the future.
    ' TODO: Move all hard coded value to a central place.
    Friend Shared ResizedImageWidth As Integer = 800
    Friend Shared ResizedImageHeight As Integer = 600

    ''' <summary>
    ''' Get the original image from XNA media library.
    ''' And resize it to the target resolution.
    ''' </summary>
    ''' <param name="name">The name of the image.</param>
    ''' <returns>A stream representing the resized image, in jpeg format.</returns>
    Public Shared Function GetResizedImage(name As String) As Stream
        Dim mediaLibrary As New MediaLibrary()
        Dim pictureCollection As PictureCollection = mediaLibrary.Pictures

        Dim picture As Picture = pictureCollection.Where(Function(p) p.Name = name).FirstOrDefault()
        If picture Is Nothing Then
            Throw New InvalidOperationException(String.Format("Cannot load the picture {0}. Possibly the picture has been deleted.", name))
        End If
        Dim originalImageStream As Stream = picture.GetImage()
        Dim bmp As New BitmapImage()
        bmp.SetSource(originalImageStream)
        Dim originalImage As New WriteableBitmap(bmp)
        Dim targetStream As New MemoryStream()
        originalImage.SaveJpeg(targetStream, ResizedImageWidth, ResizedImageHeight, 0, 100)

        ' Now that the image has been turned into a WriteableBitmap, the original image stream can be closed.
        originalImageStream.Close()

        targetStream.Position = 0
        Return targetStream
    End Function
End Class
