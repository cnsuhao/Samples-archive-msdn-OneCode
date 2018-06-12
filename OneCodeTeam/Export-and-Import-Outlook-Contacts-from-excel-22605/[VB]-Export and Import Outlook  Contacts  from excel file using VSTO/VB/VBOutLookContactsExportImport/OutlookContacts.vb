'/****************************** Module Header ******************************\
' Module Name:  OutlookContacts.vb
' Project:      VBOutLookContactsExportImport
' Copyright (c) Microsoft Corporation.
' 
' The main form of Exporting/Import outlook contacts 
' Click "Export" button to export the outlook contacts to the excel file
' 
' Import outlook contacts form excel spreadsheet as following steps:
' First select an excel spreadsheet to import
' Then Click "Import" button to import the contacts into outlook 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Imports System.IO

Public Class OutlookContacts
    ' Initialize OutlookProvider Object
    Private outlook As New OutlookProvider()

    ' Define connecting string
    Private connectingstr As String = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Import contacts from Excel spreadsheet
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            If tbxImportExcel.Text = String.Empty Then
                MessageBox.Show("Please select an Excel spreadsheet to import!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                Return
            End If

            ' Initialize Connecting String
            connectingstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbxImportExcel.Text & ";Extended Properties='Excel 12.0 Xml;HDR=Yes'"

            ' call import method to import contacts into outlook
            outlook.ContactsImportFromExcel(connectingstr)
            MessageBox.Show("Import success!")
        Catch ex As Exception
            MessageBox.Show("Import Exception is: " + ex.Message, "Exception")
        End Try
    End Sub

    ''' <summary>
    ''' Select excel spreadsheet to import
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBrowseImp_Click(sender As Object, e As EventArgs) Handles btnBrowseImp.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath
            openFileDialog.Filter = "All files (*.*)|*.*"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                tbxImportExcel.Text = openFileDialog.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Export outlook contacts to excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Exported excel file path
        Dim exportpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ContactsExport.xlsx"

        ' Initialize Connecting String
        Dim connectingstr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & exportpath & ";Extended Properties='Excel 12.0 Xml;HDR=Yes'"
        Try
            If File.Exists(exportpath) Then
                ' If the excel file has existed in directory
                ' Delete the existing excel and create a new excel file to store the contacts.
                File.Delete(exportpath)
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            Else
                outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems)
            End If

            MessageBox.Show("Export success! Exported file path is: " & exportpath)
        Catch ex As Exception
            MessageBox.Show("Export Exception is: " + ex.Message, "Exception")
        End Try
    End Sub

End Class
