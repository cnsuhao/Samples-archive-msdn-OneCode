# Win7 taskbar Application ID (CppWin7TaskbarAppID)
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
* 2012-03-11 06:45:00
## Description

<h1><span style="">Win7 taskbar Application ID (CppWin7TaskbarAppID) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Application User Model IDs (AppUserModelIDs) are used extensively by the taskbar in Windows 7 and later systems to associate processes, files, and windows with a particular application. In some cases, it is sufficient to rely on the internal AppUserModelID
 assigned to a process by the system. However, an application that owns multiple processes or an application that is running in a host process might need to explicitly identify itself so that it can group its otherwise disparate windows under a single taskbar
 button and control the contents of that application's Jump List.</p>
<p class="MsoNormal">CppWin7TaskbarAppID example demonstrates how to set process level Application User Model IDs (AppUserModelIDs or AppIDs) and modify the AppIDs for a specific window using native C&#43;&#43;.</p>
<p class="MsoNormal"></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, and click the Open Sub Form button, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54110/1/image.png" alt="" width="838" height="280" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Prerequisite:
</span></b></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=c17ba869-9671-4330-a63e-1fd44e0e2505&displaylang=en">Microsoft Windows SDK for Windows 7 and .NET Framework 3.5 SP1</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/windows/windows-7/">Windows 7</a>
</span></p>
<h2>Creation</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Main dialog and Sub Modeless dialog following the steps in example CppWindowsDialog.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Named the Sub Modeless dialog as IDD_SUBDIALOG.<span style="">�
</span>Open its properties window, set &quot;Application Window&quot; property to True in order to let the Sub dialog has an entry on the taskbar when visible.
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
</span>Add &quot;shlwapi.lib&quot; in the &quot;Additional Dependencies&quot; and &quot;shlwapi.dll;&quot; in the &quot;Delay Loaded DLLs&quot;.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In InitInstance, add the following codes to set process-level AppID.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
��� HWND hWnd;


��� hInst = hInstance; // Store instance handle in our global variable


��� hWnd = CreateDialog(hInst, MAKEINTRESOURCE(IDD_MAINDIALOG), 0, 0);


��� if (!hWnd)
��� {
������� return FALSE;
��� }


��� // Set process-level AppID
��� HRESULT hr = SetCurrentProcessExplicitAppUserModelID(c_rgszAppID[0]);


��� if (!SUCCEEDED(hr))
��� {
������� return FALSE;
��� }


��� // Set Window caption
��� if (!SetWindowText(hWnd, c_rgszAppID[0]))
��� {
������� return FALSE;
��� }


��� ShowWindow(hWnd, nCmdShow);
��� UpdateWindow(hWnd);


��� return TRUE;
}

</pre>
<pre id="codePreview" class="cplusplus">
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
��� HWND hWnd;


��� hInst = hInstance; // Store instance handle in our global variable


��� hWnd = CreateDialog(hInst, MAKEINTRESOURCE(IDD_MAINDIALOG), 0, 0);


��� if (!hWnd)
��� {
������� return FALSE;
��� }


��� // Set process-level AppID
��� HRESULT hr = SetCurrentProcessExplicitAppUserModelID(c_rgszAppID[0]);


��� if (!SUCCEEDED(hr))
��� {
������� return FALSE;
��� }


��� // Set Window caption
��� if (!SetWindowText(hWnd, c_rgszAppID[0]))
��� {
������� return FALSE;
��� }


��� ShowWindow(hWnd, nCmdShow);
��� UpdateWindow(hWnd);


��� return TRUE;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create function SetAppIDForSpecificWindow to set AppID for a specific window.<span style="">�
</span>For detail, please see the Developing for the Windows 7 Taskbar - Application ID in References section.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
void SetAppIDForSpecificWindow(HWND hWnd, int iAppID)
{
��� IPropertyStore *pps;


��� // This api retrieves an IPropertyStore that stores the window's properties
��� HRESULT hr = SHGetPropertyStoreForWindow(hWnd, IID_PPV_ARGS(&pps));
��� if (SUCCEEDED(hr))
��� {
������� PROPVARIANT pv;
������� if (iAppID &gt;= 0)
������� {
����������� // Creates a VT_LPWSTR propvariant
����������� hr = InitPropVariantFromString(c_rgszAppID[iAppID], &pv);
������� }
������� else
������� {
����������� // Initializes a PROPVARIANT structure
����������� PropVariantInit(&pv);
������� }
������� if (SUCCEEDED(hr))
������� {
����������� // Set the PROPVARIANT structure to PKEY_AppUserModel_ID property
����������� hr = pps-&gt;SetValue(PKEY_AppUserModel_ID, pv);


���� �������// Clear the PROPVARIANT structure
����������� PropVariantClear(&pv);
������� }
������� // Release the IPropertyStore
������� pps-&gt;Release();
��� }
}

