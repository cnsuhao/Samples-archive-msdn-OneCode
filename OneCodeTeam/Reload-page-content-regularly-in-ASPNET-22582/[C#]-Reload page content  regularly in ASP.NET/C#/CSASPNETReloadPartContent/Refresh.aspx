<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Refresh.aspx.cs" Inherits="CSASPNETReloadPartContent.Refresh" %>

<div id="result">
    <asp:repeater id="rptResult" runat="Server">
            <HeaderTemplate>
 <table>
            <tr>
                <th>
                    Id
                </th>
                <th>
                    Time
                </th>
            </tr>
</HeaderTemplate>

 <ItemTemplate>
  <tr><td><%#Eval("Id")%></td><td><%# Eval("Time")%></td></tr>
</ItemTemplate> 

<FooterTemplate>
  </table>
</FooterTemplate>
       
    </asp:repeater>
</div>


    <script type="text/javascript">

        setInterval(function() {
            load()
        }, 3000);

        var load = function() {
            location.reload();       
        };  
    </script>  
