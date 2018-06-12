# Navigation usage in WPF (CSWPFNavigationUsage)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:43:06
## Description

<h1><span style="">Navigation usage in WPF (CSWPFNavigationUsage) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
The sample demonstrates how to page data in WPF.<span style="">� </span>Method NavigationService.Navigate() is used to navigate to another page. The parameter needed is often a Uri, and can also be any custom classes.<span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54099/1/image.png" alt="" width="769" height="575" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create MainPage with some hyperlinks used to navigate.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Page1 and FramePage for navigating to, set FramePage�s source to �MainPage.xaml� so that in the framepage we�ll see another instance of MainPage.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add image or text Hyperlinks in MainPage.xaml so that we can click to navigate to other pages.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;StackPanel&gt;
������� &lt;!--use Hyperlink.NavigateUri property to navigate--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text =&quot;Navigate to&quot; VerticalAlignment =&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink� NavigateUri=&quot;Page1.xaml&quot;&gt;
����������������������� page1
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;using Hyperlink.NavigateUri property&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������ �&lt;!--use Hyperlink.NavigateUri property to navigate--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to Page1 using Hyperlink.NavigateUri property. Click the image to navigate to Page1:&quot; TextWrapping=&quot;Wrap&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink� NavigateUri=&quot;Page1.xaml&quot;&gt;
����������������������� &lt;Image Source=&quot;image.jpg&quot; Stretch=&quot;Uniform&quot; Height=&quot;100&quot; /&gt;
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������� &lt;!--handle Hyperlink.Click event and call NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink Click=&quot;OnHyperlink&quot;&gt;
���������������������� �Page1
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by handling the Hyperlink.Click event and calling the NavigationService.Navigate method.&quot; 
�����������������������VerticalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������ 
��������
��������&lt;!--navigate to object by calling NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink Click=&quot;OnNavagateToObject&quot;&gt;
����������������������� MyDummy object
������������������� &lt;/Hyperlink&gt;
�������������� �&lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by calling the NavigationService.Navigate method&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;
������� 
��������&lt;!--navigate to a Page with a Frame control in it by calling NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
���������� ���������&lt;Hyperlink Click=&quot;OnNavagateToPage&quot;&gt;
����������������������� Page with Frame
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by calling the NavigationService.Navigate method&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;
������� 
����&lt;/StackPanel&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;StackPanel&gt;
������� &lt;!--use Hyperlink.NavigateUri property to navigate--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text =&quot;Navigate to&quot; VerticalAlignment =&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink� NavigateUri=&quot;Page1.xaml&quot;&gt;
����������������������� page1
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;using Hyperlink.NavigateUri property&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������ �&lt;!--use Hyperlink.NavigateUri property to navigate--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to Page1 using Hyperlink.NavigateUri property. Click the image to navigate to Page1:&quot; TextWrapping=&quot;Wrap&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink� NavigateUri=&quot;Page1.xaml&quot;&gt;
����������������������� &lt;Image Source=&quot;image.jpg&quot; Stretch=&quot;Uniform&quot; Height=&quot;100&quot; /&gt;
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������� &lt;!--handle Hyperlink.Click event and call NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink Click=&quot;OnHyperlink&quot;&gt;
���������������������� �Page1
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by handling the Hyperlink.Click event and calling the NavigationService.Navigate method.&quot; 
�����������������������VerticalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;


������ 
��������
��������&lt;!--navigate to object by calling NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
������������������� &lt;Hyperlink Click=&quot;OnNavagateToObject&quot;&gt;
����������������������� MyDummy object
������������������� &lt;/Hyperlink&gt;
�������������� �&lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by calling the NavigationService.Navigate method&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;
������� 
��������&lt;!--navigate to a Page with a Frame control in it by calling NavigationService.Navigate method--&gt;
������� &lt;Border CornerRadius=&quot;10&quot; Background=&quot;Orange&quot; BorderThickness=&quot;2&quot; Padding=&quot;5&quot; Margin=&quot;5&quot;&gt;
����������� &lt;WrapPanel&gt;
��������������� &lt;TextBlock Text=&quot;Navigate to&quot; VerticalAlignment=&quot;Center&quot;/&gt;
��������������� &lt;Label&gt;
���������� ���������&lt;Hyperlink Click=&quot;OnNavagateToPage&quot;&gt;
����������������������� Page with Frame
������������������� &lt;/Hyperlink&gt;
��������������� &lt;/Label&gt;
��������������� &lt;TextBlock Text=&quot;by calling the NavigationService.Navigate method&quot; VerticalAlignment=&quot;Center&quot;/&gt;
����������� &lt;/WrapPanel&gt;
������� &lt;/Border&gt;
������� 
����&lt;/StackPanel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add hyperlinks� Click event handling methods in
<span class="SpellE">MainPage.xaml.cs</span>, <span class="SpellE">MainPage</span> will navigate to
<span class="GramE">a</span> Uri of Page1.xaml/<span class="SpellE">FramePage.xaml</span>, or navigate to the custom class
<span class="SpellE">MyDummy</span>. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void OnHyperlink(object sender, RoutedEventArgs e)
{
��� this.NavigationService.Navigate(new Uri(&quot;Page1.xaml&quot;, UriKind.Relative));
}
����� 
private void OnNavagateToObject(object sender, RoutedEventArgs e)
{
��� MyDummy obj = new MyDummy() { Property1 = &quot;Hello&quot;, Property2 = &quot;everyone&quot; };
��� this.NavigationService.Navigate(obj);
}
������ 
private void OnNavagateToPage(object sender, RoutedEventArgs e)
{
��� this.NavigationService.Navigate(new Uri(&quot;FramePage.xaml&quot;, UriKind.Relative));
}

</pre>
<pre id="codePreview" class="csharp">
private void OnHyperlink(object sender, RoutedEventArgs e)
{
��� this.NavigationService.Navigate(new Uri(&quot;Page1.xaml&quot;, UriKind.Relative));
}
����� 
private void OnNavagateToObject(object sender, RoutedEventArgs e)
{
��� MyDummy obj = new MyDummy() { Property1 = &quot;Hello&quot;, Property2 = &quot;everyone&quot; };
��� this.NavigationService.Navigate(obj);
}
������ 
private void OnNavagateToPage(object sender, RoutedEventArgs e)
{
��� this.NavigationService.Navigate(new Uri(&quot;FramePage.xaml&quot;, UriKind.Relative));
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"></p>
<p class="MsoNormal">Navigation Overview</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms750478(VS.90).aspx">http://msdn.microsoft.com/en-us/library/ms750478(VS.90).aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
