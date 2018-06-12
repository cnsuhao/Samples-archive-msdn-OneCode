# How to deep clone objects using reflection (VBDeepCloneObject)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
* CLR
## Topics
* Reflection
* Object Clone
* Property
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:12:49
## Description

<h1>The Sample Demonstrates How to Deep Clone Objects Using Reflection (VBDeepCloneObject)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to implement deep clone between objects in VB.NET using reflection.
</p>
<p class="MsoNormal">We can use the MemberwiseClone to get a copy, but the MemberwiseClone method creates a shallow copy by creating a new object, and then copying the non-static fields of the current object to the new object. If a field is a value type,
 a<span style="">&nbsp;&nbsp; </span>bit-by-bit copy of the field is performed. If a field is a reference type, the reference is copied but the referred object is not.
</p>
<p class="MsoNormal">In this sample, we make use metadata information to clone a new object and drill down each field, ultimately, copy this field.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to running the sample, the flowing is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71822/1/image.png" alt="" width="643" height="319" align="middle">
</span></p>
<p class="MsoNormal">The shallow clones of the original objects are the new objects and contain the new objects of the value type fields or the string type fields. But the reference fields refer to the same referred object. The deep clones are the new objects,
 and their reference fields also refer to the new referred object.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">A. Implement deep clone using reflection.</p>
<p class="MsoNormal">1. If the type of object is the value type, we will always get a new object when the original object is assigned to another variable. So if the type of the object is the value type, we just return the object.
</p>
<p class="MsoNormal">If the string variables contain the same chars, they always refer to the same string in the heap. So if the type of the object is string, we also return the object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If type.IsValueType OrElse type Is GetType(String) Then
&nbsp;&nbsp;&nbsp; Return obj

</pre>
<pre id="codePreview" class="vb">
If type.IsValueType OrElse type Is GetType(String) Then
&nbsp;&nbsp;&nbsp; Return obj

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. If the type of the object is the Array, we use the CreateInstance method to get a new instance of the array. We also process recursively this method in the elements of the original array because the type of the element may be the reference type.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ElseIf type.IsArray Then
&nbsp;&nbsp;&nbsp; Dim typeElement As System.Type = type.GetType(type.FullName.Replace(&quot;[]&quot;, String.Empty))
&nbsp;&nbsp;&nbsp; Dim array = TryCast(obj, System.Array)
&nbsp;&nbsp;&nbsp; Dim copiedArray As System.Array = System.Array.CreateInstance(typeElement, array.Length)
&nbsp;&nbsp;&nbsp; For i As Integer = 0 To array.Length - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the deep clone of the element in the original array and assign the 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' clone to the new array.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; copiedArray.SetValue(CloneProcedure(array.GetValue(i)), i)


&nbsp;&nbsp;&nbsp; Next i
&nbsp;&nbsp;&nbsp; Return copiedArray

</pre>
<pre id="codePreview" class="vb">
ElseIf type.IsArray Then
&nbsp;&nbsp;&nbsp; Dim typeElement As System.Type = type.GetType(type.FullName.Replace(&quot;[]&quot;, String.Empty))
&nbsp;&nbsp;&nbsp; Dim array = TryCast(obj, System.Array)
&nbsp;&nbsp;&nbsp; Dim copiedArray As System.Array = System.Array.CreateInstance(typeElement, array.Length)
&nbsp;&nbsp;&nbsp; For i As Integer = 0 To array.Length - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the deep clone of the element in the original array and assign the 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' clone to the new array.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; copiedArray.SetValue(CloneProcedure(array.GetValue(i)), i)


&nbsp;&nbsp;&nbsp; Next i
&nbsp;&nbsp;&nbsp; Return copiedArray

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. If the type of the object is class, it may contain the reference fields, so we use reflection and process recursively this method in the fields of the object to get the deep clone of the object.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ElseIf type.IsClass Then
&nbsp;&nbsp;&nbsp; Dim copiedObject As Object = Activator.CreateInstance(obj.GetType())
&nbsp;&nbsp;&nbsp; ' Get all FieldInfo.
&nbsp;&nbsp;&nbsp; Dim fields() As FieldInfo = type.GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
&nbsp;&nbsp;&nbsp; For Each field As FieldInfo In fields
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fieldValue As Object = field.GetValue(obj)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If fieldValue IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the deep clone of the field in the original object and assign the 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' clone to the field in the new object.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; field.SetValue(copiedObject, CloneProcedure(fieldValue))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Next field
&nbsp;&nbsp;&nbsp; Return copiedObject

