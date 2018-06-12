# How to use the custom type in DataTable (VBDataTableCustomType)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ADO.NET
## Topics
* XML Serialization
* Compare
* custom type
## IsPublished
* True
## ModifiedDate
* 2012-12-26 06:47:39
## Description

<h1>How to Use the Custom Type in DataTable(VBDataTableCustomType)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to use the custom type in DataTable:</p>
<p class="MsoNormal">1. Set the custom type as the datatable primary column type;</p>
<p class="MsoNormal">2. Sort the datatable by the custom type;</p>
<p class="MsoNormal">3. Write the datatable into the Xml file;</p>
<p class="MsoNormal">4. Read the Xml file into the datatable.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73573/1/image.png" alt="" width="503" height="233" align="middle">
</span></p>
<p class="MsoNormal">Because we use the custom type in DataTable, we must store the schema when we write DataTable into Xml file. And then before we load the Xml file into DataTable, we should load the schema file into DataTable. So we can find one schema
 file and one Xml file in the application's directory.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73574/1/image.png" alt="" width="617" height="66" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Set the custom type as the datatable primary column type</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim columns() As DataColumn =
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Course&quot;, GetType(Course)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Classroom&quot;, GetType(String)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Year&quot;, GetType(Int32))
&nbsp;&nbsp;&nbsp; }
table.Columns.AddRange(columns)


' Set the custom type column as the primary key.
table.PrimaryKey = New DataColumn(0) {table.Columns(0)}

</pre>
<pre id="codePreview" class="vb">
Dim columns() As DataColumn =
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Course&quot;, GetType(Course)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Classroom&quot;, GetType(String)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New DataColumn(&quot;Year&quot;, GetType(Int32))
&nbsp;&nbsp;&nbsp; }
table.Columns.AddRange(columns)


' Set the custom type column as the primary key.
table.PrimaryKey = New DataColumn(0) {table.Columns(0)}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;&nbsp; </span>When we set a column as the primary key in DataTable, the DataTable need to make sure that every value in the primary key column is unique. So DataTable will use CompareTo(object) method to compare the values.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp; </span>And when we sort the DataTable by this type, DataTable will also use this method.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp; </span>So we implement the IComparable interface in the custom type.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function CompareTo(ByVal other As Course) As Integer Implements IComparable(Of Course).CompareTo
&nbsp;&nbsp;&nbsp; If other Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return 1
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Me.CourseId.CompareTo(other.CourseId)
&nbsp;&nbsp;&nbsp; End If
End Function


Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
&nbsp;&nbsp;&nbsp; If obj Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return 1
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim other As Course = TryCast(obj, Course)
 &nbsp;&nbsp;&nbsp;If other IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Me.CompareTo(other)
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New ArgumentException(&quot;Object is not a Course&quot;)
&nbsp;&nbsp;&nbsp; End If
End Function

</pre>
<pre id="codePreview" class="vb">
Public Function CompareTo(ByVal other As Course) As Integer Implements IComparable(Of Course).CompareTo
&nbsp;&nbsp;&nbsp; If other Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return 1
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Me.CourseId.CompareTo(other.CourseId)
&nbsp;&nbsp;&nbsp; End If
End Function


Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
&nbsp;&nbsp;&nbsp; If obj Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return 1
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim other As Course = TryCast(obj, Course)
 &nbsp;&nbsp;&nbsp;If other IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Me.CompareTo(other)
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New ArgumentException(&quot;Object is not a Course&quot;)
&nbsp;&nbsp;&nbsp; End If
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Sort the datatable by the custom type</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Shared Sub SortByCourse(ByVal table As DataTable)
&nbsp;&nbsp;&nbsp; ' Use the Select method to sort the DataTable.
&nbsp;&nbsp;&nbsp; Dim resultRows() As DataRow = table.Select(&quot;&quot;, &quot;Course DESC&quot;)


&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of sorting&quot;)
&nbsp;&nbsp;&nbsp; For Each row As DataRow In resultRows
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Console.WriteLine(row(0))
&nbsp;&nbsp;&nbsp; Next row


