# Create a three-tier ASP.NET web application with Entity Framework and Self Track
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* Entity Framework
## IsPublished
* True
## ModifiedDate
* 2015-01-19 07:25:22
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1><strong>How to create a three-tier ASP.NET web application with Entity Framework and Self Track</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, which uses Entity Framework (SQL Azure database) as the Data Access Layer. This sample also shows how to implement a User Session Handling (With Azure Cache Service).</p>
<h2><strong>Building the Sample</strong></h2>
<p>To build this sample successfully, please make sure you have installed latest Windows Azure SDK and SQL Server 2008 R2.</p>
<h2><strong>Running the Sample</strong></h2>
<p>1. Open the CSAzureNTierWebRoleWithSession.sln file with Visual Studio in elevated (administrator) mode, and then you need to set CSAzureNTierWebRoleWithSession Azure application as the startup application.<em>&nbsp;</em></p>
<p>2. Before running the sample, please replace your database connection in Web.config file and App.config file, the connection string like:</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xml</span><pre class="hidden">&lt;connectionStrings&gt;
    &lt;add name=&quot;TestDBEntities&quot; connectionString=&quot;[Your database connection string]&quot; providerName=&quot;System.Data.EntityClient&quot; /&gt;
&lt;/connectionStrings&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestDBEntities&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;[Your&nbsp;database&nbsp;connection&nbsp;string]&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.EntityClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<p>Please also replace your Azure Cache service url and Authentication Token in Web.config file, in this sample application, we use Caching service to enable Session to solve the object persistence issue for multiple instances.</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xml</span><pre class="hidden">&lt;dataCacheClients&gt;
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
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;dataCacheClients</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;dataCacheClient</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;default&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;hosts</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;host</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;[Your&nbsp;Caching&nbsp;Service&nbsp;Url]&quot;</span>&nbsp;<span class="xml__attr_name">cachePort</span>=<span class="xml__attr_value">&quot;22233&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/hosts&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;securityProperties</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Message&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;messageSecurity</span>&nbsp;<span class="xml__attr_name">authorizationInfo</span>=<span class="xml__attr_value">&quot;[Your&nbsp;Caching&nbsp;Service&nbsp;Authentication&nbsp;Token]&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/messageSecurity&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/securityProperties&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/dataCacheClient&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/dataCacheClients&gt;</span>&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>3. Running the application and you can find there is a simple login page, please follow the prompt and input username and password to log in, the application will store the username and password in session and restore them when you log in successfully.</p>
<p>&nbsp;<img id="132707" src="/site/view/file/132707/1/image002.jpg" alt="" width="552" height="529"></p>
<p>4. You can find your username in the page, and the data comes from database will be bind to GridView control:</p>
<p>&nbsp;<img id="132708" src="/site/view/file/132708/1/image004.jpg" alt="" width="552" height="529"></p>
<p>5. Validation finished</p>
<h2><strong>Using the Code</strong><strong>&nbsp;</strong></h2>
<p>1. Create a Windows Azure Application Project in Visual Studio 2010, name it as &ldquo;CSAzureNTierWebRoleWithSession&rdquo;.</p>
<p>2. The sample solution contains 3 projects.<strong> </strong></p>
<ul>
<li><strong>CSAzureNTierWebRoleWithSession </strong></li><li><strong>AzureNTierWebRoleWithSession_WebRole</strong> </li><li><strong>BusinessLayer</strong> <strong>&nbsp;</strong> </li><li><strong>DataAccessLayer</strong><strong></strong> </li></ul>
<p>3. CSAzureNTierWebRoleWithSession is a cloud service project; this project will help to publish your WebRole and class library project to Cloud.</p>
<p>4. The AzureNTierWebRoleWithSession_WebRole project is a web role application; it&rsquo;s used to call BLL and Caching service to store necessary user information. The configuration file like below:</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xml</span><pre class="hidden">&lt;configuration&gt;
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
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;configuration</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;configSections</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;Append&nbsp;below&nbsp;entry&nbsp;to&nbsp;configSections.&nbsp;Do&nbsp;not&nbsp;overwrite&nbsp;the&nbsp;full&nbsp;section.&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;section</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;dataCacheClients&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;Microsoft.ApplicationServer.Caching.DataCacheClientsSection,&nbsp;Microsoft.ApplicationServer.Caching.Core&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">allowLocation</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">allowDefinition</span>=<span class="xml__attr_value">&quot;Everywhere&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/configSections&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;system</span>.diagnostics<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;trace</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;listeners</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;Microsoft.WindowsAzure.Diagnostics.DiagnosticMonitorTraceListener,&nbsp;Microsoft.WindowsAzure.Diagnostics,&nbsp;Version=1.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=31bf3856ad364e35&quot;</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;AzureDiagnostics&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;filter</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/add&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/listeners&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/trace&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/system.diagnostics&gt;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestDBEntities&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;[Your&nbsp;database&nbsp;connection&nbsp;string]&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.EntityClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;dataCacheClients</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;dataCacheClient</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;default&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;hosts</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;host</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;[Your&nbsp;Caching&nbsp;Service&nbsp;Url]&quot;</span>&nbsp;<span class="xml__attr_name">cachePort</span>=<span class="xml__attr_value">&quot;22233&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/hosts&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;securityProperties</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Message&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;messageSecurity</span>&nbsp;&nbsp;<span class="xml__attr_name">authorizationInfo</span>=<span class="xml__attr_value">&quot;[Your&nbsp;Caching&nbsp;Service&nbsp;Authentication&nbsp;Token]&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/messageSecurity&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/securityProperties&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/dataCacheClient&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/dataCacheClients&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;system</span>.web<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;sessionState</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Custom&quot;</span>&nbsp;<span class="xml__attr_name">customProvider</span>=<span class="xml__attr_value">&quot;AzureCacheServiceProvider&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;providers</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;AzureCacheServiceProvider&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;Microsoft.Web.DistributedCache.DistributedCacheSessionStateStoreProvider,&nbsp;Microsoft.Web.DistributedCache&quot;</span>&nbsp;<span class="xml__attr_name">cacheName</span>=<span class="xml__attr_value">&quot;default&quot;</span>&nbsp;<span class="xml__attr_name">useBlobMode</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">dataCacheClientName</span>=<span class="xml__attr_value">&quot;default&quot;</span>&nbsp;&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/providers&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/sessionState&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;compilation</span>&nbsp;<span class="xml__attr_name">debug</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">targetFramework</span>=<span class="xml__attr_value">&quot;4.0&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/system.web&gt;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;system</span>.webServer<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;modules</span>&nbsp;<span class="xml__attr_name">runAllManagedModulesForAllRequests</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;defaultDocument</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;files</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;clear</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;Login.aspx&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/files&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/defaultDocument&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/system.webServer&gt;&nbsp;
<span class="xml__tag_end">&lt;/configuration&gt;</span>&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>5. BLL and DAL are used to connect to the Entity Framework.</p>
<p>6. Build the application and you can debug it now.</p>
<h2><strong>More Information</strong><strong></strong></h2>
<ol>
<li><a href="http://msdn.microsoft.com/en-us/data/ee712906">Get ADO.NET Entity Framework</a>
</li><li><a href="http://www.windowsazure.com/en-us/home/features/sql-azure/">SQL Azure</a>
</li><li><a href="http://msdn.microsoft.com/en-us/magazine/gg983488.aspx">Introducing the Windows Azure Caching Service</a>
</li></ol>
