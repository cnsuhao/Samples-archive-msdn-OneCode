# Two-level grouped data displayed in WPF (CSWPFTwoLevelGrouping)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:14:46
## Description

<p style="font-family:Courier New"></p>
<h2>WPF APPLICATION : CSWPFTwoLevelGrouping Project Overview<br>
<br>
WPF Two Level Grouping Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to display two level grouped data in WPF.<br>
&nbsp; <br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
<br>
1. Create a Student class with properties of ID, Name, Class, Grade, etc.<br>
<br>
2. Define a ListView with columns binding to each properties of the Student object;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ListView Margin=&quot;14,17,16,14&quot; Name=&quot;listView1&quot; ItemsSource=&quot;{Binding}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;....<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Set up columns --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ListView.View&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GridView&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GridViewColumn DisplayMemberBinding=&quot;{Binding ID}&quot; &nbsp; &nbsp;Header=&quot;ID&quot; &nbsp; &nbsp;Width=&quot;50&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GridViewColumn DisplayMemberBinding=&quot;{Binding Name}&quot; &nbsp;Header=&quot;Name&quot; &nbsp;Width=&quot;100&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GridViewColumn DisplayMemberBinding=&quot;{Binding Class}&quot; Header=&quot;Class&quot; Width=&quot;50&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GridViewColumn DisplayMemberBinding=&quot;{Binding Grade}&quot; Header=&quot;Grade&quot; Width=&quot;50&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/GridView&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/ListView.View&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/ListView&gt;<br>
&nbsp; &nbsp; <br>
3. Create a list of Student objects, and bind it to ListView.<br>
<br>
4. Define a style for each GroupItem.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Style for the first level GroupItem --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Style x:Key=&quot;GroupHeaderStyleForFirstLevel&quot; TargetType=&quot;{x:Type GroupItem}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Setter Property=&quot;Template&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Setter.Value&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ControlTemplate TargetType=&quot;{x:Type GroupItem}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Expander IsExpanded=&quot;True&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Expander.Header&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Text=&quot;{Binding Name}&quot; TextBlock.FontWeight=&quot;Bold&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Expander.Header&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ItemsPresenter /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Expander&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/ControlTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Setter.Value&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Setter&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Style&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;!-- Style for the second level GroupItem --&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Style x:Key=&quot;GroupHeaderStyleForSecondLevel&quot; TargetType=&quot;{x:Type GroupItem}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Setter Property=&quot;Template&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Setter.Value&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ControlTemplate TargetType=&quot;{x:Type GroupItem}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Expander IsExpanded=&quot;True&quot; Margin=&quot;15,0,0,0&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Expander.Header&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;TextBlock Text=&quot;{Binding Items[0].Class}&quot; TextBlock.FontWeight=&quot;Bold&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Expander.Header&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ItemsPresenter /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Expander&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/ControlTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Setter.Value&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Setter&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Style&gt; <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
<br>
5. Create a custom StyleSelector to select style for different level of GroupItem.<br>
<br>
&nbsp; &nbsp;public class GroupItemStyleSelector : StyleSelector<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;public override Style SelectStyle(object item, DependencyObject container)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Style s;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CollectionViewGroup group = item as CollectionViewGroup;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Window window = Application.Current.MainWindow;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!group.IsBottomLevel)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s = window.FindResource(&quot;GroupHeaderStyleForFirstLevel&quot;) as Style;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s = window.FindResource(&quot;GroupHeaderStyleForSecondLevel&quot;) as Style;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return s;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
6. Use the StyleSelector in the ListView.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;ListView Margin=&quot;14,17,16,14&quot; Name=&quot;listView1&quot; ItemsSource=&quot;{Binding}&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;ListView.GroupStyle&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;GroupStyle ContainerStyleSelector=&quot;{StaticResource groupItemStyleSelector}&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/ListView.GroupStyle&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;....<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/ListView&gt;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
&nbsp; <br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
