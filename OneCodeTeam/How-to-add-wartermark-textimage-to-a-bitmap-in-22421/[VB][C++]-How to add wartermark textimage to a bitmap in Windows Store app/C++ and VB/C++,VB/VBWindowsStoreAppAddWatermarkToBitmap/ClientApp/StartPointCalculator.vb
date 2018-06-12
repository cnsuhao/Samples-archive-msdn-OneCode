'****************************** Module Header ******************************\
' Module Name:  StartPointCalculator.vb
' Project:      ClientApp
' Copyright (c) Microsoft Corporation.
' 
' This class exposes some properties for data binding. It's used to set the
' position of the start point indicator.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.ComponentModel

Public Class StartPointCalculator
    Implements INotifyPropertyChanged
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Private Const OffsetXInpercentName As String = "OffsetXInPercent"
    Private Const OffsetYInpercentName As String = "OffsetYInPercent"
    Private Const StartPointOffsetXName As String = "StartPointOffsetX"
    Private Const StartPointOffsetYName As String = "StartPointOffsetY"
    Private Const BackgroundImageActualWidthName As String = "BackgroundImageActualWidth"
    Private Const BackgroundImageActualHeightName As String = "BackgroundImageActualHeight"
    Private Const ImageContainerActualWidthName As String = "ImageContainerActualWidth"
    Private Const ImageContainerActualHeightName As String = "ImageContainerActualHeight"

    Public Sub New()
    End Sub

    Private _backGroundImageActualHeight As Double
    Public Property BackgroundImageActualHeight() As Double
        Get
            Return _backGroundImageActualHeight
        End Get
        Set(value As Double)
            If _backGroundImageActualHeight <> value Then
                _backGroundImageActualHeight = value
                Me.OnPropertyChanged(BackgroundImageActualHeightName)
            End If
        End Set
    End Property

    Private _backGroundImageActualWidth As Double
    Public Property BackgroundImageActualWidth() As Double
        Get
            Return _backGroundImageActualWidth
        End Get
        Set(value As Double)
            If _backGroundImageActualWidth <> value Then
                _backGroundImageActualWidth = value
                Me.OnPropertyChanged(BackgroundImageActualWidthName)
            End If
        End Set
    End Property

    Public Property ImageContainerActualWidth() As Double
        Get
            Return _imageContainerActualWidth
        End Get
        Set(value As Double)
            If _imageContainerActualWidth <> value Then
                _imageContainerActualWidth = value
                Me.OnPropertyChanged(ImageContainerActualWidthName)
            End If
        End Set
    End Property
    Private _imageContainerActualWidth As Double

    Public Property ImageContainerActualHeight() As Double
        Get
            Return _imageContainerActualHeight
        End Get
        Set(value As Double)
            If _imageContainerActualHeight <> value Then
                _imageContainerActualHeight = value
                Me.OnPropertyChanged(ImageContainerActualHeightName)
            End If

        End Set
    End Property
    Private _imageContainerActualHeight As Double

    ' offsetXInpercent should be in the range of 0.0 - 1.0;
    Private _offsetXInPercent As Double
    Public Property OffsetXInPercent() As Double
        Get
            Return _offsetXInPercent
        End Get
        Set(value As Double)
            If _offsetXInPercent <> value Then
                _offsetXInPercent = value
                Me.OnPropertyChanged(OffsetXInpercentName)
            End If
        End Set
    End Property

    ' offsetYInpercent should be in the range in the range of 0.0 - 1.0;
    Private _offsetYInPercent As Double
    Public Property OffsetYInPercent() As Double
        Get
            Return _offsetYInPercent
        End Get
        Set(value As Double)
            If _offsetYInPercent <> value Then
                _offsetYInPercent = value
                Me.OnPropertyChanged(OffsetYInpercentName)
            End If
        End Set
    End Property

    Private _startPointOffsetX As Double
    Public Property StartPointOffsetX() As Double
        Get
            Return _startPointOffsetX
        End Get
        Set(value As Double)
            If _startPointOffsetX <> value Then
                _startPointOffsetX = value
                Me.OnPropertyChanged(StartPointOffsetXName)
            End If
        End Set
    End Property

    Private _startPointOffsetY As Double
    Public Property StartPointOffsetY() As Double
        Get
            Return _startPointOffsetY
        End Get
        Set(value As Double)
            If _startPointOffsetY <> value Then
                _startPointOffsetY = value
                Me.OnPropertyChanged(StartPointOffsetYName)
            End If
        End Set
    End Property

    Protected Overridable Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))

        If propertyName = OffsetXInpercentName OrElse propertyName = BackgroundImageActualWidthName OrElse propertyName = ImageContainerActualWidthName Then
            UpdateStartPointOffsetX()
        ElseIf propertyName = OffsetYInpercentName OrElse propertyName = BackgroundImageActualHeightName OrElse propertyName = ImageContainerActualHeightName Then
            UpdateStartPointOffsetY()
        End If
    End Sub

    Private Sub UpdateStartPointOffsetX()
        ' Update StartPointOffsetX 
        Dim offsetX As Double = (ImageContainerActualWidth - BackgroundImageActualWidth) / 2.0
        StartPointOffsetX = offsetX + BackgroundImageActualWidth * _offsetXInPercent
    End Sub

    Private Sub UpdateStartPointOffsetY()
        ' Update StartPointOffsetY
        Dim offsetY As Double = (ImageContainerActualHeight - BackgroundImageActualHeight) / 2.0
        StartPointOffsetY = offsetY + BackgroundImageActualHeight * _offsetYInPercent

    End Sub

End Class


