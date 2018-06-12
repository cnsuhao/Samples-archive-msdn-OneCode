# .NET Remoting server demo (CSRemotingServer)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* .NET Remoting
* Inter-process Communication
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:59:01
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSRemotingServer Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
.NET remoting provides an abstract approach to interprocess communication <br>
that separates the remotable object from a specific client or server <br>
application domain and from a specific mechanism of communication. <br>
<br>
.NET remoting allows an application to make a remotable object available <br>
across remoting boundaries, which includes different appdomains, processes or <br>
even different computers connected by a network. .NET Remoting makes a <br>
reference of a remotable object available to a client application, which then <br>
instantiates and uses a remotable object as if it were a local object. <br>
However, the actual code execution happens at the server-side. Any requests <br>
to the remotable object are proxied by the .NET Remoting runtime over Channel <br>
objects, that encapsulate the actual transport mode, including TCP streams, <br>
HTTP streams and named pipes. As a result, by instantiating proper Channel <br>
objects, a .NET Remoting application can be made to support different <br>
communication protocols without recompiling the application. The runtime <br>
itself manages the act of serialization and marshalling of objects across the <br>
client and server appdomains.<br>
<br>
CSRemotingServer is a .NET Remoting server project. It contains the following <br>
remotable objects:<br>
<br>
1. RemotingShared.SingleCallObject<br>
URL: tcp://localhost:6100/SingleCallService<br>
<br>
SingleCallObject is a server-activated object (SAO) with the &quot;SingleCall&quot;
<br>
instancing mode. Such objects are created on each method call and objects are <br>
not shared among clients. State should not be maintained in such objects <br>
because they are destroyed after each method call. <br>
<br>
2. RemotingShared.SingletonObject<br>
URL: tcp://localhost:6100/SingletonService<br>
<br>
SingletonObject is a server-activated object (SAO) with the &quot;Singleton&quot;
<br>
instancing mode. Only one object will be created on the server to fulfill the <br>
requests of all the clients; that means the object is shared, and the state <br>
will be shared by all the clients. <br>
<br>
3. RemotingShared.ClientActivatedObject defined in the shared assembly <br>
CSRemotingSharedLibrary.DLL:<br>
URL: tcp://localhost:6100/RemotingService<br>
<br>
ClientActivatedObject is a client-activated object (CAO) for .NET Remoting. <br>
Client-activated objects are created by the server and their lifetime is <br>
managed by the client. In contrast to server-activated objects, client-<br>
activated objects are created as soon as the client calls &quot;new&quot; or any other
<br>
object creation methods. Client-activated objects are specific to the client, <br>
and objects are not shared among different clients; object instance exists <br>
until the lease expires or the client destroys the object. <br>
<br>
There are generally two ways to create the .NET Remoting server: using a <br>
configuration file or writing codes. The CreateRemotingServerByConfig method <br>
demonstrates the former and the CreateRemotingServerByCode method illustrates <br>
the latter method.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the .NET remoting sample.<br>
<br>
Step1. After you successfully build the CSRemotingClient and CSRemotingServer <br>
sample projects in Visual Studio 2008, you will get the console applications: <br>
CSRemotingClient.exe and CSRemotingServer.exe. <br>
<br>
Step2. Run CSRemotingServer.exe in a command prompt to start up the server <br>
project. The command 'CSRemotingServer.exe -configfile' creates and configures <br>
the .NET Remoting server using a configuration file. The command <br>
'CSRemotingServer.exe -code' uses code to create the .NET Remoting server <br>
with the same configuration. You can choose either one.<br>
<br>
Because CSRemotingServer uses a TCP channel, you may be prompted that Windows <br>
Firewall has blocked some features of the application. You can safely allow <br>
the access when you see the Windows Firewall dialog. <br>
<br>
Step3. Run CSRemotingClient.exe in another command prompt to start up the <br>
client project. Similiarly, the command 'CSRemotingClient.exe -configfile' <br>
reads a configuration file and configure the remoting infrastructure for the <br>
client project to connect to the .NET Remoting server (CSRemotingServer). The <br>
command 'CSRemotingClient.exe -code' uses code to connect to the server with <br>
the same configuration. You can choose either one.<br>
<br>
By default, CSRemotingClient creates a SingleCall server-activated object, <br>
and invokes its methods and sets properties.<br>
<br>
&nbsp; &nbsp;A SingleCall server-activated object is created<br>
&nbsp; &nbsp;Call GetRemoteObjectType =&gt; SingleCallObject<br>
&nbsp; &nbsp;The client process and thread: 6852, 4732<br>
&nbsp; &nbsp;Call GetProcessThreadID =&gt; 8092 8080<br>
&nbsp; &nbsp;Set FloatProperty &#43;= 1.2<br>
&nbsp; &nbsp;Get FloatProperty = 0<br>
<br>
SingleCallObject is a server-activated object (SAO) with the &quot;SingleCall&quot;
<br>
instancing mode. Such objects are created on each method call and objects are <br>
not shared among clients. State is not maintained in such objects because <br>
they are destroyed after each method call. Therefore, in the above output, <br>
the FloatProperty of the SingleCall object was set to 1.2 <br>
(Set FloatProperty &#43;= 1.2), but the next retrieval of the float property <br>
still returns 0.<br>
<br>
You can try out other types of remoting objects (e.g. Singleton object, <br>
client-activate object) by uncommenting the corresponding code lines and <br>
rebuilding the client project.<br>
<br>
&nbsp; &nbsp;// Create a SingleCall server-activated object.<br>
&nbsp; &nbsp;SingleCallObject remoteObj = new SingleCallObject();<br>
&nbsp; &nbsp;Console.WriteLine(&quot;A SingleCall server-activated object is created&quot;);<br>
<br>
&nbsp; &nbsp;// [-or-] Create a Singleton server-activated object.<br>
&nbsp; &nbsp;//SingletonObject remoteObj = new SingletonObject();<br>
&nbsp; &nbsp;//Console.WriteLine(&quot;A Singleton server-activated object is created&quot;);<br>
<br>
&nbsp; &nbsp;// [-or-] Create a client-activated object.<br>
&nbsp; &nbsp;//ClientActivatedObject remoteObj = new ClientActivatedObject();<br>
&nbsp; &nbsp;//Console.WriteLine(&quot;A client-activated object is created&quot;);<br>
<br>
Step4. Exit the remoting server by pressing ENTER in the server application. <br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://1code.codeplex.com)">
http://1code.codeplex.com)</a><br>
<br>
CSRemotingClient -&gt; CSRemotingServer<br>
CSRemotingClient is the client project of the CSRemotingServer server project.<br>
<br>
CSRemotingServer -&gt; CSRemotingSharedLibrary<br>
CSRemotingServer references a shared library for the client-activated <br>
remoting types.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Adding remotable types on the service project<br>
<br>
------<br>
For client-activated types, they must be defined in an assembly shared by <br>
both client and server projects, because client-activated types require not <br>
only the same namespace/class name on both sides, but also the same assembly.<br>
<br>
Step1. Create a .NET class library project, exposing the type <br>
(ClientActivatedObject) that inherits MarshalByRefObject and implement the <br>
body of the type. MarshalByRefObject marks the type as a remotable type.<br>
<br>
Step2. Add the reference to the class library in the server project.<br>
<br>
------<br>
For server-activated types, they can be either defined in a shared assembly, <br>
or defined on the server project and have en empty proxy of the type one the <br>
client projects. Please make sure that the server type and the proxy type <br>
have the same namespace/class name though it is not necessary to place them <br>
in the same assembly.<br>
<br>
Step1. Add the server-activated types (SingleCallObject, SingletonObject) <br>
that inherits MarshalByRefObject to the server project. Implement the body of<br>
the types.<br>
<br>
B. Creating .NET Remoting server using configuration file<br>
<br>
Step1. Add an application configuration file to the project.<br>
<br>
Step2. Define the channel to transport message.<br>
<br>
&lt;system.runtime.remoting&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;application&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;channels&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;channel ref=&quot;tcp&quot; port=&quot;6100&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;serverProviders&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;formatter ref=&quot;binary&quot; typeFilterLevel=&quot;Full&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/serverProviders&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/channel&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/channels&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/application&gt;<br>
&lt;/system.runtime.remoting&gt;<br>
<br>
The above configuration registers a TCP channel whose port is 6100 and <br>
formatter is binary.<br>
<br>
Step3. Register the remotable types.<br>
<br>
------<br>
For client-activated types<br>
<br>
&lt;system.runtime.remoting&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;application name=&quot;RemotingService&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;service&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;activated type=&quot;RemotingShared.ClientActivatedObject, CSRemotingSharedLibrary&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/activated&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/service&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/application&gt;<br>
&lt;/system.runtime.remoting&gt;<br>
<br>
The name of the application (&lt;application name=&quot;RemotingService&quot;&gt;) is the
<br>
service name of the client-activated types. The clients can access this kind <br>
of types through the URI tcp://server:6100/RemotingService.<br>
<br>
------<br>
For server-activated types<br>
<br>
&lt;system.runtime.remoting&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;application&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;service&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;wellknown mode=&quot;SingleCall&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;RemotingShared.SingleCallObject, CSRemotingServer&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; objectUri=&quot;SingleCallService&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/wellknown&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;wellknown mode=&quot;Singleton&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; type=&quot;RemotingShared.SingletonObject, CSRemotingServer&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; objectUri=&quot;SingletonService&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/wellknown&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/service&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/application&gt;<br>
&lt;/system.runtime.remoting&gt;<br>
<br>
The mode attribute in wellknown specifies the instancing mode of the server-<br>
activated type: SingleCall or Singleton. The objectUri attribute specifies <br>
the service name of the server-activated types. The clients can access this <br>
kind of types through the URI tcp://server:6100/SingleCallService.<br>
<br>
Step4. Read the configuration file and configure the remoting infrastructure <br>
for the server project. (RemotingConfiguration.Configure)<br>
<br>
C. Creating .NET Remoting server using code<br>
<br>
Step1. Specify the formatter of the messages for delivery. <br>
(BinaryClientFormatterSinkProvider, BinaryServerFormatterSinkProvider)<br>
Once message has been formatted, it is transported to other application <br>
domains through the appropriate channel. .NET comes with the SOAP formatter <br>
(System.Runtime.Serialization.Formatters.Soap) and Binary formatter <br>
(System.Runtime.Serialization.Formatters.Binary).<br>
<br>
Step2. Create and register the channel to transport message from one project to <br>
another. (TcpChannel/HttpChannel/IpcChannel, ChannelServices.RegisterChannel)<br>
<br>
.NET comes with three built-in channels: <br>
TCP channel (System.Runtime.Remoting.Channels.Tcp)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- good for binary<br>
HTTP channel (System.Runtime.Remoting.Channels.Http)&nbsp;&nbsp;&nbsp;&nbsp;- good for internet<br>
IPC channel (System.Runtime.Remoting.Channels.Ipc)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- based on named pipe<br>
<br>
Step3. Register the remotable classes on the service project as server-<br>
activated types (aka well-known types) or client-activated types. <br>
(RemotingConfiguration.RegisterWellKnownServiceType, <br>
RemotingConfiguration.RegisterActivatedServiceType)<br>
<br>
------<br>
For client-activated types<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;RemotingConfiguration.ApplicationName = &quot;RemotingService&quot;;<br>
&nbsp;&nbsp;&nbsp;&nbsp;RemotingConfiguration.RegisterActivatedServiceType(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;typeof(RemotingShared.ClientActivatedObject));<br>
<br>
The name of the application (RemotingConfiguration.ApplicationName) is the <br>
service name of the client-activated types. The clients can access this kind <br>
of types through the URI tcp://server:6100/RemotingService.<br>
<br>
------<br>
For server-activated types<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;RemotingConfiguration.RegisterWellKnownServiceType(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;typeof(RemotingShared.SingletonObject),&nbsp;&nbsp;&nbsp;&nbsp;// Server-activated type<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;SingletonService&quot;,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// objectUri<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WellKnownObjectMode.Singleton);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Singleton instancing mode<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
.NET Framework Remoting Architecture &nbsp;<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/2e7z38xb(VS.85).aspx">http://msdn.microsoft.com/en-us/library/2e7z38xb(VS.85).aspx</a><br>
<br>
.NET Framework Remoting Overview &nbsp;<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/kwdt6w2k(VS.85).aspx">http://msdn.microsoft.com/en-us/library/kwdt6w2k(VS.85).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>