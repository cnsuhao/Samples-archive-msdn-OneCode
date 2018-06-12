# EF4 Lazy Loading feature demo (VBEFLazyLoading)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* Lazy Loading
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:53:29
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBEFLazyLoading Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The VBEFLazyLoading example illustrates how to work with the Lazy Loading<br>
which is new in Entity Framework 4.0. &nbsp;It also shows how to use the eager<br>
loading and explicit loading which is already implemented in the first<br>
version of Entity Framework. &nbsp; <br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Please attach the database file EFDemoDB.mdf under the folder <br>
_External_Dependencies to your SQL Server 2008 database instance.<br>
<br>
2. Please modify the connection string in the App.config according to your<br>
database instance name.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create an ADO.NET Entity Data Model <br>
&nbsp; 1) Name it LazyLoading.edmx.<br>
&nbsp; 2) Set the connection string information of the EFDemoDB database.<br>
&nbsp; 3) Select the data tables Department and Course.<br>
<br>
2. Create Sub LazyLoadingTest() to demostrate how to use lazy loading for <br>
&nbsp; related entities.<br>
<br>
3. Create Sub EagerLoadingTest() to demostrate how to use eager loading for <br>
&nbsp; related entities.<br>
&nbsp; ObjectContext.ContextOptions.LazyLoadingEnabled = false to turn off<br>
&nbsp; lazy loading in EF4.<br>
&nbsp; ObjectQuery&lt;T&gt;.Include() to specify the related objects to include in the
<br>
&nbsp; query results.<br>
<br>
4. Create Sub ExplicitLoadingTest() to demostrate how to use explicit loading<br>
&nbsp; for related entities.<br>
&nbsp; ObjectContext.ContextOptions.LazyLoadingEnabled = false to turn off<br>
&nbsp; lazy loading in EF4.<br>
&nbsp; EntityCollection&lt;TEntity&gt;.Load() to load related objects into the <br>
&nbsp; collection.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Loading Related Objects (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb896272.aspx">http://msdn.microsoft.com/en-us/library/bb896272.aspx</a><br>
<br>
How to: Use Lazy Loading to Load Related Objects (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd456846.aspx">http://msdn.microsoft.com/en-us/library/dd456846.aspx</a><br>
<br>
How to: Use Query Paths to Shape Results (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb738449.aspx">http://msdn.microsoft.com/en-us/library/bb738449.aspx</a><br>
<br>
How to: Explicitly Load Related Objects (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb896249.aspx">http://msdn.microsoft.com/en-us/library/bb896249.aspx</a><br>
<br>
Is Lazy Loading in EF 4 Evil or the Second Coming?<br>
<a target="_blank" href="http://www.robbagby.com/entity-framework/is-lazy-loading-in-ef-4-evil-or-the-second-coming/">http://www.robbagby.com/entity-framework/is-lazy-loading-in-ef-4-evil-or-the-second-coming/</a><br>
<br>
Getting Started with Entity Framework 4 – Lazy Loading<br>
<a target="_blank" href="http://geekswithblogs.net/iupdateable/archive/2009/11/26/getting-started-with-entity-framework-4-ndash-lazy-loading.aspx">http://geekswithblogs.net/iupdateable/archive/2009/11/26/getting-started-with-entity-framework-4-ndash-lazy-loading.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
