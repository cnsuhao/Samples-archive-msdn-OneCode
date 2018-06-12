# Get desired result by AJAX calls (VBASPNETGetDesiredResultByAJAXCalls)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* AJAX
* ASP.NET
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:45:46
## Description

<h1><span style="">How to use Render event in ASP.NET page to return desired text results
</span>(<span class="SpellE"><span style="">VBASPNETGetDesiredResultByAJAXCalls</span></span>)
</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to use Render event in ASP.NET page's life cycle to return desired text results. Normally, developers may use Web Services, WCF services, ASHX generic handlers, static page methods or other methods to
 handle AJAX calls. These utilities are designed to meet requirements of specific purpose. Sometimes developers may need a simple and flexible way; so as to they can design their own format of data as the response to request. Some developers may use
<span class="SpellE">Response.Write</span> Method; they want to print out the string that is passed as the argument. But all they get is the long text with unwanted markups. This sample shows how to use built-in methods in page's life cycle to achieve this
 goal. It does not require other knowledge of components in ASP.NET. It also helps developers not coming from the ASP.NET world to understand how an
<span class="SpellE">aspx</span> page is designed to work.</p>
<h2>Running the Sample </h2>
<p class="MsoNormal">Please follow these demonstration steps below. </p>
<p class="MsoNormal">Step 1: Open the VBASPNETGetDesiredResultByAJAXCalls.sln. </p>
<p class="MsoNormal">Step 2: Right click Default.aspx and choose &quot;View in Browser&quot;.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><img src="/site/view/file/62025/1/image.png" alt="" width="455" height="123" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 3: Choose an item in drop-down list then click the button. You can also enter text to test output the specified text.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><img src="/site/view/file/62026/1/image.png" alt="" width="603" height="194" align="middle">
<img src="/site/view/file/62027/1/image.png" alt="" width="311" height="98" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 4: Validation finished. </p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>
</p>
<p class="MsoNormal"><span class="GramE">Step 1.</span> Create a VB.NET &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as &quot;<span class="SpellE">VBASPNETGetDesiredResultByAJAXCalls</span>&quot;.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE">Step 2.</span> Modify the Default page as the following.<span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
   You can enter some information:&lt;input type=&quot;text&quot; id=&quot;txt&quot; /&gt;<br>
   The type of data you need to return&lt;select id=&quot;drpType&quot;&gt;
       &lt;option value=&quot;1&quot;&gt;plain text&lt;/option&gt;
       &lt;option value=&quot;2&quot;&gt;JSON&lt;/option&gt;
       &lt;option value=&quot;3&quot;&gt;XML&lt;/option&gt;
   &lt;/select&gt;
   <br>
   &lt;input type=&quot;button&quot; value=&quot;Ajax Request&quot; onclick=&quot;AjaxRequest();&quot; /&gt;
   <hr>
   <div id="result">
   </div>
   &lt;/form&gt;

</pre>
<pre id="codePreview" class="html">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
   You can enter some information:&lt;input type=&quot;text&quot; id=&quot;txt&quot; /&gt;<br>
   The type of data you need to return&lt;select id=&quot;drpType&quot;&gt;
       &lt;option value=&quot;1&quot;&gt;plain text&lt;/option&gt;
       &lt;option value=&quot;2&quot;&gt;JSON&lt;/option&gt;
       &lt;option value=&quot;3&quot;&gt;XML&lt;/option&gt;
   &lt;/select&gt;
   <br>
   &lt;input type=&quot;button&quot; value=&quot;Ajax Request&quot; onclick=&quot;AjaxRequest();&quot; /&gt;
   <hr>
   <div id="result">
   </div>
   &lt;/form&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="GramE">Step 3.</span> Create an instance of
<span class="SpellE">XMLHttpRequest</span>. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
var xmlHttp;
     function createXMLHttpRequest() {
         if (window.ActiveXObject) {
             xmlHttp = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);
         }
         else if (window.XMLHttpRequest) {
             xmlHttp = new XMLHttpRequest();
         }
     }

