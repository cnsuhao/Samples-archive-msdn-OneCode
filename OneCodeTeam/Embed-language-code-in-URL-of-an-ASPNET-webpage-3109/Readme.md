# Embed language code in URL of an ASP.NET webpage (VBASPNETEmbedLanguageInUrl)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Language
* Globalization
## IsPublished
* True
## ModifiedDate
* 2011-05-20 11:25:21
## Description

<h2><span style="font-family:courier new,courier">VBASPNETEmbedLanguageInUrl Overview</span><br>
<br>
<span style="font-family:courier new,courier">Summary:</span></h2>
<p><span style="font-family:courier new,courier">The project illustrates how to embed the language code in URL such
</span><br>
<span style="font-family:courier new,courier">as <a href="http://domain/en-us/ShowMe.aspx">
http://domain/en-us/ShowMe.aspx</a>. The page will display different</span><br>
<span style="font-family:courier new,courier">content according to the language code, the sample use url-routing
</span><br>
<span style="font-family:courier new,courier">and resource files to localize the content of web page.</span></p>
<h3><br>
<span style="font-family:courier new,courier">Demo the Sample.</span></h3>
<p><span style="font-family:courier new,courier">Step 1: Open the VBASPNETEmbedLanguageInUrl.sln.</span></p>
<p><span style="font-family:courier new,courier">Step 2: Expand the VBASPNETEmbedLanguageInUrl web application and press
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ctrl &#43; F5 to start the web application.</span></p>
<p><span style="font-family:courier new,courier">Step 3: We will see a normal English web page, we try to modify the value of</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; address bar of browsers, for example, update the &quot;en-us&quot; to &quot;zh-cn&quot;</span></p>
<p><span style="font-family:courier new,courier">Step 4: If you update the url correctly, you will see a Chinese language
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; version of this web page.</span></p>
<p><span style="font-family:courier new,courier">Step 5: Good, if you input a language we did not have in this web application,</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you will see a default language web page with English.</span></p>
<p><span style="font-family:courier new,courier">Step 6: Validation finished.</span></p>
<h3><br>
<br>
<span style="font-family:courier new,courier">Code Logical:</span></h3>
<p><span style="font-family:courier new,courier">Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Visual Web Developer 2010. Name it as &quot;VBASPNETEmbedLanguageInUrl&quot;.</span></p>
<p><span style="font-family:courier new,courier">Step 2. Add one folder, &quot;XmlFolder&quot;. In order to display different language</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; content in this web page, we need a database or an xml file to store</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;our data, in this code-sample we need add a Language.xml file.</span></p>
<p><span style="font-family:courier new,courier">Step 3. Add three web forms in application's root directory, &quot;ShowMe.aspx&quot; page</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; for display to customers, &quot;InvalidPage.aspx&quot; for handle error http
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;request, &quot;Start.aspx&quot; for start url routing.</span></p>
<p><span style="font-family:courier new,courier">Step 4. Add three class files, &quot;BasePage.vb&quot; class for check the request url
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; language part and name part, and set the page's Culture and UICultrue</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; properties. &quot;UrlRoutingHandler.vb&quot; class for check the file name and
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;throw them to the InvalidPage.aspx page if it not existence. &quot;XmlLoad.vb&quot;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;class for load the xml data to display them in ShowMe.aspx page.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[Note]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;If you want to create more web pages include multiple languages, please</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; inherits the BasePage.vb class for set page's Cultrue and UICulture.</span></p>
<p><span style="font-family:courier new,courier">Step 5. Register url routes in Global.asax file.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RegisterRoutes(RouteTable.Routes)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' Url routing</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;routes&quot;&gt;&lt;/param&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; routes.Add(&quot;Page&quot;, New Route(&quot;{language}/{pageName}&quot;, New UrlRoutingHandlers()))</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;After register url routes, we need create a UrlRoutingHandlers to check</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;the request url. The UrlRoutingHanders code like this:</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' Create this RoutingHandler to check the HttpRequest and</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' return correct url path.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Function GetHttpHandler1(ByVal context As System.Web.Routing.RequestContext)
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; As System.Web.IHttpHandler Implements System.Web.Routing.IRouteHandler.GetHttpHandler</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim language As String = context.RouteData.Values(&quot;language&quot;).ToString().ToLower()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pageName As String = context.RouteData.Values(&quot;pageName&quot;).ToString()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If pageName = &quot;ShowMe.aspx&quot; Then</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return TryCast(BuildManager.CreateInstanceFromVirtualPath(&quot;~/ShowMe.aspx&quot;, GetType(Page)),
 Page)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return BuildManager.CreateInstanceFromVirtualPath(&quot;~/InvalidPage.aspx&quot;, GetType(Page))</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></p>
<p><span style="font-family:courier new,courier">Step 6. Create two resource files for support multiple language web page,
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; named &quot;Resource.resx&quot;, &quot;Resource.zh-cn.resx&quot;.</span></p>
<p><span style="font-family:courier new,courier">Step 7. Add some code in BasePage.vb, setting page.Culture and page.UICulture.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' The BasePage class used to set Page.Culture and Page.UICulture.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Protected Overrides Sub InitializeCulture()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim language As String = RouteData.Values(&quot;language&quot;).ToString().ToLower()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pageName As String = RouteData.Values(&quot;pageName&quot;).ToString()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;info&quot;) = language &amp; &quot;,&quot; &amp; pageName</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Page.Culture = language</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Page.UICulture = language</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch generatedExceptionName As Exception</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session(&quot;info&quot;) = &quot;error,error&quot;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try</span></p>
<p><span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></p>
<p><span style="font-family:courier new,courier">Step 8. In ShowMe.aspx page we need add some xml data and resource file data.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbTitleContent.Text = strTitle</span></p>
<p><span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp; &lt;asp:Literal ID=&quot;litTitle&quot; runat=&quot;server&quot; Text='&lt;%$ Resources:Resource,Title %&gt;'&gt;&lt;/asp:Literal&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></p>
<p><span style="font-family:courier new,courier">Step 9. Build the application and you can debug it.</span></p>
<h3><br>
<br>
<span style="font-family:courier new,courier">References:</span></h3>
<p><span style="font-family:courier new,courier">MSDN: Url Routing</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/magazine/dd347546.aspxMSDN">http://msdn.microsoft.com/en-us/magazine/dd347546.aspx</a></span><span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/magazine/dd347546.aspxMSDN"></a></span></p>
<p><span style="font-family:courier new,courier">NSDN: UrlRoutingHandler Class&nbsp;</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/library/system.web.routing.urlroutinghandler.aspxMSDN">http://msdn.microsoft.com/en-us/library/system.web.routing.urlroutinghandler.aspx</a></span></p>
<p><span style="font-family:Verdana">MSDN: R</span>esourse <span style="font-family:courier new,courier">
File</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/library/ccec7sz1(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ccec7sz1(VS.80).aspx</a></span></p>
<p><span style="font-family:courier new,courier">&nbsp;</span></p>
<p><span style="font-family:courier new,courier"><span style="font-family:Verdana">&nbsp;</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
