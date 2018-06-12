# How to determine Azure instance in which slot
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Staging
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:38:10
## Description

<p class="MsoNormal">To build this sample successfully, please make sure you have installed<span style=""> Windows Azure SDK 1.6.
</span></p>
<p class="MsoNormal">1. <span style="">Open the </span><span style="">CSAzureDeploymentSlot</span><span style="">.sln file with Visual Studio
</span>in elevated (administrator) mode<span style="">, and then you need to set </span>
<span class="SpellE"><span style="">CSAzureDeploymentSlot</span></span><span style="">
</span><span style="">Azure application as the startup application.</span><i style=""><span style="">
</span></i></p>
<p class="MsoNormal">2.<span style=""> </span>Before running the sample, you need to replace the following variables with your Azure application's information, such as subscription ID, hosted service name, etc.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string subscriptionID = &quot;&lt;Your subscription ID&gt;&quot;;
string thrumbnail = &quot;&lt;Your certificate thumbnail print&gt;&quot;;
string hostedServiceName = &quot;&lt;Your hosted service name&gt;&quot;;

</pre>
<pre id="codePreview" class="csharp">
string subscriptionID = &quot;&lt;Your subscription ID&gt;&quot;;
string thrumbnail = &quot;&lt;Your certificate thumbnail print&gt;&quot;;
string hostedServiceName = &quot;&lt;Your hosted service name&gt;&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">3. You need to upload a server certificate in Azure Management Portal, and also need to add the same thumbnail print client certificate in Web role. Right Click your role =&gt; select &quot;Certificates&quot; =&gt; &quot;Add
 Certificate&quot;.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
4. The sample code could not run on the local, because local deploymentID is different with cloud deploymentID, local's ID like &quot;Deployment(XXX)&quot;, but cloud'ID is a GUID. So if you run the application in local, its display &quot;Do not find this id&quot;.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
5. After deploying the application successfully, click the DNS name of the role, if your application is in
<span class="GramE">Staging</span> slot, it will display:</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/91814/1/image.png" alt="" width="583" height="533" align="middle">
</span><span style="font-size:9.5pt; font-family:新宋体; color:#A31515"></span></p>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style="">6. If your application is in Production slot, it will display:<span style="">
</span></p>
<p class="MsoNormal" style=""><span style=""><img src="/site/view/file/91815/1/image.png" alt="" width="589" height="533" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="">7. <span style="">Validation finished </span></p>
<p class="MsoNormal" style=""><span style="">1</span>. <span style="">Create a Cloud Application Project in Visual Studio 2010, name it as &quot;</span><span style="">CSAzureDeploymentSlot</span><span style="">&quot;, please also create a Web Role application
 and name it as &quot;</span><span style="">CSAzureDeploymentSlot_WebRole</span><span style="">&quot;.
</span></p>
<p class="MsoNormal" style=""><span style="">2. </span>Delete all unnecessary files of the Web role application, and create a new Default web form page. Add a button control on this page, this page is used to send GET request to Azure management api to get
 deployment slot from Azure application. Please add the following code snippets in Default.aspx.cs file.<b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></b></p>
<p class="MsoNormal" style=""><b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows</span></b><b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"> how to determine Windows
 Azure application's current instance deployment slot: </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void Page_Load(object sender, EventArgs e)
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
        Response.Write(&quot;Check Production: <br>&quot;);
        Response.Write(&quot;DeploymentID : &quot; &#43; deploymentId &#43; &quot;<br> ServerID :&quot; &#43; serverID);
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
            Response.Write(&quot;<br> Check Staging:&quot;);
            Response.Write(&quot;<br> DeploymentID : &quot; &#43; deploymentId &#43; &quot;<br> ServerID :&quot; &#43; serverID);
            if (deploymentId.Equals(serverID))
                lbStatus.Text = &quot;Staging&quot;;
            else
                lbStatus.Text = &quot;Do not find this id&quot;;
        }
        httpResponse.Close();
        stream.Close();
    }
}

</pre>
<pre id="codePreview" class="csharp">
protected void Page_Load(object sender, EventArgs e)
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
        Response.Write(&quot;Check Production: <br>&quot;);
        Response.Write(&quot;DeploymentID : &quot; &#43; deploymentId &#43; &quot;<br> ServerID :&quot; &#43; serverID);
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
            Response.Write(&quot;<br> Check Staging:&quot;);
            Response.Write(&quot;<br> DeploymentID : &quot; &#43; deploymentId &#43; &quot;<br> ServerID :&quot; &#43; serverID);
            if (deploymentId.Equals(serverID))
                lbStatus.Text = &quot;Staging&quot;;
            else
                lbStatus.Text = &quot;Do not find this id&quot;;
        }
        httpResponse.Close();
        stream.Close();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">3. Build the application and you can debug it now.</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/windowsazure/ee460804.aspx">Get Deployment</a></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleenvironment.deploymentid.aspx"><span class="SpellE">RoleEnvironment.DeploymentId</span> Property</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
