# Animation in Silverlight 3 (CSSL3Animation)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Animation
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:05:03
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3Animation Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to play animation in Silverlight. Since animation<br>
is a big topic, we only covers PointAnimation in this sample. For other animation<br>
classes, the code should be similar.<br>
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
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. MainPage.xaml:<br>
<br>
It is the container of the following UserControls:<br>
BasicPointAnimation.xaml<br>
AnimateDependencyProperty.xaml<br>
Easing.xaml<br>
CodeBehindCreation.xaml<br>
UsingKeyFrames.xaml<br>
<br>
2. BasicPointAnimation.xaml:<br>
<br>
It shows how to write baisc PointAnimation for an EllipseGeometry. In the<br>
MouseLeftButtonDown event of MyStackPanel, current mouse position is got and the<br>
To property of PointAnimation object is updated. After that, call Begin() method<br>
of the StoryBoard object to play animation.<br>
<br>
3. MyEllipse.xaml:<br>
<br>
This UserControl is used to wrap a EllipseGeometry. EllipseGeometry doesn't<br>
expose any event for its Center change. So to get a notification after Center<br>
change EllipseCenterProperty is added. A callback method is hooked so that whenever<br>
the EllipseCenterProperty is changed we can synchronize the changed value with the<br>
Center property of EllipseGeometry object, in which way to update UI.<br>
<br>
4. AnimateDependencyProperty.xaml<br>
<br>
This UserControl uses MyEllipse UserControl. The TargetProperty of the StoryBoard<br>
in it is the EllipseCenterProperty of MyEllipse object. During the animation, the<br>
EllipseCenterProperty will be changed and the callback method MyHandler() will be
<br>
called, which in turn calls OnEllipseCenterChanged() method to trigger the <br>
EllipseCenterChanged event. The EllipseCenterChanged event is public so we can hook<br>
event handler in AnimateDependencyProperty UserControl to get a notification for <br>
EllipseCenterProperty's change. In this sample, a Line object is updated in this<br>
event handler to simulate an animation effect.<br>
<br>
5. Easing.xaml<br>
<br>
This UserControl demonstrates how to use built-in Ease classes and how to write a<br>
custom Ease class. By inheriting EasingFunctionBase and override its EaseInCore()<br>
method we can write our own Ease class.<br>
<br>
6. CodeBehindCreation.xaml<br>
<br>
This UserControl shows how to initialize a Storyboard in code behind. The final effect<br>
is the same as BasicPointAnimation.xaml, which uses XAML to add Storyboard.<br>
<br>
7. UsingKeyFrames.xaml<br>
<br>
This UserControl shows how to create KeyFrames based animation in Silverlight.<br>
In the sample SplineDoubleKeyFrame is used to specify each KeyFrame.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Animation<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc189090(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc189090(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
