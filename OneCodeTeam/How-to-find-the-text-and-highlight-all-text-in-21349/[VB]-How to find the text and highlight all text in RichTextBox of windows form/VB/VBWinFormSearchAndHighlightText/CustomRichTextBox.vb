'****************************** Module Header ******************************\
' Module Name:      CustomRichTextBox.cs
' Project:                   CSWinFormSearchAndHighlightText
' Copyright(c)          Microsoft Corporation.
' 
' Theclass is used to create custom RichTextBox.
' The custom RichTextBox adds custom Highlight and ClearHighlight methods.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

''' <summary>
'''  Custom RichTextBox control
''' </summary>
Partial Public Class CustomRichTextBox
    Inherits RichTextBox
    
    ''' <summary>
    '''  Search and Highlight all text in RichTextBox Control 
    ''' </summary>
    ''' <param name="findWhat">Find What</param>
    ''' <param name="highlightColor">Highlight Color</param>
    ''' <param name="ismatchCase">Is Match Case</param>
    ''' <param name="ismatchWholeWord">Is Match Whole Word</param>
    ''' <returns></returns>
    Public Function Highlight(findWhat As String, highlightColor As Color, ismatchCase As Boolean, ismatchWholeWord As Boolean) As Boolean
        ' Clear all highlights before searching text again
        ClearHighlight()

        Dim startSearch As Integer = 0
        'int searchLength = findWhat.Length;
        Dim findoptions As RichTextBoxFinds = Nothing

        ' Setup the search options.
        If ismatchCase AndAlso ismatchWholeWord Then
            findoptions = RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord
        ElseIf ismatchCase Then
            findoptions = RichTextBoxFinds.MatchCase
        ElseIf ismatchWholeWord Then
            findoptions = RichTextBoxFinds.WholeWord
        Else
            findoptions = RichTextBoxFinds.None
        End If

        ' detect whether search text exists in richtextbox
        Dim isfind As Boolean = False
        Dim index As Integer = -1

        ' Search text in RichTextBox and highlight them with color.
        While (InlineAssignHelper(index, Me.Find(findWhat, startSearch, findoptions))) > -1
            isfind = True

            Me.SelectionBackColor = highlightColor

            ' Continue after the one we searched
            startSearch = index + 1
        End While

        ' If the text exist in RichTextBox control, then return true, otherwise, return false
        Return isfind
    End Function

    ''' <summary>
    '''  Clear all Highlights 
    ''' </summary>
    Private Sub ClearHighlight()
        Me.SelectAll()
        Me.SelectionBackColor = Color.White
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class