</pre>
<pre id="codePreview" class="cplusplus">
void SetAppIDForSpecificWindow(HWND hWnd, int iAppID)
{
��� IPropertyStore *pps;


��� // This api retrieves an IPropertyStore that stores the window's properties
��� HRESULT hr = SHGetPropertyStoreForWindow(hWnd, IID_PPV_ARGS(&pps));
��� if (SUCCEEDED(hr))
��� {
������� PROPVARIANT pv;
������� if (iAppID &gt;= 0)
������� {
����������� // Creates a VT_LPWSTR propvariant
����������� hr = InitPropVariantFromString(c_rgszAppID[iAppID], &pv);
������� }
������� else
������� {
����������� // Initializes a PROPVARIANT structure
����������� PropVariantInit(&pv);
������� }
������� if (SUCCEEDED(hr))
������� {
����������� // Set the PROPVARIANT structure to PKEY_AppUserModel_ID property
����������� hr = pps-&gt;SetValue(PKEY_AppUserModel_ID, pv);


���� �������// Clear the PROPVARIANT structure
����������� PropVariantClear(&pv);
������� }
������� // Release the IPropertyStore
������� pps-&gt;Release();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Modify the function OnCommand to create Sub Modeles.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
void OnCommand(HWND hWnd, int id, HWND hWndCtl, UINT codeNotify)
{
��� switch (id)
��� {
��� case IDC_SHOWDIALOG_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Create a Sub Modeless Dialog
������� // 


������� // You create a modeless dialog box by using the CreateDialog 
��������// function, specifying the identifier or name of a dialog box 
��������// template resource and a pointer to the dialog box procedure. 
��������// CreateDialog loads the template, creates the dialog box, and 
��������// optionally displays it. Your application is responsible for 
��������// retrieving and dispatching user input messages to the dialog box 
��������// procedure.
������ �{
����������� HWND hDlg = CreateDialog(hInst, 
����������������MAKEINTRESOURCE(IDD_SUBDIALOG), 
����������������hWnd, ModalessDlgProc);
����������� if (hDlg)
����������� {
��������������� // Set AppID (App2) for this Sub Dialog
��������������� SetAppIDForSpecificWindow(hDlg, 1);


��������������� // Set Sub Dialog caption
��������������� SetWindowText(hDlg, c_rgszAppID[1]);


��������������� ShowWindow(hDlg, SW_SHOW);
����������� }
������� }
������� break;


��� case IDC_SETAPPID1_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Set Main dialog AppID to 
��������// All-In-One Code Framework.Win7.CppWin7TaskbarAppID.App1
������� // 


������� // Set the AppID (App1) for Main Dialog
������� SetAppIDForSpecificWindow(hWnd, 0);


������� // Set Main Dialog caption
������� SetWindowText(hWnd, c_rgszAppID[0]);
������� break;


��� case IDC_SETAPPID2_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Set Main dialog AppID to 
��������// All-In-One Code Framework.Win7.CppWin7TaskbarAppID.App2
������� // 


������� // Set the AppID (App2) for Main Dialog
������� SetAppIDForSpecificWindow(hWnd, 1);


������� // Set Main Dialog caption 
��������SetWindowText(hWnd, c_rgszAppID[1]);
������� break;


��� case IDOK:
������� PostQuitMessage(0);
������� break;
��� }
}

</pre>
<pre id="codePreview" class="cplusplus">
void OnCommand(HWND hWnd, int id, HWND hWndCtl, UINT codeNotify)
{
��� switch (id)
��� {
��� case IDC_SHOWDIALOG_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Create a Sub Modeless Dialog
������� // 


������� // You create a modeless dialog box by using the CreateDialog 
��������// function, specifying the identifier or name of a dialog box 
��������// template resource and a pointer to the dialog box procedure. 
��������// CreateDialog loads the template, creates the dialog box, and 
��������// optionally displays it. Your application is responsible for 
��������// retrieving and dispatching user input messages to the dialog box 
��������// procedure.
������ �{
����������� HWND hDlg = CreateDialog(hInst, 
����������������MAKEINTRESOURCE(IDD_SUBDIALOG), 
����������������hWnd, ModalessDlgProc);
����������� if (hDlg)
����������� {
��������������� // Set AppID (App2) for this Sub Dialog
��������������� SetAppIDForSpecificWindow(hDlg, 1);


��������������� // Set Sub Dialog caption
��������������� SetWindowText(hDlg, c_rgszAppID[1]);


��������������� ShowWindow(hDlg, SW_SHOW);
����������� }
������� }
������� break;


��� case IDC_SETAPPID1_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Set Main dialog AppID to 
��������// All-In-One Code Framework.Win7.CppWin7TaskbarAppID.App1
������� // 


������� // Set the AppID (App1) for Main Dialog
������� SetAppIDForSpecificWindow(hWnd, 0);


������� // Set Main Dialog caption
������� SetWindowText(hWnd, c_rgszAppID[0]);
������� break;


��� case IDC_SETAPPID2_BN:


������� /////////////////////////////////////////////////////////////////////
������� // Set Main dialog AppID to 
��������// All-In-One Code Framework.Win7.CppWin7TaskbarAppID.App2
������� // 


������� // Set the AppID (App2) for Main Dialog
������� SetAppIDForSpecificWindow(hWnd, 1);


������� // Set Main Dialog caption 
��������SetWindowText(hWnd, c_rgszAppID[1]);
������� break;


��� case IDOK:
������� PostQuitMessage(0);
������� break;
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378459(VS.85).aspx">Application User Model IDs (AppUserModelIDs)</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378422(VS.85).aspx">SetCurrentProcessExplicitAppUserModelID Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378430(VS.85).aspx">SHGetPropertyStoreForWindow Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/ms633546(VS.85).aspx"><span class="SpellE">SetWindowText</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb762305(VS.85).aspx"><span class="SpellE">InitPropVariantFromString</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/bb761474(VS.85).aspx"><span class="SpellE">IPropertyStore</span> Interface</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/aa380293(VS.85).aspx"><span class="SpellE">PropVariantInit</span> Macro</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/aa380073(VS.85).aspx"><span class="SpellE">PropVariantClear</span> Function</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/15/windows-7-taskbar-application-id.aspx">Windows 7 Taskbar: Application Id</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/06/18/developing-for-the-windows-7-taskbar-application-id.aspx">Developing for the Windows 7 Taskbar � Application ID</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/06/19/developing-for-the-windows-7-taskbar-application-id-part-2.aspx">Developing for the Windows 7 Taskbar � Application ID � Part 2</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
