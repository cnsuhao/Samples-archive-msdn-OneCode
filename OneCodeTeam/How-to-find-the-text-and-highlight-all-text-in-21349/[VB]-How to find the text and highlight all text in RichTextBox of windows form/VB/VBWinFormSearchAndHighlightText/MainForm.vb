'****************************** Module Header ******************************\
' Module Name: MainForm.cs
' Project:     CSWinFormSearchAndHighlightText
' Copyright(c) Microsoft Corporation.
' 
' The class is the main form.
' The users can manipulate the form to find the searched text and highlight them.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/


Public Class MainForm

    Public Sub New()
        InitializeComponent()

        ' Initialize the state of SearchAndHighlight button
        Me.btnSearchAndHighlight.Enabled = False
    End Sub

    ''' <summary>
    '''  Select Highlight color
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub panelColor_Click(sender As Object, e As EventArgs) Handles panelColor.Click
        Using colorDialog As New ColorDialog()
            colorDialog.Color = Me.panelColor.BackColor
            If colorDialog.ShowDialog() = DialogResult.OK Then
                Me.panelColor.BackColor = colorDialog.Color
            End If
        End Using
    End Sub

    ''' <summary>
    '''  Search the text and Highlight them in RichTextBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSearchAndHighlight_Click(sender As Object, e As EventArgs) Handles btnSearchAndHighlight.Click
        Dim isexist As Boolean = rtbSource.Highlight(cboSearch.Text, panelColor.BackColor, chkMatchCase.Checked, chkMatchWholeWord.Checked)

        If Not isexist Then
            Dim format As String = String.Format("Can't find the ""{0}"" in RichTextBox control", cboSearch.Text)
            MessageBox.Show(format)
        End If
        If Not cboSearch.Items.Contains(cboSearch.Text) Then
            Me.cboSearch.Items.Add(Me.cboSearch.Text)
        End If
    End Sub

    ''' <summary>
    '''  The Event for Text change in ComboBox Control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboSearch_TextChanged(sender As Object, e As EventArgs) Handles cboSearch.TextChanged
        ' Disable the SearchAndHightlight button
        If cboSearch.Text.Length = 0 Then
            Me.btnSearchAndHighlight.Enabled = False
        Else
            ' Enable the SearchAndHightlight button
            Me.btnSearchAndHighlight.Enabled = True
        End If
    End Sub

    ''' <summary>
    '''  Key Press event 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cboSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSearch.KeyPress
        If e.KeyChar = ChrW(13) Then
            btnSearchAndHighlight.PerformClick()
        End If
    End Sub

End Class
