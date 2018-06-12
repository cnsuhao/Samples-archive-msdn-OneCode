# VB app P/Invokes a native DLL (VBPInvokeDll)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Interop
* P/Invoke
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:12:06
## Description

<h2><span style="font-size:14.0pt; line-height:115%">CONSOLE APPLICATION </span><span style="font-size:14.0pt; line-height:115%">(</span><span style="font-size:14.0pt; line-height:115%">VBPInvokeDll</span><span style="font-size:14.0pt; line-height:115%">)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal">Platform Invocation Services (P/Invoke) in .NET allows managed code to call unmanaged functions that are implemented and exported in unmanaged DLLs. This VB.Net code sample demonstrates using P/Invoke to call the functions exported by
 the native DLLs: CppDynamicLinkLibrary.dll, user32.dll and msvcrt.dll.<span style="">
</span></p>
<h2>Running the Sample</h2>
<h2><span style=""><img src="/site/view/file/65169/1/image.png" alt="" width="576" height="376" align="middle">
</span><span style=""></span></h2>
<h2>Using the Code<span style=""> </span></h2>
<h3>A. P/Invoke functions exposed from a native C&#43;&#43; DLL module.</h3>
<p class="MsoNormal">Step1. Declare the methods as having an implementation from a DLL export.</p>
<p class="MsoNormal">First, declare the method with the <span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;; color:blue">
Shared </span><span style="">VB.NET</span> keywords. Next, attach the DllImport attribute to the method. The DllImport attribute allows us to specify the name of the DLL that contains the method. The general practice is to name the C# method the same as the
 exported method, but we can<span style=""> </span>also use a different name for the C# method. Specify custom marshaling information for the method's parameters and return value, which will override the .NET Framework default marshaling.
</p>
<p class="MsoNormal">For example, </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;DllImport(&quot;CppDynamicLinkLibrary.dll&quot;, CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Cdecl)&gt;
Public Shared Function GetStringLength1(ByVal str As String) As Integer
End Function

</pre>
<pre id="codePreview" class="vb">
&lt;DllImport(&quot;CppDynamicLinkLibrary.dll&quot;, CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Cdecl)&gt;
Public Shared Function GetStringLength1(ByVal str As String) As Integer
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal">These tools can help your write the correct P/Invoke declartions.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Dumpbin: View the export table of a DLL</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>PInvoke.NET: PInvoke.net is primarily a wiki, allowing developers to find,
<span style="">e</span>dit and add PInvoke* signatures, user-defined types, and any other info
<span style="">r</span>elated to calling Win32 and other unmanaged APIs from managed code such
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>as C# or VB.NET.<span style="">&nbsp;&nbsp;&nbsp; </span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>PInvoke Interop Assistant: It is a toolkit that helps developers to <span style="">
e</span>fficiently convert from C to managed P/Invoke signatures or verse visa. </p>
<p class="MsoNormal">Step2. Call the methods through the PInvoke signatures. For example:<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim str As String = &quot;HelloWorld&quot;
Dim length As Integer
length = NativeMethod.GetStringLength1(str)
Console.WriteLine(&quot;GetStringLength1(&quot;&quot;{0}&quot;&quot;) =&gt; {1}&quot;, str, length)

</pre>
<pre id="codePreview" class="vb">
Dim str As String = &quot;HelloWorld&quot;
Dim length As Integer
length = NativeMethod.GetStringLength1(str)
Console.WriteLine(&quot;GetStringLength1(&quot;&quot;{0}&quot;&quot;) =&gt; {1}&quot;, str, length)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3>B. P/Invoke C&#43;&#43; classes exposed from a native C&#43;&#43; DLL module.</h3>
<p class="MsoNormal">There is no easy way to call the classes in a native C&#43;&#43; DLL module through P/Invoke.
<a href="http://go.microsoft.com/?linkid=9729423.">Visual C&#43;&#43; Team Blog</a> introduced a solution, but it is complicated<span style="">.
</span></p>
<p class="MsoNormal">The recommended way of calling native C&#43;&#43; class from .NET are:</p>
<p class="MsoNormal"><span style="">&nbsp; </span>1) use a C&#43;&#43;/CLI class library to wrap the native C&#43;&#43; module, and your .NET<span style="">&nbsp;
</span>code class the C&#43;&#43;/CLI wrapper class to indirectly access the native C&#43;&#43;<span style="">&nbsp;
</span>class.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>2) convert the native C&#43;&#43; module to be a COM server and expose the native<span style="">&nbsp;
</span>C&#43;&#43; class through a COM interface. Then, the .NET code can access the<span style="">&nbsp;
</span>class through .NET-COM interop.</p>
<h3>C. Unload the native DLL module.</h3>
<p class="MsoNormal">You can unload the DLL by first calling GetModuleHandle to get the handle of the module and then calling FreeLibrary to unload it.
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt;
Shared Function GetModuleHandle(ByVal moduleName As String) As IntPtr
End Function


&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt;
Shared Function FreeLibrary(ByVal hModule As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function
' Unload the DLL by calling GetModuleHandle and FreeLibrary. 
If Not FreeLibrary(GetModuleHandle(moduleName)) Then
   Console.WriteLine(&quot;FreeLibrary failed w/err {0}&quot;, Marshal.GetLastWin32Error())
End If

</pre>
<pre id="codePreview" class="vb">
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt;
Shared Function GetModuleHandle(ByVal moduleName As String) As IntPtr
End Function


&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt;
Shared Function FreeLibrary(ByVal hModule As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function
' Unload the DLL by calling GetModuleHandle and FreeLibrary. 
If Not FreeLibrary(GetModuleHandle(moduleName)) Then
   Console.WriteLine(&quot;FreeLibrary failed w/err {0}&quot;, Marshal.GetLastWin32Error())
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体"></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/aa288468.aspx">MSDN: Platform Invoke Tutorial</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/aa719104.aspx">MSDN: Using P/Invoke to Call Unmanaged APIs from Your Managed Classes</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/magazine/cc164123.aspx">MSDN: Calling Win32 DLLs in C# with P/Invoke</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:新宋体"><a href="http://www.pinvoke.net/">PInvoke.NET</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:新宋体"><a href="http://www.codeplex.com/clrinterop">PInvoke Interop Assistant</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