</pre>
<pre id="codePreview" class="js">
var xmlHttp;
     function createXMLHttpRequest() {
         if (window.ActiveXObject) {
             xmlHttp = new ActiveXObject(&quot;Microsoft.XMLHTTP&quot;);
         }
         else if (window.XMLHttpRequest) {
             xmlHttp = new XMLHttpRequest();
         }
     }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Create the Callback method<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
//Callback method 
function onSuccessCallBack() {
    if (xmlHttp.readyState == 4) //4 represent Complete 
    {
        if (xmlHttp.status == 200) {
            switch (document.getElementById(&quot;drpType&quot;).value) {
                case &quot;1&quot;: //For plain text
                    document.getElementById(&quot;result&quot;).innerHTML = xmlHttp.responseText;
                    break;
                case &quot;2&quot;: //For JSON
                    var result = xmlHttp.responseText;
                    var json = eval(&quot;(&quot; &#43; result &#43; &quot;)&quot;);
                    alert(json.hello);
                    alert(json.face);
                    break;
                case &quot;3&quot;: //For XML                             
                    // Get XML DOM object
                    var xmlDOM = xmlHttp.responseXML;
                    // Obtain the root of the XML document
                    var xmlRoot = xmlDOM.documentElement;
                    try {
                        var xmlItem = xmlRoot.getElementsByTagName(&quot;hello&quot;);
                        alert(&quot;responseXML's value: &quot; &#43; xmlItem[0].firstChild.data);
                        var xmlItem = xmlRoot.getElementsByTagName(&quot;world&quot;);
                        alert(&quot;responseXML's value: &quot; &#43; xmlItem[0].firstChild.data);
                    }
                    catch (e) {
                        alert(e.message);
                    }
                    break;
                default:
            }
        }
    }
} 

</pre>
<pre id="codePreview" class="js">
//Callback method 
function onSuccessCallBack() {
    if (xmlHttp.readyState == 4) //4 represent Complete 
    {
        if (xmlHttp.status == 200) {
            switch (document.getElementById(&quot;drpType&quot;).value) {
                case &quot;1&quot;: //For plain text
                    document.getElementById(&quot;result&quot;).innerHTML = xmlHttp.responseText;
                    break;
                case &quot;2&quot;: //For JSON
                    var result = xmlHttp.responseText;
                    var json = eval(&quot;(&quot; &#43; result &#43; &quot;)&quot;);
                    alert(json.hello);
                    alert(json.face);
                    break;
                case &quot;3&quot;: //For XML                             
                    // Get XML DOM object
                    var xmlDOM = xmlHttp.responseXML;
                    // Obtain the root of the XML document
                    var xmlRoot = xmlDOM.documentElement;
                    try {
                        var xmlItem = xmlRoot.getElementsByTagName(&quot;hello&quot;);
                        alert(&quot;responseXML's value: &quot; &#43; xmlItem[0].firstChild.data);
                        var xmlItem = xmlRoot.getElementsByTagName(&quot;world&quot;);
                        alert(&quot;responseXML's value: &quot; &#43; xmlItem[0].firstChild.data);
                    }
                    catch (e) {
                        alert(e.message);
                    }
                    break;
                default:
            }
        }
    }
} 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Create the Deal method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
     //Deal method 
     function AjaxRequest() {
         createXMLHttpRequest();
         var url = &quot;example.aspx?str=&quot; &#43; document.getElementById(&quot;txt&quot;).value &#43; &quot;&type=&quot; &#43; document.getElementById(&quot;drpType&quot;).value;
         xmlHttp.open(&quot;GET&quot;, url, false);
         xmlHttp.onreadystatechange = onSuccessCallBack;
         xmlHttp.send(null);
     }
     } 

</pre>
<pre id="codePreview" class="js">
     //Deal method 
     function AjaxRequest() {
         createXMLHttpRequest();
         var url = &quot;example.aspx?str=&quot; &#43; document.getElementById(&quot;txt&quot;).value &#43; &quot;&type=&quot; &#43; document.getElementById(&quot;drpType&quot;).value;
         xmlHttp.open(&quot;GET&quot;, url, false);
         xmlHttp.onreadystatechange = onSuccessCallBack;
         xmlHttp.send(null);
     }
     } 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 4. Call the function in the button's onclick event.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;input type=&quot;button&quot; value=&quot;Ajax Request&quot; onclick=&quot;AjaxRequest();&quot; /&gt;

</pre>
<pre id="codePreview" class="html">
&lt;input type=&quot;button&quot; value=&quot;Ajax Request&quot; onclick=&quot;AjaxRequest();&quot; /&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 5. Add a new Web Form and name it as &quot;example.aspx&quot;.This ASPX page is used to handle the Ajax request and return data.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
       'Query String
       Dim strText As String = Request.QueryString(&quot;str&quot;)
       Dim type As String = Request.QueryString(&quot;type&quot;)
       'Output String
       Dim strOutput As String = String.Empty


       'Returns the appropriate data type by Query String
       Select Case type
           Case &quot;1&quot;
               'For plain text, &quot;hello world&quot; or some infomation you type
               If String.IsNullOrEmpty(strText) Then
                   strText = &quot;hello world&quot;
               End If
               strOutput = strText
               Exit Select
           Case &quot;2&quot;
               'For JSON, {&quot;hello&quot;: &quot;world&quot;}                    
               strOutput = &quot;{&quot;&quot;hello&quot;&quot;: &quot;&quot;world&quot;&quot;,&quot;&quot;face&quot;&quot;: &quot;&quot;smile&quot;&quot;}&quot;
               Exit Select
           Case &quot;3&quot;
               'For XML, &lt;hello&gt;Hello&lt;/hello&gt;&lt;world&gt;World&lt;/word&gt;
               strOutput = &quot;&lt;?xml version=&quot;&quot;1.0&quot;&quot; encoding=&quot;&quot;GB2312&quot;&quot;?&gt;&lt;root&gt;&lt;hello&gt;Hello&lt;/hello&gt;&lt;world&gt;World&lt;/world&gt;&lt;/root&gt;&quot;
               Exit Select
           Case Else
               Exit Select
       End Select
       'Set the HTTP MIME type of the output stream
       Response.ContentType = &quot;text/xml&quot;
       'Output stream
       output.Write(strOutput)
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
       'Query String
       Dim strText As String = Request.QueryString(&quot;str&quot;)
       Dim type As String = Request.QueryString(&quot;type&quot;)
       'Output String
       Dim strOutput As String = String.Empty


       'Returns the appropriate data type by Query String
       Select Case type
           Case &quot;1&quot;
               'For plain text, &quot;hello world&quot; or some infomation you type
               If String.IsNullOrEmpty(strText) Then
                   strText = &quot;hello world&quot;
               End If
               strOutput = strText
               Exit Select
           Case &quot;2&quot;
               'For JSON, {&quot;hello&quot;: &quot;world&quot;}                    
               strOutput = &quot;{&quot;&quot;hello&quot;&quot;: &quot;&quot;world&quot;&quot;,&quot;&quot;face&quot;&quot;: &quot;&quot;smile&quot;&quot;}&quot;
               Exit Select
           Case &quot;3&quot;
               'For XML, &lt;hello&gt;Hello&lt;/hello&gt;&lt;world&gt;World&lt;/word&gt;
               strOutput = &quot;&lt;?xml version=&quot;&quot;1.0&quot;&quot; encoding=&quot;&quot;GB2312&quot;&quot;?&gt;&lt;root&gt;&lt;hello&gt;Hello&lt;/hello&gt;&lt;world&gt;World&lt;/world&gt;&lt;/root&gt;&quot;
               Exit Select
           Case Else
               Exit Select
       End Select
       'Set the HTTP MIME type of the output stream
       Response.ContentType = &quot;text/xml&quot;
       'Output stream
       output.Write(strOutput)
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 6. Build the application and you can debug it.</p>
<p class="MsoNormal"><span class="Heading2Char"><span style="font-size:13.0pt; line-height:115%">More Information</span></span><br>
<span class="SpellE">Control.Render</span> Method<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.render(VS.80).aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.render(VS.80).aspx</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
