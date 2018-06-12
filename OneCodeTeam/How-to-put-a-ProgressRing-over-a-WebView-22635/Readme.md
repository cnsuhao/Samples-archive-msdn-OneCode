# How to put a ProgressRing over a WebView
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* WebView
* ProgressRing
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:21:53
## Description

<h1>How to <span class="SpellE"><span style="">diplay</span></span><span style="">
<span class="SpellE">ProgressRing</span> over <span class="SpellE">Iframe</span></span>
<span style="">(<span class="SpellE">JSWindowsStoreAppProgressRingOverIframe</span></span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This sample demonstrates how to display <span class="SpellE">
ProgressRing</span> over <span class="SpellE">Iframe</span>. </span></p>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution (.<span class="SpellE">sln</span>) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span style="">the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84439/1/image.png" alt="" width="576" height="430" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Please enter a valid <span class="GramE">url</span> and click 'Load' button to load the page, then enter another url and click 'Load' button again. You will see a
<span class="SpellE">ProgressRing</span> over the first page before the second page loaded.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<p class="MsoNormal"><b style=""><span style="">NOTES: </span></b></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When loading the page, it may throw a JavaScript exception, this not caused by the sample, it is caused by the web page, many web pages have JavaScript problems, even some famous websites. This issue only occurs when debugging.
 You can get rid of those annoying JavaScript exceptions through this method: </span>
</p>
<p class="MsoListParagraphCxSpMiddle"><a href="http://blogs.msdn.com/b/wsdevsol/archive/2012/10/18/nine-things-you-need-to-know-about-webview.aspx#AN10">http://blogs.msdn.com/b/wsdevsol/archive/2012/10/18/nine-things-you-need-to-know-about-webview.aspx#AN10</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Some sites (Such as <a href="http://www.google.com">
http://www.google.com</a>) can't be nested in <span class="SpellE">iframe</span>.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below <span style="">shows the HTML UI. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
<div class="output">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;iframe id=&quot;webView&quot; src=&quot;&quot;&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/iframe&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label id=&quot;progressRingContainer&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;progress id=&quot;loadingProcessProgressRing&quot; class=&quot;win-ring&quot;&gt;&lt;/progress&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/label&gt;
 </div>

</pre>
<pre id="codePreview" class="html">
<div class="output">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;iframe id=&quot;webView&quot; src=&quot;&quot;&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/iframe&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label id=&quot;progressRingContainer&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;progress id=&quot;loadingProcessProgressRing&quot; class=&quot;win-ring&quot;&gt;&lt;/progress&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/label&gt;
 </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">The code below
</span></a><span style=""></span><span style=""></span><span style="">shows how to use JavaScript code to make the
<span class="SpellE">ProgressRing</span> over the <span class="SpellE">Iframe</span>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
// Load Button Click event handler
&nbsp; function loadButtonClick()
&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Retrieve the DOM element 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadButton = document.getElementById(&quot;loadbtn&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; urlTxb = document.getElementById(&quot;urltxb&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; progressRing = document.getElementById(&quot;progressRingContainer&quot;);
&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (validateUrl(urlTxb.value)) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;urlerror&quot;).style.visibility = &quot;collapse&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; progressRing.style.visibility = &quot;visible&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;webView&quot;).src = urlTxb.value;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;urlerror&quot;).style.visibility = &quot;visible&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp; }

</pre>
<pre id="codePreview" class="js">
// Load Button Click event handler
&nbsp; function loadButtonClick()
&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Retrieve the DOM element 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadButton = document.getElementById(&quot;loadbtn&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; urlTxb = document.getElementById(&quot;urltxb&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; progressRing = document.getElementById(&quot;progressRingContainer&quot;);
&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (validateUrl(urlTxb.value)) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;urlerror&quot;).style.visibility = &quot;collapse&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; progressRing.style.visibility = &quot;visible&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;webView&quot;).src = urlTxb.value;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById(&quot;urlerror&quot;).style.visibility = &quot;visible&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span class="SpellE"><span style="">Iframe</span></span><span style=""> element
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh465955.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh465955.aspx</a></p>
<p class="MsoNormal"><span style="">Progress element </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh441310.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh441310.aspx</a>
<span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
