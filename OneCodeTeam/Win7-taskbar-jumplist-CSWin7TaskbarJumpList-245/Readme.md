# Win7 taskbar jumplist (CSWin7TaskbarJumpList)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Shell
* Windows 7
## Topics
* Taskbar
## IsPublished
* False
## ModifiedDate
* 2011-05-05 06:44:19
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : CSWin7TaskbarJumpList Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The Jump List feature is designed to provide you with quick access to the <br>
documents and tasks associated with your applications. You can think of <br>
Jump Lists like little application-specific Start menus. Jump Lists can be <br>
found on the application icons that appear on the Taskbar when an <br>
application is running or on the Start menu in the recently opened programs<br>
section. Jump Lists can also be found on the icons of applications that <br>
have been specifically pinned to the Taskbar or the Start menu.<br>
<br>
CSWin7TaskbarJumpList example demostrates how to set register Jump List<br>
file handle, add items into Recent/Frequent known categories, add/remove<br>
user tasks, and add items/links into custom categories in Windows 7 Taskbar<br>
Jump List using Taskbar related APIs in Windows API Code Pack. &nbsp;<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. In the form load event, check the Windows version. &nbsp;if it is Windows 7 or
<br>
&nbsp; Windows Server 2008 R2, set the AppID and update the UI, otherwise exit <br>
&nbsp; the process.<br>
&nbsp; (TaskbarManager.IsPlatformSupported, TaskbarManager.Instance.ApplicationId,<br>
&nbsp; Application.Exit)<br>
<br>
2. Create static HelperMethods class and the static helper methods to handle<br>
&nbsp; Admin session check, restart application to elevate the user session, <br>
&nbsp; register/unregister application ID and file handle, validate file name, <br>
&nbsp; and create files under system temp folder.<br>
&nbsp; <br>
3. Create register/unregister file handle button events handler to register/<br>
&nbsp; unregister application ID and file handle.<br>
&nbsp; <br>
4. Create RadioButton checked event handler to modify the known category to <br>
&nbsp; display in the Jump List.<br>
&nbsp; (JumpList.KnownCategoryToDisplay) <br>
&nbsp; <br>
5. Create OpenFileDialog to open .txt file, so that the file will be<br>
&nbsp; displayed in Recent/Frequent known category.<br>
&nbsp; <br>
6. Create addTaskButton and clearTaskButton click event handler to add/remove <br>
&nbsp; user tasks (notepad.exe, mspaint.exe, and calc.exe) into the Jump List.<br>
&nbsp; (JumpList.AddUserTasks)<br>
&nbsp; <br>
7. Create event handlers to create and add custom category, shell item, and <br>
&nbsp; shell link. <br>
&nbsp; (JumpList.AddCustomCategories, JumpListCustomCategory.AddJumpListItems)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Windows® API Code Pack for Microsoft® .NET Framework<br>
<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a><br>
<br>
Inside Windows 7 Introducing The Taskbar APIs<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/dd942846.aspx">http://msdn.microsoft.com/en-us/magazine/dd942846.aspx</a><br>
<br>
Welcome to the Windows 7 Taskbar<br>
<a target="_blank" href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx">http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx</a><br>
<br>
Windows 7 Training Kit For Developers<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en</a><br>
<br>
Developing for the Windows 7 Taskbar – Jump into Jump Lists – Part 1<br>
<a target="_blank" href="http://windowsteamblog.com/blogs/developers/archive/2009/06/22/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-1.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/06/22/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-1.aspx</a><br>
<br>
Developing for the Windows 7 Taskbar – Jump into Jump Lists – Part 2<br>
<a target="_blank" href="http://windowsteamblog.com/blogs/developers/archive/2009/06/25/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-2.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/06/25/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-2.aspx</a><br>
<br>
Developing for the Windows 7 Taskbar – Jump into Jump Lists – Part 3<br>
<a target="_blank" href="http://windowsteamblog.com/blogs/developers/archive/2009/07/02/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-3.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/07/02/developing-for-the-windows-7-taskbar-jump-into-jump-lists-part-3.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
