<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSASPNETPrintPartOfPage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function btnImagePrint() {
             pnlImageDiv.style.display = "block";
             pnlListDiv.style.display = "none";
             pnlSearchDiv.style.display = "none";
             window.print();
             pnlListDiv.style.display = "block";
             pnlSearchDiv.style.display = "block";
         }
         function btnListPrint() {
             pnlImageDiv.style.display = "none";
             pnlListDiv.style.display = "block";
             pnlSearchDiv.style.display = "none";
             window.print();
             pnlImageDiv.style.display = "block";
             pnlSearchDiv.style.display = "block";
         }
         function btnSearchPrint() {
             pnlImageDiv.style.display = "none";
             pnlListDiv.style.display = "none";
             pnlSearchDiv.style.display = "block";
             window.print();
             pnlListDiv.style.display = "block";
             pnlImageDiv.style.display = "block";
         }
     </script>
    <style type="text/css">
        .printButton
        {
            text-align:right;
        }
        #pnlImage
        {          
        }
        #pnlList
        {
            text-align:center;
        }
        #pnlSearch
        {  
        }
    </style>
</head>
<body>
<form id="Form1" method="post" runat="server">

<center>
<font face="Verdana" size="4">ASP.NET MVC Sample Code</font>
    <br />
<table border="0" width="90%">
<tr><td>
<p /><font face="Verdana" size="1">
The Model-View-Controller (MVC) architectural pattern separates an application into three main components:
 the model, the view, and the controller. The ASP.NET MVC framework provides an alternative to 
 the ASP.NET Web Forms pattern for creating Web applications. The ASP.NET MVC framework is a lightweight, 
 highly testable presentation framework that (as with Web Forms-based applications) is integrated with existing ASP.NET features, 
 such as master pages and membership-based authentication. The MVC framework is defined in the System.Web.Mvc assembly.  
</font>
</td>
</tr>
</table>
<br />
</center>


<center>
<div id="pnlImageDiv">
<asp:Panel ID="pnlImage" runat="server" BorderWidth="1">
<div class="printButton">
    <input id="btnImage" type="button" value="print" onclick="btnImagePrint()" />
    </div>
<table><tr><td>
    <asp:Image ID="imgPhoto" runat="server" ImageUrl="~/image/microsoft.jpg" />
    </td></tr>
</table>
</asp:Panel></div>
</center>
<br />
<center>
<div id="pnlListDiv">
<asp:Panel ID="pnlList" runat="server" BorderWidth="1">
<div class="printButton">
    <input id="btnList" type="button" value="print" onclick="btnListPrint()" />
    </div>
<table border="0" width="90%">
<tr>
<td>Title</td>
<td>Name</td>
<td>Date</td>
</tr>
<tr>
<td>sample title1</td>
<td>sample name1</td>
<td>2011-03-05</td>
</tr>
<tr>
<td>sample title2</td>
<td>sample name2</td>
<td>2011-03-06</td>
</tr>
<tr>
<td>sample title3</td>
<td>sample name3</td>
<td>2011-03-07</td>
</tr>
<tr>
<td>sample title4</td>
<td>sample name4</td>
<td>2011-03-08</td>
</tr>
<tr>
<td>sample title5</td>
<td>sample name5</td>
<td>2011-03-09</td>
</tr>
<tr>
<td>sample title6</td>
<td>sample name6</td>
<td>2011-03-10</td>
</tr>
<tr>
<td>sample title7</td>
<td>sample name7</td>
<td>2011-03-11</td>
</tr>
<tr>
<td>sample title8</td>
<td>sample name8</td>
<td>2011-03-12</td>
</tr>
</table></asp:Panel></div>
</center>
<br />
<center>
<div id="pnlSearchDiv">
<asp:Panel ID="pnlSearch" runat="server" BorderWidth="1">
<div class="printButton">
    <input id="btnSearch" type="button" value="print" onclick="btnSearchPrint()"  />
    </div>
<table>
<tr>
<td valign="top" bgcolor="#bfa57d" width="230">
    
<font face="Arial" size="3" color="white"><b>MVC Sample Code</b><br />
    <br />
    mvc<br />
    <br />
    <font size="1">Search for code<br /></font>
<asp:TextBox id="tbSearch" runat="server" width="100"/>
<asp:Button id="btnSampleSearch" runat="server" height="22" Text="Search"/>
</font>
</td>
</tr>
</table>
</asp:Panel>
</div>
</center>
<br />
</form>
</body>
</html>
