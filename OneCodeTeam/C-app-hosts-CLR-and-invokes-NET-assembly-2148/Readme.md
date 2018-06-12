# C++ app hosts CLR and invokes .NET assembly (CppHostCLR)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* CLR
## Topics
* Interop
* CLR Hosting
## IsPublished
* True
## ModifiedDate
* 2012-04-20 03:36:44
## Description

<h1>C&#43;&#43; app hosts CLR and invokes .NET assembly (<span class="SpellE">CppHostCLR</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The Common Language Runtime (CLR) allows a level of integration between itself and a host. This C&#43;&#43; code sample demonstrates using the Hosting Interfaces of .NET Framework 1.0, 1.1 and 2.0 to host a specific version of
 CLR in the process, load a .NET assembly, and invoke the types in the assembly.<b>
</b></span></p>
<p class="MsoNormal"><span style="">NOTE: If you have installed .NET4.0, please use the new Hosting interfaces of .NET4.0. See the sample
</span><span style=""><a href="http://code.msdn.microsoft.com/CppHostCLR-e6581ee0">C&#43;&#43; app hosts CLR 4 and invokes .NET assembly (<span class="SpellE">CppHostCLR</span>)</a></span><span style="">
</span></p>
<h2>Building the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">The output path of these 2 projects should be same. In this sample, the output path is
<b style="">$(<span class="SpellE">SolutionDir</span>)\$(Configuration)\</b>. </span>
</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst">Press <b style="">F5</b> to debug this project<span style="">, and you will see</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/56605/1/image.png" alt="" width="576" height="114" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Demo .NET Framework 1.0 and 1.1 Hosting Interfaces in RuntimeHostV1.cpp
</span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Include &lt;<span class="SpellE">mscoree.h</span>&gt; and link with
<span class="SpellE">mscoree.dll's</span> import lib for <span class="SpellE">
<b style="">CorBindToRuntimeEx</b></span> and <span class="SpellE"><b style="">ICorRuntimeHost</b></span>, and import
<span class="SpellE">mscorlib.tlb</span> (Microsoft Common Language Runtime Class Library).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Include &lt;mscoree.h&gt; for CorBindToRuntimeEx and ICorRuntimeHost.
#include &lt;mscoree.h&gt;
// Link with mscoree.dll's import lib.
#pragma comment(lib, &quot;mscoree.lib&quot;) 


// Import mscorlib.tlb (Microsoft Common Language Runtime Class Library)
#import &quot;mscorlib.tlb&quot; raw_interfaces_only                \
    high_property_prefixes(&quot;_get&quot;,&quot;_put&quot;,&quot;_putref&quot;)        \
    rename(&quot;ReportEvent&quot;, &quot;InteropServices_ReportEvent&quot;)
using namespace mscorlib;

</pre>
<pre id="codePreview" class="cplusplus">
// Include &lt;mscoree.h&gt; for CorBindToRuntimeEx and ICorRuntimeHost.
#include &lt;mscoree.h&gt;
// Link with mscoree.dll's import lib.
#pragma comment(lib, &quot;mscoree.lib&quot;) 


// Import mscorlib.tlb (Microsoft Common Language Runtime Class Library)
#import &quot;mscorlib.tlb&quot; raw_interfaces_only                \
    high_property_prefixes(&quot;_get&quot;,&quot;_put&quot;,&quot;_putref&quot;)        \
    rename(&quot;ReportEvent&quot;, &quot;InteropServices_ReportEvent&quot;)
using namespace mscorlib;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Load and start the .NET runtime. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style="">Call
<span class="SpellE"><b style="">CorBindToRuntimeEx</b></span> to obtain an interface pointer to an
<span class="SpellE"><b style="">ICorRuntimeHost</b></span> that can be used to set additional options for configuring an instance of the
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">CLR before it is started. Then call
<span class="SpellE"><b style="">ICorRuntimeHost</b></span><b style="">::Start</b> to start the CLR.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
PCWSTR pszFlavor = L&quot;wks&quot;;
PCWSTR pszRuntimeModule = L&quot;mscorwks&quot;;
ICorRuntimeHost *pCorRuntimeHost = NULL;
hr = CorBindToRuntimeEx(
    pszVersion,                     // Runtime version
    pszFlavor,                      // Flavor of the runtime to request
    0,                              // Runtime startup flags
    CLSID_CorRuntimeHost,           // CLSID of ICorRuntimeHost
    IID_PPV_ARGS(&pCorRuntimeHost)  // Return ICorRuntimeHost
    );
