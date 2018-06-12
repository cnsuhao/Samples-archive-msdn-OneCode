# Shell known folder sample (VBShellKnownFolders)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Shell
## Topics
* Shell known folder
## IsPublished
* False
## ModifiedDate
* 2011-05-05 08:09:29
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBShellKnownFolders Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The Known Folder system provides a way to interact with certain high-profile <br>
folders that are present by default in Microsoft Windows. It also allows <br>
those same interactions with folders installed and registered with the Known <br>
Folder system by applications. This sample demonstrates those possible <br>
interactions in VB.NET as they are provided by the Known Folder APIs.<br>
<br>
A. Enumerate and print all known folders.<br>
<br>
B. Print some built-in known folders like FOLDERID_ProgramFiles in two <br>
different ways.<br>
<br>
C. Extend known folders with custom folders. (The feature is not demonstrated <br>
in the current sample, because the APIs for extending known folders with <br>
custom folders have not been exposed from Windows API Code Pack for Microsoft <br>
.NET Framework.)<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Windows API Code Pack for Microsoft .NET Framework <br>
<a target="_blank" href="&lt;a target=" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a>'&gt;<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Enumerate and print all known folders. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;For Each kf As IKnownFolder In KnownFolders.All<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(&quot;{0}: {1}&quot;, kf.CanonicalName, kf.Path)<br>
&nbsp;&nbsp;&nbsp;&nbsp;Next<br>
<br>
B. Print some built-in known folders like FOLDERID_ProgramFiles in two &nbsp;<br>
different ways.<br>
<br>
&nbsp;Method 1. Use KnownFolders.ProgramFiles<br>
&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;folderPath = KnownFolders.ProgramFiles.Path<br>
&nbsp;<br>
&nbsp;Method 2. Use .NET BCL Environment.GetFolderPath<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;folderPath = Environment.GetFolderPath( _<br>
&nbsp;&nbsp;&nbsp;&nbsp;Environment.SpecialFolder.ProgramFiles)<br>
<br>
C. Extend known folders with custom folders. (The feature is not demonstrated <br>
in the current sample, because the APIs for extending known folders with <br>
custom folders have not been exposed from Windows API Code Pack for Microsoft <br>
.NET Framework.)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Working with Known Folders in Applications<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776912(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb776912(VS.85).aspx</a><br>
<br>
MSDN: Default Known Folders in Windows<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd378457(VS.85).aspx">http://msdn.microsoft.com/en-us/library/dd378457(VS.85).aspx</a><br>
<br>
MSDN: Extending Known Folders with Custom Folders<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776910(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb776910(VS.85).aspx</a><br>
<br>
Windows API Code Pack for Microsoft .NET Framework <br>
<a target="_blank" href="&lt;a target=" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a>'&gt;<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
