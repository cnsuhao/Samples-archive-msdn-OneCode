Imports System.Collections.Generic
Imports System.Reflection
Imports System.Linq
Imports Windows.Foundation
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.Storage.Streams
Imports Windows.UI.ViewManagement
Imports Windows.UI.Xaml.Media.Imaging
Imports WatermarkComponent
Imports System.Threading.Tasks

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits ClientApp.Common.LayoutAwarePage
    Private d2dWrapper As D2DWrapper
    Private backgroundImageStream As IRandomAccessStream
    Private watermarkImageStream As IRandomAccessStream
    Private currentImageStream As IRandomAccessStream
    Private previousImageStream As IRandomAccessStream
    ' For undo purpose.
    Private fontColor As Color
    Private backgroundImagePixelWidth As Integer
    Private backgroundImagePixelHeight As Integer

    Private startPointCalculator As StartPointCalculator

    Public Sub New()
        Me.InitializeComponent()

        ' New a D2DWrapper instance.
        d2dWrapper = New D2DWrapper()

        ' Initialize D2DWrapper.
        d2dWrapper.Initialize()

        ' Set up datasource for comboboxes.
        SetupComboboxDataSource()

        startPointCalculator = New StartPointCalculator()

        ' Set up the DataContext.
        Me.DataContext = startPointCalculator
    End Sub

    Private Sub SetupComboboxDataSource()
        ' Set data source for font family combobox
        Me.FontFamilyComBox.ItemsSource = d2dWrapper.GetSystemFont().OrderBy(Function(x) x).ToArray()
        Me.FontFamilyComBox.SelectedIndex = 0

        ' Set data source for font size combobox
        For fontSize As Integer = 10 To 72
            Me.FontSizeComBox.Items.Add(fontSize)
        Next
        Me.FontSizeComBox.SelectedIndex = 0

        ' Set data source for font weight combobox
        Me.FontWeightComBox.ItemsSource = [Enum].GetValues(GetType(WatermarkComponent.FONT_WEIGHT_ENUM)).Cast(Of WatermarkComponent.FONT_WEIGHT_ENUM)()
        Me.FontWeightComBox.SelectedIndex = 0

        ' Set data source for font color combobox
        Dim colors = GetType(Colors).GetTypeInfo().DeclaredProperties
        For Each item In colors
            Me.FontColorComBox.Items.Add(item)
        Next
        Me.FontColorComBox.SelectedIndex = 0

        ' Set data source font style combobox
        Me.FontStyleComBox.ItemsSource = [Enum].GetValues(GetType(WatermarkComponent.FONT_STYLE_ENUM)).Cast(Of WatermarkComponent.FONT_STYLE_ENUM)()
        Me.FontStyleComBox.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As [Object], pageState As Dictionary(Of [String], [Object]))
    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of [String], [Object]))
    End Sub

    Private Async Sub LoadBackgroundImage_Click(sender As Object, e As RoutedEventArgs)
        ' Clear status text.
        Me.NotifyUser("")

        Dim imgFile As StorageFile = Await LoadImage()

        If imgFile IsNot Nothing Then
            Try
                If backgroundImageStream IsNot Nothing Then
                    backgroundImageStream.Dispose()
                    backgroundImageStream = Nothing
                End If

                ' Disable the Undo button.
                Me.UndoButton.IsEnabled = False

                ' Ensure the stream is disposed once the image is loaded
                Using fileStream As IRandomAccessStream = Await imgFile.OpenAsync(Windows.Storage.FileAccessMode.Read)
                    ' Update the background image.
                    backgroundImageStream = fileStream.CloneStream()
                    Dim bitmapImage As New BitmapImage()
                    Await bitmapImage.SetSourceAsync(fileStream)
                    Me.BackgroundImage.Source = bitmapImage

                    ' Update the preview image.
                    fileStream.Seek(0)
                    Dim previewImage As New BitmapImage()
                    Await previewImage.SetSourceAsync(fileStream)
                    Me.PreviewImage.Source = previewImage

                    backgroundImagePixelHeight = bitmapImage.PixelHeight
                    backgroundImagePixelWidth = bitmapImage.PixelWidth

                    ' Set bitmap render target.
                    d2dWrapper.SetBitmapRenderTarget(backgroundImageStream)

                    If currentImageStream IsNot Nothing Then
                        currentImageStream.Dispose()
                        currentImageStream = Nothing
                    End If
                    currentImageStream = backgroundImageStream
                End Using
            Catch ex As Exception
                Me.NotifyUser(ex.Message)
                Return
            End Try

            ' Enable the sliders
            Me.OffsetXSlider.IsEnabled = True
            Me.OffsetYSlider.IsEnabled = True

            Me.SaveToFileButton.IsEnabled = True

            startPointCalculator.OffsetXInPercent = Me.OffsetXSlider.Value
            startPointCalculator.OffsetYInPercent = Me.OffsetYSlider.Value

            Me.startPointIndicator.Visibility = Windows.UI.Xaml.Visibility.Visible
        End If
    End Sub

    Private Async Sub LoadwatermarkImageButton_Click(sender As Object, e As RoutedEventArgs)
        ' Clear status text.
        Me.NotifyUser("")

        If backgroundImageStream IsNot Nothing Then
            If watermarkImageStream IsNot Nothing Then
                watermarkImageStream.Dispose()
                watermarkImageStream = Nothing
            End If

            Dim imgFile As StorageFile = Await LoadImage()
            If imgFile IsNot Nothing Then
                Using fileStream As IRandomAccessStream = Await imgFile.OpenAsync(FileAccessMode.Read)
                    watermarkImageStream = fileStream.CloneStream()
                    Dim watermarkImage As New BitmapImage()
                    Await watermarkImage.SetSourceAsync(fileStream)
                    Me.watermarkImage.Source = watermarkImage

                    If watermarkImage.PixelWidth > backgroundImagePixelWidth OrElse watermarkImage.PixelHeight > backgroundImagePixelHeight Then
                        Me.NotifyUser("The watermark image is too big, please choose a smaller one.")
                        Me.AddwatermarkImageButton.IsEnabled = False
                    Else
                        Me.AddwatermarkImageButton.IsEnabled = True
                    End If
                End Using
            End If
        Else
            Me.NotifyUser("Please load background image first.")
        End If
    End Sub

    Private Async Sub AddTextButton_Click(sender As Object, e As RoutedEventArgs)
        ' Clear status text.
        Me.NotifyUser("")

        Try
            If backgroundImageStream IsNot Nothing Then
                If previousImageStream IsNot Nothing Then
                    previousImageStream.Dispose()
                    previousImageStream = Nothing
                End If

                ' Cache the stream for Undo purpose.
                previousImageStream = currentImageStream
                Me.UndoButton.IsEnabled = True

                Dim startPoint As New Point(Me.OffsetXSlider.Value, Me.OffsetYSlider.Value)
                Dim textColor As Color = Color.FromArgb(CByte(Me.FontOpacitySlider.Value * 255), fontColor.R, fontColor.G, fontColor.B)
                Dim fontSize As UInteger = Convert.ToUInt32(Me.FontSizeComBox.SelectedValue)

                Dim fontStyle As FONT_STYLE_ENUM = DirectCast([Enum].Parse(GetType(FONT_STYLE_ENUM), FontStyleComBox.SelectedValue.ToString()), FONT_STYLE_ENUM)

                Dim fontWeight As FONT_WEIGHT_ENUM = DirectCast([Enum].Parse(GetType(FONT_WEIGHT_ENUM), Me.FontWeightComBox.SelectedValue.ToString()), FONT_WEIGHT_ENUM)

                ' BeginDraw
                d2dWrapper.BeginDraw()

                ' Draw text
                d2dWrapper.DrawText(Me.inputText.Text, startPoint, Me.FontFamilyComBox.SelectedValue.ToString(), textColor, fontSize, fontStyle, _
                    fontWeight, String.Empty)

                ' EndDraw
                currentImageStream = d2dWrapper.EndDraw(True)
                currentImageStream.Seek(0)

                ' Update the preview image.
                Dim bi As New BitmapImage()
                Await bi.SetSourceAsync(currentImageStream)

                Me.PreviewImage.Source = bi
            End If
        Catch ex As Exception
            Me.NotifyUser(ex.Message)
        End Try
    End Sub

    Private Async Sub AddwatermarkImageButton_Click(sender As Object, e As RoutedEventArgs)
        ' Clear status text.
        Me.NotifyUser("")

        Try
            If backgroundImageStream IsNot Nothing AndAlso watermarkImageStream IsNot Nothing Then
                If previousImageStream IsNot Nothing Then
                    previousImageStream.Dispose()
                    previousImageStream = Nothing
                End If

                ' Cache the stream for Undo purpose.
                previousImageStream = currentImageStream
                Me.UndoButton.IsEnabled = True

                Dim startPoint As New Point(Me.OffsetXSlider.Value, Me.OffsetYSlider.Value)

                ' BeginDraw
                d2dWrapper.BeginDraw()

                ' Draw image
                d2dWrapper.DrawImage(watermarkImageStream, startPoint, CSng(Me.watermarkImageOpacitySlider.Value))

                ' EndDraw
                currentImageStream = d2dWrapper.EndDraw(True)
                currentImageStream.Seek(0)

                Dim bi As New BitmapImage()
                Await bi.SetSourceAsync(currentImageStream)
                Me.PreviewImage.Source = bi
            Else
                Me.NotifyUser("Can't add watermark image. Please make sure you have loaded background image and watermark image.")
            End If
        Catch ex As Exception
            Me.NotifyUser(ex.Message)
        End Try

    End Sub

    Private Sub SaveToFileButton_Click(sender As Object, e As RoutedEventArgs)
        ' Clear status text.
        Me.NotifyUser("")

        If backgroundImageStream IsNot Nothing Then
            d2dWrapper.SaveBitmapToFile()
        Else
            Me.NotifyUser("There is no background image...")
        End If
    End Sub

    ' Load Image file
    Private Async Function LoadImage() As Task(Of StorageFile)
        ' Clear status text.
        Me.NotifyUser("")

        Dim imgFile As StorageFile = Nothing
        Dim unsnapped As Boolean = ((ApplicationView.Value <> ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
        If Not unsnapped Then
            NotifyUser("Cannot unsnap the app.")
            Return Nothing
        End If

        Dim openPicker As New FileOpenPicker()
        openPicker.ViewMode = PickerViewMode.Thumbnail
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".jpeg")
        openPicker.FileTypeFilter.Add(".bmp")
        openPicker.FileTypeFilter.Add(".png")
        imgFile = Await openPicker.PickSingleFileAsync()

        Return imgFile
    End Function

    Private Sub FontColorComBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If Me.FontColorComBox.SelectedIndex <> -1 Then
            Dim pi = TryCast(Me.FontColorComBox.SelectedItem, PropertyInfo)
            fontColor = DirectCast(pi.GetValue(Nothing), Color)
        End If
    End Sub

    Private Sub inputText_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb IsNot Nothing Then
            If Not [String].IsNullOrWhiteSpace(tb.Text) Then
                Me.AddTextButton.IsEnabled = True
            Else
                Me.AddTextButton.IsEnabled = False
            End If
        End If
    End Sub

    ' If the size of the background image container has been changed, we should recalculate the start point indicator.
    Private Sub BackgroundGrid_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        startPointCalculator.ImageContainerActualHeight = e.NewSize.Height
        startPointCalculator.ImageContainerActualWidth = e.NewSize.Width
    End Sub

    ' If the size of the background image has been changed, we should recalculate the start point indicator.
    Private Sub BackgroundImage_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        startPointCalculator.BackgroundImageActualHeight = e.NewSize.Height
        startPointCalculator.BackgroundImageActualWidth = e.NewSize.Width
    End Sub

    ' In this sample, we just support undo the last operation.
    Private Async Sub UndoButton_Click(sender As Object, e As RoutedEventArgs)
        If currentImageStream IsNot Nothing Then
            currentImageStream.Dispose()
            currentImageStream = Nothing
        End If

        ' Update currentImageStream.
        currentImageStream = previousImageStream
        currentImageStream.Seek(0)

        Me.d2dWrapper.SetBitmapRenderTarget(currentImageStream)
        Me.UndoButton.IsEnabled = False

        ' NOTE: We should set the position of the stream to 0 again.
        currentImageStream.Seek(0)

        ' Update the preview image.
        Dim bi As New BitmapImage()
        Await bi.SetSourceAsync(currentImageStream)
        Me.PreviewImage.Source = bi

        ' Set previousImageStream as null.
        previousImageStream = Nothing
    End Sub

    Private Async Sub Footer_Click(sender As Object, e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Sub

    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub
End Class

