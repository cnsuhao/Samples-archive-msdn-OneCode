=============================================================================
	Windows Phone 7 Sample : CSWP7MultiTouchDrawing
=============================================================================
/////////////////////////////////////////////////////////////////////////////
Use:

This sample demonstrates how to draw pictures in canvas control with multitouch.
If we simply implement event 
Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
We can do mulit-touch draw, but only with dots. looks not good. 
InkPresenter can draw lines smoothly, but with one touch only. By this sample.
we can draw smooth line with max 4 fingers. 


To run the sample:
1. Open the project in Visual Studio 2010
2. Press Ctrl+F5.


/////////////////////////////////////////////////////////////////////////////
Prerequisite

Visual Studio 2010 with Windows phone SDK 7.1.you can get start by checking
this link: http://create.msdn.com/en-us/home/getting_started


/////////////////////////////////////////////////////////////////////////////
Creation:

1. Create a new project after template: Silverlight For Windows Phone
2. Add Reference to Microsoft.Xna.Framework dll. this dll is needed when we 
want to save a image to Media Library. 
3. Open MainPage.xaml and replace default Grid with following code:
    <Grid x:Name="LayoutRoot" Background="Transparent">
        <Grid Margin="0,1,0,0" Background="White" Height="780">
            <Canvas x:Name="drawCanvas"
                    Background="White" Margin="0,0,0,60">
            </Canvas>
            <Button Margin="0,700,240,0" Background="DarkRed" Content="Save"
                    x:Name="Save" Click="Save_Click"></Button>
            <Button Margin="240,700,0,0" Background="DarkRed" Content="New" 
                    x:Name="New" Click="New_Click"></Button>
        </Grid>
    </Grid>
4. And implement event handlers. Touch.FrameReported is the most important 
event in this sample, every sreen touch will rise this event. In this sample,
all drawing tasks are done with this:
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        //preXArray and preYArray are used to store the start point 
        //for each touch point. currently silverlight support 4 muliti-touch
        //here declare as 10 points for further needs. 
        double[] preXArray = new double[10];
        double[] preYArray = new double[10];

        /// <summary>
        /// Every touch action will rise this event handler. 
        /// </summary>
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(drawCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(drawCanvas);

            for (int i = 0; i < pointsNumber; i++)
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

        /// <summary>
        /// Save image to Media Library so that we can view pictures we created
        /// </summary>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MediaLibrary library = new MediaLibrary();
            WriteableBitmap bitMap = new WriteableBitmap(drawCanvas, null);
            MemoryStream ms = new MemoryStream();
            Extensions.SaveJpeg(bitMap, ms, bitMap.PixelWidth, bitMap.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            library.SavePicture(string.Format("Images\\{0}.jpg", Guid.NewGuid()), ms);
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            drawCanvas.Children.Clear();
        }
    }

/////////////////////////////////////////////////////////////////////////////
Reference:

http://msdn.microsoft.com/en-us/library/system.windows.input.touch.framereported(VS.95).aspx