# Host WPF control in VS ToolWindow (CSVSPackageWPFToolWindow)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Host WPF control in Visual Studio Toolwindow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:37:17
## Description

<p style="font-family:Courier New"></p>
<h2>VSX Module: CSVSPackageWPFToolWindow Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demostrate how to host a WPF control into Visual Studio <br>
ToolWindow. <br>
<br>
To use the sample<br>
1. Run the sample<br>
2. Open tool window by View / Other Windows / WPFToolWindow<br>
3. A tool window will be docked at place of solution explorer<br>
4. The tool window hosts a WPF control which represents MyDocuments folder<br>
structure<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
VS 2008 SDK must be installed on the machine. You can download it from:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en</a><br>
<br>
Otherwise the project may not be opened by Visual Studio.<br>
<br>
If you run this project on a x64 OS, please also config the Debug tab of the project<br>
Setting. Set the &quot;Start external program&quot; to <br>
C:\Program Files(x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe<br>
<br>
NOTE: The Package Load Failure Dialog occurs because there is no PLK(Package Load Key)<br>
&nbsp; &nbsp; &nbsp;Specified in this package. To obtain a PLK, please to go to WebSite:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/vsx/cc655795.aspx">http://msdn.microsoft.com/en-us/vsx/cc655795.aspx</a><br>
&nbsp; &nbsp; &nbsp;More info<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">http://msdn.microsoft.com/en-us/library/bb165395.aspx</a><br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Creating the Project<br>
Create a Visual Studio Integration Package project that provides a tool window. <br>
Later, you add a WPF control to this tool window.<br>
<br>
To create the Visual Studio project<br>
<br>
Create a Visual Studio package that provides a tool window.<br>
<br>
In the Visual Studio Integration Package Wizard, use the following settings:<br>
- Set the programming language to Visual Basic or Visual C#.<br>
- Use the default values on the Basic Package Information page.<br>
- Add a tool window that is named Hosted WPF Clock Control.<br>
- Click Finish.<br>
<br>
The wizard generates a project that contains a WinForms user control, <br>
MyControl, for the tool window.<br>
<br>
2. Adding the WPF User Control<br>
Add a WPF user control to your project. The user control presented here <br>
represents MyDocuments folder structure by tree view. <br>
Then, add this WPF control to the control for the tool window in your package.<br>
<br>
To create the WPF user control<br>
<br>
In Solution Explorer, right-click the tool window project, <br>
point to Add, and then click New Item.<br>
<br>
In the Add New Item dialog box, select the User Control (WPF) template, <br>
name it WPFControl, and click Add.<br>
<br>
Open the WPFControl.xaml file for editing, and replace the child element <br>
of the UserControl element by using the following markup. <br>
<br>
XAML<br>
&lt;UserControl x:Class=&quot;Company.VSPackageWPFToolWindow.WPFControl&quot;<br>
&nbsp; &nbsp;xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</a><br>
&nbsp; &nbsp;xmlns:x=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml&quot;">http://schemas.microsoft.com/winfx/2006/xaml&quot;</a><br>
&nbsp; &nbsp;Height=&quot;300&quot; Width=&quot;300&quot;&gt;<br>
&nbsp; &nbsp;&lt;Grid&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;TreeView Name=&quot;treeView&quot; HorizontalAlignment=&quot;Stretch&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HorizontalContentAlignment=&quot;Left&quot; /&gt;<br>
&nbsp; &nbsp;&lt;/Grid&gt;<br>
&lt;/UserControl&gt;<br>
To open the code-behind file for editing, right-click in the XAML editor, <br>
and then click View Code.<br>
<br>
Add the following code:<br>
public TreeView WPFTreeView<br>
{<br>
&nbsp; &nbsp;get<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return this.treeView;<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Save all files and verify that the solution builds.<br>
<br>
To add the WPF user control to the tool window<br>
a. Open the MyControl user control in design mode.<br>
b. Remove the default button, button1, from the control.<br>
c. In the Toolbox, directly drag WPFControl into the Windows Form<br>
<br>
Click Dock in parent container to set the Dock property to Fill.<br>
<br>
Right-click the design surface, and then click View Code to open the MyControl class in the code editor.<br>
<br>
Delete the button1_Click method that the wizard generated.<br>
<br>
Add the methods shown in the following example. <br>
public WPFControl WPFControl<br>
{<br>
&nbsp; &nbsp;get<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return wpfControl1;<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Open the MyToolWindow.cs file, add following code:<br>
/// &lt;summary&gt;<br>
/// Standard constructor for the tool window.<br>
/// &lt;/summary&gt;<br>
public MyToolWindow() :<br>
&nbsp; &nbsp;base(null)<br>
{<br>
&nbsp; &nbsp;// Set the window title reading it from the resources.<br>
&nbsp; &nbsp;this.Caption = Resources.ToolWindowTitle;<br>
&nbsp; &nbsp;// Set the image that will appear on the tab of the window frame<br>
&nbsp; &nbsp;// when docked with an other window<br>
&nbsp; &nbsp;// The resource ID correspond to the one defined in the resx file<br>
&nbsp; &nbsp;// while the Index is the offset in the bitmap strip. Each image in<br>
&nbsp; &nbsp;// the strip being 16x16.<br>
&nbsp; &nbsp;this.BitmapResourceID = 301;<br>
&nbsp; &nbsp;this.BitmapIndex = 1;<br>
<br>
<br>
&nbsp; &nbsp;control = new MyControl();<br>
&nbsp; &nbsp;wpfControl = control.WPFControl;<br>
}<br>
<br>
public override void OnToolWindowCreated()<br>
{<br>
&nbsp; &nbsp;base.OnToolWindowCreated();<br>
&nbsp; &nbsp;InitializeTreeViewContent();<br>
<br>
}<br>
<br>
private void InitializeTreeViewContent()<br>
{<br>
&nbsp; &nbsp;DirectoryInfo myDocInfo =<br>
&nbsp; &nbsp; &nbsp; &nbsp;new DirectoryInfo(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Environment.GetFolderPath(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Environment.SpecialFolder.MyDocuments<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;);<br>
&nbsp; &nbsp;IntializeTreeViewContentRecursively(myDocInfo, wpfControl.WPFTreeView.Items);<br>
}<br>
<br>
private void IntializeTreeViewContentRecursively(<br>
&nbsp; &nbsp;DirectoryInfo myDocInfo, ItemCollection itemCollection)<br>
{ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;if (myDocInfo == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp;return;<br>
<br>
&nbsp; &nbsp;try<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem item = new TreeViewItem();<br>
&nbsp; &nbsp; &nbsp; &nbsp;item.Header = myDocInfo.Name;<br>
&nbsp; &nbsp; &nbsp; &nbsp;itemCollection.Add(item);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;DirectoryInfo[] subDirs = myDocInfo.GetDirectories();<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (subDirs != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (DirectoryInfo dir in subDirs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IntializeTreeViewContentRecursively(dir, item.Items);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;FileInfo[] files = myDocInfo.GetFiles();<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (files != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (FileInfo file in files)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TreeViewItem fileItem = new TreeViewItem();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fileItem.Header = file.Name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fileItem.Tag = file.FullName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;item.Items.Add(fileItem);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;catch<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
3. Add regsitry attribute to the package<br>
<br>
Open CSVSPackageWPFToolWindowPackage.cs, add following attribute:<br>
<br>
[ProvideToolWindow(typeof(MyToolWindow), Style = VsDockStyle.Tabbed, <br>
&nbsp;&nbsp;&nbsp;&nbsp;Window = &quot;3ae79031-e1bc-11d0-8f78-00a0c9110057&quot;)]<br>
<br>
The attribute indicates that the tool window will be docked at the same place<br>
as solution explorer.<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Walkthrough: Hosting a WPF User Control in a Tool Window<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc826120.aspx">http://msdn.microsoft.com/en-us/library/cc826120.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
