# 3 Tier ASP.NET Web App wit Entity Framework (and Self Tracking Objects)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* Entity Framework
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:37:23
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">To build this sample successfully, please make sure you have installed<span> Windows Azure SDK 1.6 and SQL Server 2008 R2.
</span></p>
<p class="MsoNormal">1. <span>Open the </span><span>CSAzureNTierWebRoleWithSession</span><span>.sln file with Visual Studio
</span>in elevated (administrator) mode<span>, and then you need to set </span><span class="SpellE"><span>CSAzureNTierWebRoleWithSession</span></span><span> Azure application as the startup application.</span><em><span>
</span></em></p>
<p class="MsoNormal">2.<span> </span>Before running the sample, please replace your database connection in Web.config file and App.config file, the connection string like:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;connectionStrings&gt;
    &lt;add name=&quot;TestDBEntities&quot; connectionString=&quot;[Your database connection string]&quot; providerName=&quot;System.Data.EntityClient&quot; /&gt;
&lt;/connectionStrings&gt;

</pre>
<pre id="codePreview" class="xml">&lt;connectionStrings&gt;
    &lt;add name=&quot;TestDBEntities&quot; connectionString=&quot;[Your database connection string]&quot; providerName=&quot;System.Data.EntityClient&quot; /&gt;
&lt;/connectionStrings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Please also replace your Azure Cache service <span class="GramE">
url</span> and Authentication Token in Web.config file, in this sample application, we use Caching service to enable Session to solve the object persistence issue for multiple instances.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;dataCacheClients&gt;
  &lt;dataCacheClient name=&quot;default&quot;&gt;
    &lt;hosts&gt;
      &lt;host name=&quot;[Your Caching Service Url]&quot; cachePort=&quot;22233&quot; /&gt;
    &lt;/hosts&gt;
    &lt;securityProperties mode=&quot;Message&quot;&gt;
      &lt;messageSecurity authorizationInfo=&quot;[Your Caching Service Authentication Token]&quot;&gt;
      &lt;/messageSecurity&gt;
    &lt;/securityProperties&gt;
  &lt;/dataCacheClient&gt;
&lt;/dataCacheClients&gt;

</pre>
<pre id="codePreview" class="xml">&lt;dataCacheClients&gt;
  &lt;dataCacheClient name=&quot;default&quot;&gt;
    &lt;hosts&gt;
      &lt;host name=&quot;[Your Caching Service Url]&quot; cachePort=&quot;22233&quot; /&gt;
    &lt;/hosts&gt;
    &lt;securityProperties mode=&quot;Message&quot;&gt;
      &lt;messageSecurity authorizationInfo=&quot;[Your Caching Service Authentication Token]&quot;&gt;
      &lt;/messageSecurity&gt;
    &lt;/securityProperties&gt;
  &lt;/dataCacheClient&gt;
&lt;/dataCacheClients&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. <span>Running the application and you can find there is a simple login page, please follow the prompt and input username and password to log in, the application will store the username and password in session and restore them when
 you log in successfully. </span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73962/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">4. <span>You can find your username in the page, and the data comes from database will be bind to
