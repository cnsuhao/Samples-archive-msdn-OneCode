# How to consume SOAP Web Service from Metro App by using JavaScript
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Metro App
* SOAP Web Service
## IsPublished
* True
## ModifiedDate
* 2014-02-25 01:54:21
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to consume SOAP Web Service from Windows Store App by using <span class="SpellE">
WinJS.xhr</span> (<span class="SpellE">JSWindowsStoreAppCallSOAPWebService</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The sample demonstrates how to consume SOAP Web Service by using WinJS.xhr. When the app launched, please enter the ZIP code in textbox, and then click
 &quot;Go&quot; button to get the weather information. </span></h2>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 or F5 to run the project.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span>the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/109372/1/image.png" alt="" width="576" height="360" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Please enter a valid Zip code and click 'Go' button to get the weather as below:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/109373/1/image.png" alt="" width="576" height="362" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>If you enter an invalid Zip code and click 'Go' button, you will receive error message.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The <span>following </span>code <span>snippet</span> <span>
shows the HTML UI. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;div id=&quot;rootGrid&quot;&gt;
   &lt;div id=&quot;title&quot;&gt;
       &lt;p class=&quot;AppLogo&quot;&gt;Windows Store Code Samples by All-In-One Code Framework&lt;/p&gt;
       &lt;p class=&quot;AppName&quot;&gt;consume SOAP Web Service from Metro App by using WinJS.xhr&lt;/p&gt;
       &lt;p class=&quot;AppDescription&quot;&gt;This sample demonstrates how to consume SOAP Web Service by using WinJS.xhr. When the app launched, please enter the ZIP code in textbox, and then click &quot;Go&quot; button to get the weather.&lt;/p&gt;
   &lt;/div&gt;

   &lt;div id=&quot;content&quot;&gt;
       &lt;div id=&quot;input&quot;&gt;
           &lt;div class=&quot;Head&quot;&gt;The Weather&lt;/div&gt; 
           &lt;div class=&quot;message&quot;&gt;Enter the zip code (U.S. only, e.g. 98052)&lt;/div&gt;
           &lt;input id=&quot;txbinputZipCode&quot; type=&quot;text&quot; /&gt; 
           &lt;button id=&quot;gobtn&quot;&gt;Go&lt;/button&gt;    
        &lt;/div&gt; 

       &lt;div id=&quot;error&quot;&gt;
               
        &lt;/div&gt;

       &lt;div id=&quot;output&quot;&gt;
           &lt;span id=&quot;SpanResult&quot;&gt;&lt;/span&gt;
       &lt;/div&gt;
   &lt;/div&gt;

   &lt;div id=&quot;footer&quot;&gt;
       &lt;div&gt;
           &lt;img src=&quot;/images/microsoft.png&quot;/&gt;&lt;br/&gt;
       &lt;/div&gt;        
       &lt;div id=&quot;company&quot;&gt;&Acirc;&copy; 2013 Microsoft Corporation. All rights reserved.
       &lt;a href=&quot;http://blogs.msdn.com/b/onecode&quot;&gt;All-In-One Code Framework&lt;/a&gt;
       &lt;/div&gt;
   &lt;/div&gt;
   &lt;/div&gt;
</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;rootGrid&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;title&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;AppLogo&quot;</span><span class="html__tag_start">&gt;</span>Windows&nbsp;Store&nbsp;Code&nbsp;Samples&nbsp;by&nbsp;All-In-One&nbsp;Code&nbsp;Framework<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;AppName&quot;</span><span class="html__tag_start">&gt;</span>consume&nbsp;SOAP&nbsp;Web&nbsp;Service&nbsp;from&nbsp;Metro&nbsp;App&nbsp;by&nbsp;using&nbsp;WinJS.xhr<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;AppDescription&quot;</span><span class="html__tag_start">&gt;</span>This&nbsp;sample&nbsp;demonstrates&nbsp;how&nbsp;to&nbsp;consume&nbsp;SOAP&nbsp;Web&nbsp;Service&nbsp;by&nbsp;using&nbsp;WinJS.xhr.&nbsp;When&nbsp;the&nbsp;app&nbsp;launched,&nbsp;please&nbsp;enter&nbsp;the&nbsp;ZIP&nbsp;code&nbsp;in&nbsp;textbox,&nbsp;and&nbsp;then&nbsp;click&nbsp;&quot;Go&quot;&nbsp;button&nbsp;to&nbsp;get&nbsp;the&nbsp;weather.<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;content&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;input&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;Head&quot;</span><span class="html__tag_start">&gt;</span>The&nbsp;Weather<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;message&quot;</span><span class="html__tag_start">&gt;</span>Enter&nbsp;the&nbsp;zip&nbsp;code&nbsp;(U.S.&nbsp;only,&nbsp;e.g.&nbsp;98052)<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;txbinputZipCode&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;gobtn&quot;</span><span class="html__tag_start">&gt;</span>Go<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;error&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;output&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;SpanResult&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;footer&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;/images/microsoft.png&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;br</span><span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;company&quot;</span><span class="html__tag_start">&gt;&Acirc;</span>&copy;&nbsp;2013&nbsp;Microsoft&nbsp;Corporation.&nbsp;All&nbsp;rights&nbsp;reserved.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;a</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;http://blogs.msdn.com/b/onecode&quot;</span><span class="html__tag_start">&gt;</span>All-In-One&nbsp;Code&nbsp;Framework<span class="html__tag_end">&lt;/a&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<p class="MsoNormal"><a name="OLE_LINK1"></a><a name="OLE_LINK2"><span>The </span>
</a><span><span><span>following </span>code</span></span><span> snippet shows how to use WinJS.xhr toconsume JSON Web Service.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// Go button click event handler
    function goButtonClick() {     
        // retrieve element
        var zipCode =document.getElementById('txbinputZipCode').value.trim();
        var resultSpan = document.getElementById('SpanResult');

        // Clear Result message
        resultSpan.innerHTML = &quot;&quot;;

        // Validate input number
        if (zipCode == &quot;&quot;) {
            writeError(&quot;Error: please input ZIP Code first.&quot;);
            return;
        }
        else if (isNaN(zipCode)) {
            writeError(&quot;Error: Zip Code must be numer&quot;);
            document.getElementById('txbinputZipCode').value = &quot;&quot;;
            return;
        }

        // Clear error message
        document.getElementById(&quot;error&quot;).innerText = &quot;&quot;;

        WinJS.xhr({
            type: &quot;post&quot;,
            url: &quot;http://wsf.cdyne.com/WeatherWS/Weather.asmx/GetCityWeatherByZIP&quot;,
            data: 'ZIP=' &#43; zipCode,
            headers: { &quot;Content-type&quot;: &quot;application/x-www-form-urlencoded&quot; },
        }).then(function (r) {
           
            var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDoc.loadXml(r.responseText);
          
            for (var i = 0; i &lt; xmlDoc.documentElement.childNodes.length; i&#43;&#43;)
            {
                var statenode;
                var node =xmlDoc.documentElement.childNodes[i];
                switch (xmlDoc.documentElement.childNodes[i].nodeName) {
                    case &quot;Success&quot;:
                        if (node.innerText == &quot;false&quot;) {
                            resultSpan.innerHTML &#43;= &quot;&lt;div style='font-size:28px'&gt;City could not be found in our weather data. Please use ZIp Code in U.S&lt;/div&gt;&quot;
                            return;
                        }
                    case &quot;State&quot;:
                        statenode = xmlDoc.documentElement.childNodes[i];
                        break;
                    case &quot;City&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div style='font-size:36px'&gt;&quot; &#43; node.innerText &#43; &quot;,&quot; &#43; statenode.innerText &#43; &quot;&lt;/div&gt;&quot;;
                        break;                
                    case &quot;Description&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div&gt;Conditions - &quot; &#43; node.innerText &#43; &quot;&lt;/div&gt;&quot;;
                        break;
                    case &quot;Temperature&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div&gt;Temperature - &quot; &#43; node.innerText &#43; &quot;F&lt;/div&gt;&quot;;
                        break;
                    case &quot;RelativeHumidity&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div&gt;Relative Humidity - &quot; &#43; node.innerText &#43; &quot;&lt;/div&gt;&quot;;
                        break;
                    case &quot;Wind&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div&gt;Wind - &quot; &#43; node.innerText &#43; &quot;&lt;/div&gt;&quot;;
                        break;
                    case &quot;Pressure&quot;:
                        resultSpan.innerHTML &#43;= &quot;&lt;div&gt;Pressure - &quot; &#43; node.innerText &#43; &quot;&lt;/div&gt;&quot;;
                        break;
                }
            }
        });
    }
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Go&nbsp;button&nbsp;click&nbsp;event&nbsp;handler</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;goButtonClick()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;retrieve&nbsp;element</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;zipCode&nbsp;=document.getElementById(<span class="js__string">'txbinputZipCode'</span>).value.trim();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;resultSpan&nbsp;=&nbsp;document.getElementById(<span class="js__string">'SpanResult'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Clear&nbsp;Result&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Validate&nbsp;input&nbsp;number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(zipCode&nbsp;==&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writeError(<span class="js__string">&quot;Error:&nbsp;please&nbsp;input&nbsp;ZIP&nbsp;Code&nbsp;first.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__function">isNaN</span>(zipCode))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writeError(<span class="js__string">&quot;Error:&nbsp;Zip&nbsp;Code&nbsp;must&nbsp;be&nbsp;numer&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'txbinputZipCode'</span>).value&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Clear&nbsp;error&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">&quot;error&quot;</span>).innerText&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WinJS.xhr(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;post&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;http://wsf.cdyne.com/WeatherWS/Weather.asmx/GetCityWeatherByZIP&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__string">'ZIP='</span>&nbsp;&#43;&nbsp;zipCode,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Content-type&quot;</span>:&nbsp;<span class="js__string">&quot;application/x-www-form-urlencoded&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).then(<span class="js__operator">function</span>&nbsp;(r)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;xmlDoc&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Windows.Data.Xml.Dom.XmlDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc.loadXml(r.responseText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;xmlDoc.documentElement.childNodes.length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;statenode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;node&nbsp;=xmlDoc.documentElement.childNodes[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">switch</span>&nbsp;(xmlDoc.documentElement.childNodes[i].nodeName)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Success&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(node.innerText&nbsp;==&nbsp;<span class="js__string">&quot;false&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&nbsp;style='font-size:28px'&gt;City&nbsp;could&nbsp;not&nbsp;be&nbsp;found&nbsp;in&nbsp;our&nbsp;weather&nbsp;data.&nbsp;Please&nbsp;use&nbsp;ZIp&nbsp;Code&nbsp;in&nbsp;U.S&lt;/div&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;State&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;statenode&nbsp;=&nbsp;xmlDoc.documentElement.childNodes[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;City&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&nbsp;style='font-size:36px'&gt;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&quot;</span>&nbsp;&#43;&nbsp;statenode.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Description&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&gt;Conditions&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Temperature&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&gt;Temperature&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;F&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;RelativeHumidity&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&gt;Relative&nbsp;Humidity&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Wind&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&gt;Wind&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;<span class="js__string">&quot;Pressure&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultSpan.innerHTML&nbsp;&#43;=&nbsp;<span class="js__string">&quot;&lt;div&gt;Pressure&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;node.innerText&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information<span> </span></h2>
<p class="MsoNormal"><span>WinJS.xhr function </span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br229787.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br229787.aspx</a></p>
<p class="MsoNormal">Connecting to web services (Windows Store apps using JavaScript and HTML)</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh761502.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh761502.aspx</a><span>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
