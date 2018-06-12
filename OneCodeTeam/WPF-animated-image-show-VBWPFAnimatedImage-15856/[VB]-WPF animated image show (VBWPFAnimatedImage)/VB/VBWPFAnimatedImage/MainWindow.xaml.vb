'****************************** Module Header ******************************'
' Module Name:  MainWindow.xaml.vb
' Project:      VBWPFAnimatedImage
' Copyright (c) Microsoft Corporation.
' 
' The sample demonstrates how to display a series of photos just like a 
' digital picture frame with a "Wipe" effect. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************'

Imports System.Windows.Media.Animation

''' <summary> 
''' Interaction logic for MainWindow.xaml 
''' </summary> 
Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
    End Sub

    Private nextImageIndex As Integer
    Private images As New List(Of BitmapImage)()

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Initialize the images collection 
        images.Add(New BitmapImage(New Uri("Images/image1.jpg", UriKind.Relative)))
        images.Add(New BitmapImage(New Uri("Images/image2.jpg", UriKind.Relative)))
        images.Add(New BitmapImage(New Uri("Images/image3.jpg", UriKind.Relative)))
        images.Add(New BitmapImage(New Uri("Images/image4.jpg", UriKind.Relative)))

        nextImageIndex = 2
    End Sub

    Private Sub VisbleToInvisible_Completed(ByVal sender As Object, ByVal e As EventArgs)
        ' Change the source of the myImage1 to the next image to be shown 
        ' and increase the nextImageIndex 
        Me.myImage1.Source = images(nextImageIndex)
        nextImageIndex += 1

        ' If the nextImageIndex exceeds the top bound of the collection, 
        ' get it to 0 so as to show the first image next time 
        If nextImageIndex = images.Count Then
            nextImageIndex = 0
        End If

        ' Get the InvisibleToVisible storyboard and start it 
        Dim sb As Storyboard = TryCast(Me.FindResource("InvisibleToVisible"), Storyboard)

        sb.Begin(Me)
    End Sub

    Private Sub InvisibleToVisible_Completed(ByVal sender As Object, ByVal e As EventArgs)
        ' Change the source of the myImage2 to the next image to be shown 
        ' and increase the nextImageIndex 
        Me.myImage2.Source = images(nextImageIndex)
        nextImageIndex += 1

        ' If the nextImageIndex exceeds the top bound of the collection, 
        ' get it to 0 so as to show the first image next time 
        If nextImageIndex = images.Count Then
            nextImageIndex = 0
        End If

        ' Get the VisibleToInvisible storyboard and start it 
        Dim sb As Storyboard = TryCast(Me.FindResource("VisibleToInvisible"), Storyboard)
        sb.Begin(Me)
    End Sub

End Class