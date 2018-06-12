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
* 2013-07-05 02:37:05
## Description

<p class="MsoNormal">To build this sample successfully, please make sure you have installed<span style=""> Windows Azure SDK 1.6.
</span></p>
<p class="MsoNormal">1. <span style="">Open the </span><span style="">VBAzureDeploymentSlot</span><span style="">.sln file with Visual Studio
</span>in elevated (administrator) mode<span style="">, and then you need to set </span>
<span class="SpellE"><span style="">VBAzureDeploymentSlot</span></span><span style="">
</span><span style="">Azure application as the startup application.</span><i style=""><span style="">
</span></i></p>
<p class="MsoNormal">2.<span style=""> </span>Before running the sample, you need to replace the following variables with your Azure application's information, such as subscription ID, hosted service name, etc.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim subscriptionID As String = &quot;&lt;Your subscription ID&gt;&quot;
Dim thrumbnail As String = &quot;&lt;Your certificate thumbnail print&gt;&quot;
Dim hostedServiceName As String = &quot;&lt;Your hosted service name&gt;&quot;

</pre>
<pre id="codePreview" class="vb">
Dim subscriptionID As String = &quot;&lt;Your subscription ID&gt;&quot;
Dim thrumbnail As String = &quot;&lt;Your certificate thumbnail print&gt;&quot;
Dim hostedServiceName As String = &quot;&lt;Your hosted service name&gt;&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">3. You need to upload a server certificate in Azure Management Portal, and also need to add the same thumbnail print client certificate in Web role. Right Click your role =&gt; select &quot;Certificates&quot; =&gt; &quot;Add
 Certificate&quot;. </p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
4. The sample code could not run on the local, because local <span class="SpellE">
deploymentID</span> is different with cloud <span class="SpellE">deploymentID</span>, local's ID like &quot;<span class="GramE">Deployment(</span>XXX)&quot;, but
<span class="SpellE">cloud'ID</span> is a GUID. So if you run the application in local, its display &quot;Do not find this id&quot;.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
5. After deploying the application successfully, click the DNS name of the role, if your application is in
<span class="GramE">Staging</span> slot, it will display:</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/91811/1/image.png" alt="" width="583" height="533" align="middle">
</span><span style="font-size:9.5pt; font-family:新宋体; color:#A31515"></span></p>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style="">6. If your application is Production slot, it will display<span class="GramE">:<span style="">.</span></span><span style="">
</span></p>
<p class="MsoNormal" style=""><span style=""><img src="/site/view/file/91812/1/image.png" alt="" width="589" height="533" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="">7. <span style="">Validation finished </span></p>
<p class="MsoNormal" style=""><span style="">1</span>. <span style="">Create a Cloud Application Project in Visual Studio 2010, name it as &quot;</span><span style="">VBAzureDeploymentSlot</span><span style="">&quot;, please also create a Web Role application
 and name it as &quot;</span><span style="">VBAzureDeploymentSlot_WebRole</span><span style="">&quot;.
</span></p>
<p class="MsoNormal" style=""><span style="">2. </span>Delete all unnecessary files of the Web role application, and create a new Default web form page. Add a button control on this page, this page is used to send GET request to Azure management api to get
 deployment slot from Azure application. Please add the following code snippets in Default.aspx.vb file.<b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></b></p>
