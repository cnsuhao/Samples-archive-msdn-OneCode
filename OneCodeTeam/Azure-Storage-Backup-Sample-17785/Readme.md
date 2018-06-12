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
* 2013-04-16 10:36:11
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<p class="MsoNormal">This sample should be <span>run with Windows Azure SDK 1.6 and Sql Server.
</span></p>
<p class="MsoNormal">1. <span>Open the </span><span>CSAzureBackup</span><span>.sln file with Visual Studio, then you need set
<span>CSAzureBackup</span> Azure application as the startup application.</span><em><span>
</span></em></p>
<p class="MsoNormal">2.<span> Try to input your storage account user and key is Azure Settings &quot;StorageConnections&quot; connection string, if you only need test this sample, you can use local development storage.<span>
</span></span></p>
<p class="MsoNormal">3. <span>Press F5 to debug the Default.aspx page, you will find an &quot;Upload Resources to Storage&quot; button at the top of the page, please click it to upload the image files under the &quot;Files&quot; folder, &quot;MSDN.jpg&quot; and &quot;Microsoft.jpg&quot;.
</span></p>
<p class="MsoNormal"><span><span>&nbsp;</span><span> <img src="/site/view/file/73988/1/image.png" alt="" width="578" height="529" align="middle">
</span></span></p>
<p class="MsoNormal">4. <span>The next step, input the source container blob name in the &quot;Source Container name&quot; TextBox (Here we can input &quot;blob&quot;). To the &quot;Backup Container Name&quot;, please refer the Name rule upon the TextBoxes, and think out a proper name,
 for example, &quot;blob-copy2&quot;. Click the &quot;Back up your Blob&quot; button. <span>&nbsp;</span>
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73989/1/image.png" alt="" width="578" height="529" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>5. Use Server Explorer or Azure Storage Explorer to check blobs, refer to the following screenshot:
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73990/1/image.png" alt="" width="609" height="457" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>6. The last step, input source table name in &quot;Source Table Name&quot; TextBox (Here we can input &quot;files&quot;), please also check the Table name rules and come up with a new Table name, such as &quot;filesCopy&quot; (Here we cannot add dash (-) character
 in table name, table name rules is different). Click &quot;Back up your Table&quot; button.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73991/1/image.png" alt="" width="578" height="529" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>7. Use Server Explorer or Azure Storage Explorer to check blobs, refer to the following screenshot:
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/73992/1/image.png" alt="" width="604" height="454" align="middle">
</span></p>
<p class="MsoNormal">8. <span>Validation finished </span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span>1</span>. <span>Create a Windows Azure Project in Visual Studio 2010, name it as &quot;</span><span>CSAzureBackup</span><span>&quot;. Then please choose a WebRole as your role, name it as &quot;</span><span>AzureBackup_WebRole</span><span>&quot;.
</span></p>
<p class="MsoNormal"><span>2. Add a class library project named &quot;TableStorageManager&quot;, this class library is used to create Table storage service and make it easy to WebRole, you can create different table datasrouce and common operations to Table (Such as
 add entities). </span></p>
