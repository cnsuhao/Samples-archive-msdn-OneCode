# How to get WCF service contract programmatically from WSDL of the service
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* WCF
* .NET Framework
* Services
## Topics
* WCF
## IsPublished
* True
## ModifiedDate
* 2014-11-02 10:49:10
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>The project illustrates how to get WCF service contract programmatically from WSDL of the service</h1>
<h2>Introduction</h2>
<p>The project illustrates how to get a WCF service contract (Interface) programmatically by reading the wsdl of the service.</p>
<p>Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<h2>Running the Sample</h2>
<p>Run the code, it will ask you to enter the adddress of the wsdl for the service. Once you enter it, It will print the service contract name.&nbsp;</p>
<p><img id="128055" src="/site/view/file/128055/1/image001.png" alt="" width="677" height="343"></p>
<h2>Using the code</h2>
<p>Step1. Create a Console Application in the Visual Studio.</p>
<p>Step2. Ensure we are using System.Web.Services.Description namespace</p>
<p>Step3. Here in this project I have made use of WebRequest and HttpWebResponse object to create the request to service wsdl.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//we read wsdl via a xml reader or stream reader and identify node port type

System.Web.Services.Description.ServiceDescription wsdl = new System.Web.Services.Description.ServiceDescription();
            wsdl = ServiceDescription.Read(reader);

            foreach (PortType pt in wsdl.PortTypes)
            {
                Console.WriteLine(&quot;ServiceContract : {0}&quot;, pt.Name);
                Console.ReadLine();
            }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//we&nbsp;read&nbsp;wsdl&nbsp;via&nbsp;a&nbsp;xml&nbsp;reader&nbsp;or&nbsp;stream&nbsp;reader&nbsp;and&nbsp;identify&nbsp;node&nbsp;port&nbsp;type</span>&nbsp;
&nbsp;
System.Web.Services.Description.ServiceDescription&nbsp;wsdl&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Web.Services.Description.ServiceDescription();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wsdl&nbsp;=&nbsp;ServiceDescription.Read(reader);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(PortType&nbsp;pt&nbsp;<span class="cs__keyword">in</span>&nbsp;wsdl.PortTypes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ServiceContract&nbsp;:&nbsp;{0}&quot;</span>,&nbsp;pt.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>System.Web.Services.Description</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.web.services.description(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.web.services.description(v=vs.110).aspx</a></p>
<p>WebRequest Class</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.net.webrequest(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.net.webrequest(v=vs.110).aspx</a></p>
<p>HttpWebResponse Class</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse(v=vs.110).aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
