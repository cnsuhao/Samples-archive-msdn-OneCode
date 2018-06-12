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
* 2013-01-17 01:10:11
## Description

<h1>Create T<span style="">eam Foundation Server</span> Source Browser using TreeView in Win<span style="">dows
</span>Form (CSWinformTFSTreeView)</h1>
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
</span></span></span><span style="">How to create the <span class="SpellE">TreeView.BeforeExpand</span> event handler and generate the
<span class="SpellE">TreeNode</span> based on the hierarchy of Team Foundation Version Control Server?
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
<p class="MsoNormal"><span style=""><img src="/site/view/file/74782/1/image.png" alt="" width="576" height="432" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Click the Connect button and add the Team Foundation Server connection in the Connect to Team Project Dialog.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74783/1/image.png" alt="" width="576" height="359" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">When the connection with Team Foundation Server is established, you will see the TFS Version Control Server items shown in the hierarchical structure in the Tree View at the bottom of the Main dialog.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/74784/1/image.png" alt="" width="576" height="432" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">The code sample provides the following reusable functions for browsing the Team Foundation Version Control hierarchical sources in the Windows Forms TreeView control.</span>
<span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">How to make connection with Team Foundation Server?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public bool Connect()
{
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(TeamFoundationServerCollectionUri);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsVersionControlServer = tpc.GetService&lt;VersionControlServer&gt;();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // connect to the service at connection time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemSet items = GetChildLevelTfsVcsItems(&quot;$/&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return items != null;
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (WebException webException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return false;
}

</pre>
<pre id="codePreview" class="csharp">
public bool Connect()
{
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(TeamFoundationServerCollectionUri);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TfsVersionControlServer = tpc.GetService&lt;VersionControlServer&gt;();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // connect to the service at connection time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemSet items = GetChildLevelTfsVcsItems(&quot;$/&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return items != null;
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (WebException webException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return false;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">How to get one level Team Foundation Server Version Control Items?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public ItemSet GetChildLevelTfsVcsItems(string serverNodePath)
{
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return TfsVersionControlServer.GetItems(serverNodePath, RecursionType.OneLevel);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (WebException webException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return null;
}

</pre>
<pre id="codePreview" class="csharp">
public ItemSet GetChildLevelTfsVcsItems(string serverNodePath)
{
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return TfsVersionControlServer.GetItems(serverNodePath, RecursionType.OneLevel);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (TeamFoundationServiceUnavailableException tfsUnavailableException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowWarning(tfsUnavailableException.Message);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (WebException webException)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CommonUtilities.ShowError(webException.Message);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return null;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">How to create the <span class="SpellE">
TreeView.BeforeExpand</span> event handler and generate the TreeNode based on the hierarchy of Team Foundation Version Control Server?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void TvwSourceBrowserBeforeExpand(object sender, TreeViewCancelEventArgs e)
{
&nbsp;&nbsp;&nbsp; if (e != null && e.Node != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TreeNode currentNode = e.Node;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String currentNodeServerPath = currentNode.Tag as String;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(currentNodeServerPath))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IAsyncResult asyncResult =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.BeginInvoke(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new Action&lt;TreeNode&gt;(GenerateChildrenTFSTreeNode),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; currentNode);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.EndInvoke(asyncResult);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
/// &lt;summary&gt;
/// Generate children TFSNode based on the parentNode server path.
/// &lt;/summary&gt;
/// &lt;param name=&quot;parentNode&quot;&gt;parent TreeNode&lt;/param&gt;
private void GenerateChildrenTFSTreeNode(TreeNode parentNode)
{
&nbsp;&nbsp;&nbsp; String currentNodeServerPath = parentNode.Tag as String;


&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(currentNodeServerPath))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Clear();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemSet items = tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (items != null && items.Items != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Skip the first item which is the self item.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; for (int i = 1; i &lt;= items.Items.Count() - 1; i&#43;&#43;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TreeNode tfsTreeNode =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateTFSTreeNode(items.Items[i].ServerItem, items.Items[i].ItemType);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (tfsTreeNode != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentNode.Nodes.Add(tfsTreeNode);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
/// &lt;summary&gt;
/// Create TreeNode based on the TFS server item type
/// If it is a folder type, use Folder icon for the node;
/// If it is a file type, get the file type associated icon for the node.
/// &lt;/summary&gt;
/// &lt;param name=&quot;tfsServerItem&quot;&gt;TFS Server item full path&lt;/param&gt;
/// &lt;param name=&quot;tfsItemType&quot;&gt;TFS Server item type&lt;/param&gt;
/// &lt;returns&gt;TreeNode for a tfs server item&lt;/returns&gt;
private TreeNode CreateTFSTreeNode(string tfsServerItem, ItemType tfsItemType)
{
&nbsp;&nbsp;&nbsp; TreeNode treeNode = null;
&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(tfsServerItem))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nodeName = Path.GetFileName(tfsServerItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(nodeName))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int imageIndex = 0;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode = new TreeNode(nodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (tfsItemType)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case ItemType.Folder:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = imageList.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Resources.FolderExtensionName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Nodes.Add(Resources.WaitingTreeNodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case ItemType.File:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nodeExtension = Path.GetExtension(nodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageIndex = imageList.GetImageListIndex(nodeExtension);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.ImageIndex = imageIndex;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.SelectedImageIndex = imageIndex;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Tag = tfsServerItem;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;}
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return treeNode;
}

</pre>
<pre id="codePreview" class="csharp">
private void TvwSourceBrowserBeforeExpand(object sender, TreeViewCancelEventArgs e)
{
&nbsp;&nbsp;&nbsp; if (e != null && e.Node != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TreeNode currentNode = e.Node;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String currentNodeServerPath = currentNode.Tag as String;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(currentNodeServerPath))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IAsyncResult asyncResult =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.BeginInvoke(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new Action&lt;TreeNode&gt;(GenerateChildrenTFSTreeNode),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; currentNode);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tvwSourceBrowser.EndInvoke(asyncResult);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
/// &lt;summary&gt;
/// Generate children TFSNode based on the parentNode server path.
/// &lt;/summary&gt;
/// &lt;param name=&quot;parentNode&quot;&gt;parent TreeNode&lt;/param&gt;
private void GenerateChildrenTFSTreeNode(TreeNode parentNode)
{
&nbsp;&nbsp;&nbsp; String currentNodeServerPath = parentNode.Tag as String;


&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(currentNodeServerPath))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parentNode.Nodes.Clear();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemSet items = tfsContext.GetChildLevelTfsVcsItems(currentNodeServerPath);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (items != null && items.Items != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Skip the first item which is the self item.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; for (int i = 1; i &lt;= items.Items.Count() - 1; i&#43;&#43;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TreeNode tfsTreeNode =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateTFSTreeNode(items.Items[i].ServerItem, items.Items[i].ItemType);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (tfsTreeNode != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parentNode.Nodes.Add(tfsTreeNode);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
/// &lt;summary&gt;
/// Create TreeNode based on the TFS server item type
/// If it is a folder type, use Folder icon for the node;
/// If it is a file type, get the file type associated icon for the node.
/// &lt;/summary&gt;
/// &lt;param name=&quot;tfsServerItem&quot;&gt;TFS Server item full path&lt;/param&gt;
/// &lt;param name=&quot;tfsItemType&quot;&gt;TFS Server item type&lt;/param&gt;
/// &lt;returns&gt;TreeNode for a tfs server item&lt;/returns&gt;
private TreeNode CreateTFSTreeNode(string tfsServerItem, ItemType tfsItemType)
{
&nbsp;&nbsp;&nbsp; TreeNode treeNode = null;
&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(tfsServerItem))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nodeName = Path.GetFileName(tfsServerItem);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!String.IsNullOrEmpty(nodeName))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; int imageIndex = 0;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode = new TreeNode(nodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (tfsItemType)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case ItemType.Folder:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imageIndex = imageList.GetImageListIndex(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Resources.FolderExtensionName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Nodes.Add(Resources.WaitingTreeNodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case ItemType.File:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string nodeExtension = Path.GetExtension(nodeName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageIndex = imageList.GetImageListIndex(nodeExtension);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.ImageIndex = imageIndex;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.SelectedImageIndex = imageIndex;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; treeNode.Tag = tfsServerItem;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;}
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return treeNode;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms181475(v=vs.100).aspx">MSDN: Connect to and Access Team Projects in Team Foundation Server</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb286958(v=vs.100).aspx">MSDN: Connect to Team Foundation Server from a Console Application</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-US/library/bb138913(v=vs.100).aspx">MSDN: VersionControlServer.GetItems Method (String, RecursionType)</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
