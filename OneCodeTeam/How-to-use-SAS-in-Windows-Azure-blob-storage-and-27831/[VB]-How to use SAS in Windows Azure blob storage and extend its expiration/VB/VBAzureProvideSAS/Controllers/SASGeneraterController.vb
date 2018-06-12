'***************************** Module Header ******************************\
' Module Name: SASGeneraterController.vb
' Project:     SASGeneraterController
' Copyright (c) Microsoft Corporation.
' 
' To secure your Windows Azure storage, you need to generate SAS token to assign 
' user permission for CRUD. This sample will demonstrate how to generate SAS
' by using Web API, and get the SAS from client.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Net
Imports System.Web.Http
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Table

Public Class SASGeneraterController
    Inherits ApiController

    Private storageAccountName As String = "<Storage Account>"
    Private storageAccountKey As String = "<Storage Key>"
    Private tableName As String = "<Storage Table Name>"
    
    ' Post api/SASGenerater/PatitionKey
    Public Function Post(<FromBody> partitionKey As String) As String
        Dim credentials As New StorageCredentials(storageAccountName, storageAccountKey)
        Dim account As New CloudStorageAccount(credentials, True)
        Dim client = account.CreateCloudTableClient()
        Dim table = client.GetTableReference(tableName)


        Dim policy As New SharedAccessTablePolicy() With { _
             .SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(300.0), _
             .Permissions = SharedAccessTablePermissions.Add Or SharedAccessTablePermissions.Query Or SharedAccessTablePermissions.Update Or SharedAccessTablePermissions.Delete _
        }

        Dim sasToken As String = table.GetSharedAccessSignature(policy, Nothing, partitionKey, Nothing, partitionKey, Nothing)
        Return sasToken
    End Function
End Class