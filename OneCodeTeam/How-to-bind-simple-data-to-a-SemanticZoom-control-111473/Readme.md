# How to bind simple data to a SemanticZoom control in universal Windows apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows Phone 8
* Windows Store app
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
## Topics
* Semantic zoom
* universal app
## IsPublished
* True
## ModifiedDate
* 2015-01-05 12:30:10
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to bind simple data to a SemanticZoom control in a Universal app</h1>
<h2>Introduction</h2>
<p>There&rsquo;s an official sample for SemanticZoom control, but it&rsquo;s overly difficult to learn with complicated data struct. So this sample will show you how to bind simple data to a SemanticZoom control. Besides, this sample is based on
<a href="http://blogs.msdn.com/391897/ProfileUrlRedirect.ashx">Matt Small</a>&rsquo;s blog:
<a href="http://blogs.msdn.com/b/wsdevsol/archive/2014/09/18/a-simple-semanticzoom.aspx">
http://blogs.msdn.com/b/wsdevsol/archive/2014/09/18/a-simple-semanticzoom.aspx</a>.</p>
<h2>Running the Sample</h2>
<p>Build the sample in Visual Studio 2013 and then run it.</p>
<h2>Using the Code</h2>
<p>The Semantic Zoom consists of two parts:</p>
<p><strong>ZoomedOutView</strong></p>
<p>The XAML code that goes along with this is rather simple:&nbsp; a gridview bound to a CollectionViewSource that hosts the grouped data:</p>
<p><span style="font-size:10px">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;SemanticZoom.ZoomedOutView&gt;

    &lt;GridView x:Name=&quot;MySZ_ZoomedOutGridView&quot; SelectionMode=&quot;None&quot; IsItemClickEnabled=&quot;True&quot; VerticalAlignment=&quot;Top&quot;&gt;

        &lt;GridView.ItemTemplate&gt;

            &lt;DataTemplate&gt;

                &lt;Border BorderBrush=&quot;White&quot; BorderThickness=&quot;1&quot;&gt;

                    &lt;StackPanel Margin=&quot;10&quot;&gt;

                        &lt;TextBlock Text=&quot;{Binding Group.Language}&quot;  FontSize=&quot;22&quot; /&gt;

                        &lt;StackPanel Orientation=&quot;Horizontal&quot; MinWidth=&quot;150&quot;&gt;

                            &lt;TextBlock Text=&quot;No. Available:&amp;#160;&quot;/&gt;

                            &lt;TextBlock Text=&quot;{Binding Group.Speakers.Count}&quot;/&gt;

                        &lt;/StackPanel&gt;

                    &lt;/StackPanel&gt;

                &lt;/Border&gt;

            &lt;/DataTemplate&gt;

        &lt;/GridView.ItemTemplate&gt;

        &lt;GridView.ItemsPanel&gt;

            &lt;ItemsPanelTemplate&gt;

                &lt;StackPanel Orientation=&quot;Horizontal&quot;/&gt;

            &lt;/ItemsPanelTemplate&gt;

        &lt;/GridView.ItemsPanel&gt;

    &lt;/GridView&gt;

&lt;/SemanticZoom.ZoomedOutView&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;SemanticZoom</span>.ZoomedOutView<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;MySZ_ZoomedOutGridView&quot;</span>&nbsp;<span class="xaml__attr_name">SelectionMode</span>=<span class="xaml__attr_value">&quot;None&quot;</span>&nbsp;<span class="xaml__attr_name">IsItemClickEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Border</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;1&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Group.Language}&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;22&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span>&nbsp;<span class="xaml__attr_name">MinWidth</span>=<span class="xaml__attr_value">&quot;150&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;No.&nbsp;Available:&amp;#160;&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Group.Speakers.Count}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Border&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridView.ItemTemplate&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>.ItemsPanel<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ItemsPanelTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ItemsPanelTemplate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridView.ItemsPanel&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridView&gt;</span>&nbsp;
&nbsp;
&lt;/SemanticZoom.ZoomedOutView&gt;</pre>
</div>
</div>
</div>
<p><strong>ZoomedInView</strong></p>
<p>The XAML code for this is slightly more complicated - we use not only the data for the items, but we also must work with the groups and the headers for those groups:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;SemanticZoom.ZoomedInView&gt;

    &lt;GridView x:Name=&quot;MySZ_ZoomedInGridView&quot; ItemsSource=&quot;{Binding Source={StaticResource MyCollectionViewSource}}&quot; 

      IsSynchronizedWithCurrentItem=&quot;False&quot; SelectionChanged=&quot;MySZ_ZoomedInGridView_SelectionChanged&quot;  VerticalAlignment=&quot;Top&quot;&gt;

        &lt;GridView.ItemTemplate&gt;

            &lt;DataTemplate&gt;

                &lt;StackPanel&gt;

                    &lt;TextBlock Text=&quot;{Binding Name}&quot; MinWidth=&quot;150&quot; Margin=&quot;10&quot;/&gt;

                &lt;/StackPanel&gt;

            &lt;/DataTemplate&gt;

        &lt;/GridView.ItemTemplate&gt;

        &lt;GridView.GroupStyle&gt;

            &lt;GroupStyle&gt;

                &lt;GroupStyle.HeaderTemplate&gt;

                    &lt;DataTemplate&gt;

                        &lt;Border BorderBrush=&quot;White&quot; BorderThickness=&quot;1&quot; MinWidth=&quot;150&quot;&gt;

                            &lt;TextBlock Text=&quot;{Binding Language}&quot;  FontSize=&quot;22&quot; Margin=&quot;10&quot;/&gt;

                        &lt;/Border&gt;

                    &lt;/DataTemplate&gt;

                &lt;/GroupStyle.HeaderTemplate&gt;

            &lt;/GroupStyle&gt;

        &lt;/GridView.GroupStyle&gt;

    &lt;/GridView&gt;

