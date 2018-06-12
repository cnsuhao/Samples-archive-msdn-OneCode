# Customize ASP.NET TreeView node as RadioButton (VBASPNETRadioButtonTreeView)
## Requires
* Visual Studio 2008
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
* 2011-05-05 07:34:51
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETRadioButtonTreeView Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project shows how to simulate a RadioButton Group within the TreeView <br>
&nbsp;control to make the user can only select one item from a note tree. Since <br>
&nbsp;there is no build-in feature to achieve this, we use two images to imitate<br>
&nbsp;the RadioButton and set TreeNode's ImageUrl property as the path of these<br>
&nbsp;images. When user clicks the item in tree, reset the Checked value and the<br>
&nbsp;ImageUrl value of the treenode to make it looks lick a selected item of a <br>
&nbsp;RadioButton appearance. <br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Basic ASP.NET Web Application in Visual Studio 2008 /<br>
Visual Web Developer and name it as VBASPNETRadioButtonTreeView.<br>
<br>
Step2. Add an TreeView control into the page and change its ID property to<br>
RadioButtonTreeView.<br>
<br>
Step3: Add some test TreeNode to the TreeView follow the HTML code.<br>
<br>
&lt;asp:TreeView ID=&quot;RadioButtonTreeView&quot; runat=&quot;server&quot; ShowLines=&quot;True&quot;&gt;<br>
&nbsp; &nbsp;&lt;Nodes&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode SelectAction=&quot;Expand&quot; Text=&quot;Operating System&quot; Value=&quot;OS&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Windows XP SP1&quot; Value=&quot;Windows XP SP1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Windows XP SP2&quot; Value=&quot;Windows XP SP2&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Windows 2003&quot; Value=&quot;Windows 2003&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Windows Vista&quot; Value=&quot;Windows Vista&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:TreeNode&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode SelectAction=&quot;Expand&quot; Text=&quot;Application&quot; Value=&quot;App&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Office XP&quot; Value=&quot;Office XP&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Office 2003&quot; Value=&quot;Office 2003&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TreeNode Text=&quot;Office 2007&quot; Value=&quot;Office 2007&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:TreeNode&gt;<br>
&nbsp; &nbsp;&lt;/Nodes&gt;<br>
&lt;/asp:TreeView&gt;<br>
<br>
[NOTE] The TreeView exposes custom TreeNodeStyle properties for each node <br>
type (RootNodeStyle, ParentNodeStyle, and LeafNodeStyle), each of which has<br>
an ImageUrl property used for defining an icon for the node type. These <br>
images are rendered to the left of the node text, as shown in the figure <br>
above. Each TreeNode may selectively override the default image for its <br>
node type using the ImageUrl property on the TreeNode object. <br>
<br>
Step4: Perpare two images. One for the state that the TreeNode isn't been<br>
selected, the other for being selected. There already have been two existed<br>
images doing the role. However, we can also make them ourselves by snipping<br>
from other RadioButton from the screen.<br>
<br>
Step5: Set the TreeNode's ImageUrl property to the path of the image standing<br>
for unchecked.<br>
<br>
Step7: Open the Code-Behind page and locate the VB.NET code into the<br>
SelectedNodeChanged eventer handler of the TreeView control.<br>
<br>
[NOTE] In this step, what the code does is to loop through all the tree nodes <br>
in the same level of the selected one and set the Checked propert to false as <br>
well as the image first. Then, change the selected node one to be Checked and<br>
set the ImageUrl of this node to the path of the Checked image.<br>
<br>
Step8: Write the code to handle the Click event of the Button to return the <br>
final selection from the RadioButtonTreeView via CheckedNodes property.<br>
<br>
[NOTE] All the things we do is to imitate the feature to TreeView control <br>
and make it looks like contains a list of RadioButton. So, when user click<br>
the TreeView, the page will post back and get flash somehow. Anyway, it is<br>
a work around that is not difficult and can be used if anyone need to add<br>
radiobuttons to a TreeView control.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: TreeView Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.treeview.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.treeview.aspx</a><br>
<br>
MSDN: TreeView Web Server Control Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/e8z5184w.aspx">http://msdn.microsoft.com/en-us/library/e8z5184w.aspx</a><br>
<br>
ASP.NET Quickstart Tutorials: TreeView<br>
<a target="_blank" href="http://quickstarts.asp.net/QuickStartv20/aspnet/doc/ctrlref/navigation/treeview.aspx">http://quickstarts.asp.net/QuickStartv20/aspnet/doc/ctrlref/navigation/treeview.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
