=====================================================================================
 ASP.NET APPLICATION : CSASPNETGridViewSingleChoiceByRadioButton  Project Overview
=====================================================================================

//////////////////////////////////////////////////////////////////////////////////////
Summary:

  The sample demonstrates how to do a single select with the help of the RadioButton 
  as a Server-Side control in the ItemTemplate of the GridView.
 

//////////////////////////////////////////////////////////////////////////////////////
Demo:

  How to run the program:

  1) Double click the solution to open the sample code.

  2) Right-click the "Default.aspx" page and choose "View in Browser". You can choose the
  item by clicking the radio button, you may notice that each time there's only one item  
  is selected, and the rows's background color will be changed automatically, also you will
  find the selected rows's primary key's value shown below the GridView.


//////////////////////////////////////////////////////////////////////////////////////
Code Logic:

Step1. Open your Visual Studio 2000 Ultimate/Express or other related version 
	to create a C# Web application by choosing "File" -> "New" -> "Project...", 
	expand the "Visual C#" tag and select "Web", then choose "ASP.NET Web Application".
	Please name it as "CSASPNETGridViewSingleChoiceByRadioButton" and switch "Solution" 
	dropdownlist to "Create new solution", in the end check the checkbox "Create
	directory for solution" and press OK button to create the solution.

[ NOTE: You can download the free Visual studio 2010 Express ISO package.]
 http://download.microsoft.com/download/1/E/5/1E5F1C0A-0D5B-426A-A603-1798B951DDAE/VS2010Express1.iso]
 
Step2. Delete the following default folders and files created automatically by Visual Studio.
	Account folder
	Script folder
	Style folder
	About.aspx file
	Global.asax file


Step3. Open Default.aspx, write down the codes below to create a content page:

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETGridViewSingleChoiceByRadioButton .Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>SingleChoice By RadioButton In GridView Sample</title>
	<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.min.js"></script>
	<script>

		$(function () {

			// Handle all the radio button
			$(":radio").click(function () {

				// First set all the radio button's checked state to false
				$(":radio").attr("checked", false);

				// Then set the current one to true
				$(this).attr("checked", true);

				// Save the current selectedRow's index into hiddenfield to avoid losing data because of a post back
				$("#hidSelectedRowIndex").val($(this).parent().parent().index()-1);
			});
		})

	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:HiddenField ID="hidSelectedRowIndex" runat="server" Value="" />
		<asp:GridView ID="GridView1" runat="server" BackColor="White" 
			BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
			AllowPaging="True" onpageindexchanged="GridView1_PageIndexChanged" 
			onpageindexchanging="GridView1_PageIndexChanging" DataKeyNames="Id">
			<Columns>
				<asp:TemplateField HeaderText="Choice">
					<ItemTemplate>
						<asp:RadioButton ID="radChoice" runat="server" Checked="false" 
							AutoPostBack="True" oncheckedchanged="radChoice_CheckedChanged" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
			<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
			<PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
			<RowStyle BackColor="White" ForeColor="#330099" />
			<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
			<SortedAscendingCellStyle BackColor="#FEFCEB" />
			<SortedAscendingHeaderStyle BackColor="#AF0101" />
			<SortedDescendingCellStyle BackColor="#F6F0C0" />
			<SortedDescendingHeaderStyle BackColor="#7E0000" />
		</asp:GridView>
		<asp:Label ID="lbId" runat="server"></asp:Label>
	</div>
	</form>
</body>
</html>


Step4. Double click the page and write down these codes:

		/// <summary>
		/// Create a dynamic datatable and store it into ViewState for further use.
		/// </summary>
		private void MyDataBind()
		{
			if (ViewState["dt"] == null)
			{
				DataTable dt = new DataTable();
				dt.Columns.Add("Id", typeof(int));

				for (int i = 1; i < 21; ++i)
				{
					dt.Rows.Add(i);
				}
				ViewState["dt"] = dt;
			}
			GridView1.DataSource = ViewState["dt"] as DataTable;
			GridView1.DataBind();
		}

		/// <summary>
		/// Initializing to bind with the generated data table.
		/// </summary>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				MyDataBind();
			}
		}


Step5. Handle the GridView's PageIndexChanging and PageIndexChanged events:

		/// <summary>
		/// Change the current GridView's PageIndex
		/// </summary>
		protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView1.PageIndex = e.NewPageIndex;
		}

		/// <summary>
		/// After changing the current GridView's PageIndex, rebind to the GridView.
		/// </summary>
		protected void GridView1_PageIndexChanged(object sender, EventArgs e)
		{
			MyDataBind();
			GridView1.SelectedIndex = -1;
		}

Step6. Set the radio button's AutoPostBack=true, and handle its CheckedChanged event:

        /// <summary>
        /// When choosing a radio button, get the selected row's primary key's value. 
        /// And make this row selected to change its background color.
        /// </summary>
		protected void radChoice_CheckedChanged(object sender, EventArgs e)
		{
			GridViewRow gr = ((Control)sender).NamingContainer as GridViewRow;
			lbId.Text = "The current selected row's primary key's value is："+ GridView1.DataKeys[gr.RowIndex].Value.ToString();
			GridView1.SelectedIndex = Convert.ToInt32(hidSelectedRowIndex.Value);
		}


//////////////////////////////////////////////////////////////////////////////////////
Reference：

http://www.codedigest.com/Articles/ASPNET/134_GridView_with_RadioButton_%E2%80%93_Select_One_at_a_Time.aspx

//////////////////////////////////////////////////////////////////////////////////////