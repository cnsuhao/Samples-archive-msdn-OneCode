# General operations of XML files (CSXmlGeneral)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* XML
## Topics
* XML
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:16:25
## Description

<h2><span style="font-size:14.0pt; line-height:115%">CONSOLE APPLICATION </span><span style="font-size:14.0pt; line-height:115%">(</span><span class="SpellE"><span style="font-size:14.0pt; line-height:115%">CSXmlGeneral</span></span><span style="font-size:14.0pt; line-height:115%">)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal">This C# sample project shows how to read a XML file by using
<span class="SpellE">XmlTextReader</span> or <span class="SpellE">XmlNodeReader</span>. It also shows, instead of using forward-only reader, how to read, modify, and update Xml element using the
<span class="SpellE">XmlDocument</span> class. This class will load the whole document into memory for modification and we can save the modified XML file to the file system.<span style="">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/52974/1/image.png" alt="" width="576" height="485" align="middle">
</span></p>
<h2><span style="">Code Logic </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">1. Read XML document using the
<span class="SpellE">XmlTextReader</span> class. The <span class="SpellE">XmlTextReader</span> acts as a reader pointer that only moves forward. Because it always moves forward and reads a piece of data into memory buffer, it has a better performance than</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">the
<span class="SpellE">XmlDocument</span> class which loads the whole document into memory.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">2. Read XML document using the
<span class="SpellE">XmlNodeReader</span> class. This class is similar to <span class="SpellE">
XmlTextReader</span> but <span class="SpellE"><span class="GramE">ot</span></span> accepts an
<span class="SpellE">XmlNode</span> instance as the target to read. </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">3. Use
<span class="SpellE">XmlDocument</span> to load the whole XML file into memory.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">4. Call
<span class="SpellE">SelectSingleNode</span> to navigate to the desired node and change its contents by setting the
<span class="SpellE">InnerText</span> property </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">5. Call
<span class="SpellE">XmlDocument.CreateElement</span> and <span class="SpellE">
CreateAttribute</span> to create a new element</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">and attribute. Call
<span class="SpellE">AppendChild</span> function to add the new element to where we want to add it.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">6. Save the
<span class="SpellE">XmlDocument</span> instance to a local file. </span></h2>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/2bcctyt8.aspx">MSDN: Employing XML in the .NET Framework</a>
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
