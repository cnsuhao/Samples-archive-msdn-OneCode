'**************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETAccessResourceInAssembly
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to access user controls and web pages from class
' library via virtual path. Here we inherit VirtualPathProvider and VirtualFile 
' class for creating a custom path provider. In VBASPNETAccessResourceAssembly,
' we can load embed resource files use specify virtual path in assembly.
' 
' This web form page use to load normal web pages and user controls in this 
' application, it also load embed web pages and user controls in assembly.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Add relative web pages and user controls in assembly and this application.
        Dim tab As DataTable = Me.InitializeDataTable()
        If tab IsNot Nothing AndAlso tab.Rows.Count <> 0 Then
            For i As Integer = 0 To tab.Rows.Count - 1
                Dim control As Control = Page.LoadControl(tab.Rows(i)("UserControlUrl").ToString())
                Dim usercontrol As UserControl = TryCast(control, UserControl)
                Page.Controls.Add(usercontrol)
                Dim link As New HyperLink()
                link.NavigateUrl = tab.Rows(i)("WebPageUrl").ToString()
                link.Text = tab.Rows(i)("WebPageText").ToString()
                Page.Controls.Add(link)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Initialize a DataTable variable for storing URL and text properties. 
    ''' </summary>
    ''' <returns></returns>
    Protected Function InitializeDataTable() As DataTable
        Dim tab As New DataTable()
        Dim userControlUrl As New DataColumn("UserControlUrl", Type.[GetType]("System.String"))
        tab.Columns.Add(userControlUrl)
        Dim webPageUrl As New DataColumn("WebPageUrl", Type.[GetType]("System.String"))
        tab.Columns.Add(webPageUrl)
        Dim webPageText As New DataColumn("WebPageText", Type.[GetType]("System.String"))
        tab.Columns.Add(webPageText)
        Dim dr As DataRow = tab.NewRow()
        dr("UserControlUrl") = "~/Assembly/VBASPNETAssembly.dll/VBASPNETAssembly.WebUserControl.ascx"
        dr("WebPageUrl") = "~/Assembly/VBASPNETAssembly.dll/VBASPNETAssembly.WebPage.aspx"
        dr("WebPageText") = "Assembly/WebPage"
        Dim drWebSite As DataRow = tab.NewRow()
        drWebSite("UserControlUrl") = "~/WebSite/WebUserControl.ascx"
        drWebSite("WebPageUrl") = "~/WebSite/WebPage.aspx"
        drWebSite("WebPageText") = "WebSite/WebPage"
        tab.Rows.Add(dr)
        tab.Rows.Add(drWebSite)
        Return tab
    End Function
End Class