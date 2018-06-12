# How to access data from SQL Server database in Windows Store app
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* App-Entwicklung für Windows
## Topics
* WinJS
* access data from SQL server
* Zugriff auf Daten aus SQL Server
## IsPublished
* True
## ModifiedDate
* 2015-02-13 12:41:16
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><span>How to access data from SQL Server database in Windows Store app (<span class="SpellE">JSWindowsStoreAppAccessSQLServer</span>)
</span></h1>
<h2><span>Introduction </span></h2>
<p class="MsoNormal">​The sample demonstrates how to access data from SQL Server database in Windows Store app. We cannot access SQL Server Database from Windows Store app directly. We have to create
<span class="GramE">an</span> Service layer to access the database.</p>
<h2><span>Build the Sample </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Start Visual Studio 2013 and select File &gt; Open &gt; Project/Solution.
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution (.<span class="SpellE">sln</span>) file.
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Press F7 or use Build &gt; Build Solution to build the sample.
</span></p>
<h2><span>Running the Sample </span></h2>
<p class="MsoNormal" style="margin-left:.5in"><span><img src="/site/view/file/109954/1/image.png" alt="" width="576" height="325" align="middle">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Click '<span class="SpellE">GetData</span>' button to get result from a web service, you will see the following result.
</span></p>
<p class="MsoListParagraph"><span><img src="/site/view/file/109955/1/image.png" alt="" width="576" height="326" align="middle">
</span></p>
<h2><span>Using the Code </span></h2>
<p class="MsoNormal"><span>1. Create a Windows Store app project by using Visual Studio 2013.
</span></p>
<p class="MsoNormal"><span>2. Add WCF Service Application project to the solution.
</span></p>
<p class="MsoNormal"><span>3. Create a WCF service with the following code snippet.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceContract]
    public interface IService
    {
        // Daten abfragen
        [OperationContract]
        DataSet querySql();
    }
