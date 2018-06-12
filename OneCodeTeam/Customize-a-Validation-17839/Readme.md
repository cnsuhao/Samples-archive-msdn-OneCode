# Customize a Validation
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* ASP.NET
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:35:41
## Description

<h1>How to customize a validation in a general ASP.NET <span class="SpellE">CustomValidator</span> control (<span class="SpellE"><span style="">CSASPNETCustomizeValidation</span></span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The CSASPNETCustomizeValidation sample shows you how to use a Customized Validation control to do your own validations with the help of CustomValidation.</span><span style="">
<span style="">Though Microsoft has offered us quite a lot of validation controls such as RequiredValidation, CompareValidation</span></span><span style=""> etc</span><span style="">. However, sometimes these controls don't meet our real needs. For example,
 in a login form</span><span style="">, usually </span><span style="">we want to do validations to check whether an email has been registered or not by using a validation control</span><span style="">. In this scenario,
</span><span style="">a Customized Validation is needed</span><span style="">. </span>
<span style=""></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETCustomizeValidation.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;. Type an email then click the button to test.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For invalid email: <br>
<span style=""><img src="/site/view/file/91795/1/image.png" alt="" width="345" height="85" align="middle">
</span><br>
For existing email: <span style=""><br>
<img src="/site/view/file/91796/1/image.png" alt="" width="577" height="74" align="middle">
</span><br>
For legitimate and <a name="OLE_LINK5"></a><a name="OLE_LINK4"><span style="">non-existent
</span></a>email:<span style=""><br>
<img src="/site/view/file/91797/1/image.png" alt="" width="367" height="64" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation finished.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a C# &quot;ASP.NET Web Application&quot; in Visual Studio 2008/Visual Web Developer. Name it as &quot;CSASPNETCustomizeValidation&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. If you have installed SQL server 2008 r2 express on your computer, you can directly use the sample database under the App_Data. If not, add a SQL Server Database in the App_Data folder and name it as &quot;MyDB&quot;. The definition of
 the table &quot;User&quot; as shown below: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">[Id] [int] <span class="GramE">IDENTITY(</span>1,1) NOT NULL,[Email] [</span><span style="color:black">nvarchar</span><span style="">](</span><span style="color:black"> 50</span><span style="">)
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">You can insert the following test data or add new data: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">

INSERT [dbo].[User] ([ID], [Email]) VALUES (1, N'test@microsoft.com')
INSERT [dbo].[User] ([ID], [Email]) VALUES (2, N'test1@microsoft.com')
INSERT [dbo].[User] ([ID], [Email]) VALUES (3, N'test2@microsoft.com')

</pre>
<pre id="codePreview" class="mysql">

INSERT [dbo].[User] ([ID], [Email]) VALUES (1, N'test@microsoft.com')
INSERT [dbo].[User] ([ID], [Email]) VALUES (2, N'test1@microsoft.com')
INSERT [dbo].[User] ([ID], [Email]) VALUES (3, N'test2@microsoft.com')

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Add a success page. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;body&gt;
    &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
    <div>
    Successfully Registered!
    </div>
    &lt;/form&gt;
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
    <div>
    Successfully Registered!
    </div>
    &lt;/form&gt;
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step4. Edit the Default.aspx Page. It is used to test <span style="">your own validations</span>.<span style="">&nbsp;
</span>Add a TextBox Control, a Button Control and a CustomValidator Control on this page. Add
</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">OnServerValidate</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">
</span><span style="">event for</span><span style=""> CustomValidator</span><span lang="ZH-CN" style="font-family:宋体">：</span><span lang="ZH-CN" style="">
</span><span style=""><br>
The main code of</span><span style=""> </span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">OnServerValidate</span><span style="">
</span><span style="">as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
{
    //Control To Validate:which control to type email
    TextBox tb = Page.FindControl(CustomValidator1.ControlToValidate) as TextBox;
    //email text
    string strEmail = tb.Text.Trim();
    //flag of exist
    int intNum = 0;


    //Regex for email.
    string strRegex = @&quot;^([a-zA-Z0-9_\-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;;
    Regex re = new Regex(strRegex);


    //Verify that whether the email format is valid or not, if valid and then query the database to check
    //determine whether the email is exists, otherwise set isvalid value to false.
    if (re.IsMatch(strEmail))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = &quot;select count(1) from [user] where email=@email&quot;;
        cmd.Parameters.Add(&quot;@email&quot;, SqlDbType.NVarChar).Value = strEmail;
        cmd.CommandType = CommandType.Text;
        conn.Open();
        intNum = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
    }
    else
    {
        CustomValidator1.ErrorMessage = &quot;Invalid Email!&quot;;
        args.IsValid = false;
        return;
    }


    //Determine whether it exists or not
    if (intNum &gt; 0)
    {
        CustomValidator1.ErrorMessage = &quot;Cannot use the email address, because it exists!&quot;;
        args.IsValid = false;
    }
    else
    {
        args.IsValid = true;
    }         
}

</pre>
<pre id="codePreview" class="csharp">
protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
{
    //Control To Validate:which control to type email
    TextBox tb = Page.FindControl(CustomValidator1.ControlToValidate) as TextBox;
    //email text
    string strEmail = tb.Text.Trim();
    //flag of exist
    int intNum = 0;


    //Regex for email.
    string strRegex = @&quot;^([a-zA-Z0-9_\-\.]&#43;)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]&#43;\.)&#43;))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$&quot;;
    Regex re = new Regex(strRegex);


    //Verify that whether the email format is valid or not, if valid and then query the database to check
    //determine whether the email is exists, otherwise set isvalid value to false.
    if (re.IsMatch(strEmail))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = &quot;select count(1) from [user] where email=@email&quot;;
        cmd.Parameters.Add(&quot;@email&quot;, SqlDbType.NVarChar).Value = strEmail;
        cmd.CommandType = CommandType.Text;
        conn.Open();
        intNum = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
    }
    else
    {
        CustomValidator1.ErrorMessage = &quot;Invalid Email!&quot;;
        args.IsValid = false;
        return;
    }


    //Determine whether it exists or not
    if (intNum &gt; 0)
    {
        CustomValidator1.ErrorMessage = &quot;Cannot use the email address, because it exists!&quot;;
        args.IsValid = false;
    }
    else
    {
        args.IsValid = true;
    }         
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The main code of </span><span class="SpellE"><span style="color:black">btnRegister_<span class="GramE">Click</span></span></span><span class="GramE"><span style=""><span style="">&nbsp;
</span>event</span></span><span style=""> as shown below</span><span style="">, you can type your own logic code here:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void btnRegister_Click(object sender, EventArgs e)
       {
           // If page is IsValid then jump to another page 
           if (IsValid)
           {
               Response.Redirect(&quot;success.aspx&quot;);
           }          
       }

</pre>
<pre id="codePreview" class="csharp">
protected void btnRegister_Click(object sender, EventArgs e)
       {
           // If page is IsValid then jump to another page 
           if (IsValid)
           {
               Response.Redirect(&quot;success.aspx&quot;);
           }          
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<a name="OLE_LINK3"></a><a name="OLE_LINK2"><span style="">Register</span></a>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5.<b style=""> </b>Build the application and you can debug it.<b style="">
</b></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>