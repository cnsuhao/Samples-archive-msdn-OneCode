'****************************** Module Header ******************************\
' Project Name:   VBAzureWebRoleBackendProcessing
' Module Name:    WebRole
' File Name:      Default.aspx.vb
' Copyright (c) Microsoft Corporation
'
' This page submits words to Table storage and displays result.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports VBAzureWebRoleBackendProcessing.Common

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        ' Add a new record.
        Dim entry As New WordEntry() With { .Content = tbContent.Text }

        Dim ds As New DataSources()
        ds.AddWordEntry(entry)
        ds.QueueMessage([String].Format("{0},{1}", entry.PartitionKey, entry.RowKey))

        tbContent.Text = String.Empty
    End Sub

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        ' Display results.
        Dim ds As New DataSources()
        dlResult.DataSource = ds.GetWordEntries()
        dlResult.DataBind()
    End Sub

End Class