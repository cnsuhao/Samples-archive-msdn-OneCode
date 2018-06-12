# How to Query in a DataSet with Multiple DataTables
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* query dataset
* expression
## IsPublished
* True
## ModifiedDate
* 2014-01-06 10:06:03
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Query in a
</span><span style="font-weight:bold; font-size:14pt">DataSet</span><span style="font-weight:bold; font-size:14pt"> with Multiple
</span><span style="font-weight:bold; font-size:14pt">DataTables</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We can use traditional SQL queries to get data from the data source, but we cannot use SQL to query in
</span><span style="font-size:11pt">DataSet</span><span style="font-size:11pt">. In this sample, we will demonstrate how to use Expression to query in a
</span><span style="font-size:11pt">DataSet</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In this sample, we will demonstrate how to use Expression to query in a
</span><span style="font-size:11pt">DataSet</span><span style="font-size:11pt">:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Create a </span><span style="font-size:11pt">DataSet</span><span style="font-size:11pt"> with two
</span><span style="font-size:11pt">DataTables</span><span style="font-size:11pt">;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Create the constraints between the tables;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Use </span><a href="http://msdn.microsoft.com/en-us/library/way3dy9w.aspx" style="text-decoration:none"><span style="">DataTable.Select</span><span style=""> Method</span></a><span style="font-size:11pt">
 to get rows from the tables;</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">4. Use </span><a href="http://msdn.microsoft.com/en-us/library/system.data.datatable.compute.aspx" style="text-decoration:none"><span style="">DataTable.Compute</span><span style=""> Method</span></a><span style="font-size:11pt">
 to compute the specified rows;</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">5. Use </span><a href="http://msdn.microsoft.com/en-us/library/system.data.datacolumn.expression.aspx" style="text-decoration:none"><span style="">Expression</span></a><span style="font-size:11pt"> in
 the above methods to query</span><span style="font-size:11pt">.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, the application displa</span><span style="font-size:11pt">ys</span><span style="font-size:11pt"> three tables</span><span style="font-size:11pt"> that store data</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">SalesPerson</span><span style="font-size:11pt"> table:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106669/1/image.png" alt="" width="575" height="50" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Order table:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106670/1/image.png" alt="" width="575" height="130" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">OrderDetail</span><span style="font-size:11pt"> table:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106671/1/image.png" alt="" width="575" height="209" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Second, the application selects rows f</span><span style="font-size:11pt">ro</span><span style="font-size:11pt">m Order table
</span><span style="font-size:11pt">bas</span><span style="font-size:11pt">ed on</span><span style="font-size:11pt">
</span><span style="font-size:11pt">the territories in </span><span style="font-size:11pt">SalesPerson</span><span style="font-size:11pt"> table and</span><span style="font-size:11pt"> then</span><span style="font-size:11pt"> computes the Total results:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106672/1/image.png" alt="" width="575" height="157" align="middle">
</span><a name="_GoBack"></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">At </span><span style="font-size:11pt">last, the</span><span style="font-size:11pt"> application selects rows from
</span><span style="font-size:11pt">OrderDetail</span><span style="font-size:11pt"> table to get all the sales information of Bike:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/106673/1/image.png" alt="" width="575" height="183" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The sixth row is the product Helmet, and you can&rsquo;t find it now.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Define the constraints between the tables.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
salesSet.Relations.Add(&quot;OrderOrderDetail&quot;,
    orderTable.Columns[&quot;OrderId&quot;], orderDetailTable.Columns[&quot;OrderId&quot;], true);
salesSet.Relations.Add(&quot;SalesPersonOrder&quot;, 
    salesPersonTable.Columns[&quot;PersonId&quot;], orderTable.Columns[&quot;SalesPerson&quot;], true);
</pre>
<pre class="hidden">
salesSet.Relations.Add(&quot;OrderOrderDetail&quot;, orderTable.Columns(&quot;OrderId&quot;),
                       orderDetailTable.Columns(&quot;OrderId&quot;), True)
