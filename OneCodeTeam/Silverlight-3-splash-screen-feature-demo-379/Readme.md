# Silverlight 3 splash screen feature demo (XAMLSL3SplashScreen)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Splash Screen
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:46:26
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : XAMLSL3SplashScreen Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to customize the splash screen for Silverlight<br>
application.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Create a new ASP.NET Web Application project.<br>
<br>
Step1. Create a new ASP.NET Web Application project in Visual Studio 2008 <br>
(This sample is a C# project. However, it doesn't matter if you create a <br>
VB.NET project). Name it as &quot;XAMLSL3SplashScreen&quot;.<br>
<br>
B. Add a .xaml file and a .js file to the created ASP.NET Web Application <br>
project.<br>
<br>
Step1. Add a new .xaml file to the project. Name it as SplashScreen.xaml. <br>
Then paste the following code to it:<br>
<br>
&lt;StackPanel Width=&quot;392&quot; xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</a><br>
&nbsp; &nbsp; &nbsp; &nbsp;xmlns:x=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml&quot;">http://schemas.microsoft.com/winfx/2006/xaml&quot;</a><br>
&nbsp; &nbsp; &nbsp; &nbsp;x:Name=&quot;parentCanvas&quot;<br>
&nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp;HorizontalAlignment=&quot;Center&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackPanel HorizontalAlignment=&quot;Center&quot; Margin=&quot;8,8,0,229&quot; Width=&quot;392&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Canvas x:Name=&quot;AnimationCanvas&quot; Height=&quot;132&quot; Margin=&quot;8,0,41,0&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Canvas.Triggers&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;EventTrigger RoutedEvent=&quot;Canvas.Loaded&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;EventTrigger.Actions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;BeginStoryboard&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Storyboard AutoReverse=&quot;True&quot; x:Name=&quot;LoadingStoryboard&quot; RepeatBehavior=&quot;Forever&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;DoubleAnimationUsingKeyFrames BeginTime=&quot;00:00:00&quot; Storyboard.TargetName=&quot;AnimationCanvas&quot; Storyboard.TargetProperty=&quot;(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Offset)&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;EasingDoubleKeyFrame KeyTime=&quot;00:00:00&quot; Value=&quot;0.144&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;EasingDoubleKeyFrame KeyTime=&quot;00:00:00.5000000&quot; Value=&quot;0.296&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/DoubleAnimationUsingKeyFrames&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Storyboard&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/BeginStoryboard&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/EventTrigger.Actions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/EventTrigger&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Canvas.Triggers&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Canvas.Background&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;LinearGradientBrush EndPoint=&quot;0.587,1.407&quot; StartPoint=&quot;0.583,-0.519&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GradientStop Color=&quot;Black&quot; Offset=&quot;0.144&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GradientStop x:Name=&quot;uxGradientStop&quot; Color=&quot;White&quot; Offset=&quot;0.86&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/LinearGradientBrush&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Canvas.Background&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock Height=&quot;81&quot; Width=&quot;303&quot; Canvas.Left=&quot;32&quot; Canvas.Top=&quot;8&quot; Text=&quot;Loading&quot; TextWrapping=&quot;Wrap&quot; FontSize=&quot;64&quot;
 FontWeight=&quot;Bold&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock.Foreground&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;LinearGradientBrush EndPoint=&quot;0.978,0.543&quot; StartPoint=&quot;-0.005,0.542&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop x:Name=&quot;uxGradientStop1&quot; Color=&quot;Orange&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GradientStop x:Name=&quot;uxGradientStop2&quot; Color=&quot;White&quot;/&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/LinearGradientBrush&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TextBlock.Foreground&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TextBlock&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock x:Name=&quot;uxStatus&quot; Height=&quot;18&quot; Width=&quot;161&quot; Canvas.Left=&quot;70&quot; Canvas.Top=&quot;96&quot; TextWrapping=&quot;Wrap&quot; TextAlignment=&quot;Center&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Canvas&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackPanel&gt;<br>
