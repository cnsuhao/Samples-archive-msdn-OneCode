'**************************** Module Header ******************************\
' Module Name: TreeViewPage.aspx.vb
' Project:     VBASPNETStripHtmlCode
' Copyright (c) Microsoft Corporation
'
' The code-sample illustrates how to maintain TreeView's state across postbacks.
' The web application use session store the TreeView nodes' status and restore
' them in the next postback event. This interesting function can be used as the
' signs of the navigator bar. 
' 
' This page use to maintain the state of TreeView control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Public Class TreeViewPage
    Inherits System.Web.UI.Page
    Dim state As TreeViewState

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Instantiate the TreeViewState class. This class use to maintain TreeView's nodes
        ' state and check if the state was saved.
        state = New TreeViewState("TreeViewState")
        If Not IsPostBack Then
            Me.TreeViewBind()
        End If
    End Sub

    ''' <summary>
    ''' The method use to bind TreeView with node's last save state across postback.
    ''' </summary>
    Private Sub TreeViewBind()
        If state.IsSaved Then
            state.RestoreTreeView(tvwNodes, "TreeViewState", HttpContext.Current)
        End If
    End Sub

    ''' <summary>
    ''' The button click event use to save TreeView's state 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnSaveTreeViewState_Click(ByVal sender As Object, ByVal e As EventArgs)
        state.SaveTreeView(tvwNodes, "TreeViewState", HttpContext.Current)
    End Sub

    ''' <summary>
    ''' Refresh this page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/TreeViewPage.aspx")
    End Sub

End Class