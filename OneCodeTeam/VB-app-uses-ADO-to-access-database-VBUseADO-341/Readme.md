# VB app uses ADO to access database (VBUseADO)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* ADO
## Topics
* Interop
* Data Platform
## IsPublished
* True
## ModifiedDate
* 2012-09-27 10:18:39
## Description

<h1>VB app uses ADO to access database (<span class="SpellE">VBUseADO</span>)<span style="">
</span></h1>
<h2>Introduction<span style=""> </span></h2>
<p class="MsoNormal"><span style="">The <span class="SpellE">VBUseADO</span> sample demonstrates the Microsoft ADO technology to access databases using Visual Basic. It shows the basic structure of connecting to a data source, issuing SQL commands, using
 Recordset object and performing the cleanup. </span></p>
<h2><span style="">Building the sample </span></h2>
<p class="MsoNormal"><span style="">Attach the <b style="">_<span class="SpellE">External_Dependencies</span>\SQLServer2005DB.mdf</b> to your SQL Server (2005 or later versions).
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/67306/1/image.png" alt="" width="826" height="366" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Connect to the data source<span style="">.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'///////////////////////////////////////////////////////////////////////////////
' Connect to the data source.
' 


Console.WriteLine(&quot;Connecting to the database ...&quot;)


' Get the connection string        
Dim connStr As String = String.Format(&quot;Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI&quot;, _
                                      &quot;.\sqlexpress&quot;, &quot;SQLServer2005DB&quot;)


' Open the connection
conn = New ADODB.Connection()
conn.Open(connStr, Nothing, Nothing, 0)

</pre>
<pre id="codePreview" class="vb">
'///////////////////////////////////////////////////////////////////////////////
' Connect to the data source.
' 


Console.WriteLine(&quot;Connecting to the database ...&quot;)


' Get the connection string        
Dim connStr As String = String.Format(&quot;Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI&quot;, _
                                      &quot;.\sqlexpress&quot;, &quot;SQLServer2005DB&quot;)


' Open the connection
conn = New ADODB.Connection()
conn.Open(connStr, Nothing, Nothing, 0)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build and execute an ADO command. </p>
<p class="MsoListParagraphCxSpLast"><span style="">T</span>he command can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored<span style="">
</span>procedure call. <span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'///////////////////////////////////////////////////////////////////////////////
' Build and Execute an ADO Command.
' It can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored 
' procedure call. Here is the sample of an INSERT command.
' 


Console.WriteLine(&quot;Inserting a record to the CountryRegion table...&quot;)


' 1. Create a command object
Dim cmdInsert As New ADODB.Command()


' 2. Assign the connection to the command
cmdInsert.ActiveConnection = conn


' 3. Set the command text
' SQL statement or the name of the stored procedure 
cmdInsert.CommandText = &quot;INSERT INTO CountryRegion(CountryRegionCode, Name, ModifiedDate) VALUES (?, ?, ?)&quot;


' 4. Set the command type
' ADODB.CommandTypeEnum.adCmdText for oridinary SQL statements; 
' ADODB.CommandTypeEnum.adCmdStoredProc for stored procedures.
cmdInsert.CommandType = ADODB.CommandTypeEnum.adCmdText


' 5. Append the parameters


' Append the parameter for CountryRegionCode (nvarchar(20)
' Parameter name
' Parameter type (nvarchar(20))
' Parameter direction
' Max size of value in bytes
Dim paramCode As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;CountryRegionCode&quot;, _
ADODB.DataTypeEnum.adVarChar, _
ADODB.ParameterDirectionEnum.adParamInput, _
20, _
&quot;ZZ&quot; & DateTime.Now.Millisecond)




' Parameter value
cmdInsert.Parameters.Append(paramCode)


' Append the parameter for Name (nvarchar(200))
' Parameter name
' Parameter type (nvarchar(200))
' Parameter direction
' Max size of value in bytes
Dim paramName As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;Name&quot;, _
ADODB.DataTypeEnum.adVarChar, _
ADODB.ParameterDirectionEnum.adParamInput, _
200, _
&quot;Test Region Name&quot;)


' Parameter value
cmdInsert.Parameters.Append(paramName)


' Append the parameter for ModifiedDate (datetime)
' Parameter name
' Parameter type (datetime)
' Parameter direction
' Max size (ignored for datetime)
Dim paramModifiedDate As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;ModifiedDate&quot;, _
ADODB.DataTypeEnum.adDate, _
ADODB.ParameterDirectionEnum.adParamInput, _
-1, _
DateTime.Now)


