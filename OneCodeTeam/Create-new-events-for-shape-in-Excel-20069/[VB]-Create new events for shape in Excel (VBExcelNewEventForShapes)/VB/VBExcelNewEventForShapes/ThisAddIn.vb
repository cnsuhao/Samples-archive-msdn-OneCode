'/****************************** Module Header ******************************\
' Module Name:   ThisAddIn.vb
' Project:       VBExcelNewEventForShapes
' Copyright (c)  Microsoft Corporation.
' 
' This is a Add-in Class of Excel.
' The Excel object model doesn't have any events to control manipulations with shapes.
' The sample Add-in Project handles some events of Excel.shape Object
' and logs the events in custom task panel
' This Project creates four custom Events, they are: ShapeSelectionChange, ShapeRemoved, 
' ShapeCreated and ShapeMoved.
' 
' ShapeSelectionChange occurs when user changes selected shape.
' ShapeRemoved occurs when a shape is removed from the shapes collection of the current sheet.
' ShapeCreated occurs when a shape is added to the shapes collection of the current sheet.
' ShapeMoved occurs when a shape is moved.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx..
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Public Class ThisAddIn

#Region "define Variables"

    ' Define name of CommandBarButton
    Private Const StartJob As String = "Start checking shapes..."
    Private Const StopJob As String = "Stop checking shapes..."

    ' detect the CommandBarButton whether is working
    Private isWorking As Boolean = False

    ' CommandBars variable
    Private WithEvents commandBars As Office.CommandBars

    ' CommandBar variable
    ' Click commandBarbutton to start log shapes' events
    Private commandBarStart As Office.CommandBar
    Private WithEvents commandBarButtonStart As Office.CommandBarButton

    ' define a rectangle shape
    Private rectangleShape As MyShape

    ' define a circle shape
    Private circleShape As MyShape

    ' Task Panel object
    Private customTaskPanel As CustomTaskPanel

    ' previous Selected shape and current selected shape
    ' compare the ID in the two shape to detect Shapeselectionchange event
    Private shapeSelectedNow As MyShape = Nothing
    Private shapeSelectedLastTime As MyShape = Nothing

    ' previous existing shapes and current existing shapes
    ' commpare the Count property in the two shape collection to detect ShapeCreated and ShapeRemoved events
    Private shapesExistingNow As MyShapes = Nothing
    Private shapesExistingLastTime As MyShapes = Nothing

    ' Previous selected Type Name and current selected Type Name
    Dim selectedTypeNameLastTime As String = Nothing
    Dim selecteTypeNameNow As String = Nothing

