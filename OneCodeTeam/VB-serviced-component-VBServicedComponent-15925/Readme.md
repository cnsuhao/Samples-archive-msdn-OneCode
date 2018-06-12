# VB serviced component (VBServicedComponent)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* COM
* Windows SDK
## Topics
* Serviced Component
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:06:26
## Description

<h1>LIBRARY APPLICATION (VBServicedComponent)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">VBServicedComponent demonstrates a serviced component written in VB.NET. A serviced component is a class that is authored in a CLS-compliant language and that derives directly or indirectly from the System.EnterpriseServices.<span style="">
</span>ServicedComponent class. Classes configured in this way can be hosted in a COM&#43; application and can use COM&#43; services by way of the EnterpriseServices namespace.
</p>
<p class="MsoNormal">VBServicedComponent exposes the following component: </p>
<p class="MsoNormal">1. SimpleObject </p>
<p class="MsoNormal">Program ID: VBServicedComponent.SimpleObject </p>
<p class="MsoNormal">CLSID_SimpleObject: 53B70923-7796-4c6e-8E19-03DA58D51AB0 </p>
<p class="MsoNormal">IID_ISimpleObject: 3CBE3348-E59D-4ce6-8B46-AE0119E4B871 </p>
<p class="MsoNormal">DIID_ISimpleObjectEvents: C265CEA3-7A1C-479c-BFFC-05EC03F7D24B (EventID)
</p>
<p class="MsoNormal">LIBID_CSServicedComponent: 6B8E2f67-6E10-43A6-B8EE-7561E8E71A9E
</p>
<p class="MsoNormal">Properties: </p>
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
<p class="MsoNormal">Methods: </p>
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
Sub GetProcessThreadID(ByRef processId As UInteger, ByRef threadId As UInteger)
' Transactional operation
void DoTransaction();

</pre>
<pre id="codePreview" class="vb">
' HelloWorld returns a string &quot;HelloWorld&quot;
Function HelloWorld() As String
' GetProcessThreadID outputs the running process ID and thread ID
Sub GetProcessThreadID(ByRef processId As UInteger, ByRef threadId As UInteger)
' Transactional operation
void DoTransaction();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Events: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' FloatPropertyChanging is fired before new value is set to the FloatProperty
' property. The Cancel parameter allows the client to cancel the change of
' FloatProperty.
Event FloatPropertyChanging(ByVal NewValue As Single, ByRef Cancel As Boolean).  

</pre>
<pre id="codePreview" class="vb">
' FloatPropertyChanging is fired before new value is set to the FloatProperty
' property. The Cancel parameter allows the client to cancel the change of
' FloatProperty.
Event FloatPropertyChanging(ByVal NewValue As Single, ByRef Cancel As Boolean).  

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Using the Code</h2>
<h3><span style="">A. Creating the project </span></h3>
<p class="MsoNormal">Step1. Create a Visual Basic / Class Library project named VBServicedComponent in Visual Studio 2010.
</p>
<p class="MsoNormal">Step2. Add the reference to System.EnterpriseServices. </p>
<p class="MsoNormal">Step3. In the properties page of the project, sign the assembly with a strong name.
</p>
<p class="MsoNormal">Step4. Open the property of the project. Click the Assembly Information<span style="">&nbsp;
</span>button in the page, Application, and select the &quot;Make Assembly COM-Visible&quot; box. This corresponds to the assembly attribute ComVisible in AssemblyInfo.<span style="">vb</span>:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: ComVisible(True)&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: ComVisible(True)&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Add the following command to the post-build event of the project.
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>RegSvcs.exe &quot;$(TargetPath)&quot; </p>
<p class="MsoNormal">This makes sure that the component is added to a COM&#43; application after the build in Visual Studio.
</p>
<h3><span style="">B. Adding a serviced component </span></h3>
<p class="MsoNormal">Step1. Add a public class SimpleObject that inherits from<span style="">
</span>System.EnterpriseServices.ServicedComponent. </p>
<p class="MsoNormal">Step2. Inside the SimpleObject class, define Class ID, Interface ID, and Event ID:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ClassId As String = &quot;53B70923-7796-4c6e-8E19-03DA58D51AB0&quot;
InterfaceId As String = &quot;3CBE3348-E59D-4ce6-8B46-AE0119E4B871&quot;
EventsId As String = &quot;C265CEA3-7A1C-479c-BFFC-05EC03F7D24B&quot;

