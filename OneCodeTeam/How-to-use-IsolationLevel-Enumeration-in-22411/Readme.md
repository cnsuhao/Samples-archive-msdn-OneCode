# How to use IsolationLevel Enumeration in DbTransaction
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* IsolationLevel
* DbTransaction
## IsPublished
* True
## ModifiedDate
* 2013-06-26 01:28:37
## Description

<h1>How to Use the IsolationLevel Enumeration in DbTransaction (VBDataIsolationLevel)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In this application, we will demonstrate how to use the IsolationLevel Enumeration in DbTransaction.</p>
<p class="MsoNormal">We will show you which of the following behaviors are allowed in the different isolation levels.</p>
<p class="MsoNormal">1. Dirty reads;</p>
<p class="MsoNormal">Dirty read occurs when a second transaction selects a row that is being updated by another transaction. The second transaction is reading data that has not been committed yet and may be changed by the transaction updating the row.</p>
<p class="MsoNormal">2. Non-repeatable reads;</p>
<p class="MsoNormal">Non-repeatable read occurs when a second transaction accesses the same row several times and reads different data each time.</p>
<p class="MsoNormal">3. Phantoms.</p>
<p class="MsoNormal">Phantom reads occur when an insert or delete action is performed against a row that belongs to a range of rows being read by a transaction.</p>
<p class="MsoNormal" style="">Please refer the <span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/ms190805(v=sql.105).aspx">Concurrency Effects</a>
</span>to get more details.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">We will execute the following up behaviors in the following isolation levels:</p>
<p class="MsoNormal">1. ReadUncommitted;</p>
<p class="MsoNormal">2. ReadCommitted;</p>
<p class="MsoNormal">3. RepeatableRead;</p>
<p class="MsoNormal">4. Serializable; </p>
<p class="MsoNormal">5. Snapshot.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following step:</p>
<p class="MsoNormal">Step1. Modify the connection string in the Project Properties-&gt;Settings according-&gt; MyConnectionString to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86765/1/image.png" alt="" width="641" height="37" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
First, we create the Database 'DbDataIsolationLevel'.<span style="font-size:9.5pt; font-family:Consolas; color:#A31515">
</span></p>
<p class="MsoNormal">Then we will demonstrate which of the following behaviors the transactions will allow.</p>
<p class="MsoNormal"><b style="">1. Dirty Reads </b></p>
<p class="MsoNormal">We will add the values into the Quantity value of product (ProductId=1) in two threads. The first transaction in first thread will roll back and the second transaction in second thread will commit.</p>
<p class="MsoNormal">If the transaction allows Dirty Reads behavior, the value will be added twice (original value is 365):</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86766/1/image.png" alt="" width="641" height="48" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">Or the value will only be added once:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86767/1/image.png" alt="" width="643" height="49" align="middle">
</span></p>
<p class="MsoNormal"><b style="">2. Non-repeatable Reads </b></p>
<p class="MsoNormal">We will execute two Select operations in first thread to get the product (ProductId=1). And we also update the product (ProductId=1) between the two Select operations in second thread.</p>
<p class="MsoNormal">If the transaction allows Non-repeatable Reads behavior, the two Select operations will get the different results:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86768/1/image.png" alt="" width="641" height="88" align="middle">
</span></p>
<p class="MsoNormal">Or the two Select operations will get the same result:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86769/1/image.png" alt="" width="643" height="88" align="middle">
</span></p>
<p class="MsoNormal"><b style="">3. Phantoms Reads </b></p>
<p class="MsoNormal">We will execute two Select operations in first thread to get the product (All). And we also insert a new product between the two Select operations in second thread.</p>
<p class="MsoNormal">If the transaction allows Phantoms Reads behavior, the two Select operations will get the different results:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86770/1/image.png" alt="" width="637" height="169" align="middle">
</span></p>
<p class="MsoNormal">Or the two Select operations will get the same result:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86771/1/image.png" alt="" width="649" height="157" align="middle">
</span></p>
<p class="MsoNormal">As the result, we can find: the ReadUncommitted transaction allows the Dirty Reads, Non-repeatable and Reads Phantoms Reads behaviors; the ReadCommitted transaction allows the Non-repeatable and Reads Phantoms Reads behaviors; the RepeatableRead
 transaction allows the Phantoms Reads behavior; the Serializable and Snapshot transactions don't allow any of the following up behaviors.</p>
<p class="MsoNormal"><b style="">4. Difference between the Serializable and Snapshot transactions
</b></p>
<p class="MsoNormal">The Serializable and Snapshot transactions don't allow any of the following up behaviors, but they also have some difference.</p>
<p class="MsoNormal">We will get the Price of product (ProductId=2) and update the Price of product (ProductId=1) with the value in first thread. And then get the Price of product (ProductId=1) and update the Price of product (ProductId=2) with the value
 in second thread. After that, we commit the two transactions in two threads.</p>