' Parameter value
cmdInsert.Parameters.Append(paramModifiedDate)


' 6. Execute the command
Dim nRecordsAffected As Object = Type.Missing
Dim oParams As Object = Type.Missing
cmdInsert.Execute(nRecordsAffected, oParams, CInt(ADODB.ExecuteOptionEnum.adExecuteNoRecords))

</pre>
<pre id="codePreview" class="vb">
'///////////////////////////////////////////////////////////////////////////////
' Build and Execute an ADO Command.
' It can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored 
' procedure call. Here is the sample of an INSERT command.
' 


Console.WriteLine(&quot;Inserting a record to the CountryRegion table...&quot;)


' 1. Create a command object
Dim cmdInsert As New ADODB.Command()


' 2. Assign the connection to the command
cmdInsert.ActiveConnection = conn


' 3. Set the command text
' SQL statement or the name of the stored procedure 
cmdInsert.CommandText = &quot;INSERT INTO CountryRegion(CountryRegionCode, Name, ModifiedDate) VALUES (?, ?, ?)&quot;


' 4. Set the command type
' ADODB.CommandTypeEnum.adCmdText for oridinary SQL statements; 
' ADODB.CommandTypeEnum.adCmdStoredProc for stored procedures.
cmdInsert.CommandType = ADODB.CommandTypeEnum.adCmdText


' 5. Append the parameters


' Append the parameter for CountryRegionCode (nvarchar(20)
' Parameter name
' Parameter type (nvarchar(20))
' Parameter direction
' Max size of value in bytes
Dim paramCode As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;CountryRegionCode&quot;, _
ADODB.DataTypeEnum.adVarChar, _
ADODB.ParameterDirectionEnum.adParamInput, _
20, _
&quot;ZZ&quot; & DateTime.Now.Millisecond)




' Parameter value
cmdInsert.Parameters.Append(paramCode)


' Append the parameter for Name (nvarchar(200))
' Parameter name
' Parameter type (nvarchar(200))
' Parameter direction
' Max size of value in bytes
Dim paramName As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;Name&quot;, _
ADODB.DataTypeEnum.adVarChar, _
ADODB.ParameterDirectionEnum.adParamInput, _
200, _
&quot;Test Region Name&quot;)


' Parameter value
cmdInsert.Parameters.Append(paramName)


' Append the parameter for ModifiedDate (datetime)
' Parameter name
' Parameter type (datetime)
' Parameter direction
' Max size (ignored for datetime)
Dim paramModifiedDate As ADODB.Parameter = cmdInsert.CreateParameter( _
&quot;ModifiedDate&quot;, _
ADODB.DataTypeEnum.adDate, _
ADODB.ParameterDirectionEnum.adParamInput, _
-1, _
DateTime.Now)


' Parameter value
cmdInsert.Parameters.Append(paramModifiedDate)


