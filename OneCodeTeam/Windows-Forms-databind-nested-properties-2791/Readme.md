# Windows Forms databind nested properties (VBWinFormBindingNestedProperties)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2011-04-05 07:27:50
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : VBWinFormBindToNestedProp Project Overview<br>
<br>
BindToNestedProperty Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to bind a DataGridView column to a nested property <br>
in the data source.<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
<br>
1. Derive a class from the PropertyDescriptor class to create a <br>
&nbsp; PropertyDescriptor for a sub-property.<br>
<br>
2. Derive a class from the CustomTypeDescriptor class to add extra <br>
&nbsp; PropertyDescriptor to the original PropertyDescriptorCollection of the <br>
&nbsp; type, using the derived PropertyDescriptor class.<br>
<br>
3. Derive a class from the TypeDescriptionProvider class to use the derived <br>
&nbsp; CustomTypeDescriptor class.<br>
<br>
4. Add a TypeDescriptionProviderAttribute on the type that contains complex <br>
&nbsp; type properties.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ICustomTypeDescriptor, Part 2<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc163804.aspx">http://msdn.microsoft.com/en-us/magazine/cc163804.aspx</a><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
