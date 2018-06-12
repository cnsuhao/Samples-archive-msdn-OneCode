# LINQ to Objects demoed in VB (VBLinqToObject)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* LINQ
* LINQ to Objects
## IsPublished
* True
## ModifiedDate
* 2012-08-22 03:46:02
## Description

<h1><span style="font-family:新宋体">CONSOLE APPLICATION</span> (<span style="font-family:新宋体">VBLinqToObject</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The term &quot;LINQ to Objects&quot; refers to the use of LINQ queries with any
<span class="SpellE">IEnumerable</span> or <span class="SpellE">IEnumerable</span>&lt;T&gt; collection directly, without the use of an intermediate LINQ provider or API such as LINQ to SQL or LINQ to XML. You can use LINQ to query any enumerable collections
 such as List&lt;T&gt;, Array, or Dictionary&lt;<span class="SpellE">TKey</span>,
<span class="SpellE">TValue</span>&gt;. The collection may be user-defined or may be returned by a .NET Framework API.
</span></p>
<p class="MsoNormal"><span style="">In a basic sense, LINQ to Objects represents a new approach to collections. In the old way, you had to write complex
<span class="SpellE">foreach</span> loops that specified how to retrieve data from a collection. In the LINQ approach, you write declarative code that describes what you want to retrieve.
</span></p>
<p class="MsoNormal"><span style="">In addition, LINQ queries offer three main advantages over traditional
<span class="SpellE">foreach</span> loops: </span></p>
<p class="MsoNormal"><span class="GramE"><span style="">1.They</span></span><span style=""> are more concise and readable, especially when filtering multiple conditions.
</span></p>
<p class="MsoNormal"><span class="GramE"><span style="">2.They</span></span><span style=""> provide powerful filtering, ordering, and grouping capabilities with a minimum of application code.
</span></p>
<p class="MsoNormal"><span class="GramE"><span style="">3.They</span></span><span style=""> can be ported to other data sources with little or no modification.
</span></p>
<p class="MsoNormal"><span style="">In general, the more complex the <span class="GramE">
operation</span> you want to perform on the data, the more benefit you will realize by using LINQ instead of traditional iteration techniques.
</span></p>
<p class="MsoNormal">This example illustrates how to write <span class="SpellE">
Linq</span> to <span class="GramE">Object</span> queries using Visual C#. First, it builds a class named Person.
<span class="GramE">Person <span class="SpellE">inculdes</span> the ID, Name and Age properties.</span> Then the example creates a list of Person which will be used as the
<span class="SpellE">datasource</span>. In the example, you will see the basic <span class="SpellE">
Linq</span> operations like select, update, <span class="SpellE">orderby</span>, max, average, etc.<span style="">&nbsp;
</span><span style="">&nbsp;&nbsp;</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/65142/1/image.png" alt="" width="720" height="469" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Define the Person class that includes the ID, Name, and Age properties.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class Person


    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal age As Integer)
        Me._id = id
        Me._name = name
        Me._age = age
    End Sub


    Private _id As Integer


    ''' &lt;summary&gt;
    ''' Person ID
    ''' &lt;/summary&gt;
    Public Property PersonID() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
        End Set
    End Property


    Private _name As String


    ''' &lt;summary&gt;
    ''' Person name
    ''' &lt;/summary&gt;
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    Private _age As Integer


    ''' &lt;summary&gt;
    ''' Age that ranges from 1 to 100
    ''' &lt;/summary&gt;
    Public Property Age() As Integer
        Get
            Return Me._age
        End Get
        Set(ByVal value As Integer)
            If ((value &lt;= 0) OrElse (value &gt; 100)) Then
                Throw New Exception(&quot;Age is out of scope [1,100]&quot;)
            End If
            Me._age = value
        End Set
    End Property


End Class

</pre>
<pre id="codePreview" class="vb">
Public Class Person


    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal age As Integer)
        Me._id = id
        Me._name = name
        Me._age = age
    End Sub


    Private _id As Integer


    ''' &lt;summary&gt;
    ''' Person ID
    ''' &lt;/summary&gt;
    Public Property PersonID() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
        End Set
    End Property


    Private _name As String


    ''' &lt;summary&gt;
    ''' Person name
    ''' &lt;/summary&gt;
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    Private _age As Integer


    ''' &lt;summary&gt;
    ''' Age that ranges from 1 to 100
    ''' &lt;/summary&gt;
    Public Property Age() As Integer
        Get
            Return Me._age
        End Get
        Set(ByVal value As Integer)
            If ((value &lt;= 0) OrElse (value &gt; 100)) Then
                Throw New Exception(&quot;Age is out of scope [1,100]&quot;)
            End If
            Me._age = value
        End Set
    End Property


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Build a list of Person to be used as the data source.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Build the Person list that serves as the data source.
        '
        Dim persons As New List(Of Person)


        persons.Add(New Person(1, &quot;Alexander David&quot;, 20))
        persons.Add(New Person(2, &quot;Aziz Hassouneh&quot;, 18))
        persons.Add(New Person(3, &quot;Guido Pica&quot;, 20))
        persons.Add(New Person(4, &quot;Chris Preston&quot;, 19))
        persons.Add(New Person(5, &quot;Jorgen Rahgek&quot;, 20))
        persons.Add(New Person(6, &quot;Todd Rowe&quot;, 18))
        persons.Add(New Person(7, &quot;SPeter addow&quot;, 22))
        persons.Add(New Person(8, &quot;Markus Breyer&quot;, 19))
        persons.Add(New Person(9, &quot;Scott Brown&quot;, 20))

