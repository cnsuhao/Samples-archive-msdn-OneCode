# Master-detail databinding in WPF (VBWPFMasterDetailBinding)
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
* 2012-03-11 06:41:48
## Description

<h1><span style="">Master-detail databinding in WPF (VBWPFMasterDetailBinding) </span>
</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
<span style="">This example demonstrates how to do master/detail data binding in WPF. In this sample, two ListView are used, one is master ListView and another one is Detail ListView. The corresponding classes is Customer and Order. The Customer class has a
 property of Orders which is an order list, bind a customer list to the master ListView, and the Detail ListView bind to the order list of the selected item of master ListView which is an instance of Customer class. So that when you select one customer in the
 master ListView, the Detail ListView will show you the order list of that customer.
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the sample project in Visual Studio. </p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Without Debugging, and the mian window of the project will show.
</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The window contains two listview, the first one shows the customer list, and the second shows the order lists of the selected customer.
</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Select one item of the customer list, the second listview shows the order list of the selected customer.
</p>
<p class="MsoNormal">You will see following result. </p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54092/1/image.png" alt="" width="658" height="408" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Order class and Customer class, which has a master/detail relationship. Each customer has a customer ID and a name,<span style="">�
</span>each order also has a customer ID, so that we can get which customer the order belongs to. And in Customer, there�s<span style="">�
</span>a </span><span style="color:black">ObservableCollection</span><span style=""> property �Orders�, we can get all the orders belong to the customer from this property.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Class Customer
��� Implements INotifyPropertyChanged
��� Private _id As Integer
��� Private _name As String
��� Private _orders As New ObservableCollection(Of Order)()


��� Public Property ID() As Integer
������� Get
����������� Return _id
������� End Get
������� Set(ByVal value As Integer)
����������� _id = value
����������� OnPropertyChanged(&quot;ID&quot;)
������� End Set
��� End Property


��� Public Property Name() As String
������� Get
����������� Return _name
������� End Get
������� Set(ByVal value As String)
����������� _name = value
����������� OnPropertyChanged(&quot;Name&quot;)
������� End Set
��� End Property


��� Public ReadOnly Property Orders() As ObservableCollection(Of Order)
������� Get
����������� Return _orders
������� End Get
��� End Property


#Region &quot;INotifyPropertyChanged Members&quot;


��� Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


��� Public Sub OnPropertyChanged(ByVal name As String)
������� RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
��� End Sub


#End Region
End Class


Class Order
��� Implements INotifyPropertyChanged
��� Private _id As Integer
��� Private _date As DateTime
��� Private _shipCity As String


��� Public Property ID() As Integer
������� Get
����������� Return _id
������� End Get
������� Set(ByVal value As Integer)
����������� _id = value
����������� OnPropertyChanged(&quot;ID&quot;)
������� End Set
��� End Property


��� Public Property [Date]() As DateTime
������� Get
����������� Return _date
������� End Get
������� Set(ByVal value As DateTime)
����������� _date = value
����������� OnPropertyChanged(&quot;Date&quot;)
������� End Set
��� End Property


��� Public Property ShipCity() As String
������� Get
����������� Return _shipCity
������� End Get
������� Set(ByVal value As String)
����������� _shipCity = value
����������� OnPropertyChanged(&quot;ShipCity&quot;)
������� End Set
��� End Property


#Region &quot;INotifyPropertyChanged Members&quot;


��� Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


��� Public Sub OnPropertyChanged(ByVal name As String)
������� RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
��� End Sub


#End Region
End Class

</pre>
<pre id="codePreview" class="vb">
Class Customer
��� Implements INotifyPropertyChanged
��� Private _id As Integer
��� Private _name As String
��� Private _orders As New ObservableCollection(Of Order)()


��� Public Property ID() As Integer
������� Get
����������� Return _id
������� End Get
������� Set(ByVal value As Integer)
����������� _id = value
����������� OnPropertyChanged(&quot;ID&quot;)
������� End Set
��� End Property


��� Public Property Name() As String
������� Get
����������� Return _name
������� End Get
������� Set(ByVal value As String)
����������� _name = value
����������� OnPropertyChanged(&quot;Name&quot;)
������� End Set
��� End Property


