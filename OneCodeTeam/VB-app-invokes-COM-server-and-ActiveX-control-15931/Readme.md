# VB app invokes COM server and ActiveX control (VBCOMClient)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* COM
* Windows SDK
## Topics
* Interop
* COM Client
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:10:01
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">VBCOMClient</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This Visual Basic code example demonstrates the access of COM components from the .NET Framework by use of a runtime callable wrapper (RCW) or late binding, and the host of ActiveX control in Windows Form.</p>
<p class="MsoNormal">A. Early binding of COM</p>
<p class="MsoNormal">Early-binding means that the compiler must have prior knowledge about COM at compile time. Early-binding is supported by use of a runtime callable wrapper (RCW). The wrapper turns the COM interfaces exposed by the COM component into .NET
 Framework-compatible interfaces, and thus facilitates communication between COM and .NET.<span style="">
</span>The Interop Assembly that is made from a type library is a form of RCW. It defines managed interfaces that map to a COM-based type library and that a managed client can interact with. To use an interop assembly in Visual Studio, first add a reference
 to the corresponding COM component. Visual Studio will automatically generate a local copy of the interop assembly. Type Library Importer (Tlbimp.exe) is a standalone tool to convert the type definitions found within a COM type library into equivalent definitions
 in a common language runtime assembly. Without the use of the interop assembly, a developer may write a custom RCW and manually map the types exposed by the COM interface to .NET Framework-compatible types.
</p>
<p class="MsoNormal">B. Late binding of COM</p>
<p class="MsoNormal">Late-binding means that the compiler does not have any prior knowledge about the methods and properties in the COM component and it is delayed until runtime. The advantage of late binding is that you do not have to use an RCW (or build/ship
 a custom Interop Assembly), and it is more version agnostic. The disadvantage is that it is more difficult to program this in Visual C# than it is in Visual Basic, and late binding still suffers the performance<span style="">&nbsp;
</span>hit of having to find DISPIDs at runtime.<span style=""> </span>We do late binding in Visual Basic<span style="">
</span>through .NET reflection. Reflection is a way to determine the type or information about the classes or interfaces. We do not need to create RCW for the COM component in late binding as we did in early binding. We use System.Type.GetTypeFromProgID to
 get the type object for the COM object, then use System.Activator.CreateInstance to instantiate the COM object.</p>
<p class="MsoNormal">C. Host of ActiveX control</p>
<p class="MsoNormal">Hosting an ActiveX control requires a RCW of the AcitveX COM object, and a class that inherits from System.Windows.Forms.AxHost to wrap the ActiveX COM object and expose it as fully featured Windows Forms controls. The stuff can be automatically
 done using the Windows Forms ActiveX Control Importer (Aximp.exe) or Visual Studio Windows Forms design environment.<span style="">
</span>The ActiveX Control Importer generates a class that is derived from the AxHost<span style="">
</span>class, and compiles it into a library file (DLL) that can be added as a reference to your application. Alternatively, you can use the /source switch with the ActiveX Control Importer and a
<span style="">VB</span> file is generated for your AxHost derived class. You can then make changes to the code and recompile it into a library file.
</p>
<p class="MsoNormal">If you are using Visual Studio as your Windows Forms design environment, you can make an ActiveX control available to your application by adding the ActiveX control to your Toolbox. To accomplish this, right-click the Toolbox, select
 Choose Items, then browse to the ActiveX control's .OCX or .DLL file.<span style="">&nbsp;
</span></p>
<h2><span style="">Running the code </span></h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53691/1/image.png" alt="" width="720" height="469" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53692/1/image.png" alt="" width="720" height="471" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Input ��OneCode�� into the first Textbox control and click ��MSGBOX�� button.<span style="">&nbsp;
</span>An alert window will come out titled with ��HelloWorld��. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53693/1/image.png" alt="" width="574" height="289" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Input ��23.34�� into the second Textbox control and click ��Set�� button. An alert window will come out titled with ��MFCActiveX!FloatPropertyChanging��. You can click ��OK�� to set the value to FloatProperty. Alternatively,
 you can click ��Cancel�� to cancel the setting. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53694/1/image.png" alt="" width="720" height="273" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Click ��Get�� button to get the latest value of FloatPropery. An alert window will come out titled with ��MFCActiveX!FloatProperty��.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53695/1/image.png" alt="" width="614" height="272" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<h3><span style="">A. Early-binding to the ATLDllCOMServer component using an interop assembly
</span></h3>
<p class="MsoNormal">Step1. Add a reference to the ATLDllCOMServer COM component by right-clicking the project, selecting &quot;Add Reference...&quot;, turning to the COM tab, and adding ATLDllCOMServer Type Library. Visual Studio will automatically generate
 a<span style="">&nbsp; </span>local copy of the interop assembly &quot;Interop.ATLDllCOMServerLib.dll&quot;. If the ATLDllCOMServer Type Library is not in the list, please build and setup the ATLDllCOMServer sample first.</p>
<p class="MsoNormal">Step2. Create a thread whose thread apartement is set to STA, because we are going to demonstrate the instantiation and use of a STA COM object: ATLDllCOMServer.SimpleObject.</p>
<p class="MsoNormal">Step3. Create an ATLDllCOMServer.SimpleObject COM object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim WithEvents simpleObj As New ATLDllCOMServerLib.SimpleObject

</pre>
<pre id="codePreview" class="vb">
Dim WithEvents simpleObj As New ATLDllCOMServerLib.SimpleObject

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Register the events of the COM object,</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Sub simpleObj_FloatPropertyChanging(ByVal NewValue As Single, _
                                    ByRef Cancel As Boolean) _
                                    Handles simpleObj.FloatPropertyChanging
