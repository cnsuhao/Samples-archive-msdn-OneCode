# Determine which Windows Azure Cloud Service Role instance handles the request
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Azure
* Cloud
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-07-10 02:20:02
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to determine which Windows Azure Cloud Service Role instance handles the request</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Windows Azure cloud service can host many instances in both production deployment and staging deployment.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Sometimes developers want to know which Role Instance handles requests from the client side for several conditions:</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">They want to know which deployment slot handles the request.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">They use traffic manager to connect 7 cloud services together, and want to know which cloud service will handle the requests from south Asia.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp;<span style="font-size:11pt">They want to test load balance behavior.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">So they may need to let the role instance connect to Azure management service and get the necessary messages.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample will demonstrate how to determine which windows Azure Cloud Service Role instance handles the request.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#333333">&nbsp;</span><span style="font-size:11pt">This sample requires Windows Azure management class libraries. Please run the following command in the
</span><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="text-decoration:none"><span style="color:#0071bc; text-decoration:underline">Package Manager Console</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">&nbsp;</span><span style="background-color:#202020; color:#e2e2e2; font-size:14pt">PM&gt; Install-Package Microsoft.WindowsAzure.Management.Libraries -Pre</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Before running the sample, you need to get some information.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#ffffff; color:#222222; font-size:10pt">Download the&nbsp;</span><span style="font-weight:bold">publishsettings file</span><span style="font-size:11pt">&nbsp;from:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="background-color:#ffffff; color:#222222; font-size:10pt">&nbsp;</span><a href="https://manage.windowsazure.com/publishsettings/index?client=vs&schemaversion=2.0&whr=azure.com" style="text-decoration:none"><span style="color:#960bb4; background-color:#ffffff; font-size:10pt; text-decoration:underline">https://manage.windowsazure.com/publishsettings/index?client=vs&amp;schemaversion=2.0&amp;whr=azure.com</span></a><span style="background-color:#ffffff; color:#222222; font-size:10pt">&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:11.25pt; font-size:10.0pt; line-height:24pt; background-color:#ffffff; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#222222; font-size:10pt">And get&nbsp;</span><span style="font-weight:bold; color:#222222; font-size:10pt">SubscriptionID</span><span style="color:#222222; font-size:10pt">&nbsp;and&nbsp;</span><span style="font-weight:bold; color:#222222; font-size:10pt">ManagementCertificate
 Base64 string</span><span style="color:#222222; font-size:10pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Open the </span><span style="font-weight:bold">Cloud project-&gt;Roles-&gt;DeterminRoleLocation</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119788/1/image.png" alt="" width="381" height="54" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="OLE_LINK2"></a><a name="OLE_LINK1"></a><span style="font-size:11pt">Double click DetermineRoleLocation and then click the
