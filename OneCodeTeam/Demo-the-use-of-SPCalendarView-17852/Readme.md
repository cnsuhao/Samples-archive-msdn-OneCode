# Demo the use of SPCalendarView (CSSharePointCustomCalendar)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SPCalendarView
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:43:18
## Description

<h1><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><a name="OLE_LINK3"></a><a name="OLE_LINK4"><span style=""><span style=""><span style=""><span style="">How to develop a custom calendar</span></span></span></span></a><span style=""><span style=""><span style=""><span style=""><span style="">
 in SharePoint</span></span></span></span></span><span style=""><span style=""><span style=""><span style=""><span style="">
</span>(</span></span></span></span><span style=""><span style=""><span style=""><span style=""><span class="SpellE"><span style="">CSSharePointCustomCalendar</span></span>)</span></span></span></span><span style=""><span style=""></span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code demonstrates how to use &quot;<span class="SpellE">SPCalendarView</span>&quot; class to develop a custom calendar in a visual web part.<span style="">&nbsp;&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow the steps below.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the CSSharePointCustomCalendar.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the CustomCalendarWebPartUserControl.ascx.cs file to modify the &quot;strListName&quot; and SPSiteDataQuery's List ID. The &quot;strListName&quot; specifies the calendar for the add event and
<span class="SpellE">ListID</span> specifies </span><span style="">the </span><span style="">list we want to query.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: After that, right-click the &quot; <span class="SpellE">CSSharePointCustomCalendar</span> &quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: Let's open the SharePoint site in the browser and select &quot;Page&quot;<br>
</span><span style="font-size:9.5pt"><img src="/site/view/file/62002/1/image.png" alt="" width="1041" height="350" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Select </span><span style="">&quot;</span><span style="">Edit</span><span style="">&quot;</span><span style="">.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
<span style=""><img src="/site/view/file/62003/1/image.png" alt="" width="895" height="222" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Select &quot;Insert&quot; Tab and click &quot;Web Part&quot;.<br>
In &quot;Categories&quot;, select &quot;Custom&quot;</span><span style="">.</span><span style="">
</span><span style="">A</span><span style="">nd </span><span style="">then</span><span style=""> in &quot;Web Parts&quot; column</span><span style="">,</span><span style=""> select &quot;CustomCalendarWebPart&quot;.
</span><span style="">You can see the</span><span style=""> &quot;Add&quot; button
</span><span style="">appears </span><span style="">on the right side</span><span style="">, just click on it</span><span style="">.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Then click </span><span style="">&quot;</span><span style="">OK</span><span style="">&quot;</span><span style=""> and then you can see your
<span class="SpellE">CustomCalendar</span> web part appear</span><span style="">s</span><span style=""> in the SharePoint site:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:#A31515"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><img src="/site/view/file/62004/1/image.png" alt="" width="1002" height="524" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: You can click the Calendar item to show detail or click the link</span><span style="">s</span><span style=""> under &quot;Operation&quot;.<br>
<span style=""><img src="/site/view/file/62005/1/image.png" alt="" width="596" height="200" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Empty</span> <span style="">SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;CSSharePointCustomCalendar&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Right-click the project and add a new &quot;Visual Web Part&quot; item to our project and named it as &quot;CustomCalendarWebPart&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Open CustomCalendarWebPart.cs file and then modify the class
</span><span style="">as follows. You may notice that it </span><span style="">inherits from
<span class="SpellE">Microsoft.SharePoint.WebPartPages.WebPart</span>. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CustomCalendarWebPart : Microsoft.SharePoint.WebPartPages.WebPart //System.Web.UI.WebControls.WebParts.WebPart 

</pre>
<pre id="codePreview" class="csharp">
public class CustomCalendarWebPart : Microsoft.SharePoint.WebPartPages.WebPart //System.Web.UI.WebControls.WebParts.WebPart 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: In the Design View of CustomCalendarWebPartUserControl.ascx</span><span style="">, let's</span><span style=""> add a
<span class="SpellE">SPCalendarView</span> </span><span style="">Control</span><span style="font-size:9.5pt; font-family:Consolas; color:maroon">.</span><span style=""><br style="">
<br style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;SharePoint:SPCalendarView ID=&quot;spCalendarView&quot; runat=&quot;server&quot;&gt;
&lt;/SharePoint:SPCalendarView&gt;

