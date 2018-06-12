'****************************** Module Header ******************************\
'Module Name:  FileContext.vb
'Project:      TableStorageManager
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to backup Azure Storage in Cloud. Though 
'Windows Azure Platform have 3 copies for our data, but this is only physical
'backup, if a logical errors occurred that all copies of storage would been
'modified, so this sample shows how to protect our important data with code.
'
'The FileContext class is used to create queries for table services. You can 
'also add paging method for table storage.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
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

    ''' <summary>
    ''' Get all entities of table storage "files_backup".
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetBackupEntities() As IEnumerable(Of FileEntity)
        Get
            Dim list = Me.CreateQuery(Of FileEntity)("files_backup")
            Return list
        End Get
    End Property
End Class
