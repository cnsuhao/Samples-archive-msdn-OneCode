# How to use SqlDependency to get the notification in Entity Framework
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* Entity Framework
* .NET Development
## Topics
* Entity Frameowork
* Sqldependency
* automatically update
## IsPublished
* True
## ModifiedDate
* 2013-11-20 09:30:02
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to Automatically Update Data by Sqldependency in Entity Framework (CSEFAutoUpdate)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">We can use the Sqldependency to get the notification when the data is changed in database, but EF doesn't have the same feature. In this sample, we will demonstrate how to automatically update by Sqldependency in Entity Framework.</p>
<p class="MsoNormal">In this sample, we will demonstrate two ways that use SqlDependency to get the change notification to auto update data:</p>
<p class="MsoNormal">1. Get the notification of changes immediately.</p>
<p class="MsoNormal">2. Get the notification of changes regularly.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following step:</p>
<p class="MsoNormal">Step1. Modify the connection string in the App.config-&gt; &lt;configuration&gt;-&gt; &lt;connectionStrings&gt; to your SQL Server 2008 database instance.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span><img src="/site/view/file/101147/1/image.png" alt="" width="756" height="452" align="middle">
</span></p>
<p class="MsoNormal"><strong>1. Immediately Update </strong></p>
<p class="MsoNormal"><span>First, input the range of price to get the products, or you can directly click the
<strong><em>Get Data</em></strong> button to get all the products. </span></p>
<p class="MsoNormal"><span>&nbsp;</span><span> <img src="/site/view/file/101148/1/image.png" alt="" width="756" height="452" align="middle">
</span></p>
<p class="MsoNormal">Second, you can click the cell in DataGridView to select the product or just input the id in
<strong><em>Product Id</em></strong>, and then input the new price. After click the
<strong><em>Update</em></strong> button, the value in DataGridView will update.</p>
<p class="MsoNormal"><span><img src="/site/view/file/101149/1/image.png" alt="" width="756" height="452" align="middle">
</span></p>
<p class="MsoNormal">At finally, you can click <strong><em>Stop</em></strong> button to stop the Update.</p>
<p class="MsoNormal"><strong>2. Regularly Update </strong></p>
<p class="MsoNormal">First, input the range of price to get the products and input the seconds to set the period of update.</p>
<p class="MsoNormal"><span><img src="/site/view/file/101150/1/image.png" alt="" width="756" height="452" align="middle">
</span></p>
<p class="MsoNormal">Then you can input the new price and update. The value will be updated at the end of the period.</p>
<p class="MsoNormal"><span><img src="/site/view/file/101151/1/image.png" alt="" width="756" height="452" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. <strong>Get the ObjectQuery</strong></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We need the connection string, command string and parameters to create the SqlDependency, so we need to get the ObjectQuery. If we use DbQuery to query, we first convert the DbQuery to ObjectQuery.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static ObjectQuery GetObjectQuery&lt;TEntity&gt;(DbContext context, IQueryable query)
&nbsp;&nbsp;&nbsp; where TEntity : class
{
&nbsp;&nbsp;&nbsp; if (query is ObjectQuery)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return query as ObjectQuery;


&nbsp;&nbsp;&nbsp; if (context == null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;Paramter cannot be null&quot;, &quot;context&quot;);


&nbsp;&nbsp;&nbsp; // Use the DbContext to create the ObjectContext
&nbsp;&nbsp;&nbsp; ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
&nbsp;&nbsp;&nbsp; // Use the DbSet to create the ObjectSet and get the appropriate provider.
&nbsp;&nbsp;&nbsp; IQueryable iqueryable = objectContext.CreateObjectSet&lt;TEntity&gt;() as IQueryable;
&nbsp;&nbsp;&nbsp; IQueryProvider provider = iqueryable.Provider;


&nbsp;&nbsp;&nbsp; // Use the provider and expression to create the ObjectQuery.
&nbsp;&nbsp;&nbsp; return provider.CreateQuery(query.Expression) as ObjectQuery;
}

