'****************************** Module Header ******************************\
' Module Name:  FileEntity.vb
' Project:      TableStorageManager
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates a way to serve files from storage via a web role.
' A file from blob storage (such as http://xxx.cloudapp.net/files/File1) can be 
' reached as the normal files in your application by relative path ("files/File1"). 
' And this http module can also filter some files of specific types. 
'
' This is a table storage entity class, it includes some basic properties:
' FileName,
' FileUrl
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.WindowsAzure.StorageClient

Public Class FileEntity
    Inherits TableServiceEntity
    ''' <summary>
    ''' No parameters constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        PartitionKey = "all"
        RowKey = String.Format("{0:10}-{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid()).Replace("-", "")
    End Sub

    Public Sub New(partitionKey__1 As String)
        PartitionKey = partitionKey__1
        RowKey = String.Format("{0:10}-{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid()).Replace("-", "")
    End Sub

    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(value As String)
            m_FileName = value
        End Set
    End Property
    Private m_FileName As String

    Public Property FileUrl() As String
        Get
            Return m_FileUrl
        End Get
        Set(value As String)
            m_FileUrl = value
        End Set
    End Property
    Private m_FileUrl As String
End Class
