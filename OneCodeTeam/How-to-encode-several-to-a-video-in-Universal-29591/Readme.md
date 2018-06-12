# How to encode several images to a video in Universal apps using Media Foundation
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* DirectX
* Windows
* Windows Phone
* Windows 8
* Audio and video
* Windows Store app Development
* Windows Phone Development
* Windows Desktop App Development
* Windows 8.1
* Microsoft Media Foundation
## Topics
* video
* Image
## IsPublished
* False
## ModifiedDate
* 2014-06-27 02:04:20
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to encode several images to a video in Universal apps using Media Foundation</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample demonstrates how to encode several images to a</span><span style="font-size:11pt">n</span><span style="font-size:11pt"> mp4 video using Media Foundation in a C&#43;&#43;/CX component. This is a Universal
 app which can be built for both Windows 8 and Windows Phone.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Build the sample in Visual Studio 2013 and then run it. Click the &quot;Create new video&quot; button to create a video file which will be processed. Click the &quot;Open images&quot; button to pick several images which
 will be shown below the button in a GridView control. Then click the &quot;Encode&quot; button</span><span style="font-size:11pt"> to create a video file which will be processed and
</span><span style="font-size:11pt">encode the video with the images as frames. The video will play below the GridView in a MediaElement control.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119297/1/image.png" alt="" width="575" height="359" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; text-align:center; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119298/1/image.png" alt="" width="395" height="725" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We implement the basic capabilities in PictureWriter calss in EncodeImage namespace using Media Foundation.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In the code behind MainPage.xaml, we first open images and store the files to List&lt;StorageFile&gt; object.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden">
private async void ImageBtn_Click(object sender, RoutedEventArgs e)
  {
            if (m_images.Count != 0)
            {
                m_images.Clear();
            }
            if (m_files.Count != 0)
            {
                m_files.Clear();
            }
   statusText.Text = &quot;&quot;;
   FileOpenPicker openPicker = new FileOpenPicker();
   openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
   openPicker.ViewMode = PickerViewMode.Thumbnail;
   openPicker.FileTypeFilter.Add(&quot;.jpg&quot;);
            openPicker.FileTypeFilter.Add(&quot;.png&quot;);
            openPicker.FileTypeFilter.Add(&quot;.bmp&quot;);
   IReadOnlyList&lt;StorageFile&gt; files = await openPicker.PickMultipleFilesAsync();
   if (files.Count &gt; 0)
   {                
    foreach(StorageFile file in files)
    {
     m_files.Add(file);
     using( IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
     {
      BitmapImage bitmapImage = new BitmapImage();
      await bitmapImage.SetSourceAsync(stream);
      Image image = new Image();
      image.Source = bitmapImage;
      m_images.Add(image);                        
     }
     
    }
    ImageGV.DataContext = m_images;
   }
  }
</pre>
<pre class="hidden">
void CppUniversalAppImageToVideo::MainPage::ImageBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 statusText-&gt;Text = &quot;&quot;;
 if (m_images-&gt;Size != 0)
 {
  m_images-&gt;Clear();
 }
 if (m_files-&gt;Size != 0)
 {
  m_files-&gt;Clear();
 }
 // Open images.
 FileOpenPicker^ picker = ref new FileOpenPicker;
 picker-&gt;SuggestedStartLocation = PickerLocationId::PicturesLibrary;
 picker-&gt;ViewMode = PickerViewMode::Thumbnail;
 picker-&gt;FileTypeFilter-&gt;Append(&quot;.jpg&quot;);
 picker-&gt;FileTypeFilter-&gt;Append(&quot;.png&quot;);
 picker-&gt;FileTypeFilter-&gt;Append(&quot;.bmp&quot;);
 create_task(picker-&gt;PickMultipleFilesAsync()).then([=](IVectorView&lt;StorageFile^&gt;^ files){
  if (files-&gt;Size == 0)
  {
   cancel_current_task();
  }
  
  auto images = std::make_shared&lt;Platform::Collections::Vector&lt;Windows::UI::Xaml::Controls::Image^&gt;^&gt;(m_images);
  for (StorageFile^ file : files)
  {   
   create_task(file-&gt;OpenAsync(FileAccessMode::Read)).then([=](Streams::IRandomAccessStream^ stream){
    
    auto bitmapImage = ref new BitmapImage();
    bitmapImage-&gt;SetSource(stream);
    Image^ xamlImage = ref new Image;
    xamlImage-&gt;Source = bitmapImage;
    m_images-&gt;Append(xamlImage);
   }).then([=](){
    m_files-&gt;Append(file);
   }, task_continuation_context::use_arbitrary()).then([=](task&lt;void&gt; t){
    try
    {
     t.get();
    }
    catch (InvalidArgumentException^ e)
    {
     statusText-&gt;Text = &quot;Some errors occur when openning, please try again&quot;;
     m_images-&gt;Clear();
     m_files-&gt;Clear();
    }
   });
  }
 });
}
</pre>
<pre class="hidden">
function openImages()
    {
        if (items.length != 0)
        {
            items.splice(0, items.length);
        }
        if (g_imageFiles.length != 0)
        {
            g_imageFiles.splice(0, g_imageFiles.length);
        }
        var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
        openPicker.viewMode = Windows.Storage.Pickers.PickerViewMode.thumbnail;
        openPicker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.picturesLibrary;
        openPicker.fileTypeFilter.append(&quot;.jpg&quot;);
        openPicker.fileTypeFilter.append(&quot;.png&quot;);
        openPicker.fileTypeFilter.append(&quot;.bmp&quot;);
        openPicker.pickMultipleFilesAsync().then(function (files) {
            if(files.size &gt; 0)
            {                
                files.forEach(function (file) {
                    g_imageFiles.push(file);
                    file.openAsync(Windows.Storage.FileAccessMode.read).then(function (stream) {                        
                        items.push({ picture: URL.createObjectURL(stream) });                        
                    });
                });                
            }
        });
    }
