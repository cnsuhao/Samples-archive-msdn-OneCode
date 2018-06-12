'**************************** Module Header ******************************'
' Module Name:  MainForm.vb
' Project:      VBListFilesInDirectory
' Copyright (c) Microsoft Corporation.
'
' The CSListFilesInDirectory project demonstrates how to implement an IEnumerable<string>
' that utilizes the Win32 File Management functions to enable application to get files and
' sub-directories in a specified directory one item a time.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Public Class MainForm

    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Try
            Dim i As Integer = 0
            Dim mode As DirectoryEnumerator.Mode

            If chkDir.Checked Then mode = mode Or DirectoryEnumerator.Mode.Directory
            If chkFiles.Checked Then mode = mode Or DirectoryEnumerator.Mode.File

            lstFiles.Items.Clear()

            Dim pattern As String = Path.Combine(txtDir.Text.Trim(), txtPattern.Text.Trim())
            Dim de As New DirectoryEnumerator(pattern, mode)

            For Each file As String In de   ' Enumerate items in the directory
                i += 1  ' Increase the count
                lstFiles.Items.Add(file)
                Application.DoEvents()
            Next

            lblCount.Text = String.Format("{0:#,##0} Item{1}", i, IIf(i <> 1, "s", String.Empty))

        Catch winEx As Win32Exception
            MsgBox(winEx.Message, vbOKOnly Or vbCritical, Me.Text)
        End Try
    End Sub

    Private Sub txtDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDir.TextChanged
        ' Enable the List button if the target directory exists
        btnList.Enabled = Directory.Exists(txtDir.Text.Trim())
    End Sub

    Private Sub chkModes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDir.CheckedChanged, chkFiles.CheckedChanged
        ' Enable the List button if at least one check box is selected
        btnList.Enabled = chkDir.Checked OrElse chkFiles.Checked
    End Sub
End Class
