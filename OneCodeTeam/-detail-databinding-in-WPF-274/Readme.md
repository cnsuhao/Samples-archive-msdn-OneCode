# Master-detail databinding in WPF (CSWPFMasterDetailBinding)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:42:19
## Description

<h1><span style="">Master-detail <span class="SpellE">databinding</span> in WPF (<span class="SpellE">CSWPFMasterDetailBinding</span>)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
<span style="">This example demonstrates how to do master/detail data binding in WPF. In this sample, two
<span class="SpellE">ListView</span> are used, one is master <span class="SpellE">
ListView</span> and another one is Detail <span class="SpellE">ListView</span>. The corresponding
<span class="GramE">class are</span> Customer and Order. The Customer class has a property of Orders which is an order list, bind a customer list to the master
<span class="SpellE">ListView</span>, and the Detail <span class="SpellE">ListView</span> bind to the order list of the selected item of master
<span class="SpellE">ListView</span> which is an instance of Customer class. So that when you select one customer in the master
<span class="SpellE">ListView</span>, the Detail <span class="SpellE">ListView</span> will show you the order list of that customer.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the sample project in Visual Studio.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start <span class="GramE">Without</span> Debugging, and the
<span class="SpellE">mian</span> window of the project will show.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The window contains two <span class="SpellE">listview</span>, the first one shows the customer list, and the second shows the order lists of the selected customer.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Select one item of the customer list, the second <span class="SpellE">
listview</span> shows the order list of the selected customer.</p>
<p class="MsoNormal">You will see following result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54095/1/image.png" alt="" width="658" height="408" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Order class and Customer class, which <span class="GramE">
has</span> a master/detail relationship. Each customer has a customer ID and a name<span class="GramE">,<span style="">�
</span>each</span> order also has a customer ID, so that we can get which customer the order belongs to. And in Customer,
<span class="GramE">there�s<span style="">� </span>a</span> </span><span class="SpellE"><span style="color:black">ObservableCollection</span></span><span style=""> property �Orders�, we can get all the orders belong to the customer from this property.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class Customer : INotifyPropertyChanged
{
��� private int _id;
��� private string _name;
��� private ObservableCollection&lt;Order&gt; _orders
������� = new ObservableCollection&lt;Order&gt;();


��� public int ID
��� {
������� get { return _id; }
������� set { 
������������_id = value;
����������� OnPropertyChanged(&quot;ID&quot;);
������� }
��� }


��� public string Name
��� {
������� get { return _name; }
������� set
������� {
������� ����_name = value;
����������� OnPropertyChanged(&quot;Name&quot;);
������� }
��� }


��� public ObservableCollection&lt;Order&gt; Orders
��� {
������� get { return _orders; }
��� }


��� #region INotifyPropertyChanged Members


��� public event PropertyChangedEventHandler PropertyChanged;


��� public void OnPropertyChanged(string name)
��� {
������� if (PropertyChanged != null)
������� {
����������� PropertyChanged(this, new PropertyChangedEventArgs(name));
������� }
��� }


��� #endregion
}


class Order : INotifyPropertyChanged
{
��� private int _id;
��� private DateTime _date;
��� private string _shipCity;


��� public int ID
��� {
������� get { return _id; }
������� set
������� {
����������� _id = value;
����������� OnPropertyChanged(&quot;ID&quot;);
������ �}
��� }


��� public DateTime Date
��� {
������� get { return _date; }
������� set
������� {
����������� _date = value;
����������� OnPropertyChanged(&quot;Date&quot;);
������� }
��� }


��� public string ShipCity
��� {
������� get { return _shipCity; }
������� set
 �������{
����������� _shipCity = value;
����������� OnPropertyChanged(&quot;ShipCity&quot;);
������� }
��� }


��� #region INotifyPropertyChanged Members


��� public event PropertyChangedEventHandler PropertyChanged;


��� public void OnPropertyChanged(string name)
� ��{
������� if (PropertyChanged != null)
������� {
����������� PropertyChanged(this, new PropertyChangedEventArgs(name));
������� }
��� }


��� #endregion
}

