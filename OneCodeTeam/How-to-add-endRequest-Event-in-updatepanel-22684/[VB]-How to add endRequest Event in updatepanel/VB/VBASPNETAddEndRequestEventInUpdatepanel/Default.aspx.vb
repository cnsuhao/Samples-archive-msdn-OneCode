'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETAddEndRequestEventInUpdatepanel
' Copyright (c) Microsoft Corporation
'
' Default page shows the scene of the current page using the ScriptManager Control. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Partial Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Here you can re-bind or refresh logic. I am here is to modify the border width of the GridView.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        grid1.BorderWidth = 2
    End Sub
End Class

