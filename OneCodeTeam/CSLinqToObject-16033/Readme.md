# CSLinqToObject
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Program Language
## Topics
* LINQ
* LINQ to Objects
## IsPublished
* False
## ModifiedDate
* 2012-03-11 06:35:23
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (<span style="font-family:������">CSLinqToObject</span>)</h1>
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
<p class="MsoNormal">This example illustrates how to write Linq to <span class="GramE">
Object</span> queries using Visual C#. First, it builds a class named Person. Person inculdes the ID, Name and Age properties. Then the example creates a list of Person which will be used as the datasource. In the example, you will see the basic Linq operations
 like select, update, orderby, max, average, etc.<span style="">&nbsp; </span><span style=""></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54055/1/image.png" alt="" width="720" height="469" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Define the Person class that includes the ID, Name, and Age properties.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class Person
{
    public Person(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }


    private int id;


    /// &lt;summary&gt;
    /// Person ID
    /// &lt;/summary&gt;
    public int PersonID
    {
        get { return this.id; }
        set { this.id = value; }
    }


    private string name;


    /// &lt;summary&gt;
    /// Person name
    /// &lt;/summary&gt;
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }


    private int age;


    /// &lt;summary&gt;
    /// Age that ranges from 1 to 100
    /// &lt;/summary&gt;
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value &gt; 0 && value &lt;= 100)
                this.age = value;
            else
                throw new Exception(&quot;Age is out of scope [1,100]&quot;);
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
class Person
{
    public Person(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }


    private int id;


    /// &lt;summary&gt;
    /// Person ID
    /// &lt;/summary&gt;
    public int PersonID
    {
        get { return this.id; }
        set { this.id = value; }
    }


    private string name;


    /// &lt;summary&gt;
    /// Person name
    /// &lt;/summary&gt;
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }


    private int age;


    /// &lt;summary&gt;
    /// Age that ranges from 1 to 100
    /// &lt;/summary&gt;
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value &gt; 0 && value &lt;= 100)
                this.age = value;
            else
                throw new Exception(&quot;Age is out of scope [1,100]&quot;);
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Build a list of Person to be used as the data source.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       /////////////////////////////////////////////////////////////////////
       // Build the Person list that serves as the data source.
       // 
       List&lt;Person&gt; persons = new List&lt;Person&gt;();


       persons.Add(new Person(1, &quot;Alexander David&quot;, 20));
       persons.Add(new Person(2, &quot;Aziz Hassouneh&quot;, 18));
       persons.Add(new Person(3, &quot;Guido Pica&quot;, 20));
       persons.Add(new Person(4, &quot;Chris Preston&quot;, 19));
       persons.Add(new Person(5, &quot;Jorgen Rahgek&quot;, 20));
       persons.Add(new Person(6, &quot;Todd Rowe&quot;, 18));
       persons.Add(new Person(7, &quot;SPeter addow&quot;, 22));
       persons.Add(new Person(8, &quot;Markus Breyer&quot;, 19));
       persons.Add(new Person(9, &quot;Scott Brown&quot;, 20));

