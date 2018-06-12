'******************************** Module Header ***********************************'
'Module Name:  WPFIrregularShapeWindow.xaml.vb
'Project:      VBWPFIrregularShapeWindow
'Copyright (c) Microsoft Corporation.
'
'The WPFIrregularShapeWindow.xaml.vb file defines a MainWindow Class inherited windows Class is 
'responsible for showing which present five irregular shape window  
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**********************************************************************************'

Imports System.Text

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class WPFIrregularShapeWindow
    Inherits Window
    Public AdditionHeight As Integer
    Public AdditionWidth As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Window_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Generate random number added to the child windows's width and height in order to not be overlapped each other.
        Dim ro As New Random()
        AdditionHeight = ro.Next(500)
        AdditionWidth = ro.Next(500)
        Dim btn As Button = TryCast(e.Source, Button)
        If btn IsNot Nothing Then
            Select Case TryCast(btn.Tag, String)
                Case "Ellipse Window"
                    Dim ellipseWindow_Renamed As New EllipseWindow()

                    ' Show the child windows individually
                    ellipseWindow_Renamed.Left = Me.Left + Me.Width + AdditionWidth
                    ellipseWindow_Renamed.Top = Me.Top + Me.Height + AdditionHeight

                    ellipseWindow_Renamed.Show()
                Case "Rounded Corners Window"
                    Dim roundedCornersWindow_Renamed As New RoundedCornersWindow()

                    ' Show the child windows individually
                    roundedCornersWindow_Renamed.Left = Me.Left + Me.Width + AdditionWidth
                    roundedCornersWindow_Renamed.Top = Me.Top + Me.Height + AdditionHeight

                    roundedCornersWindow_Renamed.Show()
                Case "Triangle Corners Window"
                    Dim triangleCornersWindow_Renamed As New TriangleCornersWindow()

                    ' Show the child windows individually
                    triangleCornersWindow_Renamed.Left = Me.Left + Me.Width + AdditionWidth
                    triangleCornersWindow_Renamed.Top = Me.Top + AdditionHeight

                    triangleCornersWindow_Renamed.Show()
                Case "Popup Corners Window"
                    Dim popupCornersWindow_Renamed As New PopupCornersWindow()

                    ' Show the child windows individually
                    popupCornersWindow_Renamed.Left = Me.Left + AdditionWidth
                    popupCornersWindow_Renamed.Top = Me.Top + AdditionHeight

                    popupCornersWindow_Renamed.Show()
                Case "Picture Based Windows"
                    Dim picturebasedWindows As New PictureBasedWindow()

                    ' Show the child windows individually
                    picturebasedWindows.Left = Me.Left + AdditionWidth
                    picturebasedWindows.Top = Me.Top + AdditionHeight

                    picturebasedWindows.Show()

                Case Else
            End Select
        End If
    End Sub


End Class

