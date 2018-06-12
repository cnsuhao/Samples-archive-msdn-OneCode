# Azure Storage Backup Sample
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* backup
* Storage
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:34:20
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Windows Azure Storage Backup Sample (VBAzureBackup)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span>The sample code demonstrates how to backup Azure Storage in Cloud. Though Windows Azure Platform have 3 copies for our data, but this is only physical backup, if a logical errors occurred that all copies of storage would been modified,
 so this sample shows how to protect our important data with code. </span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">This sample should be <span>run with Windows Azure SDK 1.6, SQL Server.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">1. Open the <span>VBAzureBackup</span>.sln file with Visual Studio, then you need set
<span>VBAzureBackup</span> Azure application as the startup application.<em> </em>
</p>
<p class="MsoNormal">2. Try to input your storage account user and key is Azure Settings &quot;StorageConnections&quot; connection string, if you only need test this sample, you can use local development storage.<span>
</span></p>
<p class="MsoNormal">3. Press F5 to debug the Default.aspx page, you will find an &quot;Upload Resources to Storage&quot; button at the top of the page, please click it to upload the image files under the &quot;Files&quot; folder, &quot;MSDN.jpg&quot; and &quot;Microsoft.jpg&quot;.</p>
<p class="MsoNormal">4. <span>The next step, input the source container blob name in the &quot;Source Container name&quot; TextBox (Here we can input &quot;blob&quot;). To the &quot;Backup Container Name&quot;, please refer the Name rule upon the TextBoxes, and think out a proper name,
 for example, &quot;blob-copy2&quot;. Click the &quot;Back up your Blob&quot; button.<span>&nbsp; </span>
</span></p>
<p class="MsoNormal">5. Use Server Explorer or Azure Storage Explorer to check blobs, refer to the following screenshot:</p>
<p class="MsoNormal">6. The last step, input source table name in &quot;Source Table Name&quot; TextBox (Here we can input &quot;files&quot;), please also check the Table name rules and come up with a new Table name, such as &quot;filesCopy&quot; (Here we cannot add dash (-) character
 in table name, table name rules is different). Click &quot;Back up your Table&quot; button.</p>
<p class="MsoNormal">7. Use Server Explorer or Azure Storage Explorer to check blobs, refer to the following screenshot:</p>
<p class="MsoNormal">8. <span>Validation finished </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span>&nbsp;</span><span>1. Create a Windows Azure Project in Visual Studio 2010, name it as &quot;<span>VBAzureBackup</span>&quot;. Then please choose a WebRole as your role, name it as &quot;<span>AzureBackup_WebRole</span>&quot;.
</span></p>
<p class="MsoNormal"><span>2. Add a class library project named &quot;TableStorageManager&quot;, this class library is used to create Table storage service and make it easy to WebRole, you can create different table datasrouce and common operations to Table (Such as
 add entities). </span></p>
<p class="MsoNormal"><span>3. Then you can add a Default.aspx in WebRole, add upload module and backup module to the application. We need upload some sample data in the Storage first, then use Backup module to create copies of them.
</span></p>
<h3><span class="Heading3Char">The following code shows how to upload Blob and Table data to the Storage</span>:</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Upload resources to Storage.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
    Try
        Dim source As New FileDataSource(&quot;files&quot;)
        Dim client As CloudBlobClient = account.CreateCloudBlobClient()
        Dim container As CloudBlobContainer = client.GetContainerReference(&quot;blob&quot;)
        container.CreateIfNotExist()
        Dim permission = container.GetPermissions()
        permission.PublicAccess = BlobContainerPublicAccessType.Container
        container.SetPermissions(permission)
        Dim flag As Boolean = False


        For Each name As String In nameList
            If Not source.FileExists(name, &quot;image&quot;) Then
                flag = True
                Dim blob As CloudBlob = container.GetBlobReference(name)
                Dim path As String = String.Format(&quot;{0}/{1}&quot;, &quot;Files&quot;, name)
                blob.UploadFile(Server.MapPath(path))


                Dim entity As New FileEntity(&quot;image&quot;)
                entity.FileName = name
                entity.FileUrl = blob.Uri.ToString()
                source.AddFile(entity)
                lbContent.Text &#43;= [String].Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name)
            End If
        Next
        If Not flag Then
            lbContent.Text = &quot;You had uploaded these resources. The blob container name is 'blob', table name is 'files'&quot;
        Else
            lbContent.Text &#43;= &quot;The blob container name is 'blob', The table name is 'files'&quot;
        End If
    Catch ex As Exception
        lbContent.Text = ex.Message
    End Try
