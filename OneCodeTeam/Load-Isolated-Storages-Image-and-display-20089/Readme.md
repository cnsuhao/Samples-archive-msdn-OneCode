# Load Isolated Storage's Image  and display
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone 8
* Windows Phone Development
## Topics
* Isolated Storage
* Windows Phone
* Load Image
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:35:06
## Description

<h1>How to load an Image from IsolatedStorage and display it on Device (VBWP8ImageFromIsolatedStorage)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample will demonstrate how to load an image from IsolatedStorage and display it on a device. First,we need to access a local or network picture and then store it in IsolatedStorage. Then, we need to load and display the IsolatedStorage's
 picture.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Open VBWP8ImageFromIsolatedStorage.sln</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91780/1/image.png" alt="" width="274" height="293" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>To comment on the local image's path of the line below and then uncomment the Network image's path. Or change the strPath's value to a network path directly.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Local Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strPath = &quot;WP8Logo.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Network Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' strPath = &quot;http://i.s-microsoft.com/global/ImageStore/PublishingImages/logos/hp/logo-lg-1x.png&quot;

</pre>
<pre id="codePreview" class="vb">
' Local Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strPath = &quot;WP8Logo.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Network Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' strPath = &quot;http://i.s-microsoft.com/global/ImageStore/PublishingImages/logos/hp/logo-lg-1x.png&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5 again. The emulator looks as follows:<br>
<span style=""><img src="/site/view/file/91781/1/image.png" alt="" width="215" height="260" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:38.25pt; text-indent:-.25in">
<span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a <span style="">Visual Basic</span> &quot;Windows Phone App&quot; in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone. Name it as &quot;VBWP8ImageFromIsolatedStorage&quot;.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:38.25pt; text-indent:-.25in">
<span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The XAML code in MainPage.xaml will resemble the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;phone:PhoneApplicationPage
&nbsp;&nbsp;&nbsp; x:Class=&quot;VBWP8ImageFromIsolatedStorage.MainPage&quot;
&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
&nbsp;&nbsp;&nbsp; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp; xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
&nbsp;&nbsp;&nbsp; xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
&nbsp;&nbsp;&nbsp; xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
&nbsp;&nbsp;&nbsp; xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
&nbsp;&nbsp;&nbsp; mc:Ignorable=&quot;d&quot;
&nbsp;&nbsp;&nbsp; FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
&nbsp;&nbsp;&nbsp; FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
&nbsp;&nbsp;&nbsp; Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
&nbsp;&nbsp;&nbsp; SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
&nbsp;&nbsp;&nbsp; shell:SystemTray.IsVisible=&quot;True&quot;&gt;


&nbsp;&nbsp;&nbsp; &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.RowDefinitions&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--TitlePanel contains the name of the application and page title--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text=&quot;MY APPLICATION&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text=&quot;page name&quot; Margin=&quot;9,-7,0,0&quot; Style=&quot;{StaticResource PhoneTextTitle1Style}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--ContentPanel - place additional content here--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;


&lt;/phone:PhoneApplicationPage&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;phone:PhoneApplicationPage
&nbsp;&nbsp;&nbsp; x:Class=&quot;VBWP8ImageFromIsolatedStorage.MainPage&quot;
&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
&nbsp;&nbsp;&nbsp; xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp; xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
&nbsp;&nbsp;&nbsp; xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
&nbsp;&nbsp;&nbsp; xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
&nbsp;&nbsp;&nbsp; xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
&nbsp;&nbsp;&nbsp; mc:Ignorable=&quot;d&quot;
&nbsp;&nbsp;&nbsp; FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
&nbsp;&nbsp;&nbsp; FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
&nbsp;&nbsp;&nbsp; Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
&nbsp;&nbsp;&nbsp; SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
&nbsp;&nbsp;&nbsp; shell:SystemTray.IsVisible=&quot;True&quot;&gt;


&nbsp;&nbsp;&nbsp; &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.RowDefinitions&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--TitlePanel contains the name of the application and page title--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text=&quot;MY APPLICATION&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text=&quot;page name&quot; Margin=&quot;9,-7,0,0&quot; Style=&quot;{StaticResource PhoneTextTitle1Style}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--ContentPanel - place additional content here--&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;


