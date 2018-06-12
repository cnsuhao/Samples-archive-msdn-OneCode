# How to Use IDataAdapter.GetFillParameters Method
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
* GetFillParameters
## IsPublished
* True
## ModifiedDate
* 2014-02-24 01:25:04
## Description

<h1>How to Use IDataAdapter.GetFillParameters Method &nbsp;</h1>
<h2>Introduction</h2>
<p>N<span style="font-size:small">ow there&rsquo;s no code about the IDataAdapter.GetFillParameters Method in MSDN, and the customers want it. In this snippet code, we will demonstrate how to use the IDataAdapter.GetFillParameters method:</span></p>
<p><span style="font-size:small">1. Create DbConnection, DbCommand;</span></p>
<p><span style="font-size:small">2. Add the Parameters to the DbCommand;</span></p>
<p><span style="font-size:small">3. Create the DataAdapter and set the Connection and Command;</span></p>
<p><span style="font-size:small">4. Use IDataAdapter.GetFillParameters method to get the parameters array.</span></p>
<h2>Code Snippet&nbsp;</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private static void GetParameters(String connectiongString) 
{ 
    using (SqlConnection conn = new SqlConnection(connectiongString)) 
    { 
        String queryString = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course] where [Year]=@Year and [Credits]&gt;=@Credits&quot;; 
        SqlParameter year = new SqlParameter(&quot;@Year&quot;, 2012); 
        SqlParameter credits = new SqlParameter(&quot;@Credits&quot;, SqlDbType.Int, 4, &quot;Credits&quot;); 

        credits.Value = 4; 
        SqlCommand command = new SqlCommand(queryString, conn); 
        command.Parameters.Add(year); 
        command.Parameters.Add(credits); 
        IDbDataAdapter mySchool = new SqlDataAdapter(command); 
        IDataParameter[] parameters = mySchool.GetFillParameters(); 
        Console.WriteLine(&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;, &quot;ParameterName&quot;, &quot;SourceColumn&quot;, &quot;Direction&quot;, &quot;DbType&quot;, &quot;Value&quot;); 
       
   foreach (IDataParameter parameter in parameters) 
        { 
            Console.WriteLine(&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;, parameter.ParameterName, parameter.SourceColumn, parameter.Direction, parameter.DbType, parameter.Value); 
        } 
    } 
}
</pre>
<pre class="hidden">Private Shared Sub GetParameters(ByVal connectiongString As String) 

 Using conn As New SqlConnection(connectiongString) 

  Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course] where [Year]=@Year and [Credits]&gt;=@Credits&quot; 

  Dim year As New SqlParameter(&quot;@Year&quot;, 2012) 

  Dim credits As New SqlParameter(&quot;@Credits&quot;, SqlDbType.Int, 4, &quot;Credits&quot;) 

  credits.Value = 4 

  Dim command As New SqlCommand(queryString, conn) 

  command.Parameters.Add(year) 

  command.Parameters.Add(credits) 

  Dim mySchool As IDbDataAdapter = New SqlDataAdapter(command) 

  Dim parameters() As IDataParameter = mySchool.GetFillParameters() 

  Console.WriteLine(&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;, &quot;ParameterName&quot;, &quot;SourceColumn&quot;, &quot;Direction&quot;, &quot;DbType&quot;, &quot;Value&quot;) 

  For Each parameter As IDataParameter In parameters 

   Console.WriteLine(&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;, parameter.ParameterName, parameter.SourceColumn, parameter.Direction, parameter.DbType, parameter.Value) 
  Next parameter 
 End Using 
