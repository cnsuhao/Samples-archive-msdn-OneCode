'*********************************** Module Header ***********************************\
' Module Name:  WorkerRole.vb
' Project:  VideoEncodingWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' The Worker Role that encodes the video.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.WindowsAzure.StorageClient
Imports System.IO
Imports StoryDataModel

Public Class WorkerRole
    Inherits RoleEntryPoint
    Private _storageAccount As CloudStorageAccount
    Private _container As CloudBlobContainer
    Private _queue As CloudQueue
    Public Overrides Sub Run()
        Trace.WriteLine("VideoEncodingWorkerRole entry point called", "Information")

        ' Obtain the local storage paths.
        Dim localStorageRoot As String = RoleEnvironment.GetLocalResource("PhotoStore").RootPath
        Dim diagnosticsRoot As String = RoleEnvironment.GetLocalResource("DiagnosticStore").RootPath
        While True
            Try
                ' Get a message from the queue.
                Dim message As CloudQueueMessage = Me._queue.GetMessage(TimeSpan.FromMinutes(20.0))
                If message IsNot Nothing Then
                    Dim storyID As String = message.AsString

                    ' This story can't be encoded...
                    If message.DequeueCount > 3 Then
                        Trace.Write("∂Ã”∞ " & storyID & "has been unable to be processed for too many times.", "Error")
                        Me._queue.DeleteMessage(message)
                    Else
                        Trace.Write("Begin to process story " & storyID & ".", "Information")

                        Dim storyFolderPath As String = Path.Combine(localStorageRoot, storyID)
                        Directory.CreateDirectory(storyFolderPath)

                        ' Download the xml configuration file.
                        Dim blob As CloudBlob = Me._container.GetBlobReference(storyID & ".xml")
                        Dim config As String = blob.DownloadText()
                        Dim xdoc As XDocument = XDocument.Parse(config)
                        Dim storyName As String = xdoc.Root.Attribute("Name").Value
                        For Each photo In xdoc.Root.Elements("Photo")
                            ' Download the photo, and save it in local storage.
                            Dim photoBlobUri As String = photo.Attribute("Uri").Value
                            Dim photoBlob As CloudBlob = Me._container.GetBlobReference(photoBlobUri)
                            Dim localPhotoFilePath As String = Path.Combine(localStorageRoot, storyID, photo.Attribute("Name").Value)
                            photoBlob.DownloadToFile(localPhotoFilePath)

                            ' Modify the Name of the photo to include the full path.
                            photo.Attribute("Name").Value = localPhotoFilePath
                        Next

                        ' Save the config file to local storage.
                        Dim configFilePath As String = Path.Combine(localStorageRoot, storyID & ".xml")
                        xdoc.Save(configFilePath, SaveOptions.None)

                        ' Encode the video.
                        Dim outputFilePath As String = Path.Combine(localStorageRoot, storyID & ".mp4")
                        Dim logFilePath As String = Path.Combine(diagnosticsRoot, storyID & ".log")
                        Dim hr As Integer = NativeMethods.EncoderVideo(configFilePath, outputFilePath, logFilePath)
                        If hr <> 0 Then
                            Trace.Write("Error when encoding the story " & storyID & ". HRESULT from the native component is: " & hr & ".", "Error")
                        Else
                            ' Upload the result video to blob.
                            Dim blobName As String = storyID & "/"
                            blobName += If(String.IsNullOrEmpty(storyName), storyID, storyName)
                            blobName += ".mp4"
                            Dim outputBlob As CloudBlob = Me._container.GetBlobReference(blobName)
                            outputBlob.UploadFile(outputFilePath)
                            outputBlob.Properties.ContentType = "video/mp4"
                            outputBlob.SetProperties()

                            Dim storyDataContext As New StoryDataContext(Me._storageAccount.TableEndpoint.AbsoluteUri, Me._storageAccount.Credentials)
                            storyDataContext.AddObject("Stories", New Story(storyID, storyName, outputBlob.Uri.AbsoluteUri))
                            storyDataContext.SaveChanges()

                            ' Delete the local files.
                            File.Delete(configFilePath)
                            File.Delete(outputFilePath)
                            For Each fileName As String In Directory.GetFiles(storyFolderPath)
                                File.Delete(fileName)
                            Next
                            Directory.Delete(storyFolderPath)

                            Me._queue.DeleteMessage(message)

                            ' TODO: Should we delete the story's config file and photos from blob?

                            Trace.Write("Story " & storyID & " successfully encoded.", "Information")
                        End If
                    End If
                End If
            Catch ex As Exception
                Trace.Write("Error processing story: " + ex.Message)
            End Try

            Thread.Sleep(10000)
        End While
    End Sub

    Public Overrides Function OnStart() As Boolean

        ' Set the maximum number of concurrent connections 
        ServicePointManager.DefaultConnectionLimit = 12

        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

        ' Intilialize the storage if they haven't been intialized already.
        CloudStorageAccount.SetConfigurationSettingPublisher(Function(configName, configSetter)
                                                                 configSetter(RoleEnvironment.GetConfigurationSettingValue(configName))

                                                             End Function)
        Me._storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString")
        Dim blobClient As New CloudBlobClient(Me._storageAccount.BlobEndpoint, Me._storageAccount.Credentials)
        Me._container = blobClient.GetContainerReference("videostories")
        Me._container.CreateIfNotExist()
        Me._container.SetPermissions(New BlobContainerPermissions() With { _
          .PublicAccess = BlobContainerPublicAccessType.Blob _
        })
        Dim queueClient As New CloudQueueClient(Me._storageAccount.QueueEndpoint, Me._storageAccount.Credentials)
        Me._queue = queueClient.GetQueueReference("videostories")
        Me._queue.CreateIfNotExist()
        Dim tableClient As New CloudTableClient(Me._storageAccount.TableEndpoint.AbsoluteUri, Me._storageAccount.Credentials)
        tableClient.CreateTableIfNotExist("Stories")

        ' Configure diagnostics.
        Dim config = DiagnosticMonitor.GetDefaultInitialConfiguration()
        config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(10.0)
        config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(10.0)
        config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(10.0)
        config.Directories.DataSources.Add(New DirectoryConfiguration() With { _
          .Path = RoleEnvironment.GetLocalResource("DiagnosticStore").RootPath, _
          .Container = "videostorydiagnosticstore", _
          .DirectoryQuotaInMB = 200 _
        })
        config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(10.0)
        Microsoft.WindowsAzure.Diagnostics.CrashDumps.EnableCollection(True)
        DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", config)
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironment_Changing

        Return MyBase.OnStart()

    End Function

    Private Sub RoleEnvironment_Changing(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.OfType(Of RoleEnvironmentConfigurationSettingChange)().Count() > 0 Then
            e.Cancel = True
        End If
    End Sub
End Class
