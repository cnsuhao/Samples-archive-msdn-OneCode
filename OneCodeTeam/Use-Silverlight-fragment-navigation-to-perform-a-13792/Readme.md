# Use Silverlight fragment navigation to perform a search (VBSL4FragmentSearch)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Fragment Navigation
* Bing
## IsPublished
* True
## ModifiedDate
* 2011-10-27 10:35:19
## Description

<h2>Sivlerlight APPLICATION: VBSL4FragmentSearch Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The VBSL4FragmentSearch is a simple sample demonstrating the use of fragment navigation within Silverlight to perform a search.&nbsp; The advantage this provides is that the search can then be saved by URL, and linked directly, with consistent behavior, allowing
 users to send links to direct results within Silverlight.</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To run the sample, press ctrl &#43; F5 start the project. The application will show a popup box, click &quot;yes&quot; to continue, a web page will load, with the Silverlight fragment navigation's search component.&nbsp; Input your text in TextBox and click search button,
 and a Bing search filtered on Microsoft.com will be performed with the search terms.&nbsp; Note that the URL string will now include the search terms as a fragment, which can subsequently be bookmarked or copied and pasted into a new browser tab, after which
 time the same search will again be performed (as long as the URL remains valid - in the debug mode, as long as the project continues to run on the same port).</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The sample uses one simple Silverlight component, and all the relevant code is in MainPage.xaml, and its code behind, MainPage.xaml.cs.&nbsp; The code simply implements a fragment navigation event, which performs a web search with the Bing web service API,
 applying the fragment text as the search terms.</p>
<p style="font-family:Courier New">Following steps below to create this sample:</p>
<p>Step 1. Create a VB &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Visual Web Developer 2010. Name it as &quot;VBSL4FragmentSearch&quot;.</p>
<p>Step 2. Create a Service Reference folder and add Bing service.</p>
<p>Step 3. Add Sdk Frame with StackPanel, TextBlock, ListBox controls in MainPage,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you can refer to MainPage.xaml page.<br>
&nbsp;&nbsp;<br>
Step 4&nbsp; Add VB code in MainPage.xaml.cs page as shown below:<br>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Partial Public Class MainPage
    Inherits UserControl
    Dim results As New ObservableCollection(Of WebResult)()
    Public Sub New()
        InitializeComponent()
        SearchResults.ItemsSource = results
    End Sub
 
    Private Sub Frame_FragmentNavigation(ByVal sender As Object, ByVal e As System.Windows.Navigation.FragmentNavigationEventArgs)
        results.Clear()
 
        Dim sr As New Bing.SearchRequest()
        sr.Query = Convert.ToString(e.Fragment) &amp; &quot; (site:microsoft.com)&quot;
        sr.AppId = &quot;1009092976966EFB6DD6B0F0B98FE5E617990903&quot;
        sr.Sources = New SourceType() {SourceType.Web}
        sr.Web = New Bing.WebRequest()
        Dim bing As Bing.BingPortTypeClient = New BingPortTypeClient()
        AddHandler bing.SearchCompleted, AddressOf bing_SearchCompleted
        bing.SearchAsync(sr)
    End Sub
 
    Private Sub bing_SearchCompleted(ByVal sender As Object, ByVal e As SearchCompletedEventArgs)
        If e.Result.Web.Results IsNot Nothing Then
            For Each wr As WebResult In e.Result.Web.Results
                results.Add(wr)
            Next
        End If
    End Sub
 
    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ContentFrame.Navigate(New Uri(&quot;#&quot; &#43; SearchText.Text, UriKind.Relative))
    End Sub
 
    Private Sub Link_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim uri As New Uri(TryCast(TryCast(sender, StackPanel).Tag, String))
        System.Windows.Browser.HtmlPage.Window.Navigate(uri)
    End Sub
End Class</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Partial</span>&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MainPage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;UserControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;results&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ObservableCollection(<span class="visualBasic__keyword">Of</span>&nbsp;WebResult)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SearchResults.ItemsSource&nbsp;=&nbsp;results&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Frame_FragmentNavigation(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Windows.Navigation.FragmentNavigationEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;results.Clear()&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bing.SearchRequest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sr.Query&nbsp;=&nbsp;Convert.ToString(e.Fragment)&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;(site:microsoft.com)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sr.AppId&nbsp;=&nbsp;<span class="visualBasic__string">&quot;1009092976966EFB6DD6B0F0B98FE5E617990903&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sr.Sources&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SourceType()&nbsp;{SourceType.Web}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sr.Web&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bing.WebRequest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bing&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bing.BingPortTypeClient&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;BingPortTypeClient()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;bing.SearchCompleted,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;bing_SearchCompleted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bing.SearchAsync(sr)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;bing_SearchCompleted(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SearchCompletedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;e.Result.Web.Results&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;wr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;WebResult&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;e.Result.Web.Results&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;results.Add(wr)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentFrame.Navigate(<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__string">&quot;#&quot;</span>&nbsp;&#43;&nbsp;SearchText.Text,&nbsp;UriKind.Relative))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Link_MouseLeftButtonDown(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;MouseButtonEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;uri&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Uri(<span class="visualBasic__keyword">TryCast</span>(<span class="visualBasic__keyword">TryCast</span>(sender,&nbsp;StackPanel).Tag,&nbsp;<span class="visualBasic__keyword">String</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Browser.HtmlPage.Window.Navigate(uri)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 5. Build the application and you can debug it.</div>
<p></p>
<p style="font-family:Courier New">&nbsp;</p>
<h3>References:</h3>
<p>For more information about Silverlight fragment navigation, see <br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onfragmentnavigation%28VS.95%29.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onfragmentnavigation%28VS.95%29.aspx</a>.</p>
<p>Bing API, Version 2<br>
<a href="http://msdn.microsoft.com/en-us/library/dd251056.aspx">http://msdn.microsoft.com/en-us/library/dd251056.aspx</a></p>
<p style="font-family:Courier New"><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
