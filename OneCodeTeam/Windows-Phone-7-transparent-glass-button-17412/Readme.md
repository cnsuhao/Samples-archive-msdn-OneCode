# Windows Phone 7 transparent glass button (CSWP7GlassButton)
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
* 2012-06-24 11:24:52
## Description

<h1>Windows Phone 7 Glass Button (CSWP7GlassButton)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates a Windows Phone glass button. You can create your own transparent glass button base on this sample.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">To run this sample:</p>
<p class="MsoNormal">1. Open the project in Visual Studio 2010<br>
2. Press Ctrl&#43;F5</p>
<p class="MsoNormal">You will see a button like this:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/60165/1/image.png" alt="" width="249" height="116" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new &quot;Silverlight for Windows Phone&quot; project.<br>
2. <span style="">Add <span class="SpellE">xmlns<span class="GramE">:vsm</span></span>=&quot;<span class="SpellE">clr-namespace:System.Windows;assembly</span>=<span class="SpellE">System.Windows</span>&quot; to the root element. The
<span class="SpellE">xaml</span> code in <span class="SpellE">MainPage.xaml</span> will be look like this:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;phone:PhoneApplicationPage 
    x:Class=&quot;VBWP7GlassButton.MainPage&quot;
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
        &lt;Style x:Key=&quot;GlassButton&quot; TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Background&quot; Value=&quot;#FF1F3B53&quot;/&gt;
            &lt;Setter Property=&quot;Foreground&quot; Value=&quot;#FF000000&quot;/&gt;
            &lt;Setter Property=&quot;Padding&quot; Value=&quot;3&quot;/&gt;
            &lt;Setter Property=&quot;BorderThickness&quot; Value=&quot;1&quot;/&gt;
            &lt;Setter Property=&quot;BorderBrush&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
                        &lt;GradientStop Color=&quot;#FFA3AEB9&quot; Offset=&quot;0&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF8399A9&quot; Offset=&quot;0.375&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF718597&quot; Offset=&quot;0.375&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF617584&quot; Offset=&quot;1&quot;/&gt;
                    &lt;/LinearGradientBrush&gt;
                &lt;/Setter.Value&gt;
            &lt;/Setter&gt;
            &lt;Setter Property=&quot;Template&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;
                        &lt;Grid&gt;
                            &lt;vsm:VisualStateManager.VisualStateGroups&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;CommonStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Normal&quot;/&gt;


                                    &lt;vsm:VisualState x:Name=&quot;MouseOver&quot;&gt;
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


                                    &lt;vsm:VisualState x:Name=&quot;Disabled&quot;&gt;
                                        &lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames Storyboard.TargetName=&quot;DisabledVisualElement&quot; Storyboard.TargetProperty=&quot;Opacity&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;0&quot; Value=&quot;.55&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;
                                    &lt;/vsm:VisualState&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;FocusStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Focused&quot;&gt;
                                    &lt;/vsm:VisualState&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Unfocused&quot;/&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                            &lt;/vsm:VisualStateManager.VisualStateGroups&gt;


                            &lt;Border BorderBrush=&quot;#FFFFFFFF&quot; BorderThickness=&quot;1,1,1,1&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                &lt;Border x:Name=&quot;border&quot; Background=&quot;#7F000000&quot; BorderBrush=&quot;#FF000000&quot; BorderThickness=&quot;1,1,1,1&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                    &lt;Grid&gt;
                                        &lt;Grid.RowDefinitions&gt;
                                            &lt;RowDefinition Height=&quot;0.507*&quot;/&gt;
                                            &lt;RowDefinition Height=&quot;0.493*&quot;/&gt;
                                        &lt;/Grid.RowDefinitions&gt;
                                        &lt;Border Opacity=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; x:Name=&quot;glow&quot; Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
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
                                        &lt;ContentPresenter HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot; Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot;/&gt;
                                        &lt;Border HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;0,0,0,0&quot; x:Name=&quot;shine&quot; Width=&quot;Auto&quot; CornerRadius=&quot;4,4,0,0&quot;&gt;
                                            &lt;Border.Background&gt;
                                                &lt;LinearGradientBrush EndPoint=&quot;0.494,0.889&quot; StartPoint=&quot;0.494,0.028&quot;&gt;
                                                    &lt;GradientStop Color=&quot;#99FFFFFF&quot; Offset=&quot;0&quot;/&gt;
                                                    &lt;GradientStop Color=&quot;#33FFFFFF&quot; Offset=&quot;1&quot;/&gt;
                                                &lt;/LinearGradientBrush&gt;
                                            &lt;/Border.Background&gt;
                                        &lt;/Border&gt;
                                    &lt;/Grid&gt;
                                &lt;/Border&gt;
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


        &lt;!--TitlePanel contains the name of the application and page title--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Glass Button&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;


        &lt;!--ContentPanel - place additional content here--&gt;
        &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
            &lt;Button Width=&quot;300&quot; Height=&quot;100&quot; Content=&quot;Metro Glass&quot; Foreground=&quot;#FFFFFFFF&quot; 
                        Style=&quot;{StaticResource GlassButton}&quot;/&gt;
        &lt;/Grid&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;phone:PhoneApplicationPage 
    x:Class=&quot;VBWP7GlassButton.MainPage&quot;
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
        &lt;Style x:Key=&quot;GlassButton&quot; TargetType=&quot;Button&quot;&gt;
            &lt;Setter Property=&quot;Background&quot; Value=&quot;#FF1F3B53&quot;/&gt;
            &lt;Setter Property=&quot;Foreground&quot; Value=&quot;#FF000000&quot;/&gt;
            &lt;Setter Property=&quot;Padding&quot; Value=&quot;3&quot;/&gt;
            &lt;Setter Property=&quot;BorderThickness&quot; Value=&quot;1&quot;/&gt;
            &lt;Setter Property=&quot;BorderBrush&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;LinearGradientBrush EndPoint=&quot;0.5,1&quot; StartPoint=&quot;0.5,0&quot;&gt;
                        &lt;GradientStop Color=&quot;#FFA3AEB9&quot; Offset=&quot;0&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF8399A9&quot; Offset=&quot;0.375&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF718597&quot; Offset=&quot;0.375&quot;/&gt;
                        &lt;GradientStop Color=&quot;#FF617584&quot; Offset=&quot;1&quot;/&gt;
                    &lt;/LinearGradientBrush&gt;
                &lt;/Setter.Value&gt;
            &lt;/Setter&gt;
            &lt;Setter Property=&quot;Template&quot;&gt;
                &lt;Setter.Value&gt;
                    &lt;ControlTemplate TargetType=&quot;Button&quot;&gt;
                        &lt;Grid&gt;
                            &lt;vsm:VisualStateManager.VisualStateGroups&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;CommonStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Normal&quot;/&gt;


                                    &lt;vsm:VisualState x:Name=&quot;MouseOver&quot;&gt;
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


                                    &lt;vsm:VisualState x:Name=&quot;Disabled&quot;&gt;
                                        &lt;Storyboard&gt;
                                            &lt;DoubleAnimationUsingKeyFrames Storyboard.TargetName=&quot;DisabledVisualElement&quot; Storyboard.TargetProperty=&quot;Opacity&quot;&gt;
                                                &lt;SplineDoubleKeyFrame KeyTime=&quot;0&quot; Value=&quot;.55&quot;/&gt;
                                            &lt;/DoubleAnimationUsingKeyFrames&gt;
                                        &lt;/Storyboard&gt;
                                    &lt;/vsm:VisualState&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                                &lt;vsm:VisualStateGroup x:Name=&quot;FocusStates&quot;&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Focused&quot;&gt;
                                    &lt;/vsm:VisualState&gt;
                                    &lt;vsm:VisualState x:Name=&quot;Unfocused&quot;/&gt;
                                &lt;/vsm:VisualStateGroup&gt;
                            &lt;/vsm:VisualStateManager.VisualStateGroups&gt;


                            &lt;Border BorderBrush=&quot;#FFFFFFFF&quot; BorderThickness=&quot;1,1,1,1&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                &lt;Border x:Name=&quot;border&quot; Background=&quot;#7F000000&quot; BorderBrush=&quot;#FF000000&quot; BorderThickness=&quot;1,1,1,1&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
                                    &lt;Grid&gt;
                                        &lt;Grid.RowDefinitions&gt;
                                            &lt;RowDefinition Height=&quot;0.507*&quot;/&gt;
                                            &lt;RowDefinition Height=&quot;0.493*&quot;/&gt;
                                        &lt;/Grid.RowDefinitions&gt;
                                        &lt;Border Opacity=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; x:Name=&quot;glow&quot; Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot; CornerRadius=&quot;4,4,4,4&quot;&gt;
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
                                        &lt;ContentPresenter HorizontalAlignment=&quot;Center&quot; VerticalAlignment=&quot;Center&quot; Width=&quot;Auto&quot; Grid.RowSpan=&quot;2&quot;/&gt;
                                        &lt;Border HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;0,0,0,0&quot; x:Name=&quot;shine&quot; Width=&quot;Auto&quot; CornerRadius=&quot;4,4,0,0&quot;&gt;
                                            &lt;Border.Background&gt;
                                                &lt;LinearGradientBrush EndPoint=&quot;0.494,0.889&quot; StartPoint=&quot;0.494,0.028&quot;&gt;
                                                    &lt;GradientStop Color=&quot;#99FFFFFF&quot; Offset=&quot;0&quot;/&gt;
                                                    &lt;GradientStop Color=&quot;#33FFFFFF&quot; Offset=&quot;1&quot;/&gt;
                                                &lt;/LinearGradientBrush&gt;
                                            &lt;/Border.Background&gt;
                                        &lt;/Border&gt;
                                    &lt;/Grid&gt;
                                &lt;/Border&gt;
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


        &lt;!--TitlePanel contains the name of the application and page title--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Glass Button&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;


        &lt;!--ContentPanel - place additional content here--&gt;
        &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,0,12,0&quot;&gt;
            &lt;Button Width=&quot;300&quot; Height=&quot;100&quot; Content=&quot;Metro Glass&quot; Foreground=&quot;#FFFFFFFF&quot; 
                        Style=&quot;{StaticResource GlassButton}&quot;/&gt;
        &lt;/Grid&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style="">For more information about how to create custom Silverlight style, please also see this link:
<br>
<a href="http://www.silverlight.net/learn/creating-ui/styles-and-templates/control-styles-(silverlight-quickstart)">http://www.silverlight.net/learn/creating-ui/styles-and-templates/control-styles-(silverlight-quickstart)</a>
</span></p>
<p class="MsoNormal"><span style="">The project can be opened and the user interface can be edited using Expression Blend. For more information about how to use Blend, this article would be helpful<span class="GramE">:</span><br>
</span><a href="http://blogs.msdn.com/b/silverlight/archive/2010/10/25/expression-blend-4-for-windows-phone.aspx">http://blogs.msdn.com/b/silverlight/archive/2010/10/25/expression-blend-4-for-windows-phone.aspx</a><span style="">
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
