# Membership Providor Function In Self-database (ASPNETMembershipProvider)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Membership
## IsPublished
* True
## ModifiedDate
* 2012-04-25 11:50:36
## Description

<h1>How to use Membership Provider in Self-database(CSASPNETMembershipProvider)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">This demo is mainly showing how to use ASP.NET 2.0 (since) new feature��Membership Provider and to generate all of its related tables and combine them into your own SQL database<span lang="ZH-CN" style="font-family:SimSun">��</span>The
 most difference is that in MSDN<span lang="ZH-CN" style="font-family:SimSun">��</span>you can see it has implemented some classes or interfaces to do your own way<span lang="ZH-CN" style="font-family:SimSun">��</span>compared with this<span lang="ZH-CN" style="font-family:SimSun">��</span>what
 we do is just use aspnet_regsql.exe as well as some specific tools to generated related database's tables into your own database<span lang="ZH-CN" style="font-family:SimSun">��</span>and then change the Membership Provider to your own DB's connection<span lang="ZH-CN" style="font-family:SimSun">��</span>which
 means all of the functions are inherited from Microsoft's ones<span lang="ZH-CN" style="font-family:SimSun">��</span>So you don't need to write any codes about membership but just call them<span lang="ZH-CN" style="font-family:SimSun">��</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
Step 1:&nbsp;Open the <span style="">CSASPNETMembershipProvider</span>.sln. Expand the
<a name="OLE_LINK1"></a><span class="SpellE"><span style=""><span style="">CSASPNETMembershipProvider</span></span></span><span style="">
</span>web application.<span style="font-size:9.5pt; font-family:Consolas"> Right click
</span>CreateUser<span style="font-size:9.5pt; font-family:Consolas">.aspx and choose &quot;View in Browser&quot; to create a new user.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal"><b style=""><span style="">&nbsp;</span>[Note]</b> <b style="">
You may need to install the SQL Server 2008 r2 express. You can download it here:
<a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=3743">
http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=3743</a> </b>
</p>
<p class="MsoNormal">Step 2: Then press Ctrl &#43; F5 to show the Default.aspx. </p>
<p class="MsoNormal">Step 3:<span style="">&nbsp;&nbsp; </span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a new database in SQL Server. Name it as ��<span style="">MembershipProviderTest</span>&quot;.
<span style="">&nbsp;&nbsp; </span></p>
<p class="MsoNormal">Step 2. Use the command-line tool aspnet_regsql.exe (located in the Framework folder) to create the tables and procedures used by the
<span style="">Membership Provider</span>.<span style=""> </span></p>
<p class="MsoNormal">Step 3. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as ��<span class="SpellE"><span style="">CSASPNETMembershipProvider</span></span>&quot;.
</p>
<p class="MsoNormal">Step 4.<span style="">&nbsp; </span>Add five Page then rename them to ��CreateUser.aspx��,�� Login.aspx��,��ChangePassword.aspx��,��<span style="">
<span style="color:black">RecoveryPassword.aspx</span></span>�� and ��Default.aspx��.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Add a CreateUserWizard Control to the CreateUser page, the code as show below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">  
&lt;asp:CreateUserWizard ID=&quot;CreateUserWizard1&quot; runat=&quot;server&quot; ActiveStepIndex=&quot;0&quot; ContinueDestinationPageUrl=&quot;~/Default.aspx&quot;&gt;
        &lt;WizardSteps&gt;
          &lt;asp:CreateUserWizardStep ID=&quot;CreateUserWizardStep1&quot; runat=&quot;server&quot;&gt;
          &lt;/asp:CreateUserWizardStep&gt;
          &lt;asp:CompleteWizardStep ID=&quot;CompleteWizardStep1&quot; runat=&quot;server&quot;&gt;
          &lt;/asp:CompleteWizardStep&gt;
        &lt;/WizardSteps&gt;
      &lt;/asp:CreateUserWizard&gt;

