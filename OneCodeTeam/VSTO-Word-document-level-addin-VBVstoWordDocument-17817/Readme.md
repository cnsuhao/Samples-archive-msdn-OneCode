# VSTO Word document-level addin (VBVstoWordDocument)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* VSTO
* Word
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:57:03
## Description

<h1><span style="">Word Document</span> (<span class="SpellE"><span style="">VBVstoWordDocument</span></span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This Sample demonstrates how to manipulate Word 20<span style="">10</span> Content Controls in a VSTO document-level project.<span style="">&nbsp;
</span><span style=""></span></p>
<p><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The <span class="SpellE">
<span style="">Microsoft.Office.Interop.Word.Document</span></span> object is central to programming Word. When you open a document or create a new document, you create a new
<span class="SpellE"><span style="">Microsoft.Office.Interop.Word.Document</span></span> object, which is added to the
<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.documents.aspx">
<span style="color:windowtext; text-decoration:none">Documents</span></a> <span class="GramE">
collection<span style="">(</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.documents.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.documents.aspx</a>)</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
 in Word. The document that has the focus is called the active <span class="GramE">
document<span style="">(</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word._application.activedocument.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word._application.activedocument.aspx</a>)</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
 and is represented by the <a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word._application.activedocument.aspx">
<span class="SpellE"><span style="color:windowtext; text-decoration:none">ActiveDocument</span></span></a> property of the
<span style="">Application</span> object. </span></p>
<p><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Visual Studio Tools for Office extends the
<span class="SpellE"><span style="">Microsoft.Office.Interop.Word.Document</span></span> object by providing the
<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.word.document(v=vs.80).aspx">
<span style="color:windowtext; text-decoration:none">Microsoft.Office.Tools.Word.Document</span></a>
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">(<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.word.document(v=vs.80).aspx)">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.word.document(v=vs.80).aspx)</a>
 object</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">, which gives you access to all members of the
<span style="">Documents</span> collection, as well as data-binding capabilities and additional events. For more information, see
<a href="http://msdn.microsoft.com/en-us/library/9z4e3456(v=vs.80).aspx"><span style="color:windowtext; text-decoration:none">Host Items and Host Controls Overview</span></a></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">(<a href="http://msdn.microsoft.com/en-us/library/9z4e3456(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/9z4e3456(v=vs.80).aspx</a>)</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">.
 Since the majority of your code will be written in the <span class="SpellE">ThisDocument</span> class, you can access members of
<span class="SpellE">ThisDocument</span> with the <span class="GramE"><span style="">Me</span></span> or
<span style="">this</span> object reference</span><span style=""> </span></p>
<h2><span style="">Building the Sample </span></h2>
<p class="MsoNormal"><span style="">Before you build the sample, you must install Microsoft office2010 on your Operation System.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61545/1/image.png" alt="" width="1600" height="1248" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">1. </span>Create a Word 20<span style="">10</span> Document project.</p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">2. </span>Add a new user control in the project.</p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">3. </span>Drag three buttons in the user control.</p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">4. </span>Add code to insert all types of content controls at runtime<span style="">.<b>
</b></span></p>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-left:18.0pt">MSDN: User Account Control</p>
<p class="MsoNormal" style="margin-left:18.0pt"><a href="http://msdn.microsoft.com/en-us/library/aa511445.aspx">http://msdn.microsoft.com/en-us/library/aa511445.aspx</a><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">Using VSTO Document Features in Application-Level Add-Ins
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://blogs.msdn.com/b/eric_carter/archive/2008/07/24/using-vsto-document-features-in-application-level-add-ins.aspx">http://blogs.msdn.com/b/eric_carter/archive/2008/07/24/using-vsto-document-features-in-application-level-add-ins.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE"><span class="GramE"><span lang="EN" style="">fice</span></span></span><span lang="EN" style=""> Development with Visual Studio</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://blogs.msdn.com/b/vsto/">http://blogs.msdn.com/b/vsto/</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">Word Object Model Overview
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/kw65a0we(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/kw65a0we(v=vs.80).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
