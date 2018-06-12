# Generate webpage thumbnail image (CSWinFormSaveWebpageToImage)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* WebBrowser
* Thumbnail
## IsPublished
* True
## ModifiedDate
* 2011-06-19 02:43:55
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CSWinFormSaveWebpageToImage Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to save the webpage as an image.<br>
<br>
The code sample creates a WebBrowser to retrieve the target webpage's<br>
html code and uses be WebBrowser.DrawToBitmap method convert the html <br>
code to .bmp image. In this code-sample, users can set the image's width,<br>
height and browser's width, height, generate an appropriate image.<br>
<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSWinFormSaveWebpageToImage.sln.<br>
<br>
Step 2: Expand the CSWinFormSaveWebpageToImage web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the MainForm.cs form.<br>
<br>
Step 3: We will see a WebBrowser control, two TextBox controls, a Button,<br>
&nbsp; &nbsp; &nbsp; &nbsp;and a PictureBox control on the form, you can find the WebBrowser<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;show a web page, the Save Page button will save the current web
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page of WebBrowser control.<br>
<br>
Step 4: Click the button to save an image in web application, you can also<br>
&nbsp; &nbsp; &nbsp; &nbsp;preview it on the PictureBox control. <br>
<br>
Step 5: If you update the image's size with TextBox controls text, you can<br>
&nbsp; &nbsp; &nbsp; &nbsp;retrieve the image in the root directory of web application.<br>
<br>
Step 6: You can even click the link of the Default.htm page to redirect the <br>
&nbsp; &nbsp; &nbsp; &nbsp;www.msdn.com, and click Save Page button to save the online
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;website's page as an image, if you find the image can not contain
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;whole content of pages, please adjust width or height TextBox of
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MainForm.cs form.<br>
<br>
Step 7: Validation finished.</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a C# &quot;Windows Forms Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSWinFormSaveWebpageToImage&quot;.<br>
<br>
Step 2. Add one windows form and one class file and named them as <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;MainForm.cs&quot;, &quot;WebPageThumbnail.cs&quot;.<br>
<br>
Step 3. The WebPageThumbnail class used to receive image's information and <br>
&nbsp; &nbsp; &nbsp; &nbsp;generate an appropriate image with html code.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Constructor method<br>
&nbsp; &nbsp; &nbsp; &nbsp;public WebpageThumbnail(string data, int browserWidth, int browserHeight, int thumbnailWidth, int thumbnailHeight, ThumbnailMethod method)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Method = method;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (method == ThumbnailMethod.Url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Url = data;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (method == ThumbnailMethod.Html)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Html = data;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.BrowserWidth = browserWidth;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.BrowserHeight = browserHeight;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Height = thumbnailHeight;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Width = thumbnailWidth;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Create a thread to execute GenerateThumbnailInteral method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Because the System.Windows.Forms.WebBrowser control has to
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// run on a STA thread while the current thread is MTA.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Bitmap GenerateThumbnail()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Thread thread = new Thread(new ThreadStart(GenerateThumbnailInteral));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.SetApartmentState(ApartmentState.STA);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.Start();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.Join();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return ThumbnailImage;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// This method creates WebBrowser instance retrieve the html code. Invoke WebBrowser_DocumentCompleted
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// method and convert html code to a bmp image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void GenerateThumbnailInteral()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser webBrowser = new WebBrowser();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.ScrollBarsEnabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (this.Method == ThumbnailMethod.Url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.Navigate(this.Url);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.DocumentText = this.Html;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.DocumentCompleted &#43;= new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;while (webBrowser.ReadyState != WebBrowserReadyState.Complete)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Application.DoEvents();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser webBrowser = (WebBrowser)sender;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.ClientSize = new Size(this.BrowserWidth, this.BrowserHeight);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.ScrollBarsEnabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ThumbnailImage = new Bitmap(webBrowser.Bounds.Width, webBrowser.Bounds.Height);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.BringToFront();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.DrawToBitmap(ThumbnailImage, webBrowser.Bounds);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ThumbnailImage = (Bitmap)ThumbnailImage.GetThumbnailImage(Width, Height, null, IntPtr.Zero);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 4. In MainForm.cs form, we load the Default.htm page and use<br>
&nbsp; &nbsp; &nbsp; &nbsp;a button named &quot;btnSavePage&quot; to create image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public string rootDirectotyStr = string.Empty;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public MainForm()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Load web page of the application.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;rootDirectotyStr = Application.StartupPath;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string webPageUrl = rootDirectotyStr &#43; &quot;\\Default.htm&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowserTargetPage.Url = new Uri(webPageUrl, UriKind.RelativeOrAbsolute);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.pctPreview.SizeMode = PictureBoxSizeMode.Zoom;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Convert WebBrowser's web page as an image and rendering in this page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// You can also find an image in sample project root directory.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void btnSavePage_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Image's size<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int width;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int height;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!int.TryParse(tbWidth.Text.Trim(), out width) ||<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!int.TryParse(tbHeight.Text.Trim(), out height))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Width or height must be integer number.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (width &lt;= 0 || width &gt; 2000 || height &lt;= 0 || height &gt; 6000)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Width or height are too small or too large. Please change another one.&quot;, &quot;Application Warning&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MessageBoxButtons.OK, MessageBoxIcon.Warning);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Save web page as an image in root directory, add an image in page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string htmlCode = webBrowserTargetPage.DocumentText;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebpageThumbnail thumb = new WebpageThumbnail(htmlCode, width, height, width, height, WebpageThumbnail.ThumbnailMethod.Html);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Bitmap imageWebpage = thumb.GenerateThumbnail();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;imageWebpage.Save(rootDirectotyStr &#43; &quot;/image.bmp&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pctPreview.Load(rootDirectotyStr &#43; &quot;/image.bmp&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(ex.Message &#43; &quot; Please try again&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: BitMap Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx</a><br>
<br>
MSDN: WebBrowser Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
