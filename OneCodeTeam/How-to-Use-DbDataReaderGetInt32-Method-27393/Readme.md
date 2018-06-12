# How to Use DbDataReader.GetInt32 Method
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
* GetInt32
## IsPublished
* True
## ModifiedDate
* 2014-02-24 01:46:24
## Description

<div class="OutlineElement Ltr SCX151345884">
<h1 class="Paragraph SCX151345884"><span class="TextRun SCX151345884">How to Use DbDataReader.GetInt32 Method</span><span class="EOP SCX151345884">
</span></h1>
</div>
<div class="OutlineElement Ltr SCX151345884">
<h2 class="Paragraph SCX151345884"><span class="TextRun SCX151345884">Introduction</span><span class="EOP SCX151345884">
</span></h2>
</div>
<div class="OutlineElement Ltr SCX151345884">
<p class="Paragraph SCX151345884"><span style="font-size:small"><span class="TextRun SCX151345884">DbDataReader.GetInt32 Method</span><span class="TextRun SCX151345884"> gets the value of the specified column as a 32-bit signed integer. In this
 snippet, we will demonstrate how to use </span><span class="TextRun SCX151345884">DbDataReader.GetInt32 Method</span><span class="TextRun SCX151345884">.</span><span class="EOP SCX151345884">
</span></span></p>
</div>
<div class="OutlineElement Ltr SCX151345884">
<p class="Paragraph SCX151345884"><span style="font-size:small"><span class="TextRun SCX151345884"><span class="NormalTextRun SCX151345884">1. Create
</span><span class="SpellingError SCX151345884">DbConnection</span><span class="NormalTextRun SCX151345884">,
</span><span class="SpellingError SCX151345884">DbCommand</span><span class="NormalTextRun SCX151345884">;</span></span><span class="EOP SCX151345884">
</span></span></p>
</div>
<div class="OutlineElement Ltr SCX151345884">
<p class="Paragraph SCX151345884"><span style="font-size:small"><span class="TextRun SCX151345884"><span class="NormalTextRun SCX151345884">2. Create
</span><span class="SpellingError SCX151345884">DbDataReader</span><span class="NormalTextRun SCX151345884"> to read data;</span></span><span class="EOP SCX151345884">
</span></span></p>
</div>
<div class="OutlineElement Ltr SCX151345884">
<p class="Paragraph SCX151345884"><span class="TextRun SCX151345884" style="font-size:small">3. Use DbDataReader.GetInt32 method to get the Data of Int32 type;</span></p>
<div class="OutlineElement Ltr SCX85042296">
<h2 class="Paragraph SCX85042296"><span class="TextRun SCX85042296">Code Snippet</span></h2>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private static void GetCredits(String connectiongString) 
{ 
    using (SqlConnection conn = new SqlConnection(connectiongString)) 
    { 
        String queryString = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot;; 
        using (DbCommand command = new SqlCommand(queryString, conn)) 
        { 
            conn.Open(); 
            using (DbDataReader reader = command.ExecuteReader()) 
            { 
                while (reader.Read()) 
                { 
                    // Credits column is the integer column, and you can use the GetInt32 method  

                    // to return a a 32-bit signed integer. 
                    Console.WriteLine(&quot;Course:{0,-15} Credits:{1}&quot;,reader[1],reader.GetInt32(2)); 
                } 
            }                    
        }                
    } 
}
</pre>
<pre class="hidden">Private Shared Sub GetCredits(ByVal connectiongString As String) 

 Using conn As New SqlConnection(connectiongString) 
  Dim queryString As String = &quot;Select [CourseID],[Title],[Credits] from [MySchool].[dbo].[Course]&quot; 

  Using command As DbCommand = New SqlCommand(queryString, conn) 

   conn.Open() 

   Using reader As DbDataReader = command.ExecuteReader() 

    Do While reader.Read() 

     ' Credits column is the integer column, and you can use the GetInt32 method  

     ' to return a a 32-bit signed integer. 

     Console.WriteLine(&quot;Course:{0,-15} Credits:{1}&quot;,reader(1),reader.GetInt32(2)) 

    Loop 

   End Using 

  End Using 

 End Using 

