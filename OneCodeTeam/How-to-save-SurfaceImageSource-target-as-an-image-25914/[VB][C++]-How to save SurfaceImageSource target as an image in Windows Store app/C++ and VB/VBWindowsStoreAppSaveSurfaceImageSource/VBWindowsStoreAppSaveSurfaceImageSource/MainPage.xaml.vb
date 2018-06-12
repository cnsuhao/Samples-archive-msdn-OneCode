'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWindowsStoreAppSaveSurfaceImageSource
' Copyright (c) Microsoft Corporation
'
' This code sample shows how to save the content of SurfaceImageSource to image file.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports MyImageSourceWinRT
Imports Windows.UI
Imports Windows.UI.Xaml.Navigation
' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits VBWindowsStoreAppSaveSurfaceImageSource.Common.LayoutAwarePage
    Private imageWidth As UInteger
    Private imageHeight As UInteger
    Private myImageSource As MyImageSource

    Public Sub New()
        Me.InitializeComponent()
        imageWidth = CUInt(Me.MyImage.Width)
        imageHeight = CUInt(Me.MyImage.Height)
        myImageSource = New MyImageSource(imageWidth, imageHeight, True)
        Me.MyImage.Source = myImageSource
    End Sub

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))

    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="Common.SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of String, Object))

    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        ' Begin updating the surfaceImageSource
        myImageSource.BeginDraw()

        ' Clear background
        myImageSource.Clear(Colors.Black)

        ' Draw something...
        Dim rect As Rect
        Dim startPointX As Single = 0.0F
        Dim startPointY As Single = 0.0F
        Dim deltaX As Single = 3.0F
        Dim deltaY As Single = 3.0F

        rect.X = startPointX
        rect.Y = startPointY
        rect.Width = (imageWidth - deltaX * 2) / 2.0F
        rect.Height = (imageHeight - deltaY * 2) / 2.0F
        myImageSource.FillSolidRect(Color.FromArgb(255, 250, 67, 5), rect)

        rect.X = startPointX + rect.Width + 2 * deltaX
        myImageSource.FillSolidRect(Color.FromArgb(255, 96, 176, 6), rect)

        rect.X = startPointX
        rect.Y = startPointY + rect.Height + 2 * deltaY
        myImageSource.FillSolidRect(Color.FromArgb(255, 14, 179, 241), rect)

        rect.X = startPointX + rect.Width + 2 * deltaX
        myImageSource.FillSolidRect(Color.FromArgb(255, 247, 199, 36), rect)

        ' Stop updating the SurfaceImageSource and draw its contents 
        myImageSource.EndDraw()
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs) Handles SaveButton.Click
        NotifyUser("")
        If EnsureUnsnapped() Then
            myImageSource.SaveSurfaceImageToFile()
        End If
    End Sub

    Private Async Sub FooterClick(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Sub

    Friend Function EnsureUnsnapped() As Boolean
        ' FilePicker APIs will not work if the application is in a snapped state.
        ' If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
        Dim unsnapped As Boolean = ((ApplicationView.Value <> ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
        If Not unsnapped Then
            NotifyUser("Cannot unsnap the sample.")
        End If

        Return unsnapped
    End Function

    Public Sub NotifyUser(strMessage As String)
        Me.StatusBlock.Text = strMessage
    End Sub

End Class


