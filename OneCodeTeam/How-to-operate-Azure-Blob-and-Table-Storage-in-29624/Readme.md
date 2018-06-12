# How to operate Azure Blob and Table Storage in Windows Store apps
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Windows Azure Storage Client Library
## IsPublished
* True
## ModifiedDate
* 2014-06-29 07:58:07
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to operate Azure Blob and Table Storage in Windows Store applications (CSAzureWin8WithAzureStorage)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Windows Azure storage class libraries now support Windows Store apps.</p>
<p style="margin-top:0in; margin-right:0in; margin-bottom:12.0pt; margin-left:0in; line-height:18.45pt; background:white">
<span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">To install Windows Azure Storage, run the following command in the</span><span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#333333">&nbsp;</span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#333333"><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console" style="outline:none"><span style="color:#0071bc">Package
 Manager Console</span></a></span><span style="font-size:10.5pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#333333">
</span></p>
<p class="MsoNormal"><span style="font-size:15.0pt; line-height:115%; font-family:&quot;Lucida Console&quot;; color:#e2e2e2; background:#202020">PM&gt; Install-Package WindowsAzure.Storage</span> -PreView -Pre</p>
<p class="MsoNormal">This sample will show you how to operate Azure blob storage and table storage in your store app, including uploading/downloading/deleting files from blob storage, and inserting/deleting Azure table storage rows.</p>
<p class="MsoNormal">In this sample, you can upload images to Azure blob storage, and store the image related information to Azure table storage.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Change the Azure Storage Account and Key to yours in app.xaml.cs file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static StorageCredentials credentials = new StorageCredentials(&quot;{Storage-Account}&quot;, &quot;{Storage-Account-Key}&quot;);

</pre>
<pre id="codePreview" class="csharp">public static StorageCredentials credentials = new StorageCredentials(&quot;{Storage-Account}&quot;, &quot;{Storage-Account-Key}&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Run the application.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click anywhere on the screen, and click the Upload button in the bottom app bar, select a picture, input Name and Description.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/119399/1/image.png" alt="" width="576" height="242" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click &quot;Save to Cloud&quot;. The app will redirect to MainPage like below.</p>
<p class="MsoListParagraphCxSpMiddle">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/119400/1/image.png" alt="" width="576" height="127" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the item in list view, you can get details.</p>
<p class="MsoListParagraphCxSpMiddle">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/119401/1/image.png" alt="" width="576" height="333" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the item to select it.</p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/119402/1/image.png" alt="" width="576" height="112" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the app to show the app bar, click the &quot;Delete&quot; button to delete it from Cloud.</p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">This code sample provides many reusable methods. It uses DynamicTableEntity class as a Property.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class PictureViewModel
{
&nbsp;&nbsp;&nbsp; private DynamicTableEntity entity;


&nbsp;&nbsp;&nbsp; public PictureViewModel()
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //TODO:This username should be changed to User account in real app
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this.entity = new DynamicTableEntity() { PartitionKey = &quot;UserName&quot;, RowKey = DateTime.Now.ToFileTime().ToString() };
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; public string Name { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;FileName&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;FileName&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; public string PictureUrl {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;ImageUrl&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;ImageUrl&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;public string Description
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;Description&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;Description&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; public DynamicTableEntity PictureTableEntity { get { return entity; } set {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity = value;
&nbsp;&nbsp;&nbsp; } }
&nbsp;&nbsp;&nbsp; public StorageFile PictureFile { get; set; }
 
}

</pre>
<pre id="codePreview" class="csharp">public class PictureViewModel
{
&nbsp;&nbsp;&nbsp; private DynamicTableEntity entity;


&nbsp;&nbsp;&nbsp; public PictureViewModel()
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //TODO:This username should be changed to User account in real app
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; this.entity = new DynamicTableEntity() { PartitionKey = &quot;UserName&quot;, RowKey = DateTime.Now.ToFileTime().ToString() };
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; public string Name { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;FileName&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;FileName&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; public string PictureUrl {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;ImageUrl&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;ImageUrl&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;public string Description
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return entity.Properties[&quot;Description&quot;].StringValue;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity.Properties.Add(new KeyValuePair&lt;string, EntityProperty&gt;(&quot;Description&quot;, new EntityProperty(value)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; public DynamicTableEntity PictureTableEntity { get { return entity; } set {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; entity = value;
&nbsp;&nbsp;&nbsp; } }
&nbsp;&nbsp;&nbsp; public StorageFile PictureFile { get; set; }
 
}
</pre>
</div>
</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">You can also implement the ITableEntity class by yourself.</p>
<p class="MsoListParagraph">&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
