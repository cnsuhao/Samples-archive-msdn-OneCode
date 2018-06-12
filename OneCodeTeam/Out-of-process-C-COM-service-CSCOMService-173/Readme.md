# Out-of-process C# COM service (CSCOMService)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* COM
* Windows Service
## Topics
* Interop
* out-of-process COM Service
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:22:05
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS SERVICE : CSCOMService Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
CSCOMService demonstrates an out-of-process COM/DCOM service in the form of &nbsp;<br>
Windows Service (EXE), which is implemented entirely in Visual C#. <br>
<br>
CSCOMService exposes the following item:<br>
<br>
1. SimpleObject<br>
<br>
Program ID: CSCOMService.SimpleObject<br>
CLSID_SimpleObject: E2EDB864-02DB-4130-BEE4-2E35B30BBF3B<br>
IID_ISimpleObject: 83C40736-3189-44bc-AB0F-9FB3703EA172<br>
DIID_ISimpleObjectEvents: 7A11E6DA-DD09-404c-8731-DB917E783501<br>
AppID: 2E78BFC7-FDD9-4b87-BB6F-470D08399DD1<br>
<br>
Properties:<br>
// With both get and set accessor methods<br>
float FloatProperty<br>
<br>
Methods:<br>
// HelloWorld returns a string &quot;HelloWorld&quot;<br>
string HelloWorld();<br>
// GetProcessThreadID outputs the running process ID and thread ID<br>
void GetProcessThreadID(out uint processId, out uint threadId);<br>
<br>
Events:<br>
// FloatPropertyChanging is fired before new value is set to the <br>
// FloatProperty property. The Cancel parameter allows the client to cancel <br>
// the change of FloatProperty.<br>
void FloatPropertyChanging(float NewValue, ref bool Cancel);<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSCOMService - ATLCOMService<br>
CSCOMService and ATLCOMService, implemented in different languages, are our-<br>
of-process COM components in the form of Windows Service.<br>
<br>
CSCOMService - CSExeCOMServer - CSDllCOMServer<br>
All are COM components written in Visual C#. CSCOMService is an out-of-<br>
process component in the form of Windows Service. CSExeCOMServer is an out-<br>
of-process component in the form of local server. CSDllCOMServer is an in-<br>
process component in the form of DLL.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regasm.exe CSCOMService.exe<br>
It registers the types that are COM-visible in CSCOMService.exe.<br>
<br>
Installutil.exe CSCOMService.exe<br>
It installs CSCOMService.exe into SCM as a Windows Service.<br>
<br>
B. Cleanup<br>
<br>
Regasm.exe /u CSCOMService.exe<br>
It unregisters the types that are COM-visible in CSCOMService.exe.<br>
<br>
Installutil.exe /u CSCOMService.exe<br>
It uninstalls CSCOMService from SCM.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C# / Windows / Windows Service project named <br>
CSCOMService in Visual Studio 2008.<br>
<br>
B. Adding the COMHelper class<br>
<br>
COMHelper provides the helper functions to register/unregister COM servers <br>
and encapsulates the native COM APIs to be used in .NET.<br>
<br>
C. Adding the Windows Service<br>
<br>
Step1. Rename the existing Windows Service component as COMServie.<br>
<br>
Step2. Double-click COMService.cs to open the component in the Visual Studio <br>
designer. In the Properties dialog, set the &quot;ServiceName&quot; property as <br>
&quot;CSCOMService&quot;. <br>
<br>
Step3. In the Properties dialog, click the &quot;Add Installer&quot; button. This
<br>
generates a Project Installer component. Rename it as COMServiceInstaller. <br>
<br>
Step4. Double-click COMServiceInstaller.cs to open the component in the <br>
Visual Studio designer. It contains a ServiceProcessInstaller, and a <br>
ServiceInstaller. Set the Account property of ServiceProcessInstaller as <br>
LocalSystem so that the service runs as the SYSTEM account. <br>
<br>
D. Configuring security access of the service.<br>
<br>
Step1. In the contructor of the Service class, call CoInitializeSecurity to, <br>
for example, allow only administrators to call in.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Initialize COM security<br>
&nbsp;&nbsp;&nbsp;&nbsp;int hResult = COMNative.CoInitializeSecurity(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr.Zero, &nbsp; &nbsp;// Add your security descriptor here<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-1, IntPtr.Zero, IntPtr.Zero, RPC_C_AUTHN_LEVEL.PKT_PRIVACY,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RPC_C_IMP_LEVEL.IDENTIFY, IntPtr.Zero,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EOLE_AUTHENTICATION_CAPABILITIES.DISABLE_AAA |
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EOLE_AUTHENTICATION_CAPABILITIES.SECURE_REFS |<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EOLE_AUTHENTICATION_CAPABILITIES.NO_CUSTOM_MARSHAL,<br>
&nbsp; &nbsp; &nbsp; &nbsp;IntPtr.Zero);<br>
<br>
E. Adding the COM-visible class SimpleObject<br>
<br>
Step1. Define a &quot;public&quot; COM-visible interface ISimpleObject to describe
<br>
the COM interface of the coclass. Specify its GUID, aka IID, using <br>
GuidAttribute: <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;83C40736-3189-44bc-AB0F-9FB3703EA172&quot;), ComVisible(true)]<br>
<br>
In this way, IID of the COM object is a fixed value. By default, the <br>
interfaces used by a .NET Class are transformed to dual interfaces <br>
[InterfaceType(ComInterfaceType.InterfaceIsDual)] in the IDL. This allows the<br>
client to get the best of both early binding and late binding. Other options &nbsp;<br>
are [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] and <br>
[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)].<br>
<br>
Step2. Inside the interface ISimpleObject, define the prototypes of the <br>
properties and methods to be exported. <br>
<br>
Step3. Define a &quot;public&quot; COM-visible interface ISimpleObjectEvents to <br>
describe the events the coclass can sink. Specify its GUID, aka the Events Id, <br>
using GuidAttribute:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;7A11E6DA-DD09-404c-8731-DB917E783501&quot;), ComVisible(true)]<br>
<br>
Decorate the interface as an IDispatch interface:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]<br>
<br>
Step4. Inside the interface ISimpleObjectEvents, define the prototype of<br>
the events to be exported.<br>
<br>
Step5. Define a &quot;public&quot; COM-visible class SimpleObject that implements
<br>
the interface ISimpleObject. Attach the attribute <br>
[ClassInterface(ClassInterfaceType.None)] to it, which tells the type-library<br>
generation tools that we do not require a Class Interface. This ensures that <br>
the ISimpleObject interface is the default interface. In addition, specify <br>
the GUID of the class, aka CLSID, using the Guid attribute:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;E2EDB864-02DB-4130-BEE4-2E35B30BBF3B&quot;), ComVisible(true)]<br>
<br>
In this way, CLSID of the COM object is a fixed value. Last, decorate the <br>
class with a ComSourceInterface attribute:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[ComSourceInterfaces(typeof(ISimpleObjectEvents))]<br>
<br>
ComSourceInterfaces identifies a list of interfaces that are exposed as&nbsp;&nbsp;&nbsp;&nbsp;COM
<br>
event sources for the attributed class.<br>
<br>
Step6. Make sure that the constructor of the class SimpleObject is not <br>
private (we can either add a public constructor or use the default one), so <br>
that the COM object is creatable from the COM aware clients.<br>
<br>
Step7. Inside SimpleObject, implement the interface ISimpleObject by <br>
writing the body of the property FloatProperty and the methods HelloWorld, &nbsp;<br>
GetProcessThreadID.<br>
<br>
F. Registering SimpleObject in the registry<br>
<br>
Additional registry keys and values are required for the COM service. The <br>
default COM registration routine in Regasm.exe only works for InprocServer <br>
in the form of DLL. In order to register the LocalServer, and allow remote <br>
activation (DCOM), we need to customize the registration routine to change <br>
InprocServer32 to LocalServer, and to set AppID appropriately.<br>
<br>
Step1. Inside SimpleObject, add the functions Register and Unregister, and <br>
decorate them with ComRegisterFunctionAttribute and <br>
ComUnregisterFunctionAttribute. The custom routine gets called after Regasm <br>
finishes the default behaviors. The Register and Unregister functions call <br>
the helper methods in COMHelper.<br>
<br>
G. Registering ClassFactory of SimpleObject<br>
<br>
Step1. Create a ClassFactory class that realizes the IClassFactory interface <br>
for SimpleObject.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;/// &lt;summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;/// Class factory for the class SimpleObject.<br>
&nbsp;&nbsp;&nbsp;&nbsp;/// &lt;/summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;internal class SimpleObjectClassFactory : IClassFactory<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public int CreateInstance(IntPtr pUnkOuter, ref Guid riid,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;out IntPtr ppvObject)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ppvObject = IntPtr.Zero;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (pUnkOuter != IntPtr.Zero)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Marshal.ThrowExceptionForHR(COMNative.CLASS_E_NOAGGREGATION);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (riid == new Guid(SimpleObject.ClassId) ||
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;riid == new Guid(COMNative.GuidIUnknown))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Create the instance of the .NET object<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ppvObject = Marshal.GetComInterfaceForObject(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new SimpleObject(), typeof(ISimpleObject));<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// The object that ppvObject points to does not support the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// interface identified by riid.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.ThrowExceptionForHR(COMNative.E_NOINTERFACE);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0; &nbsp; // S_OK<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public int LockServer(bool fLock)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0; &nbsp; // S_OK<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step2. Register the class factory of SimpleObject using the standard &nbsp;<br>
CoRegisterClassObject API when the service starts. Please note that PInvoking <br>
CoRegisterClassObject to register COM objects is a technique which is not <br>
supported.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Register the SimpleObject class object on start<br>
&nbsp;&nbsp;&nbsp;&nbsp;int hResult = COMNative.CoRegisterClassObject(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ref clsidSimpleObj, &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // CLSID to be registered<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new SimpleObjectClassFactory(), &nbsp; // Class factory<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSCTX.LOCAL_SERVER, &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Context to run<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;REGCLS.MULTIPLEUSE, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;out _cookie);<br>
<br>
Step3. Revoke the registration of SimpleObject using the <br>
CoRevokeClassObject API when the service stops.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;COMNative.CoRevokeClassObject(_cookie);<br>
<br>
H. Configuring and building the project as a COM service<br>
<br>
Step1. Open the Properties page of the project and turn to Build Events.<br>
<br>
Step2. In Post-build event command line, enter the commands:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Regasm.exe &quot;$(TargetPath)&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Installutil.exe /u &quot;$(TargetPath)&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Installutil.exe &quot;$(TargetPath)&quot; <br>
<br>
The commands register the COM-visible types (e.g. SimpleObject) in the <br>
registry, and install CSCOMService into SCM as a Windows Service. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to write a DCOM server in C# <br>
<a target="_blank" href="http://blogs.msdn.com/adioltean/archive/2004/06/18/159479.aspx">http://blogs.msdn.com/adioltean/archive/2004/06/18/159479.aspx</a><br>
<br>
Building COM Servers in .NET <br>
<a target="_blank" href="http://www.codeproject.com/KB/COM/BuildCOMServersInDotNet.aspx">http://www.codeproject.com/KB/COM/BuildCOMServersInDotNet.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
