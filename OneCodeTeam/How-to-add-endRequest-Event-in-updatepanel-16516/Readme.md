# How to add endRequest Event in updatepanel (AddEndRequestEventInUpdatepanel)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* AJAX
* ASP.NET
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2012-04-20 03:27:46
## Description

<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to add endRequest Event in UpdatePanel</span></b>(<b style=""><span style="font-size:14.0pt; font-family:Consolas">VBASPNETAddEndRequestEventInUpdatepanel</span></b>)</p>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>The VBASPNETAddEndRequestEventInUpdatepanel sample demonstrates how to add endRequest Event Support in UpdatePanel and resolve add_endRequest Event doesn't work in Firefox. Default page shows the scene of the current page using the ScriptManager Control.
 The WebForm1 page shows the scene, using the MasterPage which have already has the ScriptManager control, this page use the ScriptManagerProxy control.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 1: Open the VBASPNETAddEndRequestEventInUpdatepanel.sln.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;. Wait a moment, and then see the prompt.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 3: Right-click the </span>
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">WebForm1</span><span style="font-size:9.5pt; font-family:Consolas">.aspx page then select &quot;View in Browser&quot;. Wait a moment, and then see the prompt.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 4: Validation finished. </span>
</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2008</span><span style="">/Visual Web Developer</span><span style="font-size:9.5pt; font-family:Consolas">. Name it as &quot;VBASPNETAddEndRequestEventInUpdatepanel&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. If you have installed SQL server 2008 r2 express on your computer, you can directly use the sample database under the App_Data. If not, add a SQL Server Database in the App_Data folder and name it as ��SampleData��. The definition of the
 table ��BooksScore�� as show below: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">[Id] [int] IDENTITY(1,1) NOT NULL, [Name] [nvarchar](50) NULL, [Score] [float] NULL
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">You can insert the following test data or add new data: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (1, N'HandBook', 80) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (2, N'Guide', 90) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (3, N'Story', 60.5) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (4, N'HeadFirst', 70) 

</pre>
<pre id="codePreview" class="mysql">
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (1, N'HandBook', 80) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (2, N'Guide', 90) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (3, N'Story', 60.5) 
INSERT [dbo].[BooksScore] ([Id], [Name], [Score]) VALUES (4, N'HeadFirst', 70) 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step3. Add two ��Web Service�� and a Master Page. Add two pages then rename to Default.aspx and WebForm1.aspx, the WebForm1 page uses the Master page created before.<span style="">&nbsp;
</span>Add a </span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">ScriptManager Control</span><span style="font-size:9.5pt; font-family:Consolas"> to the Default pages and the Master Page. Then to achieve the two services like the sample or you
 own code. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">The main code of Master page as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
    &lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot;&gt;
        &lt;Services&gt;
            &lt;asp:ServiceReference Path=&quot;~/WebService1.asmx&quot; /&gt;
        &lt;/Services&gt;
    &lt;/asp:ScriptManager&gt;
����
    <div>
        &lt;asp:ContentPlaceHolder ID=&quot;ContentPlaceHolder1&quot; runat=&quot;server&quot;&gt;
        &lt;/asp:ContentPlaceHolder&gt;
    </div>
    &lt;/form&gt;

</pre>
<pre id="codePreview" class="html">
&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;
    &lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot;&gt;
        &lt;Services&gt;
            &lt;asp:ServiceReference Path=&quot;~/WebService1.asmx&quot; /&gt;
        &lt;/Services&gt;
    &lt;/asp:ScriptManager&gt;
����
    <div>
        &lt;asp:ContentPlaceHolder ID=&quot;ContentPlaceHolder1&quot; runat=&quot;server&quot;&gt;
        &lt;/asp:ContentPlaceHolder&gt;
    </div>
    &lt;/form&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">The main code of WebForm1</span><span style="font-size:9.5pt; font-family:Consolas">
</span><span style="font-size:9.5pt; font-family:Consolas">page as shown below: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


����
 &lt;asp:ScriptManagerProxy ID=&quot;iSmpSum&quot; runat=&quot;server&quot;&gt;
          &lt;Services&gt;
              &lt;asp:ServiceReference Path=&quot;~/WebService2.asmx&quot; /&gt;
          &lt;/Services&gt;
      &lt;/asp:ScriptManagerProxy&gt;
����


&lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; runat=&quot;server&quot; EnableViewState=&quot;false&quot;&gt;
����


