# How to save WriteableBitmap to image file in Windows store apps
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
* Windows 8.1
## Topics
* code snippets
* save WriteableBitmap
## IsPublished
* True
## ModifiedDate
* 2014-06-15 08:17:28
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to save
</span><span style="font-weight:bold; font-size:14pt">a </span><span style="font-weight:bold; font-size:14pt">WriteableBitmap obejct to
</span><span style="font-weight:bold; font-size:14pt">an image file in Windows S</span><span style="font-weight:bold; font-size:14pt">tore apps</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The code snippets will show you how to save
</span><span style="font-size:11pt">a </span><span style="font-size:11pt">WriteableBitmap object to</span><span style="font-size:11pt"> an image file in Windows S</span><span style="font-size:11pt">tore apps. Some customers don't know how to do it.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>The XAML codes </span><span>are </span><span>shown below:</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Page
    x:Class=&quot;CSSaveWriteableBitmapToImage.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:local=&quot;using:CSSaveWriteableBitmapToImage&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    mc:Ignorable=&quot;d&quot;&gt;
    &lt;Grid Background=&quot;Transparent&quot;&gt;
        &lt;StackPanel Margin=&quot;120 0 0 0&quot;&gt;
            &lt;Button x:Name=&quot;btnSaveImage&quot; Content=&quot;Save&quot; Margin=&quot;0 10 0 0&quot; Click=&quot;btnSaveImage_Click&quot; /&gt;
        &lt;/StackPanel&gt;
    &lt;/Grid&gt;
&lt;/Page&gt;
</pre>
<pre id="codePreview" class="xaml">&lt;Page
    x:Class=&quot;CSSaveWriteableBitmapToImage.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:local=&quot;using:CSSaveWriteableBitmapToImage&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    mc:Ignorable=&quot;d&quot;&gt;
    &lt;Grid Background=&quot;Transparent&quot;&gt;
        &lt;StackPanel Margin=&quot;120 0 0 0&quot;&gt;
            &lt;Button x:Name=&quot;btnSaveImage&quot; Content=&quot;Save&quot; Margin=&quot;0 10 0 0&quot; Click=&quot;btnSaveImage_Click&quot; /&gt;
        &lt;/StackPanel&gt;
    &lt;/Grid&gt;
&lt;/Page&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>Click the save button to save </span><span>the
</span><span>WriteableBitmap object</span><a name="_GoBack"></a><span> to image file on local machine.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging; 
private async void btnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            // Create An Instance of WriteableBitmap object 
            WriteableBitmap writeableBitmap = new WriteableBitmap(300, 300);
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///Assets/Logo.scale-100.png&quot;));
            using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                // set the source for WriteableBitmap 
                await writeableBitmap.SetSourceAsync(fileStream);
            }
            // Save the writeableBitmap object to JPG Image file
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add(&quot;JPG File&quot;, new List&lt;string&gt;() { &quot;.jpg&quot; });
            StorageFile savefile = await picker.PickSaveFileAsync();
            if (savefile == null)
                return;
            IRandomAccessStream stream = await savefile.OpenAsync(FileAccessMode.ReadWrite);
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            // Get pixels of the WriteableBitmap object
            Stream pixelStream = writeableBitmap.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
            // Save the image file with jpg extension
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, 96.0, 96.0, pixels);
            await encoder.FlushAsync();
        }
</pre>
<pre class="hidden">Imports Windows.Storage
Imports Windows.Storage.Streams
Imports Windows.Storage.Pickers
Imports Windows.Graphics.Imaging
Private Async Sub btnSaveImage_Click(sender As Object, e As RoutedEventArgs)
        ' Create An Instance of WriteableBitmap object  
        Dim writeableBitmap As New WriteableBitmap(300, 300)
        Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(New Uri(&quot;ms-appx:///Assets/Logo.scale-100.png&quot;))
        Using fileStream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)
            ' set the source for WriteableBitmap  
            Await writeableBitmap.SetSourceAsync(fileStream)
        End Using
        ' Save the writeableBitmap object to JPG Image file 
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add(&quot;JPG File&quot;, New List(Of String)() From { _
            &quot;.jpg&quot;
        })
        Dim savefile As StorageFile = Await picker.PickSaveFileAsync()
        If savefile Is Nothing Then
            Return
        End If
        Dim stream As IRandomAccessStream = Await savefile.OpenAsync(FileAccessMode.ReadWrite)
        Dim encoder As BitmapEncoder = Await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream)
        ' Get pixels of the WriteableBitmap object
        Dim pixelStream As Stream = writeableBitmap.PixelBuffer.AsStream()
        Dim pixels As Byte() = New Byte(pixelStream.Length - 1) {}
        Await pixelStream.ReadAsync(pixels, 0, pixels.Length)
        ' Save the image file with jpg extension
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, CUInt(writeableBitmap.PixelWidth), CUInt(writeableBitmap.PixelHeight), 96.0, 96.0, _
            pixels)
        Await encoder.FlushAsync()
    End Sub