&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Shared Sub SortByCourse(ByVal table As DataTable)
&nbsp;&nbsp;&nbsp; ' Use the Select method to sort the DataTable.
&nbsp;&nbsp;&nbsp; Dim resultRows() As DataRow = table.Select(&quot;&quot;, &quot;Course DESC&quot;)


&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of sorting&quot;)
&nbsp;&nbsp;&nbsp; For Each row As DataRow In resultRows
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Console.WriteLine(row(0))
&nbsp;&nbsp;&nbsp; Next row


&nbsp;&nbsp;&nbsp; Console.WriteLine()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Write the datatable into the Xml file</p>
<p class="MsoNormal">Because we use the custom type in DataTable, we must store the schema when we write DataTable into Xml file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
table.WriteXmlSchema(xmlSchema)
table.WriteXml(xmlFile)

</pre>
<pre id="codePreview" class="vb">
table.WriteXmlSchema(xmlSchema)
table.WriteXml(xmlFile)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Read the Xml file into the datatable.</p>
<p class="MsoNormal">Before we load the Xml file into DataTable, we should load the schema file into DataTable.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
newTable.ReadXmlSchema(xmlSchema)
newTable.ReadXml(xmlFile)

</pre>
<pre id="codePreview" class="vb">
newTable.ReadXmlSchema(xmlSchema)
newTable.ReadXml(xmlFile)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
5. Implement IXmlSerializable interface</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
It may be a little harder than SerializableAttribute, but we can get more control.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
&nbsp;&nbsp;&nbsp; ' Because there may be many types of node, we first get the Course node.
&nbsp;&nbsp;&nbsp; reader.ReadStartElement(&quot;Course&quot;)


&nbsp;&nbsp;&nbsp; CourseId = reader.ReadElementString(&quot;CourseId&quot;)
&nbsp;&nbsp;&nbsp; Title = reader.ReadElementString(&quot;Title&quot;)


&nbsp;&nbsp;&nbsp; Dim CreditsString As String = reader.ReadElementString(&quot;Credits&quot;)
&nbsp;&nbsp;&nbsp; Dim credit As Integer = 0
&nbsp;&nbsp;&nbsp; If Int32.TryParse(CreditsString, credit) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credits = credit
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credits = -1
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; reader.ReadEndElement()
End Sub


Public Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;CourseId&quot;, CourseId)
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;Title&quot;, Title)
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;Credits&quot;, Credits.ToString())
End Sub

</pre>
<pre id="codePreview" class="vb">
Public Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
&nbsp;&nbsp;&nbsp; ' Because there may be many types of node, we first get the Course node.
&nbsp;&nbsp;&nbsp; reader.ReadStartElement(&quot;Course&quot;)


&nbsp;&nbsp;&nbsp; CourseId = reader.ReadElementString(&quot;CourseId&quot;)
&nbsp;&nbsp;&nbsp; Title = reader.ReadElementString(&quot;Title&quot;)


&nbsp;&nbsp;&nbsp; Dim CreditsString As String = reader.ReadElementString(&quot;Credits&quot;)
&nbsp;&nbsp;&nbsp; Dim credit As Integer = 0
&nbsp;&nbsp;&nbsp; If Int32.TryParse(CreditsString, credit) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credits = credit
&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Credits = -1
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; reader.ReadEndElement()
End Sub


Public Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;CourseId&quot;, CourseId)
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;Title&quot;, Title)
&nbsp;&nbsp;&nbsp; writer.WriteElementString(&quot;Credits&quot;, Credits.ToString())
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.icomparable.compareto(v=vs.100).aspx"><span class="SpellE">CompareTo</span> Method
</a></span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/fhd7bk0a(v=vs.100).aspx"><span class="SpellE">IXmlSerializable</span> Interface
</a></span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/53y1t605(v=vs.100).aspx"><span class="SpellE">DataTable.WriteXmlSchema</span> Method</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