</pre>
<pre id="codePreview" class="vb">
ClassId As String = &quot;53B70923-7796-4c6e-8E19-03DA58D51AB0&quot;
InterfaceId As String = &quot;3CBE3348-E59D-4ce6-8B46-AE0119E4B871&quot;
EventsId As String = &quot;C265CEA3-7A1C-479c-BFFC-05EC03F7D24B&quot;

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
    SimpleObject.EventsId)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
<pre id="codePreview" class="vb">
&lt;ComClass(SimpleObject.ClassId, SimpleObject.InterfaceId, _
    SimpleObject.EventsId)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Adding public properties, methods and events to the component.
</p>
<h3><span style="">C. Configuring the serviced component </span></h3>
<p class="MsoNormal">Step1. Specify the name of the COM&#43; application in AssemblyInfo.vb:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: ApplicationName(&quot;All-In-One Code Framework&quot;)&gt; 

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: ApplicationName(&quot;All-In-One Code Framework&quot;)&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The System.EnterpriseServices.ApplicationName attribute specifies the name of the COM&#43; application you would like your components to be part of. If the assembly attribute is not provided, the assembly name is used as the name of the COM&#43;
 application by default. </p>
<p class="MsoNormal">Step2. Optionally specify the application ID in AssemblyInfo.vb:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: ApplicationID(&quot;11F3EE74-29A6-4773-82C6-274A67961FB4&quot;)&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: ApplicationID(&quot;11F3EE74-29A6-4773-82C6-274A67961FB4&quot;)&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">When registration occurs, the components in the assembly are installed in an application with the given ID.
</p>
<p class="MsoNormal">Step3. Specify the application activation type in AssemblyInfo.vb:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: ApplicationActivation(ActivationOption.Server)&gt; 

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: ApplicationActivation(ActivationOption.Server)&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The ActivationOption attribute indicates whether the component will be activated within the caller's process. You can set Activation.Option to Library or to Server. If you do not provide the ApplicationActivation attribute, then .NET
 uses a library activation type by default. </p>
