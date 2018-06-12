# Extend ASP.NET TreeView to support tags (CSASPNETInheritingFromTreeNode)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* TreeView
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:03:34
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETInheritingFromTreeNode Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
In windows forms TreeView, each tree node has a property called &quot;Tag&quot; which
<br>
can be used to store a custom object. Sometimes we want to have the same <br>
feature in ASP.NET TreeView. This project creates a custom TreeView control <br>
named &quot;CustomTreeView&quot; to achieve this goal.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Open the page Default.aspx in the browser, you can see a TreeView control in <br>
the page. Select one of the TreeNode, then the custom object which assigned to <br>
the selected node will display. <br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
1. Create the custom TreeView.<br>
<br>
&nbsp; Define the custom TreeNode named &quot;CustomTreeNode&quot; with a property named &quot;Tag&quot;.<br>
&nbsp; We are going to store the custom object in that property. In order to save
<br>
&nbsp; the new property in View State, we override methods LoadViewState() and <br>
&nbsp; SaveViewState() to achieve saving and retrieving.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override void LoadViewState(object state)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;object[] arrState = state as object[];<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Tag = arrState[0];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;base.LoadViewState(arrState[1]);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override object SaveViewState()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;object[] arrState = new object[2];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;arrState[1] = base.SaveViewState();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;arrState[0] = this.Tag;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return arrState;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;In the post back, ASP.NET runtime will recreate the TreeView control. To let
<br>
&nbsp; &nbsp;the TreeView control to create custom TreeNode automatically, we override
<br>
&nbsp; &nbsp;the helper method CreateNode().<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override TreeNode CreateNode()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return new CustomTreeNode(this, false);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. Define the custom object.<br>
<br>
&nbsp; In order to save the object to View State, the object needs to be serializable.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;[Serializable]<br>
&nbsp; &nbsp; &nbsp; &nbsp;public class MyItem<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public string Title { get; set; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
3. Create the test page.<br>
<br>
&nbsp; Add a CustomTreeView control in the page. In Page_Load() method, create some
<br>
&nbsp; CustomTreeNodes and assign a custom object to each CustomTreeNode.<br>
<br>
&nbsp; In the CustomTreeView control's SelectedNodeChanged event handler, retrieve
<br>
&nbsp; the custom object from the selected tree node, and then display it.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
TreeNode.Tag Property<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.treenode.tag.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.treenode.tag.aspx</a><br>
<br>
Control.SaveViewState Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.saveviewstate.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.saveviewstate.aspx</a><br>
<br>
Control.LoadViewState Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.loadviewstate.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.loadviewstate.aspx</a><br>
<br>
TreeView.CreateNode Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.createnode.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.createnode.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
