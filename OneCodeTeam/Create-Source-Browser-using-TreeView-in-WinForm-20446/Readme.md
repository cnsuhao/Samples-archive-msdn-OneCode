# Create TFS Source Browser using TreeView in WinForm
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* TFS
## Topics
* TFS
## IsPublished
* True
## ModifiedDate
* 2013-01-17 01:13:08
## Description

<h1>Create Team Foundation Server Source Browser using TreeView in Windows Form (VBWinformTFSTreeView)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This article and the attached code sample demonstrate how to display the Team Foundation Server hierarchical source items in a tree structure outside Visual Studio Team Explorer.<span style="">&nbsp;
</span>You can find the answers for all the following questions in the code sample:
</span></p>
<p class="MsoListBulletCxSpFirst" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to make connection with Team Foundation Server?
</span></p>
<p class="MsoListBulletCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to get one level Team Foundation Server Version Control Items?
</span></p>
<p class="MsoListBulletCxSpLast" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to create the TreeView.BeforeExpand event handler and generate the TreeNode based on the hierarchy of Team Foundation Version Control Server?
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span style="">To build this sample, you must install TFS (Team Foundation Server) 2010 SP1 Object Model at first.<span style="">&nbsp;
</span>By using the TFS Object Model, the attached code samples can retrieve the Team Foundation Version Control Server Items outside the Visual Studio or Team Explorer.
</span></p>
<p class="MsoNormal"><span style="">The standalone Team Foundation Server 2010 SP1 Object Model Installer is available for download from the Visual Studio Gallery:
</span></p>
<p class="MsoNormal"><a href="http://visualstudiogallery.msdn.microsoft.com/a37e19fb-3052-4fc9-bef7-4a4682069a75">Download the Team Foundation Server 2010 SP1 Object Model Installer here</a><span style="">.
</span></p>
<p class="MsoNormal"><b style=""><span style="">Note</span></b><span style="">: this is the same Object Model included with the Visual Studio &amp; Team Explorer SKU.<span style="">&nbsp;&nbsp;&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">After you successfully build the sample project in Visual Studio 2010, you will get the application CSWinformTFSTreeView.exe.<span style="">&nbsp;
</span>Run the application either in debug mode in the Visual Studio or in standalone mode in the Windows Explorer.<span style="">&nbsp;&nbsp;
</span>The application should be initially displayed as following on the Main dialog.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74786/1/image.png" alt="" width="576" height="432" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Click the Connect button and add the Team Foundation Server connection in the &quot;Connect to Team Project&quot; Dialog.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74787/1/image.png" alt="" width="576" height="359" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">When the connection with Team Foundation Server is established, you will see the TFS Version Control Server items shown in the hierarchical structure in the Tree View at the bottom of the Main dialog.
</span></p>
<p class="MsoListBullet" style=""><span style=""><img src="/site/view/file/74788/1/image.png" alt="" width="576" height="432" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">The code sample provides the following reusable functions for browsing the Team Foundation Version Control hierarchical sources in the Windows Forms TreeView control.</span>
<span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">How to make connection with Team Foundation Server?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function Connect() As Boolean
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsVersionControlServer = New TfsTeamProjectCollection(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TeamFoundationServerCollectionUri).GetService(Of VersionControlServer)()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return (Not GetChildLevelTfsVcsItems(&quot;$/&quot;) Is Nothing)
&nbsp;&nbsp;&nbsp; Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message)
&nbsp;&nbsp;&nbsp; Catch webException As WebException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return False
End Function

</pre>
<pre id="codePreview" class="vb">
Public Function Connect() As Boolean
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsVersionControlServer = New TfsTeamProjectCollection(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TeamFoundationServerCollectionUri).GetService(Of VersionControlServer)()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return (Not GetChildLevelTfsVcsItems(&quot;$/&quot;) Is Nothing)
&nbsp;&nbsp;&nbsp; Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message)
&nbsp;&nbsp;&nbsp; Catch webException As WebException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return False
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""><span style=""></span></b></p>
<p class="MsoNormal"><b style=""><span style="">How to get one level Team Foundation Server Version Control Items?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function GetChildLevelTfsVcsItems(ByVal serverNodePath As String) As ItemSet
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return TfsVersionControlServer.GetItems(serverNodePath,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RecursionType.OneLevel)
&nbsp;&nbsp;&nbsp; Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message)
&nbsp;&nbsp;&nbsp; Catch webException As WebException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return Nothing
End Function

