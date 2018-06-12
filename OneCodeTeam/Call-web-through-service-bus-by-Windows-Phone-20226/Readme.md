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
* 2013-07-05 02:40:51
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
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">VBAzureServiceBusWithWindowsPhone</span>.sln<span style=""> as Administrator</span>. Expand the
<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style=""><span style="">VBAzureServiceBusWithWindowsPhone</span></span></a><span style=""><span style=""><span style="">
</span></span></span><span style="">application, find the app.config file and input your Service Bus namespace, issuer name and key.</span> Then
<span style="">set ServiceBusServices Console application as the startup project, press &quot;Ctrl&#43;F5&quot; for running the service</span>.
<span style="">The following screenshot shows the service is running:</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91835/1/image.png" alt="" width="678" height="442" align="middle">
</span></p>
<p class="MsoNormal">Step 2: The next step, please modify the service url of the sample, in MainPage.xaml.vb page, replace the
<b style="">servicebusNamespace</b> variable as your namespace. For example, </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
static string servicebusNamespace = &quot;your namespace&quot;;

</pre>
<pre id="codePreview" class="vb">
static string servicebusNamespace = &quot;your namespace&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp;</span>Then set <span style="">VBAzureServiceBusWithWindowsPhone as the startup application and press &quot;F5&quot; or right click the project file and select debug =&gt; Start New Instance for running the Windows
 Phone application. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91836/1/image.png" alt="" width="402" height="731" align="middle">
</span></p>
<p class="MsoNormal">Step 3: <span style="">Click &quot;Get Hello&quot; button to test hello method, it shows &quot;Hello&quot; &amp; your send parameter in the content of Button:
</span></p>
<p class="MsoNormal"><span style="">&nbsp;</span><span style=""> <img src="/site/view/file/91837/1/image.png" alt="" width="402" height="731" align="middle">
</span></p>
<p class="MsoNormal">Step 4: <span style="">Click &quot;Get Person&quot; button to test Person method, it will get two entities from Person service and add them in a ListBox control:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91838/1/image.png" alt="" width="402" height="731" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 5: Click &quot;Get Image&quot; button to test Image method, it shows a Microsoft.jpg under the Get Image button:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91839/1/image.png" alt="" width="402" height="731" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step <span style="">6</span>: Validation finished.</p>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a VB &quot;Windows <span style="">Console Application</span>&quot; in Visual Studio 201<span style="">0</span>. Name it as &quot;<span style="">ServiceBusServices</span>&quot;.
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
<p class="MsoNormal"><span style="">Step 3, The Person.vb is the Model class, you can add some basic properties of person, such as name, age, etc. The IWindowsPhoneService includes three service methods: Hello, Person, Image.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ServiceContract()&gt; _
Public Interface IWindowsPhoneService
    ''' &lt;summary&gt;
    ''' Hello method contract.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Hello?name={name}&quot;)&gt; _
    Function Hello(name As String) As [String]


    ''' &lt;summary&gt;
    ''' Image method contract.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Image&quot;)&gt; _
    Function Image() As Stream


    ''' &lt;summary&gt;
    ''' Person method contract.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Person&quot;)&gt; _
    Function Persons() As List(Of Person)
End Interface

</pre>
<pre id="codePreview" class="vb">
&lt;ServiceContract()&gt; _
Public Interface IWindowsPhoneService
    ''' &lt;summary&gt;
    ''' Hello method contract.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Hello?name={name}&quot;)&gt; _
    Function Hello(name As String) As [String]


    ''' &lt;summary&gt;
    ''' Image method contract.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Image&quot;)&gt; _
    Function Image() As Stream


    ''' &lt;summary&gt;
    ''' Person method contract.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    &lt;WebGet(UriTemplate:=&quot;/Person&quot;)&gt; _
    Function Persons() As List(Of Person)
