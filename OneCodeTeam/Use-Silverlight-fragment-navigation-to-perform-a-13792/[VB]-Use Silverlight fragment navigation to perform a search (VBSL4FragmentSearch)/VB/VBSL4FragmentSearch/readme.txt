================================================================================
       Sivlerlight APPLICATION: VBSL4FragmentSearch Overview                   

/////////////////////////////////////////////////////////////////////////////
Summary:  

The VBSL4FragmentSearch is a simple sample demonstrating the use of fragment navigation 
within Silverlight to perform a search.  The advantage this provides is that the search 
can then be saved by URL, and linked directly, with consistent behavior, allowing users 
to send links to direct results within Silverlight.


/////////////////////////////////////////////////////////////////////////////
Demo:         

To run the sample, press ctrl + F5 start the project. The application will show a popup box
, click "yes" to continue, a web page will load, with the Silverlight 
fragment navigation's search component.  Input your text in TextBox and click search button, and a Bing 
search filtered on Microsoft.com will be performed with the search terms.  Note that the
URL string will now include the search terms as a fragment, which can subsequently be bookmarked 
or copied and pasted into a new browser tab, after which time the same search will 
again be performed (as long as the URL remains valid - in the debug mode, 
as long as the project continues to run on the same port).

 
/////////////////////////////////////////////////////////////////////////////
Implementation:

The sample uses one simple Silverlight component, and all the relevant code is in MainPage.xaml, 
and its code behind, MainPage.xaml.cs.  The code simply implements a fragment navigation event, 
which performs a web search with the Bing web service API, applying the fragment text as the 
search terms.

Following steps below to create this sample:

Step 1. Create a VB "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBSL4FragmentSearch".

Step 2. Create a Service Reference folder and add Bing service.

Step 3. Add Sdk Frame with StackPanel, TextBlock, ListBox controls in MainPage,
        you can refer to MainPage.xaml page.
		
Step 4  Add VB code in MainPage.xaml.cs page as shown below:
		[code]
Partial Public Class MainPage
    Inherits UserControl
    Dim results As New ObservableCollection(Of WebResult)()
    Public Sub New()
        InitializeComponent()
        SearchResults.ItemsSource = results
    End Sub

    Private Sub Frame_FragmentNavigation(ByVal sender As Object, ByVal e As System.Windows.Navigation.FragmentNavigationEventArgs)
        results.Clear()

        Dim sr As New Bing.SearchRequest()
        sr.Query = Convert.ToString(e.Fragment) & " (site:microsoft.com)"
        sr.AppId = "1009092976966EFB6DD6B0F0B98FE5E617990903"
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
        ContentFrame.Navigate(New Uri("#" + SearchText.Text, UriKind.Relative))
    End Sub

    Private Sub Link_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        Dim uri As New Uri(TryCast(TryCast(sender, StackPanel).Tag, String))
        System.Windows.Browser.HtmlPage.Window.Navigate(uri)
    End Sub
End Class
		[/code]

Step 5. Build the application and you can debug it.

/////////////////////////////////////////////////////////////////////////////
References:

For more information about Silverlight fragment navigation, see 
http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onfragmentnavigation%28VS.95%29.aspx.

Bing API, Version 2
http://msdn.microsoft.com/en-us/library/dd251056.aspx