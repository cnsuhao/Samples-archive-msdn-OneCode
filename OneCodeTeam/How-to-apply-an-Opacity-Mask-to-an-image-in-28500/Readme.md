# How to apply an "Opacity Mask" to an image in Universal apps using Direct2D
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Direct2D
* DirectX
* Windows
* Windows 8
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
* Graphics and Gaming
## Topics
* universal app
* Opacity Mask
## IsPublished
* True
## ModifiedDate
* 2014-10-09 07:58:49
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span>How to apply</span><span> an</span><span>
</span><span>&ldquo;O</span><span>pacity </span><span>M</span><span>ask</span><span>&rdquo;</span><a name="_GoBack"></a><span> to an image in Universal apps</span><span> using Direct2D</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We use Direct2D to implement this image effect which we often use in Photoshop. This sample is based on James Dailey&rsquo;s code sample. See
</span><span style="font-weight:bold">More Information</span><span style="font-size:11pt"> below.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">&nbsp;</span></span><span style="font-size:11pt; line-height:27.6pt">Build the sample in Visual Studio 2013, and then run it.</span><span style="font-size:11pt; line-height:27.6pt">
 Click the &ldquo;Open the Image&rdquo; button to open the image which will be processed. Then select the mask image from &ldquo;Select mask image here&rdquo; Combobox. We offer you 3 mask images for testing. When finishing these operations, we can click &ldquo;Draw
 Opacity Mask&rdquo; to apply the mask to the image. The running application is shown below.</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114117/1/image.png" alt="" width="575" height="354" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">We add the D2DImageSourceWithOpacityMask project to our Xaml project solution and add reference to the Xaml project.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">In our Xaml code behind, we call the methods from D2DImageSourceWithOpacityMask namespace in which we implement the opacity mask effect applied for image. We should first set the image source
 and mask image source:</span><span> </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">m_d2dImageSource.SetSource(stream);
m_d2dImageSource.SetMask(stream1);
</pre>
<pre class="hidden">m_d2dImageSource-&gt;SetSource(randomAccessStream);
m_d2dImageSource-&gt;SetMask(randomAccessStream);
</pre>
<div class="preview">
<pre class="csharp">m_d2dImageSource.SetSource(stream);&nbsp;
m_d2dImageSource.SetMask(stream1);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Here we get the original image
</span><span style="color:#000000">randomAccessStream from the file picker.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">private async void OpenImageBtn_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(&quot;.jpg&quot;);
            openPicker.FileTypeFilter.Add(&quot;.png&quot;);
            openPicker.FileTypeFilter.Add(&quot;.jpeg&quot;);
            StorageFile file = await openPicker.PickSingleFileAsync();
            if(file != null)
            {                
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                m_d2dImageSource.SetSource(stream);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);
                OrignalImage.Source = bitmapImage;
                ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();
                OriImageSize.Text = &quot;Image size: &quot; &#43; imageProperties.Width &#43; &quot; * &quot; &#43; imageProperties.Height;
                _btnRender.IsEnabled = true;
            }
        }
