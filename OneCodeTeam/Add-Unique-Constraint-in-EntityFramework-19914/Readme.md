# Add Unique Constraint in EntityFramework (VBASPNETUniqueConstraintInEF4)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* ASP.NET
## IsPublished
* True
## ModifiedDate
* 2012-12-10 10:58:39
## Description

<h1>How to add Unique Constraint in EntityFramework (VBASPNETUniqueConstraintInEF4)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This project demonstrates how to add unique constraint in Entity Framework 4.3. Many customers need a Unique Attribute in EntityFramework4.3, but until now, there is no any published DLL or tool in Code-First of Entity Framework to serve
 this purpose.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">To install EntityFramework, run the following command in the
<b style="">Package Manager Console</b> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">powershell</span>
<pre class="hidden">
PM&gt; Install-Package EntityFramework -Version 4.3.1

</pre>
<pre id="codePreview" class="powershell">
PM&gt; Install-Package EntityFramework -Version 4.3.1

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b>Open the VBASPNETUniqueConstraintInEF4.sln file.</p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b>Open the Program class to modify the Main method. Add two items to the &quot;Categories&quot; as below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 1, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .IdentifyCode = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;.Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })

</pre>
<pre id="codePreview" class="vb">
g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 1, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .IdentifyCode = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;.Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><span style="">After that</span><span style="">, you can</span><span style=""> press &quot;Ctrl&#43;F5&quot; to run</span><span style=""> the sample</span><span style="">.<br>
</span><span style=""><img src="/site/view/file/72356/1/image.png" alt="" width="576" height="293" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b>Remove the value of IdentifyCode and then run the Program again. You will encounter an error.</p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b>The validation is complete.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a Visual Basic &quot;Console Application&quot; in Visual Studio 2010 and name it as &quot;VBASPNETUniqueConstraintInEF4.&quot;</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add the assembly reference follow the steps below.<br>
<span style="">&nbsp;</span><span style="color:black">Project-&gt; References -&gt;…</span></span>
<span style="color:black">EntityFramework</span><span style="">.dll</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a custom attribute which is inherited from System.Attribute. It is used to specify a unique constraint to the corresponding field.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'''&lt;summary&gt;
'''A unique attribute
'''&lt;/summary&gt;
&lt;AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)&gt; _
Public Class UniqueKeyAttribute
&nbsp;&nbsp;&nbsp; Inherits Attribute
End Class

</pre>
<pre id="codePreview" class="vb">
'''&lt;summary&gt;
'''A unique attribute
'''&lt;/summary&gt;
&lt;AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)&gt; _
Public Class UniqueKeyAttribute
&nbsp;&nbsp;&nbsp; Inherits Attribute
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a Database Generator by implementing the IDatabaseInitializer interface. In the class we will try to analyze the Model Entity by reflecting them one by one and fetch the properties with &quot;unique&quot; attribute and then call
 SQL statement to create database.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
