# Use XPath to read XML (VBXPath)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* XML
## Topics
* Xpath
## IsPublished
* True
## ModifiedDate
* 2012-11-27 08:38:32
## Description

<h2><span style="font-size:14.0pt; line-height:115%">CONSOLE APPLICATION </span><span style="font-size:14.0pt; line-height:115%">(<span class="SpellE">VB<span style="">XPath</span></span>)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample project shows how to use XPathDocument class to load the XML file<span style="">
</span>and manipulate. It includes two main parts, <span class="SpellE">XPathNavigator</span> usage and
<span class="SpellE">XPath</span><span style=""> </span>Expression usage. The first part shows how to use
<span class="SpellE">XPathNavigator</span> to navigate through the whole document, read its content. The second part shows how to use<span style="">
</span><span class="SpellE">XPath</span> expression to filter information.<span style="">&nbsp;
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71344/1/image.png" alt="" width="576" height="376" align="middle">
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<h3><span style="">Initialize <span class="SpellE">XPathDocument</span> and <span class="SpellE">
XPathNavigator</span> instances </span></h3>
<p class="MsoListParagraph"><span style=""></span></p>
<h3><span style="">Call <span class="SpellE">MoveToRoot</span> and <span class="SpellE">
MoveToFirstChild</span> to navigate to the book elements </span></h3>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Loop through all books and <span class="SpellE">thier</span> children nodes.
<span class="GramE">Output author, title, genre, price, <span class="SpellE">
publish_date</span>, description information for each book.</span> </span></h3>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use <span class="SpellE">XPath</span> Expression to select out the book with ID bk103 and output its detailed information.
</span></h3>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use <span class="SpellE">XPath</span> Expression to select out all books whose price
<span class="GramE">are</span> more than 10. </span></h3>
<p class="MsoNormal"><span style=""></span></p>
<h3><span style="">Use <span class="SpellE">XPath</span> Expression to calculate the average price of all books.
</span></h3>
<h2>More Information</h2>
<p class="MsoListParagraph" style="margin-bottom:0cm; margin-bottom:.0001pt; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://support.microsoft.com/kb/301111/en-us">How to navigate XML with the XPathNavigator class by using VB.NET.</a>
</span></p>
<h2><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
