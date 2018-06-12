# How to filter data in view model in Windows Store app
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows 8.1
## Topics
* Filter data
## IsPublished
* True
## ModifiedDate
* 2013-12-04 10:03:44
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to filter data in your View Model in Windows Store app (CSWindowsStoreAppFlightDataFilter)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span lang="EN" style="">Have you ever written an application, or been in the process of writing one, in which a large amount of data is being displayed on screen?&nbsp; At some point you realize that you want the users to be able to
 filter the data, but you are not sure of the best way to do it.&nbsp;&nbsp;For our sample application, we will use flight information as the sample data, and add a filter on the price of the flight. The methodology demonstrated in this sample can be applied
 to a larger application in which you have multiple filter criteria, and live data from a real time or static data source.
</span></p>
<p class="MsoNormal"><span lang="EN" style="">Please note: This sample is based on following blog:<span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://blogs.msdn.com/b/wsdevsol/archive/2013/11/14/filtering-data-in-your-view-model.aspx">http://blogs.msdn.com/b/wsdevsol/archive/2013/11/14/filtering-data-in-your-view-model.aspx</a></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Build the sample in Visual Studio 2013, and then run it. The app looks like this:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/104105/1/image.png" alt="" width="576" height="359" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">ItemsPage.xaml is the Main View of the application that displays all of the flight information and MainViewModel.cs is the ViewModel that exposes properties and methods which the
<span class="SpellE">ItemsPage.xaml</span> is bound to.<span style="">&nbsp; </span>
The flight information will be displayed in a GridView whose ItemsSource property will be bound to the
<span lang="EN" style="">FilteredFlights </span>property of the MainViewModel.</p>
<p class="MsoNormal">The following steps will show you how to expose a <span class="SpellE">
FilteredFlights</span> property in <span class="SpellE">MainViewModel</span>, bind it to the
<span class="SpellE">GridView</span>, add a control to filter on price, and finally add a function that keeps the FilteredFlights property up to date based on the current price filter.</p>
<p class="MsoNormal"><span lang="EN" style="">Step1. Create a Filtered Data Property
</span></p>
<p class="MsoNormal"><span lang="EN" style="">MainViewModel has a Flights property which is an ObservableCollection of FlightDataItem.&nbsp; This property is initialized with all of the flights in the data source, which is FlightData.json.&nbsp; To support
 filtering we will add a Property called FilteredFlights to our view model.&nbsp; To do this, open the
<span class="SpellE">MainViewModel.cs</span> file and add the following code after the Flights property:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private ObservableCollection&lt;FlightDataItem&gt; _filteredFlights;
  
 public ObservableCollection&lt;FlightDataItem&gt; FilteredFlights
 {
     get { return _filteredFlights; }
     set { _filteredFlights = value; NotifyPropertyChanged(&quot;FilteredFlights&quot;); }
 }

</pre>
<pre id="codePreview" class="csharp">
private ObservableCollection&lt;FlightDataItem&gt; _filteredFlights;
  
 public ObservableCollection&lt;FlightDataItem&gt; FilteredFlights
 {
     get { return _filteredFlights; }
     set { _filteredFlights = value; NotifyPropertyChanged(&quot;FilteredFlights&quot;); }
 }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">In the MainViewModel constructor add the following line of code to initialize the FilteredFlights to contain all of the flights:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
FilteredFlights = Flights;

</pre>
<pre id="codePreview" class="csharp">
FilteredFlights = Flights;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">Step 2. Bind the GridView to the Filtered Data Property
</span></p>
<p class="MsoNormal"><span lang="EN" style="">Now that there is a FilteredFlights property in our
<span class="SpellE">MainViewModel</span>, we will bind it to our GridView.<span style="">&nbsp;
</span>Open the ItemsPage.xaml file in XAML view and modify the ItemsSource property of the GridView to bind to FilteredFlights:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;GridView
        x:Name=&quot;itemGridView&quot;
        AutomationProperties.AutomationId=&quot;ItemsGridView&quot;
        AutomationProperties.Name=&quot;Items&quot;
        TabIndex=&quot;1&quot;
        ItemsSource=&quot;{Binding FilteredFlights}&quot;
        SelectionMode=&quot;None&quot;
        IsSwipeEnabled=&quot;false&quot;
        IsItemClickEnabled=&quot;True&quot; Grid.Column=&quot;1&quot; Margin=&quot;20,20,0,0&quot;&gt;

</pre>
<pre id="codePreview" class="csharp">
&lt;GridView
        x:Name=&quot;itemGridView&quot;
        AutomationProperties.AutomationId=&quot;ItemsGridView&quot;
        AutomationProperties.Name=&quot;Items&quot;
        TabIndex=&quot;1&quot;
        ItemsSource=&quot;{Binding FilteredFlights}&quot;
        SelectionMode=&quot;None&quot;
        IsSwipeEnabled=&quot;false&quot;
        IsItemClickEnabled=&quot;True&quot; Grid.Column=&quot;1&quot; Margin=&quot;20,20,0,0&quot;&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span lang="EN" style="">The plumbing is now in place for us to add some more functionality to the view so we can filter the data.
