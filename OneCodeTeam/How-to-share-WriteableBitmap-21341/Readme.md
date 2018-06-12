# How to share WriteableBitmap
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows 8
## Topics
* windows8
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:04:32
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1>How to <span>share WriteableBitmap image</span> (<span>VB</span>WindowsStoreApp<span>ShareWriteableBitmap</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to <span>share WriteableBitmap image.
</span></p>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span>the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/78745/1/image.png" alt="" width="866" height="493" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Click 'Load Image' button to load an image from your local disk.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>After image loaded, click 'Share' button to share the WriteableBitmap image to your desired app.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/78746/1/image.png" alt="" width="866" height="489" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to <span>load image to UI. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Use FileOpenPicker to pick an image and display it in UI
&nbsp;&nbsp; Private Async Sub LoadButton_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Me.EnsureUnsnapped() Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim openPicker As New FileOpenPicker()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.ViewMode = PickerViewMode.Thumbnail
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.jpg&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.jpeg&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.png&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; file = Await openPicker.PickSingleFileAsync()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using stream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image = New WriteableBitmap(1, 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.SetSource(stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WriteableBitmapImage.Source = image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ShareButton.IsEnabled = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Friend Function EnsureUnsnapped() As Boolean
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' FilePicker APIs will not work if the application is in a snapped state.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim unsnapped As Boolean = ((ApplicationView.Value &lt;&gt; ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not unsnapped Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(&quot;Cannot unsnap the sample.&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return unsnapped
&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">' Use FileOpenPicker to pick an image and display it in UI
&nbsp;&nbsp; Private Async Sub LoadButton_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Me.EnsureUnsnapped() Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim openPicker As New FileOpenPicker()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.ViewMode = PickerViewMode.Thumbnail
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.jpg&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.jpeg&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; openPicker.FileTypeFilter.Add(&quot;.png&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; file = Await openPicker.PickSingleFileAsync()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using stream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image = New WriteableBitmap(1, 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; image.SetSource(stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WriteableBitmapImage.Source = image
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ShareButton.IsEnabled = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Friend Function EnsureUnsnapped() As Boolean
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' FilePicker APIs will not work if the application is in a snapped state.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim unsnapped As Boolean = ((ApplicationView.Value &lt;&gt; ApplicationViewState.Snapped) OrElse ApplicationView.TryUnsnap())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not unsnapped Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NotifyUser(&quot;Cannot unsnap the sample.&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return unsnapped
&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><a name="OLE_LINK1"></a><a name="OLE_LINK2"><span>The code below shows how to
</span></a><span><span><span>register event of share contract </span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.dataTransferManager = dataTransferManager.GetForCurrentView()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;RemoveHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.dataTransferManager = dataTransferManager.GetForCurrentView()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;RemoveHandler Me.dataTransferManager.DataRequested, AddressOf Me.OnDataRequested
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal"><span>The code below shows how to share the WriteableBitmap image
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Async Sub OnDataRequested(sender As DataTransferManager, e As DataRequestedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim deferral As DataRequestDeferral = e.Request.GetDeferral()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim requestData As DataPackage = e.Request.Data
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.Properties.Title = &quot;Share WriteableBitmap Image Sample&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.Properties.Description = &quot;This sample demonstrates how to share WriteableBitmap image in Windows Store app.&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' This stream is to create a bitmap image later
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stream As IRandomAccessStream = New InMemoryRandomAccessStream()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Determin which type of BitmapEncoder we should create
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim encoderId As Guid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If file IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case file.FileType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.PngEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case &quot;.bmp&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.BmpEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.JpegEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim encoder As BitmapEncoder = Await BitmapEncoder.CreateAsync(encoderId, stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pixelStream As Stream = image.PixelBuffer.AsStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pixels As Byte() = New Byte(pixelStream.Length - 1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await pixelStream.ReadAsync(pixels, 0, pixels.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, CUInt(image.PixelWidth), CUInt(image.PixelHeight), 96.0, 96.0, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pixels)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.SetBitmap(RandomAccessStreamReference.CreateFromStream(stream))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await encoder.FlushAsync()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deferral.Complete()
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">Private Async Sub OnDataRequested(sender As DataTransferManager, e As DataRequestedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim deferral As DataRequestDeferral = e.Request.GetDeferral()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim requestData As DataPackage = e.Request.Data
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.Properties.Title = &quot;Share WriteableBitmap Image Sample&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.Properties.Description = &quot;This sample demonstrates how to share WriteableBitmap image in Windows Store app.&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' This stream is to create a bitmap image later
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stream As IRandomAccessStream = New InMemoryRandomAccessStream()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Determin which type of BitmapEncoder we should create
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim encoderId As Guid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If file IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case file.FileType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;.png&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.PngEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case &quot;.bmp&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.BmpEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoderId = BitmapEncoder.JpegEncoderId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim encoder As BitmapEncoder = Await BitmapEncoder.CreateAsync(encoderId, stream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pixelStream As Stream = image.PixelBuffer.AsStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pixels As Byte() = New Byte(pixelStream.Length - 1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await pixelStream.ReadAsync(pixels, 0, pixels.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, CUInt(image.PixelWidth), CUInt(image.PixelHeight), 96.0, 96.0, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pixels)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; requestData.SetBitmap(RandomAccessStreamReference.CreateFromStream(stream))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await encoder.FlushAsync()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deferral.Complete()
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span>WriteableBitmap class (Windows) </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/BR243259">http://msdn.microsoft.com/en-us/library/windows/apps/BR243259</a>
</span></p>
<p class="MsoNormal"><span>Quickstart: Sharing content (Windows Store apps using C#/VB/C&#43;&#43; and XAML) (Windows)
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Hh871368(v=win.10).aspx">http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Hh871368(v=win.10).aspx</a>
</span></p>
<p class="MsoNormal"><span>How to make asynchronous calls in your DataRequested handler (Windows Store apps using C#/VB/C&#43;&#43; and XAML) (Windows)
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh871365.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh871365.aspx</a>
</span></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
