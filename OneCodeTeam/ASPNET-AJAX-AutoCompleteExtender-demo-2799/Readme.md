# ASP.NET AJAX AutoCompleteExtender demo (CSASPNETAJAXAutoComplete)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
* Auto-complete
## IsPublished
* False
## ModifiedDate
* 2011-05-05 08:52:41
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETAJAXAutoComplete Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to use AutoCompleteExtender to display words <br>
that begin with the prefix that is entered into a text box.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a C# ASP.NET Web Application in Visual Studio 2010 and name it <br>
as CSASPNETAJAXAutoComplete.<br>
<br>
Step2. Delete the following default folders and files created automatically <br>
by Visual Studio.<br>
<br>
Account folder<br>
Script folder<br>
Style folder<br>
About.aspx file<br>
Default.aspx file<br>
Global.asax file<br>
Site.Master file<br>
<br>
Step3. Add a new web form page to the website and name it as Default.aspx.<br>
<br>
Step4. Add ToolkitScriptManager into the beginning page. Then add a TextBox <br>
and a AutoCompleteExtender in the page.You can find the AutoCompleteExtender <br>
in the Ajax Control Toolkit category of the Toolbox.<br>
<br>
[NOTE] When a ToolkitScriptManager is added into the page, such a Register <br>
Info will be added to the same page automatically.<br>
<br>
&lt;%@ Register Assembly=&quot;AjaxControlToolkit&quot; Namespace=&quot;AjaxControlToolkit&quot;
<br>
TagPrefix=&quot;asp&quot; %&gt;<br>
<br>
For more details of how to add Ajax Control Toolkit, please refer to:<br>
<a target="_blank" href="http://www.asp.net/ajaxlibrary/act.ashx.">http://www.asp.net/ajaxlibrary/act.ashx.</a><br>
<br>
Step5: Add a new web service to the website and name it as Searcher.asmx. <br>
Then add WebMethod in the Searcher.cs.<br>
<br>
[WebMethod]<br>
public string[] HelloWorld(string prefixText, int count) <br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (count == 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;count = 10;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (prefixText.Equals(&quot;xyz&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return new string[0];<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Random random = new Random();<br>
&nbsp; &nbsp; &nbsp; &nbsp;List&lt;string&gt; items = new List&lt;string&gt;(count);<br>
&nbsp; &nbsp; &nbsp; &nbsp;char c1;<br>
&nbsp; &nbsp; &nbsp; &nbsp;char c2;<br>
&nbsp; &nbsp; &nbsp; &nbsp;char c3;<br>
&nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; count; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;c1 = (char)random.Next(65, 90);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;c2 = (char)random.Next(97, 122);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;c3 = (char)random.Next(97, 122);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;items.Add(prefixText &#43; c1 &#43; c2 &#43; c3);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;return items.ToArray();<br>
&nbsp; &nbsp;}<br>
<br>
[NOTE] When a web service is added into the application, a same name cs file <br>
will be added in the App_Code folder automatically. For more details of web<br>
service, please refer to:<a target="_blank" href="http://msdn.microsoft.com/en-us/library/t745kdsh.aspx.">http://msdn.microsoft.com/en-us/library/t745kdsh.aspx.</a><br>
<br>
Step6: Set the corresponding properties for AutoCompleteExtender.<br>
<br>
&lt;asp:AutoCompleteExtender ID=&quot;AutoCompleteExtender1&quot; runat=&quot;server&quot;
<br>
TargetControlID=&quot;txtSearch&quot; ServicePath=&quot;~/Searcher.asmx&quot; <br>
ServiceMethod=&quot;HelloWorld&quot; MinimumPrefixLength=&quot;1&quot; CompletionSetCount=&quot;10&quot;&gt;<br>
&lt;/asp:AutoCompleteExtender&gt;<br>
<br>
[NOTE] For the details of AutoCompleteExtender properties, please refer to:<br>
<a target="_blank" href="&lt;a target=" href="http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx">http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx</a>.'&gt;<a target="_blank" href="http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx">http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx</a>.<br>
<br>
Step7: Now, you can run the page to see the achievement we did before :)<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
AutoComplete Tutorials:<br>
<a target="_blank" href="http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx">http://www.asp.net/ajaxlibrary/act_AutoComplete.ashx</a><br>
<br>
AutoComplete Sample:<br>
<a target="_blank" href="http://www.asp.net/ajax/ajaxcontroltoolkit/Samples/AutoComplete/AutoComplete.aspx">http://www.asp.net/ajax/ajaxcontroltoolkit/Samples/AutoComplete/AutoComplete.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
