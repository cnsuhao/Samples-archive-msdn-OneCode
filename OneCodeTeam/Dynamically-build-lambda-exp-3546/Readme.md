# Dynamically build lambda exp (VBDynamicallyBuildLambdaExpressionWithField)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Lambda Expression
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:25:27
## Description
======================================================================================<br>
&nbsp; &nbsp; &nbsp;Windows APPLICATION: VBDynamicallyBuildLambdaExpressionWithField Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
======================================================================================<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
&nbsp;This sample demonstrates how to dynamically build lambda expression and show data
<br>
&nbsp;into DataGridView Control.<br>
<br>
&nbsp;This sample shows up multiple conditions jointing together and dynamically <br>
&nbsp;generate &nbsp;LINQ TO SQL. LINQ is a great way to declaratively filter and query data
<br>
&nbsp;in a Type_Safe,Intuitive,and very expressive way.this sample achieve it. For example,<br>
&nbsp;the search feature in this application allow the customer to find all records that
<br>
&nbsp;meet criteria defined on multiple columns.<br>
<br>
&nbsp; <br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Build this project in Visual Studio 2010. <br>
<br>
Step2. Download SQL2000SampleDb.msi according to the website mentioned as follows:<br>
&nbsp; &nbsp; &nbsp; http://www.microsoft.com/downloads/en/details.aspx?FamilyID=06616212-0356-46a0-8da2-eebc53a68034&displaylang=en<br>
&nbsp; &nbsp; &nbsp;<br>
Step3. Install it into your system catalog and startup your SQL Server Management Studio.<br>
<br>
Step4. Right click the treenode written as &quot;Databases&quot; and left click &quot;Attach...&quot;.<br>
<br>
Step5. Make sure just Northwind.MDF and Northwind.LDF are installed in the system catalog,<br>
&nbsp; &nbsp; &nbsp; which has complete access control privileges.Under the above condition,<br>
&nbsp; &nbsp; &nbsp; Select the button written as &quot;Add...&quot; inside Attach Databases Dialog to attach
<br>
&nbsp; &nbsp; &nbsp; Northwind database. <br>
<br>
Step6. Select app.config inside the NorthwindApp project to modify the connections string
<br>
&nbsp; &nbsp; &nbsp; or double click Settings.settings under the NorthwindApp project and modify column<br>
&nbsp; &nbsp; &nbsp; written as &quot;value&quot;.<br>
<br>
Step7. Right click the NorthwindApp project and click the menuitem written as &quot;Set as Startup Project&quot;.<br>
<br>
Step8. Click F5 shortcut key and select condition field ,condition operator and condition value.<br>
<br>
Step9. Click the button written as &quot;Search&quot; and view the result parsed by LINQ TO SQL.<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
1. There are three main classes: Condition, Condition(Of T), and Condition(Of T,S)<br>
&nbsp; a. Condition is an abstract class that is used to construct the generic versions.<br>
&nbsp; By structuring it this we get the benefits of generic type parameter inference-i.e.<br>
&nbsp; we don't have to worry about passing the generic type parameters to the method;<br>
&nbsp; the factory method figures it out for us.<br>
&nbsp; b. Condition(Of T) is used to join multiple conditions together. T is the element<br>
&nbsp; type(i.e. Order in the example above).<br>
&nbsp; c. Condition(Of T,S) is the simplest type;it represents an &quot;object.propery&lt;comparison&gt; value&quot;<br>
&nbsp; expression. The type parameter S will be inferred to be the type of the value passed<br>
&nbsp; in(i.e. String,Date,Boolean etc...).<br>
2. For local execution of a query we compile the LambdaExpression to a delegate so that<br>
&nbsp; it can be executed in-memory. The user can invoke this delegate by calling the Matches
<br>
&nbsp; method.<br>
&nbsp; ' Compile the lambda expression into a delegate<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;del = CType(LambdaExpr.Compile(), Func(Of T, Boolean))<br>
3. The extension methods at the bottom are defined on IQueryable(Of T) for remote execution,<br>
&nbsp; and IEnumerable(Of T) for local execution.<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
Implementing Dynamic Searching Using LINQ <br>
http://blogs.msdn.com/b/vbteam/archive/2007/08/29/implementing-dynamic-searching-using-linq.aspx<br>
<br>
LINQ to SQL (Part 9 - Using a Custom LINQ Expression with the &lt;asp:LinqDatasource&gt; control)
<br>
http://weblogs.asp.net/scottgu/archive/2007/09/07/linq-to-sql-part-9-using-a-custom-linq-expression-with-the-lt-asp-linqdatasource-gt-control.aspx<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
