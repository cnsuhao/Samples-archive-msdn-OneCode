# Maintain TreeView Position or State On Postback (CSASPNETMaintainTreeViewState)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* TreeView
## IsPublished
* True
## ModifiedDate
* 2012-04-20 03:34:54
## Description
======================================================================== CSASPNETMaintainTreeViewState Overview ======================================================================== /////////////////////////////////////////////////////////////////////////////
 Use: The code-sample illustrates how to maintain TreeView's state across postbacks. The web application use session store the TreeView nodes' status and restore them in the next postback event. This interesting function can be used as the signs of the navigator
 bar. ///////////////////////////////////////////////////////////////////////////// Demo the Sample. Please follow these demonstration steps below. Step 1: Open the CSASPNETMaintainTreeViewState.sln. Step 2: Expand the CSASPNETMaintainTreeViewState web application
 and press Ctrl &#43; F5 to show the TreeViewPage.aspx. Step 3: You will see an TreeView control on the page, please operate the TreeView's nodes and Click the Save TreeView state button. Step 4: Click the Refresh This Page button to invoke the post back event.
 you can find the TreeView's state will stay the same. Step 5: You can also click the refresh button of the Browsers, the TreeView state can still be maintained. Step 5: Validation finished. /////////////////////////////////////////////////////////////////////////////
 Code Logical: Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETMaintainTreeViewState&quot;. Step 2. Add one web form in the root directory, name it as &quot;TreeViewPage.aspx&quot;. Step 3. Add a
 TreeView control and two buttons on the page, you can add some nodes of TreeView manually. Step 4 Create App_Code folder and add TreeViewState class file, This class use to handler TreeView nodes status and restore them: [code] /// &lt;summary&gt; /// Store TreeView's
 state in a session. /// &lt;/summary&gt; /// &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;key&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt; public void SaveTreeView(TreeView treeView, string key,HttpContext context) { context.Session[key] = treeView.Nodes; }
 /// &lt;summary&gt; /// Restore TreeView's state from session variable, and invoke SaveTreeView method. /// &lt;/summary&gt; /// &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;key&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt; public void RestoreTreeView(TreeView treeView,
 string key, HttpContext context) { if (new TreeViewState(key).IsSaved) { treeView.Nodes.Clear(); TreeNodeCollection nodes = (TreeNodeCollection)context.Session[key]; for (int index = nodes.Count - 1; index &gt;= 0; index--) { treeView.Nodes.AddAt(0, nodes[index]);
 } this.SaveTreeView(treeView, key, context); } } [/code] Step 5. Add SaveTreeViewState button's OnClick event and TreeView data bind event code of TreeViewState.aspx.cs file below: [code] /// &lt;summary&gt; /// The method use to bind TreeView with node's last save
 state across postback. /// &lt;/summary&gt; private void TreeViewBind() { if (state.IsSaved) { state.RestoreTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current); } } /// &lt;summary&gt; /// The button click event use to save TreeView's state /// &lt;/summary&gt; /// &lt;param
 name=&quot;sender&quot;&gt;&lt;/param&gt; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt; protected void btnSaveTreeViewState_Click(object sender, EventArgs e) { state.SaveTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current); } [/code] Step 6. Build the application and you can debug it. /////////////////////////////////////////////////////////////////////////////
 References: MSDN: TreeView Class http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx MSDN: TreeNodeCollection Class http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treenodecollection.aspx /////////////////////////////////////////////////////////////////////////////
