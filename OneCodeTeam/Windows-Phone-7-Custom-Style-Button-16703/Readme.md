# Windows Phone 7 Custom Style Button (CSWP7CustomStyleButton)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone 7
* Windows Phone 7.5
## Topics
* Windows Phone 7
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:52:41
## Description

<h1>Windows Phone 7 Sample: CSWP7CustomStyleButton</h1>
<h2>Introduction<span> </span></h2>
<p class="MsoNormal"><span>This sample demonstrates how to create your own style button. You do not need to use any additional tool besides Visual Studio 2010. Custom button images are not required. Use XAML only to create beautiful buttons or even buttons
 that appear similar to those used in other products such as the iPhone. </span></p>
<p class="MsoNormal">To&nbsp;run&nbsp;the&nbsp;sample:<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
1.&nbsp;Open&nbsp;the&nbsp;project&nbsp;in&nbsp;Visual&nbsp;Studio&nbsp;2010<span>.</span><br>
2.&nbsp;Press&nbsp;Ctrl&#43;F5.<span> </span></p>
<p class="MsoNormal"><span>You will see a button like this:<br>
</span><span><img src="/site/view/file/57681/1/image.png" alt="" width="303" height="101" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>When you press the button, it changes to:<br>
</span><span><img src="/site/view/file/57682/1/image.png" alt="" width="304" height="101" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span>1.&nbsp;Create&nbsp;a&nbsp;new&nbsp;��Silverlight&nbsp;for&nbsp;Windows&nbsp;Phone�� project.
</span></p>
<p class="MsoNormal"><span>2.&nbsp;Add&nbsp;xmlns:vsm=&quot;clr-namespace:System.Windows;assembly=System.Windows&quot;&nbsp;to&nbsp;the&nbsp;root&nbsp;element.&nbsp;The&nbsp;xaml&nbsp;code&nbsp;in&nbsp;MainPage.xaml&nbsp;will&nbsp;be&nbsp;look like&nbsp;this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;phone:PhoneApplicationPage 
    x:Class=&quot;CSWP7CustomStyleButton.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:vsm=&quot;clr-namespace:System.Windows;assembly=System.Windows&quot;
    mc:Ignorable=&quot;d&quot; d:DesignWidth=&quot;480&quot; d:DesignHeight=&quot;768&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;&gt;


    &lt;UserControl.Resources&gt;
        &lt;Style x:Key=&quot;metroLight&quot; TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Background&quot; Value=&quot;DarkRed&quot;/&gt;
            &lt;Setter Property=&quot;Padding&quot; Value=&quot;3&quot;/&gt;
            &lt;Setter Property=&quot;BorderThickness&quot; Value=&quot;0&quot;/&gt;


            &lt;Setter Property=&quot;Template&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;
                        &lt;Grid&gt;
                            &lt;vsm:VisualStateManager.VisualStateGroups&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;CommonStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Normal&quot;&gt;
                                        &lt;!--&lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames BeginTime=&quot;00:00:00&quot; 
                                                                           Storyboard.TargetName=&quot;glow&quot; 
                                                                           Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;00:00:00.1000000&quot; 
                                                                      Value=&quot;1&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;--&gt;
                                    &lt;/vsm:VisualState&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Pressed&quot;&gt;
                                        &lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames BeginTime=&quot;00:00:00&quot; 
                                                                           Storyboard.TargetName=&quot;glow&quot; 
                                                                           Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;00:00:00.1000000&quot; 
                                                                      Value=&quot;1&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;
                                    &lt;/vsm:VisualState&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                            &lt;/vsm:VisualStateManager.VisualStateGroups&gt;


                            &lt;Border x:Name=&quot;border&quot; Background=&quot;DarkRed&quot; 
                                    BorderBrush=&quot;#FF000000&quot; 
                                    BorderThickness=&quot;0,0,0,0&quot; CornerRadius=&quot;0,0,0,0&quot;&gt;
                                &lt;Grid&gt;
                                    &lt;Grid.RowDefinitions&gt;
                                        &lt;RowDefinition Height=&quot;0.507*&quot;/&gt;
                                        &lt;RowDefinition Height=&quot;0.493*&quot;/&gt;
                                    &lt;/Grid.RowDefinitions&gt;


                                    &lt;Border Opacity=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; 
                                            x:Name=&quot;glow&quot; Width=&quot;Auto&quot; 
                                            Grid.RowSpan=&quot;2&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                        &lt;Border.Background&gt;
                                            &lt;RadialGradientBrush&gt;
                                                &lt;RadialGradientBrush.RelativeTransform&gt;
                                                    &lt;TransformGroup&gt;
                                                        &lt;ScaleTransform ScaleX=&quot;1.702&quot; ScaleY=&quot;2.243&quot;/&gt;
                                                        &lt;SkewTransform AngleX=&quot;0&quot; AngleY=&quot;0&quot;/&gt;
                                                        &lt;RotateTransform Angle=&quot;0&quot;/&gt;
                                                        &lt;TranslateTransform X=&quot;-0.368&quot; Y=&quot;-0.152&quot;/&gt;
                                                    &lt;/TransformGroup&gt;
                                                &lt;/RadialGradientBrush.RelativeTransform&gt;
                                                &lt;GradientStop Color=&quot;#B28DBDFF&quot; Offset=&quot;0&quot;/&gt;
                                                &lt;GradientStop Color=&quot;#008DBDFF&quot; Offset=&quot;1&quot;/&gt;
                                            &lt;/RadialGradientBrush&gt;
                                        &lt;/Border.Background&gt;
                                    &lt;/Border&gt;


                                    &lt;ContentPresenter HorizontalAlignment=&quot;Center&quot; 
                                                        VerticalAlignment=&quot;Center&quot; 
                                                        Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot;/&gt;


                                    &lt;Border HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;0,0,0,0&quot; 
                                            x:Name=&quot;shine&quot; Width=&quot;Auto&quot; CornerRadius=&quot;4,4,0,0&quot;&gt;
                                    &lt;/Border&gt;
                                &lt;/Grid&gt;
                            &lt;/Border&gt;
                        &lt;/Grid&gt;
                    &lt;/ControlTemplate&gt;
                &lt;/Setter.Value&gt;
            &lt;/Setter&gt;
        &lt;/Style&gt;
    &lt;/UserControl.Resources&gt;
    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
    &lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
        &lt;Grid.Background&gt;
            &lt;ImageBrush ImageSource=&quot;BG.jpg&quot;&gt;&lt;/ImageBrush&gt;
        &lt;/Grid.Background&gt;
        &lt;!--TitlePanel contains the name of the application--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Custom Style Button&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;
        &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
            &lt;Button Width=&quot;300&quot; Height=&quot;100&quot; Content=&quot;Metro Light&quot;
                        Style=&quot;{StaticResource metroLight}&quot;&gt;
            &lt;/Button&gt;
        &lt;/Grid&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;


