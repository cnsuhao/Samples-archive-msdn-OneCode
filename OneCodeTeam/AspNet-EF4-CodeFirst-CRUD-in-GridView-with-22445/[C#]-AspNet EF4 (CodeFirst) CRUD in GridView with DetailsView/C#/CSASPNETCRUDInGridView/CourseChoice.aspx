<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseChoice.aspx.cs"
    Inherits="ASPNETCodeFirstCRUDInGridView.CourseChooice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students'Course Choice</title>
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
        Select a Student：<asp:DropDownList ID="ddrStudents" runat="server" AutoPostBack="True"
            DataSourceID="StudentDataSource" DataTextField="StudentName" DataValueField="StudentId"
            Height="23px" Width="147px" 
            onselectedindexchanged="ddrStudents_SelectedIndexChanged">
        </asp:DropDownList>
        <a href="Students.aspx" target="_self">Add a Student</a>
        <asp:ObjectDataSource ID="StudentDataSource" runat="server" SelectMethod="SelectAllStudents"
            TypeName="ASPNETCodeFirstCRUDInGridView.DBObjectDataSource"></asp:ObjectDataSource>
    </div>
    <asp:GridView ID="GridView1" runat="server" Width="70%" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
        CellPadding="4" DataSourceID="Student_CourseDataSource" DataKeyNames="Id" 
        AllowPaging="True" onrowdeleted="GridView1_RowDeleted">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" />
            <asp:BoundField DataField="CourseName" HeaderText="CourseName" SortExpression="CourseName"
                ReadOnly="true" />
            <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Center" VerticalAlign="Middle" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <asp:ObjectDataSource ID="Student_CourseDataSource" runat="server" SelectMethod="SelectAllCoursesByStudentId"
        TypeName="ASPNETCodeFirstCRUDInGridView.DBObjectDataSource" DeleteMethod="DeleteCourseScore"
        InsertMethod="AddNewCourseAndScore" UpdateMethod="UpdateCourseScore">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sid" Type="Int32" />
            <asp:Parameter Name="cid" Type="Int32" />
            <asp:Parameter Name="score" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddrStudents" Name="StudentId" PropertyName="SelectedValue"
                Type="Int32" DefaultValue="1" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Score" Type="Double" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:Label ID="lbmsg" runat="server" 
        Text="No Rest courses for the student to choose!" ForeColor="Red"></asp:Label>
    <p>

        Choose a Course：
        <asp:DropDownList ID="ddrRestCourses" runat="server" DataSourceID="RestCourseDataSource"
            DataTextField="CourseName" DataValueField="CourseId" Height="20px" Width="138px">
        </asp:DropDownList>

        <a href="Courses.aspx" target="_self">Add a course</a>

        <asp:ObjectDataSource ID="RestCourseDataSource" runat="server" SelectMethod="SelectRestCourses"
            TypeName="ASPNETCodeFirstCRUDInGridView.DBObjectDataSource">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddrStudents" DefaultValue="1" Name="sid" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        Add a score：<asp:TextBox ID="tbScore" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbScore" Display="Dynamic" ErrorMessage="Not a valid score!" 
            ForeColor="#FF3300" ValidationExpression="\d*.\d*" ValidationGroup="validate"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbScore" ErrorMessage="Not a valid value!" 
            ForeColor="#FF3300" ValidationGroup="validate"></asp:RequiredFieldValidator>
    </p>
    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="78px" 
        OnClick="btnAdd_Click" ValidationGroup="validate" />
    </form>
</body>
</html>
