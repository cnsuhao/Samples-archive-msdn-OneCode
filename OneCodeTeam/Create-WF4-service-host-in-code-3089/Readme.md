# Create WF4 service host in code (CSWF4ServiceHostFactory)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WF
## Topics
* Service Host
* WorkflowServiceHost
## IsPublished
* True
## ModifiedDate
* 2011-11-03 08:42:19
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>WF4/WCF APPLICATION : CSWF4ServiceHostFactory</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New">By using WorkflowServiceHost class, we can create a WF4 service host in code. The advantage of using WorkflowServiceHost is that we can add our own workflow extensions, tracking participant and persistence store.</p>
<p>So question is: can we use our own WorkflowServiceHost in IIS7 like we did in the console application? This sample is for answering this question.</p>
<p>To run the sample:<br>
1. Open CSWF4ServiceHostFactory.sln with Visual Studio 2010<br>
2. Press Ctrl&#43;F5.</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
1. Visual Studio 2010<br>
2. .NET Framework 4.0<br>
3. Sql Server<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1.Create a Workflow Service project named CSWF4ServiceHostFactory.<br>
2.Add assembly references to:<br>
&nbsp; System.Workflow.Runtime<br>
&nbsp; System.Workflow.Activities<br>
&nbsp; System.ServiceModel.Activation<br>
&nbsp; System.Configuration<br>
&nbsp; System.Activities.DurableInstancing<br>
&nbsp; System.Runtime.DurableInstancing<br>
3.Setup WF4 sql persistence store. <br>
&nbsp; <a href="http://msdn.microsoft.com/en-us/library/ee395773.aspx">http://msdn.microsoft.com/en-us/library/ee395773.aspx</a><br>
&nbsp; name the persistence database:WF4PersistenceDB.<br>
4.add the following configuration to web.config file right under &lt;configuration&gt; node.</p>
<p style="font-family:Courier New"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden"> &lt;appSettings&gt;
    &lt;add key=&quot;SqlWF4PersistenceConnectionString&quot; 
   value=&quot;Data Source=.\sqlexpress;Initial Catalog=WF4PersistenceDB;Integrated Security=True&quot; /&gt;
 &lt;/appSettings&gt;
</pre>
<div class="preview">
<pre class="xml">&nbsp;<span class="xml__tag_start">&lt;appSettings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;SqlWF4PersistenceConnectionString&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;Data&nbsp;Source=.\sqlexpress;Initial&nbsp;Catalog=WF4PersistenceDB;Integrated&nbsp;Security=True&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;<span class="xml__tag_end">&lt;/appSettings&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">5.Create a code file named MyServiceHostFactory.cs</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> using System;
 using System.Collections.Generic;
 using System.Workflow.Activities;
 using System.Activities;
 using System.Workflow.Runtime;
 using System.ServiceModel.Activities.Activation;
 using System.ServiceModel.Activities;
 using System.ServiceModel.Description;
 using System.Activities.DurableInstancing;
 using System.Configuration;
 
 namespace CSWF4ServiceHostFactory
 {
  public class MyServiceHostFactory : 
    System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory 
  {
   protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service,
                    Uri[] baseAddresses) 
   {
    WorkflowServiceHost host = 
     base.CreateWorkflowServiceHost(service, baseAddresses);
    string connectionString = 
     ConfigurationManager.AppSettings[&quot;SqlWF4PersistenceConnectionString&quot;].ToString();
    SqlWorkflowInstanceStore instanceStore = 
     new SqlWorkflowInstanceStore(connectionString);
    instanceStore.InstanceCompletionAction = 
     InstanceCompletionAction.DeleteNothing;
    host.DurableInstancingOptions.InstanceStore = instanceStore;
    return host;
   }
  }
 }
</pre>
<div class="preview">
<pre class="js">&nbsp;using&nbsp;System;&nbsp;
&nbsp;using&nbsp;System.Collections.Generic;&nbsp;
&nbsp;using&nbsp;System.Workflow.Activities;&nbsp;
&nbsp;using&nbsp;System.Activities;&nbsp;
&nbsp;using&nbsp;System.Workflow.Runtime;&nbsp;
&nbsp;using&nbsp;System.ServiceModel.Activities.Activation;&nbsp;
&nbsp;using&nbsp;System.ServiceModel.Activities;&nbsp;
&nbsp;using&nbsp;System.ServiceModel.Description;&nbsp;
&nbsp;using&nbsp;System.Activities.DurableInstancing;&nbsp;
&nbsp;using&nbsp;System.Configuration;&nbsp;
&nbsp;&nbsp;
&nbsp;namespace&nbsp;CSWF4ServiceHostFactory&nbsp;
&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;public&nbsp;class&nbsp;MyServiceHostFactory&nbsp;:&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;System.ServiceModel.Activities.Activation.WorkflowServiceHostFactory&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;WorkflowServiceHost&nbsp;CreateWorkflowServiceHost(WorkflowService&nbsp;service,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri[]&nbsp;baseAddresses)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WorkflowServiceHost&nbsp;host&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.CreateWorkflowServiceHost(service,&nbsp;baseAddresses);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;connectionString&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationManager.AppSettings[<span class="js__string">&quot;SqlWF4PersistenceConnectionString&quot;</span>].ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SqlWorkflowInstanceStore&nbsp;instanceStore&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;SqlWorkflowInstanceStore(connectionString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;instanceStore.InstanceCompletionAction&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InstanceCompletionAction.DeleteNothing;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;host.DurableInstancingOptions.InstanceStore&nbsp;=&nbsp;instanceStore;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;host;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">6.Open web.config file and add a ServiceHostingEnvironment node under the&nbsp;System.serviceModel.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">   &lt;serviceHostingEnvironment multipleSiteBindingsEnabled=&quot;true&quot;&gt;
  &lt;serviceActivations&gt;
   &lt;add relativeAddress=&quot;~/Service1.xamlx&quot;
      service=&quot;Service1.xamlx&quot;
      factory=&quot;CSWF4ServiceHostFactory.MyServiceHostFactory&quot;/&gt;
  &lt;/serviceActivations&gt;
 &lt;/serviceHostingEnvironment&gt;</pre>
<div class="preview">
<pre class="xml">&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceHostingEnvironment</span>&nbsp;<span class="xml__attr_name">multipleSiteBindingsEnabled</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceActivations</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">relativeAddress</span>=<span class="xml__attr_value">&quot;~/Service1.xamlx&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">service</span>=<span class="xml__attr_value">&quot;Service1.xamlx&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">factory</span>=<span class="xml__attr_value">&quot;CSWF4ServiceHostFactory.MyServiceHostFactory&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/serviceActivations&gt;</span>&nbsp;
&nbsp;<span class="xml__tag_end">&lt;/serviceHostingEnvironment&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">7.Open the default created Service1.xaml, select SendResponse activity check its PersistBeforeSend property.</div>
<div class="endscriptcode"><br>
8.Build the project and then create a IIS7 WebSite(Framework 4.0), map the physical path&nbsp;to the project path.
<br>
&nbsp; Note: To prevent that the default Application Pool identity have no permission to access the Web.config file and database, you can try shift the identity to LocalSystem.</div>
<div class="endscriptcode"><br>
9.Call Service1.xamlx. you can call it in WcfTestClient.exe.（usually, you can&nbsp;find WcfTestClient.exe in C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE）</div>
</div>
</div>
<p></p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><a href="http://xhinker.com/post/WF4Create-Your-Own-ServiceHostFactory.aspx" target="_blank">http://xhinker.com/post/WF4Create-Your-Own-ServiceHostFactory.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
