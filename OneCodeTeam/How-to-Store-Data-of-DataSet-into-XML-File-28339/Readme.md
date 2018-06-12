# How to Store Data of DataSet into XML File
## Requires
* Visual Studio 2013
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
* False
## ModifiedDate
* 2014-04-24 02:42:07
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Store Data of DataSe</span><span style="font-weight:bold; font-size:14pt">t into XML File</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In this sample, we will demonstrate how to write data into XML file from DataSet and read data into DataSet from XML.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. We will create one dataset with two tables.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. We will use two ways to export dataset into the XML files:WriteXml method and GetXml method.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. We will use two ways to import dataset from the XML files:ReadXml method and InferXmlSchema method.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample, the following is the result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we create one dataset that contains two tables.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113526/1/image.png" alt="" width="638" height="270" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Second, we use two ways to export the dataset into XML files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Use WriteXml method to export the dataset.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113527/1/image.png" alt="" width="642" height="22" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. Use GetXml method to export the dataset.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113528/1/image.png" alt="" width="639" height="23" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Third, we import the dataset from the XML files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Use ReadXml to import the dataset.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We use ReadXml method to read the XML file that WriteXml method created early. Because we also read the schema from the XML file, we can find that the schema is as same as the schema of the original
 dataset.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113529/1/image.png" alt="" width="639" height="87" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. Use InferXmlSchema method to infer the schemas.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We display four types of XML structures.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">Elements that only have attributes</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the Xml document:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
  &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;  Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot; /&gt;
  &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;  Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
  &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
  &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot; /&gt;
&lt;/MySchool&gt;
</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
  &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;  Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot; /&gt;
  &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;  Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
  &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
  &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot; /&gt;
&lt;/MySchool&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the result of inferring from the above Xml document:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113530/1/image.png" alt="" width="639" height="73" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Now we can find that the name of root element becomes the name of dataset, the names of elements become the name of table and the names of attributes become the name of columns.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">Elements that have attributes and the element text</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the Xml document:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
  &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;  Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot;&gt;New&lt;/Course&gt;
  &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;  Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
  &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
  &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot;&gt;Cancelled&lt;/Department&gt;
&lt;/MySchool&gt;
</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
  &lt;Course CourseID=&quot;C1045&quot; Year=&quot;2012&quot;  Title=&quot;Calculus&quot; Credits=&quot;4&quot; DepartmentID=&quot;7&quot;&gt;New&lt;/Course&gt;
  &lt;Course CourseID=&quot;C1061&quot; Year=&quot;2012&quot;  Title=&quot;Physics&quot; Credits=&quot;4&quot; DepartmentID=&quot;1&quot; /&gt;
  &lt;Department DepartmentID=&quot;1&quot; Name=&quot;Engineering&quot; Budget=&quot;350000&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;2&quot; /&gt;
  &lt;Department DepartmentID=&quot;7&quot; Name=&quot;Mathematics&quot; Budget=&quot;250024&quot; StartDate=&quot;2007-09-01T00:00:00&#43;08:00&quot; Administrator=&quot;3&quot;&gt;Cancelled&lt;/Department&gt;
&lt;/MySchool&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:24pt; margin-bottom:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:10pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the result of inferring from the above Xml document:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113531/1/image.png" alt="" width="635" height="87" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">The only difference between type 1 and 2 is that type 2 have the element text in Xml document. So we can find the only difference of the results is that the new columns, &ldquo;Course_Text&rdquo;, &ldquo;Department_Text&rdquo;.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">Repeating Elements</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the Xml document:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
  &lt;Course&gt;C1045&lt;/Course&gt;
  &lt;Course&gt;C1061&lt;/Course&gt;
  &lt;Department&gt;Engineering&lt;/Department&gt; 
  &lt;Department&gt;Mathematics&lt;/Department&gt;
&lt;/MySchool&gt;
</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
  &lt;Course&gt;C1045&lt;/Course&gt;
  &lt;Course&gt;C1061&lt;/Course&gt;
  &lt;Department&gt;Engineering&lt;/Department&gt; 
  &lt;Department&gt;Mathematics&lt;/Department&gt;
