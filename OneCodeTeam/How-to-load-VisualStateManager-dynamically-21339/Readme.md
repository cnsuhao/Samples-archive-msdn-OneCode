# How to load VisualStateManager dynamically
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows 8
## Topics
* windows8
* VisualStateManager
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:05:16
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1>How to <span>load VisualStateManager Dynamically</span> (<span>VB</span>WindowsStoreApp<span>LoadVisualStateManager</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span>This sample demonstrates how to load VisualStateManager dynamically and attach it to the page at runtime
</span></p>
<h2>Build the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio 2012 and select File &gt; Open &gt; Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you download the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution(.sln) file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F7 or use Build &gt; Build Solution to build the sample.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the sample is launched, <span>the screen will display this.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/78737/1/image.png" alt="" width="927" height="524" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>You can change the app to snap view. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/78738/1/image.png" alt="" width="928" height="524" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below <span>is the ResourceDictionaryPage which contains the VisualStateGroup
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- This page should be set as Embedded Resource--&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ResourceDictionary
&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp; xmlns:local=&quot;using:CSWindowsStoreAppLoadVisualStateManager.VisualStateResources&quot;&gt;


&nbsp;&nbsp;&nbsp; &lt;!-- Visual states reflect the application's view state --&gt;
&nbsp;&nbsp;&nbsp; &lt;VisualStateGroup x:Name=&quot;ApplicationViewStates&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;FullScreenLandscape&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&lt;VisualState x:Name=&quot;Filled&quot;/&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- The entire page respects the narrower 100-pixel margin convention for portrait --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;FullScreenPortrait&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.Margin)&quot; Storyboard.TargetName=&quot;contentRoot&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Thickness&gt;20,20,20,20&lt;/Thickness&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/VisualState&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- The back button and title have different styles when snapped --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;Snapped&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;FullScreenViewBox&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Collapsed&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;SnapViewBox&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Visible&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;titleGrid&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Collapsed&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.Margin)&quot; Storyboard.TargetName=&quot;contentRoot&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Thickness&gt;20,20,20,20&lt;/Thickness&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.HorizontalAlignment)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;HorizontalAlignment&gt;Left&lt;/HorizontalAlignment&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(Grid.Row)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(Grid.Column)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/VisualState&gt;
&nbsp;&nbsp;&nbsp; &lt;/VisualStateGroup&gt;


&lt;/ResourceDictionary&gt;

</pre>
<pre id="codePreview" class="xaml">&lt;!-- This page should be set as Embedded Resource--&gt;
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ResourceDictionary
&nbsp;&nbsp;&nbsp; xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
&nbsp;&nbsp;&nbsp; xmlns:local=&quot;using:CSWindowsStoreAppLoadVisualStateManager.VisualStateResources&quot;&gt;


&nbsp;&nbsp;&nbsp; &lt;!-- Visual states reflect the application's view state --&gt;
&nbsp;&nbsp;&nbsp; &lt;VisualStateGroup x:Name=&quot;ApplicationViewStates&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;FullScreenLandscape&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&lt;VisualState x:Name=&quot;Filled&quot;/&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- The entire page respects the narrower 100-pixel margin convention for portrait --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;FullScreenPortrait&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.Margin)&quot; Storyboard.TargetName=&quot;contentRoot&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Thickness&gt;20,20,20,20&lt;/Thickness&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/VisualState&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!-- The back button and title have different styles when snapped --&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;VisualState x:Name=&quot;Snapped&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;FullScreenViewBox&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Collapsed&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;SnapViewBox&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Visible&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetName=&quot;titleGrid&quot; Storyboard.TargetProperty=&quot;Visibility&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;Collapsed&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.Margin)&quot; Storyboard.TargetName=&quot;contentRoot&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Thickness&gt;20,20,20,20&lt;/Thickness&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(FrameworkElement.HorizontalAlignment)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;HorizontalAlignment&gt;Left&lt;/HorizontalAlignment&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame.Value&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DiscreteObjectKeyFrame&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(Grid.Row)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=&quot;(Grid.Column)&quot; Storyboard.TargetName=&quot;FooterPanel&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DiscreteObjectKeyFrame KeyTime=&quot;0&quot; Value=&quot;0&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ObjectAnimationUsingKeyFrames&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Storyboard&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/VisualState&gt;
&nbsp;&nbsp;&nbsp; &lt;/VisualStateGroup&gt;


