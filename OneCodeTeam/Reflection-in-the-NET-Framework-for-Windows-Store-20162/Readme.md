# Reflection in the .NET Framework for Windows Store Apps
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Windows 8
## Topics
* Reflection
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:03:04
## Description

<h1><span><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144425" target="_blank"><img id="79968" src="http://i1.code.msdn.s-msft.com/cswindowsstoreappadditem-a5d7fbcc/image/file/79968/1/dpe_w8_728x90_1022_v2.jpg" alt="" width="728" height="90" style="width:100%"></a></span></h1>
<h1><span>Reflection in the .NET Framework for Windows Store Apps(CSWindowsStoreAppReflection)
</span></h1>
<h2><span>Introduction </span></h2>
<p class="MsoNormal">This sample demonstrates how to get all classes that inherit from a base class or implement an interface in a C#/VB.NET Windows Store app.</p>
<p class="MsoNormal">In the .NET for Windows Store apps, the <strong>TypeInfo</strong> class contains some of the functionality of the .NET Framework 4
<strong>Type</strong> class. A <strong>Type</strong> object represents a reference to a type definition, whereas a
<strong>TypeInfo</strong> object represents the type definition itself. This enables you to manipulate Type objects without necessarily requiring the runtime to load the assembly they reference. Getting the associated
<strong>TypeInfo</strong> object forces the assembly to load.</p>
<p class="MsoNormal"><strong>TypeInfo</strong> contains many of the members available on Type, and many of the reflection properties in the .NET for Windows Store apps return collections of
<strong>TypeInfo</strong> objects. To get a <strong>TypeInfo</strong> object from a Type object, use the
<strong>GetTypeInfo</strong> method.</p>
<p class="MsoNormal">&nbsp;</p>
<h2><span>Running the Sample </span></h2>
<p class="MsoListParagraph">1.<span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Open this sample in Visual Studio 2012 on Windows 8 machine, and press F5 to run it.</p>
<p class="MsoListParagraph">2.<span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>After the app is launched, you will see following screen.</p>
<p class="MsoListParagraph"><span><img src="/site/view/file/73717/1/image.png" alt="" width="611" height="370" align="middle">
</span></p>
<p class="MsoListParagraph">&nbsp;</p>
<p class="MsoListParagraph">3.<span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Select a base class or an interface from the comboboxes, then you can see all classes that inherit a base class or implement an interface.&nbsp;</p>
<p class="MsoListParagraph"><span><img src="/site/view/file/73718/1/image.png" alt="" width="616" height="373" align="middle">
</span></p>
<p class="MsoListParagraph"><span>&nbsp;</span></p>
<h2><span>Using the Code </span></h2>
<p class="MsoNormal">1.<span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Define the classes and interfaces to be demonstrated.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IWork
{
&nbsp;&nbsp;&nbsp; void Work();
}


public interface IStudy
{
&nbsp;&nbsp;&nbsp; void Study();
}


public class Person
{
&nbsp;&nbsp;&nbsp; public double Name { get; set; }


&nbsp;&nbsp;&nbsp; public int Age { get; set; }


&nbsp;&nbsp;&nbsp; public bool IsMale { get; set; }
}


public class Student:Person,IStudy
{
&nbsp;&nbsp;&nbsp; public int Grade { get; set; }


&nbsp;&nbsp;&nbsp; public string School { get; set; }






&nbsp;&nbsp;&nbsp; public void Study()
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;}
}


public class Employee:Person,IWork
{
&nbsp;&nbsp;&nbsp; public string Company { get; set; }


&nbsp;&nbsp;&nbsp; public virtual void Work()
&nbsp;&nbsp;&nbsp; {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;}
}


public class Engineer:Employee
{
&nbsp;&nbsp;&nbsp; public string Technology { get; set; }
}


public class Saler:Employee
{
&nbsp;&nbsp;&nbsp; public string Product { get; set; }
}

</pre>
<pre id="codePreview" class="csharp">public interface IWork
{
&nbsp;&nbsp;&nbsp; void Work();
}


public interface IStudy
{
&nbsp;&nbsp;&nbsp; void Study();
}


public class Person
{
&nbsp;&nbsp;&nbsp; public double Name { get; set; }


&nbsp;&nbsp;&nbsp; public int Age { get; set; }


&nbsp;&nbsp;&nbsp; public bool IsMale { get; set; }
}


public class Student:Person,IStudy
{
&nbsp;&nbsp;&nbsp; public int Grade { get; set; }


&nbsp;&nbsp;&nbsp; public string School { get; set; }






&nbsp;&nbsp;&nbsp; public void Study()
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;}
}


