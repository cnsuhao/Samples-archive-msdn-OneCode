'**************************** Module Header ******************************'
' Module Name:  MyControl.vb
' Project:      VBVSPackageToolbox
' Copyright (c) Microsoft Corporation.
' 
' This UserControl will be displayed as the content of the ToolWindow.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

<DisplayName("ToolboxMemberDemo"), _
Description("Custom toolbox item from package LoadToolboxMembers."), _
ToolboxItem(True), _
ToolboxBitmap(GetType(MyControl), "MyControl.bmp")> _
Public Class MyControl

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim opg As New OpenFileDialog()
        opg.Multiselect = False
        If opg.ShowDialog() = DialogResult.OK Then
            Me.tbFileName.Text = opg.FileName
        End If
    End Sub
End Class