</pre>
<pre class="hidden">void CppWindowsStoreAppOpacityMask::MainPage::OpenImageBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 Pickers::FileOpenPicker^ openPicker = ref new Pickers::FileOpenPicker();
 openPicker-&gt;SuggestedStartLocation = Pickers::PickerLocationId::PicturesLibrary;
 openPicker-&gt;ViewMode = PickerViewMode::Thumbnail;
 openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.jpg&quot;);
 openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.bmp&quot;);
 openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.png&quot;);
 create_task(openPicker-&gt;PickSingleFileAsync()).then([=](StorageFile^ file)
 {
  if (file == nullptr)
  {
   cancel_current_task();
  }
  //ImageProperties^ imagePropertise = file-&gt;Properties-&gt;GetImagePropertiesAsync();
  return file-&gt;OpenAsync(FileAccessMode::Read);
 }).then([=](Streams::IRandomAccessStream^ randomAccessStream)
 {
  m_d2dImageSource-&gt;SetSource(randomAccessStream);
  auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
  bitmapImage-&gt;SetSourceAsync(randomAccessStream);
  OrignalImage-&gt;Source = bitmapImage;
  _btnRender-&gt;IsEnabled = true;
 });
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;OpenImageBtn_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileOpenPicker&nbsp;openPicker&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileOpenPicker();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openPicker.ViewMode&nbsp;=&nbsp;PickerViewMode.Thumbnail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openPicker.SuggestedStartLocation&nbsp;=&nbsp;PickerLocationId.PicturesLibrary;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openPicker.FileTypeFilter.Add(<span class="cs__string">&quot;.jpg&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openPicker.FileTypeFilter.Add(<span class="cs__string">&quot;.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openPicker.FileTypeFilter.Add(<span class="cs__string">&quot;.jpeg&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;file&nbsp;=&nbsp;await&nbsp;openPicker.PickSingleFileAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(file&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stream&nbsp;=&nbsp;await&nbsp;file.OpenAsync(Windows.Storage.FileAccessMode.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.SetSource(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bitmapImage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Windows.UI.Xaml.Media.Imaging.BitmapImage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;bitmapImage.SetSourceAsync(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrignalImage.Source&nbsp;=&nbsp;bitmapImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageProperties&nbsp;imageProperties&nbsp;=&nbsp;await&nbsp;file.Properties.GetImagePropertiesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OriImageSize.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Image&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties.Width&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;*&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_btnRender.IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">We get the mask image
</span><span style="color:#000000">randomAccessStream from uri.</span><span> </span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">private async void MaskComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StorageFile file;
            var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            switch(MaskComboBox.SelectedIndex)
            {
                case 0:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///Assets/BitmapMask.png&quot;));
                    var stream1 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream1);
                    await bitmapImage.SetSourceAsync(stream1);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties1 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = &quot;Image size: &quot; &#43; imageProperties1.Width &#43; &quot; * &quot; &#43; imageProperties1.Height;
                    break;
                case 1:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///Assets/Mask1.png&quot;));
                    var stream2 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream2);
                    await bitmapImage.SetSourceAsync(stream2);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties2 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = &quot;Image size: &quot; &#43; imageProperties2.Width &#43; &quot; * &quot; &#43; imageProperties2.Height;
                    break;
                case 2:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(&quot;ms-appx:///Assets/Mask2.png&quot;));
                    var stream3 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream3);
                    await bitmapImage.SetSourceAsync(stream3);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties3 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = &quot;Image size: &quot; &#43; imageProperties3.Width &#43; &quot; * &quot; &#43; imageProperties3.Height;
                    break;
            }
        }
</pre>
<pre class="hidden">void CppWindowsStoreAppOpacityMask::MainPage::MaskComboBox_SelectionChanged(Platform::Object^ sender, Windows::UI::Xaml::Controls::SelectionChangedEventArgs^ e)
{
 
 auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage;
 
 switch (MaskComboBox-&gt;SelectedIndex)
 {
 case 0:
  create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri(&quot;ms-appx:///Assets/BitmapMask.png&quot;))
   ).then([=](StorageFile^ file)
  {
   if (file == nullptr)
   {
    cancel_current_task();
   }
   return file-&gt;OpenAsync(FileAccessMode::Read);
  }).then([=](Streams::IRandomAccessStream^ randomAccessStream)
  {
   m_d2dImageSource-&gt;SetMask(randomAccessStream);
   auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
   bitmapImage-&gt;SetSourceAsync(randomAccessStream);
   MaskImage-&gt;Source = bitmapImage;
  });  
  break; 
 case 1:
  create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri(&quot;ms-appx:///Assets/Mask1.png&quot;))
   ).then([=](StorageFile^ file)
  {
   if (file == nullptr)
   {
    cancel_current_task();
   }
   return file-&gt;OpenAsync(FileAccessMode::Read);
  }).then([=](Streams::IRandomAccessStream^ randomAccessStream)
  {
   m_d2dImageSource-&gt;SetMask(randomAccessStream);
   auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
   bitmapImage-&gt;SetSourceAsync(randomAccessStream);
   MaskImage-&gt;Source = bitmapImage;
  });
  break;
 case 2:
  create_task(StorageFile::GetFileFromApplicationUriAsync(ref new Uri(&quot;ms-appx:///Assets/Mask2.png&quot;))
   ).then([=](StorageFile^ file)
  {
   if (file == nullptr)
   {
    cancel_current_task();
   }
   return file-&gt;OpenAsync(FileAccessMode::Read);
  }).then([=](Streams::IRandomAccessStream^ randomAccessStream)
  {
   m_d2dImageSource-&gt;SetMask(randomAccessStream);
   auto bitmapImage = ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
   bitmapImage-&gt;SetSourceAsync(randomAccessStream);
   MaskImage-&gt;Source = bitmapImage;
  });
  break;
 }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;MaskComboBox_SelectionChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SelectionChangedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;file;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bitmapImage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Windows.UI.Xaml.Media.Imaging.BitmapImage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>(MaskComboBox.SelectedIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">0</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file&nbsp;=&nbsp;await&nbsp;StorageFile.GetFileFromApplicationUriAsync(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx:///Assets/BitmapMask.png&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stream1&nbsp;=&nbsp;await&nbsp;file.OpenAsync(Windows.Storage.FileAccessMode.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.SetMask(stream1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;bitmapImage.SetSourceAsync(stream1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImage.Source&nbsp;=&nbsp;bitmapImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageProperties&nbsp;imageProperties1&nbsp;=&nbsp;await&nbsp;file.Properties.GetImagePropertiesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImageSize.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Image&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties1.Width&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;*&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties1.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">1</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file&nbsp;=&nbsp;await&nbsp;StorageFile.GetFileFromApplicationUriAsync(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx:///Assets/Mask1.png&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stream2&nbsp;=&nbsp;await&nbsp;file.OpenAsync(Windows.Storage.FileAccessMode.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.SetMask(stream2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;bitmapImage.SetSourceAsync(stream2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImage.Source&nbsp;=&nbsp;bitmapImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageProperties&nbsp;imageProperties2&nbsp;=&nbsp;await&nbsp;file.Properties.GetImagePropertiesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImageSize.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Image&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties2.Width&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;*&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties2.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__number">2</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file&nbsp;=&nbsp;await&nbsp;StorageFile.GetFileFromApplicationUriAsync(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx:///Assets/Mask2.png&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stream3&nbsp;=&nbsp;await&nbsp;file.OpenAsync(Windows.Storage.FileAccessMode.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.SetMask(stream3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;bitmapImage.SetSourceAsync(stream3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImage.Source&nbsp;=&nbsp;bitmapImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageProperties&nbsp;imageProperties3&nbsp;=&nbsp;await&nbsp;file.Properties.GetImagePropertiesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskImageSize.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Image&nbsp;size:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties3.Width&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;*&nbsp;&quot;</span>&nbsp;&#43;&nbsp;imageProperties3.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">We should then draw the image with the &ldquo;Draw Opacity Mask&rdquo; button being clicked.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span>
<pre class="hidden">private void _btnRender_Click(object sender, RoutedEventArgs e)
        {
            // Begin updating the SurfaceImageSource
            m_d2dImageSource.BeginDraw();
            // Clear background
            m_d2dImageSource.Clear(Colors.Transparent);
            // Render the source and apply the mask
            m_d2dImageSource.RenderBitmap();
            // Stop updating the SurfaceImageSource and draw its contents
            m_d2dImageSource.EndDraw();
        }
</pre>
<pre class="hidden">void CppWindowsStoreAppOpacityMask::MainPage::_btnRender_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 // Begin updating the SurfaceImageSource
 m_d2dImageSource-&gt;BeginDraw();
 // Clear background
 m_d2dImageSource-&gt;Clear(Windows::UI::Colors::Transparent);
 // Render the source and apply the mask
 m_d2dImageSource-&gt;RenderBitmap();
 // Stop updating the SurfaceImageSource and draw its contents
 m_d2dImageSource-&gt;EndDraw();
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;_btnRender_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Begin&nbsp;updating&nbsp;the&nbsp;SurfaceImageSource</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.BeginDraw();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Clear&nbsp;background</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.Clear(Colors.Transparent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Render&nbsp;the&nbsp;source&nbsp;and&nbsp;apply&nbsp;the&nbsp;mask</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.RenderBitmap();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Stop&nbsp;updating&nbsp;the&nbsp;SurfaceImageSource&nbsp;and&nbsp;draw&nbsp;its&nbsp;contents</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_d2dImageSource.EndDraw();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">In the D2DImageSourceWithOpacityMask namespace, we use WIC api to build Direct2D image from</span><span style="font-size:11pt">
</span><span>the</span><span style="font-size:11pt"> </span><span style="color:#000000">IRandomAccessStream object.</span><span>
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void D2DImageSource::SetMask(Windows::Storage::Streams::IRandomAccessStream^ randomAccessStream)
{
    ComPtr&lt;IWICBitmapDecoder&gt; wicBitmapDecoder;
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&amp;stream))
        );
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
        stream.Get(),
        nullptr,
        WICDecodeMetadataCacheOnDemand,
        &amp;wicBitmapDecoder
        )
        );
    ComPtr&lt;IWICBitmapFrameDecode&gt; wicBitmapFrame;
    DX::ThrowIfFailed(
        wicBitmapDecoder-&gt;GetFrame(0, &amp;wicBitmapFrame)
        );
    ComPtr&lt;IWICFormatConverter&gt; wicFormatConverter;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;wicFormatConverter)
        );
    DX::ThrowIfFailed(
        wicFormatConverter-&gt;Initialize(
        wicBitmapFrame.Get(),
        GUID_WICPixelFormat32bppPBGRA,
        WICBitmapDitherTypeNone,
        nullptr,
        0.0,
        WICBitmapPaletteTypeCustom  // the BGRA format has no palette so this value is ignored
        )
        );
    double dpiX = 96.0f;
    double dpiY = 96.0f;
    DX::ThrowIfFailed(
        wicFormatConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY)
        );
    DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateBitmapFromWicBitmap(
        wicFormatConverter.Get(),
        nullptr,
        &amp;m_Mask  //D2Dbitmap
        )
    );
}
</pre>
<pre id="codePreview" class="cplusplus">void D2DImageSource::SetMask(Windows::Storage::Streams::IRandomAccessStream^ randomAccessStream)
{
    ComPtr&lt;IWICBitmapDecoder&gt; wicBitmapDecoder;
    ComPtr&lt;IStream&gt; stream;
    DX::ThrowIfFailed(
        CreateStreamOverRandomAccessStream(randomAccessStream, IID_PPV_ARGS(&amp;stream))
        );
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateDecoderFromStream(
        stream.Get(),
        nullptr,
        WICDecodeMetadataCacheOnDemand,
        &amp;wicBitmapDecoder
        )
        );
    ComPtr&lt;IWICBitmapFrameDecode&gt; wicBitmapFrame;
    DX::ThrowIfFailed(
        wicBitmapDecoder-&gt;GetFrame(0, &amp;wicBitmapFrame)
        );
    ComPtr&lt;IWICFormatConverter&gt; wicFormatConverter;
    DX::ThrowIfFailed(
        m_wicFactory-&gt;CreateFormatConverter(&amp;wicFormatConverter)
        );
    DX::ThrowIfFailed(
        wicFormatConverter-&gt;Initialize(
        wicBitmapFrame.Get(),
        GUID_WICPixelFormat32bppPBGRA,
        WICBitmapDitherTypeNone,
        nullptr,
        0.0,
        WICBitmapPaletteTypeCustom  // the BGRA format has no palette so this value is ignored
        )
        );
    double dpiX = 96.0f;
    double dpiY = 96.0f;
    DX::ThrowIfFailed(
        wicFormatConverter-&gt;GetResolution(&amp;dpiX, &amp;dpiY)
        );
    DX::ThrowIfFailed(
        m_d2dContext-&gt;CreateBitmapFromWicBitmap(
        wicFormatConverter.Get(),
        nullptr,
        &amp;m_Mask  //D2Dbitmap
        )
    );
}</pre>
</div>
</div>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">We run the same steps for the image which will be processed. Then we get the two ID2D1Bitmap1 objects : m_Bitmap and m_Mask.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="font-size:11pt">Finally, we use
</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/jj841158(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">ID2D1DeviceContext::FillOpacityMask</span></a><span style="font-size:11pt"> method
 to apply the mask to image.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void D2DImageSource::RenderBitmap()
{
    if (m_Mask)
    {
        Microsoft::WRL::ComPtr&lt;ID2D1BitmapBrush&gt; bmpBrsh;
        m_d2dContext-&gt;CreateBitmapBrush(m_Bitmap.Get(), &amp;bmpBrsh);
        m_d2dContext-&gt;FillOpacityMask(m_Mask.Get(), bmpBrsh.Get());
    }
    else
    {
        m_d2dContext-&gt;DrawBitmap(m_Bitmap.Get());
    }
}
</pre>
<pre id="codePreview" class="cplusplus">void D2DImageSource::RenderBitmap()
{
    if (m_Mask)
    {
        Microsoft::WRL::ComPtr&lt;ID2D1BitmapBrush&gt; bmpBrsh;
        m_d2dContext-&gt;CreateBitmapBrush(m_Bitmap.Get(), &amp;bmpBrsh);
        m_d2dContext-&gt;FillOpacityMask(m_Mask.Get(), bmpBrsh.Get());
    }
    else
    {
        m_d2dContext-&gt;DrawBitmap(m_Bitmap.Get());
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-21pt">
<span style="font-size:11pt"><span style="font-style:normal; text-decoration:none; font-weight:normal">&bull;&nbsp;</span><a href="http://blogs.msdn.com/b/wsdevsol/archive/2014/03/20/how-to-apply-an-opacity-mask-to-an-image-by-mixing-xaml-and-direct2d.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">How
 to apply an &ldquo;Opacity Mask&rdquo; to an image by mixing XAML and Direct2D</span></a></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-21pt">
<span style="font-size:11pt"><span style="font-style:normal; text-decoration:none; font-weight:normal">&bull;&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee329947(v=vs.85).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Direct2D
 Opacity Mask</span></a></span></p>
<p style="margin-left:21pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-21pt">
<span style="font-size:11pt"><span style="color:#0563c1; text-decoration:underline"><br>
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