<p class="MsoNormal"><span>3. Then you can add a Default.aspx in WebRole, add upload module and backup module to the application. We need upload some sample data in the Storage first, then use Backup module to create copies of them.
</span></p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows
</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">how to upload Blob and Table data to the Storage.
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Upload resources to Storage.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
protected void btnUpload_Click(object sender, EventArgs e)
{
    try
    {
        FileDataSource source = new FileDataSource(&quot;files&quot;);
        CloudBlobClient client = account.CreateCloudBlobClient();
        CloudBlobContainer container = client.GetContainerReference(&quot;blob&quot;);
        container.CreateIfNotExist();
        var permission = container.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        container.SetPermissions(permission);
        bool flag = false;


        foreach (string name in nameList)
        {
            if (!source.FileExists(name, &quot;image&quot;))
            {
                flag = true;
                CloudBlob blob = container.GetBlobReference(name);
                string path = string.Format(&quot;{0}/{1}&quot;, &quot;Files&quot;, name);
                blob.UploadFile(Server.MapPath(path));


                FileEntity entity = new FileEntity(&quot;image&quot;);
                entity.FileName = name;
                entity.FileUrl = blob.Uri.ToString();
                source.AddFile(entity);
                lbContent.Text &#43;= String.Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name);
            }
        }
        if (!flag)
            lbContent.Text = &quot;You had uploaded these resources. The blob container name is 'blob', table name is 'files'&quot;;
        else
            lbContent.Text &#43;= &quot;The blob container name is 'blob', The table name is 'files'&quot;;
    }
    catch (Exception ex)
    {
        lbContent.Text = ex.Message;
    }
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Upload resources to Storage.
/// &lt;/summary&gt;
/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
protected void btnUpload_Click(object sender, EventArgs e)
{
    try
    {
        FileDataSource source = new FileDataSource(&quot;files&quot;);
        CloudBlobClient client = account.CreateCloudBlobClient();
        CloudBlobContainer container = client.GetContainerReference(&quot;blob&quot;);
        container.CreateIfNotExist();
        var permission = container.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        container.SetPermissions(permission);
        bool flag = false;


        foreach (string name in nameList)
        {
            if (!source.FileExists(name, &quot;image&quot;))
            {
                flag = true;
                CloudBlob blob = container.GetBlobReference(name);
                string path = string.Format(&quot;{0}/{1}&quot;, &quot;Files&quot;, name);
                blob.UploadFile(Server.MapPath(path));


                FileEntity entity = new FileEntity(&quot;image&quot;);
                entity.FileName = name;
                entity.FileUrl = blob.Uri.ToString();
                source.AddFile(entity);
                lbContent.Text &#43;= String.Format(&quot;The image file {0} is uploaded successes. <br>&quot;, name);
            }
        }
        if (!flag)
            lbContent.Text = &quot;You had uploaded these resources. The blob container name is 'blob', table name is 'files'&quot;;
        else
            lbContent.Text &#43;= &quot;The blob container name is 'blob', The table name is 'files'&quot;;
    }
    catch (Exception ex)
    {
        lbContent.Text = ex.Message;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong>&nbsp;</strong></p>
<p class="MsoNormal"><span>4. The next step, add TextBox control on the page that allow user input their source storage name and copies storage name, and these names must following related rules from MSDN article, in this sample, we'll create backup data
 in the Cloud. </span></p>
<p class="MsoNormal"><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">The following code shows</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"> how to create backup
 data of Blob and Table storage data.</span></strong><strong><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected void btnBackup_Click(object sender, EventArgs e)
{
    try
    {
        if (tbSource.Text.Trim().Equals(string.Empty) &amp;&amp; tbCopies.Text.Trim().Equals(string.Empty))
        {
            lbBackup.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;;
            return;
        }


        string sourceContainerName = tbSource.Text.Trim();
        string copiesContainerName = tbCopies.Text.Trim();
        CloudBlobClient client = account.CreateCloudBlobClient();


        CloudBlobContainer sourceContainer = client.GetContainerReference(sourceContainerName);
        if (!StorageManager.CheckIfExists(sourceContainer))
        {
            lbBackup.Text = &quot;The source blob container is not exists&quot;;
            return;
        }
        CloudBlobContainer copiesContainer = client.GetContainerReference(copiesContainerName);
        copiesContainer.CreateIfNotExist();
        var permission = copiesContainer.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        copiesContainer.SetPermissions(permission);




        foreach (var blob in sourceContainer.ListBlobs())
        {
            string uri = blob.Uri.AbsolutePath;
            string[] matches = new string[] { &quot;blob/&quot; };
            string FileName = uri.Split(matches, StringSplitOptions.None)[1].Substring(0);
            CloudBlob sourceBlob = sourceContainer.GetBlobReference(FileName);
            CloudBlob copiesBlob = copiesContainer.GetBlobReference(FileName);
            copiesBlob.CopyFromBlob(sourceBlob);
            lbBackup.Text &#43;= String.Format(&quot;The image file {0} is backup successes. Copies container name is {1} <br>&quot;, FileName, copiesContainerName);
        }
    }
    catch (StorageClientException ex)
    {
        if (ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;))
            lbBackup.Text = &quot;Please check your blob container name.&quot;;
        else
            lbBackup.Text = ex.Message;
    }
    catch (Exception all)
    {
        lbBackup.Text = all.Message;
    }
}






protected void btnBackupTable_Click(object sender, EventArgs e)
{
    try
    {
        if (tbTabelSource.Text.Trim().Equals(string.Empty) &amp;&amp; tbTableCopies.Text.Trim().Equals(string.Empty))
        {
            lbBackupTable.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;;
            return;
        }


        string sourceTableName = tbTabelSource.Text.Trim();
        string copiesTableName = tbTableCopies.Text.Trim();
        CloudTableClient client = account.CreateCloudTableClient();




        if (!client.DoesTableExist(sourceTableName))
        {
            lbBackupTable.Text = &quot;The source table is not exists&quot;;
            return;
        }


        FileDataSource tableDataSource = new FileDataSource(sourceTableName);
        List&lt;FileEntity&gt; sourceList = tableDataSource.GetAllEntities().ToList&lt;FileEntity&gt;();
        client.DeleteTableIfExist(copiesTableName);
        FileDataSource tableDataCopies = new FileDataSource(copiesTableName);
        tableDataCopies.AddNumbersOfFiles(sourceList);
        lbBackupTable.Text = String.Format(&quot;The source table {0} is backup successes. Copies table name is {1}&quot;, sourceTableName, copiesTableName);
    }
    catch (StorageClientException ex)
    {
        if (ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;))
            lbBackupTable.Text = &quot;Please check your blob container name.&quot;;
        else
            lbBackupTable.Text = ex.Message;
    }
    catch (Exception all)
    {
        lbBackupTable.Text = all.Message;
    }
}

</pre>
<pre id="codePreview" class="csharp">protected void btnBackup_Click(object sender, EventArgs e)
{
    try
    {
        if (tbSource.Text.Trim().Equals(string.Empty) &amp;&amp; tbCopies.Text.Trim().Equals(string.Empty))
        {
            lbBackup.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;;
            return;
        }


        string sourceContainerName = tbSource.Text.Trim();
        string copiesContainerName = tbCopies.Text.Trim();
        CloudBlobClient client = account.CreateCloudBlobClient();


        CloudBlobContainer sourceContainer = client.GetContainerReference(sourceContainerName);
        if (!StorageManager.CheckIfExists(sourceContainer))
        {
            lbBackup.Text = &quot;The source blob container is not exists&quot;;
            return;
        }
        CloudBlobContainer copiesContainer = client.GetContainerReference(copiesContainerName);
        copiesContainer.CreateIfNotExist();
        var permission = copiesContainer.GetPermissions();
        permission.PublicAccess = BlobContainerPublicAccessType.Container;
        copiesContainer.SetPermissions(permission);




        foreach (var blob in sourceContainer.ListBlobs())
        {
            string uri = blob.Uri.AbsolutePath;
            string[] matches = new string[] { &quot;blob/&quot; };
            string FileName = uri.Split(matches, StringSplitOptions.None)[1].Substring(0);
            CloudBlob sourceBlob = sourceContainer.GetBlobReference(FileName);
            CloudBlob copiesBlob = copiesContainer.GetBlobReference(FileName);
            copiesBlob.CopyFromBlob(sourceBlob);
            lbBackup.Text &#43;= String.Format(&quot;The image file {0} is backup successes. Copies container name is {1} <br>&quot;, FileName, copiesContainerName);
        }
    }
    catch (StorageClientException ex)
    {
        if (ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;))
            lbBackup.Text = &quot;Please check your blob container name.&quot;;
        else
            lbBackup.Text = ex.Message;
    }
    catch (Exception all)
    {
        lbBackup.Text = all.Message;
    }
}






