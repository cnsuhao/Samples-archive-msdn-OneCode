# Out-of-process VB COM server (VBExeCOMServer)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* COM
* Windows SDK
## Topics
* Interop
* out-of-process COM Server
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:08:58
## Description

<h1>WINDOWS APPLICATION (VBExeCOMServer)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">VBExeCOMServer demonstrates an out-of-process COM server in the form of local server (EXE), which is implemented entirely in Visual Basic.NET
</p>
<p class="MsoNormal">VBExeCOMServer exposes the following item: </p>
<p class="MsoNormal">1. SimpleObject </p>
<p class="MsoNormal"><span style="">&nbsp; </span>Program ID: VBExeCOMServer.SimpleObject
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>CLSID_SimpleObject: 3CCB29D4-9466-4f3c-BCB2-F5F0A62C2C3C
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>IID__SimpleObject: 5EECE765-6416-467c-8D5E-C227F69E7EB7
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>DIID___SimpleObjectEvents: 10C862E3-37E6-4e36-96FE-3106477235F1
</p>
<p class="MsoNormal"><span style="">&nbsp; </span>Properties: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' With both get and set accessor methods
FloatProperty As Single

</pre>
<pre id="codePreview" class="vb">
' With both get and set accessor methods
FloatProperty As Single

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp; </span>Methods: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' HelloWorld returns a string &quot;HelloWorld&quot;
Function HelloWorld() As String
' GetProcessThreadID outputs the running process ID and thread ID
Sub GetProcessThreadID(ByRef processId As UInteger, 
                       ByRef threadId As UInteger)

</pre>
<pre id="codePreview" class="vb">
' HelloWorld returns a string &quot;HelloWorld&quot;
Function HelloWorld() As String
' GetProcessThreadID outputs the running process ID and thread ID
Sub GetProcessThreadID(ByRef processId As UInteger, 
                       ByRef threadId As UInteger)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp; </span>Events: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' FloatPropertyChanging is fired before new value is set to the 
' FloatProperty property. The Cancel parameter allows the client to 
' cancel the change of FloatProperty.
Event FloatPropertyChanging(ByVal NewValue As Single, 
                            ByRef Cancel As Boolean)

</pre>
<pre id="codePreview" class="vb">
' FloatPropertyChanging is fired before new value is set to the 
' FloatProperty property. The Cancel parameter allows the client to 
' cancel the change of FloatProperty.
Event FloatPropertyChanging(ByVal NewValue As Single, 
                            ByRef Cancel As Boolean)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Using the Code</h2>
<h3><span style="">A. Creating the project </span></h3>
<p class="MsoNormal">Step1. Create a Visual Basic / Windows / Console Application project named
<span class="SpellE">VBExeCOMServer</span> in Visual Studio 2010.<span style="">
</span></p>
<p class="MsoNormal">Step2. Open the project's Properties page, and change the output type to &quot;Windows Forms Application&quot; in the Application tab. This avoids the console window when the executable file is started.
</p>
<h3><span style="">B. Adding the <span class="SpellE">COMHelper</span> class </span>
</h3>
<p class="MsoNormal">COMHelper provides the helper functions to register/unregister COM servers and encapsulates the native COM APIs to be used in .NET.
</p>
<h3><span style="">C. Adding the <span class="SpellE">ExeCOMServer</span> class
</span></h3>
<p class="MsoNormal">ExeCOMServer encapsulates the skeleton of an out-of-process COM server in VB.NET. The class implements the singleton design pattern and it's thread-safe. To start the server, call
<span class="GramE">VBExeCOMServer.Instance.Run(</span>). If the server is running, the function returns directly. Inside the Run method, it registers the class factories for the COM classes to be exposed from the COM server, and starts the message loop to
 wait for the drop of lock count to zero. When lock count equals zero, it revokes the registrations and quits the server.<span style="">
