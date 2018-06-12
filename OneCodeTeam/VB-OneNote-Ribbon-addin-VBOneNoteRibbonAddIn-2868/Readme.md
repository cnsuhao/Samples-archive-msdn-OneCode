# VB OneNote Ribbon addin (VBOneNoteRibbonAddIn)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
* Ribbon
* OneNote
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:59:01
## Description

<p style="font-family:Courier New"></p>
<h2>APPLICATION : VBOneNoteRibbonAddIn Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary: </h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates a OneNote 2010 COM add-in that implements <br>
IDTExtensibility2. <br>
The add-in also supports customizing the Ribbon by implementing the <br>
IRibbonExtensibility interface.<br>
In addition, the sample also demonstrates the usage of the <br>
OneNote 2010 Object Model.<br>
<br>
VBOneNoteRibbonAddIn: The project which generates VBOneNoteRibbonAddIn.dll <br>
for project VBOneNoteRibbonAddInSetup.<br>
<br>
VBOneNoteRibbonAddInSetup: The setup project which generates setup.exe and <br>
VBOneNoteRibbonAddInSetup.msi for OneNote 2010.<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
You must run this code sample on a computer that has Microsoft OneNote 2010 <br>
installed.<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the VBOneNoteRibbonAddIn<br>
sample.<br>
<br>
Step1. Open the solution file CSOneNoteRibbonAddIn.sln as Administrator;<br>
<br>
Step2. Build VBOneNoteRibbonAddIn first, and then build setup project <br>
VBOneNoteRibbonAddInSetup in Visual Studio 2010, then you will get a <br>
bootstrapper setup.exe and the application VBOneNoteRibbonAddInSetup.msi;<br>
<br>
Step3. Install setup.exe;<br>
<br>
Step4. Open OneNote 2010 and you will see three MesseageBoxs:<br>
MessageBox.Show(&quot;VBOneNoteRibbonAddIn OnConnection&quot;)<br>
MessageBox.Show(&quot;VBOneNoteRibbonAddIn OnAddInsUpdate&quot;)<br>
MessageBox.Show(&quot;VBOneNoteRibbonAddIn OnStartupComplete&quot;);<br>
<br>
Step5. Click Review Tab and you will see Statistics group which contains a<br>
button ShowForm which the add-in added to the Ribbon. Click the ShowForm <br>
button, a windows form will pop up and you can click the button on the form <br>
to get the title of the current page;<br>
<br>
Step6. When closing OneNote 2010, you will see two MessageBoxs:<br>
MessageBox.Show(&quot;VBOneNoteRibbonAddIn OnBeginShutdown&quot;)<br>
MessageBox.Show(&quot;VBOneNoteRibbonAddIn OnDisconnection&quot;)<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Shared Add-in Extensibility,and the shared Add-in Wizard is <br>
as follows:<br>
&nbsp;&nbsp;&nbsp;&nbsp;Open the Visual Studio 2010 as Administrator;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Create an Shared Add-in (Other Project Types-&gt;Extensibility)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;using Visual Basic; <br>
&nbsp;&nbsp;&nbsp;&nbsp;choose Microsoft Access&nbsp;&nbsp;&nbsp;&nbsp;(since there doesn't exist Microsoft OneNote<br>
&nbsp;&nbsp;&nbsp;&nbsp;option to choose, you can choose Microsoft Access first, but remeber
<br>
&nbsp;&nbsp;&nbsp;&nbsp;to modify Setup project registry HKCU to be OneNote);<br>
&nbsp;&nbsp;&nbsp;&nbsp;fill name and description of the Add-in;<br>
&nbsp;&nbsp;&nbsp;&nbsp;select the two checkboxes in Choose Add-in Options.<br>
<br>
Step2. Modify the VBOneNoteRibbonAddInSetup Registry <br>
(right click Project-&gt;View-&gt;Registry) <br>
[HKEY_CLASSES_ROOT\AppID\{Your GUID}]<br>
&quot;DllSurrogate&quot;=&quot;&quot;<br>
[HKEY_CLASSES_ROOT\CLSID\{Your GUID}]<br>
&quot;AppID&quot;=&quot;{Your GUID}&quot;<br>
<br>
[HKEY_CURRENT_USER\Software\Microsoft\Office\OneNote\AddIns\<br>
VBOneNoteRibbonAddIn.Connect]<br>
&quot;LoadBehavior&quot;=dword:00000003<br>
&quot;FriendlyName&quot;=&quot;OneNoteRibbonAddInSample&quot;<br>
&quot;Description&quot;=&quot;OneNote2010 Ribbon AddIn Sample&quot;<br>
<br>
[HKEY_LOCAL_MACHINE\SOFTWARE\Classes\AppID\{Your GUID}]<br>
&quot;DllSurrogate&quot;=&quot;&quot;<br>
[HKEY_LOCAL_MACHINE\SOFTWARE\Classes\CLSID\{Your GUID}]<br>
&quot;AppID&quot;=&quot;{Your GUID}&quot;<br>
<br>
Step3. Add customUI.xml and showform.png resource files into <br>
VBOneNoteRibbonAddIn project.<br>
<br>
Step4. Make Connect class inherent IRibbonExtensibility and implement the method <br>
GetCustomUI.<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' &nbsp; &nbsp; Loads the XML markup from an XML customization file
<br>
&nbsp; &nbsp;''' &nbsp; &nbsp; that customizes the Ribbon user interface.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;RibbonID&quot;&gt;The ID for the RibbonX UI&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;string&lt;/returns&gt;<br>
&nbsp; &nbsp;Public Function GetCustomUI(ByVal RibbonID As String) As String _<br>
&nbsp; &nbsp; &nbsp; &nbsp;Implements IRibbonExtensibility.GetCustomUI<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return Resources.customUI<br>
&nbsp; &nbsp;End Function<br>
Step5. Implement the methods OnGetImage and ShowForm according to the customUI.xml
<br>
content.<br>
<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' &nbsp; &nbsp; Implements the OnGetImage method in customUI.xml<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;imageName&quot;&gt;the image name in customUI.xml&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;memory stream contains image&lt;/returns&gt;<br>
&nbsp; &nbsp;Public Function OnGetImage(ByVal imageName As String) As IStream<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim stream As New MemoryStream()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;If imageName = &quot;showform.png&quot; Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Resources.showform.Save(stream, ImageFormat.Png)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return New ReadOnlyIStreamWrapper(stream)<br>
&nbsp; &nbsp;End Function<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' &nbsp; &nbsp; show Windows Form method<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;control&quot;&gt;Represents the object passed into every<br>
&nbsp; &nbsp;''' Ribbon user interface (UI) control's callback procedure.&lt;/param&gt;<br>
&nbsp; &nbsp;Public Sub ShowForm(ByVal control As IRibbonControl)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim context As OneNote.Window = TryCast(control.Context, OneNote.Window)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim owner As New CWin32WindowWrapper(CType(context.WindowHandle, IntPtr))<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim form As New TestForm(TryCast(applicationObject, OneNote.Application))<br>
&nbsp; &nbsp; &nbsp; &nbsp;form.ShowDialog(owner)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;form.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp;form = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;context = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;owner = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp;GC.Collect()<br>
&nbsp; &nbsp; &nbsp; &nbsp;GC.WaitForPendingFinalizers()<br>
&nbsp; &nbsp; &nbsp; &nbsp;GC.Collect()<br>
&nbsp; &nbsp;End Sub<br>
<br>
Step6. Add ReadOnlyIStreamWrapper class and CWin32WindowWrapper class into <br>
VBOneNoteRibbonAddIn project and add Windows Form for testing to open.<br>
<br>
Step7. Add the follwing methods in the TestForm which using OneNote 2010 Object Model<br>
to show the title of the current page:<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Get the title of the page<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;string&lt;/returns&gt;<br>
&nbsp; &nbsp;Private Function GetPageTitle() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim pageXmlOut As String = GetActivePageContent()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim doc = XDocument.Parse(pageXmlOut)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim pageTitle As String = &quot;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;pageTitle = doc.Descendants().FirstOrDefault().Attribute(&quot;ID&quot;).NextAttribute.Value<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return pageTitle<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Get active page content and output the xml string<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;string&lt;/returns&gt;<br>
&nbsp; &nbsp;Private Function GetActivePageContent() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim activeObjectID As String = Me.GetActiveObjectID(_ObjectType.Page)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim pageXmlOut As String = &quot;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;oneNoteApp.GetPageContent(activeObjectID, pageXmlOut)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return pageXmlOut<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Get ID of current page <br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;''' &lt;param name=&quot;obj&quot;&gt;_Object Type&lt;/param&gt;<br>
&nbsp; &nbsp;''' &lt;returns&gt;current page Id&lt;/returns&gt;<br>
&nbsp; &nbsp;Private Function GetActiveObjectID(ByVal obj As _ObjectType) As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim currentPageId As String = &quot;&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim count As UInteger = oneNoteApp.Windows.Count<br>
&nbsp; &nbsp; &nbsp; &nbsp;For Each window As OneNote.Window In oneNoteApp.Windows<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If window.Active Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Select Case obj<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case _ObjectType.Notebook<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;currentPageId = window.CurrentNotebookId<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case _ObjectType.Section<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;currentPageId = window.CurrentSectionId<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Case _ObjectType.SectionGroup<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;currentPageId = window.CurrentSectionGroupId<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Exit Select<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Select<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;currentPageId = window.CurrentPageId<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Next<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return currentPageId<br>
<br>
&nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Nested types<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private Enum _ObjectType<br>
&nbsp; &nbsp; &nbsp; &nbsp;Notebook<br>
&nbsp; &nbsp; &nbsp; &nbsp;Section<br>
&nbsp; &nbsp; &nbsp; &nbsp;SectionGroup<br>
&nbsp; &nbsp; &nbsp; &nbsp;Page<br>
&nbsp; &nbsp; &nbsp; &nbsp;SelectedPages<br>
&nbsp; &nbsp; &nbsp; &nbsp;PageObject<br>
&nbsp; &nbsp;End Enum<br>
<br>
Step8. Register the output assembly as COM component.<br>
<br>
To do this, click Project-&gt;Project Properties... button. And in the project<br>
properties page, navigate to Build tab and check the box &quot;Register for COM<br>
interop&quot;.<br>
<br>
Step8. Build your VBOneNoteRibbonAddIn project, <br>
and then build VBOneNoteRibbonAddInSetup project to generate setup.exe and <br>
VBOneNoteRibbonAddInSetup.msi.<br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating OneNote 2010 Extensions with the OneNote Object Model<br>
<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/ff796230.aspx">http://msdn.microsoft.com/en-us/magazine/ff796230.aspx</a><br>
<br>
Jeff Cardon's Blog<br>
<a target="_blank" href="http://blogs.msdn.com/b/onenotetips/">http://blogs.msdn.com/b/onenotetips/</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