End Sub 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;GetCredits(String&nbsp;connectiongString)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(connectiongString))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;queryString&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(DbCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(queryString,&nbsp;conn))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(DbDataReader&nbsp;reader&nbsp;=&nbsp;command.ExecuteReader())&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.Read())&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Credits&nbsp;column&nbsp;is&nbsp;the&nbsp;integer&nbsp;column,&nbsp;and&nbsp;you&nbsp;can&nbsp;use&nbsp;the&nbsp;GetInt32&nbsp;method&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;to&nbsp;return&nbsp;a&nbsp;a&nbsp;32-bit&nbsp;signed&nbsp;integer.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Course:{0,-15}&nbsp;Credits:{1}&quot;</span>,reader[<span class="cs__number">1</span>],reader.GetInt32(<span class="cs__number">2</span>));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="OutlineElement Ltr SCX61504562">
<h2 class="Paragraph SCX61504562"><span class="TextRun SCX61504562">Using the Code</span><span class="EOP SCX61504562">
</span></h2>
</div>
<div class="OutlineElement Ltr SCX61504562">
<p class="Paragraph SCX61504562"><span style="font-size:small"><span class="TextRun SCX61504562">First, use the following query string to get the results. The Credits column is
</span><span class="TextRun SCX61504562">the Integer column, and it&rsquo;s also
</span><span class="TextRun SCX61504562">the 2</span><span class="TextRun SCX61504562"><span class="NormalTextRun SCX61504562">nd</span></span><span class="TextRun SCX61504562"> column in the zero-based column ordinal.</span></span></p>
<p class="Paragraph SCX61504562"></p>
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
<pre class="csharp">String&nbsp;queryString&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;[CourseID],[Title],[Credits]&nbsp;from&nbsp;[MySchool].[dbo].[Course]&quot;</span>;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<div class="OutlineElement Ltr SCX6780389">
<p class="Paragraph SCX6780389"><span class="TextRun SCX6780389">Then </span>
<span class="TextRun SCX6780389">you</span><span class="TextRun SCX6780389"> can use the GetInt32 method to get the
</span><span class="TextRun SCX6780389">value of Credits column.</span></p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">Console.WriteLine(&quot;Course:{0,-15} Credits:{1}&quot;,reader[1],reader.GetInt32(2)); 
</pre>
<pre class="hidden">Console.WriteLine(&quot;Course:{0,-15} Credits:{1}&quot;,reader(1),reader.GetInt32(2)) 
</pre>
<div class="preview">
<pre class="js">Console.WriteLine(<span class="js__string">&quot;Course:{0,-15}&nbsp;Credits:{1}&quot;</span>,reader[<span class="js__num">1</span>],reader.GetInt32(<span class="js__num">2</span>));&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="OutlineElement Ltr SCX227931887">
<p class="Paragraph SCX227931887"><span style="font-size:small"><span class="TextRun SCX227931887">You can get the result</span><span class="TextRun SCX227931887"> as follow</span><span class="TextRun SCX227931887">s</span><span class="TextRun SCX227931887">:</span></span><span class="EOP SCX227931887">
</span></p>
</div>
<div class="OutlineElement Ltr SCX227931887">
<p class="Paragraph SCX227931887"><span class="WACImageContainer BlobObject SCX227931887"><img class="WACImage SCX227931887" src="http://sfc-office/we/GetImage.ashx?WOPIsrc=http%3A%2F%2Fworkspace%2Fsfc%2FOneCode%2F%5Fvti%5Fbin%2Fwopi%2Eashx%2Ffiles%2Fbe5061ed510f4c5fbf20840a381ca82c&access_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjJ5b1RPQVl2MjZSdER6WVJLbkhNN1ZTLWJfTSJ9%2EeyJhdWQiOiJ3b3BpL3dvcmtzcGFjZUA0OGI4NjZkZS01NjhlLTQ4MjktYmRjYi1lNWM5YjJhM2Y4NDgiLCJpc3MiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDBANDhiODY2ZGUtNTY4ZS00ODI5LWJkY2ItZTVjOWIyYTNmODQ4IiwibmJmIjoiMTM5MzIzNDEzOCIsImV4cCI6IjEzOTMyNzAxMzgiLCJuYW1laWQiOiIwIy53fGZhcmVhc3RcXHYtdG96aGkiLCJuaWkiOiJtaWNyb3NvZnQuc2hhcmVwb2ludCIsImlzdXNlciI6InRydWUiLCJjYWNoZWtleSI6IjApLnd8cy0xLTUtMjEtMjE0Njc3MzA4NS05MDMzNjMyODUtNzE5MzQ0NzA3LTE0Mjg0ODAiLCJpc2xvb3BiYWNrIjoiVHJ1ZSIsImFwcGN0eCI6ImJlNTA2MWVkNTEwZjRjNWZiZjIwODQwYTM4MWNhODJjO05hZEZOK2Q1US9WZDVXMVg0b2pCVkxQcW1Paz07RGVmYXVsdDs7MUIwM0M0MzFBRUY7VHJ1ZSJ9%2Ei5dtiM%5Fd%5FMaHTW85YtverzEA7B07uogTcOL5mvivHEeaqD1GYUpfPq9pYGDDsnxE0w6RaxBAMjNP9HhIVv0xLRKKDyLr4TU9Yz3878gapNpfvg3II8g%5FhC1HmtlwGYzmeYYvGdj%5FjZEScP33u%5FWmfm%2Dv9iNrM5ET1Qn9jJy0JeDRhjblo2Fvq4sC7dLDUi29aOvX8dpLe0fS8BZlODES3MGB6nsjjA4rcT4K6mttU8z4Jx1MLVMOu8af2W6h7h7OaQV1EuGTtq9e%2Dja%2DMXBhOSgwJtP%2DpKpoF9e04qys%5Ft1L%2DEt8Qzs3RiPliFO7wegmkgrhoFdIXTtBZKr4kjGUBw&access_token_ttl=1393270138838&ObjectDataBlobId={c72b0f06-8a8b-5a3b-a487-00932547a1db}{1}&usid=45745978-92cd-4310-a9ac-17c52925b2fb&Word=1" alt="Image"></span><span class="EOP SCX227931887">
</span></p>
</div>
<div class="OutlineElement Ltr SCX227931887">
<h2 class="Paragraph SCX227931887"><span class="TextRun SCX227931887">More Information</span><span class="EOP SCX227931887">
</span></h2>
</div>
<div class="OutlineElement Ltr SCX227931887">
<p class="Paragraph SCX227931887"><span class="TextRun Underlined SCX227931887" style="font-size:small"><span class="NormalTextRun SCX227931887">DbDataReader.GetInt32 Method</span></span></p>
</div>
</div>
<p class="Paragraph SCX61504562"><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader.getint32(VS.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader.getint32(VS.110).aspx</a></span></p>
<p><span style="font-size:small">SqlConnection Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.aspx</a></span></p>
<p><span style="font-size:small">SqlCommand Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.aspx</a></span></p>
<p>&nbsp;<span style="font-size:small">DbDataReader Class</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader(v=vs.110).aspx</a></span></p>
<p><span style="font-size:small">DbDataReader Methods</span></p>
<p><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader_methods(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.common.dbdatareader_methods(v=vs.110).aspx</a><br>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p class="Paragraph SCX61504562">&nbsp;</p>
</div>
</div>
</div>