<p class="MsoNormal">Step4. Add the Description attribute. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: Description(&quot;COM&#43; examples of All-In-One Code Framework&quot;)&gt; 

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: Description(&quot;COM&#43; examples of All-In-One Code Framework&quot;)&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The Description attribute allows you to add text to the description field on the General Properties tab of an application, component, interface, or method in DCOMCNFG.
</p>
<p class="MsoNormal">Step5. Configure the COM&#43; security </p>
<p class="MsoNormal">The COM&#43; security corresponds to the Roles folder and the Security tab of the application', components', interfaces', methods' properties in DCOMCNFG. It allows us to configure their access security. Improper configuration may cause unexpected
 &quot;permission denied&quot; error on the client side, so you need to be careful to set the security.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: ApplicationAccessControl(True, _
    AccessChecksLevel:=AccessChecksLevelOption.ApplicationComponent, _
    Authentication:=AuthenticationOption.Packet, _
    ImpersonationLevel:=ImpersonationLevelOption.Identify)&gt; 

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: ApplicationAccessControl(True, _
    AccessChecksLevel:=AccessChecksLevelOption.ApplicationComponent, _
    Authentication:=AuthenticationOption.Packet, _
    ImpersonationLevel:=ImpersonationLevelOption.Identify)&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The ApplicationAccessControl attribute programmatically configures the Security tab of the Appliction's properties dialog in DCOMCNFG. When ApplicationAccessControl(False), the &quot;Enforce access checks for this application&quot; option
 is off, and the components inside the application allow full accesses from clients. ApplicationAccessControl(True) enables access checks. You should select the appropriate security level. (See
<a href="http://msdn.microsoft.com/en-us/library/ms684382.aspx">http://msdn.microsoft.com/en-us/library/ms684382.aspx</a>) Also, you must be sure to define roles and add them to the application. If access checks are enabled but no roles have been added, all
 calls to the application will fail. (See </p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms678849.aspx">http://msdn.microsoft.com/en-us/library/ms678849.aspx</a> and
<a href="http://support.microsoft.com/kb/810153">http://support.microsoft.com/kb/810153</a>). Roles can be defined using attributes too:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Assembly: SecurityRole(&quot;Tester&quot;, SetEveryoneAccess:=True)&gt; 

</pre>
<pre id="codePreview" class="vb">
&lt;Assembly: SecurityRole(&quot;Tester&quot;, SetEveryoneAccess:=True)&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Optionally specify the COM&#43; object pooling for serviced components:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ObjectPooling(MinPoolSize:=2, MaxPoolSize:=10, CreationTimeout:=20)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
<pre id="codePreview" class="vb">
&lt;ObjectPooling(MinPoolSize:=2, MaxPoolSize:=10, CreationTimeout:=20)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The ObjectPooling attribute is used to configure the component's object pooling. It can enable or disables object pooling and set the min. or max. pool size and object creation timeout.
</p>
<p class="MsoNormal">Step7. Specify the COM&#43; transactions for the serviced components:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Transaction(TransactionOption.Required)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
<pre id="codePreview" class="vb">
&lt;Transaction(TransactionOption.Required)&gt; _
Public Class SimpleObject
    Inherits ServicedComponent

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">You can configure the serviced component to use one of the five available COM&#43; transaction support options by using the Transaction attribute:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Disabled,        ' Ignores any transaction in the current context
NotSupported,    ' Creates in a context without governing transaction
Supported,        ' Shares a transaction if one exists
Required,        ' Shares a transaction if one exists, and creates a new 
                ' transaction if necessary
RequiresNew        ' Creates the component with a new transaction, 
                ' regardless of the state of the current context.

</pre>
<pre id="codePreview" class="vb">
Disabled,        ' Ignores any transaction in the current context
NotSupported,    ' Creates in a context without governing transaction
Supported,        ' Shares a transaction if one exists
Required,        ' Shares a transaction if one exists, and creates a new 
                ' transaction if necessary
RequiresNew        ' Creates the component with a new transaction, 
                ' regardless of the state of the current context.

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The five options correspond to the Transactions tab of the components' properties sheet in DCOMCNFG. When performing transactional operations, you can use ContextUtil.SetComplete to commit the changes, or call ContextUtil.SetAbort to
 rollback on exceptions. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
     Try
        ' Operate on the resource managers like DBMS
        ' ...


        ContextUtil.SetComplete()   ' Commit
    Catch ex As Exception
        ContextUtil.SetAbort()      ' Rollback
        Throw ex
    End Try

</pre>
<pre id="codePreview" class="vb">
     Try
        ' Operate on the resource managers like DBMS
        ' ...


        ContextUtil.SetComplete()   ' Commit
    Catch ex As Exception
        ContextUtil.SetAbort()      ' Rollback
        Throw ex
    End Try

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The KB article http://support.microsoft.com/kb/816141 is an example of COM&#43; transaction. Please note that transactional operations must happen to resource
</p>
<p class="MsoNormal"><span class="GramE">managers</span>. A resource (such as a database management system) that can participate in a COM&#43; transaction is called a resource manager. A resource manager knows how to conduct itself properly in the scope of
 a COM&#43; transaction. </p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/3x7357ez(VS.80).aspx">Writing Serviced Components</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/306296">HOW TO: Create a Serviced .NET Component in Visual C# .NET</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://oreilly.com/catalog/comdotnetsvs/chapter/ch10.html">Chapter 10 .NET Serviced Components of COM and .NET Component Services</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/816141">How to use COM&#43; transactions in a Visual C# component</a>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/magazine/cc301491.aspx">COM&#43; Integration: How .NET Enterprise Services Can Help You Build Distributed Applications</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
