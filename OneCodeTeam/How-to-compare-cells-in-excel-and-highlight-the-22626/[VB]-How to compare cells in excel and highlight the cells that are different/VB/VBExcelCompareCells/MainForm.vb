'***************************** Module Header ******************************\ 
' Module Name:   MainForm.vb
' Project:       VBExcelCompareCells
' Copyright (c)  Microsoft Corporation. 
'  
' The Class is Main Form
' Customers can manipulate the form to 
' Compare in different columns in the same sheet of an excel file and 
' Compare data in different sheets of an excel file
' 
' 
' This source is subject to the Microsoft Public License. 
' See http://www.microsoft.com/en-us/openness/licenses.aspx. 
' All other rights reserved. 
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
'**************************************************************************/


Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class MainForm

    ''' <summary>
    ''' Select Excel File
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx"
            openFileDialog.Title = "Select an excel file"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                txbExcelPath.Text = openFileDialog.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Compare Cells in different columns in the same sheet of an excel file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCompareCol_Click(sender As Object, e As EventArgs) Handles btnCompareCol.Click
        If Not File.Exists(txbExcelPath.Text) Then
            MessageBox.Show("Please Select valid path of word document!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        Dim reg As New Regex("^[A-Z]+$")
        If txbSourceCol.Text <> String.Empty AndAlso txbTargetCol.Text <> String.Empty Then
            If reg.IsMatch(txbSourceCol.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetCol.Text.ToUpper()) Then
                Try
                    Dim compareHelper As New CompareHelper
                    compareHelper.CompareColumns(txbSourceCol.Text, txbTargetCol.Text, txbExcelPath.Text)

                    ' Clean up the unmanaged Excel COM resources by explicitly
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    MessageBox.Show("Compare Columns successfully,Please check in the excel file")
                Catch ex As Exception
                    MessageBox.Show("Exception occur, the Exception Message is: " & ex.Message)
                    Return
                End Try
            Else
                MessageBox.Show("Source Column and Target Column must be letter")
                Return
            End If
        Else
            MessageBox.Show("Please input Source Column and Target Column")
            Return
        End If
    End Sub

    ''' <summary>
    ''' Compare Cells in different sheets of an excel file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCompareSheet_Click(sender As Object, e As EventArgs) Handles btnCompareSheet.Click
        If Not File.Exists(txbExcelPath.Text) Then
            MessageBox.Show("Please Select valid path of word document!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        Dim reg As New Regex("^[0-9]*$")
        If txbSourceSheet.Text <> String.Empty AndAlso txbTargetSheet.Text <> String.Empty Then
            If reg.IsMatch(txbSourceSheet.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetSheet.Text.ToUpper()) Then
                Try
                    Dim compareHelper As New CompareHelper
                    compareHelper.CompareSheets(Integer.Parse(txbSourceSheet.Text), Integer.Parse(txbTargetSheet.Text), txbExcelPath.Text)

                    ' Clean up the unmanaged Excel COM resources by explicitly
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    MessageBox.Show("Compare sheets successfully,Please check in the excel file")
                Catch ex As Exception
                    MessageBox.Show("Exception occur, the Exception Message is: " & ex.Message)
                    Return
                End Try
            Else
                MessageBox.Show("Source Sheet and Target Sheet must be Number")
                Return
            End If
        Else
            MessageBox.Show("Please input Source Sheet and Target Sheet")
            Return
        End If
    End Sub

End Class
