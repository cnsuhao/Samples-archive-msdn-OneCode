# How to store the images in Microsoft Azure SQL Database
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Microsoft Azure SQL Database
## Topics
* SQL Azure
* Image
* BLOB
## IsPublished
* True
## ModifiedDate
* 2015-03-05 10:24:12
## Description

<h1>Store the images in Microsoft Azure SQL Database (VBSQLAzureStoreImages)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to store images in Microsoft Azure SQL Database.</p>
<p class="MsoNormal">Sometimes the developers need to store the files in the Microsoft Azure. In this sample, we introduce two ways to implement this function:</p>
<p class="MsoNormal">1. Store the image data in SQL Azure. It's easy to search and manage the images.</p>
<p class="MsoNormal">2. Store the image in the Blob and store the Uri of the Blob in SQL Azure. The space of Blob is cheaper. If we can store the image in the Blob and store the information of image in SQL Azure, it's also easy to manage the images.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you deploy the sample to the cloud, you need to finish the following steps:</p>
<p class="MsoNormal">Step1. Modify the connection string in the Web.config file with your server name, user name and password.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;add name=&quot;ImagesContext&quot; connectionString=&quot;Server=tcp:&lt;servername&gt;.database.windows.net,1433;Database=ImagesDb;User ID=&lt;username&gt;@&lt;servername&gt;;Password=&lt;password&gt;;Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=True;&quot; providerName=&quot;System.Data.SqlClient&quot;/&gt;

</pre>
<pre id="codePreview" class="xml">&lt;add name=&quot;ImagesContext&quot; connectionString=&quot;Server=tcp:&lt;servername&gt;.database.windows.net,1433;Database=ImagesDb;User ID=&lt;username&gt;@&lt;servername&gt;;Password=&lt;password&gt;;Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=True;&quot; providerName=&quot;System.Data.SqlClient&quot;/&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step2. Modify the value of StorageConnectionString and Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString with the user account and key of your storage. You can refer
<a href="https://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage/#header-4">
this</a>.</p>
<p class="MsoNormal"><span><img src="/site/view/file/96019/1/image.png" alt="" width="763" height="131" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">After you deploy this sample into the cloud, you can access the web.</p>
<p class="MsoNormal">1.<span>&nbsp; </span>Choose the location to store the images.</p>
<p class="MsoNormal">2. Choose an image to upload.</p>
<p class="MsoNormal">3. You can delete and copy the image.</p>
<p class="MsoNormal"><span><img src="/site/view/file/96020/1/image.png" alt="" width="1111" height="716" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<strong>1. Store the image in Microsoft Azure SQL Database. </strong></p>
<p class="MsoNormal"><span>&nbsp;&nbsp;&nbsp;&nbsp; </span><strong>a. Model Class
</strong></p>
<p class="MsoNormal">We use the following classes to build two tables that store the info of image and the data of image.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class ImageInSQLAzure
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; Public Property FileName() As String
&nbsp;&nbsp;&nbsp; Public Property ImageName() As String
&nbsp;&nbsp;&nbsp; Public Property Description() As String
End Class


Public Class ImagesTable
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property Id() As Int32


