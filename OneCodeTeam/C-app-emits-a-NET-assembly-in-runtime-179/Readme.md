# C# app emits a .NET assembly in runtime (CSEmitAssembly)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Library
## Topics
* Reflection
* Emit
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:27:30
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSEmitAssembly Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Reflection provides objects (of type Type) that encapsulate assemblies, <br>
modules and types. It allows us to<br>
<br>
1. Access attributes in your program's metadata.<br>
2. Examine and instantiate types in an assembly.<br>
3. Dynamically load and use types.<br>
4. Emit new types at runtime.<br>
<br>
This example shows the use of 4. CSReflection demonstrates 2 and 3. <br>
<br>
The System.Reflection.Emit namespace allows emitting metadata and Microsoft<br>
intermediate language (MSIL) at run time and optionally generate a portable<br>
executable (PE) file on disk. <br>
<br>
CSEmitAssembly emits these two types and save them to an assembly on disk:<br>
<br>
public class ClassA {<br>
&nbsp; &nbsp;// Fields<br>
&nbsp; &nbsp;private ClassB classBField;<br>
&nbsp; &nbsp;private String stringField;<br>
<br>
&nbsp; &nbsp;// Methods<br>
&nbsp; &nbsp;public void ClassAMethod()<br>
&nbsp; &nbsp;{ this.classBField.ClassBMethod(null); }<br>
<br>
&nbsp; &nbsp;// Properties<br>
&nbsp; &nbsp;public ClassB ClassBProperty {<br>
&nbsp; &nbsp; &nbsp; &nbsp;get { return this.classBField; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;set { this.classBField = value; }<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
public class ClassB {<br>
&nbsp; &nbsp;// Fields<br>
&nbsp; &nbsp;private List&lt;ClassA&gt; classAList;<br>
&nbsp; &nbsp;private ClassA classAField;<br>
<br>
&nbsp; &nbsp;// Methods<br>
&nbsp; &nbsp;public void ClassBMethod(List&lt;ClassA&gt; list) {<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.classAField.ClassAMethod();<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;// Properties<br>
&nbsp; &nbsp;public List&lt;ClassA&gt; ClassAList {<br>
&nbsp; &nbsp; &nbsp; &nbsp;get { return this.classAList; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;set { this.classAList.AddRange(value); }<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The ReflectionEmitLanguage Add-in of .NET Reflector <br>
(<a target="_blank" href="http://reflectoraddins.codeplex.com/)">http://reflectoraddins.codeplex.com/)</a><br>
translates the IL code of a given method into the C# code that would be <br>
needed to generate the same IL code using System.Reflection.Emit. We can <br>
first build a .NET assembly with the target types, then use the tool to <br>
generate the System.Reflection.Emit codes that emits the same types.<br>
<br>
1. Define the assembly and the module.<br>
(AppDomain.DefineDynamicAssembly, AssemblyBuilder.DefineDynamicModule)<br>
<br>
2. Declare the types. (ModuleBuilder.DefineType)<br>
<br>
3. Define the types' constructors, fields, properties, and methods.<br>
(TypeBuilder.DefineConstructor, TypeBuilder.DefineField, <br>
TypeBuilder.DefineProperty, TypeBuilder.DefineMethod)<br>
<br>
4. Create the types. (TypeBuilder.CreateType)<br>
<br>
5. Save the assembly. (AssemblyBuilder.Save)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Emitting Dynamic Methods and Assemblies<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/8ffc3x75.aspx">http://msdn.microsoft.com/en-us/library/8ffc3x75.aspx</a><br>
<br>
System.Reflection.Emit Namespace<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.reflection.emit.aspx">http://msdn.microsoft.com/en-us/library/system.reflection.emit.aspx</a><br>
<br>
Dynamic Assemblies using Reflection.Emit. Part II of II - Reflection.Emit<br>
By Piyush S Bhatnagar<br>
<a target="_blank" href="http://www.codeproject.com/KB/cs/DynamicCodeGeneration2.aspx">http://www.codeproject.com/KB/cs/DynamicCodeGeneration2.aspx</a><br>
<br>
ReflectionEmitLanguage <br>
<a target="_blank" href="http://www.codeplex.com/reflectoraddins/Wiki/View.aspx?title=ReflectionEmitLanguage&referringTitle=Home">http://www.codeplex.com/reflectoraddins/Wiki/View.aspx?title=ReflectionEmitLanguage&referringTitle=Home</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