</span>The lock count of the server is incremented when a COM object is created, and it's decremented when the object is released (GC-ed). In order that the COM objects can be GC-<span class="SpellE">ed</span> in time, ExeCOMServer triggers GC every 5 seconds
 by running a Timer after the server is started. </p>
<h3><span style="">D. Adding the component SimpleObject </span></h3>
<p class="MsoNormal">Step1. Add a public class SimpleObject. </p>
<p class="MsoNormal">Step2. Inside the SimpleObject class, define Class ID, Interface ID, and Event ID:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ClassId As String = &quot;805303FE-B5A6-308D-9E4F-BF500978AEEB&quot;
InterfaceId As String = &quot;90E0BCEA-7AFA-362A-A75E-6D07C1C6FC4B&quot;
EventsId As String = &quot;72D3EFB2-0D88-4ba7-A26B-8FFDB92FEBED&quot;

</pre>
<pre id="codePreview" class="vb">
ClassId As String = &quot;805303FE-B5A6-308D-9E4F-BF500978AEEB&quot;
InterfaceId As String = &quot;90E0BCEA-7AFA-362A-A75E-6D07C1C6FC4B&quot;
EventsId As String = &quot;72D3EFB2-0D88-4ba7-A26B-8FFDB92FEBED&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Attach ComClassAttribute to the class SimpleObject, and specify its _ClassID, _InterfaceID, and _EventID to be the above const values:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ComClass(SimpleObject.ClassId, SimpleObject.InterfaceId, _
    SimpleObject.EventsId), ComVisible(True)&gt; _
Public Class SimpleObject

</pre>
<pre id="codePreview" class="vb">
&lt;ComClass(SimpleObject.ClassId, SimpleObject.InterfaceId, _
    SimpleObject.EventsId), ComVisible(True)&gt; _
Public Class SimpleObject

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Declare the class ReferenceCountedObject. The class is responsible for incrementing the lock count of the COM server in the constructor, and decrementing the lock count in the Finalize. Inherit SimpleObject from ReferenceCountedObject.
</p>
<p class="MsoNormal">Step5. Add one property (FloatProperty), two methods (HelloWorld, GetProcessThreadID) and one event (FloatPropertyChanging) to the component.
</p>
<h3><span style="">E. Registering SimpleObject in the registry </span></h3>
<p class="MsoNormal">Additional registry keys and values are required for the COM server. The default COM registration routine in Regasm.exe only works for InprocServer in the form of DLL. In order to register the LocalServer, we need to customize the registration
 routine to change InprocServer32 to LocalServer appropriately. </p>
<p class="MsoNormal">Step1. Inside SimpleObject, add the functions Register and Unregister, and decorate them with ComRegisterFunctionAttribute and ComUnregisterFunctionAttribute. The custom routine gets called after Regasm finishes the default behaviors.
 The Register and Unregister functions call the helper methods in COMHelper. </p>
