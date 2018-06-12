# How to program control windows Azure VM
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
* VM
* Service Management
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:42:56
## Description

<h1>Virtual Machine Operation in Windows Azure platform(VBAzureControlVM)</h1>
<h2>Introduction </h2>
<p class="MsoNormal"><span style="">To operate windows azure Iaas virtual machine, using the azure power shell isn't the only way. We also can use management service API to achieve this target.
</span></p>
<p class="MsoNormal"><span style="">This sample will use GET/POST/DELETE requests to operate the virtual machine.
</span></p>
<h2>Running the Sample </h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span style="">Step 1: open the AddVirtualMachine.xml, fill your own value to this xml file.
</span></p>
<p class="MsoNormal"><span style="">Step 2: </span>Press Ctrl&#43;F5 to show the console application.
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step 3: Fill your own Subscription Id, Service name, Certificate Thumbprint.<span style="font-size:9.5pt; font-family:新宋体">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体"></span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp; </span>Choose the operation, and check it on your Azure portal.
</p>
<h2>Using the Code </h2>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1:<span style="">&nbsp; </span>Create a Console app named VBAzureControlVM.
</p>
<p class="MsoNormal">Step 2:<span style="">&nbsp; </span>Add an xml file called AddVirtualMachine.xml.
</p>
<h3>The following code shows the message we need when create a virtual machine. </h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Deployment xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot; xmlns:i=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;
  &lt;!--Your host service name--&gt;
  &lt;Name&gt;SERVICE_NAME&lt;/Name&gt;
  &lt;DeploymentSlot&gt;Production&lt;/DeploymentSlot&gt;
  &lt;Label&gt;SERVICE_NAME&lt;/Label&gt;
  &lt;RoleList&gt;
    &lt;Role i:type=&quot;PersistentVMRole&quot;&gt;
      &lt;!--Your virtual Machine Name--&gt;
      &lt;RoleName&gt;MyWinVM&lt;/RoleName&gt;
      &lt;OsVersion i:nil=&quot;true&quot;/&gt;
      &lt;RoleType&gt;PersistentVMRole&lt;/RoleType&gt;
      &lt;ConfigurationSets&gt;
        &lt;ConfigurationSet i:type=&quot;WindowsProvisioningConfigurationSet&quot;&gt;
          &lt;ConfigurationSetType&gt;WindowsProvisioningConfiguration&lt;/ConfigurationSetType&gt;
          &lt;!--Your Computer Name--&gt;
          &lt;ComputerName&gt;MyWinVM&lt;/ComputerName&gt;
          &lt;!--Computer pass word--&gt;
          &lt;AdminPassword&gt;Password1!&lt;/AdminPassword&gt;
          &lt;EnableAutomaticUpdates&gt;true&lt;/EnableAutomaticUpdates&gt;
          &lt;ResetPasswordOnFirstLogon&gt;false&lt;/ResetPasswordOnFirstLogon&gt;
        &lt;/ConfigurationSet&gt;
        &lt;ConfigurationSet i:type=&quot;NetworkConfigurationSet&quot;&gt;
          &lt;ConfigurationSetType&gt;NetworkConfiguration&lt;/ConfigurationSetType&gt;
          &lt;InputEndpoints&gt;
            &lt;InputEndpoint&gt;
              &lt;LocalPort&gt;3389&lt;/LocalPort&gt;
              &lt;Name&gt;RemoteDesktop&lt;/Name&gt;
              &lt;Protocol&gt;tcp&lt;/Protocol&gt;
            &lt;/InputEndpoint&gt;
          &lt;/InputEndpoints&gt;
        &lt;/ConfigurationSet&gt;
      &lt;/ConfigurationSets&gt;
      &lt;DataVirtualHardDisks/&gt;
      &lt;Label&gt;bXlzdmMxZGlubzY=&lt;/Label&gt;
      &lt;OSVirtualHardDisk&gt;
        &lt;!--VHD address and  source image name--&gt;
        &lt;!--replace these two properties to avaliable value--&gt;
        &lt;MediaLink&gt;https://portalvhds54h52qsyb55v4.blob.core.windows.net/vhds/mysvc-MyWinVM-2012-12-1-107.vhd&lt;/MediaLink&gt;
        &lt;SourceImageName&gt;a699494373c04fc0bc8f2bb1389d6106__Win2K8R2SP1-Datacenter-201212.01-en.us-30GB.vhd&lt;/SourceImageName&gt;
      &lt;/OSVirtualHardDisk&gt;
    &lt;/Role&gt;
  &lt;/RoleList&gt;