End Interface

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step 4. <span style="">Then you need create a class &quot;WindowsPhoneService&quot; to implement the interface. And add necessary configuration in app.comfig file. At last, create ServiceHost and expost the service with ServiceBus
 issuer and key. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Module Module1


    Sub Main()
        Dim serviceNamespace As String = ConfigurationManager.AppSettings(&quot;serviceNamespace&quot;)
        Dim address As Uri = ServiceBusEnvironment.CreateServiceUri(&quot;http&quot;, serviceNamespace, &quot;&quot;)


        ' Create WebHttpRelayBinding instance.
        Dim binding As New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None)


        ' Create ServiceHost with endpoint.
        Dim host = New ServiceHost(GetType(WindowsPhoneService), address)
        host.AddServiceEndpoint(GetType(IWindowsPhoneService), binding, address)
        Dim behavior = host.Description.Endpoints(0).Behaviors


        ' Add ServiceBus key.
        behavior.Add(New TransportClientEndpointBehavior(TokenProvider.CreateSharedSecretTokenProvider(ConfigurationManager.AppSettings(&quot;issuer&quot;), ConfigurationManager.AppSettings(&quot;key&quot;))))
        behavior.Add(New WebHttpBehavior())
        host.Open()


        Console.WriteLine(String.Format(&quot;Service listening at: {0}&quot;, host.Description.Endpoints(0).Address))
        Console.WriteLine(&quot;Press any key to exit...&quot;)
        Console.ReadKey()


        host.Close()
    End Sub


End Module

</pre>
<pre id="codePreview" class="vb">
Module Module1


    Sub Main()
        Dim serviceNamespace As String = ConfigurationManager.AppSettings(&quot;serviceNamespace&quot;)
        Dim address As Uri = ServiceBusEnvironment.CreateServiceUri(&quot;http&quot;, serviceNamespace, &quot;&quot;)


        ' Create WebHttpRelayBinding instance.
        Dim binding As New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None)


        ' Create ServiceHost with endpoint.
        Dim host = New ServiceHost(GetType(WindowsPhoneService), address)
        host.AddServiceEndpoint(GetType(IWindowsPhoneService), binding, address)
        Dim behavior = host.Description.Endpoints(0).Behaviors


        ' Add ServiceBus key.
        behavior.Add(New TransportClientEndpointBehavior(TokenProvider.CreateSharedSecretTokenProvider(ConfigurationManager.AppSettings(&quot;issuer&quot;), ConfigurationManager.AppSettings(&quot;key&quot;))))
        behavior.Add(New WebHttpBehavior())
        host.Open()


        Console.WriteLine(String.Format(&quot;Service listening at: {0}&quot;, host.Description.Endpoints(0).Address))
        Console.WriteLine(&quot;Press any key to exit...&quot;)
        Console.ReadKey()


        host.Close()
    End Sub


End Module

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step <span style="">5. Add a &quot;Windows Phone Application&quot; in the solution, add 3 buttons, a ListBox and a, Image control in the
<span class="SpellE">MainPage.xaml</span> with following VB code: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim request As HttpWebRequest
Shared servicebusNamespace As String = &quot;[Your Namespace]&quot;
Private helloUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Hello?name=New User&quot;, servicebusNamespace)
Private personUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Person&quot;, servicebusNamespace)
Private imageUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Image&quot;, servicebusNamespace)
' Constructor
Public Sub New()
    InitializeComponent()
End Sub


''' &lt;summary&gt;
''' Invoke Hello service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(helloUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnHello.Content = &quot;Wait for your information..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf Process), &quot;&quot;)
End Sub


''' &lt;summary&gt;
''' Give information to button's content property.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub Process(result As IAsyncResult)
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dim s As String = String.Empty
    Using reader As New StreamReader(stream)
        s = reader.ReadToEnd()
        s = Regex.Replace(s, &quot;&lt;(.[^&gt;]*)&gt;&quot;, &quot;&quot;, RegexOptions.IgnoreCase)
    End Using
    Dispatcher.BeginInvoke(New Action(Sub()
                                          btnHello.Content = s
                                          btnPerson.Content = &quot;Get Person&quot;
                                          btnImage.Content = &quot;Get Image&quot;
                                          lstData.Visibility = Visibility.Collapsed
                                          imgSource.Visibility = Visibility.Collapsed


                                      End Sub))
