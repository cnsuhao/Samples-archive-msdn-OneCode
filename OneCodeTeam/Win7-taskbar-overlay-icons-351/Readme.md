# Win7 taskbar overlay icons (VBWin7TaskbarOverlayIcons)
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
* 2011-05-05 08:30:45
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : VBWin7TaskbarOverlayIcons Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Windows 7 Taskbar introduces Overlay Icons, which makes your application can <br>
provide contextual status information to the user even if the application’s <br>
window is not shown. &nbsp;The user doesn’t even have to look at the thumbnail <br>
or the live preview of your app – the taskbar button itself can reveal <br>
whether you have any interesting status updates..<br>
<br>
VBWin7TaskbarOverlayIcons example demostrates how to set and clear Taskbar<br>
Overlay Icons using Taskbar related APIs in Windows API Code Pack.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. In form load event, check the Windows version. &nbsp;If the current system is <br>
&nbsp; not Windows 7 or Windows Server 2008 R2,exit the process.<br>
&nbsp; (TaskbarManager.IsPlatformSupported, Application.Exit)<br>
&nbsp; <br>
2. Create method ShowOrHideOverlayIcon to Show, hide and modify Taskbar <br>
&nbsp; button Overlay Icons.<br>
&nbsp; (TaskbarManager.Instance.SetOverlayIcon)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Windows® API Code Pack for Microsoft® .NET Framework<br>
<a target="_blank" href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a><br>
<br>
Welcome to the Windows 7 Taskbar<br>
<a target="_blank" href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx">http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx</a><br>
<br>
Windows 7 Taskbar: Overlay Icons and Progress Bars<br>
<a target="_blank" href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/16/windows-7-taskbar-overlay-icons-and-progress-bars.aspx">http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/16/windows-7-taskbar-overlay-icons-and-progress-bars.aspx</a><br>
<br>
Windows 7 Training Kit For Developers<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en</a><br>
<br>
Windows 7 Taskbar Dynamic Overlay Icons and Progress Bars<br>
<a target="_blank" href="http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
