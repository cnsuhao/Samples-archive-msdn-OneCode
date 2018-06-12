'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppEditableVector
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to create an editable vector 
'  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Windows.UI.Xaml.Shapes

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

#Region "Common methods"

    ''' <summary>
    ''' The the event handler for the click event of the link in the footer. 
    ''' </summary>
    ''' <param name="sender">
    ''' The sender.
    ''' </param>
    ''' <param name="e">
    ''' The event arguments.
    ''' </param>
    Private Async Sub FooterClick(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Sub

    Public Sub NotifyUser(message As String)
        Me.StatusText.Text = message
    End Sub

#End Region

    Private Sub Rectangle_ManipulationDelta(sender As Object, e As ManipulationDeltaRoutedEventArgs)
        Dim r = TryCast(sender, Rectangle)
        Dim x = CDbl(r.GetValue(Canvas.LeftProperty)) + e.Delta.Translation.X
        Dim y = CDbl(r.GetValue(Canvas.TopProperty)) + e.Delta.Translation.Y

        If x > VectorContainer.Width Then
            x = VectorContainer.Width
        ElseIf x < -5 Then
            x = -5
        End If

        If y > VectorContainer.Height Then
            y = VectorContainer.Height
        ElseIf y < -5 Then
            y = -5
        End If
        r.SetValue(Canvas.LeftProperty, x)
        r.SetValue(Canvas.TopProperty, y)
        Dim k As Integer = Convert.ToInt32(r.Tag)
        EditablePolygon.Points(k) = New Point(x + 5, y + 5)
    End Sub

End Class
