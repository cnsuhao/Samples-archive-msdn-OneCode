# ASP.NET MVC custom ActionFilters (CSASPNETMVCCustomActionFilter)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Model View Controller (MVC)
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:02:51
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET MVC APPLICATION : CSASPNETMVCCustomActionFilter Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;&nbsp;&nbsp;&nbsp;The CSASPNETMVCCustomActionFilter sample demonstrates how to use C# codes
<br>
&nbsp;&nbsp;&nbsp;&nbsp;to create custom ActionFilters for ASP.NET MVC web application. In this
<br>
&nbsp;&nbsp;&nbsp;&nbsp;sample,&nbsp;&nbsp;&nbsp;&nbsp;there are two custom ActionFilters, one is used for customizing
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ViewData before page view result get executed and rendered; another is
<br>
&nbsp;&nbsp;&nbsp;&nbsp;used for perform logging within the various events during the processing
<br>
&nbsp;&nbsp;&nbsp;&nbsp;of custom ActionFilters.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
Visual Studio 2008 SP1 with ASP.NET MVC 1.0 extension installed. <br>
<br>
*ASP.NET MVC 1.0 RTM download:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=53289097-73ce-43bf-b6a6-35e00103cb4b&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=53289097-73ce-43bf-b6a6-35e00103cb4b&displaylang=en</a><br>
<br>
</p>
<h3>How to Run:</h3>
<p style="font-family:Courier New">&nbsp;<br>
*open the project<br>
<br>
*select &nbsp;default.aspx page and view it in browser<br>
<br>
*in the main page UI, the message data(modified by ActionFilter) is displayed<br>
<br>
*click the &quot;About&quot; tab, the About page will be displayed, this will trigger
<br>
the Logging ActionFilter which will log events into the specified log file.<br>
<br>
</p>
<h3>Key components:</h3>
<p style="font-family:Courier New"><br>
*web.config file: contains all the necessary configuration information <br>
&nbsp;&nbsp;&nbsp;&nbsp;of this web application<br>
<br>
*global.asax: contains all the URL routing rules<br>
<br>
*HomeController class: contains the main application <br>
&nbsp;&nbsp;&nbsp;&nbsp;navigation logic(such as default page and about page)<br>
<br>
*Home Views: the page UI elements for HomeController<br>
<br>
*shared Views & Site.Master: those UI elements shared by all page UI<br>
<br>
*MessageModifierActionFilter: this is one of the custom ActionFilters which <br>
is used for intercepting the ActionResult execution and modify the ViewData<br>
<br>
<br>
*TextLogActionFilter: this is another ActionFilter which is used to log some<br>
info during the various events of ActionResult execution.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
#ASP.NET MVC Tutorials<br>
<a target="_blank" href="http://www.asp.net/Learn/mvc/">http://www.asp.net/Learn/mvc/</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
