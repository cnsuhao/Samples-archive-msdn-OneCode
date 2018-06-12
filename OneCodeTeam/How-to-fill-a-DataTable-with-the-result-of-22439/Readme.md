# How to fill a DataTable with the result of LinqToEntity
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* DataTable
* Lint to Entity
* CopyToDataTable
## IsPublished
* True
## ModifiedDate
* 2013-06-05 01:28:07
## Description

<h1>The Sample Demonstrates How to Fill a DataTable with the Result of a Linq to Entity Query (VBEFtoDataTable)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to fill a DataTable with the result of the Linq to Entity query.</p>
<p class="MsoNormal">Linq to Entity is a simple way for the developers, but sometimes we need to use the DataTable. In this sample, we demonstrate two ways to fill a DataTable with the result of the Linq to Entity query:</p>
<p class="MsoNormal">1. Use the connection string and query string that we get from the Linq to Entity;</p>
<p class="MsoNormal">2. Use the custom CopyToDataTable method.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following steps:</p>
<p class="MsoNormal">Step1. Attach the database file MySchool.mdf under the folder _External_Dependencies to your SQL Server 2008 database instance.</p>
<p class="MsoNormal">Step2. Modify the connection string in the App.config file according to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83595/1/image.png" alt="" width="574" height="380" align="middle">
</span></p>
<p class="MsoNormal">Now the sample uses the DbContext to execute the operations, but it also can use the ObjectContext:</p>
<p class="MsoNormal">1. Choose the &quot;VBEFtoDataTable&quot; project and press the &quot;Show All Files&quot; button<span style="">
<img src="/site/view/file/83596/1/image.png" alt="" width="15" height="16" align="middle">
</span>.</p>
<p class="MsoNormal">2. Right click the &quot;DbMySchool.Context.tt&quot; and the &quot;DbMySchool.tt&quot; files, and then click the &quot;Exclude From Project&quot;.</p>
<p class="MsoNormal">3. Right click the &quot;ObjectMySchool.tt&quot; file and click the &quot;Include In Project&quot;.</p>
<p class="MsoNormal">4. Press F5 to run the sample.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
A. Use the connection string and query string to fill a DataTable.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the connection string, query string and the parameters from the Linq to Entity.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If TypeOf context Is DbContext Then
&nbsp;&nbsp;&nbsp; Dim query As DbQuery(Of T) = TryCast(result, DbQuery(Of T))


&nbsp;&nbsp;&nbsp; ' Get the query string.
&nbsp;&nbsp;&nbsp; queryString = query.ToString()
&nbsp;&nbsp;&nbsp; ' Because the DeQuery doesn't support the parameters collection, we use 
&nbsp;&nbsp;&nbsp;&nbsp;' the reflection to get the ObjectQuery, and then get the parameters collection.
&nbsp;&nbsp;&nbsp; Dim objectQuery As ObjectQuery = GetObjectQuery(query)
&nbsp;&nbsp;&nbsp; parameters = GetSqlParameters(objectQuery.Parameters)
&nbsp;&nbsp;&nbsp; ' Get the collection string.
&nbsp;&nbsp;&nbsp; connectionString = (TryCast(context, DbContext)).Database.Connection.ConnectionString
ElseIf TypeOf context Is ObjectContext Then
&nbsp;&nbsp;&nbsp; Dim query As ObjectQuery = TryCast(result, ObjectQuery)


&nbsp;&nbsp;&nbsp; ' Get the query string.
&nbsp;&nbsp;&nbsp; queryString = query.ToTraceString()
&nbsp;&nbsp;&nbsp; ' Get the parameters collection.
&nbsp;&nbsp;&nbsp; parameters = GetSqlParameters(query.Parameters)
&nbsp;&nbsp;&nbsp; ' Get the connection string.
&nbsp;&nbsp;&nbsp; Dim connection As EntityConnection = TryCast((TryCast(context, ObjectContext)).Connection, EntityConnection)
&nbsp;&nbsp;&nbsp; connectionString = connection.StoreConnection.ConnectionString
End If

</pre>
<pre id="codePreview" class="vb">
If TypeOf context Is DbContext Then
&nbsp;&nbsp;&nbsp; Dim query As DbQuery(Of T) = TryCast(result, DbQuery(Of T))