&lt;/phone:PhoneApplicationPage&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:38.25pt"><b style=""><span style="">&nbsp;</span>[Note]</b> The application has a grid control called ContentPanel; it is used to display the image.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:38.25pt; text-indent:-.25in">
<span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In order to complete this sample, we must ensure that the image exists in IsolatedStorage. In this sample, we will store local or network pictures to IsolatedStorage.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save stream to Jpeg.First, determine and delete the file with the same name
&nbsp;&nbsp; ''' in IsolatedStorage, and then create a new one.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;stream&quot;&gt;The stream of local image or network image&lt;/param&gt;
&nbsp;&nbsp; Private Sub SaveToJpeg(stream As Stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If iso.FileExists(strImageName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; iso.DeleteFile(strImageName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bitmap As New BitmapImage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bitmap.SetSource(stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wb As New WriteableBitmap(bitmap)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Encode WriteableBitmap object to a JPEG stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isostream.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save stream to Jpeg.First, determine and delete the file with the same name
&nbsp;&nbsp; ''' in IsolatedStorage, and then create a new one.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;stream&quot;&gt;The stream of local image or network image&lt;/param&gt;
&nbsp;&nbsp; Private Sub SaveToJpeg(stream As Stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If iso.FileExists(strImageName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; iso.DeleteFile(strImageName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using isostream As IsolatedStorageFileStream = iso.CreateFile(strImageName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bitmap As New BitmapImage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bitmap.SetSource(stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim wb As New WriteableBitmap(bitmap)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Encode WriteableBitmap object to a JPEG stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isostream.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:38.25pt"><span style="">To store the images we must retrieve the images' stream. For a network image, we will use
<b style="">WebClient</b> to download and store the images in its <b style="">OpenReadCompleted</b> event. We will use
</span><b style="">e.Result</b> as the stream<span style="">. For the local images, we will use
<b style="">Application.GetResourceStream</b> to get the images' <b style="">StreamResourceInfo</b>, and then use
</span><b style="">sri.Stream</b> as the stream.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save image to IsolatedStorage.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;flag&quot;&gt;1:web server;0:Local&lt;/param&gt;
&nbsp;&nbsp; Private Sub SaveImageToIsolatedStorage(flag As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If flag = 1 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use WebClient to download web server's images.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClientImg As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClientImg.OpenReadCompleted, New OpenReadCompletedEventHandler(AddressOf client_OpenReadCompleted)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClientImg.OpenReadAsync(New Uri(strPath, UriKind.Absolute))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use Uri to get local images.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sri As StreamResourceInfo = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(strPath, UriKind.Relative)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sri = Application.GetResourceStream(uri)


&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Save the local image's stream into a jpeg picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveToJpeg(sri.Stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save stream to jpeg when the asynchronous resource-read operation is completed.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;WebClient&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;OpenReadCompleted Event&lt;/param&gt;
&nbsp;&nbsp; Private Sub client_OpenReadCompleted(sender As Object, e As OpenReadCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the returned image stream into a jpeg picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveToJpeg(e.Result)
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save image to IsolatedStorage.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;flag&quot;&gt;1:web server;0:Local&lt;/param&gt;
&nbsp;&nbsp; Private Sub SaveImageToIsolatedStorage(flag As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If flag = 1 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use WebClient to download web server's images.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClientImg As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClientImg.OpenReadCompleted, New OpenReadCompletedEventHandler(AddressOf client_OpenReadCompleted)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClientImg.OpenReadAsync(New Uri(strPath, UriKind.Absolute))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use Uri to get local images.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sri As StreamResourceInfo = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(strPath, UriKind.Relative)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sri = Application.GetResourceStream(uri)


&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Save the local image's stream into a jpeg picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveToJpeg(sri.Stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Save stream to jpeg when the asynchronous resource-read operation is completed.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;WebClient&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;OpenReadCompleted Event&lt;/param&gt;
&nbsp;&nbsp; Private Sub client_OpenReadCompleted(sender As Object, e As OpenReadCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the returned image stream into a jpeg picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveToJpeg(e.Result)
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:38.25pt; text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">If the</span> image contains the HTTP protocol, then it is stored on a web server. Otherwise, it is stored locally. Now the images should be stored to IsolatedStorage.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub CreateImage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Local Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strPath = &quot;WP8Logo.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Network Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' strPath = &quot;http://i.s-microsoft.com/global/ImageStore/PublishingImages/logos/hp/logo-lg-1x.png&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If strPath.Contains(&quot;http://&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strImageName = strPath.Substring(strPath.LastIndexOf(&quot;/&quot;) &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveImageToIsolatedStorage(1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strImageName = strPath
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveImageToIsolatedStorage(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 &nbsp;&nbsp;&nbsp;End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub CreateImage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Local Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strPath = &quot;WP8Logo.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Network Image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' strPath = &quot;http://i.s-microsoft.com/global/ImageStore/PublishingImages/logos/hp/logo-lg-1x.png&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If strPath.Contains(&quot;http://&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strImageName = strPath.Substring(strPath.LastIndexOf(&quot;/&quot;) &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveImageToIsolatedStorage(1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strImageName = strPath
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SaveImageToIsolatedStorage(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
 &nbsp;&nbsp;&nbsp;End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:38.25pt; text-indent:-.25in"><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Now we can load the image from IsolatedStorage. We need to get file stream of pictures from IsolatedStorage and then store it to a byte array. Based on the above file stream to create a memory stream, and then creates a Bitmap by using
 the memory stream.<span style="">&nbsp; </span>Assign the generated Bitmap to image UI element, and then add the image to the grid to display it on the device.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub LoadImageFromIsolatedStorage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The image will be read from isolated storage into the following byte array
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Read the entire image in one go into a byte array
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using isf As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Open the file - error handling omitted for brevity
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Note: If the image does not exist in isolated storage the following exception will be generated:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' System.IO.IsolatedStorage.IsolatedStorageException was unhandled 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Message=Operation not permitted on IsolatedStorageFileStream 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using isfs As IsolatedStorageFileStream = isf.OpenFile(strImageName, FileMode.Open, FileAccess.Read)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Allocate an array large enough for the entire file
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; data = New Byte(isfs.Length - 1) {}


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Read the entire file and then close it
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isfs.Read(data, 0, data.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isfs.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create memory stream and bitmap
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ms As New MemoryStream(data)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bi As New BitmapImage()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set bitmap source to memory stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bi.SetSource(ms)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an image UI element Note: this could be declared in the XAML instead
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim image As New Image()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set size of image to bitmap size for this demonstration
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Height = bi.PixelHeight
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Width = bi.PixelWidth


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Assign the bitmap image to the image's source
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Source = bi


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the image to the grid in order to display the bit map
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ContentPanel.Children.Add(image)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' handle the exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(e.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub LoadImageFromIsolatedStorage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The image will be read from isolated storage into the following byte array
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Read the entire image in one go into a byte array
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using isf As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Open the file - error handling omitted for brevity
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Note: If the image does not exist in isolated storage the following exception will be generated:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' System.IO.IsolatedStorage.IsolatedStorageException was unhandled 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Message=Operation not permitted on IsolatedStorageFileStream 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using isfs As IsolatedStorageFileStream = isf.OpenFile(strImageName, FileMode.Open, FileAccess.Read)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Allocate an array large enough for the entire file
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; data = New Byte(isfs.Length - 1) {}


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Read the entire file and then close it
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isfs.Read(data, 0, data.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isfs.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create memory stream and bitmap
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ms As New MemoryStream(data)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bi As New BitmapImage()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set bitmap source to memory stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bi.SetSource(ms)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an image UI element Note: this could be declared in the XAML instead
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim image As New Image()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set size of image to bitmap size for this demonstration
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Height = bi.PixelHeight
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Width = bi.PixelWidth


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Assign the bitmap image to the image's source
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.Source = bi


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the image to the grid in order to display the bit map
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ContentPanel.Children.Add(image)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' handle the exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(e.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:38.25pt; text-indent:-.25in"><span style=""><span style="">Step 6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Finally, register the required method at the MainPage's Constructor.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Loading local or network picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateImage()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Sample code to localize the ApplicationBar
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LoadImageFromIsolatedStorage()
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Loading local or network picture.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CreateImage()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Sample code to localize the ApplicationBar
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LoadImageFromIsolatedStorage()
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:38.25pt; text-indent:-.25in"><span style=""><span style="">Step 7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then it can be debugged.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">WebClient Class <br>
<a href="http://msdn.microsoft.com/en-US/library/system.net.webclient(v=vs.95).aspx">http://msdn.microsoft.com/en-US/library/system.net.webclient(v=vs.95).aspx</a><br>
WebClient.OpenReadAsync Method (Uri)<br>
<a href="http://msdn.microsoft.com/en-US/library/ms144211(v=vs.95).aspx">http://msdn.microsoft.com/en-US/library/ms144211(v=vs.95).aspx</a><br>
WebClient.OpenReadCompleted Event <br>
<a href="http://msdn.microsoft.com/en-US/library/system.net.webclient.openreadcompleted(v=vs.95).aspx">http://msdn.microsoft.com/en-US/library/system.net.webclient.openreadcompleted(v=vs.95).aspx</a><br>
Application.GetResourceStream Method (Uri)<br>
<a href="http://msdn.microsoft.com/en-us/library/ms596994(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/ms596994(v=VS.95).aspx</a><br>
StreamResourceInfo.Stream Property<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.resources.streamresourceinfo.stream(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.resources.streamresourceinfo.stream(v=vs.95).aspx</a><br>
IsolatedStorageFile.GetUserStoreForApplication Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragefile.getuserstoreforapplication(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragefile.getuserstoreforapplication(v=vs.95).aspx</a><br>
IsolatedStorageFile Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragefile(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/system.io.isolatedstorage.isolatedstoragefile(v=vs.95).aspx</a><br>
BitmapImage Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.media.imaging.bitmapimage(v=VS.95).aspx</a><br>
MemoryStream Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.memorystream(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/system.io.memorystream(v=vs.95).aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
