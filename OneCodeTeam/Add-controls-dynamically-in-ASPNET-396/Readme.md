# Add controls dynamically in ASP.NET (CSASPNETAddControlDynamically)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Dynamic control
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:51:13
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETAddControlDynamically Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project shows how to add controls dynamically in ASP.NET pages. It <br>
imitates a scenario that customers need to input more than one address info <br>
without max limit. So we use button to add new address input TextBoxes.<br>
After a customer inputs all the addresses, we also use button to update <br>
these info into database, which is run as displaying these addresses in <br>
this sample.<br>
<br>
Demo the Sample.<br>
<br>
Step1: Browse the Default.aspx page from the sample and you will find two <br>
buttons called &quot;Add a New Address&quot; and &quot;Save These Addresses&quot;.<br>
<br>
Step2: Click on the &quot;Add a New Address&quot; button to add a field after these<br>
two buttons. It will contain a Lable, a TextBox and a &quot;Check&quot; button.<br>
<br>
Step3: Input something into the TextBox and click on the &quot;Add a New Address&quot;
<br>
button again to add another field after the first.<br>
<br>
Step4: Enter some strings in the second TextBox and then try to click the<br>
&quot;Check&quot; button. A msg will pop-up telling the value in the TextBox next<br>
to the &quot;Check&quot; button.<br>
<br>
Step5: Click on the &quot;Save These Addresses&quot; button. Now, the list of the
<br>
addresses inputted will be displayed on the top of the page.<br>
<br>
Step6: Click on the &quot;Add a New Address&quot; button to react this process. You can<br>
add as many such fields as you want to test this demo.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a C# ASP.NET Empty Web Application in Visual Studio 2010.<br>
<br>
Step2: Add a Default ASP.NET page into it as the demo page.<br>
<br>
Step3: Add two Buttons and a Panel into the page as the HTML code below.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Button ID=&quot;btnAddAddress&quot; runat=&quot;server&quot; Text=&quot;Add a New Address&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Button ID=&quot;btnSave&quot; runat=&quot;server&quot; Text=&quot;Save These Addresses&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;br /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;br /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Panel ID=&quot;pnlAddressContainer&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Panel&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;br /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step4: Open the C# behind code view to write a funciton of adding components.<br>
You can find the complete version in the Default.aspx.cs file.<br>
<br>
&nbsp; &nbsp;protected void AddAdress(string id)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;Label lb = new Label();<br>
&nbsp; &nbsp; &nbsp; &nbsp;lb.Text = &quot;Address&quot; &#43; id &#43; &quot;: &quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;TextBox tb = new TextBox();<br>
&nbsp; &nbsp; &nbsp; &nbsp;tb.ID = &quot;TextBox&quot; &#43; id;<br>
&nbsp; &nbsp; &nbsp; &nbsp;tb.Text = Request.Form[tb.ID];<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Button btn = new Button();<br>
&nbsp; &nbsp; &nbsp; &nbsp;btn.Text = &quot;Check&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;btn.ID = &quot;Button&quot; &#43; id;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;btn.Click &#43;= new EventHandler(ClickEvent);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;pnlAddressContainer.Controls.Add(lb);<br>
&nbsp; &nbsp; &nbsp; &nbsp;pnlAddressContainer.Controls.Add(tb);<br>
&nbsp; &nbsp; &nbsp; &nbsp;pnlAddressContainer.Controls.Add(btn);<br>
&nbsp; &nbsp;}<br>
<br>
Step5: Write the function for &quot;Check&quot; button's click event. Some code in this<br>
function will need skills on working along with JavaScript in ASP.NET page.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;protected void ClickEvent(object sender, EventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;Button btn = sender as Button;<br>
&nbsp; &nbsp; &nbsp; &nbsp;TextBox tb = pnlAddressContainer.FindControl(btn.ID.Replace(&quot;Button&quot;, &quot;TextBox&quot;)) as TextBox;<br>
&nbsp; &nbsp; &nbsp; &nbsp;string address = tb.Text == &quot;&quot; ? &quot;Empty&quot; : tb.Text;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;System.Text.StringBuilder sb = new System.Text.StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp;sb.Append(&quot;&lt;script type=\&quot;text/javascript\&quot;&gt;&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;sb.Append(&quot;alert(\&quot;Address&quot; &#43; btn.ID.Replace(&quot;Button&quot;, &quot;&quot;) &#43; &quot; is &quot; &#43; address &#43; &quot;.\&quot;);&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;sb.Append(&quot;&lt;/script&gt;&quot;);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), &quot;AlertClick&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ClientScript.RegisterClientScriptBlock(this.GetType(), &quot;AlertClick&quot;, sb.ToString());<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;} <br>
<br>
Step6: Edit click event handler of the &quot;Add New Address&quot; button to call the
<br>
funciton above to add address components.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET Forum: <br>
# Why do dynamic controls disappear on postback and not raise events?<br>
<a target="_blank" href="http://forums.asp.net/t/1186195.aspx">http://forums.asp.net/t/1186195.aspx</a><br>
<br>
MSDN:<br>
# ASP.NET Page Life Cycle Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms178472.aspx">http://msdn.microsoft.com/en-us/library/ms178472.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
