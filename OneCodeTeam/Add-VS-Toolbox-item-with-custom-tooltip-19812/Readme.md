# Add VS Toolbox item with custom tooltip (VBCustomizeVSToolboxItem)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* Toolbox
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:15:51
## Description
================================================================================<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Visual Studio Package Project: VBCustomizeVSToolboxItem &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
If you add a new item to Vs2008 toolbox, the display name and tooltip of the new item are
<br>
the same by default. The sample demonstrates how to add an item with custom tooltip to<br>
Visual Studio Toolbox.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Prerequisite<br>
<br>
Visual Studio 2008 Standard Edition. Visual Studio 2008 SDK.<br>
<br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Open this project in Visual Studio 2008 Standard Edition or better. <br>
<br>
Step2. Open the property page of this project and choose Debug tab. Set the Start Option<br>
&nbsp; &nbsp; &nbsp; to Start external program and browse the devenv.exe (The default location is
<br>
&nbsp; &nbsp; &nbsp; C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe), and add<br>
&nbsp; &nbsp; &nbsp; &quot;/ranu /rootsuffix Exp&quot; (no quote) to the Command line arguments.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step3. Build the solution. <br>
<br>
Step4. Press F5, and the Experimental Instance of Microsoft Visual Studio 2008 will
<br>
&nbsp; &nbsp; &nbsp; be launched.<br>
<br>
Step5. In the VS Experimental Instance, open a new or existing solution and start to edit
<br>
&nbsp; &nbsp; &nbsp; a .txt file. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <br>
Step6. Open the toolbox window, you will find a new tab called &quot;VB Custom Toolbox Tab&quot; and<br>
&nbsp; &nbsp; &nbsp; a new item &quot;VB Custom Toolbox Item&quot;. Move mouse over this item, and you can see following
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; tooltip:<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VB Custom Toolbox Tooltip<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VB Custom Toolbox Description <br>
<br>
Step7. Drag the new toolbox item and drop it to the .txt file, &quot;VB Hello world&quot; will be added
<br>
&nbsp; &nbsp; &nbsp; to the file. &nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; &nbsp; &nbsp; <br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
A. Create a VSIX project.<br>
<br>
1. Select the Visual Studio Package project template. In the Name box, type a name for the
<br>
&nbsp; solution and then click OK.<br>
<br>
&nbsp; The Visual Studio Package project template is available in these locations in the New
<br>
&nbsp; Project dialog box:<br>
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
&nbsp; http://msdn.microsoft.com/en-us/library/bb164725.aspx<br>
<br>
&nbsp; NOTE: Command menu does not have to be selected.<br>
<br>
<br>
B. Override the Initialize method in VBCustomizeVSToolboxItemPackage.<br>
<br>
&nbsp; In this method, get the IVsToolbox2 and IVsActivityLog services.<br>
<br>
<br>
C. Add custom toolbox item. <br>
&nbsp; <br>
&nbsp; Verify whether the ToolboxTab and ToolboxItem exist, if not, add custom toolbox item.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;tooltipStream = SaveStringToStreamRaw(FormatTooltipData(toolboxTooltipString, toolboxDescriptionString))<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim toolboxData = New Microsoft.VisualStudio.Shell.OleDataObject()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Set the tooltip.<br>
&nbsp; &nbsp; &nbsp; &nbsp;toolboxData.SetData(&quot;VSToolboxTipInfo&quot;, tooltipStream)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Set the Drag-Drop text.<br>
&nbsp; &nbsp; &nbsp; &nbsp;toolboxData.SetData(DataFormats.Text, toolboxItemTextString)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim itemInfo(0) As TBXITEMINFO<br>
&nbsp; &nbsp; &nbsp; &nbsp;itemInfo(0).bstrText = toolboxItemString<br>
&nbsp; &nbsp; &nbsp; &nbsp;itemInfo(0).hBmp = IntPtr.Zero<br>
&nbsp; &nbsp; &nbsp; &nbsp;itemInfo(0).dwFlags = CUInt(__TBXITEMINFOFLAGS.TBXIF_DONTPERSIST)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;ErrorHandler.ThrowOnFailure(vsToolbox2.AddItem(toolboxData, itemInfo, toolboxTabString))<br>
<br>
&nbsp; <br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Walkthrough: Customizing ToolboxItem Configuration Dynamically<br>
http://msdn.microsoft.com/en-us/library/bb165910.aspx<br>
<br>
Walkthrough: Autoloading Toolbox Items<br>
http://msdn.microsoft.com/en-us/library/bb166237.aspx<br>
<br>
VSIX Deployment<br>
http://msdn.microsoft.com/en-us/library/ff363239.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
