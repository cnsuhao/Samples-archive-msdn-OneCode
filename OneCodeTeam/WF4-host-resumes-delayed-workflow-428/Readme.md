# WF4 host resumes delayed workflow (CSWF4LongRunningHost)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Windows Workflow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:31:25
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSWF4LongRunningHost</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
In WF3, when a workflow is delayed and persisted in persistence store, <br>
after the timer expired, workflow will resume from database automatically.<br>
Now in WF4, we have to resume a persisted workflow manually, So can we create <br>
a long running WF4 that can monitor a delayed workflow and resume a workflow<br>
automatically after the delay timer expired? this sample include a host that <br>
can do this. <br>
<br>
To run the sample:<br>
1. Sql Server 2005/2008(or express edition);<br>
2. Setup WF4 sql workflow persistence store according to this MSDN document:<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">
http://msdn.microsoft.com/en-us/library/ee395773.aspx</a><br>
3. Open CSWF4SequenceWF.sln with Visual Studio 2010<br>
4. Add sql workflow persistence store connection string to App.config file:<br>
&nbsp; &nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;<br>
&nbsp; &nbsp;&lt;configuration&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;appSettings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;add key=&quot;SqlWF4PersistenceConnectionString&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; value=&quot;Data Source=.\sqlexpress;Initial Catalog=WF4PersistenceDB;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Integrated Security=True&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;/appSettings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;startup&gt; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;supportedRuntime version=&quot;v4.0&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; sku=&quot;.NETFramework,Version=v4.0,Profile=Client&quot; /&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/startup&gt;<br>
&nbsp; &nbsp;&lt;/configuration&gt;<br>
5. Press Ctrl&#43;F5.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1.Create a Workflow Console Application and name it CSWF4LongRunningHost;<br>
<br>
2.Add assemble references:<br>
&nbsp;a. System.Activities.DurableInstancing. <br>
&nbsp;b. System.Runtime.DurableInstancing. <br>
&nbsp;c. System.Configuration. <br>
<br>
2.Create a workflow as shown in Workflow1.xaml file<br>
<br>
3.Add a new code file to the project named LongRunningHost.cs and fill the <br>
&nbsp;file with following code:<br>
&nbsp; &nbsp;using System;<br>
&nbsp; &nbsp;using System.Collections.Generic;<br>
&nbsp; &nbsp;using System.Activities;<br>
&nbsp; &nbsp;using System.Threading;<br>
&nbsp; &nbsp;using System.Xml.Linq;<br>
&nbsp; &nbsp;using System.Activities.DurableInstancing;<br>
&nbsp; &nbsp;using System.Runtime.DurableInstancing;<br>
&nbsp; &nbsp;using System.Configuration;<br>
<br>
&nbsp; &nbsp;namespace CSWF4LongRunningHost {<br>
&nbsp; &nbsp; &nbsp; &nbsp;public class LongRunningWFHost {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Activity workflow = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ManualResetEvent waitHandler = new ManualResetEvent(false);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;static XName wfHostTypeName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool completed = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private static readonly XName WorkflowHostTypePropertyName =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;XNamespace.Get(&quot;urn:schemas-microsoft-com:System.Activities/4.0/properties&quot;).<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetName(&quot;WorkflowHostType&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SqlWorkflowInstanceStore instanceStore = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InstanceHandle instanceHandle = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public LongRunningWFHost(Activity workflow) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.workflow = workflow;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void Run() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfHostTypeName = XName.Get(&quot;Version&quot; &#43; Guid.NewGuid().ToString(),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; typeof(Workflow1).FullName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.instanceStore = SetupSqlpersistenceStore();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.instanceHandle =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CreateInstanceStoreOwnerHandle(instanceStore, wfHostTypeName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WorkflowApplication wfApp = CreateWorkflowApp();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.Run();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;while (true) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.waitHandler.WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (completed) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WaitForRunnableInstance(this.instanceHandle);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp = CreateWorkflowApp();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.LoadRunnableInstance();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;waitHandler.Reset();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.Run();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;} catch (InstanceNotReadyException) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;Handled expected InstanceNotReadyException, retrying...&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;workflow completed.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void WaitForRunnableInstance(InstanceHandle handle) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var events = instanceStore.WaitForEvents(handle, TimeSpan.MaxValue);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool foundRunnable = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (var persistenceEvent in events) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (persistenceEvent.Equals(HasRunnableWorkflowEvent.Value)) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foundRunnable = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!foundRunnable) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;no runnable instance&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public WorkflowApplication CreateWorkflowApp() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WorkflowApplication wfApp = new WorkflowApplication(workflow);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.InstanceStore = this.instanceStore;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dictionary&lt;XName, object&gt; wfScope = new Dictionary&lt;XName, object&gt;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ WorkflowHostTypePropertyName, wfHostTypeName }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.AddInitialInstanceValues(wfScope);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.Unloaded = (e) =&gt; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;Unloaded&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.waitHandler.Set();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.Completed = (e) =&gt; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.completed = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.PersistableIdle = (e) =&gt; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return PersistableIdleAction.Unload;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;wfApp.Aborted = delegate(WorkflowApplicationAbortedEventArgs abortArgs) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Console.WriteLine(&quot;Workflow aborted (expected in this sample)&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return wfApp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private SqlWorkflowInstanceStore SetupSqlpersistenceStore() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string connectionString =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ConfigurationManager.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AppSettings[&quot;SqlWF4PersistenceConnectionString&quot;].ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SqlWorkflowInstanceStore sqlWFInstanceStore =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new SqlWorkflowInstanceStore(connectionString);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return sqlWFInstanceStore;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private static InstanceHandle CreateInstanceStoreOwnerHandle(InstanceStore store,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; XName
 wfHostTypeName) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InstanceHandle ownerHandle = store.CreateInstanceHandle();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CreateWorkflowOwnerCommand ownerCommand =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new CreateWorkflowOwnerCommand() {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InstanceOwnerMetadata = {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; { WorkflowHostTypePropertyName,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; new InstanceValue(wfHostTypeName) }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;store.DefaultInstanceOwner = store.Execute(ownerHandle,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ownerCommand,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TimeSpan.FromSeconds(30)).InstanceOwner;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return ownerHandle;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
4. Open Program.cs file, alter its code to:<br>
&nbsp; &nbsp;using System;<br>
&nbsp; &nbsp;using System.Activities;<br>
&nbsp; &nbsp;using System.Activities.Statements;<br>
&nbsp; &nbsp;namespace CSWF4LongRunningHost {<br>
&nbsp; &nbsp; &nbsp; &nbsp;class Program {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;static void Main(string[] args) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LongRunningWFHost host = new LongRunningWFHost(new Workflow1());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;host.Run();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><br>
Absolute Delay<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff522352.aspx">http://msdn.microsoft.com/en-us/library/ff522352.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
