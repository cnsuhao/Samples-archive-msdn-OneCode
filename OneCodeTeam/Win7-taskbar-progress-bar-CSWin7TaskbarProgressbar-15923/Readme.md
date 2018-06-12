# Win7 taskbar progress bar (CSWin7TaskbarProgressbar)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows 7
* Windows SDK
## Topics
* Windows Shell
* Taskbar
## IsPublished
* False
## ModifiedDate
* 2012-03-04 08:05:16
## Description

<h1><span style="">Win7 taskbar progress bar (CSWin7TaskbarProgressbar) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Windows 7 Taskbar introduces Taskbar Progress Bar, which makes your application can provide contextual status information to the user even if the application's window is not shown. The user doesn't even have to look at the thumbnail or the live preview of your
 app - the taskbar button itself can reveal whether you have any interesting status updates.<br>
CSWin7TaskbarProgressBar example demonstrates how to initialize Windows 7 Taskbar list instance, set Taskbar ProgressBar state and progress value using ITaskbarList3 related APIs.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53663/1/image.png" alt="" width="703" height="280" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In form load event, check the Windows version.<span style="">�
</span>If the current system is not Windows 7 or Windows Server 2008 R2, exit the process.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Check the Windows version, if the system is not Windows 7 or
// Windows Server 2008 R2, exit the current process.
private void MainForm_Load(object sender, EventArgs e)
{
��� if (!TaskbarManager.IsPlatformSupported)
��� {
������� MessageBox.Show(&quot;Overlay Icon is not supported in your &quot; &#43;
����������� &quot;operation system!&quot; &#43; Environment.NewLine &#43; &quot;Please &quot; &#43;
����������� &quot;launch the application in Windows 7 or &quot; &#43;
����������� &quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Check the Windows version, if the system is not Windows 7 or
// Windows Server 2008 R2, exit the current process.
private void MainForm_Load(object sender, EventArgs e)
{
��� if (!TaskbarManager.IsPlatformSupported)
��� {
������� MessageBox.Show(&quot;Overlay Icon is not supported in your &quot; &#43;
����������� &quot;operation system!&quot; &#43; Environment.NewLine &#43; &quot;Please &quot; &#43;
����������� &quot;launch the application in Windows 7 or &quot; &#43;
����������� &quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create method UpdateProgress to update WinForm ProgressBar value, set Taskbar button Progress Bar state and value.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Update the WinForm ProgressBar and Taskbar button Progress Bar
/// value
/// &lt;/summary&gt;
private void UpdateProgress()
{
��� if (progressBar.Value &lt; MAX_PROGRESSBAR_VALUE)
��� {
������� // Increase the WinForm ProgressBar value
������� progressBar.Value &#43;= 1;
��� }
��� else
��� {
������� // Clear the WinForm ProgressBar value
������� progressBar.Value = 0;
��� }


��� // Set the Taskbar button Progress Bar state to Normal
��� TaskbarManager.Instance.SetProgressState(
������� TaskbarProgressBarState.Normal);


��� // Set the Taskbar button Progress Bar value
��� TaskbarManager.Instance.SetProgressValue(
������� progressBar.Value, MAX_PROGRESSBAR_VALUE);
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Update the WinForm ProgressBar and Taskbar button Progress Bar
/// value
/// &lt;/summary&gt;
private void UpdateProgress()
{
��� if (progressBar.Value &lt; MAX_PROGRESSBAR_VALUE)
��� {
������� // Increase the WinForm ProgressBar value
������� progressBar.Value &#43;= 1;
��� }
��� else
��� {
������� // Clear the WinForm ProgressBar value
������� progressBar.Value = 0;
��� }


��� // Set the Taskbar button Progress Bar state to Normal
��� TaskbarManager.Instance.SetProgressState(
������� TaskbarProgressBarState.Normal);


��� // Set the Taskbar button Progress Bar value
��� TaskbarManager.Instance.SetProgressValue(
������� progressBar.Value, MAX_PROGRESSBAR_VALUE);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Start, Pause, Indeterminate, Error buttons to set the Taskbar button Progress Bar state.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">P/Invoke the Windows API FlashWindow to make the Taskbar button Progress Bar flash several times.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// P/Invoke the Windows API FlashWindow to flash Taskbar button
[DllImport(&quot;user32.dll&quot;)]
private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);


// Make the Taskbar button flash (MAX_FLASH_WINDOW_COUNT / 2) times
private void flashWindowTimer_Tick(object sender, EventArgs e)
{
��� if (count&#43;&#43; &lt; MAX_FLASH_WINDOW_COUNT)
��� {
������� // Make the window flash or return to the original state
������� FlashWindow(this.Handle, (count % 2) == 0);
��� }
��� else
��� {
������� // Restore the count variable
������� count = 0;


������� // Stop the timer
������� flashWindowTimer.Enabled = false;
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// P/Invoke the Windows API FlashWindow to flash Taskbar button
[DllImport(&quot;user32.dll&quot;)]
private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);


// Make the Taskbar button flash (MAX_FLASH_WINDOW_COUNT / 2) times
private void flashWindowTimer_Tick(object sender, EventArgs e)
{
��� if (count&#43;&#43; &lt; MAX_FLASH_WINDOW_COUNT)
��� {
������� // Make the window flash or return to the original state
������� FlashWindow(this.Handle, (count % 2) == 0);
��� }
��� else
��� {
������� // Restore the count variable
������� count = 0;


������� // Stop the timer
������� flashWindowTimer.Enabled = false;
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<p class="MsoNormal" style=""><a href="http://code.msdn.microsoft.com/WindowsAPICodePack">Windows� API Code Pack for Microsoft� .NET Framework</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms679346(VS.85).aspx">FlashWindow Function</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx">Welcome to the Windows 7 Taskbar</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/16/windows-7-taskbar-overlay-icons-and-progress-bars.aspx">Windows 7 Taskbar: Overlay Icons and Progress Bars</a></p>
<p class="MsoNormal" style=""><a href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">Windows 7 Training Kit For Developers</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx">Windows 7 Taskbar Dynamic Overlay Icons and Progress Bars</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
