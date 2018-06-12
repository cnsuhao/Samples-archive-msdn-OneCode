'***************************** Module Header ******************************\
' Module Name: TableSASController.vb
' Project:     VBAzureJSLogging
' Copyright (c) Microsoft Corporation
'
' TableSASController
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports System.Net
Imports System.Web.Http
Imports System.Globalization
Imports Microsoft.WindowsAzure.Storage.Table
Imports Microsoft.WindowsAzure.Storage

Namespace Controllers
    ''' <summary>
    ''' SAS Entity
    ''' </summary>
    Public Class SAS
        Private m_sasTokenUrl As String

        Public Property SASTokenUrl() As String
            Get
                Return m_sasTokenUrl
            End Get
            Set(value As String)
                m_sasTokenUrl = value
            End Set
        End Property

    End Class
    Public Class TableSASController
        Inherits ApiController
        Private account As CloudStorageAccount = AzureClient.StorageAccount

        'Get api/tablesas
        Public Function GetTableSAS() As SAS
            Dim tableClient As CloudTableClient = account.CreateCloudTableClient()
            Dim table As CloudTable = tableClient.GetTableReference("log")
            table.CreateIfNotExists()
            Dim s As New SAS()
            s.SASTokenUrl = GetSasForTable(table)

            Return s
        End Function

        ''' <summary>
        ''' Generate a table SAS
        ''' </summary>
        ''' <param name="table">CloudTable</param>
        ''' <returns>The SAS string for the CloudTable specified</returns>
        Private Shared Function GetSasForTable(table As CloudTable) As String
            If table Is Nothing Then
                Throw New ArgumentNullException("Table can't be null")
            End If

            ' accessPolicyIdentifier 
            ' startPartitionKey 
            ' startRowKey 
            ' endPartitionKey 
            Dim sas As String = table.GetSharedAccessSignature(New SharedAccessTablePolicy() With { _
                 .Permissions = SharedAccessTablePermissions.Update Or SharedAccessTablePermissions.Query Or SharedAccessTablePermissions.Add Or SharedAccessTablePermissions.Delete, _
                 .SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30) _
            }, Nothing, Nothing, Nothing, Nothing, Nothing)
            ' endRowKey 

            Return String.Format(CultureInfo.InvariantCulture, "{0}{1}", table.Uri, sas)
        End Function

    End Class
End Namespace