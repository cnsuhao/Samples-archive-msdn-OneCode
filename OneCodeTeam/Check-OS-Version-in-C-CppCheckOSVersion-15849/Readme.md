# Check OS Version in C++ (CppCheckOSVersion)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* OS Version
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:38:14
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">CppCheckOSVersion</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The CppCheckOSVersion demonstrates how to detect the current OS version, and how to make application that checks for the minimum operating system version work with later operating system versions.<span style="">&nbsp;
</span></p>
<h2>Running the <span style="">s</span>ample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53180/1/image.png" alt="" width="576" height="254" align="middle">
</span><span style=""></span></p>
<h2>Using the <span style="">c</span>ode</h2>
<p class="MsoNormal"><span style="">We call GetVersionEx to detect the current OS version. If compatibility mode is in effect, the GetVersionEx function reports the operating system as it identifies itself, which may not be the operating system that is installed.
 For example, if compatibility mode is in effect, GetVersionEx reports the operating system that is selected for application compatibility.To compare the current system version to a required version, use the VerifyVersionInfo function instead of using GetVersionEx
 to perform the comparison yourself. Please note that compatibility mode does not affect the result of VerifyVersionInfo. VerifyVersionInfo always reports the comparison result based on the operating system that is installed. The most common application compatibility
 issue that users as well as developers face is when an application fails upon checking the operating system version. A lot can go wrong when version checking is misused. A user might experience a silent fail where the application simply fails to load and
</span></p>
<p class="MsoNormal"><span style="">nothing happens. Or, a user might see a dialog box indicating something to the effect of -you must be running Microsoft Windows XP or later- when in fact, the computer is running Windows 7. Many other consequences to poor
 version checking can inconvenience users as well. When an application runs on an &quot;incompatible&quot; (due to poor version checking) version of Windows, it will generally display an error message, but it may also exit silently or behave erratically. Often,
 if we work around the version checking, the application will run well. End-users and IT professionals may apply a fix to let the application think it is running on an older version of Windows.
</span></p>
<h2><span style="">Code Logic </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">1. Detect the current operating system version:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
//
// Detect the current OS version.
// 


OSVERSIONINFOEX osVersionInfo = { sizeof(osVersionInfo) };
if (!GetVersionEx((LPOSVERSIONINFO) &osVersionInfo))
{
    wprintf(L&quot;GetVersionEx failed w/err 0x%08lx\n&quot;, GetLastError());
    return 1;
}


PCWSTR pszPlatform = NULL;
switch (osVersionInfo.dwPlatformId)
{
case 0:
    pszPlatform = L&quot;Microsoft Win32S&quot;;
    break;
case 1:
    if (osVersionInfo.dwMajorVersion &gt; 4 || 
        (osVersionInfo.dwMajorVersion == 4 && osVersionInfo.dwMinorVersion &gt; 0))
    {
        pszPlatform = L&quot;Microsoft Windows 98&quot;;
    }
    else
    {
        pszPlatform = L&quot;Microsoft Windows 95&quot;;
    }
    break;
case 2:
    pszPlatform = L&quot;Microsoft Windows NT&quot;;
    break;
case 3:
    pszPlatform = L&quot;Microsoft Windows CE&quot;;
    break;
default:
    pszPlatform = L&quot;Unknown platform&quot;;
    return 1;
}
wchar_t szVersionString[256];
swprintf_s(szVersionString, ARRAYSIZE(szVersionString), 
    L&quot;%s %d.%d.%d.%d&quot;, 
    pszPlatform, osVersionInfo.dwMajorVersion, 
    osVersionInfo.dwMinorVersion, 
    osVersionInfo.dwBuildNumber, 
    osVersionInfo.wServicePackMajor &lt;&lt; 0x10 | osVersionInfo.wServicePackMinor);
wprintf(L&quot;Current OS: %s\n&quot;, szVersionString);

</pre>
<pre id="codePreview" class="cplusplus">
//
// Detect the current OS version.
// 


OSVERSIONINFOEX osVersionInfo = { sizeof(osVersionInfo) };
if (!GetVersionEx((LPOSVERSIONINFO) &osVersionInfo))
{
    wprintf(L&quot;GetVersionEx failed w/err 0x%08lx\n&quot;, GetLastError());
    return 1;
}