</pre>
<pre id="codePreview" class="html">
&lt;SharePoint:SPCalendarView ID=&quot;spCalendarView&quot; runat=&quot;server&quot;&gt;
&lt;/SharePoint:SPCalendarView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">In the CustomCalendarWebPartUserControl.ascx.cs file we </span><span style="">should</span><span style=""> add the following code
</span><span style="">to </span><span style="">map</span><span style=""> </span><span class="SpellE"><span style="">SPCalendarView</span></span><span style=""> control.<span style="">&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// SPCalendarView Control
       protected SPCalendarView spCalendarView;

</pre>
<pre id="codePreview" class="csharp">
// SPCalendarView Control
       protected SPCalendarView spCalendarView;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: </span><span style="">F</span><span style="">irst</span><span style="">,</span><span style=""> let's update
<span class="SpellE">CreateChildControls</span> method. In this method we control the process of calendar creation.
</span><span style="">&quot;</span><span class="SpellE"><span style="">GetQueryData</span></span><span style="">&quot; method</span><span style=""> returns us
<span class="SpellE">DataTable</span> and </span><span style="">&quot;</span><span class="SpellE"><span style="">GetCalendarItems</span></span><span style="">&quot; method</span><span style=""> converts this
<span class="SpellE">DataTable</span> to <a name="OLE_LINK5"></a><a name="OLE_LINK6"><span style=""></span></a><span class="SpellE"><span style=""><span style="">SPCalendarItemCollection</span></span></span><span style=""></span><span style=""></span>.
 Then we </span><span style="">should </span><span style="">obtain calendar view type (day view, week view, month view) by request variables</span><span style="">. Finally,</span><span style=""> we bind data to calendar and add custom rendering to web part
 controls collection. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected override void CreateChildControls()
       {
           base.CreateChildControls();
           // Current web
           SPWeb web = SPContext.Current.Web;
           // List data
           DataTable results = GetQueryData(web);
           // Calendar Item Collection
           SPCalendarItemCollection items = GetCalendarItems(web, results);          


           spCalendarView.EnableViewState = true;


           // Calendar Type
           if (!string.IsNullOrEmpty(Page.Request[&quot;CalendarPeriod&quot;]))
           {
               spCalendarView.ViewType = GetCalendarType(Page.Request[&quot;CalendarPeriod&quot;]);
           }


           // Binds a datasource to the SPCalendarView
           spCalendarView.DataSource = items;
           spCalendarView.DataBind();         


           SPSecurity.RunWithElevatedPrivileges(
              delegate()
              {
                  // Check if current user can add events:
                  bool blnCanAddEvents = false;


                  using (web = SPContext.Current.Site.OpenWeb())
                  {
                      try
                      {
                          bool isHavePermissions = web.DoesUserHavePermissions(SPBasePermissions.AddListItems);


                          if (isHavePermissions)
                          {
                              blnCanAddEvents = true;
                          }
                      }
                      catch
                      {
                      }
                  }


                  // Render header firstly:
                  StringBuilder sbHeader = new StringBuilder();
                  sbHeader.AppendLine(&quot;<table align="center" width="100%" border="1" cellpadding="2" cellspacing="2">&quot;);
                  sbHeader.AppendLine(&quot;<tbody><tr><th align="center">&quot;);
 sbHeader.AppendLine(&quot;&lt;font color='#05C4D8' size='4'&gt;My Custom Calendar&lt;/font&gt;&quot;); sbHeader.AppendLine(&quot;</th></tr></tbody></table>&quot;);
                  Controls.Add(new LiteralControl(sbHeader.ToString()));


                  //Render calendar secondly:     
                  Controls.Add(spCalendarView);


                  // Append Operation legend:
                  StringBuilder sbLegend = new StringBuilder();
                  sbLegend.AppendLine(&quot;<table align="center" width="100%" border="0">&quot;);
                  sbLegend.AppendLine(&quot;<tbody><tr><td width="50%" align="left" valign="top">&quot;);
 sbLegend.AppendLine(&quot;<b><u>Operation:</u></b><br><br>&quot;); if (blnCanAddEvents) sbLegend.AppendLine(String.Format(&quot;<li><a href="\&quot;/Lists/{0}/NewForm.aspx\&quot;">Add New Event</a>&quot;, strListName)); sbLegend.AppendLine(String.Format(&quot;</li><li><a href="\&quot;/Lists/{0}/\&quot;">View the Full Calendar</a>&quot;, strListName)); sbLegend.AppendLine(&quot;</li></td></tr></tbody></table>&quot;);


                  Controls.Add(new LiteralControl(sbLegend.ToString()));
              });
}

