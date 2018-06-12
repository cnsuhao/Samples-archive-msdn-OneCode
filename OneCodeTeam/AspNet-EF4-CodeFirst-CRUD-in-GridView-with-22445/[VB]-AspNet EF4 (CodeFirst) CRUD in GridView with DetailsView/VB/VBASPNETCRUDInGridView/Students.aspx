<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Students.aspx.vb" Inherits="VBASPNETCodeFirstCRUDInGridViewWithDetailsView.Students" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CRUD In GridView with CodeFirst</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Verdana" 
            Font-Size="0.8em" PathSeparator=" : ">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#990000" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#990000" />
                <RootNodeStyle Font-Bold="True" ForeColor="#FF8000" />
            </asp:SiteMapPath>
        <br />
        <asp:GridView runat="server" CellPadding="4" GridLines="None" 
            ForeColor="#333333" Width="70%" ID="GridView1" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="StudentDataSource" DataKeyNames="StudentId">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="StudentId" HeaderText="StudentId" 
                    SortExpression="StudentId" ReadOnly="true" />
                <asp:BoundField DataField="StudentName" HeaderText="StudentName" 
                    SortExpression="StudentName" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57"></EditRowStyle>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White">
            </FooterStyle>
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White">
            </HeaderStyle>
            <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White">
            </PagerStyle>
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#E3EAEB">
            </RowStyle>
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333">
            </SelectedRowStyle>
            <SortedAscendingCellStyle BackColor="#F8FAFA">
            </SortedAscendingCellStyle>
            <SortedAscendingHeaderStyle BackColor="#246B61">
            </SortedAscendingHeaderStyle>
            <SortedDescendingCellStyle BackColor="#D4DFE1">
            </SortedDescendingCellStyle>
            <SortedDescendingHeaderStyle BackColor="#15524A">
            </SortedDescendingHeaderStyle>
        </asp:GridView>
        <asp:ObjectDataSource ID="StudentDataSource" runat="server" 
            DeleteMethod="DeleteStudent" InsertMethod="AddNewStudent" 
            SelectMethod="SelectAllStudents" 
             
            UpdateMethod="UpdateStudent" 
            TypeName="VBASPNETCodeFirstCRUDInGridViewWithDetailsView.DBObjectDataSource">
            <DeleteParameters>
                <asp:Parameter Name="StudentId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="StudentName" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="StudentId" Type="Int32" />
                <asp:Parameter Name="StudentName" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    <p>
        Add a Student Here：<asp:TextBox ID="tbStudentName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbStudentName" ErrorMessage="StudentName is a must!" 
            ForeColor="#FF3300" ValidationGroup="txtBox"></asp:RequiredFieldValidator>
    </p>
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
        Width="102px" ValidationGroup="txtBox" />
    </form>
    <p>
        <a href="CourseChoice.aspx" target="_self">Go To Course Choice pages</a></p>
</body>
</html>