'''&nbsp; Try to analyze the ModelEntity by reflecting them one by one and then
'''&nbsp; fetch the properties with &quot;unique&quot; attribute and then do calling Sql statement to create database.
''' &lt;/summary&gt;
''' &lt;typeparam name=&quot;T&quot;&gt;&lt;/typeparam&gt;
Public Class MyDbGenerator(Of T As DbContext)
&nbsp;&nbsp;&nbsp; Implements IDatabaseInitializer(Of T)
&nbsp;&nbsp;&nbsp; Sub InitializeDatabase(context As T) Implements System.Data.Entity.IDatabaseInitializer(Of T).InitializeDatabase
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Database.Delete()
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;context.Database.Create()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Fetch all the father class's public properties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fatherPropertyNames = GetType(DbContext).GetProperties().[Select](Function(pi) pi.Name).ToList()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Loop each dbset's T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each item As PropertyInfo In GetType(T).GetProperties().Where(Function(p) fatherPropertyNames.IndexOf(p.Name) &lt; 0).[Select](Function(p) p)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'fetch the type of &quot;T&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim entityModelType As Type = item.PropertyType.GetGenericArguments()(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim allfieldNames = From prop In entityModelType.GetProperties() Where prop.GetCustomAttributes(GetType(UniqueKeyAttribute), True).Count() &gt; 0 Select prop.Name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each s As String In allfieldNames
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Database.ExecuteSqlCommand(&quot;alter table &quot; & entityModelType.Name & &quot; add unique(&quot; & s & &quot;)&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End Sub
End Class



</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
'''&nbsp; Try to analyze the ModelEntity by reflecting them one by one and then
'''&nbsp; fetch the properties with &quot;unique&quot; attribute and then do calling Sql statement to create database.
''' &lt;/summary&gt;
''' &lt;typeparam name=&quot;T&quot;&gt;&lt;/typeparam&gt;
Public Class MyDbGenerator(Of T As DbContext)
&nbsp;&nbsp;&nbsp; Implements IDatabaseInitializer(Of T)
&nbsp;&nbsp;&nbsp; Sub InitializeDatabase(context As T) Implements System.Data.Entity.IDatabaseInitializer(Of T).InitializeDatabase
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Database.Delete()
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;context.Database.Create()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Fetch all the father class's public properties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fatherPropertyNames = GetType(DbContext).GetProperties().[Select](Function(pi) pi.Name).ToList()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Loop each dbset's T
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each item As PropertyInfo In GetType(T).GetProperties().Where(Function(p) fatherPropertyNames.IndexOf(p.Name) &lt; 0).[Select](Function(p) p)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'fetch the type of &quot;T&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim entityModelType As Type = item.PropertyType.GetGenericArguments()(0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim allfieldNames = From prop In entityModelType.GetProperties() Where prop.GetCustomAttributes(GetType(UniqueKeyAttribute), True).Count() &gt; 0 Select prop.Name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each s As String In allfieldNames
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Database.ExecuteSqlCommand(&quot;alter table &quot; & entityModelType.Name & &quot; add unique(&quot; & s & &quot;)&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp; End Sub
End Class



</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a model entity. Add the custom attribute to the IdentifyCode field.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Category Class
''' &lt;/summary&gt;
Public Class Category
&nbsp;&nbsp;&nbsp; &lt;Key()&gt; _
&nbsp;&nbsp;&nbsp; Public Property Id() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Id = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Id As Integer
&nbsp;&nbsp;&nbsp; ' Unique Key
&nbsp;&nbsp;&nbsp; &lt;UniqueKey()&gt; _
&nbsp;&nbsp;&nbsp; Public Property IdentifyCode() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_IdentifyCode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_IdentifyCode = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_IdentifyCode As Integer
&nbsp;&nbsp;&nbsp; Public Property Name() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Name = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Name As String
End Class

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Category Class
''' &lt;/summary&gt;
Public Class Category
&nbsp;&nbsp;&nbsp; &lt;Key()&gt; _
&nbsp;&nbsp;&nbsp; Public Property Id() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Id = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Id As Integer
&nbsp;&nbsp;&nbsp; ' Unique Key
&nbsp;&nbsp;&nbsp; &lt;UniqueKey()&gt; _
&nbsp;&nbsp;&nbsp; Public Property IdentifyCode() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_IdentifyCode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_IdentifyCode = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_IdentifyCode As Integer
&nbsp;&nbsp;&nbsp; Public Property Name() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Name = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Name As String
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">Step 6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a class inherited from DbContext.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class DbG
&nbsp;&nbsp;&nbsp; Inherits DbContext
&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' This method is called when the model for a derived context has been initialized, but 
&nbsp;&nbsp;&nbsp;&nbsp;''' before the model has been locked down and used to initialize the context. 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;modelBuilder&quot;&gt;It is used to map CLR classes to a database schema. &lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '&nbsp; Disable the default PluralizingTableNameConvention
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Public Property Categories() As DbSet(Of Category)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Categories
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As DbSet(Of Category))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Categories = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Categories As DbSet(Of Category)
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class DbG
&nbsp;&nbsp;&nbsp; Inherits DbContext
&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' This method is called when the model for a derived context has been initialized, but 
&nbsp;&nbsp;&nbsp;&nbsp;''' before the model has been locked down and used to initialize the context. 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;modelBuilder&quot;&gt;It is used to map CLR classes to a database schema. &lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '&nbsp; Disable the default PluralizingTableNameConvention
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Public Property Categories() As DbSet(Of Category)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_Categories
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As DbSet(Of Category))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_Categories = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_Categories As DbSet(Of Category)
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">Step 7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create Database instance and DbContext instance and then add some model instance to DbSet. Save the changes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Gets or sets the database initialization strategy.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Database.SetInitializer(Of DbG)(New MyDbGenerator(Of DbG)())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using g As New DbG()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;.Id = 1, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .IdentifyCode = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' saves all changes
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.SaveChanges()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;OK&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Gets or sets the database initialization strategy.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Database.SetInitializer(Of DbG)(New MyDbGenerator(Of DbG)())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using g As New DbG()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;.Id = 1, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.Categories.Add(New Category() With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Id = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .IdentifyCode = 2, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Name = &quot;Category&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' saves all changes
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g.SaveChanges()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;OK&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""><span style="">Step 8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build and debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">Attribute Class<br>
<a href="http://msdn.microsoft.com/en-us/library/System.Attribute(v=vs.100).aspx">http://msdn.microsoft.com/en-us/library/System.Attribute(v=vs.100).aspx</a><br>
DbContext Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx">http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext(v=VS.103).aspx</a><br>
IDatabaseInitializer&lt;TContext&gt; Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/gg696323(v=VS.100).aspx">http://msdn.microsoft.com/en-us/library/gg696323(v=VS.100).aspx</a><br>
PropertyInfo Class<br>
<a href="http://msdn.microsoft.com/en-us/library/System.Reflection.PropertyInfo.aspx">http://msdn.microsoft.com/en-us/library/System.Reflection.PropertyInfo.aspx</a><br>
Database.ExecuteSqlCommand Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.entity.database.executesqlcommand%28v=VS.103%29.aspx">http://msdn.microsoft.com/en-us/library/system.data.entity.database.executesqlcommand%28v=VS.103%29.aspx</a><br>
DbContext.OnModelCreating Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext.onmodelcreating(v=vs.103).aspx">http://msdn.microsoft.com/en-us/library/system.data.entity.dbcontext.onmodelcreating(v=vs.103).aspx</a><br>
Database.SetInitializer&lt;TContext&gt; Method<br>
<a href="http://msdn.microsoft.com/en-us/library/gg679461(v=VS.103).aspx">http://msdn.microsoft.com/en-us/library/gg679461(v=VS.103).aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
