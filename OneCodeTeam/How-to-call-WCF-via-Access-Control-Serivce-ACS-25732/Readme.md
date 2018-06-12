# How to call WCF services via Access Control Serivce (ACS) Token in Windows Azure
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Access Control Service (ACS)
## Topics
* OData
* ACS
## IsPublished
* True
## ModifiedDate
* 2013-10-23 08:23:00
## Description

<h1>How to invoke WCF service via OAuth token (VBAzureACSAndODataToken)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The sample code demonstrates how to invoke the WCF service via Access control service token. Here we create a Silverlight application and a normal Console application client. The Token format is SWT, and we will use password
 as the Service identities. </span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">This sample should be <span style="">run with the latest Windows Azure SDK, SQL Server, and Silverlight 5 SDK.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the <span style="">VBAzureACSAndODataToken</span>.sln file with Visual Studio in elevated (administrator) mode, and then you need to set
<span style="">VBAzureACSAndODataToken.Web </span>web application as the startup application.</p>
<p class="MsoNormal">2. Before running this sample, please configure the ACS to make validation of the WCF service. Create a new ACS name space under the option &quot;Service Bus, Access Control &amp; Caching&quot;. Then click &quot;Access Control Service&quot;
 to enter the ACS portal. </p>
<p class="MsoNormal">3. In &quot;Service Identities&quot; section, try to add a new identity as the new security token for service, here we create it with &quot;Password&quot; type, you can input a private password for credential.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Necessary variables from ACS Portal.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Dim serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Dim acsHostUrl As String = &quot;accesscontrol.windows.net&quot;
Dim realm As String = &quot;&lt;Your ACS service path&gt;&quot;
Dim userUrl As String = &quot;&lt;Your user service path&gt;&quot;
Dim uid As String = &quot;&lt;Your service identity name&gt;&quot;
Dim pwd As String = &quot;&lt;Your service identity password&gt;&quot;

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Necessary variables from ACS Portal.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Dim serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Dim acsHostUrl As String = &quot;accesscontrol.windows.net&quot;
Dim realm As String = &quot;&lt;Your ACS service path&gt;&quot;
Dim userUrl As String = &quot;&lt;Your user service path&gt;&quot;
Dim uid As String = &quot;&lt;Your service identity name&gt;&quot;
Dim pwd As String = &quot;&lt;Your service identity password&gt;&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In SWTModule.vb file:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Private acsHostName As String = &quot;accesscontrol.windows.net&quot;
' Certificate and keys
Private trustedTokenPolicyKey As String = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;
' Service Realm
Private trustedAudience As String = &quot;&lt;Your ACS service path&gt;&quot;

</pre>
<pre id="codePreview" class="vb">
Private serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Private acsHostName As String = &quot;accesscontrol.windows.net&quot;
' Certificate and keys
Private trustedTokenPolicyKey As String = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;
' Service Realm
Private trustedAudience As String = &quot;&lt;Your ACS service path&gt;&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">5. Running the sample, you can find a TextBlock and two buttons on the page; you need Get Token from ACS first, and then add the Token in the header of the request to access the service. The response data will be shown in a DataGrid.</p>
<p class="MsoNormal">6. You can also use the Console application to get data from the service; please do not close the web page and right click the Console application &quot;Debug =&gt; Start a new instance&quot;.</p>
<p class="MsoNormal">7. Validation finished</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">1</span>. <span style="">Create a Silverlight Application Project in Visual Studio 2010, name it as &quot;</span><span style="">VBAzureACSAndODataToken</span><span style="">&quot;, and also create asp.net host
 web application in the project. </span></p>
