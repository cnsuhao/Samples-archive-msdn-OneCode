'****************************** Module Header ******************************\
' Module Name:  ErrorPage.aspx.vb
' Project:      VBASPNETIntelligentErrorPage
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to create the intelligent error page in Asp.net 
' application. In this sample, we add a custom 404 error page and find the similar 
' local resources, then display them in error page. In this way, we will improve 
' the user-experience, since users don’t need to face a boring and helpless error 
' page any more.
'
' This page is a custom 404 error page and it can find similar local resources
' by file name.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class ErrorPage
    Inherits System.Web.UI.Page

    Const xmlPath As String = "~/App_Data/XmlData.xml"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim path As String = Request.QueryString("aspxerrorpath").ToString()
        Dim fileFullName As String = path.Substring(path.LastIndexOf("/"c) + 1)
        Dim fileName As String = fileFullName.Substring(0, fileFullName.LastIndexOf("."c))
        Dim handler As New XmlHandler(Server.MapPath(xmlPath))
        Dim tab As New DataTable()
        tab = handler.GetDataItemByName(fileName)
        lvwPageList.DataSource = tab
        lvwPageList.DataBind()
    End Sub

End Class