</pre>
<pre id="codePreview" class="csharp">
class Customer : INotifyPropertyChanged
{
��� private int _id;
��� private string _name;
��� private ObservableCollection&lt;Order&gt; _orders
������� = new ObservableCollection&lt;Order&gt;();


��� public int ID
��� {
������� get { return _id; }
������� set { 
������������_id = value;
����������� OnPropertyChanged(&quot;ID&quot;);
������� }
��� }


��� public string Name
��� {
������� get { return _name; }
������� set
������� {
������� ����_name = value;
����������� OnPropertyChanged(&quot;Name&quot;);
������� }
��� }


��� public ObservableCollection&lt;Order&gt; Orders
��� {
������� get { return _orders; }
��� }


��� #region INotifyPropertyChanged Members


��� public event PropertyChangedEventHandler PropertyChanged;


��� public void OnPropertyChanged(string name)
��� {
������� if (PropertyChanged != null)
������� {
����������� PropertyChanged(this, new PropertyChangedEventArgs(name));
������� }
��� }


��� #endregion
}


class Order : INotifyPropertyChanged
{
��� private int _id;
��� private DateTime _date;
��� private string _shipCity;


��� public int ID
��� {
������� get { return _id; }
������� set
������� {
����������� _id = value;
����������� OnPropertyChanged(&quot;ID&quot;);
������ �}
��� }


��� public DateTime Date
��� {
������� get { return _date; }
������� set
������� {
����������� _date = value;
����������� OnPropertyChanged(&quot;Date&quot;);
������� }
��� }


��� public string ShipCity
��� {
������� get { return _shipCity; }
������� set
 �������{
����������� _shipCity = value;
����������� OnPropertyChanged(&quot;ShipCity&quot;);
������� }
��� }


��� #region INotifyPropertyChanged Members


��� public event PropertyChangedEventHandler PropertyChanged;


��� public void OnPropertyChanged(string name)
� ��{
������� if (PropertyChanged != null)
������� {
����������� PropertyChanged(this, new PropertyChangedEventArgs(name));
������� }
��� }


��� #endregion
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a <span class="SpellE">CustomerList</span> class, in its constructor add some customers, and add some orders for each customer, this class is used to provide a list of customers for binding.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class CustomerList
{
��� private ObservableCollection&lt;Customer&gt; _customers;


��� public CustomerList()
��� {
������� _customers = new ObservableCollection&lt;Customer&gt;();


������� // Insert customer and corresponding order information into
������� Customer c = new Customer() { ID = 1, Name = &quot;Customer1&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Shanghai&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Beijing&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Guangzhou&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 2, Name = &quot;Customer2&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;New York&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Seattle&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 3, Name = &quot;Customer3&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Xiamen&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Shenzhen&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Tianjin&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Wuhan&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Jinan&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 4, Name = &quot;Customer4&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Lanzhou&quot; });
������� _customers.Add(c);
��� }


��� public ObservableCollection&lt;Customer&gt; Customers
��� {
������� get { return _customers; }
��� }
}

</pre>
<pre id="codePreview" class="csharp">
class CustomerList
{
��� private ObservableCollection&lt;Customer&gt; _customers;


��� public CustomerList()
��� {
������� _customers = new ObservableCollection&lt;Customer&gt;();


������� // Insert customer and corresponding order information into
������� Customer c = new Customer() { ID = 1, Name = &quot;Customer1&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Shanghai&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Beijing&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Guangzhou&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 2, Name = &quot;Customer2&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;New York&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Seattle&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 3, Name = &quot;Customer3&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Xiamen&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 2, 1), ShipCity = &quot;Shenzhen&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Tianjin&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Wuhan&quot; });
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 11, 10), ShipCity = &quot;Jinan&quot; });
������� _customers.Add(c);


������� c = new Customer() { ID = 4, Name = &quot;Customer4&quot; };
������� c.Orders.Add(new Order() { ID = 1, Date = new DateTime(2009, 1, 1), ShipCity = &quot;Lanzhou&quot; });
������� _customers.Add(c);
��� }


