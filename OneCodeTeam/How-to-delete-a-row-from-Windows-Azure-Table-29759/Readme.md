# How to delete a row from Windows Azure Table storage without retrieving it first
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Azure
* Cloud
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-07-10 02:18:08
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="">How to reduce the times of requests sent to Azure Storage Service in Windows Store apps
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">When you develop an app that needs connecting to Azure storage service, it will take a long time to send requests and get responses in the client application.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">This sample demonstrates how reduce the times of connection between client app and Azure storage service. It also shows how to handle general exception when you get the response.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="">Building the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="color:#000000">Create a new
</span><span style="font-weight:bold; color:#000000">Storage Account</span><span style="color:#000000"> from the Windows Azure Management Portal.</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="color:#000000">To do this, follow the instructions in </span>
<a href="http://www.windowsazure.com/en-us/manage/services/storage/how-to-create-a-storage-account/" style="text-decoration:none"><span style="color:#0563C1; color:#960BB4; text-decoration:underline">How To Create a Storage Account</span></a><span style="color:#000000">.</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="color:#000000">Get the </span><span style="font-weight:bold; color:#000000">Storage Account Keys</span><span style="color:#000000">. Browse to your storage account dashboard and click
</span><span style="font-weight:bold; color:#000000">Manage Access Keys</span><span style="color:#000000"> on the bottom bar.</span><span style="font-size:11pt">
<br clear="all">
</span><a name="_GoBack"></a><span style="font-size:11pt"><img src="/site/view/file/119797/1/image.png" alt="" width="201" height="57" align="middle">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="color:#000000">Copy the </span><span style="font-weight:bold; color:#000000">Storage Account Name</span><span style="color:#000000"> and
</span><span style="font-weight:bold; color:#000000">Primary Access Key</span><span style="color:#000000"> values.</span><span style="font-size:11pt">
<br clear="all">
</span><span style="font-size:11pt"><br clear="all">
</span><span style="font-size:11pt"><img src="/site/view/file/119798/1/image.png" alt="" width="479" height="403" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="">Open this project, go to the
</span><span style="font-weight:bold">Solution-&gt;Project-&gt;DataSource-&gt;TableDataSource.cs
</span><span style="">file, replace account name and account key you copied in the step 1.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="">Build the project, download the class library from nugget.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt; text-indent:-18pt">
<span style="font-size:11pt">&bull;&nbsp; <span style="">Press </span><span style="font-weight:bold">F5</span><span style=""> to start the app.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">1.</span><span style=""> </span><span style="">This app only has one page view: main page view.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/119799/1/image.png" alt="" width="193" height="479" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">2.</span><span style=""> </span><span style="">You can Click the
</span><span style="font-weight:bold">Delete</span><span style=""> button first, then use the
</span><span style="font-weight:bold">Regenerate the Sample data </span><span style="">button to create the sample data.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">The code sample provides the following reusable functions to handle Azure storage transient fault error.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:26.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt; font-weight:bold"><span style="">How to handle conflict error?</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
public class ConflictRetryPolicy:IRetryPolicy 
   { 
       int maxRetryAttemps = 10; 
       TimeSpan defaultRetryInterval = TimeSpan.FromSeconds(5); 
 
       public ConflictRetryPolicy(TimeSpan deltaBackoff, int retryAttempts) 
       { 
           maxRetryAttemps = retryAttempts; 
           defaultRetryInterval = deltaBackoff; 
       } 
 
       public IRetryPolicy CreateInstance() 
       { 
           return new ConflictRetryPolicy(TimeSpan.FromSeconds(5), 10); 
       } 
 
       public bool ShouldRetry(int currentRetryCount, int statusCode, Exception lastException, out TimeSpan retryInterval, OperationContext operationContext) 
       { 
           retryInterval = defaultRetryInterval; 
           if (currentRetryCount &gt;= maxRetryAttemps) 
           { 
               return false; 
           } 
           if (statusCode == 409) 
           { 
               return true; 
           } 
           else 
           { 
               return false; 
           } 
       } 
   } 
</pre>
<pre class="hidden">
Public Class ConflictRetryPolicy
    Implements IRetryPolicy
    Private maxRetryAttemps As Integer = 10
    Private defaultRetryInterval As TimeSpan = TimeSpan.FromSeconds(5)
    Public Sub New(deltaBackoff As TimeSpan, retryAttempts As Integer)
        maxRetryAttemps = retryAttempts
        defaultRetryInterval = deltaBackoff
    End Sub
    Public Function CreateInstance() As IRetryPolicy Implements IRetryPolicy.CreateInstance
        Return New ConflictRetryPolicy(TimeSpan.FromSeconds(5), 10)
    End Function
    Public Function ShouldRetry(currentRetryCount As Integer, statusCode As Integer, lastException As Exception, ByRef retryInterval As TimeSpan, operationContext As Microsoft.WindowsAzure.Storage.OperationContext) As Boolean Implements IRetryPolicy.ShouldRetry
        retryInterval = defaultRetryInterval
        If currentRetryCount &gt;= maxRetryAttemps Then
            Return False
        End If
        If statusCode = 409 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
