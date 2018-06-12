# How to add a loading screen to your Windows Phone Application
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone Development
## Topics
* Splash Screen
## IsPublished
* True
## ModifiedDate
* 2014-01-06 10:03:40
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to add a loading screen to your Windows Phone Application using data binding and behaviors in Blend.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">This code sample will show you how to easily add a loading screen to your Windows Phone Application using data binding and behaviors in Blend.
</span><span style="font-size:11pt"><br clear="all">
</span><span style="">The scenario we </span><span style="">are </span><span style="">focusing on for this code sample is an application that loads data that may take some time to obtain and you want the user interface to display some indication while the data
 is being loaded. Once the application data is ready, it transitions from the loading screen to the screen displaying the data.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Right click </span><span style="font-size:11pt">the
</span><span style="font-size:11pt">solution name, then click &quot;Enable NuGet Package Restore&quot;, and then
</span><span style="font-size:11pt">build the sample normally.</span><span style="font-size:11pt"> You may notice that it will try to download Microsoft Http Client Libraries from NuGet</span><span style="font-size:11pt"> if you haven't installed it before</span><span style="font-size:11pt">.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">NOTE: If you see an error message like</span><span style="font-style:italic"> &ldquo;The build restored NuGet packages. Build the project again to include these packages in the build.&rdquo;
</span><span style="">when building the sample</span><span style="font-size:11pt">, please close the solution, then re-open and rebuild it.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">To install Microsoft HTTP Client Libraries manually, please refer to
</span><span style="">the </span><span style="">following link:</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="https://www.nuget.org/packages/Microsoft.Net.Http/2.2.18" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">https://www.nuget.org/packages/Microsoft.Net.Http/2.2.18</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press Ctrl &#43; F5 to run the sample, you will first see screenshot (a)</span><span style="font-size:11pt">:</span><span style="font-size:11pt"> it indicates the data is being loaded; once the data is ready,
 you will see screenshot (b).</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106662/1/image.png" alt="" width="266" height="479" align="middle">
</span><span style="font-size:11pt"></span><span style="font-size:11pt"><img src="/site/view/file/106663/1/image.png" alt="" width="263" height="479" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">(a) (b)</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The sample application is fairly simple and we're using the Model-View-ViewModel pattern.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">We simulate loading data by specifying a URL to the OneCode site. This site loads relatively fast, so you may want provide a URL that takes a few seconds to respond.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">To modify the URL, you can open the MainViewModel.cs(MainViewModel.vb), and replace the URL with yours.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
HttpResponseMessage response = await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;);
</pre>
<pre class="hidden">
Dim response As HttpResponseMessage = Await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;)
</pre>
<pre id="codePreview" class="csharp">
HttpResponseMessage response = await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">This will be sufficient for the purpose of this sample</span><span style=""> which is focusing on the user interface, and not the application logic.</span><span style="">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Step 1. Create MainViewModel.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The ViewModel contains the DataLoaded property, which is a Boolean.
</span><span style="">A value of True indicates the data is loaded. A value of False indicates it is not.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The Status property is a simple string where we'll populate the Http Status response we get from our sample web service call, which is done in the LoadViewModelData routine.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
public class MainViewModel : INotifyPropertyChanged
{
    HttpClient _httpClient;
    public MainViewModel()
    {
        _dataLoaded = false;
        _status = &quot;&quot;;
        _httpClient = new HttpClient();
        LoadViewModelData();
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
    private bool _dataLoaded;
    public bool DataLoaded
    {
        get { return _dataLoaded; }
        set { _dataLoaded = value; NotifyPropertyChanged(&quot;DataLoaded&quot;); }
    }
    private string _status;
    public string Status
    {
        get { return _status; }
        set { _status = value; NotifyPropertyChanged(&quot;Status&quot;); }
    }
    
    public async void LoadViewModelData()
    {
        DataLoaded = false;
        HttpResponseMessage response = await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;);
        Status = String.Format(&quot;Status: {0}&quot;, response.StatusCode);
        DataLoaded = true;
    }
    
}
</pre>
<pre class="hidden">
Public Class MainViewModel
    Implements INotifyPropertyChanged
    Private _httpClient As HttpClient
    Public Sub New()
        _dataLoaded = False
        _status = &quot;&quot;
        _httpClient = New HttpClient()
        LoadViewModelData()
    End Sub
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub
    Private _dataLoaded As Boolean
    Public Property DataLoaded() As Boolean
        Get
            Return _dataLoaded
        End Get
        Set(value As Boolean)
            _dataLoaded = value
            NotifyPropertyChanged(&quot;DataLoaded&quot;)
        End Set
    End Property
    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
            NotifyPropertyChanged(&quot;Status&quot;)
        End Set
    End Property
    Public Async Sub LoadViewModelData()
        DataLoaded = False
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;)
        Status = [String].Format(&quot;Status: {0}&quot;, response.StatusCode)
        DataLoaded = True
    End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">
