# How to manage Azure BLOB storage content in Windows Store apps
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
* Windows 8
## IsPublished
* True
## ModifiedDate
* 2015-02-04 12:12:12
## Description

<h1><span lang="EN-US">How to manage Azure BLOB storage content in Windows Store apps</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="Normal"><span lang="EN-US">Windows Azure storage class library now supports windows store app.</span></p>
<p class="Normal"><span lang="EN-US">This sample will show you how to operate Azure blob storage in your store app, including upload/download/delete file from blob storage.</span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">You need to download the <a href="http://az412849.vo.msecnd.net/downloads01/Microsoft.WindowsAzure.Storage-for-win8.zip">
windows azure storage sdk for win-8</a> at first, then add reference to windowsAzure.storage.winmd file.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Change the account to your own in app.xaml.cs file.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Press Ctrl&#43;F5 to run the app.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Click &quot;save to blob&quot; button, choose a picture in your picture library and click&quot;OK&quot;.
</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US"><img src="/site/view/file/85212/1/image.png" alt="" width="576" height="359" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You will see the list as below:</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span lang="EN-US"><span>&nbsp; <img src="/site/view/file/85213/1/image.png" alt="" width="392" height="761" align="middle">
</span></span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Click an item, then you can see the picture show up on the screen.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US"><img src="/site/view/file/85214/1/image.png" alt="" width="577" height="298" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Right click an item, and click &quot;Delete from blob&quot; button.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">The selected item will be deleted.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Create a blank Windows Store app named: &quot;CSAzureBlobClassLiabaryWithWin8App&quot;.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add reference to Microsft.WidnowsAzure.Storage.winmd.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US"><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add the code below to app.xaml.cs file.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">This code specific a container for your programe.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">&nbsp;</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">4. For more details please refer to
<span class="SpellE">MainPage.xaml.cs</span>.</span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal"><span lang="EN-US"><a href="http://blogs.msdn.com/b/windowsazurestorage/archive/2012/11/05/windows-azure-storage-client-library-for-windows-runtime.aspx">http://blogs.msdn.com/b/windowsazurestorage/archive/2012/11/05/windows-azure-storage-client-library-for-windows-runtime.aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