</pre>
<pre id="codePreview" class="csharp">
       /////////////////////////////////////////////////////////////////////
       // Build the Person list that serves as the data source.
       // 
       List&lt;Person&gt; persons = new List&lt;Person&gt;();


       persons.Add(new Person(1, &quot;Alexander David&quot;, 20));
       persons.Add(new Person(2, &quot;Aziz Hassouneh&quot;, 18));
       persons.Add(new Person(3, &quot;Guido Pica&quot;, 20));
       persons.Add(new Person(4, &quot;Chris Preston&quot;, 19));
       persons.Add(new Person(5, &quot;Jorgen Rahgek&quot;, 20));
       persons.Add(new Person(6, &quot;Todd Rowe&quot;, 18));
       persons.Add(new Person(7, &quot;SPeter addow&quot;, 22));
       persons.Add(new Person(8, &quot;Markus Breyer&quot;, 19));
       persons.Add(new Person(9, &quot;Scott Brown&quot;, 20));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Use Linq to perform the query operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       /////////////////////////////////////////////////////////////////////
       // Query a person in the data source.
       // 
       var Todd = (from p in persons
                   where p.Name == &quot;Todd Rowe&quot;
                    select p).First();
       // [-or-]
       // Use extension method &#43; lambda expression directly 
       //var Todd = persons.Where(p =&gt; p.Name == &quot;Todd Rowe&quot;).First();


       Console.WriteLine(&quot;Todd Rowe's age is {0}&quot;, Todd.Age);

</pre>
<pre id="codePreview" class="csharp">
       /////////////////////////////////////////////////////////////////////
       // Query a person in the data source.
       // 
       var Todd = (from p in persons
                   where p.Name == &quot;Todd Rowe&quot;
                    select p).First();
       // [-or-]
       // Use extension method &#43; lambda expression directly 
       //var Todd = persons.Where(p =&gt; p.Name == &quot;Todd Rowe&quot;).First();


       Console.WriteLine(&quot;Todd Rowe's age is {0}&quot;, Todd.Age);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Use Linq to perform the Update operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/////////////////////////////////////////////////////////////////////
// Perform the Update operation on the person's age.
// 
Todd.Age = 21;
Console.WriteLine(&quot;Todd Rowe's age is updated to {0}&quot;, (from p in persons
                                                        where p.Name == &quot;Todd Rowe&quot;
                                                    select p).First().Age);

</pre>
<pre id="codePreview" class="csharp">
/////////////////////////////////////////////////////////////////////
// Perform the Update operation on the person's age.
// 
Todd.Age = 21;
Console.WriteLine(&quot;Todd Rowe's age is updated to {0}&quot;, (from p in persons
                                                        where p.Name == &quot;Todd Rowe&quot;
                                                    select p).First().Age);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Use Linq to perform the Order operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
      /////////////////////////////////////////////////////////////////////
      // Sort the data in the data source.       
      // Order the persons by age
      var query1 = from p in persons
                   orderby p.Age
                   select p;


      Console.WriteLine(&quot;ID\tName\t\tAge&quot;);


      foreach (Person p in query1.ToList&lt;Person&gt;())
      {
          Console.WriteLine(&quot;{0}\t{1}\t\t{2}&quot;, p.PersonID, p.Name, p.Age);
      }

</pre>
<pre id="codePreview" class="csharp">
      /////////////////////////////////////////////////////////////////////
      // Sort the data in the data source.       
      // Order the persons by age
      var query1 = from p in persons
                   orderby p.Age
                   select p;


      Console.WriteLine(&quot;ID\tName\t\tAge&quot;);


      foreach (Person p in query1.ToList&lt;Person&gt;())
      {
          Console.WriteLine(&quot;{0}\t{1}\t\t{2}&quot;, p.PersonID, p.Name, p.Age);
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">6</span>. Use Linq to perform the Max, Min, Average queries.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       /////////////////////////////////////////////////////////////////////
       // Print the average, max, min age of the persons.
       // 
       double avgAge = (from p in persons
                        select p.Age).Average();
       Console.WriteLine(&quot;The average age of the persons is {0:f2}&quot;, avgAge);


       double maxAge = (from p in persons
                        select p.Age).Max();
       Console.WriteLine(&quot;The maximum age of the persons is {0}&quot;, maxAge);


       double minAge = (from p in persons
                        select p.Age).Min();
       Console.WriteLine(&quot;The minimum age of the persons is {0}&quot;, minAge);

</pre>
<pre id="codePreview" class="csharp">
       /////////////////////////////////////////////////////////////////////
       // Print the average, max, min age of the persons.
       // 
       double avgAge = (from p in persons
                        select p.Age).Average();
       Console.WriteLine(&quot;The average age of the persons is {0:f2}&quot;, avgAge);


       double maxAge = (from p in persons
                        select p.Age).Max();
       Console.WriteLine(&quot;The maximum age of the persons is {0}&quot;, maxAge);


       double minAge = (from p in persons
                        select p.Age).Min();
       Console.WriteLine(&quot;The minimum age of the persons is {0}&quot;, minAge);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">7</span>. Use Linq to count the Person whose age is larger than 20<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       /////////////////////////////////////////////////////////////////////
       // Count the persons who age is larger than 20
       // 
       var query2 = from p in persons
                    where p.Age &gt; 20
                    select p;


       int count = query2.Count();
       Console.WriteLine(&quot;{0} persons are older than 20:&quot;, count);
       for (int i = 0; i &lt; count; i&#43;&#43;)
       {
           Console.WriteLine(query2.ElementAt(i).Name);
       }

</pre>
<pre id="codePreview" class="csharp">
       /////////////////////////////////////////////////////////////////////
       // Count the persons who age is larger than 20
       // 
       var query2 = from p in persons
                    where p.Age &gt; 20
                    select p;


       int count = query2.Count();
       Console.WriteLine(&quot;{0} persons are older than 20:&quot;, count);
       for (int i = 0; i &lt; count; i&#43;&#43;)
       {
           Console.WriteLine(query2.ElementAt(i).Name);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style="font-family:������"> </span></h2>
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
