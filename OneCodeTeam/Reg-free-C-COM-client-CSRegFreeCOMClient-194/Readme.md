# Reg-free C# COM client (CSRegFreeCOMClient)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* COM
## Topics
* Interop
* Reg-free COM
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:56:41
## Description

<p style="font-family:Courier New"></p>
<h2>LIBRARY APPLICATION : CSRegFreeCOMClient Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Registration-free COM is a mechanism available on the Microsoft Windows XP <br>
(SP2 for .NET Framework-based components), Microsoft Windows Server 2003 and <br>
newer platforms. As the name suggests, the mechanism enables easy (e.g. <br>
XCOPY) deployment of COM components to a machine without the need to register <br>
them.<br>
<br>
The CSRegFreeCOMClient sample demonstrates how to create a registration-free <br>
COM from the aspect of .NET Framework based client, so that the client can <br>
consume existing COM server as if the COM server is Registration-free.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(Relation of the current sample and other samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://cfx.codeplex.com)">
http://cfx.codeplex.com)</a><br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;CSRegFreeCOMClient -&gt; ATLDllCOMServer<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. The client automatically searches manifest file of its dependency, <br>
and use the manifest file to Activate the activation context.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step1. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add a reference to the ATLDllCOMServer COM component by right-clicking
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the project, selecting &quot;Add Reference...&quot;, turning to the COM tab, and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;adding ATLDllCOMServer Type Library. Visual Studio will automatically
<br>
&nbsp;&nbsp;&nbsp;&nbsp;generate an interop assembly &quot;Interop.ATLDllCOMServerLib.dll&quot;. If the<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServer Type Library is not in the list, please build and setup
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the ATLDllCOMServer sample first.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step2. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create a thread whose thread apartement is set to STA, because we are
<br>
&nbsp;&nbsp;&nbsp;&nbsp;going to demonstrate the instantiation and use of a STA COM object:
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServer.SimpleObject.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step3. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create method ConsumeCOMComponent which contains logic of consuming COM
<br>
&nbsp;&nbsp;&nbsp;&nbsp;server.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step4. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add app.manifest file by right-clicking the project, selecting &quot;Add&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;--&gt; &quot;New Item&quot; --&gt; &quot;General&quot; --&gt; &quot;Application Manifest File&quot; and click
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Add button. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step5. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Open the app.manifest file, find assemblyIdentity element, modify its
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Name property to CSRegFreeCOMClient:<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity version=&quot;1.0.0.0&quot; name=&quot;CSRegFreeCOMClient&quot;/&gt;<br>
&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step6. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add dependency element immediate after assemblyIdentity node:<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dependency&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dependentAssembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;name=&quot;ATLDllCOMServer.X&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;version=&quot;1.0.0.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dependentAssembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dependency&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step7. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Open property page of the app.manifest file by right-clicking the file
<br>
&nbsp;&nbsp;&nbsp;&nbsp;and selecting Property, change the value of Build Action dropdown to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Embedded Resource, and rebuild the application.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step8. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Open the application's output folder (Debug or Release folder), put a
<br>
&nbsp;&nbsp;&nbsp;&nbsp;copy of ATLDllCOMServer.dll to this folder,&nbsp;&nbsp;&nbsp;&nbsp;create a txt file and rename
<br>
&nbsp;&nbsp;&nbsp;&nbsp;it (including file extention) to ATLDllCOMServer.X.manifest, input the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;following content:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; standalone=&quot;yes&quot;?&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assembly xmlns=&quot;urn:schemas-microsoft-com:asm.v1&quot; &nbsp;manifestVersion=&quot;1.0&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; name=&quot;ATLDllCOMServer.X&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0.0.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;file name = &quot;ATLDllCOMServer.dll&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comClass clsid=&quot;{92FCF37F-F6C7-4F8A-AA09-1A14BA118084}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;threadingModel = &quot;Apartment&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;typelib tlbid=&quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0&quot; helpdir=&quot;&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/file&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comInterfaceExternalProxyStub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name=&quot;ISimpleObject&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid=&quot;{830F85D0-91B9-406D-A273-BC33133DD44B}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxyStubClsid32=&quot;{00020424-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseInterface=&quot;{00000000-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tlbid = &quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/assembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step9. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Unregistry the ATLDllCOMServer.dll, then run CSRegFreeCOMClient.exe.<br>
&nbsp;&nbsp;&nbsp;&nbsp;the output is:<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;------Activate activation context automatically------<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Call HelloWorld =&gt; HelloWorld<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Press any key to continue...<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
B. The client activates activation context by specifying manifest file <br>
manually.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step1. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add a reference to the ATLDllCOMServer COM component by right-clicking
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the project, selecting &quot;Add Reference...&quot;, turning to the COM tab, and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;adding ATLDllCOMServer Type Library. Visual Studio will automatically
<br>
&nbsp;&nbsp;&nbsp;&nbsp;generate an interop assembly &quot;Interop.ATLDllCOMServerLib.dll&quot;. If the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServer Type Library is not in the list, please build and setup
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the ATLDllCOMServer sample first.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step2. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create a thread whose thread apartement is set to STA, because we are
<br>
&nbsp;&nbsp;&nbsp;&nbsp;going to demonstrate the instantiation and use of a STA COM object:
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServer.SimpleObject.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step3. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create method ConsumeCOMComponent which contains logic of consuming COM
<br>
&nbsp;&nbsp;&nbsp;&nbsp;server.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step4. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create the ActivateActivationContext method which is used to activate
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the activation context according to given manifest file.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step5. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add app.manifest file by right-clicking the project, selecting &quot;Add&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;--&gt; &quot;New Item&quot; --&gt; &quot;General&quot; --&gt; &quot;Application Manifest File&quot; and click
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;Add&quot; button. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step6. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Open the app.manifest file, find assemblyIdentity element, modify its
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Name property to CSRegFreeCOMClient:<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity version=&quot;1.0.0.0&quot; name=&quot;CSRegFreeCOMClient&quot;/&gt;<br>
&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step7. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Add dependency element immediate after assemblyIdentity node:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dependency&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;dependentAssembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;name=&quot;ATLDllCOMServer.X&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;version=&quot;1.0.0.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dependentAssembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/dependency&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step8. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Open property page of the app.manifest file by right-clicking the file
<br>
&nbsp;&nbsp;&nbsp;&nbsp;and select Property, change the value of Build Action dropdown to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Embedded Resource, and rebuild the application.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step9. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Create a new folder, for example, &quot;D:\regfreecom&quot;, put a copy of
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServer.dll to this folder, create a txt file and rename it
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(including file extention) to ATLDllCOMServer.X.manifest, input following
<br>
&nbsp;&nbsp;&nbsp;&nbsp;content:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; standalone=&quot;yes&quot;?&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assembly xmlns=&quot;urn:schemas-microsoft-com:asm.v1&quot; &nbsp;manifestVersion=&quot;1.0&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; name=&quot;ATLDllCOMServer.X&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0.0.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;file name = &quot;ATLDllCOMServer.dll&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comClass clsid=&quot;{92FCF37F-F6C7-4F8A-AA09-1A14BA118084}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;threadingModel = &quot;Apartment&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;typelib tlbid=&quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0&quot; helpdir=&quot;&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/file&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comInterfaceExternalProxyStub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name=&quot;ISimpleObject&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid=&quot;{830F85D0-91B9-406D-A273-BC33133DD44B}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxyStubClsid32=&quot;{00020424-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseInterface=&quot;{00000000-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tlbid = &quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/assembly&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Step10. <br>
&nbsp;&nbsp;&nbsp;&nbsp;Unregistry the ATLDllCOMServer.dll, launch cmd.exe and navigate to the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;folder where CSRegFreeCOMClient.exe exists, start CSRegFreeCOMClient.exe
<br>
&nbsp;&nbsp;&nbsp;&nbsp;with command:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSRegFreeCOMClient.exe someargs<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;then, you will be required to input manifest file path:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;------ Activate activation context manually ------<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please input the full path of manifest file:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;in this case, since we put the manifest file at D:\regfreecom, so we
<br>
&nbsp;&nbsp;&nbsp;&nbsp;input:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D:\regfreecom\ATLDllCOMServer.X.manifest<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the full output is:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;------ Activate activation context manually ------<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please input the full path of manifest file:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D:\regfreecom\ATLDllCOMServer.X.manifest<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Call HelloWorld =&gt; HelloWorld<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Press any key to continue...<br>
<br>
</p>
<h3>FAQ:</h3>
<p style="font-family:Courier New"><br>
1. How can I get the CLSID, tlbID, iid etc if it is a third-party dll?<br>
To build a reg-free version for a given com dll, the key point it to <br>
construct a correct manifest file for the com dll, here is some tip for you:<br>
<br>
&nbsp; 1. Make sure that the dll has no embedded manifest, if there is, a <br>
&nbsp; &nbsp; &nbsp;separate manifest file will no take effect, manifest view can help to
<br>
&nbsp; &nbsp; &nbsp;verify whether a dll has embedded manifest.( but you can modify the
<br>
&nbsp; &nbsp; &nbsp;embedded manifest using some tools, anyway, it is not suggested).<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 2. Create a manifest file for the dll, the file usually looks like:<br>
&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; standalone=&quot;yes&quot;?&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assembly xmlns=&quot;urn:schemas-microsoft-com:asm.v1&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;manifestVersion=&quot;1.0&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; name=&quot; mycomdll.x&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0.0.0&quot; /&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;file name = &quot;mycomdll.dll&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comClass<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clsid=&quot;{[CLSID_ MyComClass]}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;threadingModel = &quot;Apartment&quot; /&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;typelib tlbid=&quot;{[LIBID_ MyComClass]}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0&quot; helpdir=&quot;&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/file&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comInterfaceExternalProxyStub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name=&quot; ISomeInterface &quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid=&quot;{[IID_I SomeInterface]}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxyStubClsid32=&quot;{00020424-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseInterface=&quot;{00000000-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tlbid = &quot;{[LIBID_ MyComClass ]}&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/assembly&gt;<br>
<br>
&nbsp; 3. To get values for placeholders in the manifest, we can use OLE/COM <br>
&nbsp; ObjectViewer (Oleview.exe) tool. <br>
&nbsp; <br>
&nbsp; Open Oleview.exe ( on Vista or Win7, you may run it as administrator),<br>
&nbsp; click File -&gt; View TypeLib… --&gt; select target com dll and click OK, <br>
&nbsp; let's open ATLDllCOMServer.dll, and you will see:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Generated .IDL file (by the OLE/COM Object Viewer)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// typelib filename: ATLDllCOMServer.dll<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;uuid(9B23EFED-A0C1-46B6-A903-218206447F3E),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;version(1.0),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;helpstring(&quot;ATLDllCOMServer 1.0 Type Library&quot;),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;custom(DE77BA64-517C-11D1-A2DA-0000F8773CE9, 117441012),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;custom(DE77BA63-517C-11D1-A2DA-0000F8773CE9, 1269332262),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;custom(DE77BA65-517C-11D1-A2DA-0000F8773CE9, &quot;Created by MIDL version 7.00.0500 at Tue Mar 23 16:17:41 2010<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;library ATLDllCOMServerLib<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// TLib : &nbsp; &nbsp; // TLib : OLE Automation : {00020430-0000-0000-C000-000000000046}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;importlib(&quot;stdole2.tlb&quot;);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Forward declare all types defined in this typelib<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dispinterface _ISimpleObjectEvents;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;interface ISimpleObject;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;uuid(87AD6FBC-8735-407C-9758-C80B48C78E7C),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;helpstring(&quot;_ISimpleObjectEvents Interface&quot;)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dispinterface _ISimpleObjectEvents {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;properties:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;methods:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[id(0x00000001), helpstring(&quot;method FloatPropertyChanging&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;void FloatPropertyChanging(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[in] single NewValue,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[in, out] VARIANT_BOOL* Cancel);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;uuid(92FCF37F-F6C7-4F8A-AA09-1A14BA118084),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;helpstring(&quot;SimpleObject Class&quot;)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;coclass SimpleObject {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[default] interface ISimpleObject;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[default, source] dispinterface _ISimpleObjectEvents;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;odl,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;uuid(830F85D0-91B9-406D-A273-BC33133DD44B),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;helpstring(&quot;ISimpleObject Interface&quot;),<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;dual,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;nonextensible,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;oleautomation<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;interface ISimpleObject : IDispatch {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[id(0x00000001), propget, helpstring(&quot;property FloatProperty&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HRESULT FloatProperty([out, retval] single* pVal);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[id(0x00000001), propput, helpstring(&quot;property FloatProperty&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HRESULT FloatProperty([in] single pVal);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[id(0x00000002), helpstring(&quot;method HelloWorld&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HRESULT HelloWorld([out, retval] BSTR* pRet);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[id(0x00000003), helpstring(&quot;method GetProcessThreadID&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HRESULT GetProcessThreadID(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[out] long* pdwProcessId,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[out] long* pdwThreadId);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};<br>
<br>
&nbsp; 6. With above information, we can fill in the manifest as following:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; standalone=&quot;yes&quot;?&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assembly xmlns=&quot;urn:schemas-microsoft-com:asm.v1&quot; &nbsp;manifestVersion=&quot;1.0&quot;&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;assemblyIdentity<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;win32&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; name=&quot;ATLDllCOMServer.X&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0.0.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;file name = &quot;ATLDllCOMServer.dll&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comClass clsid=&quot;{92FCF37F-F6C7-4F8A-AA09-1A14BA118084}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;threadingModel = &quot;Apartment&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;typelib tlbid=&quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; version=&quot;1.0&quot; helpdir=&quot;&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/file&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;comInterfaceExternalProxyStub<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name=&quot;ISimpleObject&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iid=&quot;{830F85D0-91B9-406D-A273-BC33133DD44B}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxyStubClsid32=&quot;{00020424-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseInterface=&quot;{00000000-0000-0000-C000-000000000046}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tlbid = &quot;{9B23EFED-A0C1-46B6-A903-218206447F3E}&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/assembly&gt;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Registration-Free Activation of COM Components: A Walkthrough<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms973913.aspx">http://msdn.microsoft.com/en-us/library/ms973913.aspx</a><br>
<br>
Registration-Free Activation of .NET-Based Components: A Walkthrough<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms973915.aspx">http://msdn.microsoft.com/en-us/library/ms973915.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