</pre>
<pre id="codePreview" class="csharp">  
&lt;asp:CreateUserWizard ID=&quot;CreateUserWizard1&quot; runat=&quot;server&quot; ActiveStepIndex=&quot;0&quot; ContinueDestinationPageUrl=&quot;~/Default.aspx&quot;&gt;
        &lt;WizardSteps&gt;
          &lt;asp:CreateUserWizardStep ID=&quot;CreateUserWizardStep1&quot; runat=&quot;server&quot;&gt;
          &lt;/asp:CreateUserWizardStep&gt;
          &lt;asp:CompleteWizardStep ID=&quot;CompleteWizardStep1&quot; runat=&quot;server&quot;&gt;
          &lt;/asp:CompleteWizardStep&gt;
        &lt;/WizardSteps&gt;
      &lt;/asp:CreateUserWizard&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Add a <span style="">Login Control to the Login page, the code as show below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;asp:Login ID=&quot;Login1&quot; runat=&quot;server&quot;&gt;
       &lt;/asp:Login&gt;

</pre>
<pre id="codePreview" class="csharp">
&lt;asp:Login ID=&quot;Login1&quot; runat=&quot;server&quot;&gt;
       &lt;/asp:Login&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Add a <span style="">ChangePassword Control to the ChangePassword page.</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
Add a <span style="">PasswordRecovery Control to the PasswordRecoverypage. </span>
</p>
<p class="MsoNormal"><span style="">Finally, add a LoginStatus Control to the Default page.
</span></p>
<p class="MsoNormal"><br>
Step 5.<span style="">&nbsp; </span>Now, begin to edit the web.xml.</p>
<p class="MsoNormal">First, configure the Connection Strings as show below; <span style="">
you can try the </span>connectionString1 <span style="">or </span>connectionString<span style="">2.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;connectionStrings&gt;
   &lt;!-- Clear the default connection. --&gt;
   &lt;clear/&gt;
   
   &lt;!��-connectionString1: Connect to the database in the App_Data folder --&gt;
   &lt;add name=&quot;LocalSqlServer&quot; providerName=&quot;System.Data.SqlClient&quot; connectionString=&quot;Data Source=.\SQLExpress;Integrated Security=True;User Instance=True;AttachDBFilename=|DataDirectory|MembershipProviderTest.mdf&quot;/&gt;


   &lt;!��-connectionString2: Connect to the database which has been attached to the database manager. --&gt;
   &lt;!--&lt;add name=&quot;LocalSqlServer&quot; connectionString=&quot;Data Source=.;Initial Catalog=D:\PROJECTDIR\NET\CSASPNETMEMBERSHIPPROVIDER\CSASPNETMEMBERSHIPPROVIDER\APP_DATA\MEMBERSHIPPROVIDERTEST.MDF;Integrated Security=True&quot;/&gt;--&gt;
 &lt;/connectionStrings&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;connectionStrings&gt;
   &lt;!-- Clear the default connection. --&gt;
   &lt;clear/&gt;
   
   &lt;!��-connectionString1: Connect to the database in the App_Data folder --&gt;
   &lt;add name=&quot;LocalSqlServer&quot; providerName=&quot;System.Data.SqlClient&quot; connectionString=&quot;Data Source=.\SQLExpress;Integrated Security=True;User Instance=True;AttachDBFilename=|DataDirectory|MembershipProviderTest.mdf&quot;/&gt;


   &lt;!��-connectionString2: Connect to the database which has been attached to the database manager. --&gt;
   &lt;!--&lt;add name=&quot;LocalSqlServer&quot; connectionString=&quot;Data Source=.;Initial Catalog=D:\PROJECTDIR\NET\CSASPNETMEMBERSHIPPROVIDER\CSASPNETMEMBERSHIPPROVIDER\APP_DATA\MEMBERSHIPPROVIDERTEST.MDF;Integrated Security=True&quot;/&gt;--&gt;
 &lt;/connectionStrings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Second, configure the CreateUser pa<span style="">ge and </span><span style="">the
</span><span style="">security authentication mode:</span><span style=""> </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;location path=&quot;CreateUser.aspx&quot;&gt;
   &lt;system.web&gt;
     &lt;authorization&gt;
       &lt;allow users=&quot;?&quot; /&gt;
     &lt;/authorization&gt;
   &lt;/system.web&gt;
 &lt;/location&gt;




