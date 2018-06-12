# Admin IIS using WMI (CSIISAdminWMI)
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
* 2011-05-05 05:36:01
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSIISAdminWMI Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to use Windows Management Instrumentation (WMI) <br>
to configure IIS by using .Net System.Management namespace to access IIS WMI <br>
Provider. The classes, methods, and properties of the IIS WMI provider can be<br>
used to configure IIS from scripts or executables. <br>
<br>
The IIS WMI provider, like the IIS ADSI provider, provides a standard syntax <br>
for accessing IIS configuration data through the use of the IIS admin <br>
objects. Any script or code that attempts to manage IIS using Windows <br>
Management Instrumentation (WMI) needs to access the IIS WMI provider <br>
objects. For example, if you want to change a Web site property in the <br>
metabase, you must instantiate the class called IIsWebServerSetting which is <br>
a child of the CIM_Setting class. The IIS WMI provider cannot be used without <br>
certain methods of the Windows WMI classes. <br>
<br>
To run this example project. you need:<br>
Step1. Install IIS 6.0, IIS 7.0 or IIS 7.5.<br>
Step2. You must log on as a system administrator to execute this sample.<br>
<br>
Note:<br>
1. Ensure there is no Web site called &quot;IISWMIDemo&quot; on your IIS server. <br>
2. Make sure TCP port 83 is available.<br>
<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Install IIS 6.0, IIS 7.0 or IIS 7.5<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create a new web site<br>
<br>
&nbsp;1. Connect to IIS WMI Provider by calling ManagementScope.Connect().<br>
&nbsp;2. Create a 'ServerBinding' WMI class instance.<br>
&nbsp;3. Retrive W3SVC instance through ManagementObject.<br>
&nbsp;4. Invoke 'CreateNewSite' method to create the new web site.<br>
<br>
B. Start the web site<br>
<br>
&nbsp;Invoke 'Start' method of the new site instance to start it.<br>
<br>
C. Create a virtual directory<br>
<br>
&nbsp;1. Create an 'IIsWebVirtualDirSetting' instance.<br>
&nbsp;2. Create new virtual directory object by calling <br>
&nbsp; &nbsp; ManagementClass.CreateInstance().<br>
&nbsp;3. Invoke 'AppCreate2' method to create web application for the new virtual
<br>
&nbsp; &nbsp; directory in IIS.<br>
<br>
D. List all web sites on the server<br>
<br>
&nbsp;Query and enumerate 'IISWebServerSetting' objects on the server to list all
<br>
&nbsp;web sites.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: IIS WMI Provider<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms525265.aspx">http://msdn.microsoft.com/en-us/library/ms525265.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