#End Region

    ' Initialize Control
    Private Sub InitializeCustomComponents()

        ' Add a custom commandbar button and set the name is "Start checking shapes"
        commandBarStart = Me.Application.CommandBars.ActiveMenuBar

        ' Add the commandbar button into the commandbar
        commandBarButtonStart = DirectCast(commandBarStart.Controls.Add(Office.MsoControlType.msoControlButton, Before:=1, Temporary:=True), Office.CommandBarButton)
        commandBarButtonStart.Style = Office.MsoButtonStyle.msoButtonCaption
        commandBarButtonStart.Caption = StartJob
        commandBarButtonStart.FaceId = 60
        commandBarButtonStart.Visible = True

        commandBars = Me.Application.CommandBars

        ' Initialize Task Pane 
        ' set the Position and width of task panel 
        customTaskPanel = New CustomTaskPanel()
        Dim mycustomerTaskPane As Microsoft.Office.Tools.CustomTaskPane = Me.CustomTaskPanes.Add(customTaskPanel, "Custom Task Panel Tracking Event")
        mycustomerTaskPane.Visible = True
        mycustomerTaskPane.Width = 430
        mycustomerTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight

        ' Initialize Shapes in active worksheet
        Dim shapeworksheet As Excel.Worksheet = Me.Application.ActiveSheet
        Dim shapeRect As Excel.Shape
        Dim shapeCircle As Excel.Shape
        shapeRect = shapeworksheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 60, 80, 80, 30)
        shapeCircle = shapeworksheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, 200, 30, 50, 50)

        rectangleShape = New MyShape(shapeRect)
        circleShape = New MyShape(shapeCircle)

        ' Initialize Shapes  and Selected shape before the shapes change
        shapeSelectedLastTime = GetShapeSelected()
        shapesExistingLastTime = New MyShapes(shapeworksheet)

    End Sub

    ''' <summary>
    ''' CommandBarButton Click function
    ''' </summary>
    ''' <param name="cmdBarButton">CommandBarButton Object</param>
    ''' <param name="cancel"></param>
    ''' <remarks></remarks>
    Private Sub commandBarButtonStart_Click(cmdBarButton As Office.CommandBarButton, ByRef cancel As Boolean) Handles commandBarButtonStart.Click
        StartStop(Not isWorking)
    End Sub

    ''' <summary>
    ''' Start or Stop to log the events' message
    ''' </summary>
    ''' <param name="mode">true represent for logging events started,false is to stop log events</param>
    ''' <remarks></remarks>
    Private Sub StartStop(mode As Boolean)

        isWorking = mode
        If isWorking Then
            customTaskPanel.Clear()
            commandBarButtonStart.Caption = StopJob

            ' Get previous Selected Object and Type Name
            selectedTypeNameLastTime = GetSelectedTypeName()

            ' when User restarts to log events
            ' Must Initialize previous Selected shape and previous Existing shapes again
            FillCollections()
            shapesExistingLastTime = shapesExistingNow
            shapeSelectedLastTime = shapeSelectedNow

            ' Initialize previous Selected Object and Type Name again
            selectedTypeNameLastTime = selecteTypeNameNow
        Else
            commandBarButtonStart.Caption = StartJob

            ' Dispose object
            shapeSelectedLastTime = Nothing
            shapeSelectedNow = Nothing
            shapesExistingLastTime = Nothing
            shapesExistingNow = Nothing
            selectedTypeNameLastTime = Nothing
            selecteTypeNameNow = Nothing
        End If
    End Sub

    ''' <summary>
    ''' CommandBars Update function
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub commandBars_OnUpdate() Handles commandBars.OnUpdate
        If Not isWorking Then
            Return
        End If

        selecteTypeNameNow = GetSelectedTypeName()

        ' Initialize current Selected shape and  current Existing shapes
        FillCollections()

        ' Detect whether the custom events occur
        ProcessExistingShapes()
        ProcessSelectedShape()

        ' Initialize previous Selected shape and previous Existing shapes again
        shapesExistingLastTime = shapesExistingNow
        shapeSelectedLastTime = shapeSelectedNow

        ' Initialize previous Selected Object and Type Name again
        selectedTypeNameLastTime = selecteTypeNameNow
    End Sub

    ''' <summary>
    ''' Get Selected shape and Existing shapes
    ''' </summary>
    Private Sub FillCollections()
        If selecteTypeNameNow Is Nothing OrElse selectedTypeNameLastTime Is Nothing Then
            customTaskPanel.AddMessage("The type name of the selected object is " & selectedTypeNameLastTime)
        Else
            If selecteTypeNameNow <> selectedTypeNameLastTime Then
                customTaskPanel.AddMessage("The type name of the selected object is " & selecteTypeNameNow)
            End If
        End If

        ' Get the current selected shape and current existing shapes
        shapeSelectedNow = GetShapeSelected()
        shapesExistingNow = New MyShapes(TryCast(Me.Application.ActiveSheet, Excel._Worksheet))

        ' Get the current Selected Object and current Type Name
        selecteTypeNameNow = GetSelectedTypeName()
    End Sub

    ''' <summary>
    ''' Get Selected Type Name
    ''' </summary>
    ''' <returns>return Selected TypeName</returns>
    Private Function GetSelectedTypeName() As String
        Dim typename As String = Nothing
        Dim selection As Object = Me.Application.Selection
        If selection IsNot Nothing Then
            typename = Microsoft.VisualBasic.Information.TypeName(selection)
        End If

        Return typename
    End Function

    ''' <summary>
    ''' Get Selected Shape
    ''' </summary>
    ''' <returns>Return Selected Shape</returns>
    Private Function GetShapeSelected() As MyShape
        Dim selectedShape As Excel.Shape = Nothing
        Dim myselectedShape As MyShape = Nothing
        Dim selectedShapeRange As Excel.ShapeRange = Nothing
        Try
            selectedShapeRange = Me.Application.Selection.ShapeRange
        Catch
            If selecteTypeNameNow <> selectedTypeNameLastTime Then
                customTaskPanel.AddMessage("No shape is selected")
            End If
        End Try

        If selectedShapeRange IsNot Nothing Then
            selectedShape = TryCast(selectedShapeRange.Item(1), Excel.Shape)
            If selectedShape IsNot Nothing Then
                myselectedShape = New MyShape(selectedShape)
                Return myselectedShape
            End If
        End If

        Return myselectedShape
    End Function

    ''' <summary>
    ''' Analyze Existing Shapes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessExistingShapes()
        Dim _shapesCreated As MyShapes = shapesExistingNow.GetShapesMissingIn(shapesExistingLastTime)
        Dim _shapesRemoved As MyShapes = shapesExistingLastTime.GetShapesMissingIn(shapesExistingNow)

        ' If the count of Removed Shapes is not zero then ShapesRemoved Event Occurs.
        ' Also, the number of Removed Shapes will be shown in Task Panel.
        If _shapesRemoved.Count <> 0 Then
            ShapesRemoved(_shapesRemoved)
        End If
        If _shapesCreated.Count <> 0 Then
            ShapesCreated(_shapesCreated)
        End If
    End Sub

    ''' <summary>
    ''' Analyze Selected Shape
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessSelectedShape()
        If shapeSelectedLastTime Is Nothing OrElse shapeSelectedNow Is Nothing Then
            Return
        End If
        ' Compare previous selected shape's ID with current selected shape's ID
        ' to detect whether ShapeSelectionChange event occurs
        If shapeSelectedNow.ID <> shapeSelectedLastTime.ID Then
            Me.ShapeSelctionChange(shapeSelectedNow, shapeSelectedLastTime)
        Else
            ' Compare previous selected shape's top or left with current selected shape's top or left
            ' to detect whether ShapeMoved event occurs
            If shapeSelectedNow.Top <> shapeSelectedLastTime.Top OrElse shapeSelectedNow.Left <> shapeSelectedLastTime.Left Then
                Me.ShapeMoved(shapeSelectedNow)
            End If
        End If
    End Sub

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        InitializeCustomComponents()
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

