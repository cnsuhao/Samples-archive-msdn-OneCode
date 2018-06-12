# How to intercept JavaScript alert in WebView and display the alert message in Wi
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* WebView
## IsPublished
* False
## ModifiedDate
* 2014-06-23 03:02:29
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to intercept JavaScript alert</span><span style="font-weight:bold; font-size:14pt">s</span><span style="font-weight:bold; font-size:14pt"> in WebView and display
 the alert message</span><span style="font-weight:bold; font-size:14pt">s</span><span style="font-weight:bold; font-size:14pt"> in Windows Store apps.</span><span style="font-weight:bold; font-size:14pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The Windows 8 &amp; 8.1 WebView control will not show Java</span><span style="">S</span><span style="">cript Alerts that are raised by the webpage inside the WebView. This pres</span><span style="">ents a challenge
 to application</span><span style=""> developers when they do not control the content of the website. However, this can be remedied by the use of Java</span><span style="">S</span><span style="">cript invoked into the WebView. This code sample will show you
 h</span><span style="">ow to intercept JavaScript alert</span><span style="">s</span><span style=""> in WebView and display the alert message</span><span style="">s</span><a name="_GoBack"></a><span style=""> in Windows Store apps.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold">Please note: The samples were written based on the following video:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/WebView-Magic-Tricks-Series-Part-3-Alert-Interceptor" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/WebView-Magic-Tricks-Series-Part-3-Alert-Interceptor</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can build and run the sample in Visual Studio 2013. After being launched, the app looks like this:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/117364/1/image.png" alt="" width="479" height="295" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The Windows 8 &amp; 8.1 WebView control will not show Javascript
</span><span style="">a</span><span style="">lerts that are raised by the webpage inside the WebView.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">scriptNotify_example.html</span><span style=""> mimics
</span><span style="">a scenario in which the Javascript Alert()</span><span style=""> is called.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;!DOCTYPE html&gt;
&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Example HTML document&lt;/title&gt;
&lt;/head&gt;
&lt;body onload=&quot;onload();&quot;&gt;
    <p>This is a simple test page for testing how to intercept JavaScript alerts in WebView. When you click on Alert button below, you will receive a notification sent by JavaScript alert.</p>
    &lt;input type=&quot;text&quot; id=&quot;AlertMessageTextBox&quot;/&gt;
    &lt;input type=&quot;button&quot; onclick=&quot;Alert();&quot; value=&quot;Alert!&quot;/&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        function Alert() {
            window.alert(document.getElementById('AlertMessageTextBox').value);
        }
    &lt;/script&gt;
&lt;/body&gt;
&lt;/html&gt;
</pre>
<pre id="codePreview" class="html">
&lt;!DOCTYPE html&gt;
&lt;html&gt;
&lt;head&gt;
    &lt;title&gt;Example HTML document&lt;/title&gt;
&lt;/head&gt;
&lt;body onload=&quot;onload();&quot;&gt;
    <p>This is a simple test page for testing how to intercept JavaScript alerts in WebView. When you click on Alert button below, you will receive a notification sent by JavaScript alert.</p>
    &lt;input type=&quot;text&quot; id=&quot;AlertMessageTextBox&quot;/&gt;
    &lt;input type=&quot;button&quot; onclick=&quot;Alert();&quot; value=&quot;Alert!&quot;/&gt;
    &lt;script type=&quot;text/javascript&quot;&gt;
        function Alert() {
            window.alert(document.getElementById('AlertMessageTextBox').value);
        }
    &lt;/script&gt;
&lt;/body&gt;
&lt;/html&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Normally, the WebView control will not show JavaScript Alerts. To remedy this limitation, we can inject JavaScript</span><span style=""> code by calling
</span><span style="font-weight:bold">WebView.InvokeScriptAsync </span><span style="">function.</span><span style=""> A hosted HTML page can fire the
</span><span style="font-weight:bold">ScriptNotify</span><span style=""> event in your Windows Store app when the page calls
</span><span style="font-weight:bold">window.external.notify</span><span style=""> and passes a string parameter.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">
private async void WebViewWithJSInjection_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
{
    string result = await this.WebViewWithJSInjection.InvokeScriptAsync(&quot;eval&quot;, new string[] { &quot;window.alert = function (AlertMessage) {window.external.notify(AlertMessage)}&quot; });
}
</pre>
<pre class="hidden">
Private Async Sub WebViewWithJSInjection_NavigationCompleted(sender As WebView, args As WebViewNavigationCompletedEventArgs)
    Dim result As String = Await Me.WebViewWithJSInjection.InvokeScriptAsync(&quot;eval&quot;, New String() {&quot;window.alert = function (AlertMessage) {window.external.notify(AlertMessage)}&quot;})
End Sub
</pre>
<pre class="hidden">
void MainPage::WebViewWithJSInjection_NavigationCompleted(Windows::UI::Xaml::Controls::WebView^ sender, Windows::UI::Xaml::Controls::WebViewNavigationCompletedEventArgs^ args)
{
 Array&lt;String^&gt;^ argsArray = { &quot;window.alert = function (AlertMessage) {window.external.notify(AlertMessage)}&quot; };
 Platform::Collections::Vector&lt;String^&gt;^ arguments = ref new Platform::Collections::Vector&lt;String^&gt;(argsArray);
 this-&gt;WebViewWithJSInjection-&gt;InvokeScriptAsync(&quot;eval&quot;, arguments);
}
</pre>
<pre id="codePreview" class="csharp">
private async void WebViewWithJSInjection_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
{
    string result = await this.WebViewWithJSInjection.InvokeScriptAsync(&quot;eval&quot;, new string[] { &quot;window.alert = function (AlertMessage) {window.external.notify(AlertMessage)}&quot; });
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Then in </span><span style="font-weight:bold">ScriptNotify
</span><span style="">event handler, we can receive the alert message and show it like below.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">
private async void WebViewWithJSInjection_ScriptNotify(object sender, NotifyEventArgs e)
{
    Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog(e.Value);
    await dialog.ShowAsync();
}
</pre>
<pre class="hidden">
Private Async Sub WebViewWithJSInjection_ScriptNotify(sender As Object, e As NotifyEventArgs)
    Dim dialog As New Windows.UI.Popups.MessageDialog(e.Value)
    Await dialog.ShowAsync()
End Sub
</pre>
<pre class="hidden">
void MainPage::WebViewWithJSInjection_ScriptNotify(Platform::Object^ sender, Windows::UI::Xaml::Controls::NotifyEventArgs^ e)
{
 Windows::UI::Popups::MessageDialog^ dialog = ref new Windows::UI::Popups::MessageDialog(e-&gt;Value);
 dialog-&gt;ShowAsync();
}
</pre>
<pre id="codePreview" class="csharp">
private async void WebViewWithJSInjection_ScriptNotify(object sender, NotifyEventArgs e)
{
    Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog(e.Value);
    await dialog.ShowAsync();
}
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
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">WebView Magic Tricks Series Part 3: Alert Interceptor</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/WebView-Magic-Tricks-Series-Part-3-Alert-Interceptor" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://channel9.msdn.com/Series/Windows-Store-Developer-Solutions/WebView-Magic-Tricks-Series-Part-3-Alert-Interceptor</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">WebView class</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">WebView.InvokeScriptAsync method</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.invokescriptasync.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.invokescriptasync.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">WebView.ScriptNotify event</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.scriptnotify.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.scriptnotify.aspx</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
