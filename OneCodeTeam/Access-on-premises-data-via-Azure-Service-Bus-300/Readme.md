# Access on-premises data via Azure Service Bus (VBAzureServiceBusWCFDS)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Microsoft Azure
* Data Platform
## Topics
* WCF Data Services
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:37:49
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>APPFABRIC : VBAzureServiceBusWCFDS Solution Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
It's a common scenario that we want to expose local database to internet and cloud access.<br>
However it involves a lot of security problems if we directly allow TCP connections<br>
to local SQL Server. <br>
<br>
In this scenario, another difficulty is to scale the entire system. <br>
<br>
Windows Azure platform&nbsp;can help us resolve both of above issues.<br>
<br>
The solution uses the following techniques/products:<br>
<br>
*Service Bus in Windows Azure <br>
*WCF Data Services (formerly named ADO.NET Data Services)<br>
*SQL Server<br>
<br>
Service Bus in Windows Azure provides us&nbsp;with&nbsp;the flexibility and the scalability<br>
of the entire solution.(You can refer to the LoadBalance sample in AppFabric SDK to learn details<br>
about how to use Service Bus to do load balance for your service. We don't cover it in this sample<br>
for the simplicity purpose)<br>
<br>
Service Bus also allows you to expose the local data to the intenet, so you can consume the data<br>
in your cloud applications. While this sample ships with a standard ASP.NET client, you can easily<br>
convert the client to a Web Role for a Windows Azure solution.<br>
<br>
WCF Data Services works as an intermediate node that can provide additional access control and other<br>
business logic to meet your needs.You may refer to CSADONETDataService/VBADONETDataService samples to<br>
learn more about it. WCF Data Services has more to do with WCF than ADO.NET. The sample uses a WCF<br>
message inspector to workaround a potential issue in Service Bus where POST/PUT verbs do not work properly.<br>
<br>
SQL Server is the backend database.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Windows Azure AppFabric SDK V1.0<br>
<a href="http://www.microsoft.com/downloads/details.aspx?familyid=39856A03-1490-4283-908F-C8BF0BFAD8A5&displaylang=en" target="_blank">http://www.microsoft.com/downloads/details.aspx?familyid=39856A03-1490-4283-908F-C8BF0BFAD8A5&amp;displaylang=en</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
A. Change code and settings to meet your environment<br>
<br>
1.Press Control&#43;H to open &quot;Find and Replace&quot; window.Look in &quot;Entire Solution&quot;.<br>
<br>
2.Replace [Your Connection String of Northwind Database] with your connection string of
<br>
Northwind Database.<br>
<br>
3.Replace [Your Secret] with Current Management Key of your service. <br>
You can find Current Management Key from our web portal (replace [Your Service Namespace]
<br>
with your service namespace):<br>
https://appfabric.azure.com/ServiceNamespace.aspx?ServiceNamespace=[Your Service Namespace]<br>
<br>
4.Replace [Your Service Namespace] with your service namespace.<br>
<br>
<br>
B. Run Service<br>
<br>
1.Start debugging VBAzureServiceBusWCFDS project. Input your service namespace and press enter.<br>
<br>
2.Wait several seconds for service start and after you see message &quot;Press [Enter] to exit&quot;<br>
the service has been started.<br>
<br>
C. Test Service in browser<br>
<br>
1.Stop debugging service and modify Module1.vb to test in browser.Replace:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim binding As WebHttpRelayBinding = New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.Transport, RelayClientAuthenticationType.RelayAccessToken)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;with:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim binding As WebHttpRelayBinding = New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.Transport, RelayClientAuthenticationType.None)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
2.Repeat step B.<br>
<br>
3.Follow the instruction shown on the console window to access the following URI in browser to test<br>
(replace [Your Service Namespace] with your service namespace):<br>
https://[Your Service Namespace].servicebus.windows.net/DataService/Customers<br>
<br>
2.View the source of the page you'll be able to see all records in Customers table in Northwind DB.<br>
<br>
D.Consume Service in ASP.NET<br>
<br>
1. Stop debugging service and modify Module1.vb to change code back to:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim binding As WebHttpRelayBinding = New WebHttpRelayBinding(EndToEndWebHttpSecurityMode.Transport, RelayClientAuthenticationType.RelayAccessToken)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
2. Repeat step B.<br>
<br>
3. Start debugging Client project. You'll be able to view the records in database and insert records.<br>
To keep it as concise as possible we only use simple select and insert queries. After insert<br>
you can check your database to view the records or you can insert a record with CustomerID=&quot;abc&quot; so that<br>
it will be returned by the show-first-10-records query and shown on the page.If you want to know how to
<br>
do other queries please refer to WCF Data Services samples in AIO Framework.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
WCF Data Services<br>
<a href="http://msdn.microsoft.com/en-us/data/bb931106.aspx" target="_blank">http://msdn.microsoft.com/en-us/data/bb931106.aspx</a><br>
<br>
Message Inspectors<br>
<a href="http://msdn.microsoft.com/en-us/library/aa717047.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa717047.aspx</a><br>
<br>
Creating a Custom AppFabric Service Bus Binding<br>
<a href="http://msdn.microsoft.com/en-us/library/dd582769.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd582769.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
