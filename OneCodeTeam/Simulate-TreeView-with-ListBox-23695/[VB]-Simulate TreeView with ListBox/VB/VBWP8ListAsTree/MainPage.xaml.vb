'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:		VBWP8ListAsTree
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how use ListBox Control as a tree in Windows Phone. 
' All pictures in media library will show in ListBox Control with indention by recursion.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Microsoft.Xna.Framework.Media
Imports System.IO
Imports System.Windows.Media.Imaging

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        Using library = New MediaLibrary()
            ShowAlbum(library.RootPictureAlbum, "|")
        End Using
    End Sub

    ' Show album pictures as a tree
    Private Sub ShowAlbum(theAlbum As PictureAlbum, indention As String)
        ' Show Album Name
        treeList.Items.Add(String.Concat(indention, "Album: ", theAlbum.Name))

        ' List Albums in this Album
        For Each subAlbum As PictureAlbum In theAlbum.Albums
            ShowAlbum(subAlbum, String.Concat(indention, "-"))
        Next

        ' List Pictures
        For Each thePicture As Picture In theAlbum.Pictures
            ' Get the Picture Stream
            Dim imageStream As Stream = thePicture.GetThumbnail()

            ' Wrap it with a BitmapImage object
            Dim bitmap = New BitmapImage()
            bitmap.SetSource(imageStream)

            ' Create an Image element and set the bitmap
            Dim image = New Image()
            image.Width = 60
            image.Height = 60
            image.Source = bitmap

            Dim outPanel As New StackPanel()
            Dim stackPanel As New StackPanel()
            stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim textBlock As New TextBlock()
            textBlock.Text = thePicture.Name

            stackPanel.Children.Add(image)
            stackPanel.Children.Add(textBlock)

            outPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim indentionBlock As New TextBlock()
            indentionBlock.Text = String.Concat(indention, "-")
            outPanel.Children.Add(indentionBlock)
            outPanel.Children.Add(stackPanel)

            treeList.Items.Add(outPanel)
        Next
    End Sub
End Class