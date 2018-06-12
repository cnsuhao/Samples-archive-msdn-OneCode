'******************************** Module Header ***********************************\
' Module Name:  SearchableTextControl.vb
' Project:      VBWPFSearchAndHighlightTextBlockControl
' Copyright (c) Microsoft Corporation.
'
' The SearchableTextControl.vb file defines a User Control Class in order to search for
' keyword and highlight it when the operation gets the result.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**********************************************************************************/

Public Class SearchableTextControl
    Inherits Control
    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(SearchableTextControl),
                                                 New FrameworkPropertyMetadata(GetType(SearchableTextControl)))
    End Sub

#Region "DependencyProperties"
    ''' <summary>
    ''' Text sandbox which is used to get or set the value from a dependency property.
    ''' </summary>
    Public Property Text() As String
        Get
            Return CStr(GetValue(TextProperty))
        End Get
        Set(ByVal value As String)
            SetValue(TextProperty, value)
        End Set
    End Property


    ' Real implementation about TextProperty which registers a dependency property with 
    ' the specified property name, property type, owner type, and property metadata. 
    Public Shared ReadOnly TextProperty As DependencyProperty =
        DependencyProperty.Register("Text", GetType(String), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(String.Empty, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' HighlightBackground sandbox which is used to get or set the value from a dependency property,
    ''' if getting value,it should be forced to bind to a Brushes type.
    ''' </summary>
    Public Property HighlightBackground() As Brush
        Get
            Return CType(GetValue(HighlightBackgroundProperty), Brush)
        End Get
        Set(ByVal value As Brush)
            SetValue(HighlightBackgroundProperty, value)
        End Set
    End Property


    ' Real implementation about HighlightBackgroundProperty which  registers a dependency property with
    ' the specified property name, property type, owner type, and property metadata. 
    Public Shared ReadOnly HighlightBackgroundProperty As DependencyProperty =
        DependencyProperty.Register("HighlightBackground", GetType(Brush), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(Brushes.Yellow, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' HighlightForeground sandbox which is used to get or set the value from a dependency property,
    ''' if it gets a value,it should be forced to bind to a Brushes type.
    ''' </summary>
    Public Property HighlightForeground() As Brush
        Get
            Return CType(GetValue(HighlightForegroundProperty), Brush)
        End Get
        Set(ByVal value As Brush)
            SetValue(HighlightForegroundProperty, value)
        End Set
    End Property


    ' Real implementation about HighlightForegroundProperty which  registers a dependency property with
    ' the specified property name, property type, owner type, and property metadata. 
    Public Shared ReadOnly HighlightForegroundProperty As DependencyProperty =
        DependencyProperty.Register("HighlightForeground", GetType(Brush), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(Brushes.Black, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' IsMatchCase sandbox which is used to get or set the value from a dependency property,
    ''' if it gets a value,it should be forced to bind to a bool type.
    ''' </summary>
    Public Property IsMatchCase() As Boolean
        Get
            Return CBool(GetValue(IsMatchCaseProperty))
        End Get
        Set(ByVal value As Boolean)
            SetValue(IsMatchCaseProperty, value)
        End Set
    End Property

    ' Real implementation about IsMatchCaseProperty which  registers a dependency property with 
    ' the specified property name, property type, owner type, and property metadata. 
    Public Shared ReadOnly IsMatchCaseProperty As DependencyProperty =
        DependencyProperty.Register("IsMatchCase", GetType(Boolean), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(True, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' IsHighlight sandbox which is used to get or set the value from a dependency property,
    ''' if it gets a value,it should be forced to bind to a bool type.
    ''' </summary>
    Public Property IsHighlight() As Boolean
        Get
            Return CBool(GetValue(IsHighlightProperty))
        End Get
        Set(ByVal value As Boolean)
            SetValue(IsHighlightProperty, value)
        End Set
    End Property

    ' Real implementation about IsHighlightProperty which registers a dependency property with 
    ' the specified property name, property type, owner type, and property metadata. 
    Public Shared ReadOnly IsHighlightProperty As DependencyProperty =
        DependencyProperty.Register("IsHighlight", GetType(Boolean), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(False, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' SearchText sandbox which is used to get or set the value from  a dependency property,
    ''' if it gets a value,it should be forced to bind to a string type.
    ''' </summary>
    Public Property SearchText() As String
        Get
            Return CStr(GetValue(SearchTextProperty))
        End Get
        Set(ByVal value As String)
            SetValue(SearchTextProperty, value)
        End Set
    End Property

    ''' <summary>
    ''' Real implementation about SearchTextProperty which registers a dependency property with
    ''' the specified property name, property type, owner type, and property metadata. 
    ''' </summary>
    Public Shared ReadOnly SearchTextProperty As DependencyProperty =
        DependencyProperty.Register("SearchText", GetType(String), GetType(SearchableTextControl),
                                    New UIPropertyMetadata(String.Empty, AddressOf UpdateControlCallBack))

    ''' <summary>
    ''' Create a call back function which is used to invalidate the rendering of the element, and force 
    ''' a complete new layout pass. One such advanced scenario is if you are creating a PropertyChangedCallback 
    ''' for a dependency property that is not on a Freezable or FrameworkElement derived class that 
    ''' still influences the layout when it changes.
    ''' </summary>
    Private Shared Sub UpdateControlCallBack(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim obj As SearchableTextControl = TryCast(d, SearchableTextControl)
        obj.InvalidateVisual()
    End Sub

#End Region

    ''' <summary>
    ''' override the OnRender method which is used to search for the keyword and highlight it when 
    ''' the operation gets the result.
    ''' </summary>
    Protected Overrides Sub OnRender(ByVal drawingContext_Renamed As DrawingContext)

        ' Define a TextBlock which is search result using FindName method.
        Dim displayTextBlock As TextBlock = TryCast(Me.Template.FindName("PART_TEXT", Me), TextBlock)

        If String.IsNullOrEmpty(Me.Text) Then
            MyBase.OnRender(drawingContext_Renamed)
            Return
        End If
        If Not Me.IsHighlight Then
            displayTextBlock.Text = Me.Text
            MyBase.OnRender(drawingContext_Renamed)
            Return
        End If

        displayTextBlock.Inlines.Clear()
        Dim searchstring As String = If(Me.IsMatchCase, CStr(Me.SearchText), (CStr(Me.SearchText)).ToUpper())

        Dim compareText As String = If(Me.IsMatchCase, Me.Text, Me.Text.ToUpper())
        Dim displayText As String = Me.Text

        Dim run_Renamed As Run = Nothing
        Do While (Not String.IsNullOrEmpty(searchstring)) AndAlso compareText.IndexOf(searchstring) >= 0
            Dim position As Integer = compareText.IndexOf(searchstring)

            run_Renamed = GenerateRun(displayText.Substring(0, position), False)
            If run_Renamed IsNot Nothing Then
                displayTextBlock.Inlines.Add(run_Renamed)
            End If
            run_Renamed = GenerateRun(displayText.Substring(position, searchstring.Length), True)
            If run_Renamed IsNot Nothing Then
                displayTextBlock.Inlines.Add(run_Renamed)
            End If

            compareText = compareText.Substring(position + searchstring.Length)
            displayText = displayText.Substring(position + searchstring.Length)
        Loop
        run_Renamed = GenerateRun(displayText, False)
        If run_Renamed IsNot Nothing Then
            displayTextBlock.Inlines.Add(run_Renamed)
        End If

        MyBase.OnRender(drawingContext_Renamed)
    End Sub


    ''' <summary>
    ''' Set inline-level flow content element intended to contain a run of formatted
    ''' or unformatted text into your background and foreground setting.
    ''' </summary>
    Private Function GenerateRun(ByVal searchedString As String, ByVal isHighlight As Boolean) As Run
        If Not String.IsNullOrEmpty(searchedString) Then
            Dim run_Renamed As New Run(searchedString) With {.Background =
                If(isHighlight, Me.HighlightBackground, Me.Background), .Foreground =
                If(isHighlight, Me.HighlightForeground, Me.Foreground),
                 .FontStyle = If(isHighlight, FontStyles.Italic, FontStyles.Normal
                                 ),
            .FontWeight = If(isHighlight, FontWeights.Bold, FontWeights.Normal
                                 )
                   }


            Return run_Renamed
        End If
        Return Nothing
    End Function
End Class


