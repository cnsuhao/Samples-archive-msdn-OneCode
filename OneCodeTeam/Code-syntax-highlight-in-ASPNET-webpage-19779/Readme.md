# Code syntax highlight in ASP.NET webpage (VBASPNETHighlightCodeInPage)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Highlighting
## IsPublished
* True
## ModifiedDate
* 2012-12-03 08:02:33
## Description

<h1>Code syntax highlight in ASP.NET webpage (<span class="SpellE">VBASPNETHighlightCodeInPage</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Sometimes we input code like <span style="">VB</span> or HTML in our post and we need these code<span style="">s t</span>o be highlighted for a better reading experience.<span style="">
</span>This project illustrates how<span style=""> </span>to highlight the code in a page.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1: Browse the HighlightCodePage.aspx page from the sample and you will<span style="">
</span>find a dropdownlist control which is used to let user choose the language of code and a textbox control which is used to let user paste the code in.<span style=""><br>
</span>Step2: Chose a type of language in the dropdownlist control and paste the code<span style="">
</span>in the textbox control, then click the HighLight button. If the user does not choose a type of language or does not paste the code in the textbox control<span style="">
</span>before clicking the HighLight button, page will show the error message beside<span style="">
</span>the HighLight button.<span style=""><br>
</span>Step3: After the user clicking the HighLight button, the highlighted code will<span style="">
</span>be displayed at the right side of the page.<span style=""><br>
<span style=""><img src="/site/view/file/71734/1/image.png" alt="" width="1297" height="456" align="middle">
</span></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1: Create a <span style="">Visual Basic</span> ASP.NET Empty Web Application in Visual Studio 201<span style="">2</span>.<span style=""><br>
</span>Step2: Add a <span style="">VB</span> class file which named as 'CodeManager' in Visual Studio 201<span style="">2</span>.<span style="">
</span>In this file, we use a Hashtable variable to store the different languages of code and their related regular expressions with matching options.Then add the<span style="">
</span>style object to the matching string of code. You can find the complete code in<span style="">
</span><span class="SpellE">CodeManager.<span style="">vb</span></span> file.<span style=""><br>
</span>Step3: Add an ASP.NET page into the Web Application as the page which used to<span style="">
</span>let user highlight the code.<span style=""><br>
</span>Step4: Add a dropdownlist control ,two label controls ,a textbox control and a<span style="">
</span>button control into the page as below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
&lt;head id=&quot;Head1&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;title&gt;&lt;/title&gt;
&nbsp;&nbsp;&nbsp; &lt;link href=&quot;Styles/HighlightCode.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;
&lt;/head&gt;
&lt;body&gt;
&nbsp;&nbsp;&nbsp; &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp; <table border="1" style="height:98%">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <tbody><tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td style="width:50%; font-size:12px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Please
 paste the code in textbox control and choose the language before clicking &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; the HighLight button </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td style="width:50%; font-size:12px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Result: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 Please choose the language:&lt;asp:DropDownList ID=&quot;ddlLanguage&quot; runat=&quot;server&quot;&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;-1&quot;&gt;-Please select-&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;cs&quot;&gt;C#&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;vb&quot;&gt;VB.NET&lt;/asp:ListItem&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;js&quot;&gt;JavaScript&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;vbs&quot;&gt;VBScript&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;asp:ListItem Value=&quot;sql&quot;&gt;Sql&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;css&quot;&gt;CSS&lt;/asp:ListItem&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;html&quot;&gt;HTML/XML&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:DropDownList&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;please paste your code here:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TextBox ID=&quot;tbCode&quot; runat=&quot;server&quot; TextMode=&quot;MultiLine&quot; Height=&quot;528px&quot;
 Width=&quot;710px&quot;&gt;&lt;/asp:TextBox&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnHighLight&quot; runat=&quot;server&quot; Text=&quot;HighLight&quot; OnClick=&quot;btnHighLight_Click&quot; /&gt;&lt;asp:Label &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID=&quot;lbError&quot; runat=&quot;server&quot; Text=&quot;Label&quot; ForeColor=&quot;Red&quot;&gt;&lt;/asp:Label&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="DivCode">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lbResult&quot; runat=&quot;server&quot; Text=&quot;&quot;&gt;&lt;/asp:Label&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </tr>
&nbsp;&nbsp;&nbsp; </tbody></table>
&nbsp;&nbsp;&nbsp; &lt;/form&gt;
&lt;/body&gt;
&lt;/html&gt;

</pre>
<pre id="codePreview" class="html">
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
&lt;head id=&quot;Head1&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp; &lt;title&gt;&lt;/title&gt;
&nbsp;&nbsp;&nbsp; &lt;link href=&quot;Styles/HighlightCode.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;
&lt;/head&gt;
&lt;body&gt;
&nbsp;&nbsp;&nbsp; &lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp; <table border="1" style="height:98%">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <tbody><tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td style="width:50%; font-size:12px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Please
 paste the code in textbox control and choose the language before clicking &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; the HighLight button </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td style="width:50%; font-size:12px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Result: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <tr>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 Please choose the language:&lt;asp:DropDownList ID=&quot;ddlLanguage&quot; runat=&quot;server&quot;&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;-1&quot;&gt;-Please select-&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;cs&quot;&gt;C#&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;vb&quot;&gt;VB.NET&lt;/asp:ListItem&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;js&quot;&gt;JavaScript&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;vbs&quot;&gt;VBScript&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;asp:ListItem Value=&quot;sql&quot;&gt;Sql&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;css&quot;&gt;CSS&lt;/asp:ListItem&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ListItem Value=&quot;html&quot;&gt;HTML/XML&lt;/asp:ListItem&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:DropDownList&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;please paste your code here:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TextBox ID=&quot;tbCode&quot; runat=&quot;server&quot; TextMode=&quot;MultiLine&quot; Height=&quot;528px&quot;
 Width=&quot;710px&quot;&gt;&lt;/asp:TextBox&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnHighLight&quot; runat=&quot;server&quot; Text=&quot;HighLight&quot; OnClick=&quot;btnHighLight_Click&quot; /&gt;&lt;asp:Label &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID=&quot;lbError&quot; runat=&quot;server&quot; Text=&quot;Label&quot; ForeColor=&quot;Red&quot;&gt;&lt;/asp:Label&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="DivCode">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lbResult&quot; runat=&quot;server&quot; Text=&quot;&quot;&gt;&lt;/asp:Label&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </tr>
&nbsp;&nbsp;&nbsp; </tbody></table>
&nbsp;&nbsp;&nbsp; &lt;/form&gt;
&lt;/body&gt;
&lt;/html&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5: Open the <span style="">VB</span> code behind view of the page to write the highlight code function.<span style="">
</span>You can find the complete version in the <span class="SpellE">HighlightCodePage.aspx.<span style="">vb</span></span> file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnHighLight_Click(ByVal sender As Object, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _error As String = String.Empty


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Check the value of user's input data.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If CheckControlValue(Me.ddlLanguage.SelectedValue,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.tbCode.Text, _error) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the Hashtable variable which used to
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' store the different languages of code and their 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' related regular expressions with matching options.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _htb As Hashtable = CodeManager.Init()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the suitable collection object.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _rg As New RegExp()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _rg = DirectCast(_htb(Me.ddlLanguage.SelectedValue), RegExp)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Me.ddlLanguage.SelectedValue &lt;&gt; &quot;html&quot; Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Display the highlighted code in a label control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Text = CodeManager.Encode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CodeManager.HighlightCode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Server.HtmlEncode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.tbCode.Text).
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Replace(&quot;&quot;&quot;, &quot;&quot;&quot;&quot;).
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Replace(&quot;&#39;&quot;, &quot;'&quot;),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ddlLanguage.SelectedValue, _rg))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Display the highlighted code in a label control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Text = CodeManager.Encode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CodeManager.HighlightHTMLCode(Me.tbCode.Text, _htb))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbError.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbError.Text = _error
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnHighLight_Click(ByVal sender As Object, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _error As String = String.Empty


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Check the value of user's input data.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If CheckControlValue(Me.ddlLanguage.SelectedValue,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.tbCode.Text, _error) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the Hashtable variable which used to
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' store the different languages of code and their 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' related regular expressions with matching options.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _htb As Hashtable = CodeManager.Init()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Initialize the suitable collection object.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim _rg As New RegExp()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _rg = DirectCast(_htb(Me.ddlLanguage.SelectedValue), RegExp)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Me.ddlLanguage.SelectedValue &lt;&gt; &quot;html&quot; Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Display the highlighted code in a label control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Text = CodeManager.Encode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CodeManager.HighlightCode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Server.HtmlEncode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.tbCode.Text).
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Replace(&quot;&quot;&quot;, &quot;&quot;&quot;&quot;).
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Replace(&quot;&#39;&quot;, &quot;'&quot;),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ddlLanguage.SelectedValue, _rg))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Display the highlighted code in a label control.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbResult.Text = CodeManager.Encode(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CodeManager.HighlightHTMLCode(Me.tbCode.Text, _htb))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbError.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.lbError.Text = _error
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6: Create a new directory, &quot;Styles&quot;. We need to create a style sheet file.<span style="">
</span>Add a style sheet file which named as 'HighlightCode' in the Styles folder.<span style="">
</span>In this file ,define some of the styles which used to highlight the code.You can<span style="">
</span>find the complete version in the HighlightCode.css file.</p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN:<span style="">&nbsp; </span>struct<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/ah19swz4(VS.71).aspx">http://msdn.microsoft.com/en-us/library/ah19swz4(VS.71).aspx</a><span style=""><br>
</span>MSDN: Hashtable Class<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.collections.hashtable.aspx">http://msdn.microsoft.com/en-us/library/system.collections.hashtable.aspx</a><span style=""><br>
</span>MSDN: ArrayList Class<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.collections.arraylist.aspx">http://msdn.microsoft.com/en-us/library/system.collections.arraylist.aspx</a><span style=""><br>
</span>MSDN: Regex Class<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx</a><span style=""><br>
</span>MSDN: String.Replace Method<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.string.replace.aspx">http://msdn.microsoft.com/en-us/library/system.string.replace.aspx</a><span style=""><br>
</span>MSDN: GroupCollection Class<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.groupcollection.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.groupcollection.aspx</a><span style=""><br>
</span>MSDN: Match Class<span style=""><br>
</span><a href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.match.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.match.aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>