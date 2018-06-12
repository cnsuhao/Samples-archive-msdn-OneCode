'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETBreadcrumbWithQueryString
' Copyright (c) Microsoft Corporation
'
' This is the root page that shows a category list.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Show a category list.
            gvCategories.DataSource = Database.Categories
            gvCategories.DataBind()
        End If
    End Sub

End Class