</pre>
<pre id="codePreview" class="vb">
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Build the Person list that serves as the data source.
        '
        Dim persons As New List(Of Person)


        persons.Add(New Person(1, &quot;Alexander David&quot;, 20))
        persons.Add(New Person(2, &quot;Aziz Hassouneh&quot;, 18))
        persons.Add(New Person(3, &quot;Guido Pica&quot;, 20))
        persons.Add(New Person(4, &quot;Chris Preston&quot;, 19))
        persons.Add(New Person(5, &quot;Jorgen Rahgek&quot;, 20))
        persons.Add(New Person(6, &quot;Todd Rowe&quot;, 18))
        persons.Add(New Person(7, &quot;SPeter addow&quot;, 22))
        persons.Add(New Person(8, &quot;Markus Breyer&quot;, 19))
        persons.Add(New Person(9, &quot;Scott Brown&quot;, 20))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Use Linq to perform the query operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Query a person in the data source.
    '
    Dim Todd = (From p In persons _
                Where p.Name = &quot;Todd Rowe&quot; _
                Select p).First()


    Console.WriteLine(&quot;Ereka's age is {0}&quot;, Todd.Age)

</pre>
<pre id="codePreview" class="vb">
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Query a person in the data source.
    '
    Dim Todd = (From p In persons _
                Where p.Name = &quot;Todd Rowe&quot; _
                Select p).First()


    Console.WriteLine(&quot;Ereka's age is {0}&quot;, Todd.Age)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Use Linq to perform the Update operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Perform the Update operation on the person's age.
'
Todd.Age = 21


Console.WriteLine(&quot;Todd Rowe's age is updated to {0}&quot;, (From p In persons _
                                                        Where p.Name = &quot;Todd Rowe&quot; _
                                                        Select p).First().Age)

</pre>
<pre id="codePreview" class="vb">
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Perform the Update operation on the person's age.
'
Todd.Age = 21


Console.WriteLine(&quot;Todd Rowe's age is updated to {0}&quot;, (From p In persons _
                                                        Where p.Name = &quot;Todd Rowe&quot; _
                                                        Select p).First().Age)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Use Linq to perform the Order operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
      '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Sort the data in the data source.
      ' Order the persons by age
      Dim query1 = From p In persons _
                   Order By p.Age _
                   Select p


      Console.WriteLine(&quot;ID&quot; & vbTab & &quot;Name&quot; & vbTab & vbTab & &quot;Age&quot;)


      For Each p In query1.ToList()
          Console.WriteLine(&quot;{0}&quot; & vbTab & &quot;{1}&quot; & vbTab & vbTab & &quot;{2}&quot;, _
                            p.PersonID, p.Name, p.Age)
      Next

</pre>
<pre id="codePreview" class="vb">
      '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Sort the data in the data source.
      ' Order the persons by age
      Dim query1 = From p In persons _
                   Order By p.Age _
                   Select p


      Console.WriteLine(&quot;ID&quot; & vbTab & &quot;Name&quot; & vbTab & vbTab & &quot;Age&quot;)


      For Each p In query1.ToList()
          Console.WriteLine(&quot;{0}&quot; & vbTab & &quot;{1}&quot; & vbTab & vbTab & &quot;{2}&quot;, _
                            p.PersonID, p.Name, p.Age)
      Next

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">6</span>. Use Linq to perform the Max, Min, Average queries.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
      '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Print the average, max, min age of the persons.
      '
      Dim avgAge As Double = (From p In persons _
                              Select p.Age).Average()
      Console.WriteLine(&quot;The average age of the persons is {0:f2}&quot;, avgAge)


      Dim maxAge As Double = (From p In persons _
                              Select p.Age).Max()
      Console.WriteLine(&quot;The maximum age of the persons is {0}&quot;, maxAge)


      Dim minAge As Double = (From p In persons _
                              Select p.Age).Min()
      Console.WriteLine(&quot;The minimum age of the persons is {0}&quot;, minAge)

</pre>
<pre id="codePreview" class="vb">
      '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Print the average, max, min age of the persons.
      '
      Dim avgAge As Double = (From p In persons _
                              Select p.Age).Average()
      Console.WriteLine(&quot;The average age of the persons is {0:f2}&quot;, avgAge)


      Dim maxAge As Double = (From p In persons _
                              Select p.Age).Max()
      Console.WriteLine(&quot;The maximum age of the persons is {0}&quot;, maxAge)


      Dim minAge As Double = (From p In persons _
                              Select p.Age).Min()
      Console.WriteLine(&quot;The minimum age of the persons is {0}&quot;, minAge)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">7</span>. Use Linq to count the Person whose age is larger than 20<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Count the persons who age is larger than 20.
      '
      Dim query2 = From p In persons _
                   Where p.Age &gt; 20 _
                   Select p


      Dim count As Integer = query2.Count()


      Console.WriteLine(&quot;{0} persons are older than 20:&quot;, count)


      For i = 0 To count - 1
          Console.WriteLine(query2.ElementAt(i).Name)
      Next

</pre>
<pre id="codePreview" class="vb">
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
      ' Count the persons who age is larger than 20.
      '
      Dim query2 = From p In persons _
                   Where p.Age &gt; 20 _
                   Select p


      Dim count As Integer = query2.Count()


      Console.WriteLine(&quot;{0} persons are older than 20:&quot;, count)


      For i = 0 To count - 1
          Console.WriteLine(query2.ElementAt(i).Name)
      Next

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style="font-family:新宋体"> </span></h2>
<p class="MsoNormal"><span style="">MSDN: LINQ to Objects </span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb397919.aspx">http://msdn.microsoft.com/en-us/library/bb397919.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">How to Query an ArrayList with LINQ </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb397937.aspx">http://msdn.microsoft.com/en-us/library/bb397937.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
