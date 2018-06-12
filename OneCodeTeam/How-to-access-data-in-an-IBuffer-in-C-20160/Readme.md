# How to access data in an IBuffer in C++
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Windows 8
## Topics
* Windows 8
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:05:04
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1><span>How to access data in an IBuffer in C&#43;&#43; (CppWindowsStoreAppManipulateIBuffer)
</span></h1>
<h2><span>Introduction </span></h2>
<p class="MsoNormal">​IBuffers are returned in several places (WriteableBitmap::PixelBuffer being the most common request) and it isn't clear how to manipulate them. We have samples of how to do this in .Net Framework with the AsStream extension method, but
 not in C&#43;&#43;. You can create a DataReader from an IBuffer using the static FromBuffer method, and this allows you to read raw data from the IBuffer. However, DataWriter doesn't allow you to write the raw data to IBuffer. This example demonstrates methods to
 extract pixels from a WriteableBitmap by getting its IBufferByteAccess interface, edit its pixels, and then dynamically update it.</p>
<h2><span>Running the Sample </span></h2>
<p class="MsoNormal"><span>Build the sample in Visual Studio 2012, and then run it.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73766/1/image.png" alt="" width="1016" height="571" align="middle">
</span><span>&nbsp;</span></p>
<h2><span>Using the Code </span></h2>
<p class="MsoNormal"><span>We first load an image from picture library</span><span>.</span><span style="color:black"> Then, we decode the image and fetch its pixels. Finally, we create a WriteableBitmap and get the pointer to its pixel bytes. Once we get
 the pointer, we can access the (Read/Write) data directly. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">void CppWindowsStoreAppManipulateIBuffer::MainPage::PickAFileButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; // Cache the flag.
&nbsp;&nbsp;&nbsp; bool previousFlag = m_isImgLoaded;


&nbsp;&nbsp;&nbsp; // Set the flag as false to stop updating the writable bitmap.
&nbsp;&nbsp;&nbsp; m_isImgLoaded = false;


&nbsp;&nbsp;&nbsp; FileOpenPicker^ openPicker = ref new FileOpenPicker();
&nbsp;&nbsp;&nbsp; openPicker-&gt;ViewMode = PickerViewMode::Thumbnail;
&nbsp;&nbsp;&nbsp; openPicker-&gt;SuggestedStartLocation = PickerLocationId::PicturesLibrary;
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.jpg&quot;);
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.jpeg&quot;);
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.png&quot;);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;create_task(openPicker-&gt;PickSingleFileAsync()).then([this, previousFlag](StorageFile^ imgFile)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(imgFile)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; create_task(imgFile-&gt;OpenAsync(Windows::Storage::FileAccessMode::Read)).then([](IRandomAccessStream^ stream){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return BitmapDecoder::CreateAsync(stream);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([](BitmapDecoder^ bmpDecoder){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return bmpDecoder-&gt;GetFrameAsync(0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([this](BitmapFrame^ bmpFrame){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_width = bmpFrame-&gt;PixelWidth;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_height = bmpFrame-&gt;PixelHeight;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_xCenter&nbsp; = m_width/2;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_yCenter = m_height/2;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return bmpFrame-&gt;GetPixelDataAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([this](PixelDataProvider^ pixelProvider){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_srcPixels = pixelProvider-&gt;DetachPixelData();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_writeableBitmap = ref new WriteableBitmap(m_width,m_height);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; convertedImg-&gt;Source = m_writeableBitmap;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get access to the pixels
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IBuffer^ buffer = m_writeableBitmap-&gt;PixelBuffer;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Obtain IBufferByteAccess
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ComPtr&lt;IBufferByteAccess&gt; pBufferByteAccess;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ComPtr&lt;IUnknown&gt; pBuffer((IUnknown*)buffer);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pBuffer.As(&amp;pBufferByteAccess);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get pointer to pixel bytes
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pBufferByteAccess-&gt;Buffer(&amp;m_pDstPixels);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Set the flag as true.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_isImgLoaded = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // If user does not select a picture, let's restore the flag.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_isImgLoaded = previousFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; });
}

</pre>
<pre id="codePreview" class="cplusplus">void CppWindowsStoreAppManipulateIBuffer::MainPage::PickAFileButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; // Cache the flag.
&nbsp;&nbsp;&nbsp; bool previousFlag = m_isImgLoaded;


&nbsp;&nbsp;&nbsp; // Set the flag as false to stop updating the writable bitmap.
&nbsp;&nbsp;&nbsp; m_isImgLoaded = false;


&nbsp;&nbsp;&nbsp; FileOpenPicker^ openPicker = ref new FileOpenPicker();
&nbsp;&nbsp;&nbsp; openPicker-&gt;ViewMode = PickerViewMode::Thumbnail;
&nbsp;&nbsp;&nbsp; openPicker-&gt;SuggestedStartLocation = PickerLocationId::PicturesLibrary;
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.jpg&quot;);
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.jpeg&quot;);
&nbsp;&nbsp;&nbsp; openPicker-&gt;FileTypeFilter-&gt;Append(&quot;.png&quot;);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;create_task(openPicker-&gt;PickSingleFileAsync()).then([this, previousFlag](StorageFile^ imgFile)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(imgFile)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; create_task(imgFile-&gt;OpenAsync(Windows::Storage::FileAccessMode::Read)).then([](IRandomAccessStream^ stream){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return BitmapDecoder::CreateAsync(stream);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([](BitmapDecoder^ bmpDecoder){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return bmpDecoder-&gt;GetFrameAsync(0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([this](BitmapFrame^ bmpFrame){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_width = bmpFrame-&gt;PixelWidth;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_height = bmpFrame-&gt;PixelHeight;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_xCenter&nbsp; = m_width/2;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_yCenter = m_height/2;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return bmpFrame-&gt;GetPixelDataAsync();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).then([this](PixelDataProvider^ pixelProvider){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_srcPixels = pixelProvider-&gt;DetachPixelData();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_writeableBitmap = ref new WriteableBitmap(m_width,m_height);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; convertedImg-&gt;Source = m_writeableBitmap;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get access to the pixels
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IBuffer^ buffer = m_writeableBitmap-&gt;PixelBuffer;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Obtain IBufferByteAccess
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ComPtr&lt;IBufferByteAccess&gt; pBufferByteAccess;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ComPtr&lt;IUnknown&gt; pBuffer((IUnknown*)buffer);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pBuffer.As(&amp;pBufferByteAccess);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get pointer to pixel bytes
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pBufferByteAccess-&gt;Buffer(&amp;m_pDstPixels);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Set the flag as true.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_isImgLoaded = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // If user does not select a picture, let's restore the flag.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_isImgLoaded = previousFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; });
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2><span>More Information </span></h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms748838.aspx">How to: Render on a Per Frame Interval Using CompositionTarget</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/br243259.aspx">WritableBitmap Class</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/hh846267(v=vs.85).aspx">IBufferByteAccess interface</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh781229.aspx">How to load file resources (Metro style apps using JavaScript and HTML)</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