</pre>
<pre id="codePreview" class="xaml">&lt;phone:PhoneApplicationPage 
    x:Class=&quot;CSWP7CustomStyleButton.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:vsm=&quot;clr-namespace:System.Windows;assembly=System.Windows&quot;
    mc:Ignorable=&quot;d&quot; d:DesignWidth=&quot;480&quot; d:DesignHeight=&quot;768&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;&gt;


    &lt;UserControl.Resources&gt;
        &lt;Style x:Key=&quot;metroLight&quot; TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Background&quot; Value=&quot;DarkRed&quot;/&gt;
            &lt;Setter Property=&quot;Padding&quot; Value=&quot;3&quot;/&gt;
            &lt;Setter Property=&quot;BorderThickness&quot; Value=&quot;0&quot;/&gt;


            &lt;Setter Property=&quot;Template&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;
                        &lt;Grid&gt;
                            &lt;vsm:VisualStateManager.VisualStateGroups&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;CommonStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Normal&quot;&gt;
                                        &lt;!--&lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames BeginTime=&quot;00:00:00&quot; 
                                                                           Storyboard.TargetName=&quot;glow&quot; 
                                                                           Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;00:00:00.1000000&quot; 
                                                                      Value=&quot;1&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;--&gt;
                                    &lt;/vsm:VisualState&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Pressed&quot;&gt;
                                        &lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames BeginTime=&quot;00:00:00&quot; 
                                                                           Storyboard.TargetName=&quot;glow&quot; 
                                                                           Storyboard.TargetProperty=&quot;(UIElement.Opacity)&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;00:00:00.1000000&quot; 
                                                                      Value=&quot;1&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;
                                    &lt;/vsm:VisualState&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                            &lt;/vsm:VisualStateManager.VisualStateGroups&gt;


                            &lt;Border x:Name=&quot;border&quot; Background=&quot;DarkRed&quot; 
                                    BorderBrush=&quot;#FF000000&quot; 
                                    BorderThickness=&quot;0,0,0,0&quot; CornerRadius=&quot;0,0,0,0&quot;&gt;
                                &lt;Grid&gt;
                                    &lt;Grid.RowDefinitions&gt;
                                        &lt;RowDefinition Height=&quot;0.507*&quot;/&gt;
                                        &lt;RowDefinition Height=&quot;0.493*&quot;/&gt;
                                    &lt;/Grid.RowDefinitions&gt;


                                    &lt;Border Opacity=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; 
                                            x:Name=&quot;glow&quot; Width=&quot;Auto&quot; 
                                            Grid.RowSpan=&quot;2&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                        &lt;Border.Background&gt;
                                            &lt;RadialGradientBrush&gt;
                                                &lt;RadialGradientBrush.RelativeTransform&gt;
                                                    &lt;TransformGroup&gt;
                                                        &lt;ScaleTransform ScaleX=&quot;1.702&quot; ScaleY=&quot;2.243&quot;/&gt;
                                                        &lt;SkewTransform AngleX=&quot;0&quot; AngleY=&quot;0&quot;/&gt;
                                                        &lt;RotateTransform Angle=&quot;0&quot;/&gt;
                                                        &lt;TranslateTransform X=&quot;-0.368&quot; Y=&quot;-0.152&quot;/&gt;
                                                    &lt;/TransformGroup&gt;
                                                &lt;/RadialGradientBrush.RelativeTransform&gt;
                                                &lt;GradientStop Color=&quot;#B28DBDFF&quot; Offset=&quot;0&quot;/&gt;
                                                &lt;GradientStop Color=&quot;#008DBDFF&quot; Offset=&quot;1&quot;/&gt;
                                            &lt;/RadialGradientBrush&gt;
                                        &lt;/Border.Background&gt;
                                    &lt;/Border&gt;


                                    &lt;ContentPresenter HorizontalAlignment=&quot;Center&quot; 
                                                        VerticalAlignment=&quot;Center&quot; 
                                                        Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot;/&gt;


                                    &lt;Border HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;0,0,0,0&quot; 
                                            x:Name=&quot;shine&quot; Width=&quot;Auto&quot; CornerRadius=&quot;4,4,0,0&quot;&gt;
                                    &lt;/Border&gt;
                                &lt;/Grid&gt;
                            &lt;/Border&gt;
                        &lt;/Grid&gt;
                    &lt;/ControlTemplate&gt;
                &lt;/Setter.Value&gt;
            &lt;/Setter&gt;
        &lt;/Style&gt;
    &lt;/UserControl.Resources&gt;
    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
    &lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
        &lt;Grid.Background&gt;
            &lt;ImageBrush ImageSource=&quot;BG.jpg&quot;&gt;&lt;/ImageBrush&gt;
        &lt;/Grid.Background&gt;
        &lt;!--TitlePanel contains the name of the application--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Custom Style Button&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;
        &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
            &lt;Button Width=&quot;300&quot; Height=&quot;100&quot; Content=&quot;Metro Light&quot;
                        Style=&quot;{StaticResource metroLight}&quot;&gt;
            &lt;/Button&gt;
        &lt;/Grid&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;


</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span>For more information about how to create custom Silverlight style, please also see this link:
<br>
<a href="http://www.silverlight.net/learn/creating-ui/styles-and-templates/control-styles-(silverlight-quickstart)">http://www.silverlight.net/learn/creating-ui/styles-and-templates/control-styles-(silverlight-quickstart)</a>
</span></p>
<p class="MsoNormal"><span>The project can be opened and the user interface can be edited using Expression Blend. For more information about how to use Blend, this article would be helpful:<br>
</span><a href="http://blogs.msdn.com/b/silverlight/archive/2010/10/25/expression-blend-4-for-windows-phone.aspx">http://blogs.msdn.com/b/silverlight/archive/2010/10/25/expression-blend-4-for-windows-phone.aspx</a><span>
</span></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
