# Using ACS as an OData token issuer
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* OData
* ACS
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:43:30
## Description

<h1>How to invoke WCF service via OAuth token (CSAzureACSAndODataToken)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The sample code demonstrates how to invoke the WCF service via Access control service token. Here we create a Silverlight application and a normal Console application client. The Token format is SWT, and we will use password
 as the Service identities. </span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">This sample should be <span style="">run with Windows Azure SDK 1.6, SQL Server, and Silverlight 5 SDK.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the <span style="">CSAzureACSAndODataToken</span>.sln file with Visual Studio in elevated (administrator) mode, and then you need to set
<span style="">CSAzureACSAndODataToken.Web </span>web application as the startup application.</p>
<p class="MsoNormal">2. Before running this sample, please configure the ACS to make validation of the WCF service. Create a new ACS name space under the option &quot;Service Bus, Access Control &amp; Caching&quot;. Then click &quot;Access Control Service&quot;
 to enter the ACS portal. </p>
<p class="MsoNormal">3. In &quot;Service Identities&quot; section, try to add a new identity as the new security token for service, here we create it with &quot;Password&quot; type, you can input a private password for credential.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Necessary variables from ACS Portal.
/// &lt;/summary&gt;
const string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
const string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
const string realm = &quot;&lt;Your ACS service path&gt;&quot;;
const string loginUrl = &quot;&lt;Your login path&gt;&quot;;
const string uid = &quot;&lt;Your service identity name&gt;&quot;;
const string pwd = &quot;&lt;Your service identity password&gt;&quot;;

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Necessary variables from ACS Portal.
/// &lt;/summary&gt;
const string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
const string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
const string realm = &quot;&lt;Your ACS service path&gt;&quot;;
const string loginUrl = &quot;&lt;Your login path&gt;&quot;;
const string uid = &quot;&lt;Your service identity name&gt;&quot;;
const string pwd = &quot;&lt;Your service identity password&gt;&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In SWTModule.cs file:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
string acsHostName = &quot;accesscontrol.windows.net&quot;;
// Certificate and keys
string trustedTokenPolicyKey = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;;
// Service Realm
string trustedAudience = &quot;&lt;Your ACS service path&gt;&quot;;

</pre>
<pre id="codePreview" class="csharp">
string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
string acsHostName = &quot;accesscontrol.windows.net&quot;;
// Certificate and keys
string trustedTokenPolicyKey = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;;
// Service Realm
string trustedAudience = &quot;&lt;Your ACS service path&gt;&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">5. Running the sample, you can find a TextBlock and two buttons on the page; you need Get Token from ACS first, and then add the Token in the header of the request to access the service. The response data will be shown in a DataGrid.</p>
<p class="MsoNormal">6. You can also use the Console application to get data from the service; please do not close the web page and right click the Console application &quot;Debug =&gt; Start a new instance&quot;.</p>
<p class="MsoNormal">7. Validation finished</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">1</span>. <span style="">Create a Silverlight Application Project in Visual Studio 2010, name it as &quot;</span><span style="">CSAzureACSAndODataToken</span><span style="">&quot;, and also create asp.net host
 web application in the project. </span></p>
<p class="MsoNormal" style=""><span style="">2. Create other modules: <b></b></span></p>
<p class="MsoNormal" style=""><b><span style="">RESTfulWCFLibrary: </span></b><span style=""><span style="">&nbsp;</span>It creates WCF service and entity class<b>
</b></span></p>
<p class="MsoNormal" style=""><b><span style="">SecurityModule: </span></b><span style="">It validates ACS Token and gets Token via certificate and keys
</span></p>
<p class="MsoNormal" style=""><b><span style="">ConsoleApplication1: </span></b><span style="">A Console client which will invoke service<b>
</b></span></p>
<p class="MsoNormal" style="">3. In RESTfulWCFLibrary, we create some simple methods that could be accessed by clients; here we show the interface of the Service:
</p>
<h3>The following code shows<span style=""> how to create and implement the service:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ServiceContract]
interface IUserService
{
    /// &lt;summary&gt;
    /// Get all users.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/users&quot;,
    ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    List&lt;User&gt; GetAllUsers();


    /// &lt;summary&gt;
    /// Add a new user instance
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;u&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebInvoke(UriTemplate = &quot;/users&quot;,
               Method = &quot;POST&quot;,
               RequestFormat = WebMessageFormat.Xml,
               ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    bool AddNewUser(User u);


    /// &lt;summary&gt;
    /// Get user info by id.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;userId&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/users/{userId}&quot;,
            ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    User GetUser(string userId);
}

</pre>
<pre id="codePreview" class="csharp">
[ServiceContract]
interface IUserService
{
    /// &lt;summary&gt;
    /// Get all users.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/users&quot;,
    ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    List&lt;User&gt; GetAllUsers();


