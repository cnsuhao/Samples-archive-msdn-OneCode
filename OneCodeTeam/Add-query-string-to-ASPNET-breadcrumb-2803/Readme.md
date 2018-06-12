# Add query string to ASP.NET breadcrumb (CSASPNETBreadcrumbWithQueryString)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Breadcrumb
* Query String
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:56:51
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETBreadcrumbWithQueryString Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
By default, SiteMapPath control is very static. It only shows the nodes whose <br>
location can be matched in the site map. Sometimes we want to change SiteMapPath <br>
control's titles and paths according to Query String values. And sometimes we <br>
want to create the SiteMapPath dynamically. This code sample shows how to <br>
achieve these goals by handling SiteMap.SiteMapResolve event.<br>
</p>
<h3>Demo the Sample:</h3>
<p style="font-family:Courier New"><br>
1. Open page Default.aspx, click a link in the categories list to navigate <br>
&nbsp; to page Category.aspx, then click a link to navigate to page Item.aspx.<br>
&nbsp; you can see that the breadcrumb is showing the dynamic nodes according <br>
&nbsp; to Query String values.<br>
<br>
2. Open page DynamicBreadcrumb.aspx to see the dynamically created breadcrumb.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
The point of this sample project is that we handle SiteMap.SiteMapResolve <br>
event to dynamically create/change current SiteMapNode.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SiteMap.SiteMapResolve &#43;= new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SiteMapNode SiteMap_SiteMapResolve(object sender, SiteMapResolveEventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Only need one execution in one request.<br>
&nbsp; &nbsp; &nbsp; &nbsp;SiteMap.SiteMapResolve -= new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (SiteMap.CurrentNode != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// SiteMap.CurrentNode is readonly, so we need to clone one to operate.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;currentNode.Title = Request.QueryString[&quot;name&quot;];<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Use the changed one in the breadcrumb.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return currentNode;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;return null;<br>
&nbsp; &nbsp;}<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
SiteMapPath Web Server Control Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/x20z8c51.aspx">http://msdn.microsoft.com/en-us/library/x20z8c51.aspx</a><br>
<br>
SiteMap Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.sitemap.aspx">http://msdn.microsoft.com/en-us/library/system.web.sitemap.aspx</a><br>
<br>
SiteMap.SiteMapResolve Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.sitemap.sitemapresolve.aspx">http://msdn.microsoft.com/en-us/library/system.web.sitemap.sitemapresolve.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