#Region "Custom Events"

    ''' <summary>
    ''' Occurs when the user selected shape change
    ''' </summary>
    ''' <param name="newselectedshape">Selected shape Now</param>
    ''' <param name="preselectedshape">Selected shape Before</param>
    Private Sub ShapeSelctionChange(newselectedshape As MyShape, preselectedshape As MyShape)
        customTaskPanel.AddMessage("ShapeSelctionChange, Selection from " & Convert.ToString(preselectedshape.Name) & " to " & Convert.ToString(newselectedshape.Name))
    End Sub


    ''' <summary>
    ''' Occurs when a shape(s) is removed from the Shapes collection of the current sheet
    ''' </summary>
    ''' <param name="_shapesRemoved">The removed shapes</param>
    Private Sub ShapesRemoved(ByVal _shapesRemoved As MyShapes)
        customTaskPanel.AddMessage("ShapesRemoved Event Occurs." & _shapesRemoved.Count.ToString() & " shape(s) are removed from Sheet.Shapes.")
    End Sub

    ''' <summary>
    ''' Occurs when a shape is Created
    ''' </summary>
    ''' <param name="_shapesCreated">The Created shape</param>
    Private Sub ShapesCreated(ByVal _shapesCreated As MyShapes)
        customTaskPanel.AddMessage("ShapeCreated Event Occurs." & _shapesCreated.Count.ToString() & " shape(s) are added to the Sheet.Shapes collection.")
    End Sub

    ''' <summary>
    ''' Occurs when a shape is moved
    ''' </summary>
    ''' <param name="myshape">The moved shape</param>
    Private Sub ShapeMoved(myshape As MyShape)
        customTaskPanel.AddMessage("ShapeMoved Event Occurs, Shape.Name='" & Convert.ToString(myshape.Name) & "'")
    End Sub
#End Region

End Class