End Sub

</pre>
<pre id="codePreview" class="vb">
Sub simpleObj_FloatPropertyChanging(ByVal NewValue As Single, _
                                    ByRef Cancel As Boolean) _
                                    Handles simpleObj.FloatPropertyChanging
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">and define the event handler.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim strResult As String = simpleObj.HelloWorld()

</pre>
<pre id="codePreview" class="vb">
Dim strResult As String = simpleObj.HelloWorld()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Consume the properties and the methods of the COM object. For example,
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string strResult = simpleObj.HelloWorld();

</pre>
<pre id="codePreview" class="csharp">
string strResult = simpleObj.HelloWorld();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Release the COM object. It is strongly recommended against using ReleaseComObject to manually release an RCW object that represents a COM component unless you absolutely have to. We should generally let CLR release the COM object
 in the garbage collector. Ref: <a href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">
http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Marshal.FinalReleaseComObject(simpleObj)

</pre>
<pre id="codePreview" class="vb">
Marshal.FinalReleaseComObject(simpleObj)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="">B. Late-binding to the ATLDllCOMServer component through .NET reflection
</span></h3>
<p class="MsoNormal">Step1. Create a thread whose thread apartement is set to STA, because we are going to demonstrate the instantiation and use of a STA COM object: ATLDllCOMServer.SimpleObject.</p>
<p class="MsoNormal">Step2. Create an ATLDllCOMServer.SimpleObject COM object. We use System.Type.GetTypeFromProgID to get the type object for the COM object,<span style="">&nbsp;
</span>then use System.Activator.CreateInstance to instantiate the COM object. Note<span style="">&nbsp;
</span>that the COM object is declared as Object (object simpleObj) without the<span style="">&nbsp;
</span>useful type information.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim simpleObj As Object = CreateObject( _
&quot;ATLDllCOMServer.SimpleObject&quot;)

</pre>
<pre id="codePreview" class="vb">
Dim simpleObj As Object = CreateObject( _
&quot;ATLDllCOMServer.SimpleObject&quot;)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Consume the properties and the methods of the COM object through .NET reflection. For example,
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim strResult As String = simpleObj.HelloWorld()

</pre>
<pre id="codePreview" class="vb">
Dim strResult As String = simpleObj.HelloWorld()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Release the COM object. It is strongly recommended against using ReleaseComObject to manually release an RCW object that represents a COM component unless you absolutely have to. We should generally let CLR release the COM object
 in the garbage collector. </p>
<p class="MsoNormal">Ref: <a href="http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx">
http://blogs.msdn.com/yvesdolc/archive/2004/04/17/115379.aspx</a><span style=""> </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Marshal.FinalReleaseComObject(simpleObj)

</pre>
<pre id="codePreview" class="vb">
Marshal.FinalReleaseComObject(simpleObj)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">C. Hosting the MFCActiveX control in a Windows Form</p>
<p class="MsoNormal">Step1. Open FrmMain in Visual Studio Windows Forms design environment. Right-click the Toolbox, select Choose Items, switch to the tab COM Components, and browse to the MFCActiveX control's .OCX file. The MFCActiveX control should appear
 in the Toolbox then. If MFCActiveX is not in the list, please build and setup the MFCActiveX sample first.</p>
<p class="MsoNormal">Step2. Drag and drop the MFCActiveX control to the WinForm designer. Name the control variable as axMFCActiveX1.</p>
<p class="MsoNormal">Step3. Access the properties and methods of the ActiveX control like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim fProp As Single = Me.AxMFCActiveX1.FloatProperty;

</pre>
<pre id="codePreview" class="vb">
Dim fProp As Single = Me.AxMFCActiveX1.FloatProperty;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. To access the events of the control (e.g. FloatPropertyChanging in MFCActiveX), select the ActiveX control in WinForm designer. In the Visual Studio Properties dialog, turn to the event list of the control. Double-click<span style="">
</span>the FloatPropertyChanging event in the list, which generates the event handler in code-behind:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub AxMFCActiveX1_FloatPropertyChanging( _
ByVal sender As System.Object, _
ByVal e As AxMFCActiveXLib._DMFCActiveXEvents_FloatPropertyChangingEvent) _
Handles AxMFCActiveX1.FloatPropertyChanging
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub AxMFCActiveX1_FloatPropertyChanging( _
ByVal sender As System.Object, _
ByVal e As AxMFCActiveXLib._DMFCActiveXEvents_FloatPropertyChangingEvent) _
Handles AxMFCActiveX1.FloatPropertyChanging
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The NewValue and Cancel parameters are encapsulated in AxMFCActiveXLib._DMFCActiveXEvents_FloatPropertyChangingEvent e.<span style="">
</span>In the event handler, pop up a message box to allow selecting OK or Cancel, then pass the user's selection back to the control through the<span style="">
</span>e.cancel parameter.</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/aa645736.aspx">COM Interop Part 1: C# Client Tutorial</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.codeproject.com/KB/COM/cominterop.aspx">Understanding Classic COM Interoperability With .NET Applications By Aravind</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms973800.aspx">Calling COM Components from .NET Clients</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms978506.aspx">Microsoft .NET/COM Migration and Interoperability</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/tt0cf3sx.aspx">Type Library Importer (Tlbimp.exe)</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/245115">Using early binding and late binding in Automation</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.axhost.aspx">MSDN: AxHost Class</a></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-size:12.0pt; line-height:115%; font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/8ccdh774.aspx">Windows Forms ActiveX Control Importer (Aximp.exe)</a><span style="font-size:12.0pt; line-height:115%; font-family:����">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
