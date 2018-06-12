# C# serviced component (CSServicedComponent)
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
* 2012-03-04 08:01:09
## Description

<h1>LIBRARY APPLICATION (CSServicedComponent)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">CSServicedComponent demonstrates a serviced component written in Visua C#. A serviced component is a class that is authored in a CLS-compliant language and that derives directly or indirectly from the System.EnterpriseServices.ServicedComponent
 class. Classes configured in this way can be hosted in a<span style=""> </span>COM&#43; application and can use COM&#43; services by way of the EnterpriseServices namespace.
</p>
<p class="MsoNormal">CSServicedComponent exposes the following component: </p>
<p class="MsoNormal">1. SimpleObject </p>
<p class="MsoNormal">Program ID: CSServicedComponent.SimpleObject </p>
<p class="MsoNormal">CLSID_SimpleObject: 14EAD156-F55E-4d9b-A3C5-658D4BB56D30 </p>
<p class="MsoNormal">IID_ISimpleObject: 2A59630E-4232-4582-AE47-706E2B648579 </p>
<p class="MsoNormal">DIID_ISimpleObjectEvents: A06C000A-7A85-42dc-BA6D-BE736B6EB97A
</p>
<p class="MsoNormal">LIBID_CSServicedComponent: 3308202E-A355-4C3D-805D-B527D1EF5FA3
</p>
<p class="MsoNormal">Properties: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// With both get and set accessor methods
float FloatProperty

</pre>
<pre id="codePreview" class="csharp">
// With both get and set accessor methods
float FloatProperty

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Methods: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// HelloWorld returns a string &quot;HelloWorld&quot;
string HelloWorld();
// GetProcessThreadID outputs the running process ID and thread ID
void GetProcessThreadID(out uint processId, out uint threadId);
// Transactional operation
void DoTransaction();

</pre>
<pre id="codePreview" class="csharp">
// HelloWorld returns a string &quot;HelloWorld&quot;
string HelloWorld();
// GetProcessThreadID outputs the running process ID and thread ID
void GetProcessThreadID(out uint processId, out uint threadId);
// Transactional operation
void DoTransaction();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Events: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// FloatPropertyChanging is fired before new value is set to the 
// FloatProperty property. The Cancel parameter allows the client to cancel 
// the change of FloatProperty.
void FloatPropertyChanging(float NewValue, ref bool Cancel);

</pre>
<pre id="codePreview" class="csharp">
// FloatPropertyChanging is fired before new value is set to the 
// FloatProperty property. The Cancel parameter allows the client to cancel 
// the change of FloatProperty.
void FloatPropertyChanging(float NewValue, ref bool Cancel);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Using the Code</h2>
<p class="MsoNormal">A. Creating the project </p>
<p class="MsoNormal">Step1. Create a Visual C# / Class Library project named CSServicedComponent in Visual Studio 2010.
</p>
<p class="MsoNormal">Step2. Add the reference to System.EnterpriseServices. </p>
<p class="MsoNormal">Step3. In the properties page of the project, sign the assembly with a strong name.
</p>
<p class="MsoNormal">Step4. Open the property of the project. Click the Assembly Information<span style="">&nbsp;
</span>button in the page, Application, and select the &quot;Make Assembly COM-Visible&quot; box. This corresponds to the assembly attribute ComVisible in AssemblyInfo.cs:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: ComVisible(true)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: ComVisible(true)]

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
<p class="MsoNormal">B. Adding a serviced component </p>
<p class="MsoNormal">Step1. Define a &quot;public&quot; COM-visible interface ISimpleObject to describe the COM interface of the coclass SimpleObject. Inside the interface, define the prototypes of the properties and methods to be exported.
</p>
<p class="MsoNormal">Step2. Define a &quot;public&quot; COM-visible interface ISimpleObjectEvents to describe the events the coclass can sink.
</p>
<p class="MsoNormal">Step3. Define a &quot;public&quot; COM-visible class SimpleObject that implements the interface ISimpleObject, and inherits fromSystem.EnterpriseServices.ServicedComponent. Attach the attribute [ClassInterface(ClassInterfaceType.None)]
 to the class, which tells the type-library generation tools that we do not require a Class Interface. This ensures that the ISimpleObject interface is the default interface. In addition, specify the GUID of the class, aka CLSID, using the Guid attribute:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[Guid(&quot;14EAD156-F55E-4d9b-A3C5-658D4BB56D30&quot;), ComVisible(true)]

