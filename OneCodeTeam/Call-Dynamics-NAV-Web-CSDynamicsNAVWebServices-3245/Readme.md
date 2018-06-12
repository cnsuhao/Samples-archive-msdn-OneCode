# Call Dynamics NAV Web Services (CSDynamicsNAVWebServices)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Dynamics
## Topics
* NAV
* Dynamics NAV Web Services
## IsPublished
* True
## ModifiedDate
* 2011-05-26 02:06:59
## Description

<p style="font-family:Courier New"></p>
<h2>Microsoft Dynamics NAV APPLICATION: CSDynamicNAVWebServices </h2>
<p style="font-family:Courier New"><br>
</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This sample contains code for using Web Services with Microsoft Dynamics NAV. <br>
It contains sample code for the following scenarios:<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Invoking a NAV Codeunit<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Creating an instance of a NAV Page<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Read a full list of records<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Read a filtere list of records<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Read a single record<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Insert a new record<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Insert multiple new records<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Modify a record<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Modify multiple records<br>
•&nbsp;&nbsp;&nbsp;&nbsp;Delete a record<br>
This sample is intended for casual NAV web service developers. The intention is to
<br>
have sample code in one place to copy and paste. When you can’t remember the exact<br>
syntax for initializing a web service, how to update a record or set a filter etc,<br>
having a bit of code to copy and paste is sometimes all it needs to get started.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The solution included in this sample shows the functions that are available by <br>
publishing a NAV page or codeunit as a web service. The solution is developed <br>
with c# in Visual Studio 2010.<br>
To run the project, you must first publish a page or a codeunit from NAV from <br>
Form 810 “Web Services”. The solution applies default web service connections in<br>
the InitializeComponent() – function:<br>
<br>
InitializeComponent();<br>
CodeunitURL.Text = &quot;<a target="_blank" href="http://lohndorf02:7047/DynamicsNAV/WS/">http://lohndorf02:7047/DynamicsNAV/WS/</a> ... etc &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
PageURL.Text = &quot;<a target="_blank" href="http://lohndorf02:7047/DynamicsNAV/WS/">http://lohndorf02:7047/DynamicsNAV/WS/</a>... etc<br>
<br>
You must change this to match the web services that you have published on your own system.
<br>
When you run the solution you will have two buttons – one for the codeunit web<br>
service sample, and one for the page web service sample. These two samples run <br>
independently of each other, but before activating a sample, check that the URL for<br>
that sample points to a valid NAV web service.<br>
The codeunit web service sample only just initializes connection to a codeunit that<br>
has been published as a web service, it doesn’t actually run anything since available<br>
functions here will depend on the codeunit that was published.<br>
To run the Page web service sample, you must also specify which type of sample to run<br>
(e.g. Full List, Filtered List, etc.). Important: For this to work you must publish a
<br>
page of type Card, for example Page 21 “Customer Card”. Only card pages have functions<br>
for updating a record. These functions are not published with a list page. <br>
So if you publish a list page, then when trying to run any of the update functions
<br>
would result in an error like “Method &quot;CreateMultiple” is invalid!”.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Below is a short description of what each of the functions in this sample does:<br>
<br>
Initialize<br>
Just sets up a connection to a web service<br>
<br>
Full List<br>
Reads all records in the customer table<br>
<br>
Filtered List (simple)<br>
Filters customers on Name containing “S”.<br>
<br>
Filtered List (Advanced)<br>
This also returns a filtered list. It uses a function called AddFilter to do so. <br>
This function can be found near the end of the solution. While this way of filtering
<br>
requires a bit more code to begin with, the advantage is that after having this in place,
<br>
additional filters can be added in just one line, where with the “Filtered List (Simple)”<br>
-example uses four lines of code for applying each filter.<br>
<br>
Read<br>
Reads Customer No. 10000<br>
<br>
Create<br>
Inserts a record in the Customer table. Note that just like any other ways of inserting
<br>
a record in a NAV database, the primary key value must be assigned. This example sets<br>
Customer.”No.” = ‘ABC’. Removing this line (blanking out Customer.”No.”) would make it
<br>
use the business logic (OnInsert trigger) instead to assign a number from the number series.<br>
<br>
CreateMultiple<br>
An example of inserting two records with one call. The two new records are set in an array
<br>
first, and then together they are sent for insert. This example specifically sets Customer.”No.”<br>
= null, in which case the OnInsert trigger takes care of assigning a number.<br>
<br>
Update<br>
Updates customer with No. ABC (assuming that this customer exists).<br>
<br>
UpdateMultiple<br>
This example first makes a filtered list, and then updates all records in this list.
<br>
<br>
Delete<br>
Deletes customer ABC<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New">Further information and samples for coding with NAV and web services:<br>
<br>
Microsoft Dynamics NAV Web Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd355398.aspx">http://msdn.microsoft.com/en-us/library/dd355398.aspx</a><br>
<br>
Freddy’s blog<br>
<a target="_blank" href="http://blogs.msdn.com/b/freddyk/">http://blogs.msdn.com/b/freddyk/</a><br>
<br>
NAV Team Blog<br>
<a target="_blank" href="http://blogs.msdn.com/b/nav/archive/tags/web&#43;services/">http://blogs.msdn.com/b/nav/archive/tags/web&#43;services/</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
