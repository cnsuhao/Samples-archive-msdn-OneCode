# ASP.NET DataList-based image gallery (CSASPNETDataListImageGallery)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Image Gallery
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:57:09
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETDataListImageGallery Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to implement an image gallery with DataList<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a C# ASP.NET Web Application in Visual Studio 2008 and name it <br>
as CSASPNETDataListImageGallery.<br>
<br>
Step2. Drag a DataList onto page and set RepeatColumns=&quot;5&quot; <br>
RepeatDirection=&quot;Horizontal&quot;.<br>
<br>
&lt;asp:DataList ID=&quot;DataList1&quot; runat=&quot;server&quot; RepeatColumns=&quot;5&quot;
<br>
RepeatDirection=&quot;Horizontal&quot; &gt;<br>
<br>
Step3. Set template in DataList, which binds to Url field.<br>
<br>
&lt;ItemTemplate&gt;<br>
&nbsp;&lt;asp:ImageButton ID=&quot;imgBtn&quot; runat=&quot;server&quot; <br>
&nbsp; ImageUrl='&lt;%# &quot;/Image/&quot; &#43; Eval(&quot;Url&quot;) %&gt;' Width=&quot;100px&quot; Height=&quot;100px&quot;
<br>
&nbsp; OnClick=&quot;imgBtn_Click&quot; CommandArgument='&lt;%# Container.ItemIndex %&gt;' /&gt;<br>
&lt;/ItemTemplate&gt;<br>
<br>
Step4. Add four buttons for page navigation.<br>
<br>
&lt;asp:LinkButton ID=&quot;lbnFirstPage&quot; Text=&quot;First&quot; CommandName=&quot;first&quot;
<br>
&nbsp;OnCommand=&quot;Page_OnClick&quot; runat=&quot;server&quot; Width=&quot;125px&quot; /&gt;<br>
&lt;asp:LinkButton ID=&quot;lbnPrevPage&quot; Text=&quot;Prev&quot; CommandName=&quot;prev&quot;
<br>
&nbsp;OnCommand=&quot;Page_OnClick&quot; runat=&quot;server&quot; Width=&quot;125px&quot; /&gt;<br>
&lt;asp:LinkButton ID=&quot;lbnNextPage&quot; Text=&quot;Next&quot; CommandName=&quot;next&quot;
<br>
&nbsp;OnCommand=&quot;Page_OnClick&quot; runat=&quot;server&quot; Width=&quot;125px&quot; /&gt;<br>
&lt;asp:LinkButton ID=&quot;lbnLastPage&quot; Text=&quot;Last&quot; CommandName=&quot;last&quot;
<br>
&nbsp;OnCommand=&quot;Page_OnClick&quot; runat=&quot;server&quot; Width=&quot;125px&quot; /&gt;<br>
<br>
Step5: Open the code file of page (Default.aspx.cs)<br>
<br>
Step6: Import System.Data and System.IO namespace to page.<br>
<br>
using System.Data;<br>
using System.IO;<br>
<br>
Step7: Create two properties for page index and page count.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Property for current page index.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int Page_Index<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get { return (int)ViewState[&quot;_Page_Index&quot;]; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set { ViewState[&quot;_Page_Index&quot;] = value; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Property for total page count.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public int Page_Count<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get { return (int)ViewState[&quot;_Page_Count&quot;]; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set { ViewState[&quot;_Page_Count&quot;] = value; }<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step8: Return number of images.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Return total number of images.<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected int ImageCount()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DirectoryInfo di = new DirectoryInfo(Server.MapPath(&quot;/Image/&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FileInfo[] fi = di.GetFiles();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return fi.GetLength(0);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step9: Bind DataList<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Return the data source for DataList.<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected DataTable BindGrid()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get all image paths. &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DirectoryInfo di = new DirectoryInfo(Server.MapPath(&quot;/Image/&quot;));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FileInfo[] fi = di.GetFiles();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Save all paths to the DataTable as the data source.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataTable dt = new DataTable();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataColumn dc = new DataColumn(&quot;Url&quot;, typeof(System.String));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Columns.Add(dc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int lastindex = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (Page_Count == 0 || Page_Index == Page_Count - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lastindex = ImageCount();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lastindex = Page_Index * _pageSize &#43; 5;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = Page_Index * _pageSize; i &lt; lastindex; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataRow dro = dt.NewRow();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dro[0] = fi[i].Name;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Rows.Add(dro);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return dt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step10: Handle paging buttons.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Handle the navigation button event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Page_OnClick(Object sender, CommandEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (e.CommandName.Equals(&quot;first&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Page_Index = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (e.CommandName.Equals(&quot;prev&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Page_Index -= 1;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (Page_Index == 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (e.CommandName.Equals(&quot;next&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Page_Index &#43;= 1;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (Page_Index == Page_Count - 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else if (e.CommandName.Equals(&quot;last&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Page_Index = Page_Count - 1;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnFirstPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnPrevPage.Enabled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnNextPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbnLastPage.Enabled = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataList1.SelectedIndex = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataList1.DataSource = BindGrid();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataList1.DataBind();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Image1.ImageUrl <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= ((Image)DataList1.Items[0].FindControl(&quot;imgBtn&quot;)).ImageUrl;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
Step11: Handle image click event.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Handle the thumbnail image selecting event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected void imgBtn_Click(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ImageButton ib = (ImageButton)sender;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Image1.ImageUrl = ib.ImageUrl;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DataList1.SelectedIndex = Convert.ToInt32(ib.CommandArgument);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: <br>
#DataList Server Control<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/9cx2f3ks(VS.85).aspx">http://msdn.microsoft.com/en-us/library/9cx2f3ks(VS.85).aspx</a><br>
<br>
MSDN: <br>
#Desiding When to Use the DataGrid, DataList and Repeater<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa479015.aspx">http://msdn.microsoft.com/en-us/library/aa479015.aspx</a><br>
<br>
ASP.NET: <br>
#Efficient Data Paging with the ASP.NET 2.0 DataList Control and ObjectDataSource
<br>
<a target="_blank" href="http://weblogs.asp.net/scottgu/archive/2006/01/07/434787.aspx">http://weblogs.asp.net/scottgu/archive/2006/01/07/434787.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
