'/****************************** Module Header ******************************\
' Module Name:  OutlookProvider.vb
' Project:      VBOutLookContactsExportImport
' Copyright (c) Microsoft Corporation.
' 
' Wrapper class for Outlook operation
' Using ContactsItems to get all contacts in outlook and then export the collection to excel
'  
' Using a DataTable, and then import the DataTable to outlook
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Imports Microsoft.Office.Interop.Outlook

Public Class OutlookProvider
    ' Define Outlook Application Object
    Private ReadOnly outlook As Application

    ''' <summary>
    ''' Constructor
    ''' Create an instance of the Outlook Application Object 
    ''' </summary>
    Public Sub New()
        outlook = New Application()
    End Sub

    ''' <summary>
    ''' Collection of Contacts Items
    ''' </summary>
    Public ReadOnly Property ContactsItems() As IEnumerable(Of ContactItem)
        Get
            Dim folder As MAPIFolder = outlook.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderContacts)
            Dim contacts As IEnumerable(Of ContactItem) = folder.Items.OfType(Of ContactItem)()

            ' Get Collection ordered by LastName
            Dim query = From contact In contacts Order By contact.LastName Select contact
            Return query
        End Get
    End Property

    ''' <summary>
    ''' Export Outlook contacts to Excel.
    ''' </summary>
    ''' <param name="strConn">Connecting String</param>
    ''' <param name="contacts">Collection of Outlook Contacts Items</param>
    Public Sub ContactsExportToExcel(strConn As String, contacts As IEnumerable(Of ContactItem))
        Using conn As New OleDbConnection(strConn)
            ' Create a new sheet in the Excel spreadsheet.
            Using cmd As New OleDbCommand("Create table Contact(FirstName varchar(50), LastName varchar(50),EmailAddress varchar(50),EmailDisplayName varchar(50))", conn)
                ' Open the connection.
                conn.Open()

                ' Execute the OleDbCommand.
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO Contact(FirstName,LastName,EmailAddress,EmailDisplayName) values (@FirstName,@LastName,@EmailAddress,@EmailDisplayName)"

                ' Add the parameters.
                cmd.Parameters.Add(New OleDbParameter("@FirstName", OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter("@LastName", OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter("@EmailAddress", OleDbType.VarChar))
                cmd.Parameters.Add(New OleDbParameter("@EmailDisplayName", OleDbType.VarChar))

                For Each dr As ContactItem In contacts
                    cmd.Parameters("@FirstName").Value = If((dr.FirstName Is Nothing), String.Empty, dr.FirstName)
                    cmd.Parameters("@LastName").Value = If((dr.LastName Is Nothing), String.Empty, dr.LastName)
                    cmd.Parameters("@EmailAddress").Value = If((dr.Email1Address Is Nothing), String.Empty, dr.Email1Address)
                    cmd.Parameters("@EmailDisplayName").Value = If((dr.Email1DisplayName Is Nothing), String.Empty, dr.Email1DisplayName)

                    ' Insert the data into the Excel spreadsheet.
                    cmd.ExecuteNonQuery()
                Next
            End Using
        End Using

    End Sub

    ''' <summary>
    ''' Retrieve data from the Excel spreadsheet.
    ''' </summary>
    ''' <param name="strConn">Connecting String</param>
    ''' <returns>DataTable Data</returns>
    Public Function RetrieveData(strConn As String) As DataTable
        Dim dtExcel As New DataTable()

        Using conn As New OleDbConnection(strConn)
            ' Initialize an OleDbDataAdapter object.
            Using da As New OleDbDataAdapter("Select * from [Contact$]", conn)
                ' Fill the DataTable with data from the Excel spreadsheet.
                da.Fill(dtExcel)
            End Using
        End Using

        Return dtExcel
    End Function

    ''' <summary>
    ''' Import Contacts into Outlook Contacts from Excel spreadsheet
    ''' </summary>
    ''' <param name="strConn"></param>
    Public Sub ContactsImportFromExcel(strConn As String)
        ' Get the contacts data from Excel files 
        Dim dtexcel As DataTable = RetrieveData(strConn)

        ' foreach Rows of DataTable
        For Each r As DataRow In dtexcel.Rows
            ' Create ContactItem
            Dim c As ContactItem = outlook.CreateItem(OlItemType.olContactItem)
            c.MessageClass = "IPM.Contact"
            c.FirstName = r(0).ToString()
            c.LastName = r(1).ToString()
            c.Email1Address = r(2).ToString()
            c.Email1DisplayName = r(3).ToString()

            ' Save ContactItem
            c.Save()
        Next
    End Sub

End Class
