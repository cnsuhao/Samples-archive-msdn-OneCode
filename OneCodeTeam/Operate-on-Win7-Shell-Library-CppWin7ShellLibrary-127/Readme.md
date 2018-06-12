# Operate on Win7 Shell Library (CppWin7ShellLibrary)
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
* True
## ModifiedDate
* 2011-05-05 04:42:33
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppWin7ShellLibrary Project Overview</h2>
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
The CppWin7ShellLibrary example demonstrates how to create, open, delete, <br>
rename and manage shell libraries. It also shows how to add, remove and list <br>
folders in a shell library.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
Microsoft Windows SDK for Windows 7 and .NET Framework 3.5 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en</a><br>
<br>
Windows 7<br>
<a target="_blank" href="http://www.microsoft.com/windows/windows-7/">http://www.microsoft.com/windows/windows-7/</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. In Visual Studio 2008, add a new Visual C&#43;&#43; / Win32 / Win32 Console <br>
Application project named CppWin7ShellLibrary.<br>
<br>
Step2. In targetver.h, change _WIN32_WINNT from the default value 0x0600 <br>
(Vista) to 0x0601 (Windows 7).<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#define _WIN32_WINNT 0x0601<br>
<br>
Step3. Include the following header files in Windows 7 SDK<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;shobjidl.h&gt;&nbsp;&nbsp;&nbsp;&nbsp;// Define IShellLibrary and other helper functions<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;shlobj.h&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;knownfolders.h&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;propkey.h&gt;<br>
<br>
Step4. Add the following helper functions of shell library:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;CreateShellLibrary&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Create shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;OpenShellLibrary&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Open an existing shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;DeleteShellLibrary&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Delete a shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;RenameShellLibrary&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Rename a shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;ShowManageLibraryUI&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Show Manage Library UI<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
and the helper functions about folders in shell library:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;AddFolderToShellLibrary&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Add a folder to the specified shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;RemoveFolderFromShellLibrary- Remove a folder from a shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;PrintAllFoldersInShellLibrary- Print all folders in a shell library<br>
<br>
These helper functions rely on the IShellLibrary interface and the shell <br>
libary APIs:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SHAddFolderPathToLibrary (adds a folder to a library) <br>
&nbsp;&nbsp;&nbsp;&nbsp;SHCreateLibrary (creates an IShellLibrary object) <br>
&nbsp;&nbsp;&nbsp;&nbsp;SHLoadLibraryFromItem (creates and loads an IShellLibrary object from a
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;specified library definition file)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SHLoadLibraryFromKnownFolder (creates and loads an IShellLibrary object
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;for a specified KNOWNFOLDERID) <br>
&nbsp;&nbsp;&nbsp;&nbsp;SHLoadLibraryFromParsingName (creates and loads an IShellLibrary object
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;for a specified path) <br>
&nbsp;&nbsp;&nbsp;&nbsp;SHRemoveFolderPathFromLibrary (removes a folder from a library)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SHResolveFolderPathInLibrary (attempts to resolve the target location of
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a library folder that has been moved or renamed)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SHSaveLibraryInFolderPath (saves an IShellLibrary object to disk)
<br>
<br>
Step5. In _tmain, call the above helper functions to create a shell library, <br>
display Manage Library UI, add a folder to the library, list all folders in <br>
the library, remove a folder from the shell library, and delete the shell <br>
library.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1) Create a shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;CreateShellLibrary(pwszLibraryName);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2) Show Manage Library UI<br>
&nbsp;&nbsp;&nbsp;&nbsp;ShowManageLibraryUI(pwszLibraryName);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3) Open the shell libary<br>
&nbsp;&nbsp;&nbsp;&nbsp;IShellLibrary* pShellLib = NULL;<br>
&nbsp;&nbsp;&nbsp;&nbsp;OpenShellLibrary(pwszLibraryName, &pShellLib);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;4) Add a folder to the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;AddFolderToShellLibrary(pShellLib, pwszFolderPath, TRUE);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;5) List all folders in the library<br>
&nbsp;&nbsp;&nbsp;&nbsp;ListFoldersInShellLibrary(pShellLib);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;6) Remove a folder from the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;RemoveFolderFromShellLibrary(pShellLib, pwszFolderPath);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;7) Delete the shell library<br>
&nbsp;&nbsp;&nbsp;&nbsp;DeleteShellLibrary(pwszLibraryName);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Windows 7 Programming Guide �C Libraries<br>
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
