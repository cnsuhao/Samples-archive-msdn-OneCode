# How to create a GridView which auto adapt to different resolutions
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* GridView
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:18:48
## Description

<h1><span style="">How to create a custom GridView which can adapt to different resolutions (CSWindowsStoreAppAdaptToResolutionGridView)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to create a custom GridView which can adapt to different resolutions. We don't have to set the Max number of rows or columns, the GridViewItem will automatically go to next row if the current GridViewItem
 has reached the edge.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select&nbsp;File&nbsp;&gt;&nbsp;Open&nbsp;&gt;&nbsp;Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F6 or use&nbsp;Build&nbsp;&gt;&nbsp;Build Solution&nbsp;to build the sample.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After launching the sample, this screen will display. This resolution is 1366*768.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84423/1/image.png" alt="" width="576" height="327" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Please use the Simulator to change the resolution to higher resolution, the GridViewItem will automatically adapt to the resolution. This is the effect of 1920*1080 resolution.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84424/1/image.png" alt="" width="576" height="327" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to create the custom GridView which can adapt to different resolutions.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class AdaptableGridView : GridView
    {
        // default itemWidth
       private const double itemWidth = 100.00;
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }
        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register(&quot;ItemWidth&quot;, typeof(double), typeof(AdaptableGridView), new PropertyMetadata(itemWidth));
        
        // default max number of rows or columns
        private const int maxRowsOrColumns = 3;
        public int MaxRowsOrColumns
        {
            get { return (int)GetValue(MaxRowColProperty); }
            set { SetValue(MaxRowColProperty, value); }
        }
        public static readonly DependencyProperty MaxRowColProperty =
            DependencyProperty.Register(&quot;MaxRowsOrColumns&quot;, typeof(int), typeof(AdaptableGridView), new PropertyMetadata(maxRowsOrColumns));
        
        
        public AdaptableGridView()
        {
            this.SizeChanged &#43;= MyGridViewSizeChanged;
        }


        private void MyGridViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Calculate the proper max rows or columns based on new size 
            this.MaxRowsOrColumns = this.ItemWidth &gt; 0 ? Convert.ToInt32(Math.Floor(e.NewSize.Width / this.ItemWidth)) : maxRowsOrColumns;            
        }
    }