<span class="SpellE">GridView</span> control: </span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73963/1/image.png" alt="" width="552" height="529" align="middle">
</span></p>
<p class="MsoNormal">5. <span>Validation finished </span></p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Application Project in Visual Studio 2010, name it as &quot;</span><span>CSAzureNTierWebRoleWithSession</span><span>&quot;.
</span></p>
<p class="MsoNormal"><span>2. </span>The sample solution contains 3 projects.<strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>CSAzureNTierWebRoleWithSession </strong></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>AzureNTierWebRoleWithSession_WebRole </strong></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-size:12.0pt; line-height:115%; font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>BusinessLayer</strong> <strong></strong></p>
<p class="MsoListParagraphCxSpLast"><span style="font-size:12.0pt; line-height:115%; font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>DataAccessLayer</strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoNormal">3. <span class="SpellE">CSAzureNTierWebRoleWithSession</span> is a cloud service project; this project will help to publish your WebRole and class library project to Cloud.</p>
<p class="MsoNormal">4. The AzureNTierWebRoleWithSession_WebRole project is a web role application; it's used to call BLL and Caching service to store necessary user information. The configuration file like below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;configuration&gt;
  &lt;configSections&gt;
    &lt;!-- Append below entry to configSections. Do not overwrite the full section. --&gt;
    &lt;section name=&quot;dataCacheClients&quot; type=&quot;Microsoft.ApplicationServer.Caching.DataCacheClientsSection, Microsoft.ApplicationServer.Caching.Core&quot;
             allowLocation=&quot;true&quot; allowDefinition=&quot;Everywhere&quot;/&gt;
  &lt;/configSections&gt;
  &lt;system.diagnostics&gt;
    &lt;trace&gt;
      &lt;listeners&gt;
        &lt;add type=&quot;Microsoft.WindowsAzure.Diagnostics.DiagnosticMonitorTraceListener, Microsoft.WindowsAzure.Diagnostics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; name=&quot;AzureDiagnostics&quot;&gt;
          &lt;filter type=&quot;&quot; /&gt;
        &lt;/add&gt;
      &lt;/listeners&gt;
    &lt;/trace&gt;
  &lt;/system.diagnostics&gt;
  &lt;connectionStrings&gt;
      &lt;add name=&quot;TestDBEntities&quot; connectionString=&quot;[Your database connection string]&quot; providerName=&quot;System.Data.EntityClient&quot; /&gt;
  &lt;/connectionStrings&gt;
  &lt;dataCacheClients&gt;
    &lt;dataCacheClient name=&quot;default&quot;&gt;
      &lt;hosts&gt;
        &lt;host name=&quot;[Your Caching Service Url]&quot; cachePort=&quot;22233&quot; /&gt;
      &lt;/hosts&gt;
      &lt;securityProperties mode=&quot;Message&quot;&gt;
        &lt;messageSecurity  authorizationInfo=&quot;[Your Caching Service Authentication Token]&quot;&gt;
        &lt;/messageSecurity&gt;
      &lt;/securityProperties&gt;
    &lt;/dataCacheClient&gt;
  &lt;/dataCacheClients&gt;
  &lt;system.web&gt;
    &lt;sessionState mode=&quot;Custom&quot; customProvider=&quot;AzureCacheServiceProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;AzureCacheServiceProvider&quot; type=&quot;Microsoft.Web.DistributedCache.DistributedCacheSessionStateStoreProvider, Microsoft.Web.DistributedCache&quot; cacheName=&quot;default&quot; useBlobMode=&quot;true&quot; dataCacheClientName=&quot;default&quot;  /&gt;
      &lt;/providers&gt;
    &lt;/sessionState&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
  &lt;/system.web&gt;
  &lt;system.webServer&gt;
    &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
    &lt;defaultDocument&gt;
      &lt;files&gt;
        &lt;clear/&gt;
        &lt;add value=&quot;Login.aspx&quot;/&gt;
      &lt;/files&gt;
    &lt;/defaultDocument&gt;
  &lt;/system.webServer&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">&lt;configuration&gt;
  &lt;configSections&gt;
    &lt;!-- Append below entry to configSections. Do not overwrite the full section. --&gt;
    &lt;section name=&quot;dataCacheClients&quot; type=&quot;Microsoft.ApplicationServer.Caching.DataCacheClientsSection, Microsoft.ApplicationServer.Caching.Core&quot;
             allowLocation=&quot;true&quot; allowDefinition=&quot;Everywhere&quot;/&gt;
  &lt;/configSections&gt;
  &lt;system.diagnostics&gt;
    &lt;trace&gt;
      &lt;listeners&gt;
        &lt;add type=&quot;Microsoft.WindowsAzure.Diagnostics.DiagnosticMonitorTraceListener, Microsoft.WindowsAzure.Diagnostics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; name=&quot;AzureDiagnostics&quot;&gt;
          &lt;filter type=&quot;&quot; /&gt;
        &lt;/add&gt;
      &lt;/listeners&gt;
    &lt;/trace&gt;
  &lt;/system.diagnostics&gt;
  &lt;connectionStrings&gt;
      &lt;add name=&quot;TestDBEntities&quot; connectionString=&quot;[Your database connection string]&quot; providerName=&quot;System.Data.EntityClient&quot; /&gt;
  &lt;/connectionStrings&gt;
  &lt;dataCacheClients&gt;
    &lt;dataCacheClient name=&quot;default&quot;&gt;
      &lt;hosts&gt;
        &lt;host name=&quot;[Your Caching Service Url]&quot; cachePort=&quot;22233&quot; /&gt;
      &lt;/hosts&gt;
      &lt;securityProperties mode=&quot;Message&quot;&gt;
        &lt;messageSecurity  authorizationInfo=&quot;[Your Caching Service Authentication Token]&quot;&gt;
        &lt;/messageSecurity&gt;
      &lt;/securityProperties&gt;
    &lt;/dataCacheClient&gt;
  &lt;/dataCacheClients&gt;
  &lt;system.web&gt;
    &lt;sessionState mode=&quot;Custom&quot; customProvider=&quot;AzureCacheServiceProvider&quot;&gt;
      &lt;providers&gt;
        &lt;add name=&quot;AzureCacheServiceProvider&quot; type=&quot;Microsoft.Web.DistributedCache.DistributedCacheSessionStateStoreProvider, Microsoft.Web.DistributedCache&quot; cacheName=&quot;default&quot; useBlobMode=&quot;true&quot; dataCacheClientName=&quot;default&quot;  /&gt;
      &lt;/providers&gt;
    &lt;/sessionState&gt;
    &lt;compilation debug=&quot;true&quot; targetFramework=&quot;4.0&quot; /&gt;
  &lt;/system.web&gt;
  &lt;system.webServer&gt;
    &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
    &lt;defaultDocument&gt;
      &lt;files&gt;
        &lt;clear/&gt;
        &lt;add value=&quot;Login.aspx&quot;/&gt;
      &lt;/files&gt;
    &lt;/defaultDocument&gt;
  &lt;/system.webServer&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. BLL and DAL are used to connect to the Entity Framework.</p>
<p class="MsoNormal">6. Build the application and you can debug it now.</p>
<p class="MsoListParagraphCxSpFirst"><span lang="EN"><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN"><a href="http://msdn.microsoft.com/en-us/data/ee712906">Get ADO.NET Entity Framework</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN"><a href="http://www.windowsazure.com/en-us/home/features/sql-azure/">SQL Azure</a></span><span>
</span></p>
<p class="MsoListParagraphCxSpLast"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/magazine/gg983488.aspx">Introducing the Windows Azure Caching Service</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
