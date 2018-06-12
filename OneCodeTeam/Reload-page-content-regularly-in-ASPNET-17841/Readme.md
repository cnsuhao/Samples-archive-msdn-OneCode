# Reload page content  regularly in ASP.NET (CSASPNETReloadPartContent)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* ASP.NET
## IsPublished
* True
## ModifiedDate
* 2012-08-08 12:59:08
## Description

<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to reload part of page content regularly
</span></b>(<b style=""><span style="font-size:14.0pt; font-family:Consolas">CSASPNETReloadPartContent</span></b>)</p>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
<span style="">The CSASPNETReloadPartContent sample show you how to reload part of page content regularly.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:9.0pt; line-height:normal; text-autospace:none">
<span style="">&#8203;One method is use meta tag<span style="">&nbsp; </span>to refresh page regually as show below:<br>
HtmlMeta meta = new HtmlMeta(); </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">meta.HttpEquiv = &quot;Refresh&quot;; </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">meta.Content = &quot;5&quot;; </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">this.Page.Header.Controls.Add(meta); </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Here we want to use javascript setInterval with jquery ajax method.</span><span style="">
</span><span style=""></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETReloadPartContent.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/63224/1/image.png" alt="" width="302" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation finished.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a C# &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer. Name it as &quot;CSASPNETReloadPartContent&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add two Web Forms then rename them to &quot;Default.aspx&quot; and &quot;Refresh.aspx&quot;. The Default page is used to test part of page content
<span style="">regularly reload</span>. The Refresh is used to get the latest data.</span><span style="">
</span><span style="">Add a</span><span style="">n</span><span style=""> </span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">div</span><span style=""> to Default page, it is used to load the latest content. The main code as show
 below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
   This is the main page.
   <div>
       <div id="target">
       </div>
   </div>
   &lt;/form&gt;

</pre>
<pre id="codePreview" class="html">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
   This is the main page.
   <div>
       <div id="target">
       </div>
   </div>
   &lt;/form&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Add some Data Control to &quot;Refresh&quot; page, they are used to bind data. In this demo, we add a
<span style="">Repeater</span></span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">
</span><span style="">Control to show data. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:repeater id=&quot;rptResult&quot; runat=&quot;Server&quot;&gt;
           &lt;HeaderTemplate&gt;
<table><tbody><tr><th>Id </th><th>Time </th></tr>
&lt;/HeaderTemplate&gt;


&lt;ItemTemplate&gt;
 <tr><td>&lt;%#Eval(&quot;Id&quot;)%&gt;</td><td>&lt;%# Eval(&quot;Time&quot;)%&gt;</td></tr>
&lt;/ItemTemplate&gt; 


&lt;FooterTemplate&gt;
 </tbody></table>
&lt;/FooterTemplate&gt;
      
   &lt;/asp:repeater&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:repeater id=&quot;rptResult&quot; runat=&quot;Server&quot;&gt;
           &lt;HeaderTemplate&gt;
<table><tbody><tr><th>Id </th><th>Time </th></tr>
&lt;/HeaderTemplate&gt;


&lt;ItemTemplate&gt;
 <tr><td>&lt;%#Eval(&quot;Id&quot;)%&gt;</td><td>&lt;%# Eval(&quot;Time&quot;)%&gt;</td></tr>
&lt;/ItemTemplate&gt; 


&lt;FooterTemplate&gt;
 </tbody></table>
&lt;/FooterTemplate&gt;
      
   &lt;/asp:repeater&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3.<b style=""> </b>Now we begin to implement reload part of page content regularly. Add JavaScript reference, and write the corresponding JavaScript script.</span><span style=""> In the Default page, the JavaScript will be shown as below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
&lt;script src=&quot;jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


    &lt;script language=&quot;JavaScript&quot; type=&quot;text/javascript&quot;&gt;
        function refreshConsole() {
            $.ajax({
                type: &quot;POST&quot;,
                url: &quot;refresh.aspx&quot;,
                success: function(data) {
                    $(&quot;#target&quot;).html(data);
                }
            });
        }


        $(document).ready(function() {
            refreshConsole();
        });
        
    &lt;/script&gt;

</pre>
<pre id="codePreview" class="js">
&lt;script src=&quot;jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


    &lt;script language=&quot;JavaScript&quot; type=&quot;text/javascript&quot;&gt;
        function refreshConsole() {
            $.ajax({
                type: &quot;POST&quot;,
                url: &quot;refresh.aspx&quot;,
                success: function(data) {
                    $(&quot;#target&quot;).html(data);
                }
            });
        }


        $(document).ready(function() {
            refreshConsole();
        });
        
    &lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style="">[Note]</span></b> <span style="">We need to set the value of the parameter type of jQuery Ajax method to &quot;POST&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">In the Refresh Page, the script as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
&lt;script type=&quot;text/javascript&quot;&gt;


       setInterval(function() {
           load()
       }, 3000);


       var load = function() {
           location.reload();       
       };  
   &lt;/script&gt;  

</pre>
<pre id="codePreview" class="js">
&lt;script type=&quot;text/javascript&quot;&gt;


       setInterval(function() {
           load()
       }, 3000);


       var load = function() {
           location.reload();       
       };  
   &lt;/script&gt;  

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style=""></span></b></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4.<b style=""> </b>We get the latest Data and bind it to DataBind Control in the code-behind.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Here i create a table to store the time of refresh,you can put your logic here instead of it.
        private void BindResult()
        {
            //In the actual scene, you may not need operating the session, here is just to test
            if (Session[&quot;dtResult&quot;] != null)
            {
                dtResult = (DataTable)Session[&quot;dtResult&quot;];
            }
            else
            {
                dtResult = new DataTable();
                dtResult.Columns.Add(&quot;Id&quot;);
                dtResult.Columns.Add(&quot;Time&quot;);
            }


            DataRow dr = dtResult.NewRow();
            dr[&quot;Id&quot;] = dtResult.Rows.Count &#43; 1;
            dr[&quot;Time&quot;] = DateTime.Now.ToString();
            dtResult.Rows.Add(dr);


            //Save data to Session, in a 
            Session[&quot;dtResult&quot;]=dtResult;
            //Bind data to GridView
            rptResult.DataSource = dtResult;
            rptResult.DataBind();
        }

</pre>
<pre id="codePreview" class="csharp">
//Here i create a table to store the time of refresh,you can put your logic here instead of it.
        private void BindResult()
        {
            //In the actual scene, you may not need operating the session, here is just to test
            if (Session[&quot;dtResult&quot;] != null)
            {
                dtResult = (DataTable)Session[&quot;dtResult&quot;];
            }
            else
            {
                dtResult = new DataTable();
                dtResult.Columns.Add(&quot;Id&quot;);
                dtResult.Columns.Add(&quot;Time&quot;);
            }


            DataRow dr = dtResult.NewRow();
            dr[&quot;Id&quot;] = dtResult.Rows.Count &#43; 1;
            dr[&quot;Time&quot;] = DateTime.Now.ToString();
            dtResult.Rows.Add(dr);


            //Save data to Session, in a 
            Session[&quot;dtResult&quot;]=dtResult;
            //Bind data to GridView
            rptResult.DataSource = dtResult;
            rptResult.DataBind();
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5.<b style=""> </b>Build the application and you can debug it.<b style="">
</b></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
