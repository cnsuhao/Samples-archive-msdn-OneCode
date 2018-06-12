# Win7 taskbar overlay icons (CppWin7TaskbarOverlayIcons)
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
* 2012-08-20 01:29:05
## Description

<h1><span style="">Win7 taskbar overlay icons (CppWin7TaskbarOverlayIcons) </span>
</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Windows 7 Taskbar introduces Overlay Icons, which makes your application can provide contextual status information to the user even if the application's window is not shown.<span style="">?</span>The user doesn't even have to look at the thumbnail or the live
 preview of your app, the taskbar button itself can reveal whether you have any interesting status updates.</p>
<p class="MsoNormal">CppWin7TaskbarOverlayIcons example demonstrates how to initialize Windows 7 Taskbar list instance, set and clear Taskbar Overlay Icons using ITaskbarList3 related APIs.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, set status 揂vailable?and select 揝how Overlay Icons? you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/64971/1/image.png" alt="" width="326" height="160" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Prerequisite
</span></b></p>
<p class="MsoNormal"><span style="">Microsoft Windows SDK for Windows 7 and .NET Framework 3.5 SP1
</span></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&amp;displaylang=en</a>
</span></p>
<p class="MsoNormal"><span style="">Windows 7 </span></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/windows/windows-7/">http://www.microsoft.com/windows/windows-7/</a>
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
#ifndef NTDDI_VERSION牋牋牋牋牋牋 // Specifies that the minimum required platform is Windows 7.
#define NTDDI_VERSION NTDDI_WIN7?// Change this to the appropriate value to target other versions of Windows.
#endif

</pre>
<pre id="codePreview" class="cplusplus">
#ifndef NTDDI_VERSION牋牋牋牋牋牋 // Specifies that the minimum required platform is Windows 7.
#define NTDDI_VERSION NTDDI_WIN7?// Change this to the appropriate value to target other versions of Windows.
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
</span></span></span><span style="">Open the project's properties from the &quot;project&quot; menu by selecting properties. Select &quot;linker - Input&quot; from the tree control on the left of your project properties dialog.<span style="">?</span>Add &quot;shlwapi.lib&quot;
 in the &quot;Additional Dependencies&quot;. </span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In InitInstance, add the following codes to set find the ComboBox window handle and add items into the ComboBox.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Find the ComboBox window handle
hCombo = FindWindowEx(hWnd, NULL, L&quot;ComboBox&quot;, NULL);


if (hCombo)
{
牋?// Add items into the ComboBox
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Available&quot;);
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Away&quot;);
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Offline&quot;);
}
else
{
牋?return FALSE;
}

</pre>
<pre id="codePreview" class="cplusplus">
// Find the ComboBox window handle
hCombo = FindWindowEx(hWnd, NULL, L&quot;ComboBox&quot;, NULL);


if (hCombo)
{
牋?// Add items into the ComboBox
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Available&quot;);
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Away&quot;);
牋?SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)L&quot;Offline&quot;);
}
else
{
牋?return FALSE;
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
HRESULT hr;


// Initialize the Windows 7 Taskbar list instance
hr = CoCreateInstance(CLSID_TaskbarList, 
牋牋NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&g_pTaskbarList));
if (!SUCCEEDED(hr))
{
牋?return FALSE;
}

</pre>
<pre id="codePreview" class="cplusplus">
HRESULT hr;


// Initialize the Windows 7 Taskbar list instance
hr = CoCreateInstance(CLSID_TaskbarList, 
牋牋NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&g_pTaskbarList));
if (!SUCCEEDED(hr))
{
牋?return FALSE;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create function SetOverlayIcons to load an icon and set the icon as Taskbar Overlay Icon.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create function SetOverlayIconsByComboSelectedValue to get the selected index of the ComboBox and set the Overlay Icons.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">10.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Modify the WM_COMMAND message codes to handle ComboBox selected and CheckBox clicked messages.
</span></p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style="">ITaskbarList3 Interface</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd391692(VS.85).aspx">http://msdn.microsoft.com/en-us/library/dd391692(VS.85).aspx</a></p>
<p class="MsoNormal" style="">ITaskbarList3::SetOverlayIcon Method</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd391696(VS.85).aspx">http://msdn.microsoft.com/en-us/library/dd391696(VS.85).aspx</a></p>
<p class="MsoNormal" style="">Combo Box</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb775792(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb775792(VS.85).aspx</a></p>
<p class="MsoNormal" style="">CBN_SELENDOK Notification</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb775825(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb775825(VS.85).aspx</a></p>
<p class="MsoNormal" style="">CB_ADDSTRING Message</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb775828(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb775828(VS.85).aspx</a></p>
<p class="MsoNormal" style="">CB_GETCURSEL Message</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb775845(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb775845(VS.85).aspx</a></p>
<p class="MsoNormal" style="">CoCreateInstance Function</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms686615(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms686615(VS.85).aspx</a></p>
<p class="MsoNormal" style="">SendMessage Function</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms644950(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms644950(VS.85).aspx</a></p>
<p class="MsoNormal" style="">FindWindowEx Function</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms633500(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms633500(VS.85).aspx</a></p>
<p class="MsoNormal" style="">LoadIcon Function</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms648072(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms648072(VS.85).aspx</a></p>
<p class="MsoNormal" style="">Windows 7 Taskbar Dynamic Overlay Icons and Progress Bars</p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx">http://windowsteamblog.com/blogs/developers/archive/2009/07/28/windows-7-taskbar-dynamic-overlay-icons-and-progress-bars.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
