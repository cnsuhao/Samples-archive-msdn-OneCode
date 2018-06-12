# Correlate two workflow services to work together
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Workflow
* .NET Development
## Topics
* Receive Activity
## IsPublished
* True
## ModifiedDate
* 2013-08-05 12:44:42
## Description

<h1>Correlate two workflow services to work together (VBWF4ActivitiesCorrelation)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Consider such a workflow:</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Start<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp; </span>|<br>
<span style="">&nbsp;</span>Receive activity<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp; </span>|<br>
<span style="">&nbsp;</span>Receive activity<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>|</p>
<p class="MsoNormal">There are two Receive activities. The first Receive activity will create a workflow instance. The second Receive activity functions as a bookmark activity. Imagine that there are two such workflow instances:</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>start<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>start</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp; </span>
|<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>|</p>
<p class="MsoNormal"><span style="">&nbsp;</span>Receive activity<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Receive activity</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp; </span>
|<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>|</p>
<p class="MsoNormal"><span style="">&nbsp;</span>Receive activity<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Receive activity</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>|<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>|</p>
<p class="MsoNormal">A WCF request comes to call the second Receive activity.<br>
Which one should take care of the request? We can use correlation to solve the problem.<span style="">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Setup WF4 persistence store according to:<br>
<span style="">&nbsp;&nbsp; </span><a href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">http://msdn.microsoft.com/en-us/library/ee395773.aspx</a>.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open VBWF4ActivitiesCorrelation.sln with Visual Studio.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open App.config file and alter the sql connection string.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 to start the WF service.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/93824/1/image.png" alt="" width="460" height="24" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use WCF Test Client to test the WF service.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/93825/1/image.png" alt="" width="446" height="156" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new Workflow Console Application project and name it:<span style="">&nbsp;&nbsp;&nbsp;
</span>VBWF4ActivitiesCorrelation. To create a Workflow Console Application:</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp; </span>Click File|New|Visual VB|Workflow|Workflow Console Application.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add assembly references:</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp;</span>System.Activities.DurableInstancing</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp;</span>System.Configuation</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp;</span>System.Runtime.DurableInstancing:</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Setup WF4 persistence store according to:</p>
<p class="MsoListParagraphCxSpMiddle"><a href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">http://msdn.microsoft.com/en-us/library/ee395773.aspx</a>.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open App.config file and alter its code to:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&nbsp;&nbsp; &lt;configuration&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;startup&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;supportedRuntime version=&quot;v4.0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sku=&quot;.NETFramework,Version=v4.0,Profile=Client&quot; /&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/startup&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;system.serviceModel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;bindings /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;client /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceDebug includeExceptionDetailInFaults=&quot;True&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpHelpPageEnabled=&quot;True&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceMetadata httpGetEnabled=&quot;True&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/system.serviceModel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;appSettings&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SqlWF4PersistenceConnectionString&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value=&quot;Data Source=.\sqlexpress;Initial Catalog=WF4PersistenceDB;Integrated Security=True&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/appSettings&gt;
&nbsp;&nbsp; &lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&nbsp;&nbsp; &lt;configuration&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;startup&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;supportedRuntime version=&quot;v4.0&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sku=&quot;.NETFramework,Version=v4.0,Profile=Client&quot; /&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/startup&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;system.serviceModel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;bindings /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;client /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceDebug includeExceptionDetailInFaults=&quot;True&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpHelpPageEnabled=&quot;True&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;serviceMetadata httpGetEnabled=&quot;True&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/behavior&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/serviceBehaviors&gt;
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/behaviors&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/system.serviceModel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;appSettings&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SqlWF4PersistenceConnectionString&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value=&quot;Data Source=.\sqlexpress;Initial Catalog=WF4PersistenceDB;Integrated Security=True&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/appSettings&gt;
&nbsp;&nbsp; &lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open the default created file Workflow1.xaml,Create a workflow shown
</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp;&nbsp; </span>in the Workflow1.xaml.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open MainModule.vb file and alter its code to:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wfAddress As New Uri(&quot;http://localhost:8000/WFServices&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim waitHandler As New AutoResetEvent(False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using host As New WorkflowServiceHost(New Workflow1(), wfAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; host.WorkflowExtensions.Add(SetupSimplySqlPersistenceStore())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler host.Closed, Function(obj, arg) waitHandler.Set()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; host.Open()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;http://localhost:8000/WFServices is opening&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; waitHandler.WaitOne()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Private Function SetupSimplySqlPersistenceStore() As SqlWorkflowInstanceStore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim connectionString As String =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ConfigurationManager.AppSettings(&quot;SqlWF4PersistenceConnectionString&quot;).ToString()
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim sqlInstanceStore As SqlWorkflowInstanceStore =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New SqlWorkflowInstanceStore(connectionString)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sqlInstanceStore.HostLockRenewalPeriod = TimeSpan.FromSeconds(30)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return sqlInstanceStore
&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wfAddress As New Uri(&quot;http://localhost:8000/WFServices&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim waitHandler As New AutoResetEvent(False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using host As New WorkflowServiceHost(New Workflow1(), wfAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; host.WorkflowExtensions.Add(SetupSimplySqlPersistenceStore())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler host.Closed, Function(obj, arg) waitHandler.Set()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; host.Open()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;http://localhost:8000/WFServices is opening&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; waitHandler.WaitOne()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Private Function SetupSimplySqlPersistenceStore() As SqlWorkflowInstanceStore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim connectionString As String =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ConfigurationManager.AppSettings(&quot;SqlWF4PersistenceConnectionString&quot;).ToString()
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim sqlInstanceStore As SqlWorkflowInstanceStore =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New SqlWorkflowInstanceStore(connectionString)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sqlInstanceStore.HostLockRenewalPeriod = TimeSpan.FromSeconds(30)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return sqlInstanceStore
&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 to start the service.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use WCF Test Client to test the service.</p>
<p class="MsoListParagraphCxSpMiddle"><span style="">&nbsp;&nbsp; </span>Add service address http://localhost:8000/WFServices to the WCF Test Client
</p>
<p class="MsoListParagraphCxSpLast"><span style="">&nbsp; </span>Then, Double Click StartWF(), invoke with any string, say, &quot;aaa&quot;. After pressing the Invoke button, you shall see &quot;Hello&quot; printed in the service<span style="">&nbsp;&nbsp;&nbsp;
</span>console window. Next, click ResumeWorkflow() in WCF Test Client. Invoke<span style="">&nbsp;&nbsp;
</span>the method with the string &quot;aaa&quot;. And only by &quot;aaa&quot; you then can resume<span style="">&nbsp;&nbsp;&nbsp;
</span>the persisted workflow...<br style="">
<br style="">
<span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
