# Irregular Shape of WPF Window (CSWPFIrregularShapeWindow)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Window
## IsPublished
* True
## ModifiedDate
* 2012-04-20 05:00:48
## Description
================================================================================ Windows APPLICATION: CSWPFIrregularShapeWindow Overview =============================================================================== /////////////////////////////////////////////////////////////////////////////
 Summary: The sample demonstrates how to create an irregularly shaped windows for WPF UI. The sample includes irregularly shaped windows such as: rectangles, circles,triangles or picture-based form shapes,etc. In each WPF form we can right-click the mouse and
 click the popup menu to enlarge,reduce,close the operation. In addition,adding these irregularly shaped actions to be dragged. The sample has two output paths setting. If you are running different CPU platform, you should update the configuration manager to
 align with their real environment. //////////////////////////////////////////////////////////////////////////////// Demo: Step1. Build this project in VS2010. Step2. Using PNG format image files replace the images' list of transparentPic. PNG formats. Step3.
 Run CSWPFIrregularShapeWindow.exe. Step4. Separately click &quot;Ellipse Window&quot;,&quot;Rounded Corners Window&quot;,&quot;Popup Corners Window&quot;, &quot;Triangle Corners Window&quot;,&quot;Picture Based Window&quot; and they show differently shaped windows with effects. /////////////////////////////////////////////////////////////////////////////
 Code Logic: 1. Each irregular window has a CommandBinding class which binds a RountedCommand to the event handlers that implement the command. 2. We can use ScaleTransform to enlarge and reduce the size of objects. And these are two opposite actions, so when
 different commands are in effect the objects are light or dark. 3. If you use a menu item to influence an object, you should set examples from the menu item ,Commandtarget method and button, otherwise menu item object will be invalid. 4. This sample provides
 a ready-made examples of ways to judge whether the CommandBinding object such as :canExecute method to receive results which are true or false. 5. This sample uses EventTriggers and Storyboards such as http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189,
 If you have Scanned the article mentioned above,you can find another type of trigger is the EventTrigger, which starts a set of actions based on the occurrence of an event. For example,the EventTrigger objects specify that when the mouse pointer enters the
 Button,Path,Ellipse and Image, the Height property animates to a value of 260 over a 0.2 second period. When the mouse moves away from the item, the property returns to the original value over a period of 1 second. Note how it is not necessary to specify a
 To value for the MouseLeave animation. This is because the animation is able to keep track of the original value. You only use the code as shown below and replace TargetType property into Button,Path,Ellipse or Image. &lt;Window.Resources&gt; &lt;Style TargetType=&quot;Path&quot;&gt;
 &lt;Setter Property=&quot;Opacity&quot; Value=&quot;0.5&quot; /&gt; &lt;Style.Triggers&gt; &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseEnter&quot;&gt; &lt;EventTrigger.Actions&gt; &lt;BeginStoryboard&gt; &lt;Storyboard&gt; &lt;DoubleAnimation Duration=&quot;0:0:0.2&quot; Storyboard.TargetProperty=&quot;Height&quot; To=&quot;260&quot; /&gt; &lt;/Storyboard&gt;
 &lt;/BeginStoryboard&gt; &lt;/EventTrigger.Actions&gt; &lt;/EventTrigger&gt; &lt;EventTrigger RoutedEvent=&quot;Mouse.MouseLeave&quot;&gt; &lt;EventTrigger.Actions&gt; &lt;BeginStoryboard&gt; &lt;Storyboard&gt; &lt;DoubleAnimation Duration=&quot;0:0:1&quot; Storyboard.TargetProperty=&quot;Height&quot; /&gt; &lt;/Storyboard&gt; &lt;/BeginStoryboard&gt;
 &lt;/EventTrigger.Actions&gt; &lt;/EventTrigger&gt; &lt;/Style.Triggers&gt; &lt;/Style&gt; &lt;/Window.Resources&gt; Certainly, you should add Height property and set its value for the Button,Path,Ellipse or Image such as &lt;Path Height=&quot;250&quot; Name=&quot;Triangle&quot; Stroke=&quot;Black&quot; StrokeThickness=&quot;2&quot;
 Grid.ColumnSpan=&quot;10&quot; Grid.RowSpan=&quot;4&quot;&gt; 6. In order to make child windows not to overlap the main windows, the sample uses codes listed below to singlely display child windows. ellipseWindow.Left = this.Left &#43; width; ellipseWindow.Top = this.Top &#43; height; /////////////////////////////////////////////////////////////////////////////
 References: CommandBinding Class http://msdn.microsoft.com/en-us/library/system.windows.input.commandbinding.aspx RoutedUICommand Class http://msdn.microsoft.com/en-us/library/system.windows.input.routeduicommand.aspx ScaleTransform Class http://msdn.microsoft.com/en-us/library/system.windows.media.scaletransform.aspx
 Window.WindowState Property http://msdn.microsoft.com/en-us/library/system.windows.window.windowstate.aspx Styling and Templating http://msdn.microsoft.com/en-us/library/ms745683.aspx#Y3189 /////////////////////////////////////////////////////////////////////////////