&lt;/MySchool&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:24pt; margin-bottom:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:10pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the result of inferring from the above Xml document:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113532/1/image.png" alt="" width="635" height="79" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">We can find that the repeat elements result in a single inferred table.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">Elements With Child Elements</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the Xml document:</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;MySchool&gt;
  &lt;Course&gt;
    &lt;CourseID&gt;C1045&lt;/CourseID&gt;
    &lt;Year&gt;2012&lt;/Year&gt;
    &lt;Title&gt;Calculus&lt;/Title&gt;
    &lt;Credits&gt;4&lt;/Credits&gt;
    &lt;DepartmentID&gt;7&lt;/DepartmentID&gt;
  &lt;/Course&gt;
  &lt;Course&gt;
    &lt;CourseID&gt;C1061&lt;/CourseID&gt;
    &lt;Year&gt;2012&lt;/Year&gt;
    &lt;Title&gt;Physics&lt;/Title&gt;
    &lt;Credits&gt;4&lt;/Credits&gt;
    &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
  &lt;/Course&gt;
  .................................
  &lt;Department&gt;
    &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
    &lt;Name&gt;Engineering&lt;/Name&gt;
    &lt;Budget&gt;350000&lt;/Budget&gt;
    &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
    &lt;Administrator&gt;2&lt;/Administrator&gt;
  &lt;/Department&gt;
  &lt;Department&gt;
    &lt;DepartmentID&gt;2&lt;/DepartmentID&gt;
    &lt;Name&gt;English&lt;/Name&gt;
    &lt;Budget&gt;120000&lt;/Budget&gt;
    &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
    &lt;Administrator&gt;6&lt;/Administrator&gt;
  &lt;/Department&gt;
  .................................
&lt;/MySchool&gt;
</pre>
<pre id="codePreview" class="xml">
&lt;MySchool&gt;
  &lt;Course&gt;
    &lt;CourseID&gt;C1045&lt;/CourseID&gt;
    &lt;Year&gt;2012&lt;/Year&gt;
    &lt;Title&gt;Calculus&lt;/Title&gt;
    &lt;Credits&gt;4&lt;/Credits&gt;
    &lt;DepartmentID&gt;7&lt;/DepartmentID&gt;
  &lt;/Course&gt;
  &lt;Course&gt;
    &lt;CourseID&gt;C1061&lt;/CourseID&gt;
    &lt;Year&gt;2012&lt;/Year&gt;
    &lt;Title&gt;Physics&lt;/Title&gt;
    &lt;Credits&gt;4&lt;/Credits&gt;
    &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
  &lt;/Course&gt;
  .................................
  &lt;Department&gt;
    &lt;DepartmentID&gt;1&lt;/DepartmentID&gt;
    &lt;Name&gt;Engineering&lt;/Name&gt;
    &lt;Budget&gt;350000&lt;/Budget&gt;
    &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
    &lt;Administrator&gt;2&lt;/Administrator&gt;
  &lt;/Department&gt;
  &lt;Department&gt;
    &lt;DepartmentID&gt;2&lt;/DepartmentID&gt;
    &lt;Name&gt;English&lt;/Name&gt;
    &lt;Budget&gt;120000&lt;/Budget&gt;
    &lt;StartDate&gt;2007-09-01T00:00:00&#43;08:00&lt;/StartDate&gt;
    &lt;Administrator&gt;6&lt;/Administrator&gt;
  &lt;/Department&gt;
  .................................
&lt;/MySchool&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">Following is the result of inferring from the above Xml document:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113533/1/image.png" alt="" width="637" height="83" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">The above Xml document is as same as the document that GetXml method created early and we get the same structure as the original dataset. For this type structure, we can find that the name of root becomes
 the name of dataset, the names of second level elements become the names of tables and the names of the third level elements become the names of attributes.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">1. Use two ways to export the dataset into the XML files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Use WriteXml method to export the dataset.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
using (FileStream fsWriterStream = new FileStream(xmlFileName, FileMode.Create))
{
    using (XmlTextWriter xmlWriter = new XmlTextWriter(fsWriterStream, Encoding.Unicode))
    {
        dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
        Console.WriteLine(&quot;Write {0} to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
        Console.WriteLine();
    }
}
</pre>
<pre class="hidden">
Using fsWriterStream As New FileStream(xmlFileName, FileMode.Create)
    Using xmlWriter As New XmlTextWriter(fsWriterStream, Encoding.Unicode)
        dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)
        Console.WriteLine(&quot;Write {0} to the File {1}.&quot;, dataset.DataSetName, xmlFileName)
        Console.WriteLine()
    End Using
