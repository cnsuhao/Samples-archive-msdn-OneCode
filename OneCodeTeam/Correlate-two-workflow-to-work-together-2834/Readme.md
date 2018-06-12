# Correlate two workflow services to work together (CSWF4ActivitiesCorrelation)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Workflow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:30:30
## Description

<p style="font-family:Courier New"></p>
<h2>WF4 APPLICATION : CSWF4ActivitiesCorrelation</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New">Consider such a workflow:<br>
&nbsp; &nbsp; &nbsp;start<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;|<br>
Receive activity<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;|<br>
Receive activity<br>
&nbsp; &nbsp; &nbsp; &nbsp;|<br>
There are two Receive activities. The first Receive activity will create a <br>
workflow instance. The second Receive activity functions as a bookmark <br>
activity. Imagine that there are two such workflow instances:<br>
&nbsp; &nbsp; &nbsp;start &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; start<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;| &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |<br>
Receive activity &nbsp; &nbsp; &nbsp;Receive activity<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;| &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |<br>
Receive activity &nbsp; &nbsp; &nbsp;Receive activity<br>
&nbsp; &nbsp; &nbsp; &nbsp;| &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |<br>
A WCF request comes to call the second Receive activity.<br>
Which one should take care of the request? We can use correlation to solve<br>
the problem.<br>
<br>
<br>
To run the sample:<br>
1. Setup WF4 persistence store according to:<br>
&nbsp; <a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">
http://msdn.microsoft.com/en-us/library/ee395773.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">http://msdn.microsoft.com/en-us/library/ee395773.aspx</a><br>
2. Open CSWF4ActivitiesCorrelation.sln with Visual Studio 2010(run as administrator).
<br>
3. Open App.config file and alter the sql connection string. <br>
4. Press Ctrl&#43;F5 to start the WF service. <br>
5. Use WCF Test Client to test the WF service.<br>
<br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
1. Visual Studio 2010<br>
2. .NET Framework 4.0<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New">1. Create a new Workflow Console Application project and name it:
<br>
&nbsp; CSWF4ActivitiesCorrelation. To create a Workflow Console Application:<br>
&nbsp; Click File|New|Visual C#|Workflow|Workflow Console Application. <br>
2. Add assembly references:<br>
&nbsp; &nbsp; &nbsp; System.Activities.DurableInstancing<br>
&nbsp; &nbsp; &nbsp; System.Configuation<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; System.Runtime.DurableInstancing<br>
3. Setup WF4 persistence store according to:<br>
&nbsp; <a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">
http://msdn.microsoft.com/en-us/library/ee395773.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">http://msdn.microsoft.com/en-us/library/ee395773.aspx</a><br>
4. Open App.config file and alter its code to: <br>
&nbsp; &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;<br>
&nbsp; &lt;configuration&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;startup&gt; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;supportedRuntime version=&quot;v4.0&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; sku=&quot;.NETFramework,Version=v4.0,Profile=Client&quot; /&gt; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp;&lt;/startup&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&lt;system.serviceModel&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;bindings /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;client /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;behaviors&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;serviceBehaviors&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;behavior&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;serviceDebug includeExceptionDetailInFaults=&quot;True&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpHelpPageEnabled=&quot;True&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;serviceMetadata httpGetEnabled=&quot;True&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/behavior&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/serviceBehaviors&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/behaviors&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/system.serviceModel&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;appSettings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key=&quot;SqlWF4PersistenceConnectionString&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; value=&quot;Data Source=.\sqlexpress;Initial Catalog=WF4PersistenceDB;Integrated Security=True&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/appSettings&gt;<br>
&nbsp; &lt;/configuration&gt;<br>
5. Open the default created file Workflow1.xaml,Create a workflow shown <br>
&nbsp; in the Workflow1.xaml. <br>
6. Open Program.cs file and alter its code to: <br>
using System;<br>
using System.Activities;<br>
using System.Activities.Statements;<br>
using System.Activities.DurableInstancing;<br>
using System.Configuration;<br>
using System.Threading;<br>
using System.ServiceModel.Activities;<br>
<br>
namespace CSWF4ActivitiesCorrelation<br>
{<br>
&nbsp; &nbsp;class Program<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;static void Main(string[] args)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Uri wfAddress = new Uri(@&quot;<a target="_blank" href="&lt;a target=" href="&lt;a target=" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>'&gt;<a target="_blank" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>&quot;);'&gt;<a target="_blank" href="&lt;a target=" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>'&gt;<a target="_blank" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AutoResetEvent waitHandler = new AutoResetEvent(false);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;using (WorkflowServiceHost host =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new WorkflowServiceHost(new Workflow1(), wfAddress))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;host.WorkflowExtensions.Add(SetupSimplySqlPersistenceStore());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;host.Closed &#43;= (obj, arg) =&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;waitHandler.Set();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;host.Open();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(@&quot;<a target="_blank" href="&lt;a target=" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>'&gt;<a target="_blank" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a>
 is opening&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;waitHandler.WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private static SqlWorkflowInstanceStore SetupSimplySqlPersistenceStore()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string connectionString =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ConfigurationManager.AppSettings[&quot;SqlWF4PersistenceConnectionString&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SqlWorkflowInstanceStore sqlInstanceStore =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new SqlWorkflowInstanceStore(connectionString);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sqlInstanceStore.HostLockRenewalPeriod = TimeSpan.FromSeconds(30);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return sqlInstanceStore;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
7. Press Ctrl&#43;F5 to start the service. <br>
8. Use WCF Test Client to test the service.<br>
&nbsp; Add service address <a target="_blank" href="&lt;a target=" href="http://localhost:8000/WFServices">
http://localhost:8000/WFServices</a>'&gt;<a target="_blank" href="http://localhost:8000/WFServices">http://localhost:8000/WFServices</a> to the WCF Test Client
<br>
&nbsp; then, Double Click StartWF(), invoke with any string, say, &quot;aaa&quot;. after<br>
&nbsp; pressing the Invoke button, you shall see &quot;Hello&quot; printed in the service
<br>
&nbsp; console window. next, click ResumeWorkflow() in WCF Test Client. Invoke<br>
&nbsp; the method with the string &quot;aaa&quot;. and only by &quot;aaa&quot; you then can resume
<br>
&nbsp; the persisted workflow. <br>
<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><a target="_blank" href="http://sharepoint/sites/cfx/workspace/Lists/Samples/AllItems.aspx">http://sharepoint/sites/cfx/workspace/Lists/Samples/AllItems.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
