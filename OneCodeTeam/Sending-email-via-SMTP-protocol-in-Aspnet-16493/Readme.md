# Sending email via SMTP protocol in Asp.net (CSASPNETSendingEmail)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* SMTP
* Email
## IsPublished
* True
## ModifiedDate
* 2012-04-20 01:12:47
## Description

<h1>Sending email via Asp.net web form application (CSASPNETSendingEmail)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to send an email with attachments and embedded images using SMTP protocol in Asp.net. This is a very common issue in forums, customers always fall into troubles when they try to implement relative APIs,
 that is because they receive many errors or exceptions, so we provide this sample code to show how to send an email with your web application, and this sample also demonstrates how to send emails asynchronously for improving user experience.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">CSASPNETSendingEmail</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">CSASPNETSendingEmail</span> </a>web application and press Ctrl &#43; F5 to show the Default.aspx.
</p>
<p class="MsoNormal">Step 2: We will see a web page that we can input email information, for example you can input e-mail account and password for login, and Target Email address is the people you want to send message to him, The Target email host is the
 SMTP address of your email. For example, if you use Hotmail mailbox, you can input ��smtp.live.com��, if you use google��s email, you can input ��smpt.gmail.com��, etc.
<span style="">&nbsp;</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56421/1/image.png" alt="" width="831" height="702" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span style="">&nbsp; </span>After all above works finished, you can click Send Now! Button for send email or click Reset Email for re-writer email��s content. In this sample, all TextBox and FileUpload controls need been added,
 you can change this rule by modify the code. Now let��s look the result of send success.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56422/1/image.png" alt="" width="831" height="702" align="middle">
</span></p>
<p class="MsoNormal">Step 4: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as ��<span style="">CSASPNETSendingEmail</span>&quot;. Add one web form pages and name it as ��Default.aspx�� page,
 the input controls and buttons are in this page, customers can view this page for sending email.</p>
<p class="MsoNormal">Step 2. Add two class files and name them as ��EmailModel.cs�� and ��StringValidation.cs��. The EmailModel class is used to define basic properties of an email message, such as SourceAddress, SourcePassword, TargetAddress, etc. The StringValidation
 class is used to check user��s input and return error information, for easy to show core functions, we only check the string variables is null and email string variables�� format.</p>
