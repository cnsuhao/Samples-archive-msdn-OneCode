# How to render html to Image on Windows Phone
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone Development
## Topics
* Image
* WebBrowser
* code snippets
* Render html
## IsPublished
* True
## ModifiedDate
* 2014-04-24 02:50:45
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to render html to Image on Windows Phone 8</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">How to render html to Image on Windows Phone 8.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Create </span>
<span style="font-size:11pt">an</span><span style="font-size:11pt"> instance of Popup.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Set the Popup control off the screen.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Us</span><span style="font-size:11pt">e</span><span style="font-size:11pt"> a WebBrowser</span><span style="font-size:11pt">(WebView in Windows Phone 8.1)</span><span style="font-size:11pt">
 control to render your html.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Add the WebBrowser control to Popup's child panel.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.HorizontalOffset = -300;
            popup.VerticalOffset = -300;
            //web is WebBrowser type.
            web = new WebBrowser()
            {
                Width = 300d,
                Height = 300d
            };
            popup.Child = web;
            popup.IsOpen = true;
            web.Navigate(new Uri(&quot;http://www.msn.com&quot;));
        }
</pre>
<pre class="hidden">Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
 Dim popup As New Popup()
 popup.HorizontalOffset = -300
 popup.VerticalOffset = -300
 web = New WebBrowser() With { _
  Key .Width = 300.0, _
  Key .Height = 300.0 _
 }
 popup.Child = web
 popup.IsOpen = True
 web.Navigate(New Uri(&quot;http://www.msn.com&quot;))
End Sub
</pre>
<pre class="hidden">void TestApp::MainPage::Page_Loaded(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 Popup^ popup = ref new Popup();
 popup-&gt;HorizontalOffset = -300;
 popup-&gt;VerticalOffset = -300;
//web is WebView type.
 web = ref new WebView;
 web-&gt;Width = 300;
 web-&gt;Height = 300;
 popup-&gt;Child = web;
 popup-&gt;IsOpen = true;
 web-&gt;Navigate(ref new Uri(L&quot;http://www.msn.com&quot;));
}
</pre>
<pre id="codePreview" class="csharp">void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.HorizontalOffset = -300;
            popup.VerticalOffset = -300;
            //web is WebBrowser type.
            web = new WebBrowser()
            {
                Width = 300d,
                Height = 300d
            };
            popup.Child = web;
            popup.IsOpen = true;
            web.Navigate(new Uri(&quot;http://www.msn.com&quot;));
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>If you have a WebBrowser</span><span>(or WebView)</span><span> control (named &ldquo;web&rdquo; in my example) that hosts your HTML, you can just do this:
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">private void btnTest_Click(object sender, RoutedEventArgs e) 
        { 
            WriteableBitmap bitmap = new WriteableBitmap(web, null); 
            Image img = new Image(); 
            img.Name = &quot;testImg&quot;; 
            img.Source = bitmap; 
            img.Height = 200; 
            img.Width = 200;             
            
            ContentPanel.Children.Add(img); 
        } 
</pre>
<pre class="hidden">Private Sub btnTest_Click(sender As Object, e As RoutedEventArgs)
 Dim bitmap As New WriteableBitmap(web, Nothing)
 Dim img As New Image()
 img.Name = &quot;testImg&quot;
 img.Source = bitmap
 img.Height = 200
 img.Width = 200
 ContentPanel.Children.Add(img)
End Sub
</pre>
<pre class="hidden">void TestApp::MainPage::Button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 InMemoryRandomAccessStream^ stream = ref new InMemoryRandomAccessStream;
 create_task(web-&gt;CapturePreviewToStreamAsync(stream)).then([this, stream](){
  WriteableBitmap^ bitmap = ref new WriteableBitmap(200, 200);
  bitmap-&gt;SetSource(stream);
  Image ^img = ref new Image;
  img-&gt;Width = 200;
  img-&gt;Height = 200;
  img-&gt;Source = bitmap;
  ContentPanel-&gt;Children-&gt;Append(img);
 }); 
}
</pre>
<pre id="codePreview" class="csharp">private void btnTest_Click(object sender, RoutedEventArgs e) 
        { 
            WriteableBitmap bitmap = new WriteableBitmap(web, null); 
            Image img = new Image(); 
            img.Name = &quot;testImg&quot;; 
            img.Source = bitmap; 
            img.Height = 200; 
            img.Width = 200;             
            
            ContentPanel.Children.Add(img); 
        } 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Popup Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.primitives.popup(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.controls.primitives.popup(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Popup Properties</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.primitives.popup_properties(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.windows.controls.primitives.popup_properties(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>WebBrowser control for Windows Phone</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/ff431797(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/ff431797(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>WebBrowser Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/microsoft.phone.controls.webbrowser(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/microsoft.phone.controls.webbrowser(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>WriteableBitmap Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.windows.media.imaging.writeablebitmap(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/system.windows.media.imaging.writeablebitmap(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Quickstart: Images for Windows Phone</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj206957(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj206957(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WebBrowser Methods</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/microsoft.phone.controls.webbrowser_methods(v=vs.105).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windowsphone/develop/microsoft.phone.controls.webbrowser_methods(v=vs.105).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WebView.CapturePreviewToStreamAsync</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.capturepreviewtostreamasync(v=win.10).aspx?cs-save-lang=1&cs-lang=cpp#code-snippet-1" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.webview.capturepreviewtostreamasync(v=win.10).aspx?cs-save-lang=1&amp;cs-lang=cpp#code-snippet-1</span></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
