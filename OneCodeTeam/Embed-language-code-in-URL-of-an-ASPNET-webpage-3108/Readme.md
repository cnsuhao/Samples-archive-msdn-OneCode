# Embed language code in URL of an ASP.NET webpage (CSASPNETEmbedLanguageInUrl)
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
* 2011-05-09 12:37:30
## Description

<h2><span style="font-family:courier new,courier">CSASPNETEmbedLanguageInUrl Overview</span></h2>
<h3><span style="font-family:courier new,courier">Summary:</span></h3>
<div><span style="font-family:courier new,courier">The project illustrates how to embed the language code in URL such</span><br>
<span style="font-family:courier new,courier">as <a href="http://domain/en-us/ShowMe.aspx">
http://domain/en-us/ShowMe.aspx</a>. The page will display different</span><br>
<span style="font-family:courier new,courier">content according to the language code, the sample use url-routing
</span><br>
<span style="font-family:courier new,courier">and resource files to localize the content of web page.</span></div>
<h3><br>
<br>
<span style="font-family:courier new,courier">Demo the Sample:</span></h3>
<div><span style="font-family:courier new,courier">Please follow these demonstration steps below.</span></div>
<div><span style="font-family:courier new,courier">Step 1: Open the CSASPNETEmbedLanguageInUrl.sln.</span></div>
<div><span style="font-family:courier new,courier">Step 2: Expand the CSASPNETEmbedLanguageInUrl web application and press
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ctrl &#43; F5 to start the web application.</span></div>
<div><span style="font-family:courier new,courier">Step 3: We will see a normal English web page, we try to modify the value of</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; address bar of browsers, for example, update the &quot;en-us&quot; to &quot;zh-cn&quot;</span></div>
<div><span style="font-family:courier new,courier">Step 4: If you update the url correctly, you will see a Chinese language
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; version of this web page.</span></div>
<div><span style="font-family:courier new,courier">Step 5: Good, if you input a language we did not have in this web application,</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you will see a default language web page with English.</span></div>
<div><span style="font-family:courier new,courier">Step 6: Validation finished.</span></div>
<h3><br>
<br>
<span style="font-family:courier new,courier">Code Logical:</span></h3>
<div><span style="font-family:courier new,courier">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Visual Web Developer 2010. Name it as &quot;CSASPNETEmbedLanguageInUrl&quot;.</span></div>
<div><span style="font-family:courier new,courier">Step 2. Add one folder, &quot;XmlFolder&quot;. In order to display different language</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; content in this web page, we need a database or an xml file to store</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;our data, in this code-sample we need add a Language.xml file.</span></div>
<div><span style="font-family:courier new,courier">Step 3. Add three web forms in application's root directory, &quot;ShowMe.aspx&quot; page</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; for display to customers, &quot;InvalidPage.aspx&quot; for handle error http
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;request, &quot;Start.aspx&quot; for start url routing.</span></div>
<div><span style="font-family:courier new,courier">Step 4. Add three class files, &quot;BasePage.cs&quot; class for check the request url
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; language part and name part, and set the page's Culture and UICultrue</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; properties. &quot;UrlRoutingHandler.cs&quot; class for check the file name and
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;throw them to the InvalidPage.aspx page if it not existence. &quot;XmlLoad.cs&quot;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;class for load the xml data to display them in ShowMe.aspx page.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[Note]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;If you want to create more web pages include multiple languages, please</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; inherits the BasePage.cs class for set page's Cultrue and UICulture.</span></div>
<div><span style="font-family:courier new,courier">Step 5. Register url routes in Global.asax file.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void Application_Start(object sender, EventArgs e)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RegisterRoutes(RouteTable.Routes);</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span></div>
<div><span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static void RegisterRoutes(RouteCollection routes)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; routes.Add(&quot;Page&quot;, new Route(&quot;{language}/{pageName}&quot;, new UrlRoutingHandlers()));</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;After register url routes, we need create a UrlRoutingHandlers to check</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;the request url. The UrlRoutingHanders code like this:</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Create this RoutingHandler to check the HttpRequest and</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// return correct url path.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;returns&gt;&lt;/returns&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public IHttpHandler GetHttpHandler(RequestContext context)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string language = context.RouteData.Values[&quot;language&quot;].ToString().ToLower();</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string pageName = context.RouteData.Values[&quot;pageName&quot;].ToString();</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (pageName == &quot;ShowMe.aspx&quot;)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return BuildManager.CreateInstanceFromVirtualPath(&quot;~/ShowMe.aspx&quot;, typeof(Page)) as
 Page;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return BuildManager.CreateInstanceFromVirtualPath(&quot;~/InvalidPage.aspx&quot;, typeof(Page))
 as Page;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></div>
<div><span style="font-family:courier new,courier">Step 6. Create two resource files for support multiple language web page,
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; named &quot;Resource.resx&quot;, &quot;Resource.zh-cn.resx&quot;.</span></div>
<div><span style="font-family:courier new,courier">Step 7. Add some code in BasePage.cs, setting page.Culture and page.UICulture.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// The BasePage class used to set Page.Culture and Page.UICulture.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override void InitializeCulture()</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string language = RouteData.Values[&quot;language&quot;].ToString().ToLower();</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string pageName = RouteData.Values[&quot;pageName&quot;].ToString();</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session[&quot;info&quot;] = language &#43; &quot;,&quot; &#43; pageName;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Page.Culture = language;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Page.UICulture = language;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception)</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Session[&quot;info&quot;] = &quot;error,error&quot;;
</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></div>
<div><span style="font-family:courier new,courier">Step 8. In ShowMe.aspx page we need add some xml data and resource file data.</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [code]</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lbTitleContent.Text = strTitle;</span></div>
<div><span style="font-family:courier new,courier">&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Literal ID=&quot;litTitle&quot; runat=&quot;server&quot; Text='&lt;%$ Resources:Resource,Title %&gt;'&gt;&lt;/asp:Literal&gt;</span><br>
<span style="font-family:courier new,courier">&nbsp;&nbsp;[/code]</span></div>
<div><span style="font-family:courier new,courier">Step 9. Build the application and you can debug it.</span></div>
<h3><br>
<br>
<span style="font-family:courier new,courier">References:</span></h3>
<div><span style="font-family:courier new,courier">MSDN: Url Routing</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/magazine/dd347546.aspxMSDN">http://msdn.microsoft.com/en-us/magazine/dd347546.aspx</a></span></div>
<div><span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/magazine/dd347546.aspxMSDN">
<div>&nbsp;</div>
</a></span></div>
<div><span style="font-family:courier new,courier">MSDN: UrlRoutingHandler Class&nbsp;</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/library/system.web.routing.urlroutinghandler.aspxMSDN">http://msdn.microsoft.com/en-us/library/system.web.routing.urlroutinghandler.aspx</a></span></div>
<div><span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/library/system.web.routing.urlroutinghandler.aspxMSDN">
<div>&nbsp;</div>
</a></span></div>
<div><span style="font-family:courier new,courier">MSDN: Resourse File</span><br>
<span style="font-family:courier new,courier"><a href="http://msdn.microsoft.com/en-us/library/ccec7sz1.aspx">http://msdn.microsoft.com/en-us/library/ccec7sz1.aspx</a></span></div>
<div><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
