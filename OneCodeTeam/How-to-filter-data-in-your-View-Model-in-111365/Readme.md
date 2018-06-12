# How to filter data in your View Model in universal Windows apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows 8
* Windows Phone 8
* Windows Store app Development
* Windows Phone Development
* Windows 8.1
* Windows Phone 8.1
* universal windows app
## Topics
* ViewModel pattern (MVVM)
* filter
* universal app
## IsPublished
* True
## ModifiedDate
* 2014-12-30 11:23:05
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to filter data in your View Model in universal Windows apps</h1>
<h2>Introduction</h2>
<p>This sample is upgraded from the following Windows store sample:</p>
<p><a href="https://code.msdn.microsoft.com/How-to-filter-data-in-view-acbd98f2">https://code.msdn.microsoft.com/How-to-filter-data-in-view-acbd98f2</a></p>
<p>Have you ever written an application, or been in the process of writing one, in which a large amount of data is being displayed on screen?&nbsp; At some point you realize that you want the users to be able to filter the data, but you are not sure of the
 best way to do it.&nbsp;&nbsp;For our sample application, we will use flight information as the sample data, and add a filter on the price of the flight. The methodology demonstrated in this sample can be applied to a larger application in which you have multiple
 filter criteria, and live data from a real time or static data source.</p>
<p>Please note: This sample is based on the following blog:&nbsp;&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/wsdevsol/archive/2013/11/14/filtering-data-in-your-view-model.aspx">http://blogs.msdn.com/b/wsdevsol/archive/2013/11/14/filtering-data-in-your-view-model.aspx</a></p>
<h2>Running the Sample</h2>
<p>Build the sample in Visual Studio 2013, and then run it. The app looks like this:</p>
<p>&nbsp;<img id="131774" src="/site/view/file/131774/1/1231.jpg" alt="" width="600" height="338" style="border:1px solid black"></p>
<p><img id="131775" src="/site/view/file/131775/1/1234.jpg" alt="" width="355" height="592"></p>
<p>&nbsp;</p>
<h2>Using the Code</h2>
<p>MainPage.xaml is the Main View of the application that displays all of the flight information and MainViewModel (.cs/h/cpp) is the ViewModel that exposes properties and methods which the MainPage.xaml is bound to.&nbsp; The flight information will be displayed
 in a GridView whose ItemsSource property will be bound to the FilteredFlights property of the MainViewModel.</p>
<p>The following steps will show you how to expose a FilteredFlights property in MainViewModel, bind it to the GridView, add a control to filter on price, and finally add a function that keeps the FilteredFlights property up to date based on the current price
 filter.</p>
<p>Step1. Create a Filtered Data Property</p>
<p>MainViewModel has a Flights property which is an ObservableCollection of FlightDataItem.&nbsp; This property is initialized with all of the flights in the data source, which is FlightData.json.&nbsp; To support filtering we will add a Property called FilteredFlights
 to our view model.&nbsp; To do this, open the MainViewModel.cs file and add the following code after the Flights property:</p>
<pre><span style="font-size:10px"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">private ObservableCollection&lt;FlightDataItem&gt; _filteredFlights;
  
 public ObservableCollection&lt;FlightDataItem&gt; FilteredFlights
 {
     get { return _filteredFlights; }
     set { _filteredFlights = value; NotifyPropertyChanged(&quot;FilteredFlights&quot;); }
 }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;ObservableCollection&lt;FlightDataItem&gt;&nbsp;_filteredFlights;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;FlightDataItem&gt;&nbsp;FilteredFlights&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_filteredFlights;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_filteredFlights&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;FilteredFlights&quot;</span>);&nbsp;}&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
</span></pre>
<p>In the MainViewModel constructor add the following line of code to initialize the FilteredFlights to contain all of the flights:</p>
<pre><span style="font-size:10px"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">FilteredFlights = Flights;</pre>
<div class="preview">
<pre class="csharp">FilteredFlights&nbsp;=&nbsp;Flights;</pre>
</div>
</div>
</div>
</span></pre>
<p>Step 2. Bind the GridView to the Filtered Data Property</p>
<p>Now that there is a FilteredFlights property in our MainViewModel, we will bind it to our GridView.&nbsp; Open the ItemsPage.xaml file in XAML view and modify the ItemsSource property of the GridView to bind to FilteredFlights:</p>
<pre><span style="font-size:10px"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">&lt;GridView

                    x:Name=&quot;itemGridView&quot;

                    AutomationProperties.AutomationId=&quot;ItemsGridView&quot;

                    AutomationProperties.Name=&quot;Items&quot;

                    TabIndex=&quot;1&quot;

                    ItemsSource=&quot;{Binding FilteredFlights}&quot;

                    SelectionMode=&quot;None&quot;

                    IsSwipeEnabled=&quot;false&quot;

                    IsItemClickEnabled=&quot;True&quot; 

                    Grid.Column=&quot;1&quot; 

                    Grid.RowSpan=&quot;2&quot;

                    Margin=&quot;20,20,0,0&quot;&gt;</pre>
