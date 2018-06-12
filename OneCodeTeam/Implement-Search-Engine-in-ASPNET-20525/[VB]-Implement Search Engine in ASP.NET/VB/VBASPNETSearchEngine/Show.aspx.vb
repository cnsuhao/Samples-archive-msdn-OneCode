'****************************** Module Header ******************************\
' Module Name:    Show.aspx.vb
' Project:        VBASPNETSearchEngine
' Copyright (c) Microsoft Corporation
'
' This page receives a parameter from Query String named "id", and then calls
' DataAccess class to retrieve an record from database and then shows it in 
' the page. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class Show
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' The record which is displaying.
    ''' </summary>
    Protected Data As Article

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim id As Long = 0

        ' Only query database in the first load and ensure the input parameter is valid.
        If Not IsPostBack _
            AndAlso Not String.IsNullOrEmpty(Request.QueryString("id")) _
            AndAlso Long.TryParse(Request.QueryString("id"), id) Then
            Dim dataAccess As New DataAccess()
            Data = dataAccess.GetArticle(id)
        End If

        ' Ensure the result is not null.
        If Data Is Nothing Then
            Data = New Article()
        End If
    End Sub
End Class