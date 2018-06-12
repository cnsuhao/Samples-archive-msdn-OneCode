# How to implement the Between operator in the EF
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
## Topics
* Entity Framework
* Between
* Expression Tree
## IsPublished
* True
## ModifiedDate
* 2013-03-22 05:28:50
## Description

<h1>Implement the Between Operator in Entity Framework (VBEFBetweenOperator)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to implement the <span class="GramE">
Between</span> operator in Entity Framework.</p>
<p class="MsoNormal">In this sample, we use two ways to implement the Entity Framework Between
<span class="GramE">operator</span>:</p>
<p class="MsoNormal">1. Use the Entity SQL;</p>
<p class="MsoNormal">2. Use the extension method and expression tree.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following steps:</p>
<p class="MsoNormal">Step1. Attach the database file MySchool.mdf under the folder _External_Dependecies to your SQL Server 2008 database instance.</p>
<p class="MsoNormal">Step2. Modify the connection string in the App.config file according to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/78785/1/image.png" alt="" width="562" height="325" align="middle">
</span></p>
<p class="MsoNormal">First, we get the courses by Entity SQL. In the Entity SQL statement, we select the courses on the Department column which the value is between 1 and 5.
</p>
<p class="MsoNormal">Then we get the courses by extension method. In this statement, we select the courses on the CourseID column which the value is between C1050 and C3141.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the Courses by Entity SQL.</p>
<p class="MsoNormal">We select the courses on the Department column by Entity SQL.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Return school.Courses.Where(&quot;it.DepartmentID between @lowerbound And @highbound&quot;, New ObjectParameter(&quot;lowerbound&quot;, 1), New ObjectParameter(&quot;highbound&quot;, 5)).ToList()

</pre>
<pre id="codePreview" class="vb">
Return school.Courses.Where(&quot;it.DepartmentID between @lowerbound And @highbound&quot;, New ObjectParameter(&quot;lowerbound&quot;, 1), New ObjectParameter(&quot;highbound&quot;, 5)).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Get the Courses by Extension Method.<span style="font-size:9.5pt; font-family:Consolas; color:green">
</span></p>
<p class="MsoNormal">We select the courses on the CourseID column by the Bwtween extension method. In this method, we need pass three parameters: lambda expression, low boundary of the value, high boundary of the value.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Return school.Courses.Between(Function(c) c.CourseID, &quot;C1050&quot;, &quot;C3141&quot;).ToList()

</pre>
<pre id="codePreview" class="vb">
Return school.Courses.Between(Function(c) c.CourseID, &quot;C1050&quot;, &quot;C3141&quot;).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
In the extension method, we use two expressions to implement the Between operation, and so we need to use the
<span style="color:black">Expression.LessThanOrEqual and Expression.GreaterThanOrEqual methods to return the two expressions.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Expression.LessThanOrEqual and Expression.GreaterThanOrEqua method are only used inthe numeric comparision. If we want to compare the non-numeric type, we can't directly use the two methods.
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
So we first use the Compare method to compare the objects, and the Compare method will return an int number. Then we can use the LessThanOrEqual and GreaterThanOrEqua method.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
For this reason, we ask all the TKey types implement the IComparable&lt;&gt; interface.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function Between(Of TSource, TKey As IComparable(Of TKey))(ByVal source As IQueryable(Of TSource), ByVal keySelector As Expression(Of Func(Of TSource, TKey)), ByVal low As TKey, ByVal high As TKey) As IQueryable(Of TSource)


&nbsp;&nbsp;&nbsp; Dim sourceParameter As ParameterExpression = Expression.Parameter(GetType(TSource))


&nbsp;&nbsp;&nbsp; Dim body As Expression = keySelector.Body
 &nbsp;&nbsp;&nbsp;Dim parameter As ParameterExpression = Nothing
&nbsp;&nbsp;&nbsp; If keySelector.Parameters.Count &gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parameter = keySelector.Parameters(0)
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim compareMethod As MethodInfo = GetType(TKey).GetMethod(&quot;CompareTo&quot;, {GetType(TKey)})


&nbsp;&nbsp;&nbsp; Dim upper As Expression = Expression.LessThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(high)), Expression.Constant(0, GetType(Integer)))
&nbsp;&nbsp;&nbsp; Dim lower As Expression = Expression.GreaterThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(low)), Expression.Constant(0, GetType(Integer)))


&nbsp;&nbsp;&nbsp; Dim andExpression As Expression = Expression.And(upper, lower)


&nbsp;&nbsp;&nbsp; Dim whereCallExpression As MethodCallExpression = Expression.Call(GetType(Queryable), &quot;Where&quot;, New Type() {source.ElementType}, source.Expression, Expression.Lambda(Of Func(Of TSource, Boolean))(andExpression, New ParameterExpression() {parameter}))


&nbsp;&nbsp;&nbsp; Return source.Provider.CreateQuery(Of TSource)(whereCallExpression)
End Function

</pre>
<pre id="codePreview" class="vb">
Public Function Between(Of TSource, TKey As IComparable(Of TKey))(ByVal source As IQueryable(Of TSource), ByVal keySelector As Expression(Of Func(Of TSource, TKey)), ByVal low As TKey, ByVal high As TKey) As IQueryable(Of TSource)


&nbsp;&nbsp;&nbsp; Dim sourceParameter As ParameterExpression = Expression.Parameter(GetType(TSource))


&nbsp;&nbsp;&nbsp; Dim body As Expression = keySelector.Body
 &nbsp;&nbsp;&nbsp;Dim parameter As ParameterExpression = Nothing
&nbsp;&nbsp;&nbsp; If keySelector.Parameters.Count &gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; parameter = keySelector.Parameters(0)
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim compareMethod As MethodInfo = GetType(TKey).GetMethod(&quot;CompareTo&quot;, {GetType(TKey)})


&nbsp;&nbsp;&nbsp; Dim upper As Expression = Expression.LessThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(high)), Expression.Constant(0, GetType(Integer)))
&nbsp;&nbsp;&nbsp; Dim lower As Expression = Expression.GreaterThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(low)), Expression.Constant(0, GetType(Integer)))


&nbsp;&nbsp;&nbsp; Dim andExpression As Expression = Expression.And(upper, lower)


&nbsp;&nbsp;&nbsp; Dim whereCallExpression As MethodCallExpression = Expression.Call(GetType(Queryable), &quot;Where&quot;, New Type() {source.ElementType}, source.Expression, Expression.Lambda(Of Func(Of TSource, Boolean))(andExpression, New ParameterExpression() {parameter}))


&nbsp;&nbsp;&nbsp; Return source.Provider.CreateQuery(Of TSource)(whereCallExpression)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb506649(v=vs.100).aspx">System.Linq.Expressions Namespace</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/4d7sx9hd(v=vs.100).aspx">IComparable&lt;T&gt; Interface</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
