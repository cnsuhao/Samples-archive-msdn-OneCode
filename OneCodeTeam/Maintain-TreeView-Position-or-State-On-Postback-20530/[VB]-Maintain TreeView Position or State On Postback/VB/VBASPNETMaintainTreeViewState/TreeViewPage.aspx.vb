'**************************** Module Header ******************************\
' Module Name: TreeViewPage.aspx.vb
' Project:     VBASPNETStripHtmlCode
' Copyright (c) Microsoft Corporation
'
' The code-sample illustrates how to maintain TreeView's state across postbacks.
' The web application uses session to store the TreeView node's status and restores
' them in the next postback event. 
' 
' This page use to maintain the state of TreeView control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Public Class TreeViewPage
    Inherits System.Web.UI.Page
    Dim state As TreeViewState

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Instantiate the TreeViewState class. This class is used to maintain TreeView node's
        ' state and check if the state is saved.
        state = New TreeViewState("TreeViewState")
        If Not IsPostBack Then
            Me.TreeViewBind()
        End If
    End Sub

    ''' <summary>
    ''' Restore TreeView.
    ''' </summary>
    Private Sub TreeViewBind()
        If state.IsSaved Then
            state.RestoreTreeView(tvwNodes, "TreeViewState", HttpContext.Current)
        End If
    End Sub

    ''' <summary>
    ''' Save TreeView's state 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnSaveTreeViewState_Click(ByVal sender As Object, ByVal e As EventArgs)
        state.SaveTreeView(tvwNodes, "TreeViewState", HttpContext.Current)
    End Sub

    ''' <summary>
    ''' Refresh the page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/TreeViewPage.aspx")
    End Sub

End Class