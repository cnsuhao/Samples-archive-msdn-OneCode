# Admin IIS using ADSI (VBIISAdminADSI)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* IIS
* ADSI
## Topics
* IIS Admin
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:53:06
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBIISAdminADSI Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New">This sample demonstrates how to use Active Directory Service Interfaces (ADSI)
<br>
to configure IIS by using .Net System.DirectoryServices namespace to access IIS <br>
ADSI Provider. The classes, methods, and properties of the IIS ADSI provider can<br>
be used to configure IIS from scripts or executables. <br>
<br>
Active Directory Service Interfaces (ADSI) is a directory service model and a <br>
set of Component Object Model (COM) interfaces. ADSI enables Windows applications<br>
and Active Directory clients to access several network directory services. The<br>
IIS ADSI provider, like the IIS WMI provider provides a standard syntax for <br>
accessing IIS configuration data.<br>
<br>
To run this example project. you need:<br>
Step1. Install IIS 6.0, IIS 7.0 or IIS7.5.<br>
Step2. You must log on as a system administrator to execute this sample.<br>
<br>
Note:<br>
1.Ensure there is no Web site called &quot;IISADSIDemo&quot; on your IIS server. <br>
2.Make sure TCP port 83 is available.<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Install IIS 6.0, IIS 7.0 or IIS7.5<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Retrive W3SVC object with System.DirectoryServices.DirectoryEntry.<br>
2. Create a 'siteProperty' object arrary contains new site's properties.<br>
3. Invoke 'CreateNewSite' method to create the new web site.<br>
4. Invoke 'Start' method of the new site instance to start it.<br>
5. Retrive new site's instance with System.DirectoryServices.DirectoryEntry.<br>
6. Create new virtual directory object by calling <br>
&nbsp; &nbsp;DirectoryEntries.Add().<br>
7. Set virtual directory properties.<br>
8. List all web sites on the server by enumerating DirectoryEntry objects <br>
&nbsp; &nbsp;in W3SVC instance's Children collection.<br>
&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
IIS ADSI Provider<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms524997.aspx">http://msdn.microsoft.com/en-us/library/ms524997.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
