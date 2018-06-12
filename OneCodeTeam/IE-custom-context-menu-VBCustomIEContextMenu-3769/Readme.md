# IE custom context menu (VBCustomIEContextMenu)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Internet Explorer
## Topics
* Context menu
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:04:45
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBCustomIEContextMenu Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to open an image in a new Tab using customized IE
<br>
Context Menu. This sample<br>
supplies following features:<br>
1. Adding Entries to the IE Standard Context Menu. <br>
2. Overriding the IE Standard Context Menu using Browser Helper Object.<br>
3. Deploy the custom IE Context Menu.<br>
<br>
NOTE:<br>
1. In IE8, there is a new approach to add a entry to IE context menu, which is called<br>
&nbsp; Accelerator or Activity. Accelerators make it easier to copy information from one
<br>
&nbsp; Web page to another, and &quot;Adding Entries to the IE Standard Context Menu&quot; is still<br>
&nbsp; a good approach to do work locally.<br>
<br>
2. If you override the IE Standard Context Menu in a BHO, make sure only one add-on
<br>
&nbsp; at a time can override IDocHostUIHandler and multiple add-ons can easily conflict
<br>
&nbsp; with each other. You can also create your own web browser to set this handler.<br>
<br>
3. On Windows Server 2008 or Windows Server 2008 R2, the Internet Explorer Enhanced
<br>
&nbsp; Security Configuration (IE ESC) is set to On by default, which means that this
<br>
&nbsp; Extension can not be loaded by IE. You have to turn off IE ESC for you. <br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
For 32bit IE on x86 or x64 OS, installVBCustomIEContextMenuSetup(x86).msi, the output<br>
of the VBCustomIEContextMenuSetup(x86) setup project.<br>
<br>
For 64bit IE on x64 OS, install VBCustomIEContextMenuSetup(x64).msi outputted by the
<br>
VBCustomIEContextMenuSetup(x64) setup project.<br>
<br>
B. Removal<br>
<br>
For 32bit IE on x86 or x64 OS, uninstall VBCustomIEContextMenuSetup(x86).msi, the
<br>
output of the VBCustomIEContextMenuSetup(x86) setup project. <br>
<br>
For 64bit IE on x64 OS, uninstall VBCustomIEContextMenuSetup(x64).msi, the output of<br>
the VBCustomIEContextMenuSetup(x64) setup project.<br>
<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in VS2008 and set the platform of the solution to x86. Make<br>
&nbsp; &nbsp; &nbsp; sure that the projects VBCustomIEContextMenu and VBCustomIEContextMenuSetup(x86)<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; are selected to build in Configuration Manager.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; NOTE: If you want to run this sample in 64bit IE, set the platform to x64 and
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; select VBCustomIEContextMenu and VBCustomIEContextMenuSetup(x64) to build.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution.<br>
<br>
Step3. Right click the project VBCustomIEContextMenuSetup(x86) in Solution Explorer,
<br>
&nbsp; &nbsp; &nbsp; and choose &quot;Install&quot;.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; After the installation, open 32bit IE and click Tools=&gt;Manage Add-ons, in the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Manage Add-ons dialog, you can find the item &quot;VBCustomIEContextMenu.BHOIEContextMenu&quot;.<br>
<br>
Demo Adding Entries to the IE Standard Context Menu. <br>
<br>
Step4. Open 32bit IE and click Tools=&gt;Manage Add-ons, and disable <br>
&nbsp; &nbsp; &nbsp; &quot;VBCustomIEContextMenu.BHOIEContextMenu&quot;. You may have to restart IE to make it
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; take effect. <br>
<br>
Step5. Visit <a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/.">
http://www.microsoft.com/.</a>'&gt;<a target="_blank" href="http://www.microsoft.com/.">http://www.microsoft.com/.</a> Right click an image on the web page, in the context<br>
&nbsp; &nbsp; &nbsp; menu, you will see the item &quot;Open image in new tab&quot;. Click this item, and IE will<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; open a new tab to open the image.<br>
<br>
Demo Overriding the IE Standard Context Menu.<br>
<br>
Step6. Open 32bit IE and click Tools=&gt;Manage Add-ons, and enable <br>
&nbsp; &nbsp; &nbsp; &quot;VBCustomIEContextMenu.BHOIEContextMenu&quot;. You may have to restart IE to make it
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; take effect. <br>
<br>
Step7. Visit <a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/.">
http://www.microsoft.com/.</a>'&gt;<a target="_blank" href="http://www.microsoft.com/.">http://www.microsoft.com/.</a> Right click an image on the web page, in the context<br>
&nbsp; &nbsp; &nbsp; menu, you will only see one item called &quot;Open image in new tab&quot;. Click this item, and IE will<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; open a new tab to open the image.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Create the project and add references<br>
<br>
In Visual Studio 2008, create a Visual Basic / Windows / Class Library project <br>
named &quot;VBCustomIEContextMenu&quot;. <br>
<br>
Right click the project in Solution Explorer and choose &quot;Add Reference&quot;. Add<br>
&quot;Microsoft HTML Object Library&quot; and &quot;Microsoft Internet Controls&quot; in COM tab.<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
B. Add Entries to the IE Standard Context Menu.<br>
<br>
To add a entry to IE Standard Context Menu, you can add a key under <br>
&quot;HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\MenuExt\&quot;. &nbsp;The default
<br>
value of the key is the html file path that will handle the event. See <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx</a>
 for detailed information.<br>