<p class="MsoNormal" style=""><span style="">2. Create other modules: <b></b></span></p>
<p class="MsoNormal" style=""><b><span style="">RESTfulWCFLibrary: </span></b><span style=""><span style="">&nbsp;</span>It creates WCF service and entity class<b>
</b></span></p>
<p class="MsoNormal" style=""><b><span style="">SecurityModule: </span></b><span style="">It validates ACS Token and gets Token via certificate and keys
</span></p>
<p class="MsoNormal" style=""><b><span style="">ConsoleApplication1: </span></b><span style="">A Console client which will invoke service<b>
</b></span></p>
<p class="MsoNormal" style="">3. In RESTfulWCFLibrary, we create some simple methods that could be accessed by clients; here we show the interface of the Service:</p>
<h3>The following code shows<span style=""> how to create and implement the service:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Get all users.
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebGet(UriTemplate:=&quot;/users&quot;, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function GetAllUsers() As List(Of User)


''' &lt;summary&gt;
''' Add a new user instance
''' &lt;/summary&gt;
''' &lt;param name=&quot;u&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebInvoke(UriTemplate:=&quot;/users&quot;, Method:=&quot;POST&quot;, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function AddNewUser(u As User) As Boolean


''' &lt;summary&gt;
''' Get user info by id.
''' &lt;/summary&gt;
''' &lt;param name=&quot;userId&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebGet(UriTemplate:=&quot;/users/{userId}&quot;, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function GetUser(userId As String) As User

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Get all users.
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebGet(UriTemplate:=&quot;/users&quot;, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function GetAllUsers() As List(Of User)


''' &lt;summary&gt;
''' Add a new user instance
''' &lt;/summary&gt;
''' &lt;param name=&quot;u&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebInvoke(UriTemplate:=&quot;/users&quot;, Method:=&quot;POST&quot;, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function AddNewUser(u As User) As Boolean


''' &lt;summary&gt;
''' Get user info by id.
''' &lt;/summary&gt;
''' &lt;param name=&quot;userId&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
&lt;WebGet(UriTemplate:=&quot;/users/{userId}&quot;, ResponseFormat:=WebMessageFormat.Xml)&gt; _
&lt;OperationContract()&gt; _
Function GetUser(userId As String) As User

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal" style="">4. In SecurityModule library, the TokenValidator class authenticates the Token and the SWTModule class is used to get available Token from specific certificate and keys:</p>
<h3>The following code is used to authenticate and get tokens from Access control service<span style="">:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Private acsHostName As String = &quot;accesscontrol.windows.net&quot;
' Certificate and keys
Private trustedTokenPolicyKey As String = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;
' Service Realm
Private trustedAudience As String = &quot;&lt;Your ACS service path&gt;&quot;




Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose


End Sub


Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
    AddHandler context.BeginRequest, AddressOf context_BeginRequest
End Sub


Private Sub context_BeginRequest(sender As Object, e As EventArgs)
    If HttpContext.Current.Request.Url.AbsolutePath.EndsWith(&quot;.svc&quot;) Then
        ' Get the authorization header
        Dim headerValue As String = HttpContext.Current.Request.Headers.[Get](&quot;Authorization&quot;)


        ' Check that a value is there
        If String.IsNullOrEmpty(headerValue) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        ' Check that it starts with 'WRAP'
        If Not headerValue.StartsWith(&quot;WRAP &quot;) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        Dim nameValuePair As String() = headerValue.Substring(&quot;WRAP &quot;.Length).Split(New Char() {&quot;=&quot;c}, 2)


        If nameValuePair.Length &lt;&gt; 2 OrElse nameValuePair(0) &lt;&gt; &quot;access_token&quot; OrElse Not nameValuePair(1).StartsWith(&quot;&quot;&quot;&quot;) OrElse Not nameValuePair(1).EndsWith(&quot;&quot;&quot;&quot;) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        ' Trim off the leading and trailing double-quotes
        Dim token As String = nameValuePair(1).Substring(1, nameValuePair(1).Length - 2)


        ' Create a token validate
        Dim validator As New TokenValidator(Me.acsHostName, Me.serviceNamespace, Me.trustedAudience, Me.trustedTokenPolicyKey)


        ' Validate the token
        If Not validator.Validate(token) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
Private serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Private acsHostName As String = &quot;accesscontrol.windows.net&quot;
' Certificate and keys
Private trustedTokenPolicyKey As String = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;
' Service Realm
Private trustedAudience As String = &quot;&lt;Your ACS service path&gt;&quot;




Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose


End Sub


Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
    AddHandler context.BeginRequest, AddressOf context_BeginRequest
End Sub


Private Sub context_BeginRequest(sender As Object, e As EventArgs)
    If HttpContext.Current.Request.Url.AbsolutePath.EndsWith(&quot;.svc&quot;) Then
        ' Get the authorization header
        Dim headerValue As String = HttpContext.Current.Request.Headers.[Get](&quot;Authorization&quot;)


        ' Check that a value is there
        If String.IsNullOrEmpty(headerValue) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        ' Check that it starts with 'WRAP'
        If Not headerValue.StartsWith(&quot;WRAP &quot;) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        Dim nameValuePair As String() = headerValue.Substring(&quot;WRAP &quot;.Length).Split(New Char() {&quot;=&quot;c}, 2)


        If nameValuePair.Length &lt;&gt; 2 OrElse nameValuePair(0) &lt;&gt; &quot;access_token&quot; OrElse Not nameValuePair(1).StartsWith(&quot;&quot;&quot;&quot;) OrElse Not nameValuePair(1).EndsWith(&quot;&quot;&quot;&quot;) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If


        ' Trim off the leading and trailing double-quotes
        Dim token As String = nameValuePair(1).Substring(1, nameValuePair(1).Length - 2)


        ' Create a token validate
        Dim validator As New TokenValidator(Me.acsHostName, Me.serviceNamespace, Me.trustedAudience, Me.trustedTokenPolicyKey)


        ' Validate the token
        If Not validator.Validate(token) Then
            Throw New ApplicationException(&quot;unauthorized&quot;)
        End If
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><span style="">5. Then you need to add the service reference in VBAzureACSAndODataToken.Web application, add a WCF service file in web application, remove .vb files, and replace the service namespace and Factory properties with
 &quot;RESTfulWCFLibrary.UserService&quot; and &quot;System.ServiceModel.Activation.WebServiceHostFactory&quot;.
</span></p>
<p class="MsoNormal" style=""><span style="">6. Now we need to implement the MainPage.xaml page as the Silverlight client to access token via HttpWebRequest and get data from WCF service. Drag and drop TextBlock, Button, DataGrid control on the Mainpage.xaml
 page, in this sample, we just get the Token and show it in the TextBlock, this is not a recommended way, and you can just add the token in the request. Then we need to create a new HttpWebRequset with the Token to access the service:
</span></p>
<h3>The following code shows<span style=""> how the Silverlight client works with the ACS Token and WCF service:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private issuerLabel As String = &quot;Issuer&quot;
Private expiresLabel As String = &quot;ExpiresOn&quot;
Private audienceLabel As String = &quot;Audience&quot;
Private hmacSHA256Label As String = &quot;HMACSHA256&quot;


Private acsHostName As String


Private trustedSigningKey As String
Private trustedTokenIssuer As String
Private trustedAudienceValue As String


''' &lt;summary&gt;
''' Token validate constructor method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;acsHostName&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;serviceNamespace&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;trustedAudienceValue&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;trustedSigningKey&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Public Sub New(acsHostName As String, serviceNamespace As String, trustedAudienceValue As String, trustedSigningKey As String)
    Me.trustedSigningKey = trustedSigningKey
    Me.trustedTokenIssuer = [String].Format(&quot;https://{0}.{1}/&quot;, serviceNamespace.ToLowerInvariant(), acsHostName.ToLowerInvariant())


    Me.trustedAudienceValue = trustedAudienceValue
End Sub


Public Function Validate(token As String) As Boolean
    If Not Me.IsHMACValid(token, Convert.FromBase64String(Me.trustedSigningKey)) Then
        Return False
    End If


    If Me.IsExpired(token) Then
        Return False
    End If


    If Not Me.IsIssuerTrusted(token) Then
        Return False
    End If


    If Not Me.IsAudienceTrusted(token) Then
        Return False
    End If


    Return True
End Function


Public Function GetNameValues(token As String) As Dictionary(Of String, String)
    If String.IsNullOrEmpty(token) Then
        Throw New ArgumentException()
    End If


    Return token.Split(&quot;&&quot;c).Aggregate(New Dictionary(Of String, String)(), Function(dict, rawNameValue)
                                                                                If rawNameValue = String.Empty Then
                                                                                    Return dict
                                                                                End If


                                                                                Dim nameValue As String() = rawNameValue.Split(&quot;=&quot;c)


                                                                                If nameValue.Length &lt;&gt; 2 Then
                                                                                    Throw New ArgumentException(&quot;Invalid formEncodedstring - contains a name/value pair missing an = character&quot;)
                                                                                End If


                                                                                If dict.ContainsKey(nameValue(0)) = True Then
                                                                                    Throw New ArgumentException(&quot;Repeated name/value pair in form&quot;)
                                                                                End If


                                                                                dict.Add(HttpUtility.UrlDecode(nameValue(0)), HttpUtility.UrlDecode(nameValue(1)))
                                                                                Return dict


                                                                            End Function)
End Function


Private Shared Function GenerateTimeStamp() As ULong
    ' Default implementation of epoch time
    Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, _
     0)
    Return Convert.ToUInt64(ts.TotalSeconds)
End Function


Private Function IsAudienceTrusted(token As String) As Boolean
    Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)


    Dim audienceValue As String


    tokenValues.TryGetValue(Me.audienceLabel, audienceValue)


    If Not String.IsNullOrEmpty(audienceValue) Then
        If audienceValue.Equals(Me.trustedAudienceValue, StringComparison.Ordinal) Then
            Return True
        End If
    End If


    Return False
End Function


Private Function IsIssuerTrusted(token As String) As Boolean
    Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)


    Dim issuerName As String


    tokenValues.TryGetValue(Me.issuerLabel, issuerName)


    If Not String.IsNullOrEmpty(issuerName) Then
        If issuerName.Equals(Me.trustedTokenIssuer) Then
            Return True
        End If
    End If


    Return False
End Function


Private Function IsHMACValid(swt As String, sha256HMACKey As Byte()) As Boolean
    Dim swtWithSignature As String() = swt.Split(New String() {&quot;&&quot; & Me.hmacSHA256Label & &quot;=&quot;}, StringSplitOptions.None)


    If (swtWithSignature Is Nothing) OrElse (swtWithSignature.Length &lt;&gt; 2) Then
        Return False
    End If


    Dim hmac As New HMACSHA256(sha256HMACKey)


    Dim locallyGeneratedSignatureInBytes As Byte() = hmac.ComputeHash(Encoding.ASCII.GetBytes(swtWithSignature(0)))


    Dim locallyGeneratedSignature As String = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes))


    Return locallyGeneratedSignature = swtWithSignature(1)
End Function


Private Function IsExpired(swt As String) As Boolean
    Try
        Dim nameValues As Dictionary(Of String, String) = Me.GetNameValues(swt)
        Dim expiresOnValue As String = nameValues(Me.expiresLabel)
        Dim expiresOn As ULong = Convert.ToUInt64(expiresOnValue)
        Dim currentTime As ULong = Convert.ToUInt64(GenerateTimeStamp())


        If currentTime &gt; expiresOn Then
            Return True
        End If


        Return False
    Catch generatedExceptionName As KeyNotFoundException
        Throw New ArgumentException()
    End Try
End Function

</pre>
<pre id="codePreview" class="vb">
Private issuerLabel As String = &quot;Issuer&quot;
Private expiresLabel As String = &quot;ExpiresOn&quot;
Private audienceLabel As String = &quot;Audience&quot;
Private hmacSHA256Label As String = &quot;HMACSHA256&quot;


Private acsHostName As String


Private trustedSigningKey As String
Private trustedTokenIssuer As String
Private trustedAudienceValue As String


''' &lt;summary&gt;
''' Token validate constructor method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;acsHostName&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;serviceNamespace&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;trustedAudienceValue&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;trustedSigningKey&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Public Sub New(acsHostName As String, serviceNamespace As String, trustedAudienceValue As String, trustedSigningKey As String)
    Me.trustedSigningKey = trustedSigningKey
    Me.trustedTokenIssuer = [String].Format(&quot;https://{0}.{1}/&quot;, serviceNamespace.ToLowerInvariant(), acsHostName.ToLowerInvariant())


    Me.trustedAudienceValue = trustedAudienceValue
End Sub


Public Function Validate(token As String) As Boolean
    If Not Me.IsHMACValid(token, Convert.FromBase64String(Me.trustedSigningKey)) Then
        Return False
    End If


    If Me.IsExpired(token) Then
        Return False
    End If


    If Not Me.IsIssuerTrusted(token) Then
        Return False
    End If


    If Not Me.IsAudienceTrusted(token) Then
        Return False
    End If


    Return True
End Function


Public Function GetNameValues(token As String) As Dictionary(Of String, String)
    If String.IsNullOrEmpty(token) Then
        Throw New ArgumentException()
    End If


    Return token.Split(&quot;&&quot;c).Aggregate(New Dictionary(Of String, String)(), Function(dict, rawNameValue)
                                                                                If rawNameValue = String.Empty Then
                                                                                    Return dict
                                                                                End If


                                                                                Dim nameValue As String() = rawNameValue.Split(&quot;=&quot;c)


                                                                                If nameValue.Length &lt;&gt; 2 Then
                                                                                    Throw New ArgumentException(&quot;Invalid formEncodedstring - contains a name/value pair missing an = character&quot;)
                                                                                End If


                                                                                If dict.ContainsKey(nameValue(0)) = True Then
                                                                                    Throw New ArgumentException(&quot;Repeated name/value pair in form&quot;)
                                                                                End If


                                                                                dict.Add(HttpUtility.UrlDecode(nameValue(0)), HttpUtility.UrlDecode(nameValue(1)))
                                                                                Return dict


                                                                            End Function)
End Function


Private Shared Function GenerateTimeStamp() As ULong
    ' Default implementation of epoch time
    Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, _
     0)
    Return Convert.ToUInt64(ts.TotalSeconds)
End Function


Private Function IsAudienceTrusted(token As String) As Boolean
    Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)


    Dim audienceValue As String


    tokenValues.TryGetValue(Me.audienceLabel, audienceValue)


    If Not String.IsNullOrEmpty(audienceValue) Then
        If audienceValue.Equals(Me.trustedAudienceValue, StringComparison.Ordinal) Then
            Return True
        End If
    End If


    Return False
