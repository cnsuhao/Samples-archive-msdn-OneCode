# How to control your role instances programmatically in Azure using a WCF service
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-11-02 07:35:24
## Description

<h1><span lang="EN-US">How to control your role instances programmatically in Azure using a WCF service</span></h1>
<h2><strong>Introduction</strong></h2>
<p>Many developers may need to add some additional configuration on their worker Role.</p>
<p>And sometimes they may want to stop some progress on their instances.</p>
<p>This sample will show you how to start a WCF service which can execute any script file or .exe file on every instance.</p>
<h2><strong>Running the Sample</strong></h2>
<ol>
<li><span style="font-size:10px">Change StorageConnectionString to your own storage connection string.<img src="/site/view/file/85020/1/image.png" alt="" width="576" height="148" align="middle"></span>
</li><li><span style="font-size:10px">Publish the worker role to Azure.</span> </li><li>Create an executable file and upload it to your blob storage, for example: you can create an application which will generate a test.txt file on E:\.
</li><li>Set Client application as startup project. Change the address to your own, and you can find it on your portal.
</li><li>Run the client project. </li><li>Log in to each of your remote instance, then go to the E:\ and you will every instance E:\ contain the test.txt file.
</li></ol>
<h2><strong>Using code</strong></h2>
<p><span style="font-size:10px">&nbsp; &nbsp; &nbsp;1. Create a cloud service named CSAzureRunScriptOnEachInstance.</span></p>
<p><span style="font-size:10px">&nbsp;</span><span style="font-size:10px">&nbsp; &nbsp; &nbsp;2. In the workerRole.cs use the code below:</span></p>
<p><strong>This code shows how to host a WCF service on the Worker Role</strong></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine(&quot;WorkerRole1 entry point called&quot;, &quot;Information&quot;);

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine(&quot;Working&quot;, &quot;Information&quot;);
            }
        }

        public override bool OnStart()
        {
            var internalEndPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[&quot;InternalEndPoint&quot;];

            ServiceHost host = new ServiceHost(typeof(InstanceControllerService));
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None;

            host.AddServiceEndpoint(typeof(IInstanceController), binding, string.Format(&quot;http://{0}/InternalService&quot;, internalEndPoint.IPEndpoint));
            if (host.Description.Behaviors.Find&lt;ServiceMetadataBehavior&gt;() == null)
            {
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                behavior.HttpGetUrl = new Uri(string.Format(&quot;http://{0}/InternalService/metadata&quot;, internalEndPoint.IPEndpoint));
                host.Description.Behaviors.Add(behavior);
            }
         
            host.Open();
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;WorkerRole1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WorkerRole&nbsp;:&nbsp;RoleEntryPoint&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Run()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;is&nbsp;a&nbsp;sample&nbsp;worker&nbsp;implementation.&nbsp;Replace&nbsp;with&nbsp;your&nbsp;logic.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trace.WriteLine(<span class="cs__string">&quot;WorkerRole1&nbsp;entry&nbsp;point&nbsp;called&quot;</span>,&nbsp;<span class="cs__string">&quot;Information&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">10000</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trace.WriteLine(<span class="cs__string">&quot;Working&quot;</span>,&nbsp;<span class="cs__string">&quot;Information&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;OnStart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;internalEndPoint&nbsp;=&nbsp;RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[<span class="cs__string">&quot;InternalEndPoint&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceHost&nbsp;host&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceHost(<span class="cs__keyword">typeof</span>(InstanceControllerService));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BasicHttpBinding&nbsp;binding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BasicHttpBinding();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;binding.Security.Mode&nbsp;=&nbsp;BasicHttpSecurityMode.None;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.AddServiceEndpoint(<span class="cs__keyword">typeof</span>(IInstanceController),&nbsp;binding,&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;http://{0}/InternalService&quot;</span>,&nbsp;internalEndPoint.IPEndpoint));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(host.Description.Behaviors.Find&lt;ServiceMetadataBehavior&gt;()&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceMetadataBehavior&nbsp;behavior&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceMetadataBehavior();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;behavior.HttpGetEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;behavior.HttpGetUrl&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;http://{0}/InternalService/metadata&quot;</span>,&nbsp;internalEndPoint.IPEndpoint));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Description.Behaviors.Add(behavior);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;information&nbsp;on&nbsp;handling&nbsp;configuration&nbsp;changes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;see&nbsp;the&nbsp;MSDN&nbsp;topic&nbsp;at&nbsp;http://go.microsoft.com/fwlink/?LinkId=166357.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnStart();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt">&nbsp;</p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt">3. Create an Interface named IInstanceController as a contract in WCF service</p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;</span></span></span><span lang="EN-US">Implement the interface in worker role; create a service reference.</span></p>
<p class="Normal" style="margin-left:18pt; text-indent:5pt"><span lang="EN-US">&nbsp;</span><strong style="text-indent:5pt; font-size:10px">Get the file run on your instances.</strong></p>
<p class="Normal" style="margin-left:18pt; text-indent:5pt"><strong style="text-indent:5pt; font-size:10px"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public bool RunScriptOnEveryInstance(string Container,string FileName)
{
    var internalEndpointList = GetInstanceInternalEndPoint();
    try
    {
        foreach (var internalEndpoint in internalEndpointList)
        {

            BasicHttpBinding binding = new BasicHttpBinding();
            using (ChannelFactory&lt;IInstanceController&gt; channel = new ChannelFactory&lt;IInstanceController&gt;(binding, string.Format(&quot;http://{0}/InternalService&quot;, internalEndpoint)))
            {
                IInstanceController proxy = channel.CreateChannel();
                proxy.RunExecutableFile(Container, FileName);
            }
        }
        return true;
    }
    catch (Exception e)
    {
        //TODO: Add your logic here.
        return false;
    }   
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;RunScriptOnEveryInstance(<span class="cs__keyword">string</span>&nbsp;Container,<span class="cs__keyword">string</span>&nbsp;FileName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;internalEndpointList&nbsp;=&nbsp;GetInstanceInternalEndPoint();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;internalEndpoint&nbsp;<span class="cs__keyword">in</span>&nbsp;internalEndpointList)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BasicHttpBinding&nbsp;binding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BasicHttpBinding();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(ChannelFactory&lt;IInstanceController&gt;&nbsp;channel&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChannelFactory&lt;IInstanceController&gt;(binding,&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;http://{0}/InternalService&quot;</span>,&nbsp;internalEndpoint)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IInstanceController&nbsp;proxy&nbsp;=&nbsp;channel.CreateChannel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxy.RunExecutableFile(Container,&nbsp;FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//TODO:&nbsp;Add&nbsp;your&nbsp;logic&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Download the executable file from Blob.</strong></div>
<div class="endscriptcode"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void DownLoadFileFromBlob(string ContainerName, string FileName)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(&quot;StorageConnectionString&quot;));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
            string directoryPath = CreateTempDirectory();
            _filePath = directoryPath &#43; &quot;\\&quot; &#43; FileName;
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(_filePath))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DownLoadFileFromBlob(<span class="cs__keyword">string</span>&nbsp;ContainerName,&nbsp;<span class="cs__keyword">string</span>&nbsp;FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudStorageAccount&nbsp;storageAccount&nbsp;=&nbsp;CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(<span class="cs__string">&quot;StorageConnectionString&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlobClient&nbsp;blobClient&nbsp;=&nbsp;storageAccount.CreateCloudBlobClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlobContainer&nbsp;container&nbsp;=&nbsp;blobClient.GetContainerReference(ContainerName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;directoryPath&nbsp;=&nbsp;CreateTempDirectory();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_filePath&nbsp;=&nbsp;directoryPath&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\&quot;</span>&nbsp;&#43;&nbsp;FileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlockBlob&nbsp;blockBlob&nbsp;=&nbsp;container.GetBlockBlobReference(FileName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Save&nbsp;blob&nbsp;contents&nbsp;to&nbsp;a&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;fileStream&nbsp;=&nbsp;System.IO.File.OpenWrite(_filePath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blockBlob.DownloadToStream(fileStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</strong></div>
</strong>
<p></p>
<p class="Normal"><span lang="EN-US">5. Finally create a Client project and test this project.</span></p>
<h2><strong>More Information</strong></h2>
<p><a href="http://msdn.microsoft.com/en-us/spazuretrainingcourse_azurefromsponpremusingjquery_topic2.aspx">http://msdn.microsoft.com/en-us/spazuretrainingcourse_azurefromsponpremusingjquery_topic2.aspx</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj156007.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/jj156007.aspx</a></p>
<p><a href="http://blogs.msdn.com/b/avkashchauhan/archive/2012/01/18/windows-azure-application-vm-and-virtual-ip-address.aspx">http://blogs.msdn.com/b/avkashchauhan/archive/2012/01/18/windows-azure-application-vm-and-virtual-ip-address.aspx</a></p>
<p>&nbsp;</p>
<p class="Normal"><span lang="EN-US"><br>
</span></p>
<p class="Normal"><span lang="EN-US">&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
