# C++ app implicitly links a DLL (CppImplicitlyLinkDll)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Library
## Topics
* DLL
* Implicitly Link
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:28:11
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppImplicitlyLinkDll Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Normally, when we link to a DLL via a LIB file, the DLL is loaded when the &nbsp;<br>
application starts up. This kind of loading is kwown as implicit linking, &nbsp;<br>
because the system takes care of loading the DLL for us - all we need to do <br>
is link with the LIB file.<br>
<br>
After the configuration of linking, we can import symbols of a DLL into the <br>
application using the keyword __declspec(dllimport) no matter whether the <br>
symbols were exported with __declspec(dllexport) or with a .def file.<br>
<br>
This sample demonstrates implicitly linking CppDynamicLinkLibrary.dll and <br>
importing and using its symbols.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New"><br>
CppImplicitlyLinkDll -&gt; CppDynamicLinkLibrary<br>
CppImplicitlyLinkDll implicitly links (staticly loads) the <br>
CppDynamicLinkLibrary.dll and uses its symbols.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step1. Reference the Dynamic Link Library in your C&#43;&#43; project.<br>
<br>
&nbsp;Option1. Link the LIB file of the DLL by entering the LIB file name in <br>
&nbsp;Project Properties / Linker / Input / Additional Dependencies. You can <br>
&nbsp;configure the search path of the LIB file in Project Properties / Linker / <br>
&nbsp;General / Additional Library Directories.<br>
<br>
&nbsp;Option2. Select References from the Project's shortcut menu. On the <br>
&nbsp;Property Pages dialog box, expand the Common Properties node, select <br>
&nbsp;References, and then select the Add New Reference... button. The Add <br>
&nbsp;Reference dialog box is displayed. This dialog lists all the libraries that
<br>
&nbsp;you can reference. The Projects tab lists all the projects in the current <br>
&nbsp;solution and any libraries they contain. If the CppDynamicLinkLibrary <br>
&nbsp;project is in the current solution, select CppDynamicLinkLibrary and click <br>
&nbsp;OK in the Projects tab.<br>
<br>
Step2. Include the header file that declares the functions and classes of the <br>
DLL.<br>
<br>
&nbsp; &nbsp;#include &quot;CppDynamicLinkLibrary.h&quot;<br>
<br>
You can configure the search path of the header file in Project Properties / <br>
C/C&#43;&#43; / General / Additional Include Directories.<br>
<br>
Step3. Use the imported symbols.<br>
<br>
For example:<br>
<br>
&nbsp; &nbsp;PWSTR pszString = L&quot;HelloWorld&quot;;<br>
&nbsp; &nbsp;int nLength;<br>
&nbsp; &nbsp;nLength = GetStringLength1(pszString);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Importing into an Application<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/kh1zw7z7.aspx">http://msdn.microsoft.com/en-us/library/kh1zw7z7.aspx</a><br>
<br>
MSDN: Creating and Using a Dynamic Link Library (C&#43;&#43;)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms235636.aspx">http://msdn.microsoft.com/en-us/library/ms235636.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
