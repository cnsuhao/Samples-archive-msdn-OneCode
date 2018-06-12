'****************************** Module Header ******************************\
' Module Name:  HighlightTextBlock.vb
' Project:      ListBox_HighlightMatchString
' Copyright (c) Microsoft Corporation.
'
' Custom control class to enable options of highlighting.
'
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class HighlightTextBlock
    Inherits TextBlock
#Region "DependencyProperty"

    ' Background color for highlighting matching text.
    Public Shared HighlightBackgroundProperty As DependencyProperty = DependencyProperty.Register("HighlightBackground", GetType(Brush), GetType(HighlightTextBlock))

    Public Property HighlightBackground() As Brush
        Get
            Return DirectCast(GetValue(HighlightBackgroundProperty), Brush)
        End Get
        Set(value As Brush)
            SetValue(HighlightBackgroundProperty, value)
        End Set
    End Property

    ' Foreground color for highlighting matching text.
    Public Shared HighlightForegroundProperty As DependencyProperty = DependencyProperty.Register("HighlightForeground", GetType(Brush), GetType(HighlightTextBlock))

    Public Property HighlightForeground() As Brush
        Get
            Return DirectCast(GetValue(HighlightForegroundProperty), Brush)
        End Get
        Set(value As Brush)
            SetValue(HighlightForegroundProperty, value)
        End Set
    End Property

    ' Text to be highlighted.
    Public Shared HighlightTextroperty As DependencyProperty = DependencyProperty.Register("HighlightText", GetType([String]), GetType(HighlightTextBlock), New PropertyMetadata(New PropertyChangedCallback(AddressOf HighlightTextChanged)))

    Public Property HighlightText() As [String]
        Get
            Return DirectCast(GetValue(HighlightTextroperty), [String])
        End Get
        Set(value As [String])
            SetValue(HighlightTextroperty, value)
        End Set
    End Property

    'Is text matching case sensitive.
    Public Shared MatchCaseProperty As DependencyProperty = DependencyProperty.Register("MatchCase", GetType([Boolean]), GetType(HighlightTextBlock))

    Public Property MatchCase() As [Boolean]
        Get
            Return DirectCast(GetValue(MatchCaseProperty), [Boolean])
        End Get
        Set(value As [Boolean])
            SetValue(MatchCaseProperty, value)
        End Set
    End Property

    'Should we match the complete word.
    Public Shared MatchWholeWordProperty As DependencyProperty = DependencyProperty.Register("MatchWholeWord", GetType([Boolean]), GetType(HighlightTextBlock), New PropertyMetadata(New PropertyChangedCallback(AddressOf MatchWholeWordPropertyChanged)))

    Public Property MatchWholeWord() As [Boolean]
        Get
            Return DirectCast(GetValue(MatchWholeWordProperty), [Boolean])
        End Get
        Set(value As [Boolean])
            SetValue(MatchWholeWordProperty, value)
        End Set
    End Property


#End Region

#Region "Property"

    Private Highlighted As Boolean

#End Region

#Region "Method"

    ''' <summary>
    ''' Callback method when user search is changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Shared Sub HighlightTextChanged(sender As DependencyObject, e As DependencyPropertyChangedEventArgs)
        'getting the current instance of Textblock
        Dim tb As HighlightTextBlock = TryCast(sender, HighlightTextBlock)

        Dim completeText As String = tb.Text.Trim()
        Dim searchText As String = e.NewValue.ToString().Trim()

        'Check if string case hase to be considered.
        If Not tb.MatchCase Then
            completeText = completeText.ToLower()
            searchText = searchText.ToLower()
        End If

        'Check if we need to compare the whole word.
        If tb.MatchWholeWord Then
            If completeText <> String.Empty Then
                'when the condition is true, 
                'set the highlight color specified by customer.
                If completeText = searchText Then
                    ' we swap the colors so reset when no search text is passed.
                    Swap(tb)
                    tb.Highlighted = True
                Else
                    If tb.Highlighted Then
                        Swap(tb)
                        tb.Highlighted = False
                    End If
                End If
            End If
        Else
            Dim endIndex As Integer = completeText.Length
            Dim highlightStartIndex As Integer = completeText.IndexOf(searchText)

            completeText = tb.Text.Trim()

            tb.Inlines.Clear()
            If highlightStartIndex >= 0 Then
                Dim highlightTextLength As Integer = searchText.Length
                Dim highlightEndIndex As Integer = highlightStartIndex + highlightTextLength

                tb.Inlines.Add(completeText.Substring(0, highlightStartIndex))
                Dim newRun As New Run
                With newRun
                    .Text = completeText.Substring(highlightStartIndex, highlightTextLength)
                    .Foreground = tb.HighlightForeground
                    .Background = tb.HighlightBackground
                End With

                tb.Inlines.Add(newRun)

                tb.Inlines.Add(completeText.Substring(highlightEndIndex, endIndex - highlightEndIndex))
            Else
                tb.Inlines.Add(completeText)
            End If
        End If
    End Sub

    Private Shared Sub Swap(tb As HighlightTextBlock)
        Dim temp As Brush

        temp = tb.Background
        tb.Background = tb.HighlightBackground
        tb.HighlightBackground = temp

        temp = tb.Foreground
        tb.Foreground = tb.HighlightForeground
        tb.HighlightForeground = temp

        temp = Nothing
    End Sub

    Private Shared Sub MatchWholeWordPropertyChanged(sender As DependencyObject, e As DependencyPropertyChangedEventArgs)
        'getting the current instance of Textblock
        Dim tb As HighlightTextBlock = TryCast(sender, HighlightTextBlock)

        If Not CBool(e.NewValue) Then
            If tb.Highlighted Then
                Swap(tb)
                tb.Highlighted = False
            End If
        End If
    End Sub

#End Region
End Class

