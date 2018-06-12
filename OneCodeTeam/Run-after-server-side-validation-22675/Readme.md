# Run scripts after server side validation
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Data Validation
* Script
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:54:00
## Description

<h1><span style="">Run scripts after server side validation </span>(<span style="">VBASPNETRunScriptsAfterServerSideValidation</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal"><span style="">The sample code demonstrates how to run client script after server side validation. Normall<span id="ms-rterangepaste-start"></span>y, client script is placed to validate user inputs at client side. After this validation
 is successful, server side validation is then performed. But sometimes, after server side validation, &#8203; we'll need to run client script to perform tasks that only achievable by javascript, for example, showing a dialog box, scrolling the page to a designated
 place, etc. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBASPNETRunScriptsAfterServerSideValidation.sln. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right click Default.aspx and choose &quot;View in Browser&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Enter an email in the textbox and click the button to validate.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 20</span><span style="">12</span><span style="">. Name it as &quot;VBASPNETRunScriptsAfterServerSideValidation&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2. Add a TextBox Control, a Button, a RequiredFieldValidator and a CustomValidator to the Dafault page.The add a div in the bottom of the form for run scripts after
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Server side validation.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Step 3. In the Page_Load event, Page object gets checked to see if the value of the input element is valid. If the value is valid, then register a script to run at client side. This
 script is used to perform client side tasks. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">First, get the value of the input.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim strMail As String = Request.Form(&quot;tbEmail&quot;)

</pre>
<pre id="codePreview" class="vb">
Dim strMail As String = Request.Form(&quot;tbEmail&quot;)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;</span></span><span style="">Second,<span style="color:green">
</span>declare the pattern to validate the email. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim strPattern As String = &quot;\w&#43;([-&#43;.']\w&#43;)*@\w&#43;([-.]\w&#43;)*\.\w&#43;([-.]\w&#43;)*&quot;

</pre>
<pre id="codePreview" class="vb">
Dim strPattern As String = &quot;\w&#43;([-&#43;.']\w&#43;)*@\w&#43;([-.]\w&#43;)*\.\w&#43;([-.]\w&#43;)*&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;</span></span><span style="">Finally, according to the results of the verification decision as to whether to register a script to run at client side or not.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If System.Text.RegularExpressions.Regex.IsMatch(strMail, strPattern) Then
                   'Register a script to run at client side.
                   Page.ClientScript.RegisterStartupScript([GetType](), &quot;Alert&quot;, &quot;&lt;script&gt;document.getElementById('divTask').style.display='block';&lt;/script&gt;&quot;)
               Else
                   CustomValidator1.IsValid = False
               End If

</pre>
<pre id="codePreview" class="vb">
If System.Text.RegularExpressions.Regex.IsMatch(strMail, strPattern) Then
                   'Register a script to run at client side.
                   Page.ClientScript.RegisterStartupScript([GetType](), &quot;Alert&quot;, &quot;&lt;script&gt;document.getElementById('divTask').style.display='block';&lt;/script&gt;&quot;)
               Else
                   CustomValidator1.IsValid = False
               End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4. </span><span style="">When targeting .NET 4.5 we enable Unobtrusive Validation by default. You need to have jQuery in your project and have something like this in Global.asax to register jQuery properly:</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim myScriptResDef As New ScriptResourceDefinition()
       myScriptResDef.Path = &quot;~/JS/jquery-1.8.1.js&quot;
       myScriptResDef.DebugPath = &quot;~/JS/jquery-1.8.1.js&quot;
       myScriptResDef.CdnPath = &quot;http://code.jquery.com/jquery-1.8.1.js&quot;
       myScriptResDef.CdnDebugPath = &quot;http://code.jquery.com/jquery-1.8.1.js&quot;
       ScriptManager.ScriptResourceMapping.AddDefinition(&quot;jquery&quot;, Nothing, myScriptResDef)

</pre>
<pre id="codePreview" class="vb">
Dim myScriptResDef As New ScriptResourceDefinition()
       myScriptResDef.Path = &quot;~/JS/jquery-1.8.1.js&quot;
       myScriptResDef.DebugPath = &quot;~/JS/jquery-1.8.1.js&quot;
       myScriptResDef.CdnPath = &quot;http://code.jquery.com/jquery-1.8.1.js&quot;
       myScriptResDef.CdnDebugPath = &quot;http://code.jquery.com/jquery-1.8.1.js&quot;
       ScriptManager.ScriptResourceMapping.AddDefinition(&quot;jquery&quot;, Nothing, myScriptResDef)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Add global.asax item in your project and add above code to Application_Start. Replacing the version of jQuery with the version you are using.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step </span><span style="">5</span><span style="">. Build the application and you can debug it.
</span></p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style=""><span class="SpellE"><span style="">ClientScriptManager.RegisterStartupScript</span></span><span style=""> Method
</span><span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.registerstartupscript.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.registerstartupscript.aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
