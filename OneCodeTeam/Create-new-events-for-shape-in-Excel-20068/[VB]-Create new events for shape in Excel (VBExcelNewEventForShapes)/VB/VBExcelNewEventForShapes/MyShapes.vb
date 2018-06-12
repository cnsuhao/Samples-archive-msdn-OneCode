'\****************************** Module Header ******************************\
' Module Name:   MyShapes.vb
' Project:       VBExcelNewEventForShapes
' Copyright (c)  Microsoft Corporation.
' 
' This Class represents the collection of Excel.Shape Object
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx..
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Public Class MyShapes

    ' Collection of Excel.Shape Object
    Private myShapes As List(Of MyShape) = Nothing

    ''' <summary>
    ''' Constructor function without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        myShapes = New List(Of MyShape)()
    End Sub

    ''' <summary>
    ''' Constructor function
    ''' </summary>
    ''' <param name="shapes">Collection of Shape</param>
    ''' <remarks></remarks>
    Public Sub New(shapes As List(Of MyShape))
        myShapes = shapes
    End Sub

    ''' <summary>
    ''' Constructor function
    ''' </summary>
    ''' <param name="shapeSource">Worksheet Object</param>
    ''' <remarks></remarks>
    Public Sub New(shapeSource As Excel._Worksheet)
        InitializeListOfShapes(shapeSource.Shapes)
    End Sub

    ' Count Property of Shapes
    ' Use this property to detect creating or deleting shape event
    Public ReadOnly Property Count() As Integer
        Get
            Return myShapes.Count
        End Get
    End Property

    ' Initialize Shapes List
    Private Sub InitializeListOfShapes(shapes As Excel.Shapes)
        myShapes = New List(Of MyShape)()
        For i As Integer = 1 To shapes.Count
            Dim shape As Excel.Shape = shapes.Item(i)
            Dim myShape As New MyShape(shape)
            myShapes.Add(myShape)
        Next
    End Sub

    ''' <summary>
    ''' Verify Shapes Collection whether contain a shape
    ''' </summary>
    ''' <param name="id">Shape Id</param>
    ''' <returns>If Contain an same shape return true,else return false</returns>
    Public Function Contains(id As Integer) As Boolean
        For Each aShape As MyShape In myShapes
            If aShape.ID = id Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Get Created Shape Collection or Removed Shape Collection
    ''' </summary>
    ''' <param name="shapesToCheck">Shapes Collections to be Checked</param>
    ''' <returns>Return ShapesCreated Collection or ShapesRemoved</returns>
    Public Function GetShapesMissingIn(shapesToCheck As MyShapes) As MyShapes
        Dim newShapes As New MyShapes()
        For Each shape As MyShape In myShapes
            If shapesToCheck Is Nothing OrElse Not shapesToCheck.Contains(shape.ID) Then
                newShapes.Add(shape)
            End If
        Next
        Return newShapes
    End Function

    ' Add Shape Method
    Public Sub Add(shapeToAdd As MyShape)
        myShapes.Add(shapeToAdd)
    End Sub

    ' Remove Shape Method
    Public Sub Remove(shapeToRemove As MyShape)
        myShapes.Remove(shapeToRemove)
    End Sub

End Class
