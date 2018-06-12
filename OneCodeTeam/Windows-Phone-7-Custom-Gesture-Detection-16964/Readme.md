# Windows Phone 7 Custom Gesture Detection (VBWP7GestureDetection)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Phone 7
## Topics
* Windows Phone 7
## IsPublished
* True
## ModifiedDate
* 2012-05-28 08:21:29
## Description

<h1><span style="">Windows Phone 7 Gesture Detection demo</span> (<span style="">VB</span>WP7GestureDetection)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to detect <span style="">enlargement/shrink</span> and rotation with two points touch<span style="">ing</span> and one<span style=""> point</span> touch flick. By this sample, you can create your own photo
 viewer that support picture enlargement, rotation<span style="">,</span> move<span style=""> and
</span>flick.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Visual Studio 2010 with Windows phone SDK 7.1.you can get start by checking this link:
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open the project in Visual Studio 2010</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl&#43;F5.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Deploy the sample in a real Windows Phone.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>You can use two fingers to enlarge, shrink or rotate. You can use one finger to move or flick.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/57878/1/image.png" alt="" width="319" height="529" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new <span style="">��</span>Silverlight For Windows Phone<span style="">�� project;</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open MainPage.xaml file and replace its layout Grid with the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
    &lt;Grid.Background&gt;
        &lt;ImageBrush ImageSource=&quot;BG.jpg&quot;&gt;&lt;/ImageBrush&gt;
    &lt;/Grid.Background&gt;


    &lt;StackPanel x:Name=&quot;touchStackPanel&quot; Margin=&quot;10,10,10,10&quot; Background=&quot;Black&quot; Opacity=&quot;0.5&quot;&gt;
        &lt;TextBlock x:Name=&quot;txt_SharpInfo&quot; Text=&quot;Enlarg and shrink&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBlock x:Name=&quot;txt_RotateInfo&quot; Text=&quot;Rotate&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBlock x:Name=&quot;txt_FlickInfo&quot; Text=&quot;Flick&quot;&gt;&lt;/TextBlock&gt;
    &lt;/StackPanel&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
    &lt;Grid.Background&gt;
        &lt;ImageBrush ImageSource=&quot;BG.jpg&quot;&gt;&lt;/ImageBrush&gt;
    &lt;/Grid.Background&gt;


    &lt;StackPanel x:Name=&quot;touchStackPanel&quot; Margin=&quot;10,10,10,10&quot; Background=&quot;Black&quot; Opacity=&quot;0.5&quot;&gt;
        &lt;TextBlock x:Name=&quot;txt_SharpInfo&quot; Text=&quot;Enlarg and shrink&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBlock x:Name=&quot;txt_RotateInfo&quot; Text=&quot;Rotate&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBlock x:Name=&quot;txt_FlickInfo&quot; Text=&quot;Flick&quot;&gt;&lt;/TextBlock&gt;
    &lt;/StackPanel&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open MainPage.xaml.<span style="">vb</span> file, alter its code
