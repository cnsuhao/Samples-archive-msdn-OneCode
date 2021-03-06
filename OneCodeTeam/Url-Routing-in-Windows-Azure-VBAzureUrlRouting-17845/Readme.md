# Url Routing in Windows Azure (VBAzureUrlRouting)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* URL Routing
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:37:00
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">To build this sample successfully, please make sure you have installed<span> Windows Azure SDK 1.6 and SQL Server 2008 R2.</span></p>
<p class="MsoNormal">1. <span>Open the</span><strong><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong><span>VBAzureUrlRouting</span><span>.sln file with Visual Studio </span>
in elevated (administrator) mode<span>, <span class="GramE">then</span> you need to set
</span><span class="SpellE"><span>VBAzureUrlRouting</span></span><span> Azure application as the startup application.</span><em><span>
</span></em></p>
<p class="MsoNormal">2.<span> </span>Set Default.aspx as the startup page, and press F5 to start the Azure emulator. You will see some links on the page. Please also open the Solution Explorer of Visual Studio and observe folders and web form pages, the URL
 routing format is {Root}/{Directory Name}/{File Name}.</p>
<p class="MsoNormal"><span><img src="/site/view/file/61976/1/image.png" alt="" width="583" height="533" align="middle">
</span></p>
<p class="MsoNormal">3. <span>If the URL format is correct, Root and directory name follow the &quot;Routing.xml&quot; in the
<span class="SpellE">App_Data</span> folder and the page exists. You will see the page in Browser like below:
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/61977/1/image.png" alt="" width="583" height="533" align="middle">
</span></p>
<p class="MsoNormal">4. <span>If the file does not exist or the folder name and the root name don't map, for example, try to access Sample/PageResources2/Page3.aspx in browser, you will see NoHandler.aspx.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/61978/1/image.png" alt="" width="587" height="537" align="middle">
</span></p>
<p class="MsoNormal">5. <span>Validation finished </span></p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Application Project in Visual Studio 2010, name it as &quot;<span>VBAzureUrlRouting</span>&quot;.
</span></p>
<p class="MsoNormal"><span>2. </span>Create a Web Role and name it as &quot;VBAzureUrlRouting_WebRole&quot;, this project is used to create a web application and implement URL Routing map in Global.asax page.
<strong></strong></p>
<p class="MsoNormal">3. Add a class file implement <span class="SpellE">IRouteHandler</span> interface, this handler class can retrieve parameters and values from URL string variable (follow
<span class="SpellE">url</span> routing format), also it will check if URL rule is correct and if the file exists, if not, provide NoHandler.aspx page as the response.</p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"> how to implement
 IRouteHandler interface and GetHttpHandler method: </span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Check URLs from requests.
''' &lt;/summary&gt;
''' &lt;param name=&quot;requestContext&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function GetHttpHandler(requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
    Dim root As String = requestContext.RouteData.Values(&quot;root&quot;).ToString().ToLower()
    Dim name As String = requestContext.RouteData.Values(&quot;name&quot;).ToString().ToLower()
    Dim directory As String = requestContext.RouteData.Values(&quot;directory&quot;).ToString().ToLower()
    Dim page As String = String.Format(&quot;~/{0}/{1}&quot;, directory, name)
    Dim xmlPath As String = requestContext.HttpContext.Server.MapPath(&quot;~/App_Data/Routing.xml&quot;)
    If Not IsInRoot(directory, root, xmlPath) Then
        Return TryCast(BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, GetType(Page)), IHttpHandler)
    End If
    If File.Exists(requestContext.HttpContext.Server.MapPath(page)) Then
        Dim handler As IHttpHandler = TryCast(BuildManager.CreateInstanceFromVirtualPath(page, GetType(Page)), IHttpHandler)
        Return handler
    Else
        Return TryCast(BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, GetType(Page)), IHttpHandler)
    End If
End Function


