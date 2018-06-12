# Code syntax highlight in ASP.NET webpage (CSASPNETHighlightCodeInPage)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Syntax Highlight
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:01:06
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETHighlightCodeInPage Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Sometimes we input code like C# or HTML in our post and we need these code <br>
to be highlighted for a better reading experience.This project illustrates how<br>
to highlight the code in a page. <br>
<br>
<br>
Demo the Sample.<br>
<br>
Step1: Browse the HighlightCodePage.aspx page from the sample and you will<br>
find a dropdownlist control which is used to let user choose the language of <br>
code and a textbox control which is used to let user paste the code in.<br>
<br>
Step2: Chose a type of language in the dropdownlist control and paste the code<br>
in the textbox control, then click the HighLight button. If the user does not <br>
choose a type of language or does not paste the code in the textbox control<br>
before clicking the HighLight button, page will show the error message beside<br>
the HighLight button.<br>
<br>
Step3: After the user clicking the HighLight button, the highlighted code will<br>
be displayed at the right side of the page. <br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a C# ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step2: Add a C# class file which named as 'CodeManager' in Visual Studio 2010.<br>
In this file, we use a Hashtable variable to store the different languages of <br>
code and their related regular expressions with matching options.Then add the<br>
style object to the matching string of code. You can find the complete code in<br>
CodeManager.cs file.<br>
<br>
Step3: Add an ASP.NET page into the Web Application as the page which used to<br>
let user highlight the code.<br>
<br>
Step4: Add a dropdownlist control ,two label controls ,a textbox control and a<br>
button control into the page as below.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;html xmlns=&quot;<a target="_blank" href="http://www.w3.org/1999/xhtml&quot;&gt;">http://www.w3.org/1999/xhtml&quot;&gt;</a><br>
&lt;head id=&quot;Head1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp; &nbsp;&lt;title&gt;&lt;/title&gt;<br>
&nbsp; &nbsp;&lt;link href=&quot;Styles/HighlightCode.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
&nbsp; &nbsp;&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp; &nbsp;&lt;table border=&quot;1&quot; style=&quot;height: 98%&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;tr&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td style=&quot;width: 50%; font-size: 12px&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;strong&gt;Please paste the code in textbox control and choose
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the language before clicking<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;the HighLight button &lt;/strong&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td style=&quot;width: 50%; font-size: 12px&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;strong&gt;Result: &lt;/strong&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/tr&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;tr&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Please choose the language:&lt;asp:DropDownList ID=&quot;ddlLanguage&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; runat=&quot;server&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;-1&quot;&gt;-Please select-&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;cs&quot;&gt;C#&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;vb&quot;&gt;VB.NET&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;js&quot;&gt;JavaScript&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;vbs&quot;&gt;VBScript&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;sql&quot;&gt;Sql&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;css&quot;&gt;CSS&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ListItem Value=&quot;html&quot;&gt;HTML/XML&lt;/asp:ListItem&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:DropDownList&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;please paste your code here:&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TextBox ID=&quot;tbCode&quot; runat=&quot;server&quot; TextMode=&quot;MultiLine&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height=&quot;528px&quot; Width=&quot;710px&quot;&gt;&lt;/asp:TextBox&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Button ID=&quot;btnHighLight&quot; runat=&quot;server&quot; Text=&quot;HighLight&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OnClick=&quot;btnHighLight_Click&quot; /&gt;&lt;asp:Label<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ID=&quot;lbError&quot; runat=&quot;server&quot; Text=&quot;Label&quot; ForeColor=&quot;Red&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Label&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;div id=&quot;DivCode&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Label ID=&quot;lbResult&quot; runat=&quot;server&quot; Text=&quot;&quot;&gt;&lt;/asp:Label&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/div&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/td&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/tr&gt;<br>
&nbsp; &nbsp;&lt;/table&gt;<br>
&nbsp; &nbsp;&lt;/form&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
<br>
Step5: Open the C# code behind view of the page to write the highlight code function.<br>
You can find the complete version in the HighlightCodePage.aspx.cs file.<br>
<br>
&nbsp; &nbsp; &nbsp;protected void btnHighLight_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string _error = string.Empty;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Check the value of user's input data.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (CheckControlValue(this.ddlLanguage.SelectedValue,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbCode.Text, out _error))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Initialize the Hashtable variable which used to<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// store the different languages of code and their
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// related regular expressions with matching options.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Hashtable _htb = CodeManager.Init();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Initialize the suitable collection object.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RegExp _rg = new RegExp();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_rg = (RegExp)_htb[this.ddlLanguage.SelectedValue];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.lbResult.Visible = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (this.ddlLanguage.SelectedValue != &quot;html&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Display the highlighted code in a label control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.lbResult.Text = CodeManager.Encode(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CodeManager.HighlightCode(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Server.HtmlEncode(this.tbCode.Text)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.Replace(&quot;&quot;&quot;, &quot;\&quot;&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ddlLanguage.SelectedValue, _rg)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Display the highlighted code in a label control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.lbResult.Text = CodeManager.Encode(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CodeManager.HighlightHTMLCode(this.tbCode.Text, _htb)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.lbError.Visible = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.lbError.Text = _error;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step6: Create a new directory, &quot;Styles&quot;. We need to create a style sheet file.<br>
Add a style sheet file which named as 'HighlightCode' in the Styles folder.<br>
In this file ,define some of the styles which used to highlight the code.You can<br>
find the complete version in the HighlightCode.css file.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: <br>
# struct<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ah19swz4(VS.71).aspx">http://msdn.microsoft.com/en-us/library/ah19swz4(VS.71).aspx</a><br>
<br>
MSDN:<br>
# Hashtable Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.collections.hashtable.aspx">http://msdn.microsoft.com/en-us/library/system.collections.hashtable.aspx</a><br>
<br>
MSDN:<br>
# ArrayList Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.collections.arraylist.aspx">http://msdn.microsoft.com/en-us/library/system.collections.arraylist.aspx</a><br>
<br>
MSDN:<br>
# Regex Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx</a><br>
<br>
MSDN:<br>
# String.Replace Method <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.string.replace.aspx">http://msdn.microsoft.com/en-us/library/system.string.replace.aspx</a><br>
<br>
MSDN:<br>
# GroupCollection Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.groupcollection.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.groupcollection.aspx</a><br>
<br>
MSDN:<br>
# Match Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.match.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.match.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
