'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETAddDynamicControltoGridView
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to add dynamic LinkButton in Gridview.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Namespace VBASPNETAddDynamicControltoGridView
    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            gdvCustomer.DataBind()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                AddLinkButton()
            End If
        End Sub

        ''' <summary>
        ''' To initialize the page.
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
        End Sub

        ''' <summary>
        ''' Add a LinkButton To GridView Row.
        ''' </summary>
        Private Sub AddLinkButton()
            For Each row As GridViewRow In gdvCustomer.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim lb As New LinkButton()
                    lb.Text = "Approve"
                    lb.CommandName = "ApproveVacation"
                    AddHandler lb.Command, AddressOf LinkButton_Command
                    row.Cells(0).Controls.Add(lb)
                End If
            Next
        End Sub

        Protected Sub LinkButton_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
            If e.CommandName = "ApproveVacation" Then
                Dim lb As LinkButton = DirectCast(sender, LinkButton)
                lb.Text = "OK"
            End If
        End Sub

        Protected Sub gdvCustomer_DataBound(ByVal sender As Object, ByVal e As EventArgs)
            AddLinkButton()
        End Sub
    End Class
End Namespace