<p class="MsoNormal">In Serializable transaction, the Price values will be same:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86772/1/image.png" alt="" width="640" height="69" align="middle">
</span></p>
<p class="MsoNormal">In Snapshot transaction, the Price values will be exchanged:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/86773/1/image.png" alt="" width="641" height="76" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. <b style="">Dirty Reads</b></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The first thread will add the values into the Quantity value of product (ProductId=1) , and then roll back the transaction.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp; &quot; Update dbo.Products set Quantity=Quantity&#43;100 where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06';&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;DirtyReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tran IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Rollback()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp; &quot; Update dbo.Products set Quantity=Quantity&#43;100 where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06';&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;DirtyReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tran IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Rollback()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The second thread will add the values into the Quantity value of product (ProductId=1) too, and then commit the transaction.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @qty int;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @qty=Quantity from dbo.Products where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Quantity=@qty&#43;100 where ProductId=1;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;DirtyReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @qty int;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @qty=Quantity from dbo.Products where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Quantity=@qty&#43;100 where ProductId=1;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;DirtyReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style=""><b style="">2. Non-repeatable Reads </b></p>
<p class="MsoNormal" style="">First thread will execute two Select operations to get the product (ProductId=1).
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;where ProductId=1&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WaitFor Delay '00:00:06';&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;where ProductId=1&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;NonrepeatableReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using reader As SqlDataReader = command.ExecuteReader()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim isFirstReader As Boolean = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of {0} read:&quot;, If(isFirstReader, &quot;first&quot;, &quot;second&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TransactionIsolationLevels.DisplayData(reader)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFirstReader = Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop While reader.NextResult() AndAlso Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;where ProductId=1&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WaitFor Delay '00:00:06';&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;where ProductId=1&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;NonrepeatableReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using reader As SqlDataReader = command.ExecuteReader()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim isFirstReader As Boolean = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of {0} read:&quot;, If(isFirstReader, &quot;first&quot;, &quot;second&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TransactionIsolationLevels.DisplayData(reader)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFirstReader = Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop While reader.NextResult() AndAlso Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Second thread will update the product (ProductId=1) between the two Select operations.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Quantity=Quantity&#43;100 where ProductId=1;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;NonrepeatableReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Quantity=Quantity&#43;100 where ProductId=1;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;NonrepeatableReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><b style=""></b></p>
<p class="MsoNormal" style=""><b style="">3. Phantoms Reads </b></p>
<p class="MsoNormal" style="">First thread will execute two Select operations to get the product (All).
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06';&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;PhantomReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using reader As SqlDataReader = command.ExecuteReader()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim isFirstReader As Boolean = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of {0} read:&quot;, If(isFirstReader, &quot;first&quot;, &quot;second&quot;))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TransactionIsolationLevels.DisplayData(reader)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFirstReader = Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop While reader.NextResult() AndAlso Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06';&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Select ProductId,ProductName,Quantity,Price&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;from dbo.Products&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;PhantomReadFirst&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using reader As SqlDataReader = command.ExecuteReader()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim isFirstReader As Boolean = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Do
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's the result of {0} read:&quot;, If(isFirstReader, &quot;first&quot;, &quot;second&quot;))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TransactionIsolationLevels.DisplayData(reader)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFirstReader = Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Loop While reader.NextResult() AndAlso Not isFirstReader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Second thread will insert a new product between the two Select operations.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;VALUES (N'White Bike', 843, 1349.00)&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;PhantomReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;VALUES (N'White Bike', 843, 1349.00)&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;PhantomReadSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style=""><b style="">4. Difference between the Serializable and Snapshot transactions
</b></p>
<p class="MsoNormal" style="">First thread will get the Price of product (ProductId=2) and update the Price of product (ProductId=1) with the value.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @price money;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @price=Price from dbo.Products where ProductId=2;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Price=@price where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06'; &quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;ExchangeValuesFirst&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @price money;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @price=Price from dbo.Products where ProductId=2;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Price=@price where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;WaitFor Delay '00:00:06'; &quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;ExchangeValuesFirst&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Second thread will get the Price of product (ProductId=1) and update the Price of product (ProductId=2) with the value.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @price money;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @price=Price from dbo.Products where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Price=@price where ProductId=2;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;ExchangeValuesSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
<pre id="codePreview" class="vb">
Using conn As New SqlConnection(connStrig)
&nbsp;&nbsp;&nbsp; Dim cmdText As String = &quot;Use DbDataIsolationLevel;&quot; & ControlChars.CrLf &
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;WaitFor Delay '00:00:03'; &quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Declare @price money;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;select @price=Price from dbo.Products where ProductId=1;&quot; & ControlChars.CrLf &
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;Update dbo.Products set Price=@price where ProductId=2;&quot;


&nbsp;&nbsp;&nbsp; conn.Open()


&nbsp;&nbsp;&nbsp; Using tran As SqlTransaction = conn.BeginTransaction(level, &quot;ExchangeValuesSecond&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using command As New SqlCommand(cmdText, conn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.Transaction = tran


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; command.ExecuteNonQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tran.Commit()
&nbsp;&nbsp;&nbsp; End Using
End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.data.isolationlevel(VS.110).aspx"><span class="SpellE">IsolationLevel</span> Enumeration
</a></span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/Bb350727(v=vs.110).aspx"><span class="SpellE">SqlConnection.BeginTransaction</span> Method
</a></span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/ms190805(v=sql.105).aspx">Concurrency Effects</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
