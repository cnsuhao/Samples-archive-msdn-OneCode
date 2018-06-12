# Silverlight 3 full screen feature demo (CSSL3FullScreen)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Full Screen
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:09:15
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3FullScreen Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to use the full screen feature in Silverlight 3.<br>
In addition, it demonstrates the keyboard limiation in full screen mode, how<br>
to get the size of Silverilght plug-in in full screen mode and how to subscribe<br>
FullScreenChanged event.<br>
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
A. Create the Silverlight project<br>
<br>
Step1. Create a Visual C# Silverlight Application project named CSSL3FullScreen<br>
in Visual Studio 2008 SP1.<br>
<br>
B. Edit MainPage.xaml<br>
<br>
Step1. Double click MainPage.xaml in the Solution Explorer window to view the <br>
xaml code. Replace &lt;Grid&gt; with the following code:<br>
<br>
&nbsp;&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;AliceBlue&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Grid.RowDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;2.3*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;1*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;3*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;RowDefinition Height=&quot;2*&quot;&gt;&lt;/RowDefinition&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Grid.RowDefinitions&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Please click the button below to switch to full-screen mode or embeded mode.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;LineBreak/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Please test the keyboard in both full-screen mode and embeded mode.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;LineBreak/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;All supported keys will be printed on the screen. In full-screen mode, the only<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;supported keys are:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;LineBreak/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;UP ARROW, DOWN ARROW, LEFT ARROW, RIGHT ARROW, SPACEBAR, TAB, PAGE UP, PAGE DOWN, HOME, END, ENTER<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/TextBlock&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Button IsTabStop=&quot;False&quot; Grid.Row=&quot;1&quot; Width=&quot;180&quot; Height=&quot;30&quot; Content=&quot;Full Screen Switch&quot; Click=&quot;Button_Click&quot;&gt;&lt;/Button&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock x:Name=&quot;TextBlockShowKeyboardInput&quot; Grid.Row=&quot;2&quot; FontSize=&quot;36&quot;&gt;&lt;/TextBlock&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock x:Name=&quot;TextBlockShowSize&quot; Grid.Row=&quot;3&quot; FontSize=&quot;20&quot;&gt;&lt;/TextBlock&gt;<br>
&nbsp; &nbsp;&lt;/Grid&gt;<br>
<br>
The above code mainly adds four controls:<br>
A TextBlock control to instruct you how to test the project.<br>
A Button control usded to swith to full screen mode or embeded mode.<br>
TextBlockShowKeyboardInput control (TextBlock) to show the keyboard input.<br>
TextBlockShowSize control (TextBlock) to show the size of Silverlight plug-in.<br>
<br>
Step2. Add KeyDown event for the &lt;UserControl&gt; to catch keyboard input, like below:<br>
<br>
&lt;UserControl x:Class=&quot;CSSL3FullScreen.MainPage&quot;<br>
&nbsp; &nbsp;xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;">http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</a>
<br>
&nbsp; &nbsp;xmlns:x=&quot;<a target="_blank" href="http://schemas.microsoft.com/winfx/2006/xaml&quot;">http://schemas.microsoft.com/winfx/2006/xaml&quot;</a><br>
&nbsp; &nbsp;xmlns:d=&quot;<a target="_blank" href="http://schemas.microsoft.com/expression/blend/2008&quot;">http://schemas.microsoft.com/expression/blend/2008&quot;</a> xmlns:mc=&quot;<a target="_blank" href="http://schemas.openxmlformats.org/markup-compatibility/2006&quot;">http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</a>
<br>
&nbsp; &nbsp;mc:Ignorable=&quot;d&quot; d:DesignWidth=&quot;640&quot; d:DesignHeight=&quot;480&quot; &nbsp; KeyDown=&quot;UserControl_KeyDown&quot;&gt;<br>
&nbsp; &nbsp;<br>
C. Edit MainPage.xaml.cs.<br>
<br>
Step1. Replace MainPage class with the following code.<br>
<br>
&nbsp; &nbsp;public partial class MainPage : UserControl<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public MainPage()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Attach the Loaded event to hook up events on load stage. &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Loaded &#43;= new RoutedEventHandler(MainPage_Loaded);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void MainPage_Loaded(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Attach events of SilverlightHost to subscribe the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// FullScreenChanged and Resized event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;App.Current.Host.Content.FullScreenChanged &#43;= new EventHandler(Content_FullScreenChanged);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;App.Current.Host.Content.Resized &#43;= new EventHandler(Content_Resized);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void Content_Resized(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// When content get resized, refresh TextBlockShowSize control to<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// show the size of the Silverlight plug-in. &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RefreshTextBlockShowSize();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void Content_FullScreenChanged(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{ <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// When full screen mode changed, refresh TextBlockShowSize
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// control to show the size of the Silverlight plug-in.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RefreshTextBlockShowSize();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void RefreshTextBlockShowSize()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Show the size of the Silverlight plug-in on TextBlockShowSize
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.TextBlockShowSize.Text = string.Format(&quot;{0}*{1}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;App.Current.Host.Content.ActualWidth,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;App.Current.Host.Content.ActualHeight);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void UserControl_KeyDown(object sender, KeyEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Show the input key on TextBlockShowKeyboardInput control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.TextBlockShowKeyboardInput.Text = e.Key.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Button_Click(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Switch to full screen mode or embeded mode.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;App.Current.Host.Content.IsFullScreen =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!App.Current.Host.Content.IsFullScreen;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Full-Screen Support<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc189023(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc189023(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
