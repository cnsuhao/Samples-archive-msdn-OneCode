# Dynamically build lambda exp
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Lambda Expression
## IsPublished
* True
## ModifiedDate
* 2013-01-22 08:14:34
## Description

<h1>How to dynamically build lambda expression and show data into DataGridView Control (CSDynamicallyBuildLambdaExpressionWithField)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to dynamically build lambda expression and show data into DataGridView Control.</p>
<p class="MsoNormal">This sample shows up multiple conditions jointing together and dynamically generate LINQ to SQL. LINQ is a great way to declaratively filter and query data in a Type_Safe, Intuitive, and very expressive way. This sample achieve it. For
 example, the search feature in this application allow the customer to find all records that meet criteria defined on multiple columns.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Download SQL2000SampleDb.msi according to access the website mentioned as follow:
<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034&displaylang=en">
http://www.microsoft.com/downloads/en/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034&amp;displaylang=en</a>
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Build this project in VS2012.</p>
<p class="MsoNormal">Step2. Download SQL2000SampleDb.msi according to access the website mentioned as follow:
<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034&displaylang=en">
http://www.microsoft.com/downloads/en/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034&amp;displaylang=en</a>
</p>
<p class="MsoNormal">Step3. Install it into your system catalog and startup your SQL Server Management Studio.
</p>
<p class="MsoNormal">Step4. Right click the tree node written as &quot;Databases&quot; and left click &quot;Attach...&quot;
</p>
<p class="MsoNormal">Step5. Make sure just Northwind.MDF and Northwind.LDF installed in the system catalog, which have complete access control privileges. Under the above condition, select the button written as &quot;Add...&quot; inside Attach Databases Dialog
 to attach Northwind database. </p>
<p class="MsoNormal">Step6. Select app.config inside the NorthwindApp project to modify connections string or double click Settings.settings under the NorthwindApp project and modify column written as &quot;value&quot;.
</p>
<p class="MsoNormal">Step7. Right click the NorthwindApp project and click the menuitem written as &quot;Set as Startup Project&quot;.
</p>
<p class="MsoNormal">Step8. Click F5 shortcut key and select condition field, condition operator and condition value.
</p>
<p class="MsoNormal">Step9. Click the button written as &quot;Search&quot; and view the result parsed by LINQ TO SQL.</p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. There are three main classes: Condition, Condition (Of T), and Condition (Of T, S)</p>
<p class="MsoNormal">a. Condition is an abstract class that is used to construct the generic versions. By structuring it this we get the benefits of generic type parameter inference-i.e. We don't have to worry about passing the generic type parameters to
 the method; the factory method figures it out for us.</p>
<p class="MsoNormal"><span style="">&nbsp;</span>b. Condition (Of T) is used to join multiple conditions together. T is the element type (i.e. Order in the example above).</p>
<p class="MsoNormal"><span style="">&nbsp;</span>c. Condition (Of T, S) is the simplest type; it represents an &quot;object.propery&lt;comparison&gt; value&quot; expression. The type parameter S will be inferred to be the type of the value passed in(i.e.
 String, Date, Boolean etc...).</p>
<p class="MsoNormal">Step2. For local execution of a query we compile the Lambda Expression to a delegate so that it can be executed in-memory. The user can invoke this delegate by calling the Matches method</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Compile the lambda expression into a delegate
del = (Func&lt;T, bool&gt;)(LambdaExpr.Compile());

</pre>
<pre id="codePreview" class="csharp">
// Compile the lambda expression into a delegate
del = (Func&lt;T, bool&gt;)(LambdaExpr.Compile());

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. The extension methods at the bottom are defined on IQueryable (Of T) for remote execution, and IEnumerable (Of T) for local execution.</p>
<h2>More Information</h2>
<p class="MsoNormal">Implementing Dynamic Searching Using LINQ <a href="http://blogs.msdn.com/b/vbteam/archive/2007/08/29/implementing-dynamic-searching-using-linq.aspx">
http://blogs.msdn.com/b/vbteam/archive/2007/08/29/implementing-dynamic-searching-using-linq.aspx</a>
</p>
<p class="MsoNormal">LINQ to SQL (Part 9 - Using a Custom LINQ Expression with the &lt;asp: LinqDatasource&gt; control)
<a href="http://weblogs.asp.net/scottgu/archive/2007/09/07/linq-to-sql-part-9-using-a-custom-linq-expression-with-the-lt-asp-linqdatasource-gt-control.aspx">
http://weblogs.asp.net/scottgu/archive/2007/09/07/linq-to-sql-part-9-using-a-custom-linq-expression-with-the-lt-asp-linqdatasource-gt-control.aspx</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
