# Call web services through service bus by Windows Phone Application
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Phone
* Windows Phone Development
## Topics
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:42:43
## Description

<p class="MsoNormal">The sample code demonstrates how to expose an on-premise REST service to Internet via Service Bus, then you can access this service by Windows Phone application. The service includes normal string, generics and image methods.</p>
<p class="MsoNormal"><span style="">Before running this sample, please install Windows Azure SDK 1.6 and Windows Azure Toolkit for Visual Studio
</span></p>
<p class="MsoNormal"><span style=""><a href="http://www.windowsazure.com/en-us/develop/downloads/">http://www.windowsazure.com/en-us/develop/downloads/</a>
</span></p>
<p class="MsoNormal"><span style="">SQL Server 2008 R2 Express: </span></p>
<p class="MsoNormal"><span style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=23650">http://www.microsoft.com/download/en/details.aspx?id=23650</a>
</span></p>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">CSAzureServiceBusWithWindowsPhone</span>.sln<span style=""> as Administrator</span>. Expand the
<a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""><span style="">CSAzureServiceBusWithWindowsPhone</span></span></a><span style=""><span style=""><span style="">
</span></span></span><span style="">application, find the app.config file and input your Service Bus namespace, issuer name and key.</span> Then
<span style="">set ServiceBusServices Console application as the startup project, press &quot;Ctrl&#43;F5&quot; for running the service</span>.
<span style="">The following screenshot shows the service is running:</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91847/1/image.png" alt="" width="678" height="442" align="middle">
</span></p>
<p class="MsoNormal">Step 2: The next step, please modify the service url of the sample, in MainPage.xaml.cs page, replace the
<b style="">servicebusNamespace</b> variable as your namespace. For example, </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static string servicebusNamespace = &quot;your namespace&quot;;

</pre>
<pre id="codePreview" class="csharp">
static string servicebusNamespace = &quot;your namespace&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;</span>Then set <span style="">CSAzureServiceBusWithWindowsPhone as the startup application and press &quot;F5&quot; or right click the project file and select debug =&gt; Start New Instance for running the Windows
 Phone application. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91848/1/image.png" alt="" width="402" height="731" align="middle">
</span></p>
<p class="MsoNormal">Step 3: <span style="">Click &quot;Get Hello&quot; button to test hello method, it shows &quot;Hello&quot; &amp; your send parameter in the content of Button:
</span></p>
<p class="MsoNormal"><span style="">&nbsp;</span><span style=""> <img src="/site/view/file/91849/1/image.png" alt="" width="402" height="731" align="middle">
</span></p>
<p class="MsoNormal">Step 4: <span style="">Click &quot;Get Person&quot; button to test Person method, it will get two entities from Person service and add them in a ListBox control:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91850/1/image.png" alt="" width="402" height="731" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 5: Click &quot;Get Image&quot; button to test Image method, it shows a Microsoft.jpg under the Get Image button:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91851/1/image.png" alt="" width="402" height="731" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step <span style="">6</span>: Validation finished.</p>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;Windows <span style="">Console Application</span>&quot; in Visual Studio 201<span style="">0</span>. Name it as &quot;<span style="">ServiceBusServices</span>&quot;.
<span style="">Add a Service Interface class and name it as &quot;IWindowsPhoneService&quot;, a Service class implements the interface, a model class and app.config file.
</span></p>
<p class="MsoNormal">Step 2. <span style="">The following reference is necessary to the ServiceBusServices project, please add them in your application:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">Microsoft.ServiceBus </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">System.ServiceModel </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">System.ServiceModel.Web </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">System.configuration </span></b></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">System.Xml.Linq </span></b></p>
<p class="MsoNormal"><span style="">Step 3, The Person.cs is the Model class, you can add some basic properties of person, such as name, age, etc. The IWindowsPhoneService includes three service methods: Hello, Person, Image.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ServiceContract]
public interface IWindowsPhoneService
{
    /// &lt;summary&gt;
    /// Hello method contract.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Hello?name={name}&quot;)]
    String Hello(string name);


    /// &lt;summary&gt;
    /// Image method contract.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Image&quot;)]
    Stream Image();


    /// &lt;summary&gt;
    /// Person method contract.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Person&quot;)]
    List&lt;Person&gt; Persons();

</pre>
<pre id="codePreview" class="csharp">
[ServiceContract]
public interface IWindowsPhoneService
{
    /// &lt;summary&gt;
    /// Hello method contract.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Hello?name={name}&quot;)]
    String Hello(string name);