    /// &lt;summary&gt;
    /// Add a new user instance
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;u&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebInvoke(UriTemplate = &quot;/users&quot;,
               Method = &quot;POST&quot;,
               RequestFormat = WebMessageFormat.Xml,
               ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    bool AddNewUser(User u);


    /// &lt;summary&gt;
    /// Get user info by id.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;userId&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/users/{userId}&quot;,
            ResponseFormat = WebMessageFormat.Xml)]
    [OperationContract]
    User GetUser(string userId);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal" style="">4. In SecurityModule library, the TokenValidator class authenticates the Token and the SWTModule class is used to get available Token from specific certificate and keys:
</p>
<h3>The following code is used to authenticate and get tokens from Access control service<span style="">:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class SWTMoudle : IHttpModule
{
    string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
    string acsHostName = &quot;accesscontrol.windows.net&quot;;
    // Certificate and keys
    string trustedTokenPolicyKey = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;;
    // Service Realm
    string trustedAudience = &quot;&lt;Your ACS service path&gt;&quot;;




    void IHttpModule.Dispose()
    {


    }


    void IHttpModule.Init(HttpApplication context)
    {
        context.BeginRequest &#43;= new EventHandler(context_BeginRequest);
    }


    void context_BeginRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Url.AbsolutePath.EndsWith(&quot;.svc&quot;))
        {
            // Get the authorization header
            string headerValue = HttpContext.Current.Request.Headers.Get(&quot;Authorization&quot;);


            // Check that a value is there
            if (string.IsNullOrEmpty(headerValue))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            // Check that it starts with 'WRAP'
            if (!headerValue.StartsWith(&quot;WRAP &quot;))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            string[] nameValuePair = headerValue.Substring(&quot;WRAP &quot;.Length).Split(new char[] { '=' }, 2);


            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != &quot;access_token&quot; ||
                !nameValuePair[1].StartsWith(&quot;\&quot;&quot;) ||
                !nameValuePair[1].EndsWith(&quot;\&quot;&quot;))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            // Trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);


            // Create a token validate
            TokenValidator validator = new TokenValidator(
                this.acsHostName,
                this.serviceNamespace,
                this.trustedAudience,
                this.trustedTokenPolicyKey);


            // Validate the token
            if (!validator.Validate(token))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }
        }
    }


}

</pre>
<pre id="codePreview" class="csharp">
class SWTMoudle : IHttpModule
{
    string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
    string acsHostName = &quot;accesscontrol.windows.net&quot;;
    // Certificate and keys
    string trustedTokenPolicyKey = &quot;&lt;Your Signing certificate symmetric key&gt;&quot;;
    // Service Realm
    string trustedAudience = &quot;&lt;Your ACS service path&gt;&quot;;




    void IHttpModule.Dispose()
    {


    }


    void IHttpModule.Init(HttpApplication context)
    {
        context.BeginRequest &#43;= new EventHandler(context_BeginRequest);
    }


    void context_BeginRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Url.AbsolutePath.EndsWith(&quot;.svc&quot;))
        {
            // Get the authorization header
            string headerValue = HttpContext.Current.Request.Headers.Get(&quot;Authorization&quot;);


            // Check that a value is there
            if (string.IsNullOrEmpty(headerValue))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            // Check that it starts with 'WRAP'
            if (!headerValue.StartsWith(&quot;WRAP &quot;))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            string[] nameValuePair = headerValue.Substring(&quot;WRAP &quot;.Length).Split(new char[] { '=' }, 2);


            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != &quot;access_token&quot; ||
                !nameValuePair[1].StartsWith(&quot;\&quot;&quot;) ||
                !nameValuePair[1].EndsWith(&quot;\&quot;&quot;))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }


            // Trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);


            // Create a token validate
            TokenValidator validator = new TokenValidator(
                this.acsHostName,
                this.serviceNamespace,
                this.trustedAudience,
                this.trustedTokenPolicyKey);


            // Validate the token
            if (!validator.Validate(token))
            {
                throw new ApplicationException(&quot;unauthorized&quot;);
            }
        }
    }


}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><span style="">5. Then you need to add the service reference in CSAzureACSAndODataToken.Web application, add a WCF service file in web application, remove .cs files, and replace the service namespace and Factory properties with
 &quot;RESTfulWCFLibrary.UserService&quot; and &quot;System.ServiceModel.Activation.WebServiceHostFactory&quot;.
