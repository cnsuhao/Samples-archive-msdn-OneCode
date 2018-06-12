'**************************** Module Header ******************************\
' Module Name: TreeViewState.vb
' Project:     VBASPNETStripHtmlCode
' Copyright (c) Microsoft Corporation
'
' The code-sample illustrates how to maintain TreeView's state across postbacks.
' The web application use session store the TreeView nodes' status and restore
' them in the next postback event. This interesting function can be used as the
' signs of the navigator bar. 
' 
' This class provide the TreeView state handler methods.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Public Class TreeViewState
    ''' <summary>
    ''' The isSaved field use to check TreeView state was saved.
    ''' </summary>
    Public Property IsSaved() As Boolean

    ''' <summary>
    ''' The class constructor method.
    ''' </summary>
    ''' <param name="key"></param>
    Public Sub New(ByVal key As String)
        If System.Web.HttpContext.Current.Session("TreeViewState") Is Nothing Then
            IsSaved = False
        Else
            IsSaved = True
        End If
    End Sub

    ''' <summary>
    ''' Store TreeView's state in a session.
    ''' </summary>
    ''' <param name="treeView"></param>
    ''' <param name="key"></param>
    ''' <param name="context"></param>
    Public Sub SaveTreeView(ByVal treeView As TreeView, ByVal key As String, ByVal context As HttpContext)
        context.Session(key) = treeView.Nodes
    End Sub

    ''' <summary>
    ''' Restore TreeView's state from session variable, and invoke SaveTreeView method.
    ''' </summary>
    ''' <param name="treeView"></param>
    ''' <param name="key"></param>
    ''' <param name="context"></param>
    Public Sub RestoreTreeView(ByVal treeView As TreeView, ByVal key As String, ByVal context As HttpContext)
        If New TreeViewState(key).IsSaved Then
            treeView.Nodes.Clear()

            Dim nodes As TreeNodeCollection = DirectCast(context.Session(key), TreeNodeCollection)
            For index As Integer = nodes.Count - 1 To 0 Step -1
                treeView.Nodes.AddAt(0, nodes(index))
            Next
            Me.SaveTreeView(treeView, key, context)
        End If

    End Sub

End Class
