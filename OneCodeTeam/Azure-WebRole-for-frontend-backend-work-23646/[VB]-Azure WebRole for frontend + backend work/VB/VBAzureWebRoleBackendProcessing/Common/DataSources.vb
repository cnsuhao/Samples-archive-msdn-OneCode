'****************************** Module Header ******************************\
' Project Name:   VBAzureWebRoleBackendProcessing
' Module Name:    Common
' File Name:      DataSources.vb
' Copyright (c) Microsoft Corporation
'
' This class provides methods to access Table storage and Queue storage.
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
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Queue
Imports Microsoft.WindowsAzure.Storage.Table

Public Class DataSources
    Private Shared ReadOnly Property _storageAccount() As CloudStorageAccount
        Get
            Return CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"))
        End Get
    End Property

    Private _context As WordDataContext
    Private _queueStorage As CloudQueueClient
    Shared ReadOnly _queueName As String = "words"
    Public ReadOnly Property WordQuque() As CloudQueue
        Get
            Return _queueStorage.GetQueueReference(_queueName)
        End Get
    End Property

    ''' <summary>
    ''' Instantiate a new DataSources object.
    ''' This method will throw exception if the storage account is wrong.
    ''' </summary>
    Public Sub New()
        Dim client As CloudTableClient = New CloudTableClient(New Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials)
        ' Instantiate a table service context.
        _context = New WordDataContext(client)


        ' Instantiate a queue client for use.
        _queueStorage = _storageAccount.CreateCloudQueueClient()
    End Sub

    Public Function GetWordEntries() As IEnumerable(Of WordEntry)
        Dim results = From word In _context.WordEntry
                      Select word
        Return results
    End Function

    Public Function GetWordEntry(partitionKey As String, rowKey As String) As WordEntry
        Dim results = From word In _context.WordEntry
                      Where word.PartitionKey = partitionKey AndAlso word.RowKey = rowKey
                      Select word
        Return results.FirstOrDefault()
    End Function

    Public Sub AddWordEntry(newItem As WordEntry)
        _context.AddObject("WordEntry", newItem)
        _context.SaveChanges()
    End Sub

    Public Sub UpdateWordEntry(updatedItem As WordEntry)
        _context.UpdateObject(updatedItem)
        _context.SaveChanges()
    End Sub

    Public Sub QueueMessage(message As String)
        WordQuque.AddMessage(New CloudQueueMessage(message))
    End Sub

    Shared Sub New()
        ' Cancel the restart of instances when the service configuration is updated.
        AddHandler RoleEnvironment.Changing, Function(sender, e)
                                                 e.Cancel = False
                                                 Return Nothing
                                             End Function
        AddHandler RoleEnvironment.Changed, Function(sender, e)
                                                ' Initialize the storage again after the configuration is changed.
                                                initializeStorage()
                                                Return Nothing
                                            End Function

        ' Firstly Initialize the storage at the first start.
        initializeStorage()
    End Sub
    Private Shared Sub initializeStorage()

        Try
            ' Create the Table for storing words.
            Dim tableStorage As CloudTableClient = _storageAccount.CreateCloudTableClient()
            Dim table As CloudTable = tableStorage.GetTableReference("WordEntry")
            table.CreateIfNotExists()

            ' Create the queue for communication if it is not exist.
            Dim queueStorage As CloudQueueClient = _storageAccount.CreateCloudQueueClient()
            Dim queue As CloudQueue = queueStorage.GetQueueReference(_queueName)
            queue.CreateIfNotExists()
            ' This method is running in the backend.
            ' It will never crash even though there is a big error.
        Catch ex As Exception
            Trace.TraceError("Exception when processing queue item. Message: '{0}'", ex.Message)
        End Try
    End Sub
End Class