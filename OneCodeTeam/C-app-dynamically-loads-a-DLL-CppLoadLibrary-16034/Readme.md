# C++ app dynamically loads a DLL (CppLoadLibrary)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* LoadLibrary
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:49:04
## Description

<h1>CONSOLE APPLICATION (CppLoadLibrary)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This is an example of dynamically loading a DLL using the APIs LoadLibrary, GetProcAddress and FreeLibrary. In contrast with implicit linking (static loading), dynamic loading does not require the LIB file, and the application loads the
 module just before we call a function in the DLL. The API functions LoadLibrary and GetProcAddress are used to load the DLL and then retrieve the<span style="">
</span>address of a function in the export table. Because we explicitly invoke these APIs, this kind of loading is also referred to as explicit linking.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54136/1/image.png" alt="" width="673" height="370" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Type-define the functions exported from the DLL. For example:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Function pointer types for functions exported from the DLL module


typedef int     (_cdecl* LPFNGETSTRINGLENGTH1)      (PCWSTR);


// CALLBACK, aka __stdcall, can only be used for stdcall methods. If it is
// used for __cdecl methods, this error will be thrown in runtime: The value 
// of ESP was not properly saved across a function call. This is usually a 
// result of calling a function declared with one calling convention with a
// function pointer declared with a different calling convention.
typedef int     (CALLBACK* LPFNGETSTRINGLENGTH2)    (PCWSTR);


// Type-definition of the 'PFN_COMPARE' callback function, and the CompareInts 
// function that requires the callback as one of the arguments.
typedef int     (CALLBACK* PFN_COMPARE)             (int, int);
typedef int     (CALLBACK* LPFNMAX)                 (int, int, PFN_COMPARE);

</pre>
<pre id="codePreview" class="cplusplus">
// Function pointer types for functions exported from the DLL module


typedef int     (_cdecl* LPFNGETSTRINGLENGTH1)      (PCWSTR);


// CALLBACK, aka __stdcall, can only be used for stdcall methods. If it is
// used for __cdecl methods, this error will be thrown in runtime: The value 
// of ESP was not properly saved across a function call. This is usually a 
// result of calling a function declared with one calling convention with a
// function pointer declared with a different calling convention.
typedef int     (CALLBACK* LPFNGETSTRINGLENGTH2)    (PCWSTR);


// Type-definition of the 'PFN_COMPARE' callback function, and the CompareInts 
// function that requires the callback as one of the arguments.
typedef int     (CALLBACK* PFN_COMPARE)             (int, int);
typedef int     (CALLBACK* LPFNMAX)                 (int, int, PFN_COMPARE);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Dynamically load the DLL by calling LoadLibrary.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
hModule = LoadLibrary(pszModuleName);

</pre>
<pre id="codePreview" class="cplusplus">
hModule = LoadLibrary(pszModuleName);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Call GetProcAddress to get the address of the function in the export table of the DLL.<span style="">
<span class="GramE">Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</span> If the function succeeds, the return value is the address of the exported function or variable. If the function fails, the
 return value is NULL. To get extended error information, call <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms679360(v=vs.85).aspx">
<span class="SpellE">GetLastError</span></a>. </span></p>
<p class="MsoNormal"><span style="">The spelling and case of a function name pointed to by
<span class="SpellE">lpProcName</span> must be identical to that in the EXPORTS statement of the source DLL's module-definition (.<span class="SpellE">def</span>) file. The exported names of functions may differ from the names you use when calling these
 functions in your code. This difference is hidden by macros used in the SDK header files. For more information, see Conventions for Function Prototypes.
</span></p>
<p class="MsoNormal"><span style="">The <span class="SpellE">lpProcName</span> parameter can identify the DLL function by specifying an ordinal value associated with the function in the EXPORTS statement.
<span class="SpellE">GetProcAddress</span> verifies that the specified ordinal is in the range 1 through the highest ordinal value exported in the .<span class="SpellE">def</span> file. The function then uses the ordinal as an index to read the function's
 address from a function table. </span></p>
<p class="MsoNormal"><span style="">If the .<span class="SpellE">def</span> file does not number the functions consecutively from 1 to N (where N is the number of exported functions), an error can occur where
<span class="SpellE">GetProcAddress</span> returns an invalid, non-NULL address, even though there is no function with the specified ordinal.
</span></p>
<p class="MsoNormal"><span style="">If the function might not exist in the DLL module��for example, if the function is available only on Windows Vista but the application might be running on Windows XP��specify the function by name rather than by ordinal
 value and design your application to handle the case when the function is not available, as shown in the following code fragment.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
LPFNGETSTRINGLENGTH1 lpfnGetStringLength1 = (LPFNGETSTRINGLENGTH1) 
    GetProcAddress(hModule, &quot;GetStringLength1&quot;);

</pre>
<pre id="codePreview" class="cplusplus">
LPFNGETSTRINGLENGTH1 lpfnGetStringLength1 = (LPFNGETSTRINGLENGTH1) 
    GetProcAddress(hModule, &quot;GetStringLength1&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Call the function.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
PWSTR pszString = L&quot;HelloWorld&quot;;
int nLength;
nLength = lpfnGetStringLength1(pszString);

</pre>
<pre id="codePreview" class="cplusplus">
PWSTR pszString = L&quot;HelloWorld&quot;;
int nLength;
nLength = lpfnGetStringLength1(pszString);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Unload the library by calling FreeLibrary.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
FreeLibrary(hModule);

</pre>
<pre id="codePreview" class="cplusplus">
FreeLibrary(hModule);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal">MSDN: Using Run-Time Dynamic Linking<span style=""> </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms686944.aspx">http://msdn.microsoft.com/en-us/library/ms686944.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
