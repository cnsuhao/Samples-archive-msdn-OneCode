# How to output a list of RDP ports in Microsoft Azure
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Azure
* Cloud
* Azure Network Services
## Topics
* Azure
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-06-24 01:32:15
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-size:14pt">&nbsp;</span><span style="font-size:14pt">How to output a list of RDP ports in Windows Azure</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">As </span><span style="font-size:11pt">developers usually connect to a new environment, they need&nbsp;to manually set</span><span style="font-size:11pt">
</span><span style="font-size:11pt">up all of the RDP settings including which external port is used to&nbsp;connect to RDP. We can use the code to output the RDP ports of the virtual&nbsp;machines in a given service endpoint.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#333333">&nbsp;</span><span style="font-size:11pt">This code snippet requires Windows Azure management class library. If you have not installed it, please run the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt; Install-Package Microsoft.WindowsAzure.Management.Libraries -Pre</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Note: If you use </span>
<span style="font-size:11pt">Windows 8, Windows Phone Silverlight 8, or Windows Phone 8.1</span><span style="font-size:11pt"> you may need to install the Nuget package</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:15pt">PM&gt; Install-Package Microsoft.Bcl.Async</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to get a subscription</span><span style="font-size:11pt"> of</span><a name="_GoBack"></a><span style="font-size:11pt"> cloud credentials.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public static string subscriptionId = &quot;{Your-Subscription-id}&quot;;
        public static string base64EncodedCertificate = &quot;Your-certificate-Base64-string&quot;;
        static SubscriptionCloudCredentials getCredentials()
        {
            return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
        }
</pre>
<pre class="hidden">Public Shared subscriptionId As String = &quot;{Your-Subscription-id}&quot;
Public Shared base64EncodedCertificate As String = &quot;Your-certificate-Base64-string&quot;
Private Shared Function getCredentials() As SubscriptionCloudCredentials
 Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
End Function
</pre>
<pre id="codePreview" class="csharp">public static string subscriptionId = &quot;{Your-Subscription-id}&quot;;
        public static string base64EncodedCertificate = &quot;Your-certificate-Base64-string&quot;;
        static SubscriptionCloudCredentials getCredentials()
        {
            return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to output the VM input endpoint</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">static void Main(string[] args)
{
    ComputeManagementClient client = new ComputeManagementClient(getCredentials());
    var vm = client.VirtualMachines.Get(&quot;{Cloud-Service-Name}&quot;, &quot;{Deployment-Name}&quot;, &quot;{Virtual-Machine-Name}&quot;);
  
    foreach (var endpoint in vm.ConfigurationSets.First().InputEndpoints)
    {
        Console.WriteLine(&quot;LocalPort:{0}\nName:{1}\nProtocal:{2}\nport:{3}\n&quot;,endpoint.LocalPort,endpoint.Name,endpoint.Protocol,endpoint.Port);
    }
    Console.ReadLine();
}
</pre>
<pre class="hidden">Private Shared Sub Main(args As String())
 Dim client As New ComputeManagementClient(getCredentials())
 Dim vm = client.VirtualMachines.[Get](&quot;{Cloud-Service-Name}&quot;, &quot;{Deployment-Name}&quot;, &quot;{Virtual-Machine-Name}&quot;)
 For Each endpoint As var In vm.ConfigurationSets.First().InputEndpoints
  Console.WriteLine(&quot;LocalPort:{0}&quot; &amp; vbLf &amp; &quot;Name:{1}&quot; &amp; vbLf &amp; &quot;Protocal:{2}&quot; &amp; vbLf &amp; &quot;port:{3}&quot; &amp; vbLf, endpoint.LocalPort, endpoint.Name, endpoint.Protocol, endpoint.Port)
 Next
 Console.ReadLine()
End Sub
</pre>
<pre id="codePreview" class="csharp">static void Main(string[] args)
{
    ComputeManagementClient client = new ComputeManagementClient(getCredentials());
    var vm = client.VirtualMachines.Get(&quot;{Cloud-Service-Name}&quot;, &quot;{Deployment-Name}&quot;, &quot;{Virtual-Machine-Name}&quot;);
  
    foreach (var endpoint in vm.ConfigurationSets.First().InputEndpoints)
    {
        Console.WriteLine(&quot;LocalPort:{0}\nName:{1}\nProtocal:{2}\nport:{3}\n&quot;,endpoint.LocalPort,endpoint.Name,endpoint.Protocol,endpoint.Port);
    }
    Console.ReadLine();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
