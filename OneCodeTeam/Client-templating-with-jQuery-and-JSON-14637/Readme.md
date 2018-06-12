# Client templating with jQuery and JSON (VBASPNETClientTemplateJQueryJSON)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* JSON
* jQuery
* jTemplate
## IsPublished
* True
## ModifiedDate
* 2012-03-01 07:02:32
## Description

<h1>Client templating with jQuery and JSON (VBASPNETClientTemplateJQueryJSON)</h1>
<h2>Summary</h2>
<div>This project illustrates how to display a tabular data to users based on some inputs in ASP.NET application. We will see how this can be addressed with JQuery and JSON to build a tabular data display in web page. Here we use JQuery plug-in JTemplate to
 make it easy.</div>
<h2>Demo</h2>
<div>Please follow these demonstration steps below.</div>
<div>Step 1: Open the VBASPNETClientTemplateJQueryJSON.sln.</div>
<div>Step 2: Expand the VBASPNETClientTemplateJQueryJSON web application and press&nbsp;Ctrl &#43; F5 to show the Default.aspx.</div>
<div>Step 3: You can find an HTML table on the Default.aspx page, the tabular data display by JQuery plug-in JTemplate.</div>
<h2>Code Logical</h2>
<div>Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;VBASPNETClientTemplateJQueryJSON&quot;.</div>
<div>Step 2. Add two JQuery library files in JS folder of the application, These JQuery library can help us create the JQuery function and JTemplate HTML table.</div>
<div>Step 3. Create an ASP.NET folder named &quot;App_Code&quot;, and add Person entity class in&nbsp;it. The Person class is created as the data source of table.</div>
<div>Step 4. Add a web form and name it as &quot;Default.aspx&quot; in the root directory of&nbsp;application. The HTML table host in default page with JQuery functions.<br>
&nbsp;&nbsp;<br>
Step 5&nbsp; The JQuery functions can receive the JSON string from code-behind file and constructing an HTML table using JQuery by plug-in JTemplate. The HTML code as shown below:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">    &lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
    &lt;head runat=&quot;server&quot;&gt;
    &lt;title&gt;&lt;/title&gt;
    &lt;script src=&quot;JS/jquery-1.4.4.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;
    &lt;script src=&quot;JS/jquery-jtemplates.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;
    &lt;!--
        .jTemplates { 
                        background: #FF00FF; 
                        border: 1px solid #000; 
                        margin: 2em; 
                        border-style:dashed;
       } 
    
