'****************************** Module Header ******************************\
'Module Name:  FileDataSource.vb
'Project:      TableStorageManager
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates a way to serve files from storage via a web role.
'A file from blob storage(such as http://xxx.cloudapp.net/files/File1) can be
'reached as the normal files in your application by relative path ("files/File1").
'And this http module can also filter some specify types files.
'
'The FileDataSource package the bottom layer methods(about cloud account,
'TableServiceContext, credentials, etc).
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient

Public Class FileDataSource
    Private Shared account As CloudStorageAccount
    Private context As FileContext

    Public Sub New()
        '' Create table storage client via cloud account.
        account = CloudStorageAccount.FromConfigurationSetting("StorageConnections")
        Dim client As CloudTableClient = account.CreateCloudTableClient()
        client.CreateTableIfNotExist("files")

        '' Table context properties.
        context = New FileContext(account.TableEndpoint.AbsoluteUri, account.Credentials)
        context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1))
        context.IgnoreResourceNotFoundException = True

        context.IgnoreMissingProperties = True
    End Sub

    ''' <summary>
    ''' Get all entities method.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllEntities() As IEnumerable(Of FileEntity)
        Dim list = From m In Me.context.GetEntities
                   Select m
        Return list
    End Function

    ''' <summary>
    ''' Get table rows by partitionKey.
    ''' </summary>
    ''' <param name="partitionKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEntities(partitionKey As String) As IEnumerable(Of FileEntity)
        Dim list = From m In Me.context.GetEntities Where m.PartitionKey = partitionKey
                   Select m
        Return list
    End Function

    ''' <summary>
    ''' Get specify entity.
    ''' </summary>
    ''' <param name="partitionKey"></param>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEntitiesByName(partitionKey As String, fileName As String) As FileEntity
        Dim list = From m In Me.context.GetEntities
                   Where m.PartitionKey = partitionKey AndAlso m.FileName = fileName
                   Select m
        If list.Count() > 0 Then
            Return list.First()
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Add an entity.
    ''' </summary>
    ''' <param name="entity"></param>
    ''' <remarks></remarks>
    Public Sub AddFile(entity As FileEntity)
        Me.context.AddObject("files", entity)
        Me.context.SaveChanges()
    End Sub

    ''' <summary>
    ''' Make a judgment to check if file is exists.
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="partitionKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FileExists(filename As String, partitionKey As String) As Boolean
        Dim list As IEnumerable(Of FileEntity) = From m In Me.context.GetEntities
                                                 Where m.FileName = filename AndAlso m.PartitionKey = partitionKey
                                                 Select m
        If list.Count() > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