<p class="MsoNormal" style=""><b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows</span></b><b><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"> how to determine Windows
 Azure application's current instance deployment slot: </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' You basic information of the Deployment of Azure application.
    Dim deploymentId As String = RoleEnvironment.DeploymentId
    Dim subscriptionID As String = &quot;&lt;Your subscription ID&gt;&quot;
    Dim thrumbnail As String = &quot;&lt;Your certificate thumbnail print&gt;&quot;
    Dim hostedServiceName As String = &quot;&lt;Your hosted service name&gt;&quot;
    Dim productionString As String = String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Production&quot;)
    Dim requestUri As New Uri(productionString)


    ' Add client certificate.
    Dim store As New X509Store(StoreName.My, StoreLocation.LocalMachine)
    store.Open(OpenFlags.OpenExistingOnly)
    Dim collection As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, thrumbnail, False)
    store.Close()


    If collection.Count &lt;&gt; 0 Then
        Dim certificate As X509Certificate2 = collection(0)
        Dim httpRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUri), HttpWebRequest)
        httpRequest.ClientCertificates.Add(certificate)
        httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;)
        httpRequest.KeepAlive = False
        Dim httpResponse As HttpWebResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)


        ' Get response stream from Management API.
        Dim stream As Stream = httpResponse.GetResponseStream()
        Dim result As String = String.Empty
        Using reader As New StreamReader(stream)


            result = reader.ReadToEnd()
        End Using
        If result Is Nothing OrElse result.Trim() = String.Empty Then
            Return
        End If
        Dim document As XDocument = XDocument.Parse(result)
        Dim serverID As String = String.Empty
        Dim list = From item In document.Descendants(XName.[Get](&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                   Select item


        serverID = list.First().Value
        Response.Write(&quot;Check Production: <br>&quot;)
        Response.Write(&quot;DeploymentID : &quot; & deploymentId & &quot;<br> ServerID :&quot; & serverID)
        If deploymentId.Equals(serverID) Then
            lbStatus.Text = &quot;Production&quot;
        Else
            ' If the application not in Production slot, try to check Staging slot.
            Dim stagingString As String = String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Staging&quot;)
            Dim stagingUri As New Uri(stagingString)
            httpRequest = DirectCast(HttpWebRequest.Create(stagingUri), HttpWebRequest)
            httpRequest.ClientCertificates.Add(certificate)
            httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;)
            httpRequest.KeepAlive = False
            httpResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)
            stream = httpResponse.GetResponseStream()
            result = String.Empty
            Using reader As New StreamReader(stream)


                result = reader.ReadToEnd()
            End Using
            If result Is Nothing OrElse result.Trim() = String.Empty Then
                Return
            End If
            document = XDocument.Parse(result)
            serverID = String.Empty
            list = From item In document.Descendants(XName.[Get](&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                   Select item


            serverID = list.First().Value
            Response.Write(&quot;<br> Check Staging:&quot;)
            Response.Write(&quot;<br> DeploymentID : &quot; & deploymentId & &quot;<br> ServerID :&quot; & serverID)
            If deploymentId.Equals(serverID) Then
                lbStatus.Text = &quot;Staging&quot;
            Else
                lbStatus.Text = &quot;Do not find this id&quot;
            End If
        End If
        httpResponse.Close()
        stream.Close()
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ' You basic information of the Deployment of Azure application.
    Dim deploymentId As String = RoleEnvironment.DeploymentId
    Dim subscriptionID As String = &quot;&lt;Your subscription ID&gt;&quot;
    Dim thrumbnail As String = &quot;&lt;Your certificate thumbnail print&gt;&quot;
    Dim hostedServiceName As String = &quot;&lt;Your hosted service name&gt;&quot;
    Dim productionString As String = String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Production&quot;)
    Dim requestUri As New Uri(productionString)


    ' Add client certificate.
    Dim store As New X509Store(StoreName.My, StoreLocation.LocalMachine)
    store.Open(OpenFlags.OpenExistingOnly)
    Dim collection As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, thrumbnail, False)
    store.Close()


    If collection.Count &lt;&gt; 0 Then
        Dim certificate As X509Certificate2 = collection(0)
        Dim httpRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUri), HttpWebRequest)
        httpRequest.ClientCertificates.Add(certificate)
        httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;)
        httpRequest.KeepAlive = False
        Dim httpResponse As HttpWebResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)


        ' Get response stream from Management API.
        Dim stream As Stream = httpResponse.GetResponseStream()
        Dim result As String = String.Empty
        Using reader As New StreamReader(stream)


            result = reader.ReadToEnd()
        End Using
        If result Is Nothing OrElse result.Trim() = String.Empty Then
            Return
        End If
        Dim document As XDocument = XDocument.Parse(result)
        Dim serverID As String = String.Empty
        Dim list = From item In document.Descendants(XName.[Get](&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                   Select item


        serverID = list.First().Value
        Response.Write(&quot;Check Production: <br>&quot;)
        Response.Write(&quot;DeploymentID : &quot; & deploymentId & &quot;<br> ServerID :&quot; & serverID)
        If deploymentId.Equals(serverID) Then
            lbStatus.Text = &quot;Production&quot;
        Else
            ' If the application not in Production slot, try to check Staging slot.
            Dim stagingString As String = String.Format(&quot;https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}&quot;, subscriptionID, hostedServiceName, &quot;Staging&quot;)
            Dim stagingUri As New Uri(stagingString)
            httpRequest = DirectCast(HttpWebRequest.Create(stagingUri), HttpWebRequest)
            httpRequest.ClientCertificates.Add(certificate)
            httpRequest.Headers.Add(&quot;x-ms-version&quot;, &quot;2011-10-01&quot;)
            httpRequest.KeepAlive = False
            httpResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)
            stream = httpResponse.GetResponseStream()
            result = String.Empty
            Using reader As New StreamReader(stream)


                result = reader.ReadToEnd()
            End Using
            If result Is Nothing OrElse result.Trim() = String.Empty Then
                Return
            End If
            document = XDocument.Parse(result)
            serverID = String.Empty
            list = From item In document.Descendants(XName.[Get](&quot;PrivateID&quot;, &quot;http://schemas.microsoft.com/windowsazure&quot;))
                   Select item


            serverID = list.First().Value
            Response.Write(&quot;<br> Check Staging:&quot;)
            Response.Write(&quot;<br> DeploymentID : &quot; & deploymentId & &quot;<br> ServerID :&quot; & serverID)
            If deploymentId.Equals(serverID) Then
                lbStatus.Text = &quot;Staging&quot;
            Else
                lbStatus.Text = &quot;Do not find this id&quot;
            End If
        End If
        httpResponse.Close()
        stream.Close()
    End If
End Sub

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