public class Service : IService
    {
        /// &lt;summary&gt;
        /// Daten aus TestTable abfragen
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        
        SqlConnection sqlCon = new SqlConnection(&quot;Data Source=(local);Initial Catalog=Test;Integrated Security =SSPI;&quot;);
        public DataSet querySql()
        {
            try
            {
                sqlCon.Open();
                string strSql = &quot;select Title, Text from TestTable&quot;;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDa = new SqlDataAdapter(strSql,sqlCon);
                sqlDa.Fill(ds);
                return ds;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
</pre>
<div class="preview">
<pre class="csharp">[ServiceContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Daten&nbsp;abfragen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;querySql();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Service&nbsp;:&nbsp;IService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Daten&nbsp;aus&nbsp;TestTable&nbsp;abfragen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;sqlCon&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(<span class="cs__string">&quot;Data&nbsp;Source=(local);Initial&nbsp;Catalog=Test;Integrated&nbsp;Security&nbsp;=SSPI;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataSet&nbsp;querySql()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCon.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strSql&nbsp;=&nbsp;<span class="cs__string">&quot;select&nbsp;Title,&nbsp;Text&nbsp;from&nbsp;TestTable&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;ds&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataAdapter&nbsp;sqlDa&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDataAdapter(strSql,sqlCon);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlDa.Fill(ds);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ds;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCon.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:10px">4. Insert the following JavaScript code snippet to handle the click event of the &quot;</span><span class="SpellE" style="font-size:10px">GetData</span><span style="font-size:10px">&quot; button.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">// Ereignishandler der Schaltfl&auml;che GetData 
   function getDatabuttonclick()
   {
       // Fehlermeldung l&ouml;schen 
       document.getElementById('error').innerText = &quot;&quot;;
       document.getElementById('getdatabtn').style.setAttribute(&quot;disabled&quot;, &quot;disabled&quot;);
       var baseURI = &quot;http://localhost:42920/Service.svc/querySql&quot;;
       var xmlDoc;
       WinJS.xhr({
           type:&quot;get&quot;,
           url: baseURI
       }).then(function (response) {
           if (eval('(' &#43; response.responseText &#43; ')').queryParam == true) {
               var items = [];
               var resulttxt = eval('(' &#43; response.responseText &#43; ')').querySqlResult;               
               if (window.DOMParser) {
                   var parser = new DOMParser();
                   xmlDoc = parser.parseFromString(resulttxt, &quot;text/xml&quot;);
                  
               }
               else {// Internet Explorer
                   xmlDoc = new ActiveXObject(&quot;Microsoft.XMLDOM&quot;);
                   xmlDoc.async = false;
                   xmlDoc.loadXML(resulttxt);
               }
               var nodes = xmlDoc.querySelectorAll(&quot;Table&quot;);
               
               for (var i = 0; i &lt; nodes.length; i&#43;&#43;)
               {
                   var item =new Object();
                   item.Title=nodes[i].childNodes[0].textContent;
                   item.Text =nodes[i].childNodes[1].textContent;
                   items.push(item);
               }


               var list = new WinJS.Binding.List(items);
               document.getElementById('listView').winControl.itemDataSource = list.dataSource;
               document.getElementById('getdatabtn').removeAttribute(&quot;disabled&quot;);
           }
           else {
               writeError(&quot;Error occurs. Please make sure the database has been attached to SQL Server!&quot;);
           }
       });
   }</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Ereignishandler&nbsp;der&nbsp;Schaltfl&auml;che&nbsp;GetData&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getDatabuttonclick()&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Fehlermeldung&nbsp;l&ouml;schen&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'error'</span>).innerText&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'getdatabtn'</span>).style.setAttribute(<span class="js__string">&quot;disabled&quot;</span>,&nbsp;<span class="js__string">&quot;disabled&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;baseURI&nbsp;=&nbsp;<span class="js__string">&quot;http://localhost:42920/Service.svc/querySql&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;xmlDoc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WinJS.xhr(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:<span class="js__string">&quot;get&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;baseURI&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).then(<span class="js__operator">function</span>&nbsp;(response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__function">eval</span>(<span class="js__string">'('</span>&nbsp;&#43;&nbsp;response.responseText&nbsp;&#43;&nbsp;<span class="js__string">')'</span>).queryParam&nbsp;==&nbsp;true)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;items&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;resulttxt&nbsp;=&nbsp;<span class="js__function">eval</span>(<span class="js__string">'('</span>&nbsp;&#43;&nbsp;response.responseText&nbsp;&#43;&nbsp;<span class="js__string">')'</span>).querySqlResult;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(window.DOMParser)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;parser&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DOMParser();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc&nbsp;=&nbsp;parser.parseFromString(resulttxt,&nbsp;<span class="js__string">&quot;text/xml&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Internet&nbsp;Explorer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ActiveXObject(<span class="js__string">&quot;Microsoft.XMLDOM&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc.async&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDoc.loadXML(resulttxt);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;nodes&nbsp;=&nbsp;xmlDoc.querySelectorAll(<span class="js__string">&quot;Table&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;nodes.length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item&nbsp;=<span class="js__operator">new</span>&nbsp;<span class="js__object">Object</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.Title=nodes[i].childNodes[<span class="js__num">0</span>].textContent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.Text&nbsp;=nodes[i].childNodes[<span class="js__num">1</span>].textContent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.push(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;list&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;WinJS.Binding.List(items);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'listView'</span>).winControl.itemDataSource&nbsp;=&nbsp;list.dataSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'getdatabtn'</span>).removeAttribute(<span class="js__string">&quot;disabled&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writeError(<span class="js__string">&quot;Error&nbsp;occurs.&nbsp;Please&nbsp;make&nbsp;sure&nbsp;the&nbsp;database&nbsp;has&nbsp;been&nbsp;attached&nbsp;to&nbsp;SQL&nbsp;Server!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2><span>More Information </span></h2>
<p class="MsoNormal"><span>&nbsp;</span><span class="SpellE"><span class="GramE">parseFromString</span></span> method:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh770806.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh770806.aspx</a></p>
<p class="MsoNormal"><span class="SpellE">WinJS.UI.ListView</span> object:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx#properties">http://msdn.microsoft.com/en-us/library/windows/apps/br211837.aspx#properties</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
