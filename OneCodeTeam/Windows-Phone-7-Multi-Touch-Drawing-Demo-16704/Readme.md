# Windows Phone 7 Multi-Touch Drawing Demo (CSWP7MultiTouchDrawing)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone 7
* Windows Phone 7.5
## Topics
* Multi-touch
* Drawing
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:53:25
## Description

<h1>Windows Phone 7 Sample : CSWP7MultiTouchDrawing</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to draw pictures with Canvas Control on a multi-touch screen. If
<span>you</span> simply implement <span>the following </span>event: <br>
<span><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span class="SpellE">Touch.FrameReported</span> &#43;= new
<span class="SpellE"><span class="GramE">TouchFrameEventHandler</span></span><span class="GramE">(</span><span class="SpellE">Touch_FrameReported</span>);<br>
<span>You can implement multi-touch draw, representing each event using only dots, but the resulting drawing is not visually appealing.
<span class="SpellE">InkPresenter</span> can draw lines smoothly, but it demonstrates the action of one touch only. This sample demonstrates how to draw smooth lines using up to four fingers simultaneously.
</span></p>
<p class="MsoNormal">Prerequisite: <br>
Visual Studio 2010 with Windows phone SDK 7.1.</p>
<p class="MsoNormal">You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the project in Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.</p>
<p class="MsoNormal"><span>T</span>he emulated mouse can only simulate one point touch drawing. If you wish to test multi-touch drawing, please deploy the sample application to a real windows phone.
<br>
<span><img src="/site/view/file/57259/1/image.png" alt="" width="378" height="706" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new <span>��</span>Silverlight <span>f</span>or Windows Phone<span>�� project</span>.<br>
2. Add Reference to Microsoft.Xna.Framework dll. This dll is needed when we want to save an image to<span> the</span> Media Library.
<br>
3. Open MainPage.xaml and replace default Grid with following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
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
<pre id="codePreview" class="xaml">&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported &#43;= new TouchFrameEventHandler(Touch_FrameReported);
        }


        //preXArray and preYArray are used to store the start point 
        //for each touch point. currently silverlight support 4 muliti-touch
        //here declare as 10 points for further needs. 
        double[] preXArray = new double[10];
        double[] preYArray = new double[10];


        /// &lt;summary&gt;
        /// Every touch action will rise this event handler. 
        /// &lt;/summary&gt;
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(drawCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(drawCanvas);


            for (int i = 0; i &lt; pointsNumber; i&#43;&#43;)
            {
                if (pointCollection[i].Action == TouchAction.Down)
                {
                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
                if (pointCollection[i].Action == TouchAction.Move)
                {
                    Line line = new Line();


                    line.X1 = preXArray[i];
                    line.Y1 = preYArray[i];
                    line.X2 = pointCollection[i].Position.X;
                    line.Y2 = pointCollection[i].Position.Y;


                    line.Stroke = new SolidColorBrush(Colors.Black);
                    line.Fill = new SolidColorBrush(Colors.Black);
                    drawCanvas.Children.Add(line);


                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
            }
        }


        /// &lt;summary&gt;
        /// Save image to Media Library so that we can view pictures we created
        /// &lt;/summary&gt;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MediaLibrary library = new MediaLibrary();
            WriteableBitmap bitMap = new WriteableBitmap(drawCanvas, null);
            MemoryStream ms = new MemoryStream();
            Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            library.SavePicture(string.Format(&quot;Images\\{0}.jpg&quot;, Guid.NewGuid()), ms);
        }


        private void New_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }
    }

</pre>
<pre id="codePreview" class="csharp">    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported &#43;= new TouchFrameEventHandler(Touch_FrameReported);
        }


        //preXArray and preYArray are used to store the start point 
        //for each touch point. currently silverlight support 4 muliti-touch
        //here declare as 10 points for further needs. 
        double[] preXArray = new double[10];
        double[] preYArray = new double[10];


        /// &lt;summary&gt;
        /// Every touch action will rise this event handler. 
        /// &lt;/summary&gt;
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(drawCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(drawCanvas);


            for (int i = 0; i &lt; pointsNumber; i&#43;&#43;)
            {
                if (pointCollection[i].Action == TouchAction.Down)
                {
                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
                if (pointCollection[i].Action == TouchAction.Move)
                {
                    Line line = new Line();


                    line.X1 = preXArray[i];
                    line.Y1 = preYArray[i];
                    line.X2 = pointCollection[i].Position.X;
                    line.Y2 = pointCollection[i].Position.Y;


                    line.Stroke = new SolidColorBrush(Colors.Black);
                    line.Fill = new SolidColorBrush(Colors.Black);
                    drawCanvas.Children.Add(line);


                    preXArray[i] = pointCollection[i].Position.X;
                    preYArray[i] = pointCollection[i].Position.Y;
                }
            }
        }


        /// &lt;summary&gt;
        /// Save image to Media Library so that we can view pictures we created
        /// &lt;/summary&gt;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MediaLibrary library = new MediaLibrary();
            WriteableBitmap bitMap = new WriteableBitmap(drawCanvas, null);
            MemoryStream ms = new MemoryStream();
            Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            library.SavePicture(string.Format(&quot;Images\\{0}.jpg&quot;, Guid.NewGuid()), ms);
        }


        private void New_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal">To learn more about <span class="SpellE">Touch.FrameReported</span> event please check this link<span class="GramE">:</span><br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
