# How to import/export the XML files using Code First in EF (VBEFStoreXmlFiles)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ADO.NET
## Topics
* XML
* Code First
* ColumnAttribute
## IsPublished
* True
## ModifiedDate
* 2012-12-20 07:31:20
## Description

<h1>Import/Export the XML into/from database using Code First in EF(VBEFStoreXmlFiles)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to import/export the XML into/from database using Code First in EF.</p>
<p class="MsoNormal">We implement two ways in the sample:</p>
<p class="MsoNormal">1. Using LinqToXml to import/export the XML files;</p>
<p class="MsoNormal">2. Using the XmlColumn to store the Xml files.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following step:</p>
<p class="MsoNormal">Step1. Modify the connection string in the App.config file according to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73130/1/image.png" alt="" width="633" height="324" align="middle">
</span></p>
<p class="MsoNormal">In this sample, we use LinqToXml to import information in the Xml file(Courses-2012.xml) into the database, and then export the Xml document to the CoursesByLinqToXml.xml file.</p>
<p class="MsoNormal">We can also use the Xml column to store the Xml document, so we will store the entire Xml file(Courses-2012.xml)<span style="">&nbsp;
</span>in the database. And then we get the file from the database and save it into the CoursesFromXmlColumn-2012.xml.</p>
<p class="MsoNormal">You can find the three Xml files in the directory of the application:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73131/1/image.png" alt="" width="620" height="88" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Import/Export the Xml file using LinqToXml</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
a. Import information in the xml file into the database</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim courses As IEnumerable(Of Course) =
&nbsp;&nbsp;&nbsp; From c In document.Descendants(&quot;Course&quot;)
Select New Course With
{
&nbsp;&nbsp;&nbsp; .CourseID = If(c.Element(&quot;CourseId&quot;) Is Nothing, Guid.NewGuid().ToString(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.Element(&quot;CourseId&quot;).Value),
&nbsp;&nbsp;&nbsp; .Title = If(c.Element(&quot;Title&quot;) Is Nothing, Nothing, c.Element(&quot;Title&quot;).Value),
&nbsp;&nbsp;&nbsp; .Credits = If(c.Element(&quot;Credits&quot;) Is Nothing, -1, Int32.Parse(c.Element(&quot;Credits&quot;).Value)),
&nbsp;&nbsp;&nbsp; .Department = If(c.Element(&quot;Department&quot;) Is Nothing, Nothing, c.Element(&quot;Department&quot;).Value)
}

</pre>
<pre id="codePreview" class="vb">
Dim courses As IEnumerable(Of Course) =
&nbsp;&nbsp;&nbsp; From c In document.Descendants(&quot;Course&quot;)
Select New Course With
{
&nbsp;&nbsp;&nbsp; .CourseID = If(c.Element(&quot;CourseId&quot;) Is Nothing, Guid.NewGuid().ToString(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.Element(&quot;CourseId&quot;).Value),
&nbsp;&nbsp;&nbsp; .Title = If(c.Element(&quot;Title&quot;) Is Nothing, Nothing, c.Element(&quot;Title&quot;).Value),
&nbsp;&nbsp;&nbsp; .Credits = If(c.Element(&quot;Credits&quot;) Is Nothing, -1, Int32.Parse(c.Element(&quot;Credits&quot;).Value)),
&nbsp;&nbsp;&nbsp; .Department = If(c.Element(&quot;Department&quot;) Is Nothing, Nothing, c.Element(&quot;Department&quot;).Value)
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
b. Export the information into a Xml file from the database </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim ns As XNamespace = &quot;http://VBEFStoreXmlFiles&quot;
Dim coursesXml As New XElement(ns &#43; &quot;Courses&quot;,
&nbsp;&nbsp;&nbsp; From c In school.Courses.Take(5).AsEnumerable()
&nbsp;&nbsp;&nbsp; Select New XElement(ns &#43; &quot;Course&quot;,
&nbsp;&nbsp;&nbsp; If(c.CourseID Is Nothing, Nothing, New XElement(ns &#43; &quot;CourseID&quot;, c.CourseID)),
&nbsp;&nbsp;&nbsp; If(c.Title Is Nothing, Nothing, New XElement(ns &#43; &quot;Title&quot;, c.Title)),
&nbsp;&nbsp;&nbsp; If(c.Credits Is Nothing, Nothing, New XElement(ns &#43; &quot;Credits&quot;, c.Credits)),
&nbsp;&nbsp;&nbsp; If(c.Department Is Nothing, Nothing, New XElement(ns &#43; &quot;Department&quot;, c.Department))))

</pre>
<pre id="codePreview" class="vb">
Dim ns As XNamespace = &quot;http://VBEFStoreXmlFiles&quot;
Dim coursesXml As New XElement(ns &#43; &quot;Courses&quot;,
&nbsp;&nbsp;&nbsp; From c In school.Courses.Take(5).AsEnumerable()
&nbsp;&nbsp;&nbsp; Select New XElement(ns &#43; &quot;Course&quot;,
&nbsp;&nbsp;&nbsp; If(c.CourseID Is Nothing, Nothing, New XElement(ns &#43; &quot;CourseID&quot;, c.CourseID)),
&nbsp;&nbsp;&nbsp; If(c.Title Is Nothing, Nothing, New XElement(ns &#43; &quot;Title&quot;, c.Title)),
&nbsp;&nbsp;&nbsp; If(c.Credits Is Nothing, Nothing, New XElement(ns &#43; &quot;Credits&quot;, c.Credits)),
&nbsp;&nbsp;&nbsp; If(c.Department Is Nothing, Nothing, New XElement(ns &#43; &quot;Department&quot;, c.Department))))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Using XmlColumn to store the Xml file</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>a. The XmlColumn type in the SqlServer will be mapped as the String type in the EntityFramework. And EntityFramework can't map the XDcoument type into the SqlServer type, so we use the XmlValues property to map the XmlColumn in the
 SqlServer and use the Courses property to access the Xml document.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Because EntityFramework doesn't support map the XDocument type, so we set NotMapped on the Courses property.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class YearCourse
&nbsp;&nbsp;&nbsp; Public Property YearCourseId() As Int32
&nbsp;&nbsp;&nbsp; Public Property Year() As Int32


&nbsp;&nbsp;&nbsp; &lt;Column(TypeName:=&quot;xml&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property XmlValues() As String


&nbsp;&nbsp;&nbsp; &lt;NotMapped()&gt;
&nbsp;&nbsp;&nbsp; Public Property Courses() As XDocument
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return XDocument.Parse(XmlValues)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(ByVal value As XDocument)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; XmlValues = value.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class YearCourse
&nbsp;&nbsp;&nbsp; Public Property YearCourseId() As Int32
&nbsp;&nbsp;&nbsp; Public Property Year() As Int32


&nbsp;&nbsp;&nbsp; &lt;Column(TypeName:=&quot;xml&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property XmlValues() As String


&nbsp;&nbsp;&nbsp; &lt;NotMapped()&gt;
&nbsp;&nbsp;&nbsp; Public Property Courses() As XDocument
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return XDocument.Parse(XmlValues)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(ByVal value As XDocument)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; XmlValues = value.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal">b.<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span>When we get the Xml document form the Xml column in the database, we can use LinqToXml to get the information of the course.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim courseList As IEnumerable(Of Course) =
From c In courses.Courses.Descendants(&quot;Course&quot;)
Select New Course With
{
.CourseID = If(c.Element(&quot;CourseId&quot;) Is Nothing, Guid.NewGuid().ToString(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.Element(&quot;CourseId&quot;).Value),
.Title = If(c.Element(&quot;Title&quot;) Is Nothing, Nothing, c.Element(&quot;Title&quot;).Value),
.Credits = If(c.Element(&quot;Credits&quot;) Is Nothing, -1, Int32.Parse(c.Element(&quot;Credits&quot;).Value)),
.Department = If(c.Element(&quot;Department&quot;) Is Nothing, Nothing, c.Element(&quot;Department&quot;).Value)
}

</pre>
<pre id="codePreview" class="vb">
Dim courseList As IEnumerable(Of Course) =
From c In courses.Courses.Descendants(&quot;Course&quot;)
Select New Course With
{
.CourseID = If(c.Element(&quot;CourseId&quot;) Is Nothing, Guid.NewGuid().ToString(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.Element(&quot;CourseId&quot;).Value),
.Title = If(c.Element(&quot;Title&quot;) Is Nothing, Nothing, c.Element(&quot;Title&quot;).Value),
.Credits = If(c.Element(&quot;Credits&quot;) Is Nothing, -1, Int32.Parse(c.Element(&quot;Credits&quot;).Value)),
.Department = If(c.Element(&quot;Department&quot;) Is Nothing, Nothing, c.Element(&quot;Department&quot;).Value)
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/bb387098.aspx">LINQ to XML</a>
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.columnattribute%28v=VS.103%29.aspx">ColumnAttribute Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
