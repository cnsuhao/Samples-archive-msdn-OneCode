# How to get a distinct, ordered list of names from a DataTable using LINQ
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* LINQ
* .NET Framework
## Topics
* LINQ
* DataTable
## IsPublished
* True
## ModifiedDate
* 2014-08-31 11:12:12
## Description

<h1><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></h1>
<h1>How to get a distinct, ordered list of names from a DataTable using LINQ (VBDataTable2ListLINQOperation)</h1>
<h2>Introduction</h2>
<p>The project illustrates how to get a distinct, ordered list of names from a DataTable using LINQ.</p>
<p>Lots of developers ask about this in the MSDN forums, so we create the code sample to address the frequently asked programming scenario.</p>
<h2>Building the Project</h2>
<p>Just build the sample in Visual Studio.</p>
<h2>Running the Sample</h2>
<ol>
<li>Create a Console Application in Visual Studio 2013. </li><li>Ensure we have a valid DataTable with us. </li><li>In this example, we consider Employee entity with Id, Name, Location columns </li><li>When you run the application, you will see the following output. </li></ol>
<p><img id="124631" src="/site/view/file/124631/1/1.png" alt="" width="669" height="334"></p>
<h2>Using the code</h2>
<p>&nbsp; &nbsp; 1. Employee class:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Class Employee
    Public Property Id As Integer
    Public Property Name As String
    Public Property Location As String
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Class</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;Id&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Integer</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;Name&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Property</span>&nbsp;Location&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">String</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp; &nbsp; 2.EmployeeComparer class.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Class EmployeeComparer
    Implements IEqualityComparer(Of Employee)

    ' Products are equal if their names and product numbers are equal. 
    Public Function Equals1(ByVal x As Employee, ByVal y As Employee
            ) As Boolean Implements IEqualityComparer(Of Employee).Equals

        ' Check whether the compared objects reference the same data. 
        If x Is y Then Return True

        'Check whether any of the compared objects is null. 
        If x Is Nothing OrElse y Is Nothing Then Return False

        'Check whether the products' properties are equal. 
        Return x.Id = y.Id AndAlso x.Name = y.Name AndAlso x.Location = y.Location
    End Function

    ' If Equals() returns true for a pair of objects  
    ' then GetHashCode() must return the same value for these objects. 

    Public Function GetHashCode1(
        ByVal employee As Employee
        ) As Integer Implements IEqualityComparer(Of Employee).GetHashCode

        ' Check whether the object is null. 
        If employee Is Nothing Then Return 0

        'Get hash code for the Id field if it is not null. 
        Dim hashEmployeeId As Integer = employee.Id.GetHashCode()

        'Get hash code for the Name field if it is not null. 
        Dim hashEmployeeName As Integer = If(employee.Name Is Nothing, 0, employee.Name.GetHashCode())

        'Get hash code for the Location field. 
        Dim hashEmployeeLocation As Integer = If(employee.Location Is Nothing, 0, employee.Location.GetHashCode())

        'Calculate the hash code for the product. 
        Return hashEmployeeId Xor hashEmployeeName Xor hashEmployeeLocation
    End Function

