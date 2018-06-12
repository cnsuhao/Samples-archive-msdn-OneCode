# Win7 taskbar progress bar (CppWin7TaskbarProgressBar)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows 7
* Windows SDK
## Topics
* Windows Shell
* Taskbar
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:44:29
## Description

<h1><span style="">Win7 taskbar progress bar (CppWin7TaskbarProgressbar) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Windows 7 Taskbar introduces Taskbar Progress Bar, which makes your application can provide contextual status information to the user even if the application's window is not shown. The user doesn't even have to look at the thumbnail or the live preview of your
 app - the taskbar button itself can reveal whether you have any interesting status updates.<br>
CppWin7TaskbarProgressBar example demonstrates how to initialize Windows 7 Taskbar list instance, set Taskbar ProgressBar state and progress value using ITaskbarList3 related APIs.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54107/1/image.png" alt="" width="703" height="280" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Prerequisite
</span></b></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en">Microsoft Windows SDK for Windows 7 and .NET Framework 3.5 SP1</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://www.microsoft.com/windows/windows-7/">Windows 7</a>
</span></p>
<h2>Creation</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Main dialog and following the steps in example CppWindowsDialog.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Set the Main dialog &quot;Application Window&quot; property to True in order to let the main dialog has an entry on the taskbar when visible.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In targetver.h, comments the original version information and add the following codes to specify the minimum required platform is Windows 7.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#ifndef NTDDI_VERSION������������ // Specifies that the minimum required platform is Windows 7.
#define NTDDI_VERSION NTDDI_WIN7� // Change this to the appropriate value to target other versions of Windows.
#endif

</pre>
<pre id="codePreview" class="cplusplus">
#ifndef NTDDI_VERSION������������ // Specifies that the minimum required platform is Windows 7.
#define NTDDI_VERSION NTDDI_WIN7� // Change this to the appropriate value to target other versions of Windows.
#endif

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In stdafx.h, include necessary header files. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Windows Header Files:
#include &lt;windows.h&gt;
#include &lt;windowsx.h&gt;


// C RunTime Header Files
#include &lt;stdlib.h&gt;
#include &lt;malloc.h&gt;
#include &lt;memory.h&gt;
#include &lt;tchar.h&gt;


// ATL/WTL
#include &lt;atlbase.h&gt;
#include &lt;atlstr.h&gt;
#include &lt;atltypes.h&gt;


// Header Files for Windows 7 Taskbar features
#include &lt;shobjidl.h&gt;
#include &lt;propkey.h&gt;
#include &lt;propvarutil.h&gt;
#include &lt;shlobj.h&gt;
#include &lt;shellapi.h&gt;

</pre>
<pre id="codePreview" class="cplusplus">
// Windows Header Files:
#include &lt;windows.h&gt;
#include &lt;windowsx.h&gt;


// C RunTime Header Files
#include &lt;stdlib.h&gt;
#include &lt;malloc.h&gt;
#include &lt;memory.h&gt;
#include &lt;tchar.h&gt;


// ATL/WTL
#include &lt;atlbase.h&gt;
#include &lt;atlstr.h&gt;
#include &lt;atltypes.h&gt;


// Header Files for Windows 7 Taskbar features
#include &lt;shobjidl.h&gt;
#include &lt;propkey.h&gt;
#include &lt;propvarutil.h&gt;
#include &lt;shlobj.h&gt;
#include &lt;shellapi.h&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the project's properties from the &quot;project&quot; menu by selecting properties. Select &quot;linker - Input&quot; from the tree control on the left of your project properties dialog.<span style="">�
</span>Add &quot;shlwapi.lib&quot; in the &quot;Additional Dependencies&quot;. </span>
</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In InitInstance, add the following codes to set find the ProgressBar window handle.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Find the ProgressBar window handle
hProgressBar = FindWindowEx(hWnd, NULL, L&quot;msctls_progress32&quot;, NULL);
if (!hProgressBar)
{
��� return FALSE;
}

</pre>
<pre id="codePreview" class="cplusplus">
// Find the ProgressBar window handle
hProgressBar = FindWindowEx(hWnd, NULL, L&quot;msctls_progress32&quot;, NULL);
if (!hProgressBar)
{
��� return FALSE;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In InitInstance, add the following codes to initialize the Windows 7 Taskbar list instance.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Initialize the Windows 7 Taskbar list instance
hr = CoCreateInstance(CLSID_TaskbarList, 
����NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&g_pTaskbarList));
if (!SUCCEEDED(hr))
{
��� return FALSE;
}

</pre>
<pre id="codePreview" class="cplusplus">
// Initialize the Windows 7 Taskbar list instance
hr = CoCreateInstance(CLSID_TaskbarList, 
����NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&g_pTaskbarList));
if (!SUCCEEDED(hr))
{
��� return FALSE;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Modify the WM_COMMAND message codes to set Taskbar ProgressBar state (normal, pause, indeterminate, error), progress value, and flash window.
</span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd391692(VS.85).aspx">ITaskbarList3 Interface</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd391697(VS.85).aspx">ITaskbarList3::<span class="SpellE">SetProgressState</span> Method</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd391698(VS.85).aspx">ITaskbarList3::<span class="SpellE">SetProgressValue</span> Method</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb760818(VS.85).aspx">Progress Bar</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms686615(VS.85).aspx"><span class="SpellE">CoCreateInstance</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb760850(VS.85).aspx">PBM_SETSTATE Message</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb760844(VS.85).aspx">PBM_SETPOS Message</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms644950(VS.85).aspx"><span class="SpellE">SendMessage</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms633500(VS.85).aspx"><span class="SpellE">FindWindowEx</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx">Windows 7 Taskbar Dynamic Overlay Icons and Progress Bars</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
