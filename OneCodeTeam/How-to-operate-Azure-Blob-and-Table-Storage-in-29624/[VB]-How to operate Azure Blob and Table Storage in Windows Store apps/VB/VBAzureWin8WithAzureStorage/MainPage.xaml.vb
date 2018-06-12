'**************************** Module Header ******************************\
' Module Name:	MainPage.xaml.vb
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
Imports VBAzureWin8WithAzureStorage.Common
Imports Microsoft.WindowsAzure.Storage.Blob

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Partial Public NotInheritable Class MainPage
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

    Private Sub navigationHelper_LoadState(sender As Object, e As LoadStateEventArgs)

        Me.lstMassageInfos.ItemsSource = PictureDataSource.GetAllImages()
    End Sub


    Private Sub navigationHelper_SaveState(sender As Object, e As SaveStateEventArgs)

    End Sub

#Region "NavigationHelper registration"

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        m_navigationHelper.OnNavigatedTo(e)
    End Sub

    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        m_navigationHelper.OnNavigatedFrom(e)
    End Sub

#End Region

    Private Async Function lstMassageInfos_ItemClick(sender As Object, e As ItemClickEventArgs) As Task
        Dim item = TryCast(e.ClickedItem, PictureViewModel)
        tbFileName.Text = item.Name
        tbDescription.Text = item.Description
        If item.PictureFile Is Nothing Then
            Dim blob = New CloudBlockBlob(New Uri(item.PictureUrl), App.credentials)
            Dim file As StorageFile
            Try
                file = Await temporaryFolder.CreateFileAsync(item.Name, CreationCollisionOption.ReplaceExisting)
                Using fileStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
                    Await blob.DownloadToStreamAsync(fileStream)
                End Using
                item.PictureFile = file
                imgBlobItem.Source = New BitmapImage(New Uri(file.Path))
            Catch ex As Exception
                Throw
            End Try
        Else

            imgBlobItem.Source = New BitmapImage(New Uri(item.PictureFile.Path))
        End If
    End Function

    Private Sub Upload_Click(sender As Object, e As RoutedEventArgs)
        Me.Frame.Navigate(GetType(UploadPage))
    End Sub

    Private Async Function AppBarButton_Click(sender As Object, e As RoutedEventArgs) As Task
        Dim item = TryCast(lstMassageInfos.SelectedItem, PictureViewModel)
        If item IsNot Nothing Then
            Await PictureDataSource.DeletePictureFormCloud(item)
            lstMassageInfos.SelectedItem = Nothing
            CleanDetails()
        End If
    End Function
    Private Sub CleanDetails()
        tbFileName.Text = String.Empty
        tbDescription.Text = String.Empty
        imgBlobItem.Source = Nothing
    End Sub
End Class

