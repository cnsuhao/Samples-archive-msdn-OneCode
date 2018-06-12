# Windows Phone 7 Custom Gesture Detection (CSWP7GestureDetection)
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
* 2012-05-28 08:21:47
## Description

<h1><span style="">Windows Phone 7 Gesture Detection demo</span> (CSWP7GestureDetection)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to detect <span style="">enlargement/shrink</span> and rotation with two points touch<span style="">ing</span> and one<span style=""> point</span> touch or flick. For example, you can use this sample as a
 starting point for creating your own photo viewer that supports picture enlargement, rotation,move and flick gestures.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Use Visual Studio 2010 with Windows phone SDK 7.1.you can get started by clicking this link:
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
<p class="MsoNormal"><span style=""><img src="/site/view/file/57879/1/image.png" alt="" width="319" height="529" align="middle">
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
</span></span></span>Open MainPage.xaml.cs file, alter its code <span style="">like so:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace CSWP7GestureDetection
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported &#43;= new TouchFrameEventHandler(Touch_FrameReported);
        }


        double preDistance = 0;
        double preAngle = 0;
        double preFlickX = 0;
        double preFlickY = 0;
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection tpc = e.GetTouchPoints(touchStackPanel);
            if (tpc.Count == 2)
            {
                TouchPoint point1 = tpc[0];
                TouchPoint point2 = tpc[1];


                double X1 = point1.Position.X;
                double X2 = point2.Position.X;
                double Y1 = point1.Position.Y;
                double Y2 = point2.Position.Y;


                // Detect two fingers enlargement and shrink
                var distance = Math.Pow((X1 - X2), 2) &#43; Math.Pow((Y1 - Y2), 2);
                if (distance &gt; preDistance)
                {
                    txt_SharpInfo.Text = &quot;enlarge&quot;;
                }
                else
                {
                    txt_SharpInfo.Text = &quot;shink&quot;;
                }
                preDistance = distance;


                // Detect rotation.
                double nowAngle = 0;
                if ((X2 - X1) == 0)
                {
                    nowAngle = 90;
                }
                else
                {
                    nowAngle = Math.Atan((Y2 - Y1) / (X2 - X1));
                }
                if (nowAngle &gt; preAngle)
                {
                    txt_RotateInfo.Text = &quot;clock wise rotation&quot;;
                }
                else
                {
                    txt_RotateInfo.Text = &quot;counter clock wise rotation&quot;;
                }
                preAngle = nowAngle;
            }


            if (tpc.Count == 1)
            {
                TouchPoint flickPoint = tpc[0];
                if (flickPoint.Action == TouchAction.Move)
                {
                    txt_FlickInfo.Text = &quot;Move&quot;;
                    preFlickX = flickPoint.Position.X;
                    preFlickY = flickPoint.Position.Y;
                }
                else if (flickPoint.Action == TouchAction.Up)
                {
                    double nowflickX = flickPoint.Position.X;
                    double nowflickY = flickPoint.Position.Y;
                    double length = Math.Pow((nowflickX - preFlickX), 2) &#43; Math.Pow((nowflickY - preFlickY), 2);
                    if (length &gt; 0)
                    {
                        txt_FlickInfo.Text = String.Concat(&quot;flick&quot;, length.ToString());
                    }
                }
            }
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


namespace CSWP7GestureDetection
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported &#43;= new TouchFrameEventHandler(Touch_FrameReported);
        }


        double preDistance = 0;
        double preAngle = 0;
        double preFlickX = 0;
        double preFlickY = 0;
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection tpc = e.GetTouchPoints(touchStackPanel);
            if (tpc.Count == 2)
            {
                TouchPoint point1 = tpc[0];
                TouchPoint point2 = tpc[1];


                double X1 = point1.Position.X;
                double X2 = point2.Position.X;
                double Y1 = point1.Position.Y;
                double Y2 = point2.Position.Y;


                // Detect two fingers enlargement and shrink
                var distance = Math.Pow((X1 - X2), 2) &#43; Math.Pow((Y1 - Y2), 2);
                if (distance &gt; preDistance)
                {
                    txt_SharpInfo.Text = &quot;enlarge&quot;;
                }
                else
                {
                    txt_SharpInfo.Text = &quot;shink&quot;;
                }
                preDistance = distance;


                // Detect rotation.
                double nowAngle = 0;
                if ((X2 - X1) == 0)
                {
                    nowAngle = 90;
                }
                else
                {
                    nowAngle = Math.Atan((Y2 - Y1) / (X2 - X1));
                }
                if (nowAngle &gt; preAngle)
                {
                    txt_RotateInfo.Text = &quot;clock wise rotation&quot;;
                }
                else
                {
                    txt_RotateInfo.Text = &quot;counter clock wise rotation&quot;;
                }
                preAngle = nowAngle;
            }


            if (tpc.Count == 1)
            {
                TouchPoint flickPoint = tpc[0];
                if (flickPoint.Action == TouchAction.Move)
                {
                    txt_FlickInfo.Text = &quot;Move&quot;;
                    preFlickX = flickPoint.Position.X;
                    preFlickY = flickPoint.Position.Y;
                }
                else if (flickPoint.Action == TouchAction.Up)
                {
                    double nowflickX = flickPoint.Position.X;
                    double nowflickY = flickPoint.Position.Y;
                    double length = Math.Pow((nowflickX - preFlickX), 2) &#43; Math.Pow((nowflickY - preFlickY), 2);
                    if (length &gt; 0)
                    {
                        txt_FlickInfo.Text = String.Concat(&quot;flick&quot;, length.ToString());
                    }
                }
            }
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported.aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
