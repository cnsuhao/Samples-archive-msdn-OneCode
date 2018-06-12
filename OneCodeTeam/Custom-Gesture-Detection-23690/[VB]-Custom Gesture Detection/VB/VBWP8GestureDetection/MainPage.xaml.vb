'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:		VBWP8GestureDetection
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to detect sharp and rotation with two points touch
' and one touch flick. By this sample, you can create your own photo viewer that 
' support picture enlargement, rotation and move/flick.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()
        AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
    End Sub

    Private preDistance As Double = 0
    Private preAngle As Double = 0
    Private preFlickX As Double = 0
    Private preFlickY As Double = 0
    Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
        Dim tpc As TouchPointCollection = e.GetTouchPoints(touchStackPanel)
        If tpc.Count = 2 Then
            Dim point1 As TouchPoint = tpc(0)
            Dim point2 As TouchPoint = tpc(1)

            Dim X1 As Double = point1.Position.X
            Dim X2 As Double = point2.Position.X
            Dim Y1 As Double = point1.Position.Y
            Dim Y2 As Double = point2.Position.Y

            ' Detect two fingers enlargement and shrink.
            Dim distance = Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)
            If distance > preDistance Then
                txt_SharpInfo.Text = "enlarge"
            Else
                txt_SharpInfo.Text = "shink"
            End If
            preDistance = distance

            ' Detect rotation.
            Dim nowAngle As Double = 0
            If (X2 - X1) = 0 Then
                nowAngle = 90
            Else
                nowAngle = Math.Atan((Y2 - Y1) / (X2 - X1))
            End If
            If nowAngle > preAngle Then
                txt_RotateInfo.Text = "clock wise rotation"
            Else
                txt_RotateInfo.Text = "counter clock wise rotation"
            End If
            preAngle = nowAngle
        End If

        ' Detect flick.
        If tpc.Count = 1 Then
            Dim flickPoint As TouchPoint = tpc(0)
            If flickPoint.Action = TouchAction.Move Then
                txt_FlickInfo.Text = "Move"
                preFlickX = flickPoint.Position.X
                preFlickY = flickPoint.Position.Y
            ElseIf flickPoint.Action = TouchAction.Up Then
                Dim nowflickX As Double = flickPoint.Position.X
                Dim nowflickY As Double = flickPoint.Position.Y
                Dim length As Double = Math.Pow((nowflickX - preFlickX), 2) + Math.Pow((nowflickY - preFlickY), 2)
                If length > 0 Then
                    txt_FlickInfo.Text = [String].Concat("flick", length.ToString())
                End If
            End If
        End If
    End Sub

End Class