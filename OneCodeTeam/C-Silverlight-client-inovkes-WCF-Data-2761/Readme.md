# C# Silverlight client inovkes WCF Data Services (CSADONETDataServiceSL3Client)
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
* 2011-05-05 04:52:14
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSADONETDataServiceSL3Client Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSADONETDataServiceSL3Client example demonstrates how to access ADO.NET <br>
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
CSADONETDataServiceSL3Client -&gt; CSADONETDataService -&gt; SQLServer2005DB<br>
CSADONETDataServiceSL3Client sends async REST call to CSADONETDataService to<br>
retrieve data.<br>
CSADONETDataService accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Note:</h3>
<p style="font-family:Courier New"><br>
Before running this project please make sure you've deployed CSADONETDataService<br>
and changed the URL of the service (such as &quot;<a target="_blank" href="http://localhost/SchoolLinqToEntities.svc&quot;">http://localhost/SchoolLinqToEntities.svc&quot;</a><br>
in SchoolLinqToEntitiesUpdate.xaml.cs) to your own one. Also make sure the web<br>
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
&nbsp; (2) Create a DataServiceQuery&lt;T&gt; object.<br>
&nbsp; <br>
&nbsp; (3) Call the DataServiceQuery&lt;T&gt;.BeginExecute() method to begin an<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; async REST call. Hook up a callback method which will be called after<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; query complete.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (4) Call DataServiceQuery&lt;T&gt;.EndExecute() method to end the query<br>
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
1. Use WebClient or HttpWebRequest instead of the generated proxy. Below is the <br>
sample code to update a CourseGrade record:<br>
<br>
bool httpResult = WebRequest.RegisterPrefix(&quot;http://&quot;, WebRequestCreator.ClientHttp); &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
decimal grade = 2;<br>
string s = string.Format(@&quot;&lt;?xml version=&quot;&quot;1.0&quot;&quot; encoding=&quot;&quot;utf-8&quot;&quot; standalone=&quot;&quot;yes&quot;&quot;?&gt;<br>
&lt;entry xmlns:d=&quot;&quot;<a target="_blank" href="http://schemas.microsoft.com/ado/2007/08/dataservices&quot;&quot;">http://schemas.microsoft.com/ado/2007/08/dataservices&quot;&quot;</a> xmlns:m=&quot;&quot;<a target="_blank" href="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata&quot;&quot;">http://schemas.microsoft.com/ado/2007/08/dataservices/metadata&quot;&quot;</a>
 xmlns=&quot;&quot;<a target="_blank" href="http://www.w3.org/2005/Atom&quot;&quot;&gt;">http://www.w3.org/2005/Atom&quot;&quot;&gt;</a><br>
&nbsp;&lt;category scheme=&quot;&quot;<a target="_blank" href="http://schemas.microsoft.com/ado/2007/08/dataservices/scheme&quot;&quot;">http://schemas.microsoft.com/ado/2007/08/dataservices/scheme&quot;&quot;</a> term=&quot;&quot;SQLServer2005DBModel.CourseGrade&quot;&quot;
 /&gt;<br>
&nbsp;&lt;title /&gt;<br>
&nbsp;&lt;updated&gt;{0}&lt;/updated&gt;<br>
&nbsp;&lt;author&gt;<br>
&nbsp; &nbsp;&lt;name /&gt;<br>
&nbsp;&lt;/author&gt;<br>
&nbsp;&lt;id&gt;<a target="_blank" href="http://yourdomain/SchoolLinqToEntities.svc/CourseGrade(7)&lt;/id&gt;">http://yourdomain/SchoolLinqToEntities.svc/CourseGrade(7)&lt;/id&gt;</a><br>
&nbsp;&lt;content type=&quot;&quot;application/xml&quot;&quot;&gt;<br>
&nbsp; &nbsp;&lt;m:properties&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;d:EnrollmentID m:type=&quot;&quot;Edm.Int32&quot;&quot;&gt;7&lt;/d:EnrollmentID&gt;<br>
&nbsp; &nbsp; &nbsp;&lt;d:Grade m:type=&quot;&quot;Edm.Decimal&quot;&quot;&gt;{1}&lt;/d:Grade&gt;<br>
&nbsp; &nbsp;&lt;/m:properties&gt;<br>
&nbsp;&lt;/content&gt;<br>
&lt;/entry&gt;&quot;,DateTime.Now.ToUniversalTime().ToString(&quot;yyyy-MM-ddTHH:mm:ssZ&quot;),grade);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;byte[] buffer = System.Text.Encoding.UTF8.GetBytes(s);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(&quot;<a target="_blank" href="http://yourdomain/SchoolLinqToEntities.svc/CourseGrade(7)&quot;));">http://yourdomain/SchoolLinqToEntities.svc/CourseGrade(7)&quot;));</a><br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.Method = &quot;POST&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.Headers[&quot;x-http-method&quot;] = &quot;PUT&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.ContentType = &quot;application/atom&#43;xml&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.Headers[&quot;dataserviceversion&quot;] = &quot;1.0;Silverlight&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.Headers[&quot;maxdataserviceversion&quot;] = &quot;1.0;Silverlight&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.BeginGetRequestStream((asynchronousResult) =&gt; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebRequest r = (HttpWebRequest)asynchronousResult.AsyncState;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// End the operation.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Stream postStream = r.EndGetRequestStream(asynchronousResult);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;postStream.Write(buffer, 0, buffer.Length);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;postStream.Close();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;request.BeginGetResponse((asynchronousResult2) =&gt; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebRequest r2 = (HttpWebRequest)asynchronousResult2.AsyncState;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HttpWebResponse resp = (HttpWebResponse)r2.EndGetResponse(asynchronousResult2);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Stream streamResponse = resp.GetResponseStream();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StreamReader streamRead = new StreamReader(streamResponse);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string responseString = streamRead.ReadToEnd();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Close the stream object.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;streamResponse.Close();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;streamRead.Close();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Release the HttpWebResponse.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;resp.Close();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}, request);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}, request);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
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
