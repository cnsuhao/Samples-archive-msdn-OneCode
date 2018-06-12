# C++ app dynamically loads a DLL (CppLoadLibrary)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* LoadLibrary
## IsPublished
* True
## ModifiedDate
* 2012-06-11 12:42:16
## Description

<h1><span style="">C&#43;&#43; Application Dynamically Loads a Native DLL and Invoke its Exported Functions</span> (<span class="SpellE">CppLoadLibrary</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This is an example of dynamically loading a DLL using the APIs LoadLibrary, GetProcAddress and FreeLibrary. In contrast with implicit linking (static loading), dynamic loading does not require the LIB file, and the application loads the
 module just before we call a function in the DLL. The API functions LoadLibrary and GetProcAddress are used to load the DLL and then retrieve the<span style="">
</span>address of a function in the export table. Because we explicitly invoke these APIs, this kind of loading is also referred to as explicit linking.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/59706/1/image.png" alt="" width="538" height="296" align="middle">
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
<p class="MsoNormal">3. Call GetProcAddress to get the address of the function in the export table of the DLL.</p>
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
<p class="MsoNormal">MSDN: Using Run-Time Dynamic <span class="GramE">Linking</span><span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/ms686944.aspx">http://msdn.microsoft.com/en-us/library/ms686944.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">MSDN: <span class="SpellE">LoadLibrary</span><br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms684175.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms684175.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">MSDN: <span class="SpellE">GetProcAddress</span><br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms683212.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms683212.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">MSDN: Dynamic-Link Library Functions<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms682599.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms682599.aspx</a>
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
