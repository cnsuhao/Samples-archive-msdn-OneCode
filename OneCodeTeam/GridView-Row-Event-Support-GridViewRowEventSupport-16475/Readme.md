# GridView Row Event Support (GridViewRowEventSupport)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* GridView
## IsPublished
* True
## ModifiedDate
* 2012-04-20 01:07:44
## Description

<h1>Adding GridView Row Event Support (<span style="">CSASPNETGridViewRowEventSupport</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The CSASPNETGridViewRowEventSupport sample demonstrates how to add GridView Row Event Support on Server side or Client side. In this sample, the server side registers script then triggers the RowEditing event of the GridView and the Client side
 alerts the InnerHtml text of the selected ��tr��. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETGridViewRowEventSupport.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the ClientSideSupport.aspx page then select &quot;View in Browser&quot;. Click the Data row you can see an alert to show the
<span style="">InnerHtml of the selected ��tr�� tag.</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Right-click the ServerSideSupport.aspx page then select &quot;View in Browser&quot;. Click the Data row you can see enter EditTemplate of the GridView<span style="">.</span>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a C# &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as &quot;CSASPNETGridViewRowEventSupport&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add two pages then rename to ClientSideSupport.aspx and ServerSideSupport.aspx. Add a GridView to the both pages. Then rename them ��<span style="">gvCustomer</span>��.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Under the App_Data folder add a database name it ��gvData.mdf�� then create a table name it ��CustomerInfo��.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Add a SqlDataSource for each page, it uses the database to obtain the load data, and then bound to the GridView of the current page.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5. In the ClientSideSupport page, add <span style="color:red">
OnRowEditing</span> and <span style="color:red">OnRowCreated</span> event for the GridView</span><span style="">.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:GridView ID=&quot;gvCustomer&quot; runat=&quot;server&quot; OnRowCreated=&quot;gvCustomer_RowCreated&quot;
         AutoGenerateColumns=&quot;False&quot; OnRowEditing=&quot;gvCustomer_RowEditing&quot; DataSourceID=&quot;SqlDataSource1&quot;&gt;
�� 
 &lt;/asp:GridView&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:GridView ID=&quot;gvCustomer&quot; runat=&quot;server&quot; OnRowCreated=&quot;gvCustomer_RowCreated&quot;
         AutoGenerateColumns=&quot;False&quot; OnRowEditing=&quot;gvCustomer_RowEditing&quot; DataSourceID=&quot;SqlDataSource1&quot;&gt;
�� 
 &lt;/asp:GridView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The code-behind is as follows: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void gvCustomer_RowCreated(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               //Returns a string that can be used in a client event to cause postback to the server
               e.Row.Attributes.Add(&quot;onclick&quot;, Page.ClientScript.GetPostBackEventReference((Control)sender, &quot;Edit$&quot; &#43; e.Row.RowIndex.ToString()));
           }
       }


       protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
       {
           //Set the edit index.
           gvCustomer.EditIndex = e.NewEditIndex;
       }

</pre>
<pre id="codePreview" class="csharp">
protected void gvCustomer_RowCreated(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               //Returns a string that can be used in a client event to cause postback to the server
               e.Row.Attributes.Add(&quot;onclick&quot;, Page.ClientScript.GetPostBackEventReference((Control)sender, &quot;Edit$&quot; &#43; e.Row.RowIndex.ToString()));
           }
       }


       protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
       {
           //Set the edit index.
           gvCustomer.EditIndex = e.NewEditIndex;
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style="">[Note]</span></b><span style=""> In order to call GetPostBackEventReference method we must add the following code:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
       /// Register the postback or callback data for validation. 
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;writer&quot;&gt;&lt;/param&gt;
       protected override void Render(HtmlTextWriter writer)
       {
           for (int i = 0; i &lt; gvCustomer.Rows.Count; i&#43;&#43;)
               ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, &quot;Edit$&quot; &#43; i);
           base.Render(writer);
       }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
       /// Register the postback or callback data for validation. 
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;writer&quot;&gt;&lt;/param&gt;
       protected override void Render(HtmlTextWriter writer)
       {
           for (int i = 0; i &lt; gvCustomer.Rows.Count; i&#43;&#43;)
               ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, &quot;Edit$&quot; &#43; i);
           base.Render(writer);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step6.<b style=""> </b>Build the application and you can debug it.<b style="">
</b></span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:-.25in; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms223395.aspx">ClientScriptManager.RegisterForEventValidation Method (String, String)</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:-.25in; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.getpostbackeventreference.aspx">ClientScriptManager.GetPostBackEventReference Method</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
