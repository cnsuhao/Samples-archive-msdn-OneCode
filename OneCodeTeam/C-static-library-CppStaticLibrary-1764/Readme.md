# C++ static library (CppStaticLibrary)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Library
## Topics
* Lib
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:38:46
## Description

<p style="font-family:Courier New"></p>
<h2>STATIC LIBRARY : CppStaticLibrary Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates exporting functions and classes for use in C or C&#43;&#43; <br>
language executables in the form of a static library.<br>
<br>
A static library or statically-linked library is a set of routines, external <br>
functions and variables which are resolved in a caller at compile-time and <br>
copied into a target application by a compiler, linker, or binder, producing <br>
an object file and a stand-alone executable. This executable and the process <br>
of compiling it are both known as a static build of the program.<br>
<br>
There are several advantages to statically linking libraries with an <br>
executable instead of dynamically linking them. The most significant is that <br>
the application can be certain that all its libraries are present and that <br>
they are the correct version. This avoids dependency problems. In some cases, <br>
static linking can result in a performance improvement. Static linking can <br>
also allow the application to be contained in a single executable file, <br>
simplifying distribution and installation. On the other hand, statically <br>
linking libraries with the executable increases its size. This is because the<br>
library code is stored within the executable rather than in separate files.<br>
<br>
The sample LIB exports these functionalities:<br>
<br>
// Functions<br>
int /*__cdecl*/ GetStringLength1(PCWSTR pszString);<br>
int __stdcall GetStringLength2(PCWSTR pszString);<br>
<br>
// Class<br>
CppSimpleClass<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New"><br>
CppStaticallyLinkLib -&gt; CppStaticLibrary<br>
CppStaticallyLinkLib references CppStaticLibrary, and uses the functionality <br>
from the static library.<br>
<br>
CppCLIWrapLib -&gt; CppStaticLibrary<br>
CppCLIWrapLib wraps the native class in CppStaticLibrary so it can be <br>
consumed by code authored in C#, or other .NET language.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / Win32 / Win32 Project named CppStaticLibrary in <br>
Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of Win32 Application Wizard, select<br>
Application type as Static library, and check the Precompiled header checkbox. <br>
Click Finish.<br>
<br>
B. Adding a class and some functions to the static library<br>
<br>
Step1. Create the files CppSimpleClass.h/cpp.<br>
<br>
Step2. Declare the class CppSimpleClass in CppSimpleClass.h, and implement <br>
the class in CppSimpleClass.cpp.<br>
<br>
Step3. Create the files CppLibFuncs.h/cpp.<br>
<br>
Step4. Declare the functions GetStringLength1 and GetStringLength2 in <br>
CppLibFuncs.h, and implement the functions in CppLibFuncs.cpp.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Creating and Using a Static Library (C&#43;&#43;)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms235627.aspx">http://msdn.microsoft.com/en-us/library/ms235627.aspx</a><br>
<br>
Static library<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/Static_library">http://en.wikipedia.org/wiki/Static_library</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
