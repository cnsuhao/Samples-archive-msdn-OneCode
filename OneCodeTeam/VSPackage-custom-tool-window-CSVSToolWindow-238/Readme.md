# VSPackage custom tool window (CSVSToolWindow)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* VSPackage with Tool Window
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:38:59
## Description

<p style="font-family:Courier New"></p>
<h2>CSVSToolWindow Module: CSVSToolWindow Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
VSPackages are software modules that make up and extend the Visual Studio <br>
integrated development environment (IDE) by providing UI elements, services, <br>
projects, editors, and designers. VSPackages are the principal architectural <br>
unit of Visual Studio, and are the unit of deployment, licensing, and security <br>
also. Visual Studio itself is written mostly as a collection of VSPackages. <br>
This sample demonstrate how to use the the Visual Studio Integration Package <br>
Wizard to create a simple VSPackage with a tool window that has a Windows Media<br>
control on it.<br>
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
A: How to Create a VSPackage <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Create a new project using Visual Studio Integration Package as template<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; (New Project dialog box -&gt; Other Project Types -&gt; Extensibility).
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. In the Location box, type the file path for your VSPackage.
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. In the Name box, type the name for the solution and then click OK to start<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; the wizard. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. On the Select a Programming Language page, select Visual C# and have the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; wizard generate a key.snk file to sign the assembly, then click Next.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;4. In the Basic VSPackage Information page, specify details about your
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VSPackage(Brand the VSPackage) and click Next.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;5. Select the Menu Command option to create a new command for the VSPackage and<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; select Tool Window to create a tool window in this VSPackage. Then click Next.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; The new command is put at the top of the Tools menu.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;6. Type the name(All-In-One) and ID(cmdidToolWindow) for the new
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; menu command in the text boxes, then click Next. The command ID is the name<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; of a constant that represents this menu command in the generated code.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;7. Type the name(My Tool Window) and ID(cmdidMyTool) for new tool window in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; text boxes, and click Next.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;8. Uncheck the Intergration Test Project and Unit Test Project, then click<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Finish.<br>
<br>
B: Customize the ToolWindow<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. In Solution Explorer, MyControls.cs in the WinForm Designer.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Delete the ClickMe button and add the Windows Media control to MyControls.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Set the Dock property to Fill.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
C: Add a Toolbar to the Tool Window<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. In Solution Explorer, open CSVSToolWindow.vsct.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VSCT file stands for Visual Studio Command Table. This is an XML based file that
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; describes the layout and appearance of command items for a VSPackage. Command
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; items include buttons, combo boxes, menus, toolbars, and groups of command items.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. In the &lt;Symbols&gt; section, find the &lt;GuidSymbol&gt; node whose name attribute is
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; guidCSVSToolWindowCmdSet. Add the following two &lt;IDSymbol&gt; elements to the list of
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;IDSymbol&gt; elements in this node to define a toolbar and a toolbar group.
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;IDSymbol name=&quot;ToolbarID&quot; value=&quot;0x1000&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &lt;IDSymbol name=&quot;ToolbarGroupID&quot; value=&quot;0x1001&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Just above the &lt;Groups&gt; section, create an empty &lt;Menus&gt; section, and create the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; following &lt;Menu&gt; element to define the toolbar that you declared in step 2.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;Menus&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Menu guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;priority=&quot;0x0000&quot; type=&quot;ToolWindowToolbar&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ButtonText&gt;Tool Window Toolbar&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandName&gt;Tool Window Toolbar&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Menu&gt;<br>
&nbsp; &nbsp; &nbsp; &lt;/Menus&gt; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; &nbsp;4. Add a new &lt;Group&gt; element to the &lt;Groups&gt; section to define the group that you
<br>
&nbsp; &nbsp; &nbsp; declared in the &lt;Symbols&gt; section. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &lt;Group guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarGroupID&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;priority=&quot;0x0000&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &lt;/Group&gt;<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;5. Save CSVSToolWindow.vsct.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
D: Add a Toolbar to the Tool Window<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. In Solution Explorer, open CSVSToolWindow.vsct.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VSCT file stands for Visual Studio Command Table. This is an XML based file that
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; describes the layout and appearance of command items for a VSPackage. Command
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; items include buttons, combo boxes, menus, toolbars, and groups of command items.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. In the &lt;Symbols&gt; section, declare the following commands just after the toolbar<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; and toolbar group declarations. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;IDSymbol name=&quot;cmdidWindowsMediaOpen&quot; value=&quot;0x132&quot; /&gt;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. In the &lt;Buttons&gt; section, a &lt;Button&gt; element is already present and it contains
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; a definition forthe cmdidToolWindow command. Add one more &lt;Button&gt; element to
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; define the cmdidWindowsMedia and cmdidWindowsMediaOpen commands.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Button guid=&quot;guidCSVSToolWindowCmdSet&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;id=&quot;cmdidWindowsMediaOpen&quot; priority=&quot;0x0101&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;type=&quot;Button&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;id=&quot;ToolbarGroupID&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandFlag&gt;IconAndText&lt;/CommandFlag&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandName&gt;cmdidWindowsMediaOpen&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ButtonText&gt;Load File&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Button&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;4. Save and close CSVSToolWindow.vsct, open PkgCmdID.cs and add the following lines
<br>
&nbsp; &nbsp; &nbsp; in the class just after the existing members<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public const int cmdidWindowsMediaOpen = 0x132;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public const int ToolbarID = 0x1000;<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;5. Save PkgCmdID.cs<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
E: Implement the Commands:<br>
<br>
&nbsp; &nbsp;1. In Solution Explorer, open MyToolWindow.cs, which contains the class for the tool
<br>
&nbsp; &nbsp; &nbsp; window itself. Add the following code just after the existing using statements.
<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; using System.ComponentModel.Design;<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;2. Add the following code to the constructor, just before the line that says
<br>
&nbsp; &nbsp; &nbsp; control = new MyControl(). <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Create the toolbar.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ToolBar = new CommandID(GuidList.guidCSVSToolWindowCmdSet,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PkgCmdIDList.ToolbarID);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ToolBarLocation = (int)VSTWT_LOCATION.VSTWT_TOP;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Create the handlers for the toolbar commands.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var mcs = GetService(typeof(IMenuCommandService))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;as OleMenuCommandService;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (null != mcs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var toolbarbtnCmdID = new CommandID(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GuidList.guidCSVSToolWindowCmdSet,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PkgCmdIDList.cmdidWindowsMediaOpen);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var menuItem = new MenuCommand(new EventHandler(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ButtonHandler), toolbarbtnCmdID);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;mcs.AddCommand(menuItem);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;3. In Solution Explorer, right-click MyControl.cs, click View Code, and add the following<br>
&nbsp; &nbsp; &nbsp; code to the end of the file, just before the final two closing braces.Save and close
<br>
&nbsp; &nbsp; &nbsp; MyControl.cs. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;public AxWMPLib.AxWindowsMediaPlayer MediaPlayer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get { return axWindowsMediaPlayer1; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;4. Open to MyToolWindow.cs, and add the following handler at the end of the class, just before
<br>
&nbsp; &nbsp; &nbsp; the two final closing braces. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ButtonHandler(object sender, EventArgs arguments)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OpenFileDialog fd = new OpenFileDialog();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fd.Filter = &quot;media files |*.wmv;*.asf&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fd.Multiselect = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (DialogResult.OK == fd.ShowDialog())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;control.MediaPlayer.URL = fd.FileName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;5. Save all the files.<br>
<br>
F: Testing the Tool Window<br>
<br>
&nbsp; &nbsp;1. Press F5 to open a new instance of the Visual Studio experimental build.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;2. On the View menu, point to Other Windows and then click My Tool Window.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;3. Click the Load File button on the Tool Window and Select a media file.<br>
<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to: Create VSPackages (C# and Visual Basic)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">http://msdn.microsoft.com/en-us/library/bb164725.aspx</a><br>
<br>
How to: Register a VSPackage (C#)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166544.aspx">http://msdn.microsoft.com/en-us/library/bb166544.aspx</a><br>
<br>
<br>
VSPackage Tutorial 1: How to Create a VSPackage<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">http://msdn.microsoft.com/en-us/library/cc138589.aspx</a><br>
<br>
Designing XML Command Table (.Vsct) Files<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166366.aspx">http://msdn.microsoft.com/en-us/library/bb166366.aspx</a><br>
<br>
Commands Element<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165399.aspx">http://msdn.microsoft.com/en-us/library/bb165399.aspx</a><br>
<br>
KeyBindings Element<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165085.aspx">http://msdn.microsoft.com/en-us/library/bb165085.aspx</a><br>
<br>
VSPackage Tutorial 2: How to Create a Tool Window<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc138567.aspx">http://msdn.microsoft.com/en-us/library/cc138567.aspx</a><br>
<br>
Creating a package with a simple command<br>
<a target="_blank" href="http://dotneteers.net/blogs/divedeeper/archive/2008/01/06/LearnVSXNowPart3.aspx">http://dotneteers.net/blogs/divedeeper/archive/2008/01/06/LearnVSXNowPart3.aspx</a><br>
<br>
Menus and comands in VS IDE<br>
<a target="_blank" href="http://dotneteers.net/blogs/divedeeper/archive/2008/02/22/LearnVSXNowPart13.aspx">http://dotneteers.net/blogs/divedeeper/archive/2008/02/22/LearnVSXNowPart13.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
