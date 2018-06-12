# How to use Microsoft.WindowsAzure.Storage 2.0 operate Azure Table storage in Win
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2013-06-16 06:33:43
## Description

<h1><span lang="EN-US">How to use latest Azure Table Storage SDK with Windows Store APP (VBAzureTableStorageClassLibaryWithStoreApp)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="Normal"><span lang="EN-US">This sample shows how to use latest Azure Table Storage SDK with Windows Store APP.</span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="Normal"><span lang="EN-US">You need to download <a href="http://az412849.vo.msecnd.net/downloads01/Microsoft.WindowsAzure.Storage-for-win8.zip">
Storage Client libraries for Windows 8</a>, <a href="http://www.microsoft.com/en-us/download/details.aspx?id=30714">
WCF data service tools for windows store apps</a>. </span></p>
<p class="Normal"><span lang="EN-US">Then you can add references to Microsoft.WindowsAzure.storage, and Microsoft.WindowsAzure.Storage.Table.
</span></p>
<p class="MsoNormal" style="margin-bottom:5.0pt; line-height:normal; background:white">
<span lang="EN-US">You also need to add the reference to Microsoft.Data.Services.Client.WindowsStore.
<a href="http://www.microsoft.com/en-us/download/details.aspx?id=30714"><span style="color:windowtext; text-decoration:none">WCF data service tools for windows store apps</span></a> is a
<a href="http://www.damirscorner.com/ct.ashx?id=1fd28e2b-ddf0-4d07-8df4-21b516d992a6&url=http%3a%2f%2fwww.microsoft.com%2fen-us%2fdownload%2fdetails.aspx%3fid%3d30714">
<span style="color:windowtext; text-decoration:none">downloadable package</span></a> which extends the Add Service Reference functionality in Visual Studio 2012 to support OData feeds. Without it OData feeds can't be added as services references to a Windows
 Store app project. To make this work, you can add another package source to NuGet, pointing to your local folder where the downloaded installer has put the packages, i.e. c:\Program Files (x86)\Microsoft WCF Data Services\5.0\bin\NuGet. I suggest you define
 it as the secondary package source, so that after the packages are available directly from NuGet, they will be retrieved from there instead from your local disk.
</span></p>
<p class="Normal"><span lang="EN-US">You can add the package source either through Package Manager Settings in Visual Studio Options window:
</span></p>
<p class="Normal"><span lang="EN-US" style="font-size:8.0pt; line-height:115%; font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;; color:black"><img src="/site/view/file/85042/1/image.png" alt="" width="576" height="336" align="middle">
</span><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">Then manage Nuget to install this WCF Data Service Client for Windows Store Apps.
</span></p>
<p class="Normal"><span lang="EN-US" style=""><img src="/site/view/file/85043/1/image.png" alt="" width="576" height="331" align="middle">
</span><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">Then press Ctrl&#43;F5 to run the sample. </span>
</p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You can save a new to-do Items to table storage with save button.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85044/1/image.png" alt="" width="552" height="434" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You can use delete button to delete the selected item, this item will be deleted in table storage.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You can use complete button to mark selected items as completed, the selected item in listview will be removed, and in table storage the item's IsCompleted filed will be true.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Create a new VB.NET blank Windows Store app named VBAzureTableStorageClassLibaryWithStoreApp.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Design the UI as below.</span></p>
<h3><span lang="EN-US">MainPage.xml</span></h3>
<p class="Normal"><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">3. Create a static table instance in App.xaml.</span></p>
<h3><span lang="EN-US">Create a new table instance</span></h3>
<p class="Normal"><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">4. Add click event for buttons at the code behind.</span></p>
<p class="Normal"><span lang="EN-US">For save button:</span></p>
<p class="Normal"><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">For Delete button:</span></p>
<p class="Normal"><span lang="EN-US"></span></p>
<p class="Normal"><span lang="EN-US">For Complete button:</span></p>
<p class="Normal"><span lang="EN-US"></span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal"><span lang="EN-US" style="font-size:8.0pt; line-height:115%; color:#595959"><a href="http://blogs.msdn.com/b/windowsazurestorage/archive/2012/11/06/windows-azure-storage-client-library-2-0-tables-deep-dive.aspx">http://blogs.msdn.com/b/windowsazurestorage/archive/2012/11/06/windows-azure-storage-client-library-2-0-tables-deep-dive.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
