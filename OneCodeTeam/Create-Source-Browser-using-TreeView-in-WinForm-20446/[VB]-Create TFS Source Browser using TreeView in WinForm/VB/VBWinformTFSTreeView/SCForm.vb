'***************************** Module Header *******************************\
' Module Name:  CommonUtilities.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' Common Utilities
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/


Imports System
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.VersionControl.Client
Imports VBWinformTFSTreeView.Microsoft.OneCode.Utilities
Imports System.Linq

Public Class SCForm

    Private tfsContext As TFSContext

#Region "Private Methods"

    ''' <summary>
    ''' Initialize the Source Control TreeView.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeSourceControlBrowser()
        tvwSourceBrowser.BeginUpdate()

        tvwSourceBrowser.ImageList = imageList

        If (Not tfsContext Is Nothing) Then
            tvwSourceBrowser.Nodes.Clear()
            Dim rootImageIndex As Integer =
                ImageListExtension.GetImageListIndex(imageList, My.Resources.FolderExtensionName)

            Dim rootTreeNode As TreeNode =
                New TreeNode(tfsContext.RootName, rootImageIndex, rootImageIndex)
            rootTreeNode.Tag = "$/"
            rootTreeNode.Nodes.Add("")
            tvwSourceBrowser.Nodes.Add(rootTreeNode)

            tvwSourceBrowser.EndUpdate()
        End If
    End Sub

    ''' <summary>
    ''' Create connection via TFSContext class
    ''' </summary>
    ''' <param name="tfsTeamProjectCollection">Team Foundation Server Team Project Collection</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConnectToTfs(ByVal tfsTeamProjectCollection As TfsTeamProjectCollection) As Boolean
        If (Not tfsTeamProjectCollection Is Nothing _
            AndAlso Not tfsTeamProjectCollection.Uri Is Nothing _
            AndAlso Not tfsTeamProjectCollection.Name Is Nothing) Then

            tfsContext = New TfsContext(tfsTeamProjectCollection.Uri, tfsTeamProjectCollection.Name)

            If tfsContext.Connect() Then
                DefaultSettingProvider.SaveSettings(tfsTeamProjectCollection)
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' Generate children TFSNode per the parentNode server path.
    ''' </summary>
    ''' <param name="parentNode">parent TreeNode</param>
    ''' <remarks></remarks>
    Private Sub GenerateChildrenTfsTreeNode(ByVal parentNode As TreeNode)
        Dim currentNodeServerPath As String = TryCast(parentNode.Tag, String)

        If Not String.IsNullOrEmpty(currentNodeServerPath) Then
            parentNode.Nodes.Clear()
            Dim items As ItemSet =
                tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath)

            If ((Not items Is Nothing) AndAlso (Not items.Items Is Nothing)) Then
                ' Filter the first item which is the self item.
                For i As Integer = 1 To Enumerable.Count(Of Item)(items.Items) - 1
                    Dim tfsTreeNode As TreeNode =
                        CreateTFSTreeNode(items.Items(i).ServerItem,
                                          items.Items(i).ItemType)
                    If (Not tfsTreeNode Is Nothing) Then
                        parentNode.Nodes.Add(tfsTreeNode)
                    End If
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' Create TreeNode per the tfs server item type
    ''' If it's a folder type, use Folder icon for the node;
    ''' If it's a file type, get the file type associated icon for the node.
    ''' </summary>
    ''' <param name="tfsServerItem">TFS Server item full path</param>
    ''' <param name="tfsItemType">TFS Server item type</param>
    ''' <returns>TreeNode for a tfs server item</returns>
    ''' <remarks></remarks>
    Private Function CreateTfsTreeNode(ByVal tfsServerItem As String,
                                       ByVal tfsItemType As ItemType) As TreeNode
        Dim treeNode As TreeNode = Nothing

        If Not String.IsNullOrEmpty(tfsServerItem) Then
            Dim nodeName As String = Path.GetFileName(tfsServerItem)

            If String.IsNullOrEmpty(nodeName) Then
                Return treeNode
            End If

            Dim imageIndex As Integer = 0
            treeNode = New TreeNode(nodeName)

            Select Case tfsItemType
                Case ItemType.Folder
                    imageIndex = ImageListExtension.GetImageListIndex(
                        imageList, My.Resources.FolderExtensionName)
                    treeNode.Nodes.Add(My.Resources.WaitingTreeNodeName)
                    Exit Select
                Case ItemType.File
                    Dim nodeExtension As String = Path.GetExtension(nodeName)
                    imageIndex = ImageListExtension.GetImageListIndex(
                        imageList, nodeExtension)
                    Exit Select
            End Select
            treeNode.ImageIndex = imageIndex
            treeNode.SelectedImageIndex = imageIndex
            treeNode.Tag = tfsServerItem
        End If

        Return treeNode
    End Function

#End Region

#Region "Event Handler"

    ''' <summary>
    ''' Click Event handler for button "Connect"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnConnectClick(sender As System.Object, e As EventArgs) Handles btnConnect.Click
        Dim tpp As TeamProjectPicker = New TeamProjectPicker(TeamProjectPickerMode.NoProject, False)

        Dim defaultSelectionProvider As DefaultSettingProvider = New DefaultSettingProvider()
        tpp.SetDefaultSelectionProvider(defaultSelectionProvider)

        Dim result As DialogResult = tpp.ShowDialog()

        If (result = DialogResult.OK) Then
            Dim isConnected As Boolean = ConnectToTfs(tpp.SelectedTeamProjectCollection)
            If isConnected Then
                InitializeSourceControlBrowser()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Before Expand Event handler for tree view browser
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TvwSourceBrowserBeforeExpand(sender As System.Object, e As Windows.Forms.TreeViewCancelEventArgs) Handles tvwSourceBrowser.BeforeExpand
        If ((Not e Is Nothing) AndAlso (Not e.Node Is Nothing)) Then
            Dim currentNode As TreeNode = e.Node

            Dim currentNodeServerPath As String = TryCast(currentNode.Tag, String)

            If Not String.IsNullOrEmpty(currentNodeServerPath) Then
                Dim asyncResult As IAsyncResult = tvwSourceBrowser.BeginInvoke(
                    New Action(Of TreeNode)(AddressOf GenerateChildrenTfsTreeNode),
                    New Object() {currentNode})
                tvwSourceBrowser.EndInvoke(asyncResult)
            End If
        End If
    End Sub

#End Region

End Class