</pre>
<pre id="codePreview" class="csharp">
private async void ImageBtn_Click(object sender, RoutedEventArgs e)
  {
            if (m_images.Count != 0)
            {
                m_images.Clear();
            }
            if (m_files.Count != 0)
            {
                m_files.Clear();
            }
   statusText.Text = &quot;&quot;;
   FileOpenPicker openPicker = new FileOpenPicker();
   openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
   openPicker.ViewMode = PickerViewMode.Thumbnail;
   openPicker.FileTypeFilter.Add(&quot;.jpg&quot;);
            openPicker.FileTypeFilter.Add(&quot;.png&quot;);
            openPicker.FileTypeFilter.Add(&quot;.bmp&quot;);
   IReadOnlyList&lt;StorageFile&gt; files = await openPicker.PickMultipleFilesAsync();
   if (files.Count &gt; 0)
   {                
    foreach(StorageFile file in files)
    {
     m_files.Add(file);
     using( IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
     {
      BitmapImage bitmapImage = new BitmapImage();
      await bitmapImage.SetSourceAsync(stream);
      Image image = new Image();
      image.Source = bitmapImage;
      m_images.Add(image);                        
     }
     
    }
    ImageGV.DataContext = m_images;
   }
  }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then we initialize the the PictureWriter object after creating the new video file.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden">
void CppUniversalAppImageToVideo::MainPage::EncodeBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 if (m_files-&gt;Size == 0)
 {
  statusText-&gt;Text = &quot;You must select one image at least.&quot;;
  return;
 }
 // Create the video via file picker.
 statusText-&gt;Text = &quot;&quot;;
 FileSavePicker^ picker = ref new FileSavePicker;
 picker-&gt;SuggestedStartLocation = PickerLocationId::VideosLibrary;
 auto mp4Extensions = ref new Platform::Collections::Vector&lt;Platform::String^&gt;();
 mp4Extensions-&gt;Append(&quot;.mp4&quot;);
 picker-&gt;FileTypeChoices-&gt;Insert(&quot;MP4 file&quot;, mp4Extensions);
 picker-&gt;DefaultFileExtension = &quot;.mp4&quot;;
 picker-&gt;SuggestedFileName = &quot;output&quot;;
 picker-&gt;SuggestedStartLocation = PickerLocationId::VideosLibrary;
 
 create_task( picker-&gt;PickSaveFileAsync())
 .then([=](StorageFile^ file){
  if (nullptr == file)
  {
   cancel_current_task();
  }
  m_videoFile = file;
  return file-&gt;OpenAsync(FileAccessMode::ReadWrite);
 }).then([=](Streams::IRandomAccessStream^ stream){  
  m_picture = ref new PictureWriter(stream, m_videoWidth, m_videoHeight);
 }).then([this](){
  // Add frames to the video.  
  ProcessVideoRing-&gt;IsActive = true;
  statusText-&gt;Text = &quot;Encoding...&quot;;
  static int imageWidth, imageHeight, width, height;
  
  create_task([=](){
   for (StorageFile^ file : m_files)
   {
    // We set 10 FPS default in the PictureWriter, so we add 10 same frames with each image.
    for (int i = 0; i &lt; 10; &#43;&#43;i)
    {
     create_task(file-&gt;Properties-&gt;GetImagePropertiesAsync()).then([&](FileProperties::ImageProperties^ properties){
      imageWidth = properties-&gt;Width;
      imageHeight = properties-&gt;Height;
      return file-&gt;OpenAsync(FileAccessMode::Read);
     }).then([=](Streams::IRandomAccessStream^ stream){
      return BitmapDecoder::CreateAsync(stream);
     }).then([&](BitmapDecoder^ decoder){
      float scaleOfWidth = static_cast&lt;float&gt;(m_videoWidth) / imageWidth;
      float scaleOfHeight = static_cast&lt;float&gt;(m_videoHeight) / imageHeight;
      float scale = scaleOfHeight &gt; scaleOfWidth ?
      scaleOfWidth : scaleOfHeight;
      width = static_cast&lt;int&gt;(imageWidth * scale);
      height = static_cast&lt;int&gt;(imageHeight * scale);
      
      BitmapTransform^ transform = ref new BitmapTransform;
      transform-&gt;ScaledWidth = width;
      transform-&gt;ScaledHeight = height;
      return decoder-&gt;GetPixelDataAsync(BitmapPixelFormat::Bgra8,
       BitmapAlphaMode::Straight,
       transform,
       ExifOrientationMode::RespectExifOrientation,
       ColorManagementMode::ColorManageToSRgb);
     }).then([&](PixelDataProvider^ provider){
      m_picture-&gt;AddFrame(provider-&gt;DetachPixelData(), width, height);
     }).wait();
    }    
   }
  }).then([=](){
   m_picture-&gt;Finalize();
   m_picture = nullptr;   
  }).then([=](){
   return m_videoFile-&gt;OpenAsync(FileAccessMode::Read);
  }).then([=](Streams::IRandomAccessStream^ stream){
   VideoElement-&gt;SetSource(stream, nullptr);
   
   ProcessVideoRing-&gt;IsActive = false;
   statusText-&gt;Text = &quot;The image files are encoded successfully.&quot;;   
  });
 }); 
}
</pre>
<pre class="hidden">
function encode()
    {
        if (g_imageFiles.length == 0)
        {
            displayInfo(&quot;You must select one image at least.&quot;);
            return;
        }
        var savePicker = new Windows.Storage.Pickers.FileSavePicker();
        savePicker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.videosLibrary;
        savePicker.suggestedFileName = &quot;output&quot;;
        savePicker.defaultFileExtension = &quot;.mp4&quot;;
        savePicker.fileTypeChoices.insert(&quot;MP4 file&quot;, [&quot;.mp4&quot;]);
        var promise = savePicker.pickSaveFileAsync().then(function (videoFile) {
            if (videoFile) {
                g_videoFile = videoFile;
                return videoFile.openAsync(Windows.Storage.FileAccessMode.readWrite);
            }
        }).then(function (stream) {
            if (stream)
            {
                g_picture = new EncodeImages.PictureWriter(stream, g_videoWidth, g_videoHeight);
            }            
        });
        var imageWidth, imageHeight;
        var promiseArray = g_imageFiles.map(function (file) {
            promise = promise.then(function () {
                
                return file.properties.getImagePropertiesAsync().then(function (props) {
                    if (g_picture) {
                        imageWidth = props.width;
                        imageHeight = props.height;
                        return file.openAsync(Windows.Storage.FileAccessMode.read);
                    }
                    
                }).then(function (stream) {
                    if (stream)
                    {
                        return Windows.Graphics.Imaging.BitmapDecoder.createAsync(stream);
                    }
                    
                }).then(function (decoder) {
                    if (decoder)
                    {
                        // Transform the image size.
                        var scaleOfWidth = g_videoWidth / imageWidth;
                        var scaleOfHeight = g_videoHeight / imageHeight;
                        var scale = scaleOfWidth &gt; scaleOfHeight ? scaleOfHeight : scaleOfWidth;
                        imageWidth *= scale;
                        imageHeight *= scale;
                        var transform = new Windows.Graphics.Imaging.BitmapTransform();
                        transform.scaledWidth = imageWidth;
                        transform.scaledHeight = imageHeight;
                        return decoder.getPixelDataAsync(
                            Windows.Graphics.Imaging.BitmapPixelFormat.bgra8,
                            Windows.Graphics.Imaging.BitmapAlphaMode.straight,
                            transform,
                            Windows.Graphics.Imaging.ExifOrientationMode.respectExifOrientation,
                            Windows.Graphics.Imaging.ColorManagementMode.colorManageToSRgb);
                    }
                    
                }).then(function (provider) {
                    if (provider)
                    {
                        var data = provider.detachPixelData();
                        for (var i = 0; i &lt; 10; &#43;&#43;i) {
                            g_picture.addFrame(data, imageWidth, imageHeight);
                        }
                    }
                });
            });
            return promise;
            
        });
        WinJS.Promise.join(promiseArray).then(function () {
            if (g_picture)
            {
                g_picture.finalize();
                g_picture = null;
                displayInfo(&quot;The image files are encoded successfully.&quot;);
                var myVideo = document.getElementById(&quot;videoElement&quot;);
                myVideo.src = URL.createObjectURL(g_videoFile);
            }
            
        });        
    }
</pre>
<pre id="codePreview" class="cplusplus">
void CppUniversalAppImageToVideo::MainPage::EncodeBtn_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
 if (m_files-&gt;Size == 0)
 {
  statusText-&gt;Text = &quot;You must select one image at least.&quot;;
  return;
 }
 // Create the video via file picker.
 statusText-&gt;Text = &quot;&quot;;
 FileSavePicker^ picker = ref new FileSavePicker;
 picker-&gt;SuggestedStartLocation = PickerLocationId::VideosLibrary;
 auto mp4Extensions = ref new Platform::Collections::Vector&lt;Platform::String^&gt;();
 mp4Extensions-&gt;Append(&quot;.mp4&quot;);
 picker-&gt;FileTypeChoices-&gt;Insert(&quot;MP4 file&quot;, mp4Extensions);
 picker-&gt;DefaultFileExtension = &quot;.mp4&quot;;
 picker-&gt;SuggestedFileName = &quot;output&quot;;
 picker-&gt;SuggestedStartLocation = PickerLocationId::VideosLibrary;
 
 create_task( picker-&gt;PickSaveFileAsync())
 .then([=](StorageFile^ file){
  if (nullptr == file)
  {
   cancel_current_task();
  }
  m_videoFile = file;
  return file-&gt;OpenAsync(FileAccessMode::ReadWrite);
 }).then([=](Streams::IRandomAccessStream^ stream){  
  m_picture = ref new PictureWriter(stream, m_videoWidth, m_videoHeight);
 }).then([this](){
  // Add frames to the video.  
  ProcessVideoRing-&gt;IsActive = true;
  statusText-&gt;Text = &quot;Encoding...&quot;;
  static int imageWidth, imageHeight, width, height;
  
  create_task([=](){
   for (StorageFile^ file : m_files)
   {
    // We set 10 FPS default in the PictureWriter, so we add 10 same frames with each image.
    for (int i = 0; i &lt; 10; &#43;&#43;i)
    {
     create_task(file-&gt;Properties-&gt;GetImagePropertiesAsync()).then([&](FileProperties::ImageProperties^ properties){
      imageWidth = properties-&gt;Width;
      imageHeight = properties-&gt;Height;
      return file-&gt;OpenAsync(FileAccessMode::Read);
     }).then([=](Streams::IRandomAccessStream^ stream){
      return BitmapDecoder::CreateAsync(stream);
     }).then([&](BitmapDecoder^ decoder){
      float scaleOfWidth = static_cast&lt;float&gt;(m_videoWidth) / imageWidth;
      float scaleOfHeight = static_cast&lt;float&gt;(m_videoHeight) / imageHeight;
      float scale = scaleOfHeight &gt; scaleOfWidth ?
      scaleOfWidth : scaleOfHeight;
      width = static_cast&lt;int&gt;(imageWidth * scale);
      height = static_cast&lt;int&gt;(imageHeight * scale);
      
      BitmapTransform^ transform = ref new BitmapTransform;
      transform-&gt;ScaledWidth = width;
      transform-&gt;ScaledHeight = height;
      return decoder-&gt;GetPixelDataAsync(BitmapPixelFormat::Bgra8,
       BitmapAlphaMode::Straight,
       transform,
       ExifOrientationMode::RespectExifOrientation,
       ColorManagementMode::ColorManageToSRgb);
     }).then([&](PixelDataProvider^ provider){
      m_picture-&gt;AddFrame(provider-&gt;DetachPixelData(), width, height);
     }).wait();
    }    
   }
  }).then([=](){
   m_picture-&gt;Finalize();
   m_picture = nullptr;   
  }).then([=](){
   return m_videoFile-&gt;OpenAsync(FileAccessMode::Read);
  }).then([=](Streams::IRandomAccessStream^ stream){
   VideoElement-&gt;SetSource(stream, nullptr);
   
   ProcessVideoRing-&gt;IsActive = false;
   statusText-&gt;Text = &quot;The image files are encoded successfully.&quot;;   
  });
 }); 
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://blogs.msdn.com/b/eternalcoding/archive/2013/03/06/developing-a-winrt-component-to-create-a-video-file-using-media-foundation.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Developing
 a WinRT component to create a video file using Media Foundation</span></a><a name="_GoBack"></a></span>
</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