protected void btnBackupTable_Click(object sender, EventArgs e)
{
    try
    {
        if (tbTabelSource.Text.Trim().Equals(string.Empty) &amp;&amp; tbTableCopies.Text.Trim().Equals(string.Empty))
        {
            lbBackupTable.Text = &quot;Source TextBox and Copies TextBox can not be empty&quot;;
            return;
        }


        string sourceTableName = tbTabelSource.Text.Trim();
        string copiesTableName = tbTableCopies.Text.Trim();
        CloudTableClient client = account.CreateCloudTableClient();




        if (!client.DoesTableExist(sourceTableName))
        {
            lbBackupTable.Text = &quot;The source table is not exists&quot;;
            return;
        }


        FileDataSource tableDataSource = new FileDataSource(sourceTableName);
        List&lt;FileEntity&gt; sourceList = tableDataSource.GetAllEntities().ToList&lt;FileEntity&gt;();
        client.DeleteTableIfExist(copiesTableName);
        FileDataSource tableDataCopies = new FileDataSource(copiesTableName);
        tableDataCopies.AddNumbersOfFiles(sourceList);
        lbBackupTable.Text = String.Format(&quot;The source table {0} is backup successes. Copies table name is {1}&quot;, sourceTableName, copiesTableName);
    }
    catch (StorageClientException ex)
    {
        if (ex.ExtendedErrorInformation.ErrorCode.Equals(&quot;OutOfRangeInput&quot;))
            lbBackupTable.Text = &quot;Please check your blob container name.&quot;;
        else
            lbBackupTable.Text = ex.Message;
    }
    catch (Exception all)
    {
        lbBackupTable.Text = all.Message;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Build the application and you can debug it now.</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.tableserviceentity.aspx"><span class="SpellE">TableServiceEntity</span> Class</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/microsoft.windowsazure.storageclient.cloudblobcontainer.aspx"><span class="SpellE">CloudBlobContainer</span> Class</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><a href="http://msdn.microsoft.com/en-us/library/windowsazure/ee772794.aspx"><span class="SpellE">CloudPageBlob.CopyFromBlob</span> Method</a>
</span></p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