&lt;/StackPanel&gt;<br>
<br>
The above XAML code mainly adds three controls:<br>
<br>
1. A Canvas that triggers a storyboard on its Loaded event. It demonstrates <br>
how to play animation on the splash screen.<br>
<br>
2. A TextBlock control renders &quot;Loading&quot; text. GradientStop objects of its
<br>
Foreground brush are given names so that we can access them in JavaScript <br>
functions.<br>
<br>
3. Another TextBlock intended to render download progress. Its name is <br>
specified so that we can access it in JavaScript functions.<br>
<br>
Step2. Add a new .js file to the project. Name it as &quot;XAMLSplashScreen.js&quot;.
<br>
Then paste following code to it:<br>
<br>
function onSourceDownloadProgressChanged(sender, eventArgs) {<br>
&nbsp; &nbsp;sender.findName(&quot;uxStatus&quot;).Text = Math.round((eventArgs.progress * 1000)) / 10 &#43; &quot;%&quot;;<br>
&nbsp; &nbsp;sender.findName(&quot;uxGradientStop1&quot;).Offset = eventArgs.progress;<br>
&nbsp; &nbsp;sender.findName(&quot;uxGradientStop2&quot;).Offset = eventArgs.progress;<br>
}<br>
<br>
In the above function, we get the progress from eventArgs, then find the <br>
TextBlock and GradientStop objects and update their properties.<br>
<br>
C. Add .xap to the project.<br>
<br>
Step1. Add a new Folder named &quot;ClientBin&quot; to the project.<br>
<br>
Step2. Add a .xap file under the &quot;ClientBin&quot; folder. The .xap file is created
<br>
by Silverlight project. You can find it in the output folder of any <br>
Silverlight projects. By default it is under &quot;Bin\Debug&quot;. If you cannot find
<br>
it, please check the output path setting of the Silverlight project. You can <br>
right click the project node in the Solution Explorer window, click <br>
&quot;Properties&quot;, select &quot;Build&quot; tab and set it in the Output section. Please
<br>
note that the .xap file should be large enough or else it's possible that the <br>
splash screen cannot be seen by users. In this sample the .xap file is only <br>
1250 KB so you possibly cannot see the effect clearly. If you want to test <br>
the effect of splash screen, you can add large files as resources in the <br>
Silverlight project. Please remember to set files' Build Action to &quot;Resource&quot;
<br>
or &quot;Embeded Resource&quot; so that they will be included in the generated .xap
<br>
file.<br>
<br>
D. Edit Default.aspx file.<br>
<br>
Step1. Replace the existing &lt;html&gt; tag and it's children elements with the <br>
following code:<br>
<br>
&lt;html xmlns=&quot;<a target="_blank" href="http://www.w3.org/1999/xhtml&quot;">http://www.w3.org/1999/xhtml&quot;</a> &gt;<br>
&lt;head id=&quot;Head1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp; &nbsp;&lt;title&gt;&lt;/title&gt;<br>
&nbsp; &nbsp;<style type="text/css"><br>
   html, body {<br>
        height: 100%;<br>
        overflow: auto;<br>
   }<br>
   body {<br>
        padding: 0;<br>
        margin: 0;<br>
   }<br>
   #silverlightControlHost {<br>
        height: 100%;<br>
        text-align:center;<br>
   }<br>
   </style><br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot; src=&quot;Silverlight.js&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;function onSilverlightError(sender, args) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var appSource = &quot;&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (sender != null && sender != 0) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;appSource = sender.getHost().Source;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var errorType = args.ErrorType;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var iErrorCode = args.ErrorCode;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (errorType == &quot;ImageError&quot; || errorType == &quot;MediaError&quot;) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var errMsg = &quot;Unhandled Error in Silverlight Application &quot; &#43; &nbsp;appSource &#43; &quot;\n&quot; ;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Code: &quot;&#43; iErrorCode &#43; &quot; &nbsp; &nbsp;\n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Category: &quot; &#43; errorType &#43; &quot; &nbsp; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Message: &quot; &#43; args.ErrorMessage &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (errorType == &quot;ParserError&quot;) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;File: &quot; &#43; args.xamlFile &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Line: &quot; &#43; args.lineNumber &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Position: &quot; &#43; args.charPosition &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (errorType == &quot;RuntimeError&quot;) { &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (args.lineNumber != 0) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Line: &quot; &#43; args.lineNumber &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;Position: &quot; &#43; &nbsp;args.charPosition &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;errMsg &#43;= &quot;MethodName: &quot; &#43; args.methodName &#43; &quot; &nbsp; &nbsp; \n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new Error(errMsg);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot; src=&quot;XAMLSplashScreen.js&quot;&gt;&lt;/script&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