</pre>
<pre id="codePreview" class="vb">
ElseIf type.IsClass Then
&nbsp;&nbsp;&nbsp; Dim copiedObject As Object = Activator.CreateInstance(obj.GetType())
&nbsp;&nbsp;&nbsp; ' Get all FieldInfo.
&nbsp;&nbsp;&nbsp; Dim fields() As FieldInfo = type.GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance)
&nbsp;&nbsp;&nbsp; For Each field As FieldInfo In fields
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fieldValue As Object = field.GetValue(obj)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If fieldValue IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the deep clone of the field in the original object and assign the 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' clone to the field in the new object.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; field.SetValue(copiedObject, CloneProcedure(fieldValue))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Next field
&nbsp;&nbsp;&nbsp; Return copiedObject

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
B. Demonstrate the different clones of the Employee class.<span style="font-size:9.5pt; font-family:Consolas; color:green">
</span></p>
<p class="MsoNormal">Demonstrate the difference between the shallow clone and the deep clone of the Employee class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Sub CloneEmployee()
&nbsp;&nbsp;&nbsp; Dim address As Address = New Address With {.City = &quot;ShangHai&quot;}
&nbsp;&nbsp;&nbsp; Dim originalEmployee As Employee = New Employee With {.Id = 101, .Name = &quot;Gail Erickson&quot;, .Address = address}


&nbsp;&nbsp;&nbsp; ' Get a shallow copy of the originalEmployee and set the new values in the copy.
&nbsp;&nbsp;&nbsp; Dim shallowCloneEmployee As Employee = originalEmployee.ShallowCopy()
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Id = 102
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Name = &quot;Dylan Miller&quot;
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Address.City = &quot;RedMond&quot; ' Change the shallow copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalEmployee and the shallow copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the shallow clone of the Employee class.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalEmployee.Id, originalEmployee.Name, originalEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, shallowCloneEmployee.Id, shallowCloneEmployee.Name, shallowCloneEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()


&nbsp;&nbsp;&nbsp; ' Get a deep copy of the originalEmployee and set the new values in the copy.
&nbsp;&nbsp;&nbsp; address.City = &quot;ShangHai&quot;
&nbsp;&nbsp;&nbsp; Dim deepCloneEmployee As Employee = DeepCloneHelper.DeepClone(originalEmployee)
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Id = 102
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Name = &quot;Dylan Miller&quot;
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Address.City = &quot;RedMond&quot; ' Change the deep copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalEmployee and the deep copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the deep clone of the Employee class.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalEmployee.Id, originalEmployee.Name, originalEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, deepCloneEmployee.Id, deepCloneEmployee.Name, deepCloneEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
<pre id="codePreview" class="vb">
Public Shared Sub CloneEmployee()
&nbsp;&nbsp;&nbsp; Dim address As Address = New Address With {.City = &quot;ShangHai&quot;}
&nbsp;&nbsp;&nbsp; Dim originalEmployee As Employee = New Employee With {.Id = 101, .Name = &quot;Gail Erickson&quot;, .Address = address}


&nbsp;&nbsp;&nbsp; ' Get a shallow copy of the originalEmployee and set the new values in the copy.
&nbsp;&nbsp;&nbsp; Dim shallowCloneEmployee As Employee = originalEmployee.ShallowCopy()
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Id = 102
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Name = &quot;Dylan Miller&quot;
&nbsp;&nbsp;&nbsp; shallowCloneEmployee.Address.City = &quot;RedMond&quot; ' Change the shallow copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalEmployee and the shallow copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the shallow clone of the Employee class.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalEmployee.Id, originalEmployee.Name, originalEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, shallowCloneEmployee.Id, shallowCloneEmployee.Name, shallowCloneEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()