<br>
The class OpenImageMenuExt supplies 2 methods to add / remove entries in the registry.<br>
And the html page Resource\OpenImage.htm is used to open a image in a new tab.<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
C. Override the IE Standard Context Menu using Browser Helper Object.<br>
<br>
1. The class OpenImageHandler implements the interface IDocHostUIHandler, and it will<br>
&nbsp; override the default context menu.<br>
<br>
2. The class OpenImageBHO is a Browser Helper Object that will set the OpenImageHandler<br>
&nbsp; as the UIHandler of the html document. For how to create / deploy BHO, see the sample<br>
&nbsp; &quot;CSBrowserHelperObject&quot; in Microsoft All-In-One Code Framework. &nbsp;
<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
D. Deploying the custom context menu with a setup project.<br>
<br>
&nbsp;(1) In VBCustomIEContextMenu, add an Installer class (named CustomIEContextMenuInstaller
<br>
&nbsp; &nbsp; &nbsp;in this code sample) to define the custom actions in the setup. The class derives from<br>
&nbsp; &nbsp; &nbsp;System.Configuration.Install.Installer. We use the custom actions to add/remove the IE
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Context Menu entries in registry and register/unregister the COM-visible classes in<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;the current managed assembly when user installs/uninstalls the component.
<br>
<br>
&nbsp; &nbsp;[RunInstaller(true), ComVisible(false)]<br>
&nbsp; &nbsp;public partial class CustomIEContextMenuInstaller : System.Configuration.Install.Installer<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public CustomIEContextMenuInstaller()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public override void Install(System.Collections.IDictionary stateSaver)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;base.Install(stateSaver);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OpenImageMenuExt.RegisterMenuExt();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RegistrationServices regsrv = new RegistrationServices();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!regsrv.RegisterAssembly(this.GetType().Assembly,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AssemblyRegistrationFlags.SetCodeBase))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new InstallException(&quot;Failed To Register for COM&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public override void Uninstall(System.Collections.IDictionary savedState)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;base.Uninstall(savedState);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;OpenImageMenuExt.UnRegisterMenuExt();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RegistrationServices regsrv = new RegistrationServices();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!regsrv.UnregisterAssembly(this.GetType().Assembly))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new InstallException(&quot;Failed To Unregister for COM&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
<br>
&nbsp;(2) To add a deployment project, on the File menu, point to Add, and then <br>
&nbsp;click New Project. In the Add New Project dialog box, expand the Other <br>
&nbsp;Project Types node, expand the Setup and Deployment Projects, click Visual <br>
&nbsp;Studio Installer, and then click Setup Project. In the Name box, type <br>
&nbsp;VBCustomIEContextMenuSetup(x86). Click OK to create the project. <br>
&nbsp;In the Properties dialog of the setup project, make sure that the <br>
&nbsp;TargetPlatform property is set to x86. This setup project is to be deployed
<br>
&nbsp;for 32bit IE on x86 or x64 Windows operating systems. <br>
<br>
&nbsp;Right-click the setup project, and choose Add / Project Output ... <br>
&nbsp;In the Add Project Output Group dialog box, VBCustomIEContextMenu will &nbsp;<br>
&nbsp;be displayed in the Project list. Select Primary Output and click OK. VS<br>
&nbsp;will detect the dependencies of the VBCustomIEContextMenu, including .NET<br>
&nbsp;Framework 4.0 (Client Profile).<br>
<br>
&nbsp;Right-click the setup project, and choose View / Custom Actions. <br>
&nbsp;In the Custom Actions Editor, right-click the root Custom Actions node. On <br>
&nbsp;the Action menu, click Add Custom Action. In the Select Item in Project <br>
&nbsp;dialog box, double-click the Application Folder. Select Primary output from
<br>
&nbsp;VBCustomIEContextMenu. This adds the custom actions that we defined <br>
&nbsp;in BHOInstaller of VBCustomIEContextMenu. <br>
&nbsp;<br>
&nbsp;Right-click the setup project again, and choose View / File System. In the <br>
&nbsp;Application Folder, add a folder named &quot;Resource&quot;, and add OpenImage.htm to
<br>
&nbsp;this folder.<br>
<br>
&nbsp;Build the setup project. If the build succeeds, you will get a .msi file <br>
&nbsp;and a Setup.exe file. You can distribute them to your users to install or <br>
&nbsp;uninstall this BHO. <br>
<br>
&nbsp;(3) To deploy the BHO for 64bit IE on a x64 operating system, you <br>
&nbsp;must create a new setup project (e.g. VBCustomIEContextMenuSetup(x64) <br>
&nbsp;in this code sample), and set its TargetPlatform property to x64. <br>
<br>
&nbsp;Although the TargetPlatform property is set to x64, the native shim <br>
&nbsp;packaged with the .msi file is still a 32-bit executable. The Visual Studio
<br>
&nbsp;embeds the 32-bit version of InstallUtilLib.dll into the Binary table as <br>
&nbsp;InstallUtil. So the custom actions will be run in the 32-bit, which is <br>
&nbsp;unexpected in this code sample. To workaround this issue and ensure that <br>
&nbsp;the custom actions run in the 64-bit mode, you either need to import the <br>
&nbsp;appropriate bitness of InstallUtilLib.dll into the Binary table for the <br>
&nbsp;InstallUtil record or - if you do have or will have 32-bit managed custom <br>
&nbsp;actions add it as a new record in the Binary table and adjust the <br>
&nbsp;CustomAction table to use the 64-bit Binary table record for 64-bit managed
<br>
&nbsp;custom actions. This blog article introduces how to do it manually with <br>
&nbsp;Orca <a target="_blank" href="http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx">
http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx</a><br>
<br>
&nbsp;In this code sample, we automate the modification of InstallUtil by using a
<br>
&nbsp;post-build javascript: Fix64bitInstallUtilLib.js. You can find the script <br>
&nbsp;file in the VBCustomIEContextMenuSetup(x64) project folder. To <br>
&nbsp;configure the script to run in the post-build event, you select the <br>
&nbsp;VBCustomIEContextMenuSetup(x64) project in Solution Explorer, and <br>
&nbsp;find the PostBuildEvent property in the Properties window. Specify its <br>
&nbsp;value to be <br>
&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;$(ProjectDir)Fix64bitInstallUtilLib.js&quot; &quot;$(BuiltOuputPath)&quot; &quot;$(ProjectDir)&quot;<br>
<br>
&nbsp;Repeat the rest steps in (2) to add the project output, set the custom <br>
&nbsp;actions, configure the prerequisites, and build the setup project.<br>
<br>
</p>
<h3>Diagnostic:</h3>
<p style="font-family:Courier New"><br>
To debug IE Context Menu, you can attach to iexplorer.exe. <br>
<br>
<br>
<br>
References:<br>
<br>
Adding Entries to the Standard Context Menu<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa753589(VS.85).aspx</a><br>
<br>
Context Menus and Extensions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa770042(VS.85).aspx#wbc_ctxmenus">http://msdn.microsoft.com/en-us/library/aa770042(VS.85).aspx#wbc_ctxmenus</a><br>
<br>
Browser Helper Objects: The Browser the Way You Want It<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms976373.aspx">http://msdn.microsoft.com/en-us/library/ms976373.aspx</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