&nbsp; &nbsp;&lt;form id=&quot;form1&quot; runat=&quot;server&quot; style=&quot;height:100%&quot;&gt;<br>
&nbsp; &nbsp;&lt;div id=&quot;silverlightControlHost&quot;&gt;<br>
&nbsp; &nbsp;&lt;h2&gt;<br>
&nbsp; &nbsp;XAMLSplashScreen<br>
&nbsp; &nbsp;&lt;/h2&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;object data=&quot;data:application/x-silverlight-2,&quot; type=&quot;application/x-silverlight-2&quot; width=&quot;100%&quot; height=&quot;100%&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;param name=&quot;source&quot; value=&quot;ClientBin/SplashScreenLoaded.xap&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;param name=&quot;onError&quot; value=&quot;onSilverlightError&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;param name=&quot;background&quot; value=&quot;white&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;param name=&quot;minRuntimeVersion&quot; value=&quot;3.0.40624.0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;param name=&quot;autoUpgrade&quot; value=&quot;true&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br>
&lt;param name=&quot;splashscreensource&quot; value=&quot;SplashScreen.xaml&quot;/&gt;<br>
&lt;param name=&quot;onSourceDownloadProgressChanged&quot; value=&quot;onSourceDownloadProgressChanged&quot; /&gt;<br>
<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;a href=&quot;<a target="_blank" href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0&quot;">http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0&quot;</a> style=&quot;text-decoration:none&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;img src=&quot;<a target="_blank" href="http://go.microsoft.com/fwlink/?LinkId=108181&quot;">http://go.microsoft.com/fwlink/?LinkId=108181&quot;</a> alt=&quot;Get Microsoft Silverlight&quot;
 style=&quot;border-style:none&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/a&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&lt;/object&gt;<br>
<br>
&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&lt;iframe id=&quot;_sl_historyFrame&quot; style=&quot;visibility:hidden;height:0px;width:0px;border:0px&quot;&gt;&lt;/iframe&gt;&lt;/div&gt;<br>
&nbsp; &nbsp;&lt;/form&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
<br>
The above code is the same as auto-generated test aspx page for Silverlight <br>
projects except for two parts:<br>
<br>
1. A &lt;script&gt; tag is used to reference the JavaScript file:<br>
&lt;script type=&quot;text/javascript&quot; src=&quot;XAMLSplashScreen.js&quot;&gt;&lt;/script&gt;<br>
<br>
2. Two &lt;param&gt;s are used to specify the splash screen source and the event <br>
handler of onSourceDownloadProgressChanged:<br>
<br>
&lt;param name=&quot;splashscreensource&quot; value=&quot;SplashScreen.xaml&quot;/&gt;<br>
&lt;param name=&quot;onSourceDownloadProgressChanged&quot; value=&quot;onSourceDownloadProgressChanged&quot; /&gt;<br>
<br>
To use your xap file, you also need to change the value of:<br>
&lt;param name=&quot;source&quot; value=&quot;ClientBin/SplashScreenLoaded.xap&quot;/&gt;<br>
<br>
</p>
<h3>Known Issue:</h3>
<p style="font-family:Courier New"><br>
If the source URL does not end in &quot;.xap&quot;, Silverlight cannot know if it is a
<br>
request to a Silverlight 1.0 app (XAML&#43;JS) or a XAP before download. So the <br>
default splash screen will be used even if you've specified a custom splash <br>
screen source.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to: Define a Simple Silverlight Splash Screen<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc903962(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc903962(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
