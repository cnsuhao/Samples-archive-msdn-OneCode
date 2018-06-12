# Load javascript resources on demand (VBASPNETLoadAndExecuteDynamicJS)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* ASP.NET
* Javascript
## IsPublished
* True
## ModifiedDate
* 2012-04-20 01:12:02
## Description

<h1>The sample demonstrates how JavaScript resources can be loaded on-demand.<span style="">&nbsp;
</span>(VBASPNETLoadAndExecuteDynamicJS)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how JavaScript resources can be loaded on-demand. The JavaScript file is linked to the page via an Asynchronous web service call which returns the relative location of the JS on the server file and links it to
 the current page through JavaScript.</p>
<h2>Building the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Add a SVC (Ajax enabled web service [WCF]) to the project.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Add a ScriptManager Object to the Default.aspx page for asynchronously calling the method in the WCF service.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>We call the method in WCF service asynchronously using the &quot;$.Ajax()&quot; method in JQuery.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>The result of the service call is the path to the script object on the server.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Server contains a folder named a &quot;Scripts&quot; which is only known to the WCF service.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>We add the &quot;Source&quot; of the JavaScript to the string that is returned as relative path from the web service.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Add a Web Service to the project.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Add a ScriptManager Object to the Default2.aspx page for asynchronously calling the method in the Web Service.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span>Step 9:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp; </span></span></span>Use the following JavaScript syntax to call the Web Service:<span style="">&nbsp;
</span>[NameSpace].[ClassName].[MethodName](param1, param2 ......, callbackFunction), then specify the callback function for the client-side asynchronous calls.</p>
<p class="MsoListParagraphCxSpLast"><b style="">[For sample]</b> we just have a &quot;alert()&quot; in the dynamic script that is loaded and executed.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the ��VBASPNETLoadAndExecuteDynamicJS.sln��.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Run the sample.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Click the ��Load Script stored on Internal Server�� button.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>This will attach the script on-demand to the page.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Click the ��Call Script stored on Internal Server�� button.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>This will call the method from the dynamically loaded /linked scripts.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>For external scripts enter the script URL in the text box provided.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:40.5pt; text-indent:-.5in">
<span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Valid link will attach the external script to the page.</p>
<p class="MsoNormal" style="margin-left:.25in">The following image is the screenshot.</p>
<p class="MsoNormal" style="margin-left:.25in"><span style=""><img src="/site/view/file/56413/1/image.png" alt="" width="662" height="278" align="middle">
<img src="/site/view/file/56414/1/image.png" alt="" width="554" height="270" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.5in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>The ��Default.aspx�� page contains a JavaScript method for calling the web method from the ��Service1.svc��.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.5in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>We use the ��$.ajax()�� method from JQuery to asynchronously call the web method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function LoadAndExecuteDynamicJS(src1) {
         
         $.ajax({
             type: &quot;POST&quot;,
             url: &quot;Service1.svc/LoadScript&quot;,
             data: JSON.stringify({ source: src1 }),
             contentType: &quot;application/json; charset=utf-8&quot;,
             dataType: &quot;json&quot;,
             success: function (msg) {
                 $(&quot;head&quot;).append($(&quot;&lt;script type='text/javascript' /&gt;&quot;).attr(&quot;src&quot;, msg.d));
                 alert('Script loaded');


                 // Do something interesting here.
             }
         });
     }

</pre>
<pre id="codePreview" class="js">
function LoadAndExecuteDynamicJS(src1) {
         
         $.ajax({
             type: &quot;POST&quot;,
             url: &quot;Service1.svc/LoadScript&quot;,
             data: JSON.stringify({ source: src1 }),
             contentType: &quot;application/json; charset=utf-8&quot;,
             dataType: &quot;json&quot;,
             success: function (msg) {
                 $(&quot;head&quot;).append($(&quot;&lt;script type='text/javascript' /&gt;&quot;).attr(&quot;src&quot;, msg.d));
                 alert('Script loaded');


                 // Do something interesting here.
             }
         });
     }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.5in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>The parameter to the service is the name of the script that is to be linked on demand.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>We call the ��Hello()�� method from the dynamically loaded script as usual JavaScript method.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.5in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>The ��Default2.aspx�� page contains a JavaScript method for calling the web method from the ��WebService1.asmx��.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.5in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>We use the following JavaScript syntax to call the Web Service: [NameSpace].[ClassName].[MethodName](param1, param2 ......, callbackFunction)</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function LoadAndExecuteDynamicJS(src1) {
           var wsp = VBLoadAndExecuteDynamicJS.WebService1;
           wsp.LoadScript(src1, CallBackFunction);
       }

</pre>
<pre id="codePreview" class="js">
function LoadAndExecuteDynamicJS(src1) {
           var wsp = VBLoadAndExecuteDynamicJS.WebService1;
           wsp.LoadScript(src1, CallBackFunction);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.5in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Specify the callback function for the client-side asynchronous calls. To receive the return value and further processing in the callback function.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function CallBackFunction(result) {
           $(&quot;head&quot;).append($(&quot;&lt;script type='text/javascript' /&gt;&quot;).attr(&quot;src&quot;, result));
           alert('Script loaded');
           // Do something interesting here.
       }

</pre>
<pre id="codePreview" class="js">
function CallBackFunction(result) {
           $(&quot;head&quot;).append($(&quot;&lt;script type='text/javascript' /&gt;&quot;).attr(&quot;src&quot;, result));
           alert('Script loaded');
           // Do something interesting here.
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
