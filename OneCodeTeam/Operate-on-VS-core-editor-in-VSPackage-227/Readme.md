# Operate on VS core editor in VSPackage (CSVSPackageInvokeCoreEditor)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Visual Studio Core Editor
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:32:13
## Description

<p style="font-family:Courier New"></p>
<h2>VSX application : CSVSPackageInvokeCoreEditor Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New">The Visual Studio core editor is the default editor of Visual Studio.
<br>
The editor supports text-editing functions such as insert, delete, <br>
copy, and paste. Its functionality combines with that provided by the <br>
language that it is currently editing, such as text colorization, <br>
indentation, and IntelliSense statement completion.<br>
<br>
This sample demostrates the basic operations on Core Editor, which<br>
includes:<br>
1. Initiate core editor, include IVsTextBuffer and IVsCodeWindow<br>
2. Associating core editor with file extension: .aio<br>
3. Providing an options page in Tools / Options to let user to choose<br>
languages (VB, CS and XML) in the core editor.<br>
<br>
To use this sample, here is the suggested demo steps:<br>
1. Open Tools / Options / CSVSPackageInvokeCoreEditor Options / <br>
Language Service Settings / Select one language:<br>
None: represents no language service<br>
VB: Visual Basic<br>
CS: C#<br>
XML: XML language<br>
After selecting language settings, please save the changes and close <br>
options page<br>
<br>
2. File / Open / Go to path: <br>
[All-In-One Root Folder]/CSVSPackageInvokeCoreEditor/DemoFiles<br>
and select one file with name: demo.[Language].aio<br>
<br>
3. After the file is opened by Visual Studio, you will see:<br>
a. The file name is suffixed with &quot; [CSVSPackageInvokeCoreEditor]&quot;<br>
b. The editor has functionality of the selected language service like <br>
coloring.<br>
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
<h3></h3>
<p style="font-family:Courier New">Steps:<br>
In order to implement this sample, following are the core steps:<br>
(For detailed informaiton, please view sample code)<br>
<br>
1. Create class EditorFactory which inherits from IVsEditorFactory.<br>
<br>
2. Implement IVsEditorFactory.CreateEditorInstance method.<br>
<br>
3. Obtain a IVsTextBuffer to hold the document data object being edited.<br>
<br>
4. Get LanguageServiceOptionsPage's user setting and SetLanguageServiceID <br>
with selected language guid.<br>
Language service has following guid:<br>
public const string guidVBLangSvcString = <br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;{E34ACDC0-BAAE-11D0-88BF-00A0C9110049}&quot;;<br>
public const string guidCSharpLangSvcString = <br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;{694DD9B6-B865-4C5B-AD85-86356E9C88DC}&quot;;<br>
public const string guidXmlLangSvcString = <br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;{f6819a78-a205-47b5-be1c-675b3c7f0b8e}&quot;;<br>
More languages' guid can be found in <br>
&quot;HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\9.0\<br>
Languages\Language Services&quot;<br>
<br>
5. Gets a GUID value in Microsoft.VisualStudio.TextManager.Interop.IVsUserData<br>
that, when set to false, will stop the core editor for searching for a different<br>
language service.<br>
This operation prevents situation when one file extension is associated with<br>
multiple languages.<br>
<br>
6. Create a line oriented representation of the document data object by <br>
creating an IVsTextLines interface from the IVsTextBuffer interface. <br>
<br>
7. Set IVsTextLines as the document data object for an instance of the <br>
default implementation of the IVsCodeWindow interface, using the SetBuffer <br>
method.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Instantiating the Core Editor<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166530.aspx">http://msdn.microsoft.com/en-us/library/bb166530.aspx</a><br>
<br>
Language Service and the Core Editor<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166541.aspx">http://msdn.microsoft.com/en-us/library/bb166541.aspx</a><br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
