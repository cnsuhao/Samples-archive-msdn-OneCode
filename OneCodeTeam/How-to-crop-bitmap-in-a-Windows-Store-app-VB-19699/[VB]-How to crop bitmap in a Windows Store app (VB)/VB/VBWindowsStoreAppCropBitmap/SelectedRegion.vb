'************************** Module Header ******************************\
' Module Name:  SelectedRegion.vb
' Project:      VBWindowsStoreAppCropBitmap
' Copyright (c) Microsoft Corporation.
' 
' This class represents the selected region. It implements the INotifyPropertyChanged
' interface and can be bound to the Xaml element
'  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************

Imports System
Imports System.ComponentModel
Imports System.Linq
Imports Windows.Foundation

Public Class SelectedRegion
    Implements INotifyPropertyChanged
    Private Const TopLeftCornerCanvasLeftPropertyName As String = "TopLeftCornerCanvasLeft"
    Private Const TopLeftCornerCanvasTopPropertyName As String = "TopLeftCornerCanvasTop"
    Private Const BottomRightCornerCanvasLeftPropertyName As String = "BottomRightCornerCanvasLeft"
    Private Const BottomRightCornerCanvasTopPropertyName As String = "BottomRightCornerCanvasTop"
    Private Const OutterRectPropertyName As String = "OuterRect"
    Private Const SelectedRectPropertyName As String = "SelectedRect"

    Public Const TopLeftCornerName As String = "TopLeftCorner"
    Public Const TopRightCornerName As String = "TopRightCorner"
    Public Const BottomLeftCornerName As String = "BottomLeftCorner"
    Public Const BottomRightCornerName As String = "BottomRightCorner"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' The minimun size of the seleced region
    ''' </summary>
    Public Property MinSelectRegionSize() As Double

    Private _topLeftCornerCanvasLeft As Double

    ''' <summary>
    ''' The Canvas.Left property of the TopLeft corner.
    ''' </summary>
    Public Property TopLeftCornerCanvasLeft() As Double
        Get
            Return _topLeftCornerCanvasLeft
        End Get
        Protected Set(ByVal value As Double)
            If _topLeftCornerCanvasLeft <> value Then
                _topLeftCornerCanvasLeft = value
                Me.OnPropertyChanged(TopLeftCornerCanvasLeftPropertyName)
            End If
        End Set
    End Property

    Private _topLeftCornerCanvasTop As Double

    ''' <summary>
    ''' The Canvas.Top property of the TopLeft corner.
    ''' </summary>
    Public Property TopLeftCornerCanvasTop() As Double
        Get
            Return _topLeftCornerCanvasTop
        End Get
        Protected Set(ByVal value As Double)
            If _topLeftCornerCanvasTop <> value Then
                _topLeftCornerCanvasTop = value
                Me.OnPropertyChanged(TopLeftCornerCanvasTopPropertyName)
            End If
        End Set
    End Property

    Private _bottomRightCornerCanvasLeft As Double

    ''' <summary>
    ''' The Canvas.Left property of the BottomRight corner.
    ''' </summary>
    Public Property BottomRightCornerCanvasLeft() As Double
        Get
            Return _bottomRightCornerCanvasLeft
        End Get
        Protected Set(ByVal value As Double)
            If _bottomRightCornerCanvasLeft <> value Then
                _bottomRightCornerCanvasLeft = value

                Me.OnPropertyChanged(BottomRightCornerCanvasLeftPropertyName)
            End If
        End Set
    End Property

    Private _bottomRightCornerCanvasTop As Double

    ''' <summary>
    ''' The Canvas.Top property of the BottomRight corner.
    ''' </summary>
    Public Property BottomRightCornerCanvasTop() As Double
        Get
            Return _bottomRightCornerCanvasTop
        End Get
        Protected Set(ByVal value As Double)
            If _bottomRightCornerCanvasTop <> value Then
                _bottomRightCornerCanvasTop = value
                Me.OnPropertyChanged(BottomRightCornerCanvasTopPropertyName)
            End If
        End Set
    End Property

    Private _outerRect As Rect

    ''' <summary>
    ''' The outer rect. The non-selected region can be represented by the 
    ''' OuterRect and the SelectedRect.
    ''' </summary>
    Public Property OuterRect() As Rect
        Get
            Return _outerRect
        End Get
        Set(ByVal value As Rect)
            If _outerRect <> value Then
                _outerRect = value

                Me.OnPropertyChanged(OutterRectPropertyName)
            End If
        End Set
    End Property

    Private _selectedRect As Rect

    ''' <summary>
    ''' The selected region, which is represented by the four corners.
    ''' </summary>
    Public Property SelectedRect() As Rect
        Get
            Return _selectedRect
        End Get
        Protected Set(ByVal value As Rect)
            If _selectedRect <> value Then
                _selectedRect = value

                Me.OnPropertyChanged(SelectedRectPropertyName)
            End If
        End Set
    End Property

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))

        ' When the corner is moved, update the SelectedRect.
        If propertyName = TopLeftCornerCanvasLeftPropertyName OrElse
            propertyName = TopLeftCornerCanvasTopPropertyName OrElse
            propertyName = BottomRightCornerCanvasLeftPropertyName OrElse
            propertyName = BottomRightCornerCanvasTopPropertyName Then
            SelectedRect = New Rect(TopLeftCornerCanvasLeft,
                                    TopLeftCornerCanvasTop,
                                    BottomRightCornerCanvasLeft - TopLeftCornerCanvasLeft,
                                    BottomRightCornerCanvasTop - TopLeftCornerCanvasTop)
        End If
    End Sub


    Public Sub ResetCorner(ByVal topLeftCornerCanvasLeft As Double,
                           ByVal topLeftCornerCanvasTop As Double,
                           ByVal bottomRightCornerCanvasLeft As Double,
                           ByVal bottomRightCornerCanvasTop As Double)
        Me.TopLeftCornerCanvasLeft = topLeftCornerCanvasLeft
        Me.TopLeftCornerCanvasTop = topLeftCornerCanvasTop
        Me.BottomRightCornerCanvasLeft = bottomRightCornerCanvasLeft
        Me.BottomRightCornerCanvasTop = bottomRightCornerCanvasTop
    End Sub

    ''' <summary>
    ''' Update the Canvas.Top and Canvas.Left of the corner.
    ''' </summary>
    Public Sub UpdateCorner(ByVal cornerName As String,
                            ByVal leftUpdate As Double,
                            ByVal topUpdate As Double)
        UpdateCorner(cornerName, leftUpdate, topUpdate,
                     Me.MinSelectRegionSize, Me.MinSelectRegionSize)
    End Sub

    ''' <summary>
    ''' Update the Canvas.Top and Canvas.Left of the corner.
    ''' </summary>
    Public Sub UpdateCorner(ByVal cornerName As String,
                            ByVal leftUpdate As Double,
                            ByVal topUpdate As Double,
                            ByVal minWidthSize As Double,
                            ByVal minHeightSize As Double)
        Select Case cornerName
            Case SelectedRegion.TopLeftCornerName
                TopLeftCornerCanvasLeft = ValidateValue(
                    _topLeftCornerCanvasLeft + leftUpdate,
                    0,
                    _bottomRightCornerCanvasLeft - minWidthSize)

                TopLeftCornerCanvasTop = ValidateValue(
                    _topLeftCornerCanvasTop + topUpdate,
                    0,
                    _bottomRightCornerCanvasTop - minHeightSize)

            Case SelectedRegion.TopRightCornerName
                BottomRightCornerCanvasLeft = ValidateValue(
                    _bottomRightCornerCanvasLeft + leftUpdate,
                    _topLeftCornerCanvasLeft + minWidthSize,
                    _outerRect.Width)

                TopLeftCornerCanvasTop = ValidateValue(
                    _topLeftCornerCanvasTop + topUpdate,
                    0,
                    _bottomRightCornerCanvasTop - minHeightSize)

            Case SelectedRegion.BottomLeftCornerName
                TopLeftCornerCanvasLeft = ValidateValue(
                    _topLeftCornerCanvasLeft + leftUpdate,
                    0,
                    _bottomRightCornerCanvasLeft - minWidthSize)

                BottomRightCornerCanvasTop = ValidateValue(
                    _bottomRightCornerCanvasTop + topUpdate,
                    _topLeftCornerCanvasTop + minHeightSize,
                    _outerRect.Height)

            Case SelectedRegion.BottomRightCornerName
                BottomRightCornerCanvasLeft = ValidateValue(
                    _bottomRightCornerCanvasLeft + leftUpdate,
                    _topLeftCornerCanvasLeft + minWidthSize,
                    _outerRect.Width)

                BottomRightCornerCanvasTop = ValidateValue(
                    _bottomRightCornerCanvasTop + topUpdate,
                    _topLeftCornerCanvasTop + minHeightSize,
                    _outerRect.Height)

            Case Else
                Throw New ArgumentException("cornerName: " &
                                            cornerName &
                                            "  is not recognized.")
        End Select

    End Sub

    Private Function ValidateValue(ByVal tempValue As Double,
                                   ByVal fromValue As Double,
                                   ByVal toValue As Double) As Double
        If tempValue < fromValue Then
            tempValue = fromValue
        End If

        If tempValue > toValue Then
            tempValue = toValue
        End If

        Return tempValue
    End Function

    ''' <summary>
    ''' Update the SelectedRect when it is moved or scaled.
    ''' </summary>
    Public Sub UpdateSelectedRect(ByVal scale As Double,
                                  ByVal leftUpdate As Double,
                                  ByVal topUpdate As Double)
        Dim width As Double = _bottomRightCornerCanvasLeft - _topLeftCornerCanvasLeft
        Dim height As Double = _bottomRightCornerCanvasTop - _topLeftCornerCanvasTop

        Dim scaledLeftUpdate As Double =
            (_bottomRightCornerCanvasLeft - _topLeftCornerCanvasLeft) * (scale - 1) / 2
        Dim scaledTopUpdate As Double =
            (_bottomRightCornerCanvasTop - _topLeftCornerCanvasTop) * (scale - 1) / 2

        Dim minWidth As Double = Math.Max(Me.MinSelectRegionSize, width * scale)
        Dim minHeight As Double = Math.Max(Me.MinSelectRegionSize, height * scale)


        If scale <> 1 Then
            Me.UpdateCorner(SelectedRegion.TopLeftCornerName,
                            -scaledLeftUpdate,
                            -scaledTopUpdate)

            Me.UpdateCorner(SelectedRegion.BottomRightCornerName,
                            scaledLeftUpdate,
                            scaledTopUpdate)
        End If

        ' Move towards BottomRight: Move BottomRightCorner first, and then move TopLeftCorner.
        If leftUpdate >= 0 AndAlso topUpdate >= 0 Then
            Me.UpdateCorner(SelectedRegion.BottomRightCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            Me.UpdateCorner(SelectedRegion.TopLeftCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            ' Move towards TopRight: Move TopRightCorner first, and then move BottomLeftCorner.
        ElseIf leftUpdate >= 0 AndAlso topUpdate < 0 Then
            Me.UpdateCorner(SelectedRegion.TopRightCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            Me.UpdateCorner(SelectedRegion.BottomLeftCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            ' Move towards BottomLeft: Move BottomLeftCorner first, and then move TopRightCorner.
        ElseIf leftUpdate < 0 AndAlso topUpdate >= 0 Then
            Me.UpdateCorner(SelectedRegion.BottomLeftCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            Me.UpdateCorner(SelectedRegion.TopRightCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            ' Move towards TopLeft: Move TopLeftCorner first, and then move BottomRightCorner.
        ElseIf leftUpdate < 0 AndAlso topUpdate < 0 Then
            Me.UpdateCorner(SelectedRegion.TopLeftCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)

            Me.UpdateCorner(SelectedRegion.BottomRightCornerName,
                            leftUpdate,
                            topUpdate,
                            minWidth,
                            minHeight)
        End If
    End Sub

    ''' <summary>
    ''' Resize the SelectedRect
    ''' </summary>
    ''' <param name="scale"></param>
    Public Sub ResizeSelectedRect(ByVal scale As Double)
        If scale > 1 Then
            Me.BottomRightCornerCanvasLeft = Me.BottomRightCornerCanvasLeft * scale
            Me.BottomRightCornerCanvasTop = Me.BottomRightCornerCanvasTop * scale
            Me.TopLeftCornerCanvasLeft = Me.TopLeftCornerCanvasLeft * scale
            Me.TopLeftCornerCanvasTop = Me.TopLeftCornerCanvasTop * scale
        Else
            Me.TopLeftCornerCanvasLeft = Me.TopLeftCornerCanvasLeft * scale
            Me.TopLeftCornerCanvasTop = Me.TopLeftCornerCanvasTop * scale
            Me.BottomRightCornerCanvasLeft = Me.BottomRightCornerCanvasLeft * scale
            Me.BottomRightCornerCanvasTop = Me.BottomRightCornerCanvasTop * scale
        End If

    End Sub
End Class