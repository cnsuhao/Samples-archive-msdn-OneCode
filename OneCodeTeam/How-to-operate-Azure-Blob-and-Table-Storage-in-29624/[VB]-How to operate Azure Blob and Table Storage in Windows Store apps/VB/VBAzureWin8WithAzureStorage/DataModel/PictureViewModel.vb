'**************************** Module Header ******************************\
' Module Name:	PictureViewModel.vb
' Project:		VBAzureWin8WithAzureStorage
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to store images to Windows Azure Blob storage,
' and save image information to table storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/
Imports Microsoft.WindowsAzure.Storage.Table

Public Class PictureViewModel
    Private entity As DynamicTableEntity

    Public Sub New()
        'TODO:This username should be changed to User account in real app
        Me.entity = New DynamicTableEntity() With { _
             .PartitionKey = "UserName", _
             .RowKey = DateTime.Now.ToFileTime().ToString() _
        }
    End Sub

    Public Property Name() As String
        Get
            Return entity.Properties("FileName").StringValue
        End Get
        Set(value As String)
            entity.Properties.Add(New KeyValuePair(Of String, EntityProperty)("FileName", New EntityProperty(value)))
        End Set
    End Property
    Public Property PictureUrl() As String
        Get
            Return entity.Properties("ImageUrl").StringValue
        End Get
        Set(value As String)
            entity.Properties.Add(New KeyValuePair(Of String, EntityProperty)("ImageUrl", New EntityProperty(value)))
        End Set
    End Property

    Public Property Description() As String
        Get
            Return entity.Properties("Description").StringValue
        End Get
        Set(value As String)
            entity.Properties.Add(New KeyValuePair(Of String, EntityProperty)("Description", New EntityProperty(value)))
        End Set
    End Property

    Public Property PictureTableEntity() As DynamicTableEntity
        Get
            Return entity
        End Get
        Set(value As DynamicTableEntity)
            entity = value
        End Set
    End Property
    Public Property PictureFile() As StorageFile
        Get
            Return m_PictureFile
        End Get
        Set(value As StorageFile)
            m_PictureFile = value
        End Set
    End Property
    Private m_PictureFile As StorageFile
End Class