</pre>
<pre id="codePreview" class="csharp">
[Guid(&quot;14EAD156-F55E-4d9b-A3C5-658D4BB56D30&quot;), ComVisible(true)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In this way, CLSID of the COM object is a fixed value. Last, decorate the class with a ComSourceInterface attribute:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ComSourceInterfaces(typeof(ISimpleObjectEvents))]

</pre>
<pre id="codePreview" class="csharp">
[ComSourceInterfaces(typeof(ISimpleObjectEvents))]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">ComSourceInterfaces identifies a list of interfaces that are exposed as<span style="">
</span>COM event sources for the attributed class. </p>
<p class="MsoNormal">Step7. Make sure that the constructor of the class SimpleObject is not private (we can either add a public constructor or use the default one), so that the COM object is creatable from the COM aware clients.
</p>
<p class="MsoNormal">Step8. Inside SimpleObject, implement the interface ISimpleObject by writing the body of the property FloatProperty and the methods HelloWorld,<span style="">&nbsp;
</span>GetProcessThreadID. </p>
<p class="MsoNormal">C. Configuring the serviced component </p>
<p class="MsoNormal">Step1. Specify the name of the COM&#43; application in AssemblyInfo.cs:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: ApplicationName(&quot;All-In-One Code Framework&quot;)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: ApplicationName(&quot;All-In-One Code Framework&quot;)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The System.EnterpriseServices.ApplicationName attribute specifies the name of the COM&#43; application you would like your components to be part of. If the assembly attribute is not provided, the assembly name is used as the name of the COM&#43;
 application by default. </p>
<p class="MsoNormal">Step2. Optionally specify the application ID in AssemblyInfo.cs:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: ApplicationID(&quot;11F3EE74-29A6-4773-82C6-274A67961FB4&quot;)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: ApplicationID(&quot;11F3EE74-29A6-4773-82C6-274A67961FB4&quot;)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">When registration occurs, the components in the assembly are installed in an application with the given ID.
</p>
<p class="MsoNormal">Step3. Specify the application activation type in AssemblyInfo.cs:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: ApplicationActivation(ActivationOption.Server)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: ApplicationActivation(ActivationOption.Server)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The ActivationOption attribute indicates whether the component will be activated within the caller's process. You can set Activation.Option to Library or to Server. If you do not provide the ApplicationActivation attribute, then .NET
 uses a library activation type by default. </p>
