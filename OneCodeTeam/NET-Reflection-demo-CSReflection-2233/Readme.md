# .NET Reflection demo (CSReflection)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Library
## Topics
* Reflection
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:56:00
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSReflection Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Reflection provides objects (of type Type) that encapsulate assemblies, <br>
modules and types. It allows us to<br>
<br>
1. Access attributes in your program's metadata.<br>
2. Examine and instantiate types in an assembly.<br>
3. Dynamically load and use types.<br>
4. Emit new types at runtime.<br>
<br>
This sample demonstrates 2 and 3. CSEmitAssembly shows the use of 4.<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSReflection -&gt; CSClassLibrary<br>
CSReflection dynamically loads the assembly, CSClassLibrary.dll, and <br>
instantiate, examine and use its types.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1. Dynamically load the assembly. <br>
(Assembly.LoadFrom, Assembly.Load, Assembly.LoadFile)<br>
<br>
2. Get a type and instantiate the type in the assembly.<br>
(Assembly.GetType, Activator.CreateInstance, Assembly.CreateInstance)<br>
<br>
3. Examine the type. (Type.GetFields, Type.GetProperties, Type.GetEvents, <br>
Type.GetMethods, Type.GetConstructors)<br>
<br>
4. Use the type (Late Binding). (MethodInfo.Invoke)<br>
<br>
5. There is no API to unload an assembly<br>
<a target="_blank" href="http://blogs.msdn.com/suzcook/archive/2003/07/08/57211.aspx">http://blogs.msdn.com/suzcook/archive/2003/07/08/57211.aspx</a><br>
<a target="_blank" href="http://blogs.msdn.com/jasonz/archive/2004/05/31/145105.aspx">http://blogs.msdn.com/jasonz/archive/2004/05/31/145105.aspx</a><br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Reflection (C# Programming Guide)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms173183.aspx">http://msdn.microsoft.com/en-us/library/ms173183.aspx</a><br>
<br>
Dynamically Loading and Using Types<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/k3a58006.aspx">http://msdn.microsoft.com/en-us/library/k3a58006.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