if (FAILED(hr)) { /* Error handling */ }
hr = pCorRuntimeHost-&gt;Start();
if (FAILED(hr)) { /* Error handling */ }

</pre>
<pre id="codePreview" class="cplusplus">
PCWSTR pszFlavor = L&quot;wks&quot;;
PCWSTR pszRuntimeModule = L&quot;mscorwks&quot;;
ICorRuntimeHost *pCorRuntimeHost = NULL;
hr = CorBindToRuntimeEx(
    pszVersion,                     // Runtime version
    pszFlavor,                      // Flavor of the runtime to request
    0,                              // Runtime startup flags
    CLSID_CorRuntimeHost,           // CLSID of ICorRuntimeHost
    IID_PPV_ARGS(&pCorRuntimeHost)  // Return ICorRuntimeHost
    );
if (FAILED(hr)) { /* Error handling */ }
hr = pCorRuntimeHost-&gt;Start();
if (FAILED(hr)) { /* Error handling */ }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Load a .NET assembly and call the static method.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">Instantiate the class
<span class="SpellE"><b style="">CSSimpleObject</b></span> and call its instance method
<span class="SpellE"><b style="">ToString</b></span>. Different from .NET Framework 2.0 Hosting Interfaces, .NET Framework 1.0 and 1.1 Hosting Interfaces does not limit the signature of the invoked method.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
IUnknownPtr spAppDomainThunk = NULL;
_AppDomainPtr spDefaultAppDomain = NULL;


// The .NET assembly to load.
bstr_t bstrAssemblyName(L&quot;CSClassLibrary&quot;);
_AssemblyPtr spAssembly = NULL;


// The .NET class to instantiate.
bstr_t bstrClassName(L&quot;CSClassLibrary.CSSimpleObject&quot;);
_TypePtr spType = NULL;
variant_t vtObject;
variant_t vtEmpty;


// The static method in the .NET class to invoke.
bstr_t bstrStaticMethodName(L&quot;GetStringLength&quot;);
SAFEARRAY *psaStaticMethodArgs = NULL;
variant_t vtStringArg(L&quot;HelloWorld&quot;);
variant_t vtLengthRet;


// The instance method in the .NET class to invoke.
bstr_t bstrMethodName(L&quot;ToString&quot;);
SAFEARRAY *psaMethodArgs = NULL;
variant_t vtStringRet;