End Using
</pre>
<pre id="codePreview" class="csharp">
using (FileStream fsWriterStream = new FileStream(xmlFileName, FileMode.Create))
{
    using (XmlTextWriter xmlWriter = new XmlTextWriter(fsWriterStream, Encoding.Unicode))
    {
        dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
        Console.WriteLine(&quot;Write {0} to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
        Console.WriteLine();
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. Use GetXml method to export the dataset.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
using (StreamWriter writer = new StreamWriter(xmlFileName))
{
    writer.WriteLine(dataset.GetXml());
    Console.WriteLine(&quot;Get Xml data from {0} and write to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
    Console.WriteLine();
}
</pre>
<pre class="hidden">
Using writer As New StreamWriter(xmlFileName)
    writer.WriteLine(dataset.GetXml())
    Console.WriteLine(&quot;Get Xml data from {0} and write to the File {1}.&quot;,
                      dataset.DataSetName, xmlFileName)
    Console.WriteLine()
End Using
</pre>
<pre id="codePreview" class="csharp">
using (StreamWriter writer = new StreamWriter(xmlFileName))
{
    writer.WriteLine(dataset.GetXml());
    Console.WriteLine(&quot;Get Xml data from {0} and write to the File {1}.&quot;, dataset.DataSetName, xmlFileName);
    Console.WriteLine();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">2. Use two ways to import the dataset from the XML files.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Use ReadXml method to import the dataset.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
using (FileStream fsReaderStream = new FileStream(xmlFileName, FileMode.Open))
{
    using (XmlTextReader xmlReader = new XmlTextReader(fsReaderStream))
    {
        newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema);
    }
}
</pre>
<pre class="hidden">
Using fsReaderStream As New FileStream(xmlFileName, FileMode.Open)
    Using xmlReader As New XmlTextReader(fsReaderStream)
        newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema)
    End Using
End Using
</pre>
<pre id="codePreview" class="csharp">
using (FileStream fsReaderStream = new FileStream(xmlFileName, FileMode.Open))
{
    using (XmlTextReader xmlReader = new XmlTextReader(fsReaderStream))
    {
        newDataSet.ReadXml(xmlReader, XmlReadMode.ReadSchema);
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. Use InferXmlSchema method to import the datset.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
String[] xmlFileNames = { 
                        @&quot;XMLFiles\ElementsWithOnlyAttributes.xml&quot;, 
                        @&quot;XMLFiles\ElementsWithAttributes.xml&quot;,
                        @&quot;XMLFiles\RepeatingElements.xml&quot;, 
                        @&quot;XMLFiles\ElementsWithChildElements.xml&quot; };
foreach (String xmlFileName in xmlFileNames)
{
    Console.WriteLine(&quot;Result of {0}&quot;, Path.GetFileNameWithoutExtension(xmlFileName));
    DataSet newSchool = new DataSet();
    newSchool.InferXmlSchema(xmlFileName,null);
    DataTableHelper.ShowDataSetSchema(newSchool);
    Console.WriteLine();
           }
</pre>
<pre class="hidden">
Dim xmlFileNames() As String =
    {&quot;XMLFiles\ElementsWithOnlyAttributes.xml&quot;,
     &quot;XMLFiles\ElementsWithAttributes.xml&quot;,
     &quot;XMLFiles\RepeatingElements.xml&quot;,
     &quot;XMLFiles\ElementsWithChildElements.xml&quot;}
For Each xmlFileName As String In xmlFileNames
    Console.WriteLine(&quot;Result of {0}&quot;, Path.GetFileNameWithoutExtension(xmlFileName))
    Dim newSchool As New DataSet()
    newSchool.InferXmlSchema(xmlFileName, Nothing)
    DataTableHelper.ShowDataSetSchema(newSchool)
    Console.WriteLine()
Next xmlFileName
</pre>
<pre id="codePreview" class="csharp">
String[] xmlFileNames = { 
                        @&quot;XMLFiles\ElementsWithOnlyAttributes.xml&quot;, 
                        @&quot;XMLFiles\ElementsWithAttributes.xml&quot;,
                        @&quot;XMLFiles\RepeatingElements.xml&quot;, 
                        @&quot;XMLFiles\ElementsWithChildElements.xml&quot; };
foreach (String xmlFileName in xmlFileNames)
{
    Console.WriteLine(&quot;Result of {0}&quot;, Path.GetFileNameWithoutExtension(xmlFileName));
    DataSet newSchool = new DataSet();
    newSchool.InferXmlSchema(xmlFileName,null);
    DataTableHelper.ShowDataSetSchema(newSchool);
    Console.WriteLine();
           }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/system.data.dataset.getxml.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataSet.GetXml
 Method</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/d6swf149.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataSet.ReadXml Method
 (XmlReader)</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/cat50f7f.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Inferring Tables</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/fx29c3yd(VS.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Loading a
 DataSet from XML</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
