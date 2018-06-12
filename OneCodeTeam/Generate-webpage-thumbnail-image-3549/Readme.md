# Generate webpage thumbnail image (VBWinFormSaveWebpageToImage)
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
* 2011-06-19 02:37:31
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>VBWinFormSaveWebpageToImage Overview</h2>
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
Step 1: Open the VBWinFormSaveWebpageToImage.sln.<br>
<br>
Step 2: Expand the VBWinFormSaveWebpageToImage web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the MainForm.vb form.<br>
<br>
Step 3: We will see a WebBrowser control, two TextBox controls, a Button,<br>
&nbsp; &nbsp; &nbsp; &nbsp;and a PictureBox control on the form, you can find the WebBrowser<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;show a web page, the Save Page button will save the current web
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page of WebBrowser control.<br>
<br>
Step 4: Click the button to save an image of web application, you can also<br>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MainForm.vb form.<br>
<br>
Step 7: Validation finished.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;Windows Forms Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBWinFormSaveWebpageToImage&quot;.<br>
<br>
Step 2. Add one windows form and one class file and named them as <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;MainForm.vb&quot;, &quot;WebPageThumbnail.vb&quot;.<br>
<br>
Step 3. The WebPageThumbnail class used to receive image's information and <br>
&nbsp; &nbsp; &nbsp; &nbsp;generate an appropriate image with html code.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Constructor method<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal data As String, ByVal browserWidth As Integer, ByVal browserHeight As Integer, ByVal thumbnailWidth As Integer, ByVal thumbnailHeight As Integer, ByVal method As ThumbnailMethod)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Method = method<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If method = ThumbnailMethod.Url Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Url = data<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ElseIf method = ThumbnailMethod.Html Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Html = data<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.BrowserWidth = browserWidth<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.BrowserHeight = browserHeight<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Height = thumbnailHeight<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Width = thumbnailWidth<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Create a thread to execute GenerateThumbnailInteral method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Because the System.Windows.Forms.WebBrowser control has to
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' run on a STA thread while the current thread is MTA.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;returns&gt;&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Function GenerateThumbnail() As Bitmap<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim thread As New Thread(New ThreadStart(AddressOf GenerateThumbnailInteral))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.SetApartmentState(ApartmentState.STA)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.Start()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;thread.Join()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return ThumbnailImage<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Function<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' This method creates WebBrowser instance retrieve the html code. Invoke WebBrowser_DocumentCompleted
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' method and convert html code to a bmp image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub GenerateThumbnailInteral()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim webBrowser As New WebBrowser()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.ScrollBarsEnabled = False<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.ScriptErrorsSuppressed = True<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Me.Method = ThumbnailMethod.Url Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.Navigate(Me.Url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.DocumentText = Me.Html<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler webBrowser.DocumentCompleted, AddressOf WebBrowser_DocumentCompleted<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;While webBrowser.ReadyState &lt;&gt; WebBrowserReadyState.Complete<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Application.DoEvents()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End While<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch e As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Record the exception...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw e<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Finally<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowser.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub WebBrowser_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim webBrowser As WebBrowser = DirectCast(sender, WebBrowser)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser.ClientSize = New Size(Me.BrowserWidth, Me.BrowserHeight)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser.ScrollBarsEnabled = False<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.ThumbnailImage = New Bitmap(WebBrowser.Bounds.Width, WebBrowser.Bounds.Height)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser.BringToFront()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowser.DrawToBitmap(ThumbnailImage, WebBrowser.Bounds)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.ThumbnailImage = DirectCast(ThumbnailImage.GetThumbnailImage(Width, Height, Nothing, IntPtr.Zero), Bitmap)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 4. In MainForm.vb form, we load the Default.htm page and use<br>
&nbsp; &nbsp; &nbsp; &nbsp;a button named &quot;btnSavePage&quot; to create image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Handles MyBase.Load<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Load web page of the application.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;rootDirectotyStr = Application.StartupPath<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim webPageUrl As String = rootDirectotyStr &amp; &quot;\Default.htm&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;webBrowserTargetPage.Url = New Uri(webPageUrl, UriKind.RelativeOrAbsolute)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.pctPreview.SizeMode = PictureBoxSizeMode.Zoom<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Convert WebBrowser's web page as an image and rendering in this page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' You can also find an image in sample project root directory.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub btnSavePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePage.Click<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Thumbnail image size<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim width As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim height As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not Integer.TryParse(tbWidth.Text.Trim(), width) OrElse _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Not Integer.TryParse(tbHeight.Text.Trim(), height) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Width or height must be integer number.&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If width &lt;= 0 OrElse width &gt; 2000 OrElse height &lt;= 0 OrElse height &gt; 6000 Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Width(1-2000) or height(1-6000) are too small or too large. &quot; &amp; _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Please change the size.&quot;, &quot;Application Warning&quot;, _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBoxButtons.OK, MessageBoxIcon.Warning)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Save web page as an image in root diectory, add an image in page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim htmlCode As String = webBrowserTargetPage.DocumentText<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim thumb As New WebPageThumbnail(htmlCode, width, height, width, height, _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebPageThumbnail.ThumbnailMethod.Html)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim imageWebpage As Bitmap = thumb.GenerateThumbnail()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;imageWebpage.Save(rootDirectotyStr &amp; &quot;/image.bmp&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pctPreview.Load(rootDirectotyStr &amp; &quot;/image.bmp&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(ex.Message &#43; &quot; Please try again&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
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
