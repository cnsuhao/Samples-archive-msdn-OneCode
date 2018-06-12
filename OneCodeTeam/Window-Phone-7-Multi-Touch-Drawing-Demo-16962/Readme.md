# Window Phone 7 Multi-Touch Drawing Demo (VBWP7MultiTouchDrawing)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Phone 7
## Topics
* Multi-touch
* Drawing
## IsPublished
* True
## ModifiedDate
* 2012-05-28 08:22:34
## Description

<h1>Windows Phone 7 Sample : <span style="">VB</span>WP7MultiTouchDrawing</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to draw pictures with Canvas Control on a multi-touch screen. If
<span style="">you</span> simply implement <span style="">the following </span>event:
<br>
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style="font-family:Consolas; color:blue">AddHandler</span><span style="font-family:Consolas; color:black">&nbsp;</span><span style="font-family:Consolas; color:#2B91AF">Touch</span><span style="font-family:Consolas; color:black">.FrameReported,&nbsp;</span><span style="font-family:Consolas; color:blue">AddressOf</span><span style="font-family:Consolas; color:black">&nbsp;</span><span style="font-family:Consolas; color:blue">Me</span><span style="font-family:Consolas; color:black">.Touch_FrameReported</span><span style="">
</span></p>
<p class="MsoNormal"><span style="">You can implement multi-touch draw, representing each event using only dots, but the resulting drawing is not visually appealing. InkPresenter can draw lines smoothly, but it demonstrates the action of one touch only. This
 sample demonstrates how to draw smooth lines using up to four fingers simultaneously.
