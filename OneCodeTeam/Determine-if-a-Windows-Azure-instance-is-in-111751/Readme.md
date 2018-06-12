# Determine if a Windows Azure instance is in Production or in the Staging slot
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* Staging
## IsPublished
* True
## ModifiedDate
* 2015-01-19 07:39:23
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1><strong>Determine Azure instance is in Production or Staging slot </strong><strong>(</strong><strong>CSAzureDeploymentSlot</strong><strong>)</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>The sample code demonstrates how to determine an Azure instance is in Production or Staging slot. Some customers like to use VIP swap to upgrade their roles (has no service down time), and usually they want to perform different operations depend on the instance's
 current state in Azure Management Portal, for example, disable some events when application is in staging slot. But, as you know, RoleEnvironment class does not provide a property for this. In this sample, we use Windows Azure Management API for achieving
 goal, use &quot;Get Deployment&quot; service to get deployment ID and compare it with current instance.<strong>&nbsp;</strong></p>
<h2><strong>Building the Sample</strong></h2>
<p>To build this sample successfully, please make sure you have installed latest Windows Azure SDK.</p>
<h2><strong>Running the Sample</strong></h2>
<p>1. Open the CSAzureDeploymentSlot.sln file with Visual Studio in elevated (administrator) mode, and then you need to set CSAzureDeploymentSlot Azure application as the startup application.<em>&nbsp;</em></p>
<p>2. Before running the sample, you need to replace the following variables with your Azure application&rsquo;s information, such as subscription ID, hosted service name, etc.</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">string subscriptionID = &quot;&lt;Your subscription ID&gt;&quot;;
string thrumbnail = &quot;&lt;Your certificate thumbnail print&gt;&quot;;
string hostedServiceName = &quot;&lt;Your hosted service name&gt;&quot;;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;subscriptionID&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;subscription&nbsp;ID&gt;&quot;</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;thrumbnail&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;certificate&nbsp;thumbnail&nbsp;print&gt;&quot;</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;hostedServiceName&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;hosted&nbsp;service&nbsp;name&gt;&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>3. You need to upload a server certificate in Azure Management Portal, and also need to add the same thumbnail print client certificate in Web role. Right Click your role =&gt; select &ldquo;Certificates&rdquo; =&gt; &ldquo;Add Certificate&rdquo;.</p>
<p>4. The sample code could not run on the local, because local deploymentID is different with cloud deploymentID, local&rsquo;s ID like &ldquo;Deployment(XXX)&rdquo;, but cloud&rsquo;ID is a GUID. So if you run the application in local, its display &ldquo;Do
 not find this id&rdquo;.</p>
<p>&nbsp;</p>
<p>5. After deploying the application successfully, click the DNS name of the role, if your application is in Staging slot, it will display:</p>
<p>&nbsp;<img id="132724" src="/site/view/file/132724/1/image002.jpg" alt="" width="583" height="533"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>6. If your application is in Production slot, it will display:</p>
<p>&nbsp;<img id="132725" src="/site/view/file/132725/1/image004.jpg" alt="" width="589" height="533"></p>
<p>7. Validation finished</p>
<h2><strong>Using the Code</strong><strong>&nbsp;</strong></h2>
<p>1. Create a Cloud Application Project in Visual Studio 2010, name it as &ldquo;CSAzureDeploymentSlot&rdquo;, please also create a Web Role application and name it as &ldquo;CSAzureDeploymentSlot_WebRole&rdquo;.</p>
<p>2. Delete all unnecessary files of the Web role application, and create a new Default web form page. Add a button control on this page, this page is used to send GET request to Azure management api to get deployment slot from Azure application. Please add
 the following code snippets in Default.aspx.cs file.<strong></strong></p>
