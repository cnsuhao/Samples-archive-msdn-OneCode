# Back button clear page variables (ClearVariablesOnClickOfBackButton)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Navigation
## IsPublished
* True
## ModifiedDate
* 2012-05-10 07:52:27
## Description

<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to clear variables on click of Back button to previous page on browser
</span></b><b style=""><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">(</span></b><b style=""><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">CSASPNETClearVariablesOnClickOfBackButton</span></b><b style=""><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">)
</span></b></p>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">&nbsp;&nbsp;&nbsp;
</span></span><span style="">The CSASPNETClearVariablesOnClickOfBackButton sample demonstrates how to clear
</span><span style="">variables on click of Back button to previous page on browser</span><span style="">. Usually, if user hits browser's back button, some of the session variables still appear, user can resubmit data or manipulate again, which will lead the
 repeat submit or operation. here we clear out the previous page's. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETClearVariablesOnClickOfBackButton.sln. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the a.aspx page then select &quot;View in Browser&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Enter some data then click the button to submit. In the b.aspx will show the data you enter in a.aspx. Then click the Back Button of browser return to a.aspx. You previously entered will not appear.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: If you comment out the code in the <span style="">Page_Load</span> event of the a.aspx page. And then do the &quot;Step 3&quot; of the same operation. You previously entered will appear.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a C# <span class="GramE">&quot; ASP.NET</span> Web Application &quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as &quot;CSASPNETClearVariablesOnClickOfBackButton&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add two pages then rename to a.aspx and b.aspx. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Add a button Control and two TextBox Control on the a.aspx page then rename them to ��<span style="">tbName</span>��,��tbPwd�� for TextBox and
<span style="">btnSubmit for button</span>. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. In the <span style="">Page_Load event of the a.aspx add code
</span>as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
           Response.Cache.SetCacheability(HttpCacheability.NoCache);
           Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
           Response.Cache.SetNoStore();

</pre>
<pre id="codePreview" class="csharp">
           Response.Cache.SetCacheability(HttpCacheability.NoCache);
           Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
           Response.Cache.SetNoStore();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5. <span class="GramE">In the click event of the button.</span> The code as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (!string.IsNullOrEmpty(tbName.Text.Trim()) && !string.IsNullOrEmpty(tbPwd.Text.Trim()))
           {
               Session[&quot;uName&quot;] = tbName.Text;
               Session[&quot;uPwd&quot;] = tbPwd.Text;
               Response.Redirect(&quot;b.aspx&quot;);
           }

</pre>
<pre id="codePreview" class="csharp">
if (!string.IsNullOrEmpty(tbName.Text.Trim()) && !string.IsNullOrEmpty(tbPwd.Text.Trim()))
           {
               Session[&quot;uName&quot;] = tbName.Text;
               Session[&quot;uPwd&quot;] = tbPwd.Text;
               Response.Redirect(&quot;b.aspx&quot;);
           }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">IsNullOrEmpty method use in order to avoid duplicate submissions, of course, you can change the client-side validation or other complex logic.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step6. In the Page_Load event of the b.aspx add code as showm below for show the data you enter in a.aspx.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (!string.IsNullOrEmpty(Session[&quot;uName&quot;] as string))
           {
               Response.Write(Session[&quot;uName&quot;].ToString());
           }
           Response.Write(&quot;<br>&quot;);
           if (!string.IsNullOrEmpty(Session[&quot;uPwd&quot;] as string))
           {
               Response.Write(Session[&quot;uPwd&quot;].ToString());
           }      

</pre>
<pre id="codePreview" class="csharp">
if (!string.IsNullOrEmpty(Session[&quot;uName&quot;] as string))
           {
               Response.Write(Session[&quot;uName&quot;].ToString());
           }
           Response.Write(&quot;<br>&quot;);
           if (!string.IsNullOrEmpty(Session[&quot;uPwd&quot;] as string))
           {
               Response.Write(Session[&quot;uPwd&quot;].ToString());
           }      

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:-.25in; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:Consolas"><a href="http://msdn.microsoft.com/en-us/library/aa332794(v=vs.71).aspx">HttpCachePolicy.SetCacheability Method (HttpCacheability)</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
