'****************************** Module Header ******************************\
' Module Name:  FileContext.vb
' Project:      TableStorageManager
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates a way to serve files from storage via a web role.
' A file from blob storage (such as http://xxx.cloudapp.net/files/File1) can be 
' reached as the normal files in your application by relative path ("files/File1"). 
' And this http module can also filter some files of specific types. 
'
' The FileContext class is used to create queries for table services. You can 
' also add paging method for table storage.
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

Public Class FileContext
    Inherits TableServiceContext
    Public Sub New(baseAddress As String, credentials As Microsoft.WindowsAzure.StorageCredentials)

        MyBase.New(baseAddress, credentials)
    End Sub

    ''' <summary>
    ''' Get all entities of table storage "files".
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetEntities() As IEnumerable(Of FileEntity)
        Get
            Dim list = Me.CreateQuery(Of FileEntity)("files")
            Return list
        End Get
    End Property
End Class
