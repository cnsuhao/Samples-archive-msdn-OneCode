# How to consume JSON Web Service Using WinJS.xhr
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Json Web Service
* WinJS.xhr
## IsPublished
* True
## ModifiedDate
* 2013-06-11 01:45:05
## Description

<h1>How to consume JSON Web Service Using WinJS.xhr <span style="">(JSWindowsStoreAppCallJsonWebService</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to consume JSON Web Service Using WinJS.xhr. When the app launched, please enter two numbers in textbox, and then click
 &quot;=&quot; button to get the addition of the two numbers. </span></h2>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click &quot;JSONWCFService&quot; project and click &quot;View in Browser (Internet Explorer)&quot; to run JSON Web Service firstly.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 or F5 to run the project.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span style="">the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84032/1/image.png" alt="" width="576" height="433" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Please enter a valid number and click '=' button to get the addition of the input two numbers, then enter an invalid number and click '=' button, you will receive the error &quot;please input number&quot; message.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below <span style="">shows the HTML UI. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
<div id="content">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="input">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div>Input Numbers: </div> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;txbFirstNumber&quot; type=&quot;text&quot; /&gt; &lt;label&gt; &#43; &lt;/label&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;txbSecondNumber&quot; type=&quot;text&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;button id=&quot;addbtn&quot;&gt;=&lt;/button&gt;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div> 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="error">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="output">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;Addition result of two numbers: &lt;/label&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id="SpanResult"></span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;</div>
&nbsp;&nbsp;&nbsp; </div>

</pre>
<pre id="codePreview" class="js">
<div id="content">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="input">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div>Input Numbers: </div> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;txbFirstNumber&quot; type=&quot;text&quot; /&gt; &lt;label&gt; &#43; &lt;/label&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input id=&quot;txbSecondNumber&quot; type=&quot;text&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;button id=&quot;addbtn&quot;&gt;=&lt;/button&gt;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div> 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="error">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="output">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;label&gt;Addition result of two numbers: &lt;/label&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id="SpanResult"></span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;</div>
&nbsp;&nbsp;&nbsp; </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">The code below
</span></a><span style=""></span><span style=""></span><span style="">shows how to use WinJS.xhr toconsume JSON Web Service.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
// Add button click event handler
&nbsp;&nbsp; function addButtonClick()
&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Retrieve element
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var leftnumber = document.getElementById('txbFirstNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rightnumber = document.getElementById('txbSecondNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var resultSpan = document.getElementById('SpanResult');


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Validate input number
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leftnumber == &quot;&quot; || rightnumber == &quot;&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; writeError(&quot;Error: left number or right number can not be null&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isNaN(leftnumber) || isNaN(rightnumber))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; writeError(&quot;Error: please input number&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Clear error input
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById('txbFirstNumber').value = &quot;&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById('txbSecondNumber').value = &quot;&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var baseURI=&quot;http://localhost:45573/AddService.svc/Add&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var leftnumber = document.getElementById('txbFirstNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rightnumber = document.getElementById('txbSecondNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WinJS.xhr({
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; type: &quot;post&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; url: baseURI,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headers: { &quot;Content-type&quot;: &quot;application/json&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; data: '{&quot;Number1&quot;:' &#43; leftnumber &#43; ',&quot;Number2&quot;:' &#43; rightnumber &#43; '}'
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then(function (r) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (eval('(' &#43; r.responseText &#43; ')').error != null) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var result = eval('(' &#43; r.responseText &#43; ')').error;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.style.color = &quot;red&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.innerHTML = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var result = JSON.parse(eval('(' &#43; r.responseText &#43; ')').AddResult);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.style.removeAttribute(&quot;color&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.innerHTML = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="js">
// Add button click event handler
&nbsp;&nbsp; function addButtonClick()
&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Retrieve element
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var leftnumber = document.getElementById('txbFirstNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rightnumber = document.getElementById('txbSecondNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var resultSpan = document.getElementById('SpanResult');


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Validate input number
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leftnumber == &quot;&quot; || rightnumber == &quot;&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; writeError(&quot;Error: left number or right number can not be null&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isNaN(leftnumber) || isNaN(rightnumber))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; writeError(&quot;Error: please input number&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Clear error input
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; document.getElementById('txbFirstNumber').value = &quot;&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById('txbSecondNumber').value = &quot;&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var baseURI=&quot;http://localhost:45573/AddService.svc/Add&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var leftnumber = document.getElementById('txbFirstNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rightnumber = document.getElementById('txbSecondNumber').value.trim();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WinJS.xhr({
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; type: &quot;post&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; url: baseURI,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headers: { &quot;Content-type&quot;: &quot;application/json&quot; },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; data: '{&quot;Number1&quot;:' &#43; leftnumber &#43; ',&quot;Number2&quot;:' &#43; rightnumber &#43; '}'
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then(function (r) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (eval('(' &#43; r.responseText &#43; ')').error != null) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var result = eval('(' &#43; r.responseText &#43; ')').error;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.style.color = &quot;red&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.innerHTML = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var result = JSON.parse(eval('(' &#43; r.responseText &#43; ')').AddResult);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.style.removeAttribute(&quot;color&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; resultSpan.innerHTML = result;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style="">WinJS.xhr function </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br229787.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br229787.aspx</a></p>
<p class="MsoNormal"><span style="">JSON.parse Function (JavaScript) </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ie/cc836466(v=vs.94).aspx">http://msdn.microsoft.com/en-us/library/ie/cc836466(v=vs.94).aspx</a></p>
<p class="MsoNormal">Connecting to web services (Windows Store apps using JavaScript and HTML)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh761502.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh761502.aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
