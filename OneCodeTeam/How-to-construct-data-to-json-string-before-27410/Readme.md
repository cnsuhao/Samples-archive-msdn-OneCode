# How to construct data to json string before posting to pagemethod using jQuery
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* construct  complex data to serialization
## IsPublished
* True
## ModifiedDate
* 2014-03-06 07:45:04
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><span lang="EN-US">Transfer data use Json string (CSASPNETUseJsonString)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal"><span lang="EN-US">Transfer data use Json is a general question, when you use asp.net mvc, you many need to use Jquery grid view control, then you need to transfer the data to this grid view control and get the data back use Json. You
 can find the answers for all the following questions in the code sample:</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">How to construct Json string use Jquery.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">How to get Json data and deserialize it to class.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">You must run this code sample on Windows XP or newer operating systems.</span></p>
<p class="MsoNormal"><span lang="EN-US">First open the solution file, then build the whole solution, the project will auto download json.net class library from nugget.</span></p>
<p class="MsoNormal"><span lang="EN-US">The JSON <span class="SpellE">serializer</span> is a good choice when the JSON you are reading or writing maps closely to a .NET class.
</span></p>
<p class="MsoNormal"><span lang="EN-US">LINQ to JSON is good for situations where you are only interested in getting values from JSON, you don't have a class to serialize or
<span class="SpellE">deserialize</span> to, or the JSON is radically different from your class and you need to manually read and write from your objects.
</span></p>
<p class="MsoNormal"><span lang="EN-US">Download Json.NET from <span class="SpellE">
CodePlex</span> or install using&nbsp;</span><span class="SpellE"><span lang="EN-US" style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#253340"><a href="http://nuget.org/packages/Newtonsoft.Json" target="_blank"><span style="color:#2e8bcc">NuGet</span></a></span></span><span lang="EN-US" style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#253340"><br>
<span><img src="/site/view/file/110043/1/image.png" alt="" width="576" height="68" align="middle">
</span></span></p>
<p class="MsoNormal"><span lang="EN-US">Then you can run the sample directly.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US">The code sample provides the following reusable functions.</span></p>
<h3><span lang="EN-US">How to construct Json string use Jquery?</span></h3>
<p><span lang="EN-US">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">&lt;script type=&quot;text/javascript&quot;&gt;
        var userInfos = [];
        function saveEntities() {
            var trs = $(&quot;#grid tbody tr&quot;);
            $(trs).each(function () {
                var userInfo = {
                    Name: $(this).children().first().text(),
                    Email: $(this).children().last().text()
                }
                userInfos.push(userInfo);
            });
            var json = JSON.stringify(userInfos);
            alert('Start to transfer data:'&#43;json);
            $.ajax({
                type: &quot;POST&quot;,
                contentType: &quot;application/json&quot;,
                data: &quot;{'data':'&quot; &#43; json &#43; &quot;'}&quot;,
                url: &quot;Home/saveUserInfos&quot;,
                dataType: &quot;json&quot;,
                success: function (xhr) { alert(xhr); },
                error: function (xhr) { alert(xhr); }
            });
        }
    &lt;/script&gt;
</pre>
<div class="preview">
<pre class="js">&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;userInfos&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;saveEntities()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;trs&nbsp;=&nbsp;$(<span class="js__string">&quot;#grid&nbsp;tbody&nbsp;tr&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(trs).each(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;userInfo&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:&nbsp;$(<span class="js__operator">this</span>).children().first().text(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email:&nbsp;$(<span class="js__operator">this</span>).children().last().text()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;userInfos.push(userInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;json&nbsp;=&nbsp;JSON.stringify(userInfos);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">'Start&nbsp;to&nbsp;transfer&nbsp;data:'</span>&#43;json);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__string">&quot;{'data':'&quot;</span>&nbsp;&#43;&nbsp;json&nbsp;&#43;&nbsp;<span class="js__string">&quot;'}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;Home/saveUserInfos&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">&quot;json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(xhr)&nbsp;<span class="js__brace">{</span>&nbsp;alert(xhr);&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(xhr)&nbsp;<span class="js__brace">{</span>&nbsp;alert(xhr);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<p class="MsoNormal"><span lang="EN-US">The function get all the data from grid view control, convert it to json string, and then use Ajax post the json string to the server side.</span></p>
<p class="MsoNormal"><span lang="EN-US">It will post the JSON format data to Home controller.<br>
</span></p>
<h3>How to get Json data and deserialize it to class?</h3>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[HttpPost]
       public ActionResult saveUserInfos(string data)
       {
           try
           {
               var userInfoList = JsonConvert.DeserializeObject&lt;IEnumerable&lt;UserInfo&gt;&gt;(data);
               //Save these data to Your DB

               return Json(&quot;Success&quot;);
           }
           catch (JsonReaderException e)
           {

               return Json(e.Message);
           }
       }
</pre>
<div class="preview">
<pre class="csharp">[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;saveUserInfos(<span class="cs__keyword">string</span>&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;userInfoList&nbsp;=&nbsp;JsonConvert.DeserializeObject&lt;IEnumerable&lt;UserInfo&gt;&gt;(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;these&nbsp;data&nbsp;to&nbsp;Your&nbsp;DB</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__string">&quot;Success&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(JsonReaderException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(e.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<p class="MsoNormal"><span lang="EN-US">The function use json.net <span class="SpellE">
deserialize</span> the JSON <span class="SpellE">formate</span> string to <span class="SpellE">
UserInfo</span> class library.</span></p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US"><a href="msdn.microsoft.com/en-us/library/bb410770(v=vs.110).aspx">MSDN: JSON Serialization</a></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US"><a href="http://json.codeplex.com/">Json.Net</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