<p><strong>The following code shows</strong><strong> how to determine Windows Azure application&rsquo;s current instance deployment slot:</strong></p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">protected void Page_Load(object sender, EventArgs e)
{
    // You basic information of the Deployment of Azure application.
    string deploymentId = RoleEnvironment.DeploymentId;
    string subscriptionID = &quot;&lt;Your subscription ID&gt;&quot;;
    string thrumbnail = &quot;&lt;Your certificate thumbnail print&gt;&quot;;
    string hostedServiceName = &quot;&lt;Your hosted service name&gt;&quot;;
    string productionString = string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Production&quot;);
    Uri requestUri = new Uri(productionString);
 
    // Add client certificate.
    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.OpenExistingOnly);
    X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindByThumbprint, thrumbnail, false);
    store.Close();
 
    if (collection.Count != 0)
    {
        X509Certificate2 certificate = collection[0];
        HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(requestUri);
        httpRequest.ClientCertificates.Add(certificate);
        httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;);
        httpRequest.KeepAlive = false;
        HttpWebResponse httpResponse = httpRequest.GetResponse() as HttpWebResponse;
 
        // Get response stream from Management API.
        Stream stream = httpResponse.GetResponseStream();
        string result = string.Empty;
        using (StreamReader reader = new StreamReader(stream))
        {
            result = reader.ReadToEnd();
 
        }
        if (result == null || result.Trim() == string.Empty)
            return;
        XDocument document = XDocument.Parse(result);
        string serverID = string.Empty;
        var list = from item in document.Descendants(XName.Get(&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                   select item;
        
        serverID = list.First().Value;
        Response.Write(&quot;Check Production: &lt;br /&gt;&quot;);
        Response.Write(&quot;DeploymentID : &quot; &#43; deploymentId &#43; &quot;&lt;br&gt; ServerID :&quot; &#43; serverID);
        if (deploymentId.Equals(serverID))
            lbStatus.Text = &quot;Production&quot;;
        else
        {
            // If the application not in Production slot, try to check Staging slot.
            string stagingString = string.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Staging&quot;);
            Uri stagingUri = new Uri(stagingString);
            httpRequest = (HttpWebRequest)HttpWebRequest.Create(stagingUri);
            httpRequest.ClientCertificates.Add(certificate);
            httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;);
            httpRequest.KeepAlive = false;
            httpResponse = httpRequest.GetResponse() as HttpWebResponse;
            stream = httpResponse.GetResponseStream();
            result = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
 
            }
            if (result == null || result.Trim() == string.Empty)
                return;
            document = XDocument.Parse(result);
            serverID = string.Empty;
            list = from item in document.Descendants(XName.Get(&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                       select item;
 
            serverID = list.First().Value;
            Response.Write(&quot;&lt;br /&gt; Check Staging:&quot;);
            Response.Write(&quot;&lt;br /&gt; DeploymentID : &quot; &#43; deploymentId &#43; &quot;&lt;br&gt; ServerID :&quot; &#43; serverID);
            if (deploymentId.Equals(serverID))
                lbStatus.Text = &quot;Staging&quot;;
            else
                lbStatus.Text = &quot;Do not find this id&quot;;
        }
        httpResponse.Close();
        stream.Close();
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;basic&nbsp;information&nbsp;of&nbsp;the&nbsp;Deployment&nbsp;of&nbsp;Azure&nbsp;application.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;deploymentId&nbsp;=&nbsp;RoleEnvironment.DeploymentId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;subscriptionID&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;subscription&nbsp;ID&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;thrumbnail&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;certificate&nbsp;thumbnail&nbsp;print&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;hostedServiceName&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;Your&nbsp;hosted&nbsp;service&nbsp;name&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;productionString&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;</span>,&nbsp;subscriptionID,&nbsp;hostedServiceName,&nbsp;<span class="cs__string">&quot;Production&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;requestUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(productionString);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;client&nbsp;certificate.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;X509Store&nbsp;store&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;X509Store(StoreName.My,&nbsp;StoreLocation.LocalMachine);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;store.Open(OpenFlags.OpenExistingOnly);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2Collection&nbsp;collection&nbsp;=&nbsp;store.Certificates.Find(X509FindType.FindByThumbprint,&nbsp;thrumbnail,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;store.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(collection.Count&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2&nbsp;certificate&nbsp;=&nbsp;collection[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;httpRequest&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(requestUri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.ClientCertificates.Add(certificate);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.Headers.Add(<span class="cs__string">&quot;x-ms-version&quot;</span>,&nbsp;<span class="cs__string">&quot;2011-10-01&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.KeepAlive&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;httpResponse&nbsp;=&nbsp;httpRequest.GetResponse()&nbsp;<span class="cs__keyword">as</span>&nbsp;HttpWebResponse;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;response&nbsp;stream&nbsp;from&nbsp;Management&nbsp;API.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;stream&nbsp;=&nbsp;httpResponse.GetResponseStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(stream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;||&nbsp;result.Trim()&nbsp;==&nbsp;<span class="cs__keyword">string</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;document&nbsp;=&nbsp;XDocument.Parse(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;serverID&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;list&nbsp;=&nbsp;from&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;document.Descendants(XName.Get(<span class="cs__string">&quot;PrivateID&quot;</span>,&nbsp;<span class="cs__string">&quot;http://schemas.microsoft.com/windowsazure&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;item;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverID&nbsp;=&nbsp;list.First().Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;Check&nbsp;Production:&nbsp;&lt;br&nbsp;/&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;DeploymentID&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;deploymentId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;br&gt;&nbsp;ServerID&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;serverID);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(deploymentId.Equals(serverID))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Production&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;the&nbsp;application&nbsp;not&nbsp;in&nbsp;Production&nbsp;slot,&nbsp;try&nbsp;to&nbsp;check&nbsp;Staging&nbsp;slot.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;stagingString&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;</span>,&nbsp;subscriptionID,&nbsp;hostedServiceName,&nbsp;<span class="cs__string">&quot;Staging&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;stagingUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(stagingString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(stagingUri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.ClientCertificates.Add(certificate);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.Headers.Add(<span class="cs__string">&quot;x-ms-version&quot;</span>,&nbsp;<span class="cs__string">&quot;2011-10-01&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpRequest.KeepAlive&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse&nbsp;=&nbsp;httpRequest.GetResponse()&nbsp;<span class="cs__keyword">as</span>&nbsp;HttpWebResponse;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream&nbsp;=&nbsp;httpResponse.GetResponseStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(stream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;||&nbsp;result.Trim()&nbsp;==&nbsp;<span class="cs__keyword">string</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document&nbsp;=&nbsp;XDocument.Parse(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverID&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list&nbsp;=&nbsp;from&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;document.Descendants(XName.Get(<span class="cs__string">&quot;PrivateID&quot;</span>,&nbsp;<span class="cs__string">&quot;http://schemas.microsoft.com/windowsazure&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;item;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serverID&nbsp;=&nbsp;list.First().Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;&lt;br&nbsp;/&gt;&nbsp;Check&nbsp;Staging:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;&lt;br&nbsp;/&gt;&nbsp;DeploymentID&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;deploymentId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&lt;br&gt;&nbsp;ServerID&nbsp;:&quot;</span>&nbsp;&#43;&nbsp;serverID);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(deploymentId.Equals(serverID))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Staging&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Do&nbsp;not&nbsp;find&nbsp;this&nbsp;id&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpResponse.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br></pre>
<p>3. Build the application and you can debug it now.</p>
<h2><strong>More Information</strong><strong></strong></h2>
<p><a href="http://msdn.microsoft.com/en-us/library/windowsazure/ee460804.aspx">Get Deployment</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleenvironment.deploymentid.aspx">RoleEnvironment.DeploymentId Property</a></p>
