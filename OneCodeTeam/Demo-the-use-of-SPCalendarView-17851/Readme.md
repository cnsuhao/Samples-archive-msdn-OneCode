# Demo the use of SPCalendarView (VBSharePointCustomCalendar)
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
* 2012-07-22 07:43:02
## Description

<h1><span style="">How to develop a custom calendar</span><span style=""> in SharePoint</span><span style="">
</span>(<span style="">VBSharePointCustomCalendar</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code demonstrates how to use &quot;SPCalendarView&quot; class to develop a custom calendar in a visual web part.<span style="">&nbsp;&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBSharePointCustomCalendar.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the CustomCalendarWebPartUserControl.ascx.vb file to modify the &quot;strListName&quot; and SPSiteDataQuery's List ID. The &quot;strListName&quot; specifies the calendar for the add event and ListID specifies the list we want to
 query. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: After that, right-click the &quot;VBSharePointCustomCalendar&quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: Let's open the SharePoint site in the browser and select &quot;Page&quot;<br>
</span><span style="font-size:9.5pt"><img src="/site/view/file/61998/1/image.png" alt="" width="1041" height="350" align="middle">
</span><span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Select &quot;Edit&quot;. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
<span style=""><img src="/site/view/file/61999/1/image.png" alt="" width="895" height="222" align="middle">
</span><br style="">
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
<span style="">Then click </span><span style="">&quot;</span><span style="">OK</span><span style="">&quot;</span><span style=""> and then you can see your CustomCalendar web part appear</span><span style="">s</span><span style=""> in the SharePoint site:</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><img src="/site/view/file/62000/1/image.png" alt="" width="1002" height="524" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: You can click the Calendar item to show detail or click the link</span><span style="">s</span><span style=""> under &quot;Operation&quot;.<br>
<span style=""><img src="/site/view/file/62001/1/image.png" alt="" width="596" height="200" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a VB &quot;Empty</span> <span style="">SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;VBSharePointCustomCalendar&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Right-click the project and add a new &quot;Visual Web Part&quot; item to our project and named it as &quot;CustomCalendarWebPart&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Open CustomCalendarWebPart.vb file and then modify the class
</span><span style="">as follows. You may notice that it </span><span style="">inherits from Microsoft.SharePoint.WebPartPages.WebPart.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class CustomCalendarWebPart Inherits Microsoft.SharePoint.WebPartPages.WebPart //System.Web.UI.WebControls.WebParts.WebPart 

</pre>
<pre id="codePreview" class="vb">
Public Class CustomCalendarWebPart Inherits Microsoft.SharePoint.WebPartPages.WebPart //System.Web.UI.WebControls.WebParts.WebPart 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: In the Design View of CustomCalendarWebPartUserControl.ascx, let's add a SPCalendarView
</span><span style="">Control</span><span style="font-size:9.5pt; font-family:Consolas; color:maroon">.</span><span style=""><br style="">
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
<span style="">Step 5: </span><span style="">F</span><span style="">irst</span><span style="">,</span><span style=""> let's update CreateChildControls method. In this method we control the process of calendar creation.
</span><span style="">&quot;</span><span style="">GetQueryData</span><span style="">&quot; method</span><span style=""> returns us DataTable and
</span><span style="">&quot;</span><span style="">GetCalendarItems</span><span style="">&quot; method</span><span style=""> converts this DataTable to
<a name="OLE_LINK5"></a><a name="OLE_LINK6"><span style="">SPCalendarItemCollection</span></a>. Then we
</span><span style="">should </span><span style="">obtain calendar view type (day view, week view, month view) by request variables</span><span style="">. Finally,</span><span style=""> we bind data to calendar and add custom rendering to web part controls
 collection. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub CreateChildControls()
        MyBase.CreateChildControls()
        ' Current web
        Using web As SPWeb = SPContext.Current.Web
            ' List data
            Dim results As DataTable = GetQueryData(web)
            ' Calendar Item Collection
            Dim items As SPCalendarItemCollection = GetCalendarItems(web, results)


            spCalendarView.EnableViewState = True


            ' Calendar Type
            If Not String.IsNullOrEmpty(Page.Request(&quot;CalendarPeriod&quot;)) Then
                spCalendarView.ViewType = GetCalendarType(Page.Request(&quot;CalendarPeriod&quot;))
            End If


            ' Binds a datasource to the SPCalendarView
            spCalendarView.DataSource = items
            spCalendarView.DataBind()


            'Executes the specified method with Full Control rights even if the user does not otherwise have Full Control.
            SPSecurity.RunWithElevatedPrivileges(AddressOf ElevatedSaveCache)
        End Using
    End Sub


    ''' &lt;summary&gt;
    ''' Check if current user can add events and render content.
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Sub ElevatedSaveCache()
        ' The flag whether the current user has AddListItems permissions.
        Dim blnCanAddEvents As Boolean = False


        Using web As SPWeb = SPContext.Current.Web
            Try
                Dim isHavePermissions As Boolean = web.DoesUserHavePermissions(SPBasePermissions.AddListItems)


                If isHavePermissions Then
                    blnCanAddEvents = True
                End If


            Catch
            End Try
        End Using


        ' Render header firstly:
        Dim sbHeader As New StringBuilder()
        sbHeader.AppendLine(&quot;<table align="center" width="100%" border="1" cellpadding="2" cellspacing="2">&quot;)
        sbHeader.AppendLine(&quot;<tbody><tr><th align="center">&quot;)
 sbHeader.AppendLine(&quot;&lt;font color='#05C4D8' size='4'&gt;My VB Custom Calendar&lt;/font&gt;&quot;) sbHeader.AppendLine(&quot;</th></tr></tbody></table>&quot;)
        Controls.Add(New LiteralControl(sbHeader.ToString()))


        'Render calendar secondly:     
        Controls.Add(spCalendarView)


        ' Append Operation legend:
        Dim sbLegend As New StringBuilder()
        sbLegend.AppendLine(&quot;<table align="center" width="100%" border="0">&quot;)
        sbLegend.AppendLine(&quot;<tbody><tr><td width="50%" align="left" valign="top">&quot;)
 sbLegend.AppendLine(&quot;<b><u>Operation:</u></b><br><br>&quot;) If blnCanAddEvents Then sbLegend.AppendLine([String].Format(&quot;<li><a href="">Add New Event</a>&quot;, strListName)) End If sbLegend.AppendLine([String].Format(&quot;</li><li><a href="">View the Full Calendar</a>&quot;, strListName)) sbLegend.AppendLine(&quot;</li></td></tr></tbody></table>&quot;)


        Controls.Add(New LiteralControl(sbLegend.ToString()))
    End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub CreateChildControls()
        MyBase.CreateChildControls()
        ' Current web
        Using web As SPWeb = SPContext.Current.Web
            ' List data
            Dim results As DataTable = GetQueryData(web)
            ' Calendar Item Collection
            Dim items As SPCalendarItemCollection = GetCalendarItems(web, results)


            spCalendarView.EnableViewState = True


            ' Calendar Type
            If Not String.IsNullOrEmpty(Page.Request(&quot;CalendarPeriod&quot;)) Then
                spCalendarView.ViewType = GetCalendarType(Page.Request(&quot;CalendarPeriod&quot;))
            End If


            ' Binds a datasource to the SPCalendarView
            spCalendarView.DataSource = items
            spCalendarView.DataBind()


            'Executes the specified method with Full Control rights even if the user does not otherwise have Full Control.
            SPSecurity.RunWithElevatedPrivileges(AddressOf ElevatedSaveCache)
        End Using
    End Sub


    ''' &lt;summary&gt;
    ''' Check if current user can add events and render content.
    ''' &lt;/summary&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Sub ElevatedSaveCache()
        ' The flag whether the current user has AddListItems permissions.
        Dim blnCanAddEvents As Boolean = False


        Using web As SPWeb = SPContext.Current.Web
            Try
                Dim isHavePermissions As Boolean = web.DoesUserHavePermissions(SPBasePermissions.AddListItems)


                If isHavePermissions Then
                    blnCanAddEvents = True
                End If


            Catch
            End Try
        End Using


        ' Render header firstly:
        Dim sbHeader As New StringBuilder()
        sbHeader.AppendLine(&quot;<table align="center" width="100%" border="1" cellpadding="2" cellspacing="2">&quot;)
        sbHeader.AppendLine(&quot;<tbody><tr><th align="center">&quot;)
 sbHeader.AppendLine(&quot;&lt;font color='#05C4D8' size='4'&gt;My VB Custom Calendar&lt;/font&gt;&quot;) sbHeader.AppendLine(&quot;</th></tr></tbody></table>&quot;)
        Controls.Add(New LiteralControl(sbHeader.ToString()))


        'Render calendar secondly:     
        Controls.Add(spCalendarView)


        ' Append Operation legend:
        Dim sbLegend As New StringBuilder()
        sbLegend.AppendLine(&quot;<table align="center" width="100%" border="0">&quot;)
        sbLegend.AppendLine(&quot;<tbody><tr><td width="50%" align="left" valign="top">&quot;)
 sbLegend.AppendLine(&quot;<b><u>Operation:</u></b><br><br>&quot;) If blnCanAddEvents Then sbLegend.AppendLine([String].Format(&quot;<li><a href="">Add New Event</a>&quot;, strListName)) End If sbLegend.AppendLine([String].Format(&quot;</li><li><a href="">View the Full Calendar</a>&quot;, strListName)) sbLegend.AppendLine(&quot;</li></td></tr></tbody></table>&quot;)


        Controls.Add(New LiteralControl(sbLegend.ToString()))
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""><br>
Step 6: </span><span style="">The following code snippet shows the &quot;GetQueryData&quot; method</span><span style="">.</span><span style=""> W</span><span style="">e
</span><span style="">can </span><span style="">create </span><span style="">a </span>
<span style="">SPSiteDataQuery</span><span style=""> object to</span><span style=""> query all the lists in site or site collection</span><span lang="EN" style="">.</span><span lang="EN" style=""><span style="">&nbsp;
</span></span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Function GetQueryData(ByVal web As SPWeb) As DataTable
        Dim query = New SPSiteDataQuery()


        query.Lists = &quot;&lt;Lists&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' /&gt;&quot; _
            & vbCr & vbLf & &quot;List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' /&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Lists&gt;&quot;




        query.Query = &quot;&lt;Where&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;Gt&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;FieldRef Name='ID' /&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;Value Type='Number'&gt;0&lt;/Value&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Gt&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Where&gt;&quot;


        query.Webs = &quot;&lt;Webs Scope='SiteCollection' /&gt;&quot;
        query.ViewFields = &quot;&lt;FieldRef Name='Title' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='ID' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='EventDate' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='EndDate' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='Location' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='Description' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='fAllDayEvent' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='fRecurrence' /&gt;&quot;
        query.RowLimit = 100


        Return web.GetSiteData(query)
    End Function

</pre>
<pre id="codePreview" class="vb">
Private Function GetQueryData(ByVal web As SPWeb) As DataTable
        Dim query = New SPSiteDataQuery()


        query.Lists = &quot;&lt;Lists&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;List ID='{080BA3CB-9D7F-4E6B-AE02-2E5BFB79EF91}' /&gt;&quot; _
            & vbCr & vbLf & &quot;List ID='{B65A63B6-B857-423A-AE22-AA7957E78157}' /&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Lists&gt;&quot;




        query.Query = &quot;&lt;Where&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;Gt&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;FieldRef Name='ID' /&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;Value Type='Number'&gt;0&lt;/Value&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Gt&gt;&quot; _
            & vbCr & vbLf & &quot;&lt;/Where&gt;&quot;


        query.Webs = &quot;&lt;Webs Scope='SiteCollection' /&gt;&quot;
        query.ViewFields = &quot;&lt;FieldRef Name='Title' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='ID' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='EventDate' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='EndDate' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='Location' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='Description' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='fAllDayEvent' /&gt;&quot;
        query.ViewFields &#43;= &quot;&lt;FieldRef Name='fRecurrence' /&gt;&quot;
        query.RowLimit = 100


        Return web.GetSiteData(query)
    End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="font-size:9.5pt; line-height:115%; font-family:Consolas"><br>
</span><b style=""><span style="">[Note]</span></b><span style=""> </span><span lang="EN" style="">The first block of XML is lists definition. Replace GUID-s of lists with GUID-s of your lists! Also</span><span lang="EN" style="">, please</span><span lang="EN" style="">
 don't remove row limit. You can change the value but if you remove it you</span><span lang="EN" style=""> will</span><span lang="EN" style=""> get no results.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 7: </span><span lang="EN" style="">&quot;</span><span lang="EN" style="">GetSiteData</span><span lang="EN" style="">&quot; method</span><span lang="EN" style=""> returns results as</span><span lang="EN" style="">
</span><span lang="EN" style="">DataTable. SPCalendarView </span><span lang="EN" style="">can
</span><span lang="EN" style="">accept DataTable as data source but </span><span lang="EN" style="">you may find
</span><span lang="EN" style="">it </span><span lang="EN" style="">will </span><span lang="EN" style="">show</span><span lang="EN" style=""> an
</span><span lang="EN" style="">empty calend</span><span lang="EN" style="">ar</span><span lang="EN" style="">.
</span><span lang="EN" style="">&quot;</span><span style="color:black">GetCalendarItems</span><span lang="EN" style="">&quot; method converts Datatable to
</span><span style="">SPCalendarItemCollection</span><span lang="EN" style="">. </span>
<span lang="EN" style="">This method takes </span><span lang="EN" style="">the </span>
<span lang="EN" style="">DataTable </span><span lang="EN" style="">which </span><span lang="EN" style="">returned by
</span><span lang="EN" style="">&quot;</span><span lang="EN" style="">GetSiteData</span><span lang="EN" style="">&quot; method</span><span lang="EN" style=""> and returns results as SPCalendarItemCollection. We also can add some custom Calendar Item</span><span lang="EN" style="">s</span><span lang="EN" style="">
 to the SPCalendarItemCollection. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Function GetCalendarItems(ByVal web As SPWeb, ByVal results As DataTable) As SPCalendarItemCollection
       ' Create a new collection for the calendar items
       Dim items = New SPCalendarItemCollection()
       ' SPCalendar Item
       Dim item As SPCalendarItem = Nothing


       '#Region &quot;Calendar Items which is got from the results&quot;
       ' Loop results to get Calendar Item Information
       For Each row As DataRow In results.Rows
           ' List Guid
           Dim listGuid = New Guid(TryCast(row(&quot;ListId&quot;), String))
           ' List
           Dim list = web.Lists(listGuid)


           item = New SPCalendarItem()


           For Each form As SPForm In list.Forms
               ' Display Form Url
               If form.Type = PAGETYPE.PAGE_DISPLAYFORM Then
                   item.DisplayFormUrl = form.ServerRelativeUrl
                   Exit For
               End If
           Next


           item.ItemID = TryCast(row(&quot;ID&quot;), String)
           item.StartDate = DateTime.Parse(TryCast(row(&quot;EventDate&quot;), String))
           item.EndDate = DateTime.Parse(TryCast(row(&quot;EndDate&quot;), String))
           item.hasEndDate = True
           item.Title = TryCast(row(&quot;Title&quot;), String)
           item.Location = TryCast(row(&quot;Location&quot;), String)
           item.Description = TryCast(row(&quot;Description&quot;), String)
           item.IsAllDayEvent = (Integer.Parse(TryCast(row(&quot;fAllDayEvent&quot;), String)) &lt;&gt; 0)
           item.IsRecurrence = (Integer.Parse(TryCast(row(&quot;fRecurrence&quot;), String)) &lt;&gt; 0)
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)


           items.Add(item)
       Next
       '#End Region
       '#Region &quot;Custom Calendar Item&quot;
       ' This is an item with a start and end date. 
       ' Add the first dummy item
       item = New SPCalendarItem()


       item.ItemID = &quot;Select&quot;
       item.Title = &quot;First calendar item&quot;
       item.StartDate = DateTime.Now
       item.EndDate = DateTime.Now.AddHours(1)
       item.hasEndDate = True
       item.DisplayFormUrl = &quot;/News&quot;
       item.Location = &quot;USA&quot;
       item.Description = &quot;This is the first test item in the calendar rollup&quot;
       item.IsAllDayEvent = False
       item.IsRecurrence = False
       item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
       items.Add(item)


       ' Add the second item. This is an all day event.
       item = New SPCalendarItem()


       item.StartDate = DateTime.Now.AddDays(-1)
       item.hasEndDate = True
       item.Title = &quot;Second calendar item&quot;
       item.DisplayFormUrl = &quot;/News&quot;
       item.Location = &quot;India&quot;
       item.Description = &quot;This is the second test item in the calendar rollup&quot;
       item.IsAllDayEvent = True
       item.IsRecurrence = False
       item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
       items.Add(item)
       '#End Region


       Return items
   End Function

</pre>
<pre id="codePreview" class="vb">
Private Function GetCalendarItems(ByVal web As SPWeb, ByVal results As DataTable) As SPCalendarItemCollection
       ' Create a new collection for the calendar items
       Dim items = New SPCalendarItemCollection()
       ' SPCalendar Item
       Dim item As SPCalendarItem = Nothing


       '#Region &quot;Calendar Items which is got from the results&quot;
       ' Loop results to get Calendar Item Information
       For Each row As DataRow In results.Rows
           ' List Guid
           Dim listGuid = New Guid(TryCast(row(&quot;ListId&quot;), String))
           ' List
           Dim list = web.Lists(listGuid)


           item = New SPCalendarItem()


           For Each form As SPForm In list.Forms
               ' Display Form Url
               If form.Type = PAGETYPE.PAGE_DISPLAYFORM Then
                   item.DisplayFormUrl = form.ServerRelativeUrl
                   Exit For
               End If
           Next


           item.ItemID = TryCast(row(&quot;ID&quot;), String)
           item.StartDate = DateTime.Parse(TryCast(row(&quot;EventDate&quot;), String))
           item.EndDate = DateTime.Parse(TryCast(row(&quot;EndDate&quot;), String))
           item.hasEndDate = True
           item.Title = TryCast(row(&quot;Title&quot;), String)
           item.Location = TryCast(row(&quot;Location&quot;), String)
           item.Description = TryCast(row(&quot;Description&quot;), String)
           item.IsAllDayEvent = (Integer.Parse(TryCast(row(&quot;fAllDayEvent&quot;), String)) &lt;&gt; 0)
           item.IsRecurrence = (Integer.Parse(TryCast(row(&quot;fRecurrence&quot;), String)) &lt;&gt; 0)
           item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)


           items.Add(item)
       Next
       '#End Region
       '#Region &quot;Custom Calendar Item&quot;
       ' This is an item with a start and end date. 
       ' Add the first dummy item
       item = New SPCalendarItem()


       item.ItemID = &quot;Select&quot;
       item.Title = &quot;First calendar item&quot;
       item.StartDate = DateTime.Now
       item.EndDate = DateTime.Now.AddHours(1)
       item.hasEndDate = True
       item.DisplayFormUrl = &quot;/News&quot;
       item.Location = &quot;USA&quot;
       item.Description = &quot;This is the first test item in the calendar rollup&quot;
       item.IsAllDayEvent = False
       item.IsRecurrence = False
       item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
       items.Add(item)


       ' Add the second item. This is an all day event.
       item = New SPCalendarItem()


       item.StartDate = DateTime.Now.AddDays(-1)
       item.hasEndDate = True
       item.Title = &quot;Second calendar item&quot;
       item.DisplayFormUrl = &quot;/News&quot;
       item.Location = &quot;India&quot;
       item.Description = &quot;This is the second test item in the calendar rollup&quot;
       item.IsAllDayEvent = True
       item.IsRecurrence = False
       item.CalendarType = Convert.ToInt32(SPCalendarType.Gregorian)
       items.Add(item)
       '#End Region


       Return items
   End Function

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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Shared Function GetCalendarType(ByVal type As String) As String
       If type Is Nothing Then
           type = String.Empty
       End If
       Select Case type.ToLower()
           Case &quot;day&quot;
               Return &quot;day&quot;
           Case &quot;week&quot;
               Return &quot;week&quot;
           Case &quot;timeline&quot;
               Return &quot;timeline&quot;
           Case Else
               Return &quot;month&quot;
       End Select
   End Function

</pre>
<pre id="codePreview" class="vb">
Protected Shared Function GetCalendarType(ByVal type As String) As String
       If type Is Nothing Then
           type = String.Empty
       End If
       Select Case type.ToLower()
           Case &quot;day&quot;
               Return &quot;day&quot;
           Case &quot;week&quot;
               Return &quot;week&quot;
           Case &quot;timeline&quot;
               Return &quot;timeline&quot;
           Case Else
               Return &quot;month&quot;
       End Select
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">When we switch view, the view type is passed by query string. As you know, query string is something that everybody can easily change, so we should make sure that the view
 type is correct. Otherwise exception will be thrown.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
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
