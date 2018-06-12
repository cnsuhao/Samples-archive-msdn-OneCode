# Sending email via SMTP protocol in Asp.net (VBASPNETSendingEmail)
## Requires
* Visual Studio 2008
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
* 2012-04-20 01:13:02
## Description

<h1>Sending email via Asp.net web form application (VBASPNETSendingEmail)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to send an email with attachments and embedded images using SMTP protoc<b style="">o</b>l in Asp.net. This is a very common issue in forums, customers always fall into troubles when they try to implement
 relative APIs, that is because they receive many errors or exceptions, so we provide this sample code to show how to send an email with your web application, and this sample also demonstrates how to send emails asynchronously for improving user experience.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">VBASPNETSendingEmail</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">VBASPNETSendingEmail</span> </a>web application and press Ctrl &#43; F5 to show the Default.aspx.
</p>
<p class="MsoNormal">Step 2: We will see a web page that we can input email information, for example you can input e-mail account and password for login, and Target Email address is the people you want to send message to him, The Target email host is the
 SMTP address of your email. For example, if you use Hotmail mailbox, you can input ��smtp.live.com��, if you use google��s email, you can input ��smpt.gmail.com��, etc.<span style="">&nbsp;
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56424/1/image.png" alt="" width="831" height="702" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span style="">&nbsp; </span>After all above works finished, you can click Send Now! Button for send email or click Reset Email for re-writer email��s content. In this sample, all TextBox and FileUpload controls need been added,
 you can change this rule by modify the code. Now let��s look the result of send success.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56425/1/image.png" alt="" width="831" height="702" align="middle">
</span></p>
<p class="MsoNormal">Step 4: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2008. Name it as ��<span style="">VBASPNETSendingEmail</span>&quot;. Add one web form pages and name it as ��Default.aspx�� page, the input controls and buttons
 are in this page, customers can view this page for sending email.</p>
<p class="MsoNormal">Step 2. Add two class files and name them as ��EmailModel.vb�� and ��StringValidation.vb��. The EmailModel class is used to define basic properties of an email message, such as SourceAddress, SourcePassword, TargetAddress, etc. The StringValidation
 class is used to check user��s input and return error information, for easy to show core functions, we only check the string variables is null and email string variables�� format.</p>
<h3>The following code shows how to make a simple validation class.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Email information validation.
''' &lt;/summary&gt;
''' &lt;param name=&quot;model&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function Validation(ByVal model As EmailModel) As String
    If [String].IsNullOrEmpty(model.SourceAddress) Then
        Return EmailModel.__SourceAddress &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.SourcePassword) Then
        Return EmailModel.__SourcePassword &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.TargetAddress) Then
        Return EmailModel.__TargetAddress &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.SourcetHost) Then
        Return EmailModel.__SourcetHost &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.Title) Then
        Return EmailModel.__Title &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.AttachmentUri) Then
        Return EmailModel.__AttachmentUri &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.ImageUri) Then
        Return EmailModel.__ImageUri &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.Text) Then
        Return EmailModel.__Text &#43; &quot; is null&quot;
    End If
    If Not ValidEmail(model.SourceAddress) Then
        Return EmailModel.__SourceAddress &#43; &quot; is invalid.&quot;
    End If
    If Not ValidEmail(model.TargetAddress) Then
        Return EmailModel.__TargetAddress &#43; &quot; is invalid.&quot;
    End If
    Return [String].Empty
End Function


