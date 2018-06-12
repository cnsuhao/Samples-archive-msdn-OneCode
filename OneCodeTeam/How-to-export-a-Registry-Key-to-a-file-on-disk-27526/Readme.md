# How to export a Registry Key to a file on disk
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Desktop App Development
* System Services
## Topics
* Platforms SDK
## IsPublished
* True
## ModifiedDate
* 2014-03-03 11:11:25
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Export a Registry key (</span><span style="font-weight:bold; font-size:14pt">Cpp</span><span style="font-weight:bold; font-size:14pt">RegistryExport)</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample exports the registry key to a file on disk. This file can be used on another machine to create same registry key.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After building the sample, you can use the exe and provide the commandline arguments like this-</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Usage:</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">RegistryExport.exe &lt;Root Key&gt; &lt;Subkey&gt; &lt;Full file path&gt;</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">Example:</span><span style="font-size:11pt"> <br clear="all">
</span><span style="font-size:11pt">RegistryExport.exe HKLM Software\Microsoft\Storage C:\temp\regexport.txt</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><br clear="all">
</span><span style="font-size:11pt">Root Keys-</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">HKLM HKEY_LOCAL_MACHINE</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">HKCU HKEY_CURRENT_USER</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">HKCR HKEY_CLASSES_ROOT</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">HKU HKEY_USERS</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">For HKEY_LOCAL_MACHINE, just use HKLM. Similar for other root keys.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The sample gets the arguments from the user commandline. At start it process the supplied arguments.</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">After this, the sample try to enable SE_BACKUP_NAME privilege.
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms724917(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/desktop/ms724917(v=vs.85).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt">Then the sample uses RegSaveKey() and RegSaveKeyEx() to save the registry to file on disk.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Consider documentation for RegSaveKey() and RegSaveKeyEx().</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms724917(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/desktop/ms724917(v=vs.85).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms724919(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/desktop/ms724919(v=vs.85).aspx</span></a><span style="font-size:11pt">
<br clear="all">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
