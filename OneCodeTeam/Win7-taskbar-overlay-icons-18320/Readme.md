# Win7 taskbar overlay icons (CSWin7TaskbarOverlayIcons)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows 7
## Topics
* Windows Shell
* Windows 7
## IsPublished
* True
## ModifiedDate
* 2012-11-27 08:36:03
## Description

<h1><span style="">Win7 taskbar overlay icons (CSWin7TaskbarOverlayIcons) </span>
</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Windows 7 Taskbar introduces Overlay Icons, which makes your application can provide contextual status information to the user even if the application抯 window is not shown.<span style="">?</span>The user doesn抰 even have to look at the thumbnail or the live
 preview of your app ?the taskbar button itself can reveal whether you have any interesting status updates.</p>
<p class="MsoNormal">CSWin7TaskbarOverlayIcons example demonstrates how to set and clear Taskbar Overlay Icons using Taskbar related APIs in Windows API Code Pack.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, set status 揂vailable?and select 揝how Overlay Icons? you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71319/1/image.png" alt="" width="334" height="164" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Prerequisite
</span></b></p>
<p class="MsoNormal"><span style="">Windows 7 </span></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/windows/windows-7/">http://www.microsoft.com/windows/windows-7/</a>
</span></p>
<p class="MsoNormal"><span style="">Windows API Code Pack for Microsoft .NET Framework
</span></p>
<p class="MsoNormal"><span style=""><a href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a>
</span></p>
<h2>Creation</h2>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In form load event, check the Windows version.<span style="">?
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
牋?if (!TaskbarManager.IsPlatformSupported)
牋?{
牋牋牋?MessageBox.Show(&quot;Overlay Icon is not supported in your &quot; &#43; 
牋牋牋牋牋牋&quot;operation system!&quot; &#43; Environment.NewLine &#43; &quot;Please &quot; &#43; 
牋牋?/span&gt;牋牋牋?/span&gt;&quot;launch the application in Windows 7 or &quot; &#43; 
牋牋牋牋牋牋&quot;Windows Server 2008 R2 systems.&quot;);
牋牋牋?
牋牋牋牋// Exit the current process
牋牋牋?Application.Exit();
牋?}
}

</pre>
<pre id="codePreview" class="csharp">
// Check the Windows version, if the system is not Windows 7 or
// Windows Server 2008 R2, exit the current process.
private void MainForm_Load(object sender, EventArgs e)
{
牋?if (!TaskbarManager.IsPlatformSupported)
牋?{
牋牋牋?MessageBox.Show(&quot;Overlay Icon is not supported in your &quot; &#43; 
牋牋牋牋牋牋&quot;operation system!&quot; &#43; Environment.NewLine &#43; &quot;Please &quot; &#43; 
牋牋?/span&gt;牋牋牋?/span&gt;&quot;launch the application in Windows 7 or &quot; &#43; 
牋牋牋牋牋牋&quot;Windows Server 2008 R2 systems.&quot;);
牋牋牋?
牋牋牋牋// Exit the current process
牋牋牋?Application.Exit();
牋?}
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create method <span class="SpellE">ShowOrHideOverlayIcon</span> to Show, hide and modify Taskbar button Overlay Icons.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Show, hide and modify Taskbar button Overlay Icons
/// &lt;/summary&gt;
private void ShowOrHideOverlayIcon()
{
牋?// Show or hide the Overlay Icon
牋?if (showIconCheckBox.Checked)
牋?{
牋牋 牋?/span&gt;Icon icon = null;


牋牋牋?// Select Overlay Icon image based on the selected status
牋牋牋?switch (statusComboBox.SelectedIndex)
牋牋牋?{
牋牋牋牋牋?case 0:
牋牋牋牋牋牋牋?icon = Properties.Resources.Available;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?case 1:
牋牋牋牋牋牋牋?icon = Properties.Resources.Away;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?case 2:
牋牋牋牋牋牋牋?icon = Properties.Resources.Offline;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?default:
牋牋牋牋牋牋牋?MessageBox.Show(&quot;Please set the Status to show the Overlay Icon!&quot;);
牋牋牋牋牋牋牋?break;
牋牋牋?}


牋牋牋?// Set the Taskbar Overlay Icon
牋牋牋?TaskbarManager.Instance.SetOverlayIcon(icon, statusComboBox.SelectedIndex.ToString());
牋?}
牋?else
牋牋牋?// Hide the Taskbar Overlay Icon
牋牋牋?TaskbarManager.Instance.SetOverlayIcon(null, null);
牋牋牋?
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Show, hide and modify Taskbar button Overlay Icons
/// &lt;/summary&gt;
private void ShowOrHideOverlayIcon()
{
牋?// Show or hide the Overlay Icon
牋?if (showIconCheckBox.Checked)
牋?{
牋牋 牋?/span&gt;Icon icon = null;


牋牋牋?// Select Overlay Icon image based on the selected status
牋牋牋?switch (statusComboBox.SelectedIndex)
牋牋牋?{
牋牋牋牋牋?case 0:
牋牋牋牋牋牋牋?icon = Properties.Resources.Available;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?case 1:
牋牋牋牋牋牋牋?icon = Properties.Resources.Away;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?case 2:
牋牋牋牋牋牋牋?icon = Properties.Resources.Offline;
牋牋牋牋牋牋牋?break;
牋牋牋牋牋?default:
牋牋牋牋牋牋牋?MessageBox.Show(&quot;Please set the Status to show the Overlay Icon!&quot;);
牋牋牋牋牋牋牋?break;
牋牋牋?}


牋牋牋?// Set the Taskbar Overlay Icon
牋牋牋?TaskbarManager.Instance.SetOverlayIcon(icon, statusComboBox.SelectedIndex.ToString());
牋?}
牋?else
牋牋牋?// Hide the Taskbar Overlay Icon
牋牋牋?TaskbarManager.Instance.SetOverlayIcon(null, null);
牋牋牋?
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""></span></p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style="">Windows? API Code Pack for Microsoft?.NET Framework</p>
<p class="MsoNormal" style=""><a href="http://code.msdn.microsoft.com/WindowsAPICodePack">http://code.msdn.microsoft.com/WindowsAPICodePack</a></p>
<p class="MsoNormal" style="">Welcome to the Windows 7 Taskbar</p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx">http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx</a></p>
<p class="MsoNormal" style="">Windows 7 Taskbar: Overlay Icons and Progress Bars</p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/16/windows-7-taskbar-overlay-icons-and-progress-bars.aspx">http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/16/windows-7-taskbar-overlay-icons-and-progress-bars.aspx</a></p>
<p class="MsoNormal" style="">Windows 7 Training Kit <span class="GramE">For</span> Developers</p>
<p class="MsoNormal" style=""><a href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&amp;displaylang=en</a></p>
<p class="MsoNormal" style="">Windows 7 Taskbar Dynamic Overlay Icons and Progress Bars</p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