&nbsp;&nbsp;&nbsp; ' Get a deep copy of the originalEmployee and set the new values in the copy.
&nbsp;&nbsp;&nbsp; address.City = &quot;ShangHai&quot;
&nbsp;&nbsp;&nbsp; Dim deepCloneEmployee As Employee = DeepCloneHelper.DeepClone(originalEmployee)
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Id = 102
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Name = &quot;Dylan Miller&quot;
&nbsp;&nbsp;&nbsp; deepCloneEmployee.Address.City = &quot;RedMond&quot; ' Change the deep copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalEmployee and the deep copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the deep clone of the Employee class.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalEmployee.Id, originalEmployee.Name, originalEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, deepCloneEmployee.Id, deepCloneEmployee.Name, deepCloneEmployee.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
C. Demonstrate the different clones of the Customer struct.</p>
<p class="MsoNormal">Demonstrate the difference between the shallow clone and the deep clone of the Customer struct.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Sub CloneCustomer()
&nbsp;&nbsp;&nbsp; Dim address As Address = New Address With {.City = &quot;Los Angeles&quot;}
&nbsp;&nbsp;&nbsp; Dim originalCustomer As Customer = New Customer With {.Id = 201, .Name = &quot;Kevin Brown&quot;, .Address = address}


&nbsp;&nbsp;&nbsp; ' Get a shallow copy of the originalCustomer and set the new values in the copy.
&nbsp;&nbsp;&nbsp; Dim shallowCloneCustomer As Customer = originalCustomer
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Id = 202
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Name = &quot;John Wood&quot;
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Address.City = &quot;Boston&quot; ' Change the shallow copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalCustomer and the shallow copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the shallow clone of the Customer struct.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalCustomer.Id, originalCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, shallowCloneCustomer.Id, shallowCloneCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()


&nbsp;&nbsp;&nbsp; ' Get a deep copy of the originalCustomer and set the new values in the copy.
&nbsp;&nbsp;&nbsp; address.City = &quot;Los Angeles&quot;
&nbsp;&nbsp;&nbsp; Dim deepCloneCustomer As Customer = originalCustomer.DeepCopy()
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Id = 202
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Name = &quot;John Wood&quot;
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Address.City = &quot;Boston&quot; ' Change the deep copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalCustomer and the deep copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the deep clone of the Customer struct.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalCustomer.Id, originalCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, deepCloneCustomer.Id, deepCloneCustomer.Name, deepCloneCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
<pre id="codePreview" class="vb">
Public Shared Sub CloneCustomer()
&nbsp;&nbsp;&nbsp; Dim address As Address = New Address With {.City = &quot;Los Angeles&quot;}
&nbsp;&nbsp;&nbsp; Dim originalCustomer As Customer = New Customer With {.Id = 201, .Name = &quot;Kevin Brown&quot;, .Address = address}


&nbsp;&nbsp;&nbsp; ' Get a shallow copy of the originalCustomer and set the new values in the copy.
&nbsp;&nbsp;&nbsp; Dim shallowCloneCustomer As Customer = originalCustomer
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Id = 202
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Name = &quot;John Wood&quot;
&nbsp;&nbsp;&nbsp; shallowCloneCustomer.Address.City = &quot;Boston&quot; ' Change the shallow copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalCustomer and the shallow copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the shallow clone of the Customer struct.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalCustomer.Id, originalCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, shallowCloneCustomer.Id, shallowCloneCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()


&nbsp;&nbsp;&nbsp; ' Get a deep copy of the originalCustomer and set the new values in the copy.
&nbsp;&nbsp;&nbsp; address.City = &quot;Los Angeles&quot;
&nbsp;&nbsp;&nbsp; Dim deepCloneCustomer As Customer = originalCustomer.DeepCopy()
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Id = 202
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Name = &quot;John Wood&quot;
&nbsp;&nbsp;&nbsp; deepCloneCustomer.Address.City = &quot;Boston&quot; ' Change the deep copy's address information.


&nbsp;&nbsp;&nbsp; ' Show the information of originalCustomer and the deep copy.
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It is the deep clone of the Customer struct.&quot;)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, originalCustomer.Id, originalCustomer.Name, originalCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-5} {1,-25} {2}&quot;, deepCloneCustomer.Id, deepCloneCustomer.Name, deepCloneCustomer.Address.City)
&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.OBJECT.MEMBERWISECLONE);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">MemberwiseClone Method</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.TYPE);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">Type Class</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.REFLECTION.FIELDINFO);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">FieldInfo Class</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
