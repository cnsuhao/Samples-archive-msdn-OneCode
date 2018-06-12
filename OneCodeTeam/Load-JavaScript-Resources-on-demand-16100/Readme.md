# Load JavaScript Resources on-demand (CSASPNETLoadAndExecuteDynamicJS)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Javascript
## IsPublished
* True
## ModifiedDate
* 2012-04-03 06:56:13
## Description

<h1>The sample demonstrates how JavaScript resources can be loaded on-demand.&nbsp; (CSASPNETLoadAndExecuteDynamicJS)</h1>
<h2>Introduction</h2>
<p>The sample demonstrates how JavaScript resources can be loaded on-demand. The JavaScript file is linked to the page via an Asynchronous web service call which returns the relative location of the JS on the server file and links it to the current page through
 JavaScript.</p>
<p>&nbsp;</p>
<h2>Building the Sample</h2>
<ol>
<li>Added a SVC (Ajax enabled web service [WCF] to the project). </li><li>Added a ScriptManager Object to the Default.aspx page for asynchronously calling the method in the WCF service.
</li><li>We call the method in WCF service Asynchronously using the &quot;$.Ajax()&quot; method. in JQuery
</li><li>The result of the service call is the path to the script object on the server.
</li><li>Server contains a folder named a &quot;Scripts&quot; which is only known to the WCF service.
</li><li>Then dynamically, the demanded script is linked to the page. </li><li>We add the &quot;Source&quot; of the JavaScript to the string that is returned as relative path from the web service.
</li><li>For sample, we just have a &quot;alert()&quot; in the dynamic script that is loaded and executed.
</li></ol>
<p>&nbsp;</p>
<h2>Running the Sample</h2>
<ol>
<li>Open the &ldquo;CSASPNETLoadAndExecuteDynamicJS.sln&rdquo; file in Visual Studio 2010.
</li><li>Run the sample. </li><li>Click the &ldquo;Load Script stored on Internal Server&rdquo; button. </li><li>This will attach the script on-demand to the page. </li><li>Click the &ldquo;Call Script stored on Internal Server&rdquo; button. </li><li>This will call the method from the dynamically loaded /linked scripts. </li><li>For external scripts enter the script URL in the text box provided. </li><li>Valid link will attach the external script to the page. </li></ol>
<p>The following image is the screenshot.</p>
<p><img src="/site/view/file/54338/1/image001.png" alt="" width="798" height="504"></p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>1) The &ldquo;Default.aspx&rdquo; page contains a JavaScript method for calling the web method from the &ldquo;Service1.svc&rdquo;.</p>
<p>2) We use the &ldquo;$.ajax()&rdquo; method from JQuery to asynchronously call the web method.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function LoadAndExecuteDynamicJS(src1) {
    
    $.ajax({
        type: &quot;POST&quot;,
        url: &quot;Service1.svc/LoadScript&quot;,
        data: JSON.stringify({ source: src1 }),
        contentType: &quot;application/json; charset=utf-8&quot;,
        dataType: &quot;json&quot;,
        success: function (msg) {
            $(&quot;head&quot;).append($(&quot;&lt;script type='text/javascript' /&gt;&quot;).attr(&quot;src&quot;, msg.d));
            alert('Script loaded');
        }
    });
}
</pre>
<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;LoadAndExecuteDynamicJS(src1)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;Service1.svc/LoadScript&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;JSON.stringify(<span class="js__brace">{</span>&nbsp;source:&nbsp;src1&nbsp;<span class="js__brace">}</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json;&nbsp;charset=utf-8&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">&quot;json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(msg)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;head&quot;</span>).append($(<span class="js__string">&quot;&lt;script&nbsp;type='text/javascript'&nbsp;/&gt;&quot;</span>).attr(<span class="js__string">&quot;src&quot;</span>,&nbsp;msg.d));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">'Script&nbsp;loaded'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">3) The parameter to the service is the name of the script that is to be linked on demand.</div>
<p>4) We call the &ldquo;Hello()&rdquo; method from the dynamically loaded script as usual JavaScript method.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