</pre>
<pre id="codePreview" class="csharp">public static ObjectQuery GetObjectQuery&lt;TEntity&gt;(DbContext context, IQueryable query)
&nbsp;&nbsp;&nbsp; where TEntity : class
{
&nbsp;&nbsp;&nbsp; if (query is ObjectQuery)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return query as ObjectQuery;


&nbsp;&nbsp;&nbsp; if (context == null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;Paramter cannot be null&quot;, &quot;context&quot;);


&nbsp;&nbsp;&nbsp; // Use the DbContext to create the ObjectContext
&nbsp;&nbsp;&nbsp; ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
&nbsp;&nbsp;&nbsp; // Use the DbSet to create the ObjectSet and get the appropriate provider.
&nbsp;&nbsp;&nbsp; IQueryable iqueryable = objectContext.CreateObjectSet&lt;TEntity&gt;() as IQueryable;
&nbsp;&nbsp;&nbsp; IQueryProvider provider = iqueryable.Provider;


&nbsp;&nbsp;&nbsp; // Use the provider and expression to create the ObjectQuery.
&nbsp;&nbsp;&nbsp; return provider.CreateQuery(query.Expression) as ObjectQuery;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. <strong>Immediately Update</strong></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Before start the SqlDependency, stop all the SqlDependency.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void BeginSqlDependency()
{
&nbsp;&nbsp;&nbsp; SqlDependency.Stop(QueryExtension.GetConnectionString(oquery));
&nbsp;&nbsp;&nbsp; SqlDependency.Start(QueryExtension.GetConnectionString(oquery));


&nbsp;&nbsp;&nbsp; RegisterSqlDependency();
}

</pre>
<pre id="codePreview" class="csharp">private void BeginSqlDependency()
{
&nbsp;&nbsp;&nbsp; SqlDependency.Stop(QueryExtension.GetConnectionString(oquery));
&nbsp;&nbsp;&nbsp; SqlDependency.Start(QueryExtension.GetConnectionString(oquery));


&nbsp;&nbsp;&nbsp; RegisterSqlDependency();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Then register the SqlDependency.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void RegisterSqlDependency()
{
&nbsp;&nbsp;&nbsp; if (command == null || connection == null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;command and connection cannot be null&quot;);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // Make sure the command object does not already have
&nbsp;&nbsp;&nbsp; // a notification object associated with it.
&nbsp;&nbsp;&nbsp; command.Notification = null;


&nbsp;&nbsp;&nbsp; // Create and bind the SqlDependency object to the command object.
&nbsp;&nbsp;&nbsp; dependency = new SqlDependency(command);
&nbsp;&nbsp;&nbsp; dependency.OnChange &#43;= new OnChangeEventHandler(DependencyOnChange);


&nbsp;&nbsp;&nbsp; // After register SqlDependency, the SqlCommand must be executed, or we can't 
&nbsp;&nbsp;&nbsp;&nbsp;// get the notification.
&nbsp;&nbsp;&nbsp; RegisterSqlCommand();
}

</pre>
<pre id="codePreview" class="csharp">private void RegisterSqlDependency()
{
&nbsp;&nbsp;&nbsp; if (command == null || connection == null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;command and connection cannot be null&quot;);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // Make sure the command object does not already have
&nbsp;&nbsp;&nbsp; // a notification object associated with it.
&nbsp;&nbsp;&nbsp; command.Notification = null;


&nbsp;&nbsp;&nbsp; // Create and bind the SqlDependency object to the command object.
&nbsp;&nbsp;&nbsp; dependency = new SqlDependency(command);
&nbsp;&nbsp;&nbsp; dependency.OnChange &#43;= new OnChangeEventHandler(DependencyOnChange);


&nbsp;&nbsp;&nbsp; // After register SqlDependency, the SqlCommand must be executed, or we can't 
&nbsp;&nbsp;&nbsp;&nbsp;// get the notification.
&nbsp;&nbsp;&nbsp; RegisterSqlCommand();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
When data was changed, the even handler will be fired.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void DependencyOnChange(object sender, SqlNotificationEventArgs e)
{
&nbsp;&nbsp;&nbsp; // Move the original SqlDependency event handler.
&nbsp;&nbsp;&nbsp; SqlDependency dependency =(SqlDependency)sender;
&nbsp;&nbsp;&nbsp; dependency.OnChange -= DependencyOnChange;


&nbsp;&nbsp;&nbsp; if (OnChanged != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnChanged(this,null);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // We re-register the SqlDependency.
&nbsp;&nbsp;&nbsp; RegisterSqlDependency();
}

</pre>
<pre id="codePreview" class="csharp">private void DependencyOnChange(object sender, SqlNotificationEventArgs e)
{
&nbsp;&nbsp;&nbsp; // Move the original SqlDependency event handler.
&nbsp;&nbsp;&nbsp; SqlDependency dependency =(SqlDependency)sender;
&nbsp;&nbsp;&nbsp; dependency.OnChange -= DependencyOnChange;


&nbsp;&nbsp;&nbsp; if (OnChanged != null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnChanged(this,null);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // We re-register the SqlDependency.
&nbsp;&nbsp;&nbsp; RegisterSqlDependency();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. <strong>Regularly Update </strong></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
When register the SqlDependency, we create a Threading.Timer and set the delegate, state,delay time, period, and then run it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void RegisterSqlDependency()
{
&nbsp;&nbsp;&nbsp; if (connection == null || command == null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;command and connection cannot be null&quot;);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // Make sure the command object does not already have
&nbsp;&nbsp;&nbsp; // a notification object associated with it.
&nbsp;&nbsp;&nbsp; command.Notification = null;


&nbsp;&nbsp;&nbsp; // Create and bind the SqlDependency object
&nbsp;&nbsp;&nbsp; // to the command object.
&nbsp;&nbsp;&nbsp; dependency = new SqlDependency(command);
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Id of sqldependency:{0}&quot;, dependency.Id);


&nbsp;&nbsp;&nbsp; RegisterSqlCommand();


&nbsp;&nbsp;&nbsp; timer = new Timer(CheckChange, null, 0, interval);
&nbsp;&nbsp;&nbsp; timer.Change(0, interval);
}

</pre>
<pre id="codePreview" class="csharp">private void RegisterSqlDependency()
{
&nbsp;&nbsp;&nbsp; if (connection == null || command == null)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new ArgumentException(&quot;command and connection cannot be null&quot;);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; // Make sure the command object does not already have
&nbsp;&nbsp;&nbsp; // a notification object associated with it.
&nbsp;&nbsp;&nbsp; command.Notification = null;


&nbsp;&nbsp;&nbsp; // Create and bind the SqlDependency object
&nbsp;&nbsp;&nbsp; // to the command object.
&nbsp;&nbsp;&nbsp; dependency = new SqlDependency(command);
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Id of sqldependency:{0}&quot;, dependency.Id);


&nbsp;&nbsp;&nbsp; RegisterSqlCommand();


&nbsp;&nbsp;&nbsp; timer = new Timer(CheckChange, null, 0, interval);
&nbsp;&nbsp;&nbsp; timer.Change(0, interval);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Then at the end of period, the delegate will be fired.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void CheckChange(object state)
{
&nbsp;&nbsp;&nbsp; if (dependency!=null&amp;&amp;dependency.HasChanges)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (OnChanged != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnChanged(this, null);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">private void CheckChange(object state)
{
&nbsp;&nbsp;&nbsp; if (dependency!=null&amp;&amp;dependency.HasChanges)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (OnChanged != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnChanged(this, null);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(System.Data.SqlClient.SqlDependency);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true">SqlDependency
 Class</a> </span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/a52dhwx7.aspx">Using SqlDependency in a Windows Application</a>
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/System.Threading.Timer.aspx">Timer Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
