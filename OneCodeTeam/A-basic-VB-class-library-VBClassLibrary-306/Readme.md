# A basic VB class library (VBClassLibrary)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Class Library
## IsPublished
* True
## ModifiedDate
* 2012-08-22 03:47:09
## Description

<h1>LIBRARY APPLICATION <span style="">(</span>VBClassLibrary)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The code sample demonstrates a C# class library that we can use in other applications. The class library exposes a simple class named VBSimpleObject.
</p>
<p class="MsoNormal">The class contains:<span style=""> </span></p>
<p class="MsoNormal"><span style="">Constructor: </span></p>
<p class="MsoNormal"><span style="">Instance field and property: </span></p>
<p class="MsoNormal"><span style="">Instance method: </span></p>
<p class="MsoNormal"><span style="">Shared (static) method: </span></p>
<p class="MsoNormal"><span style="">Instance event: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// The event is fired in the set accessor of FloatProperty
public event PropertyChangingEventHandler FloatPropertyChanging;

</pre>
<pre id="codePreview" class="csharp">
// The event is fired in the set accessor of FloatProperty
public event PropertyChangingEventHandler FloatPropertyChanging;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">The process of creating the class library is very straight-forward.
</span></p>
<h2>Implementation: </h2>
<h3>A. Creating the project </h3>
<p class="MsoNormal">Step1. Create a Visual C# / Class Library project named VBClassLibrary in Visual Studio 2008.
</p>
<h3>B. Adding a class VBSimpleObject to the project and define its fields, properties, methods, and events.
</h3>
<p class="MsoNormal">Step1. In Solution Explorer, add a new Class item to the project and name it<span style="">
</span>as <span class="SpellE">VBSimpleObject</span>. </p>
<p class="MsoNormal">Step2. Edit the file VBSimpleObject.vb to add the fields, properties, methods,<span style="">
</span>and events. </p>
<h3>C. Signing the assembly with a strong name (Optional) </h3>
<p class="MsoNormal">Strong names are required to store shared assemblies in Global Assembly
<span class="GramE">Cache(</span>GAC). This helps avoid DLL Hell. <span class="GramE">
Strong names also protects</span> the assembly from being hacked (replaced or injected). A strong name consists of the assembly's identity—its simple text name, version number, and culture info<span style="">
</span>(if provided)—plus a public key and a digital signature. It is generated from an assembly file using the corresponding private key.
</p>
<p class="MsoNormal">Step1. Right-click the project and open its Properties page.
</p>
<p class="MsoNormal">Step2. Turn to the Signing tab, and check the Sign the assembly checkbox.
</p>
<p class="MsoNormal">Step3. In the Choose a strong name key file drop-down, select New. The &quot;Create Strong Name Key&quot; dialog appears. In the Key file name text box, type<span style="">
</span>the desired key name. If necessary, we can protect the strong name key file with a password. Click the OK button.<span style="">
</span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/b0b8dk77.aspx">MSDN: Creating Assemblies</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/xc31ft41.aspx">How to: Sign an Assembly with a Strong Name</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/3707x96z.aspx">How to: Create and Use C# DLLs (C# Programming Guide)</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
