Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Private pd As PictureDataSource
    Public Sub New()
        InitializeComponent()
        pd = New PictureDataSource()


        llsPictures.ItemsSource = pd.AllPictures
    End Sub

    Private Sub Upload_Click(sender As Object, e As EventArgs)
        NavigationService.Navigate(New Uri("/UploadPage.xaml", UriKind.RelativeOrAbsolute))
    End Sub

    Private Sub llsPictures_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim pvm As PictureViewModel = Nothing
        If e.AddedItems.Count > 0 AndAlso e.AddedItems(0) IsNot Nothing Then
            pvm = DirectCast(e.AddedItems(0), PictureViewModel)
            Dim itemId = pvm.UniqueId
            PhoneApplicationService.Current.State("SelectItem") = pvm
            NavigationService.Navigate(New Uri("/PictureDetailPage.xaml?itemId=" & Convert.ToString(itemId), UriKind.RelativeOrAbsolute))

            llsPictures.SelectedItem = Nothing
        End If
    End Sub
End Class