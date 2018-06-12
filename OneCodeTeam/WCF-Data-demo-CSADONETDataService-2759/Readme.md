# WCF Data Services demo (CSADONETDataService)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* WCF Data Services
## Topics
* Data Access
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:51:04
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSADONETDataServiceClient Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CSADONETDataServiceClient example demonstrates an ADO.NET Data Service client<br>
application. It calls certain ADO.NET Data Services for ADO.NET Entity Data <br>
Model, Linq To SQL Data Classes, and non-relational in-memory data, and it <br>
demonstrates these ways (LINQ, ADO.NET query options, custom service <br>
operations) to update and query the data source. <br>
<br>
Please note: The ADO.NET Data Services URLs need to be modified based on your<br>
system's IIS setting. &nbsp;<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSADONETDataServiceClient -&gt; CSADONETDataService<br>
CSADONETDataServiceClient accesses the ADO.NET Data Services created by <br>
CSADONETDataService.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the ADO.NET Data Services<br>
client sample that calls certain ADO.NET Data Services for ADO.NET Entity <br>
Data Model, Linq To SQL Data Classes, and non-relational in-memory data. &nbsp;<br>
<br>
Step 1: Open the DB project SQLServer2005DB, right click the project file and<br>
select Deploy to create the SQLServer2005DB database in your database <br>
instance.<br>
<br>
Step 2: Modify the connection string information to consistent with your <br>
database instance and account. &nbsp;<br>
<br>
&nbsp;&lt;add name=&quot;SQLServer2005DBConnectionString&quot; connectionString=...<br>
&nbsp;&lt;add name=&quot;SQLServer2005DBEntities&quot; connectionString=...<br>
<br>
Step 3: Build the project CSADONETDataService and CSADONETDataServiceClient.<br>
<br>
Step 4: Run the output executable file of project CSADONETDataServiceClient, <br>
CSADONETDataServiceClient.exe.<br>
<br>
</p>
<h3>Creation Steps:</h3>
<p style="font-family:Courier New"><br>
A. Creating an ordinary Visual C# Console Application and adding the <br>
&nbsp; ADO.NET Data Services references.<br>
<br>
&nbsp; 1. In the same solution of the ADO.NET Data Services project, add a new <br>
&nbsp; &nbsp; &nbsp;Visual C# / Windows / Console Application project named <br>
&nbsp; &nbsp; &nbsp;CSADONETDataServiceClient.<br>
<br>
&nbsp; 2. Right click the References in the Solution Explorer, select <br>
&nbsp; &nbsp; &nbsp;Add Service References….<br>
<br>
&nbsp; 3. In the Add Service Reference dialog, click Discover, add the three <br>
&nbsp; &nbsp; &nbsp;ADO.NET Data Services Samples.svc, SchoolLinqToEntities.svc, and
<br>
&nbsp; &nbsp; &nbsp;SchoolLinqToSQL.svc, rename the Namespace of the services to <br>
&nbsp; &nbsp; &nbsp;SamplesService, SchoolLinqToEntities, and SchoolLinqToSQLService
<br>
&nbsp; &nbsp; &nbsp;respectively.<br>
<br>
B. Creating static ADO.NET Data Services URL fields, local entity classes, <br>
&nbsp; and helper methods.<br>
<br>
&nbsp; 1. Define static fields for the ADO.NET Data Services URL. &nbsp;You need to
<br>
&nbsp; &nbsp; &nbsp;modify the URL to specify the port settings of the localhost. &nbsp;<br>
<br>
&nbsp; 2. Create a local entity class named TempCourse which only have CourseID <br>
&nbsp; &nbsp; &nbsp;and Title properties and misses other properties than the Course entity
<br>
&nbsp; &nbsp; &nbsp;class in the ADO.NET Data Service references.<br>
<br>
&nbsp; 3. Create a local entity class named InnerDataServiceException to hold <br>
&nbsp; &nbsp; &nbsp;the inner exception information of the DataServiceException.<br>
<br>
&nbsp; 4. Create a helper method ParseDataServiceClientException to parse the <br>
&nbsp; &nbsp; &nbsp;DataServiceClientException via LINQ to XML methods, and return a local
<br>
&nbsp; &nbsp; &nbsp;entity class object InnerDataServiceException holding the inner
<br>
&nbsp; &nbsp; &nbsp;exception information.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; 5. Create a helper method UpdateData to save the pending modifications of <br>
&nbsp; &nbsp; &nbsp;the DataServiceContext. &nbsp;If all the DataServiceResponse.StatusCode
<br>
&nbsp; &nbsp; &nbsp;start with 2, since the status code 2** means success. &nbsp; For detail,
<br>
&nbsp; &nbsp; &nbsp;please see List of HTTP status codes. &nbsp;If there are any exception occurs
<br>
&nbsp; &nbsp; &nbsp;and the InnerException is in type of DataServiceClientException, use
<br>
&nbsp; &nbsp; &nbsp;the helper method ParseDataServiceClientException to parse the
<br>
&nbsp; &nbsp; &nbsp;exception information.<br>
<br>
C. Updating and querying database via calling ADO.NET Data Service for the <br>
&nbsp; ADO.NET Entity Data Model.<br>
<br>
&nbsp; 1. Initialize the DataService object for the ADO.NET Entity Data Model.<br>
<br>
&nbsp; 2. Create an invalid entity class, add it into the DataService context, <br>
&nbsp; &nbsp; &nbsp;and then try to save the pending modification. &nbsp; Through the helper
<br>
&nbsp; &nbsp; &nbsp;methods UpdateData and ParseDataServiceClientException, we will see
<br>
&nbsp; &nbsp; &nbsp;the exception information from the server side: The valid value of
<br>
&nbsp; &nbsp; &nbsp;PersonCategory is 1 (for students) or 2 (for instructors).<br>
&nbsp; <br>
&nbsp; 3. Create some valid entity classes and some relationships among them, <br>
&nbsp; &nbsp; &nbsp;then save the pending modification. &nbsp;Call AddTo** to add entity
<br>
&nbsp; &nbsp; &nbsp;class and call AddLink to add the relationships. &nbsp;<br>
&nbsp; &nbsp; <br>
&nbsp; 4. Perform a LINQ query which contains where, orderby, Skip, and Take <br>
&nbsp; &nbsp; &nbsp;operators or methods. &nbsp;These four LINQ operators or methods have
<br>
&nbsp; &nbsp; &nbsp;their corresponding supported ADO.NET Data Service query options
<br>
&nbsp; &nbsp; &nbsp;(filter, orderby, skip, top). &nbsp; How to use the query options will
<br>
&nbsp; &nbsp; &nbsp;be introduced in the following steps. &nbsp;<br>
&nbsp; &nbsp; <br>
&nbsp; 5. Call the service operation CourseByPerson to get the certain person’s <br>
&nbsp; &nbsp; &nbsp;courses based on the person table primary key PersonID. &nbsp;The URL for
<br>
&nbsp; &nbsp; &nbsp;the service operation CourseByPersonID can be: <br>
<br>
D. Updating and querying database via ADO.NET Data Service for LINQ to SQL <br>
&nbsp; Classes.<br>
<br>
&nbsp; 1. Initialize the DataService object for the LINQ to SQL Classes.<br>
&nbsp; &nbsp; <br>
&nbsp; 2. Create some valid entity classes and some relationship entity classes, <br>
&nbsp; &nbsp; &nbsp;then save the pending modification. &nbsp;Since LINQ to SQL does not
<br>
&nbsp; &nbsp; &nbsp;implement the many-to-many relationships, we need to add the <br>
&nbsp; &nbsp; &nbsp;relationship entity as well instead of calling AddLink to create the
<br>
&nbsp; &nbsp; &nbsp;relationships. &nbsp;First we add the entity classes, after saving the
<br>
&nbsp; &nbsp; &nbsp;entity classes, then we add the relationship entity class and save the
<br>
&nbsp; &nbsp; &nbsp;data.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. Query the many-to-many relationships through the relationship entity. &nbsp;<br>
&nbsp; &nbsp; &nbsp;First we get all CourseGrade entities of one Person based on the
<br>
&nbsp; &nbsp; &nbsp;PersonID. &nbsp;The URL can be:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://localhost/SchoolLinqToSQL.svc/Persons(PersonID)/CourseGrades.">http://localhost/SchoolLinqToSQL.svc/Persons(PersonID)/CourseGrades.</a><br>
&nbsp; &nbsp; &nbsp;By CourseGrade entity, we can get the Course object via it CourseID. &nbsp;<br>
&nbsp; &nbsp; &nbsp;The URL can be:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://localhost/SchoolLinqToSQL.svc/Courses(CourseID).">http://localhost/SchoolLinqToSQL.svc/Courses(CourseID).</a><br>
&nbsp; &nbsp; &nbsp;<br>
E. Querying the database via ADO.NET query options and custom service <br>
&nbsp; operations.<br>
<br>
&nbsp; 1. Initialize the DataService object. &nbsp;Here we use the ADO.NET Data <br>
&nbsp; &nbsp; &nbsp;Service for ADO.NET Entity Data Model for testing.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 2. Perform the data source using query options (filter, orderby, skip, <br>
&nbsp; &nbsp; &nbsp;top) directly. &nbsp;The query URL can be:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://localhost/SchoolLinqToEntities.svc/Person?$">http://localhost/SchoolLinqToEntities.svc/Person?$</a><br>
&nbsp; &nbsp; &nbsp;filter=PersonCategory eq 1&$orderby=EnrollmentDate desc&$skip=2&$top=2.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. Initialize another DataService object and set the <br>
&nbsp; &nbsp; &nbsp;IgnoreMissingProperties property as true, so that the returned type
<br>
&nbsp; &nbsp; &nbsp;should be mapped to the client side type. &nbsp;Here we use the ADO.NET
<br>
&nbsp; &nbsp; &nbsp;Data Service for LINQ to SQL Classes for testing.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 4. Call the service operation SearchCourses and use local entity class <br>
&nbsp; &nbsp; &nbsp;LocalCourse to retrieve the returned course information. &nbsp;The query
<br>
&nbsp; &nbsp; &nbsp;URL can be:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://localhost/SchoolLinqToSQL.svc/SearchCourses?searchText=">http://localhost/SchoolLinqToSQL.svc/SearchCourses?searchText=</a><br>
&nbsp; &nbsp; &nbsp;’SELECT * FROM [Course] AS [c] WHERE [c].[Credits] = 4’.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
F. Updating and querying non-relational data via ADO.NET Data Service for <br>
&nbsp; non-relational data.<br>
<br>
&nbsp; 1. Initialize the DataService object for non-relational data.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 2. Insert a new entity object into the non-relational data collection.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. Query the non-relational data based on DataServiceKey value and <br>
&nbsp; &nbsp; &nbsp;object links and group the data.<br>
&nbsp; &nbsp; &nbsp;<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ADO.NET Data Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/data/bb931106.aspx">http://msdn.microsoft.com/en-us/data/bb931106.aspx</a><br>
<br>
Overview: ADO.NET Data Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc956153.aspx">http://msdn.microsoft.com/en-us/library/cc956153.aspx</a><br>
<br>
How Do I: Consume an ADO.NET Data Service in a .NET Application<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/data/cc974504.aspx">http://msdn.microsoft.com/en-us/data/cc974504.aspx</a><br>
<br>
Using Microsoft ADO.NET Data Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc907912.aspx">http://msdn.microsoft.com/en-us/library/cc907912.aspx</a><br>
<br>
ADO.NET Data Services Team Blog<br>
<a target="_blank" href="http://blogs.msdn.com/astoriateam/">http://blogs.msdn.com/astoriateam/</a><br>
<br>
MSDN API Reference Documentation – Client<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.data.services.client.aspx">http://msdn.microsoft.com/en-us/library/system.data.services.client.aspx</a><br>
<br>
Query Expressions (ADO.NET Data Services)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668784.aspx">http://msdn.microsoft.com/en-us/library/cc668784.aspx</a><br>
<br>
Query Functions (ADO.NET Data Services)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668793.aspx">http://msdn.microsoft.com/en-us/library/cc668793.aspx</a><br>
<br>
Filter Query Option: $filter (ADO.NET Data Services Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668778.aspx">http://msdn.microsoft.com/en-us/library/cc668778.aspx</a><br>
<br>
Order By Query Option: $orderby (ADO.NET Data Services Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668776.aspx">http://msdn.microsoft.com/en-us/library/cc668776.aspx</a><br>
<br>
Top Query Option: $top (ADO.NET Data Services Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc716654.aspx">http://msdn.microsoft.com/en-us/library/cc716654.aspx</a><br>
<br>
Skip Query Option: $skip (ADO.NET Data Services Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668773.aspx">http://msdn.microsoft.com/en-us/library/cc668773.aspx</a><br>
<br>
Addressing Resources (ADO.NET Data Services)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668766.aspx">http://msdn.microsoft.com/en-us/library/cc668766.aspx</a><br>
<br>
Service Operations (ADO.NET Data Services)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc668788.aspx">http://msdn.microsoft.com/en-us/library/cc668788.aspx</a><br>
<br>
Interceptors (ADO.NET Data Services)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd744842.aspx">http://msdn.microsoft.com/en-us/library/dd744842.aspx</a><br>
<br>
Injecting Custom Logic in ADO.NET Data Services <br>
<a target="_blank" href="http://weblogs.asp.net/cibrax/archive/2009/06/08/injecting-custom-logic-in-ado-net-data-services.aspx">http://weblogs.asp.net/cibrax/archive/2009/06/08/injecting-custom-logic-in-ado-net-data-services.aspx</a><br>
<br>
List of HTTP status codes<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/List_of_HTTP_status_codes">http://en.wikipedia.org/wiki/List_of_HTTP_status_codes</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