<h3><span style="">F. Registering ClassFactory of SimpleObject </span></h3>
<p class="MsoNormal">Step1. Create a ClassFactory class that realizes the IClassFactory interface for SimpleObject.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Class factory for the class SimpleObject.
''' &lt;/summary&gt;
Friend Class SimpleObjectClassFactory
    Implements IClassFactory


    Public Function CreateInstance(ByVal pUnkOuter As IntPtr, ByRef riid As Guid, _
                                   &lt;Out()&gt; ByRef ppvObject As IntPtr) As Integer _
                                   Implements IClassFactory.CreateInstance
        ppvObject = IntPtr.Zero


        If (pUnkOuter &lt;&gt; IntPtr.Zero) Then
            ' The pUnkOuter parameter was non-NULL and the object does 
            ' not support aggregation.
            Marshal.ThrowExceptionForHR(COMNative.CLASS_E_NOAGGREGATION)
        End If


        If ((riid = New Guid(SimpleObject.ClassId)) OrElse _
            (riid = New Guid(COMNative.GuidIUnknown))) Then
            ' Create the instance of the .NET object
            ppvObject = Marshal.GetComInterfaceForObject( _
            New SimpleObject, GetType(SimpleObject).GetInterface(&quot;_SimpleObject&quot;))
        Else
            ' The object that ppvObject points to does not support the 
            ' interface identified by riid.
            Marshal.ThrowExceptionForHR(COMNative.E_NOINTERFACE)
        End If


        Return 0  ' S_OK
    End Function




    Public Function LockServer(ByVal fLock As Boolean) As Integer _
    Implements IClassFactory.LockServer
        Return 0  ' S_OK
    End Function


End Class

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Class factory for the class SimpleObject.
''' &lt;/summary&gt;
Friend Class SimpleObjectClassFactory
    Implements IClassFactory


    Public Function CreateInstance(ByVal pUnkOuter As IntPtr, ByRef riid As Guid, _
                                   &lt;Out()&gt; ByRef ppvObject As IntPtr) As Integer _
                                   Implements IClassFactory.CreateInstance
        ppvObject = IntPtr.Zero


        If (pUnkOuter &lt;&gt; IntPtr.Zero) Then
            ' The pUnkOuter parameter was non-NULL and the object does 
            ' not support aggregation.
            Marshal.ThrowExceptionForHR(COMNative.CLASS_E_NOAGGREGATION)
        End If


        If ((riid = New Guid(SimpleObject.ClassId)) OrElse _
            (riid = New Guid(COMNative.GuidIUnknown))) Then
            ' Create the instance of the .NET object
            ppvObject = Marshal.GetComInterfaceForObject( _
            New SimpleObject, GetType(SimpleObject).GetInterface(&quot;_SimpleObject&quot;))
        Else
            ' The object that ppvObject points to does not support the 
            ' interface identified by riid.
            Marshal.ThrowExceptionForHR(COMNative.E_NOINTERFACE)
        End If


        Return 0  ' S_OK
    End Function




    Public Function LockServer(ByVal fLock As Boolean) As Integer _
    Implements IClassFactory.LockServer
        Return 0  ' S_OK
    End Function


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step2. Register the class factory of SimpleObject using the standard<span style="">&nbsp;
</span>CoRegisterClassObject API when the server starts (In the PreMessageLoop method of ExeCOMServer). Please note that PInvoking CoRegisterClassObject to register COM objects is a technique which is not supported.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
// Register the SimpleObject class object on start
Dim hResult As Integer = COMNative.CoRegisterClassObject( _
clsidSimpleObj, New SimpleObjectClassFactory, CLSCTX.LOCAL_SERVER, _
REGCLS.SUSPENDED Or REGCLS.MULTIPLEUSE, Me._cookieSimpleObj)

</pre>
<pre id="codePreview" class="vb">
// Register the SimpleObject class object on start
Dim hResult As Integer = COMNative.CoRegisterClassObject( _
clsidSimpleObj, New SimpleObjectClassFactory, CLSCTX.LOCAL_SERVER, _
REGCLS.SUSPENDED Or REGCLS.MULTIPLEUSE, Me._cookieSimpleObj)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Revoke the registration of SimpleObject using the CoRevokeClassObject API when the server stops (In the PostMessageLopp method of ExeCOMServer).
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
COMNative.CoRevokeClassObject(Me._cookieSimpleObj)

</pre>
<pre id="codePreview" class="vb">
COMNative.CoRevokeClassObject(Me._cookieSimpleObj)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="">G. Configuring and building the project as a COM local server </span>
</h3>
<p class="MsoNormal">Step1. Open the Properties page of the project and turn to Build Events.
</p>
<p class="MsoNormal">Step2. In Post-build event command line, enter the commands:
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Regasm.exe &quot;$(TargetPath)&quot; </p>
<p class="MsoNormal">The commands register the COM-visible types (e.g. SimpleObject) in the registry.
</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraph" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.codeproject.com/KB/COM/BuildCOMServersInDotNet.aspx">Building COM Servers in .NET</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
