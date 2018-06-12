# Merge the Config file for Referenced Managed DLL (CSMergeConfig)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* XML
* .NET Framework
## Topics
* LINQ to XML
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:54:30
## Description

<h1>Merging the configuration file for a referenced managed <span class="SpellE">
dll</span> with the console application (<span class="SpellE">CSMergeConfig</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This program is a generic sample for a scenario where the <span class="SpellE">
config</span> file of the <span class="SpellE">dll</span> needs to be merged with the Console application so that the Configuration of the class library (contains reference to service) can be accessed during application run to initialize the class.</p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Purpose<span style="">&nbsp;&nbsp; </span>of the sample:</p>
<p class="MsoNormal" style="text-indent:.5in">Merging the configuration file for a referenced managed
<span class="SpellE">dll</span> with the console application such that the Specified Section from the
<span class="SpellE">config</span> file of Class Library will be merged with the console application.
</p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Why do we need to merge the <span class="SpellE">config</span> file?
</p>
<p class="MsoNormal" style="margin-left:.5in">By default, only the <span class="SpellE">
config</span> file of the executable will be accessed during runtime. If we need to load a class Library that has a service reference, the respective
<span class="SpellE">dll.config</span> file cannot be accessed which will result in a
<span class="SpellE">System.Reflection.TargetInvocationException</span>. So, to avoid there has been lot of request from our customers to provide a way to merge the
<span class="SpellE">config</span> file such that we will be able to access the
<span class="SpellE">config</span> file of the application and still be able to initialize.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">We first load the two <span class="SpellE">config</span> files and then merge them.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
var doc = XElement.Load(@&quot;ServiceReferenceddll.dll.config&quot;);


var query = from ele in doc.Elements(&quot;system.serviceModel&quot;)
            select ele;


var doc1 = XElement.Load(@&quot;..\CSMergeConfig\App.config&quot;);


var node1 = doc.Descendants(&quot;system.serviceModel&quot;).FirstOrDefault();
var node2 = doc1.Descendants(&quot;system.serviceModel&quot;).FirstOrDefault();


XNode node = doc1.Element(&quot;system.serviceModel&quot;);


// Lets iterate the node of the console until the last node is reached 
if (!XElement.DeepEquals(node1, node2))
{
    node2.Add(node1.Nodes());
    doc1.Save(@&quot;..\CSMergeConfig\App.config&quot;);
}

</pre>
<pre id="codePreview" class="csharp">
var doc = XElement.Load(@&quot;ServiceReferenceddll.dll.config&quot;);


var query = from ele in doc.Elements(&quot;system.serviceModel&quot;)
            select ele;


var doc1 = XElement.Load(@&quot;..\CSMergeConfig\App.config&quot;);


var node1 = doc.Descendants(&quot;system.serviceModel&quot;).FirstOrDefault();
var node2 = doc1.Descendants(&quot;system.serviceModel&quot;).FirstOrDefault();


XNode node = doc1.Element(&quot;system.serviceModel&quot;);


// Lets iterate the node of the console until the last node is reached 
if (!XElement.DeepEquals(node1, node2))
{
    node2.Add(node1.Nodes());
    doc1.Save(@&quot;..\CSMergeConfig\App.config&quot;);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">These are the inputs: </p>
<p class="MsoNormal">First <span class="SpellE">config</span> <span class="GramE">
file :</span> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
    &lt;system.serviceModel&gt;
        &lt;bindings&gt;
            &lt;basicHttpBinding&gt;
                &lt;binding name=&quot;BasicHttpBinding_IService&quot; closeTimeout=&quot;00:01:00&quot;
                    openTimeout=&quot;00:01:00&quot; receiveTimeout=&quot;00:10:00&quot; sendTimeout=&quot;00:01:00&quot;
                    allowCookies=&quot;false&quot; bypassProxyOnLocal=&quot;false&quot; hostNameComparisonMode=&quot;StrongWildcard&quot;
                    maxBufferSize=&quot;65536&quot; maxBufferPoolSize=&quot;524288&quot; maxReceivedMessageSize=&quot;65536&quot;
                    messageEncoding=&quot;Text&quot; textEncoding=&quot;utf-8&quot; transferMode=&quot;Buffered&quot;
                    useDefaultWebProxy=&quot;true&quot;&gt;
                    &lt;readerQuotas maxDepth=&quot;32&quot; maxStringContentLength=&quot;8192&quot; maxArrayLength=&quot;16384&quot;
                        maxBytesPerRead=&quot;4096&quot; maxNameTableCharCount=&quot;16384&quot; /&gt;
                    &lt;security mode=&quot;None&quot;&gt;
                        &lt;transport clientCredentialType=&quot;None&quot; proxyCredentialType=&quot;None&quot;
                            realm=&quot;&quot; /&gt;
                        &lt;message clientCredentialType=&quot;UserName&quot; algorithmSuite=&quot;Default&quot; /&gt;
                    &lt;/security&gt;
                &lt;/binding&gt;
            &lt;/basicHttpBinding&gt;
        &lt;/bindings&gt;
        &lt;client&gt;
            &lt;endpoint address=&quot;http://localhost/WCFService/Service.svc&quot; binding=&quot;basicHttpBinding&quot;
                bindingConfiguration=&quot;BasicHttpBinding_IService&quot; contract=&quot;ServiceReference1.IService&quot;
                name=&quot;BasicHttpBinding_IService&quot; /&gt;
        &lt;/client&gt;
    &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
    &lt;system.serviceModel&gt;
        &lt;bindings&gt;
            &lt;basicHttpBinding&gt;
                &lt;binding name=&quot;BasicHttpBinding_IService&quot; closeTimeout=&quot;00:01:00&quot;
                    openTimeout=&quot;00:01:00&quot; receiveTimeout=&quot;00:10:00&quot; sendTimeout=&quot;00:01:00&quot;
                    allowCookies=&quot;false&quot; bypassProxyOnLocal=&quot;false&quot; hostNameComparisonMode=&quot;StrongWildcard&quot;
                    maxBufferSize=&quot;65536&quot; maxBufferPoolSize=&quot;524288&quot; maxReceivedMessageSize=&quot;65536&quot;
                    messageEncoding=&quot;Text&quot; textEncoding=&quot;utf-8&quot; transferMode=&quot;Buffered&quot;
                    useDefaultWebProxy=&quot;true&quot;&gt;
                    &lt;readerQuotas maxDepth=&quot;32&quot; maxStringContentLength=&quot;8192&quot; maxArrayLength=&quot;16384&quot;
                        maxBytesPerRead=&quot;4096&quot; maxNameTableCharCount=&quot;16384&quot; /&gt;
                    &lt;security mode=&quot;None&quot;&gt;
                        &lt;transport clientCredentialType=&quot;None&quot; proxyCredentialType=&quot;None&quot;
                            realm=&quot;&quot; /&gt;
                        &lt;message clientCredentialType=&quot;UserName&quot; algorithmSuite=&quot;Default&quot; /&gt;
                    &lt;/security&gt;
                &lt;/binding&gt;
            &lt;/basicHttpBinding&gt;
        &lt;/bindings&gt;
        &lt;client&gt;
            &lt;endpoint address=&quot;http://localhost/WCFService/Service.svc&quot; binding=&quot;basicHttpBinding&quot;
                bindingConfiguration=&quot;BasicHttpBinding_IService&quot; contract=&quot;ServiceReference1.IService&quot;
                name=&quot;BasicHttpBinding_IService&quot; /&gt;
        &lt;/client&gt;
    &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Second <span class="SpellE">config</span> file -- <span class="SpellE">
app.config</span> of the Console application that needs to be merged with the specific node from the
<span class="SpellE">ServiceReferenceddll.dll.config</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;


  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;


  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Expected output -- <span class="SpellE">App.config</span> of
<span class="SpellE">consoleApplication</span> has the following output: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;
    &lt;bindings&gt;
      &lt;basicHttpBinding&gt;
        &lt;binding name=&quot;BasicHttpBinding_IService&quot; closeTimeout=&quot;00:01:00&quot; openTimeout=&quot;00:01:00&quot; receiveTimeout=&quot;00:10:00&quot; sendTimeout=&quot;00:01:00&quot; allowCookies=&quot;false&quot; bypassProxyOnLocal=&quot;false&quot; hostNameComparisonMode=&quot;StrongWildcard&quot; maxBufferSize=&quot;65536&quot; maxBufferPoolSize=&quot;524288&quot; maxReceivedMessageSize=&quot;65536&quot; messageEncoding=&quot;Text&quot; textEncoding=&quot;utf-8&quot; transferMode=&quot;Buffered&quot; useDefaultWebProxy=&quot;true&quot;&gt;
          &lt;readerQuotas maxDepth=&quot;32&quot; maxStringContentLength=&quot;8192&quot; maxArrayLength=&quot;16384&quot; maxBytesPerRead=&quot;4096&quot; maxNameTableCharCount=&quot;16384&quot; /&gt;
          &lt;security mode=&quot;None&quot;&gt;
            &lt;transport clientCredentialType=&quot;None&quot; proxyCredentialType=&quot;None&quot; realm=&quot;&quot; /&gt;
            &lt;message clientCredentialType=&quot;UserName&quot; algorithmSuite=&quot;Default&quot; /&gt;
          &lt;/security&gt;
        &lt;/binding&gt;
      &lt;/basicHttpBinding&gt;
    &lt;/bindings&gt;
    &lt;client&gt;
      &lt;endpoint address=&quot;http://localhost/WCFService/Service.svc&quot; binding=&quot;basicHttpBinding&quot; bindingConfiguration=&quot;BasicHttpBinding_IService&quot; contract=&quot;ServiceReference1.IService&quot; name=&quot;BasicHttpBinding_IService&quot; /&gt;
    &lt;/client&gt;
  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;
    &lt;bindings&gt;
      &lt;basicHttpBinding&gt;
        &lt;binding name=&quot;BasicHttpBinding_IService&quot; closeTimeout=&quot;00:01:00&quot; openTimeout=&quot;00:01:00&quot; receiveTimeout=&quot;00:10:00&quot; sendTimeout=&quot;00:01:00&quot; allowCookies=&quot;false&quot; bypassProxyOnLocal=&quot;false&quot; hostNameComparisonMode=&quot;StrongWildcard&quot; maxBufferSize=&quot;65536&quot; maxBufferPoolSize=&quot;524288&quot; maxReceivedMessageSize=&quot;65536&quot; messageEncoding=&quot;Text&quot; textEncoding=&quot;utf-8&quot; transferMode=&quot;Buffered&quot; useDefaultWebProxy=&quot;true&quot;&gt;
          &lt;readerQuotas maxDepth=&quot;32&quot; maxStringContentLength=&quot;8192&quot; maxArrayLength=&quot;16384&quot; maxBytesPerRead=&quot;4096&quot; maxNameTableCharCount=&quot;16384&quot; /&gt;
          &lt;security mode=&quot;None&quot;&gt;
            &lt;transport clientCredentialType=&quot;None&quot; proxyCredentialType=&quot;None&quot; realm=&quot;&quot; /&gt;
            &lt;message clientCredentialType=&quot;UserName&quot; algorithmSuite=&quot;Default&quot; /&gt;
          &lt;/security&gt;
        &lt;/binding&gt;
      &lt;/basicHttpBinding&gt;
    &lt;/bindings&gt;
    &lt;client&gt;
      &lt;endpoint address=&quot;http://localhost/WCFService/Service.svc&quot; binding=&quot;basicHttpBinding&quot; bindingConfiguration=&quot;BasicHttpBinding_IService&quot; contract=&quot;ServiceReference1.IService&quot; name=&quot;BasicHttpBinding_IService&quot; /&gt;
    &lt;/client&gt;
  &lt;/system.serviceModel&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style="">Note: </b></p>
<p class="MsoNormal">When run the application for the first time, you will see that we will get an unhandled exception of type '<span class="SpellE">System.Reflection.TargetInvocationException</span>' occurred in mscorlib.dll, along with this error, the
<span class="SpellE">config</span> will be merged. The application will run successfully post this.
</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.xml.linq.xelement.aspx">http://msdn.microsoft.com/en-us/library/system.xml.linq.xelement.aspx</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.xml.linq.xnode.nextnode.aspx">http://msdn.microsoft.com/en-us/library/system.xml.linq.xnode.nextnode.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
