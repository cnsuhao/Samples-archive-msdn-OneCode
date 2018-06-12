'****************************** Module Header ******************************\
' Module Name:  PreviewPage.xaml.vb
' Project:  VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' This page allows the user to preview the story using DispatcherTimer and Storyboard.
' It doesn't actually encode the story to a video.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Windows.Threading
Imports System.IO
Imports System.Windows.Media.Imaging

<CLSCompliant(False)> _
Partial Public Class PreviewPage
    Inherits PhoneApplicationPage
    Private _dispatcherTimer As DispatcherTimer
    Private _currentImageIndex As Integer
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub PhoneApplicationPage_Loaded(sender As Object, e As System.Windows.RoutedEventArgs)
        Dim mediaCount As Integer = App.MediaCollection.Count
        If mediaCount < 2 Then
            Throw New InvalidOperationException("You must choose at least two media.")
        End If

        ' Configure the foreground/background images.
        If App.MediaCollection(0).ResizedImage IsNot Nothing Then
            Me.foregroundImage.Source = App.MediaCollection(0).ResizedImage
        Else
            Dim bmp As WriteableBitmap = Me.GetResizedImage(App.MediaCollection(0))
            Me.foregroundImage.Source = bmp
        End If
        If App.MediaCollection(1).ResizedImage IsNot Nothing Then
            Me.backgroundImage.Source = App.MediaCollection(1).ResizedImage
        Else
            Dim bmp As WriteableBitmap = Me.GetResizedImage(App.MediaCollection(1))
            Me.backgroundImage.Source = bmp
        End If

        ' Set _currentImageIndex to 2, so the next time we'll begin with App.MediaCollection[2].
        Me._currentImageIndex = 2

        Me._dispatcherTimer = New DispatcherTimer()
        Me._dispatcherTimer.Interval = App.MediaCollection(0).PhotoDuration
        AddHandler Me._dispatcherTimer.Tick, AddressOf DispatcherTimer_Tick
        Me._dispatcherTimer.Start()
    End Sub

    Private Sub DispatcherTimer_Tick(sender As Object, e As EventArgs)
        Me.backgroundImage.Opacity = 1
        Dim transition As ITransition = App.MediaCollection(Me._currentImageIndex - 1).Transition

        ' Display the transition if it's not null.
        ' This task is delegated to the individual transition class.
        If transition IsNot Nothing Then
            transition.ForegroundElement = Me.foregroundImage
            transition.BackgroundElement = Me.backgroundImage
            AddHandler transition.TransitionCompleted, AddressOf TransitionCompleted
            transition.Begin()
            Me._dispatcherTimer.[Stop]()
        Else
            ' No transition. Simply start to display the next image.
            Me._dispatcherTimer.[Stop]()
            Me.backgroundImage.SetValue(Canvas.ZIndexProperty, 2)
            Me.foregroundImage.SetValue(Canvas.ZIndexProperty, 0)
            Me.GoToNext()
        End If
    End Sub

    Private Sub TransitionCompleted(sender As Object, e As EventArgs)
        Dim transition As ITransition = DirectCast(sender, ITransition)

        ' Modify the z-index if it's not already modified by the transition.
        If Not transition.ImageZIndexModified Then
            Me.backgroundImage.SetValue(Canvas.ZIndexProperty, 2)
            Me.foregroundImage.SetValue(Canvas.ZIndexProperty, 0)
        End If
        transition.[Stop]()

        Me.GoToNext()
    End Sub

    ''' <summary>
    ''' Display the next image.
    ''' </summary>
    Private Sub GoToNext()
        ' Switch the reference so the logic is clearer.
        ' When passed to the transition class, foreground image is the current image,
        ' while background image is the new image to display.
        Dim tempImg As Image = Me.foregroundImage
        Me.foregroundImage = Me.backgroundImage
        Me.backgroundImage = tempImg

        ' More images available, continue the animation.
        If _currentImageIndex < App.MediaCollection.Count Then
            If App.MediaCollection(Me._currentImageIndex).ResizedImage IsNot Nothing Then
                Me.backgroundImage.Source = App.MediaCollection(Me._currentImageIndex).ResizedImage
            Else
                Dim bmp As WriteableBitmap = Me.GetResizedImage(App.MediaCollection(Me._currentImageIndex))
                Me.backgroundImage.Source = bmp
            End If

            Me._dispatcherTimer.Interval = App.MediaCollection(_currentImageIndex).PhotoDuration
            Me._currentImageIndex += 1
            Me._dispatcherTimer.Start()
        End If
    End Sub

    ''' <summary>
    ''' Get the original image from XNA media library.
    ''' And resize it to the target resolution.
    ''' Invokes BitmapHelper.GetResizedImage internally.
    ''' The difference is this method returns WriteableBitmap,
    ''' while BitmapHelper.GetResizedImage returns Stream.
    ''' This method also sets Photo.ResizedImage and Photo.ResizedImageStream.
    ''' </summary>
    ''' <param name="photo">The photo that needs to be resized.</param>
    ''' <returns>A WriteableBitmap representing the resized image.</returns>
    Private Function GetResizedImage(photo As Photo) As WriteableBitmap
        Dim resizedImageStream As Stream = BitmapHelper.GetResizedImage(photo.Name)
        Dim resizedImage As New WriteableBitmap(BitmapHelper.ResizedImageWidth, BitmapHelper.ResizedImageHeight)
        resizedImage.SetSource(resizedImageStream)
        photo.ResizedImageStream = resizedImageStream
        photo.ResizedImage = resizedImage
        Return resizedImage
    End Function
End Class
