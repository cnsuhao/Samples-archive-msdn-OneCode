<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MultiFiltering.ascx.vb" Inherits="VBASPNETMultiFiltering.MultiFiltering" %>
<%@ Import Namespace="VBASPNETMultiFiltering.MultiFiltering" %>
<fieldset>

    <legend>Filtering</legend>
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
        </HeaderTemplate>

        <ItemTemplate>
            <tr style="width:100%">
                <td style="width:25%">
                    FieldName:(Type of <%#CType(Container.DataItem, [Structure]).DataType%>)
                    <br />
                    <asp:DropDownList ID="ddrFields" AutoPostBack="true" runat="server" Width="50%" DataSource='<%#CType(Container.DataItem, [Structure]).ColumnNames %>' OnSelectedIndexChanged="ddrColumnNames_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td>
                <td style="width:25%">
                    Condition:
                    <br />
                    <asp:DropDownList ID="ddrOperation" Width="50%" DataSource='<%#CType(Container.DataItem,[Structure]).Operations %>'
                     runat="server" >
                    </asp:DropDownList>
                </td>
                 <td style="width:25%">
                     Value:
                     <br />
                     <asp:TextBox ID="txtBox" runat="server" Text='<%#Eval("EqualValue") %>' >
                     </asp:TextBox>
                </td>
                <td style="width:25%">
                   Relation:
                   <br />
                   <asp:DropDownList ID="ddrRelation" runat="server" Width="50%"  DataSource='<%#CType(Container.DataItem,[Structure]).Relations %>'>
                    </asp:DropDownList>
                </td>
                <td style="width:20%">
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" />
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

   <hr />
   <table width="100%">
        <tr>
            <td style="width:50%" align="center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" 
                    onclick="btnSearch_Click" style="height: 26px" /> 
                 <asp:Button ID="btnAdd" runat="server" Text="Add Filter" 
                    onclick="btnAdd_Click" /> 
            </td>
             <td style="width:50%" align="center">
                 <asp:CheckBox ID="chkAll" runat="server" Text="All Records" Checked="true" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lbError" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
   </table>

</fieldset>