    /// &lt;summary&gt;
    /// Image method contract.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Image&quot;)]
    Stream Image();


    /// &lt;summary&gt;
    /// Person method contract.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    [WebGet(UriTemplate = &quot;/Person&quot;)]
    List&lt;Person&gt; Persons();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style="">Step 4. <span style="">Then you need create a class &quot;WindowsPhoneService&quot; to implement the interface. And add necessary configuration in app.comfig file. At last, create ServiceHost and expost the service with ServiceBus
 issuer and key. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class Program
{
    static void Main(string[] args)
    {
        string serviceNamespace = ConfigurationManager.AppSettings[&quot;serviceNamespace&quot;];
        Uri address = ServiceBusEnvironment.CreateServiceUri(&quot;http&quot;, serviceNamespace, &quot;&quot;);


        // Create WebHttpRelayBinding instance.
        WebHttpRelayBinding binding = new WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None);
        
        // Create ServiceHost with endpoint.
        var host = new ServiceHost(typeof(WindowsPhoneService), address);
        host.AddServiceEndpoint(typeof(IWindowsPhoneService), binding, address);
        var behavior = host.Description.Endpoints[0].Behaviors;


        // Add ServiceBus key.
        behavior.Add(new TransportClientEndpointBehavior(TokenProvider.CreateSharedSecretTokenProvider(ConfigurationManager.AppSettings[&quot;issuer&quot;], ConfigurationManager.AppSettings[&quot;key&quot;])));
        behavior.Add(new WebHttpBehavior());
        host.Open();


        Console.WriteLine(&quot;Service listening at: &quot; &#43; host.Description.Endpoints[0].Address);
        Console.WriteLine(&quot;Press any key to exit...&quot;);
        Console.ReadKey();


        host.Close();
    }
}

</pre>
<pre id="codePreview" class="csharp">
class Program
{
    static void Main(string[] args)
    {
        string serviceNamespace = ConfigurationManager.AppSettings[&quot;serviceNamespace&quot;];
        Uri address = ServiceBusEnvironment.CreateServiceUri(&quot;http&quot;, serviceNamespace, &quot;&quot;);


        // Create WebHttpRelayBinding instance.
        WebHttpRelayBinding binding = new WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None);
        
        // Create ServiceHost with endpoint.
        var host = new ServiceHost(typeof(WindowsPhoneService), address);
        host.AddServiceEndpoint(typeof(IWindowsPhoneService), binding, address);
        var behavior = host.Description.Endpoints[0].Behaviors;


        // Add ServiceBus key.
        behavior.Add(new TransportClientEndpointBehavior(TokenProvider.CreateSharedSecretTokenProvider(ConfigurationManager.AppSettings[&quot;issuer&quot;], ConfigurationManager.AppSettings[&quot;key&quot;])));
        behavior.Add(new WebHttpBehavior());
        host.Open();


