# GridView Row Event Support
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* GridView
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:41:50
## Description

<h1>Adding GridView Row Event Support (<span style="">VBASPNETGridViewRowEventSupport</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The VBASPNETGridViewRowEventSupport sample demonstrates how to add GridView Row Event Support on Server side or Client side. In this sample,the server side register script then triggers the RowEditing event of the GridView and the Client side
 alerts the InnerHtml text of the selected &quot;tr&quot;. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBASPNETGridViewRowEventSupport.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the ClientSideSupport.aspx page then select &quot;View in Browser&quot;. Click the Data row you can see an alert to show the
<span style="">InnerHtml of the selected &quot;tr&quot; tag.</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Right-click the ServerSideSupport.aspx page then select &quot;View in Browser&quot;. Click the Data row you can see enter EditTemplate of the GridView<span style="">.</span>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Validation finished.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2012. Name it as &quot;VBASPNETGridViewRowEventSupport&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add two pages then rename to ClientSideSupport.aspx and ServerSideSupport.aspx. Add a GridView to the both pages. Then rename them &quot;<span style="">gvCustomer</span>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Under the App_Data folder add a database name it &quot;gvData.mdf&quot; then create a table name it &quot;CustomerInfo&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Add a SqlDataSource for each page, it uses the database to obtain the load data, and then bound to the GridView of the current page.
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
… 
 &lt;/asp:GridView&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:GridView ID=&quot;gvCustomer&quot; runat=&quot;server&quot; OnRowCreated=&quot;gvCustomer_RowCreated&quot;
         AutoGenerateColumns=&quot;False&quot; OnRowEditing=&quot;gvCustomer_RowEditing&quot; DataSourceID=&quot;SqlDataSource1&quot;&gt;
… 
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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub gvCustomer_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvCustomer.RowCreated
       If e.Row.RowType = DataControlRowType.DataRow Then
           'Returns a string that can be used in a client event to cause postback to the server
           e.Row.Attributes.Add(&quot;onclick&quot;, Page.ClientScript.GetPostBackEventReference(DirectCast(sender, Control), &quot;Edit$&quot; & e.Row.RowIndex.ToString()))
       End If
   End Sub


   Protected Sub gvCustomer_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles gvCustomer.RowEditing
       'Set the edit index.
       gvCustomer.EditIndex = e.NewEditIndex
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub gvCustomer_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvCustomer.RowCreated
       If e.Row.RowType = DataControlRowType.DataRow Then
           'Returns a string that can be used in a client event to cause postback to the server
           e.Row.Attributes.Add(&quot;onclick&quot;, Page.ClientScript.GetPostBackEventReference(DirectCast(sender, Control), &quot;Edit$&quot; & e.Row.RowIndex.ToString()))
       End If
   End Sub


   Protected Sub gvCustomer_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles gvCustomer.RowEditing
       'Set the edit index.
       gvCustomer.EditIndex = e.NewEditIndex
   End Sub

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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Register the postback or callback data for validation. 
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;writer&quot;&gt;&lt;/param&gt;
   Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
       For i As Integer = 0 To gvCustomer.Rows.Count - 1
           ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, &quot;Edit$&quot; & i)
       Next
       MyBase.Render(writer)
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Register the postback or callback data for validation. 
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;writer&quot;&gt;&lt;/param&gt;
   Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
       For i As Integer = 0 To gvCustomer.Rows.Count - 1
           ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, &quot;Edit$&quot; & i)
       Next
       MyBase.Render(writer)
   End Sub

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
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms223395.aspx">ClientScriptManager.RegisterForEventValidation Method (String, String)</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:-.25in; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.getpostbackeventreference.aspx">ClientScriptManager.GetPostBackEventReference Method</a></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