public class Employee:Person,IWork
{
&nbsp;&nbsp;&nbsp; public string Company { get; set; }


&nbsp;&nbsp;&nbsp; public virtual void Work()
&nbsp;&nbsp;&nbsp; {&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;}
}


public class Engineer:Employee
{
&nbsp;&nbsp;&nbsp; public string Technology { get; set; }
}


public class Saler:Employee
{
&nbsp;&nbsp;&nbsp; public string Product { get; set; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:1.0in">&nbsp;</p>
<p class="MsoListParagraph" style="margin-left:1.0in">&nbsp;</p>
<p class="MsoNormal">2.<span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Get all classes and interface in an assembly.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> 
// Get current assembly.
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;


// Bind all classes under CSWindowsStoreAppReflection.Types to typeCombobox
typeCombobox.ItemsSource = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t=&gt;t.IsClass &amp;&amp; t.Namespace==&quot;CSWindowsStoreAppReflection.Types&quot;);


// Bind all interfaces under CSWindowsStoreAppReflection.Types to interfaceCombobox
interfaceCombobox.ItemsSource = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsInterface &amp;&amp; t.Namespace == &quot;CSWindowsStoreAppReflection.Types&quot;);

</pre>
<pre id="codePreview" class="csharp"> 
// Get current assembly.
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;


// Bind all classes under CSWindowsStoreAppReflection.Types to typeCombobox
typeCombobox.ItemsSource = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t=&gt;t.IsClass &amp;&amp; t.Namespace==&quot;CSWindowsStoreAppReflection.Types&quot;);


// Bind all interfaces under CSWindowsStoreAppReflection.Types to interfaceCombobox
interfaceCombobox.ItemsSource = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsInterface &amp;&amp; t.Namespace == &quot;CSWindowsStoreAppReflection.Types&quot;);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">3.<span>&nbsp; </span>Find all the derived classes of the selected type.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Get the selected type.
TypeInfo selectedType = (sender as ComboBox).SelectedItem as TypeInfo;


// Find all the derived classes of the selected type.
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
var subTypes = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsClass &amp;&amp; t.IsSubclassOf(selectedType.AsType()));

</pre>
<pre id="codePreview" class="csharp">// Get the selected type.
TypeInfo selectedType = (sender as ComboBox).SelectedItem as TypeInfo;


// Find all the derived classes of the selected type.
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
var subTypes = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsClass &amp;&amp; t.IsSubclassOf(selectedType.AsType()));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">4.<span>&nbsp; </span>Get all classes that implement the selected interface</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Get the selected interface.
TypeInfo selectedInterface = (sender as ComboBox).SelectedItem as TypeInfo;


// Get all classes that implement the selected interface 
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
var subTypes = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsClass &amp;&amp; t.ImplementedInterfaces.Any(i=&gt; i ==selectedInterface.AsType()));

</pre>
<pre id="codePreview" class="csharp">// Get the selected interface.
TypeInfo selectedInterface = (sender as ComboBox).SelectedItem as TypeInfo;


// Get all classes that implement the selected interface 
Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
var subTypes = asm.DefinedTypes
&nbsp;&nbsp;&nbsp; .Where(t =&gt; t.IsClass &amp;&amp; t.ImplementedInterfaces.Any(i=&gt; i ==selectedInterface.AsType()));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<h2><span>More Information </span></h2>
<p class="MsoListParagraph"><span style="font-family:Symbol">&bull;</span><span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>.NET for Windows Store apps overview</p>
<p class="MsoListParagraph"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/br230302.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/br230302.aspx</a></p>
<p class="MsoListParagraph"><span style="font-family:Symbol">&bull;</span><span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Reflection in the .NET Framework for Windows Store Apps</p>
<p class="MsoListParagraph"><a href="http://msdn.microsoft.com/en-us/library/hh535795.aspx">http://msdn.microsoft.com/en-us/library/hh535795.aspx</a></p>
<p class="MsoListParagraph"><span style="font-family:Symbol">&bull;</span><span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="SpellE">TypeInfo</span> Class</p>
<p class="MsoListParagraph"><a href="http://msdn.microsoft.com/en-us/library/system.reflection.typeinfo.aspx">http://msdn.microsoft.com/en-us/library/system.reflection.typeinfo.aspx</a></p>
<p class="MsoListParagraph"><span style="font-family:Symbol">&bull;</span><span style="font-size:7.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Assembly Class</p>
<p class="MsoListParagraph"><a href="http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx">http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx</a></p>
<p class="MsoListParagraph">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