PCWSTR pszPlatform = NULL;
switch (osVersionInfo.dwPlatformId)
{
case 0:
    pszPlatform = L&quot;Microsoft Win32S&quot;;
    break;
case 1:
    if (osVersionInfo.dwMajorVersion &gt; 4 || 
        (osVersionInfo.dwMajorVersion == 4 && osVersionInfo.dwMinorVersion &gt; 0))
    {
        pszPlatform = L&quot;Microsoft Windows 98&quot;;
    }
    else
    {
        pszPlatform = L&quot;Microsoft Windows 95&quot;;
    }
    break;
case 2:
    pszPlatform = L&quot;Microsoft Windows NT&quot;;
    break;
case 3:
    pszPlatform = L&quot;Microsoft Windows CE&quot;;
    break;
default:
    pszPlatform = L&quot;Unknown platform&quot;;
    return 1;
}
wchar_t szVersionString[256];
swprintf_s(szVersionString, ARRAYSIZE(szVersionString), 
    L&quot;%s %d.%d.%d.%d&quot;, 
    pszPlatform, osVersionInfo.dwMajorVersion, 
    osVersionInfo.dwMinorVersion, 
    osVersionInfo.dwBuildNumber, 
    osVersionInfo.wServicePackMajor &lt;&lt; 0x10 | osVersionInfo.wServicePackMinor);
wprintf(L&quot;Current OS: %s\n&quot;, szVersionString);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">2. Check if the current OS is at least Windows XP
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
//
   // Make application that checks for the minimum operating system version
   // work with later operating system versions. To compare the current 
   // system version to a required version, use the VerifyVersionInfo 
   // function instead of using GetVersionEx to perform the comparison 
   // yourself.
   // 


   // osVersionInfoToCompare contains the OS version requirements to compare
   OSVERSIONINFOEX osVersionInfoToCompare = { sizeof(OSVERSIONINFOEX) };
   osVersionInfoToCompare.dwMajorVersion = 5;
   osVersionInfoToCompare.dwMinorVersion = 1;        // Windows XP
   osVersionInfoToCompare.wServicePackMajor = 2;    // Service Pack 2
   osVersionInfoToCompare.wServicePackMinor = 0;


   // Initialize the condition mask with ULONGLONG VER_SET_CONDITION(
   // ULONGLONG dwlConditionMask, DWORD dwTypeBitMask, BYTE dwConditionMask)
   ULONGLONG comparisonInfo = 0;
   BYTE conditionMask = VER_GREATER_EQUAL;
   VER_SET_CONDITION(comparisonInfo, VER_MAJORVERSION, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_MINORVERSION, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_SERVICEPACKMAJOR, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_SERVICEPACKMINOR, conditionMask);


   // Compares a set of operating system version requirements to the 
   // corresponding values for the currently running version of the system.
   if (!VerifyVersionInfo(&osVersionInfoToCompare, VER_MAJORVERSION | 
       VER_MINORVERSION | VER_SERVICEPACKMAJOR | VER_SERVICEPACKMINOR,
       comparisonInfo))
   {
       wprintf(L&quot;Windows XP SP2 or later is required.&quot;);
       // Quit the application due to incompatible OS
       return 1;
   }

</pre>
<pre id="codePreview" class="cplusplus">
//
   // Make application that checks for the minimum operating system version
   // work with later operating system versions. To compare the current 
   // system version to a required version, use the VerifyVersionInfo 
   // function instead of using GetVersionEx to perform the comparison 
   // yourself.
   // 


   // osVersionInfoToCompare contains the OS version requirements to compare
   OSVERSIONINFOEX osVersionInfoToCompare = { sizeof(OSVERSIONINFOEX) };
   osVersionInfoToCompare.dwMajorVersion = 5;
   osVersionInfoToCompare.dwMinorVersion = 1;        // Windows XP
   osVersionInfoToCompare.wServicePackMajor = 2;    // Service Pack 2
   osVersionInfoToCompare.wServicePackMinor = 0;


   // Initialize the condition mask with ULONGLONG VER_SET_CONDITION(
   // ULONGLONG dwlConditionMask, DWORD dwTypeBitMask, BYTE dwConditionMask)
   ULONGLONG comparisonInfo = 0;
   BYTE conditionMask = VER_GREATER_EQUAL;
   VER_SET_CONDITION(comparisonInfo, VER_MAJORVERSION, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_MINORVERSION, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_SERVICEPACKMAJOR, conditionMask);
   VER_SET_CONDITION(comparisonInfo, VER_SERVICEPACKMINOR, conditionMask);


   // Compares a set of operating system version requirements to the 
   // corresponding values for the currently running version of the system.
   if (!VerifyVersionInfo(&osVersionInfoToCompare, VER_MAJORVERSION | 
       VER_MINORVERSION | VER_SERVICEPACKMAJOR | VER_SERVICEPACKMINOR,
       comparisonInfo))
   {
       wprintf(L&quot;Windows XP SP2 or later is required.&quot;);
       // Quit the application due to incompatible OS
       return 1;
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms724451(VS.85).aspx">MSDN: GetVersionEx Function</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms724429(VS.85).aspx">MSDN: Getting the System Version</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms725492(VS.85).aspx">MSDN: VerifyVersionInfo Function</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/ms725491(VS.85).aspx">MSDN: Verifying the System Version</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
