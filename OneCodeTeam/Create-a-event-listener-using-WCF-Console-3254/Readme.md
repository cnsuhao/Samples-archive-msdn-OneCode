# Create a TFS event listener using WCF Console Application (VBTFSEventListener)
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
* 2011-05-26 08:51:23
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Console APPLICATION: VBTFSEventListener</h2>
<p style="font-family:Courier New">&nbsp;</p>
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
Step3. Open VBTFSEventListener.exe.config in the output folder.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Set the baseAddress of the service, like <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<a href="&lt;a target=" target="_blank">http://localhost:8732/VBTFSEventListener/EventService/</a>'&gt;<a href="http://localhost:8732/VBTFSEventListener/EventService/" target="_blank">http://localhost:8732/VBTFSEventListener/EventService/</a><br>
<br>
Step4. Run VBTFSEventListener.exe.<br>
<br>
<br>
<br>
Subscribe Check-in Event.<br>
<br>
Step1. On TFS2010 application tier, open command line and navigate to &nbsp; <br>
Step2. Run following command in command line.<br>
&nbsp; &nbsp; &nbsp; BisSubscribe.exe /eventtype CheckinEvent /address <a href="&lt;a target=" target="_blank">
http://localhost:8732/VBTFSEventListener/EventService/</a>'&gt;<a href="http://localhost:8732/VBTFSEventListener/EventService/" target="_blank">http://localhost:8732/VBTFSEventListener/EventService/</a>
<br>
&nbsp; &nbsp; &nbsp; /collection <a href="http://Server:8080/tfs/collectionName" target="_blank">
http://Server:8080/tfs/collectionName</a> /deliveryType Soap<br>
<br>
You can also set the alert using Alert Explorer of TFS2010 PowerTools.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br>
<br>
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
&nbsp; &nbsp; &nbsp; VBTFSEventListener.exe.&nbsp;&nbsp;&nbsp;&nbsp;<br>
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
&nbsp; &nbsp;&lt;ServiceContract(Namespace:=&quot;<a href="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03">&quot; target=&quot;_blank&quot;&gt;http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03&quot;)&gt;</a><br>
&nbsp; &nbsp;Public Interface IEventService<br>
&nbsp; &nbsp; &nbsp;&lt;OperationContract(Action:=&quot;<a href="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify">&quot; target=&quot;_blank&quot;&gt;http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify&quot;)&gt;</a><br>
&nbsp; &nbsp; &nbsp;&lt;XmlSerializerFormat(Style:=OperationFormatStyle.Document)&gt;<br>
&nbsp; &nbsp; &nbsp;Sub Notify(ByVal eventXml As String, ByVal tfsIdentityXml As String)<br>
&nbsp; &nbsp;End Interface<br>
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
&nbsp; expose a service for use</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">     Using host As New ServiceHost(GetType(CheckinEventService))
           host.Open()
           Console.WriteLine(host.BaseAddresses.First())

           Console.WriteLine(&quot;Press &lt;Enter&gt; to exit...&quot;)
           Console.ReadLine()
       End Using</pre>
<div class="preview">
<pre id="codePreview" class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;host&nbsp;As&nbsp;New&nbsp;ServiceHost(GetType(CheckinEventService))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(host.BaseAddresses.First())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Press&nbsp;&lt;Enter&gt;&nbsp;to&nbsp;exit...&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using<br></pre>
</div>
</div>
</div>
<p>&nbsp;&nbsp;&nbsp; In the configuration file, make sure this WCF service use wsHttpBinding and security mode<br>
&nbsp;&nbsp;&nbsp;&nbsp;is None.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">    &lt;system.serviceModel&gt;
   &lt;bindings&gt;
     &lt;wsHttpBinding&gt;
       &lt;binding name=&quot;EventService&quot;&gt;
         &lt;security mode=&quot;None&quot;&gt;&lt;/security&gt;
       &lt;/binding&gt;
     &lt;/wsHttpBinding&gt;
   &lt;/bindings&gt;
   &lt;behaviors&gt;
     &lt;serviceBehaviors&gt;
       &lt;behavior name=&quot;EventServiceBehavior&quot;&gt;
         &lt;serviceMetadata httpGetEnabled=&quot;true&quot;/&gt;
         &lt;serviceDebug includeExceptionDetailInFaults=&quot;true&quot;/&gt;
       &lt;/behavior&gt;
     &lt;/serviceBehaviors&gt;
   &lt;/behaviors&gt;
   &lt;services&gt;
     &lt;service behaviorConfiguration=&quot;EventServiceBehavior&quot; name=&quot;VBTFSEventListener.CheckinEventService&quot;&gt;
       &lt;endpoint address=&quot;&quot; binding=&quot;wsHttpBinding&quot; bindingConfiguration=&quot;EventService&quot; contract=&quot;VBTFSEventListener.IEventService&quot;/&gt;
       &lt;endpoint address=&quot;mex&quot; binding=&quot;mexHttpBinding&quot; contract=&quot;IMetadataExchange&quot;/&gt;
       &lt;host&gt;
         &lt;baseAddresses&gt;
           &lt;add baseAddress=&quot;http://localhost:8732/VBTFSEventListener/EventService/'&gt;http://localhost:8732/VBTFSEventListener/EventService/&quot;/&gt;
         &lt;/baseAddresses&gt;
       &lt;/host&gt;
     &lt;/service&gt;
   &lt;/services&gt;
 &lt;/system.serviceModel&gt;</pre>
