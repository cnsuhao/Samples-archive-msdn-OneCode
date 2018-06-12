# Use Silverlight fragment navigation to perform a search (CSSL4FragmentSearch)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Fragment Navigation
* Bing
## IsPublished
* True
## ModifiedDate
* 2011-07-17 08:20:59
## Description

<p style="font-family:Courier New"></p>
<h2>Sivlerlight APPLICATION: CSSL4FragmentSearch Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The CSSL4FragmentSearch is a simple sample demonstrating the use of fragment <br>
navigation within Silverlight to perform a search. &nbsp;The advantage this <br>
provides is that the search can then be saved by URL, and linked directly, <br>
with consistent behavior, allowing users to send links to direct results <br>
within Silverlight.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To run the sample, simply launch the project. &nbsp;A web page will load, with the
<br>
Silverlight fragment search component. &nbsp;Type a search, and a Bing search <br>
filtered on Microsoft.com will be performed with the search terms. &nbsp;Note that
<br>
the URL will now include the search terms as a fragment, which can <br>
subsequently be bookmarked or copied and pasted into a new browser tab, after <br>
which time the same search will again be performed (as long as the URL <br>
remains valid - in the debug mode, as long as the project continues to run on <br>
the same port).<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The sample uses one simple Silverlight component, and all the relevant code <br>
is in MainPage.xaml, and its codebehind, MainPage.xaml.cs. &nbsp;The code simply <br>
implements a fragment navigation event, which performs a web search with the <br>
Bing web service API, applying the fragment text as the search terms.<br>
<br>
&nbsp; &nbsp;&lt;sdk:Frame x:Name=&quot;ContentFrame&quot; FragmentNavigation=&quot;Frame_FragmentNavigation&quot;&gt;<br>
<br>
&nbsp; &nbsp;private void Frame_FragmentNavigation(object sender, System.Windows.Navigation.FragmentNavigationEventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;results.Clear();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Bing.SearchRequest sr = new Bing.SearchRequest();<br>
&nbsp; &nbsp; &nbsp; &nbsp;sr.Query = e.Fragment &#43; &quot; (site:microsoft.com)&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;sr.AppId = &quot;1009092976966EFB6DD6B0F0B98FE5E617990903&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;sr.Sources = new SourceType[] { SourceType.Web };<br>
&nbsp; &nbsp; &nbsp; &nbsp;sr.Web = new Bing.WebRequest();<br>
&nbsp; &nbsp; &nbsp; &nbsp;Bing.BingPortTypeClient bing = new BingPortTypeClient();<br>
&nbsp; &nbsp; &nbsp; &nbsp;bing.SearchCompleted &#43;= new EventHandler&lt;SearchCompletedEventArgs&gt;(bing_SearchCompleted);<br>
&nbsp; &nbsp; &nbsp; &nbsp;bing.SearchAsync(sr);<br>
&nbsp; &nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
For more information about Silverlight fragment navigation, see <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onfragmentnavigation%28VS.95%29.aspx.">http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onfragmentnavigation%28VS.95%29.aspx.</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