&lt;!--


           
The &lt;authentication&gt; section enables configuration 


           
of the security authentication mode used by 


           
ASP.NET to identify an incoming user. 


        --&gt;


    &lt;authentication mode=&quot;Forms&quot; &gt;


      &lt;forms loginUrl=&quot;login.aspx&quot;


        name=&quot;.ASPXFORMSAUTH&quot;  /&gt;


    &lt;/authentication&gt;






    &lt;authorization&gt;


      &lt;deny users=&quot;?&quot; /&gt;


    &lt;/authorization&gt;



</pre>
<pre id="codePreview" class="xml">
&lt;location path=&quot;CreateUser.aspx&quot;&gt;
   &lt;system.web&gt;
     &lt;authorization&gt;
       &lt;allow users=&quot;?&quot; /&gt;
     &lt;/authorization&gt;
   &lt;/system.web&gt;
 &lt;/location&gt;




&lt;!--


           
The &lt;authentication&gt; section enables configuration 


           
of the security authentication mode used by 


           
ASP.NET to identify an incoming user. 


        --&gt;


    &lt;authentication mode=&quot;Forms&quot; &gt;


      &lt;forms loginUrl=&quot;login.aspx&quot;


        name=&quot;.ASPXFORMSAUTH&quot;  /&gt;


    &lt;/authentication&gt;






    &lt;authorization&gt;


      &lt;deny users=&quot;?&quot; /&gt;


    &lt;/authorization&gt;



</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&lt;!-- </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:green"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>The &lt;authentication&gt; section enables configuration </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:green"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>of the security authentication mode used by </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:green"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ASP.NET to identify an incoming user. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:green"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">--&gt;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">authentication</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">
</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">mode</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">&quot;<span style="color:blue">Forms</span>&quot;<span style="color:blue">
 &gt; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">forms</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">
</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">loginUrl</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">&quot;<span style="color:blue">login.aspx</span>&quot;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">name</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">&quot;<span style="color:blue">.ASPXFORMSAUTH</span>&quot;<span style="color:blue"><span style="">&nbsp;
</span>/&gt; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;</span><span style="">&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">authentication</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">authorization</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">deny</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">
</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">users</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">&quot;<span style="color:blue">?</span>&quot;<span style="color:blue">
 /&gt; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">authorization</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;</span>Finally, configure the membership<span style=""> to
</span>AspNetSqlMembershipProvider<span style="">:</span><span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!--Build-in Provider Configuration--&gt;


  &lt;membership defaultProvider=&quot;AspNetSqlMembershipProvider&quot; userIsOnlineTimeWindow=&quot;15&quot;&gt;
    &lt;providers&gt;
    &lt;/providers&gt;
  &lt;/membership&gt;
  &lt;!--Build-in Provider Configuration--&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!--Build-in Provider Configuration--&gt;


  &lt;membership defaultProvider=&quot;AspNetSqlMembershipProvider&quot; userIsOnlineTimeWindow=&quot;15&quot;&gt;
    &lt;providers&gt;
    &lt;/providers&gt;
  &lt;/membership&gt;
  &lt;!--Build-in Provider Configuration--&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style="">[Note] </b>If you want to use <span style="color:black">
Recovery Password</span>, you must configure <span style="color:maroon">mailSettings
</span>your own:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;system.net&gt;
   &lt;mailSettings&gt;    
     &lt;smtp deliveryMethod=&quot;Network&quot; from=&quot;*@server.com&quot;&gt;
       &lt;network host=&quot;*&quot; password=&quot;*****&quot; port=&quot;25&quot; userName=&quot;*****&quot; defaultCredentials=&quot;true&quot;/&gt;
     &lt;/smtp&gt;
   &lt;/mailSettings&gt;
 &lt;/system.net&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;system.net&gt;
   &lt;mailSettings&gt;    
     &lt;smtp deliveryMethod=&quot;Network&quot; from=&quot;*@server.com&quot;&gt;
       &lt;network host=&quot;*&quot; password=&quot;*****&quot; port=&quot;25&quot; userName=&quot;*****&quot; defaultCredentials=&quot;true&quot;/&gt;
     &lt;/smtp&gt;
   &lt;/mailSettings&gt;
 &lt;/system.net&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step <span style="">6</span>. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.security.sqlmembershipprovider.aspx">SqlMembershipProvider Class</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.security.membership.aspx">Membership Class</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
