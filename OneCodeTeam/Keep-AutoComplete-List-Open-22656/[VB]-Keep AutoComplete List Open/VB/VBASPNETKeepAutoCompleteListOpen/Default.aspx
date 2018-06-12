<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETKeepAutoCompleteListOpen._Default" %>

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
                Personal information settings
            </caption>
            <tr>
                <td colspan="4">
                    In the text box on the left fuzzy search of their favorite movies, and then select.
                </td>
            </tr>
            <tr>
                <td>
                    MovieName:
                    <asp:TextBox ID="tbMovies" runat="server" Text=''></asp:TextBox>
                </td>
                <td>
                    <input type="button" name="close" value="Close the Popup" onclick="hideOptionList();" />
                    <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" BehaviorID="ACE"
                        runat="server" TargetControlID="tbMovies" ServicePath="AutoComplete.asmx" ServiceMethod="GetMovies"
                        MinimumPrefixLength="1" CompletionInterval="10" CompletionSetCount="10" EnableCaching="true" />
                </td>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                </td>
                <td>
                    <input type="button" name="reset" value="Reset the ListBox" onclick="resetListBox();" />
                </td>
            </tr>
        </table>
    </div>

    <script src="AutoComplete.js" type="text/javascript"></script>

    </form>
</body>
</html>
