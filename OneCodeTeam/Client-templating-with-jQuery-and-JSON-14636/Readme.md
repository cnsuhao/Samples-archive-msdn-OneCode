# Client templating with jQuery and JSON (CSASPNETClientTemplateJQueryJSON)
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
* 2011-12-28 11:58:55
## Description

<h1>Client templating with jQuery and JSON (CSASPNETClientTemplateJQueryJSON)</h1>
<h2>Summary</h2>
<p>This project illustrates how to display a tabular data to users based on some inputs in ASP.NET application. We will see how this can be addressed with JQuery and JSON to build a tabular data display in web page. Here we use JQuery plug-in JTemplate to make
 it easy.</p>
<h2>Demo</h2>
<p>Please follow these demonstration steps below.</p>
<p>Step 1: Open the CSASPNETClientTemplateJQueryJSON.sln.</p>
<p>Step 2: Expand the CSASPNETClientTemplateJQueryJSON web application and press&nbsp;Ctrl &#43; F5 to show the Default.aspx.</p>
<p>Step 3: You can find an HTML table on the Default.aspx page, the tabular data display by JQuery plug-in JTemplate.</p>
<h2>Code Logical</h2>
<p>Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or&nbsp;Visual Web Developer 2010. Name it as &quot;CSASPNETClientTemplateJQueryJSON&quot;.</p>
<p>Step 2. Add two JQuery library files in JS folder of the application, These JQuery library can help us create the JQuery function and JTemplate HTML table.</p>
<p>Step 3. Create an ASP.NET folder named &quot;App_Code&quot;, and add Person entity class in&nbsp;it. The Person class is created as the data source of table.</p>
<p>Step 4. Add a web form and name it as &quot;Default.aspx&quot; in the root directory of&nbsp;application. The HTML table host in default page with JQuery functions.<br>
&nbsp;&nbsp;<br>
Step 5&nbsp; The JQuery functions can receive the JSON string from code-behind file and constructing an HTML table using JQuery by plug-in JTemplate. The HTML code&nbsp;as shown below:</p>
<p></p>
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
    <style type="text/css">
        .jTemplates { 
                        background: #FF00FF; 
                        border: 1px solid #000; 
                        margin: 2em; 
                        border-style:dashed;
       } 
    </style>
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
<pre class="html"><span class="html__tag_start">&lt;html</span><span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span><span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span><span class="html__tag_start">&lt;script</span><span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;JS/jquery-1.4.4.min.js&quot;</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span><span class="html__tag_start">&lt;script</span><span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;JS/jquery-jtemplates.js&quot;</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span><span class="html__tag_start">&lt;style</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span><span class="html__tag_start">&gt;</span><span class="css__class">.jTemplates</span>&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background:</span><span class="css__color">#FF00FF</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border:</span><span class="css__number">1px</span><span class="css__value">solid</span><span class="css__color">#000</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">margin:</span><span class="css__number">2em</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border-style:</span><span class="css__value">dashed</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/style&gt;</span><span class="html__tag_start">&lt;script</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="js__operator">function</span>&nbsp;GetJSONString()&nbsp;<span class="js__brace">{</span>&nbsp;
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(json,&nbsp;status,&nbsp;e)&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;err&nbsp;=&nbsp;JSON.parse(json.responseText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;Zone&quot;</span>).html(err.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="html__tag_end">&lt;/script&gt;</span><span class="html__tag_end">&lt;/head&gt;</span><span class="html__tag_start">&lt;body</span><span class="html__attr_name">onload</span>=<span class="html__attr_value">&quot;return&nbsp;GetJSONString()&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;form</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span><span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;</span>build&nbsp;a&nbsp;tabular&nbsp;data&nbsp;display&nbsp;in&nbsp;web&nbsp;page.<span class="html__tag_end">&lt;/b&gt;</span><span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;script</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;jTemplate&quot;</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/html&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
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
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span><span class="html__tag_start">&lt;br</span><span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;div</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Zone&quot;</span><span class="html__tag_start">&gt;&nbsp;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_end">&lt;/form&gt;</span><span class="html__tag_end">&lt;/body&gt;</span><span class="html__tag_end">&lt;/html&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 6. The Person entity class file provide basic person properties, such as&nbsp;Name, Age, Country, e-mail, Address, Telephone and comments. This class&nbsp;need be a serializable class.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private string name;
        private int age;
        private string country;
        private string address;
        private string mail;
        private string telephone;
        private string comment;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get 
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }

        public string Comment
        {
            get 
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">int</span>&nbsp;age;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;address;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;mail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;telephone;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">string</span>&nbsp;comment;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">int</span>&nbsp;Age&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;age;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;age&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Country&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Address&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;address;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;address&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Mail&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;mail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mail&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Telephone&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;telephone;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;telephone&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Comment&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;comment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;comment&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 7. Create a PersonList method for returning a list of person entity instances as the JSON string that it will render on the default page.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        /// &lt;summary&gt;
        /// This method is used to provide JSON string variable.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;pageSize&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;pageNumber&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [WebMethod]
        public static List&lt;Person&gt; PersonList(int pageSize)
        {
            List&lt;Person&gt; personList = new List&lt;Person&gt;();
            Person person = new Person();
            person.Name = &quot;Mike&quot;;
            person.Age = 20;
            person.Country = &quot;United State&quot;;
            person.Address = &quot;Mike's address&quot;;
            person.Mail = &quot;mike@hotmail.com&quot;;
            person.Telephone = &quot;13333333333&quot;;
            person.Comment = &quot;None&quot;;
            personList.Add(person);
            Person personTwo = new Person();
            personTwo.Name = &quot;James&quot;;
            personTwo.Age = 22;
            personTwo.Country = &quot;United State&quot;;
            personTwo.Address = &quot;James's address&quot;;
            personTwo.Mail = &quot;james@hotmail.com&quot;;
            personTwo.Telephone = &quot;13333333334&quot;;
            personTwo.Comment = &quot;Jim's comment&quot;;
            personList.Add(personTwo);
            Person personThree = new Person();
            personThree.Name = &quot;Nancy&quot;;
            personThree.Age = 21;
            personThree.Country = &quot;China&quot;;
            personThree.Address = &quot;Nancy's address&quot;;
            personThree.Mail = &quot;nancy@hotmail.com&quot;;
            personThree.Telephone = &quot;13333333335&quot;;
            personThree.Comment = &quot;wang's comment&quot;;
            personList.Add(personThree);
            Person personFour = new Person();
            personFour.Name = &quot;Lisa&quot;;
            personFour.Age = 28;
            personFour.Country = &quot;United Kingdom&quot;;
            personFour.Address = &quot;Lisa's address&quot;;
            personFour.Mail = &quot;lisa@hotmail.com&quot;;
            personFour.Telephone = &quot;13333333336&quot;;
            personFour.Comment = &quot;li's comment&quot;;
            personList.Add(personFour);
            Person personFive = new Person();
            personFive.Name = &quot;Sakura&quot;;
            personFive.Age = 24;
            personFive.Country = &quot;Japan&quot;;
            personFive.Address = &quot;Sakura's address&quot;;
            personFive.Mail = &quot;sakura@hotmail.com&quot;;
            personFive.Telephone = &quot;13333333337&quot;;
            personFive.Comment = &quot;sa's comment&quot;;
            personList.Add(personFive);
            return personList;
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;This&nbsp;method&nbsp;is&nbsp;used&nbsp;to&nbsp;provide&nbsp;JSON&nbsp;string&nbsp;variable.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;pageSize&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;pageNumber&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[WebMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;List&lt;Person&gt;&nbsp;PersonList(<span class="cs__keyword">int</span>&nbsp;pageSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Person&gt;&nbsp;personList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Person&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;person&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Mike&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Age&nbsp;=&nbsp;<span class="cs__number">20</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Country&nbsp;=&nbsp;<span class="cs__string">&quot;United&nbsp;State&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Address&nbsp;=&nbsp;<span class="cs__string">&quot;Mike's&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Mail&nbsp;=&nbsp;<span class="cs__string">&quot;mike@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;13333333333&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;person.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personList.Add(person);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;personTwo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Name&nbsp;=&nbsp;<span class="cs__string">&quot;James&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Age&nbsp;=&nbsp;<span class="cs__number">22</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Country&nbsp;=&nbsp;<span class="cs__string">&quot;United&nbsp;State&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Address&nbsp;=&nbsp;<span class="cs__string">&quot;James's&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Mail&nbsp;=&nbsp;<span class="cs__string">&quot;james@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;13333333334&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personTwo.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;Jim's&nbsp;comment&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personList.Add(personTwo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;personThree&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Nancy&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Age&nbsp;=&nbsp;<span class="cs__number">21</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Country&nbsp;=&nbsp;<span class="cs__string">&quot;China&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Address&nbsp;=&nbsp;<span class="cs__string">&quot;Nancy's&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Mail&nbsp;=&nbsp;<span class="cs__string">&quot;nancy@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;13333333335&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personThree.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;wang's&nbsp;comment&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personList.Add(personThree);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;personFour&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Lisa&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Age&nbsp;=&nbsp;<span class="cs__number">28</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Country&nbsp;=&nbsp;<span class="cs__string">&quot;United&nbsp;Kingdom&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Address&nbsp;=&nbsp;<span class="cs__string">&quot;Lisa's&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Mail&nbsp;=&nbsp;<span class="cs__string">&quot;lisa@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;13333333336&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFour.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;li's&nbsp;comment&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personList.Add(personFour);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;personFive&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sakura&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Age&nbsp;=&nbsp;<span class="cs__number">24</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Country&nbsp;=&nbsp;<span class="cs__string">&quot;Japan&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Address&nbsp;=&nbsp;<span class="cs__string">&quot;Sakura's&nbsp;address&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Mail&nbsp;=&nbsp;<span class="cs__string">&quot;sakura@hotmail.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;13333333337&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personFive.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;sa's&nbsp;comment&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;personList.Add(personFive);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;personList;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 8. Build the application and you can debug it.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">References:</h2>
</div>
</div>
<p></p>
<p>MSDN: jQuery and Microsoft <br>
<a href="http://weblogs.asp.net/scottgu/archive/2008/09/28/jquery-and-microsoft.aspx">http://weblogs.asp.net/scottgu/archive/2008/09/28/jquery-and-microsoft.aspx</a></p>
<p>MSDN: JSON Object (Windows Scripting - JScript)<br>
<a href="http://msdn.microsoft.com/en-us/library/cc836458(VS.85).aspx">http://msdn.microsoft.com/en-us/library/cc836458(VS.85).aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</em>
<p></p>
