# Admin IIS7 using MWA (CSIIS7AdminMWA)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* IIS
## Topics
* IIS Admin
## IsPublished
* True
## ModifiedDate
* 2012-03-22 01:48:35
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CSIIS7AdminMWA Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New">The Microsoft.Web.Administration namespace contains classes that a developer
<br>
can use to administer IIS Manager. With the classes in this namespace, an <br>
administrator can read and write configuration information to ApplicationHost.<br>
config, Web.config, and Administration.config files.<br>
<br>
The classes in the Microsoft.Web.Administration namespace contain a series of <br>
convenient top-level objects that allow the developer to perform administrative<br>
tasks. The different logical objects available include sites, applications,<br>
application pools, application domains, virtual directories, and worker <br>
processes. You can use the API to obtain and work with the configuration <br>
and state of these objects and to perform such actions as creating a site, <br>
starting or stopping a site, deleting an application pool, recycling an <br>
application pool, and even unloading application domains.<br>
<br>
To run this example project. you need:<br>
Step1. Install IIS7 or IIS7.5.<br>
Step2. Add a refernce to Microsoft.Web.Administration.dll. You can find <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; this dll at (%WinDir%\System32\InetSrv).<br>
Step3. You must run as administrator to execute this sample.<br>
<br>
Note:<br>
1.Ensure there is no Web site called &quot;MySite&quot; on your IIS server. <br>
2.Make sure port 8080 is available.<br>
<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Install IIS 7 or IIS 7.5<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
0. Add reference to Microsoft.Web.Administration.dll <br>
1. Create a IIS7 Site by calling ServerManager.Sites.Add<br>
2. Create a IIS7 Application by calling <br>
&nbsp;&nbsp;&nbsp;&nbsp;ServerManager.Sites[siteName].Applications.Add<br>
3. Create a Virtual Directory by calling ServerManager.Sites[siteName].<br>
&nbsp;&nbsp;&nbsp;&nbsp;Applications[appName].VirtualDirectories.Add<br>
4. Create a Application Pool by calling ServerManager.ApplicationPools.Add<br>
5. Delete a IIS7 Site by calling ServerManager.Sites.Remove<br>
6. Delete a IIS7 Application Pool by calling <br>
&nbsp;&nbsp;&nbsp;&nbsp;ServerManager.ApplicationPools.Remove<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Microsoft.Web.Administrator Namespaces<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.web.administration.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/microsoft.web.administration.aspx</a><br>
<br>
</p>
<p style="font-family:Courier New">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
