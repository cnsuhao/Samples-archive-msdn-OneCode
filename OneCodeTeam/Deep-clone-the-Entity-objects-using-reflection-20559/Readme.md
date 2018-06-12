# Deep clone the Entity objects using reflection [VB.NET-Visual Studio 2012]
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ADO.NET
## Topics
* Reflection
* Serialization
* Entity Object Clone
## IsPublished
* True
## ModifiedDate
* 2013-01-25 03:11:29
## Description

<p class="MsoNormalCxSpFirst" style="margin-top:24.0pt; line-height:115%"><b><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to deeply clone/duplicate the Entity objects using reflection (<span class="SpellE">VBEFDeepCloneObject</span>)
</span></b></p>
<p class="MsoNormal" style="margin-top:10.0pt; line-height:115%"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Introduction
</span></b></p>
<p class="MsoNormal" style="margin-bottom:3.0pt"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">This sample demonstrates how to deeply clone/duplicate entity objects using serialization and reflection.
</span></p>
<p class="MsoCommentText" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Rather than a shallow copy that shares the same memory block between original object and the copied one, Deep copied objects do not depend on the original
 object's memory block. </span></p>
<p class="MsoNormal" style="margin-top:10.0pt; line-height:115%"><b><span style="">Building the Sample
</b></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">1. Please run the
<span class="SpellE">EFCloneDB.sql</span> script on your Microsoft SQL Server. The
<span class="SpellE">EFCloneDB.sql</span> is used to create four <span class="GramE">
tables :</span> Employee ,<span style="">&nbsp; </span><span class="SpellE">EmpAddress</span>,
<span class="SpellE">BasicSalesInfo</span> and <span class="SpellE">DetailSalesInfo</span>.<span style="">&nbsp;
</span>The relationship between <span class="GramE">Employee <span style="">&nbsp;</span>and</span>
<span style="">&nbsp;</span><span class="SpellE">EmpAddress</span> is 1:1, relationship between Employee and
<span style="">&nbsp;</span><span class="SpellE">BasicSalesInfo</span> is 1:1, relationship between
<span class="SpellE">BasicSalesInfo</span> and <span style="">&nbsp;</span><span class="SpellE">DetailSalesInfo</span> is 1:N.
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">2. Please modify the connection string in the
<span class="SpellE">App.config</span> according to your Microsoft SQL Server instance name.
</span></p>
<p class="MsoNormal" style="margin-top:10.0pt; line-height:115%"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Running the Sample
</span></b></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">1．<span style="font:7.0pt &quot;Times New Roman&quot;">
</span></span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Show the Main Window.
</span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/75164/1/image.png" alt="" width="576" height="547" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2．<span style="font:7.0pt &quot;Times New Roman&quot;">
</span></span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Click Create button, in the new child window, create a new employee object.
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.25in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/75165/1/image.png" alt="" width="502" height="294" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3．<span style="font:7.0pt &quot;Times New Roman&quot;">
</span></span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Click the CreateSalesInfo button, in the launched window, add the employee sales information.
</span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/75166/1/image.png" alt="" width="375" height="235" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">4．<span style="font:7.0pt &quot;Times New Roman&quot;">
</span></span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The employee<span style="">&nbsp;
</span>information before you click the Clone button. </span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/75167/1/image.png" alt="" width="576" height="550" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">5．<span style="font:7.0pt &quot;Times New Roman&quot;">
</span></span></span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Click the Clone button, a new employee object and related information will be displayed.
</span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/75168/1/image.png" alt="" width="631" height="599" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:10.0pt; margin-left:.5in; line-height:115%">
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style="margin-top:10.0pt; line-height:115%"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Using the Code
</span></b></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">1. Create an ADO.NET Entity Data Model
</span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;&nbsp;
</span>1) Name it EmpModel.edmx. </span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;&nbsp;
</span>2) Set the connection string information of the EFCloneDB database. </span>
</p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;&nbsp;
</span>3) Select all the data tables. </span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">2. Create a static class DpCloneHelper used to define some extension methods for the Entity Framework's object<span style="">&nbsp;
</span>EntityObject. </span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;
</span>1) Create an extension method clone </span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">using serialization to implement the deep clone for an object<span style="">&nbsp;
</span>whose the type is EntityObject. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Extension method to Enitity Object. 
''' Deeply clone the Object.
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cloned &lt;/param&gt;
''' &lt;returns&gt;The cloned object&lt;/returns&gt;
&lt;Extension()&gt; _
Public Function Clone(Of T As EntityObject)(ByVal source As T) As T
&nbsp;&nbsp;&nbsp; Dim ser As New DataContractSerializer(GetType(T))
&nbsp;&nbsp;&nbsp; Using stream As MemoryStream = New MemoryStream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ser.WriteObject(stream, source)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream.Seek(0, SeekOrigin.Begin)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DirectCast(ser.ReadObject(stream), T)
&nbsp;&nbsp;&nbsp; End Using
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Extension method to Enitity Object. 
''' Deeply clone the Object.
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cloned &lt;/param&gt;
''' &lt;returns&gt;The cloned object&lt;/returns&gt;
&lt;Extension()&gt; _
Public Function Clone(Of T As EntityObject)(ByVal source As T) As T
&nbsp;&nbsp;&nbsp; Dim ser As New DataContractSerializer(GetType(T))
&nbsp;&nbsp;&nbsp; Using stream As MemoryStream = New MemoryStream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ser.WriteObject(stream, source)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; stream.Seek(0, SeekOrigin.Begin)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DirectCast(ser.ReadObject(stream), T)
&nbsp;&nbsp;&nbsp; End Using
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;</span>2) Create the below methods to clear the Entity Reference on the cloned Entity. The cloned Entity will not be attached to the object until
 the Entity References are cleared. The cloned object should be treated as new data and should create new Primary Keys and associate with Referential Integrity.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
