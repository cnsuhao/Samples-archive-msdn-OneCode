# How to Use IDataRecord.GetDataTypeName Method
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Framework
## Topics
* code snippets
* GetDataTypeName
## IsPublished
* True
## ModifiedDate
* 2014-02-24 01:55:48
## Description

<h1>How to Use IDataRecord.GetDataTypeName Method</h1>
<h2>Introduction</h2>
<p><span style="font-size:small">Now there&rsquo;s no code about the IDataRecord.GetDataTypeName Method in MSDN, and the customers want it. In this snippet code, we will demonstrate how to use the DbDataReader.GetInt32 method:</span></p>
<p><span style="font-size:small">1. Create DbConnection, DbCommand;</span></p>
<p><span style="font-size:small">2. Create DbDataReader to read data;</span></p>
<p><span style="font-size:small">3. Use IDataRecord.GetDataTypeName method to get the data type information for the specified field.</span></p>
<h2>Code Snippet&nbsp;</h2>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private static void GetDataTypes(String connectiongString) 
{ 
    using (SqlConnection conn = new SqlConnection(connectiongString)) 
    { 
        String queryString = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot;; 

        using (DbCommand command = new SqlCommand(queryString, conn)) 
        { 
            conn.Open(); 
            using (DbDataReader reader = command.ExecuteReader()) 
            { 
                for (Int32 i = 0; i &lt; reader.FieldCount; i&#43;&#43;) 

                { 
                    Console.WriteLine(&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;,reader.GetName(i),reader.GetDataTypeName(i)); 
                } 
            } 
        } 
    } 
} 
</pre>
<pre class="hidden">Private Shared Sub GetDataTypes(ByVal connectiongString As String) 

 Using conn As New SqlConnection(connectiongString) 

  Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot; 

  Using command As DbCommand = New SqlCommand(queryString, conn) 
   conn.Open() 

   Using reader As DbDataReader = command.ExecuteReader() 
    For i As Int32 = 0 To reader.FieldCount - 1 

     Console.WriteLine(&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;,reader.GetName(i),reader.GetDataTypeName(i)) 
    Next i 
   End Using 
  End Using 
 End Using 
End Sub 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;GetDataTypes(String&nbsp;connectiongString)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectiongString))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;queryString&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&quot;</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(DbCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(queryString,&nbsp;conn))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(DbDataReader&nbsp;reader&nbsp;=&nbsp;command.ExecuteReader())&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(Int32&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;reader.FieldCount;&nbsp;i&#43;&#43;)&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;</span>,reader.GetName(i),reader.GetDataTypeName(i));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<div class="OutlineElement Ltr SCX249033524">
<h2 class="Paragraph SCX249033524"><span class="TextRun SCX249033524">Using the Code</span><span class="EOP SCX249033524">
</span></h2>
</div>
<div class="OutlineElement Ltr SCX249033524">
<p class="Paragraph SCX249033524"><span class="TextRun SCX249033524" style="font-size:small">First, use the following query string to get the results.&nbsp;</span></p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">String queryString = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot;; 
</pre>
<pre class="hidden">Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot; 
</pre>
<div class="preview">
<pre class="js"><span class="js__object">String</span>&nbsp;queryString&nbsp;=&nbsp;<span class="js__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&quot;</span>;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="OutlineElement Ltr SCX114262838">
<p class="Paragraph SCX114262838"><span class="TextRun SCX114262838" style="font-size:small"><span class="NormalTextRun SCX114262838">Then use the
</span><span class="SpellingError SCX114262838">GetDataTypeName</span><span class="NormalTextRun SCX114262838"> method to get the data types of the fields.</span></span></p>
</div>
</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">using (DbDataReader reader = command.ExecuteReader()) 
{ 
    for (Int32 i = 0; i &lt; reader.FieldCount; i&#43;&#43;) 
    { 
        Console.WriteLine(&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;,reader.GetName(i),reader.GetDataTypeName(i)); 
    } 
} 
</pre>
<pre class="hidden">Using reader As DbDataReader = command.ExecuteReader() 

 For i As Int32 = 0 To reader.FieldCount - 1 
  Console.WriteLine(&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;,reader.GetName(i),reader.GetDataTypeName(i)) 

 Next i 
End Using 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(DbDataReader&nbsp;reader&nbsp;=&nbsp;command.ExecuteReader())&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(Int32&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;reader.FieldCount;&nbsp;i&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;ColumnName:{0,-15}DataType:{1,-15}&quot;</span>,reader.GetName(i),reader.GetDataTypeName(i));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<div class="OutlineElement Ltr SCX175866680">
<p class="Paragraph SCX175866680"><span style="font-size:small"><span class="TextRun SCX175866680">You can get the result as follow</span><span class="TextRun SCX175866680">s</span><span class="TextRun SCX175866680">:</span></span><span class="EOP SCX175866680">
</span></p>
</div>
<div class="OutlineElement Ltr SCX175866680">
<p class="Paragraph SCX175866680"><span class="WACImageContainer BlobObject SCX175866680"><img class="WACImage SCX175866680" src="http://sfc-office/we/GetImage.ashx?WOPIsrc=http%3A%2F%2Fworkspace%2Fsfc%2FOneCode%2F%5Fvti%5Fbin%2Fwopi%2Eashx%2Ffiles%2Fe8c772a3201546039608dc411f09a3e2&access_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJ5b1RPQVl2MjZSdER6WVJLbkhNN1ZTLWJfTSJ9%2EeyJhdWQiOiJ3b3BpL3dvcmtzcGFjZUA0OGI4NjZkZS01NjhlLTQ4MjktYmRjYi1lNWM5YjJhM2Y4NDgiLCJpc3MiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDBANDhiODY2ZGUtNTY4ZS00ODI5LWJkY2ItZTVjOWIyYTNmODQ4IiwibmJmIjoiMTM5MzIzNTI1MCIsImV4cCI6IjEzOTMyNzEyNTAiLCJuYW1laWQiOiIwIy53fGZhcmVhc3RcXHYtdG96aGkiLCJuaWkiOiJtaWNyb3NvZnQuc2hhcmVwb2ludCIsImlzdXNlciI6InRydWUiLCJjYWNoZWtleSI6IjApLnd8cy0xLTUtMjEtMjE0Njc3MzA4NS05MDMzNjMyODUtNzE5MzQ0NzA3LTE0Mjg0ODAiLCJpc2xvb3BiYWNrIjoiVHJ1ZSIsImFwcGN0eCI6ImU4Yzc3MmEzMjAxNTQ2MDM5NjA4ZGM0MTFmMDlhM2UyO05hZEZOK2Q1US9WZDVXMVg0b2pCVkxQcW1Paz07RGVmYXVsdDs7MUIwM0M0MzFBRUY7VHJ1ZSJ9%2Ekv3dJzt7V%5F146QEDvN2O4LepcGJ86T6WstXILKEyj4i6m%5FGT8k99De0o7v0endQsWMP2aENjE8YMEyhrswfLymkV%5FX1DYgzQUmu%5FhJM3UmvA%5FXh4vG268nXAIq4sgt9eebj6u%5FRflFirGExOmY5dJbH%5FleEZFubqppbvsnuo5IMBkPCrJy%5FZzudkgRPMy3WHLjDNVrRi2jEmgIh37u2mVGZzGAfKnY19OlK84QrgNNX9uly494hjiwwuM5GFFlRRB7qJNtTURpE6zluzxTZ8b4jAxjpZPATk2NQYL9HXDBJMnFGYrFuRTPL4LOVmOuf72vDx9U5lmb3Yu346t5q94A&access_token_ttl=1393271250389&ObjectDataBlobId={270f5049-352e-5fdf-86ed-3fcb4036395a}{1}&usid=f2393e72-4c15-43cf-a431-7de5f8e878ad&Word=1" alt="Image"></span><span class="EOP SCX175866680">
</span></p>
</div>
<div class="OutlineElement Ltr SCX175866680">
<h2 class="Paragraph SCX175866680"><span class="TextRun SCX175866680">More Information</span><span class="EOP SCX175866680">
</span></h2>
</div>
<div class="OutlineElement Ltr SCX175866680">
<p class="Paragraph SCX175866680"><span class="TextRun Underlined SCX175866680" style="font-size:small"><span class="NormalTextRun SCX175866680">IDataRecord.GetDataTypeName Method</span></span></p>
<p class="Paragraph SCX175866680"><span class="TextRun Underlined SCX175866680" style="font-size:small"><span class="NormalTextRun SCX175866680"><a href="http://msdn.microsoft.com/en-us/library/system.data.idatarecord.getdatatypename(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.idatarecord.getdatatypename(v=vs.110).aspx</a><br>
</span></span></p>
</div>
<p><span style="font-size:small">SqlConnection Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx</a></span></p>
<p><span style="font-size:small">SqlCommand Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx</a></span></p>
<p><span style="font-size:small">DbDataReader Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/System.Data.Common.DbDataReader(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/System.Data.Common.DbDataReader(v=vs.110).aspx</a></span></p>
<p><span style="font-size:small">DbDataReader Methods</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader_methods(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader_methods(v=vs.110).aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
