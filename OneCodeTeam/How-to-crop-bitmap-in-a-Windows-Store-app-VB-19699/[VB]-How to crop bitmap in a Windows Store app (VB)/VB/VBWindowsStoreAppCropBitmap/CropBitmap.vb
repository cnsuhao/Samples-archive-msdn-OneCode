'************************** Module Header ******************************\
' Module Name:  CropBitmap.vb
' Project:      VBWindowsStoreAppCropBitmap
' Copyright (c) Microsoft Corporation.
' 
' This class is used to get and save cropped image.
' 
' To crop a bitmap, we can follow these steps:
' 
' 1. Read the original image to a IRandomAccessStream
' 2. Create a decoder from the stream. With the decoder, we can get the
'    properties of the image.
' 3. Use BitmapTransform to define the region to crop, and then get the pixel
'    data in the region.
'    If we also want to scale the image, we can set the ScaledWidth and 
'    ScaledHeight properties of the BitmapTransform.
' 4. To get a cropped bitmap directly, we write the pixel data to a WriteableBitmap.
'    To save the cropped bitmap to a local file, we can use BitmapEncoder.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************

Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Graphics.Imaging
Imports Windows.Storage
Imports Windows.Storage.Streams

Public Class CropBitmap


    ''' <summary>
    ''' Get a cropped bitmap from a image file.
    ''' </summary>
    ''' <param name="originalImageFile">
    ''' The original image file.
    ''' </param>
    ''' <param name="startPoint">
    ''' The start point of the region to be cropped.
    ''' </param>
    ''' <param name="corpSize">
    ''' The size of the region to be cropped.
    ''' </param>
    ''' <returns>
    ''' The cropped image.
    ''' </returns>
    Public Shared Async Function GetCroppedBitmapAsync(ByVal originalImageFile As StorageFile, ByVal startPoint As Point, ByVal corpSize As Size, ByVal scale As Double) As Task(Of ImageSource)
        If Double.IsNaN(scale) OrElse Double.IsInfinity(scale) Then
            scale = 1
        End If

        ' Convert start point and size to integer.
        Dim startPointX As UInteger = CUInt(Math.Floor(startPoint.X * scale))
        Dim startPointY As UInteger = CUInt(Math.Floor(startPoint.Y * scale))
        Dim height As UInteger = CUInt(Math.Floor(corpSize.Height * scale))
        Dim width As UInteger = CUInt(Math.Floor(corpSize.Width * scale))

        Using stream As IRandomAccessStream = Await originalImageFile.OpenReadAsync()

            ' Create a decoder from the stream. With the decoder, we can get 
            ' the properties of the image.
            Dim decoder As BitmapDecoder = Await BitmapDecoder.CreateAsync(stream)

            ' The scaledSize of original image.
            Dim scaledWidth As UInteger = CUInt(Math.Floor(decoder.PixelWidth * scale))
            Dim scaledHeight As UInteger = CUInt(Math.Floor(decoder.PixelHeight * scale))


            ' Refine the start point and the size. 
            If startPointX + width > scaledWidth Then
                startPointX = scaledWidth - width
            End If

            If startPointY + height > scaledHeight Then
                startPointY = scaledHeight - height
            End If

            ' Get the cropped pixels.
            Dim pixels() As Byte = Await GetPixelData(decoder, startPointX, startPointY, width, height, scaledWidth, scaledHeight)

            ' Stream the bytes into a WriteableBitmap
            Dim cropBmp As New WriteableBitmap(CInt(width), CInt(height))
            Dim pixStream As Stream = cropBmp.PixelBuffer.AsStream()
            pixStream.Write(pixels, 0, CInt(width * height * 4))

            Return cropBmp
        End Using

    End Function

    ''' <summary>
    ''' Save the cropped bitmap to a image file.
    ''' </summary>
    ''' <param name="originalImageFile">
    ''' The original image file.
    ''' </param>
    ''' <param name="newImageFile">
    ''' The target file.
    ''' </param>
    ''' <param name="startPoint">
    ''' The start point of the region to be cropped.
    ''' </param>
    ''' <param name="cropSize">
    ''' The size of the region to be cropped.
    ''' </param>
    ''' <returns>
    ''' Whether the operation is successful.
    ''' </returns>
    Public Shared Async Function SaveCroppedBitmapAsync(ByVal originalImageFile As StorageFile, ByVal newImageFile As StorageFile, ByVal startPoint As Point, ByVal cropSize As Size) As Task

        ' Convert start point and size to integer.
        Dim startPointX As UInteger = CUInt(Math.Floor(startPoint.X))
        Dim startPointY As UInteger = CUInt(Math.Floor(startPoint.Y))
        Dim height As UInteger = CUInt(Math.Floor(cropSize.Height))
        Dim width As UInteger = CUInt(Math.Floor(cropSize.Width))

        Using originalImgFileStream As IRandomAccessStream = Await originalImageFile.OpenReadAsync()


            ' Create a decoder from the stream. With the decoder, we can get 
            ' the properties of the image.
            Dim decoder As BitmapDecoder = Await BitmapDecoder.CreateAsync(originalImgFileStream)

            ' Refine the start point and the size. 
            If startPointX + width > decoder.PixelWidth Then
                startPointX = decoder.PixelWidth - width
            End If

            If startPointY + height > decoder.PixelHeight Then
                startPointY = decoder.PixelHeight - height
            End If

            ' Get the cropped pixels.
            Dim pixels() As Byte = Await GetPixelData(decoder, startPointX, startPointY, width, height, decoder.PixelWidth, decoder.PixelHeight)

            Using newImgFileStream As IRandomAccessStream = Await newImageFile.OpenAsync(FileAccessMode.ReadWrite)

                Dim encoderID As Guid = Guid.Empty

                Select Case newImageFile.FileType.ToLower()
                    Case ".png"
                        encoderID = BitmapEncoder.PngEncoderId
                    Case ".bmp"
                        encoderID = BitmapEncoder.BmpEncoderId
                    Case Else
                        encoderID = BitmapEncoder.JpegEncoderId
                End Select

                ' Create a bitmap encoder

                Dim bmpEncoder As BitmapEncoder = Await BitmapEncoder.CreateAsync(encoderID, newImgFileStream)

                ' Set the pixel data to the cropped image.
                bmpEncoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, width, height, decoder.DpiX, decoder.DpiY, pixels)

                ' Flush the data to file.
                Await bmpEncoder.FlushAsync()
            End Using
        End Using

    End Function

    ''' <summary>
    ''' Use BitmapTransform to define the region to crop, and then get the pixel data in the region
    ''' </summary>
    ''' <returns></returns>
    Private Shared Async Function GetPixelData(ByVal decoder As BitmapDecoder, ByVal startPointX As UInteger, ByVal startPointY As UInteger, ByVal width As UInteger, ByVal height As UInteger) As Task(Of Byte())
        Return Await GetPixelData(decoder, startPointX, startPointY, width, height, decoder.PixelWidth, decoder.PixelHeight)
    End Function

    ''' <summary>
    ''' Use BitmapTransform to define the region to crop, and then get the pixel data in the region.
    ''' If you want to get the pixel data of a scaled image, set the scaledWidth and scaledHeight
    ''' of the scaled image.
    ''' </summary>
    ''' <returns></returns>
    Private Shared Async Function GetPixelData(ByVal decoder As BitmapDecoder, ByVal startPointX As UInteger, ByVal startPointY As UInteger, ByVal width As UInteger, ByVal height As UInteger, ByVal scaledWidth As UInteger, ByVal scaledHeight As UInteger) As Task(Of Byte())

        Dim transform As New BitmapTransform()
        Dim bounds As New BitmapBounds()
        bounds.X = startPointX
        bounds.Y = startPointY
        bounds.Height = height
        bounds.Width = width
        transform.Bounds = bounds

        transform.ScaledWidth = scaledWidth
        transform.ScaledHeight = scaledHeight

        ' Get the cropped pixels within the bounds of transform.
        Dim pix As PixelDataProvider = Await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, transform, ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.ColorManageToSRgb)
        Dim pixels() As Byte = pix.DetachPixelData()
        Return pixels
    End Function

End Class