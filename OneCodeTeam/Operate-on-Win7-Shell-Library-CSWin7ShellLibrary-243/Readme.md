# Operate on Win7 Shell Library (CSWin7ShellLibrary)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Shell
* Windows 7
## Topics
* Shell Library
## IsPublished
* False
## ModifiedDate
* 2011-05-05 06:42:37
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWin7ShellLibrary Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Libraries are the new entry points to user data in Windows 7. Libraries are a <br>
natural evolution of the My Documents folder concept that blends into the <br>
Windows Explorer user experience. A library is a common store of user defined <br>
locations that applications can leverage to manage user content as their part <br>
of the user experience. Because libraries are not file system locations, you <br>
will need to update some applications to work with them like folders. <br>
<br>
The CSWin7ShellLibrary example demonstrates how to create, open, delete, <br>
rename and manage shell libraries. It also shows how to add, remove and list <br>
folders in a shell library.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
Windows 7<br>
<a target="_blank" href="http://www.microsoft.com/windows/windows-7/">http://www.microsoft.com/windows/windows-7/</a><br>
<br>
Windows API Code Pack for Microsoft .NET Framework<br>
<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. In Visual Studio 2008, add a new Visual C# / Windows / Console <br>
Application project named CSWin7ShellLibrary.<br>
<br>
Step2. Add the reference to Microsoft.WindowsAPICodePack.dll and <br>
Microsoft.WindowsAPICodePack.Shell.dll available in Windows API Code Pack for <br>
Microsoft .NET Framework (<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a>),
<br>
and the assemblies that they rely on: System.Windows.Forms, PresentationCore, <br>
PresentationFramework, WindowsBase.<br>
<br>
Step3. In Program.Main, call the classes in the code pack to create a shell <br>
library, display Manage Library UI, add a folder to the library, list all <br>
folders in the library, remove a folder from the shell library, and delete <br>
the shell library.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1) Create a shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;using (ShellLibrary library = new ShellLibrary(libraryName, true))<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ }<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2) Show Manage Library UI<br>
&nbsp;&nbsp;&nbsp;&nbsp;ShellLibrary.ShowManageLibraryUI(libraryName, IntPtr.Zero,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;CSWin7ShellLibrary&quot;, &quot;Manage Library folders and settings&quot;, true);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3) Open the shell libary<br>
&nbsp;&nbsp;&nbsp;&nbsp;using (ShellLibrary library = ShellLibrary.Load(libraryName, false))<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ }<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;4) Add a folder to the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;library.Add(folderPath);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;5) List all folders in the library<br>
&nbsp;&nbsp;&nbsp;&nbsp;foreach (ShellFolder folder in library)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ }<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;6) Remove a folder from the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;library.Remove(folderPath);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;7) Delete the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;string librariesPath = Path.Combine(Environment.GetFolderPath(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Environment.SpecialFolder.ApplicationData),
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShellLibrary.LibrariesKnownFolder.RelativePath);<br>
&nbsp;&nbsp;&nbsp;&nbsp;string libraryPath = Path.Combine(librariesPath, libraryName);<br>
&nbsp;&nbsp;&nbsp;&nbsp;string libraryFullPath = Path.ChangeExtension(libraryPath, &quot;library-ms&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(libraryFullPath);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Windows 7 Programming Guide – Libraries<br>
<a target="_blank" href="http://windowsteamblog.com/blogs/developers/archive/2009/06/11/windows-7-programming-guide-libraries.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/06/11/windows-7-programming-guide-libraries.aspx</a><br>
<br>
Introducing Libraries<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/dd861346.aspx">http://msdn.microsoft.com/en-us/magazine/dd861346.aspx</a><br>
<br>
KB: How to programmatically manipulate Windows 7 shell libraries<br>
<a target="_blank" href="http://support.microsoft.com/kb/976027/en-us">http://support.microsoft.com/kb/976027/en-us</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
