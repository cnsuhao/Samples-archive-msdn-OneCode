# Multi-Touch Drawing
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone 8
* Windows Phone Development
## Topics
* Muliti-Touch drawing
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:21:34
## Description

<h1>Draw pictures with Canvas Control on a multi-touch screen (VBWP8MultiTouchDrawing)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to draw pictures with Canvas Control on a multi-touch screen. If you simply implement the following event:
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Touch.FrameReported &#43;= new TouchFrameEventHandler(Touch_FrameReported);</p>
<p class="MsoNormal">You can implement multi-touch draw, representing each event using only dots, but the resulting drawing is not visually appealing. InkPresenter can draw lines smoothly, but it demonstrates the action of one touch only. This sample demonstrates
 how to draw smooth lines using up to four fingers simultaneously.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Prerequisite: <b style="">Visual Studio 2012</b> with <b style="">
Windows Phone SDK 8.0</b>.</p>
<p class="MsoNormal">You can download Visual Studio 2012 from here:<br>
<a href="http://www.microsoft.com/visualstudio/eng/downloads">http://www.microsoft.com/visualstudio/eng/downloads</a><br>
You can download Windows Phone SDK 8.0 from here:<br>
<a href="https://dev.windowsphone.com/en-us/downloadsdk">https://dev.windowsphone.com/en-us/downloadsdk</a><br>
You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open &quot;VBWP8MultiTouchDrawing&quot;in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91654/1/image.png" alt="" width="287" height="463" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The emulated mouse can only simulate one point touch drawing. If you wish to test multi-touch drawing, please deploy the sample application to a real windows phone.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new &quot;Windows Phone&quot; project in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add Reference to <b style="">Microsoft.Xna.Framework</b> DLL. This DLL is needed when we want to save an image to the Media Library.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The Grid named &quot;<b style="">LayoutRoot</b>&quot; in the
<b style="">MainPage.xaml</b> file will resemble the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid Margin=&quot;0,1,0,0&quot; Background=&quot;White&quot; Height=&quot;780&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Canvas x:Name=&quot;drawCanvas&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Background=&quot;White&quot; Margin=&quot;0,0,0,60&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Canvas&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Margin=&quot;0,700,240,0&quot; Background=&quot;DarkRed&quot; Content=&quot;Save&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x:Name=&quot;Save&quot; Click=&quot;Save_Click&quot;&gt;&lt;/Button&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Margin=&quot;240,700,0,0&quot; Background=&quot;DarkRed&quot; Content=&quot;New&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:Name=&quot;New&quot; Click=&quot;New_Click&quot;&gt;&lt;/Button&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;Grid Margin=&quot;0,1,0,0&quot; Background=&quot;White&quot; Height=&quot;780&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Canvas x:Name=&quot;drawCanvas&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Background=&quot;White&quot; Margin=&quot;0,0,0,60&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Canvas&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Margin=&quot;0,700,240,0&quot; Background=&quot;DarkRed&quot; Content=&quot;Save&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x:Name=&quot;Save&quot; Click=&quot;Save_Click&quot;&gt;&lt;/Button&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Button Margin=&quot;240,700,0,0&quot; Background=&quot;DarkRed&quot; Content=&quot;New&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:Name=&quot;New&quot; Click=&quot;New_Click&quot;&gt;&lt;/Button&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>And implement event handlers. Touch.FrameReported is the most important event in this sample, every screen touch will raise this event. In this sample, all drawing tasks are done with this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Partial Public Class MainPage
&nbsp;&nbsp;&nbsp; Inherits PhoneApplicationPage
&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp; Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ' preXArray and preYArray are used to store the start point 
&nbsp;&nbsp;&nbsp;&nbsp;' for each touch point. currently silverlight support 4 muliti-touch
&nbsp;&nbsp;&nbsp; ' here declare as 10 points for further needs. 
&nbsp;&nbsp;&nbsp;&nbsp;Private preXArray As Double() = New Double(9) {}
&nbsp;&nbsp;&nbsp; Private preYArray As Double() = New Double(9) {}


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Every touch action will rise this event handler. 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pointsNumber As Integer = e.GetTouchPoints(drawCanvas).Count
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pointCollection As TouchPointCollection = e.GetTouchPoints(drawCanvas)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 0 To pointsNumber - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If pointCollection(i).Action = TouchAction.Down Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preXArray(i) = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preYArray(i) = pointCollection(i).Position.Y
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If pointCollection(i).Action = TouchAction.Move Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim line As New Line()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.X1 = preXArray(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Y1 = preYArray(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.X2 = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Y2 = pointCollection(i).Position.Y


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Stroke = New SolidColorBrush(Colors.Black)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Fill = New SolidColorBrush(Colors.Black)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; drawCanvas.Children.Add(line)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preXArray(i) = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preYArray(i) = pointCollection(i).Position.Y
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp; &nbsp;&nbsp;''' Save image to Media Library so that we can view pictures we created
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim library As New MediaLibrary()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bitMap As New WriteableBitmap(drawCanvas, Nothing)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ms As New MemoryStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ms.Seek(0, SeekOrigin.Begin)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; library.SavePicture(String.Format(&quot;Images\{0}.jpg&quot;, Guid.NewGuid()), ms)
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Private Sub New_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; drawCanvas.Children.Clear()
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Partial Public Class MainPage
&nbsp;&nbsp;&nbsp; Inherits PhoneApplicationPage
&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp; Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ' preXArray and preYArray are used to store the start point 
&nbsp;&nbsp;&nbsp;&nbsp;' for each touch point. currently silverlight support 4 muliti-touch
&nbsp;&nbsp;&nbsp; ' here declare as 10 points for further needs. 
&nbsp;&nbsp;&nbsp;&nbsp;Private preXArray As Double() = New Double(9) {}
&nbsp;&nbsp;&nbsp; Private preYArray As Double() = New Double(9) {}


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Every touch action will rise this event handler. 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pointsNumber As Integer = e.GetTouchPoints(drawCanvas).Count
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim pointCollection As TouchPointCollection = e.GetTouchPoints(drawCanvas)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 0 To pointsNumber - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If pointCollection(i).Action = TouchAction.Down Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preXArray(i) = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preYArray(i) = pointCollection(i).Position.Y
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If pointCollection(i).Action = TouchAction.Move Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim line As New Line()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.X1 = preXArray(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Y1 = preYArray(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.X2 = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Y2 = pointCollection(i).Position.Y


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Stroke = New SolidColorBrush(Colors.Black)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; line.Fill = New SolidColorBrush(Colors.Black)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; drawCanvas.Children.Add(line)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preXArray(i) = pointCollection(i).Position.X
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; preYArray(i) = pointCollection(i).Position.Y
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp; &nbsp;&nbsp;''' Save image to Media Library so that we can view pictures we created
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim library As New MediaLibrary()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim bitMap As New WriteableBitmap(drawCanvas, Nothing)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ms As New MemoryStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ms.Seek(0, SeekOrigin.Begin)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; library.SavePicture(String.Format(&quot;Images\{0}.jpg&quot;, Guid.NewGuid()), ms)
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Private Sub New_Click(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; drawCanvas.Children.Clear()
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">To learn more about Touch.FrameReported event please check this link:
<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
