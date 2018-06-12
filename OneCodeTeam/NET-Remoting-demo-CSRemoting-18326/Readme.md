# .NET Remoting demo (CSRemoting)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* .NET Remoting
## Topics
* Remoting
## IsPublished
* True
## ModifiedDate
* 2012-08-23 02:32:02
## Description

<h1><span>.NET Remoting demo (CSRemoting) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
.NET remoting provides an abstract approach to interprocess communication that separates the remotable object from a specific client or server application domain and from a specific mechanism of communication.</p>
<p class="MsoNormal">.NET remoting allows an application to make a remotable object available across remoting boundaries, which includes different appdomains, processes or even different computers connected by a network. .NET Remoting makes a reference of
 a remotable object available to a client application, which then instantiates and uses a remotable object as if it were a local object. However, the actual code execution happens at the server-side. Any requests to the remotable object are proxied by the .NET
 Remoting runtime over Channel objects, that encapsulate the actual transport mode, including TCP streams, HTTP streams and named pipes. As a result, by instantiating proper Channel objects, a .NET Remoting application can be made to support different communication
 protocols without recompiling the application. The runtime itself manages the act of serialization and marshalling of objects across the client and server appdomains.</p>
<p class="MsoNormal"><span class="SpellE">CSRemotingSharedLibrary</span> contains the remote object types shared by the .NET
<span class="SpellE">Remoting</span> clients and servers.</p>
<p class="MsoNormal"><span class="SpellE">CSRemotingClient</span> is a .NET Remoting client project. It accesses the remote objects (SingleCall objects or Singleton objects or client-activated objects) exposed by the .NET Remoting server project, CSRemotingServer.</p>
<p class="MsoNormal">There are generally two ways to create the .NET Remoting client: using a configuration file or writing codes. The AccessRemotingServerByConfig method demonstrates the former and the AccessRemotingServerByCode method illustrates the latter
 method.</p>
<p class="MsoNormal">CSRemotingServer is a .NET Remoting server project. It contains the following remotable objects:</p>
<p class="MsoNormal">1. RemotingShared.SingleCallObject</p>
<p class="MsoNormal">URL: tcp://localhost:6100/SingleCallService</p>
<p class="MsoNormal">SingleCallObject is a server-activated object (SAO) with the &quot;SingleCall&quot; instancing mode. Such objects are created on each method call and objects are not shared among clients. State should not be maintained in such objects because they
 are destroyed after each method call.</p>
<p class="MsoNormal">2. RemotingShared.SingletonObject</p>
<p class="MsoNormal">URL: tcp://localhost:6100/SingletonService</p>
<p class="MsoNormal">SingletonObject is a server-activated object (SAO) with the &quot;Singleton&quot; instancing mode. Only one object will be created on the server to fulfill the requests of all the clients; that means the object is shared, and the state will be
 shared by all the clients.</p>
<p class="MsoNormal">3. RemotingShared.ClientActivatedObject defined in the shared assembly CSRemotingSharedLibrary.DLL:</p>
<p class="MsoNormal">URL: tcp://localhost:6100/RemotingService</p>
<p class="MsoNormal">ClientActivatedObject is a client-activated object (CAO) for .NET Remoting.</p>
<p class="MsoNormal">Client-activated objects are created by the server and their lifetime is managed by the client. In contrast to server-activated objects, client-activated objects are created as soon as the client calls &quot;new&quot; or any other object creation
 methods. Client-activated objects are specific to the client, and objects are not shared among different clients; object instance exists until the lease expires or the client destroys the object.</p>
<p class="MsoNormal">There are generally two ways to create the .NET Remoting server: using a configuration file or writing codes. The CreateRemotingServerByConfig method demonstrates the former and the CreateRemotingServerByCode method illustrates the latter
 method.</p>
<p class="MsoNormal"><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Running the Sample
</span></strong></p>
<p class="MsoNormal"><span>The following steps walk through a demonstration of the .NET remoting sample.
</span></p>
<p class="MsoNormal"><span>Step1. After you successfully build the CSRemotingClient and CSRemotingServer sample projects in Visual Studio 2010, you will get the console applications: CSRemotingClient.exe and CSRemotingServer.exe.
</span></p>
<p class="MsoNormal"><span>Step2. Run CSRemotingServer.exe in a command prompt to start up the server project. The command 'CSRemotingServer.exe -configfile' creates and configures the .NET Remoting server using a configuration file. The command 'CSRemotingServer.exe
 -code' uses code to create the .NET Remoting server with the same configuration. You can choose either one. Because CSRemotingServer uses a TCP channel, you may be prompted that Windows Firewall has blocked some features of the application. You can safely
 allow the access when you see the Windows Firewall dialog. </span></p>