</span><span style="font-weight:bold">Settings</span><span style="font-size:11pt"> tab.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119789/1/image.png" alt="" width="575" height="142" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Fill the </span><span style="font-weight:bold; color:#222222; font-size:10pt">SubscriptionID</span><span style="color:#222222; font-size:10pt">&nbsp;and
</span><span style="font-weight:bold; color:#222222; font-size:10pt">ManagementCertificate Base64 string
</span><span style="font-size:11pt">to </span><span style="font-weight:bold; color:#222222; font-size:10pt">subscriptionId
</span><span style="color:#222222; font-size:10pt">and</span><span style="font-weight:bold; color:#222222; font-size:10pt"> base64EncodedCertificate</span><span style="color:#222222; font-size:10pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="OLE_LINK4"></a><a name="OLE_LINK3"></a><span style="font-size:11pt">Then go to the
</span><span style="font-weight:bold; color:#222222; font-size:10pt">Default.aspx.cs/Default.aspx.vb
</span><span style="font-size:11pt">in the web project, change &lsquo;cloudServiceNames&rsquo; in the following code to your cloud service names.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">//You can store your cloudServiceName in Azure Table storage, and get the value dynamically.  
public static string[] cloudServiceNames = new string[3] { &quot;testcloud&quot;, &quot;testcloud1&quot;, &quot;testcloud2&quot; }; 
</pre>
<pre class="hidden">'You can store your cloudServiceName in Azure Table storage, and get the value dynamically.
Public Shared cloudServiceNames As String() = New String(2) {&quot;testcloud&quot;, &quot;testcloud1&quot;, &quot;testcloud2&quot;}
</pre>
<pre id="codePreview" class="csharp">//You can store your cloudServiceName in Azure Table storage, and get the value dynamically.  
public static string[] cloudServiceNames = new string[3] { &quot;testcloud&quot;, &quot;testcloud1&quot;, &quot;testcloud2&quot; }; 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code snippet above shows that in one subscription there are three cloud services which are connected by the traffic manager.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After the steps above, now you can deploy the cloud service to Windows Azure.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After completion of the deployment, input your website address:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can get the message like below:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119790/1/image.png" alt="" width="575" height="105" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following code snippet shows how to achieve the goal.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">protected void Page_Load(object sender, EventArgs e)
{
    var hostedServiceDetails = getCloudServiceDetailsByDeploymentId();
    if (hostedServiceDetails!=null)
    {
        lbRoleName.Text = RoleEnvironment.CurrentRoleInstance.Id;
        var deployment = hostedServiceDetails.Deployments.Where(dep =&gt; dep.PrivateId == RoleEnvironment.DeploymentId).FirstOrDefault();
        lbDeploymentName.Text = deployment.Label;
        lbHostServiceName.Text = hostedServiceDetails.ServiceName;
        lbRegionOrGroup.Text = 
            hostedServiceDetails.Properties.AffinityGroup == null ? hostedServiceDetails.Properties.Location : hostedServiceDetails.Properties.AffinityGroup;
        lbslot.Text = deployment.DeploymentSlot.ToString();
    }
    else
    {
        Response.Write(&quot;can't find this VM in current subscription&quot;);
    }
}
static HostedServiceGetDetailedResponse getCloudServiceDetailsByDeploymentId()
{
    var managementClient = new ComputeManagementClient(getCredentials());
    var currentDeployment = new HostedServiceGetDetailedResponse.Deployment();
    foreach (var serviceName in cloudServiceNames)
    {
        var hostedServiceDetails = managementClient.HostedServices.GetDetailed(serviceName);
        foreach (var deployment in hostedServiceDetails.Deployments)
        {
            if (deployment.PrivateId == RoleEnvironment.DeploymentId)
            {
                return hostedServiceDetails;
            }
        }              
    }
    return null;
}
static SubscriptionCloudCredentials getCredentials()
{
    return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
}
</pre>
<pre class="hidden">Protected Sub Page_Load(sender As Object, e As EventArgs)
    Dim hostedServiceDetails = getCloudServiceDetailsByDeploymentId()
    If hostedServiceDetails IsNot Nothing Then
        lbRoleName.Text = RoleEnvironment.CurrentRoleInstance.Id
        Dim deployment = hostedServiceDetails.Deployments.Where(Function(dep) dep.PrivateId = RoleEnvironment.DeploymentId).FirstOrDefault()
        lbDeploymentName.Text = deployment.Label
        lbHostServiceName.Text = hostedServiceDetails.ServiceName
        lbRegionOrGroup.Text = If(hostedServiceDetails.Properties.AffinityGroup Is Nothing, hostedServiceDetails.Properties.Location, hostedServiceDetails.Properties.AffinityGroup)
        lbslot.Text = deployment.DeploymentSlot.ToString()
    Else
        Response.Write(&quot;can't find this VM in current subscription&quot;)
    End If
End Sub
Private Shared Function getCloudServiceDetailsByDeploymentId() As HostedServiceGetDetailedResponse
    Dim managementClient = New ComputeManagementClient(getCredentials())
    Dim currentDeployment = New Deployment()
    For Each serviceName In cloudServiceNames
        Dim hostedServiceDetails = managementClient.HostedServices.GetDetailed(serviceName)
        For Each deployment In hostedServiceDetails.Deployments
            If deployment.PrivateId = RoleEnvironment.DeploymentId Then
                Return hostedServiceDetails
            End If
        Next
    Next
    Return Nothing
End Function
Private Shared Function getCredentials() As SubscriptionCloudCredentials
    Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
End Function
</pre>
<pre id="codePreview" class="csharp">protected void Page_Load(object sender, EventArgs e)
{
    var hostedServiceDetails = getCloudServiceDetailsByDeploymentId();
    if (hostedServiceDetails!=null)
    {
        lbRoleName.Text = RoleEnvironment.CurrentRoleInstance.Id;
        var deployment = hostedServiceDetails.Deployments.Where(dep =&gt; dep.PrivateId == RoleEnvironment.DeploymentId).FirstOrDefault();
        lbDeploymentName.Text = deployment.Label;
        lbHostServiceName.Text = hostedServiceDetails.ServiceName;
        lbRegionOrGroup.Text = 
            hostedServiceDetails.Properties.AffinityGroup == null ? hostedServiceDetails.Properties.Location : hostedServiceDetails.Properties.AffinityGroup;
        lbslot.Text = deployment.DeploymentSlot.ToString();
    }
    else
    {
        Response.Write(&quot;can't find this VM in current subscription&quot;);
    }
}
static HostedServiceGetDetailedResponse getCloudServiceDetailsByDeploymentId()
{
    var managementClient = new ComputeManagementClient(getCredentials());
    var currentDeployment = new HostedServiceGetDetailedResponse.Deployment();
    foreach (var serviceName in cloudServiceNames)
    {
        var hostedServiceDetails = managementClient.HostedServices.GetDetailed(serviceName);
        foreach (var deployment in hostedServiceDetails.Deployments)
        {
            if (deployment.PrivateId == RoleEnvironment.DeploymentId)
            {
                return hostedServiceDetails;
            }
        }              
    }
    return null;
}
static SubscriptionCloudCredentials getCredentials()
{
    return new CertificateCloudCredentials(subscriptionId, new X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Please refer to the project for more details.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="_GoBack"></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
