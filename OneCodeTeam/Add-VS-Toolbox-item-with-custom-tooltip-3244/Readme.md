# Add VS Toolbox item with custom tooltip (CSCustomizeVSToolboxItem)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Toolbox
## IsPublished
* True
## ModifiedDate
* 2011-05-26 02:06:20
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Package Project: CSCustomizeVSToolboxItem</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
If you add a new item to Visual Studio 2010 toolbox, the display name and <br>
tooltip of the new item is the same by default. &nbsp;The sample demonstrates how
<br>
to add an item with custom tooltip to Visual Studio Toolbox.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
Visual Studio 2010 Premium or Visual Studio 2010 Ultimate. Visual Studio 2010 SDK.<br>
<br>
NOTE: VS2010 SP1 should be applied after the installation of VS SDK.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in Visual Studio 2010 Professional or better. <br>
<br>
Step2. Open the property page of this project and choose Debug tab. Set the Start Option<br>
&nbsp; &nbsp; &nbsp; to Start external program and browse the devenv.exe (The default location is
<br>
&nbsp; &nbsp; &nbsp; C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe), and add<br>
&nbsp; &nbsp; &nbsp; &quot;/rootsuffix Exp&quot; (no quote) to the Command line arguments.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step3. Build the solution. <br>
<br>
Step4. Press F5, and the Experimental Instance of Microsoft Visual Studio 2010 will
<br>
&nbsp; &nbsp; &nbsp; be launched.<br>
<br>
Step5. In the VS Experimental Instance, open a new or existing solution and start to edit
<br>
&nbsp; &nbsp; &nbsp; a .txt file. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <br>
Step6. Open the toolbox window, you will find a new tab called &quot;CS Custom Toolbox Tab&quot; and<br>
&nbsp; &nbsp; &nbsp; a new item &quot;CS Custom Toolbox Item&quot;. Move mouse over this item, and you can see following
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; tooltip:<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; CS Custom Toolbox Tooltip<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; CS Custom Toolbox Description <br>
<br>
Step7. Drag the new toolbox item and drop it to the .txt file, &quot;CS Hello world&quot; will be added
<br>
&nbsp; &nbsp; &nbsp; to the file. &nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create a VSIX project.<br>
<br>
1. Select the Visual Studio Package project template. In the Name box, type a name for the
<br>
&nbsp; solution and then click OK.<br>
<br>
&nbsp; The Visual Studio Package project template is available in these locations in the New
<br>
&nbsp; Project dialog box:<br>
&nbsp; &nbsp; &nbsp; Under Visual Basic Extensibility. By default, the language of the project is Visual Basic.<br>
&nbsp; &nbsp; &nbsp; Under C# Extensibility. By default, the language of the project is C#.<br>
&nbsp; &nbsp; &nbsp; Under Other Project Types Extensibility. By default, the language of the project is C&#43;&#43;.<br>
<br>
2. On the Select a Programming Language page, select either Visual C#. Have the template
<br>
&nbsp; generate a key.snk file to sign the assembly. Alternatively, click Browse to select your<br>
&nbsp; own key file. The template makes a copy of your key file and names it key.snk.
<br>
<br>
3. On the Basic VSPackage Information page, specify details about your VSPackage.
<br>
<br>
4. Click Finish to complete the creation. <br>
<br>
5. Optionally, select Integration Test Project and Unit Test Project to create test<br>
&nbsp; projects for your solution.<br>
<br>
&nbsp; For more information, see <br>
&nbsp; Walkthrough: Creating a Menu Command By Using the Visual Studio Package Template.<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">
http://msdn.microsoft.com/en-us/library/bb164725.aspx</a><br>
<br>
&nbsp; NOTE: Command menu does not have to be selected.<br>
<br>
<br>
B. Override the Initialize method in CSCustomizeVSToolboxItemPackage.<br>
<br>
&nbsp; In this method, get the IVsToolbox2 and IVsActivityLog services.<br>
<br>
<br>
C. Add custom toolbox item. <br>
&nbsp; <br>
&nbsp; Verify whether the ToolboxTab and ToolboxItem exist, if not, add custom toolbox item.<br>
<br>
&nbsp; using (var stream = SaveStringToStreamRaw(FormatTooltipData(toolboxTooltipString, toolboxDescriptionString)))<br>
&nbsp; {<br>
&nbsp; &nbsp; &nbsp; var toolboxData = new Microsoft.VisualStudio.Shell.OleDataObject();<br>
&nbsp; &nbsp; &nbsp; toolboxData.SetData(&quot;VSToolboxTipInfo&quot;, stream);<br>
&nbsp; &nbsp; &nbsp; toolboxData.SetData(DataFormats.Text, &quot;Hello world&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; TBXITEMINFO[] itemInfo = new TBXITEMINFO[1];<br>
&nbsp; &nbsp; &nbsp; itemInfo[0].bstrText = toolboxItemString;<br>
&nbsp; &nbsp; &nbsp; itemInfo[0].hBmp = IntPtr.Zero;<br>
&nbsp; &nbsp; &nbsp; itemInfo[0].dwFlags = (uint)__TBXITEMINFOFLAGS.TBXIF_DONTPERSIST;<br>
<br>
&nbsp; &nbsp; &nbsp; ErrorHandler.ThrowOnFailure(vsToolbox2.AddItem(toolboxData, itemInfo, toolboxTabString));<br>
&nbsp; }<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Walkthrough: Customizing ToolboxItem Configuration Dynamically<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165910.aspx">http://msdn.microsoft.com/en-us/library/bb165910.aspx</a><br>
<br>
Walkthrough: Autoloading Toolbox Items<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166237.aspx">http://msdn.microsoft.com/en-us/library/bb166237.aspx</a><br>
<br>
VSIX Deployment<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff363239.aspx">http://msdn.microsoft.com/en-us/library/ff363239.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
