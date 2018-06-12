# How to add certificate to Azure Cloud service and Management certificates
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud Services
* Managing Services on Windows Azure
## Topics
* Azure
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-06-15 08:18:19
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to add certificate to Azure Cloud service and Managemen</span><span style="font-weight:bold; font-size:14pt">t certificates programmatically</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">Microsoft Azure uses certificates in three ways:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">Management certificates &ndash; Stored at the subscription level, these certificates are used to enable the use of the SDK tools, the Windows Azure Tools for
 Microsoft Visual Studio, or the Service Management REST API Reference. These certificates are independent of any cloud service or deployment.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">Service certificates &ndash; Stored at the cloud service level, these certificates are used by your deployed services.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">SSH Keys &ndash; Stored on the Linux virtual machine, SSH keys are used to authenticate remote connections to the virtual machine.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet will show you how to add certificate to
</span><span style="font-size:11pt">Management certificates</span><span style="font-size:11pt"> and
</span><span style="font-size:11pt">Service certificates</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This code snippet requires Windows Azure management class library. If you have not installed it, please run the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt; Install-Package Microsoft.WindowsAzure.Management.Libraries -Pre</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="OLE_LINK4"></a><a name="OLE_LINK5"></a><span style="font-size:11pt">The code below shows how to get a subscription
</span><span style="font-size:11pt">of </span><a name="_GoBack"></a><span style="font-size:11pt">cloud credentials</span><span style="font-size:11pt">.</span></span></p>
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
        }</pre>
</div>
</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to add certificate to Management certificates:</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">ManagementClient client = new ManagementClient(getCredentials());
           ManagementCertificateCreateParameters parm=new ManagementCertificateCreateParameters()
           {
               Data=cerByte,//the certificate your want to add(convert to byte[] the certificate should be cer )
               Thumbprint=&quot;{Your-certificate-thumb}&quot;
           };
           client.ManagementCertificates.Create(parm);
</pre>
<pre class="hidden">Dim client As New ManagementClient(getCredentials())
 'the certificate your want to add(convert to byte[] the certificate should be cer )
Dim parm As New ManagementCertificateCreateParameters() With { _
 Key .Data = cerByte, _
 Key .Thumbprint = &quot;{Your-certificate-thumb}&quot; _
}
client.ManagementCertificates.Create(parm)
</pre>
<pre id="codePreview" class="csharp">ManagementClient client = new ManagementClient(getCredentials());
           ManagementCertificateCreateParameters parm=new ManagementCertificateCreateParameters()
           {
               Data=cerByte,//the certificate your want to add(convert to byte[] the certificate should be cer )
               Thumbprint=&quot;{Your-certificate-thumb}&quot;
           };
           client.ManagementCertificates.Create(parm);</pre>
</div>
</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to add certificate to Service certificates.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">ComputeManagementClient client = new ComputeManagementClient(getCredentials());
           ServiceCertificateCreateParameters parm = new ServiceCertificateCreateParameters()
           {
               Data = certByte,//the certificate your want to add(convert to byte[] the certificate should be pfx )
               CertificateFormat = CertificateFormat.Pfx,
               Password = &quot;YouPassword&quot;
           };
           client.ServiceCertificates.Create(&quot;{Service-Name}&quot;, parm);
           
</pre>
<pre class="hidden">Dim client As New ComputeManagementClient(getCredentials())
 'the certificate your want to add(convert to byte[] the certificate should be pfx )
Dim parm As New ServiceCertificateCreateParameters() With { _
 Key .Data = certByte, _
 Key .CertificateFormat = CertificateFormat.Pfx, _
 Key .Password = &quot;YouPassword&quot; _
}
client.ServiceCertificates.Create(&quot;{Service-Name}&quot;, parm)
</pre>
<pre id="codePreview" class="csharp">ComputeManagementClient client = new ComputeManagementClient(getCredentials());
           ServiceCertificateCreateParameters parm = new ServiceCertificateCreateParameters()
           {
               Data = certByte,//the certificate your want to add(convert to byte[] the certificate should be pfx )
               CertificateFormat = CertificateFormat.Pfx,
               Password = &quot;YouPassword&quot;
           };
           client.ServiceCertificates.Create(&quot;{Service-Name}&quot;, parm);
           
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">MSDN:</span><span style="font-size:11pt">
<a href="add certificate to Management certificates and Service certificates" target="_blank">
http://msdn.microsoft.com/en-us/library/azure/gg981929.aspx</a></span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
