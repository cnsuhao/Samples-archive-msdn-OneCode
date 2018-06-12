# VSPackage closes open file in VS (CSVSPackageCloseOpenedDocument)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Close already open document
## IsPublished
* False
## ModifiedDate
* 2011-05-05 06:31:36
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio VSPackage : CSVSPackageCloseOpenedDocument Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to close the document which is already open in<br>
another editor.<br>
<br>
In Visual Studio, a specific editor cannot open the document which is already<br>
open by another editor. &nbsp;For example, if a .cs file is already open with<br>
Code Editor, trying to open that .cs file with XML Editor will cause a dialog<br>
comes out saying &quot;The document 'xxx.cs' is already open. &nbsp;Do you want to<br>
close it?&quot;<br>
Another example is, in VC&#43;&#43; project, the Resource View toolwindow will always<br>
trying to open the .rc file in a invisible editor(IVsInvisibleEditor) and<br>
track its change to update the information in its tree view. &nbsp;So if we want<br>
to open the .rc file with Code Editor(right-click -&gt; View Code) for seeing<br>
its source code, the same dialog will appear.<br>
<br>
In this sample, it shows how to use the IVsRunningDocumentTable interface to<br>
access the RDT(Running Document Table), find out the opened document and<br>
lock it, then trying to close it, so that other editors can open the same<br>
document without the dialog prompt showing.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
VS 2008 SDK must be installed on the machine. You can download it from:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-">http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-</a><br>
867c-04dc45164f5b&displaylang=en<br>
<br>
Otherwise the project may not be opened by Visual Studio.<br>
<br>
NOTE: The Package Load Failure Dialog occurs because there is no<br>
&nbsp; &nbsp; &nbsp;PLK(Package Load Key) Specified in this package. To obtain a PLK, please<br>
&nbsp; &nbsp; &nbsp;to go to WebSite:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/vsx/cc655795.aspx">http://msdn.microsoft.com/en-us/vsx/cc655795.aspx</a><br>
&nbsp; &nbsp; &nbsp;More info:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">http://msdn.microsoft.com/en-us/library/bb165395.aspx</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Studio Integration Package project from the New<br>
Project dialog named CSVSPackageCloseOpenedDocument, choose Visual C# as<br>
the development language.<br>
Check the Menu Command checkbox to create a menu command.<br>
<br>
Step2. Open the CSVSPackageCloseOpenedDocumentPackage.cs file, define a<br>
method named CloseAndOpenInXMLEditor which will trying to open a file with<br>
XML Editor, if the document is already open in another editor, close it from<br>
the RDT.<br>
<br>
private void CloseAndOpenInXMLEditor(string filePath)<br>
{<br>
&nbsp; &nbsp;IVsHierarchy ppHier = null;<br>
&nbsp; &nbsp;uint pitemid = Microsoft.VisualStudio.VSConstants.VSITEMID_NIL;<br>
&nbsp; &nbsp;IntPtr ppunkDocData = IntPtr.Zero;<br>
&nbsp; &nbsp;uint pdwCookie = Microsoft.VisualStudio.VSConstants.VSITEMID_NIL;<br>
<br>
&nbsp; &nbsp;try<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Get the IVsRunningDocumentTable interface and cast it to<br>
&nbsp; &nbsp; &nbsp; &nbsp;// IVsRunningDocumentTable2 interface.<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsRunningDocumentTable rdt =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetService(typeof(SVsRunningDocumentTable))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;as IVsRunningDocumentTable;<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsRunningDocumentTable2 rdt2 = rdt as IVsRunningDocumentTable2;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Find the opened document(.rc file) from the RDT.<br>
&nbsp; &nbsp; &nbsp; &nbsp;rdt.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, filePath,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;out ppHier, out pitemid, out ppunkDocData, out pdwCookie);<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (ppunkDocData != IntPtr.Zero)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Close the opened document.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;rdt2.CloseDocuments((uint)__FRAMECLOSE.FRAMECLOSE_SaveIfDirty,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;null, pdwCookie));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ppunkDocData = IntPtr.Zero;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsInvisibleEditorManager spIEM;<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsInvisibleEditor invisibleEditor = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsWindowFrame winFrame = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Guid logicalView = Microsoft.VisualStudio.VSConstants.LOGVIEWID_Primary;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Get the IVsInvisibleEditorManager interface.<br>
&nbsp; &nbsp; &nbsp; &nbsp;spIEM = (IVsInvisibleEditorManager)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetService(typeof(IVsInvisibleEditorManager));<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Register a invisible editor, then the specific document will be<br>
&nbsp; &nbsp; &nbsp; &nbsp;// loaded into the RDT.<br>
&nbsp; &nbsp; &nbsp; &nbsp;spIEM.RegisterInvisibleEditor(filePath, null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(uint)_EDITORREGFLAGS.RIEF_ENABLECACHING,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;null, out invisibleEditor);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Get the IVsUIShellOpenDocument interface.<br>
&nbsp; &nbsp; &nbsp; &nbsp;IVsUIShellOpenDocument uiShellOpenDocument =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetService(typeof(SVsUIShellOpenDocument))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;as IVsUIShellOpenDocument;<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Guid of the Microsoft XML editor<br>
&nbsp; &nbsp; &nbsp; &nbsp;Guid guidXMLEditor = new Guid(&quot;{FA3CD31E-987B-443A-9B81-186104E8DAC1}&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;rdt.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, filePath,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;out ppHier, out pitemid, out ppunkDocData, out pdwCookie);<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Open the document in XML editor.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;uiShellOpenDocument.OpenSpecificEditor((uint)0, filePath,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ref guidXMLEditor, &quot;&quot;, ref logicalView, &quot;XML Editor&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ppHier as IVsUIHierarchy, pitemid,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ppunkDocData, this, out winFrame));<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Show the editor window.<br>
&nbsp; &nbsp; &nbsp; &nbsp;winFrame.Show();<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;catch (Exception e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;System.Windows.Forms.MessageBox.Show(e.Message);<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Step3. Call the method CloseAndOpenInXMLEditor in the menu command handler,<br>
replace the default message box.<br>
<br>
private void MenuItemCallback(object sender, EventArgs e)<br>
{<br>
&nbsp; &nbsp;CloseAndOpenInXMLEditor(@&quot;E:\Projects\TestProject\TestProject\TestProject.cs&quot;);<br>
}<br>
<br>
To test the method CloseAndOpenInXMLEditor, you will need to replace the<br>
passed file to the specific one you want to open in XML Editor.<br>
<br>
Step4. Save and compile the project.<br>
<br>
Step5. Run this VSPackage in a new instance of Visual Studio(simply press F5),<br>
open a existing project in the new instance of Visual Studio, open a project<br>
file with the Code Editor(e.g.: double-click a .cs file in Solution Explorer).<br>
Then run our method from Tools -&gt; CSVSPackageCloseOpenedDocument, you will<br>
see the opened document being closed then opened again in XML Editor without<br>
the &quot;The document 'xxx.cs' is already open. &nbsp;Do you want to close it?&quot; dialog<br>
being shown.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: IVsRunningDocumentTable Interface<br>
<a target="_blank" href="&lt;a target=" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a><br>
.ivsrunningdocumenttable(VS.80).aspx<br>
<br>
MSDN: IVsRunningDocumentTable2 Interface<br>
<a target="_blank" href="&lt;a target=" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a><br>
.ivsrunningdocumenttable2(VS.80).aspx<br>
<br>
MSDN: IVsUIShellOpenDocument.OpenSpecificEditor Method<br>
<a target="_blank" href="&lt;a target=" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop</a><br>
.ivsuishellopendocument.openspecificeditor.aspx<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