&lt;/Deployment&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Deployment xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot; xmlns:i=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;
  &lt;!--Your host service name--&gt;
  &lt;Name&gt;SERVICE_NAME&lt;/Name&gt;
  &lt;DeploymentSlot&gt;Production&lt;/DeploymentSlot&gt;
  &lt;Label&gt;SERVICE_NAME&lt;/Label&gt;
  &lt;RoleList&gt;
    &lt;Role i:type=&quot;PersistentVMRole&quot;&gt;
      &lt;!--Your virtual Machine Name--&gt;
      &lt;RoleName&gt;MyWinVM&lt;/RoleName&gt;
      &lt;OsVersion i:nil=&quot;true&quot;/&gt;
      &lt;RoleType&gt;PersistentVMRole&lt;/RoleType&gt;
      &lt;ConfigurationSets&gt;
        &lt;ConfigurationSet i:type=&quot;WindowsProvisioningConfigurationSet&quot;&gt;
          &lt;ConfigurationSetType&gt;WindowsProvisioningConfiguration&lt;/ConfigurationSetType&gt;
          &lt;!--Your Computer Name--&gt;
          &lt;ComputerName&gt;MyWinVM&lt;/ComputerName&gt;
          &lt;!--Computer pass word--&gt;
          &lt;AdminPassword&gt;Password1!&lt;/AdminPassword&gt;
          &lt;EnableAutomaticUpdates&gt;true&lt;/EnableAutomaticUpdates&gt;
          &lt;ResetPasswordOnFirstLogon&gt;false&lt;/ResetPasswordOnFirstLogon&gt;
        &lt;/ConfigurationSet&gt;
        &lt;ConfigurationSet i:type=&quot;NetworkConfigurationSet&quot;&gt;
          &lt;ConfigurationSetType&gt;NetworkConfiguration&lt;/ConfigurationSetType&gt;
          &lt;InputEndpoints&gt;
            &lt;InputEndpoint&gt;
              &lt;LocalPort&gt;3389&lt;/LocalPort&gt;
              &lt;Name&gt;RemoteDesktop&lt;/Name&gt;
              &lt;Protocol&gt;tcp&lt;/Protocol&gt;
            &lt;/InputEndpoint&gt;
          &lt;/InputEndpoints&gt;
        &lt;/ConfigurationSet&gt;
      &lt;/ConfigurationSets&gt;
      &lt;DataVirtualHardDisks/&gt;
      &lt;Label&gt;bXlzdmMxZGlubzY=&lt;/Label&gt;
      &lt;OSVirtualHardDisk&gt;
        &lt;!--VHD address and  source image name--&gt;
        &lt;!--replace these two properties to avaliable value--&gt;
        &lt;MediaLink&gt;https://portalvhds54h52qsyb55v4.blob.core.windows.net/vhds/mysvc-MyWinVM-2012-12-1-107.vhd&lt;/MediaLink&gt;
        &lt;SourceImageName&gt;a699494373c04fc0bc8f2bb1389d6106__Win2K8R2SP1-Datacenter-201212.01-en.us-30GB.vhd&lt;/SourceImageName&gt;
      &lt;/OSVirtualHardDisk&gt;
    &lt;/Role&gt;
  &lt;/RoleList&gt;
&lt;/Deployment&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="Normal"></p>
<p class="MsoNormal">Step 3: Add the operation method to the MainModule.vb file.
</p>
<p class="Normal"><b style="">The following code shows how to generate a create VM request.
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Add a windows server 2008 R2 virtual machine.
''' Need to set the AddVirtualMachine.xml file first
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function AddVirtualMachine() As HttpWebRequest


    'For more details about how to add virtual machine please refer to:
    'http://msdn.microsoft.com/en-us/library/windowsazure/jj157194.aspx.
    Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri(&quot;https://management.core.windows.net/&quot; & subscriptionID & &quot;/services/hostedservices/&quot; & serviceName & &quot;/deployments&quot;)), HttpWebRequest)


    request.Method = &quot;POST&quot;
    request.ClientCertificates.Add(certificate)
    request.ContentType = &quot;application/xml&quot;
    request.Headers.Add(&quot;x-ms-version&quot;, &quot;2012-03-01&quot;)


    'Add body to the request
    Dim xmlDoc As New XmlDocument()
    xmlDoc.Load(&quot;..\..\AddVirtualMachine.xml&quot;)


    Dim requestStream As Stream = request.GetRequestStream()
    Dim streamWriter As New StreamWriter(requestStream, System.Text.UTF8Encoding.UTF8)
    xmlDoc.Save(streamWriter)


    streamWriter.Close()
    requestStream.Close()


    Return request


End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Add a windows server 2008 R2 virtual machine.
''' Need to set the AddVirtualMachine.xml file first
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function AddVirtualMachine() As HttpWebRequest


    'For more details about how to add virtual machine please refer to:
    'http://msdn.microsoft.com/en-us/library/windowsazure/jj157194.aspx.
    Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(New Uri(&quot;https://management.core.windows.net/&quot; & subscriptionID & &quot;/services/hostedservices/&quot; & serviceName & &quot;/deployments&quot;)), HttpWebRequest)


    request.Method = &quot;POST&quot;
    request.ClientCertificates.Add(certificate)
    request.ContentType = &quot;application/xml&quot;
    request.Headers.Add(&quot;x-ms-version&quot;, &quot;2012-03-01&quot;)


    'Add body to the request
    Dim xmlDoc As New XmlDocument()
    xmlDoc.Load(&quot;..\..\AddVirtualMachine.xml&quot;)


    Dim requestStream As Stream = request.GetRequestStream()
    Dim streamWriter As New StreamWriter(requestStream, System.Text.UTF8Encoding.UTF8)
    xmlDoc.Save(streamWriter)


    streamWriter.Close()
    requestStream.Close()


    Return request


End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="Normal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj157194.aspx"><span lang="EN" style="">Create Virtual Machine Deployment</span></a><span lang="EN" style="">
</span></p>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
