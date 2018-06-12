# VB Silverlight client inovkes WCF Data Services (VBADONETDataServiceSL3Client)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
* ADO.NET
* WCF Data Services
## Topics
* Data Access
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:26:04
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBADONETDataServiceSL3Client Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The VBADONETDataServiceSL3Client example demonstrates how to access ADO.NET <br>
Data Services in Silverlight. It creates three proxies that maps three different<br>
services at server side, which respectively uses ADO.NET Entity Data Model, <br>
Linq to SQL Data Classes, and non-relational in-memory data as data source.<br>
<br>
This sample demonstrates how to select, update, delete and insert data via REST<br>
calls to ADO.NET Data Services. These REST messages will be automatically created<br>
by the proxy class. We can also create/send/receive messages on our own but using
<br>
proxy is much more easier.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
VBADONETDataServiceSL3Client -&gt; VBADONETDataService -&gt; SQLServer2005DB<br>
VBADONETDataServiceSL3Client sends async REST call to VBADONETDataService to<br>
retrieve data.<br>
VBADONETDataService accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Note:</h3>
<p style="font-family:Courier New"><br>
Before running this project please make sure you've deployed VBADONETDataService<br>
and changed the URL of the service (such as &quot;<a target="_blank" href="http://localhost/SchoolLinqToEntities.svc&quot;">http://localhost/SchoolLinqToEntities.svc&quot;</a><br>
in SchoolLinqToEntitiesUpdate.xaml.VB) to your own one. Also make sure the web<br>
page that hosts Silverlight application are in the same domain of ADO.NET Data Service.<br>
For more details about this requirement, please check out &quot;Known Issue&quot; section<br>
of this file.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Select.<br>
&nbsp; (1) Initialize a DataServiceContext object.<br>
&nbsp; <br>
&nbsp; (2) Create a DataServiceQuery(Of T) object.<br>
&nbsp; <br>
&nbsp; (3) Call the DataServiceQuery(Of T).BeginExecute() method to begin an<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; async REST call. Hook up a callback method which will be called after<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; query complete.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (4) Call DataServiceQuery(Of T).EndExecute() method to end the query<br>
&nbsp; &nbsp; &nbsp; and retrieve data.<br>
&nbsp; &nbsp; &nbsp; <br>
2. Update.<br>
&nbsp; <br>
&nbsp; (1) Maintain a reference of DataServiceContext object that is retrieved by<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; select operation. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (2) Call DataServiceContext.UpdateObject() method.<br>
&nbsp; <br>
&nbsp; (3) Call DataServiceContext.BeginSaveChanges() method to begin an async REST<br>
&nbsp; &nbsp; &nbsp; call. Hook up a callback method which will be called after query complete.<br>
&nbsp; <br>
&nbsp; (4) Call DataServiceContext.EndSaveChanges() method to end the query.<br>
&nbsp; <br>
3. Delete.<br>
<br>
&nbsp; (1) Maintain a reference of DataServiceContext object that is retrieved by<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; select operation. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (2) Call DataServiceContext.DeleteObject() method.<br>
&nbsp; <br>
&nbsp; (3) Call DataServiceContext.BeginSaveChanges() method to begin an async REST<br>
&nbsp; &nbsp; &nbsp; call. Hook up a callback method which will be called after query complete.<br>
&nbsp; <br>
&nbsp; (4) Call DataServiceContext.EndSaveChanges() method to end the query.<br>
&nbsp; <br>
4. Insert.<br>
<br>
&nbsp; (1) Maintain a reference of DataServiceContext object that is retrieved by<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; select operation. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (2) Call DataServiceContext.AddObject() method. (Or a more friendly method
<br>
&nbsp; &nbsp; &nbsp; such as AddToCategories() in this sample)<br>
&nbsp; <br>
&nbsp; (3) Call DataServiceContext.BeginSaveChanges() method to begin an async REST<br>
&nbsp; &nbsp; &nbsp; call. Hook up a callback method which will be called after query complete.<br>
&nbsp; <br>
&nbsp; (4) Call DataServiceContext.EndSaveChanges() method to end the query.<br>
&nbsp; <br>
&nbsp; </p>
<h3>Known Issue:</h3>
<p style="font-family:Courier New"><br>
If the web page that hosts Silverlight application and the ADO.NET Data Services <br>
are from different domains, the sample will not work in FireFox. Because IE 8 <br>
allows you to do cross-domain access from XmlHttpRequest if have the option set <br>
or brings up a prompt if you don’t. Firefox silently fails when you attempt <br>
Cross-domain XmlHttpRequest.<br>
<br>
To work around this issue, you have two options:<br>
<br>
1. Use WebClient or HttpWebRequest instead of the generated proxy.<br>
<br>
For more details about the REST HTTP messages, please refer to:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd672595(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd672595(VS.100).aspx</a><br>
<br>
Or you can create a test client of ADO.NET Data Service and use tools like Fiddler to view the
<br>
correct messages directly. <br>
<br>
This approach is a little overwhelming because we have to do a lot of stuffs to <br>
request/receive/parse messages.<br>
<br>
2. Add a web service in the same domain of the web site that hosts Silverlight application.<br>
The web service acts as a proxy. Silverlight application access the web service and web service<br>
retrieve data from ADO.NET Data Service on behalf of Silverlight application.<br>
<br>
For more details please check out:<br>
<a target="_blank" href="http://blogs.msdn.com/phaniraj/archive/2008/10/21/accessing-cross-domain-ado-net-data-services-from-the-silverlight-client-library.aspx">http://blogs.msdn.com/phaniraj/archive/2008/10/21/accessing-cross-domain-ado-net-data-services-from-the-silverlight-client-library.aspx</a><br>
<a target="_blank" href="http://blogs.msdn.com/tom_laird-mcconnell/archive/2009/03/25/creating-an-ado-net-data-service-proxy-as-workaround-for-silverlight-ado-net-cross-domain-issue.aspx">http://blogs.msdn.com/tom_laird-mcconnell/archive/2009/03/25/creating-an-ado-net-data-service-proxy-as-workaround-for-silverlight-ado-net-cross-domain-issue.aspx</a><br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ADO.NET Data Services (Silverlight)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc838234(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc838234(VS.95).aspx</a><br>
<br>
How to: Specify Browser or Client HTTP Handling<br>
<a target="_blank" href="http://blogs.msdn.com/silverlight_sdk/archive/2009/08/12/new-networking-stack-in-silverlight-3.aspx">http://blogs.msdn.com/silverlight_sdk/archive/2009/08/12/new-networking-stack-in-silverlight-3.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