<p class="MsoNormal">Step4. Add the Description attribute. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: Description(&quot;COM&#43; examples of All-In-One Code Framework&quot;)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: Description(&quot;COM&#43; examples of All-In-One Code Framework&quot;)]

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: ApplicationAccessControl(true,   //Authentication is on
    AccessChecksLevel = AccessChecksLevelOption.ApplicationComponent,
    Authentication = AuthenticationOption.Packet,
    ImpersonationLevel = ImpersonationLevelOption.Identify)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: ApplicationAccessControl(true,   //Authentication is on
    AccessChecksLevel = AccessChecksLevelOption.ApplicationComponent,
    Authentication = AuthenticationOption.Packet,
    ImpersonationLevel = ImpersonationLevelOption.Identify)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The ApplicationAccessControl attribute programmatically configures the Security tab of the Appliction's properties dialog in DCOMCNFG. When ApplicationAccessControl(false), the &quot;Enforce access checks for this application&quot; option
 is off, and the components inside the application allow full accesses from clients. ApplicationAccessControl(true) enables access checks. You should select the appropriate security level. (See
<a href="http://msdn.microsoft.com/en-us/library/ms684382.aspx">http://msdn.microsoft.com/en-us/library/ms684382.aspx</a>) Also, you must be sure to define roles and add them to the application. If access checks are enabled but no roles have been added, all
 calls to the application will fail. (See </p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms678849.aspx">http://msdn.microsoft.com/en-us/library/ms678849.aspx</a> and
<a href="http://support.microsoft.com/kb/810153">http://support.microsoft.com/kb/810153</a>). Roles can be defined using attributes too:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[assembly: SecurityRole(&quot;Tester&quot;, SetEveryoneAccess = true)]

</pre>
<pre id="codePreview" class="csharp">
[assembly: SecurityRole(&quot;Tester&quot;, SetEveryoneAccess = true)]

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Optionally specify the COM&#43; object pooling for serviced components:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
    [ObjectPooling(MinPoolSize=2, MaxPoolSize=10, CreationTimeout=20)]
    public class SimpleObject : ServicedComponent, ISimpleObject
    {
    }

</pre>
<pre id="codePreview" class="csharp">
    [ObjectPooling(MinPoolSize=2, MaxPoolSize=10, CreationTimeout=20)]
    public class SimpleObject : ServicedComponent, ISimpleObject
    {
    }

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[Transaction(TransactionOption.Required)]
public class SimpleObject : ServicedComponent, ISimpleObject
{
}

</pre>
<pre id="codePreview" class="csharp">
[Transaction(TransactionOption.Required)]
public class SimpleObject : ServicedComponent, ISimpleObject
{
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">You can configure the serviced component to use one of the five available COM&#43; transaction support options by using the Transaction attribute:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public enum TransactionOption
    {
       Disabled,        // Ignores any transaction in the current context
       NotSupported,    // Creates in a context without governing transaction
       Supported,        // Shares a transaction if one exists
       Required,        // Shares a transaction if one exists, and creates a
                        // new transaction if necessary
       RequiresNew        // Creates the component with a new transaction, 
                        // regardless of the state of the current context.
    }
public enum TransactionOption
    {
       Disabled,        // Ignores any transaction in the current context
       NotSupported,    // Creates in a context without governing transaction
       Supported,        // Shares a transaction if one exists
       Required,        // Shares a transaction if one exists, and creates a
                        // new transaction if necessary
       RequiresNew        // Creates the component with a new transaction, 
                        // regardless of the state of the current context.
    }

</pre>
<pre id="codePreview" class="csharp">
public enum TransactionOption
    {
       Disabled,        // Ignores any transaction in the current context
       NotSupported,    // Creates in a context without governing transaction
       Supported,        // Shares a transaction if one exists
       Required,        // Shares a transaction if one exists, and creates a
                        // new transaction if necessary
       RequiresNew        // Creates the component with a new transaction, 
                        // regardless of the state of the current context.
    }
public enum TransactionOption
    {
       Disabled,        // Ignores any transaction in the current context
       NotSupported,    // Creates in a context without governing transaction
       Supported,        // Shares a transaction if one exists
       Required,        // Shares a transaction if one exists, and creates a
                        // new transaction if necessary
       RequiresNew        // Creates the component with a new transaction, 
                        // regardless of the state of the current context.
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The five options correspond to the Transactions tab of the components' properties sheet in DCOMCNFG. When performing transactional operations, you can use ContextUtil.SetComplete to commit the changes, or call ContextUtil.SetAbort to
 rollback on exceptions. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
try
    {
        // Operate on the resource managers like DBMS
        // ...
        
        ContextUtil.SetComplete(); // Commit
    }
    catch
    {
        ContextUtil.SetAbort(); // Rollback
    }

</pre>
<pre id="codePreview" class="csharp">
try
    {
        // Operate on the resource managers like DBMS
        // ...
        
        ContextUtil.SetComplete(); // Commit
    }
    catch
    {
        ContextUtil.SetAbort(); // Rollback
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The KB article http://support.microsoft.com/kb/816141 is an example of COM&#43; transaction. Please note that transactional operations must happen to resource managers. A resource (such as a database management system) that can participate
 in a COM&#43; transaction is called a resource manager. A resource manager knows how to conduct itself properly in the scope of a COM&#43; transaction.
</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/3x7357ez(VS.80).aspx">Writing Serviced Components</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/306296">HOW TO: Create a Serviced .NET Component in Visual C# .NET</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://oreilly.com/catalog/comdotnetsvs/chapter/ch10.html">Chapter 10 .NET Serviced Components of 'COM and .NET Component Services'</a>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/816141">How to use COM&#43; transactions in a Visual C# component</a>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/magazine/cc301491.aspx">COM&#43; Integration: How .NET Enterprise Services Can Help You Build Distributed Applications</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
