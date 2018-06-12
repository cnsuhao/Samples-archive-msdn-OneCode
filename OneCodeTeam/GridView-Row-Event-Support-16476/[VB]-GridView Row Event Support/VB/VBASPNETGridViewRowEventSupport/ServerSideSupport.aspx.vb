
'****************************** Module Header ******************************\
' Module Name:    ServerSideSupport.aspx.vb
' Project:        VBASPNETGridViewRowEventSupport
' Copyright (c) Microsoft Corporation
'
' The page shows how to add GridView RowEvent Support on ServerSide.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Partial Public Class ServerSideSupport
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Register the postback or callback data for validation. 
    ''' </summary>
    ''' <param name="writer"></param>
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        For i As Integer = 0 To gvCustomer.Rows.Count - 1
            ClientScript.RegisterForEventValidation(gvCustomer.UniqueID, "Edit$" & i)
        Next
        MyBase.Render(writer)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub gvCustomer_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvCustomer.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Returns a string that can be used in a client event to cause postback to the server
            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(DirectCast(sender, Control), "Edit$" & e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub gvCustomer_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles gvCustomer.RowEditing
        'Set the edit index.
        gvCustomer.EditIndex = e.NewEditIndex
    End Sub
End Class