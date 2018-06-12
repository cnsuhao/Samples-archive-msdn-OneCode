<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETGridViewSingleChoiceByRadioButton.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SingleChoice By RadioButton In GridView Sample</title>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.min.js"></script>
    <script>

        $(function () {

            // Handle all the radio button.
            $(":radio").click(function () {

                // First set all the radio button's checked state to false.
                $(":radio").attr("checked", false);

                // Then set the current one to true.
                $(this).attr("checked", true);

                // Save the current selectedRow's index into hiddenfield to avoid losing data because of a post back.
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
