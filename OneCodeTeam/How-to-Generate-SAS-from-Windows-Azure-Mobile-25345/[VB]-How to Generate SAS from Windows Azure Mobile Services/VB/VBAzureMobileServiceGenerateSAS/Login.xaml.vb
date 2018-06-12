'****************************** Module Header ******************************\
' Module Name: Login.xaml.vb
' Project:     AzureMobileServiceGenerateSAS
' Copyright (c) Microsoft Corporation.
' 
' Interaction logic for Login.xaml
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Windows.Controls.Primitives

''' <summary>
''' Interaction logic for Login.xaml
''' </summary>
Partial Public Class Login
    Inherits UserControl
    Private startUri As Uri
    Private endUri As Uri

    Private loginCancelled As Boolean = False
    Private loginToken As String = Nothing

    Public Sub New(startUri As Uri, endUri As Uri)
        InitializeComponent()

        Me.startUri = startUri
        Me.endUri = endUri

        Dim bounds = Application.Current.MainWindow.RenderSize

        Me.grdRootPanel.Width = Math.Max(bounds.Width, 640)
        Me.grdRootPanel.Height = Math.Max(bounds.Height, 480)

        AddHandler Me.webControl.LoadCompleted, AddressOf webControl_LoadCompleted
        AddHandler Me.webControl.Navigating, AddressOf webControl_Navigating
        Me.webControl.Navigate(Me.startUri)
    End Sub

    Private Sub webControl_Navigating(sender As Object, e As NavigatingCancelEventArgs)
        If e.Uri.Equals(Me.endUri) Then
            Dim uri As String = e.Uri.ToString()
            Dim tokenIndex As Integer = uri.IndexOf("#token=")
            If tokenIndex >= 0 Then
                Me.loginToken = uri.Substring(tokenIndex + "#token=".Length)
            Else

                Me.loginCancelled = True
            End If

            DirectCast(Me.Parent, Popup).IsOpen = False
        End If
    End Sub

    Private Sub webControl_LoadCompleted(sender As Object, e As NavigationEventArgs)
        Me.progress.Visibility = System.Windows.Visibility.Collapsed
        Me.webControl.Visibility = System.Windows.Visibility.Visible
    End Sub

    Public Function Display() As Task(Of String)
        Dim popup As New Popup()
        popup.Child = Me
        popup.PlacementRectangle = New Rect(New Size(SystemParameters.FullPrimaryScreenWidth, SystemParameters.FullPrimaryScreenHeight))
        popup.Placement = PlacementMode.Center
        Dim tcs As New TaskCompletionSource(Of String)()
        popup.IsOpen = True
        AddHandler popup.Closed,
            Sub(snd, ea)
                    If Me.loginCancelled Then
                        tcs.SetException(New InvalidOperationException("Login cancelled"))
                    Else
                        tcs.SetResult(Me.loginToken)
                    End If
                End Sub

        Return tcs.Task
    End Function

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs)
        Me.loginCancelled = True
        DirectCast(Me.Parent, Popup).IsOpen = False
    End Sub
End Class