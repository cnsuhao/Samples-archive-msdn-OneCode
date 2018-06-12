# Alert user session expire (VBASPNETAlertSessionExpire)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Session
## IsPublished
* True
## ModifiedDate
* 2012-12-03 08:00:14
## Description

<h1>How to show alert to user when their session is about to expire (VBASPNETAlertSessionExpired)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to design a simple user control, which is used to alert the user when the session is about to expired. We use jQuery, ASP.NET AJAX at client side. In this sample, we add a SessionExpired user control and Script
 Manager on the Master page. It will display an alert message if user idle for long time, user can choose whether to extend the session before it's expired or not.<span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the VBASPNETAlertSessionExpired.sln.<span style=""> </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the VBASPNETAlertSessionExpired web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">By default, we can see a &quot;GetSessionState&quot; button; you can click the button to query the SessionState.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/71707/1/image.png" alt="" width="310" height="130" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>The session is set expired in 1 minute, so idle the page for 30 seconds.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>After 30 seconds, you will see an alert message &quot;Your session will be expired after 30 seconds, would you like to extend the session time?&quot; You can choose &quot;Yes&quot; or &quot;No&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/71708/1/image.png" alt="" width="524" height="187" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>If you choose &quot;Yes&quot;, the session will be reset. You can click the &quot;GetSessionState&quot; button to query the session status, you will see the SessionState: Existing.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>If you choose &quot;No&quot;, the &quot;GetSessionState&quot; button will be disabled temporarily. When the session is really expired you can click the &quot;GetSessionState&quot; button, the page will redirect to the SessionExpired page.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/71709/1/image.png" alt="" width="192" height="49" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;VBASPNETAlertSessionExpired&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Right-click the VBASPNETAlertSessionExpired , and click Add -&gt; New Item -&gt;<span style="">&nbsp;
</span>New Folder &quot;Controls&quot;.<span style="">&nbsp; </span>Right-click The Controls directory, and click Add-&gt; New Item -&gt; Web User Control name as &quot;SessionExpired.ascx&quot;:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in">SessionExpired.ascx.vb:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in">1) The SessionExpired class inherits from ICallHandlerEvent which is used to indicate that the control can be the target of a callback event on the server. Then it will extend the Session's lifetime.
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in">2) Register the Session's timeout value to the client so that user can extend the Session's lifetime before it expired.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in">3) Verify the Session is expired or not.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in">SessionExpired.ascx: It will get the Session's timeout value and request the server interval by async method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If Not IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;SessionForTest&quot;) = &quot;SessionForTest&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If

</pre>
<pre id="codePreview" class="vb">
If Not IsPostBack Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;SessionForTest&quot;) = &quot;SessionForTest&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in"><span style="">&nbsp;&nbsp; </span>
Add the Session state judgment like:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If Session(&quot;SessionForTest&quot;) Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbSessionState.Text = SessionStates.Expired.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbSessionState.Text = SessionStates.Exist.ToString()
&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If

</pre>
<pre id="codePreview" class="vb">
If Session(&quot;SessionForTest&quot;) Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbSessionState.Text = SessionStates.Expired.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbSessionState.Text = SessionStates.Exist.ToString()
&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Right-click the VBASPNETAlertSessionExpired , and click Add -&gt; New Item -&gt; New Folder &quot;Util&quot;. Create a menu type which is used to output the session state consistent.</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the Site.Master,(If there is no Site.Master, create one.)<span style="">&nbsp;
</span>add a user control reference and a script reference like below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;uc:SessionExpired ID=&quot;ucSesvsionExpired&quot; runat=&quot;server&quot; /&gt;

</pre>
<pre id="codePreview" class="html">
&lt;uc:SessionExpired ID=&quot;ucSesvsionExpired&quot; runat=&quot;server&quot; /&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the Default.aspx<span style="">,&nbsp;a</span>dd the scripts and css reference<span style="">&nbsp;
</span>like below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
&lt;script&nbsp; type=&quot;text/javascript&quot;&nbsp; language=&quot;javascript&quot; src=&quot;Scripts/jquery-1.4.1-vsdoc.js&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;script type=&quot;text/javascript&quot; language=&quot;javascript&quot; src=&quot;Scripts/SessionExpired.js&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;link href=&quot;Styles/SessionExpired.css&quot;&nbsp; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;

</pre>
<pre id="codePreview" class="js">
&lt;script&nbsp; type=&quot;text/javascript&quot;&nbsp; language=&quot;javascript&quot; src=&quot;Scripts/jquery-1.4.1-vsdoc.js&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;script type=&quot;text/javascript&quot; language=&quot;javascript&quot; src=&quot;Scripts/SessionExpired.js&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/script&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;link href=&quot;Styles/SessionExpired.css&quot;&nbsp; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the Web.config<span style=""> and s</span>et the Session timeout value like below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;system.web&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;sessionState timeout=&quot;1&quot;&gt;&lt;/sessionState&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/system.web&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;system.web&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;sessionState timeout=&quot;1&quot;&gt;&lt;/sessionState&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/system.web&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: How to: Implement Callbacks in ASP.NET Web Pages<br>
<a href="http://msdn.microsoft.com/en-us/library/ms366518.aspx">http://msdn.microsoft.com/en-us/library/ms366518.aspx</a><br>
MSDN: How to: Save Values in Session State<br>
<a href="http://msdn.microsoft.com/en-us/library/6ad7zeeb(VS.90).aspx">http://msdn.microsoft.com/en-us/library/6ad7zeeb(VS.90).aspx</a><br>
MSDN: ASP.NET Session State Overview<br>
<a href="http://msdn.microsoft.com/en-us/library/ms178581.aspx">http://msdn.microsoft.com/en-us/library/ms178581.aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
