# Use SMTP to send email (CSSMTPSendEmail)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Network
## Topics
* SMTP
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:47:45
## Description

<h1>CONSOLE APPLICATION( CSSMTPSendEmail)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">CSSMTPSendEmail demonstrates sending email with attachment and embedded image in the message body using SMTP server from a C# program.</p>
<p class="MsoNormal">With the introduction of .NET 2.0, the classes for sending email are packed in the System.Net.Mail namespace. In the example, we use the MailMessage and the SmtpClient classes.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build an email object and set the basic email properties.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">Represents an e-mail message that can be sent using the SmtpClient class.</span>
<span style="">Instances of the MailMessage class are used to construct e-mail messages that are transmitted to an SMTP server for delivery using the SmtpClient class.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">The sender, recipient, subject, and body of an e-mail message may be specified as parameters when a MailMessage is used to initialize a MailMessage object. These parameters may also be set or accessed using
 properties on the MailMessage object. </span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><span style="">&nbsp;</span>The primary mail message headers and elements for the message may be set using the following properties of the MailMessage class.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
    MailMessage mail = new MailMessage();
    mail.To.Add(&quot;anyreceiver@anydomain.com&quot;);
    mail.From = new MailAddress(&quot;anyaddress@anydomain.com&quot;);

</pre>
<pre id="codePreview" class="csharp">
    MailMessage mail = new MailMessage();
    mail.To.Add(&quot;anyreceiver@anydomain.com&quot;);
    mail.From = new MailAddress(&quot;anyaddress@anydomain.com&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add an attachment of the email.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
    mail.Attachments.Add(new Attachment(attachedFile));

</pre>
<pre id="codePreview" class="csharp">
    mail.Attachments.Add(new Attachment(attachedFile));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Embed an image in the message body.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
    mail.Body, null, &quot;text/html&quot;);
LinkedResource imgLink = new LinkedResource(imgFile, &quot;image/jpg&quot;);
imgLink.ContentId = &quot;image1&quot;;
imgLink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
htmlView.LinkedResources.Add(imgLink);
mail.AlternateViews.Add(htmlView);

</pre>
<pre id="codePreview" class="csharp">
AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
    mail.Body, null, &quot;text/html&quot;);
LinkedResource imgLink = new LinkedResource(imgFile, &quot;image/jpg&quot;);
imgLink.ContentId = &quot;image1&quot;;
imgLink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
htmlView.LinkedResources.Add(imgLink);
mail.AlternateViews.Add(htmlView);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Configure the SMTP client.</p>
<p class="MsoListParagraphCxSpMiddle"><span class="GramE">Allows applications to send e-mail by using the Simple Mail Transfer Protocol (SMTP).</span> The
<span class="SpellE">SmtpClient</span> class is used to send e-mail to an SMTP server for delivery. The SMTP protocol is defined in RFC 2821, which is available at
<a href="http://www.ietf.org/">http://www.ietf.org</a>. </p>
<p class="MsoListParagraphCxSpLast">The classes shown in the following table are used to construct e-mail messages that can be sent using
<span class="SpellE">SmtpClient</span>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SmtpClient smtp = new SmtpClient();
smtp.Host = &quot;smtp.live.com&quot;;
smtp.Credentials = new NetworkCredential(
    &quot;myaccount@live.com&quot;, &quot;mypassword&quot;);
smtp.EnableSsl = true;

</pre>
<pre id="codePreview" class="csharp">
SmtpClient smtp = new SmtpClient();
smtp.Host = &quot;smtp.live.com&quot;;
smtp.Credentials = new NetworkCredential(
    &quot;myaccount@live.com&quot;, &quot;mypassword&quot;);
smtp.EnableSsl = true;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Send the email.</p>
<p class="MsoListParagraphCxSpMiddle"><span class="GramE">Sends the specified message to an SMTP server for delivery.</span> This method blocks while the e-mail is transmitted. You can specify a time-out value using the Timeout property to ensure that the
 method returns after a specified amount of time elapses. </p>
<p class="MsoListParagraphCxSpMiddle">Before calling this method, the Host and Port properties must be set either through the configuration files by setting the relevant properties, or by passing this information into the
<span class="SpellE"><span class="GramE">SmtpClient</span></span><span class="GramE">(</span>String, Int32) constructor.
</p>
<p class="MsoListParagraphCxSpMiddle">You cannot call this method if there is a message being sent asynchronously.
</p>
<p class="MsoListParagraphCxSpMiddle">If the SMTP host requires credentials, you must set them before calling this method. To specify credentials, use the
<span class="SpellE">UseDefaultCredentials</span> or Credentials properties. </p>
<p class="MsoListParagraphCxSpMiddle">If you receive <span class="GramE">an</span>
<span class="SpellE">SmtpException</span> exception, check the <span class="SpellE">
StatusCode</span> property to find the reason the operation failed. The <span class="SpellE">
SmtpException</span> can also contain an inner exception that indicates the reason the operation failed.
</p>
<p class="MsoListParagraphCxSpLast">When sending e-mail using Send to multiple recipients and the SMTP server accepts some recipients as valid and rejects others, Send sends e-mail to the accepted recipients and then a
<span class="SpellE">SmtpFailedRecipientsException</span> is thrown. The exception will contain a listing of the recipients that were rejected.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
   smtp.Send(mail);

</pre>
<pre id="codePreview" class="csharp">
   smtp.Send(mail);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style="font-family:������">MSDN: SmtpClient Class </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx</a>
</span></p>
<p class="MsoNormal"><span style="font-family:������">Sending Emails from C# Application using default SMTP
</span></p>
<p class="MsoNormal"><span style=""><a href="http://www.codeproject.com/KB/cs/Sending_Mails_From_C_.aspx">http://www.codeproject.com/KB/cs/Sending_Mails_From_C_.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
