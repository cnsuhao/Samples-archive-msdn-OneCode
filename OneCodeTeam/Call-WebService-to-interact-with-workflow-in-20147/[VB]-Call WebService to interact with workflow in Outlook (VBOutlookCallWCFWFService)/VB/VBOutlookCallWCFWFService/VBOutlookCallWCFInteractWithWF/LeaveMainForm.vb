'/****************************** Module Header ******************************\
' Module Name:   LeaveMainForm.vb
' Project:       VBOutlookCallWCFInteractWithWF
' Copyright (c)  Microsoft Corporation.
' 
' The Leave Main Form. It calls WCF service to interact with workflow.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports System.Windows.Forms
Imports VBOutlookCallWCFInteractWithWF.ServiceReference1

Public Class LeaveMainForm

    ' Initialize a new instance of Service Client 
    Private leaveclient As New LeaveServiceClient()

    ' Constructor function
    Public Sub New()
        InitializeComponent()
        BindListView()
    End Sub

    ''' <summary>
    ''' Get pending list from database and bind the list to ListView control 
    ''' </summary>
    Private Sub BindListView()
        lstViewPendingLeaves.Items.Clear()
        Dim itemsource As New ListViewItem()
        Dim leaves As Leave() = leaveclient.GetLeaveList()
        For Each l In leaves
            Dim item As New ListViewItem()
            item.SubItems.Add(l.LeaveID.ToString())
            item.SubItems.Add(l.LeaveName)
            item.SubItems.Add(l.LeaveDay.ToString())
            item.SubItems.Add(l.Comment)
            item.SubItems.Add(l.Status)
            lstViewPendingLeaves.Items.Add(item)
        Next
    End Sub

    ''' <summary>
    ''' Create a Leave WorkFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrWhiteSpace(tbName.Text) OrElse String.IsNullOrWhiteSpace(tbDay.Text) Then
            MessageBox.Show("Name or Day cann't be empty")
            Return
        End If

        Try
            leaveclient.CreateLeave(tbName.Text.Trim(), tbDay.Text.Trim())

            ' Clear input argument
            tbName.Clear()
            tbDay.Clear()
            MessageBox.Show("Create Leave request successfully.")
            BindListView()
        Catch ex As Exception
            MessageBox.Show("Exception occurs, The exception is :" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Approve leave request
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If lstViewPendingLeaves.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a Leave Request to approve or reject", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim leaveGuid As String = lstViewPendingLeaves.SelectedItems(0).SubItems(1).Text
            leaveclient.AuditingLeave(leaveGuid, "Yes")
            MessageBox.Show("Approve Successfully")
            BindListView()
        Catch ex As Exception
            MessageBox.Show("Exception occurs, The exception is :" + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reject leave request
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If lstViewPendingLeaves.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a Leave Request to approve or reject", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim leaveGuid As String = lstViewPendingLeaves.SelectedItems(0).SubItems(1).Text
            leaveclient.AuditingLeave(leaveGuid, "No")
            MessageBox.Show("Reject Successfully")
            BindListView()
        Catch ex As Exception
            MessageBox.Show("Exception occurs, The exception is :" + ex.Message)
        End Try
    End Sub

End Class