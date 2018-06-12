# Admin IIS using WMI (VBIISAdminWMI)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* IIS
* WMI
## Topics
* IIS Admin
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:53:53
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBIISAdminWMI Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New">This sample demonstrates how to use Windows Management Instrumentation (WMI)
<br>
to configure IIS by using .Net System.Management namespace to access IIS WMI <br>
Provider. The classes, methods, and properties of the IIS WMI provider can be<br>
used to configure IIS from scripts or executables. <br>
<br>
The IIS WMI provider, like the IIS ADSI provider, provides a standard syntax <br>
for accessing IIS configuration data through the use of the IIS admin objects. <br>
Any script or code that attempts to manage IIS using Windows Management <br>
Instrumentation (WMI) needs to access the IIS WMI provider objects. For example,<br>
if you want to change a Web site property in the metabase, you must instantiate<br>
the class called IIsWebServerSetting which is a child of the CIM_Setting class.<br>
The IIS WMI provider cannot be used without certain methods of the Windows WMI <br>
classes. <br>
<br>
<br>
To run this example project. you need:<br>
Step1. Install IIS 6.0, IIS 7.0 or IIS7.5.<br>
Step2. You must log on as a system administrator to execute this sample.<br>
<br>
Note:<br>
1.Ensure there is no Web site called &quot;IISWMIDemo&quot; on your IIS server. <br>
2.Make sure TCP port 83 is available.<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Install IIS 6.0, IIS 7.0 or IIS7.5<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Connection to IIS WMI Provider by calling ManagementScope.Connect().<br>
2. Create a 'ServerBinding' WMI class instance.<br>
3. Retrive W3SVC instance through ManagementObject.<br>
4. Invoke 'CreateNewSite' method to create the new web site.<br>
5. Invoke 'Start' method of the new site instance to start it.<br>
6. Create an 'IIsWebVirtualDirSetting' instance.<br>
7. Create new virtual directory object by calling <br>
&nbsp; &nbsp;ManagementClass.CreateInstance().<br>
8. Invoke 'AppCreate2' method to create web application for the new <br>
&nbsp; &nbsp;virtual directory in IIS.<br>
9. Query and enumerate 'IISWebServerSetting' objects on the server to<br>
&nbsp; &nbsp;list all web sites.&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
IIS WMI Provider<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms525265.aspx">http://msdn.microsoft.com/en-us/library/ms525265.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
