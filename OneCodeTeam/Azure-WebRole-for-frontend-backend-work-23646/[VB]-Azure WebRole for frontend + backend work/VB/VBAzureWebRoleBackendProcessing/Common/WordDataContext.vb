'****************************** Module Header ******************************\
' Project Name:   VBAzureWebRoleBackendProcessing
' Module Name:    Common
' File Name:      WordDataContext.vb
' Copyright (c) Microsoft Corporation
'
' This class represents a System.Data.Services.Client.DataServiceContext object 
' for use with the Windows Azure Table service.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Storage.Table
Imports Microsoft.WindowsAzure.Storage.Table.DataServices


Public Class WordDataContext
    Inherits TableServiceContext
    Public Sub New(client As CloudTableClient)
        MyBase.New(client)
    End Sub

    Public ReadOnly Property WordEntry() As IQueryable(Of WordEntry)
        Get
            Return Me.CreateQuery(Of WordEntry)("WordEntry")
        End Get
    End Property
End Class