hr = spAppDomainThunk-&gt;QueryInterface(IID_PPV_ARGS(&spDefaultAppDomain));
if (FAILED(hr))
{
    wprintf(L&quot;Failed to get default AppDomain w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Load the .NET assembly.
wprintf(L&quot;\nLoad the assembly %s\n&quot;, (PCWSTR)bstrAssemblyName);
hr = spDefaultAppDomain-&gt;Load_2(bstrAssemblyName, &spAssembly);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to load the assembly w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Get the Type of CSSimpleObject.
hr = spAssembly-&gt;GetType_2(bstrClassName, &spType);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to get the Type interface w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Call the static method of the class:
//   public static int GetStringLength(string str);


// Create a safe array to contain the arguments of the method. The safe 
// array must be created with vt = VT_VARIANT because .NET reflection 
// expects an array of Object - VT_VARIANT. There is only one argument, 
// so cElements = 1.
psaStaticMethodArgs = SafeArrayCreateVector(VT_VARIANT, 0, 1);
LONG index = 0;
hr = SafeArrayPutElement(psaStaticMethodArgs, &index, &vtStringArg);
if (FAILED(hr))
{
    wprintf(L&quot;SafeArrayPutElement failed w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Invoke the &quot;GetStringLength&quot; method from the Type interface.
hr = spType-&gt;InvokeMember_3(bstrStaticMethodName, (BindingFlags)
    (BindingFlags_InvokeMethod | BindingFlags_Static | BindingFlags_Public), 
    NULL, vtEmpty, psaStaticMethodArgs, &vtLengthRet);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to invoke GetStringLength w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Print the call result of the static method.
wprintf(L&quot;Call %s.%s(\&quot;%s\&quot;) =&gt; %d\n&quot;, (PCWSTR)bstrClassName, 
    (PCWSTR)bstrStaticMethodName, (PCWSTR)vtStringArg.bstrVal, 
    vtLengthRet.lVal);


// Instantiate the class.
hr = spAssembly-&gt;CreateInstance(bstrClassName, &vtObject);
if (FAILED(hr))
{
    wprintf(L&quot;Assembly::CreateInstance failed w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Call the instance method of the class.
//   public string ToString();


// Create a safe array to contain the arguments of the method.
psaMethodArgs = SafeArrayCreateVector(VT_VARIANT, 0, 0);


// Invoke the &quot;ToString&quot; method from the Type interface.
hr = spType-&gt;InvokeMember_3(bstrMethodName, (BindingFlags)
    (BindingFlags_InvokeMethod | BindingFlags_Instance | BindingFlags_Public),
    NULL, vtObject, psaMethodArgs, &vtStringRet);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to invoke ToString w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Print the call result of the method.
wprintf(L&quot;Call %s.%s() =&gt; %s\n&quot;, (PCWSTR)bstrClassName, 
    (PCWSTR)bstrMethodName, (PCWSTR)vtStringRet.bstrVal);

</pre>
<pre id="codePreview" class="cplusplus">
IUnknownPtr spAppDomainThunk = NULL;
_AppDomainPtr spDefaultAppDomain = NULL;


// The .NET assembly to load.
bstr_t bstrAssemblyName(L&quot;CSClassLibrary&quot;);
_AssemblyPtr spAssembly = NULL;


// The .NET class to instantiate.
bstr_t bstrClassName(L&quot;CSClassLibrary.CSSimpleObject&quot;);
_TypePtr spType = NULL;
variant_t vtObject;
variant_t vtEmpty;


// The static method in the .NET class to invoke.
bstr_t bstrStaticMethodName(L&quot;GetStringLength&quot;);
SAFEARRAY *psaStaticMethodArgs = NULL;
variant_t vtStringArg(L&quot;HelloWorld&quot;);
variant_t vtLengthRet;


// The instance method in the .NET class to invoke.
bstr_t bstrMethodName(L&quot;ToString&quot;);
SAFEARRAY *psaMethodArgs = NULL;
variant_t vtStringRet;




hr = spAppDomainThunk-&gt;QueryInterface(IID_PPV_ARGS(&spDefaultAppDomain));
if (FAILED(hr))
{
    wprintf(L&quot;Failed to get default AppDomain w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Load the .NET assembly.
wprintf(L&quot;\nLoad the assembly %s\n&quot;, (PCWSTR)bstrAssemblyName);
hr = spDefaultAppDomain-&gt;Load_2(bstrAssemblyName, &spAssembly);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to load the assembly w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Get the Type of CSSimpleObject.
hr = spAssembly-&gt;GetType_2(bstrClassName, &spType);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to get the Type interface w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Call the static method of the class:
//   public static int GetStringLength(string str);


// Create a safe array to contain the arguments of the method. The safe 
// array must be created with vt = VT_VARIANT because .NET reflection 
// expects an array of Object - VT_VARIANT. There is only one argument, 
// so cElements = 1.
psaStaticMethodArgs = SafeArrayCreateVector(VT_VARIANT, 0, 1);
LONG index = 0;
hr = SafeArrayPutElement(psaStaticMethodArgs, &index, &vtStringArg);
if (FAILED(hr))
{
    wprintf(L&quot;SafeArrayPutElement failed w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Invoke the &quot;GetStringLength&quot; method from the Type interface.
hr = spType-&gt;InvokeMember_3(bstrStaticMethodName, (BindingFlags)
    (BindingFlags_InvokeMethod | BindingFlags_Static | BindingFlags_Public), 
    NULL, vtEmpty, psaStaticMethodArgs, &vtLengthRet);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to invoke GetStringLength w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Print the call result of the static method.
wprintf(L&quot;Call %s.%s(\&quot;%s\&quot;) =&gt; %d\n&quot;, (PCWSTR)bstrClassName, 
    (PCWSTR)bstrStaticMethodName, (PCWSTR)vtStringArg.bstrVal, 
    vtLengthRet.lVal);


// Instantiate the class.
hr = spAssembly-&gt;CreateInstance(bstrClassName, &vtObject);
if (FAILED(hr))
{
    wprintf(L&quot;Assembly::CreateInstance failed w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Call the instance method of the class.
//   public string ToString();


// Create a safe array to contain the arguments of the method.
psaMethodArgs = SafeArrayCreateVector(VT_VARIANT, 0, 0);


// Invoke the &quot;ToString&quot; method from the Type interface.
hr = spType-&gt;InvokeMember_3(bstrMethodName, (BindingFlags)
    (BindingFlags_InvokeMethod | BindingFlags_Instance | BindingFlags_Public),
    NULL, vtObject, psaMethodArgs, &vtStringRet);
if (FAILED(hr))
{
    wprintf(L&quot;Failed to invoke ToString w/hr 0x%08lx\n&quot;, hr);
    goto Cleanup;
}


// Print the call result of the method.
wprintf(L&quot;Call %s.%s() =&gt; %s\n&quot;, (PCWSTR)bstrClassName, 
    (PCWSTR)bstrMethodName, (PCWSTR)vtStringRet.bstrVal);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">Above code is similar to the following .NET reflection code.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
Assembly assembly = AppDomain.CurrentDomain.Load(&quot;CSClassLibrary&quot;);
object length = type.InvokeMember(&quot;GetStringLength&quot;, 
    BindingFlags.InvokeMethod | BindingFlags.Static | 
    BindingFlags.Public, null, null, new object[] { &quot;HelloWorld&quot; });
object obj = assembly.CreateInstance(&quot;CSClassLibrary.CSSimpleObject&quot;);
object str = type.InvokeMember(&quot;ToString&quot;, 
    BindingFlags.InvokeMethod | BindingFlags.Instance | 
    BindingFlags.Public, null, obj, new object[] { });

</pre>
<pre id="codePreview" class="csharp">
Assembly assembly = AppDomain.CurrentDomain.Load(&quot;CSClassLibrary&quot;);
object length = type.InvokeMember(&quot;GetStringLength&quot;, 
    BindingFlags.InvokeMethod | BindingFlags.Static | 
    BindingFlags.Public, null, null, new object[] { &quot;HelloWorld&quot; });
object obj = assembly.CreateInstance(&quot;CSClassLibrary.CSSimpleObject&quot;);
object str = type.InvokeMember(&quot;ToString&quot;, 
    BindingFlags.InvokeMethod | BindingFlags.Instance | 
    BindingFlags.Public, null, obj, new object[] { });

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Stops the execution of code in the runtime for the current process.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style="">Please note that after a call to Stop, the CLR cannot be reinitialized
<span class="SpellE">intothe</span> same process. This step is usually not necessary. You can leave the .NET runtime loaded in your process.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
pCorRuntimeHost-&gt;Stop();

</pre>
<pre id="codePreview" class="cplusplus">
pCorRuntimeHost-&gt;Stop();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Demo .NET Framework 2.0 Hosting Interfaces in RuntimeHostV2.cpp
</span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Include &lt;<span class="SpellE">mscoree.h</span>&gt; and link with
<span class="SpellE">mscoree.dll's</span> import lib for <span class="SpellE">
<b style="">CorBindToRuntimeEx</b></span> and <span class="SpellE"><b style="">ICLRRuntimeHost</b></span>, and import
<span class="SpellE">mscorlib.tlb</span> (Microsoft Common Language Runtime Class Library).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Include &lt;mscoree.h&gt; for CorBindToRuntimeEx and ICLRRuntimeHost.
#include &lt;mscoree.h&gt;
// Link with mscoree.dll's import lib.
#pragma comment(lib, &quot;mscoree.lib&quot;) 


// Import mscorlib.tlb (Microsoft Common Language Runtime Class Library).
#import &quot;mscorlib.tlb&quot; raw_interfaces_only                \
    high_property_prefixes(&quot;_get&quot;,&quot;_put&quot;,&quot;_putref&quot;)        \
    rename(&quot;ReportEvent&quot;, &quot;InteropServices_ReportEvent&quot;)
using namespace mscorlib;

</pre>
<pre id="codePreview" class="cplusplus">
// Include &lt;mscoree.h&gt; for CorBindToRuntimeEx and ICLRRuntimeHost.
#include &lt;mscoree.h&gt;
// Link with mscoree.dll's import lib.
#pragma comment(lib, &quot;mscoree.lib&quot;) 


// Import mscorlib.tlb (Microsoft Common Language Runtime Class Library).
#import &quot;mscorlib.tlb&quot; raw_interfaces_only                \
    high_property_prefixes(&quot;_get&quot;,&quot;_put&quot;,&quot;_putref&quot;)        \
    rename(&quot;ReportEvent&quot;, &quot;InteropServices_ReportEvent&quot;)
using namespace mscorlib;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Load and start the .NET runtime. </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">Call
<span class="SpellE"><b style="">CorBindToRuntimeEx</b></span> to obtain an interface pointer to an
<span class="SpellE"><b style="">ICLRRuntimeHost</b></span> Then call <span class="SpellE">
<b style="">ICLRRuntimeHost</b></span><b style="">::Start</b> to start the CLR. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
PCWSTR pszFlavor = L&quot;wks&quot;;
PCWSTR pszRuntimeModule = L&quot;mscorwks&quot;;
ICLRRuntimeHost *pClrRuntimeHost = NULL;
hr = CorBindToRuntimeEx(
    pszVersion,                     // Runtime version
    pszFlavor,                      // Flavor of the runtime to request
    0,                              // Runtime startup flags
    CLSID_CLRRuntimeHost,           // CLSID of ICorRuntimeHost
    IID_PPV_ARGS(&pClrRuntimeHost)  // Return ICLRRuntimeHost
    );
if (FAILED(hr)) { /* Error handling */ }
hr = pClrRuntimeHost-&gt;Start();
if (FAILED(hr)) { /* Error handling */ }

</pre>
<pre id="codePreview" class="cplusplus">
PCWSTR pszFlavor = L&quot;wks&quot;;
PCWSTR pszRuntimeModule = L&quot;mscorwks&quot;;
ICLRRuntimeHost *pClrRuntimeHost = NULL;
hr = CorBindToRuntimeEx(
    pszVersion,                     // Runtime version
    pszFlavor,                      // Flavor of the runtime to request
    0,                              // Runtime startup flags
    CLSID_CLRRuntimeHost,           // CLSID of ICorRuntimeHost
    IID_PPV_ARGS(&pClrRuntimeHost)  // Return ICLRRuntimeHost
    );
if (FAILED(hr)) { /* Error handling */ }
hr = pClrRuntimeHost-&gt;Start();
if (FAILED(hr)) { /* Error handling */ }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Load the NET assembly <b style="">CSClassLibrary.dll,</b> and call the static method
<span class="SpellE"><b style="">GetStringLength</b></span> of the type <span class="SpellE">
<b style="">CSSimpleObject</b></span> in the assembly. </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">.NET Framework 2.0 Hosting Interfaces allows you to load a .NET assembly, and execute its code in the default application domain by calling
<span class="SpellE"><b style="">ICLRRuntimeHost</b></span><b style="">::<span class="SpellE">ExecuteInDefaultAppDomain</span></b>. However, there is a restriction to the invoked .NET method: The invoked method of
<span class="SpellE"><b style="">ExecuteInDefaultAppDomain</b></span> must have the following signature where
<span class="SpellE">pwzMethodName</span> represents the name of the invoked method, and
<span class="SpellE">pwzArgument</span> represents the string value passed as a parameter to that method.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
static int pwzMethodName (String pwzArgument)

</pre>
<pre id="codePreview" class="cplusplus">
static int pwzMethodName (String pwzArgument)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">If the HRESULT return value of
<span class="SpellE"><b style="">ExecuteInDefaultAppDomain</b></span> is set to S_OK,
<span class="SpellE">pReturnValue</span> is set to the integer value returned by the invoked method. Otherwise,
<span class="SpellE">pReturnValue</span> is not set. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
hr = pClrRuntimeHost-&gt;ExecuteInDefaultAppDomain(pszAssemblyPath, 
    pszClassName, pszStaticMethodName, pszStringArg, &dwLengthRet);

</pre>
<pre id="codePreview" class="cplusplus">
hr = pClrRuntimeHost-&gt;ExecuteInDefaultAppDomain(pszAssemblyPath, 
    pszClassName, pszStaticMethodName, pszStringArg, &dwLengthRet);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Stops the execution of code in the runtime for the current process.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">Please note that after a call to Stop, the CLR cannot be reinitialized
<span class="SpellE">intothe</span> same process. This step is usually not necessary. You can leave the .NET runtime loaded in your process.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
pClrRuntimeHost-&gt;Stop();

</pre>
<pre id="codePreview" class="cplusplus">
pClrRuntimeHost-&gt;Stop();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms164318.aspx">.NET Framework 1.0 and 1.1 Hosting Interfaces</a></span><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms164336.aspx">.NET Framework 2.0 Hosting Interfaces</a><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/9x0wh2z3.aspx">Hosting the Common Language Runtime</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://support.microsoft.com/kb/953836">Calling
<span class="GramE">A</span> .NET Managed Method from Native Code</a> </span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/magazine/cc163567.aspx">CLR Hosting APIs</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
