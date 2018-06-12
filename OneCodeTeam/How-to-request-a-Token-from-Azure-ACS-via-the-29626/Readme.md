# How to request a Token from Azure ACS via the OAuth v2 Protocol
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Security
* Azure
* Cloud
* Access Control Service (ACS)
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-06-30 01:07:03
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to request a Token from Azure ACS via the OAuth v2 Protocol
</span><span style="font-weight:bold; font-size:14pt">(</span><span style="font-weight:bold; font-size:14pt">CS\</span><span style="font-weight:bold; font-size:14pt">VBAzureACSWithOauth</span><span style="font-weight:bold; font-size:14pt">)</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">When your web applications and services handle authentication using ACS, the client must obtain a security token issued by ACS to log in to your application or service. In order to obtain this ACS-issued
 token (output token), the client must either authenticate directly with ACS or send ACS a security token issued by its identity provider (input token). ACS validates this input security token, processes the identity claims in this token through the ACS rules
 engine, calculates the output identity claims, and issues an output security token.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">&nbsp;</span><span style="font-size:11pt">This topic describes the methods of requesting a token from ACS via the OAuth
</span><span style="font-size:11pt">V2</span><span style="font-size:11pt"> protocol. All token requests via the OAuth
</span><span style="font-size:11pt">V</span><span style="font-size:11pt">2</span><span style="font-size:11pt">protocol are transmitted over SSL. ACS always issues a Simple Web Token (SWT) via the OAuth
</span><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><span style="font-size:11pt">V</span><span style="font-size:11pt">2</span><span style="font-size:11pt">
</span><span style="font-size:11pt">protocol, in response to a correctly formatted token request. All token requests via the OAuth
</span><span style="font-size:11pt">V</span><span style="font-size:11pt">2</span><span style="font-size:11pt">protocol are sent to ACS in an HTTP POST. You can request an ACS token via the OAuth
</span><span style="font-size:11pt">V</span><span style="font-size:11pt">2 </span>
<span style="font-size:11pt">protocol from any platform that can make an HTTPS FORM POST: .NET Framework, Windows Communication Foundation (WCF), Silverlight, ASP.NET, Java, Python, Ruby, PHP, Flash, and other platforms.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Firs</span><span style="font-size:11pt">t c</span><span style="font-size:11pt">hange all the parameters to yours.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then you can run this application directly</span><span style="font-size:11pt">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to generate a</span><span style="font-size:11pt">n</span><span style="font-size:11pt"> SWT token</span><span style="font-size:11pt">.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">namespace CSAzureACSWithOauth
{
    public class TokenFactory
    {
        string signingKey;
        string issuer;
        public TokenFactory(string issuer, string signingKey)
        {
            this.issuer = issuer;
            this.signingKey = signingKey;
        }
        public string CreateToken()
        {
            StringBuilder builder = new StringBuilder();
            // add the issuer name
            builder.Append(&quot;Issuer=&quot;);
            builder.Append(HttpUtility.UrlEncode(this.issuer));
            string signature = this.GenerateSignature(builder.ToString(), this.signingKey);
            builder.Append(&quot;&amp;HMACSHA256=&quot;);
            builder.Append(signature);
            return builder.ToString();
        }
        private string GenerateSignature(string unsignedToken, string signingKey)
        {
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(signingKey));
            byte[] locallyGeneratedSignatureInBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));
            string locallyGeneratedSignature = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes));
            return locallyGeneratedSignature;
        }
    }
}
</pre>
<pre class="hidden">Public Class TokenFactory
    Private signingKey As String
    Private issuer As String
    Public Sub New(issuer As String, signingKey As String)
        Me.issuer = issuer
        Me.signingKey = signingKey
    End Sub
    Public Function CreateToken() As String
        Dim builder As New StringBuilder()
        ' add the issuer name
        builder.Append(&quot;Issuer=&quot;)
        builder.Append(HttpUtility.UrlEncode(Me.issuer))
        Dim signature As String = Me.GenerateSignature(builder.ToString(), Me.signingKey)
        builder.Append(&quot;&amp;HMACSHA256=&quot;)
        builder.Append(signature)
        Return builder.ToString()
    End Function
    Private Function GenerateSignature(unsignedToken As String, signingKey As String) As String
        Dim hmac As New HMACSHA256(Convert.FromBase64String(signingKey))
        Dim locallyGeneratedSignatureInBytes As Byte() = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken))
        Dim locallyGeneratedSignature As String = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes))
        Return locallyGeneratedSignature
    End Function