End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Class</span>&nbsp;EmployeeComparer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IEqualityComparer(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Products&nbsp;are&nbsp;equal&nbsp;if&nbsp;their&nbsp;names&nbsp;and&nbsp;product&nbsp;numbers&nbsp;are&nbsp;equal.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Equals1(<span class="visualBasic__keyword">ByVal</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IEqualityComparer(<span class="visualBasic__keyword">Of</span>&nbsp;Employee).Equals&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Check&nbsp;whether&nbsp;the&nbsp;compared&nbsp;objects&nbsp;reference&nbsp;the&nbsp;same&nbsp;data.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;whether&nbsp;any&nbsp;of&nbsp;the&nbsp;compared&nbsp;objects&nbsp;is&nbsp;null.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">OrElse</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;whether&nbsp;the&nbsp;products'&nbsp;properties&nbsp;are&nbsp;equal.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;x.Id&nbsp;=&nbsp;y.Id&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;x.Name&nbsp;=&nbsp;y.Name&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;x.Location&nbsp;=&nbsp;y.Location&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;Equals()&nbsp;returns&nbsp;true&nbsp;for&nbsp;a&nbsp;pair&nbsp;of&nbsp;objects&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;then&nbsp;GetHashCode()&nbsp;must&nbsp;return&nbsp;the&nbsp;same&nbsp;value&nbsp;for&nbsp;these&nbsp;objects.&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetHashCode1(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;employee&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;<span class="visualBasic__keyword">Implements</span>&nbsp;IEqualityComparer(<span class="visualBasic__keyword">Of</span>&nbsp;Employee).GetHashCode&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Check&nbsp;whether&nbsp;the&nbsp;object&nbsp;is&nbsp;null.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;employee&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Get&nbsp;hash&nbsp;code&nbsp;for&nbsp;the&nbsp;Id&nbsp;field&nbsp;if&nbsp;it&nbsp;is&nbsp;not&nbsp;null.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hashEmployeeId&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;employee.Id.GetHashCode()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Get&nbsp;hash&nbsp;code&nbsp;for&nbsp;the&nbsp;Name&nbsp;field&nbsp;if&nbsp;it&nbsp;is&nbsp;not&nbsp;null.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hashEmployeeName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(employee.Name&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;employee.Name.GetHashCode())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Get&nbsp;hash&nbsp;code&nbsp;for&nbsp;the&nbsp;Location&nbsp;field.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hashEmployeeLocation&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(employee.Location&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;employee.Location.GetHashCode())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Calculate&nbsp;the&nbsp;hash&nbsp;code&nbsp;for&nbsp;the&nbsp;product.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;hashEmployeeId&nbsp;<span class="visualBasic__keyword">Xor</span>&nbsp;hashEmployeeName&nbsp;<span class="visualBasic__keyword">Xor</span>&nbsp;hashEmployeeLocation&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp; &nbsp; &nbsp;3.&nbsp;The main function</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Sub Main()

    ' Get the data table
    Dim sourceData As DataTable = GetDataSource()

    ' Convert it to a new employee list
    Dim employeeList As List(Of Employee) = sourceData.AsEnumerable().Select(Function(rw) New Employee() With { _
                                                                                 .Id = Int32.Parse(rw(&quot;Id&quot;).ToString()), _
                                                                                 .Name = rw(&quot;Name&quot;).ToString(), _
                                                                                 .Location = rw(&quot;Location&quot;).ToString() _
                                                    }).ToList()

    ' Read out the list items
    Console.WriteLine(vbLf &amp; &quot;Employee list:&quot;)
    ReadEmployees(employeeList)

    ' Take the distinct employee list
    Dim distinctEmployeeList As List(Of Employee) = employeeList.Distinct(New EmployeeComparer()).ToList()

    ' Read out the distinct list items
    Console.WriteLine(vbLf &amp; &quot;Distinct Employee list:&quot;)
    ReadEmployees(distinctEmployeeList)


    ' Take the ordered employee list by Location
    Dim orderedEmployeeList As List(Of Employee) = distinctEmployeeList.OrderBy(Function(x) x.Location).ToList()

    ' Read out the ordered list items by Location 
    Console.WriteLine(vbLf &amp; &quot;Ordered by Location Employee list:&quot;)
    ReadEmployees(orderedEmployeeList)

End Sub

' Read through the list
Private Sub ReadEmployees(employeeList As List(Of Employee))
    For Each emp As Employee In employeeList
        Console.WriteLine((emp.Id.ToString() &#43; vbTab &#43; emp.Name &amp; vbTab) &#43; emp.Location)
    Next
End Sub

' Prepare the data table
Private Function GetDataSource() As DataTable
    ' Prepare schema
    Dim dt As New DataTable(&quot;TestDB&quot;)
    dt.Columns.Add(&quot;Id&quot;, GetType(System.Int32))
    dt.Columns.Add(&quot;Name&quot;, GetType(System.String))
    dt.Columns.Add(&quot;Location&quot;, GetType(System.String))

    ' way 1: Create a row for the table
    Dim row As DataRow = dt.NewRow()
    row(&quot;Id&quot;) = 1236
    row(&quot;Name&quot;) = &quot;James&quot;
    row(&quot;Location&quot;) = &quot;NewYork&quot;
    dt.Rows.Add(row)

    ' way 2: Create a row for the table
    dt.Rows.Add(New Object() {4321, &quot;Brian&quot;, &quot;Boston&quot;})
    dt.Rows.Add(New Object() {3213, &quot;Jeff&quot;, &quot;Chicago&quot;})
    dt.Rows.Add(New Object() {5435, &quot;Adam&quot;, &quot;NewYork&quot;})
    dt.Rows.Add(New Object() {3453, &quot;Brian&quot;, &quot;Dallas&quot;})
    dt.Rows.Add(New Object() {5344, &quot;Kayle&quot;, &quot;Dallas&quot;})
    dt.Rows.Add(New Object() {3213, &quot;Jeff&quot;, &quot;Chicago&quot;})

    ' return the populated data table
    Return dt
End Function

End Module
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Sub</span>&nbsp;Main()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Get&nbsp;the&nbsp;data&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sourceData&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable&nbsp;=&nbsp;GetDataSource()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Convert&nbsp;it&nbsp;to&nbsp;a&nbsp;new&nbsp;employee&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;employeeList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;=&nbsp;sourceData.AsEnumerable().<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(rw)&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Employee()&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Id&nbsp;=&nbsp;Int32.Parse(rw(<span class="visualBasic__string">&quot;Id&quot;</span>).ToString()),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;rw(<span class="visualBasic__string">&quot;Name&quot;</span>).ToString(),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Location&nbsp;=&nbsp;rw(<span class="visualBasic__string">&quot;Location&quot;</span>).ToString()&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).ToList()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Read&nbsp;out&nbsp;the&nbsp;list&nbsp;items</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(vbLf&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;Employee&nbsp;list:&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ReadEmployees(employeeList)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Take&nbsp;the&nbsp;distinct&nbsp;employee&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;distinctEmployeeList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;=&nbsp;employeeList.Distinct(<span class="visualBasic__keyword">New</span>&nbsp;EmployeeComparer()).ToList()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Read&nbsp;out&nbsp;the&nbsp;distinct&nbsp;list&nbsp;items</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(vbLf&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;Distinct&nbsp;Employee&nbsp;list:&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ReadEmployees(distinctEmployeeList)&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Take&nbsp;the&nbsp;ordered&nbsp;employee&nbsp;list&nbsp;by&nbsp;Location</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;orderedEmployeeList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Employee)&nbsp;=&nbsp;distinctEmployeeList.OrderBy(<span class="visualBasic__keyword">Function</span>(x)&nbsp;x.Location).ToList()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Read&nbsp;out&nbsp;the&nbsp;ordered&nbsp;list&nbsp;items&nbsp;by&nbsp;Location&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(vbLf&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;Ordered&nbsp;by&nbsp;Location&nbsp;Employee&nbsp;list:&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ReadEmployees(orderedEmployeeList)&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Read&nbsp;through&nbsp;the&nbsp;list</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ReadEmployees(employeeList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Employee))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;emp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Employee&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;employeeList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine((emp.Id.ToString()&nbsp;&#43;&nbsp;vbTab&nbsp;&#43;&nbsp;emp.Name&nbsp;&amp;&nbsp;vbTab)&nbsp;&#43;&nbsp;emp.Location)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Prepare&nbsp;the&nbsp;data&nbsp;table</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetDataSource()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Prepare&nbsp;schema</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable(<span class="visualBasic__string">&quot;TestDB&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="visualBasic__string">&quot;Id&quot;</span>,&nbsp;<span class="visualBasic__keyword">GetType</span>(System.Int32))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="visualBasic__string">&quot;Name&quot;</span>,&nbsp;<span class="visualBasic__keyword">GetType</span>(System.<span class="visualBasic__keyword">String</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="visualBasic__string">&quot;Location&quot;</span>,&nbsp;<span class="visualBasic__keyword">GetType</span>(System.<span class="visualBasic__keyword">String</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;way&nbsp;1:&nbsp;Create&nbsp;a&nbsp;row&nbsp;for&nbsp;the&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;=&nbsp;dt.NewRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Id&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">1236</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Name&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;James&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Location&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;NewYork&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(row)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;way&nbsp;2:&nbsp;Create&nbsp;a&nbsp;row&nbsp;for&nbsp;the&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">4321</span>,&nbsp;<span class="visualBasic__string">&quot;Brian&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Boston&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">3213</span>,&nbsp;<span class="visualBasic__string">&quot;Jeff&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Chicago&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">5435</span>,&nbsp;<span class="visualBasic__string">&quot;Adam&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;NewYork&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">3453</span>,&nbsp;<span class="visualBasic__string">&quot;Brian&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Dallas&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">5344</span>,&nbsp;<span class="visualBasic__string">&quot;Kayle&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Dallas&quot;</span>})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{<span class="visualBasic__number">3213</span>,&nbsp;<span class="visualBasic__string">&quot;Jeff&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Chicago&quot;</span>})&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;return&nbsp;the&nbsp;populated&nbsp;data&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dt&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Module</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<h2>More Information</h2>
</div>
<div class="endscriptcode">
<ul>
<li><a href="http://stackoverflow.com/questions/59/how-do-i-get-a-distinct-ordered-list-of-names-from-a-datatable-using-linq" target="_blank">http://stackoverflow.com/questions/59/how-do-i-get-a-distinct-ordered-list-of-names-from-a-datatable-using-linq</a>
</li></ul>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<ul>
<li><a href="http://forums.asp.net/t/1617515.aspx?How&#43;to&#43;get&#43;the&#43;distinct&#43;value&#43;form&#43;DataTable&#43;using&#43;LINQ" target="_blank">http://forums.asp.net/t/1617515.aspx?How&#43;to&#43;get&#43;the&#43;distinct&#43;value&#43;form&#43;DataTable&#43;using&#43;LINQ</a>
</li></ul>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p><span>&nbsp;</span><span style="font-size:11pt; line-height:27.6pt">&nbsp;</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a name="_GoBack"></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