End Sub


''' &lt;summary&gt;
''' Invoke Person service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(personUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnPerson.Content = &quot;Wait for your information..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf PersonProcess), &quot;&quot;)
End Sub


''' &lt;summary&gt;
''' Give Person model class entity information to ListBox control.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub PersonProcess(result As IAsyncResult)
    Dispatcher.BeginInvoke(New Action(Sub()
                                          lstData.Items.Clear()


                                      End Sub))
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dim str As String = String.Empty
    Dim list As New List(Of Person)()
    Using reader As New StreamReader(stream)
        str &#43;= reader.ReadToEnd()


        Dim collection As MatchCollection = Regex.Matches(str, &quot;&lt;Person.*?&gt;(.*?)&lt;/Person&gt;&quot;)
        For Each c As Match In collection
            If Not c.Value.Equals(String.Empty) Then
                Dim person As New Person()
                person.Name = Regex.Replace(Regex.Match(c.Value, &quot;&lt;Name.*?&gt;(.*?)&lt;/Name&gt;&quot;).Value, &quot;&lt;[^&gt;]*&gt;&quot;, String.Empty, RegexOptions.IgnoreCase)
                person.Comments = Regex.Replace(Regex.Match(c.Value, &quot;&lt;Comments&gt;((\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*)&lt;/Comments&gt;&quot;).Value, &quot;&lt;[^&gt;]*&gt;&quot;, String.Empty, RegexOptions.IgnoreCase)
                list.Add(person)
            End If
        Next


        Dispatcher.BeginInvoke(New Action(Sub()
                                              For Each p As Person In list
                                                  lstData.Items.Add(&quot;Person Name:&quot; &#43; p.Name)
                                                  lstData.Items.Add(&quot;Person Comments:&quot; &#43; p.Comments)
                                                  btnPerson.Content = &quot;OK&quot;
                                                  lstData.Visibility = Visibility.Visible
                                                  imgSource.Visibility = Visibility.Collapsed
                                                  btnImage.Content = &quot;Get Image&quot;
                                                  btnHello.Content = &quot;Get Hello&quot;
                                              Next


                                          End Sub))
    End Using


End Sub


''' &lt;summary&gt;
''' Invoke Image service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(imageUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnImage.Content = &quot;Wait for your image..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf ImageProcess), Nothing)
End Sub


''' &lt;summary&gt;
''' Give Image stream to Image control.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub ImageProcess(result As IAsyncResult)
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dispatcher.BeginInvoke(New Action(Sub()
                                          Dim source As New BitmapImage()
                                          source.SetSource(stream)
                                          imgSource.Source = source
                                          lstData.Visibility = Visibility.Collapsed
                                          imgSource.Visibility = Visibility.Visible
                                          btnImage.Content = &quot;OK&quot;
                                          btnPerson.Content = &quot;Get Person&quot;
                                          btnHello.Content = &quot;Get Hello&quot;


                                      End Sub))


End Sub

</pre>
<pre id="codePreview" class="vb">
Dim request As HttpWebRequest
Shared servicebusNamespace As String = &quot;[Your Namespace]&quot;
Private helloUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Hello?name=New User&quot;, servicebusNamespace)
Private personUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Person&quot;, servicebusNamespace)
Private imageUri As String = [String].Format(&quot;http://{0}.servicebus.windows.net/Image&quot;, servicebusNamespace)
' Constructor
Public Sub New()
    InitializeComponent()
End Sub


''' &lt;summary&gt;
''' Invoke Hello service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(helloUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnHello.Content = &quot;Wait for your information..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf Process), &quot;&quot;)
End Sub