</pre>
<pre id="codePreview" class="csharp">
public class ConflictRetryPolicy:IRetryPolicy 
   { 
       int maxRetryAttemps = 10; 
       TimeSpan defaultRetryInterval = TimeSpan.FromSeconds(5); 
 
       public ConflictRetryPolicy(TimeSpan deltaBackoff, int retryAttempts) 
       { 
           maxRetryAttemps = retryAttempts; 
           defaultRetryInterval = deltaBackoff; 
       } 
 
       public IRetryPolicy CreateInstance() 
       { 
           return new ConflictRetryPolicy(TimeSpan.FromSeconds(5), 10); 
       } 
 
       public bool ShouldRetry(int currentRetryCount, int statusCode, Exception lastException, out TimeSpan retryInterval, OperationContext operationContext) 
       { 
           retryInterval = defaultRetryInterval; 
           if (currentRetryCount &gt;= maxRetryAttemps) 
           { 
               return false; 
           } 
           if (statusCode == 409) 
           { 
               return true; 
           } 
           else 
           { 
               return false; 
           } 
       } 
   } 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:26.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt; font-weight:bold"><span style="">How to reduce request sending times?</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
public static async Task&lt;bool&gt; DeleteEntity(DynamicTableEntity entity) 
       { 
           try 
           { 
               var table = client.GetTableReference(tableName); 
 
               TableOperation deleteOperation = TableOperation.Delete(entity); 
               var result = await table.ExecuteAsync(deleteOperation); 
 
               return true; 
           } 
           catch (Exception e) 
           { 
               //In windows store apps, StorageException is an internal class. 
               //You can't convert Exception to StorageException, so you should use  
               //RequestResult.TranslateFromExceptionMessage(e.Message) to get the HttpStatusCode. 
               var result = RequestResult.TranslateFromExceptionMessage(e.Message); 
 
               //We treat 404 as it has already been deleted. 
               if (result.HttpStatusCode == 404) 
               { 
                   return true; 
               } 
               else 
               { 
                   return false; 
                   //throw new WebException(result.HttpStatusMessage); 
               } 
           } 
 
       } 
</pre>
<pre class="hidden">
Public Shared Async Function DeleteEntity(entity As DynamicTableEntity) As Task(Of Boolean)
     Try
         Dim table = client.GetTableReference(tableName)
         Dim deleteOperation As TableOperation = TableOperation.Delete(entity)
         Dim result = Await table.ExecuteAsync(deleteOperation)
         Return True
     Catch e As Exception
         ' In windows store app, StorageException is an internal class.
         ' You can't convert Exception to StorageException, so you should use 
         ' RequestResult.TranslateFromExceptionMessage(e.Message) get the HttpStatusCode.
         Dim result = RequestResult.TranslateFromExceptionMessage(e.Message)
         ' We treat 404 as it has already been deleted.
         If result.HttpStatusCode = 404 Then
             Return True
         Else
             ' Throw new WebException(result.HttpStatusMessage);
             Return False
         End If
     End Try
 End Function
</pre>
<pre id="codePreview" class="csharp">
public static async Task&lt;bool&gt; DeleteEntity(DynamicTableEntity entity) 
       { 
           try 
           { 
               var table = client.GetTableReference(tableName); 
 
               TableOperation deleteOperation = TableOperation.Delete(entity); 
               var result = await table.ExecuteAsync(deleteOperation); 
 
               return true; 
           } 
           catch (Exception e) 
           { 
               //In windows store apps, StorageException is an internal class. 
               //You can't convert Exception to StorageException, so you should use  
               //RequestResult.TranslateFromExceptionMessage(e.Message) to get the HttpStatusCode. 
               var result = RequestResult.TranslateFromExceptionMessage(e.Message); 
 
               //We treat 404 as it has already been deleted. 
               if (result.HttpStatusCode == 404) 
               { 
                   return true; 
               } 
               else 
               { 
                   return false; 
                   //throw new WebException(result.HttpStatusMessage); 
               } 
           } 
 
       } 
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://www.windowsazure.com/en-us/documentation/articles/storage-dotnet-how-to-use-table-storage-20/" style="text-decoration:none"><span style="color:#0563C1; color:#0563C1; text-decoration:underline">Azure table storage
 feature guide</span></a><span style=""> shows that it is not necessary to retrieve an entity before deletion if you have already retrieved it before. So we can delete that retrieve operation in code.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">If you send the same entity delete operation twice, you should catch the 404 error and ignore it as the code above does.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://www.windowsazure.com/en-us/documentation/articles/storage-dotnet-how-to-use-table-storage-20/#delete-entity" style="text-decoration:none"><span style="color:#0563C1; color:#0563C1; text-decoration:underline">http://www.windowsazure.com/en-us/documentation/articles/storage-dotnet-how-to-use-table-storage-20/#delete-entity</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