End Sub 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;GetParameters(String&nbsp;connectiongString)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectiongString))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;queryString&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&nbsp;where&nbsp;[Year]=@Year&nbsp;and&nbsp;[Credits]&gt;=@Credits&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;year&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlParameter(<span class="cs__string">&quot;@Year&quot;</span>,&nbsp;<span class="cs__number">2012</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;credits&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlParameter(<span class="cs__string">&quot;@Credits&quot;</span>,&nbsp;SqlDbType.Int,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__string">&quot;Credits&quot;</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;credits.Value&nbsp;=&nbsp;<span class="cs__number">4</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(queryString,&nbsp;conn);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;command.Parameters.Add(year);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;command.Parameters.Add(credits);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDbDataAdapter&nbsp;mySchool&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDataAdapter(command);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDataParameter[]&nbsp;parameters&nbsp;=&nbsp;mySchool.GetFillParameters();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;</span>,&nbsp;<span class="cs__string">&quot;ParameterName&quot;</span>,&nbsp;<span class="cs__string">&quot;SourceColumn&quot;</span>,&nbsp;<span class="cs__string">&quot;Direction&quot;</span>,&nbsp;<span class="cs__string">&quot;DbType&quot;</span>,&nbsp;<span class="cs__string">&quot;Value&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(IDataParameter&nbsp;parameter&nbsp;<span class="cs__keyword">in</span>&nbsp;parameters)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}&quot;</span>,&nbsp;parameter.ParameterName,&nbsp;parameter.SourceColumn,&nbsp;parameter.Direction,&nbsp;parameter.DbType,&nbsp;parameter.Value);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<h2>Using the Code</h2>
<p><span style="font-size:small">First, define a query string that contains two parameters.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course] where [Year]=@Year and [Credits]&gt;=@Credits&quot;</pre>
<pre class="hidden">Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course] where [Year]=@Year and [Credits]&gt;=@Credits&quot;</pre>
<div class="preview">
<pre class="csharp">Dim&nbsp;queryString&nbsp;As&nbsp;String&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&nbsp;where&nbsp;[Year]=@Year&nbsp;and&nbsp;[Credits]&gt;=@Credits&quot;</span></pre>
</div>
</div>
</div>
<p><span style="font-size:small">Then, define two parameters. The second parameter contains more details besides the parameter name and value.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">SqlParameter year = new SqlParameter(&quot;@Year&quot;, 2012);
SqlParameter credits = new SqlParameter(&quot;@Credits&quot;, SqlDbType.Int, 4, &quot;Credits&quot;);
credits.Value = 4;
</pre>
<pre class="hidden">Dim year As New SqlParameter(&quot;@Year&quot;, 2012)
Dim credits As New SqlParameter(&quot;@Credits&quot;, SqlDbType.Int, 4, &quot;Credits&quot;)
credits.Value = 4
</pre>
<div class="preview">
<pre class="csharp">SqlParameter&nbsp;year&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlParameter(<span class="cs__string">&quot;@Year&quot;</span>,&nbsp;<span class="cs__number">2012</span>);&nbsp;
SqlParameter&nbsp;credits&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlParameter(<span class="cs__string">&quot;@Credits&quot;</span>,&nbsp;SqlDbType.Int,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__string">&quot;Credits&quot;</span>);&nbsp;
credits.Value&nbsp;=&nbsp;<span class="cs__number">4</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small">After adding the command that is set with the query string and the parameters into the IDbDataAdapter, use GetFillParameters method to get the parameters.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">SqlCommand command = new SqlCommand(queryString, conn);
command.Parameters.Add(year);
command.Parameters.Add(credits);
IDbDataAdapter mySchool = new SqlDataAdapter(command);
IDataParameter[] parameters = mySchool.GetFillParameters();
</pre>
<pre class="hidden">Dim command As New SqlCommand(queryString, conn)
command.Parameters.Add(year)
command.Parameters.Add(credits)
Dim mySchool As IDbDataAdapter = New SqlDataAdapter(command)
Dim parameters() As IDataParameter = mySchool.GetFillParameters()
</pre>
<div class="preview">
<pre class="csharp">SqlCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(queryString,&nbsp;conn);&nbsp;
command.Parameters.Add(year);&nbsp;
command.Parameters.Add(credits);&nbsp;
IDbDataAdapter&nbsp;mySchool&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDataAdapter(command);&nbsp;
IDataParameter[]&nbsp;parameters&nbsp;=&nbsp;mySchool.GetFillParameters();&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p><span style="font-size:small">You can get the result as following:</span></p>
<p><span class="WACImageContainer BlobObject SCX39504481"><img class="WACImage SCX39504481" src="http://sfc-office/we/GetImage.ashx?WOPIsrc=http%3A%2F%2Fworkspace%2Fsfc%2FOneCode%2F%5Fvti%5Fbin%2Fwopi%2Eashx%2Ffiles%2Fd6fda4bf00c241e0baaca891b98d0d31&access_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJ5b1RPQVl2MjZSdER6WVJLbkhNN1ZTLWJfTSJ9%2EeyJhdWQiOiJ3b3BpL3dvcmtzcGFjZUA0OGI4NjZkZS01NjhlLTQ4MjktYmRjYi1lNWM5YjJhM2Y4NDgiLCJpc3MiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDBANDhiODY2ZGUtNTY4ZS00ODI5LWJkY2ItZTVjOWIyYTNmODQ4IiwibmJmIjoiMTM5MzIzMzUxOSIsImV4cCI6IjEzOTMyNjk1MTkiLCJuYW1laWQiOiIwIy53fGZhcmVhc3RcXHYtdG96aGkiLCJuaWkiOiJtaWNyb3NvZnQuc2hhcmVwb2ludCIsImlzdXNlciI6InRydWUiLCJjYWNoZWtleSI6IjApLnd8cy0xLTUtMjEtMjE0Njc3MzA4NS05MDMzNjMyODUtNzE5MzQ0NzA3LTE0Mjg0ODAiLCJpc2xvb3BiYWNrIjoiVHJ1ZSIsImFwcGN0eCI6ImQ2ZmRhNGJmMDBjMjQxZTBiYWFjYTg5MWI5OGQwZDMxO05hZEZOK2Q1US9WZDVXMVg0b2pCVkxQcW1Paz07RGVmYXVsdDs7MUIwM0M0MzFBRUY7VHJ1ZSJ9%2ENoacSSNEA4wqeQhCChIXnuP8kJ3w3KbKLYQXy043E2kUDCMJxi5LaBVhfUsKzFO%5FID8A3XgOFA3SAqoBZ56QGUGfXcLARxFKAxb1fVT2%5FLKg1na98V7j0w6BmJr5EKVu8xZyqDsoJg7LztQvRSp11kUrs4LdRcRMmkr5fdnN%2Dpq2ej4iiEO3xg%5FGXkrgSa4CFQz1hR1lu%5FhpRTbL1ivtVmFuC%5FvWszjeoWxfrQe%5FK78xn4g%2DkWVSSJdCCpY%2DEKCUyRuct%5Fgry%2DgrUSDkrG733w%2DbgHw4mbVaKW0eckVDJIhN7ypvRKZSsMI%5FXbQMiVR6PQIp2c9Jvba9e2AC2OZDGA&access_token_ttl=1393269519697&ObjectDataBlobId={c2312b1a-9585-5182-ab32-0b3e99da36ff}{1}&usid=29742924-450d-49c9-85c6-48d76fd83f3e&Word=1" alt="Image"></span></p>
<h2>More Information</h2>
<p><span style="font-size:small">IDataAdapter.GetFillParameters Method</span></p>
</div>
</div>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.idataadapter.getfillparameters(VS.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.idataadapter.getfillparameters(VS.110).aspx</a></span></p>
<p><span style="font-size:small">SqlConnection Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx</a></span></p>
<p><span style="font-size:small">SqlCommand Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx</a></span></p>
<p></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p></p>
