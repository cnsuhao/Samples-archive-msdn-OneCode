'****************************** Module Header ******************************
' Module Name:                MainPage.xaml.vb
' Project:                    VBWP7SecondaryTile
' Copyright (c) Microsoft Corporation.
' 
' MainPage's code hehind file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        If Me.NavigationContext.QueryString.ContainsKey("Param") Then
            Dim param As String = Me.NavigationContext.QueryString("Param")'Get "Param" this query string.
            textBlock1.Text = "Welcome back from " & param
        End If
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs)
        Dim tileParameter As String = "Param=" + DirectCast(sender, Button).Name
        Dim tile As ShellTile = CheckIfTileExist(tileParameter)
        If tile Is Nothing Then

            Dim secondaryTile As New StandardTileData With {
             .Title = tileParameter,
             .BackgroundImage = New Uri("Background-Secondary.png", UriKind.Relative),
             .Count = 2,
             .BackContent = "Secondary Tile Test"
            }
            ShellTile.Create(New Uri("/MainPage.xaml?" & tileParameter, UriKind.Relative), secondaryTile) 'Create SecondaryTile and pass querystring to navigation url.
        End If
    End Sub

    Private Function CheckIfTileExist(tileUri As String) As ShellTile
        Dim shellTile__1 As ShellTile = ShellTile.ActiveTiles.FirstOrDefault(Function(tile) tile.NavigationUri.ToString().Contains(tileUri))
        Return shellTile__1
    End Function

End Class
