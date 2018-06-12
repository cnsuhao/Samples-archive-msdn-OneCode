# Validate user email address in ASP.NET
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Email
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:06:51
## Description

<h1>Send a confirmation Email to check whether an Email address is available (CSASPNETEmailAddressValidator)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to send a confirmation Email to check whether an Email address is available.<span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the CSASPNETEmailAddressValidator.sln.<span style=""> </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the CSASPNETEmailAddressValidator web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="">&nbsp; <img src="/site/view/file/91614/1/image.png" alt="" width="575" height="184" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">We will see a Wizard. In the first step, input a SMTP server name or IP address and one Email address based on that SMTP server and its password. We need to use this to send the confirmation Email.<br>
In this sample, we use Hotmail, so if you have a hotmail, you can input your hotmail address and password and then click Next.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">In the second step, input an Email address which need to be validated. Of course, you need to see the message to process the next step.
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/91615/1/image.png" alt="" width="575" height="131" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Open the mail message which you have received. Click the link or copy the link address to the browser and you can see a 'Congratulation' message.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/91616/1/image.png" alt="" width="570" height="25" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation is complete.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012. Name it as &quot;CSASPNETEmailAddressValidator&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Add two folders, &quot;Handler&quot; and &quot;Module&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Add a new database file in the App_Data and create a new table called,
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">&nbsp;&nbsp;
</span>&quot;tblEmailValidation&quot;. Add six columns which are illustrated like below:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">id: the identity key of the table;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">EmailAddress: store the Email address which need to be validated;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">IsValidated: store a bit to check whether the validation is completed.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">IsSendCheckEmail: store a bit to check whether the message has been sent.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">ValidatingStartTime: store the datetime which start the validation.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style="">ValdateKey: a unique key which used to tell different validation links.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Add a new Linq to SQL class in the Module folder and name it as EmailAddressValidation.dbml. Open the Server Explorer, create a connection to the EmailValidationDB.mdf and drag the tblEmailValidation table and drop it to the desktop of
 the EmailAddressValidation.dbml. Then build the project.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a new class file, name it as EmailValidation.cs. Write the codes like the sample and we can find more details from the comments in the sample file.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a new HttpHandler in the Handler folder. Write the codes like the sample and we can find more details from the comments in the sample file.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Modify the Webform1.aspx to Default.aspx and create a Wizard control there. Follow the sample to complete the markups.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the Default.aspx.cs. Write the codes like the sample. You can get more details from the comments in the sample file.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 9:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the web.config. Add a new HttpHandler like below in the &lt;system.web&gt; node.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;httpHandlers&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add path=&quot;mail.axd&quot; verb=&quot;GET&quot; validate=&quot;false&quot; type=&quot;CSASPNETEmailAddresseValidator.Handler.EmailAvailableValidationHandler&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/httpHandlers&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;httpHandlers&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add path=&quot;mail.axd&quot; verb=&quot;GET&quot; validate=&quot;false&quot; type=&quot;CSASPNETEmailAddresseValidator.Handler.EmailAvailableValidationHandler&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/httpHandlers&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in; text-indent:-.25in"><span style=""><span style="">Step 10:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: SmtpClient Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx</a><br>
MSDN: SQL-CLR Type Mapping (LINQ to SQL)<br>
<a href="http://msdn.microsoft.com/en-us/library/bb386947.aspx">http://msdn.microsoft.com/en-us/library/bb386947.aspx</a><br>
MSDN: HttpHandlers<br>
<a href="http://msdn.microsoft.com/en-us/library/5c67a8bd(VS.71).aspx">http://msdn.microsoft.com/en-us/library/5c67a8bd(VS.71).aspx</a><br>
<br>
<span style=""><br style="">
<br style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
