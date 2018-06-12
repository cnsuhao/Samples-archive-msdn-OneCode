# Provide, register and use service in VSPackage (CSVSService)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Consume service in VSPackage
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:37:44
## Description

<p style="font-family:Courier New"></p>
<h2>VISUAL STUDIO EXTENSIBILITY : CSVSService Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to provide, register, consume service in <br>
VSPackage.<br>
<br>
1) Provide services in VSPackage as a Service Provider, this sample providing <br>
&nbsp; a global service and a local service.<br>
&nbsp; We adding callback methods to the service container to create the services
<br>
&nbsp; at first, and then implementing the callback methods and the services <br>
&nbsp; classes.<br>
<br>
2) Register the services we provided.<br>
&nbsp; Only the global services need to be registered, we using <br>
&nbsp; ProvideServiceAttribute attribute to register them, and using <br>
&nbsp; DefaultRegistryRootAttribute and PackageRegistrationAttribute attributes to
<br>
&nbsp; specify the path in the registry.<br>
<br>
3) Consume the services we provided in another VSPackage.<br>
&nbsp; In sited VSPackage, we using GetService method provided by Package class to<br>
&nbsp; get the services. &nbsp;In non-sited scenario, such as in a tool window, we could
<br>
&nbsp; use GetGlobalService method to get the services.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
VS 2008 SDK must be installed on the machine. You can download it from:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en</a><br>
<br>
Otherwise the project may not be opened by Visual Studio.<br>
<br>
If you run this project on a x64 OS, please also config the Debug tab of the project<br>
Setting. Set the &quot;Start external program&quot; to <br>
C:\Program Files(x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe<br>
<br>
NOTE: The Package Load Failure Dialog occurs because there is no PLK(Package Load Key)<br>
&nbsp; &nbsp; &nbsp;Specified in this package. To obtain a PLK, please to go to WebSite:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/vsx/cc655795.aspx">http://msdn.microsoft.com/en-us/vsx/cc655795.aspx</a><br>
&nbsp; &nbsp; &nbsp;More info<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">http://msdn.microsoft.com/en-us/library/bb165395.aspx</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Studio Integration Package project from the New <br>
Project dialog, with Menu Command checkbox checked, so we have a .vsct file <br>
which responsible to the menu commands.<br>
<br>
Step2. Open the default package class file(we make it as Service Provider), add <br>
[ProvideService] attribute at the head of Package class's definition to provide<br>
our global service.<br>
<br>
Step3. In the Service Provider package class's constructor, add service callback<br>
to the service container:<br>
IServiceContainer serviceContainer = this as IServiceContainer;<br>
ServiceCreatorCallback callback = new ServiceCreatorCallback(CreateService);<br>
serviceContainer.AddService(typeof(SCSGlobalService), callback, true);<br>
serviceContainer.AddService(typeof(SCSLocalService), callback);<br>
<br>
Step4. Implement the service callback:<br>
private object CreateService(IServiceContainer container, Type serviceType)<br>
{<br>
&nbsp; &nbsp;if (typeof(SCSGlobalService) == serviceType)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return new GlobalService(this);<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;else if (typeof(SCSLocalService) == serviceType)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return new LocalService(this);<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;else<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return null;<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Step4. Create a new class file to implement the global service class.<br>
<br>
Step5. Create a new class file to implement the local service class.<br>
<br>
Step6. Create a new package class file to implement the Service Consumer, apply<br>
[ProvideMenuResource] attribute to it to expose the menus created by .vsct file.<br>
<br>
Step7. Add the menu items in Initialize method of package class, implement the<br>
handlers of the menu items.<br>
<br>
Step8. Modify the .vsct file to specify the Menu Command.<br>
1) Create two menu groups for the submenu and buttons:<br>
&lt;Groups&gt;<br>
&nbsp; &nbsp;&lt;Group guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceMenuGroup&quot; priority=&quot;0x0600&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDM_VS_MENU_TOOLS&quot;/&gt;<br>
&nbsp; &nbsp;&lt;/Group&gt;<br>
<br>
&nbsp; &nbsp;&lt;Group guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceButtonGroup&quot; priority=&quot;0x0600&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceMenu&quot;/&gt;<br>
&nbsp; &nbsp;&lt;/Group&gt;<br>
&lt;/Groups&gt;<br>
<br>
2) Create the submenu:<br>
&lt;Menus&gt;<br>
&nbsp; &nbsp;&lt;Menu guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceMenu&quot; priority=&quot;0x700&quot; type=&quot;Menu&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceMenuGroup&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ButtonText&gt;Service Sample&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandName&gt;Service Sample&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Strings&gt;<br>
&nbsp; &nbsp;&lt;/Menu&gt;<br>
&lt;/Menus&gt;<br>
<br>
3) Create the buttons:<br>
&lt;Buttons&gt;<br>
&nbsp; &nbsp;&lt;Button guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;cmdidCallLocalService&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceButtonGroup&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandName&gt;cmdidCallLocalService&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ButtonText&gt;CallLocalService&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Strings&gt;<br>
&nbsp; &nbsp;&lt;/Button&gt;<br>
<br>
&nbsp; &nbsp;&lt;Button guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;cmdidCallGlobalService&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidCSVSServiceCmdSet&quot; id=&quot;ServiceButtonGroup&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic2&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;CommandName&gt;cmdidCallGlobalService&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ButtonText&gt;CallGlobalService&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Strings&gt;<br>
&nbsp; &nbsp;&lt;/Button&gt;<br>
&lt;/Buttons&gt;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166389.aspx">http://msdn.microsoft.com/en-us/library/bb166389.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
