'************************** Module Header ******************************\
' Module Name:  MainPage.vb
' Project:      VBWindowsStoreAppCropBitmap
' Copyright (c) Microsoft Corporation.
' 
' This UI of this application.
'  
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
Imports Windows.Graphics.Imaging
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Navigation

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits VBWindowsStoreAppCropBitmap.Common.LayoutAwarePage

    Private _selectedRegion As SelectedRegion

    ' The current image file to be cropped.
    Private _sourceImageFile As StorageFile = Nothing

    Private _sourceImagePixelWidth As UInteger
    Private _sourceImagePixelHeight As UInteger

    ''' <summary>
    ''' The size of the corners.
    ''' </summary>
    Private _cornerSize As Double

    Private ReadOnly Property CornerSize() As Double
        Get
            If _cornerSize <= 0 Then
                _cornerSize = CDbl(Application.Current.Resources("Size"))
            End If

            Return _cornerSize
        End Get
    End Property

    ''' <summary>
    ''' The previous points of all the pointers.
    ''' </summary>
    Private _pointerPositionHistory As New Dictionary(Of UInteger, Point?)()

    Public Sub New()
        Me.InitializeComponent()

        selectRegion.ManipulationMode = ManipulationModes.Scale Or ManipulationModes.TranslateX Or ManipulationModes.TranslateY

        _selectedRegion = New SelectedRegion With {.MinSelectRegionSize = 2 * CornerSize}
        Me.DataContext = _selectedRegion
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        AddHandler _selectedRegion.PropertyChanged, AddressOf selectedRegion_PropertyChanged

        AddHandler Me.sourceImage.ImageFailed, AddressOf sourceImage_ImageFailed

        ' Handle the pointer events of the corners. 
        AddCornerEvents(topLeftCorner)
        AddCornerEvents(topRightCorner)
        AddCornerEvents(bottomLeftCorner)
        AddCornerEvents(bottomRightCorner)

        ' Handle the manipulation events of the selectRegion
        AddHandler selectRegion.ManipulationDelta, AddressOf selectRegion_ManipulationDelta
        AddHandler selectRegion.ManipulationCompleted, AddressOf selectRegion_ManipulationCompleted

        AddHandler Me.sourceImage.SizeChanged, AddressOf sourceImage_SizeChanged


    End Sub

    Protected Overrides Sub OnNavigatedFrom(ByVal e As NavigationEventArgs)
        MyBase.OnNavigatedFrom(e)

        RemoveHandler _selectedRegion.PropertyChanged, AddressOf selectedRegion_PropertyChanged

        RemoveHandler Me.sourceImage.ImageFailed, AddressOf sourceImage_ImageFailed

        ' Handle the pointer events of the corners. 
        RemoveCornerEvents(topLeftCorner)
        RemoveCornerEvents(topRightCorner)
        RemoveCornerEvents(bottomLeftCorner)
        RemoveCornerEvents(bottomRightCorner)

        ' Handle the manipulation events of the selectRegion
        RemoveHandler selectRegion.ManipulationDelta, AddressOf selectRegion_ManipulationDelta
        RemoveHandler selectRegion.ManipulationCompleted, AddressOf selectRegion_ManipulationCompleted

        RemoveHandler Me.sourceImage.SizeChanged, AddressOf sourceImage_SizeChanged

    End Sub

    Private Sub AddCornerEvents(ByVal corner As Control)
        AddHandler corner.PointerPressed, AddressOf Corner_PointerPressed
        AddHandler corner.PointerMoved, AddressOf Corner_PointerMoved
        AddHandler corner.PointerReleased, AddressOf Corner_PointerReleased
    End Sub

    Private Sub RemoveCornerEvents(ByVal corner As Control)
        RemoveHandler corner.PointerPressed, AddressOf Corner_PointerPressed
        RemoveHandler corner.PointerMoved, AddressOf Corner_PointerMoved
        RemoveHandler corner.PointerReleased, AddressOf Corner_PointerReleased
    End Sub