public class MainViewModel : INotifyPropertyChanged
{
    HttpClient _httpClient;
    public MainViewModel()
    {
        _dataLoaded = false;
        _status = &quot;&quot;;
        _httpClient = new HttpClient();
        LoadViewModelData();
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
    private bool _dataLoaded;
    public bool DataLoaded
    {
        get { return _dataLoaded; }
        set { _dataLoaded = value; NotifyPropertyChanged(&quot;DataLoaded&quot;); }
    }
    private string _status;
    public string Status
    {
        get { return _status; }
        set { _status = value; NotifyPropertyChanged(&quot;Status&quot;); }
    }
    
    public async void LoadViewModelData()
    {
        DataLoaded = false;
        HttpResponseMessage response = await _httpClient.GetAsync(&quot;http://blogs.msdn.com/b/onecode/&quot;);
        Status = String.Format(&quot;Status: {0}&quot;, response.StatusCode);
        DataLoaded = true;
    }
    
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Step 2. Create ViewModelLocator.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">ViewModelLocator exposes our main ViewModel through the main property on the ViewModelLocator.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
public class ViewModelLocator
{
    /// &lt;summary&gt;
    /// Initializes a new instance of the ViewModelLocator class.
    /// &lt;/summary&gt;
    static ViewModelLocator()
    {
        _main = new MainViewModel();
    }
    public static MainViewModel _main;
    public MainViewModel Main
    {
        get
        {
            return _main;
        }
    }
    public static void Cleanup()
    {
        // TODO Clear the ViewModels
    }
}
</pre>
<pre class="hidden">
Public Class ViewModelLocator
    ''' &lt;summary&gt;
    ''' Initializes a new instance of the ViewModelLocator class.
    ''' &lt;/summary&gt;
    Shared Sub New()
        _main = New MainViewModel()
    End Sub
    Public Shared _main As MainViewModel
    Public ReadOnly Property Main() As MainViewModel
        Get
            Return _main
        End Get
    End Property
    Public Shared Sub Cleanup()
        ' TODO Clear the ViewModels
    End Sub
End Class
</pre>
<pre id="codePreview" class="csharp">
public class ViewModelLocator
{
    /// &lt;summary&gt;
    /// Initializes a new instance of the ViewModelLocator class.
    /// &lt;/summary&gt;
    static ViewModelLocator()
    {
        _main = new MainViewModel();
    }
    public static MainViewModel _main;
    public MainViewModel Main
    {
        get
        {
            return _main;
        }
    }
    public static void Cleanup()
    {
        // TODO Clear the ViewModels
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">This is created as a static resource in our App.xaml file so any page in our application can access the ViewModelLocator and obtain a ViewModel from it.</span><span style="font-size:11pt">
<br clear="all">
</span><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Application.Resources&gt;
    &lt;local:LocalizedStrings xmlns:local=&quot;clr-namespace:SplashScreen&quot; x:Key=&quot;LocalizedStrings&quot;/&gt;
    &lt;vm:ViewModelLocator x:Key=&quot;Locator&quot;/&gt;
&lt;/Application.Resources&gt;
</pre>
<pre id="codePreview" class="xaml">
&lt;Application.Resources&gt;
    &lt;local:LocalizedStrings xmlns:local=&quot;clr-namespace:SplashScreen&quot; x:Key=&quot;LocalizedStrings&quot;/&gt;
    &lt;vm:ViewModelLocator x:Key=&quot;Locator&quot;/&gt;
&lt;/Application.Resources&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Step 3. Customize MainPage.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">In this case our MainPage.xaml sets its data
</span><span style="">context equal to the main property of our ViewModelLocator. And our MainPage.xaml only has a simple TextBlock that will display the status from our ViewModel.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;phone:PhoneApplicationPage
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:i=&quot;clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity&quot; xmlns:ec=&quot;clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions&quot;
    x:Class=&quot;SplashScreen.MainPage&quot;
    mc:Ignorable=&quot;d&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    DataContext=&quot;{Binding Source={StaticResource Locator}, Path=Main}&quot;&gt;
</pre>
<pre id="codePreview" class="xaml">
&lt;phone:PhoneApplicationPage
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:i=&quot;clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity&quot; xmlns:ec=&quot;clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions&quot;
    x:Class=&quot;SplashScreen.MainPage&quot;
    mc:Ignorable=&quot;d&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    DataContext=&quot;{Binding Source={StaticResource Locator}, Path=Main}&quot;&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We also need to create a splash screen. We can
</span><span style="">create that in Blend and wire it up to trigger off the binding to our DataLoaded property on our ViewModel.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Open the MainPage.xaml in Blend. You can do this by right clicking MainPage.xaml in Visual Studio and choosing open in Blend. Creating the loading screen will be done in three parts.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">a. W</span><span style="">e will create the visual we want to see when data is loading.</span><span style="">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The first thing we need to do is create what we want to see when the data is loading.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">To do this we'll use a StackPanel that contains a ProgressBar and LoadingText.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">We'll add the StackPanel at the same level as the ContentPanel.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">And then we will add the ProgressBar and the TextBlock</span><span style=""> to the StackPanel</span><span style="">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">We want the StackPanel to take up the entire screen, so we need to change a couple properties on it.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">First, we need to make sure it spans both rows.
</span><span style="">So</span><span style=""> we'll set the auto Width and auto Height proerty and
</span><span style="">then</span><span style=""> stretch it.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">And lastly for this StackPanel we want to give it a background color so it stands out and covers up the main screen.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">We're going to just choose a dark green here with a gradient brush and give it a little bit of a gradient here.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Next we want to position our loading text and the ProgressBar towards the middle of the screen.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">So for the ProgressBar we'll set its top margin halfway down the screen.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">And we'll also set the </span><span style="font-weight:bold">IsIndeterminate
</span><span style="">property to true.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">This means that the loading dots that come across the screen will always be there.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Lastly we want to change some properties on the TextBlock.
</span><span style="">We'll </span><span style="">Start</span><span style=""> </span>
<span style="">with centering it.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Then w</span><span style="">e're going to</span><span style=""> set</span><span style=""> the font to</span><span style=""> the same one
</span><span style="">we're using for our </span><span style="">StatusText on the main screen.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">And for that one we used Britannic Bold. And then we're going to set the font size to 72 and change the text to Loading.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">And let's give the text a different color as well. Keep it in the green theme here. And change the brush to the linear</span><span style=""> gradient brush.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">So this is basically what it will look like when data is loading.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106664/1/image.png" alt="" width="275" height="479" align="middle">
</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">b) Then w</span><span style="">e will create a VisualState group to define a Loading and data Loaded VisualState.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">We do this from the States tab in Blend. First thing you need to do is create a VisualStateGroup which I will call DataStates. And we'll have two different states, one for the Loading state and one for the Loaded
 state.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">When you cho</span><span style="">o</span><span style="">se
</span><span style="">either</span><span style=""> of these states, basically it will record the properties and values you want for this specific VisualState. For the loading state we don't want th</span><span style="">e content panel to be displayed;</span><span style="">
 so we'll set it to collapsed. But for </span><span style="">the</span><span style=""> StackPanel we created, this is the screen we want to see when we're loading data, so we want to make sure the opacity is 100% and its visibility is set to visible.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Now once the data is loaded, we want the splash screen to go away. So we'll set its opacity to zero and the visibility to collapsed so we can see the main screen. And that basically sets up what it looks like between
 the two states.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">If we have transition preview on, we can see what it looks like to transition from the Loading to the Loaded state. And by default it's just going to be an abrupt change.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">To fix that we'll add a transition, and we'll cho</span><span style="">o</span><span style="">se just a very simple curved EasingFunction and let the transition take two seconds. Now that we have our states and transitions
 taken care of, let's turn off recording. </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106665/1/image.png" alt="" width="301" height="217" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">c) </span><span style="">And finally we will add a DataState behavior and bind it to our DataLoaded property.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Then w</span><span style="">e need to hook up our ViewModel's DataLoaded property so that it controls the VisualStates in our UI.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">To do this we add a DataStateBehavior to our page. The behaviors can be found on the Assets tab under behaviors. And in this case we'll add the DataStateBehavior to our page. We'll bind the DataStateBehavior to the
 DataLoadedProperty on our ViewModel. </span><span style="">The value of the DataLoaded property will trigger our state changes on</span><span style=""> when</span><span style=""> in False.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106666/1/image.png" alt="" width="279" height="263" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">So when our DataLoaded property value is False,
</span><span style="">it means</span><span style=""> </span><span style="">that we want to set the
</span><span style="">True state to Loading. And when the DataLoaded property is True,
</span><span style="">it means that we want to set the</span><span style=""> False state to Loaded.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">You can use these DataStates for more complex scenarios as well.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">For example a game screen </span><span style="">on which we</span><span style=""> want to show scores between levels while the next level is loading, or something similar like that.</span><span style="font-size:11pt">
<br clear="all">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following is the complete XAML code of the MainPage:</span><span style="">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;phone:PhoneApplicationPage
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:i=&quot;clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity&quot; xmlns:ec=&quot;clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions&quot;
    x:Class=&quot;SplashScreen.MainPage&quot;
    mc:Ignorable=&quot;d&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    DataContext=&quot;{Binding Source={StaticResource Locator}, Path=Main}&quot;&gt;
 
  &lt;ec:DataStateBehavior Binding=&quot;{Binding DataLoaded}&quot; Value=&quot;False&quot; TrueState=&quot;Loading&quot; FalseState=&quot;Loaded&quot;/&gt;
 
    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
  &lt;VisualStateManager.VisualStateGroups&gt;
   &lt;VisualStateGroup x:Name=&quot;DataStates&quot;&gt;
    &lt;VisualStateGroup.Transitions&gt;
     &lt;VisualTransition GeneratedDuration=&quot;0:0:2&quot; To=&quot;Loaded&quot;&gt;
      &lt;VisualTransition.GeneratedEasingFunction&gt;
       &lt;CubicEase EasingMode=&quot;EaseOut&quot;/&gt;
      &lt;/VisualTransition.GeneratedEasingFunction&gt;
     &lt;/VisualTransition&gt;
    &lt;/VisualStateGroup.Transitions&gt;
    &lt;VisualState x:Name=&quot;Loading&quot;&gt;
     &lt;Storyboard&gt;
      &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(UIElement.Visibility)&quot; Storyboard.TargetName=&quot;ContentPanel&quot;&gt;
       &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
        &lt;DiscreteObjectKeyFrame.Value&gt;
         &lt;Visibility&gt;Collapsed&lt;/Visibility&gt;
        &lt;/DiscreteObjectKeyFrame.Value&gt;
       &lt;/DiscreteObjectKeyFrame&gt;
      &lt;/ObjectAnimationUsingKeyFrames&gt;
     &lt;/Storyboard&gt;
    &lt;/VisualState&gt;
    &lt;VisualState x:Name=&quot;Loaded&quot;&gt;
     &lt;Storyboard&gt;
      &lt;DoubleAnimation Duration=&quot;0&quot; To=&quot;0&quot; Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot; Storyboard.TargetName=&quot;stackPanel&quot; d:IsOptimized=&quot;True&quot;/&gt;
     &lt;/Storyboard&gt;
    &lt;/VisualState&gt;
   &lt;/VisualStateGroup&gt;
  &lt;/VisualStateManager.VisualStateGroups&gt;
  &lt;Grid.RowDefinitions&gt;
   &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
   &lt;RowDefinition Height=&quot;*&quot;/&gt;
  &lt;/Grid.RowDefinitions&gt;
&lt;!--TitlePanel contains the name of the application and page title--&gt;
  &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
   &lt;TextBlock Text=&quot;MY APPLICATION&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot; Margin=&quot;12,0&quot;/&gt;
   &lt;TextBlock Text=&quot;page name&quot; Margin=&quot;9,-7,0,0&quot; Style=&quot;{StaticResource PhoneTextTitle1Style}&quot;/&gt;
  &lt;/StackPanel&gt;
        &lt;!--ContentPanel - place additional content here--&gt;
  &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
   &lt;TextBlock HorizontalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Status}&quot; VerticalAlignment=&quot;Center&quot; FontFamily=&quot;Britannic Bold&quot; FontSize=&quot;48&quot;/&gt;
  &lt;/Grid&gt;
  &lt;StackPanel x:Name=&quot;stackPanel&quot; Grid.RowSpan=&quot;2&quot;&gt;
   &lt;StackPanel.Background&gt;
    &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
     &lt;GradientStop Color=&quot;Black&quot; Offset=&quot;0&quot;/&gt;
     &lt;GradientStop Color=&quot;#FF448939&quot; Offset=&quot;0.552&quot;/&gt;
    &lt;/LinearGradientBrush&gt;
   &lt;/StackPanel.Background&gt;
   &lt;ProgressBar Height=&quot;10&quot; Margin=&quot;0,320,0,0&quot; IsIndeterminate=&quot;True&quot;/&gt;
   &lt;TextBlock TextWrapping=&quot;Wrap&quot; Text=&quot;Loading&quot; TextAlignment=&quot;Center&quot; FontFamily=&quot;Britannic Bold&quot; FontSize=&quot;96&quot;&gt;
    &lt;TextBlock.Foreground&gt;
     &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
      &lt;GradientStop Color=&quot;Black&quot; Offset=&quot;0.375&quot;/&gt;
      &lt;GradientStop Color=&quot;#FF427434&quot; Offset=&quot;1&quot;/&gt;
      &lt;GradientStop Color=&quot;#FF417333&quot; Offset=&quot;1&quot;/&gt;
     &lt;/LinearGradientBrush&gt;
    &lt;/TextBlock.Foreground&gt;
   &lt;/TextBlock&gt;
  &lt;/StackPanel&gt;
 &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;
</pre>
<pre id="codePreview" class="xaml">
&lt;phone:PhoneApplicationPage
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:i=&quot;clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity&quot; xmlns:ec=&quot;clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions&quot;
    x:Class=&quot;SplashScreen.MainPage&quot;
    mc:Ignorable=&quot;d&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    DataContext=&quot;{Binding Source={StaticResource Locator}, Path=Main}&quot;&gt;
 
  &lt;ec:DataStateBehavior Binding=&quot;{Binding DataLoaded}&quot; Value=&quot;False&quot; TrueState=&quot;Loading&quot; FalseState=&quot;Loaded&quot;/&gt;
 
    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
 &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
  &lt;VisualStateManager.VisualStateGroups&gt;
   &lt;VisualStateGroup x:Name=&quot;DataStates&quot;&gt;
    &lt;VisualStateGroup.Transitions&gt;
     &lt;VisualTransition GeneratedDuration=&quot;0:0:2&quot; To=&quot;Loaded&quot;&gt;
      &lt;VisualTransition.GeneratedEasingFunction&gt;
       &lt;CubicEase EasingMode=&quot;EaseOut&quot;/&gt;
      &lt;/VisualTransition.GeneratedEasingFunction&gt;
     &lt;/VisualTransition&gt;
    &lt;/VisualStateGroup.Transitions&gt;
    &lt;VisualState x:Name=&quot;Loading&quot;&gt;
     &lt;Storyboard&gt;
      &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(UIElement.Visibility)&quot; Storyboard.TargetName=&quot;ContentPanel&quot;&gt;
       &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
        &lt;DiscreteObjectKeyFrame.Value&gt;
         &lt;Visibility&gt;Collapsed&lt;/Visibility&gt;
        &lt;/DiscreteObjectKeyFrame.Value&gt;
       &lt;/DiscreteObjectKeyFrame&gt;
      &lt;/ObjectAnimationUsingKeyFrames&gt;
     &lt;/Storyboard&gt;
    &lt;/VisualState&gt;
    &lt;VisualState x:Name=&quot;Loaded&quot;&gt;
     &lt;Storyboard&gt;
      &lt;DoubleAnimation Duration=&quot;0&quot; To=&quot;0&quot; Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot; Storyboard.TargetName=&quot;stackPanel&quot; d:IsOptimized=&quot;True&quot;/&gt;
     &lt;/Storyboard&gt;
    &lt;/VisualState&gt;
   &lt;/VisualStateGroup&gt;
  &lt;/VisualStateManager.VisualStateGroups&gt;
  &lt;Grid.RowDefinitions&gt;
   &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
   &lt;RowDefinition Height=&quot;*&quot;/&gt;
  &lt;/Grid.RowDefinitions&gt;
&lt;!--TitlePanel contains the name of the application and page title--&gt;
  &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
   &lt;TextBlock Text=&quot;MY APPLICATION&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot; Margin=&quot;12,0&quot;/&gt;
   &lt;TextBlock Text=&quot;page name&quot; Margin=&quot;9,-7,0,0&quot; Style=&quot;{StaticResource PhoneTextTitle1Style}&quot;/&gt;
  &lt;/StackPanel&gt;
        &lt;!--ContentPanel - place additional content here--&gt;
  &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
   &lt;TextBlock HorizontalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot; Text=&quot;{Binding Status}&quot; VerticalAlignment=&quot;Center&quot; FontFamily=&quot;Britannic Bold&quot; FontSize=&quot;48&quot;/&gt;
  &lt;/Grid&gt;
  &lt;StackPanel x:Name=&quot;stackPanel&quot; Grid.RowSpan=&quot;2&quot;&gt;
   &lt;StackPanel.Background&gt;
    &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
     &lt;GradientStop Color=&quot;Black&quot; Offset=&quot;0&quot;/&gt;
     &lt;GradientStop Color=&quot;#FF448939&quot; Offset=&quot;0.552&quot;/&gt;
    &lt;/LinearGradientBrush&gt;
   &lt;/StackPanel.Background&gt;
   &lt;ProgressBar Height=&quot;10&quot; Margin=&quot;0,320,0,0&quot; IsIndeterminate=&quot;True&quot;/&gt;
   &lt;TextBlock TextWrapping=&quot;Wrap&quot; Text=&quot;Loading&quot; TextAlignment=&quot;Center&quot; FontFamily=&quot;Britannic Bold&quot; FontSize=&quot;96&quot;&gt;
    &lt;TextBlock.Foreground&gt;
     &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
      &lt;GradientStop Color=&quot;Black&quot; Offset=&quot;0.375&quot;/&gt;
      &lt;GradientStop Color=&quot;#FF427434&quot; Offset=&quot;1&quot;/&gt;
      &lt;GradientStop Color=&quot;#FF417333&quot; Offset=&quot;1&quot;/&gt;
     &lt;/LinearGradientBrush&gt;
    &lt;/TextBlock.Foreground&gt;
   &lt;/TextBlock&gt;
  &lt;/StackPanel&gt;
 &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Video blog: Implementing a Loading Splash Screen for your Windows Phone App</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/Implementing-a-Loading-Splash-Screen-for-your-Windows-Phone-App" style="text-decoration:none"><span style="color:#0563C1; color:#0563C1; text-decoration:underline">http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/Implementing-a-Loading-Splash-Screen-for-your-Windows-Phone-App</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Implementing the Model-View-ViewModel pattern in a Windows Phone App</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/gg521153(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/gg521153(v=vs.105).aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Designing your XAML UI with Blend Jumpstart</span><span style="font-size:11pt">
<br clear="all">
</span><a href="http://www.microsoftvirtualacademy.com/training-courses/designing-your-xaml-ui-with-blend-jump-start#?fbid=Y4cvgt4Hy8E" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://www.microsoftvirtualacademy.com/training-courses/designing-your-xaml-ui-with-blend-jump-start#?fbid=Y4cvgt4Hy8E</span></a><span style="font-size:11pt">
<br clear="all">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
