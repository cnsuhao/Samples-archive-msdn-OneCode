'****************************** Module Header ******************************\
'Module Name:  FileDataSource.vb
'Project:      TableStorageManager
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to backup Azure Storage in Cloud. Though 
'Windows Azure Platform have 3 copies for our data, but this is only physical
'backup, if a logical errors occurred that all copies of storage would been
'modified, so this sample shows how to protect our important data with code.
'
'The FileDataSource package the bottom layer methods(about cloud account,
'TableServiceContext, credentials, etc).
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
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
    Private tabName As String

    Public Sub New(tabName As String)
        '' Create table storage client via cloud account.
        Me.tabName = tabName
        account = CloudStorageAccount.FromConfigurationSetting("StorageConnections")
        Dim client As CloudTableClient = account.CreateCloudTableClient()
        client.CreateTableIfNotExist(tabName)

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
        Me.context.AddObject(Me.tabName, entity)
        Me.context.SaveChanges()
    End Sub

    ''' <summary>
    ''' Add multiple entities.
    ''' </summary>
    ''' <param name="entities"></param>
    Public Sub AddNumbersOfFiles(entities As List(Of FileEntity))
        If entities.Count() > 0 Then
            Dim totleNumbers As Integer = entities.Count()
            Dim uploadTimes As Integer = entities.Count() / 100
            If (entities.Count() Mod 100) > 0 Then
                uploadTimes += 1
            End If
            For i As Integer = 0 To uploadTimes - 1
                If i = uploadTimes - 1 Then
                    For j As Integer = i * 100 To totleNumbers - 1
                        Me.context.AddObject(Me.tabName, entities(j))
                    Next
                    Me.context.SaveChanges()
                Else
                    For j As Integer = i * 100 To (i + 1) * 100 - 1
                        Me.context.AddObject(Me.tabName, entities(j))
                    Next
                    Me.context.SaveChanges()
                End If
            Next
        End If

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
