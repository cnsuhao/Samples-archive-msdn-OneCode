# How to achieve breakpoint resume when upload big file to blob (VS2013)
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2015-01-19 09:50:37
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to achieve breakpoint resume when upload big file to blob</h1>
<h2>Introduction</h2>
<p>Sometimes we need to upload big file to blob storage. Usually when we use (UploadFromStream), if the network interrupt, the transport will restart.&nbsp; If we want to achieve breakpoint resume we need to use PutBlock method.</p>
<p><strong>Put Block</strong>&nbsp;uploads a block for future inclusion in a block blob. A block may be up to 4 MB in size.</p>
<p>After you have uploaded a set of blocks, you can create or update the blob on the server from this set by calling the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/azure/dd179467.aspx">Put Block List</a>&nbsp;operation. Each block in the set is identified
 by a block ID that is unique within that blob. Block IDs are scoped to a particular blob, so different blobs can have blocks with same IDs.</p>
<p>If you call&nbsp;<strong>Put Block</strong>&nbsp;on a blob that does not yet exist, a new block blob is created with a content length of 0. This blob is enumerated by the&nbsp;<strong>List Blobs</strong>&nbsp;operation if the&nbsp;<em>include=uncommittedblobs</em>&nbsp;option
 is specified. The block or blocks that you uploaded are not committed until you call&nbsp;<strong>Put Block List</strong>&nbsp;on the new blob. A blob created this way is maintained on the server for a week; if you have not added more blocks or committed blocks
 to the blob within that time period, then the blob is garbage collected.</p>
<p>The maximum blob size currently supported by the&nbsp;<strong>Put Block List</strong>&nbsp;operation is 200 GB, and up to 50,000 blocks. A blob can have a maximum of 100,000 uncommitted blocks at any given time, and the set of uncommitted blocks cannot exceed
 400 GB in total size. If these maximums are exceeded, the service returns status code 413 (RequestEntityTooLarge).</p>
<p>A block that has been successfully uploaded with the&nbsp;<strong>Put Block</strong>&nbsp;operation does not become part of a blob until it is committed with&nbsp;<strong>Put Block List</strong>. Before&nbsp;<strong>Put Block List</strong>&nbsp;is called
 to commit the new or updated blob, any calls to&nbsp;<a href="http://msdn.microsoft.com/en-us/library/azure/dd179440.aspx">Get Blob</a>&nbsp;return the blob contents without the inclusion of the uncommitted block.</p>
<p>If you upload a block that has the same block ID as another block that has not yet been committed, the last uploaded block with that ID will be committed on the next successful&nbsp;<strong>Put Block List</strong>&nbsp;operation.</p>
<p>After&nbsp;<strong>Put Block List</strong>&nbsp;is called, all uncommitted blocks specified in the block list are committed as part of the new blob. Any uncommitted blocks that were not specified in the block list for the blob will be garbage collected and
 removed from the Blob service. Any uncommitted blocks will also be garbage collected if there are no successful calls to&nbsp;<strong>Put Block</strong>&nbsp;or&nbsp;<strong>Put Block List</strong>&nbsp;on the same blob within a week following the last successful&nbsp;<strong>Put
 Block</strong>&nbsp;operation. If&nbsp;<a href="http://msdn.microsoft.com/en-us/library/azure/dd179451.aspx">Put Blob</a>&nbsp;is called on the blob, any uncommitted blocks will be garbage collected.</p>
<p>If the blob has an active lease, the client must specify a valid lease ID on the request in order to write a block to the blob. If the client does not specify a lease ID, or specifies an invalid lease ID, the Blob service returns status code 412 (Precondition
 Failed). If the client specifies a lease ID but the blob does not have an active lease, the Blob service also returns status code 412 (Precondition Failed).</p>
<p>For a given blob, all block IDs must be the same length. If a block is uploaded with a block ID of a different length than the block IDs for any existing uncommitted blocks, the service returns error response code 400 (Bad Request).</p>
<p>If you attempt to upload a block that is larger than 4 MB, the service returns status code 413 (Request Entity Too Large). The service also returns additional information about the error in the response, including the maximum block size permitted in bytes.</p>
<p>&nbsp;</p>
<h2>Building the Sample</h2>
<p>First change the account name and key to yours.</p>
<p>Then you can run the sample directly.</p>
<h2>Using the Code</h2>
<p>The code below shows how to upload big files.</p>
<p>&nbsp; </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void UploadBigFile(BackgroundWorker worker, DoWorkEventArgs e)

       {

           //bufferSize 40KB

           byte[] bufferBytes = new byte[bufferSize];

           string fileName = Path.GetFileName(filePath);

           CloudBlockBlob blob = GetBlobkBlob(fileName);

           using (FileStream fileStream = File.OpenRead(filePath))

           {

               //Get the total count of block

               blockCount = (int)(fileStream.Length / bufferSize) &#43; 1;

               Int64 currentBlockSize = 0;

               int currentCount = blockIds.Count();

               fileStream.Seek(bufferSize * currentCount, SeekOrigin.Begin);

               for (int i = blockIds.Count; i &lt; blockCount; i&#43;&#43;)

               {

                   if (worker.WorkerSupportsCancellation &amp;&amp; worker.CancellationPending)

                   {

                       return;

                   }

                   currentBlockSize = bufferSize;

                   if (i == blockCount - 1)

                   {

                       currentBlockSize = fileStream.Length - bufferSize * i;

                       bufferBytes = new byte[currentBlockSize];

                   }

                   if (currentBlockSize == 0) break;

                   //Get the block data

                   fileStream.Read(bufferBytes, 0, Convert.ToInt32(currentBlockSize));

                   using (MemoryStream memoryStream = new MemoryStream(bufferBytes))

                   {

                       try

                       {

                           //Get Base64-encoded block Id

                           string blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));

                           //Upload the block

                           blob.PutBlock(blockId, memoryStream, null);

                           //Cache the block Id

                           blockIds.Add(blockId);

                           worker.ReportProgress(i &#43; 1);

                       }

                       catch (Exception)

                       {

                       }

                   }

               }

           }

           //Commit all the blocks

           blob.PutBlockList(blockIds);

           isCanceled = false;

       }</pre>
