# How to add item to grouped Gridview dynamically
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Windows 8
## Topics
* Data Binding
* Windows 8
## IsPublished
* True
## ModifiedDate
* 2013-04-16 09:45:53
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1><span>&nbsp;</span></h1>
<h1><span>Add an item dynamically to a grouped GridView in a Windows Store app (CSWindowsStoreAppAddItem)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:.75pt"><span style="color:black">This sample demonstrates how to add an item dynamically to a grouped GridView.
</span></p>
<p class="MsoNormal" style="margin-bottom:.75pt"><span style="color:black">From the GridView control we get the collections view source. In the source we search for the group with the key of the item we want to add, or we add a new group to the source, if
 the key doesn't exist. Then we add the item to the list of items in that group. </span>
</p>
<p class="MsoNormal"><span style="color:black">Because the source is a dependency property and it is bound to the GridView control with an OneWay binding, the change in the source is dynamically propagated to the control.</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open this sample in Visual Studio 2012 on Windows 8 machine, and press F5 to run it.</p>
<p class="MsoListParagraphCxSpMiddle"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After the app is launched, you will see following screen.</p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black"><img src="/site/view/file/73743/1/image.png" alt="" width="866" height="491" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Select the name of a picture and a category from the combo boxes and name the item you want to add. After clicking the &quot;Add Item&quot; button you will see the item appearing in the list<span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black">.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><img src="/site/view/file/73744/1/image.png" alt="" width="865" height="492" align="middle">
</span></p>
<p class="MsoNormal">&nbsp;</p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span>In MainPage.xaml the GridView named ItemsByCategory is declared. Note that the ItemsSource is bound to the resource collectionViewSource declared earlier in the same file. The important part is the binding mode. By default data
 bindings are OneTime, which means no changes of the data source are propagated to the control. The modes OneWay and TwoWay make use of the notification event in the dependency property to update the control.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;GridView x:Name=&quot;ItemsByCategory&quot; 
                  ItemsSource=&quot;{Binding Source={StaticResource collectionViewSource}, Mode=TwoWay}&quot;

</pre>
<pre id="codePreview" class="xaml">&lt;GridView x:Name=&quot;ItemsByCategory&quot; 
                  ItemsSource=&quot;{Binding Source={StaticResource collectionViewSource}, Mode=TwoWay}&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>In <span class="SpellE">MainPage.xaml.cs</span> you see the source of the collection view source, which is declared in the XAML, set to an observable collection. Each item in this collection represents a group. The control is
 subscribed to changes in this collection, so whenever a group is added or removed, it will automatically be updated.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public sealed partial class MainPage
{
    /// &lt;summary&gt;
    /// The data source for the grouped grid view.
    /// &lt;/summary&gt;
    private static ObservableCollection&lt;GroupInfoCollection&lt;Item&gt;&gt; _source;


    /// &lt;summary&gt;
    /// Initializes a new instance of the &lt;see cref=&quot;MainPage&quot;/&gt; class.
    /// &lt;/summary&gt;
    public MainPage()
    {
        InitializeComponent();


        _source = (new StoreData()).GetGroupsByCategory();


        collectionViewSource.Source = _source;

</pre>
<pre id="codePreview" class="csharp">public sealed partial class MainPage
{
    /// &lt;summary&gt;
    /// The data source for the grouped grid view.
    /// &lt;/summary&gt;
    private static ObservableCollection&lt;GroupInfoCollection&lt;Item&gt;&gt; _source;


    /// &lt;summary&gt;
    /// Initializes a new instance of the &lt;see cref=&quot;MainPage&quot;/&gt; class.
    /// &lt;/summary&gt;
    public MainPage()
    {
        InitializeComponent();


        _source = (new StoreData()).GetGroupsByCategory();


        collectionViewSource.Source = _source;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>The GroupInfoCollection&lt;T&gt; objects in the observable collection are again observable collections. The items in this collection represent the items in each group. Through the data binding the control will be subscribed to the
 notification event of those collections as well and automatically update, when an item is added or removed.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class GroupInfoCollection&lt;T&gt; : ObservableCollection&lt;T&gt;
{

</pre>
<pre id="codePreview" class="csharp">public class GroupInfoCollection&lt;T&gt; : ObservableCollection&lt;T&gt;
{

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>Changing the key of a GroupInfoCollection&lt;T&gt; object, however, doesn't rise a notification event. Hence the control doesn't update after the key changed.
</span></p>
<p class="MsoNormal"><span>The items implement the interface </span><span style="font-size:9.5pt; line-height:115%; font-family:Consolas; color:#2b91af; background:white">INotifyPropertyChanged</span><span>. Changing any property of an object of type Item
 that rises the PropertyChanged event will also result in the control updating. </span>
</p>
<p class="MsoNormal"><span>When the &quot;Add Item&quot; button is clicked, the </span><span class="SpellE">btnAddItemClick</span><span> event handler will be invoked. After gathering the information from the combo boxes and the text box, the source is queried for
 the group that represents the selected category. The new item will be added to the list of items in that group. Now, transparent for the developer, the event will notify the control and the GridView will be updated.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void btnAddItemClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    string path = string.Format(CultureInfo.InvariantCulture, &quot;SampleData/Images/60{0}.png&quot;, pictureComboBox.SelectedItem);


    Item item = new Item
                    {
                        Title = titleTextBox.Text,
                        Category = (string)groupComboBox.SelectedItem
                    };
    item.SetImage(StoreData.BaseUri, path);


    GroupInfoCollection&lt;Item&gt; group =
        _source.Single(groupInfoList =&gt; groupInfoList.Key == item.Category);


    group.Add(item);
}

</pre>
<pre id="codePreview" class="csharp">private void btnAddItemClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    string path = string.Format(CultureInfo.InvariantCulture, &quot;SampleData/Images/60{0}.png&quot;, pictureComboBox.SelectedItem);


    Item item = new Item
                    {
                        Title = titleTextBox.Text,
                        Category = (string)groupComboBox.SelectedItem
                    };
    item.SetImage(StoreData.BaseUri, path);


    GroupInfoCollection&lt;Item&gt; group =
        _source.Single(groupInfoList =&gt; groupInfoList.Key == item.Category);


    group.Add(item);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.groupstyle">GroupStyle Class</a></span></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
