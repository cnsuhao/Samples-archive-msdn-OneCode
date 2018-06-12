# How to add VM role using Service Management libraries
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Microsoft Azure
* code snippets
* Windows Azure Virtual Machines
## IsPublished
* True
## ModifiedDate
* 2014-02-24 02:01:48
## Description

<h1 class="projectTitle">How to add VM role using Service Management libraries</h1>
<h2>Introduction</h2>
<p><span style="font-size:small">There are two methods in Service Management REST API to create Azure Virtual Machine.</span></p>
<p><span style="font-size:small">The first is <a href="http://msdn.microsoft.com/en-us/library/jj157194.aspx">
Create Virtual Machine Deployment</a>, and the second is <a href="http://msdn.microsoft.com/en-us/library/jj157186.aspx">
Add Role</a>.</span></p>
<p><span style="font-size:small">This code snippet will show how to work with these methods by using the latest
<a href="http://www.nuget.org/packages/Microsoft.WindowsAzure.Management.Libraries">
Service Management libraries</a>.</span></p>
<p><span style="font-size:small">For both methods, you need to create a hosted service first.</span></p>
<h2>Using the Code</h2>
<p><span style="font-size:small">The following code snippet shows how to create a hosted service for Azure VM.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public static void createCloudServiceByLocation(string cloudServiceName, string location)
{
    ComputeManagementClient client = new ComputeManagementClient(getCredentials());
    HostedServiceCreateParameters hostedServiceCreateParams = new HostedServiceCreateParameters
    {
        ServiceName = cloudServiceName,
        Location = location,
        Label = EncodeToBase64(cloudServiceName),
    };
    try
    {
        client.HostedServices.Create(hostedServiceCreateParams);
    }
    catch (CloudException e)
    {
        throw;
    }

}
public static void createCloudServiceByAffinityGroup(string cloudServiceName, string affinityGroupName)
{
    ComputeManagementClient client = new ComputeManagementClient(getCredentials());
    HostedServiceCreateParameters hostedServiceCreateParams = new HostedServiceCreateParameters
    {
        ServiceName = cloudServiceName,
        AffinityGroup = affinityGroupName,
        Label = EncodeToBase64(cloudServiceName),
    };
    try
    {
        client.HostedServices.Create(hostedServiceCreateParams);
    }
    catch (CloudException e)
    {
        throw;
    }

}
public static string EncodeToBase64(string toEncode)
{
    byte[] toEncodeAsBytes
    = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
    string returnValue
          = System.Convert.ToBase64String(toEncodeAsBytes);
    return returnValue;
}
</pre>
<pre class="hidden">Public Sub createCloudServiceByLocation(cloudServiceName As String, location As String)
        Dim client As New ComputeManagementClient(getCredentials())
        Dim hostedServiceCreateParams As New HostedServiceCreateParameters() With { _
             .ServiceName = cloudServiceName, _
             .Location = location, _
             .Label = EncodeToBase64(cloudServiceName) _
        }
        Try
            client.HostedServices.Create(hostedServiceCreateParams)
        Catch e As CloudException
            Throw
        End Try

    End Sub

    Public Sub createCloudServiceByAffinityGroup(cloudServiceName As String, affinityGroupName As String)
        Dim client As New ComputeManagementClient(getCredentials())
        Dim hostedServiceCreateParams As New HostedServiceCreateParameters() With { _
             .ServiceName = cloudServiceName, _
             .AffinityGroup = affinityGroupName, _
             .Label = EncodeToBase64(cloudServiceName) _
        }
        Try
            client.HostedServices.Create(hostedServiceCreateParams)
        Catch e As CloudException
            Throw
        End Try

    End Sub

    Public Function EncodeToBase64(toEncode As String) As String
        Dim toEncodeAsBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode)
        Dim returnValue As String = System.Convert.ToBase64String(toEncodeAsBytes)
        Return returnValue
    End Function

    Public Function getCredentials() As SubscriptionCloudCredentials
        Return New CertificateCloudCredentials(subscriptionId, New X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)))
    End Function
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;createCloudServiceByLocation(<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;location)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ComputeManagementClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ComputeManagementClient(getCredentials());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HostedServiceCreateParameters&nbsp;hostedServiceCreateParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HostedServiceCreateParameters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceName&nbsp;=&nbsp;cloudServiceName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location&nbsp;=&nbsp;location,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;EncodeToBase64(cloudServiceName),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.HostedServices.Create(hostedServiceCreateParams);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;createCloudServiceByAffinityGroup(<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;affinityGroupName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ComputeManagementClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ComputeManagementClient(getCredentials());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HostedServiceCreateParameters&nbsp;hostedServiceCreateParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HostedServiceCreateParameters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceName&nbsp;=&nbsp;cloudServiceName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AffinityGroup&nbsp;=&nbsp;affinityGroupName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;EncodeToBase64(cloudServiceName),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.HostedServices.Create(hostedServiceCreateParams);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;EncodeToBase64(<span class="cs__keyword">string</span>&nbsp;toEncode)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;toEncodeAsBytes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;returnValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;System.Convert.ToBase64String(toEncodeAsBytes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;returnValue;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The following code snippet shows how to create a Management Class Libraries Extension class, the methods in this extension class have the similiar parms like Azure management REST API.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public static class MyVirtualMachineExtension
   {
       /// &lt;summary&gt;
       /// Instantiate a new VM Role
       /// &lt;/summary&gt;
       public static Role CreateVMRole(this IVirtualMachineOperations client, string cloudServiceName, string roleName, VirtualMachineRoleSize roleSize, string userName, string password, OSVirtualHardDisk osVHD)
       {
           Role vmRole = new Role
           {
               RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
               RoleName = roleName,
               Label = roleName,
               RoleSize = roleSize,
               ConfigurationSets = new List&lt;ConfigurationSet&gt;(),
               OSVirtualHardDisk = osVHD
           };
           ConfigurationSet configSet = new ConfigurationSet
           {
               ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
               EnableAutomaticUpdates = true,
               ResetPasswordOnFirstLogon = false,
               ComputerName = roleName,
               AdminUserName = userName,
               AdminPassword = password,
               InputEndpoints = new BindingList&lt;InputEndpoint&gt;
               {
                   new InputEndpoint { LocalPort = 3389, Name = &quot;RDP&quot;, Protocol = &quot;tcp&quot; },
 new InputEndpoint { LocalPort = 80, Port = 80, Name = &quot;web&quot;, Protocol = &quot;tcp&quot; }
               }
           };
           vmRole.ConfigurationSets.Add(configSet);
           return vmRole;
       }

       public static OSVirtualHardDisk CreateOSVHD(this IVirtualMachineImageOperations operation, string cloudserviceName, string vmName, string storageAccount, string imageFamiliyName)
       {
           try
           {
               var osVHD = new OSVirtualHardDisk
               {
                   MediaLink = GetVhdUri(string.Format(&quot;{0}.blob.core.windows.net/vhds&quot;, storageAccount), cloudserviceName, vmName),
                   SourceImageName = GetSourceImageNameByFamliyName(operation, imageFamiliyName)
               };
               return osVHD;
           }
           catch (CloudException e)
           {

               throw;
           }

       }

       private static string GetSourceImageNameByFamliyName(this IVirtualMachineImageOperations operation, string imageFamliyName)
       {
           var disk = operation.List().Where(o =&gt; o.ImageFamily == imageFamliyName).FirstOrDefault();
           if (disk != null)
           {
               return disk.Name;
           }
           else
           {
               throw new CloudException(string.Format(&quot;Can't find {0} OS image in current subscription&quot;));
           }
       }

       private static Uri GetVhdUri(string blobcontainerAddress, string cloudServiceName, string vmName, bool cacheDisk = false, bool https = false)
       {
           var now = DateTime.UtcNow;
           string dateString = now.Year &#43; &quot;-&quot; &#43; now.Month &#43; &quot;-&quot; &#43; now.Day;

           var address = string.Format(&quot;http{0}://{1}/{2}-{3}-{4}-{5}-650.vhd&quot;, https ? &quot;s&quot; : string.Empty, blobcontainerAddress, cloudServiceName, vmName, cacheDisk ? &quot;-CacheDisk&quot; : string.Empty, dateString);
           return new Uri(address);
       }

       public static void CreateVMDeployment(this IVirtualMachineOperations operations, string cloudServiceName, string deploymentName, List&lt;Role&gt; roleList, DeploymentSlot slot = DeploymentSlot.Production)
       {

           try
           {
               VirtualMachineCreateDeploymentParameters createDeploymentParams = new VirtualMachineCreateDeploymentParameters
               {

                   Name = deploymentName,
                   Label = cloudServiceName,
                   Roles = roleList,
                   DeploymentSlot = slot
               };
               operations.CreateDeployment(cloudServiceName, createDeploymentParams);
           }
           catch (CloudException e)
           {
               throw;
           }
       }

       public static void AddRole(this IVirtualMachineOperations operations, string cloudServiceName, string deploymentName, Role role, DeploymentSlot slot = DeploymentSlot.Production)
       {
           try
           {
               VirtualMachineCreateParameters createParams = new VirtualMachineCreateParameters
               {
                   RoleName = role.Label,
                   RoleSize = role.RoleSize,
                   OSVirtualHardDisk = role.OSVirtualHardDisk,
                   ConfigurationSets = role.ConfigurationSets,
                   AvailabilitySetName = role.AvailabilitySetName,
                   DataVirtualHardDisks = role.DataVirtualHardDisks
               };

               operations.Create(cloudServiceName, deploymentName, createParams);
           }
           catch (CloudException e)
           {
               throw;
           }
          
       }
   }
</pre>
<pre class="hidden">Module MyVirtualMachineExtension
    ''' &lt;summary&gt;
    ''' Instantiation a new VM Role
    ''' &lt;/summary&gt;
    &lt;Extension()&gt;
    Public Function CreateVMRole(client As IVirtualMachineOperations, cloudServiceName As String, roleName As String, roleSize As VirtualMachineRoleSize, userName As String, password As String, _
        osVHD As OSVirtualHardDisk) As Role
        Dim vmRole As New Role() With { _
             .RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(), _
             .RoleName = roleName, _
             .Label = roleName, _
             .RoleSize = roleSize, _
             .ConfigurationSets = New List(Of ConfigurationSet)(), _
             .OSVirtualHardDisk = osVHD _
        }
        Dim configSet As New ConfigurationSet() With { _
             .ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration, _
             .EnableAutomaticUpdates = True, _
             .ResetPasswordOnFirstLogon = False, _
             .ComputerName = roleName, _
             .AdminUserName = userName, _
             .AdminPassword = password, _
             .InputEndpoints = New BindingList(Of InputEndpoint)() From { _
                New InputEndpoint() With { _
                     .LocalPort = 3389, _
                     .Name = &quot;RDP&quot;, _
                     .Protocol = &quot;tcp&quot; _
                }, _
                New InputEndpoint() With { _
                     .LocalPort = 80, _
                     .Port = 80, _
                     .Name = &quot;web&quot;, _
                     .Protocol = &quot;tcp&quot; _
                } _
            } _
        }
        vmRole.ConfigurationSets.Add(configSet)
        Return vmRole
    End Function

    &lt;Extension()&gt;
    Public Function CreateOSVHD(operation As IVirtualMachineImageOperations, cloudserviceName As String, vmName As String, storageAccount As String, imageFamiliyName As String) As OSVirtualHardDisk
        Try
            Dim osVHD = New OSVirtualHardDisk() With { _
                 .MediaLink = GetVhdUri(String.Format(&quot;{0}.blob.core.windows.net/vhds&quot;, storageAccount), cloudserviceName, vmName), _
                 .SourceImageName = GetSourceImageNameByFamliyName(operation, imageFamiliyName) _
            }
            Return osVHD
        Catch e As CloudException

            Throw
        End Try

    End Function

    &lt;Extension()&gt;
    Private Function GetSourceImageNameByFamliyName(operation As IVirtualMachineImageOperations, imageFamliyName As String) As String
        Dim disk = operation.List().Where(Function(o) o.ImageFamily = imageFamliyName).FirstOrDefault()
        If disk IsNot Nothing Then
            Return disk.Name
        Else
            Throw New CloudException(String.Format(&quot;Can't find {0} OS image in current subscription&quot;))
        End If
    End Function

    &lt;Extension()&gt;
    Private Function GetVhdUri(blobcontainerAddress As String, cloudServiceName As String, vmName As String, Optional cacheDisk As Boolean = False, Optional https As Boolean = False) As Uri
        Dim now = DateTime.UtcNow
        Dim dateString As String = Convert.ToString(now.Year) &amp; &quot;-&quot; &amp; Convert.ToString(now.Month) &amp; &quot;-&quot; &amp; Convert.ToString(now.Day)

        Dim address = String.Format(&quot;http{0}://{1}/{2}-{3}-{4}-{5}-650.vhd&quot;, If(https, &quot;s&quot;, String.Empty), blobcontainerAddress, cloudServiceName, vmName, If(cacheDisk, &quot;-CacheDisk&quot;, String.Empty), _
            dateString)
        Return New Uri(address)
    End Function

    &lt;Extension()&gt;
    Public Sub CreateVMDeployment(operations As IVirtualMachineOperations, cloudServiceName As String, deploymentName As String, roleList As List(Of Role), Optional slot As DeploymentSlot = DeploymentSlot.Production)
        Try
            Dim createDeploymentParams As New VirtualMachineCreateDeploymentParameters() With { _
                .Name = deploymentName, _
                 .Label = cloudServiceName, _
                 .Roles = roleList, _
                 .DeploymentSlot = slot _
            }
            operations.CreateDeployment(cloudServiceName, createDeploymentParams)
        Catch e As CloudException
            Throw
        End Try
    End Sub
End Module
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">class</span>&nbsp;MyVirtualMachineExtension&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;Instantiate&nbsp;a&nbsp;new&nbsp;VM&nbsp;Role</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;Role&nbsp;CreateVMRole(<span class="cs__keyword">this</span>&nbsp;IVirtualMachineOperations&nbsp;client,&nbsp;<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;roleName,&nbsp;VirtualMachineRoleSize&nbsp;roleSize,&nbsp;<span class="cs__keyword">string</span>&nbsp;userName,&nbsp;<span class="cs__keyword">string</span>&nbsp;password,&nbsp;OSVirtualHardDisk&nbsp;osVHD)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Role&nbsp;vmRole&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Role&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleType&nbsp;=&nbsp;VirtualMachineRoleType.PersistentVMRole.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleName&nbsp;=&nbsp;roleName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;roleName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleSize&nbsp;=&nbsp;roleSize,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSets&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ConfigurationSet&gt;(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OSVirtualHardDisk&nbsp;=&nbsp;osVHD&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSet&nbsp;configSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ConfigurationSet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSetType&nbsp;=&nbsp;ConfigurationSetTypes.WindowsProvisioningConfiguration,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableAutomaticUpdates&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResetPasswordOnFirstLogon&nbsp;=&nbsp;<span class="cs__keyword">false</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComputerName&nbsp;=&nbsp;roleName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AdminUserName&nbsp;=&nbsp;userName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AdminPassword&nbsp;=&nbsp;password,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InputEndpoints&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingList&lt;InputEndpoint&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;InputEndpoint&nbsp;{&nbsp;LocalPort&nbsp;=&nbsp;<span class="cs__number">3389</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;RDP&quot;</span>,&nbsp;Protocol&nbsp;=&nbsp;<span class="cs__string">&quot;tcp&quot;</span>&nbsp;},&nbsp;
&nbsp;<span class="cs__keyword">new</span>&nbsp;InputEndpoint&nbsp;{&nbsp;LocalPort&nbsp;=&nbsp;<span class="cs__number">80</span>,&nbsp;Port&nbsp;=&nbsp;<span class="cs__number">80</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;web&quot;</span>,&nbsp;Protocol&nbsp;=&nbsp;<span class="cs__string">&quot;tcp&quot;</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vmRole.ConfigurationSets.Add(configSet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;vmRole;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span>&nbsp;OSVirtualHardDisk&nbsp;CreateOSVHD(<span class="cs__keyword">this</span>&nbsp;IVirtualMachineImageOperations&nbsp;operation,&nbsp;<span class="cs__keyword">string</span>&nbsp;cloudserviceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;vmName,&nbsp;<span class="cs__keyword">string</span>&nbsp;storageAccount,&nbsp;<span class="cs__keyword">string</span>&nbsp;imageFamiliyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;osVHD&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OSVirtualHardDisk&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MediaLink&nbsp;=&nbsp;GetVhdUri(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}.blob.core.windows.net/vhds&quot;</span>,&nbsp;storageAccount),&nbsp;cloudserviceName,&nbsp;vmName),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SourceImageName&nbsp;=&nbsp;GetSourceImageNameByFamliyName(operation,&nbsp;imageFamiliyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;osVHD;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;GetSourceImageNameByFamliyName(<span class="cs__keyword">this</span>&nbsp;IVirtualMachineImageOperations&nbsp;operation,&nbsp;<span class="cs__keyword">string</span>&nbsp;imageFamliyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;disk&nbsp;=&nbsp;operation.List().Where(o&nbsp;=&gt;&nbsp;o.ImageFamily&nbsp;==&nbsp;imageFamliyName).FirstOrDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(disk&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;disk.Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span><span class="cs__keyword">new</span>&nbsp;CloudException(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Can't&nbsp;find&nbsp;{0}&nbsp;OS&nbsp;image&nbsp;in&nbsp;current&nbsp;subscription&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">static</span>&nbsp;Uri&nbsp;GetVhdUri(<span class="cs__keyword">string</span>&nbsp;blobcontainerAddress,&nbsp;<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;vmName,&nbsp;<span class="cs__keyword">bool</span>&nbsp;cacheDisk&nbsp;=&nbsp;<span class="cs__keyword">false</span>,&nbsp;<span class="cs__keyword">bool</span>&nbsp;https&nbsp;=&nbsp;<span class="cs__keyword">false</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;now&nbsp;=&nbsp;DateTime.UtcNow;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;dateString&nbsp;=&nbsp;now.Year&nbsp;&#43;&nbsp;<span class="cs__string">&quot;-&quot;</span>&nbsp;&#43;&nbsp;now.Month&nbsp;&#43;&nbsp;<span class="cs__string">&quot;-&quot;</span>&nbsp;&#43;&nbsp;now.Day;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;address&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;http{0}://{1}/{2}-{3}-{4}-{5}-650.vhd&quot;</span>,&nbsp;https&nbsp;?&nbsp;<span class="cs__string">&quot;s&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">string</span>.Empty,&nbsp;blobcontainerAddress,&nbsp;cloudServiceName,&nbsp;vmName,&nbsp;cacheDisk&nbsp;?&nbsp;<span class="cs__string">&quot;-CacheDisk&quot;</span>&nbsp;:&nbsp;<span class="cs__keyword">string</span>.Empty,&nbsp;dateString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;Uri(address);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;CreateVMDeployment(<span class="cs__keyword">this</span>&nbsp;IVirtualMachineOperations&nbsp;operations,&nbsp;<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;deploymentName,&nbsp;List&lt;Role&gt;&nbsp;roleList,&nbsp;DeploymentSlot&nbsp;slot&nbsp;=&nbsp;DeploymentSlot.Production)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VirtualMachineCreateDeploymentParameters&nbsp;createDeploymentParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;VirtualMachineCreateDeploymentParameters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;deploymentName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;cloudServiceName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Roles&nbsp;=&nbsp;roleList,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeploymentSlot&nbsp;=&nbsp;slot&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;operations.CreateDeployment(cloudServiceName,&nbsp;createDeploymentParams);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;AddRole(<span class="cs__keyword">this</span>&nbsp;IVirtualMachineOperations&nbsp;operations,&nbsp;<span class="cs__keyword">string</span>&nbsp;cloudServiceName,&nbsp;<span class="cs__keyword">string</span>&nbsp;deploymentName,&nbsp;Role&nbsp;role,&nbsp;DeploymentSlot&nbsp;slot&nbsp;=&nbsp;DeploymentSlot.Production)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VirtualMachineCreateParameters&nbsp;createParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;VirtualMachineCreateParameters&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleName&nbsp;=&nbsp;role.Label,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleSize&nbsp;=&nbsp;role.RoleSize,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OSVirtualHardDisk&nbsp;=&nbsp;role.OSVirtualHardDisk,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSets&nbsp;=&nbsp;role.ConfigurationSets,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AvailabilitySetName&nbsp;=&nbsp;role.AvailabilitySetName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataVirtualHardDisks&nbsp;=&nbsp;role.DataVirtualHardDisks&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;operations.Create(cloudServiceName,&nbsp;deploymentName,&nbsp;createParams);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">You can use the extension to create virtual machine deployment as shown below.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">//TODO: The properties should be changed to those of your own.
public const string base64EncodedCertificate = &quot;Your base64 certificate string&quot;;
public const string subscriptionId = &quot;Your SubscriptionId&quot;;

public static string vmName = &quot;MyVirtualMachine&quot;;
public static string location = &quot;East Asia&quot;;
public static string storageAccountName = &quot;Storgate Account Name&quot;;
public static string userName = &quot;User&quot;;
public static string password = &quot;Password1!&quot;;


public static string imageFamiliyName = &quot;Windows Server 2012 Datacenter&quot;;


static void Main(string[] args)
{
    ComputeManagementClient client = new ComputeManagementClient(getCredentials());
    //You need a hosted service host VM.
     try
            {
                client.HostedServices.Get(vmName);
            }
            catch (CloudException e)
            {
                createCloudServiceByLocation(vmName, location);
            }
    var OSVHD = client.VirtualMachineImages.CreateOSVHD(vmName, vmName, storageAccountName, imageFamiliyName);
    var VMROle = client.VirtualMachines.CreateVMRole(vmName, vmName, VirtualMachineRoleSize.Small, userName, password, OSVHD);
    List&lt;Role&gt; roleList = new List&lt;Role&gt;{
        VMROle
    };
    client.VirtualMachines.CreateVMDeployment(vmName, vmName, roleList);
    Console.WriteLine(&quot;Create VM success&quot;);

    Console.ReadLine();
}
}
</pre>
<pre class="hidden">Public Const base64EncodedCertificate As String = &quot;Your base64 certificate string&quot;

    Public vmName As String = &quot;MyVirtualMachine&quot;
    Public location As String = &quot;East Asia&quot;

    Public storageAccountName As String = &quot;Storgate Account Name&quot;
    Public userName As String = &quot;User&quot;

    Public password As String = &quot;Password1!&quot;
    Public imageFamiliyName As String = &quot;Windows Server 2012 Datacenter&quot;

    Sub Main()
        Dim client As New ComputeManagementClient(getCredentials())
        'You need a hosted service host VM.
        Try
            Dim hostedService = client.HostedServices.Get(vmName)
        Catch ex As CloudException
            createCloudServiceByLocation(vmName, location)
            Console.Write(&quot;Create CloudService First&quot;)
        End Try
        

        Dim OSVHD = client.VirtualMachineImages.CreateOSVHD(vmName, vmName, storageAccountName, imageFamiliyName)
        Dim VMROle = client.VirtualMachines.CreateVMRole(vmName, vmName, VirtualMachineRoleSize.Small, userName, password, OSVHD)
        Dim roleList As New List(Of Role)() From { _
            VMROle _
        }
        client.VirtualMachines.CreateVMDeployment(vmName, vmName, roleList)
        Console.WriteLine(&quot;Create VM successfully&quot;)

        Console.ReadLine()
    End Sub
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//TODO:&nbsp;The&nbsp;properties&nbsp;should&nbsp;be&nbsp;changed&nbsp;to&nbsp;those&nbsp;of&nbsp;your&nbsp;own.</span><span class="cs__keyword">public</span><span class="cs__keyword">const</span><span class="cs__keyword">string</span>&nbsp;base64EncodedCertificate&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;base64&nbsp;certificate&nbsp;string&quot;</span>;&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">const</span><span class="cs__keyword">string</span>&nbsp;subscriptionId&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;SubscriptionId&quot;</span>;&nbsp;
&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;vmName&nbsp;=&nbsp;<span class="cs__string">&quot;MyVirtualMachine&quot;</span>;&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;location&nbsp;=&nbsp;<span class="cs__string">&quot;East&nbsp;Asia&quot;</span>;&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;storageAccountName&nbsp;=&nbsp;<span class="cs__string">&quot;Storgate&nbsp;Account&nbsp;Name&quot;</span>;&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;userName&nbsp;=&nbsp;<span class="cs__string">&quot;User&quot;</span>;&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;password&nbsp;=&nbsp;<span class="cs__string">&quot;Password1!&quot;</span>;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">string</span>&nbsp;imageFamiliyName&nbsp;=&nbsp;<span class="cs__string">&quot;Windows&nbsp;Server&nbsp;2012&nbsp;Datacenter&quot;</span>;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ComputeManagementClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ComputeManagementClient(getCredentials());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//You&nbsp;need&nbsp;a&nbsp;hosted&nbsp;service&nbsp;host&nbsp;VM.</span><span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.HostedServices.Get(vmName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(CloudException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createCloudServiceByLocation(vmName,&nbsp;location);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;OSVHD&nbsp;=&nbsp;client.VirtualMachineImages.CreateOSVHD(vmName,&nbsp;vmName,&nbsp;storageAccountName,&nbsp;imageFamiliyName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;VMROle&nbsp;=&nbsp;client.VirtualMachines.CreateVMRole(vmName,&nbsp;vmName,&nbsp;VirtualMachineRoleSize.Small,&nbsp;userName,&nbsp;password,&nbsp;OSVHD);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Role&gt;&nbsp;roleList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Role&gt;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VMROle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;client.VirtualMachines.CreateVMDeployment(vmName,&nbsp;vmName,&nbsp;roleList);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Create&nbsp;VM&nbsp;success&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-size:small">To add role to existing deployment, you can just use the code below:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">client.VirtualMachines.AddRole(&quot;CloudServiceName&quot;, &quot;ExsitDeploymentName&quot;, VMROle);</pre>
<pre class="hidden">client.VirtualMachines.AddRole(&quot;CloudServiceName&quot;, &quot;ExsitDeploymentName&quot;, VMROle)</pre>
<div class="preview">
<pre class="js">client.VirtualMachines.AddRole(<span class="js__string">&quot;CloudServiceName&quot;</span>,&nbsp;<span class="js__string">&quot;ExsitDeploymentName&quot;</span>,&nbsp;VMROle);</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Then you can use some tool to capture the request; you may note that the CreateVMDeployment will have the context like
<a href="http://msdn.microsoft.com/en-us/library/jj157194.aspx">Create Virtual Machine Deployment</a>, while AddRole will send the request like
<a href="http://msdn.microsoft.com/en-us/library/jj157186.aspx">Add Role</a>.</span></p>
<h2>More Information</h2>
<p><span style="font-size:small">Create Virtual Machine Deployment<br>
</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/jj157194.aspx ">http://msdn.microsoft.com/en-us/library/jj157194.aspx&nbsp;</a></span></p>
<p><span style="font-size:small">Add Role</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/jj157186.aspx">http://msdn.microsoft.com/en-us/library/jj157186.aspx</a></span></p>
<p><span style="font-size:small">Windows Azure Management Libraries&nbsp;</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/jj157186.aspx">http://msdn.microsoft.com/en-us/library/jj157186.aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
