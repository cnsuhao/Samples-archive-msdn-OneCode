Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class DetailsPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim item = DirectCast(PhoneApplicationService.Current.State("SelectItem"), PictureViewModel)

        Me.DataContext = item
    End Sub

End Class