# How to use SQL Azure mke asp.net membership work on your Azure webrole
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* Microsoft Azure
## Topics
* Azure
## IsPublished
* False
## ModifiedDate
* 2013-06-13 10:56:14
## Description

<h1>How to use Asp.net membership with SQL Azure (CSAzureMembershipWithSQLAzure)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">When upgrade Asp.net application to Windows Azure platform, upgrade local SQL server database to SQL Azure is a good choice.
</p>
<p class="MsoNormal">But SQL Azure is not as same as SQL Server, when anyone wants to create membership tables by aspnet_regsql, he may got an error because sysdatabases table can't be accessed in SQL Azure.
</p>
<p class="MsoNormal">So this sample will show you how to create membership table and make your Azure app connect to SQL Azure.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">In page default.aspx, click Members-only Page1.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84775/1/image.png" alt="" width="576" height="224" align="middle">
</span></p>
<p class="MsoNormal">If you haven't sign in, you will redirect to page login.aspx.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84776/1/image.png" alt="" width="410" height="219" align="middle">
</span></p>
<p class="MsoNormal">Else you will redirect to page MemberPage1.aspx</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84777/1/image.png" alt="" width="376" height="147" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1: Download the aspnet_regsqlazure.zip from <a href="http://archive.msdn.microsoft.com/KB2006191/Release/ProjectReleases.aspx?ReleaseId=3539">
Updated ASP.NET scripts for use with SQL Azure</a> . </p>
<p class="MsoNormal">Step 2: Execute the InstallCommon.sql first in your SQL Azure.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84778/1/image.png" alt="" width="197" height="193" align="middle">
</span></p>
<p class="MsoNormal">Step 3: Execute the others .sql script in your SQL server management studio.
</p>
<p class="MsoNormal">Step 4: Get the SQL Azure Database connect string from Azure portal and past it in web.config connectionstring.</p>
<p class="MsoNormal">Step 5: Delete the AspNetSqlMembershipProvider which defined in machine.config, and redefine it in web.config.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;system.web&gt;
&nbsp;&nbsp; &lt;roleManager enabled=&quot;true&quot; /&gt;
&nbsp;&nbsp; &lt;authentication mode=&quot;Forms&quot; /&gt;
&nbsp;&nbsp; &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
&nbsp;&nbsp; &lt;membership&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;providers&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;remove name=&quot;AspNetSqlMembershipProvider&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add name=&quot;AspNetSqlMembershipProvider&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; type=&quot;System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connectionStringName=&quot;aspnet_membership&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; enablePasswordRetrieval=&quot;false&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; enablePasswordReset=&quot;true&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requiresQuestionAndAnswer=&quot;true&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; applicationName=&quot;/&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requiresUniqueEmail=&quot;false&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordFormat=&quot;Hashed&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; maxInvalidPasswordAttempts=&quot;5&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; minRequiredPasswordLength=&quot;7&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; minRequiredNonalphanumericCharacters=&quot;1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordAttemptWindow=&quot;10&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordStrengthRegularExpression=&quot;&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;/providers&gt;
&nbsp;&nbsp; &lt;/membership&gt;
 &lt;/system.web&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;system.web&gt;
&nbsp;&nbsp; &lt;roleManager enabled=&quot;true&quot; /&gt;
&nbsp;&nbsp; &lt;authentication mode=&quot;Forms&quot; /&gt;
&nbsp;&nbsp; &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
&nbsp;&nbsp; &lt;membership&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;providers&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;remove name=&quot;AspNetSqlMembershipProvider&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add name=&quot;AspNetSqlMembershipProvider&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; type=&quot;System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connectionStringName=&quot;aspnet_membership&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; enablePasswordRetrieval=&quot;false&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; enablePasswordReset=&quot;true&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requiresQuestionAndAnswer=&quot;true&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; applicationName=&quot;/&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requiresUniqueEmail=&quot;false&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordFormat=&quot;Hashed&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; maxInvalidPasswordAttempts=&quot;5&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; minRequiredPasswordLength=&quot;7&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; minRequiredNonalphanumericCharacters=&quot;1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordAttemptWindow=&quot;10&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; passwordStrengthRegularExpression=&quot;&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;/providers&gt;
&nbsp;&nbsp; &lt;/membership&gt;
 &lt;/system.web&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 6: Create the access rule in your asp.net configuration.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84779/1/image.png" alt="" width="576" height="177" align="middle">
</span></p>
<p class="MsoNormal">Step 7: Ctrl&#43;F5 execute the program. </p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><a href="http://support.microsoft.com/kb/2006191?wa=wsignin1.0">http://support.microsoft.com/kb/2006191?wa=wsignin1.0</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
