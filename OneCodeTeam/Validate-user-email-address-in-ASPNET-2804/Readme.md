# Validate user email address in ASP.NET (CSASPNETEmailAddressValidator)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Email address
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:58:40
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETEmailAddressValidator Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to send a confirmation Email to check whether an<br>
Email address is available.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSASPNETEmailAddressValidator.sln.<br>
<br>
Step 2: Expand the CSASPNETEmailAddressValidator website and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: We will see a Wizard. In the first step, input a SMTP server name or<br>
&nbsp; &nbsp; &nbsp; &nbsp;IP address and one Email address based on that SMTP server and its<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;password. We need to use this to send the confirmation Email.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In this sample, we use Hotmail, so if you have a hotmail, you can<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input your hotmail address and password and then click Next.<br>
<br>
Step 4: In the second step, input an Email address which need to be validated.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Of course, you need to see the message to process the next step.<br>
<br>
Step 5: Open the mail message which you have received. Click the link or copy the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;link address to the browser and you can see a 'Congratulation' message.<br>
<br>
Step 6: Validation finished.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp; Visual Web Developer 2010. Name it as &quot;CSASPNETEmailAddressValidator&quot;.<br>
<br>
Step 2. &nbsp;Add two folders, &quot;Handler&quot; and &quot;Module&quot;.<br>
<br>
Step 3. &nbsp;Add a new database file in the App_Data and create a new table called,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &quot;tblEmailValidation&quot;. Add six columns which are illustrated like below:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; id: the identity key of the table;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EmailAddress: store the Email address which need to be validated;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IsValidated: store a bit to check whether the validation is completed.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IsSendCheckEmail: store a bit to check whether the message has been sent.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ValidatingStartTime: store the datetime which start the validation.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ValdateKey: a unique key which used to tell different validation links.<br>
<br>
Step 4. &nbsp;Add a new Linq to SQL class in the Module folder and name it as <br>
&nbsp; &nbsp; &nbsp; &nbsp; EmailAddressValidation.dbml. Open the Server Explorer, create a connection<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; to the EmailValidationDB.mdf and drag the tblEmailValidation table and<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; drop it to the desktop of the EmailAddressValidation.dbml. Then build the<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; project.<br>
<br>
Step 5. &nbsp;Create a new class file, name it as EmailValidation.cs. Write the codes<br>
&nbsp; &nbsp; &nbsp; &nbsp; like the sample and we can find more details from the comments
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; in the sample file.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Step 6. &nbsp;Create a new HttpHandler in the Handler folder. Write the codes like the<br>
&nbsp; &nbsp; &nbsp; &nbsp; sample and we can find more details from the comments in the sample file.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 7. &nbsp;Modify the Webform1.aspx to Default.aspx and create a Wizard control there.<br>
&nbsp; &nbsp; &nbsp; &nbsp; Follow the sample to complete the markups.<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
Step 8. &nbsp;Open the Default.aspx.cs. Write the codes like the sample. You can get more<br>
&nbsp; &nbsp; &nbsp; &nbsp; details from the comments in the sample file.<br>
<br>
Step 9. &nbsp;Open the web.config. Add a new HttpHandler like below in the &lt;system.web&gt;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; node.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [Code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;httpHandlers&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;add path=&quot;mail.axd&quot; verb=&quot;GET&quot; validate=&quot;false&quot; type=&quot;CSASPNETEmailAddresseValidator.Handler.EmailAvailableValidationHandler&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;/httpHandlers&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; [/Code] &nbsp;<br>
<br>
Step 10. Build the application and you can debug it.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: SmtpClient Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx</a><br>
<br>
MSDN: SQL-CLR Type Mapping (LINQ to SQL)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386947.aspx">http://msdn.microsoft.com/en-us/library/bb386947.aspx</a><br>
<br>
MSDN: HttpHandlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/5c67a8bd(VS.71).aspx">http://msdn.microsoft.com/en-us/library/5c67a8bd(VS.71).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
