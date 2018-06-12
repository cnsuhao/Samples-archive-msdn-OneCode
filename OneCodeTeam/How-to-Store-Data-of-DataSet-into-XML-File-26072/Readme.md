# How to Store Data of DataSet into XML File
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* XML
* DataSet
* XML Schema
## IsPublished
* True
## ModifiedDate
* 2013-11-25 11:30:46
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to Store Data of DataSet into XML File (CSDataSetToXML)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In this sample, we will demonstrate how to write data into XML file from DataSet and read data into DataSet from XML.
</p>
<p class="MsoNormal">1. We will create one dataset with two tables. </p>
<p class="MsoNormal">2. We will use two ways to export dataset into the XML files:WriteXml method and GetXml method.
</p>
<p class="MsoNormal">3. We will use two ways to import dataset from the XML files:ReadXml method and InferXmlSchema method.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal">First, we create one dataset that contains two tables.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102817/1/image.png" alt="" width="639" height="271" align="middle">
</span></p>
<p class="MsoNormal">Second, we use two ways to export the dataset into XML files.</p>
<p class="MsoNormal">a. Use WriteXml method to export the dataset.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102818/1/image.png" alt="" width="643" height="23" align="middle">
</span></p>
<p class="MsoNormal">b. Use GetXml method to export the dataset.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102819/1/image.png" alt="" width="640" height="24" align="middle">
</span></p>
<p class="MsoNormal">Third, we import the dataset from the XML files.</p>
<p class="MsoNormal">a. Use ReadXml to import the dataset.</p>
<p class="MsoNormal">We use ReadXml method to read the XML file that WriteXml method created early. Because we also read the schema from the XML file, we can find that the schema is as same as the schema of the original dataset.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102820/1/image.png" alt="" width="641" height="89" align="middle">
</span></p>
<p class="MsoNormal">b. Use InferXmlSchema method to infer the schemas.</p>
<p class="MsoNormal">We display four types of XML structures.</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Elements that only have attributes</p>
<p class="MsoListParagraphCxSpLast">Following is the Xml document:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
&nbsp; &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot; /&gt;
&nbsp; &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot; /&gt;
&lt;/MySchool&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
&nbsp; &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot; /&gt;
&nbsp; &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot; /&gt;
&lt;/MySchool&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">Following is the result of inferring from the above Xml document:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102821/1/image.png" alt="" width="640" height="74" align="middle">
</span></p>
<p class="MsoListParagraphCxSpFirst">Now we can find that the name of root element becomes the name of dataset, the names of elements become the name of table and the names of attributes become the name of columns.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Elements that have attributes and the element text</p>
<p class="MsoListParagraphCxSpLast">Following is the Xml document:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
&nbsp; &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot;&gt;New&lt;/Course&gt;
&nbsp; &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot;&gt;Cancelled&lt;/Department&gt;
&lt;/MySchool&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
&nbsp; &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot;&gt;New&lt;/Course&gt;
&nbsp; &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;&nbsp; Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
&nbsp; &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot;&gt;Cancelled&lt;/Department&gt;
&lt;/MySchool&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">Following is the result of inferring from the above Xml document:
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102822/1/image.png" alt="" width="637" height="88" align="middle">
</span></p>
<p class="MsoListParagraphCxSpFirst">The only difference between type 1 and 2 is that type 2 have the element text in Xml document. So we can find the only difference of the results is that the new columns, &quot;Course_Text&quot;, &quot;Department_Text&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Repeating Elements</p>
<p class="MsoListParagraphCxSpLast">Following is the Xml document: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
&nbsp; &lt;Course&gt;C1045&lt;/Course&gt;
&nbsp; &lt;Course&gt;C1061&lt;/Course&gt;
&nbsp; &lt;Department&gt;Engineering&lt;/Department&gt; 
&nbsp;&nbsp;&lt;Department&gt;Mathematics&lt;/Department&gt;
&lt;/MySchool&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
&nbsp; &lt;Course&gt;C1045&lt;/Course&gt;
&nbsp; &lt;Course&gt;C1061&lt;/Course&gt;
&nbsp; &lt;Department&gt;Engineering&lt;/Department&gt; 
&nbsp;&nbsp;&lt;Department&gt;Mathematics&lt;/Department&gt;
&lt;/MySchool&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">Following is the result of inferring from the above Xml document:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102823/1/image.png" alt="" width="637" height="81" align="middle">
</span></p>
<p class="MsoListParagraphCxSpFirst">We can find that the repeat elements result in a single inferred table.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Elements With Child Elements</p>
<p class="MsoListParagraphCxSpLast">Following is the Xml document: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
&nbsp; &lt;Course&gt;
&nbsp;&nbsp;&nbsp; &lt;CourseID&gt;C1045&lt;/CourseID&gt;
&nbsp;&nbsp;&nbsp; &lt;Year&gt;2012&lt;/Year&gt;
&nbsp;&nbsp;&nbsp; &lt;Title&gt;Calculus&lt;/Title&gt;
&nbsp;&nbsp;&nbsp; &lt;Credits&gt;4&lt;/Credits&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;7&lt;/DepartmentID&gt;
&nbsp; &lt;/Course&gt;
&nbsp; &lt;Course&gt;
&nbsp;&nbsp;&nbsp; &lt;CourseID&gt;C1061&lt;/CourseID&gt;
&nbsp;&nbsp;&nbsp; &lt;Year&gt;2012&lt;/Year&gt;
&nbsp;&nbsp;&nbsp; &lt;Title&gt;Physics&lt;/Title&gt;
&nbsp;&nbsp;&nbsp; &lt;Credits&gt;4&lt;/Credits&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
&nbsp; &lt;/Course&gt;
&nbsp; .................................
&nbsp; &lt;Department&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
&nbsp;&nbsp;&nbsp; &lt;Name&gt;Engineering&lt;/Name&gt;
&nbsp;&nbsp;&nbsp; &lt;Budget&gt;350000&lt;/Budget&gt;
&nbsp;&nbsp;&nbsp; &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
&nbsp;&nbsp;&nbsp; &lt;Administrator&gt;2&lt;/Administrator&gt;
&nbsp; &lt;/Department&gt;
&nbsp; &lt;Department&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;2&lt;/DepartmentID&gt;
&nbsp;&nbsp;&nbsp; &lt;Name&gt;English&lt;/Name&gt;
&nbsp;&nbsp;&nbsp; &lt;Budget&gt;120000&lt;/Budget&gt;
&nbsp;&nbsp;&nbsp; &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
&nbsp;&nbsp;&nbsp; &lt;Administrator&gt;6&lt;/Administrator&gt;
&nbsp; &lt;/Department&gt;
&nbsp; .................................
&lt;/MySchool&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
&nbsp; &lt;Course&gt;
&nbsp;&nbsp;&nbsp; &lt;CourseID&gt;C1045&lt;/CourseID&gt;
&nbsp;&nbsp;&nbsp; &lt;Year&gt;2012&lt;/Year&gt;
&nbsp;&nbsp;&nbsp; &lt;Title&gt;Calculus&lt;/Title&gt;
&nbsp;&nbsp;&nbsp; &lt;Credits&gt;4&lt;/Credits&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;7&lt;/DepartmentID&gt;
&nbsp; &lt;/Course&gt;
&nbsp; &lt;Course&gt;
&nbsp;&nbsp;&nbsp; &lt;CourseID&gt;C1061&lt;/CourseID&gt;
&nbsp;&nbsp;&nbsp; &lt;Year&gt;2012&lt;/Year&gt;
&nbsp;&nbsp;&nbsp; &lt;Title&gt;Physics&lt;/Title&gt;
&nbsp;&nbsp;&nbsp; &lt;Credits&gt;4&lt;/Credits&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
&nbsp; &lt;/Course&gt;
&nbsp; .................................
&nbsp; &lt;Department&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
&nbsp;&nbsp;&nbsp; &lt;Name&gt;Engineering&lt;/Name&gt;
&nbsp;&nbsp;&nbsp; &lt;Budget&gt;350000&lt;/Budget&gt;
&nbsp;&nbsp;&nbsp; &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
&nbsp;&nbsp;&nbsp; &lt;Administrator&gt;2&lt;/Administrator&gt;
&nbsp; &lt;/Department&gt;
&nbsp; &lt;Department&gt;
&nbsp;&nbsp;&nbsp; &lt;DepartmentID&gt;2&lt;/DepartmentID&gt;
&nbsp;&nbsp;&nbsp; &lt;Name&gt;English&lt;/Name&gt;
&nbsp;&nbsp;&nbsp; &lt;Budget&gt;120000&lt;/Budget&gt;
&nbsp;&nbsp;&nbsp; &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
&nbsp;&nbsp;&nbsp; &lt;Administrator&gt;6&lt;/Administrator&gt;
&nbsp; &lt;/Department&gt;
&nbsp; .................................
&lt;/MySchool&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">Following is the result of inferring from the above Xml document:
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/102824/1/image.png" alt="" width="638" height="85" align="middle">
</span></p>
<p class="MsoListParagraph">The above Xml document is as same as the document that GetXml method created early and we get the same structure as the original dataset. For this type structure, we can find that the name of root becomes the name of dataset, the
 names of second level elements become the names of tables and the names of the third level elements become the names of attributes.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Use two ways to export the dataset into the XML files.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Use WriteXml method to export the dataset.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using (FileStream fsWriterStream = new FileStream(xmlFileName, FileMode.Create))
{
&nbsp;&nbsp;&nbsp; using (XmlTextWriter xmlWriter = new XmlTextWriter(fsWriterStream, Encoding.Unicode))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Write {0} to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">
using (FileStream fsWriterStream = new FileStream(xmlFileName, FileMode.Create))
{
&nbsp;&nbsp;&nbsp; using (XmlTextWriter xmlWriter = new XmlTextWriter(fsWriterStream, Encoding.Unicode))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Write {0} to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Use GetXml method to export the dataset.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using (StreamWriter writer = new StreamWriter(xmlFileName))
{
&nbsp;&nbsp;&nbsp; writer.WriteLine(dataset.GetXml());
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Get Xml data from {0} and write to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
}

</pre>
<pre id="codePreview" class="csharp">
using (StreamWriter writer = new StreamWriter(xmlFileName))
{
&nbsp;&nbsp;&nbsp; writer.WriteLine(dataset.GetXml());
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Get Xml data from {0} and write to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Use two ways to import the dataset from the XML files.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Use ReadXml method to import the dataset.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using (FileStream fsReaderStream = new FileStream(xmlFileName, FileMode.Open))
{
&nbsp;&nbsp;&nbsp; using (XmlTextReader xmlReader = new XmlTextReader(fsReaderStream))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema);
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">
using (FileStream fsReaderStream = new FileStream(xmlFileName, FileMode.Open))
{
&nbsp;&nbsp;&nbsp; using (XmlTextReader xmlReader = new XmlTextReader(fsReaderStream))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema);
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Use InferXmlSchema method to import the dataset.<span style="font-size:9.5pt; font-family:Consolas; color:black">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
String[] xmlFileNames = { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithOnlyAttributes.xml&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithAttributes.xml&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; @&quot;XMLFiles\RepeatingElements.xml&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithChildElements.xml&quot; };


foreach (String xmlFileName in xmlFileNames)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Result of {0}&quot;, Path.GetFileNameWithoutExtension(xmlFileName));
&nbsp;&nbsp;&nbsp; DataSet newSchool = new DataSet();
&nbsp;&nbsp;&nbsp; newSchool.InferXmlSchema(xmlFileName,null);
&nbsp;&nbsp;&nbsp; DataTableHelper.ShowDataSetSchema(newSchool);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
String[] xmlFileNames = { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithOnlyAttributes.xml&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithAttributes.xml&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; @&quot;XMLFiles\RepeatingElements.xml&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@&quot;XMLFiles\ElementsWithChildElements.xml&quot; };


foreach (String xmlFileName in xmlFileNames)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Result of {0}&quot;, Path.GetFileNameWithoutExtension(xmlFileName));
&nbsp;&nbsp;&nbsp; DataSet newSchool = new DataSet();
&nbsp;&nbsp;&nbsp; newSchool.InferXmlSchema(xmlFileName,null);
&nbsp;&nbsp;&nbsp; DataTableHelper.ShowDataSetSchema(newSchool);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.data.dataset.getxml.aspx"><span class="SpellE">DataSet.GetXml</span> Method</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/d6swf149.aspx"><span class="SpellE">DataSet.ReadXml</span> Method (<span class="SpellE">XmlReader</span>)</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/cat50f7f.aspx">Inferring Tables</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/fx29c3yd(VS.110).aspx">Loading a
<span class="SpellE">DataSet</span> from XML</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