''' &lt;summary&gt;
''' Email string variable Regular Expression
''' &lt;/summary&gt;
''' &lt;param name=&quot;email&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function ValidEmail(ByVal email As String) As Boolean
    ' Return true if strIn is in valid e-mail format.
    Return Regex.IsMatch(email, &quot;^([\w-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)&quot; & &quot;|(([\w-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;)
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Email information validation.
''' &lt;/summary&gt;
''' &lt;param name=&quot;model&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function Validation(ByVal model As EmailModel) As String
    If [String].IsNullOrEmpty(model.SourceAddress) Then
        Return EmailModel.__SourceAddress &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.SourcePassword) Then
        Return EmailModel.__SourcePassword &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.TargetAddress) Then
        Return EmailModel.__TargetAddress &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.SourcetHost) Then
        Return EmailModel.__SourcetHost &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.Title) Then
        Return EmailModel.__Title &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.AttachmentUri) Then
        Return EmailModel.__AttachmentUri &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.ImageUri) Then
        Return EmailModel.__ImageUri &#43; &quot; is null&quot;
    End If
    If [String].IsNullOrEmpty(model.Text) Then
        Return EmailModel.__Text &#43; &quot; is null&quot;
    End If
    If Not ValidEmail(model.SourceAddress) Then
        Return EmailModel.__SourceAddress &#43; &quot; is invalid.&quot;
    End If
    If Not ValidEmail(model.TargetAddress) Then
        Return EmailModel.__TargetAddress &#43; &quot; is invalid.&quot;
    End If
    Return [String].Empty
End Function