End Class
</pre>
<pre id="codePreview" class="csharp">namespace CSAzureACSWithOauth
{
    public class TokenFactory
    {
        string signingKey;
        string issuer;
        public TokenFactory(string issuer, string signingKey)
        {
            this.issuer = issuer;
            this.signingKey = signingKey;
        }
        public string CreateToken()
        {
            StringBuilder builder = new StringBuilder();
            // add the issuer name
            builder.Append(&quot;Issuer=&quot;);
            builder.Append(HttpUtility.UrlEncode(this.issuer));
            string signature = this.GenerateSignature(builder.ToString(), this.signingKey);
            builder.Append(&quot;&amp;HMACSHA256=&quot;);
            builder.Append(signature);
            return builder.ToString();
        }
        private string GenerateSignature(string unsignedToken, string signingKey)
        {
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(signingKey));
            byte[] locallyGeneratedSignatureInBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));
            string locallyGeneratedSignature = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes));
            return locallyGeneratedSignature;
        }
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code below shows how to request a token from ACS via the OAuth V2 protocol</span><span style="font-size:11pt">.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">class Program
   {
       public const string ACSNameSpace = &quot;{Your-ACS-NameSpace}&quot;;
       static void Main(string[] args)
       {
           var accessToken = HttpUtility.UrlDecode(GetTokenBySymmetricKey(&quot;http://dinohy.com/&quot;));
           Console.WriteLine(accessToken);
           Console.ReadLine();
       }
       public static string GetTokenByPassword(string scope)
       {
           try
           {
               const string identityName = &quot;{Service-Identity-Name}&quot;;
               const string identityPassword = &quot;{Password}&quot;;
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;client_credentials&quot;);
               values.Add(&quot;client_id&quot;, identityName);
               values.Add(&quot;client_secret&quot;, identityPassword);
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string GetTokenBySymmetricKey(string scope)
       {
           try
           {
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0&quot;);
               values.Add(&quot;assertion&quot;, createSWT(&quot;{Service-Identity-Name}&quot;, &quot;0ytBPxRB6nc05zv6mjP2aK8rCWWPnP3fR&#43;IDTDHEfSM=&quot;));
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string GetTokenFromAcsBySAML(string scope, string samlToken)
       {
           //For how to create a samlToken please refer to:
           //http://msdn.microsoft.com/en-us/library/aa355062(v=vs.110).aspx
           try
           {
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;,ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;saml2-bearer&quot;);
               values.Add(&quot;assertion&quot;, samlToken);
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string createSWT(string issuer, string signingKey)
       {
           var factory = new TokenFactory(issuer, signingKey);
           return factory.CreateToken();
       }
   }
</pre>
<pre class="hidden">Module Module1
    Public Const ACSNameSpace As String = &quot;{Your-ACS-NameSpace}&quot;
    Sub Main()
        Dim accessToken = HttpUtility.UrlDecode(GetTokenBySymmetricKey(&quot;http://dinohy.com/&quot;))
        Console.WriteLine(accessToken)
        Console.ReadLine()
    End Sub
    Public Function GetTokenByPassword(scope As String) As String
        Try
            Const identityName As String = &quot;{Service-Identity-Name}&quot;
            Const identityPassword As String = &quot;{Password}&quot;
            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace))
            Dim values = New NameValueCollection()
            values.Add(&quot;grant_type&quot;, &quot;client_credentials&quot;)
            values.Add(&quot;client_id&quot;, identityName)
            values.Add(&quot;client_secret&quot;, identityPassword)
            values.Add(&quot;scope&quot;, scope)
            Dim responseBytes As Byte() = client.UploadValues(address, &quot;POST&quot;, values)
            Dim response As String = Encoding.UTF8.GetString(responseBytes)
            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()
            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))
            Return TryCast(decodedDictionary(&quot;access_token&quot;), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try
    End Function
    Public Function GetTokenBySymmetricKey(scope As String) As String
        Try
            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace))
            Dim values = New NameValueCollection()
            values.Add(&quot;grant_type&quot;, &quot;http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0&quot;)
            values.Add(&quot;assertion&quot;, createSWT(&quot;{Service-Identity-Name}&quot;, &quot;0ytBPxRB6nc05zv6mjP2aK8rCWWPnP3fR&#43;IDTDHEfSM=&quot;))
            values.Add(&quot;scope&quot;, scope)
            Dim responseBytes As Byte() = client.UploadValues(address, &quot;POST&quot;, values)
            Dim response As String = Encoding.UTF8.GetString(responseBytes)
            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()
            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))
            Return TryCast(decodedDictionary(&quot;access_token&quot;), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try
    End Function
    Public Function GetTokenFromAcsBySAML(scope As String, samlToken As String) As String
        'For how to create a samlToken please refer to:
        'http://msdn.microsoft.com/en-us/library/aa355062(v=vs.110).aspx
        Try
            ' Request a token from ACS
            Dim client = New WebClient()
            Dim address = New Uri(String.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace))
            Dim values = New NameValueCollection()
            values.Add(&quot;grant_type&quot;, &quot;saml2-bearer&quot;)
            values.Add(&quot;assertion&quot;, samlToken)
            values.Add(&quot;scope&quot;, scope)
            Dim responseBytes As Byte() = client.UploadValues(address, &quot;POST&quot;, values)
            Dim response As String = Encoding.UTF8.GetString(responseBytes)
            ' Parse the JSON response and return the access token
            Dim serializer = New JavaScriptSerializer()
            Dim decodedDictionary = TryCast(serializer.DeserializeObject(response), Dictionary(Of String, Object))
            Return TryCast(decodedDictionary(&quot;access_token&quot;), String)
        Catch wex As WebException
            Dim value As String = New StreamReader(wex.Response.GetResponseStream()).ReadToEnd()
            Throw
        End Try
    End Function
    Public Function createSWT(issuer As String, signingKey As String) As String
        Dim factory = New TokenFactory(issuer, signingKey)
        Return factory.CreateToken()
    End Function
End Module
</pre>
<pre id="codePreview" class="csharp">class Program
   {
       public const string ACSNameSpace = &quot;{Your-ACS-NameSpace}&quot;;
       static void Main(string[] args)
       {
           var accessToken = HttpUtility.UrlDecode(GetTokenBySymmetricKey(&quot;http://dinohy.com/&quot;));
           Console.WriteLine(accessToken);
           Console.ReadLine();
       }
       public static string GetTokenByPassword(string scope)
       {
           try
           {
               const string identityName = &quot;{Service-Identity-Name}&quot;;
               const string identityPassword = &quot;{Password}&quot;;
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;client_credentials&quot;);
               values.Add(&quot;client_id&quot;, identityName);
               values.Add(&quot;client_secret&quot;, identityPassword);
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string GetTokenBySymmetricKey(string scope)
       {
           try
           {
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;, ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0&quot;);
               values.Add(&quot;assertion&quot;, createSWT(&quot;{Service-Identity-Name}&quot;, &quot;0ytBPxRB6nc05zv6mjP2aK8rCWWPnP3fR&#43;IDTDHEfSM=&quot;));
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string GetTokenFromAcsBySAML(string scope, string samlToken)
       {
           //For how to create a samlToken please refer to:
           //http://msdn.microsoft.com/en-us/library/aa355062(v=vs.110).aspx
           try
           {
               // Request a token from ACS
               var client = new WebClient();
               var address = new Uri(string.Format(&quot;https://{0}.accesscontrol.windows.net/v2/OAuth2-13&quot;,ACSNameSpace));
               var values = new NameValueCollection();
               values.Add(&quot;grant_type&quot;, &quot;saml2-bearer&quot;);
               values.Add(&quot;assertion&quot;, samlToken);
               values.Add(&quot;scope&quot;, scope);
               byte[] responseBytes = client.UploadValues(address, &quot;POST&quot;, values);
               string response = Encoding.UTF8.GetString(responseBytes);
               // Parse the JSON response and return the access token
               var serializer = new JavaScriptSerializer();
               var decodedDictionary = serializer.DeserializeObject(response) as Dictionary&lt;string, object&gt;;
               return decodedDictionary[&quot;access_token&quot;] as string;
           }
           catch (WebException wex)
           {
               string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
               throw;
           }
       }
       public static string createSWT(string issuer, string signingKey)
       {
           var factory = new TokenFactory(issuer, signingKey);
           return factory.CreateToken();
       }
   }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><a title="http://msdn.microsoft.com/en-us/library/hh674475.aspx" href="http://msdn.microsoft.com/en-us/library/hh674475.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/hh674475.aspx</a></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