End Function


Private Function IsIssuerTrusted(token As String) As Boolean
    Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)


    Dim issuerName As String


    tokenValues.TryGetValue(Me.issuerLabel, issuerName)


    If Not String.IsNullOrEmpty(issuerName) Then
        If issuerName.Equals(Me.trustedTokenIssuer) Then
            Return True
        End If
    End If


    Return False
End Function


Private Function IsHMACValid(swt As String, sha256HMACKey As Byte()) As Boolean
    Dim swtWithSignature As String() = swt.Split(New String() {&quot;&&quot; & Me.hmacSHA256Label & &quot;=&quot;}, StringSplitOptions.None)


    If (swtWithSignature Is Nothing) OrElse (swtWithSignature.Length &lt;&gt; 2) Then
        Return False
    End If


    Dim hmac As New HMACSHA256(sha256HMACKey)


    Dim locallyGeneratedSignatureInBytes As Byte() = hmac.ComputeHash(Encoding.ASCII.GetBytes(swtWithSignature(0)))


    Dim locallyGeneratedSignature As String = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes))


    Return locallyGeneratedSignature = swtWithSignature(1)
End Function


Private Function IsExpired(swt As String) As Boolean
    Try
        Dim nameValues As Dictionary(Of String, String) = Me.GetNameValues(swt)
        Dim expiresOnValue As String = nameValues(Me.expiresLabel)
        Dim expiresOn As ULong = Convert.ToUInt64(expiresOnValue)
        Dim currentTime As ULong = Convert.ToUInt64(GenerateTimeStamp())


        If currentTime &gt; expiresOn Then
            Return True
        End If


        Return False
    Catch generatedExceptionName As KeyNotFoundException
        Throw New ArgumentException()
    End Try
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal" style=""><span style="">7. In the application, we also provide a Console application to show how does Console application work with the ACS and WCF service</span>. You can use WebClient instead of HttpWebRequest.<span style="">
</span></p>
<h3>The following code shows <span style="">how Console application works with ACS Token and WCF service.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Necessary variables from ACS Portal.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Dim serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Dim acsHostUrl As String = &quot;accesscontrol.windows.net&quot;
Dim realm As String = &quot;&lt;Your ACS service path&gt;&quot;
Dim userUrl As String = &quot;&lt;Your user service path&gt;&quot;
Dim uid As String = &quot;&lt;Your service identity name&gt;&quot;
Dim pwd As String = &quot;&lt;Your service identity password&gt;&quot;