<div class="preview">
<pre id="codePreview" class="xaml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;system</span>.serviceModel<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;bindings</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;wsHttpBinding</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;binding</span>&nbsp;<span class="xaml__attr_name">name</span>=<span class="xaml__attr_value">&quot;EventService&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;security</span>&nbsp;<span class="xaml__attr_name">mode</span>=<span class="xaml__attr_value">&quot;None&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/security&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/binding&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/wsHttpBinding&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/bindings&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;behaviors</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;serviceBehaviors</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;behavior</span>&nbsp;<span class="xaml__attr_name">name</span>=<span class="xaml__attr_value">&quot;EventServiceBehavior&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;serviceMetadata</span>&nbsp;<span class="xaml__attr_name">httpGetEnabled</span>=<span class="xaml__attr_value">&quot;true&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;serviceDebug</span>&nbsp;<span class="xaml__attr_name">includeExceptionDetailInFaults</span>=<span class="xaml__attr_value">&quot;true&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/behavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/serviceBehaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/behaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;services</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;service</span>&nbsp;<span class="xaml__attr_name">behaviorConfiguration</span>=<span class="xaml__attr_value">&quot;EventServiceBehavior&quot;</span>&nbsp;<span class="xaml__attr_name">name</span>=<span class="xaml__attr_value">&quot;VBTFSEventListener.CheckinEventService&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;endpoint</span>&nbsp;<span class="xaml__attr_name">address</span>=<span class="xaml__attr_value">&quot;&quot;</span>&nbsp;<span class="xaml__attr_name">binding</span>=<span class="xaml__attr_value">&quot;wsHttpBinding&quot;</span>&nbsp;<span class="xaml__attr_name">bindingConfiguration</span>=<span class="xaml__attr_value">&quot;EventService&quot;</span>&nbsp;<span class="xaml__attr_name">contract</span>=<span class="xaml__attr_value">&quot;VBTFSEventListener.IEventService&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;endpoint</span>&nbsp;<span class="xaml__attr_name">address</span>=<span class="xaml__attr_value">&quot;mex&quot;</span>&nbsp;<span class="xaml__attr_name">binding</span>=<span class="xaml__attr_value">&quot;mexHttpBinding&quot;</span>&nbsp;<span class="xaml__attr_name">contract</span>=<span class="xaml__attr_value">&quot;IMetadataExchange&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;host</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;baseAddresses</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;add</span>&nbsp;baseAddress=&quot;http://localhost:8732/VBTFSEventListener/EventService/'<span class="xaml__tag_start">&gt;</span>http://localhost:8732/VBTFSEventListener/EventService/&quot;<span class="xaml__tag_end">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/baseAddresses&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/host&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/service&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/services&gt;</span>&nbsp;
&nbsp;&lt;/system.serviceModel&gt;</pre>
</div>
</div>
</div>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Team Foundation Server Event Service<br>
<a href="http://msdn.microsoft.com/en-us/magazine/cc507647.aspx" target="_blank">http://msdn.microsoft.com/en-us/magazine/cc507647.aspx</a><br>
<br>
CheckinEvent Class<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.versioncontrol.common.checkinevent.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.versioncontrol.common.checkinevent.aspx</a><br>
<br>
ServiceHost Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
