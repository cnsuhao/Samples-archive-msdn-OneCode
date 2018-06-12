'***************************** Module Header ******************************\
' Project Name:   VBAzureWebRoleBackendProcessing
' Module Name:    Common
' File Name:      WordEntry.vb
' Copyright (c) Microsoft Corporation
'
' This class represents an entity in Table storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Microsoft.WindowsAzure.Storage.Table.DataServices

Public Class WordEntry
    Inherits TableServiceEntity
    Public Sub New()
        PartitionKey = ""
        RowKey = String.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid())
    End Sub

    Public Property Content As String
    Public Property IsProcessed As Boolean
End Class