        Console.WriteLine(&quot;Service listening at: &quot; &#43; host.Description.Endpoints[0].Address);
        Console.WriteLine(&quot;Press any key to exit...&quot;);
        Console.ReadKey();


        host.Close();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step <span style="">5. Add a &quot;Windows Phone Application&quot; in the solution, add 3 buttons, a ListBox and a, Image control in the MainPage.xaml with following C# code:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
HttpWebRequest request;
static string servicebusNamespace = &quot;[Your Namespace]&quot;;
string helloUri = String.Format(&quot;http://{0}.servicebus.windows.net/Hello?name=New User&quot;, servicebusNamespace);
string personUri = String.Format(&quot;http://{0}.servicebus.windows.net/Person&quot;, servicebusNamespace);
string imageUri = String.Format(&quot;http://{0}.servicebus.windows.net/Image&quot;, servicebusNamespace);
// Constructor
public MainPage()
{
    InitializeComponent();
}


/// &lt;summary&gt;
/// Invoke Hello service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button1_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(helloUri);
    request.Method = &quot;GET&quot;;
    btnHello.Content = &quot;Wait for your information..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(Process), &quot;&quot;);
}


/// &lt;summary&gt;
/// Give information to button's content property.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void Process(IAsyncResult result)
{
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    string s = string.Empty;
    using (StreamReader reader = new StreamReader(stream))
    {
        s = reader.ReadToEnd();
        s = Regex.Replace(s, @&quot;&lt;(.[^&gt;]*)&gt;&quot;, &quot;&quot;, RegexOptions.IgnoreCase);
    }
    Dispatcher.BeginInvoke(new Action(() =&gt; 
    {
        btnHello.Content = s;
        btnPerson.Content = &quot;Get Person&quot;;
        btnImage.Content = &quot;Get Image&quot;;
        lstData.Visibility = Visibility.Collapsed;
        imgSource.Visibility = Visibility.Collapsed;
    }));
}


/// &lt;summary&gt;
/// Invoke Person service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button2_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(personUri);
    request.Method = &quot;GET&quot;;
    btnPerson.Content = &quot;Wait for your information..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(PersonProcess), &quot;&quot;);
}


/// &lt;summary&gt;
/// Give Person model class entity information to ListBox control.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void PersonProcess(IAsyncResult result)
{
    Dispatcher.BeginInvoke(new Action(() =&gt;
        {
            lstData.Items.Clear();
        }));
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    string str = string.Empty;
    List&lt;Person&gt; list = new List&lt;Person&gt;();
    using (StreamReader reader = new StreamReader(stream))
    {
        str &#43;= reader.ReadToEnd();


        MatchCollection collection = Regex.Matches(str, @&quot;&lt;Person.*?&gt;(.*?)&lt;/Person&gt;&quot;);
        foreach (Match c in collection)
        {
            if (!c.Value.Equals(string.Empty))
            {
                Person person = new Person();
                person.Name = Regex.Replace(Regex.Match(c.Value, @&quot;&lt;Name.*?&gt;(.*?)&lt;/Name&gt;&quot;).Value, @&quot;&lt;[^&gt;]*&gt;&quot;, string.Empty, RegexOptions.IgnoreCase);
                person.Comments = Regex.Replace(Regex.Match(c.Value, @&quot;&lt;Comments&gt;((\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*)&lt;/Comments&gt;&quot;).Value, @&quot;&lt;[^&gt;]*&gt;&quot;, string.Empty, RegexOptions.IgnoreCase);
                list.Add(person);
            }
        }


        Dispatcher.BeginInvoke(new Action(() =&gt;
            {
                foreach (Person p in list)
                {
                    lstData.Items.Add(&quot;Person Name:&quot; &#43; p.Name);
                    lstData.Items.Add(&quot;Person Comments:&quot; &#43; p.Comments);
                    btnPerson.Content = &quot;OK&quot;;
                    lstData.Visibility = Visibility.Visible;
                    imgSource.Visibility = Visibility.Collapsed;
                    btnImage.Content = &quot;Get Image&quot;;
                    btnHello.Content = &quot;Get Hello&quot;;
                }
            }));
    }


}


/// &lt;summary&gt;
/// Invoke Image service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button3_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(imageUri);
    request.Method = &quot;GET&quot;;
    btnImage.Content = &quot;Wait for your image..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(ImageProcess), null);
}


/// &lt;summary&gt;
/// Give Image stream to Image control.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void ImageProcess(IAsyncResult result)
{
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    Dispatcher.BeginInvoke(new Action(() =&gt;
    {
        BitmapImage source = new BitmapImage();
        source.SetSource(stream);
        imgSource.Source = source;
        lstData.Visibility = Visibility.Collapsed;
        imgSource.Visibility = Visibility.Visible;
        btnImage.Content = &quot;OK&quot;;
        btnPerson.Content = &quot;Get Person&quot;;
        btnHello.Content = &quot;Get Hello&quot;;
    }));


}

</pre>
<pre id="codePreview" class="csharp">
HttpWebRequest request;
static string servicebusNamespace = &quot;[Your Namespace]&quot;;
string helloUri = String.Format(&quot;http://{0}.servicebus.windows.net/Hello?name=New User&quot;, servicebusNamespace);
string personUri = String.Format(&quot;http://{0}.servicebus.windows.net/Person&quot;, servicebusNamespace);
string imageUri = String.Format(&quot;http://{0}.servicebus.windows.net/Image&quot;, servicebusNamespace);
// Constructor
public MainPage()
{
    InitializeComponent();
}


/// &lt;summary&gt;
/// Invoke Hello service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button1_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(helloUri);
    request.Method = &quot;GET&quot;;
    btnHello.Content = &quot;Wait for your information..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(Process), &quot;&quot;);
}


/// &lt;summary&gt;
/// Give information to button's content property.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void Process(IAsyncResult result)
{
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    string s = string.Empty;
    using (StreamReader reader = new StreamReader(stream))
    {
        s = reader.ReadToEnd();
        s = Regex.Replace(s, @&quot;&lt;(.[^&gt;]*)&gt;&quot;, &quot;&quot;, RegexOptions.IgnoreCase);
    }
    Dispatcher.BeginInvoke(new Action(() =&gt; 
    {
        btnHello.Content = s;
        btnPerson.Content = &quot;Get Person&quot;;
        btnImage.Content = &quot;Get Image&quot;;
        lstData.Visibility = Visibility.Collapsed;
        imgSource.Visibility = Visibility.Collapsed;
    }));
}


/// &lt;summary&gt;
/// Invoke Person service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button2_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(personUri);
    request.Method = &quot;GET&quot;;
    btnPerson.Content = &quot;Wait for your information..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(PersonProcess), &quot;&quot;);
}


/// &lt;summary&gt;
/// Give Person model class entity information to ListBox control.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void PersonProcess(IAsyncResult result)
{
    Dispatcher.BeginInvoke(new Action(() =&gt;
        {
            lstData.Items.Clear();
        }));
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    string str = string.Empty;
    List&lt;Person&gt; list = new List&lt;Person&gt;();
    using (StreamReader reader = new StreamReader(stream))
    {
        str &#43;= reader.ReadToEnd();


        MatchCollection collection = Regex.Matches(str, @&quot;&lt;Person.*?&gt;(.*?)&lt;/Person&gt;&quot;);
        foreach (Match c in collection)
        {
            if (!c.Value.Equals(string.Empty))
            {
                Person person = new Person();
                person.Name = Regex.Replace(Regex.Match(c.Value, @&quot;&lt;Name.*?&gt;(.*?)&lt;/Name&gt;&quot;).Value, @&quot;&lt;[^&gt;]*&gt;&quot;, string.Empty, RegexOptions.IgnoreCase);
                person.Comments = Regex.Replace(Regex.Match(c.Value, @&quot;&lt;Comments&gt;((\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*)&lt;/Comments&gt;&quot;).Value, @&quot;&lt;[^&gt;]*&gt;&quot;, string.Empty, RegexOptions.IgnoreCase);
                list.Add(person);
            }
        }


        Dispatcher.BeginInvoke(new Action(() =&gt;
            {
                foreach (Person p in list)
                {
                    lstData.Items.Add(&quot;Person Name:&quot; &#43; p.Name);
                    lstData.Items.Add(&quot;Person Comments:&quot; &#43; p.Comments);
                    btnPerson.Content = &quot;OK&quot;;
                    lstData.Visibility = Visibility.Visible;
                    imgSource.Visibility = Visibility.Collapsed;
                    btnImage.Content = &quot;Get Image&quot;;
                    btnHello.Content = &quot;Get Hello&quot;;
                }
            }));
    }


}


/// &lt;summary&gt;
/// Invoke Image service method.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
private void button3_Click(object sender, RoutedEventArgs e)
{
    request = (HttpWebRequest)HttpWebRequest.Create(imageUri);
    request.Method = &quot;GET&quot;;
    btnImage.Content = &quot;Wait for your image..&quot;;
    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(ImageProcess), null);
}


/// &lt;summary&gt;
/// Give Image stream to Image control.
/// &lt;/summary&gt;
/// &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
private void ImageProcess(IAsyncResult result)
{
    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
    Stream stream = response.GetResponseStream();
    Dispatcher.BeginInvoke(new Action(() =&gt;
    {
        BitmapImage source = new BitmapImage();
        source.SetSource(stream);
        imgSource.Source = source;
        lstData.Visibility = Visibility.Collapsed;
        imgSource.Visibility = Visibility.Visible;
        btnImage.Content = &quot;OK&quot;;
        btnPerson.Content = &quot;Get Person&quot;;
        btnHello.Content = &quot;Get Hello&quot;;
    }));


}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="GramE">Step <span style="">6</span>.</span> Build the application and you can debug it.</p>
<p class="MsoNormal" style=""></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx"><span class="SpellE">ServiceHost</span> Class</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.servicebus.webhttprelaybinding.aspx"><span class="SpellE">WebHttpRelayBinding</span> Class</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.servicebus.transportclientendpointbehavior.aspx"><span class="SpellE">TransportClientEndpointBehavior</span> Class</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
