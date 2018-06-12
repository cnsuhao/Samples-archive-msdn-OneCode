'/************************************* Module Header **************************************\
' Module Name:	ThisDocument.vb
' Project:		VBWordDocument
' Copyright (c) Microsoft Corporation.
' 
' The VBWordDocument project provides the examples on how manipulate Word 2007 Content Controls 
' in a VSTO document-level project.

' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\******************************************************************************************/

Public Class ThisDocument

    Private Sub ThisDocument_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        Me.ActionsPane.Visible = True
        Dim p As PaneControl = New PaneControl()
        Me.ActionsPane.Controls.Add(p)
    End Sub

    Private Sub ThisDocument_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
