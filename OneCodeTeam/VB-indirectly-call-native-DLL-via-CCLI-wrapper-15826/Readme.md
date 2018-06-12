# VB indirectly call native DLL via C++/CLI wrapper (VBCallNativeDllWrapper)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Interop
## IsPublished
* True
## ModifiedDate
* 2012-08-22 03:47:53
## Description

<h1><span style="font-family:新宋体">Console Application </span>(<span class="SpellE"><span style="font-family:新宋体">VBCallNativeDllWrapper</span></span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The code sample demonstrates calling the functions and classes exported by a native C&#43;&#43; DLL module from VB.NET code through C&#43;&#43;/CLI wrapper classes.
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp; </span><span class="SpellE">VBCallNativeDllWrapper</span> (this .NET application)<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>--&gt;<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="SpellE">CppCLINativeDllWrapper</span> (the C&#43;&#43;/CLI wrapper)<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>--&gt;<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="SpellE">CppDynamicLinkLibrary</span> (a native C&#43;&#43; DLL module)<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<h3>Demo</h3>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The following steps walk through a demonstration of the .NET-native <span class="SpellE">
interop</span> sample.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step1. After you successfully build the <span class="SpellE">CppDynamicLinkLibrary</span>,
<span class="SpellE">CppCLINativeDllWrapper</span>, and <span class="SpellE">
VBCallNativeDllWrapper</span> sample projects in Visual Studio 2008, you will get the applications: VBCallNativeDllWrapper.exe and two DLL files: CppCLINativeDllWrapper.dll and CppDynamicLinkLibrary.dll. Their relationship is that VBCallNativeDllWrapper.exe
 invokes CppCLINativeDllWrapper.dll, which further invokes functions and classes exported by CppDynamicLinkLibrary.dll.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step2. Run <span class="SpellE">VBCallNativeDllWrapper</span> in a command prompt. The application should<span style="">
</span>print the following messages in the console. </p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/65148/1/image.png" alt="" width="525" height="251" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The messages indicate that <span class="SpellE">VBCallNativeDllWrapper</span> <span class="SpellE">
successfuly</span> loaded CppDynamicLinkLibrary.dll and invoked the functions (GetStringLength1, GetStringLength2, Max) and the class (<span class="SpellE">CSimpleObject</span>) exported by the native module.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
NOTE: You may receive the following error if you run the debug build of the sample project on a system without the Visual Studio 2008 installed.
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;&nbsp;&nbsp; </span>Unhandled Exception: <span class="SpellE">
System.IO.FileLoadException</span>: Could not load file <span class="GramE">or<span style="">&nbsp;
</span>assembly</span> '<span class="SpellE">CppCLINativeDllWrapper</span>, Version=1.0.0.0, Culture=neutral,
<span class="SpellE">PublicKeyToken</span>=null' or one of its dependencies. This application
<span class="GramE">has<span style="">&nbsp; </span>failed</span> to start because the application configuration is incorrect.<span style="">&nbsp;
</span>Reinstalling the application may fix this problem. (Exception from HRESULT: 0x800736B1) File name:
<span class="SpellE">CppCLINativeDllWrapper</span>, Version=1.0.0.0, Culture=neutral<span class="GramE">,<span style="">&nbsp;
</span><span class="SpellE">PublicKeyToken</span></span>=null' ---&gt; <span class="SpellE">
System.Runtime.InteropServices.COMException</span><span style="">&nbsp; </span>(0x800736B1): This application has failed to start because the application configuration is incorrect. Reinstalling the application may fix
<span class="GramE">this<span style="">&nbsp; </span>problem</span>. (Exception from HRESULT: 0x800736B1) at
<span class="SpellE"><span class="GramE">CSCallNativeDllWrapper.Program.Main</span></span><span class="GramE">(</span>String[]
<span class="SpellE">args</span>)</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This is caused by the fact the debug build of <span class="SpellE">CppCLINativeDllWrapper</span> and
<span class="SpellE">CppDynamicLinkLibrary</span> depends on the Debug CRT which is only available in the development environments with Visual Studio 2008 installed. You must run the release build of the sample project in the non-development environment.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<h3>Implementation</h3>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step1. Reference the C&#43;&#43;/CLI wrapper class library <span class="SpellE">CppCLINativeDllWrapper</span> in the VB.NET sample
<span class="SpellE">applicatino</span>. <span class="SpellE">CppCLINativeDllWrapper</span> wraps the functions and classes exported by the native C&#43;&#43; DLL
<span class="SpellE">CppDynamicLinkLibrary</span>.<span style=""> </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step2. Call the .NET classes <span class="SpellE">CSimpleObjectWrapper</span> and
<span class="SpellE">NativeMethods</span> exposed by <span class="SpellE">CppCLINativeDllWrapper</span> to indirectly access the functions and classes exported by the native C&#43;&#43; DLL
<span class="SpellE">CppDynamicLinkLibrary</span>. For example, <span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/2x8kf7zx.aspx">Using C&#43;&#43;
<span class="SpellE">Interop</span> (Implicit <span class="SpellE">PInvoke</span>)</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms235281.aspx">How to: Wrap Native Class for Use by C#</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