</pre>
<pre class="hidden">#include &quot;pch.h&quot;
#include &quot;MainPage.xaml.h&quot;
using namespace CppSaveWriteableBitmapToImage;
using namespace concurrency;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace Windows::Storage;
using namespace Windows::Storage::Pickers;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Media::Imaging;
using namespace Windows::Graphics::Imaging;
void CppSaveWriteableBitmapToImage::MainPage::btnSaveImage_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 writeableBitmap = ref new WriteableBitmap(300, 300);
 create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri(&quot;ms-appx:///Assets/Logo.scale-100.png&quot;))).then([this](StorageFile^ file)
 {
  if (file)
  {
   create_task(file-&gt;OpenAsync(FileAccessMode::Read)).then([this](IRandomAccessStream^ fileStream)
   {
    
    create_task(writeableBitmap-&gt;SetSourceAsync(fileStream)).then([this]()
    {
     FileSavePicker^ picker = ref new FileSavePicker();
     auto imgExtensions = ref new Platform::Collections::Vector&lt;String^&gt;();
     imgExtensions-&gt;Append(&quot;.jpg&quot;);
     picker-&gt;FileTypeChoices-&gt;Insert(&quot;JPG File&quot;, imgExtensions);
     create_task(picker-&gt;PickSaveFileAsync()).then([this](StorageFile^ saveFile)
     {
      if (saveFile==nullptr)
      {
       return;
      }
      create_task(saveFile-&gt;OpenAsync(FileAccessMode::ReadWrite)).then([this](IRandomAccessStream^ stream)
      {
       create_task(BitmapEncoder::CreateAsync(BitmapEncoder::JpegEncoderId, stream)).then([this](BitmapEncoder^ encoder)
       {
        IBuffer^ buffer=writeableBitmap-&gt;PixelBuffer;
        DataReader^ dataReader = DataReader::FromBuffer(buffer);
        Platform::Array&lt;unsigned char,1&gt;^ pixels = ref new Platform::Array&lt;unsigned char,1&gt;(buffer-&gt;Length);
        dataReader-&gt;ReadBytes(pixels);
        encoder-&gt;SetPixelData(BitmapPixelFormat::Bgra8, BitmapAlphaMode::Ignore, writeableBitmap-&gt;PixelWidth, writeableBitmap-&gt;PixelHeight, 96.0, 86.0, pixels);
        create_task(encoder-&gt;FlushAsync());
       });
      });
     });
    });
   });
  }  
 });
}
</pre>
<pre id="codePreview" class="csharp">using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging; 
private async void btnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            // Create An Instance of WriteableBitmap object 
            WriteableBitmap writeableBitmap = new WriteableBitmap(300, 300);
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///Assets/Logo.scale-100.png&quot;));
            using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
            {
                // set the source for WriteableBitmap 
                await writeableBitmap.SetSourceAsync(fileStream);
            }
            // Save the writeableBitmap object to JPG Image file
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add(&quot;JPG File&quot;, new List&lt;string&gt;() { &quot;.jpg&quot; });
            StorageFile savefile = await picker.PickSaveFileAsync();
            if (savefile == null)
                return;
            IRandomAccessStream stream = await savefile.OpenAsync(FileAccessMode.ReadWrite);
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            // Get pixels of the WriteableBitmap object
            Stream pixelStream = writeableBitmap.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
            // Save the image file with jpg extension
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, 96.0, 96.0, pixels);
            await encoder.FlushAsync();
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>StorageFile class </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>WriteableBitmap class </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.imaging.writeablebitmap.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.imaging.writeablebitmap.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>FileSavePicker class </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.pickers.filesavepicker.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.pickers.filesavepicker.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