</span></p>
<p class="MsoNormal"><span lang="EN" style="">Step 3. Add a control to filter the data
</span></p>
<p class="MsoNormal"><span lang="EN" style="">Continuing in the ItemsPage.xaml file we will modify the layout so it can host a slider control for our price filter.<span style="">&nbsp;
</span>For starters we will give our main layout Grid two columns by adding column definitions:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;!--
    This grid acts as a root panel for the page that defines two rows:
    * Row 0 contains the back button and page title
    * Row 1 contains the rest of the page layout
--&gt;
&lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
    &lt;Grid.ColumnDefinitions&gt;
        &lt;ColumnDefinition Width=&quot;344*&quot;/&gt;
        &lt;ColumnDefinition Width=&quot;1023*&quot;/&gt;
    &lt;/Grid.ColumnDefinitions&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;!--
    This grid acts as a root panel for the page that defines two rows:
    * Row 0 contains the back button and page title
    * Row 1 contains the rest of the page layout
--&gt;
&lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
    &lt;Grid.ColumnDefinitions&gt;
        &lt;ColumnDefinition Width=&quot;344*&quot;/&gt;
        &lt;ColumnDefinition Width=&quot;1023*&quot;/&gt;
    &lt;/Grid.ColumnDefinitions&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">Add the layout element and controls for our price filter after the GridView.<span style="">&nbsp;
</span>Please note that the Value property of the Slider control is bound to the SelectedPrice property which we have not yet added to our view model.
<span style="">&nbsp;</span>We will do this in the next section.<span style="">&nbsp;
</span>Also note that the binding Mode is TwoWay. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;StackPanel Grid.Row=&quot;1&quot;&gt;
    &lt;TextBlock Text=&quot;Price Filter&quot; FontSize=&quot;48&quot; Margin=&quot;10&quot; /&gt;
    &lt;Slider Height=&quot;50&quot; Margin=&quot;10&quot; Minimum=&quot;100.00&quot; Maximum=&quot;2265.00&quot; Value=&quot;{Binding Path=SelectedPrice, Mode=TwoWay}&quot; /&gt;
&lt;/StackPanel&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;StackPanel Grid.Row=&quot;1&quot;&gt;
    &lt;TextBlock Text=&quot;Price Filter&quot; FontSize=&quot;48&quot; Margin=&quot;10&quot; /&gt;
    &lt;Slider Height=&quot;50&quot; Margin=&quot;10&quot; Minimum=&quot;100.00&quot; Maximum=&quot;2265.00&quot; Value=&quot;{Binding Path=SelectedPrice, Mode=TwoWay}&quot; /&gt;
&lt;/StackPanel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">This concludes the changes needed in the view for filtering our data.<span style="">&nbsp;
</span>If you run the application now, the slider will move, but the data will not yet change.<span style="">&nbsp;
</span>We will add the code to do this in the final section of this article. </span>
</p>
<p class="MsoNormal"><span lang="EN" style="">Step 4. Bringing it all together in the MainViewModel
</span></p>
<p class="MsoNormal"><span lang="EN" style="">In our final section we will add a function named RefreshFilteredData to filter our data, and the SelectedPrice property to our MainViewModel.cs file.<span style="">&nbsp;
</span>The RefreshFilteredData function selects all items from the Flights collection whose price is less than the SelectedPrice.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void RefreshFilteredData()
 {
     var fr = from fobjs in Flights
             where fobjs.Price &lt; SelectedPrice
             select fobjs;
  
     // This will limit the amount of view refreshes
     if (FilteredFlights.Count == fr.Count())
         return;
  
     FilteredFlights = new ObservableCollection&lt;FlightDataItem&gt;(fr);
 }

</pre>
<pre id="codePreview" class="csharp">
private void RefreshFilteredData()
 {
     var fr = from fobjs in Flights
             where fobjs.Price &lt; SelectedPrice
             select fobjs;
  
     // This will limit the amount of view refreshes
     if (FilteredFlights.Count == fr.Count())
         return;
  
     FilteredFlights = new ObservableCollection&lt;FlightDataItem&gt;(fr);
 }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">The following code is the definition of our SelectedPrice property.<span style="">&nbsp;
</span>When this property changes, which will be the case when the price slider moves because of our TwoWay binding, it will call the RefreshFilteredData function to update the FilteredFlights property of the MainViewModel.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private double _selectedPrice;
  
 public double SelectedPrice
 {
     get { return _selectedPrice; }
     set { _selectedPrice = value; NotifyPropertyChanged(&quot;SelectedPrice&quot;); RefreshFilteredData(); }
 }

</pre>
<pre id="codePreview" class="csharp">
private double _selectedPrice;
  
 public double SelectedPrice
 {
     get { return _selectedPrice; }
     set { _selectedPrice = value; NotifyPropertyChanged(&quot;SelectedPrice&quot;); RefreshFilteredData(); }
 }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">Lastly, we need to initialize the SelectedPrice property by adding the following to the end of the LoadFlightData() function
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SelectedPrice = maxPrice;

</pre>
<pre id="codePreview" class="csharp">
SelectedPrice = maxPrice;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">This concludes the work needed to update our MainViewModel to support the data filtering. At this point in time if you run the application and move the Slider control to the left, you should see the Flight data
 filtered to only show prices in the selected price range.<span style="">&nbsp; </span>
</span></p>
<p class="MsoNormal"><span lang="EN" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
