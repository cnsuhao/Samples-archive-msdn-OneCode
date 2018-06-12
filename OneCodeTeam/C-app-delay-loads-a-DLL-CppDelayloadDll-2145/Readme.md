# C++ app delay-loads a DLL  (CppDelayloadDll)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Library
## Topics
* Delayload
* DLL
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:23:50
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppDelayloadDll Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The support of delayed loading of DLLs in Visual C&#43;&#43; linker relieves us of <br>
the need to use the API LoadLibrary and GetProcAddress to implement DLL <br>
delayed loading. DLL is implicitly linked but not actually loaded until the <br>
code attempts to reference a symbol contained within the DLL. An application <br>
can delay load a DLL using the /DELAYLOAD (Delay Load Import) linker option <br>
with a helper function (default implementation provided by Visual C&#43;&#43;, see <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx">http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx</a>).'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx">http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx</a>).
 The helper function <br>
will load the DLL at run time by calling LoadLibrary and GetProcAddress for <br>
us. <br>
<br>
We should consider delay loading a DLL if the program may not call a function<br>
in the DLL or a function in the DLL may not get called until late in the <br>
program's execution. Delay loading a DLL saves the initialization time when <br>
the executable files starts up.<br>
<br>
This code sample demonstrates delay loading CppDynamicLinkLibrary.dll, <br>
importing and using the data, functions and classes exported from the DLL, <br>
and explicitly unloading the module.<br>
<br>
You can also learn how to hook notifications and failures in the delay-load <br>
process, and customize the default delay-load behavior. In this code sample, <br>
if the target DLL CppDynamicLinkLibrary.dll fails to be loaded, you will be <br>
asked to input the full path of the DLL, and the application will attempt to <br>
load the DLL again. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the DLL delayed loading <br>
sample.<br>
<br>
Step1. After you successfully build the sample project CppDelayloadDll and <br>
its dependent project CppDynamicLinkLibrary in Visual Studio 2008, you will <br>
get an application CppDelayloadDll.exe and a DLL CppDynamicLinkLibrary.dll.<br>
<br>
Step2. Run CppDelayloadDll.exe in a command prompt. The application should <br>
print the following messages in the console.<br>
<br>
&nbsp; &nbsp;Module &quot;CppDynamicLinkLibrary&quot; is not loaded<br>
&nbsp; &nbsp;Function: GetStringLength1(&quot;HelloWorld&quot;) =&gt; 10<br>
&nbsp; &nbsp;Function: GetStringLength2(&quot;HelloWorld&quot;) =&gt; 10<br>
&nbsp; &nbsp;Function: Max(2, 3) =&gt; 3<br>
&nbsp; &nbsp;Class: CSimpleObject::FloatProperty = 1.20<br>
&nbsp; &nbsp;Module &quot;CppDynamicLinkLibrary&quot; is loaded<br>
&nbsp; &nbsp;Unload the delay-loaded DLL<br>
&nbsp; &nbsp;Module &quot;CppDynamicLinkLibrary&quot; is not loaded<br>
<br>
The messages indicate that, at first, CppDynamicLinkLibrary.dll was not <br>
loaded. The DLL is loaded after the application calls the functions or &nbsp;<br>
classes exported by the DLL. Last, it is allowed to unload the delay-loaded <br>
DLL. <br>
<br>
Step3. To demo the notification hooks and failure hooks, move the DLL file <br>
CppDynamicLinkLibrary.dll to a folder that is not in the default DLL search <br>
path (e.g. D:\Test\). Run CppDelayloadDll.exe again. The application displays <br>
that the DLL fails to be loaded. You are be asked to input the path of the <br>
DLL file.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Module &quot;CppDynamicLinkLibrary&quot; is not loaded<br>
&nbsp;&nbsp;&nbsp;&nbsp;Failed to load the DLL CppDynamicLinkLibrary.dll w/err 0x0000007e.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Please input the path of the DLL file:<br>
<br>
By entering the new path of the DLL (e.g. D:\Test\CppDynamicLinkLibrary.dll), <br>
the application will attempt to load the DLL again. This time, the module <br>
is successfully loaded. The sample application proceeds to invoke the <br>
functions and classes exported from the DLL.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Please input the path of the DLL file:<br>
&nbsp;&nbsp;&nbsp;&nbsp;D:\Test\CppDynamicLinkLibrary.dll<br>
&nbsp;&nbsp;&nbsp;&nbsp;Function: GetStringLength1(&quot;HelloWorld&quot;) =&gt; 10<br>
&nbsp;&nbsp;&nbsp;&nbsp;Function: GetStringLength2(&quot;HelloWorld&quot;) =&gt; 10<br>
&nbsp;&nbsp;&nbsp;&nbsp;Function: Max(2, 3) =&gt; 3<br>
&nbsp;&nbsp;&nbsp;&nbsp;Class: CSimpleObject::FloatProperty = 1.20<br>
&nbsp;&nbsp;&nbsp;&nbsp;Module &quot;CppDynamicLinkLibrary&quot; is loaded<br>
&nbsp;&nbsp;&nbsp;&nbsp;Unload the delay-loaded DLL<br>
&nbsp;&nbsp;&nbsp;&nbsp;Module &quot;CppDynamicLinkLibrary&quot; is not loaded<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://1code.codeplex.com)">
http://1code.codeplex.com)</a><br>
<br>
CppDelayloadDll -&gt; CppDynamicLinkLibrary<br>
CppDelayloadDll delay-loads CppDynamicLinkLibrary.dll and invokes the <br>
functions and classes exported by the DLL.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step1. Link the LIB file of the DLL by entering the LIB file name in <br>
Project Properties / Linker / Input / Additional Dependencies. We can <br>
configure the search path of the LIB file in Project Properties / Linker / <br>
General / Additional Library Directories.<br>
<br>
Step2. #include the header file that imports the symbols of the DLL.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &quot;CppDynamicLinkLibrary.h&quot;<br>
<br>
We can configure the search path of the header file in Project Properties / <br>
C/C&#43;&#43; / General / Additional Include Directories.<br>
<br>
Step3. Specify the DLL for delay loading by entering the DLL file name, <br>
CppDynamicLinkLibrary.dll, in Project Properties / Linker / Input / Delay <br>
Loaded DLLs.<br>
<br>
Step4. Specify to allow explicitly unloading of the delayed load DLLs by <br>
selecting &quot;Support Unload (/DELAY:UNLOAD) in Project Properties / Linker / <br>
Advanced / Delay Loaded DLL.<br>
<br>
Step5. Use the imported symbols. For example:<br>
<br>
&nbsp; &nbsp;PCWSTR pszString = L&quot;HelloWorld&quot;;<br>
&nbsp; &nbsp;int nLength;<br>
&nbsp;&nbsp;&nbsp;&nbsp;nLength = GetStringLength1(pszString);<br>
<br>
Note: Delay-load does not allow accessing/dllimport-ing data symbols.<br>
<br>
Step6. Unload the delay-loaded DLL after the use.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;PCSTR pszDll = &quot;CppDynamicLinkLibrary.dll&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (!__FUnloadDelayLoadedDLL2(pszDll))<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;wprintf(L&quot;The DLL failed to be unloaded\n&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step7. (Optional) Setup notification hooks and failure hooks if you want to <br>
customize the default behaviors in the delay-load helper function.<br>
<br>
The notification hook is enabled by supplying a new definition of the pointer <br>
__pfnDliNotifyHook2 that is initialized to point to your own function that <br>
receives the notifications, or by setting the pointer __pfnDliNotifyHook2 to <br>
your hook function before any calls to the DLL that the program is delay <br>
loading.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;PfnDliHook __pfnDliNotifyHook2 = DelayLoadHook;<br>
<br>
The failure hook is enabled in the same manner as the notification hook. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;PfnDliHook __pfnDliFailureHook2 = DelayLoadHook;<br>
<br>
The hook function is defined as <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;FARPROC WINAPI DelayLoadHook(unsigned dliNotify, PDelayLoadInfo pdli)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
The delay-load helper function can call back to a notification hook in your <br>
program after each of the following actions: <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Just before LoadLibrary is called in the helper function<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Just before GetProcAddress is called in the helper function<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;If the call to LoadLibrary in the helper function failed<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;If the call to GetProcAddress in the helper function failed<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;After the helper function is done processing<br>
<br>
In this code sample, we hook the dliFailGetProc notification. If the target <br>
DLL fails to be loaded, you will be asked to input the full path of the DLL, <br>
and the application will attempt to load the DLL again. <br>
<br>
&nbsp; &nbsp;case dliFailLoadLib : <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// LoadLibrary failed.<br>
&nbsp; &nbsp; &nbsp; &nbsp;// If you don't want to handle this failure yourself, return 0. In
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// this case the helper will raise an exception (ERROR_MOD_NOT_FOUND)
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// and exit. If you want to handle the failure by loading an
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// alternate DLL (for example), then return the HMODULE for the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// alternate DLL. The helper will continue execution with this
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// alternate DLL and attempt to find the requested entrypoint via
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// GetProcAddress.<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;printf(&quot;Failed to load the DLL %s w/err 0x%08lx.\n&quot;, pdli-&gt;szDll,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pdli-&gt;dwLastError);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;printf(&quot;Please input the path of the DLL file:\n&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wchar_t szDll[MAX_PATH];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fgetws(szDll, ARRAYSIZE(szDll), stdin);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wchar_t *p = wcschr(szDll, L'\n');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (p != NULL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;*p = L'\0'; &nbsp;// Remove the trailing L'\n'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Try to load the DLL again.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HMODULE hLib = LoadLibrary(szDll);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (hLib == NULL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wprintf(L&quot;Still failed to load the DLL %s w/err 0x%08lx.\n&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;szDll, GetLastError());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return reinterpret_cast&lt;FARPROC&gt;(hLib);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Linker Support for Delay-Loaded DLLs<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/151kt790.aspx">http://msdn.microsoft.com/en-us/library/151kt790.aspx</a><br>
<br>
MSDN: Unloading a Delay-Loaded DLL<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/94zxdhbc.aspx">http://msdn.microsoft.com/en-us/library/94zxdhbc.aspx</a><br>
<br>
MSDN: Understanding the Helper Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx">http://msdn.microsoft.com/en-us/library/09t6x5ds.aspx</a><br>
<br>
MSDN: Notification Hooks<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/z9h1h6ty.aspx">http://msdn.microsoft.com/en-us/library/z9h1h6ty.aspx</a><br>
<br>
MSDN: Failure Hooks<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/sfcfb0a3.aspx">http://msdn.microsoft.com/en-us/library/sfcfb0a3.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