<span style="">like so:</span></p>
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
        AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
    End Sub


    Private preDistance As Double = 0
    Private preAngle As Double = 0
    Private preFlickX As Double = 0
    Private preFlickY As Double = 0
    Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
        Dim tpc As TouchPointCollection = e.GetTouchPoints(touchStackPanel)
        If tpc.Count = 2 Then
            Dim point1 As TouchPoint = tpc(0)
            Dim point2 As TouchPoint = tpc(1)


            Dim X1 As Double = point1.Position.X
            Dim X2 As Double = point2.Position.X
            Dim Y1 As Double = point1.Position.Y
            Dim Y2 As Double = point2.Position.Y


            ' Detect two fingers enlargement and shrink.
            Dim distance = Math.Pow((X1 - X2), 2) &#43; Math.Pow((Y1 - Y2), 2)
            If distance &gt; preDistance Then
                txt_SharpInfo.Text = &quot;enlarge&quot;
            Else
                txt_SharpInfo.Text = &quot;shink&quot;
            End If
            preDistance = distance


            ' Detect rotation.
            Dim nowAngle As Double = 0
            If (X2 - X1) = 0 Then
                nowAngle = 90
            Else
                nowAngle = Math.Atan((Y2 - Y1) / (X2 - X1))
            End If
            If nowAngle &gt; preAngle Then
                txt_RotateInfo.Text = &quot;clock wise rotation&quot;
            Else
                txt_RotateInfo.Text = &quot;counter clock wise rotation&quot;
            End If
            preAngle = nowAngle
        End If


        ' Detect flick.
        If tpc.Count = 1 Then
            Dim flickPoint As TouchPoint = tpc(0)
            If flickPoint.Action = TouchAction.Move Then
                txt_FlickInfo.Text = &quot;Move&quot;
                preFlickX = flickPoint.Position.X
                preFlickY = flickPoint.Position.Y
            ElseIf flickPoint.Action = TouchAction.Up Then
                Dim nowflickX As Double = flickPoint.Position.X
                Dim nowflickY As Double = flickPoint.Position.Y
                Dim length As Double = Math.Pow((nowflickX - preFlickX), 2) &#43; Math.Pow((nowflickY - preFlickY), 2)
                If length &gt; 0 Then
                    txt_FlickInfo.Text = [String].Concat(&quot;flick&quot;, length.ToString())
                End If
            End If
        End If
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        AddHandler Touch.FrameReported, AddressOf Me.Touch_FrameReported
    End Sub


    Private preDistance As Double = 0
    Private preAngle As Double = 0
    Private preFlickX As Double = 0
    Private preFlickY As Double = 0
    Private Sub Touch_FrameReported(sender As Object, e As TouchFrameEventArgs)
        Dim tpc As TouchPointCollection = e.GetTouchPoints(touchStackPanel)
        If tpc.Count = 2 Then
            Dim point1 As TouchPoint = tpc(0)
            Dim point2 As TouchPoint = tpc(1)


            Dim X1 As Double = point1.Position.X
            Dim X2 As Double = point2.Position.X
            Dim Y1 As Double = point1.Position.Y
            Dim Y2 As Double = point2.Position.Y


            ' Detect two fingers enlargement and shrink.
            Dim distance = Math.Pow((X1 - X2), 2) &#43; Math.Pow((Y1 - Y2), 2)
            If distance &gt; preDistance Then
                txt_SharpInfo.Text = &quot;enlarge&quot;
            Else
                txt_SharpInfo.Text = &quot;shink&quot;
            End If
            preDistance = distance


            ' Detect rotation.
            Dim nowAngle As Double = 0
            If (X2 - X1) = 0 Then
                nowAngle = 90
            Else
                nowAngle = Math.Atan((Y2 - Y1) / (X2 - X1))
            End If
            If nowAngle &gt; preAngle Then
                txt_RotateInfo.Text = &quot;clock wise rotation&quot;
            Else
                txt_RotateInfo.Text = &quot;counter clock wise rotation&quot;
            End If
            preAngle = nowAngle
        End If


        ' Detect flick.
        If tpc.Count = 1 Then
            Dim flickPoint As TouchPoint = tpc(0)
            If flickPoint.Action = TouchAction.Move Then
                txt_FlickInfo.Text = &quot;Move&quot;
                preFlickX = flickPoint.Position.X
                preFlickY = flickPoint.Position.Y
            ElseIf flickPoint.Action = TouchAction.Up Then
                Dim nowflickX As Double = flickPoint.Position.X
                Dim nowflickY As Double = flickPoint.Position.Y
                Dim length As Double = Math.Pow((nowflickX - preFlickX), 2) &#43; Math.Pow((nowflickY - preFlickY), 2)
                If length &gt; 0 Then
                    txt_FlickInfo.Text = [String].Concat(&quot;flick&quot;, length.ToString())
                End If
            End If
        End If
    End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported.aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