</pre>
<pre id="codePreview" class="csharp">
protected override void CreateChildControls()
       {
           base.CreateChildControls();
           // Current web
           SPWeb web = SPContext.Current.Web;
           // List data
           DataTable results = GetQueryData(web);
           // Calendar Item Collection
           SPCalendarItemCollection items = GetCalendarItems(web, results);          


           spCalendarView.EnableViewState = true;


           // Calendar Type
           if (!string.IsNullOrEmpty(Page.Request[&quot;CalendarPeriod&quot;]))
           {
               spCalendarView.ViewType = GetCalendarType(Page.Request[&quot;CalendarPeriod&quot;]);
           }


           // Binds a datasource to the SPCalendarView
           spCalendarView.DataSource = items;
           spCalendarView.DataBind();         


           SPSecurity.RunWithElevatedPrivileges(
              delegate()
              {
                  // Check if current user can add events:
                  bool blnCanAddEvents = false;


                  using (web = SPContext.Current.Site.OpenWeb())
                  {
                      try
                      {
                          bool isHavePermissions = web.DoesUserHavePermissions(SPBasePermissions.AddListItems);


                          if (isHavePermissions)
                          {
                              blnCanAddEvents = true;
                          }
                      }
                      catch
                      {
                      }
                  }


                  // Render header firstly:
                  StringBuilder sbHeader = new StringBuilder();
                  sbHeader.AppendLine(&quot;<table align="center" width="100%" border="1" cellpadding="2" cellspacing="2">&quot;);
                  sbHeader.AppendLine(&quot;<tbody><tr><th align="center">&quot;);
 sbHeader.AppendLine(&quot;&lt;font color='#05C4D8' size='4'&gt;My Custom Calendar&lt;/font&gt;&quot;); sbHeader.AppendLine(&quot;</th></tr></tbody></table>&quot;);
                  Controls.Add(new LiteralControl(sbHeader.ToString()));


                  //Render calendar secondly:     
                  Controls.Add(spCalendarView);


                  // Append Operation legend:
                  StringBuilder sbLegend = new StringBuilder();
                  sbLegend.AppendLine(&quot;<table align="center" width="100%" border="0">&quot;);
                  sbLegend.AppendLine(&quot;<tbody><tr><td width="50%" align="left" valign="top">&quot;);
 sbLegend.AppendLine(&quot;<b><u>Operation:</u></b><br><br>&quot;); if (blnCanAddEvents) sbLegend.AppendLine(String.Format(&quot;<li><a href="\&quot;/Lists/{0}/NewForm.aspx\&quot;">Add New Event</a>&quot;, strListName)); sbLegend.AppendLine(String.Format(&quot;</li><li><a href="\&quot;/Lists/{0}/\&quot;">View the Full Calendar</a>&quot;, strListName)); sbLegend.AppendLine(&quot;</li></td></tr></tbody></table>&quot;);


                  Controls.Add(new LiteralControl(sbLegend.ToString()));
              });
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""><br>
Step 6: </span><span style="">The following code snippet shows the &quot;<span class="SpellE">GetQueryData</span>&quot; method</span><span style="">.</span><span style=""> W</span><span style="">e
</span><span style="">can </span><span style="">create </span><span style="">a </span>
<span class="SpellE"><span style="">SPSiteDataQuery</span></span><span style=""> object to</span><span style=""> query all the lists in site or site collection.</span><span style="">
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
      /// Executes the query against the web and returns 
      /// results as DataTable.
      /// &lt;/summary&gt;
      /// &lt;param name=&quot;web&quot;&gt;The web that is queried.&lt;/param&gt;
      /// &lt;returns&gt;Query results as DataTable.&lt;/returns&gt;
      private DataTable GetQueryData(SPWeb web)
      {
          var query = new SPSiteDataQuery();


          query.Lists = @&quot;&lt;Lists&gt;
                      &lt;List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' /&gt;
                      &lt;List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' /&gt;
                  &lt;/Lists&gt;&quot;;


          query.Query = @&quot;&lt;Where&gt;
                      &lt;Gt&gt;
                          &lt;FieldRef Name='ID' /&gt;
                          &lt;Value Type='Number'&gt;0&lt;/Value&gt;
                      &lt;/Gt&gt;
                  &lt;/Where&gt;&quot;;


          query.Webs = &quot;&lt;Webs Scope='SiteCollection' /&gt;&quot;;
          query.ViewFields = &quot;&lt;FieldRef Name='Title' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='ID' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='EventDate' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='EndDate' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='Location' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='Description' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='fAllDayEvent' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='fRecurrence' /&gt;&quot;;
          query.RowLimit = 100;


          return web.GetSiteData(query);
      }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
      /// Executes the query against the web and returns 
      /// results as DataTable.
      /// &lt;/summary&gt;
      /// &lt;param name=&quot;web&quot;&gt;The web that is queried.&lt;/param&gt;
      /// &lt;returns&gt;Query results as DataTable.&lt;/returns&gt;
      private DataTable GetQueryData(SPWeb web)
      {
          var query = new SPSiteDataQuery();


          query.Lists = @&quot;&lt;Lists&gt;
                      &lt;List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' /&gt;
                      &lt;List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' /&gt;
                  &lt;/Lists&gt;&quot;;


          query.Query = @&quot;&lt;Where&gt;
                      &lt;Gt&gt;
                          &lt;FieldRef Name='ID' /&gt;
                          &lt;Value Type='Number'&gt;0&lt;/Value&gt;
                      &lt;/Gt&gt;
                  &lt;/Where&gt;&quot;;


          query.Webs = &quot;&lt;Webs Scope='SiteCollection' /&gt;&quot;;
          query.ViewFields = &quot;&lt;FieldRef Name='Title' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='ID' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='EventDate' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='EndDate' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='Location' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='Description' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='fAllDayEvent' /&gt;&quot;;
          query.ViewFields &#43;= &quot;&lt;FieldRef Name='fRecurrence' /&gt;&quot;;
          query.RowLimit = 100;


          return web.GetSiteData(query);
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="font-size:9.5pt; line-height:115%; font-family:Consolas"><br>
</span><b style=""><span style="">[Note]</span></b><span style=""> </span><span lang="EN" style="">The first block of XML is lists definition. Replace GUID-s of lists with GUID-s of your lists! Also</span><span lang="EN" style="">, please</span><span lang="EN" style="">
 don't remove row limit. You can change the value but if you remove it you</span><span lang="EN" style=""> will</span><span lang="EN" style=""> get no results.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 7: </span><span lang="EN" style="">&quot;</span><span class="SpellE"><span lang="EN" style="">GetSiteData</span></span><span lang="EN" style="">&quot; method</span><span lang="EN" style=""> returns
 results as</span><span lang="EN" style=""> </span><span class="SpellE"><span lang="EN" style="">DataTable</span></span><span lang="EN" style="">.
<span class="SpellE">SPCalendarView</span> </span><span lang="EN" style="">can </span>
<span lang="EN" style="">accept <span class="SpellE">DataTable</span> as data source but
</span><span lang="EN" style="">you may find </span><span lang="EN" style="">it </span>
<span lang="EN" style="">will </span><span lang="EN" style="">show</span><span lang="EN" style=""> an
</span><span lang="EN" style="">empty calend</span><span lang="EN" style="">ar</span><span lang="EN" style="">.
</span><span lang="EN" style="">&quot;</span><span class="SpellE"><span style="color:black">GetCalendarItems</span></span><span lang="EN" style="">&quot; method converts
<span class="SpellE">Datatable</span> to </span><span class="SpellE"><span style="">SPCalendarItemCollection</span></span><span lang="EN" style="">.
</span><span lang="EN" style="">This method takes </span><span lang="EN" style="">the
</span><span class="SpellE"><span lang="EN" style="">DataTable</span></span><span lang="EN" style="">
</span><span lang="EN" style="">which </span><span lang="EN" style="">returned by
</span><span lang="EN" style="">&quot;</span><span class="SpellE"><span lang="EN" style="">GetSiteData</span></span><span lang="EN" style="">&quot; method</span><span lang="EN" style=""> and returns results as SPCalendarItemCollection. We also can add some
 custom Calendar Item</span><span lang="EN" style="">s</span><span lang="EN" style=""> to the SPCalendarItemCollection.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private SPCalendarItemCollection GetCalendarItems(SPWeb web, DataTable results)
       {
           // Create a new collection for the calendar items
           var items = new SPCalendarItemCollection();
           // SPCalendar Item
           SPCalendarItem item = null;


           #region Calendar Items which is got from the results
           // Loop results to get Calendar Item Information
           foreach (DataRow row in results.Rows)
           {
               // List Guid
               var listGuid = new Guid(row[&quot;ListId&quot;] as string);
               // List
               var list = web.Lists[listGuid];


               item = new SPCalendarItem();


               foreach (SPForm form in list.Forms)
               {
                   // Display Form Url
                   if (form.Type == PAGETYPE.PAGE_DISPLAYFORM)
                   {
                       item.DisplayFormUrl = form.ServerRelativeUrl;
                       break;
                   }
               }


               item.ItemID = row[&quot;ID&quot;] as string;
               item.StartDate = DateTime.Parse(row[&quot;EventDate&quot;] as string);
               item.EndDate = DateTime.Parse(row[&quot;EndDate&quot;] as string);
               item.hasEndDate = true;
               item.Title = row[&quot;Title&quot;] as string;
               item.Location = row[&quot;Location&quot;] as string;
               item.Description = row[&quot;Description&quot;] as string;
               item.IsAllDayEvent = (int.Parse(row[&quot;fAllDayEvent&quot;] as string) != 0);
               item.IsRecurrence = (int.Parse(row[&quot;fRecurrence&quot;] as string) != 0);
               item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);


               items.Add(item);
           }
           #endregion
           #region Custom Calendar Item
           // This is an item with a start and end date. 
           // Add the first dummy item
           item = new SPCalendarItem();


           item.ItemID = &quot;Select&quot;;
           item.Title = &quot;First calendar item&quot;;
           item.StartDate = DateTime.Now;
           item.EndDate = DateTime.Now.AddHours(1);
           item.hasEndDate = true;
           item.DisplayFormUrl = &quot;/News&quot;;
           item.Location = &quot;USA&quot;;
           item.Description = &quot;This is the first test item in the calendar rollup&quot;;
           item.IsAllDayEvent = false;
           item.IsRecurrence = false;
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
           items.Add(item);


           // Add the second item. This is an all day event.
           item = new SPCalendarItem();


           item.StartDate = DateTime.Now.AddDays(-1);
           item.hasEndDate = true;
           item.Title = &quot;Second calendar item&quot;;
           item.DisplayFormUrl = &quot;/News&quot;;
           item.Location = &quot;India&quot;;
           item.Description = &quot;This is the second test item in the calendar rollup&quot;;
           item.IsAllDayEvent = true;
           item.IsRecurrence = false;
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
           items.Add(item);
           #endregion


           return items;
       }

</pre>
<pre id="codePreview" class="csharp">
private SPCalendarItemCollection GetCalendarItems(SPWeb web, DataTable results)
       {
           // Create a new collection for the calendar items
           var items = new SPCalendarItemCollection();
           // SPCalendar Item
           SPCalendarItem item = null;


           #region Calendar Items which is got from the results
           // Loop results to get Calendar Item Information
           foreach (DataRow row in results.Rows)
           {
               // List Guid
               var listGuid = new Guid(row[&quot;ListId&quot;] as string);
               // List
               var list = web.Lists[listGuid];


               item = new SPCalendarItem();


               foreach (SPForm form in list.Forms)
               {
                   // Display Form Url
                   if (form.Type == PAGETYPE.PAGE_DISPLAYFORM)
                   {
                       item.DisplayFormUrl = form.ServerRelativeUrl;
                       break;
                   }
               }


               item.ItemID = row[&quot;ID&quot;] as string;
               item.StartDate = DateTime.Parse(row[&quot;EventDate&quot;] as string);
               item.EndDate = DateTime.Parse(row[&quot;EndDate&quot;] as string);
               item.hasEndDate = true;
               item.Title = row[&quot;Title&quot;] as string;
               item.Location = row[&quot;Location&quot;] as string;
               item.Description = row[&quot;Description&quot;] as string;
               item.IsAllDayEvent = (int.Parse(row[&quot;fAllDayEvent&quot;] as string) != 0);
               item.IsRecurrence = (int.Parse(row[&quot;fRecurrence&quot;] as string) != 0);
               item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);


               items.Add(item);
           }
           #endregion
           #region Custom Calendar Item
           // This is an item with a start and end date. 
           // Add the first dummy item
           item = new SPCalendarItem();


           item.ItemID = &quot;Select&quot;;
           item.Title = &quot;First calendar item&quot;;
           item.StartDate = DateTime.Now;
           item.EndDate = DateTime.Now.AddHours(1);
           item.hasEndDate = true;
           item.DisplayFormUrl = &quot;/News&quot;;
           item.Location = &quot;USA&quot;;
           item.Description = &quot;This is the first test item in the calendar rollup&quot;;
           item.IsAllDayEvent = false;
           item.IsRecurrence = false;
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
           items.Add(item);


           // Add the second item. This is an all day event.
           item = new SPCalendarItem();


           item.StartDate = DateTime.Now.AddDays(-1);
           item.hasEndDate = true;
           item.Title = &quot;Second calendar item&quot;;
           item.DisplayFormUrl = &quot;/News&quot;;
           item.Location = &quot;India&quot;;
           item.Description = &quot;This is the second test item in the calendar rollup&quot;;
           item.IsAllDayEvent = true;
           item.IsRecurrence = false;
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian);
           items.Add(item);
           #endregion


           return items;
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">This method has one little trick. We need URL template to assign it to DisplayFormUrl. When calendar is rendered then parameter ID will be added to this URL. Why don't</span><span lang="EN" style="">
</span><span lang="EN" style="">we ask it from list and then use it as constant? Okay, results are coming from more than one list. Each list has separate display form and therefore separate display form URL. To get correct URL</span><span lang="EN" style="">
</span><span lang="EN" style="">- it is</span><span lang="EN" style=""> a</span><span lang="EN" style=""> good idea to ask them directly from list Forms collection.<br>
Step 8: </span><span lang="EN" style="">At last,</span><span lang="EN" style=""> we have to add one utility method to our web part class. We need to know
</span><span lang="EN" style="">which</span><span lang="EN" style=""> view</span><span lang="EN" style=""> the</span><span lang="EN" style=""> calendar has to show. There</span><span lang="EN" style=""> are</span><span lang="EN" style=""> three view</span><span lang="EN" style="">s</span><span lang="EN" style="">:
</span><span lang="EN" style="">day view,</span><span lang="EN" style=""> </span>
<span lang="EN" style="">week view,</span><span lang="EN" style=""> </span><span lang="EN" style="">month view.</span><span lang="EN" style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected static string GetCalendarType(string type)
      {
          if (type == null)
              type = string.Empty;
          switch (type.ToLower())
          {
              case &quot;day&quot;:
                  return &quot;day&quot;;
              case &quot;week&quot;:
                  return &quot;week&quot;;
              case &quot;timeline&quot;:
                  return &quot;timeline&quot;;
              default:
                  return &quot;month&quot;;
          }
      }