&nbsp;&nbsp;&nbsp; ' Get the query string.
&nbsp;&nbsp;&nbsp; queryString = query.ToString()
&nbsp;&nbsp;&nbsp; ' Because the DeQuery doesn't support the parameters collection, we use 
&nbsp;&nbsp;&nbsp;&nbsp;' the reflection to get the ObjectQuery, and then get the parameters collection.
&nbsp;&nbsp;&nbsp; Dim objectQuery As ObjectQuery = GetObjectQuery(query)
&nbsp;&nbsp;&nbsp; parameters = GetSqlParameters(objectQuery.Parameters)
&nbsp;&nbsp;&nbsp; ' Get the collection string.
&nbsp;&nbsp;&nbsp; connectionString = (TryCast(context, DbContext)).Database.Connection.ConnectionString
ElseIf TypeOf context Is ObjectContext Then
&nbsp;&nbsp;&nbsp; Dim query As ObjectQuery = TryCast(result, ObjectQuery)


&nbsp;&nbsp;&nbsp; ' Get the query string.
&nbsp;&nbsp;&nbsp; queryString = query.ToTraceString()
&nbsp;&nbsp;&nbsp; ' Get the parameters collection.
&nbsp;&nbsp;&nbsp; parameters = GetSqlParameters(query.Parameters)
&nbsp;&nbsp;&nbsp; ' Get the connection string.
&nbsp;&nbsp;&nbsp; Dim connection As EntityConnection = TryCast((TryCast(context, ObjectContext)).Connection, EntityConnection)
&nbsp;&nbsp;&nbsp; connectionString = connection.StoreConnection.ConnectionString
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">The method can be used in the DbContext or the ObjectContext.<span style="">&nbsp;
</span>The DbQuery doesn't contain the parameters collection. So if the context's type is the DbContext, we have to get the ObjectQuery from the DbQuery to get the parameters collection.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Use the SqlDataAdapter to fill a DataTable and return it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using SQLCon As New SqlConnection(connectionString)
&nbsp;&nbsp;&nbsp; Using Cmd As New SqlCommand(queryString, SQLCon)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the parameter collection.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cmd.Parameters.AddRange(parameters)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using da As New SqlDataAdapter(Cmd)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using dt As New DataTable()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; da.Fill(dt)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using SQLCon As New SqlConnection(connectionString)
&nbsp;&nbsp;&nbsp; Using Cmd As New SqlCommand(queryString, SQLCon)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add the parameter collection.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cmd.Parameters.AddRange(parameters)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using da As New SqlDataAdapter(Cmd)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using dt As New DataTable()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; da.Fill(dt)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">B. Use the custom CopyToDataTable method.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. implement two custom CopyToDataTable&lt;T&gt; extension methods</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
&nbsp;&nbsp;&nbsp; Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
End Function


&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
&nbsp;&nbsp;&nbsp; Return New ObjectShredder(Of T)().Shred(source, table, options)
End Function

</pre>
<pre id="codePreview" class="vb">
&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
&nbsp;&nbsp;&nbsp; Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
End Function


&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
&nbsp;&nbsp;&nbsp; Return New ObjectShredder(Of T)().Shred(source, table, options)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Implement the ObjectShredder&lt;T&gt; class that contains the logic to create a DataTable from an IEnumerable&lt;T&gt; source.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Load the table from the scalar sequence if T is a primitive type.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If GetType(T).IsPrimitive Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return ShredPrimitive(source, table, options)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a new table if the input table is null.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If table Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table = New DataTable(GetType(T).Name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the ordinal map and extend the table schema based on type T.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table = ExtendTable(table, GetType(T))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Enumerate the source sequence and load the object values into rows.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.BeginLoadData()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using e As IEnumerator(Of T) = source.GetEnumerator()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do While e.MoveNext()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If options IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LoadDataRow(ShredObject(table, e.Current), CType(options, LoadOption))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LoadDataRow(ShredObject(table, e.Current), True)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.EndLoadData()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Return the table.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return table
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Load the table from the scalar sequence if T is a primitive type.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If GetType(T).IsPrimitive Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return ShredPrimitive(source, table, options)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a new table if the input table is null.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If table Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table = New DataTable(GetType(T).Name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the ordinal map and extend the table schema based on type T.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table = ExtendTable(table, GetType(T))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Enumerate the source sequence and load the object values into rows.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.BeginLoadData()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using e As IEnumerator(Of T) = source.GetEnumerator()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do While e.MoveNext()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If options IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LoadDataRow(ShredObject(table, e.Current), CType(options, LoadOption))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.LoadDataRow(ShredObject(table, e.Current), True)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; table.EndLoadData()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Return the table.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return table
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.DATA.ENTITY.DBCONTEXT.DATABASE);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">DbContext.Database Property</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.DATA.OBJECTS.OBJECTQUERY.PARAMETERS);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">ObjectQuery.Parameters
 Property</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb669096.aspx">custom CopyToDataTable&lt;T&gt; methods</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