��� public ObservableCollection&lt;Customer&gt; Customers
��� {
������� get { return _customers; }
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In <span class="SpellE">MainWindow.xaml</span> define the
<span class="SpellE">CustomerList</span> object in the window resources, so that we can use it as a static resource for binding.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Window.Resources&gt;
��� &lt;!-- Data Source For Binding--&gt;
��� &lt;local:CustomerList x:Key=&quot;CustomerList&quot;/&gt;
&lt;/Window.Resources&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Window.Resources&gt;
��� &lt;!-- Data Source For Binding--&gt;
��� &lt;local:CustomerList x:Key=&quot;CustomerList&quot;/&gt;
&lt;/Window.Resources&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Bind the <span class="SpellE">listViewCustomers�s</span>
<span class="SpellE">ItemsSource</span> to the Customers property of <span class="SpellE">
CustomerList</span> class. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;!-- This ListView displays the all the customer information --&gt;
������ &lt;ListView Grid.Row=&quot;1&quot; Name=&quot;listViewCustomers&quot; 
�����������������ItemsSource=&quot;{Binding Source={StaticResource CustomerList}, Path=Customers}&quot;
���������������� SelectedIndex=&quot;0&quot;&gt;
���������� &lt;ListView.View&gt;
�������������� &lt;GridView&gt;
������������������ &lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
������������������ &lt;GridViewColumn Header=&quot;Name&quot; DisplayMemberBinding=&quot;{Binding Name}&quot; Width=&quot;100&quot;/&gt;
�������������� &lt;/GridView&gt;
���������� &lt;/ListView.View&gt;
������ &lt;/ListView&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;!-- This ListView displays the all the customer information --&gt;
������ &lt;ListView Grid.Row=&quot;1&quot; Name=&quot;listViewCustomers&quot; 
�����������������ItemsSource=&quot;{Binding Source={StaticResource CustomerList}, Path=Customers}&quot;
���������������� SelectedIndex=&quot;0&quot;&gt;
���������� &lt;ListView.View&gt;
�������������� &lt;GridView&gt;
������������������ &lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
������������������ &lt;GridViewColumn Header=&quot;Name&quot; DisplayMemberBinding=&quot;{Binding Name}&quot; Width=&quot;100&quot;/&gt;
�������������� &lt;/GridView&gt;
���������� &lt;/ListView.View&gt;
������ &lt;/ListView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Bind the <span class="SpellE">listViewOrders�s</span>
<span class="SpellE">ItemsSource</span> to the Orders property of the selected customer object.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;!-- This ListView displayd the corresponding order information for the selected customer in the customers ListView --&gt;
&lt;!-- Put attention to the ItemSource property, its the key point of this kind of master/detail data binding --&gt;
&lt;ListView Grid.Row=&quot;3&quot; Name=&quot;listViewOrders&quot;
��������� ItemsSource=&quot;{Binding ElementName=listViewCustomers, Path=SelectedItem.Orders}&quot;&gt;
��� &lt;ListView.View&gt;
������� &lt;GridView&gt;
������ �����&lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
����������� &lt;GridViewColumn Header=&quot;Date&quot; DisplayMemberBinding=&quot;{Binding Date}&quot; Width=&quot;auto&quot;/&gt;
����������� &lt;GridViewColumn Header=&quot;ShipCity&quot; DisplayMemberBinding=&quot;{Binding ShipCity}&quot; Width=&quot;auto&quot;/&gt;
������� &lt;/GridView&gt;
��� &lt;/ListView.View&gt;
&lt;/ListView&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;!-- This ListView displayd the corresponding order information for the selected customer in the customers ListView --&gt;
&lt;!-- Put attention to the ItemSource property, its the key point of this kind of master/detail data binding --&gt;
&lt;ListView Grid.Row=&quot;3&quot; Name=&quot;listViewOrders&quot;
��������� ItemsSource=&quot;{Binding ElementName=listViewCustomers, Path=SelectedItem.Orders}&quot;&gt;
��� &lt;ListView.View&gt;
������� &lt;GridView&gt;
������ �����&lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
����������� &lt;GridViewColumn Header=&quot;Date&quot; DisplayMemberBinding=&quot;{Binding Date}&quot; Width=&quot;auto&quot;/&gt;
����������� &lt;GridViewColumn Header=&quot;ShipCity&quot; DisplayMemberBinding=&quot;{Binding ShipCity}&quot; Width=&quot;auto&quot;/&gt;
������� &lt;/GridView&gt;
��� &lt;/ListView.View&gt;
&lt;/ListView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