''' &lt;summary&gt;
''' Access the service via ACS Token.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Sub Main()
    Dim token As String = GetTokenFromACS(realm)


    Dim client As New WebClient()


    Dim headerValue As String = String.Format(&quot;WRAP access_token=&quot;&quot;{0}&quot;&quot;&quot;, token)


    Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(userUrl), HttpWebRequest)
    request.ContentLength = 0
    request.Method = &quot;GET&quot;
    request.Headers(&quot;Authorization&quot;) = headerValue


    Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
    Using reader As New StreamReader(response.GetResponseStream())
        Dim obj As String = reader.ReadToEnd()
        Console.Write(obj)
        Console.ReadLine()
    End Using
End Sub
''' &lt;summary&gt;
''' Get Token from ACS.
''' &lt;/summary&gt;
''' &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Function GetTokenFromACS(scope As String) As String
    Dim wrapPassword As String = pwd
    Dim wrapUsername As String = uid


    ' Request a token from ACS
    Dim client As New WebClient()
    client.BaseAddress = String.Format(&quot;https://{0}.{1}&quot;, serviceNamespace, acsHostUrl)


    Dim values As New NameValueCollection()
    values.Add(&quot;wrap_name&quot;, wrapUsername)
    values.Add(&quot;wrap_password&quot;, wrapPassword)
    values.Add(&quot;wrap_scope&quot;, scope)


    Dim responseBytes As Byte() = client.UploadValues(&quot;WRAPv0.9/&quot;, &quot;POST&quot;, values)


    Dim response As String = Encoding.UTF8.GetString(responseBytes)


    Console.WriteLine(vbLf & &quot;received token from ACS: {0}&quot; & vbLf, response)


    Return HttpUtility.UrlDecode(response.Split(&quot;&&quot;c).[Single](Function(value) value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase)).Split(&quot;=&quot;c)(1))
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Necessary variables from ACS Portal.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Dim serviceNamespace As String = &quot;&lt;Your ACS namespace&gt;&quot;
Dim acsHostUrl As String = &quot;accesscontrol.windows.net&quot;
Dim realm As String = &quot;&lt;Your ACS service path&gt;&quot;
Dim userUrl As String = &quot;&lt;Your user service path&gt;&quot;
Dim uid As String = &quot;&lt;Your service identity name&gt;&quot;
Dim pwd As String = &quot;&lt;Your service identity password&gt;&quot;


