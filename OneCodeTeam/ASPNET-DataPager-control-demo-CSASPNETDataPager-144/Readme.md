# ASP.NET DataPager control demo (CSASPNETDataPager)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* DataPager
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:57:50
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETDataPager Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSASPNETDataPager sample describes how to use ASP.NET DataPager to <br>
render a paging interface and communicate to the corresponding data-bound <br>
control.<br>
<br>
DataPager control Provides paging functionality for data-bound controls that <br>
implement the IPageableItemContainer interface, such as the ListView control.<br>
<br>
In this sample, the ListView control is populated with data from SQL Server <br>
database in ADO.NET way. The sample uses the SQLServer2005DB sample database. &nbsp;<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a C# ASP.NET Web Application named CSASPNETDataPager in <br>
Visual Studio 2008 / Visual Web Developer.<br>
<br>
<br>
Step2. Drag a ListView control and a DataPager control into an <br>
ASP.NET Web Form page. And then rename the controls as follows:<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;ListView1 &nbsp;-&gt; lvPerson<br>
&nbsp;&nbsp;&nbsp;&nbsp;DataPager1 -&gt; dpPerson<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step3. Add the following three templates in lvPerson: LayoutTemplate, <br>
ItemTemplate and AlternatingItemTemplate.<br>
<br>
For a ListView control, in order to display content, the LayoutTemplate and <br>
ItemTemplate are required. In this sample, we use the following three <br>
templates.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(1) LayoutTemplate: The root template that defines a container object,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;such as a table, div, or span element, that will contain the content
<br>
&nbsp;&nbsp;&nbsp;&nbsp;defined in the ItemTemplate or GroupTemplate template. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;The LayoutTemplate content must include a placeholder control, which has
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the runat attribute set to &quot;server&quot; and the ID attribute set to the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;value of the ItemPlaceholderID or the GroupPlaceholderID property.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;We display the title of the person list in this template.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(2) ItemTemplate: Defines the data-bound content to display for
<br>
&nbsp;&nbsp;&nbsp;&nbsp;individual items.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;In this template, we display the retrieved person information from the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;SQL Server table.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;(3) AlternatingItemTemplate: Defines the content to render for
<br>
&nbsp;&nbsp;&nbsp;&nbsp;alternating items to make it easier to distinguish between consecutive
<br>
&nbsp;&nbsp;&nbsp;&nbsp;items.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;We specify a different background color from ItemTemplate to make the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ListView look better.<br>
&nbsp;&nbsp;&nbsp;&nbsp; <br>
Related references:&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
MSDN: ListView Class<br>
MSDN: ListView Web Server Control Overview<br>
MSDN: PlaceHolder Class<br>
<br>
<br>
Step4. Copy the BindListView method from this sample and paste it <br>
in code-behind. We can use a SqlDataReader here since it's forward-only and <br>
cannot go backwards.<br>
<br>
<br>
Step5. Navigate to the Property panel of dpPerson, set the property <br>
PagedControlID to lvPerson, which measn lvPerson will be paged by dpPerson.<br>
<br>
Related reference:<br>
MSDN: DataPager.PagedControlID Property <br>
<br>
<br>
Step6. Navigate to the Property panel of dpPerson and then switch to Event. <br>
Double-click on the event PreRender to generate the event handler <br>
in code-behind.<br>
<br>
&nbsp; &nbsp;protected void dpPerson_PreRender(object sender, EventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;BindListView();<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
This event occurs after control object is loaded but prior to rendering. <br>
We use it to populate the ListView lvPerson.<br>
<br>
Related reference:<br>
MSDN: Control.PreRender Event<br>
<br>
<br>
Step7. Right-click on dpPerson, select Show Smart Tag. On the Smart Tag, <br>
click Edit Pager Fields and add a Next/Previous Pager Field and <br>
three Template Pager Fields to create the custom paging UI.<br>
<br>
Select the Next/Previous Pager Field and enable the following properties <br>
in the right panel:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ShowFirstPageButton<br>
&nbsp;&nbsp;&nbsp;&nbsp;ShowLastPageButton<br>
<br>
Related references:<br>
<br>
MSDN: NextPreviousPagerField Class<br>
MSDN: TemplatePagerField Class<br>
<br>
<br>
Step8. In the Source view, copy and paste the following markup:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;(1) This TemplatePagerField is used to display the current page number,<br>
&nbsp;&nbsp;&nbsp;&nbsp; the total number of pages and the total number of rows.<br>
<br>
&nbsp; &nbsp;/////////////////////////////////////////////////////////////////////////&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplatePagerField&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;PagerTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Page<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Label runat=&quot;server&quot; ID=&quot;lbCurrentPage&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;&lt;%# Container.TotalRowCount&gt;0 ? (Container.StartRowIndex / Container.PageSize) &#43; 1 : 0 %&gt;&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;of<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Label runat=&quot;server&quot; ID=&quot;lbTotalPages&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;&lt;%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %&gt;&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(Total:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Label runat=&quot;server&quot; ID=&quot;lbTotalItems&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;&lt;%# Container.TotalRowCount%&gt;&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;records) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/PagerTemplate&gt;<br>
&nbsp; &nbsp;&lt;/asp:TemplatePagerField&gt;<br>
&nbsp; &nbsp;/////////////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;(2) This TemplatePagerField shows the pager number in intervals, <br>
&nbsp; &nbsp;like 1-10, 11-20 and so on.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;We also need to add a PagerCommand method in code-behind. So that when a
<br>
&nbsp; &nbsp;button is clicked in this TemplatePagerField,we can handle its behavior.
<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;We will add the method in following steps.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;///////////////////////////////////////////////////////////////////////// &nbsp;
<br>
&nbsp; &nbsp;&lt;asp:TemplatePagerField OnPagerCommand=&quot;TemplateNextPrevious_OnPagerCommand&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;PagerTemplate&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:LinkButton ID=&quot;lbtnFirst&quot; runat=&quot;server&quot; CommandName=&quot;First&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;First&quot; Visible='&lt;%# Container.StartRowIndex &gt; 0 %&gt;' /&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:LinkButton ID=&quot;lbtnPrevious&quot; runat=&quot;server&quot; CommandName=&quot;Previous&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text='&lt;%# (Container.StartRowIndex - Container.PageSize &#43; 1) &#43; &quot; - &quot; &#43; (Container.StartRowIndex) %&gt;'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Visible='&lt;%# Container.StartRowIndex &gt; 0 %&gt;' /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Label ID=&quot;lbtnCurrent&quot; runat=&quot;server&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text='&lt;%# (Container.StartRowIndex &#43; 1) &#43; &quot;-&quot; &#43; (Container.StartRowIndex &#43; Container.PageSize &gt; Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex &#43; Container.PageSize) %&gt;'
 /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:LinkButton ID=&quot;lbtnNext&quot; runat=&quot;server&quot; CommandName=&quot;Next&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text='&lt;%# (Container.StartRowIndex &#43; Container.PageSize &#43; 1) &#43; &quot; - &quot; &#43; (Container.StartRowIndex &#43; Container.PageSize*2 &gt; Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex &#43; Container.PageSize*2)
 %&gt;' <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Visible='&lt;%# (Container.StartRowIndex &#43; Container.PageSize) &lt; Container.TotalRowCount %&gt;' /&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:LinkButton ID=&quot;lbtnLast&quot; runat=&quot;server&quot; CommandName=&quot;Last&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;Last&quot; Visible='&lt;%# (Container.StartRowIndex &#43; Container.PageSize) &lt; Container.TotalRowCount %&gt;' /&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/PagerTemplate&gt;<br>
&nbsp; &nbsp;&lt;/asp:TemplatePagerField&gt; &nbsp; &nbsp;<br>
&nbsp; &nbsp;/////////////////////////////////////////////////////////////////////////<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;(3) In this TemplatePagerField, we can type a page number and click the
<br>
&nbsp; &nbsp;GoTo button to jump to that page.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;This TemplatePagerField also requires a PagerCommand method in code-behind. &nbsp; &nbsp;<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;///////////////////////////////////////////////////////////////////////// &nbsp; &nbsp;<br>
&nbsp; &nbsp;&lt;asp:TemplatePagerField OnPagerCommand = &quot;TemplateGoTo_OnPagerCommand&quot;&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;PagerTemplate&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;br /&gt;&lt;br /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:TextBox ID=&quot;tbPageNumber&quot; runat=&quot;server&quot; Width=&quot;30px&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Text=&quot;&lt;%# Container.TotalRowCount&gt;0 ? (Container.StartRowIndex / Container.PageSize) &#43; 1 : 0 %&gt;&quot; &gt;&lt;/asp:TextBox&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Button ID=&quot;btnGoTo&quot; runat=&quot;server&quot; Text=&quot;GoTo&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/PagerTemplate&gt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp;&lt;/asp:TemplatePagerField&gt; &nbsp; &nbsp;<br>
&nbsp; &nbsp;</p>
<h3></h3>
<p style="font-family:Courier New">Related references:<br>
<br>
MSDN: TemplatePagerField.PagerCommand Event<br>
MSDN: TemplatePagerField.OnPagerCommand Method<br>
&nbsp; <br>
We can also editing the page fields as follows:<br>
<br>
Right-click on dpPerson, select Show Smart Tag. On the Smart Tag, click <br>
Edit Templates to edit the added three Template Pager Fields. We can switch <br>
between them via the Display dropdownlist.<br>
<br>
<br>
Step9. Copy the following methods from this sample and paste them in <br>
code-behind.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;TemplateNextPrevious_OnPagerCommand<br>
&nbsp;&nbsp;&nbsp;&nbsp;TemplateGoTo_OnPagerCommand<br>
<br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: ListView Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview.aspx</a><br>
<br>
MSDN: ListView Web Server Control Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398790.aspx">http://msdn.microsoft.com/en-us/library/bb398790.aspx</a><br>
<br>
MSDN: PlaceHolder Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.placeholder.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.placeholder.aspx</a><br>
<br>
MSDN: DataPager.PagedControlID Property<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.datapager.pagedcontrolid.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.datapager.pagedcontrolid.aspx</a>
<br>
<br>
MSDN: Control.PreRender Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.prerender.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.control.prerender.aspx</a><br>
<br>
MSDN: NextPreviousPagerField Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.nextpreviouspagerfield.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.nextpreviouspagerfield.aspx</a><br>
<br>
MSDN: TemplatePagerField Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.aspx</a><br>
<br>
MSDN: TemplatePagerField.PagerCommand Event<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.pagercommand.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.pagercommand.aspx</a><br>
<br>
MSDN: TemplatePagerField.OnPagerCommand Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.onpagercommand.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.templatepagerfield.onpagercommand.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
