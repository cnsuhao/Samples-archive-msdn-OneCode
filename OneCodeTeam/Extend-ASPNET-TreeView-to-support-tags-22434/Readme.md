# Extend ASP.NET TreeView to support tags
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* TreeView
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:37:38
## Description

<h1>Extend ASP.NET TreeView to support tags (VBASPNETInheritingFromTreeNode)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In Windows Forms TreeView, each tree node has a property called &quot;Tag&quot; which can be used to store a custom object. Sometimes we want to have the same feature in ASP.NET TreeView. This project creates a custom TreeView control
 named &quot;CustomTreeView&quot; to achieve this goal.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal">Step 1: Open the VBASPNETInheritingFromTreeNode.sln.<br>
Step 2: Expand the VBASPNETInheritingFromTreeNode web application and press Ctrl &#43; F5 to show the Default.aspx.<span style=""> You can see a TreeView control in the page.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83559/1/image.png" alt="" width="613" height="259" align="middle">
</span><br>
Step 3: <span style="">Select one of the TreeNode, then the custom object which assigned to the selected node will display</span>.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83560/1/image.png" alt="" width="628" height="289" align="middle">
</span><br>
Step <span style="">4</span>: Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a <span style="">VB</span> &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as VBASPNETInheritingFromTreeNode&quot;.<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Create the custom TreeView.<span style="">&nbsp; </span>
<br>
<span style="">&nbsp;</span>Define the custom TreeNode named &quot;CustomTreeNode&quot; with a property named &quot;Tag&quot;.<span style="">&nbsp;&nbsp;
</span>We are going to store the custom object in that property. In order to save the new property in View State, we should override LoadViewState() and SaveViewState()
<span style="">methods </span>. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub LoadViewState(ByVal state As Object)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arrState As Object() = TryCast(state, Object())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Tag = arrState(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MyBase.LoadViewState(arrState(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Protected Overrides Function SaveViewState() As Object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arrState As Object() = New Object(1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; arrState(1) = MyBase.SaveViewState()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; arrState(0) = Me.Tag


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return arrState
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub LoadViewState(ByVal state As Object)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arrState As Object() = TryCast(state, Object())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Tag = arrState(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MyBase.LoadViewState(arrState(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Protected Overrides Function SaveViewState() As Object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arrState As Object() = New Object(1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; arrState(1) = MyBase.SaveViewState()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; arrState(0) = Me.Tag


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return arrState
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in"><span style=""><span style="">&nbsp;&nbsp;&nbsp;
</span>In the post back, ASP.NET runtime will recreate the TreeView control. To let the TreeView control to create custom TreeNode automatically, we should override the helper method CreateNode().
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Function CreateNode() As TreeNode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New CustomTreeNode(Me, False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Function CreateNode() As TreeNode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New CustomTreeNode(Me, False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in; text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Define the custom object. In order to save the object to View State, the object needs to be serializable.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Serializable()&gt; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Class MyItem
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Title() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Title
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(ByVal value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Title = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private m_Title As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Class

</pre>
<pre id="codePreview" class="vb">
&lt;Serializable()&gt; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Class MyItem
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Title() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Title
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(ByVal value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Title = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private m_Title As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Create the test page.<span style="">&nbsp;&nbsp;&nbsp; </span>
</span>Add <span style="">a</span> web forms in the root directory, name <span style="">
it</span> as &quot;Default.aspx&quot;<span style="">. Add a CustomTreeView control in the page. In Page_Load() method, create some CustomTreeNodes and assign a custom object to each CustomTreeNode.<span style="">&nbsp;&nbsp;
</span>In the CustomTreeView control's SelectedNodeChanged event handler, retrieve the custom object from the selected tree node, and then display it.</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">TreeNode.Tag Property<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.treenode.tag.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.treenode.tag.aspx</a><span style=""><br>
</span>Control.SaveViewState Method<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.saveviewstate.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.saveviewstate.aspx</a><span style=""><br>
</span>Control.LoadViewState Method<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.loadviewstate.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.loadviewstate.aspx</a><span style=""><br>
</span>TreeView.CreateNode Method<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.createnode.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.createnode.aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