'''&nbsp; The Extension method will be used to clear the entity of object and all related child objects 
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cleared&lt;/param&gt;
''' &lt;param name=&quot;bcheckHierarchy&quot;&gt;This parameter is used to define whether to clear all the child object&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function ClearEntityObject(Of T As Class)(ByVal source As T, ByVal bCheckHierarchy As Boolean) As T
&nbsp;&nbsp;&nbsp; If (source Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New Exception(&quot;Null Object cannot be cloned&quot;)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Dim tObj As Type = source.GetType
&nbsp;&nbsp;&nbsp; If (Not tObj.GetProperty(&quot;EntityKey&quot;) Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tObj.GetProperty(&quot;EntityKey&quot;).SetValue(source, Nothing, Nothing)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; If bCheckHierarchy Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim PropertyList As List(Of PropertyInfo) = Enumerable.ToList(Of PropertyInfo)((From a In source.GetType.GetProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where a.PropertyType.Name.Equals(&quot;ENTITYCOLLECTION`1&quot;, StringComparison.OrdinalIgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select a))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim prop As PropertyInfo
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each prop In PropertyList
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim keys As IEnumerable = DirectCast(tObj.GetProperty(prop.Name).GetValue(source, Nothing), IEnumerable)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim key As Object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each key In keys
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim childProp As EntityReference = Enumerable.SingleOrDefault(Of PropertyInfo)((From a In key.GetType.GetProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where (a.PropertyType.Name.Equals(&quot;EntityReference`1&quot;, StringComparison.OrdinalIgnoreCase))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select a)).GetValue(key, Nothing)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClearEntityObject(childProp, False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClearEntityObject(key, True)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Return source
End Function


''' &lt;summary&gt;
'''&nbsp; Clear the entity of object and all related child objects 
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cleared&lt;/param&gt;
''' &lt;param name=&quot;bcheckHierarchy&quot;&gt;This parameter is used to determine whether to clear all the child object&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;Extension()&gt; _
Public Function ClearEntityReference(ByVal source As EntityObject, ByVal bCheckHierarchy As Boolean) As EntityObject
&nbsp;&nbsp;&nbsp; Return ClearEntityObject(source, bCheckHierarchy)
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
'''&nbsp; The Extension method will be used to clear the entity of object and all related child objects 
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cleared&lt;/param&gt;
''' &lt;param name=&quot;bcheckHierarchy&quot;&gt;This parameter is used to define whether to clear all the child object&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function ClearEntityObject(Of T As Class)(ByVal source As T, ByVal bCheckHierarchy As Boolean) As T
&nbsp;&nbsp;&nbsp; If (source Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New Exception(&quot;Null Object cannot be cloned&quot;)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Dim tObj As Type = source.GetType
&nbsp;&nbsp;&nbsp; If (Not tObj.GetProperty(&quot;EntityKey&quot;) Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tObj.GetProperty(&quot;EntityKey&quot;).SetValue(source, Nothing, Nothing)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; If bCheckHierarchy Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim PropertyList As List(Of PropertyInfo) = Enumerable.ToList(Of PropertyInfo)((From a In source.GetType.GetProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where a.PropertyType.Name.Equals(&quot;ENTITYCOLLECTION`1&quot;, StringComparison.OrdinalIgnoreCase)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select a))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim prop As PropertyInfo
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each prop In PropertyList
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim keys As IEnumerable = DirectCast(tObj.GetProperty(prop.Name).GetValue(source, Nothing), IEnumerable)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim key As Object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each key In keys
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim childProp As EntityReference = Enumerable.SingleOrDefault(Of PropertyInfo)((From a In key.GetType.GetProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where (a.PropertyType.Name.Equals(&quot;EntityReference`1&quot;, StringComparison.OrdinalIgnoreCase))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select a)).GetValue(key, Nothing)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClearEntityObject(childProp, False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClearEntityObject(key, True)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Return source
End Function


''' &lt;summary&gt;
'''&nbsp; Clear the entity of object and all related child objects 
''' &lt;/summary&gt;
''' &lt;param name=&quot;source&quot;&gt;Entity Object need to be cleared&lt;/param&gt;
''' &lt;param name=&quot;bcheckHierarchy&quot;&gt;This parameter is used to determine whether to clear all the child object&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;Extension()&gt; _
Public Function ClearEntityReference(ByVal source As EntityObject, ByVal bCheckHierarchy As Boolean) As EntityObject
&nbsp;&nbsp;&nbsp; Return ClearEntityObject(source, bCheckHierarchy)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style="margin-top:10.0pt; line-height:115%"><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">More Information
</span></b></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">ADO.NET Entity Framework
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://msdn.microsoft.com/en-us/library/bb399572.aspx">http://msdn.microsoft.com/en-us/library/bb399572.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Serialization
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://msdn.microsoft.com/en-us/library/7ay27kt9.aspx">http://msdn.microsoft.com/en-us/library/7ay27kt9.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Reflection
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://msdn.microsoft.com/en-us/library/f7ykdhsy.aspx">http://msdn.microsoft.com/en-us/library/f7ykdhsy.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
</span>