</pre>
<pre id="codePreview" class="vb">
Public Function GetChildLevelTfsVcsItems(ByVal serverNodePath As String) As ItemSet
&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return TfsVersionControlServer.GetItems(serverNodePath,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RecursionType.OneLevel)
&nbsp;&nbsp;&nbsp; Catch tfsUnavailableException As TeamFoundationServiceUnavailableException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message)
&nbsp;&nbsp;&nbsp; Catch webException As WebException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return Nothing
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">How to create the TreeView.BeforeExpand event handler and generate the TreeNode based on the hierarchy of Team Foundation Version Control Server?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub TvwSourceBrowserBeforeExpand(sender As System.Object, e As Windows.Forms.TreeViewCancelEventArgs) Handles tvwSourceBrowser.BeforeExpand
&nbsp;&nbsp;&nbsp; If ((Not e Is Nothing) AndAlso (Not e.Node Is Nothing)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNode As TreeNode = e.Node


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNodeServerPath As String = TryCast(currentNode.Tag, String)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(currentNodeServerPath) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim asyncResult As IAsyncResult = tvwSourceBrowser.BeginInvoke(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Action(Of TreeNode)(AddressOf Me.GenerateChildrenTFSTreeNode),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Object() {currentNode})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.EndInvoke(asyncResult)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End Sub


''' &lt;summary&gt;
''' Generate children TFSNode per the parentNode server path.
''' &lt;/summary&gt;
''' &lt;param name=&quot;parentNode&quot;&gt;parent TreeNode&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub GenerateChildrenTFSTreeNode(ByVal parentNode As TreeNode)
&nbsp;&nbsp;&nbsp; Dim currentNodeServerPath As String = TryCast(parentNode.Tag, String)


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(currentNodeServerPath) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Clear()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim items As ItemSet =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ((Not items Is Nothing) AndAlso (Not items.Items Is Nothing)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Filter the first item which is the self item.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 1 To Enumerable.Count(Of Item)(items.Items) - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim tfsTreeNode As TreeNode =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateTFSTreeNode(items.Items(i).ServerItem,
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Items(i).ItemType)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not tfsTreeNode Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Add(tfsTreeNode)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End Sub


''' &lt;summary&gt;
''' Create TreeNode per the tfs server item type
''' If it's a folder type, use Folder icon for the node;
''' If it's a file type, get the file type associated icon for the node.
''' &lt;/summary&gt;
''' &lt;param name=&quot;tfsServerItem&quot;&gt;TFS Server item full path&lt;/param&gt;
''' &lt;param name=&quot;tfsItemType&quot;&gt;TFS Server item type&lt;/param&gt;
''' &lt;returns&gt;TreeNode for a tfs server item&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Function CreateTFSTreeNode(ByVal tfsServerItem As String,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal tfsItemType As ItemType) As TreeNode
&nbsp;&nbsp;&nbsp; Dim treeNode As TreeNode = Nothing


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(tfsServerItem) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nodeName As String = Path.GetFileName(tfsServerItem)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If String.IsNullOrEmpty(nodeName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return treeNode
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim imageIndex As Integer = 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode = New TreeNode(nodeName)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case tfsItemType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case ItemType.Folder
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = ImageListExtension.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageList, My.Resources.FolderExtensionName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Nodes.Add(My.Resources.WaitingTreeNodeName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case ItemType.File
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nodeExtension As String = Path.GetExtension(nodeName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = ImageListExtension.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageList, nodeExtension)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.ImageIndex = imageIndex
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.SelectedImageIndex = imageIndex
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Tag = tfsServerItem
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return treeNode
End Function

</pre>
<pre id="codePreview" class="vb">
Private Sub TvwSourceBrowserBeforeExpand(sender As System.Object, e As Windows.Forms.TreeViewCancelEventArgs) Handles tvwSourceBrowser.BeforeExpand
&nbsp;&nbsp;&nbsp; If ((Not e Is Nothing) AndAlso (Not e.Node Is Nothing)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNode As TreeNode = e.Node


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNodeServerPath As String = TryCast(currentNode.Tag, String)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(currentNodeServerPath) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim asyncResult As IAsyncResult = tvwSourceBrowser.BeginInvoke(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Action(Of TreeNode)(AddressOf Me.GenerateChildrenTFSTreeNode),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Object() {currentNode})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.EndInvoke(asyncResult)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End Sub


''' &lt;summary&gt;
''' Generate children TFSNode per the parentNode server path.
''' &lt;/summary&gt;
''' &lt;param name=&quot;parentNode&quot;&gt;parent TreeNode&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub GenerateChildrenTFSTreeNode(ByVal parentNode As TreeNode)
&nbsp;&nbsp;&nbsp; Dim currentNodeServerPath As String = TryCast(parentNode.Tag, String)


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(currentNodeServerPath) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Clear()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim items As ItemSet =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ((Not items Is Nothing) AndAlso (Not items.Items Is Nothing)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Filter the first item which is the self item.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 1 To Enumerable.Count(Of Item)(items.Items) - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim tfsTreeNode As TreeNode =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateTFSTreeNode(items.Items(i).ServerItem,
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Items(i).ItemType)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not tfsTreeNode Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Add(tfsTreeNode)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End Sub


''' &lt;summary&gt;
''' Create TreeNode per the tfs server item type
''' If it's a folder type, use Folder icon for the node;
''' If it's a file type, get the file type associated icon for the node.
''' &lt;/summary&gt;
''' &lt;param name=&quot;tfsServerItem&quot;&gt;TFS Server item full path&lt;/param&gt;
''' &lt;param name=&quot;tfsItemType&quot;&gt;TFS Server item type&lt;/param&gt;
''' &lt;returns&gt;TreeNode for a tfs server item&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Function CreateTFSTreeNode(ByVal tfsServerItem As String,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal tfsItemType As ItemType) As TreeNode
&nbsp;&nbsp;&nbsp; Dim treeNode As TreeNode = Nothing


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(tfsServerItem) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nodeName As String = Path.GetFileName(tfsServerItem)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If String.IsNullOrEmpty(nodeName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return treeNode
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim imageIndex As Integer = 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode = New TreeNode(nodeName)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case tfsItemType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case ItemType.Folder
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = ImageListExtension.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageList, My.Resources.FolderExtensionName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Nodes.Add(My.Resources.WaitingTreeNodeName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case ItemType.File
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nodeExtension As String = Path.GetExtension(nodeName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = ImageListExtension.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageList, nodeExtension)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.ImageIndex = imageIndex
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.SelectedImageIndex = imageIndex
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Tag = tfsServerItem
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return treeNode
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms181475(v=vs.100).aspx">MSDN: Connect to and Access Team Projects in Team Foundation Server</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb286958(v=vs.100).aspx">MSDN: Connect to Team Foundation Server from a Console Application</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-US/library/bb138913(v=vs.100).aspx">MSDN: VersionControlServer.GetItems Method (String, RecursionType)</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
