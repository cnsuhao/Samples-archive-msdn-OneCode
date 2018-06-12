'***************************** Module Header ******************************\
' Module Name:  InstanceControllerService.vb
' Project:      WorkerRole1
' Copyright (c) Microsoft Corporation.
' 
' This application shows how to run your cmd script or other executable
' file on each worker role instance.
'
' Implement the WCF contract.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

Imports InstanceController.Interface
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports System.ServiceModel
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient
Imports System.IO
Imports System.Collections

Public Class InstanceControllerService
    Implements IInstanceController
    ''' <summary>
    ''' Store temp file path
    ''' </summary>
    Private _filePath As String = Nothing

    ''' <summary>
    ''' Get every instance internal endpoint.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetInstanceInternalEndPoint() As List(Of String) Implements IInstanceController.GetInstanceInternalEndPoint
        Dim EndPointList As New List(Of String)()
        Trace.Write("Method start")
        Dim workerInstances = RoleEnvironment.Roles("WorkerRole1").Instances
        Trace.Write(String.Format("This App has {0} instance", workerInstances.Count))
        Try
            For Each instance In workerInstances
                EndPointList.Add(instance.InstanceEndpoints("InternalEndPoint").IPEndpoint.ToString())
            Next
            Return EndPointList
        Catch e As Exception

            EndPointList.Add(e.ToString())
            Return EndPointList
        End Try
    End Function

    ''' <summary>
    ''' Use this method run the file on your each instance
    ''' </summary>
    ''' <param name="Container"></param>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    Public Function RunScriptOnEveryInstance(Container As String, FileName As String) As Boolean Implements IInstanceController.RunScriptOnEveryInstance
        Dim internalEndpointList = GetInstanceInternalEndPoint()
        Try
            For Each internalEndpoint In internalEndpointList

                Dim binding As New BasicHttpBinding()
                Using channel As New ChannelFactory(Of IInstanceController)(binding, String.Format("http://{0}/InternalService", internalEndpoint))
                    Dim proxy As IInstanceController = channel.CreateChannel()
                    proxy.RunExecutableFile(Container, FileName)
                End Using
            Next
            Return True
        Catch e As Exception
            'TODO: Add your logic here.
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Download the file from blob storage, then excute it in local.
    ''' </summary>
    ''' <param name="Container">blob container name</param>
    ''' <param name="FileName">file name</param>
    Public Sub RunExecutableFile(Container As String, FileName As String) Implements IInstanceController.RunExecutableFile
        DownLoadFileFromBlob(Container, FileName)
        If _filePath IsNot Nothing Then
            Try

                System.Diagnostics.Process.Start(_filePath)
            Catch
                Throw New NotSupportedException("The file is not a excutable file")
            End Try
        Else
            Throw New NullReferenceException("Can't get the file from blob.")
        End If
    End Sub

    ''' <summary>
    ''' Download the file from blob storage, and store the temp file path.
    ''' </summary>
    ''' <param name="ContainerName"></param>
    ''' <param name="FileName"></param>
    Public Sub DownLoadFileFromBlob(ContainerName As String, FileName As String) Implements IInstanceController.DownLoadFileFromBlob

        Dim storageAccount As CloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"))
        Dim blobClient As CloudBlobClient = storageAccount.CreateCloudBlobClient()
        Dim container As CloudBlobContainer = blobClient.GetContainerReference(ContainerName)
        Dim directoryPath As String = CreateTempDirectory()
        _filePath = directoryPath & "\" & FileName
        Dim blockBlob As CloudBlockBlob = container.GetBlockBlobReference(FileName)

        ' Save blob contents to a file.
        Using fileStream = System.IO.File.OpenWrite(_filePath)
            blockBlob.DownloadToStream(fileStream)
        End Using
    End Sub

    ''' <summary>
    ''' Create a Temp file path to store the file download from blob.
    ''' </summary>
    ''' <returns>temp path</returns>
    Private Function CreateTempDirectory() As String
        While True
            Dim tempPath As String = Path.GetRandomFileName()
            Dim directoryPath As String = Path.Combine(Path.GetTempPath(), tempPath)

            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
                Directory.CreateDirectory(tempPath)
                Return directoryPath
            End If
        End While
        Return Nothing
    End Function

End Class