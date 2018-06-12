# How to disable the "save" and "save as" buttons in Office
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Office
* VSTO
* Office Development
## Topics
* code snippets
* disable save and saveas button
## IsPublished
* True
## ModifiedDate
* 2014-06-11 08:16:06
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to disable the &quot;save&quot; and &quot;save as&quot; buttons in Office</span><span style="font-weight:bold; font-size:14pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span><span style="font-weight:bold; font-size:13pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code snippets demonstrate how to disable &quot;save&quot; and &quot;save as</span><span style="font-size:11pt">&quot; button</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> in word application.
</span><span style="font-size:11pt">This is a frequently asked question in forums.
</span><span style="font-size:11pt">Many customers don't know how to</span><span style="font-size:11pt"> achieve</span><span style="font-size:11pt"> it</span><span style="font-size:11pt">.</span><span style="font-size:11pt"> The following simple code snippets
 will show you </span><span style="font-size:11pt">how to </span><span style="font-size:11pt">solve the problem</span><span style="font-size:11pt">.</span><span style="font-weight:bold; font-style:italic; font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span><span style="font-weight:bold; font-size:13pt">
</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Create Word 2013 Add-in project by using Visual Studio.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Add Ribbon</span><span style="font-size:11pt"> (XML) item into the project. Note that you need to use Ribbon XML,
</span><span style="font-size:11pt">and </span><span style="font-size:11pt">can't use the Ribbon Designer.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Modify the Ribbon xml a</span><span style="font-size:11pt">s follows</span><span style="font-size:11pt">:</span><span style="font-size:11pt">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt; 
&lt;customUI xmlns=&quot;http://schemas.microsoft.com/office/2009/07/customui&quot; onLoad=&quot;Ribbon_Load&quot;&gt; 
&lt;commands&gt; 
&lt;command idMso=&quot;FileSaveAs&quot; enabled=&quot;false&quot;/&gt; 
&lt;command idMso=&quot;FileSave&quot; enabled=&quot;false&quot;/&gt; 
&lt;/commands&gt; 
&lt;/customUI&gt; 
</pre>
<pre id="codePreview" class="xml">&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt; 
&lt;customUI xmlns=&quot;http://schemas.microsoft.com/office/2009/07/customui&quot; onLoad=&quot;Ribbon_Load&quot;&gt; 
&lt;commands&gt; 
&lt;command idMso=&quot;FileSaveAs&quot; enabled=&quot;false&quot;/&gt; 
&lt;command idMso=&quot;FileSave&quot; enabled=&quot;false&quot;/&gt; 
&lt;/commands&gt; 
&lt;/customUI&gt; 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">4. </span><span style="font-size:11pt">Add the following code block into the
</span><span style="font-size:11pt">ThisAddin</span><span style="font-size:11pt"> class.</span><span style="font-size:11pt">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public partial class ThisAddIn 
{ 
protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject() 
{ 
return new Ribbon1(); 
} 
private void ThisAddIn_Startup(object sender, System.EventArgs e) 
{ 
} 
private void ThisAddIn_Shutdown(object sender, System.EventArgs e) 
{ 
} 
#region VSTO generated code 
/// &lt;summary&gt; 
/// Required method for Designer support - do not modify 
/// the contents of this method with the code editor. 
/// &lt;/summary&gt; 
private void InternalStartup() 
{ 
this.Startup &#43;= new System.EventHandler(ThisAddIn_Startup); 
this.Shutdown &#43;= new System.EventHandler(ThisAddIn_Shutdown); 
} 
#endregion 
}
</pre>
<pre class="hidden">Public Class ThisAddIn 
Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility 
Return New Ribbon1() 
End Function 
Private Sub ThisAddIn_Startup() Handles Me.Startup 
End Sub 
Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown 
End Sub 
End Class 
</pre>
<pre id="codePreview" class="csharp">public partial class ThisAddIn 
{ 
protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject() 
{ 
return new Ribbon1(); 
} 
private void ThisAddIn_Startup(object sender, System.EventArgs e) 
{ 
} 
private void ThisAddIn_Shutdown(object sender, System.EventArgs e) 
{ 
} 
#region VSTO generated code 
/// &lt;summary&gt; 
/// Required method for Designer support - do not modify 
/// the contents of this method with the code editor. 
/// &lt;/summary&gt; 
private void InternalStartup() 
{ 
this.Startup &#43;= new System.EventHandler(ThisAddIn_Startup); 
this.Shutdown &#43;= new System.EventHandler(ThisAddIn_Shutdown); 
} 
#endregion 
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Customizing the 2007 Office Fluent Ribbon for Developers
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/office/aa338202(v=office.12).aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/office/aa338202(v=office.12).aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Office UI Customization</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/bf08984t.aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/bf08984t.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
