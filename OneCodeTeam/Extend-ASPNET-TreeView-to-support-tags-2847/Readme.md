# Extend ASP.NET TreeView to support tags (VBASPNETInheritingFromTreeNode)
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
* 2011-05-05 09:42:50
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETInheritingFromTreeNode Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
In windows forms TreeView, each tree node has a property called &quot;Tag&quot; which can
<br>
be used to store a custom object. Sometimes we want to have the same feature in ASP.NET
<br>
TreeView. This project creates a custom TreeView control named &quot;CustomTreeView&quot;
<br>
to achieve this goal.<br>
</p>
<h3>Demo the Sample:</h3>
<p style="font-family:Courier New"><br>
Open the page Default.aspx in the browser, you can see a TreeView control in the page.<br>
Select one of the TreeNode, then the custom object which assigned to the selected node<br>
will display. <br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
1. Create the custom TreeView.<br>
<br>
&nbsp; Define the custom TreeNode named &quot;CustomTreeNode&quot; with a property named &quot;Tag&quot;.<br>
&nbsp; We are going to store the custom object in that property. In order to save
<br>
&nbsp; the new property in View State, we override methods LoadViewState() and SaveViewState()<br>
&nbsp; to achieve saving and retrieving.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Sub LoadViewState(ByVal state As Object)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim arrState As Object() = TryCast(state, Object())<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Tag = arrState(0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MyBase.LoadViewState(arrState(1))<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Function SaveViewState() As Object<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim arrState As Object() = New Object(1) {}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;arrState(1) = MyBase.SaveViewState()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;arrState(0) = Me.Tag<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return arrState<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;In the post back, ASP.NET runtime will recreate the TreeView control. To let
<br>
&nbsp; &nbsp;the TreeView control to create custom TreeNode automatically, we override
<br>
&nbsp; &nbsp;the helper method CreateNode().<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Function CreateNode() As TreeNode<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return New CustomTreeNode(Me, False)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
2. Define the custom object.<br>
<br>
&nbsp; In order to save the object to View State, the object needs to be serializable.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Serializable()&gt; _<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Class MyItem<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Property Title() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return m_Title<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Set(ByVal value As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_Title = value<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Set<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Property<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private m_Title As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Class<br>
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
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
