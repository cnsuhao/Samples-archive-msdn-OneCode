# C++ app statically links a static library (CppStaticallyLinkLib)
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
* 2011-05-05 04:38:09
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppStaticallyLinkLib Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates statically linking CppStaticLibrary.lib and using <br>
its functionalities.<br>
<br>
There are several advantages to statically linking libraries with an <br>
executable instead of dynamically linking them. The most significant is that <br>
the application can be certain that all its libraries are present and that <br>
they are the correct version. This avoids dependency problems. In some cases, <br>
static linking can result in a performance improvement. Static linking can <br>
also allow the application to be contained in a single executable file, <br>
simplifying distribution and installation. On the other hand, statically <br>
linking libraries with the executable increases its size. This is because the <br>
library code is stored within the executable rather than in separate files. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CppStaticallyLinkLib -&gt; CppStaticLibrary<br>
CppStaticallyLinkLib references CppStaticLibrary, and uses the functionality <br>
from the static library.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Referencing the Static Library<br>
<br>
Option1. Link the LIB file of CppStaticLibrary by entering the LIB file name &nbsp;<br>
in Project Properties / Linker / Input / Additional Dependencies. We can <br>
configure the search path of the LIB file in Project Properties / Linker / <br>
General / Additional Library Directories.<br>
<br>
Option2. Select References... from the Project's shortcut menu. From the <br>
Property Pages dialog box, expand the Common Properties node and select <br>
References. Then select the Add New Reference... button. The Add Reference <br>
dialog box is displayed. This dialog box lists all the libraries that you can <br>
reference. The Project tab lists all the projects in the current solution and <br>
any libraries they contain. On the Projects tab, select CppStaticLibrary. <br>
Then select OK.<br>
<br>
B. Including the header file<br>
<br>
To reference the header files of the static library, you can modify the <br>
include directories path. To do this, in the Property Pages dialog box, <br>
expand the Configuration Properties node, expand the C/C&#43;&#43; node, and then <br>
select General. Next to Additional Include Directories, type the path of the <br>
location of the CppSimpleClass.h and CppLibFuncs.h header files.<br>
<br>
In the source code file, include header with the statement:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &quot;CppSimpleClass.h&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &quot;CppLibFuncs.h&quot;<br>
<br>
C. Using the symbols<br>
<br>
For example:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;_TCHAR* result;<br>
&nbsp;&nbsp;&nbsp;&nbsp;HelloWorld(&result);<br>
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
