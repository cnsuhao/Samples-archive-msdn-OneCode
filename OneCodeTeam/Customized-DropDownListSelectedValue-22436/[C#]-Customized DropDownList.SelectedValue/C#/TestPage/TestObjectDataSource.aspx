<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestObjectDataSource.aspx.cs" Inherits="TestPage.TestObjectDataSource" %>
<%@ Register assembly="CSASPNETSmartDropdownlist" namespace="CSASPNETSmartDropdownlist" tagprefix="yw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <yw:CustomizedDropDownList ID="customizedDropDownList" runat="server" 
            Width="127px">
        </yw:CustomizedDropDownList>
        <br />
        <asp:GridView ID="gvwDropDownListSource" runat="server" 
            onrowcommand="gvwDropDownListSource_RowCommand" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Person ID" />
                <asp:BoundField DataField="Name" HeaderText="Person Name" />
                <asp:BoundField DataField="Age" HeaderText="Person Age" />
                <asp:ButtonField CommandName="Select" Text="Select DropDownList Option" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