</pre>
<pre id="codePreview" class="csharp">
public class AdaptableGridView : GridView
    {
        // default itemWidth
       private const double itemWidth = 100.00;
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }
        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register(&quot;ItemWidth&quot;, typeof(double), typeof(AdaptableGridView), new PropertyMetadata(itemWidth));
        
        // default max number of rows or columns
        private const int maxRowsOrColumns = 3;
        public int MaxRowsOrColumns
        {
            get { return (int)GetValue(MaxRowColProperty); }
            set { SetValue(MaxRowColProperty, value); }
        }
        public static readonly DependencyProperty MaxRowColProperty =
            DependencyProperty.Register(&quot;MaxRowsOrColumns&quot;, typeof(int), typeof(AdaptableGridView), new PropertyMetadata(maxRowsOrColumns));
        
        
        public AdaptableGridView()
        {
            this.SizeChanged &#43;= MyGridViewSizeChanged;
        }


        private void MyGridViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Calculate the proper max rows or columns based on new size 
            this.MaxRowsOrColumns = this.ItemWidth &gt; 0 ? Convert.ToInt32(Math.Floor(e.NewSize.Width / this.ItemWidth)) : maxRowsOrColumns;            
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">The code below shows how to work with the custom GridView in xaml:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;local:AdaptableGridView x:Name=&quot;AGridView&quot; ItemWidth=&quot;250&quot; 
                          AutomationProperties.AutomationId=&quot;CustomerGridView&quot;
                          AutomationProperties.Name=&quot; Customers Group&quot;
                          ScrollViewer.VerticalScrollMode=&quot;Enabled&quot;
                          ScrollViewer.VerticalScrollBarVisibility=&quot;Visible&quot;
                                         SelectionMode=&quot;None&quot;
                                         IsItemClickEnabled=&quot;False&quot;&gt;
                    &lt;GridView.ItemsPanel&gt;
                        &lt;ItemsPanelTemplate&gt;
                            &lt;VariableSizedWrapGrid  Orientation=&quot;Horizontal&quot; 
                                            ItemWidth=&quot;{Binding ElementName=AGridView, Path=ItemWidth}&quot;
                                            MaximumRowsOrColumns=&quot;{Binding ElementName=AGridView, Path=MaxRowsOrColumns}&quot;/&gt;
                        &lt;/ItemsPanelTemplate&gt;
                    &lt;/GridView.ItemsPanel&gt;                   
                    &lt;GridView.ItemTemplate&gt;
                        &lt;DataTemplate&gt;
                            &lt;Grid HorizontalAlignment=&quot;Left&quot; Height=&quot;150&quot;&gt;
                                &lt;StackPanel&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                        &lt;Run Text=&quot;Name: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Name}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                    &lt;Run Text=&quot;Age: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Age}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                        &lt;Run Text=&quot;Sex: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Sex,Converter={StaticResource BTSConverter}}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                    &lt;Run Text=&quot;Favourite Sport: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding FavouriteSport}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                &lt;/StackPanel&gt;
                            &lt;/Grid&gt;
                        &lt;/DataTemplate&gt;
                    &lt;/GridView.ItemTemplate&gt;                    
                &lt;/local:AdaptableGridView&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;local:AdaptableGridView x:Name=&quot;AGridView&quot; ItemWidth=&quot;250&quot; 
                          AutomationProperties.AutomationId=&quot;CustomerGridView&quot;
                          AutomationProperties.Name=&quot; Customers Group&quot;
                          ScrollViewer.VerticalScrollMode=&quot;Enabled&quot;
                          ScrollViewer.VerticalScrollBarVisibility=&quot;Visible&quot;
                                         SelectionMode=&quot;None&quot;
                                         IsItemClickEnabled=&quot;False&quot;&gt;
                    &lt;GridView.ItemsPanel&gt;
                        &lt;ItemsPanelTemplate&gt;
                            &lt;VariableSizedWrapGrid  Orientation=&quot;Horizontal&quot; 
                                            ItemWidth=&quot;{Binding ElementName=AGridView, Path=ItemWidth}&quot;
                                            MaximumRowsOrColumns=&quot;{Binding ElementName=AGridView, Path=MaxRowsOrColumns}&quot;/&gt;
                        &lt;/ItemsPanelTemplate&gt;
                    &lt;/GridView.ItemsPanel&gt;                   
                    &lt;GridView.ItemTemplate&gt;
                        &lt;DataTemplate&gt;
                            &lt;Grid HorizontalAlignment=&quot;Left&quot; Height=&quot;150&quot;&gt;
                                &lt;StackPanel&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                        &lt;Run Text=&quot;Name: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Name}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                    &lt;Run Text=&quot;Age: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Age}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                        &lt;Run Text=&quot;Sex: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding Sex,Converter={StaticResource BTSConverter}}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                    &lt;TextBlock Style=&quot;{StaticResource ItemStyle}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;10,10,0,0&quot;&gt;
                    &lt;Run Text=&quot;Favourite Sport: &quot;/&gt;
                        &lt;Run Text=&quot;{Binding FavouriteSport}&quot;/&gt;
                                    &lt;/TextBlock&gt;
                                &lt;/StackPanel&gt;
                            &lt;/Grid&gt;
                        &lt;/DataTemplate&gt;
                    &lt;/GridView.ItemTemplate&gt;                    
                &lt;/local:AdaptableGridView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="SpellE">GridView</span> class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.gridview</a></p>
<p class="MsoNormal"><span class="SpellE">VariableSizedWrapGrid</span> class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.variablesizedwrapgrid.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.variablesizedwrapgrid.aspx</a>
</p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