</span></p>
<p class="MsoNormal">Prerequisite: <br>
Visual Studio 2010 with Windows phone SDK 7.1. <span style=""></span></p>
<p class="MsoNormal">You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the project in Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.</p>
<p class="MsoNormal"><span style="">T</span>he emulated mouse can only simulate one point touch drawing. If you wish to test multi-touch drawing, please deploy the sample application to a real windows phone.
<br>
<span style=""><img src="/site/view/file/57886/1/image.png" alt="" width="378" height="706" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new <span style="">��</span>Silverlight <span style="">
f</span>or Windows Phone<span style="">�� project</span>.<br>
2. Add Reference to Microsoft.Xna.Framework dll. This dll is needed when we want to save an image to<span style=""> the</span> Media Library.
<br>
3. Open MainPage.xaml and replace default Grid with following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;Grid Margin=&quot;0,1,0,0&quot; Background=&quot;White&quot; Height=&quot;780&quot;&gt;
        &lt;Canvas x:Name=&quot;drawCanvas&quot;
                Background=&quot;White&quot; Margin=&quot;0,0,0,60&quot;&gt;
        &lt;/Canvas&gt;
        &lt;Button Margin=&quot;0,700,240,0&quot; Background=&quot;DarkRed&quot; Content=&quot;Save&quot;
                x:Name=&quot;Save&quot; Click=&quot;Save_Click&quot;&gt;&lt;/Button&gt;
        &lt;Button Margin=&quot;240,700,0,0&quot; Background=&quot;DarkRed&quot; Content=&quot;New&quot; 
                x:Name=&quot;New&quot; Click=&quot;New_Click&quot;&gt;&lt;/Button&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;Grid Margin=&quot;0,1,0,0&quot; Background=&quot;White&quot; Height=&quot;780&quot;&gt;
        &lt;Canvas x:Name=&quot;drawCanvas&quot;
                Background=&quot;White&quot; Margin=&quot;0,0,0,60&quot;&gt;
        &lt;/Canvas&gt;
        &lt;Button Margin=&quot;0,700,240,0&quot; Background=&quot;DarkRed&quot; Content=&quot;Save&quot;
                x:Name=&quot;Save&quot; Click=&quot;Save_Click&quot;&gt;&lt;/Button&gt;
        &lt;Button Margin=&quot;240,700,0,0&quot; Background=&quot;DarkRed&quot; Content=&quot;New&quot; 
                x:Name=&quot;New&quot; Click=&quot;New_Click&quot;&gt;&lt;/Button&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. And implement event handlers. Touch.FrameReported is the most important event in this sample, every screen touch will raise this event. In this sample, all drawing tasks are done with this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        'Touch.FrameReported &#43;= New TouchFrameEventHandler(AddressOf Touch_FrameReported)
        AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
    End Sub


    'preXArray and preYArray are used to store the start point 
    'for each touch point. currently silverlight support 4 muliti-touch
    'here declare as 10 points for further needs. 
    Private preXArray As Double() = New Double(9) {}
    Private preYArray As Double() = New Double(9) {}


    ''' &lt;summary&gt;
    ''' Every touch action will rise this event handler. 
    ''' &lt;/summary&gt;
    Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
        Dim pointsNumber As Integer = e.GetTouchPoints(drawCanvas).Count
        Dim pointCollection As TouchPointCollection = e.GetTouchPoints(drawCanvas)


        For i As Integer = 0 To pointsNumber - 1
            If pointCollection(i).Action = TouchAction.Down Then
                preXArray(i) = pointCollection(i).Position.X
                preYArray(i) = pointCollection(i).Position.Y
            End If
            If pointCollection(i).Action = TouchAction.Move Then
                Dim line As New Line()


                line.X1 = preXArray(i)
                line.Y1 = preYArray(i)
                line.X2 = pointCollection(i).Position.X
                line.Y2 = pointCollection(i).Position.Y


                line.Stroke = New SolidColorBrush(Colors.Black)
                line.Fill = New SolidColorBrush(Colors.Black)
                drawCanvas.Children.Add(line)


                preXArray(i) = pointCollection(i).Position.X
                preYArray(i) = pointCollection(i).Position.Y
            End If
        Next
    End Sub


    ''' &lt;summary&gt;
    ''' Save image to Media Library so that we can view pictures we created
    ''' &lt;/summary&gt;
    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
        Dim library As New MediaLibrary()
        Dim bitMap As New WriteableBitmap(drawCanvas, Nothing)
        Dim ms As New MemoryStream()
        Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100)
        ms.Seek(0, SeekOrigin.Begin)
        library.SavePicture(String.Format(&quot;Images\{0}.jpg&quot;, Guid.NewGuid()), ms)
    End Sub


    Private Sub New_Click(sender As Object, e As RoutedEventArgs)
        drawCanvas.Children.Clear()
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        'Touch.FrameReported &#43;= New TouchFrameEventHandler(AddressOf Touch_FrameReported)
        AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
    End Sub


    'preXArray and preYArray are used to store the start point 
    'for each touch point. currently silverlight support 4 muliti-touch
    'here declare as 10 points for further needs. 
    Private preXArray As Double() = New Double(9) {}
    Private preYArray As Double() = New Double(9) {}


    ''' &lt;summary&gt;
    ''' Every touch action will rise this event handler. 
    ''' &lt;/summary&gt;
    Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
        Dim pointsNumber As Integer = e.GetTouchPoints(drawCanvas).Count
        Dim pointCollection As TouchPointCollection = e.GetTouchPoints(drawCanvas)


        For i As Integer = 0 To pointsNumber - 1
            If pointCollection(i).Action = TouchAction.Down Then
                preXArray(i) = pointCollection(i).Position.X
                preYArray(i) = pointCollection(i).Position.Y
            End If
            If pointCollection(i).Action = TouchAction.Move Then
                Dim line As New Line()


                line.X1 = preXArray(i)
                line.Y1 = preYArray(i)
                line.X2 = pointCollection(i).Position.X
                line.Y2 = pointCollection(i).Position.Y


                line.Stroke = New SolidColorBrush(Colors.Black)
                line.Fill = New SolidColorBrush(Colors.Black)
                drawCanvas.Children.Add(line)


                preXArray(i) = pointCollection(i).Position.X
                preYArray(i) = pointCollection(i).Position.Y
            End If
        Next
    End Sub


    ''' &lt;summary&gt;
    ''' Save image to Media Library so that we can view pictures we created
    ''' &lt;/summary&gt;
    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
        Dim library As New MediaLibrary()
        Dim bitMap As New WriteableBitmap(drawCanvas, Nothing)
        Dim ms As New MemoryStream()
        Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100)
        ms.Seek(0, SeekOrigin.Begin)
        library.SavePicture(String.Format(&quot;Images\{0}.jpg&quot;, Guid.NewGuid()), ms)
    End Sub


    Private Sub New_Click(sender As Object, e As RoutedEventArgs)
        drawCanvas.Children.Clear()
    End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">To learn more about Touch.FrameReported event please check this link:<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
