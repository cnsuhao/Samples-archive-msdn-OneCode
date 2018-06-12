'\****************************** Module Header ******************************\
'Module Name:   MyShape.vb
' Project:      VBExcelNewEventForShapes
' Copyright (c) Microsoft Corporation.
' 
' This Class represents Excel.Shape Object
' We can get and set the properties of Excel.Shape via this Class.
'
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Public Class MyShape

#Region "Private Fields"

    Private _name As String
    Private _id As Integer
    Private _top As Double
    Private _left As Double
    Private _height As Double
    Private _width As Double

#End Region

#Region "Properties"

    ' Name Property of Excel.Shape Object
    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    ' ID Property of Excel.Shape Object
    ' We can compare the ID of the Shape to detect selection change
    Public ReadOnly Property ID() As Integer
        Get
            Return _id
        End Get
    End Property

    ' We can compare the Top or Left Property of Shape to detect shape's position change
    ' The distance from the top edge of Excel.Shape Object
    Public ReadOnly Property Top() As Double
        Get
            Return _top
        End Get
    End Property

    ' The distance from the left edge of Excel.Shape Object
    Public ReadOnly Property Left() As Double
        Get
            Return _left
        End Get
    End Property

    ' We can compare the Height or Width Property of Shape to detect shape's Size change
    ' Height of Excel.Shape Object
    Public ReadOnly Property Height() As Double
        Get
            Return _height
        End Get
    End Property

    ' Width of Excel.Shape Object
    Public ReadOnly Property Width() As Double
        Get
            Return _width
        End Get
    End Property

#End Region

    ' Constructor Method
    Public Sub New(ByVal shape As Excel.Shape)
        _name = shape.Name
        _id = shape.ID
        Update(shape)
    End Sub

    ' Update Shape Position and Size
    Public Sub Update(ByVal shape As Excel.Shape)
        _top = shape.Top
        _left = shape.Left
        _height = shape.Height
        _width = shape.Width
        _name = shape.Name
    End Sub

End Class
