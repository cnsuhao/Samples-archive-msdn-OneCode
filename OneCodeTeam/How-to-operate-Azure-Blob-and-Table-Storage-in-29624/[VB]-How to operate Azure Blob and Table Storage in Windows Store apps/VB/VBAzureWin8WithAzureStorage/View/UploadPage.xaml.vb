'**************************** Module Header ******************************\
' Module Name:	UploadPage.xaml.vb
' Project:		VBAzureWin8WithAzureStorage
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to store images to Windows Azure Blob storage,
' and save image information to table storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/
Imports Windows.UI.Popups
Imports Windows.Storage.FileProperties
Imports Windows.Storage.Pickers
Imports VBAzureWin8WithAzureStorage.Common

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Partial Public NotInheritable Class UploadPage
    Inherits Page
    Private temporaryFolder As StorageFolder = ApplicationData.Current.TemporaryFolder
    Private m_navigationHelper As NavigationHelper
    Private m_defaultViewModel As New ObservableDictionary()



    ''' <summary>
    ''' This can be changed to a strongly typed view model.
    ''' </summary>
    Public ReadOnly Property DefaultViewModel() As ObservableDictionary
        Get
            Return Me.m_defaultViewModel
        End Get
    End Property

    ''' <summary>
    ''' NavigationHelper is used on each page to aid in navigation and 
    ''' process lifetime management
    ''' </summary>
    Public ReadOnly Property NavigationHelper() As NavigationHelper
        Get
            Return Me.m_navigationHelper
        End Get
    End Property


    Public Sub New()
        Me.InitializeComponent()
        Me.m_navigationHelper = New NavigationHelper(Me)
        AddHandler Me.m_navigationHelper.LoadState, AddressOf navigationHelper_LoadState
        AddHandler Me.m_navigationHelper.SaveState, AddressOf navigationHelper_SaveState
    End Sub

    ''' <summary>
    ''' Populates the page with content passed during navigation. Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="sender">
    ''' The source of the event; typically <see cref="NavigationHelper"/>
    ''' </param>
    ''' <param name="e">Event data that provides both the navigation parameter passed to
    ''' <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
    ''' a dictionary of state preserved by this page during an earlier
    ''' session. The state will be null the first time a page is visited.</param>
    Private Sub navigationHelper_LoadState(sender As Object, e As LoadStateEventArgs)
        Dim pictureVM = New PictureViewModel()
        Me.DefaultViewModel("uploadForm") = pictureVM
    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
    ''' <param name="e">Event data that provides an empty dictionary to be populated with
    ''' serializable state.</param>
    Private Sub navigationHelper_SaveState(sender As Object, e As SaveStateEventArgs)
    End Sub

#Region "NavigationHelper registration"

    ''' The methods provided in this section are simply used to allow
    ''' NavigationHelper to respond to the page's navigation methods.
    ''' 
    ''' Page specific logic should be placed in event handlers for the  
    ''' <see cref="GridCS.Common.NavigationHelper.LoadState"/>
    ''' and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
    ''' The navigation parameter is available in the LoadState method 
    ''' in addition to page state preserved during an earlier session.

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        m_navigationHelper.OnNavigatedTo(e)
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        m_navigationHelper.OnNavigatedFrom(e)
    End Sub

#End Region

    Private Async Function btnSelect_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim uploadForm = TryCast(Me.DefaultViewModel("uploadForm"), PictureViewModel)
        Dim openPicker = New FileOpenPicker() With { _
             .ViewMode = PickerViewMode.Thumbnail, _
             .SuggestedStartLocation = PickerLocationId.PicturesLibrary _
        }

        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".jpeg")
        openPicker.FileTypeFilter.Add(".png")

        Dim file = Await openPicker.PickSingleFileAsync()
        Dim tempFile As StorageFile
        If file IsNot Nothing Then
            tempFile = Await file.CopyAsync(temporaryFolder, Guid.NewGuid().ToString())
            uploadForm.PictureFile = tempFile
            txtFileName.Text = file.Name
            Dim thumbnail = Await file.GetThumbnailAsync(ThumbnailMode.PicturesView)
            Dim bitmap = New BitmapImage()
            bitmap.SetSource(thumbnail)
            imgThumbnail.Source = bitmap
        End If
    End Function

    Private Async Function btnSave_Click(sender As Object, e As RoutedEventArgs) As Task
        btnSave.IsEnabled = False
        Dim uploadForm = TryCast(Me.DefaultViewModel("uploadForm"), PictureViewModel)
        uploadForm.Description = txtDescription.Text
        uploadForm.Name = txtFileName.Text
        If uploadForm.Description = String.Empty OrElse uploadForm.Name = String.Empty OrElse uploadForm.PictureFile Is Nothing Then
            Dim messageBox = New MessageDialog("Please fill all the information", "Warning!")
            Await messageBox.ShowAsync()
            btnSave.IsEnabled = True
            Return
        End If
        If Await PictureDataSource.UploadPictureToCloud(uploadForm) Then
            Me.Frame.Navigate(GetType(MainPage))
        Else
            Dim messageBox As New MessageDialog("Failed to upload. Please try it again later.")
            Await messageBox.ShowAsync()
        End If
    End Function
End Class