#Region "Open an image, handle the select region changed event and save the image."

    ''' <summary>
    ''' Let user choose an image and load it.
    ''' </summary>
    Private Async Sub openImageButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim unsnapped As Boolean = ((ApplicationView.Value <> ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
        If Not unsnapped Then
            NotifyUser("Cannot unsnap the sample.")
            Return
        End If


        Dim openPicker As New FileOpenPicker()
        openPicker.ViewMode = PickerViewMode.Thumbnail
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".jpeg")
        openPicker.FileTypeFilter.Add(".bmp")
        openPicker.FileTypeFilter.Add(".png")
        Dim imgFile As StorageFile = Await openPicker.PickSingleFileAsync()
        If imgFile IsNot Nothing Then

            Me.previewImage.Source = Nothing
            Me.sourceImage.Source = Nothing
            Me.imageCanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            Me.originalImageInfoText.Text = String.Empty
            Me.selectInfoInBitmapText.Text = String.Empty
            Me.saveImageButton.IsEnabled = False

            ' Ensure the stream is disposed once the image is loaded
            Using fileStream As IRandomAccessStream = Await imgFile.OpenAsync(Windows.Storage.FileAccessMode.Read)
                Me._sourceImageFile = imgFile
                Dim decoder As BitmapDecoder = Await BitmapDecoder.CreateAsync(fileStream)

                Me._sourceImagePixelHeight = decoder.PixelHeight
                Me._sourceImagePixelWidth = decoder.PixelWidth
            End Using

            If Me._sourceImagePixelHeight < 2 * Me.CornerSize OrElse Me._sourceImagePixelWidth < 2 * Me.CornerSize Then
                Me.NotifyUser(String.Format("Please select an image which is larger than {0}*{0}", 2 * Me.CornerSize))
                Return
            Else
                Dim sourceImageScale As Double = 1

                If Me._sourceImagePixelHeight < Me.sourceImageGrid.ActualHeight AndAlso Me._sourceImagePixelWidth < Me.sourceImageGrid.ActualWidth Then
                    Me.sourceImage.Stretch = Windows.UI.Xaml.Media.Stretch.None
                Else
                    sourceImageScale = Math.Min(Me.sourceImageGrid.ActualWidth / Me._sourceImagePixelWidth, Me.sourceImageGrid.ActualHeight / Me._sourceImagePixelHeight)
                    Me.sourceImage.Stretch = Windows.UI.Xaml.Media.Stretch.Uniform
                End If

                Me.sourceImage.Source = Await CropBitmap.GetCroppedBitmapAsync(Me._sourceImageFile, New Point(0, 0), New Size(Me._sourceImagePixelWidth, Me._sourceImagePixelHeight), sourceImageScale)

                Me.originalImageInfoText.Text = String.Format("Original Image Size: {0}*{1} ", Me._sourceImagePixelWidth, Me._sourceImagePixelHeight)

            End If


        End If
    End Sub

    ''' <summary>
    ''' Show the error message if the image is failed.
    ''' </summary>
    Private Sub sourceImage_ImageFailed(ByVal sender As Object, ByVal e As ExceptionRoutedEventArgs)
        Me.NotifyUser(String.Format("Failed to open the image file: {0}", e.ErrorMessage))
    End Sub

    ''' <summary>
    ''' This event will be fired when 
    ''' 1. An new image is opened.
    ''' 2. The source of the sourceImage is set to null.
    ''' 3. The view state of this application is changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub sourceImage_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)

        If e.NewSize.IsEmpty OrElse Double.IsNaN(e.NewSize.Height) OrElse e.NewSize.Height <= 0 Then
            Me.imageCanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed
            Me.saveImageButton.IsEnabled = False
            Me._selectedRegion.OuterRect = Rect.Empty
            Me._selectedRegion.ResetCorner(0, 0, 0, 0)
        Else
            Me.imageCanvas.Visibility = Windows.UI.Xaml.Visibility.Visible
            Me.saveImageButton.IsEnabled = True

            Me.imageCanvas.Height = e.NewSize.Height
            Me.imageCanvas.Width = e.NewSize.Width
            Me._selectedRegion.OuterRect = New Rect(0, 0, e.NewSize.Width, e.NewSize.Height)

            If e.PreviousSize.IsEmpty OrElse Double.IsNaN(e.PreviousSize.Height) OrElse e.PreviousSize.Height <= 0 Then
                Me._selectedRegion.ResetCorner(0, 0, e.NewSize.Width, e.NewSize.Height)
            Else
                Dim scale As Double = e.NewSize.Height / e.PreviousSize.Height
                Me._selectedRegion.ResizeSelectedRect(scale)
                UpdatePreviewImage()
            End If

        End If


    End Sub

    ''' <summary>
    ''' Show the select region information.
    ''' </summary>
    Private Sub selectedRegion_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        Dim widthScale As Double = imageCanvas.Width / Me._sourceImagePixelWidth
        Dim heightScale As Double = imageCanvas.Height / Me._sourceImagePixelHeight

        Me.selectInfoInBitmapText.Text = String.Format("Start Point: ({0},{1})  Size: {2}*{3}", Math.Floor(Me._selectedRegion.SelectedRect.X / widthScale), Math.Floor(Me._selectedRegion.SelectedRect.Y / heightScale), Math.Floor(Me._selectedRegion.SelectedRect.Width / widthScale), Math.Floor(Me._selectedRegion.SelectedRect.Height / heightScale))
    End Sub

    ''' <summary>
    ''' Save the cropped image.
    ''' </summary>
    Private Async Sub saveImageButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim unsnapped As Boolean = ((ApplicationView.Value <> ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
        If Not unsnapped Then
            NotifyUser("Cannot unsnap the sample.")
            Return
        End If

        Dim widthScale As Double = imageCanvas.Width / Me._sourceImagePixelWidth
        Dim heightScale As Double = imageCanvas.Height / Me._sourceImagePixelHeight

        Dim savePicker As New FileSavePicker()
        savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary

        savePicker.FileTypeChoices.Add("JPG file", New List(Of String)() From {".jpg"})
        savePicker.FileTypeChoices.Add("JPEG file", New List(Of String)() From {".jpeg"})
        savePicker.FileTypeChoices.Add("PNG file", New List(Of String)() From {".png"})
        savePicker.FileTypeChoices.Add("BMP file", New List(Of String)() From {".bmp"})


        savePicker.SuggestedFileName = String.Format(
            "{0}_{1}x{2}{3}",
            _sourceImageFile.DisplayName,
            CInt(Math.Floor(Me._selectedRegion.SelectedRect.Width / widthScale)),
            CInt(Math.Floor(Me._selectedRegion.SelectedRect.Height / heightScale)),
            _sourceImageFile.FileType)
        Dim croppedImageFile As StorageFile = Await savePicker.PickSaveFileAsync()

        If croppedImageFile IsNot Nothing Then
            Await CropBitmap.SaveCroppedBitmapAsync(_sourceImageFile, croppedImageFile, New Point(Me._selectedRegion.SelectedRect.X / widthScale, Me._selectedRegion.SelectedRect.Y / heightScale), New Size(Me._selectedRegion.SelectedRect.Width / widthScale, Me._selectedRegion.SelectedRect.Height / heightScale))

            Me.NotifyUser("The cropped bitmap is saved.")
        End If
    End Sub

#End Region

#Region "Select Region methods"

    ''' <summary>
    ''' If a pointer presses in the corner, it means that the user starts to move the corner.
    ''' 1. Capture the pointer, so that the UIElement can get the Pointer events (PointerMoved,
    '''    PointerReleased...) even the pointer is outside of the UIElement.
    ''' 2. Record the start position of the move.
    ''' </summary>
    Private Sub Corner_PointerPressed(ByVal sender As Object, ByVal e As PointerRoutedEventArgs)
        TryCast(sender, UIElement).CapturePointer(e.Pointer)

        Dim pt As Windows.UI.Input.PointerPoint = e.GetCurrentPoint(Me)

        ' Record the start point of the pointer.
        _pointerPositionHistory(pt.PointerId) = pt.Position

        e.Handled = True
    End Sub

    ''' <summary>
    ''' If a pointer which is captured by the corner moves，the select region will be updated.
    ''' </summary>
    Private Sub Corner_PointerMoved(ByVal sender As Object, ByVal e As PointerRoutedEventArgs)

        Dim pt As Windows.UI.Input.PointerPoint = e.GetCurrentPoint(Me)
        Dim ptrId As UInteger = pt.PointerId

        If _pointerPositionHistory.ContainsKey(ptrId) AndAlso _pointerPositionHistory(ptrId).HasValue Then
            Dim currentPosition As Point = pt.Position
            Dim previousPosition As Point = _pointerPositionHistory(ptrId).Value

            Dim xUpdate As Double = currentPosition.X - previousPosition.X
            Dim yUpdate As Double = currentPosition.Y - previousPosition.Y

            Me._selectedRegion.UpdateCorner(TryCast((TryCast(sender, ContentControl)).Tag, String), xUpdate, yUpdate)

            _pointerPositionHistory(ptrId) = currentPosition
        End If

        e.Handled = True
    End Sub

    ''' <summary>
    ''' The pressed pointer is released, which means that the move is ended.
    ''' 1. Release the Pointer.
    ''' 2. Clear the position history of the Pointer.
    ''' </summary>
    Private Sub Corner_PointerReleased(ByVal sender As Object, ByVal e As PointerRoutedEventArgs)
        Dim ptrId As UInteger = e.GetCurrentPoint(Me).PointerId
        If Me._pointerPositionHistory.ContainsKey(ptrId) Then
            Me._pointerPositionHistory.Remove(ptrId)
        End If

        TryCast(sender, UIElement).ReleasePointerCapture(e.Pointer)

        UpdatePreviewImage()
        e.Handled = True


    End Sub

    ''' <summary>
    ''' The user manipulates the selectRegion. The manipulation includes
    ''' 1. Translate
    ''' 2. Scale
    ''' </summary>
    Private Sub selectRegion_ManipulationDelta(ByVal sender As Object, ByVal e As ManipulationDeltaRoutedEventArgs)
        Me._selectedRegion.UpdateSelectedRect(e.Delta.Scale, e.Delta.Translation.X, e.Delta.Translation.Y)
        e.Handled = True
    End Sub

    ''' <summary>
    ''' The manipulation is completed, and then update the preview image
    ''' </summary>
    Private Sub selectRegion_ManipulationCompleted(ByVal sender As Object, ByVal e As ManipulationCompletedRoutedEventArgs)
        UpdatePreviewImage()
    End Sub

    ''' <summary>
    ''' Update preview image.
    ''' </summary>
    Private Async Sub UpdatePreviewImage()
        Dim sourceImageWidthScale As Double = imageCanvas.Width / Me._sourceImagePixelWidth
        Dim sourceImageHeightScale As Double = imageCanvas.Height / Me._sourceImagePixelHeight


        Dim previewImageSize As New Size(
            Me._selectedRegion.SelectedRect.Width / sourceImageWidthScale,
            Me._selectedRegion.SelectedRect.Height / sourceImageHeightScale)

        Dim previewImageScale As Double = 1

        If previewImageSize.Width <= imageCanvas.Width AndAlso previewImageSize.Height <= imageCanvas.Height Then
            Me.previewImage.Stretch = Windows.UI.Xaml.Media.Stretch.None
        Else
            Me.previewImage.Stretch = Windows.UI.Xaml.Media.Stretch.Uniform

            previewImageScale = Math.Min(imageCanvas.Width / previewImageSize.Width,
                                         imageCanvas.Height / previewImageSize.Height)
        End If



        Me.previewImage.Source = Await CropBitmap.GetCroppedBitmapAsync(Me._sourceImageFile, New Point(Me._selectedRegion.SelectedRect.X / sourceImageWidthScale, Me._selectedRegion.SelectedRect.Y / sourceImageHeightScale), previewImageSize, previewImageScale)

    End Sub

#End Region



#Region "Common methods"

    Private Async Sub Footer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri((TryCast(sender, HyperlinkButton)).Tag.ToString()))
    End Sub


    Public Sub NotifyUser(ByVal message As String)
        Me.statusText.Text = message
    End Sub

#End Region

End Class