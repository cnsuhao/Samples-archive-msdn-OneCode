# Embed ActiveX control in HTML (HTMLEmbedActiveX)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* COM
## Topics
* ActiveX
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:18:44
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVEX CONTROL DLL : CSActiveX Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates an ActiveX control written in C#. ActiveX controls<br>
(formerly known as OLE controls) are small program building blocks that can <br>
work in a variety of different containers, ranging from software development <br>
tools to end-user productivity tools. For example, it can be used to create <br>
distributed applications that work over the Internet through web browsers. <br>
ActiveX controls can be written in MFC, ATL, C&#43;&#43;, C#, Borland Delphi and <br>
Visual Basic. In this sample, we focus on writing an ActiveX control using <br>
C#. We will go through the basic steps of adding UI, properties, methods, and <br>
events to the control. Please note that ActiveX controls or COM components <br>
written in .NET languages cannot be referenced by .NET applications in the <br>
form of interop assemblies. If you &quot;add reference&quot; to such a TLB, or drag &
<br>
drop such an ActiveX control to your .NET application, you will get an error <br>
&quot;The ActiveX type library 'XXXXX.tlb' was exported from a .NET assembly and <br>
cannot be added as a reference.&quot;. The correct approach is to add a reference
<br>
to the .NET assembly directly.<br>
<br>
CSActiveX exposes the following items:<br>
<br>
1. A C# ActiveX control.<br>
<br>
&nbsp;Program ID: CSActiveX.CSActiveXCtrl<br>
&nbsp;CLSID_CSActiveXCtrl: 80B59B58-98EA-303C-BE83-D26E5D8D6794<br>
&nbsp;DIID_AxCSActiveXCtrl: D4B8539E-3839-3913-8B1A-C551A9930864<br>
&nbsp;DIID_AxCSActiveXCtrlEvents: 901EE2A0-C47C-43EC-B433-985C020051D5<br>
&nbsp;LIBID_CSActiveX: 361188E4-99EB-4E43-A72F-C89451E756DD<br>
<br>
&nbsp;UI:<br>
&nbsp; &nbsp;// The main UI of the control<br>
&nbsp; &nbsp;CSActiveXCtrl<br>
<br>
&nbsp;Properties:<br>
&nbsp; &nbsp;// Typical control properties<br>
&nbsp; &nbsp;bool Visible<br>
&nbsp; &nbsp;bool Enabled<br>
&nbsp; &nbsp;int ForeColor<br>
&nbsp; &nbsp;int BackColor<br>
&nbsp; &nbsp;// Custom properties<br>
&nbsp; &nbsp;float FloatProperty<br>
<br>
&nbsp;Methods:<br>
&nbsp; &nbsp;// Typical control methods<br>
&nbsp; &nbsp;void Refresh()<br>
&nbsp; &nbsp;// Custom methods<br>
&nbsp; &nbsp;string HelloWorld()<br>
<br>
&nbsp;Events:<br>
&nbsp; &nbsp;// Typical control events<br>
&nbsp; &nbsp;void Click();<br>
&nbsp; &nbsp;// Custom events<br>
&nbsp; &nbsp;// FloatPropertyChanging is fired before new value is set to the <br>
&nbsp; &nbsp;// FloatProperty property. The Cancel parameter allows the client to
<br>
&nbsp; &nbsp;// cancel the change of FloatProperty.<br>
&nbsp; &nbsp;void FloatPropertyChanging(float NewValue, ref bool Cancel);<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSActiveX - VBActiveX - MFCActiveX<br>
These samples expose the same UI and the same set of properties, methods, and<br>
events, but they are implemented in different languages.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C# / Class Library project named CSActiveX in Visual <br>
Studio 2008. Delete the default Class1.cs file.<br>
<br>
Step2. In order to make the .NET assembly COM-visible, first, open the <br>
property of the project. Click the Assembly Information button in the <br>
Application page, and select the &quot;Make Assembly COM-Visible&quot; box. This <br>
corresponds to the assembly attribute ComVisible in AssemblyInfo.cs:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[assembly: ComVisible(true)]<br>
<br>
The GUID value in the dialog is the libid of the component:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[assembly: Guid(&quot;361188e4-99eb-4e43-a72f-c89451e756dd&quot;)]<br>
<br>
Second, in the Build page of the project's property, select the option <br>
&quot;Register for COM interop&quot;. This option specifies whether your managed <br>
application will expose a COM object (a COM-callable wrapper) that allows a <br>
COM object to interact with your managed application.<br>
<br>
B. Adding the ActiveXCtrlHelper class<br>
<br>
ActiveXCtrlHelper provides the helper functions to register/unregister an <br>
ActiveX control, and helps to handle the focus and tabbing across the <br>
container and the .NET controls.<br>
<br>
C. Adding a user control and expose it as an ActiveX control<br>
<br>
Step1. Right-click the project and choose Add / User Control in the context <br>
menu. Name the control as CSActiveXCtrl. Next, double-click the control to <br>
open its design view and design the UI.<br>
<br>
Step2. In the code view of CSActiveXCtrl.cs, add a public interface named <br>
AxCSActiveXCtrl to describe the COM interface of the coclass CSActiveXCtrl. <br>
Inside the interface, define the properties and methods to be exposed by the <br>
ActiveX control. Attach the GuidAttribute to the interface. The GUID value <br>
can be generated using Tools / Create GUID, and is used as the interface ID.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;D4B8539E-3839-3913-8B1A-C551A9930864&quot;)]<br>
<br>
The detailed steps of adding properties and methods are documented below.<br>
<br>
Step3. In CSActiveXCtrl.cs, add a public interface, AxCSActiveXCtrlEvents, to <br>
describe the events of the control. Inside the interface, define the <br>
prototype of the events and assign DISPID to each. For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[DispId(2)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;void FloatPropertyChanging(float NewValue, ref bool Cancel);<br>
<br>
The detailed steps of adding events are documented below.<br>
<br>
Please note that DISPID must be explicitly defined for each event, otherwise, <br>
the callback address cannot be found when the event is fired. <br>
<br>
Next, assign a GUID to the interface as the event ID, and define the <br>
interface type as InterfaceIsIDispatch.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;901EE2A0-C47C-43ec-B433-985C020051D5&quot;)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]<br>
<br>
Step4. Set the class CSActiveXCtrl to implement the interface AxCSActiveXCtrl <br>
and attach [ComSourceInterfaces(typeof(AxCSActiveXCtrlEvents))] to the class.<br>
ComSourceInterfacesAttribute identifies the interface exposed as COM event <br>
sources for the attributed class. Next, add the attribute <br>
[ClassInterface(ClassInterfaceType.None)] to the class, which tells the <br>
type-library generation tools that we do not require a Class Interface. This <br>
ensures that the AxCSActiveXCtrl interface is the default interface. In <br>
addition, specify the GUID of the class, aka CLSID, using the Guid attribute:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(&quot;80B59B58-98EA-303C-BE83-D26E5D8D6794&quot;)]<br>
<br>
D. ActiveX Control Registration<br>
<br>
Additional registry keys/values are required to be set for ActiveX controls <br>
when compared with ordinary COM components. The default COM registration <br>
routine does not meet the need. Inside CSActiveXCtrl, add the functions <br>
Register, Unregister and decorate them with ComRegisterFunctionAttribute, <br>
ComUnregisterFunctionAttribute. The custom routine gets called after Regasm <br>
finishes the default behaviors. The Register and Unregister functions call <br>
the helper methods in ActiveXCtrlHelper.<br>
<br>
E. Adding Properties to the ActiveX control<br>
<br>
Step1. Add the prototype of property to the COM interface AxCSActiveXCtrl. <br>
For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;float FloatProperty { get; set; }<br>
<br>
Step2. Add the implementation of the property to the coclass CSActiveXCtrl. <br>
For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private float fField = 0;<br>
&nbsp;&nbsp;&nbsp;&nbsp;public float FloatProperty<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get { return this.fField; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set { this.fField = value; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
F. Adding Methods to the ActiveX control<br>
<br>
Step1. Add the prototype of method to the COM interface AxCSActiveXCtrl. <br>
For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;string HelloWorld();<br>
<br>
Step2. Add the implementation of the method to the coclass CSActiveXCtrl. <br>
For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;public string HelloWorld()<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return &quot;HelloWorld&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
G. Adding Events to the ActiveX control<br>
<br>
Step1. Add the prototype of event to the event interface <br>
AxCSActiveXCtrlEvents, and explicitly assign a DISPID to it. For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[DispId(2)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;void FloatPropertyChanging(float NewValue, ref bool Cancel);<br>
<br>
Step2. Inside the coclass CSActiveXCtrl, add a delegate with the above <br>
prototype as the event handler. Set the delegate to be [ComVisible(false)]. <br>
For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;[ComVisible(false)]<br>
&nbsp;&nbsp;&nbsp;&nbsp;public delegate void FloatPropertyChangingEventHandler<br>
&nbsp;&nbsp;&nbsp;&nbsp;(float NewValue, ref bool Cancel);<br>
<br>
Next, add a public event:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;public event FloatPropertyChangingEventHandler FloatPropertyChanging;<br>
<br>
And raise the event in the proper places. Please check null on the event <br>
before raising it. For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (null != FloatPropertyChanging)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FloatPropertyChanging(value, ref cancel);<br>
<br>
H. Adding the ToolBox Bitmap resource<br>
<br>
The ToolBox bitmap resource is specified in the regsitry key:<br>
HKCR\CLSID\{CLSID of the control}\ToolBoxBitmap32\<br>
(see the RegisterControl method in ActiveXCtrlHelper)<br>
ToolBoxBitmap32 is used to identify the module name and the resource ID for a <br>
16 x 16 bitmap as the toolbar button face. Each specified icon must be <br>
embedded as a win32 resource in the assembly. In order to embed the bitmap <br>
CSActiveX.bmp into the assembly as a win32 resource, we need to <br>
<br>
Step1. Place the CSActiveX.bmp file in the root folder of the project.<br>
<br>
Step2. Add a .rc file (CSActiveX.rc) to the project with the content: <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;101 BITMAP CSActiveX.bmp<br>
<br>
101 is the resource ID, BITMAP is the resource type, and CSActiveX.bmp is the<br>
resource name. <br>
<br>
Step3. Open Project Properties, and turn to the Build Events page. In <br>
Pre-build event command line, enter this command:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;@echo.<br>
&nbsp;&nbsp;&nbsp;&nbsp;IF EXIST &quot;$(DevEnvDir)..\..\..\Microsoft SDKs\Windows\v6.0A\bin\rc.exe&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(&quot;$(DevEnvDir)..\..\..\Microsoft SDKs\Windows\v6.0A\bin\rc.exe&quot; /r
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&quot;$(ProjectDir)CSActiveX.rc&quot;) <br>
&nbsp;&nbsp;&nbsp;&nbsp;ELSE (IF EXIST &quot;$(DevEnvDir)..\..\SDK\v2.0\Bin\rc.exe&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(&quot;$(DevEnvDir)..\..\SDK\v2.0\Bin\rc.exe&quot;/r &quot;$(ProjectDir)CSActiveX.rc&quot;)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ELSE (IF EXIST &quot;$(DevEnvDir)..\Tools\Bin\rc.exe&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(&quot;$(DevEnvDir)..\Tools\Bin\rc.exe&quot;/r &quot;$(ProjectDir)CSActiveX.rc&quot;)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ELSE (IF EXIST &quot;$(DevEnvDir)..\..\VC\Bin\rc.exe&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(&quot;$(DevEnvDir)..\..\VC\Bin\rc.exe&quot;/r &quot;$(ProjectDir)CSActiveX.rc&quot;)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ELSE (@Echo Unable to find rc.exe, using default manifest instead))))<br>
&nbsp;&nbsp;&nbsp;&nbsp;@echo.<br>
<br>
The command searches for the Resource Compiler (rc.exe), and use the tool to <br>
compile the resource definition file and the resource files (binary files <br>
such as icon, bitmap, and cursor files) into a binary resource (.RES) file: <br>
CSActiveX.RES.<br>
<br>
Step4. Turn to the Application page of Project Properties. In the section <br>
&quot;Specify how application resources will be managed&quot;, select &quot;Resource File&quot;,
<br>
and enter the full path of CSActiveX.RES that is generated in step 3.<br>
<br>
Step5. (Optional) If you perfer a relative path to the full path of <br>
CSActiveX.RES, you need to modify the project file (CSActiveX.csproj). The <br>
&quot;Resource File&quot; value corresponds to the XML element:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Win32Resource&gt;CSActiveX.res&lt;/Win32Resource&gt;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Interop Forms Toolkit 2.0<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/vbasic/bb419144.aspx">http://msdn.microsoft.com/en-us/vbasic/bb419144.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