End Sub

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Upload resources to Storage.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
    Try
        Dim source As New FileDataSource(&quot;files&quot;)
        Dim client As CloudBlobClient = account.CreateCloudBlobClient()
        Dim container As CloudBlobContainer = client.GetContainerReference(&quot;blob&quot;)
        container.CreateIfNotExist()
        Dim permission = container.GetPermissions()
        permission.PublicAccess = BlobContainerPublicAccessType.Container
        container.SetPermissions(permission)
        Dim flag As Boolean = False


        For Each name As String In nameList
            If Not source.FileExists(name, &quot;image&quot;) Then
                flag = True
                Dim blob As CloudBlob = container.GetBlobReference(name)
                Dim path As String = String.Format(&quot;{0}/{1}&quot;, &quot;Files&quot;, name)
                blob.UploadFile(Server.MapPath(path))


                Dim entity As New FileEntity(&quot;image&quot;)
                entity.FileName = name
                entity.FileUrl = blob.Uri.ToString()
                source.AddFile(entity)
                lbContent.Text &#43;= [String].Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name)
            End If
        Next
        If Not flag Then
            lbContent.Text = &quot;You had uploaded these resources. The blob container name is 'blob', table name is 'files'&quot;
        Else
            lbContent.Text &#43;= &quot;The blob container name is 'blob', The table name is 'files'&quot;
        End If
    Catch ex As Exception
        lbContent.Text = ex.Message
    End Try
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal"><span>&nbsp;</span><span>4. The next step, add TextBox control on the page that allow user input their source storage name and copies storage name, and these names must following related rules from MSDN article, in this sample, we'll
 create backup data in the Cloud.</span></p>
<h3>The following code shows<span> how to create backup data of Blob and Table storage data.
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Sub btnBackup_Click(sender As Object, e As EventArgs)
    Try
        If tbSource.Text.Trim().Equals(String.Empty) AndAlso tbCopies.Text.Trim().Equals(String.Empty) Then
            lbBackup.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;
            Return
        End If


        Dim sourceContainerName As String = tbSource.Text.Trim()
        Dim copiesContainerName As String = tbCopies.Text.Trim()
        Dim client As CloudBlobClient = account.CreateCloudBlobClient()


        Dim sourceContainer As CloudBlobContainer = client.GetContainerReference(sourceContainerName)
        If Not StorageManager.CheckIfExists(sourceContainer) Then
            lbBackup.Text = &quot;The source blob container is not exists&quot;
            Return
        End If
        Dim copiesContainer As CloudBlobContainer = client.GetContainerReference(copiesContainerName)
        copiesContainer.CreateIfNotExist()
        Dim permission = copiesContainer.GetPermissions()
        permission.PublicAccess = BlobContainerPublicAccessType.Container
        copiesContainer.SetPermissions(permission)




        For Each blob In sourceContainer.ListBlobs()
            Dim uri As String = blob.Uri.AbsolutePath
            Dim matches As String() = New String() {&quot;blob/&quot;}
            Dim FileName As String = uri.Split(matches, StringSplitOptions.None)(1).Substring(0)
            Dim sourceBlob As CloudBlob = sourceContainer.GetBlobReference(FileName)
            Dim copiesBlob As CloudBlob = copiesContainer.GetBlobReference(FileName)
            copiesBlob.CopyFromBlob(sourceBlob)
            lbBackup.Text &#43;= [String].Format(&quot;The image file {0} is backup successes. Copies container name is {1} <br>&quot;, FileName, copiesContainerName)
        Next
    Catch ex As StorageClientException
        If ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;) Then
            lbBackup.Text = &quot;Please check your blob container name.&quot;
        Else
            lbBackup.Text = ex.Message
        End If
    Catch all As Exception
        lbBackup.Text = all.Message
    End Try
End Sub






Protected Sub btnBackupTable_Click(sender As Object, e As EventArgs)
    Try
        If tbTabelSource.Text.Trim().Equals(String.Empty) AndAlso tbTableCopies.Text.Trim().Equals(String.Empty) Then
            lbBackupTable.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;
            Return
        End If


        Dim sourceTableName As String = tbTabelSource.Text.Trim()
        Dim copiesTableName As String = tbTableCopies.Text.Trim()
        Dim client As CloudTableClient = account.CreateCloudTableClient()




        If Not client.DoesTableExist(sourceTableName) Then
            lbBackupTable.Text = &quot;The source table is not exists&quot;
            Return
        End If


        Dim tableDataSource As New FileDataSource(sourceTableName)
        Dim sourceList As List(Of FileEntity) = tableDataSource.GetAllEntities().ToList()
        client.DeleteTableIfExist(copiesTableName)
        Dim tableDataCopies As New FileDataSource(copiesTableName)
        tableDataCopies.AddNumbersOfFiles(sourceList)
        lbBackupTable.Text = [String].Format(&quot;The source table {0} is backup successes. Copies table name is {1}&quot;, sourceTableName, copiesTableName)
    Catch ex As StorageClientException
        If ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;) Then
            lbBackupTable.Text = &quot;Please check your blob container name.&quot;
        Else
            lbBackupTable.Text = ex.Message
        End If
    Catch all As Exception
        lbBackupTable.Text = all.Message
    End Try