salesSet.Relations.Add(&quot;SalesPersonOrder&quot;, salesPersonTable.Columns(&quot;PersonId&quot;),
                       orderTable.Columns(&quot;SalesPerson&quot;), True)
</pre>
<pre id="codePreview" class="csharp">
salesSet.Relations.Add(&quot;OrderOrderDetail&quot;,
    orderTable.Columns[&quot;OrderId&quot;], orderDetailTable.Columns[&quot;OrderId&quot;], true);
salesSet.Relations.Add(&quot;SalesPersonOrder&quot;, 
    salesPersonTable.Columns[&quot;PersonId&quot;], orderTable.Columns[&quot;SalesPerson&quot;], true);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Create the expression columns</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If you must perform an operation on two or more columns, you should create a&nbsp;</span><span style="font-size:11pt"></span><a href="http://msdn.microsoft.com/en-us/library/system.data.datacolumn.aspx"><span style="font-size:11pt">DataColumn</span></a><span style="font-size:11pt">
 instead of using </span><span style="font-size:11pt">DataTable.Compute</span><span style="font-size:11pt"> method</span><span style="font-size:11pt">
</span><span style="font-size:11pt">and</span><span style="font-size:11pt">set</span><span style="font-size:11pt"> its&nbsp;Expression&nbsp;property to an appropriate expression</span><span style="font-size:11pt">.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
// Use the Aggregate-Sum on the child table column to get the result.
DataColumn colSub = new DataColumn(&quot;SubTotal&quot;, typeof(Decimal), &quot;Sum(Child.LineTotal)&quot;);
orderTable.Columns.Add(colSub);
// Compute the tax by referencing the SubTotal expression column.
DataColumn colTax = new DataColumn(&quot;Tax&quot;, typeof(Decimal), &quot;SubTotal*0.1&quot;);
orderTable.Columns.Add(colTax);
// If the OrderId is 'Total', compute the due on all orders; or compute the due on this order.
DataColumn colTotal = new DataColumn(&quot;TotalDue&quot;, typeof(Decimal),
    &quot;IIF(OrderId='Total',Sum(SubTotal)&#43;Sum(Tax),SubTotal&#43;Tax)&quot;);
orderTable.Columns.Add(colTotal);
DataRow totalRow = orderTable.NewRow();
totalRow[&quot;OrderId&quot;] = &quot;Total&quot;;
orderTable.Rows.Add(totalRow);
</pre>
<pre class="hidden">
' Use the Aggregate-Sum on the child table column to get the result.
Dim colSub As New DataColumn(&quot;SubTotal&quot;, GetType(Decimal), &quot;Sum(Child.LineTotal)&quot;)
orderTable.Columns.Add(colSub)
' Compute the tax by referencing the SubTotal expression column.
Dim colTax As New DataColumn(&quot;Tax&quot;, GetType(Decimal), &quot;SubTotal*0.1&quot;)
orderTable.Columns.Add(colTax)
' If the OrderId is 'Total', compute the due on all orders; or compute the due on this order.
Dim colTotal As New DataColumn(&quot;TotalDue&quot;, GetType(Decimal),
                               &quot;IIF(OrderId='Total',Sum(SubTotal)&#43;Sum(Tax),SubTotal&#43;Tax)&quot;)
orderTable.Columns.Add(colTotal)
Dim totalRow As DataRow = orderTable.NewRow()
totalRow(&quot;OrderId&quot;) = &quot;Total&quot;
orderTable.Rows.Add(totalRow)
</pre>
<pre id="codePreview" class="csharp">
// Use the Aggregate-Sum on the child table column to get the result.
DataColumn colSub = new DataColumn(&quot;SubTotal&quot;, typeof(Decimal), &quot;Sum(Child.LineTotal)&quot;);
orderTable.Columns.Add(colSub);
// Compute the tax by referencing the SubTotal expression column.
DataColumn colTax = new DataColumn(&quot;Tax&quot;, typeof(Decimal), &quot;SubTotal*0.1&quot;);
orderTable.Columns.Add(colTax);
// If the OrderId is 'Total', compute the due on all orders; or compute the due on this order.
DataColumn colTotal = new DataColumn(&quot;TotalDue&quot;, typeof(Decimal),
    &quot;IIF(OrderId='Total',Sum(SubTotal)&#43;Sum(Tax),SubTotal&#43;Tax)&quot;);
orderTable.Columns.Add(colTotal);
DataRow totalRow = orderTable.NewRow();
totalRow[&quot;OrderId&quot;] = &quot;Total&quot;;
orderTable.Rows.Add(totalRow);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span><span style="font-size:11pt">3. Use Select method and Compute method
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Use Select method to get the rows
</span><span style="font-size:11pt">bas</span><span style="font-size:11pt">ed on</span><span style="font-size:11pt">
</span><span style="font-size:11pt">the Territory in the </span><span style="font-size:11pt">SalesPerson</span><span style="font-size:11pt"> Table.</span><span style="font-size:11pt"> And also use Compute method to get the Total result.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
String[] territories = { &quot;Europe&quot;, &quot;North America&quot;};
Console.WriteLine(&quot;Following is the sales information for every territories.&quot;);
foreach(String territory in territories)
{
    String expression = String.Format(&quot;Parent.Territory='{0}'&quot;,
        territory);
    Object total = orderTable.Compute(&quot;Sum(TotalDue)&quot;, expression);
    Console.WriteLine(&quot;Sales information in {0}(Total:{1:C}):&quot;, territory, total);
    DataRow[] territoryRows = orderTable.Select(expression);
    ShowRows(territoryRows);
}
</pre>
<pre class="hidden">
Dim territories() As String = {&quot;Europe&quot;, &quot;North America&quot;}
Console.WriteLine(&quot;Following is the sales information for every territories.&quot;)
For Each territory As String In territories
    Dim expression As String = String.Format(&quot;Parent.Territory='{0}'&quot;, territory)
    Dim total As Object = orderTable.Compute(&quot;Sum(TotalDue)&quot;, expression)
    Console.WriteLine(&quot;Sales information in {0}(Total:{1:C}):&quot;, territory, total)
    Dim territoryRows() As DataRow = orderTable.Select(expression)
    ShowRows(territoryRows)
Next territory
</pre>
<pre id="codePreview" class="csharp">
String[] territories = { &quot;Europe&quot;, &quot;North America&quot;};
Console.WriteLine(&quot;Following is the sales information for every territories.&quot;);
foreach(String territory in territories)
{
    String expression = String.Format(&quot;Parent.Territory='{0}'&quot;,
        territory);
    Object total = orderTable.Compute(&quot;Sum(TotalDue)&quot;, expression);
    Console.WriteLine(&quot;Sales information in {0}(Total:{1:C}):&quot;, territory, total);
    DataRow[] territoryRows = orderTable.Select(expression);
    ShowRows(territoryRows);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span><span style="font-size:11pt">4. Use Select method and Like</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Use select method and Like to get all the Bikes&rsquo; sales information.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Following is the sales information for all the bikes.&quot;);
DataRow[] bikeRows = orderDetailTable.Select(&quot;Product like '*Bike'&quot;);
ShowRows(bikeRows);
</pre>
<pre class="hidden">
Console.WriteLine(&quot;Following is the sales information for all the bikes.&quot;)
Dim bikeRows() As DataRow = orderDetailTable.Select(&quot;Product like '*Bike'&quot;)
ShowRows(bikeRows)
</pre>
<pre id="codePreview" class="csharp">
Console.WriteLine(&quot;Following is the sales information for all the bikes.&quot;);
DataRow[] bikeRows = orderDetailTable.Select(&quot;Product like '*Bike'&quot;);
ShowRows(bikeRows);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/way3dy9w.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataTable.Select</span><span style="color:#0563C1; text-decoration:underline"> Method
 (String, String)</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.data.datatable.compute.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataTable.Compute</span><span style="color:#0563C1; text-decoration:underline">
 Method</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.data.datacolumn.expression.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataColumn.Expression</span><span style="color:#0563C1; text-decoration:underline">
 Property</span></a></span> </p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
