# Access Azure table storage via WCF Data Services (VBAzureTableStorageWCFDS)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Silverlight
* Microsoft Azure
* Data Platform
## Topics
* WCF Data Services
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:26:41
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>Overview</h2>
<p>This sample demonstrates how to run a WCF Data Service on Windows Azure. The data service uses table storage as its data source. A test Silverlight client is also available.</p>
<p>Both table storage and WCF Data Services use the OData protocol. So in most cases, you can work with table storage in client applications using StorageClient library directly. But, it is always a good idea to adopt SOA. By adding a service layer in the solution's
 architecture, your service can be invoked by multiple clients built with different technologies. In addition, you should not distribute your storage key to your clients. So you should always work with storage in a service that is under your control, and let
 clients invoke your service. Finally, cross domain policy file is not currently available for table storage, so if you want to build a Silverlight client, you must create a web service as a bridge.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Prerequests</h2>
<p>For this sample to work, you must install the Windows Azure SDK and the Windows Azure Tools for Visual Studio. This sample works on the local Development Fabric (included in the Windows Azure SDK) and also in the Windows Azure cloud service. To run the sample
 in the cloud service, you must also have a valid Windows Azure account. More information about Windows Azure can be found here:
<a href="http://msdn.microsoft.com/en-us/library/dd179367.aspx">http://msdn.microsoft.com/en-us/library/dd179367.aspx</a>. Please note that the Windows Azure SDK also has a number of its own pre-requisites (including IIS and SQL Server).</p>
<h2>Running the Sample</h2>
<p>You must start Visual Studio in elevated (administrator) mode. Right-click on Visual Studio and then click Run as Administrator. This is required by the Windows Azure simulation environment.</p>
<p>Please make sure the &quot;CloudService&quot; project is set as the starting project of the solution, if not already.</p>
<p>Running the application, and you will see a Silverlight DataGrid with some pre-populated entities. Select an item, type a name and an age in the TextBoxes, and click a Button to perform the insert/delete/update operations. Note the sample doesn't implement
 the feature where you can directly update the entity by typing into the DataGrid.</p>
<p>If you want to test against cloud storage, please modify the connection strings in the ServiceConfiguration.cscfg file:</p>
<p class="MsoNormal"><span style="font-family:'Courier New'; color:blue; font-size:10pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-family:'Courier New'; color:#a31515; font-size:10pt">Setting</span><span style="font-family:'Courier New'; color:blue; font-size:10pt">
</span><span style="font-family:'Courier New'; color:red; font-size:10pt">name</span><span style="font-family:'Courier New'; color:blue; font-size:10pt">=</span><span style="font-family:'Courier New'; font-size:10pt">&quot;<span style="color:blue">DiagnosticsConnectionString</span>&quot;<span style="color:blue">
</span><span style="color:red">value</span><span style="color:blue">=</span>&quot;<span style="color:blue">DefaultEndpointsProtocol=https;AccountName=[AccountName];AccountKey=[AccountKey]</span>&quot;<span style="color:blue"> /&gt;&lt;O:P&gt;&lt;/O:P&gt;</span></span></p>
<p class="MsoNormal"><span style="font-family:'Courier New'; color:blue; font-size:10pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-family:'Courier New'; color:#a31515; font-size:10pt">Setting</span><span style="font-family:'Courier New'; color:blue; font-size:10pt">
</span><span style="font-family:'Courier New'; color:red; font-size:10pt">name</span><span style="font-family:'Courier New'; color:blue; font-size:10pt">=</span><span style="font-family:'Courier New'; font-size:10pt">&quot;<span style="color:blue">DataConnectionString</span>&quot;<span style="color:blue">
</span><span style="color:red">value</span><span style="color:blue">=</span>&quot;<span style="color:blue">DefaultEndpointsProtocol=https;AccountName=[AccountName];AccountKey=[AccountKey]</span>&quot;<span style="color:blue"> /&gt;</span></span>&lt;SETTING value=&quot;DefaultEndpointsProtocol=https;AccountName=bluestar;AccountKey=XM9Chm8IZQtJERuOELiO3YZtNCBhkxUa2NbMN9J3NAuVwyLMbfnzhbV/W8Obh9UVm86EYzQtq9XJfK&#43;LJ4k4Uw==&quot;
 name=&quot;DataConnectionString&quot; /&gt;&lt;SETTING value=&quot;DefaultEndpointsProtocol=https;AccountName=bluestar;AccountKey=XM9Chm8IZQtJERuOELiO3YZtNCBhkxUa2NbMN9J3NAuVwyLMbfnzhbV/W8Obh9UVm86EYzQtq9XJfK&#43;LJ4k4Uw==&quot; name=&quot;DataConnectionString&quot; /&gt;</p>
<p>Replace [AccountName] with your storage account name, and replace [AccountKey] with your storage account key.</p>
<p>Before uploading the package to the cloud, please make sure to modify the connection strings to cloud storage.</p>
<h2>Description</h2>
<p>The sample solution contains 3 projects.</p>
<h3>CloudService</h3>
<p>The cloud service project. When testing in Development Fabric, please make sure to set this project as the starting project of the solution.</p>
<h3>WebRole</h3>
<p>The Web Role project. It is a normal ASP.NET project that hosts a WCF Data Service. Hosting a data service in Windows Azure is the same as hosting in IIS.</p>
<p>The data service uses table storage as the data source. WCF Data Services ship with 2 default data source providers: EDM and LINQ to SQL. It's very easy to use data services against those data sources. But when working with custom data sources, such as table
 storage, in order to support insert/delete/update, you're required to provide a custom object context class that implements IUpdatable. In this sample, the PersonDataServiceContext class is the object context class. Please do not confuse it with the table
 storage context class (PersonTableStorageContext).</p>
<p>If you're not familar with WCF Data Services, I highly suggest you to learn the VBADONETDataService sample first. That sample serves as a pre-request knowledge of this sample. ADO.NET Data Services is the former name of WCF Data Services. Data service is
 now in the WCF product family, because it has more to do with WCF than ADO.NET.</p>
<h3>Client</h3>
<p>A Silverlight client application that invokes the WCF Data Service. Silverlight applications run on the client side. If you distribute your storage account key with Silverlight applications, every user will get your key, and they will be able to hack your
 storage! So you must make the Silverlight application talk to a service that is under your control, instead of working with storage directly.</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
