'/****************************** Module Header ******************************\
' Module Name:  MainForm.vb
' Project:      VBOpenXmlGetPlainText
' Copyright(c)  Microsoft Corporation.
' 
' This is the main form of this application. It is used to initialize the UI and 
' handle the events.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/


Public Class MainForm
    Private getWordPlainText As GetWordPlainText = Nothing

    Public Sub New()
        InitializeComponent()
        Me.btnSaveas.Enabled = False
    End Sub

    ''' <summary>
    '''  Handle the btnOpen Click event to load an Word file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        SelectWordFile()
    End Sub

    ''' <summary>
    ''' Show an OpenFileDialog to select a Word document.
    ''' </summary>
    ''' <returns>
    ''' The file name.
    ''' </returns>
    Private Function SelectWordFile() As String
        Dim fileName As String = Nothing
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Word document (*.docx)|*.docx"
            dialog.InitialDirectory = Environment.CurrentDirectory

            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                fileName = dialog.FileName
                tbxFile.Text = dialog.FileName
                rtbText.Clear()
            End If
        End Using

        Return fileName
    End Function

    ''' <summary>
    ''' Get Plain Text from Word file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnGetPlainText_Click(sender As Object, e As EventArgs) Handles btnGetPlainText.Click
        Try
            getWordPlainText = New GetWordPlainText(tbxFile.Text)
            Me.rtbText.Clear()
            Me.rtbText.Text = getWordPlainText.ReadWordDocument()

            ' After read text in word document successfully，make "save as text" button to be enabled.
            Me.btnSaveas.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If getWordPlainText IsNot Nothing Then
                getWordPlainText.Dispose()
            End If
        End Try
    End Sub

    ''' <summary>
    '''  Save the text to text file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSaveas_Click(sender As Object, e As EventArgs) Handles btnSaveas.Click
        Using savefileDialog As New SaveFileDialog()
            savefileDialog.Filter = "txt document(*.txt)|*.txt"

            ' default file name extension
            savefileDialog.DefaultExt = ".txt"

            ' Retore the directory before closing
            savefileDialog.RestoreDirectory = True
            If savefileDialog.ShowDialog() = DialogResult.OK Then
                Dim filename As String = savefileDialog.FileName
                rtbText.SaveFile(filename, RichTextBoxStreamType.PlainText)
                MessageBox.Show("Save Text file successfully, the file path is： " & filename)
            End If
        End Using
    End Sub

End Class
