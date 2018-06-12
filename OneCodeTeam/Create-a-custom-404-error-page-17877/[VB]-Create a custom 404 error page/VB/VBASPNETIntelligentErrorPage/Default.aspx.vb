'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBASPNETIntelligentErrorPage
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to create the intelligent error page in Asp.net 
' application. In this sample, we add a custom 404 error page and find the similar 
' local resources, then display them in error page. In this way, we will improve 
' the user-experience, since users don’t need to face a boring and helpless error 
' page any more.
'
' This page is used to display available and unavailable web resources,
' the useless links will be redirected to ErrorPage.aspx.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class _Default
    Inherits System.Web.UI.Page
    Const xmlPath As String = "~/App_Data/XmlData.xml"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim tab As New DataTable()
            Dim handler As New XmlHandler(Server.MapPath(xmlPath))
            tab = handler.GetOpenData()
            If tab IsNot Nothing AndAlso tab.Rows.Count <> 0 Then
                lvwPageList.DataSource = tab
                lvwPageList.DataBind()
            Else
                Response.Write("Sorry, the xml file is null or the path is error.")
            End If
        End If
    End Sub

End Class