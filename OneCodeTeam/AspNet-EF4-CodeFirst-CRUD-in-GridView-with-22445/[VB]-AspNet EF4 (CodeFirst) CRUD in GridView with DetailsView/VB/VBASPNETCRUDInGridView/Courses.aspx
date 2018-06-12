<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Courses.aspx.vb" Inherits="VBASPNETCodeFirstCRUDInGridViewWithDetailsView.Courses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Courses Page</title>
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
        <asp:GridView ID="GridView1" runat="server" BackColor="White" width="70%"
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CourseId" 
            DataSourceID="CourseDataSource" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CourseId" HeaderText="CourseId" 
                    SortExpression="CourseId" />
                <asp:BoundField DataField="CourseName" HeaderText="CourseName" 
                    SortExpression="CourseName" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:ObjectDataSource ID="CourseDataSource" runat="server" 
            SelectMethod="SelectAllCourses" 
             TypeName="VBASPNETCodeFirstCRUDInGridViewWithDetailsView.DBObjectDataSource">
        </asp:ObjectDataSource>
        <p />
        Details Edit:
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="20%" 
                CellPadding="4" ForeColor="#333333" GridLines="None" 
                AutoGenerateRows="False" DataKeyNames="CourseId" 
                DataSourceID="CourseDetailDataSource" 
                onitemupdated="DetailsView1_ItemUpdated" 
                oniteminserted="DetailsView1_ItemInserted" 
                oniteminserting="DetailsView1_ItemInserting" 
                onitemupdating="DetailsView1_ItemUpdating">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
            <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
            <Fields>
                <asp:TemplateField HeaderText="CourseId" SortExpression="CourseId">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CourseId") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                       Auto Generated after inserting the new record.
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CourseName" SortExpression="CourseName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" 
                            ErrorMessage="CourseName cannot be Empty!" ForeColor="#FF3300" 
                            ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" 
                            ErrorMessage="CourseName cannot be empty!" ForeColor="#FF3300" 
                            ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkbtnAdd" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" ValidationGroup="validate"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel" onclick="LinkButton2_Click"></asp:LinkButton>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:LinkButton ID="LinkbtnAdd" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkbtnAdd" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="New" Text="New"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:DetailsView>
            <asp:ObjectDataSource ID="CourseDetailDataSource" runat="server" 
                InsertMethod="AddNewCourse" SelectMethod="SelectCourseById" 
                 TypeName="VBASPNETCodeFirstCRUDInGridViewWithDetailsView.DBObjectDataSource"
                UpdateMethod="UpdateCourse">
                <InsertParameters>
                    <asp:Parameter Name="CourseName" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridView1" DefaultValue="1" Name="CourseId" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="CourseId" Type="Int32" />
                    <asp:Parameter Name="CourseName" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
    </div>
    </form>
    <p>
        <a href="CourseChoice.aspx" target="_self">Go To Course Choice pages</a></p>
</body>
</html>