End Sub

</pre>
<pre id="codePreview" class="vb">Protected Sub btnBackup_Click(sender As Object, e As EventArgs)
    Try
        If tbSource.Text.Trim().Equals(String.Empty) AndAlso tbCopies.Text.Trim().Equals(String.Empty) Then
            lbBackup.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;
            Return
        End If


        Dim sourceContainerName As String = tbSource.Text.Trim()
        Dim copiesContainerName As String = tbCopies.Text.Trim()
        Dim client As CloudBlobClient = account.CreateCloudBlobClient()


        Dim sourceContainer As CloudBlobContainer = client.GetContainerReference(sourceContainerName)
        If Not StorageManager.CheckIfExists(sourceContainer) Then
            lbBackup.Text = &quot;The source blob container is not exists&quot;
            Return
        End If
        Dim copiesContainer As CloudBlobContainer = client.GetContainerReference(copiesContainerName)
        copiesContainer.CreateIfNotExist()
        Dim permission = copiesContainer.GetPermissions()
        permission.PublicAccess = BlobContainerPublicAccessType.Container
        copiesContainer.SetPermissions(permission)




        For Each blob In sourceContainer.ListBlobs()
            Dim uri As String = blob.Uri.AbsolutePath
            Dim matches As String() = New String() {&quot;blob/&quot;}
            Dim FileName As String = uri.Split(matches, StringSplitOptions.None)(1).Substring(0)
            Dim sourceBlob As CloudBlob = sourceContainer.GetBlobReference(FileName)
            Dim copiesBlob As CloudBlob = copiesContainer.GetBlobReference(FileName)
            copiesBlob.CopyFromBlob(sourceBlob)
            lbBackup.Text &#43;= [String].Format(&quot;The image file {0} is backup successes. Copies container name is {1} <br>&quot;, FileName, copiesContainerName)
        Next
    Catch ex As StorageClientException
        If ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;) Then
            lbBackup.Text = &quot;Please check your blob container name.&quot;
        Else
            lbBackup.Text = ex.Message
        End If
    Catch all As Exception
        lbBackup.Text = all.Message
    End Try
End Sub






Protected Sub btnBackupTable_Click(sender As Object, e As EventArgs)
    Try
        If tbTabelSource.Text.Trim().Equals(String.Empty) AndAlso tbTableCopies.Text.Trim().Equals(String.Empty) Then
            lbBackupTable.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;
            Return
        End If


        Dim sourceTableName As String = tbTabelSource.Text.Trim()
        Dim copiesTableName As String = tbTableCopies.Text.Trim()
        Dim client As CloudTableClient = account.CreateCloudTableClient()




        If Not client.DoesTableExist(sourceTableName) Then
            lbBackupTable.Text = &quot;The source table is not exists&quot;
            Return
        End If


        Dim tableDataSource As New FileDataSource(sourceTableName)
        Dim sourceList As List(Of FileEntity) = tableDataSource.GetAllEntities().ToList()
        client.DeleteTableIfExist(copiesTableName)
        Dim tableDataCopies As New FileDataSource(copiesTableName)
        tableDataCopies.AddNumbersOfFiles(sourceList)
        lbBackupTable.Text = [String].Format(&quot;The source table {0} is backup successes. Copies table name is {1}&quot;, sourceTableName, copiesTableName)
    Catch ex As StorageClientException
        If ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;) Then
            lbBackupTable.Text = &quot;Please check your blob container name.&quot;
        Else
            lbBackupTable.Text = ex.Message
        End If
    Catch all As Exception
        lbBackupTable.Text = all.Message
    End Try
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">5. Build the application and you can debug it now.</p>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.tableserviceentity.aspx">TableServiceEntity Class</a>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.cloudblobcontainer.aspx">CloudBlobContainer Class</a>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/ee772794.aspx">CloudPageBlob.CopyFromBlob Method</a>
</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