</pre>
<pre id="codePreview" class="csharp">
protected static string GetCalendarType(string type)
      {
          if (type == null)
              type = string.Empty;
          switch (type.ToLower())
          {
              case &quot;day&quot;:
                  return &quot;day&quot;;
              case &quot;week&quot;:
                  return &quot;week&quot;;
              case &quot;timeline&quot;:
                  return &quot;timeline&quot;;
              default:
                  return &quot;month&quot;;
          }
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">When we switch view</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">,</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
 the view type is</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> passed</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">by</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> query string.
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">As you know,</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> query string is something that everybody can easily change</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">,
 so </span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">we
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">should</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> make sure that
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">the
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">view type</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"> is correct</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">.
 Otherwise exception will be thrown.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 9: You can debug and test it.
</span></p>
<p class="MsoNormal" style="">Control<span>.</span>CreateChildControls Method<span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.createchildcontrols.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.createchildcontrols.aspx</a><br>
</span>SPCalendarItemCollection Class<span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendaritemcollection.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendaritemcollection.aspx</a><br>
</span>SPSiteDataQuery Class<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spsitedataquery.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spsitedataquery.aspx</a><br>
</span>SPCalendarItem<span>.</span>DisplayFormUrl Property<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendaritem.displayformurl.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendaritem.displayformurl.aspx</a><br>
</span>SPList<span>.</span>Forms Property<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.splist.forms.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.splist.forms.aspx</a><br>
</span>SPCalendarView Class<span style=""><br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendarview.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spcalendarview.aspx</a><br>
SPSecurity.RunWithElevatedPrivileges Method<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spsecurity.runwithelevatedprivileges.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spsecurity.runwithelevatedprivileges.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