</span></p>
<p class="MsoNormal" style=""><span style="">6. Now we need to implement the MainPage.xaml page as the Silverlight client to access token via HttpWebRequest and get data from WCF service. Drag and drop TextBlock, Button, DataGrid control on the Mainpage.xaml
 page, in this sample, we just get the Token and show it in the TextBlock, this is not a recommended way, and you can just add the token in the request. Then we need to create a new HttpWebRequset with the Token to access the service:
</span></p>
<h3>The following code shows<span style=""> how the Silverlight client works with the ACS Token and WCF service:
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Necessary variables from ACS Portal.
/// &lt;/summary&gt;
const string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
const string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
const string realm = &quot;&lt;Your ACS service path&gt;&quot;;
const string loginUrl = &quot;&lt;Your login path&gt;&quot;;
const string uid = &quot;&lt;Your service identity name&gt;&quot;;
const string pwd = &quot;&lt;Your service identity password&gt;&quot;;
string variables;
string tokenString;
public MainPage()
{
    InitializeComponent();
}


/// &lt;summary&gt;
/// Get Token from ACS.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void btnToken_Click(object sender, RoutedEventArgs e)
{
    string token = GetTokenFromACS(realm);
}


/// &lt;summary&gt;
/// Access WCF service.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void btnData_Click(object sender, RoutedEventArgs e)
{
    if (!tbToken.Text.Trim().Equals(string.Empty))
    {
        HttpWebRequest request = HttpWebRequest.Create(loginUrl) as HttpWebRequest;
        string headerValue = string.Format(&quot;WRAP access_token=\&quot;{0}\&quot;&quot;, tokenString);
        request.Method = &quot;GET&quot;;
        request.Headers[&quot;Authorization&quot;] = headerValue;
        AsyncCallback callBack = new AsyncCallback(LoginGetResponse);
        request.BeginGetResponse(callBack, request);


    }
    else
    {
        lbContent.Content = &quot;Please get token first.&quot;;
    }
}


/// &lt;summary&gt;
/// Display data from WCF service.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
public void LoginGetResponse(IAsyncResult result)
{
    HttpWebRequest request = result.AsyncState as HttpWebRequest;
    HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;
    string obj = string.Empty;
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
        obj = reader.ReadToEnd();
    }
    XDocument document = XDocument.Parse(obj);
    var list = from d in document.Descendants(&quot;User&quot;)
               select new User
               {
                   UserId = d.Element(&quot;UserId&quot;).Value,
                   FirstName = d.Element(&quot;FirstName&quot;).Value,
                   LastName = d.Element(&quot;LastName&quot;).Value
               };
    ObservableCollection&lt;User&gt; collection = new ObservableCollection&lt;User&gt;();
    foreach (User user in list)
    {
        collection.Add(user);
    }


    Dispatcher.BeginInvoke(() =&gt;
        {
            dtgContent.ItemsSource = collection;
        });


}




/// &lt;summary&gt;
/// Get Token from ACS portal.
/// &lt;/summary&gt;
/// &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private string GetTokenFromACS(string scope)
{
    string wrapPassword = pwd;
    string wrapUsername = uid;


    // request a token from ACS
    string address = string.Format(&quot;https://{0}.{1}/WRAPv0.9&quot;, serviceNamespace, acsHostUrl);
    HttpWebRequest requestToken = (HttpWebRequest)HttpWebRequest.Create(address);
    variables = string.Format(&quot;{0}={1}&{2}={3}&{4}={5}&quot;, &quot;wrap_name&quot;, wrapUsername, &quot;wrap_password&quot;, wrapPassword, &quot;wrap_scope&quot;, scope);
    requestToken.Method = &quot;POST&quot;;
    AsyncCallback callBack = new AsyncCallback(EndGetRequestStream);
    requestToken.BeginGetRequestStream(callBack, requestToken);
    return tokenString;
}


public void EndGetRequestStream(IAsyncResult result)
{
    HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
    Stream stream = requestToken.EndGetRequestStream(result);
    byte[] bytes = Encoding.UTF8.GetBytes(variables);
    stream.Write(bytes, 0, bytes.Length);
    stream.Close();
    requestToken.BeginGetResponse(TokenEndReponse, requestToken);
}


public void TokenEndReponse(IAsyncResult result)
{
    HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
    HttpWebResponse responseToken = requestToken.EndGetResponse(result) as HttpWebResponse;
    using(StreamReader reader = new StreamReader(responseToken.GetResponseStream()))
    {
        tokenString = reader.ReadToEnd();
    }


    string resultString = HttpUtility.UrlDecode(
        tokenString
        .Split('&')
        .Single(value =&gt; value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase))
        .Split('=')[1]);
    tokenString = resultString;
    Dispatcher.BeginInvoke(() =&gt;
        {
            tbToken.Text = resultString;
        });


}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Necessary variables from ACS Portal.
/// &lt;/summary&gt;
const string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
const string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
const string realm = &quot;&lt;Your ACS service path&gt;&quot;;
const string loginUrl = &quot;&lt;Your login path&gt;&quot;;
const string uid = &quot;&lt;Your service identity name&gt;&quot;;
const string pwd = &quot;&lt;Your service identity password&gt;&quot;;
string variables;
string tokenString;
public MainPage()
{
    InitializeComponent();
}