&lt;/SemanticZoom.ZoomedInView&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;SemanticZoom</span>.ZoomedInView<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;MySZ_ZoomedInGridView&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;MyCollectionViewSource}}&quot;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IsSynchronizedWithCurrentItem</span>=<span class="xaml__attr_value">&quot;False&quot;</span>&nbsp;<span class="xaml__attr_name">SelectionChanged</span>=<span class="xaml__attr_value">&quot;MySZ_ZoomedInGridView_SelectionChanged&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;<span class="xaml__attr_name">MinWidth</span>=<span class="xaml__attr_value">&quot;150&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridView.ItemTemplate&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span>.GroupStyle<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GroupStyle</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GroupStyle</span>.HeaderTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Border</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">BorderThickness</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">MinWidth</span>=<span class="xaml__attr_value">&quot;150&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Language}&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;22&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Border&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GroupStyle.HeaderTemplate&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GroupStyle&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridView.GroupStyle&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridView&gt;</span>&nbsp;
&nbsp;
&lt;/SemanticZoom.ZoomedInView&gt;<span style="font-size:10px">&nbsp;</span></pre>
</div>
</div>
</div>
<p>This is the data structure we're using:</p>
<ul>
<li><strong>Speaker</strong>- the customer is a class (implements INotifiyPropertyChanged) that consists of a name (string), and a collection of languages (list&lt;string&gt;) known by that customer.&nbsp; This is a sample Customer:&nbsp;<br>
&nbsp; Customer:&nbsp;<br>
&nbsp;&nbsp;&nbsp; Name: Johnny&nbsp;<br>
&nbsp;&nbsp;&nbsp; Languages: Spanish&nbsp; </li><li><strong>LanguageGroup</strong>- the LanguageGroup contains the name of the language of that group (string) and collection of members of that group(ObservableCollection&lt;Speaker&gt;).&nbsp; In this app, I add a new group (Speakers) for every language,
 and add every Speaker who knows that language.&nbsp; This is a sample LanguageGroup :&nbsp;<br>
&nbsp; LanguageGroup:&nbsp;<br>
&nbsp;&nbsp;&nbsp; Language: Spanish&nbsp;<br>
&nbsp;&nbsp;&nbsp; Speakers:&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customer&nbsp; - Johnny&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Customer - Jose&nbsp;
</li><li><strong>AllLanguageGroups</strong>- this is the final collection (ObservableCollection) which contains all of the LanguageGroups.&nbsp; This is the datasource for our CollectionViewSource.&nbsp;<br>
&nbsp; AllLanguageGroups:&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LanguageGroup: Spanish&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LanguageGroup: Arabic&nbsp; </li></ul>
<p>The most important thing we have to realize in binding the data is that the GridViews actually have difference datasources.&nbsp; This is how I set the datasources in the code:<span style="font-size:10px">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MyCollectionViewSource.Source = AllLanguageGroups;; 

MySZ_ZoomedOutGridView.ItemsSource = MyCollectionViewSource.View.CollectionGroups;</pre>
<div class="preview">
<pre class="csharp">MyCollectionViewSource.Source&nbsp;=&nbsp;AllLanguageGroups;;&nbsp;&nbsp;
&nbsp;
MySZ_ZoomedOutGridView.ItemsSource&nbsp;=&nbsp;MyCollectionViewSource.View.CollectionGroups;</pre>
</div>
</div>
</div>
<p>We are setting the source of the CollectionViewSource to AllLanguageGroups- the set of languages and all of its Speakers.&nbsp; The ItemsSource of the ZoomedInView is in turn set to the CollectionViewSource - we can't directly set the ItemsSource to the
 AllLanguageGroupsor we will lose the grouping capabilities that CollectionViewSources provide.&nbsp;</p>
<p>Next, we set the ItemsSource of the ZoomedOutView to the collection of Groups inside the CollectionViewSource - this is because the ZoomedOutView only uses the details of the groups themselves.&nbsp; Notice the XAML bindings we used in the ZoomedOutView:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;TextBlock Text=&quot;{Binding Group.Language}&quot; FontSize=&quot;22&quot; /&gt;

&lt;TextBlock Text=&quot;{Binding Group.Speakers.Count}&quot;/&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Group.Language}&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;22&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Group.Speakers.Count}&quot;</span><span class="xaml__tag_start">/&gt;</span><span style="font-size:10px">&nbsp;</span></pre>
</div>
</div>
</div>
<p>The bound information is actually the collection of groups.&nbsp; Along with that, we can dive into each group and get the individual details inside each group.&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>&nbsp;&nbsp;<a href="http://blogs.msdn.com/b/wsdevsol/archive/2014/09/18/a-simple-semanticzoom.aspx">A Simple SemanticZoom</a></p>
