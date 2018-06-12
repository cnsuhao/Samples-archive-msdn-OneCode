# How to call ASMX Web Service with WSDL file on local computer
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Web Services
* .NET Framework
## Topics
* WSDL
## IsPublished
* True
## ModifiedDate
* 2014-08-31 11:24:51
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h2>Introduction</h2>
<p>The project illustrates how to call ASMX Web Service with WSDL file on local computer.</p>
<p>Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<p><a href="http://forums.asp.net/p/1739187/4685087.aspx/1?Re&#43;how&#43;to&#43;delpoy&#43;this&#43;web&#43;service">http://forums.asp.net/p/1739187/4685087.aspx/1?Re&#43;how&#43;to&#43;delpoy&#43;this&#43;web&#43;service</a></p>
<p><a href="http://forums.asp.net/p/1729861/4641556.aspx/1?Re&#43;Webservice&#43;for&#43;oracle&#43;database&#43;lookup">http://forums.asp.net/p/1729861/4641556.aspx/1?Re&#43;Webservice&#43;for&#43;oracle&#43;database&#43;lookup</a></p>
<p>&nbsp;</p>
<h2>Building the Project</h2>
<p>&nbsp;</p>
<p><strong>A.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><strong>Creating a Console Application (CScallASMXlocalWsdl)</strong></p>
<ol>
<li>In the Visual Studio 2012 create a Console Application </li><li>Open the Solution Explorer in my project </li><li>Right click on it and choose &quot;Add Web Reference&quot; </li><li>The &ldquo;Add Web Reference&rdquo; pop window appears </li><li>In URL box, instead of type the web site address, enter the exact location of your wsdl file, and don't forget to type the extension. (e.g D:\OneCode\CScallASMXlocalWsdl\Metadata\SampleWebService.wsdl)
</li><li>Click on &quot;Go&quot;, If everything's all right Visual Studio will recognize the wsdl and procedures inside.
</li><li>You can also rename the Web reference name, click &ldquo;Add Reference&rdquo; button
</li><li>Back to Solution Explorer window, you should see the wsdl file appears under WebReference node. You can now consume it in the same way as any other reference file.
</li><li>Call the web method using the following code snippet. </li><li>In this example, consider to change the parameter and test the application numerous times.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using (var webService = new WebReference.WebService1())
{
                var result = webService.GetData(10);
                Console.WriteLine(result);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(var&nbsp;webService&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebReference.WebService1())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;webService.GetData(<span class="cs__number">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(result);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
<p>&nbsp;</p>
<h2>Running the Sample</h2>
<p>&nbsp;</p>
<ol>
<li>The target method is GetData. </li><li>Test method </li></ol>
<ul>
<li>Modify the parameter for GetData() </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var result = webService.GetData(10);</pre>
<div class="preview">
<pre class="csharp">var&nbsp;result&nbsp;=&nbsp;webService.GetData(<span class="cs__number">10</span>);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<ul>
<li>Run the application </li></ul>
<p>&nbsp;</p>
<p>Sharing the sample data by its operations:</p>
<h1><img id="124636" src="/site/view/file/124636/1/1.png" alt="" width="296" height="165"></h1>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="color:white; line-height:0.6pt; font-size:10px">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft
 development technologies, and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently
 asked programming tasks, and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
