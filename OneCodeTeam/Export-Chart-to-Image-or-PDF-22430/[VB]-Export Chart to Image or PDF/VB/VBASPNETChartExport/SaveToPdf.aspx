<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SaveToPdf.aspx.vb" Inherits="VBASPNETChartExport.SaveToPdf" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <asp:Chart ID="myChart" runat="server" Height="400px" Width="500px">
            <Series>
                <asp:Series Name="Series1" ChartType="Column" ChartArea="ChartArea1">
                </asp:Series>
                <asp:Series Name="Series2" ChartType="Column" ChartArea="ChartArea1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Button ID="btnSave" runat="server" Text="Save to Pdf" OnClick="btnSave_Click" />
    </div>
    </form>
</body>
</html>