<h3>The following code shows how to make a simple validation class.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class StringValidation
{
    /// &lt;summary&gt;
    /// Email information validation.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;model&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public string Validation(EmailModel model)
    {
        if (String.IsNullOrEmpty(model.SourceAddress))
            return EmailModel._SourceAddress &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.SourcePassword))
            return EmailModel._SourcePassword &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.TargetAddress))
            return EmailModel._TargetAddress &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.SourcetHost))
            return EmailModel._SourcetHost &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.Title))
            return EmailModel._Title &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.AttachmentUri))
            return EmailModel._AttachmentUri &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.ImageUri))
            return EmailModel._ImageUri &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.Text))
            return EmailModel._Text &#43; &quot; is null&quot;;
        if (!ValidEmail(model.SourceAddress))
            return EmailModel._SourceAddress &#43; &quot; is invalid.&quot;;
        if (!ValidEmail(model.TargetAddress))
            return EmailModel._TargetAddress &#43; &quot; is invalid.&quot;;
        return String.Empty; 
    }


    /// &lt;summary&gt;
    /// Email string variable Regular Expression
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;strIn&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public bool ValidEmail(string email)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(
           email, @&quot;^([\w-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)&quot; &#43;
           @&quot;|(([\w-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;);
    }
}

</pre>
<pre id="codePreview" class="csharp">
public class StringValidation
{
    /// &lt;summary&gt;
    /// Email information validation.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;model&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public string Validation(EmailModel model)
    {
        if (String.IsNullOrEmpty(model.SourceAddress))
            return EmailModel._SourceAddress &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.SourcePassword))
            return EmailModel._SourcePassword &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.TargetAddress))
            return EmailModel._TargetAddress &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.SourcetHost))
            return EmailModel._SourcetHost &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.Title))
            return EmailModel._Title &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.AttachmentUri))
            return EmailModel._AttachmentUri &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.ImageUri))
            return EmailModel._ImageUri &#43; &quot; is null&quot;;
        if (String.IsNullOrEmpty(model.Text))
            return EmailModel._Text &#43; &quot; is null&quot;;
        if (!ValidEmail(model.SourceAddress))
            return EmailModel._SourceAddress &#43; &quot; is invalid.&quot;;
        if (!ValidEmail(model.TargetAddress))
            return EmailModel._TargetAddress &#43; &quot; is invalid.&quot;;
        return String.Empty; 
    }


    /// &lt;summary&gt;
    /// Email string variable Regular Expression
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;strIn&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public bool ValidEmail(string email)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(
           email, @&quot;^([\w-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)&quot; &#43;
           @&quot;|(([\w-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""></b></p>
<p class="MsoNormal">Step 3. Then we can begin to design our Default page. First, please drag and drop some server controls with a HTML table on the page, customers can input their e-mail information and private messages in TextBox and FileUpload controls.
 Then you need set page��s Async property to ��<b style="">Ture</b>��, because in this sample code, we can also send e-mail asynchronously.</p>
<p class="MsoNormal">Step 4. Add relative method of Send Button and Reset Button clicks events, tbSend_Click and tbReset_Click. The tbSend_Click method is a little complex, we will get all information of the page, then use StringValidation class to make a
 input check, then create a MailMessage class and give these values to it, at last, create a SmtpClient instance for sending email.
</p>
<p class="MsoNormal"><b style="">Note: </b></p>
<p class="MsoNormal"><b style="">Here we give two ways to send email, SmtpClient.Send() method and SmtpClient.SendAsync() method, The former method is simple, you can put your MailMessage instance as the parameter of the method. If you want to use second
 method, you have to create SmtpClient.SendCompleted event method for display error messages or success messages, and you also need to define a State object as sender object to complete event.
</b></p>
<h3>The following code showing how to send e-mail message normally and how to send e-mail message asynchronously.
</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void btnSend_Click(object sender, EventArgs e)
{
    EmailModel model = new EmailModel();
    StringValidation validation = new StringValidation();
    model.SourceAddress = tbEmailAddress.Text.Trim();
    model.SourcePassword = tbEmailPassword.Text.Trim();
    model.TargetAddress = tbTargetEmailAddress.Text.Trim();
    model.SourcetHost = tbSourceHost.Text.Trim();
    model.Title = tbTitle.Text.Trim();
    model.AttachmentUri = fupAttachment.PostedFile.FileName;
    model.ImageUri = fupImage.PostedFile.FileName;
    model.Text = tbText.Text;
    string result = validation.Validation(model);
    if (result.Equals(String.Empty))
    {
        // Collect basic messages of Page and make simple validation.
        MailMessage mail = new MailMessage();
        mail.To.Add(model.TargetAddress);
        mail.From = new MailAddress(model.SourceAddress);
        mail.Subject = model.Title;
        mail.Body = model.Text;
        mail.IsBodyHtml = true;
        Attachment attachment = new Attachment(model.AttachmentUri);
        mail.Attachments.Add(attachment);
        mail.Body &#43;= String.Format(&quot;<p><img src="{0}"></p>&quot;, &quot;cid:imgEmbed&quot;);
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body, null, &quot;text/html&quot;);
        LinkedResource resources = new LinkedResource(model.ImageUri, &quot;image/jpg&quot;);
        resources.ContentId = &quot;imgEmbed&quot;;
        resources.TransferEncoding = TransferEncoding.Base64;
        htmlView.LinkedResources.Add(resources);
        mail.AlternateViews.Add(htmlView);


        SmtpClient client = new SmtpClient();
        object state = mail.Subject;
        client.Host = model.SourcetHost;
        NetworkCredential credential = new NetworkCredential();
        credential.UserName = model.SourceAddress;
        credential.Password = model.SourcePassword;
        client.Credentials = credential;
        client.EnableSsl = true;
        client.Port = 587;


        // Send email asynchronously or not.
        if (Page.IsAsync)
        {
            client.SendCompleted &#43;= new SendCompletedEventHandler(SendCompleted);
            client.SendAsync(mail, state);
        }
        else
        {
            client.Send(mail);
            lbMessage.Text = String.Format(&quot;E-mail-{0} has been sent!&quot;, mail.Subject);
        }
    }
    else
    {
        lbMessage.Text = result;
    }
}
/// &lt;summary&gt;
/// Asynchronous e-mail send complete operation event. 
/// You can create your own exception handing methods base on this method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;obj&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
public void SendCompleted(object obj, AsyncCompletedEventArgs e)
{
    string mailTitle = e.UserState as string;
    if (e.Cancelled)
        lbMessage.Text = String.Format(&quot;Send e-mail canceled: Email Title-{0}&quot;, mailTitle);
    if (e.Error != null)
        lbMessage.Text = String.Format(&quot;Send e-mail error of {0}: {1}&quot;, mailTitle, e.Error.ToString());
    else
        lbMessage.Text = String.Format(&quot;E-mail-{0} has been sent!&quot;, mailTitle);
}

</pre>
<pre id="codePreview" class="csharp">
protected void btnSend_Click(object sender, EventArgs e)
{
    EmailModel model = new EmailModel();
    StringValidation validation = new StringValidation();
    model.SourceAddress = tbEmailAddress.Text.Trim();
    model.SourcePassword = tbEmailPassword.Text.Trim();
    model.TargetAddress = tbTargetEmailAddress.Text.Trim();
    model.SourcetHost = tbSourceHost.Text.Trim();
    model.Title = tbTitle.Text.Trim();
    model.AttachmentUri = fupAttachment.PostedFile.FileName;
    model.ImageUri = fupImage.PostedFile.FileName;
    model.Text = tbText.Text;
    string result = validation.Validation(model);
    if (result.Equals(String.Empty))
    {
        // Collect basic messages of Page and make simple validation.
        MailMessage mail = new MailMessage();
        mail.To.Add(model.TargetAddress);
        mail.From = new MailAddress(model.SourceAddress);
        mail.Subject = model.Title;
        mail.Body = model.Text;
        mail.IsBodyHtml = true;
        Attachment attachment = new Attachment(model.AttachmentUri);
        mail.Attachments.Add(attachment);
        mail.Body &#43;= String.Format(&quot;<p><img src="{0}"></p>&quot;, &quot;cid:imgEmbed&quot;);
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body, null, &quot;text/html&quot;);
        LinkedResource resources = new LinkedResource(model.ImageUri, &quot;image/jpg&quot;);
        resources.ContentId = &quot;imgEmbed&quot;;
        resources.TransferEncoding = TransferEncoding.Base64;
        htmlView.LinkedResources.Add(resources);
        mail.AlternateViews.Add(htmlView);


        SmtpClient client = new SmtpClient();
        object state = mail.Subject;
        client.Host = model.SourcetHost;
        NetworkCredential credential = new NetworkCredential();
        credential.UserName = model.SourceAddress;
        credential.Password = model.SourcePassword;
        client.Credentials = credential;
        client.EnableSsl = true;
        client.Port = 587;


        // Send email asynchronously or not.
        if (Page.IsAsync)
        {
            client.SendCompleted &#43;= new SendCompletedEventHandler(SendCompleted);
            client.SendAsync(mail, state);
        }
        else
        {
            client.Send(mail);
            lbMessage.Text = String.Format(&quot;E-mail-{0} has been sent!&quot;, mail.Subject);
        }
    }
    else
    {
        lbMessage.Text = result;
    }
}
/// &lt;summary&gt;
/// Asynchronous e-mail send complete operation event. 
/// You can create your own exception handing methods base on this method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;obj&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
public void SendCompleted(object obj, AsyncCompletedEventArgs e)
{
    string mailTitle = e.UserState as string;
    if (e.Cancelled)
        lbMessage.Text = String.Format(&quot;Send e-mail canceled: Email Title-{0}&quot;, mailTitle);
    if (e.Error != null)
        lbMessage.Text = String.Format(&quot;Send e-mail error of {0}: {1}&quot;, mailTitle, e.Error.ToString());
    else
        lbMessage.Text = String.Format(&quot;E-mail-{0} has been sent!&quot;, mailTitle);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Build the application and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.mailmessage.aspx">MailMessage Class</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx">SmtpClient Class</a></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.send.aspx">SmtpClient.Send Method</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
