<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETGetSelectedValueOfAutoCompleteExtender.VBASPNETGetSelectedValueOfAutoCompleteExtender._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <AjaxControlToolkit:ToolkitScriptManager CombineScripts="false" runat="server" EnablePartialRendering="true">
    </AjaxControlToolkit:ToolkitScriptManager>        
    <div>
        <table border="1">
            <caption>
                Search Movies
            </caption>
            <tr>
                <td colspan="4">
                    You can input part or complete of the movie name, and then select one item.
                </td>
            </tr>
            <tr>
                <td>
                    MovieName:
                    <asp:TextBox ID="tbMovies" runat="server" Text=''></asp:TextBox>
                    <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" BehaviorID="ACE"
                        runat="server" TargetControlID="tbMovies" ServicePath="AutoComplete.asmx" ServiceMethod="GetMovies"
                        MinimumPrefixLength="1" CompletionInterval="10" CompletionSetCount="10" EnableCaching="true" />
                </td>
                <td>
                    <asp:GridView runat="server" ID="gdvKeyword" EnableModelValidation="True" AutoGenerateColumns="False"
                        DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                SortExpression="Id" />
                            <asp:BoundField DataField="Keywords" HeaderText="Keywords" SortExpression="Keywords" />
                            <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
        <asp:HiddenField ID="hf1" runat="server" />
    </div>

    <script src="AutoComplete.js" type="text/javascript"></script>

    </form>
</body>
</html>