' 6. Execute the command
Dim nRecordsAffected As Object = Type.Missing
Dim oParams As Object = Type.Missing
cmdInsert.Execute(nRecordsAffected, oParams, CInt(ADODB.ExecuteOptionEnum.adExecuteNoRecords))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use the Recordset object. </p>
<p class="MsoListParagraphCxSpLast">Recordset represents the entire set of records from a base table or the results of an executed command. It facilitates the enumeration, insertion, update, deletion of records. At any time, the Recordset object refers to
 only a single record within the set as the current record.<span style=""> </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Enumerating the records in the CountryRegion table&quot;)


 ' 1. Create a Recordset object
 rs = New ADODB.Recordset()


 ' 2. Open the Recordset object
 Dim strSelectCmd As String = &quot;SELECT * FROM CountryRegion&quot; ' WHERE ...


 ' SQL statement / table,view name /
 ' stored procedure call / file name
 ' Connection / connection string
 ' Cursor type. (forward-only cursor)
 ' Lock type. (locking records only 
 ' when you call the Update method.
 ' Evaluate the first parameter as
 ' a SQL command or stored procedure.


 rs.Open(strSelectCmd, _
         conn, _
         ADODB.CursorTypeEnum.adOpenForwardOnly, _
         ADODB.LockTypeEnum.adLockOptimistic, _
         CInt(ADODB.CommandTypeEnum.adCmdText))


 ' 3. Enumerate the records by moving the cursor forward
 rs.MoveFirst()
 ' Move to the first record in the Recordset
 While (Not rs.EOF)


     ' When dumping a SQL-Nullable field in the table, need to test it for 
     ' DBNull.Value.
     Dim code As String = If(rs.Fields(&quot;CountryRegionCode&quot;).Value Is DBNull.Value, _
                             &quot;(DBNull)&quot;, rs.Fields(&quot;CountryRegionCode&quot;).Value.ToString())


     Dim name As String = If(rs.Fields(&quot;Name&quot;).Value Is DBNull.Value, _
                             &quot;(DBNull)&quot;, rs.Fields(&quot;Name&quot;).Value.ToString())


     Dim modifiedDate As Date = If(rs.Fields(&quot;ModifiedDate&quot;).Value Is DBNull.Value, _
                                   Date.MinValue, CDate(rs.Fields(&quot;ModifiedDate&quot;).Value))




     Console.WriteLine(&quot; {2} &quot; & vbTab & &quot;{0}&quot; & vbTab & &quot;{1}&quot;, code, name, modifiedDate.ToString(&quot;yyyy-MM-dd&quot;))


     ' Move to the next record
     rs.MoveNext()
 End While

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(&quot;Enumerating the records in the CountryRegion table&quot;)


 ' 1. Create a Recordset object
 rs = New ADODB.Recordset()


 ' 2. Open the Recordset object
 Dim strSelectCmd As String = &quot;SELECT * FROM CountryRegion&quot; ' WHERE ...


 ' SQL statement / table,view name /
 ' stored procedure call / file name
 ' Connection / connection string
 ' Cursor type. (forward-only cursor)
 ' Lock type. (locking records only 
 ' when you call the Update method.
 ' Evaluate the first parameter as
 ' a SQL command or stored procedure.


 rs.Open(strSelectCmd, _
         conn, _
         ADODB.CursorTypeEnum.adOpenForwardOnly, _
         ADODB.LockTypeEnum.adLockOptimistic, _
         CInt(ADODB.CommandTypeEnum.adCmdText))


 ' 3. Enumerate the records by moving the cursor forward
 rs.MoveFirst()
 ' Move to the first record in the Recordset
 While (Not rs.EOF)


     ' When dumping a SQL-Nullable field in the table, need to test it for 
     ' DBNull.Value.
     Dim code As String = If(rs.Fields(&quot;CountryRegionCode&quot;).Value Is DBNull.Value, _
                             &quot;(DBNull)&quot;, rs.Fields(&quot;CountryRegionCode&quot;).Value.ToString())


     Dim name As String = If(rs.Fields(&quot;Name&quot;).Value Is DBNull.Value, _
                             &quot;(DBNull)&quot;, rs.Fields(&quot;Name&quot;).Value.ToString())


     Dim modifiedDate As Date = If(rs.Fields(&quot;ModifiedDate&quot;).Value Is DBNull.Value, _
                                   Date.MinValue, CDate(rs.Fields(&quot;ModifiedDate&quot;).Value))




     Console.WriteLine(&quot; {2} &quot; & vbTab & &quot;{0}&quot; & vbTab & &quot;{1}&quot;, code, name, modifiedDate.ToString(&quot;yyyy-MM-dd&quot;))


     ' Move to the next record
     rs.MoveNext()
 End While

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Clean up objects before exit. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'///////////////////////////////////////////////////////////////////////////////
' Clean up objects before exit.
' 


Console.WriteLine(&quot;Closing the connections ...&quot;)


' Close the record set if it is open
If rs IsNot Nothing AndAlso rs.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
    rs.Close()
End If


' Close the connection to the database if it is open
If conn IsNot Nothing AndAlso conn.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
    conn.Close()
End If

</pre>
<pre id="codePreview" class="vb">
'///////////////////////////////////////////////////////////////////////////////
' Clean up objects before exit.
' 


Console.WriteLine(&quot;Closing the connections ...&quot;)


' Close the record set if it is open
If rs IsNot Nothing AndAlso rs.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
    rs.Close()
End If


' Close the connection to the database if it is open
If conn IsNot Nothing AndAlso conn.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
    conn.Close()
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://support.microsoft.com/kb/308611">HOW TO: Open ADO Connection and
<span class="SpellE">RecordSet</span> Objects in Visual C# .NET</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