<pre class="hidden">Private Sub UploadBigFile(worker As BackgroundWorker, e As DoWorkEventArgs)

        'bufferSize 40KB

        Dim bufferBytes As Byte() = New Byte(bufferSize - 1) {}

        Dim fileName As String = Path.GetFileName(filePath)

        Dim blob As CloudBlockBlob = GetBlobkBlob(fileName)

        Using fileStream As FileStream = File.OpenRead(filePath)

            'Get the total count of block

            blockCount = CInt(fileStream.Length / bufferSize) &#43; 1

            Dim currentBlockSize As Int64 = 0

            Dim currentCount As Integer = blockIds.Count()

            fileStream.Seek(bufferSize * currentCount, SeekOrigin.Begin)

            For i As Integer = blockIds.Count To blockCount - 1

                If worker.WorkerSupportsCancellation AndAlso worker.CancellationPending Then

                    Return

                End If

                currentBlockSize = bufferSize

                If i = blockCount - 1 Then

                    currentBlockSize = fileStream.Length - bufferSize * i

                    bufferBytes = New Byte(currentBlockSize - 1) {}

                End If

                If currentBlockSize = 0 Then

                    Exit For

                End If

                'Get the block data

                fileStream.Read(bufferBytes, 0, Convert.ToInt32(currentBlockSize))

                Using memoryStream As New MemoryStream(bufferBytes)

                    Try

                        'Get Base64-encoded block Id

                        Dim blockId As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))

                        'Upload the block

                        blob.PutBlock(blockId, memoryStream, Nothing)

                        'Cache the block Id

                        blockIds.Add(blockId)

                        worker.ReportProgress(i &#43; 1)

                    Catch generatedExceptionName As Exception

                    End Try

                End Using

            Next

        End Using

        'Commit all the blocks

        blob.PutBlockList(blockIds)

        isCanceled = False

    End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UploadBigFile(BackgroundWorker&nbsp;worker,&nbsp;DoWorkEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//bufferSize&nbsp;40KB</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;bufferBytes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[bufferSize];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;fileName&nbsp;=&nbsp;Path.GetFileName(filePath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlockBlob&nbsp;blob&nbsp;=&nbsp;GetBlobkBlob(fileName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(FileStream&nbsp;fileStream&nbsp;=&nbsp;File.OpenRead(filePath))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;total&nbsp;count&nbsp;of&nbsp;block</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blockCount&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(fileStream.Length&nbsp;/&nbsp;bufferSize)&nbsp;&#43;&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Int64&nbsp;currentBlockSize&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;currentCount&nbsp;=&nbsp;blockIds.Count();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileStream.Seek(bufferSize&nbsp;*&nbsp;currentCount,&nbsp;SeekOrigin.Begin);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;blockIds.Count;&nbsp;i&nbsp;&lt;&nbsp;blockCount;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(worker.WorkerSupportsCancellation&nbsp;&amp;&amp;&nbsp;worker.CancellationPending)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentBlockSize&nbsp;=&nbsp;bufferSize;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;==&nbsp;blockCount&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentBlockSize&nbsp;=&nbsp;fileStream.Length&nbsp;-&nbsp;bufferSize&nbsp;*&nbsp;i;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bufferBytes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[currentBlockSize];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(currentBlockSize&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;block&nbsp;data</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileStream.Read(bufferBytes,&nbsp;<span class="cs__number">0</span>,&nbsp;Convert.ToInt32(currentBlockSize));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MemoryStream&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(bufferBytes))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;Base64-encoded&nbsp;block&nbsp;Id</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;blockId&nbsp;=&nbsp;Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Upload&nbsp;the&nbsp;block</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.PutBlock(blockId,&nbsp;memoryStream,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cache&nbsp;the&nbsp;block&nbsp;Id</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blockIds.Add(blockId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worker.ReportProgress(i&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Commit&nbsp;all&nbsp;the&nbsp;blocks</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.PutBlockList(blockIds);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isCanceled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:10px">&nbsp;</span></div>
<p></p>
<p>&nbsp;</p>
<h2>More Information</h2>
<p><a href="http://msdn.microsoft.com/en-us/library/azure/dd135726.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/azure/dd135726.aspx</a></p>