''' &lt;summary&gt;
''' Give information to button's content property.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub Process(result As IAsyncResult)
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dim s As String = String.Empty
    Using reader As New StreamReader(stream)
        s = reader.ReadToEnd()
        s = Regex.Replace(s, &quot;&lt;(.[^&gt;]*)&gt;&quot;, &quot;&quot;, RegexOptions.IgnoreCase)
    End Using
    Dispatcher.BeginInvoke(New Action(Sub()
                                          btnHello.Content = s
                                          btnPerson.Content = &quot;Get Person&quot;
                                          btnImage.Content = &quot;Get Image&quot;
                                          lstData.Visibility = Visibility.Collapsed
                                          imgSource.Visibility = Visibility.Collapsed


                                      End Sub))
End Sub


''' &lt;summary&gt;
''' Invoke Person service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(personUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnPerson.Content = &quot;Wait for your information..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf PersonProcess), &quot;&quot;)
End Sub


''' &lt;summary&gt;
''' Give Person model class entity information to ListBox control.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub PersonProcess(result As IAsyncResult)
    Dispatcher.BeginInvoke(New Action(Sub()
                                          lstData.Items.Clear()


                                      End Sub))
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dim str As String = String.Empty
    Dim list As New List(Of Person)()
    Using reader As New StreamReader(stream)
        str &#43;= reader.ReadToEnd()


        Dim collection As MatchCollection = Regex.Matches(str, &quot;&lt;Person.*?&gt;(.*?)&lt;/Person&gt;&quot;)
        For Each c As Match In collection
            If Not c.Value.Equals(String.Empty) Then
                Dim person As New Person()
                person.Name = Regex.Replace(Regex.Match(c.Value, &quot;&lt;Name.*?&gt;(.*?)&lt;/Name&gt;&quot;).Value, &quot;&lt;[^&gt;]*&gt;&quot;, String.Empty, RegexOptions.IgnoreCase)
                person.Comments = Regex.Replace(Regex.Match(c.Value, &quot;&lt;Comments&gt;((\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*)&lt;/Comments&gt;&quot;).Value, &quot;&lt;[^&gt;]*&gt;&quot;, String.Empty, RegexOptions.IgnoreCase)
                list.Add(person)
            End If
        Next


        Dispatcher.BeginInvoke(New Action(Sub()
                                              For Each p As Person In list
                                                  lstData.Items.Add(&quot;Person Name:&quot; &#43; p.Name)
                                                  lstData.Items.Add(&quot;Person Comments:&quot; &#43; p.Comments)
                                                  btnPerson.Content = &quot;OK&quot;
                                                  lstData.Visibility = Visibility.Visible
                                                  imgSource.Visibility = Visibility.Collapsed
                                                  btnImage.Content = &quot;Get Image&quot;
                                                  btnHello.Content = &quot;Get Hello&quot;
                                              Next


                                          End Sub))
    End Using


End Sub


''' &lt;summary&gt;
''' Invoke Image service method.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Sub button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
    request = DirectCast(HttpWebRequest.Create(imageUri), HttpWebRequest)
    request.Method = &quot;GET&quot;
    btnImage.Content = &quot;Wait for your image..&quot;
    Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf ImageProcess), Nothing)
End Sub


''' &lt;summary&gt;
''' Give Image stream to Image control.
''' &lt;/summary&gt;
''' &lt;param name=&quot;result&quot;&gt;&lt;/param&gt;
Private Sub ImageProcess(result As IAsyncResult)
    Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
    Dim stream As Stream = response.GetResponseStream()
    Dispatcher.BeginInvoke(New Action(Sub()
                                          Dim source As New BitmapImage()
                                          source.SetSource(stream)
                                          imgSource.Source = source
                                          lstData.Visibility = Visibility.Collapsed
                                          imgSource.Visibility = Visibility.Visible
                                          btnImage.Content = &quot;OK&quot;
                                          btnPerson.Content = &quot;Get Person&quot;
                                          btnHello.Content = &quot;Get Hello&quot;


                                      End Sub))


End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="GramE">Step <span style="">6</span>.</span> Build the application and you can debug it.</p>
<p class="MsoNormal" style=""></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.servicehost.aspx">ServiceHost Class</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.servicebus.webhttprelaybinding.aspx">WebHttpRelayBinding Class</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.servicebus.transportclientendpointbehavior.aspx">TransportClientEndpointBehavior Class</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