&nbsp;&nbsp;&nbsp; &lt;Column(TypeName:=&quot;image&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageData() As Byte()


&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; &lt;ForeignKey(&quot;ImageId&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageInfo() As ImageInSQLAzure
End Class

</pre>
<pre id="codePreview" class="vb">Public Class ImageInSQLAzure
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; Public Property FileName() As String
&nbsp;&nbsp;&nbsp; Public Property ImageName() As String
&nbsp;&nbsp;&nbsp; Public Property Description() As String
End Class


Public Class ImagesTable
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property Id() As Int32


&nbsp;&nbsp;&nbsp; &lt;Column(TypeName:=&quot;image&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageData() As Byte()


&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; &lt;ForeignKey(&quot;ImageId&quot;)&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageInfo() As ImageInSQLAzure
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp;&nbsp; </span>b. Show the Gallery
</strong></p>
<p class="MsoNormal">We bind the info of image to the ListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Me.images.DataSource = imagesDb.SQLAzureImages.ToList()

</pre>
<pre id="codePreview" class="vb">Me.images.DataSource = imagesDb.SQLAzureImages.ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">And then we will set the Uri of image to the GetImage.ashx with the ImageId.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">img.ImageUrl = &quot;GetImage.ashx?ImageId=&quot; &amp; image.ImageId

</pre>
<pre id="codePreview" class="vb">img.ImageUrl = &quot;GetImage.ashx?ImageId=&quot; &amp; image.ImageId

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In GetImage.ashx, we will get the image according to the ImageId from the SQL Azure and return to the client.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">context.Response.ContentType = &quot;image/jpeg&quot;


Dim imageId As Int32 = Int32.Parse(context.Request.QueryString(&quot;ImageId&quot;))
Dim image As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If image IsNot Nothing Then
&nbsp;&nbsp;&nbsp; context.Response.BinaryWrite(image.ImageData)
Else
&nbsp;&nbsp;&nbsp; context.Response.Write(&quot;No this Image&quot;)
End If

</pre>
<pre id="codePreview" class="vb">context.Response.ContentType = &quot;image/jpeg&quot;


Dim imageId As Int32 = Int32.Parse(context.Request.QueryString(&quot;ImageId&quot;))
Dim image As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If image IsNot Nothing Then
&nbsp;&nbsp;&nbsp; context.Response.BinaryWrite(image.ImageData)
Else
&nbsp;&nbsp;&nbsp; context.Response.Write(&quot;No this Image&quot;)
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Now, we can see the image gallery in the browser.</p>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp;&nbsp; </span>c. Upload the Image
</strong></p>
<p class="MsoNormal">You can also upload the image to the SQL Azure. We just need to store the info and data of the image to the classes, and save the changes. Now the image is in the database of SQL Azure.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim newImageInfo As New ImageInSQLAzure()
Dim newImage As New ImagesTable()


newImageInfo.FileName = fileName
newImageInfo.ImageName = If(String.IsNullOrEmpty(name), &quot;unknown&quot;, name)
newImageInfo.Description = If(String.IsNullOrEmpty(description), &quot;unknown&quot;, description)


newImage.ImageInfo = newImageInfo
newImage.ImageData = data


imagesDb.SQLAzureImages.Add(newImageInfo)
imagesDb.ImagesTable.Add(newImage)
imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">Dim newImageInfo As New ImageInSQLAzure()
Dim newImage As New ImagesTable()


newImageInfo.FileName = fileName
newImageInfo.ImageName = If(String.IsNullOrEmpty(name), &quot;unknown&quot;, name)
newImageInfo.Description = If(String.IsNullOrEmpty(description), &quot;unknown&quot;, description)


newImage.ImageInfo = newImageInfo
newImage.ImageData = data


imagesDb.SQLAzureImages.Add(newImageInfo)
imagesDb.ImagesTable.Add(newImage)
imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>d. Delete the Image
</strong></p>
<p class="MsoNormal">We first get the image according to the ImageId, and then remove it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim deletedImage As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()


If deletedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim deletedImageInfo As ImageInSQLAzure = deletedImage.ImageInfo


&nbsp;&nbsp;&nbsp; imagesDb.SQLAzureImages.Remove(deletedImageInfo)
&nbsp;&nbsp;&nbsp; imagesDb.ImagesTable.Remove(deletedImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">Dim deletedImage As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()


If deletedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim deletedImageInfo As ImageInSQLAzure = deletedImage.ImageInfo


&nbsp;&nbsp;&nbsp; imagesDb.SQLAzureImages.Remove(deletedImageInfo)
&nbsp;&nbsp;&nbsp; imagesDb.ImagesTable.Remove(deletedImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong>e. Copy the Image </strong></p>
<p class="MsoNormal">We first get the source image according to the ImageId, and then create the new image. After save the changes, the new image now is in the database.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim copiedImage As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()


If copiedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim copiedImageInfo As ImageInSQLAzure = copiedImage.ImageInfo
&nbsp;&nbsp;&nbsp; Dim newImage As New ImagesTable()
&nbsp;&nbsp;&nbsp; Dim newImageInfo As New ImageInSQLAzure()


&nbsp;&nbsp;&nbsp; ' Copy the info of image.
&nbsp;&nbsp;&nbsp; newImageInfo.FileName = copiedImageInfo.FileName
 &nbsp;&nbsp;&nbsp;newImageInfo.ImageName = &quot;Copy of &quot;&quot;&quot; &amp; copiedImageInfo.ImageName &amp; &quot;&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp; newImageInfo.Description = copiedImageInfo.Description


&nbsp;&nbsp;&nbsp; newImage.ImageData = copiedImage.ImageData
&nbsp;&nbsp;&nbsp; newImage.ImageInfo = newImageInfo


&nbsp;&nbsp;&nbsp; imagesDb.SQLAzureImages.Add(newImageInfo)
&nbsp;&nbsp;&nbsp; imagesDb.ImagesTable.Add(newImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">Dim copiedImage As ImagesTable = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.ImagesTable
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()


If copiedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim copiedImageInfo As ImageInSQLAzure = copiedImage.ImageInfo
&nbsp;&nbsp;&nbsp; Dim newImage As New ImagesTable()
&nbsp;&nbsp;&nbsp; Dim newImageInfo As New ImageInSQLAzure()


&nbsp;&nbsp;&nbsp; ' Copy the info of image.
&nbsp;&nbsp;&nbsp; newImageInfo.FileName = copiedImageInfo.FileName
 &nbsp;&nbsp;&nbsp;newImageInfo.ImageName = &quot;Copy of &quot;&quot;&quot; &amp; copiedImageInfo.ImageName &amp; &quot;&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp; newImageInfo.Description = copiedImageInfo.Description


&nbsp;&nbsp;&nbsp; newImage.ImageData = copiedImage.ImageData
&nbsp;&nbsp;&nbsp; newImage.ImageInfo = newImageInfo


&nbsp;&nbsp;&nbsp; imagesDb.SQLAzureImages.Add(newImageInfo)
&nbsp;&nbsp;&nbsp; imagesDb.ImagesTable.Add(newImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong>2. Store the images in Blob </strong></p>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>a. Model Class </strong>
</p>
<p class="MsoNormal">We use the following class to build a table to store the info of the image and the Uri of Blob.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class ImageInBlob
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; Public Property FileName() As String
&nbsp;&nbsp;&nbsp; Public Property ImageName() As String
&nbsp;&nbsp;&nbsp; Public Property Description() As String
&nbsp;&nbsp;&nbsp; Public Property BlobUri() As String
End Class

</pre>
<pre id="codePreview" class="vb">Public Class ImageInBlob
&nbsp;&nbsp;&nbsp; &lt;Key()&gt;
&nbsp;&nbsp;&nbsp; Public Property ImageId() As Int32
&nbsp;&nbsp;&nbsp; Public Property FileName() As String
&nbsp;&nbsp;&nbsp; Public Property ImageName() As String
&nbsp;&nbsp;&nbsp; Public Property Description() As String
&nbsp;&nbsp;&nbsp; Public Property BlobUri() As String
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>b. Show the Gallery
</strong></p>
<p class="MsoNormal">We bind the info of image and the Uri of Blob to the ListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Me.images.DataSource = imagesDb.BlobImages.ToList()

</pre>
<pre id="codePreview" class="vb">Me.images.DataSource = imagesDb.BlobImages.ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>c. Upload Image </strong>
</p>
<p class="MsoNormal">We first create a blob and save the data of image into the blob. And then we will save the info of image and Uri of blob to the database.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">name = If(String.IsNullOrEmpty(name), &quot;unknown&quot;, name)
Dim blob = Me.GetContainer().GetBlobReference(name)


blob.Properties.ContentType = contentType


Dim newImage As New ImageInBlob()
newImage.FileName = fileName
newImage.ImageName = name
newImage.Description = If(String.IsNullOrEmpty(description), &quot;unknown&quot;, description)


blob.UploadByteArray(data)
newImage.BlobUri = blob.Uri.ToString()


imagesDb.BlobImages.Add(newImage)
imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">name = If(String.IsNullOrEmpty(name), &quot;unknown&quot;, name)
Dim blob = Me.GetContainer().GetBlobReference(name)


blob.Properties.ContentType = contentType


Dim newImage As New ImageInBlob()
newImage.FileName = fileName
newImage.ImageName = name
newImage.Description = If(String.IsNullOrEmpty(description), &quot;unknown&quot;, description)


blob.UploadByteArray(data)
newImage.BlobUri = blob.Uri.ToString()


imagesDb.BlobImages.Add(newImage)
imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>d. Delete Image </strong>
</p>
<p class="MsoNormal">We first get the ImageInBlob according to the ImageId, and then get the blob according to the ImageInBlob.Uri. After we delete the blob, we will remove the info of image from the database.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim deletedImage As ImageInBlob = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.BlobImages
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If deletedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; ' Delete an blob by uri.
&nbsp;&nbsp;&nbsp; Dim blob = Me.GetContainer().GetBlobReference(deletedImage.BlobUri)
&nbsp;&nbsp;&nbsp; blob.DeleteIfExists()


&nbsp;&nbsp;&nbsp; imagesDb.BlobImages.Remove(deletedImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">Dim deletedImage As ImageInBlob = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.BlobImages
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If deletedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; ' Delete an blob by uri.
&nbsp;&nbsp;&nbsp; Dim blob = Me.GetContainer().GetBlobReference(deletedImage.BlobUri)
&nbsp;&nbsp;&nbsp; blob.DeleteIfExists()


&nbsp;&nbsp;&nbsp; imagesDb.BlobImages.Remove(deletedImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong><span>&nbsp;&nbsp;&nbsp; </span>e. Copy Image </strong>
</p>
<p class="MsoNormal">We first get the source Image according to the ImageId, and then get the source blob according to the Uri. After we create the copy of the blob, we also insert a copy of the info to the database.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim copiedImage As ImageInBlob = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.BlobImages
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If copiedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim srcBlob = Me.GetContainer().GetBlobReference(copiedImage.BlobUri)


&nbsp;&nbsp;&nbsp; Dim newImageName As String = &quot;Copy of &quot;&quot;&quot; &amp; copiedImage.ImageName &amp; &quot;&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp; Dim newBlob = Me.GetContainer().GetBlobReference(Guid.NewGuid().ToString())


&nbsp;&nbsp;&nbsp; ' Copy content from source blob
&nbsp;&nbsp;&nbsp; newBlob.CopyFromBlob(srcBlob)


&nbsp;&nbsp;&nbsp; ' Copy the info of image.
&nbsp;&nbsp;&nbsp; Dim newImage As New ImageInBlob()
&nbsp;&nbsp;&nbsp; newImage.FileName = copiedImage.FileName
&nbsp;&nbsp;&nbsp; newImage.ImageName = newImageName
&nbsp;&nbsp;&nbsp; newImage.Description = copiedImage.Description
&nbsp;&nbsp;&nbsp; newImage.BlobUri = newBlob.Uri.ToString()


&nbsp;&nbsp;&nbsp; imagesDb.BlobImages.Add(newImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
<pre id="codePreview" class="vb">Dim copiedImage As ImageInBlob = (
&nbsp;&nbsp;&nbsp; From i In imagesDb.BlobImages
&nbsp;&nbsp;&nbsp; Where i.ImageId = imageId
&nbsp;&nbsp;&nbsp; Select i).FirstOrDefault()
If copiedImage IsNot Nothing Then
&nbsp;&nbsp;&nbsp; Dim srcBlob = Me.GetContainer().GetBlobReference(copiedImage.BlobUri)


&nbsp;&nbsp;&nbsp; Dim newImageName As String = &quot;Copy of &quot;&quot;&quot; &amp; copiedImage.ImageName &amp; &quot;&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp; Dim newBlob = Me.GetContainer().GetBlobReference(Guid.NewGuid().ToString())


&nbsp;&nbsp;&nbsp; ' Copy content from source blob
&nbsp;&nbsp;&nbsp; newBlob.CopyFromBlob(srcBlob)


&nbsp;&nbsp;&nbsp; ' Copy the info of image.
&nbsp;&nbsp;&nbsp; Dim newImage As New ImageInBlob()
&nbsp;&nbsp;&nbsp; newImage.FileName = copiedImage.FileName
&nbsp;&nbsp;&nbsp; newImage.ImageName = newImageName
&nbsp;&nbsp;&nbsp; newImage.Description = copiedImage.Description
&nbsp;&nbsp;&nbsp; newImage.BlobUri = newBlob.Uri.ToString()


&nbsp;&nbsp;&nbsp; imagesDb.BlobImages.Add(newImage)
&nbsp;&nbsp;&nbsp; imagesDb.SaveChanges()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="https://www.windowsazure.com/en-us/develop/net/how-to-guides/blob-storage">How to use the Microsoft Azure&nbsp;Blob Storage Service in .NET</a><span class="MsoHyperlink">
</span></p>
<p class="MsoNormal"><a href="http://www.windowsazure.com/en-us/develop/net/tutorials/cloud-service-with-sql-database/">Deploying an ASP.NET Web Application to a Microsoft Azure Cloud Service and SQL Database</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
