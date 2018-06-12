# Create a TFS event listener using WCF Console Application (CSTFSEventListener)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* TFS
## Topics
* Event Listener
## IsPublished
* True
## ModifiedDate
* 2011-05-26 02:09:23
## Description

<p style="font-family:Courier New"></p>
<h2>Console APPLICATION: CSTFSEventListener </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to create a TFS event listener using WCF Console <br>
Application.<br>
<br>
This WCF service is used to subscribe a TFS Check-in Event. If a user checked <br>
in a changeset which meets the filters of the subscription, TFS will call the <br>
Notify method of this WCF service with the parameters. The Notify method will <br>
display a message if the Changeset has policy failures. <br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
This sample have to run on TFS2010 Application Tier. <br>
<br>
To set the check-in policy and check-in a changeset, you need a machine that <br>
Team Explorer2010 and TFS2010 PowerTools are installed on it. The machine could<br>
be the same as TFS2010 application tier. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
<br>
Build and run this WCF application.<br>
<br>
Step1. Open this project in &nbsp;Visual Studio 2010. <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step2. Build the solution. <br>
<br>
Step3. Open CSTFSEventListener.exe.config in the output folder.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Set the baseAddress of the service, like <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<a target="_blank" href="&lt;a target=" href="http://localhost:8732/CSTFSEventListener/EventService/">http://localhost:8732/CSTFSEventListener/EventService/</a>'&gt;<a target="_blank" href="http://localhost:8732/CSTFSEventListener/EventService/">http://localhost:8732/CSTFSEventListener/EventService/</a><br>
<br>
Step4. Run CSTFSEventListener.exe.<br>
<br>
<br>
<br>
<br>
Subscribe Check-in Event.<br>
<br>
Step1. On TFS2010 application tier, open command line and navigate to &nbsp; <br>
&nbsp; &nbsp; &nbsp; C:\Program Files\Microsoft Team Foundation Server 2010\Tools<br>
<br>
Step2. Run following command in command line.<br>
<br>
&nbsp; &nbsp; &nbsp; BisSubscribe.exe /eventtype CheckinEvent /address <a target="_blank" href="&lt;a target=" href="http://localhost:8732/CSTFSEventListener/EventService/">
http://localhost:8732/CSTFSEventListener/EventService/</a>'&gt;<a target="_blank" href="http://localhost:8732/CSTFSEventListener/EventService/">http://localhost:8732/CSTFSEventListener/EventService/</a>
<br>
&nbsp; &nbsp; &nbsp; /collection <a target="_blank" href="http://Server:8080/tfs/collectionName">
http://Server:8080/tfs/collectionName</a> /deliveryType Soap<br>
<br>
&nbsp; &nbsp; &nbsp; <br>
You can also set the alert using Alert Explorer of TFS2010 PowerTools.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br>
<br>
Set Check-in policy<br>
<br>
Step1. Open VS and connect to the specified Project Collection and Team Project <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; using Team Explorer.<br>
<br>
Step2. Right click the Team Project node in Team Explorer, and in the context menu,<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; expand Team Project Settings, select Source Control.<br>
<br>
Step3. In the Source Control Settings dialog, choose Check-in Policy tab and click<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;Add...&quot; button. <br>
<br>
Step4. In the Add Check-in Policy dialog, choose &quot;Changest Comments Policy&quot; and click<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; OK. You will see a new check-in policy in the Source Control Settings dialog,
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; click OK to close this dialog.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
<br>
Check in files to fire the event.<br>
<br>
Step1. Open VS and connect to the specified Project Collection and Team Project <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; using Team Explorer.<br>
<br>
Step2. Double click the &quot;Source Control&quot; node under the Team Project in Team Explorer.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; VS will open Source Control Explorer.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; You have to create a workspace and map a work folder.<br>
<br>
Step3. Check out a file of the Team Project in Source Control Explorer, open the file
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; edit it and save it. Then right click the file in Source Control Explorer, select
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;Check In Pending Changes&quot;. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
Step4. In &quot;Policy Warning&quot; tab of the &quot;Check In&quot; dialog, you will find a message that
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;Please Provide some comments about your check-in&quot;. Ignore it and continue to
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; click the &quot;Check In&quot; button to check in the file.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
Step5. VS will alert a message that &quot;Checkin cannot proceed because the policy requirement<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; have not been satisfied&quot;. Check &quot;Override policy failure and continue checkin&quot;, and type
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;Test checkin event&quot; in the Reason textbox. Click OK, and then VS will check-in the<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; files. &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <br>
<br>
Step6. Wait for one or two minutes, and then you will see following message in the
<br>
&nbsp; &nbsp; &nbsp; CSTFSEventListener.exe.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; ChangeSetChangeset 10 Check In Policy Policy Failed.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Committer : &lt;Domain&gt;\&lt;user&gt;<br>
&nbsp; &nbsp; &nbsp; Override Comment : Test checkin event<br>
&nbsp; &nbsp; &nbsp; Check in policy failures:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Changeset Comments Policy : Please provide some comments about your check-in<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Define the WCF Service Contract which is used to listen TFS event.<br>
<br>
&nbsp; [ServiceContract(Namespace = &quot;<a target="_blank" href="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03&quot;)">http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03&quot;)</a>]<br>
&nbsp; &nbsp;public interface IEventService<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;[OperationContract(Action = &quot;<a target="_blank" href="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify&quot;)">http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify&quot;)</a>]<br>
&nbsp; &nbsp; &nbsp; &nbsp;[XmlSerializerFormat(Style = OperationFormatStyle.Document)]<br>
&nbsp; &nbsp; &nbsp; &nbsp;void Notify(string eventXml, string tfsIdentityXml);<br>
&nbsp; &nbsp;}<br>
<br>
B. Create CheckinEventService class that implement the Service Contract.<br>
<br>
&nbsp; The eventXml parameter of the Notify method is serialized from a CheckinEvent object,
<br>
&nbsp; we can use XmlSerializer to deserialize it back to a CheckinEvent object.<br>
&nbsp; <br>
&nbsp; The CheckinEvent contains a PolicyFailures field from which we can determine whether
<br>
&nbsp; the Changeset has policy failures. <br>
<br>
C. Create a console application to host the WCF Service. <br>
&nbsp; In the main method of this application, use the ServiceHost class to configure and
<br>
&nbsp; expose a service for use<br>
<br>
&nbsp; &nbsp;using (ServiceHost host = new ServiceHost(typeof(CheckinEventService)))<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;host.Open();<br>
&nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(host.BaseAddresses.First());<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;Press &lt;Enter&gt; to exit...&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;Console.ReadLine();<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;In the configuration file, make sure this WCF service use wsHttpBinding and security mode<br>
&nbsp;&nbsp;&nbsp;&nbsp;is None.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;system.serviceModel&gt;<br>
&nbsp; &nbsp;&lt;bindings&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;wsHttpBinding&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;binding name=&quot;EventService&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;security mode=&quot;None&quot;&gt;&lt;/security&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/binding&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;/wsHttpBinding&gt;<br>
&nbsp; &nbsp;&lt;/bindings&gt;<br>
&nbsp; &nbsp;&lt;behaviors&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;serviceBehaviors&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;behavior name=&quot;EventServiceBehavior&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;serviceMetadata httpGetEnabled=&quot;true&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;serviceDebug includeExceptionDetailInFaults=&quot;true&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/behavior&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;/serviceBehaviors&gt;<br>
&nbsp; &nbsp;&lt;/behaviors&gt;<br>
&nbsp; &nbsp;&lt;services&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;service behaviorConfiguration=&quot;EventServiceBehavior&quot; name=&quot;CSTFSEventListener.CheckinEventService&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;endpoint address=&quot;&quot; binding=&quot;wsHttpBinding&quot; bindingConfiguration=&quot;EventService&quot; contract=&quot;CSTFSEventListener.IEventService&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;endpoint address=&quot;mex&quot; binding=&quot;mexHttpBinding&quot; contract=&quot;IMetadataExchange&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;host&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;baseAddresses&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;add baseAddress=&quot;<a target="_blank" href="&lt;a target=" href="http://localhost:8732/CSTFSEventListener/EventService/">http://localhost:8732/CSTFSEventListener/EventService/</a>'&gt;<a target="_blank" href="http://localhost:8732/CSTFSEventListener/EventService/">http://localhost:8732/CSTFSEventListener/EventService/</a>&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/baseAddresses&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/host&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;/service&gt;<br>
&nbsp; &nbsp;&lt;/services&gt;<br>
&nbsp;&lt;/system.serviceModel&gt;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Team Foundation Server Event Service<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc507647.aspx">http://msdn.microsoft.com/en-us/magazine/cc507647.aspx</a><br>
<br>
CheckinEvent Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.versioncontrol.common.checkinevent.aspx">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.versioncontrol.common.checkinevent.aspx</a><br>
<br>
ServiceHost Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx">http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
