# How to load local assembly in WF4
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* .NET Framework
* Windows Workflow Foundation
## Topics
* WF
* Assembly
## IsPublished
* True
## ModifiedDate
* 2015-02-02 06:08:32
## Description

<h1>The project illustrates how to load local assembly in WF4</h1>
<h2>Introduction</h2>
<p>The project illustrates how to load activity from local assembly in WF4.</p>
<p>Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<ol>
<li>Runtime ERROR received when a xaml activity references another activity in an Activity Library assembly...
</li></ol>
<p><a href="http://social.msdn.microsoft.com/Forums/en-US/wfprerelease/thread/d16a383a-cb04-4fbc-a603-cda5cff9056a">http://social.msdn.microsoft.com/Forums/en-US/wfprerelease/thread/d16a383a-cb04-4fbc-a603-cda5cff9056a</a></p>
<ol>
<li>Why can I not load a workflow using ActivityXamlServices.Load when it contains a custom activity?
</li></ol>
<p><a href="http://social.msdn.microsoft.com/Forums/en/wfprerelease/thread/0086f55d-3ed1-4015-90ca-ad8144178255">http://social.msdn.microsoft.com/Forums/en/wfprerelease/thread/0086f55d-3ed1-4015-90ca-ad8144178255</a></p>
<p>&nbsp;</p>
<h2>Building the Project</h2>
<p>&nbsp;</p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating a c# console application (CSLoadAssemblyWF4)</strong></p>
<ol>
<li>Create a workflow console application in visual studio 2010 </li><li>Remove workflow1.xaml </li><li>Add another project of template Activity workflow library </li><li>Remove Acitivty1.xaml </li><li>Add new item activity, named SampleActivity </li><li>Drag &ldquo;WriteLine&rdquo; primitive on to the user graphic space </li><li>Build it and make it available on parent project via reference </li><li>Modify the Main() content </li></ol>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden"> // Sepcify LocalAssembly in XamlXmlReaderSettings

            XamlReader reader = new XamlXmlReader(@&quot;..\..\..\ActivityLibrarySample\SampleActivity.xaml&quot;, new XamlXmlReaderSettings { LocalAssembly = typeof(ActivityLibrarySample.SampleActivity).Assembly });

 

            // Read the xaml contents

            XamlReader xamlReader = ActivityXamlServices.CreateReader(reader);

 

            // Invoke the workflow XAML data

            WorkflowInvoker.Invoke(ActivityXamlServices.Load(xamlReader));</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">//&nbsp;Sepcify&nbsp;LocalAssembly&nbsp;in&nbsp;XamlXmlReaderSettings</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XamlReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XamlXmlReader(@<span class="cs__string">&quot;..\..\..\ActivityLibrarySample\SampleActivity.xaml&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;XamlXmlReaderSettings&nbsp;{&nbsp;LocalAssembly&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(ActivityLibrarySample.SampleActivity).Assembly&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Read&nbsp;the&nbsp;xaml&nbsp;contents</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XamlReader&nbsp;xamlReader&nbsp;=&nbsp;ActivityXamlServices.CreateReader(reader);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Invoke&nbsp;the&nbsp;workflow&nbsp;XAML&nbsp;data</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WorkflowInvoker.Invoke(ActivityXamlServices.Load(xamlReader));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<h2>Running the Sample</h2>
<ol>
<li>Run the sample </li><li>Output should look like the following: </li></ol>
<p>&nbsp;<img id="133296" src="/windowsapps/site/view/file/133296/1/image002.jpg" alt="" width="575" height="92"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
