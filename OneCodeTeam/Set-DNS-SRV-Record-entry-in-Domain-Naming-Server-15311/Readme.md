# Set DNS SRV Record entry in Domain Naming Server (CppCreateDNSRecord)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WMI
## Topics
* DNS
## IsPublished
* True
## ModifiedDate
* 2012-02-22 12:12:44
## Description

<div class="WordSection1">
<h1>This sample application demonstrates how to set the DNS SRV Record entry in the Domain Naming Server via C&#43;&#43;. (<span class="SpellE">CppCreateDNSRecord</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample application demonstrates how to set the DNS SRV Record entry in the Domain Naming Server via C&#43;&#43;. We are using here WMI&rsquo;s class
<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">MicrosoftDNS_SRVType</span></span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">
</span>under <span style="font-size:9.5pt; font-family:Consolas; color:#a31515">ROOT\<span class="SpellE">MicrosoftDNS</span>
</span>namespace.</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This namespace is provided by Microsoft to manage DNS.<span>&nbsp; </span>This application takes the advantages of WMI classes and executes the method
<span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">CreateInstanceFromPropertydata</span></span>.</p>
<p class="MsoNormal">To know more about SRV Records, please visit <a href="http://technet.microsoft.com/en-us/library/cc742513.aspx">
http://technet.microsoft.com/en-us/library/cc742513.aspx</a> &amp; <a href="http://technet.microsoft.com/en-us/library/cc772362.aspx">
http://technet.microsoft.com/en-us/library/cc772362.aspx</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">In order to execute this sample code, we need a DNS Server which is in a domain. You must execute this application under Domain Administrator privileges as this requires domain admin privileges to update DNS SRV records.</p>
<p class="MsoNormal">Once we have this DNS Server, we need to know what <span class="GramE">
are the following parameters value</span> in domain:</p>
<ul>
<li>
<div class="MsoNormal">DNS Server Name</div>
</li><li>
<div class="MsoNormal">Container Name</div>
</li><li>
<div class="MsoNormal">Owner Name</div>
</li><li>
<div class="MsoNormal">Priority</div>
</li><li>
<div class="MsoNormal">Weight</div>
</li><li>
<div class="MsoNormal">Port</div>
</li><li>
<div class="MsoNormal">Domain Name</div>
</li></ul>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Since this is a C&#43;&#43; Application, we need to include certain header files: </span>
<span class="SpellE"><span style="color:#a31515">comdef.h</span></span><span> for COM &amp;
</span><span class="SpellE"><span style="color:#a31515">Wbemidl.h</span></span><span> for WMI. In the code, first we need to initialize COM by calling (</span><span class="SpellE"><span>CoInitializeEx</span></span><span>). Once the COM is initialized we
 need to set the COM general security calling (</span><span class="SpellE"><span>CoInitializeSecurity</span></span><span>). Then we require
<span class="GramE">to get</span> the WMI Locator in order to connect to a WMI service by calling (</span><span class="SpellE"><span>CoCreateInstance</span></span><span>) &amp; (</span><span class="SpellE"><span>IWbemServices</span></span><span>::</span><span class="SpellE"><span>ConnectServer</span></span><span>).
 While connecting to the WMI service we need to connect to the </span><span style="color:#a31515">ROOT\<span class="SpellE">MicrosoftDNS</span>
</span><span>namespace. This namespace gives us the facilities to work with the Domain Naming Server. After we obtain the connection to the WMI service we would require to setting the proxy setting via
</span><span class="SpellE"><span>CoSetProxyBlanket</span></span><span>, make sure we use the impersonation level as
</span><span>RPC_C_IMP_LEVEL_IMPERSONATE</span><span>.</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>For creating the DNS record we have a class called </span><span class="SpellE"><span style="color:#a31515">MicrosoftDNS_SRVType</span></span><span> which has a method called
</span><span class="SpellE"><span style="color:#a31515">CreateInstanceFromPropertydata</span></span><span>. This
<span class="GramE">methods</span> takes certain important parameters as described below:</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><span style="color:green">DnsServerName</span></span><span style="color:green"> =&gt; This takes the FQDN of the DNS Server</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><span style="color:green">ContainerName</span></span><span style="color:green"> =&gt; FQDN of domain controller or called Container</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><span style="color:green">OwnerName</span></span><span style="color:green"> =&gt;
<span class="GramE">Should</span> be the New alias name, in FQDN format</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><span style="color:green">RecordClass</span></span><span style="color:green"> =&gt; It should be the record class, generally passed as 0</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:green">TTL =&gt; It must be 0 while creating the DNS SVR Record</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:green">Priority =&gt; Priority can be defined as per your need, generally it is 0</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:green">Weight =&gt; As Priority, Weight can be as per your requirement.</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:green">Port<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>=&gt; This will be the port on which DNS SRV Record will work.</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="SpellE"><span style="color:green">DomainName</span></span><span style="color:green"> =&gt; This should be the FQDN of the Domain.</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Once we set the above parameters, we will execute <span class="SpellE"><span style="color:#a31515">CreateInstanceFromPropertydata</span></span> method with the help of
<span class="SpellE">IWbemServices</span>:<span class="GramE">:<span class="SpellE">ExecMethod.This</span></span> method returns the HRESULT and if successful we need to release all the pointers and must exit out gracefully.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">For more information on:</p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Working on WMI via C&#43;&#43;:</p>
<p class="MsoNormal" style="text-indent:.5in"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394558(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa394558(v=vs.85).aspx</a></p>
<p class="MsoNormal" style="text-indent:.5in"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa389762(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa389762(v=vs.85).aspx</a></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Microsoft DNS Namespace &amp; Classes:</p>
<p class="MsoNormal" style="text-indent:.5in"><a href="http://technet.microsoft.com/en-us/library/dd197491(WS.10).aspx">http://technet.microsoft.com/en-us/library/dd197491(WS.10).aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p></p>
</div>
