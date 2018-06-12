# Use CodeDom to generate code for WinForms Designer (VBWinFormDesignerCodeDom)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:35:59
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : VBWinFormDesignerCodeDom Project Overview<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to add your own customized generate code for <br>
control.<br>
<br>
In this example, if we don't customize the code, <br>
system will generate following code for MyList property<br>
Me.MyComponent1.MyList = <br>
CType(resources.GetObject(&quot;MyComponent1.MyList&quot;), System.Collections.Generic.List(Of String))<br>
<br>
But now we want the code with following format<br>
this.myComponent1.MyList.Add(&quot;string5&quot;)<br>
this.myComponent1.MyList.Add(&quot;string4&quot;)<br>
this.myComponent1.MyList.Add(&quot;string3&quot;)<br>
this.myComponent1.MyList.Add(&quot;string2&quot;)<br>
this.myComponent1.MyList.Add(&quot;string1&quot;)<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create a class named &quot;MyCodeGenerator&quot; inherits from CodeDomSerializer.<br>
<br>
2. Override the Deserialize and Serialize method<br>
<br>
3. Get base class's CodeDomSerializer from the IDesignerSerializationManager<br>
<br>
4. Create CodeAssignStatement to generate<br>
&nbsp; myComponent1.MyList = new System.Collections.Generic.List(Of String)();<br>
<br>
5. Create CodeCommentStatement to add comment to our generated code<br>
<br>
6. Create CodeMethodInvokeExpression to generate<br>
&nbsp; Me.myComponent1.MyList.Add(&quot;string1&quot;);<br>
<br>
7. Use MyCodeGenerator for MyComponent class<br>
&nbsp; &lt;DesignerSerializer(GetType(MyCodeGenerator), GetType(CodeDomSerializer))&gt; _<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. CodeDomSerializer Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.design.serialization.codedomserializer.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.design.serialization.codedomserializer.aspx</a><br>
<br>
2. Windows Forms FAQs<br>
<a target="_blank" href="http://windowsclient.net/blogs/faqs/archive/tags/Custom&#43;Designers/default.aspx">http://windowsclient.net/blogs/faqs/archive/tags/Custom&#43;Designers/default.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