''' &lt;summary&gt;
''' Check directory name is in root node (XML file).
''' &lt;/summary&gt;
''' &lt;param name=&quot;directory&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;root&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;xmlPath&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function IsInRoot(directory As String, root As String, xmlPath As String) As Boolean
    Dim document As XDocument = XDocument.Load(xmlPath)
    Dim list = From e In document.Descendants(root).Descendants(&quot;add&quot;)
               Where directory.Equals(e.Value)
               Select e
    If list.Count() &gt; 0 Then
        Return True
    Else
        Return False
    End If
End Function

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Check URLs from requests.
''' &lt;/summary&gt;
''' &lt;param name=&quot;requestContext&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function GetHttpHandler(requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
    Dim root As String = requestContext.RouteData.Values(&quot;root&quot;).ToString().ToLower()
    Dim name As String = requestContext.RouteData.Values(&quot;name&quot;).ToString().ToLower()
    Dim directory As String = requestContext.RouteData.Values(&quot;directory&quot;).ToString().ToLower()
    Dim page As String = String.Format(&quot;~/{0}/{1}&quot;, directory, name)
    Dim xmlPath As String = requestContext.HttpContext.Server.MapPath(&quot;~/App_Data/Routing.xml&quot;)
    If Not IsInRoot(directory, root, xmlPath) Then
        Return TryCast(BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, GetType(Page)), IHttpHandler)
    End If
    If File.Exists(requestContext.HttpContext.Server.MapPath(page)) Then
        Dim handler As IHttpHandler = TryCast(BuildManager.CreateInstanceFromVirtualPath(page, GetType(Page)), IHttpHandler)
        Return handler
    Else
        Return TryCast(BuildManager.CreateInstanceFromVirtualPath(&quot;~/NoHandler.aspx&quot;, GetType(Page)), IHttpHandler)
    End If
End Function


''' &lt;summary&gt;
''' Check directory name is in root node (XML file).
''' &lt;/summary&gt;
''' &lt;param name=&quot;directory&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;root&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;xmlPath&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function IsInRoot(directory As String, root As String, xmlPath As String) As Boolean
    Dim document As XDocument = XDocument.Load(xmlPath)
    Dim list = From e In document.Descendants(root).Descendants(&quot;add&quot;)
               Where directory.Equals(e.Value)
               Select e
    If list.Count() &gt; 0 Then
        Return True
    Else
        Return False
    End If
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>4. In order to make your application runs successfully in Azure environment, please create
<span class="SpellE">IISHandler</span> that inherits <span class="SpellE">UrlRoutingHandler</span> class, this custom routing handler is used to cancel verification of process request. Then you can add the related configuration section in
<span class="SpellE">Web.config</span> file as below</span>:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.webServer&gt;
  &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
  &lt;handlers&gt;
    &lt;add name=&quot;UrlRoutingHandler&quot; preCondition=&quot;integratedMode&quot; verb=&quot;*&quot; path=&quot;UrlRouting.axd&quot; type=&quot;WebCore.IISHandler, WebCore&quot;/&gt;
  &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
<pre id="codePreview" class="xml">&lt;system.webServer&gt;
  &lt;modules runAllManagedModulesForAllRequests=&quot;true&quot; /&gt;
  &lt;handlers&gt;
    &lt;add name=&quot;UrlRoutingHandler&quot; preCondition=&quot;integratedMode&quot; verb=&quot;*&quot; path=&quot;UrlRouting.axd&quot; type=&quot;WebCore.IISHandler, WebCore&quot;/&gt;
  &lt;/handlers&gt;
&lt;/system.webServer&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. The next step, add route in route table before application starts, and please also add some sample links in Default.aspx page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">RouteTable.Routes.Add(&quot;PageResources&quot;, New Route(&quot;{root}/{directory}/{name}&quot;, New WebRoleRoute()))

</pre>
<pre id="codePreview" class="vb">RouteTable.Routes.Add(&quot;PageResources&quot;, New Route(&quot;{root}/{directory}/{name}&quot;, New WebRoleRoute()))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">6. Add an xml file to manage Root name and directory name, URL string should follow this xml file; you can also create your rule via this xml file.</p>
<p class="MsoNormal">7. Build the application and you can debug it now.</p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/cc668201.aspx">ASP.NET Routing</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
