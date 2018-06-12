# make GridView single selectable (ASPNETSingleChoiceByRadioButton)
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
* 2012-05-10 07:55:47
## Description
=====================================================================================<br>
ASP.NET APPLICATION : VBASPNETGridViewSingleChoiceByRadioButton Project Overview<br>
=====================================================================================<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
&nbsp;The sample demonstrates how to do a single select with the help of the RadioButton
<br>
&nbsp;as a Server-Side control in the ItemTemplate of the GridView.<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
&nbsp;How to run the program:<br>
<br>
&nbsp;1) Double click the solution to open the sample code.<br>
<br>
&nbsp;2) Right-click the &quot;Default.aspx&quot; page and choose &quot;View in Browser&quot;. You can choose the<br>
&nbsp;item by clicking the radio button, you may notice that each time there's only one item &nbsp;<br>
&nbsp;is selected, and the rows's background color will be changed automatically, also you will<br>
&nbsp;find the selected rows's primary key's value shown below the GridView.<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
Step1. Open your Visual Studio 2000 Ultimate/Express or other related version <br>
&nbsp;&nbsp;&nbsp;&nbsp;to create a VB.NET Web application by choosing &quot;File&quot; -&gt; &quot;New&quot; -&gt; &quot;Project...&quot;,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;expand the &quot;Visual Basic&quot; tag and select &quot;Web&quot;, then choose &quot;ASP.NET Web Application&quot;.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Please name it as &quot;VBASPNETGridViewSingleChoiceByRadioButton&quot; and switch &quot;Solution&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;dropdownlist to &quot;Create new solution&quot;, in the end check the checkbox &quot;Create<br>
&nbsp;&nbsp;&nbsp;&nbsp;directory for solution&quot; and press OK button to create the solution.<br>
<br>
[ NOTE: You can download the free Visual studio 2010 Express ISO package.]<br>
http://download.microsoft.com/download/1/E/5/1E5F1C0A-0D5B-426A-A603-1798B951DDAE/VS2010Express1.iso]<br>
<br>
Step2. Delete the following default folders and files created automatically by Visual Studio.<br>
&nbsp;&nbsp;&nbsp;&nbsp;Account folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;Script folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;Style folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;About.aspx file<br>
&nbsp;&nbsp;&nbsp;&nbsp;Global.asax file<br>
<br>
Step3. Open Default.aspx, write down the codes below to create a content page:<br>
<br>
&lt;%@ Page Language=&quot;vb&quot; AutoEventWireup=&quot;true&quot; CodeBehind=&quot;Default.aspx.vb&quot; Inherits=&quot;VBASPNETGridViewSingleChoiceByRadioButton.Default&quot; %&gt;<br>
<br>
&lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;<br>
<br>
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;<br>
&lt;head runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;SingleChoice By RadioButton In GridView Sample&lt;/title&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script type=&quot;text/javascript&quot; src=&quot;http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.min.js&quot;&gt;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(function () {<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Handle all the radio button.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&quot;:radio&quot;).click(function () {<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// First set all the radio button's checked state to false.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&quot;:radio&quot;).attr(&quot;checked&quot;, false);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Then set the current one to true.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(this).attr(&quot;checked&quot;, true);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Save the current selectedRow's index into hiddenfield to avoid losing data because of a post back.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&quot;#hidSelectedRowIndex&quot;).val($(this).parent().parent().index()-1);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;})<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;<br>
&lt;/head&gt;<br>
&lt;body&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;form id=&quot;form1&quot; runat=&quot;server&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;
<div><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:HiddenField ID=&quot;hidSelectedRowIndex&quot; runat=&quot;server&quot; Value=&quot;&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:GridView ID=&quot;GridView1&quot; runat=&quot;server&quot; BackColor=&quot;White&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BorderColor=&quot;#CC9966&quot; BorderStyle=&quot;None&quot; BorderWidth=&quot;1px&quot; CellPadding=&quot;4&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllowPaging=&quot;True&quot; onpageindexchanged=&quot;GridView1_PageIndexChanged&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onpageindexchanging=&quot;GridView1_PageIndexChanging&quot; DataKeyNames=&quot;Id&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField HeaderText=&quot;Choice&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:RadioButton ID=&quot;radChoice&quot; runat=&quot;server&quot; Checked=&quot;false&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutoPostBack=&quot;True&quot; oncheckedchanged=&quot;radChoice_CheckedChanged&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterStyle BackColor=&quot;#FFFFCC&quot; ForeColor=&quot;#330099&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;HeaderStyle BackColor=&quot;#990000&quot; Font-Bold=&quot;True&quot; ForeColor=&quot;#FFFFCC&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerStyle BackColor=&quot;#FFFFCC&quot; ForeColor=&quot;#330099&quot; HorizontalAlign=&quot;Center&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowStyle BackColor=&quot;White&quot; ForeColor=&quot;#330099&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SelectedRowStyle BackColor=&quot;#FFCC66&quot; Font-Bold=&quot;True&quot; ForeColor=&quot;#663399&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingCellStyle BackColor=&quot;#FEFCEB&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingHeaderStyle BackColor=&quot;#AF0101&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingCellStyle BackColor=&quot;#F6F0C0&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingHeaderStyle BackColor=&quot;#7E0000&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label ID=&quot;lbId&quot; runat=&quot;server&quot;&gt;&lt;/asp:Label&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;</div>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;<br>
&lt;/body&gt;<br>
&lt;/html&gt;<br>
<br>
<br>
Step4. Double click the page and write down these codes:<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Create a dynamic datatable and store it into ViewState <br>
&nbsp; &nbsp;''' for further use.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Private Sub MyDataBind()<br>
&nbsp; &nbsp; &nbsp; &nbsp;If ViewState(&quot;dt&quot;) Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim dt As New DataTable()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Columns.Add(&quot;Id&quot;, GetType(Integer))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For i As Integer = 1 To 20<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dt.Rows.Add(i)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ViewState(&quot;dt&quot;) = dt<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView1.DataSource = TryCast(ViewState(&quot;dt&quot;), DataTable)<br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView1.DataBind()<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Initializing to bind with the generated data table.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MyDataBind()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
<br>
<br>
Step5. Handle the GridView's PageIndexChanging and PageIndexChanged events.<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' Change the current GridView's PageIndex<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView1.PageIndex = e.NewPageIndex<br>
&nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' After changing the current GridView's PageIndex, rebind to the GridView.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Protected Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;MyDataBind()<br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView1.SelectedIndex = -1<br>
&nbsp; &nbsp;End Sub<br>
<br>
Step6. Set the radio button's AutoPostBack=true, and handle its CheckedChanged event:<br>
<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' When choosing a radio button, get the selected row's primary key's value.
<br>
&nbsp; &nbsp;''' And make this row selected to change its background color.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Protected Sub radChoice_CheckedChanged(sender As Object, e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim gr As GridViewRow = TryCast(DirectCast(sender, Control).NamingContainer, GridViewRow)<br>
&nbsp; &nbsp; &nbsp; &nbsp;lbId.Text = &quot;The current selected row's primary key's value is：&quot; & GridView1.DataKeys(gr.RowIndex).Value.ToString()<br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView1.SelectedIndex = Convert.ToInt32(hidSelectedRowIndex.Value)<br>
&nbsp; &nbsp;End Sub<br>
<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
Reference：<br>
<br>
http://www.codedigest.com/Articles/ASPNET/134_GridView_with_RadioButton_%E2%80%93_Select_One_at_a_Time.aspx<br>
<br>
//////////////////////////////////////////////////////////////////////////////////////<br>