''' &lt;summary&gt;
''' Email string variable Regular Expression
''' &lt;/summary&gt;
''' &lt;param name=&quot;email&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function ValidEmail(ByVal email As String) As Boolean
    ' Return true if strIn is in valid e-mail format.
    Return Regex.IsMatch(email, &quot;^([\w-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)&quot; & &quot;|(([\w-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Sending e-mail message.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
    Dim model As New EmailModel()
    Dim validation As New StringValidation()
    model.SourceAddress = tbEmailAddress.Text.Trim()
    model.SourcePassword = tbEmailPassword.Text.Trim()
    model.TargetAddress = tbTargetEmailAddress.Text.Trim()
    model.SourcetHost = tbSourceHost.Text.Trim()
    model.Title = tbTitle.Text.Trim()
    model.AttachmentUri = fupAttachment.PostedFile.FileName
    model.ImageUri = fupImage.PostedFile.FileName
    model.Text = tbText.Text
    Dim result As String = validation.Validation(model)
    If result.Equals([String].Empty) Then
        ' Collect basic messages of Page and make simple validation.
        Dim mail As New MailMessage()
        mail.[To].Add(model.TargetAddress)
        mail.From = New MailAddress(model.SourceAddress)
        mail.Subject = model.Title
        mail.Body = model.Text
        mail.IsBodyHtml = True
        Dim attachment As New Attachment(model.AttachmentUri)
        mail.Attachments.Add(attachment)
        mail.Body &#43;= [String].Format(&quot;<p><img src="{0}"></p>&quot;, &quot;cid:imgEmbed&quot;)
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(mail.Body, Nothing, &quot;text/html&quot;)
        Dim resources As New LinkedResource(model.ImageUri, &quot;image/jpg&quot;)
        resources.ContentId = &quot;imgEmbed&quot;
        resources.TransferEncoding = TransferEncoding.Base64
        htmlView.LinkedResources.Add(resources)
        mail.AlternateViews.Add(htmlView)


        Dim client As New SmtpClient()
        Dim state As Object = mail.Subject
        client.Host = model.SourcetHost
        Dim credential As New NetworkCredential()
        credential.UserName = model.SourceAddress
        credential.Password = model.SourcePassword
        client.Credentials = credential
        client.EnableSsl = True
        client.Port = 587


        ' Send email asynchronously or not.
        If Page.IsAsync Then
            AddHandler client.SendCompleted, AddressOf SendCompleted
            client.SendAsync(mail, state)
        Else
            client.Send(mail)
            lbMessage.Text = [String].Format(&quot;E-mail-{0} has been sent!&quot;, mail.Subject)
        End If
    Else
        lbMessage.Text = result
    End If
End Sub


''' &lt;summary&gt;
''' Asynchronous e-mail send complete operation event. 
''' You can create your own exception handing methods base on this method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;obj&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
Public Sub SendCompleted(ByVal obj As Object, ByVal e As AsyncCompletedEventArgs)
    Dim mailTitle As String = TryCast(e.UserState, String)
    If e.Cancelled Then
        lbMessage.Text = [String].Format(&quot;Send e-mail canceled: Email Title-{0}&quot;, mailTitle)
    End If
    If e.[Error] IsNot Nothing Then
        lbMessage.Text = [String].Format(&quot;Send e-mail error of {0}: {1}&quot;, mailTitle, e.[Error].ToString())
    Else
        lbMessage.Text = [String].Format(&quot;E-mail-{0} has been sent!&quot;, mailTitle)
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Sending e-mail message.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
    Dim model As New EmailModel()
    Dim validation As New StringValidation()
    model.SourceAddress = tbEmailAddress.Text.Trim()
    model.SourcePassword = tbEmailPassword.Text.Trim()
    model.TargetAddress = tbTargetEmailAddress.Text.Trim()
    model.SourcetHost = tbSourceHost.Text.Trim()
    model.Title = tbTitle.Text.Trim()
    model.AttachmentUri = fupAttachment.PostedFile.FileName
    model.ImageUri = fupImage.PostedFile.FileName
    model.Text = tbText.Text
    Dim result As String = validation.Validation(model)
    If result.Equals([String].Empty) Then
        ' Collect basic messages of Page and make simple validation.
        Dim mail As New MailMessage()
        mail.[To].Add(model.TargetAddress)
        mail.From = New MailAddress(model.SourceAddress)
        mail.Subject = model.Title
        mail.Body = model.Text
        mail.IsBodyHtml = True
        Dim attachment As New Attachment(model.AttachmentUri)
        mail.Attachments.Add(attachment)
        mail.Body &#43;= [String].Format(&quot;<p><img src="{0}"></p>&quot;, &quot;cid:imgEmbed&quot;)
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(mail.Body, Nothing, &quot;text/html&quot;)
        Dim resources As New LinkedResource(model.ImageUri, &quot;image/jpg&quot;)
        resources.ContentId = &quot;imgEmbed&quot;
        resources.TransferEncoding = TransferEncoding.Base64
        htmlView.LinkedResources.Add(resources)
        mail.AlternateViews.Add(htmlView)


        Dim client As New SmtpClient()
        Dim state As Object = mail.Subject
        client.Host = model.SourcetHost
        Dim credential As New NetworkCredential()
        credential.UserName = model.SourceAddress
        credential.Password = model.SourcePassword
        client.Credentials = credential
        client.EnableSsl = True
        client.Port = 587


        ' Send email asynchronously or not.
        If Page.IsAsync Then
            AddHandler client.SendCompleted, AddressOf SendCompleted
            client.SendAsync(mail, state)
        Else
            client.Send(mail)
            lbMessage.Text = [String].Format(&quot;E-mail-{0} has been sent!&quot;, mail.Subject)
        End If
    Else
        lbMessage.Text = result
    End If
End Sub


''' &lt;summary&gt;
''' Asynchronous e-mail send complete operation event. 
''' You can create your own exception handing methods base on this method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;obj&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
Public Sub SendCompleted(ByVal obj As Object, ByVal e As AsyncCompletedEventArgs)
    Dim mailTitle As String = TryCast(e.UserState, String)
    If e.Cancelled Then
        lbMessage.Text = [String].Format(&quot;Send e-mail canceled: Email Title-{0}&quot;, mailTitle)
    End If
    If e.[Error] IsNot Nothing Then
        lbMessage.Text = [String].Format(&quot;Send e-mail error of {0}: {1}&quot;, mailTitle, e.[Error].ToString())
    Else
        lbMessage.Text = [String].Format(&quot;E-mail-{0} has been sent!&quot;, mailTitle)
    End If
End Sub

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
