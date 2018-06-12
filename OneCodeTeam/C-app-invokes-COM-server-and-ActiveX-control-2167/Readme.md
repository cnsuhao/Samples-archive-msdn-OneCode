# C# app invokes COM server and ActiveX control (CSCOMClient)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* COM
## Topics
* Interop
* COM Client
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:21:32
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSCOMClient Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This Visual C# code example demonstrates the access of COM components from <br>
the .NET Framework by use of a runtime callable wrapper (RCW) or late binding, <br>
and the host of ActiveX control in Windows Form.<br>
<br>
A. Early binding of COM<br>
<br>
Early-binding means that the compiler must have prior knowledge about COM at <br>
compile time. Early-binding is supported by use of a runtime callable wrapper <br>
(RCW). The wrapper turns the COM interfaces exposed by the COM component into <br>
.NET Framework-compatible interfaces, and thus facilitates communication <br>
between COM and .NET.<br>
<br>
The Interop Assembly that is made from a type library is a form of RCW. It <br>
defines managed interfaces that map to a COM-based type library and that a <br>
managed client can interact with. To use an interop assembly in Visual Studio, <br>
first add a reference to the corresponding COM component. Visual Studio will <br>
automatically generate a local copy of the interop assembly. Type Library <br>
Importer (Tlbimp.exe) is a standalone tool to convert the type definitions <br>
found within a COM type library into equivalent definitions in a common <br>
language runtime assembly. <br>
<br>
Without the use of the interop assembly, a developer may write a custom RCW <br>
and manually map the types exposed by the COM interface to .NET Framework-<br>
compatible types. <br>
<br>
B. Late binding of COM<br>
<br>
Late-binding means that the compiler does not have any prior knowledge about <br>
the methods and properties in the COM component and it is delayed until <br>
runtime. The advantage of late binding is that you do not have to use an RCW <br>
(or build/ship a custom Interop Assembly), and it is more version agnostic. <br>
The disadvantage is that it is more difficult to program this in Visual C# <br>
than it is in Visual Basic, and late binding still suffers the performance &nbsp;<br>
hit of having to find DISPIDs at runtime.<br>
<br>
We do late binding in Visual C# through .NET reflection. Reflection is a way <br>
to determine the type or information about the classes or interfaces. We do <br>
not need to create RCW for the COM component in late binding as we did in <br>
early binding. We use System.Type.GetTypeFromProgID to get the type object <br>
for the COM object, then use System.Activator.CreateInstance to instantiate <br>
the COM object.<br>
<br>
C. Host of ActiveX control<br>
<br>
Hosting an ActiveX control requires a RCW of the AcitveX COM object, and a <br>
class that inherits from System.Windows.Forms.AxHost to wrap the ActiveX COM <br>
object and expose it as fully featured Windows Forms controls. The stuff can <br>
be automatically done using the Windows Forms ActiveX Control Importer <br>
(Aximp.exe) or Visual Studio Windows Forms design environment.<br>
<br>
The ActiveX Control Importer generates a class that is derived from the AxHost<br>
class, and compiles it into a library file (DLL) that can be added as a <br>
reference to your application. Alternatively, you can use the /source switch <br>
with the ActiveX Control Importer and a C# file is generated for your AxHost <br>
derived class. You can then make changes to the code and recompile it into a <br>
library file. <br>
<br>
If you are using Visual Studio as your Windows Forms design environment, you <br>
can make an ActiveX control available to your application by adding the <br>
ActiveX control to your Toolbox. To accomplish this, right-click the Toolbox, <br>
select Choose Items, then browse to the ActiveX control's .OCX or .DLL file. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New">(Relation of the current sample and other samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://cfx.codeplex.com)">
http://cfx.codeplex.com)</a><br>
<br>
CSCOMClient -&gt; ATLDllCOMServer<br>
CSCOMClient is the client application of the COM server ATLDllCOMServer.<br>
<br>
CSCOMClient -&gt; MFCActiveX<br>
CSCOMClient hosts the MFCActiveX control in a Windows Form.<br>
<br>
CSCOMClient - VBCOMClient<br>
These samples demonstrate the use of COM objects and ActiveX controls in <br>
different .NET languages.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Early-binding to the ATLDllCOMServer component using an interop assembly<br>
<br>
Step1. Add a reference to the ATLDllCOMServer COM component by right-clicking <br>
the project, selecting &quot;Add Reference...&quot;, turning to the COM tab, and adding
<br>
ATLDllCOMServer Type Library. Visual Studio will automatically generate a &nbsp;<br>
local copy of the interop assembly &quot;Interop.ATLDllCOMServerLib.dll&quot;. If the
<br>
ATLDllCOMServer Type Library is not in the list, please build and setup the <br>
ATLDllCOMServer sample first.<br>
<br>
Step2. Create a thread whose thread apartement is set to STA, because we are <br>
going to demonstrate the instantiation and use of a STA COM object: <br>
ATLDllCOMServer.SimpleObject.<br>
<br>
Step3. Create an ATLDllCOMServer.SimpleObject COM object.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ATLDllCOMServerLib.SimpleObject simpleObj = <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new ATLDllCOMServerLib.SimpleObject();<br>
<br>
Step4. Register the events of the COM object,<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;simpleObj.FloatPropertyChanging &#43;= new ATLDllCOMServerLib.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ISimpleObjectEvents_FloatPropertyChangingEventHandler(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;simpleObj_FloatPropertyChanging);<br>
<br>
and define the event handler.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;static void simpleObj_FloatPropertyChanging(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;float NewValue, ref bool Cancel)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step5. Consume the properties and the methods of the COM object. For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;string strResult = simpleObj.HelloWorld();<br>
<br>
Step6. Release the COM object. It is strongly recommended against using <br>
ReleaseComObject to manually release an RCW object that represents a COM <br>
component unless you absolutely have to. We should generally let CLR release <br>
the COM object in the garbage collector. <br>
Ref: <a target="_blank" href="&lt;a target=" href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">
http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a>'&gt;<a target="_blank" href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a><br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(simpleObj);<br>
<br>
B. Late-binding to the ATLDllCOMServer component through .NET reflection <br>
<br>
Step1. Create a thread whose thread apartement is set to STA, because we are <br>
going to demonstrate the instantiation and use of a STA COM object: <br>
ATLDllCOMServer.SimpleObject.<br>
<br>
Step2. Create an ATLDllCOMServer.SimpleObject COM object. We use <br>
System.Type.GetTypeFromProgID to get the type object for the COM object, &nbsp;<br>
then use System.Activator.CreateInstance to instantiate the COM object. Note &nbsp;<br>
that the COM object is declared as Object (object simpleObj) without the &nbsp;<br>
useful type information.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Type simpleObjType = Type.GetTypeFromProgID(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;ATLDllCOMServer.SimpleObject&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;object simpleObj = Activator.CreateInstance(simpleObjType);<br>
<br>
Step3. Consume the properties and the methods of the COM object through .NET <br>
reflection. For example, <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;string strResult = simpleObjType.InvokeMember(&quot;HelloWorld&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingFlags.InvokeMethod, null, simpleObj, null) as string;<br>
<br>
Step4. Release the COM object. It is strongly recommended against using <br>
ReleaseComObject to manually release an RCW object that represents a COM <br>
component unless you absolutely have to. We should generally let CLR release <br>
the COM object in the garbage collector. <br>
Ref: <a target="_blank" href="&lt;a target=" href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">
http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a>'&gt;<a target="_blank" href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a><br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.FinalReleaseComObject(simpleObj);<br>
<br>
C. Hosting the MFCActiveX control in a Windows Form<br>
<br>
Step1. Open FrmMain in Visual Studio Windows Forms design environment. Right-<br>
click the Toolbox, select Choose Items, switch to the tab COM Components, <br>
and browse to the MFCActiveX control's .OCX file. The MFCActiveX control <br>
should appear in the Toolbox then. If MFCActiveX is not in the list, please <br>
build and setup the MFCActiveX sample first.<br>
<br>
Step2. Drag and drop the MFCActiveX control to the WinForm designer. Name the <br>
control variable as axMFCActiveX1.<br>
<br>
Step3. Access the properties and methods of the ActiveX control like this:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;float fProp = this.axMFCActiveX1.FloatProperty;<br>
<br>
Step4. To access the events of the control (e.g. FloatPropertyChanging in <br>
MFCActiveX), select the ActiveX control in WinForm designer. In the Visual <br>
Studio Properties dialog, turn to the event list of the control. Double-click<br>
the FloatPropertyChanging event in the list, which generates the event <br>
handler in code-behind:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;private void axMFCActiveX1_FloatPropertyChanging(object sender,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AxMFCActiveXLib._DMFCActiveXEvents_FloatPropertyChangingEvent e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
The NewValue and Cancel parameters are encapsulated in <br>
AxMFCActiveXLib._DMFCActiveXEvents_FloatPropertyChangingEvent e.<br>
<br>
In the event handler, pop up a message box to allow selecting <br>
OK or Cancel, then pass the user's selection back to the control through the<br>
e.cancel parameter.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
COM Interop Part 1: C# Client Tutorial<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa645736.aspx">http://msdn.microsoft.com/en-us/library/aa645736.aspx</a><br>
<br>
Understanding Classic COM Interoperability With .NET Applications By Aravind<br>
<a target="_blank" href="http://www.codeproject.com/KB/COM/cominterop.aspx">http://www.codeproject.com/KB/COM/cominterop.aspx</a><br>
<br>
Calling COM Components from .NET Clients<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms973800.aspx">http://msdn.microsoft.com/en-us/library/ms973800.aspx</a><br>
<br>
Microsoft .NET/COM Migration and Interoperability<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms978506.aspx">http://msdn.microsoft.com/en-us/library/ms978506.aspx</a><br>
<br>
Type Library Importer (Tlbimp.exe)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/tt0cf3sx.aspx">http://msdn.microsoft.com/en-us/library/tt0cf3sx.aspx</a><br>
<br>
Using early binding and late binding in Automation<br>
<a target="_blank" href="http://support.microsoft.com/kb/245115">http://support.microsoft.com/kb/245115</a><br>
<br>
MSDN: AxHost Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.axhost.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.axhost.aspx</a><br>
<br>
Windows Forms ActiveX Control Importer (Aximp.exe)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/8ccdh774.aspx">http://msdn.microsoft.com/en-us/library/8ccdh774.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