<p class="MsoNormal"><span>Step3. Run CSRemotingClient.exe in another command prompt to start up the client project. Similiarly, the command 'CSRemotingClient.exe -configfile' reads a configuration file and configure the remoting infrastructure for the client
 project to connect to the .NET Remoting server (CSRemotingServer). The command 'CSRemotingClient.exe -code' uses code to connect to the server with the same configuration. You can choose either one.
</span></p>
<p class="MsoNormal"><span>By default, CSRemotingClient creates a SingleCall server-activated object, and invokes its methods and sets properties.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/65128/1/image.png" alt="" width="611" height="391" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>SingleCallObject is a server-activated object (SAO) with the &quot;SingleCall&quot; instancing mode. Such objects are created on each method call and objects are not shared among clients. State is not maintained in such objects because they
 are destroyed after each method call. Therefore, in the above output, the FloatProperty of the SingleCall object was set to 1.2 (Set FloatProperty &#43;= 1.2), but the next retrieval of the float property still returns 0.
</span></p>
<p class="MsoNormal"><span>You can try out other types of remoting objects (e.g. Singleton object, client-activate object) by uncommenting the corresponding code lines and rebuilding the client project.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Create a SingleCall server-activated proxy.
SingleCallObject remoteObj = new SingleCallObject();
Console.WriteLine(&quot;A SingleCall server-activated proxy is created&quot;);
// [-or-] Create a Singleton server-activated proxy.
//SingletonObject remoteObj = new SingletonObject();
//Console.WriteLine(&quot;A Singleton server-activated proxy is created&quot;);
// [-or-] Create a client-activated object.
//ClientActivatedObject remoteObj = new ClientActivatedObject();
//Console.WriteLine(&quot;A client-activated object is created&quot;);

</pre>
<pre id="codePreview" class="cplusplus">// Create a SingleCall server-activated proxy.
SingleCallObject remoteObj = new SingleCallObject();
Console.WriteLine(&quot;A SingleCall server-activated proxy is created&quot;);
// [-or-] Create a Singleton server-activated proxy.
//SingletonObject remoteObj = new SingletonObject();
//Console.WriteLine(&quot;A Singleton server-activated proxy is created&quot;);
// [-or-] Create a client-activated object.
//ClientActivatedObject remoteObj = new ClientActivatedObject();
//Console.WriteLine(&quot;A client-activated object is created&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal"><span>Step4. Exit the remoting server by pressing ENTER in the server application.
</span></p>
<p class="MsoNormal"><strong><span>Sample Relation: </span></strong></p>
<p class="MsoNormal"><span>CSRemotingClient -&gt; CSRemotingServer </span></p>
<p class="MsoNormal"><span>CSRemotingClient is the client project of the CSRemotingServer server project.
</span></p>
<p class="MsoNormal"><span>CSRemotingServer -&gt; CSRemotingSharedLibrary </span>
</p>
<p class="MsoNormal"><span>CSRemotingServer references a shared library for the client-activated
</span></p>
<p class="MsoNormal"><span>remoting types. </span></p>
<p class="MsoNormal"><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Using the Code
</span></strong></p>
<p class="MsoNormal"><span class="SpellE"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">CSRemotingServer</span></span><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Adding <span class="SpellE">remotable</span> types on the service project.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>For client-activated types, they must be defined in an assembly shared by both client and server projects, because client-activated types require not only the same namespace/class name on both sides, but also the
 same assembly. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step1. Create a .NET class library project, exposing the type (<span class="SpellE">ClientActivatedObject</span>) that inherits
<span class="SpellE">MarshalByRefObject</span> and implement the body of the type.
<span class="SpellE">MarshalByRefObject</span> marks the type as a <span class="SpellE">
remotable</span> type. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step2. Add the reference to the class library in the server project.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>For server-activated types, they can be either defined in a shared assembly, or defined on the server project and have an empty proxy of the type one the client projects. Please make sure that the server type and
 the proxy type have the same namespace/class name though it is not necessary to place them in the same assembly.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step1. Add the server-activated <span class="GramE">
types (<span class="SpellE">SingleCallObject</span>, <span class="SpellE">SingletonObject</span>) that inherits</span>
<span class="SpellE">MarshalByRefObject</span> to the server project. Implement the body
<span class="SpellE">ofthe</span> types. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Creating .NET <span class="SpellE">Remoting</span> server using configuration file.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step1. Add an application configuration file to the project.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step2. Define the channel to transport message.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step3. Register the <span class="SpellE">
remotable</span> types. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step4. Read the configuration file and configure the
<span class="SpellE">remoting</span> infrastructure for the server project. (<span class="SpellE">RemotingConfiguration.Configure</span>)
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Creating .NET <span class="SpellE">Remoting</span> server using code.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step1. Specify the formatter of the messages for delivery. (<span class="SpellE">BinaryClientFormatterSinkProvider</span>,
<span class="SpellE">BinaryServerFormatterSinkProvider</span>)Once message has been formatted, it is transported to other application domains through the appropriate channel. .NET comes with the SOAP formatter (<span class="SpellE">System.Runtime.Serialization.Formatters.Soap</span>)
 and Binary formatter (<span class="SpellE">System.Runtime.Serialization.Formatters.Binary</span>).
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Step2. Create and register the channel to transport message from one project to another. (<span class="SpellE">TcpChannel</span>/<span class="SpellE">HttpChannel</span>/<span class="SpellE">IpcChannel</span>,
<span class="SpellE">ChannelServices.RegisterChannel</span>) </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>.NET comes with three built-in channels:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>TCP channel (<span class="SpellE">System.Runtime.Remoting.Channels.Tcp</span>)<span>牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋
</span>- good for binary </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>HTTP channel (<span class="SpellE">System.Runtime.Remoting.Channels.Http</span>)<span>牋牋牋牋牋牋牋牋牋牋牋牋牋牋?</span>- good for internet
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>IPC channel (<span class="SpellE">System.Runtime.Remoting.Channels.Ipc</span>)<span>牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋牋
</span>- based on named pipe </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>Step3. Register the <span class="SpellE">
remotable</span> classes on the service project as server-activated types (aka well-known types) or client-activated types. (<span class="SpellE">RemotingConfiguration.RegisterWellKnownServiceType</span>,
<span class="SpellE">RemotingConfiguration.RegisterActivatedServiceType</span>)
</span></p>
<p class="MsoNormal"><span class="SpellE"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">CSRemotingClient</span></span><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Adding <span class="SpellE">
remotable</span> types on the client project. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">For client-activated types, they must be defined in an assembly shared by both client and server projects, because client-activated types require not only the same namespace/class
 name on both sides, but also the same assembly. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step1. Add the reference to the .NET class library shared by the .NET
<span class="SpellE">Remoting</span> server. The class library exposes the client-activated type (<span class="SpellE">ClientActivatedObject</span>) that inherits
<span class="SpellE">MarshalByRefObject</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">For server-activated types, they can be either defined in a shared assembly, or defined in the server project and have
<span class="SpellE">en</span> empty proxy of the type in the client projects. Please make sure that the server type and the proxy type have the same namespace/class name though it is not necessary to place them in the same assembly.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step1. Add the proxy of the server-activated types (<span class="SpellE">SingleCallObject</span>,
<span class="SpellE">SingletonObject</span>) that inherits <span class="SpellE">
MarshalByRefObject</span> to the client project. There is no need to implement the body of the types.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Accessing .NET <span class="SpellE">
Remoting</span> server using configuration file. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step1. Add an application configuration file to the project.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step2. Define the channel to transport message.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step3. Register the
<span class="SpellE">remotable</span> types. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step4. Read the configuration file and configure the
<span class="SpellE">remoting</span> infrastructure for the client project. (<span class="SpellE">RemotingConfiguration.Configure</span>)
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step5. Create the
<span class="SpellE">remotable</span> object. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step6. Use the
<span class="SpellE">remotable</span> object as if it were a local object. </span>
</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Accessing .NET <span class="SpellE">
Remoting</span> server using code. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step1. Specify the formatter of the messages for delivery. (<span class="SpellE">BinaryClientFormatterSinkProvider</span>,
<span class="SpellE">BinaryServerFormatterSinkProvider</span>)Once message has been formatted, it is transported to other application domains through the appropriate channel. .NET comes with the SOAP formatter (<span class="SpellE">System.Runtime.Serialization.Formatters.Soap</span>)
 and Binary formatter (<span class="SpellE">System.Runtime.Serialization.Formatters.Binary</span>).
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step2. Create and register the channel to transport message according to the channel on the server project. (<span class="SpellE">TcpChannel</span>/<span class="SpellE">HttpChannel</span>/<span class="SpellE">IpcChannel</span>,
<span class="SpellE">ChannelServices.RegisterChannel</span>) </span></p>
<p class="MsoListParagraphCxSpMiddle">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step3. Create the
<span class="SpellE">remotable</span> object. </span></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Step4. Use the
<span class="SpellE">remotable</span> object as if it were a local object. </span>
</p>
<p class="MsoNormal"><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">References
</span></strong></p>
<p class="MsoNormal"><span>.NET Framework <span class="SpellE">Remoting</span> Architecture<span>?</span>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/2e7z38xb(VS.85).aspx">http://msdn.microsoft.com/en-us/library/2e7z38xb(VS.85).aspx</a>
</span></p>
<p class="MsoNormal"><span>.NET Framework <span class="SpellE">Remoting</span> Overview<span>?</span>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/kwdt6w2k(VS.85).aspx">http://msdn.microsoft.com/en-us/library/kwdt6w2k(VS.85).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