&lt;Triggers&gt;


&lt;asp:AsyncPostBackTrigger ControlID=&quot;LinkButton1&quot;
/&gt;


&lt;/Triggers&gt;
&lt;/asp:UpdatePanel&gt;


 &lt;script type=&quot;text/javascript&quot;&gt;
 $(document).ready(function() {
          Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);


          function endRequestHandle(sender, Args) {
              if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())


  __doPostBack('LinkButton1',
'');


               
//alert test


//               
var testGrid = $get('&lt;%=grid1.ClientID %&gt;');


//                alert(testGrid.rows[1].cells[0].innerHTML);          }
����
});
&lt;/script&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


����
 &lt;asp:ScriptManagerProxy ID=&quot;iSmpSum&quot; runat=&quot;server&quot;&gt;
          &lt;Services&gt;
              &lt;asp:ServiceReference Path=&quot;~/WebService2.asmx&quot; /&gt;
          &lt;/Services&gt;
      &lt;/asp:ScriptManagerProxy&gt;
����


&lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; runat=&quot;server&quot; EnableViewState=&quot;false&quot;&gt;
����


&lt;Triggers&gt;


&lt;asp:AsyncPostBackTrigger ControlID=&quot;LinkButton1&quot;
/&gt;


&lt;/Triggers&gt;
&lt;/asp:UpdatePanel&gt;


 &lt;script type=&quot;text/javascript&quot;&gt;
 $(document).ready(function() {
          Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);


          function endRequestHandle(sender, Args) {
              if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())


  __doPostBack('LinkButton1',
'');


               
//alert test


//               
var testGrid = $get('&lt;%=grid1.ClientID %&gt;');


//                alert(testGrid.rows[1].cells[0].innerHTML);          }
����
});
&lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">Triggers</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">asp</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">:</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">AsyncPostBackTrigger</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;">
<span style="color:red">ControlID</span><span style="color:blue">=&quot;LinkButton1&quot;</span>
<span style="color:blue">/&gt; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">&nbsp; </span>
__doPostBack(<span style="color:#A31515">'LinkButton1'</span>, <span style="color:#A31515">
''</span>); </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">//alert test </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:green">//<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>var testGrid = $get('&lt;%=grid1.ClientID %&gt;'); </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">The main code of </span><span style="font-size:9.5pt; font-family:Consolas">Default
</span><span style="font-size:9.5pt; font-family:Consolas">page as shown below:</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot; LoadScriptsBeforeUI=&quot;false&quot;&gt;
   &lt;/asp:ScriptManager&gt;
   <div>
       &lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; runat=&quot;server&quot; EnableViewState=&quot;false&quot;&gt;
           &lt;ContentTemplate&gt;
               &lt;asp:Timer ID=&quot;Timer1&quot; Interval=&quot;15000&quot; runat=&quot;server&quot;&gt;
               &lt;/asp:Timer&gt;
               &lt;asp:GridView ID=&quot;grid1&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;False&quot; DataKeyNames=&quot;Id&quot;
                   DataSourceID=&quot;SqlDataSource2&quot;&gt;
                   &lt;Columns&gt;
                       &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot;
                           SortExpression=&quot;Id&quot; /&gt;
                       &lt;asp:BoundField DataField=&quot;Name&quot; HeaderText=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
                       &lt;asp:BoundField DataField=&quot;Score&quot; HeaderText=&quot;Score&quot; SortExpression=&quot;Score&quot; /&gt;
                   &lt;/Columns&gt;
               &lt;/asp:GridView&gt;
               &lt;asp:SqlDataSource ID=&quot;SqlDataSource2&quot; runat=&quot;server&quot; 
                   ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot; 
                   SelectCommand=&quot;SELECT [Id], [Name], [Score] FROM [BooksScore]&quot;&gt;
               &lt;/asp:SqlDataSource&gt;             
           &lt;/ContentTemplate&gt;


           