/// &lt;summary&gt;
/// Get Token from ACS.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void btnToken_Click(object sender, RoutedEventArgs e)
{
    string token = GetTokenFromACS(realm);
}


/// &lt;summary&gt;
/// Access WCF service.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void btnData_Click(object sender, RoutedEventArgs e)
{
    if (!tbToken.Text.Trim().Equals(string.Empty))
    {
        HttpWebRequest request = HttpWebRequest.Create(loginUrl) as HttpWebRequest;
        string headerValue = string.Format(&quot;WRAP access_token=\&quot;{0}\&quot;&quot;, tokenString);
        request.Method = &quot;GET&quot;;
        request.Headers[&quot;Authorization&quot;] = headerValue;
        AsyncCallback callBack = new AsyncCallback(LoginGetResponse);
        request.BeginGetResponse(callBack, request);


    }
    else
    {
        lbContent.Content = &quot;Please get token first.&quot;;
    }
}


/// &lt;summary&gt;
/// Display data from WCF service.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
public void LoginGetResponse(IAsyncResult result)
{
    HttpWebRequest request = result.AsyncState as HttpWebRequest;
    HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;
    string obj = string.Empty;
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
        obj = reader.ReadToEnd();
    }
    XDocument document = XDocument.Parse(obj);
    var list = from d in document.Descendants(&quot;User&quot;)
               select new User
               {
                   UserId = d.Element(&quot;UserId&quot;).Value,
                   FirstName = d.Element(&quot;FirstName&quot;).Value,
                   LastName = d.Element(&quot;LastName&quot;).Value
               };
    ObservableCollection&lt;User&gt; collection = new ObservableCollection&lt;User&gt;();
    foreach (User user in list)
    {
        collection.Add(user);
    }


    Dispatcher.BeginInvoke(() =&gt;
        {
            dtgContent.ItemsSource = collection;
        });


}




/// &lt;summary&gt;
/// Get Token from ACS portal.
/// &lt;/summary&gt;
/// &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private string GetTokenFromACS(string scope)
{
    string wrapPassword = pwd;
    string wrapUsername = uid;


    // request a token from ACS
    string address = string.Format(&quot;https://{0}.{1}/WRAPv0.9&quot;, serviceNamespace, acsHostUrl);
    HttpWebRequest requestToken = (HttpWebRequest)HttpWebRequest.Create(address);
    variables = string.Format(&quot;{0}={1}&{2}={3}&{4}={5}&quot;, &quot;wrap_name&quot;, wrapUsername, &quot;wrap_password&quot;, wrapPassword, &quot;wrap_scope&quot;, scope);
    requestToken.Method = &quot;POST&quot;;
    AsyncCallback callBack = new AsyncCallback(EndGetRequestStream);
    requestToken.BeginGetRequestStream(callBack, requestToken);
    return tokenString;
}


public void EndGetRequestStream(IAsyncResult result)
{
    HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
    Stream stream = requestToken.EndGetRequestStream(result);
    byte[] bytes = Encoding.UTF8.GetBytes(variables);
    stream.Write(bytes, 0, bytes.Length);
    stream.Close();
    requestToken.BeginGetResponse(TokenEndReponse, requestToken);
}


public void TokenEndReponse(IAsyncResult result)
{
    HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
    HttpWebResponse responseToken = requestToken.EndGetResponse(result) as HttpWebResponse;
    using(StreamReader reader = new StreamReader(responseToken.GetResponseStream()))
    {
        tokenString = reader.ReadToEnd();
    }


    string resultString = HttpUtility.UrlDecode(
        tokenString
        .Split('&')
        .Single(value =&gt; value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase))
        .Split('=')[1]);
    tokenString = resultString;
    Dispatcher.BeginInvoke(() =&gt;
        {
            tbToken.Text = resultString;
        });


}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class Program
{
    /// &lt;summary&gt;
    /// Necessary variables from ACS Portal.
    /// &lt;/summary&gt;
    static string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
    static string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
    static string realm = &quot;&lt;Your ACS service path&gt;&quot;;
    static string userUrl = &quot;&lt;Your user service path&gt;&quot;;
    static string uid = &quot;&lt;Your service identity name&gt;&quot;;
    static string pwd = &quot;&lt;Your service identity password&gt;&quot;;


    /// &lt;summary&gt;
    /// Access the service via ACS Token.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;args&quot;&gt;&lt;/param&gt;
    static void Main(string[] args)
    {
        string token = GetTokenFromACS(realm);


        WebClient client = new WebClient();


        string headerValue = string.Format(&quot;WRAP access_token=\&quot;{0}\&quot;&quot;, token);


        HttpWebRequest request = HttpWebRequest.Create(userUrl) as HttpWebRequest;
        request.ContentLength = 0;
        request.Method = &quot;GET&quot;;
        request.Headers[&quot;Authorization&quot;] = headerValue;


        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string obj = reader.ReadToEnd();
            Console.Write(obj);
            Console.ReadLine();
        }
    }


    /// &lt;summary&gt;
    /// Get Token from ACS.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    private static string GetTokenFromACS(string scope)
    {
        string wrapPassword = pwd;
        string wrapUsername = uid;


        // request a token from ACS
        WebClient client = new WebClient();
        client.BaseAddress = string.Format(&quot;https://{0}.{1}&quot;, serviceNamespace, acsHostUrl);


        NameValueCollection values = new NameValueCollection();
        values.Add(&quot;wrap_name&quot;, wrapUsername);
        values.Add(&quot;wrap_password&quot;, wrapPassword);
        values.Add(&quot;wrap_scope&quot;, scope);


        byte[] responseBytes = client.UploadValues(&quot;WRAPv0.9/&quot;, &quot;POST&quot;, values);


        string response = Encoding.UTF8.GetString(responseBytes);


        Console.WriteLine(&quot;\nreceived token from ACS: {0}\n&quot;, response);


        return HttpUtility.UrlDecode(
            response
            .Split('&')
            .Single(value =&gt; value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase))
            .Split('=')[1]);
    }




}