<div class="preview">
<pre class="csharp">&lt;GridView&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:Name=<span class="cs__string">&quot;itemGridView&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutomationProperties.AutomationId=<span class="cs__string">&quot;ItemsGridView&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutomationProperties.Name=<span class="cs__string">&quot;Items&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TabIndex=<span class="cs__string">&quot;1&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;FilteredFlights}&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectionMode=<span class="cs__string">&quot;None&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSwipeEnabled=<span class="cs__string">&quot;false&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsItemClickEnabled=<span class="cs__string">&quot;True&quot;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.Column=<span class="cs__string">&quot;1&quot;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.RowSpan=<span class="cs__string">&quot;2&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Margin=<span class="cs__string">&quot;20,20,0,0&quot;</span>&gt;</pre>
</div>
</div>
</div>
</span></pre>
<p>The plumbing is now in place for us to add some more functionality to the view so we can filter the data.</p>
<p>Step 3. Add a control to filter the data</p>
<p>Continuing in the MainPage.xaml file we will modify the layout so it can host a slider control for our price filter.</p>
<pre><span style="font-size:10px"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XAML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xaml</span><pre class="hidden">&lt;Grid Grid.Row=&quot;1&quot; &gt;

                &lt;Grid.RowDefinitions&gt;

                    &lt;RowDefinition Height=&quot;auto&quot;/&gt;

                    &lt;RowDefinition Height=&quot;1*&quot;/&gt;

                &lt;/Grid.RowDefinitions&gt;

                &lt;Grid.ColumnDefinitions&gt;

                    &lt;ColumnDefinition Width=&quot;auto&quot;/&gt;

                    &lt;ColumnDefinition Width=&quot;1*&quot;/&gt;

                &lt;/Grid.ColumnDefinitions&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;1*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;1*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;</pre>
</div>
</div>
</div>
</span></pre>
<p>Add the layout element and controls for our price filter after the GridView. Please note that the Value property of the Slider control is bound to the SelectedPrice property which we have not yet added to our view model. We will do this in the next section.
 Also note that the binding Mode is TwoWay.</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XAML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xaml</span><pre class="hidden">&lt;StackPanel Name=&quot;filterPanel&quot;&gt;
       &lt;TextBlock x:Name=&quot;PriceText&quot; Text=&quot;Price Filter&quot; FontSize=&quot;20&quot; Margin=&quot;5&quot; /&gt;
       &lt;Slider Height=&quot;50&quot; Width=&quot;250&quot; Margin=&quot;5&quot; Minimum=&quot;100.00&quot; Maximum=&quot;2265.00&quot; Value=&quot;{Binding Path=SelectedPrice, Mode=TwoWay}&quot; /&gt;
&lt;/StackPanel&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;filterPanel&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;PriceText&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Price&nbsp;Filter&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Slider</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;250&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">Minimum</span>=<span class="xaml__attr_value">&quot;100.00&quot;</span>&nbsp;<span class="xaml__attr_name">Maximum</span>=<span class="xaml__attr_value">&quot;2265.00&quot;</span>&nbsp;<span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=SelectedPrice,&nbsp;Mode=TwoWay}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
</pre>
<p>This concludes the changes needed in the view for filtering our data. If you run the application now, the slider will move, but the data will not yet change.&nbsp; We will add the code to do this in the final section of this article.</p>
<p>Step 4. Bringing it all together in the MainViewModel</p>
<p>In our final section we will add a function named RefreshFilteredData to filter our data, and the SelectedPrice property to our MainViewModel.cs file. The RefreshFilteredData function selects all items from the Flights collection whose price is less than
 the SelectedPrice.</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">private void RefreshFilteredData()
        {
            var fr = from fobjs in Flights
                     where fobjs.Price &lt;= SelectedPrice
                     select fobjs;
 
            //  This will limit the amount of view refreshes
            if (FilteredFlights == null || FilteredFlights.Count == fr.Count())
                return;
 
            FilteredFlights = new ObservableCollection&lt;FlightDataItem&gt;(fr);
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RefreshFilteredData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fr&nbsp;=&nbsp;from&nbsp;fobjs&nbsp;<span class="cs__keyword">in</span>&nbsp;Flights&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;fobjs.Price&nbsp;&lt;=&nbsp;SelectedPrice&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;fobjs;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;This&nbsp;will&nbsp;limit&nbsp;the&nbsp;amount&nbsp;of&nbsp;view&nbsp;refreshes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(FilteredFlights&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;||&nbsp;FilteredFlights.Count&nbsp;==&nbsp;fr.Count())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FilteredFlights&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;FlightDataItem&gt;(fr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</pre>
<p>The following code is the definition of our SelectedPrice property. When this property changes, which will be the case when the price slider moves because of our TwoWay binding, it will call the RefreshFilteredData function to update the FilteredFlights
 property of the MainViewModel.</p>
<pre><span style="font-size:10px"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">private double _selectedPrice;
  
 public double SelectedPrice
 {
     get { return _selectedPrice; }
     set { _selectedPrice = value; NotifyPropertyChanged(&quot;SelectedPrice&quot;); RefreshFilteredData(); }
 }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;_selectedPrice;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;SelectedPrice&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_selectedPrice;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_selectedPrice&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;SelectedPrice&quot;</span>);&nbsp;RefreshFilteredData();&nbsp;}&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
</span></pre>
<p>Lastly, we need to initialize the SelectedPrice property by adding the following to the end of the LoadFlightData() function</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">SelectedPrice = maxPrice;</pre>
<div class="preview">
<pre class="csharp">SelectedPrice&nbsp;=&nbsp;maxPrice;</pre>
</div>
</div>
</div>
</pre>
<p>This concludes the work needed to update our MainViewModel to support the data filtering. At this point in time if you run the application and move the Slider control to the left, you should see the Flight data filtered to only show prices in the selected
 price range.&nbsp;</p>
