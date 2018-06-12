'****************************** Module Header ******************************\
' Module Name:    WebForm1.aspx.vb
' Project:        VBASPNETAddEndRequestEventInUpdatepanel
' Copyright (c) Microsoft Corporation
'
' The WebForm1 page shows the scene, using the MasterPage which have already has the ScriptManager control, this page use the ScriptManagerProxy control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        'grid1.BorderWidth = 2
    End Sub
End Class