</pre>
<pre id="codePreview" class="csharp">
class Program
{
    /// &lt;summary&gt;
    /// Necessary variables from ACS Portal.
    /// &lt;/summary&gt;
    static string serviceNamespace = &quot;&lt;Your ACS namespace&gt;&quot;;
    static string acsHostUrl = &quot;accesscontrol.windows.net&quot;;
    static string realm = &quot;&lt;Your ACS service path&gt;&quot;;
    static string userUrl = &quot;&lt;Your user service path&gt;&quot;;
    static string uid = &quot;&lt;Your service identity name&gt;&quot;;
    static string pwd = &quot;&lt;Your service identity password&gt;&quot;;


    /// &lt;summary&gt;
    /// Access the service via ACS Token.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;args&quot;&gt;&lt;/param&gt;
    static void Main(string[] args)
    {
        string token = GetTokenFromACS(realm);


        WebClient client = new WebClient();


        string headerValue = string.Format(&quot;WRAP access_token=\&quot;{0}\&quot;&quot;, token);


        HttpWebRequest request = HttpWebRequest.Create(userUrl) as HttpWebRequest;
        request.ContentLength = 0;
        request.Method = &quot;GET&quot;;
        request.Headers[&quot;Authorization&quot;] = headerValue;


        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string obj = reader.ReadToEnd();
            Console.Write(obj);
            Console.ReadLine();
        }
    }


    /// &lt;summary&gt;
    /// Get Token from ACS.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;scope&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    private static string GetTokenFromACS(string scope)
    {
        string wrapPassword = pwd;
        string wrapUsername = uid;


        // request a token from ACS
        WebClient client = new WebClient();
        client.BaseAddress = string.Format(&quot;https://{0}.{1}&quot;, serviceNamespace, acsHostUrl);


        NameValueCollection values = new NameValueCollection();
        values.Add(&quot;wrap_name&quot;, wrapUsername);
        values.Add(&quot;wrap_password&quot;, wrapPassword);
        values.Add(&quot;wrap_scope&quot;, scope);


        byte[] responseBytes = client.UploadValues(&quot;WRAPv0.9/&quot;, &quot;POST&quot;, values);


        string response = Encoding.UTF8.GetString(responseBytes);


        Console.WriteLine(&quot;\nreceived token from ACS: {0}\n&quot;, response);


        return HttpUtility.UrlDecode(
            response
            .Split('&')
            .Single(value =&gt; value.StartsWith(&quot;wrap_access_token=&quot;, StringComparison.OrdinalIgnoreCase))
            .Split('=')[1]);
    }




}

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