��� Public ReadOnly Property Orders() As ObservableCollection(Of Order)
������� Get
����������� Return _orders
������� End Get
��� End Property


#Region &quot;INotifyPropertyChanged Members&quot;


��� Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


��� Public Sub OnPropertyChanged(ByVal name As String)
������� RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
��� End Sub


#End Region
End Class


Class Order
��� Implements INotifyPropertyChanged
��� Private _id As Integer
��� Private _date As DateTime
��� Private _shipCity As String


��� Public Property ID() As Integer
������� Get
����������� Return _id
������� End Get
������� Set(ByVal value As Integer)
����������� _id = value
����������� OnPropertyChanged(&quot;ID&quot;)
������� End Set
��� End Property


��� Public Property [Date]() As DateTime
������� Get
����������� Return _date
������� End Get
������� Set(ByVal value As DateTime)
����������� _date = value
����������� OnPropertyChanged(&quot;Date&quot;)
������� End Set
��� End Property


��� Public Property ShipCity() As String
������� Get
����������� Return _shipCity
������� End Get
������� Set(ByVal value As String)
����������� _shipCity = value
����������� OnPropertyChanged(&quot;ShipCity&quot;)
������� End Set
��� End Property


#Region &quot;INotifyPropertyChanged Members&quot;


��� Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


��� Public Sub OnPropertyChanged(ByVal name As String)
������� RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
��� End Sub


#End Region
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a CustomerList class, in its constructor add some customers, and add some orders for each customer, this class is used to provide a list of customers for binding.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Class CustomerList
��� Private _customers As ObservableCollection(Of Customer)


��� Public Sub New()
������� _customers = New ObservableCollection(Of Customer)()


������� ' Insert customer and corresponding order information into 
��������Dim c As New Customer() With {.ID = 1, .Name = &quot;Customer1&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Shanghai&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Beijing&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Guangzhou&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 2, .Name = &quot;Customer2&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;New York&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Seattle&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 3, .Name = &quot;Customer3&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Xiamen&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Shenzhen&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Tianjin&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Wuhan&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Jinan&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 4, .Name = &quot;Customer4&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Lanzhou&quot;})
������� _customers.Add(c)
��� End Sub


��� Public ReadOnly Property Customers() As ObservableCollection(Of Customer)
������� Get
����������� Return _customers
������� End Get
��� End Property
End Class

</pre>
<pre id="codePreview" class="vb">
Class CustomerList
��� Private _customers As ObservableCollection(Of Customer)


��� Public Sub New()
������� _customers = New ObservableCollection(Of Customer)()


������� ' Insert customer and corresponding order information into 
��������Dim c As New Customer() With {.ID = 1, .Name = &quot;Customer1&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Shanghai&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Beijing&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Guangzhou&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 2, .Name = &quot;Customer2&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;New York&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Seattle&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 3, .Name = &quot;Customer3&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Xiamen&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 2, 1), .ShipCity = &quot;Shenzhen&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Tianjin&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Wuhan&quot;})
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 11, 10), .ShipCity = &quot;Jinan&quot;})
������� _customers.Add(c)


������� c = New Customer() With {.ID = 4, .Name = &quot;Customer4&quot;}
������� c.Orders.Add(New Order() With {.ID = 1, .Date = New DateTime(2009, 1, 1), .ShipCity = &quot;Lanzhou&quot;})
������� _customers.Add(c)
��� End Sub


��� Public ReadOnly Property Customers() As ObservableCollection(Of Customer)
������� Get
����������� Return _customers
������� End Get
��� End Property
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In MainWindow.xaml define the CustomerList object in the window resources, so that we can use it as a static resource for binding.
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
</span></span></span><span style="">Bind the listViewCustomers�s ItemsSource to the Customers property of CustomerList class.
</span></p>
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
</span></span></span><span style="">Bind the listViewOrders�s ItemsSource to the Orders property of the selected customer object.
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
����������� &lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
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
����������� &lt;GridViewColumn Header=&quot;ID&quot; DisplayMemberBinding=&quot;{Binding ID}&quot; Width=&quot;50&quot;/&gt;
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