''' &lt;summary&gt;
''' Access the service via ACS Token.
''' &lt;/summary&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Sub Main()
    Dim token As String = GetTokenFromACS(realm)


    Dim client As New WebClient()


    Dim headerValue As String = String.Format(&quot;WRAP access_token=&quot;&quot;{0}&quot;&quot;&quot;, token)


    Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(userUrl), HttpWebRequest)
    request.ContentLength = 0
    request.Method = &quot;GET&quot;
    request.Headers(&quot;Authorization&quot;) = headerValue


    Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
    Using reader As New StreamReader(response.GetResponseStream())
        Dim obj As String = reader.ReadToEnd()
        Console.Write(obj)
        Console.ReadLine()
    End Using
End Sub
''' &lt;summary&gt;
''' Get Token from ACS.
''' &lt;/summary&gt;
''' &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Function GetTokenFromACS(scope As String) As String
    Dim wrapPassword As String = pwd
    Dim wrapUsername As String = uid


    ' Request a token from ACS
    Dim client As New WebClient()
    client.BaseAddress = String.Format(&quot;https://{0}.{1}&quot;, serviceNamespace, acsHostUrl)


    Dim values As New NameValueCollection()
    values.Add(&quot;wrap_name&quot;, wrapUsername)
    values.Add(&quot;wrap_password&quot;, wrapPassword)
    values.Add(&quot;wrap_scope&quot;, scope)


    Dim responseBytes As Byte() = client.UploadValues(&quot;WRAPv0.9/&quot;, &quot;POST&quot;, values)


    Dim response As String = Encoding.UTF8.GetString(responseBytes)


    Console.WriteLine(vbLf & &quot;received token from ACS: {0}&quot; & vbLf, response)


    Return HttpUtility.UrlDecode(response.Split(&quot;&&quot;c).[Single](Function(value) value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase)).Split(&quot;=&quot;c)(1))
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">8. Build the application and you can debug it now.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg429786.aspx">Access Control Service 2.0</a><b>
</b></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