--&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        function GetJSONString() {
            $.ajax({
                url: &quot;Default.aspx/PersonList&quot;,
                type: &quot;POST&quot;,
                data: &quot;{pageSize:5}&quot;,
                dataType: &quot;json&quot;,
                contentType: &quot;application/json; charset=utf-8&quot;,
                success:
                function success(jsonString) {
                    $('#Zone').setTemplate($(&quot;#jTemplate&quot;).html());
                    $('#Zone').processTemplate(jsonString);
                },

                error:
                function (json, status, e) {
                    var err = JSON.parse(json.responseText);
                    $(&quot;Zone&quot;).html(err.Message);
                }
            });

        }
    &lt;/script&gt; 

    &lt;/head&gt;
    &lt;body onload=&quot;return GetJSONString()&quot;&gt;
    &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
    &lt;b&gt;build a tabular data display in web page.&lt;/b&gt;
    &lt;div&gt;
    &lt;script id=&quot;jTemplate&quot; type=&quot;text/html&quot;&gt;   
        &lt;table class=&quot;jTemplates&quot;&gt;   
               &lt;colgroup width=&quot;100px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;100px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;125px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;150px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;150px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;125px&quot;&gt;&lt;/colgroup&gt;
               &lt;colgroup width=&quot;*&quot;&gt;&lt;/colgroup&gt;
                &lt;tr&gt;   
                    &lt;td style=&quot;border-style:dashed;;&quot;&gt;Name&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Age&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Country&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Address&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Mail&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Telephone&lt;/td&gt;  
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;Comment&lt;/td&gt; 
                &lt;/tr&gt;    
            {#foreach $T.d as Person}   
                &lt;tr&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Name }&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Age }&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Country }&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Address }&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Mail }&lt;/td&gt;   
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Telephone }&lt;/td&gt; 
                    &lt;td style=&quot;border-style:dashed;&quot;&gt;{ $T.Person.Comment }&lt;/td&gt;
                &lt;/tr&gt;   
            {#/for}    
        &lt;/table&gt;   
    &lt;/script&gt;
    &lt;br /&gt; 
    &lt;div id=&quot;Zone&quot;&gt; 
    &lt;/div&gt;
    &lt;/div&gt;
    &lt;/form&gt;
    &lt;/body&gt;
    &lt;/html&gt;</pre>
<div class="preview">
<pre class="html">&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;JS/jquery-1.4.4.min.js&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;JS/jquery-jtemplates.js&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;style</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__class">.jTemplates</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background:</span>&nbsp;<span class="css__color">#FF00FF</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border:</span>&nbsp;<span class="css__number">1px</span>&nbsp;<span class="css__value">solid</span>&nbsp;<span class="css__color">#000</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">margin:</span>&nbsp;<span class="css__number">2em</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border-style:</span><span class="css__value">dashed</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/style&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;GetJSONString()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;Default.aspx/PersonList&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__string">&quot;{pageSize:5}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">&quot;json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json;&nbsp;charset=utf-8&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;success(jsonString)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#Zone'</span>).setTemplate($(<span class="js__string">&quot;#jTemplate&quot;</span>).html());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#Zone'</span>).processTemplate(jsonString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(json,&nbsp;status,&nbsp;e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;err&nbsp;=&nbsp;JSON.parse(json.responseText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;Zone&quot;</span>).html(err.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;body</span>&nbsp;<span class="html__attr_name">onload</span>=<span class="html__attr_value">&quot;return&nbsp;GetJSONString()&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;</span>build&nbsp;a&nbsp;tabular&nbsp;data&nbsp;display&nbsp;in&nbsp;web&nbsp;page.<span class="html__tag_end">&lt;/b&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;jTemplate&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/html&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;class=<span class="js__string">&quot;jTemplates&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;100px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;100px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;125px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;150px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;150px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;125px&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;colgroup&nbsp;width=<span class="js__string">&quot;*&quot;</span>&gt;&lt;/colgroup&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;;&quot;</span>&gt;Name&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Age&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Country&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Address&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Mail&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Telephone&lt;/td&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;Comment&lt;/td&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>#foreach&nbsp;$T.d&nbsp;as&nbsp;Person<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Name&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Age&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Country&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Address&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Mail&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Telephone&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;border-style:dashed;&quot;</span>&gt;<span class="js__brace">{</span>&nbsp;$T.Person.Comment&nbsp;<span class="js__brace">}</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>#/<span class="js__statement">for</span><span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Zone&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/html&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 6. The Person entity class file provide basic person properties, such as Name, Age, Country, e-mail, Address, Telephone and comments. This class need be a serializable class.</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    &lt;Serializable()&gt; _
    Public Class Person

        Public Property Name As String
        Public Property Age As Integer
        Public Property Country As String
        Public Property Address As String
        Public Property Mail As String
        Public Property Telephone As String
        Public Property Comment As String

    End Class</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;&lt;Serializable()&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Person&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Name&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Age&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Country&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Address&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Mail&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Telephone&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Comment&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 7. Create a PersonList method for returning a list of person entity instances as the JSON string that it will render on the default page.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    ''' &lt;summary&gt;
    ''' This method is used to provide JSON string variable.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;pageSize&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebMethod()&gt; _
    Public Shared Function PersonList(ByVal pageSize As Integer) As List(Of Person)
        Dim _personList As New List(Of Person)()
        Dim person As New Person()
        person.Name = &quot;Mike&quot;
        person.Age = 20
        person.Country = &quot;United State&quot;
        person.Address = &quot;Mike's address&quot;
        person.Mail = &quot;mike@hotmail.com&quot;
        person.Telephone = &quot;13333333333&quot;
        person.Comment = &quot;None&quot;
        _personList.Add(person)
        Dim personTwo As New Person()
        personTwo.Name = &quot;James&quot;
        personTwo.Age = 22
        personTwo.Country = &quot;United State&quot;
        personTwo.Address = &quot;James's address&quot;
        personTwo.Mail = &quot;james@hotmail.com&quot;
        personTwo.Telephone = &quot;13333333334&quot;
        personTwo.Comment = &quot;Jim's comment&quot;
        _personList.Add(personTwo)
        Dim personThree As New Person()
        personThree.Name = &quot;Nancy&quot;
        personThree.Age = 21
        personThree.Country = &quot;China&quot;
        personThree.Address = &quot;Nancy's address&quot;
        personThree.Mail = &quot;nancy@hotmail.com&quot;
        personThree.Telephone = &quot;13333333335&quot;
        personThree.Comment = &quot;wang's comment&quot;
        _personList.Add(personThree)
        Dim personFour As New Person()
        personFour.Name = &quot;Lisa&quot;
        personFour.Age = 28
        personFour.Country = &quot;United Kingdom&quot;
        personFour.Address = &quot;Lisa's address&quot;
        personFour.Mail = &quot;lisa@hotmail.com&quot;
        personFour.Telephone = &quot;13333333336&quot;
        personFour.Comment = &quot;li's comment&quot;
        _personList.Add(personFour)
        Dim personFive As New Person()
        personFive.Name = &quot;Sakura&quot;
        personFive.Age = 24
        personFive.Country = &quot;Japan&quot;
        personFive.Address = &quot;Sakura's address&quot;
        personFive.Mail = &quot;sakura@hotmail.com&quot;
        personFive.Telephone = &quot;13333333337&quot;
        personFive.Comment = &quot;sa's comment&quot;
        _personList.Add(personFive)
        Return _personList
    End Function
</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;is&nbsp;used&nbsp;to&nbsp;provide&nbsp;JSON&nbsp;string&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;pageSize&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;WebMethod()&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;PersonList(<span class="visualBasic__keyword">ByVal</span>&nbsp;pageSize&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Person)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_personList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Person)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;person&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Mike&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Age&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;United&nbsp;State&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Mike's&nbsp;address&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Mail&nbsp;=&nbsp;<span class="visualBasic__string">&quot;mike@hotmail.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13333333333&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_personList.Add(person)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;personTwo&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;James&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Age&nbsp;=&nbsp;<span class="visualBasic__number">22</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;United&nbsp;State&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;James's&nbsp;address&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Mail&nbsp;=&nbsp;<span class="visualBasic__string">&quot;james@hotmail.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13333333334&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Jim's&nbsp;comment&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_personList.Add(personTwo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;personThree&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Nancy&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Age&nbsp;=&nbsp;<span class="visualBasic__number">21</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;China&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Nancy's&nbsp;address&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Mail&nbsp;=&nbsp;<span class="visualBasic__string">&quot;nancy@hotmail.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13333333335&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;wang's&nbsp;comment&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_personList.Add(personThree)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;personFour&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Lisa&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Age&nbsp;=&nbsp;<span class="visualBasic__number">28</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;United&nbsp;Kingdom&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Lisa's&nbsp;address&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Mail&nbsp;=&nbsp;<span class="visualBasic__string">&quot;lisa@hotmail.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13333333336&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;li's&nbsp;comment&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_personList.Add(personFour)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;personFive&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Person()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Sakura&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Age&nbsp;=&nbsp;<span class="visualBasic__number">24</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Japan&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Address&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Sakura's&nbsp;address&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Mail&nbsp;=&nbsp;<span class="visualBasic__string">&quot;sakura@hotmail.com&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13333333337&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;sa's&nbsp;comment&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_personList.Add(personFive)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_personList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<div class="endscriptcode">Step 8. Build the application and you can debug it.</div>
</div>
<div class="endscriptcode">
<div class="endscriptcode">
<div class="endscriptcode"></div>
<h2 class="endscriptcode">References:</h2>
</div>
</div>
<div>&nbsp;</div>
<div>MSDN: jQuery and Microsoft <br>
<a href="http://weblogs.asp.net/scottgu/archive/2008/09/28/jquery-and-microsoft.aspx">http://weblogs.asp.net/scottgu/archive/2008/09/28/jquery-and-microsoft.aspx</a></div>
<div>&nbsp;</div>
<div>MSDN: JSON Object (Windows Scripting - JScript)<br>
<a href="http://msdn.microsoft.com/en-us/library/cc836458(VS.85).aspx">http://msdn.microsoft.com/en-us/library/cc836458(VS.85).aspx</a></div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<div><em>&nbsp;</em></div>
<div><em>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</em></div>
