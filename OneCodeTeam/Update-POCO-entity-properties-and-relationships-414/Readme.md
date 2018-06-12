# Update POCO entity properties and relationships in EF4 (CSEFPOCOChangeTracking)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* POCO
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:19:47
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSEFPOCOChangeTracking Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The CSEFPOCOChangeTracking example illustrates how to update POCO entity<br>
properties and relationships with change tracking proxy and without change<br>
tracking proxy.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the sample.<br>
<br>
Step1. After you successfully build the CSEFPOCOChangeTracking sample project <br>
in Visual Studio 2008, you will get the applications: <br>
CSEFPOCOChangeTracking.exe.<br>
<br>
Step2. Attach the database file EFDemoDB.mdf under the folder <br>
_External_Dependencies to your SQL Server 2008 database instance.<br>
<br>
Step3. Modify the connection string in the App.config according to your <br>
SQL Server 2008 database instance name.<br>
<br>
Step4. Run the CSEFPOCOChangeTracking.exe, you will see the following outputs:<br>
<br>
&nbsp;Update properties with change tracking proxy...<br>
&nbsp;Entity State before modification: Unchanged<br>
&nbsp;Entity State after modification: Modified<br>
<br>
&nbsp;Update properties without change tracking proxy...<br>
&nbsp;Entity State before modification: Unchanged<br>
&nbsp;Entity State after modification: Unchanged<br>
&nbsp;Entity State after DetectChanges is called: Modified<br>
<br>
&nbsp;Update relationships with change tracking proxy...<br>
&nbsp;Is the newly created object a proxy? True<br>
&nbsp;1 object(s) added<br>
<br>
&nbsp;Update relationships without change tracking proxy...<br>
&nbsp;Is the newly created object a proxy? False<br>
&nbsp;Before DetectChanges is called, 0 object(s) added<br>
&nbsp;After DetectChanges is called, 1 object(s) added<br>
<br>
&nbsp;Press [Enter] to exit...<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1. Download ADO.NET C# POCO Entity Generator (see References) and install it <br>
&nbsp; in Visual Studio 2010. &nbsp;<br>
<br>
2. Create a new C# console project named CSEFPOCOChangeTraching.<br>
<br>
3. Add a new ADO.NET Entity Data Model item named POCOChangeTracking.edmx,<br>
&nbsp; Entity Container name is POCOChangeTrackingEntities and Namespace is<br>
&nbsp; POCOChangeTrackingModel. &nbsp;Select the database EFDemoDB, tables <br>
&nbsp; Department and Course.<br>
<br>
4. After the Entity Data Model is created, right click the designer and <br>
&nbsp; choose &quot;Add Code Generation Item...&quot;, then select &quot;ADO.NET POCO Entity<br>
&nbsp; Generator&quot;.<br>
<br>
5. Write sample codes to update POCO entity properties and relationships <br>
&nbsp; with change tracking proxy and without change tracking proxy.<br>
&nbsp; <br>
&nbsp; 1) By default, EF creates proxies for POCO entities, so we can directly<br>
&nbsp; &nbsp; &nbsp;update the entity properties and EF will know the modification via<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;POCO change tracking proxy.<br>
<br>
&nbsp; 2) If we do not use change tracking proxies, we need to turn off the <br>
&nbsp; &nbsp; &nbsp;proxy creation and call DetectChanges after all the modification has<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;been performed.<br>
<br>
&nbsp; 3) If the proxy creation is enabled, we need to use <br>
&nbsp; &nbsp; &nbsp;ObjectSet.CreateObject to manually create a proxy.<br>
<br>
&nbsp; 4) Turn off the proxy creation. &nbsp;We need to call DetectChanges after the<br>
&nbsp; &nbsp; &nbsp;relationships have been updated. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New">ADO.NET C# POCO Entity Generator<br>
<a target="_blank" href="http://visualstudiogallery.msdn.microsoft.com/en-us/23df0450-5677-4926-96cc-173d02752313">http://visualstudiogallery.msdn.microsoft.com/en-us/23df0450-5677-4926-96cc-173d02752313</a><br>
<br>
POCO Proxies Part1 (ADO.NET team blog)<br>
<a target="_blank" href="http://blogs.msdn.com/b/adonet/archive/2009/12/22/poco-proxies-part-1.aspx">http://blogs.msdn.com/b/adonet/archive/2009/12/22/poco-proxies-part-1.aspx</a><br>
<br>
POCO Proxies Part 2: Serializing POCO Proxies (ADO.NET team blog)<br>
<a target="_blank" href="http://blogs.msdn.com/b/adonet/archive/2010/01/05/poco-proxies-part-2-serializing-poco-proxies.aspx">http://blogs.msdn.com/b/adonet/archive/2010/01/05/poco-proxies-part-2-serializing-poco-proxies.aspx</a><br>
<br>
POCO in the Entity Framework: Part 3 – Change Tracking with POCO (ADO.NET team blog)<br>
<a target="_blank" href="http://blogs.msdn.com/b/adonet/archive/2009/06/10/poco-in-the-entity-framework-part-3-change-tracking-with-poco.aspx">http://blogs.msdn.com/b/adonet/archive/2009/06/10/poco-in-the-entity-framework-part-3-change-tracking-with-poco.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