&lt;Triggers&gt;


               
&lt;asp:AsyncPostBackTrigger
ControlID=&quot;LinkButton1&quot;
/&gt;


            &lt;/Triggers&gt;
       &lt;/asp:UpdatePanel&gt;
   </div>


   &lt;script type=&quot;text/javascript&quot;&gt;
           Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
       
       function endRequestHandler(sender, args) {
           if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
              __doPostBack('LinkButton1', '');
               var testGrid = $get('&lt;%=grid1.ClientID %&gt;');
           alert(testGrid.rows[1].cells[0].innerHTML);     
       }
   &lt;/script&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot; LoadScriptsBeforeUI=&quot;false&quot;&gt;
   &lt;/asp:ScriptManager&gt;
   <div>
       &lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; runat=&quot;server&quot; EnableViewState=&quot;false&quot;&gt;
           &lt;ContentTemplate&gt;
               &lt;asp:Timer ID=&quot;Timer1&quot; Interval=&quot;15000&quot; runat=&quot;server&quot;&gt;
               &lt;/asp:Timer&gt;
               &lt;asp:GridView ID=&quot;grid1&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;False&quot; DataKeyNames=&quot;Id&quot;
                   DataSourceID=&quot;SqlDataSource2&quot;&gt;
                   &lt;Columns&gt;
                       &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot;
                           SortExpression=&quot;Id&quot; /&gt;
                       &lt;asp:BoundField DataField=&quot;Name&quot; HeaderText=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
                       &lt;asp:BoundField DataField=&quot;Score&quot; HeaderText=&quot;Score&quot; SortExpression=&quot;Score&quot; /&gt;
                   &lt;/Columns&gt;
               &lt;/asp:GridView&gt;
               &lt;asp:SqlDataSource ID=&quot;SqlDataSource2&quot; runat=&quot;server&quot; 
                   ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot; 
                   SelectCommand=&quot;SELECT [Id], [Name], [Score] FROM [BooksScore]&quot;&gt;
               &lt;/asp:SqlDataSource&gt;             
           &lt;/ContentTemplate&gt;


           
&lt;Triggers&gt;


               
&lt;asp:AsyncPostBackTrigger
ControlID=&quot;LinkButton1&quot;
/&gt;


            &lt;/Triggers&gt;
       &lt;/asp:UpdatePanel&gt;
   </div>


   &lt;script type=&quot;text/javascript&quot;&gt;
           Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
       
       function endRequestHandler(sender, args) {
           if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
              __doPostBack('LinkButton1', '');
               var testGrid = $get('&lt;%=grid1.ClientID %&gt;');
           alert(testGrid.rows[1].cells[0].innerHTML);     
       }
   &lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">Triggers</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">&lt;</span><span style="color:#A31515">asp</span><span style="color:blue">:</span><span style="color:#A31515">AsyncPostBackTrigger</span>
<span style="color:red">ControlID</span><span style="color:blue">=&quot;LinkButton1&quot;</span>
<span style="color:blue">/&gt; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">You can replace the alert with you own code.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style="font-size:9.5pt; font-family:Consolas">[NOTE]</span></b><span style="font-size:9.5pt; font-family:Consolas">
</span><span style="font-size:9.5pt; font-family:Consolas">On the Default page, the most important thing is set
</span><span style="color:black">LoadScriptsBeforeUI Property of ScriptManager to false.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot; LoadScriptsBeforeUI=&quot;false&quot;&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;asp:ScriptManager ID=&quot;ScriptManager&quot; runat=&quot;server&quot; LoadScriptsBeforeUI=&quot;false&quot;&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step4. <b style="">[NOTE]</b> To make WebForm1 page and Default page to achieve the same effect, the main code of
</span><span style="font-size:9.5pt; font-family:Consolas">Default </span><span style="font-size:9.5pt; font-family:Consolas">page as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;script type=&quot;text/javascript&quot;&gt;
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);


            function endRequestHandle(sender, Args) {
                if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
              __doPostBack('LinkButton1', '');
                    var testGrid = $get('&lt;%=grid1.ClientID %&gt;');
                alert(testGrid.rows[1].cells[0].innerHTML);
            }
 });

</pre>
<pre id="codePreview" class="html">
&lt;script type=&quot;text/javascript&quot;&gt;
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);


            function endRequestHandle(sender, Args) {
                if (!Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
              __doPostBack('LinkButton1', '');
                    var testGrid = $get('&lt;%=grid1.ClientID %&gt;');
                alert(testGrid.rows[1].cells[0].innerHTML);
            }
 });

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step5.<b style=""> </b>Build the application and you can debug it.<b style="">
</b></span></p>
<p class="MsoListParagraph" style="margin-bottom:0in; margin-bottom:.0001pt; text-indent:-.25in; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:9.5pt; font-family:Consolas"><a href="http://msdn.microsoft.com/en-us/library/bb311028.aspx">Sys.WebForms.PageRequestManager Class
</a><span style="">&nbsp;</span> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