&lt;/ResourceDictionary&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><a name="OLE_LINK1"></a><a name="OLE_LINK2"><span>The code below
</span></a><span><span><span>is used to load VisualStateManager and attach it to the page
</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public NotInheritable Class LoadVisualStateManager
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Shared Sub AttachVisualStateGroups(RootGrid As Grid, Optional VisualStateGroupKey As String = &quot;ApplicationViewStates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;' Creates a VisualStateManager and attaches it to the RootGrid in GroupedItemsPage.xaml
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim manager As New VisualStateManager()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VisualStateManager.SetCustomVisualStateManager(RootGrid, manager)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Gets a reference to the VisualStateGroup collection that now exists in the RootGrid (thanks to the above code)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim states As IList(Of VisualStateGroup) = VisualStateManager.GetVisualStateGroups(RootGrid)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Dynamically loads the ResourceDictionary that contains the VisualState XAML
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim loadedResource As ResourceDictionary = GetVisualStateXaml()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the VisualStateGroup from Resource Dictionary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim vsgDynamic As VisualStateGroup = TryCast(loadedResource(VisualStateGroupKey), VisualStateGroup)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; loadedResource.Clear()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the dynamically loaded VisualState into the RootGrid's VisualStateGroup's collection
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; states.Add(vsgDynamic)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private Shared Function GetVisualStateXaml() As ResourceDictionary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the namespace for this class that lives in the same namespace location as the ResourceDictionary 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim RunTimeNamespace = GetType(LoadVisualStateManager).GetTypeInfo().[Namespace]


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Load the resource dictionary into a stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ResourceDictionaryFilename As String = &quot;VisualStatePage.xaml&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim resource As Stream = GetType(LoadVisualStateManager).GetTypeInfo().Assembly.GetManifestResourceStream(Convert.ToString(RunTimeNamespace) &amp; &quot;.&quot; &amp; ResourceDictionaryFilename)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an instance of a ResourceDictionary from the resource Stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim loadedResource As ResourceDictionary = TryCast(XamlReader.Load(New StreamReader(resource).ReadToEnd()), ResourceDictionary)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return loadedResource
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function
&nbsp;&nbsp;&nbsp; End Class

</pre>
<pre id="codePreview" class="vb">Public NotInheritable Class LoadVisualStateManager
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Shared Sub AttachVisualStateGroups(RootGrid As Grid, Optional VisualStateGroupKey As String = &quot;ApplicationViewStates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;' Creates a VisualStateManager and attaches it to the RootGrid in GroupedItemsPage.xaml
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim manager As New VisualStateManager()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VisualStateManager.SetCustomVisualStateManager(RootGrid, manager)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Gets a reference to the VisualStateGroup collection that now exists in the RootGrid (thanks to the above code)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim states As IList(Of VisualStateGroup) = VisualStateManager.GetVisualStateGroups(RootGrid)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Dynamically loads the ResourceDictionary that contains the VisualState XAML
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim loadedResource As ResourceDictionary = GetVisualStateXaml()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the VisualStateGroup from Resource Dictionary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim vsgDynamic As VisualStateGroup = TryCast(loadedResource(VisualStateGroupKey), VisualStateGroup)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; loadedResource.Clear()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the dynamically loaded VisualState into the RootGrid's VisualStateGroup's collection
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; states.Add(vsgDynamic)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private Shared Function GetVisualStateXaml() As ResourceDictionary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Get the namespace for this class that lives in the same namespace location as the ResourceDictionary 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim RunTimeNamespace = GetType(LoadVisualStateManager).GetTypeInfo().[Namespace]


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Load the resource dictionary into a stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ResourceDictionaryFilename As String = &quot;VisualStatePage.xaml&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim resource As Stream = GetType(LoadVisualStateManager).GetTypeInfo().Assembly.GetManifestResourceStream(Convert.ToString(RunTimeNamespace) &amp; &quot;.&quot; &amp; ResourceDictionaryFilename)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an instance of a ResourceDictionary from the resource Stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim loadedResource As ResourceDictionary = TryCast(XamlReader.Load(New StreamReader(resource).ReadToEnd()), ResourceDictionary)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return loadedResource
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function
&nbsp;&nbsp;&nbsp; End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span>VisualStateManager class (Windows) </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.visualstatemanager.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.visualstatemanager.aspx</a>
</span></p>
<p class="MsoNormal"><span>VisualStateManager.VisualStateGroups attached property (Windows)
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.visualstatemanager.visualstategroups.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.visualstatemanager.visualstategroups.aspx</a>
</span></p>
<p class="MsoNormal"><span>ResourceDictionary class (Windows) </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.resourcedictionary.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.resourcedictionary.aspx</a>
</span></p>
<p class="MsoNormal"><span>XamlReader class (Windows) </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.markup.xamlreader.aspx</a>
</span></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
