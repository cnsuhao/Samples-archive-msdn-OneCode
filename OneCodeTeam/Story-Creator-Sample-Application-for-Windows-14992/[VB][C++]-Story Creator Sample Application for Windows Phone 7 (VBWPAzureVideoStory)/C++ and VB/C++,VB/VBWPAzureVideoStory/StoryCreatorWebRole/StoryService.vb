'****************************** Module Header ******************************\
' Module Name:	StoryService.vb
' Project: StoryCreatorWebRole
' Copyright (c) Microsoft Corporation.
' 
' A WCF REST service built with Web API.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.ServiceModel
Imports System.Net.Http
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports Microsoft.WindowsAzure.StorageClient
Imports System.ServiceModel.Web
Imports System.Xml
Imports StoryDataModel

<ServiceContract()>
Public Class StoryService
    ''' <summary>
    ''' Create a new story resource.
    ''' </summary>
    <WebInvoke(Method:="POST", UriTemplate:="")> _
    Public Function Post(request As HttpRequestMessage) As HttpResponseMessage
        '  Make sure the storage account is ready.
        If Global_asax.StorageAccount Is Nothing Then
            If Not Global_asax.InitializeStorage() Then
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The service is unavailable at the moment. Please try again later.")
            End If
        End If

        Try
            ' Request body.
            Dim docSource As XDocument = XDocument.Parse(request.Content.ReadAsString())

            ' Response body.
            Dim docResult As New XDocument(New XElement("Story"))


            Dim photos = docSource.Root.Elements("Photo")
            Dim photoElementsCount As Integer = photos.Count()
            If photos.Count() < 2 Then
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "A story requires at least 2 photos.")
            End If

            Dim photoCount As Integer = 0
            Try
                photoCount = Integer.Parse(docSource.Root.Attribute("PhotoCount").Value)
            Catch
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The request body is not well formatted. The required attribute PhotoCount of element Story is either missing or incorrect.")
            End Try

            If photoElementsCount <> photoCount Then
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The request body is not well formatted. The value of PhotoCount doesn't equal to count of the Photo elements.")
            End If

            Dim blobClient As New CloudBlobClient(Global_asax.StorageAccount.BlobEndpoint, Global_asax.StorageAccount.Credentials)
            Dim container As CloudBlobContainer = blobClient.GetContainerReference("videostories")

            ' The unique ID that represents the story.
            Dim id As String = Guid.NewGuid().ToString()
            Dim configBlob As CloudBlob = container.GetBlobReference(id & ".xml")
            docResult.Root.Add(New XAttribute("ID", id))

            For Each photo As XElement In photos
                Dim name As String = photo.Attribute("Name").Value

                ' Construct SAS. The start time is set to 1 minute earlier,
                ' to make sure the client is able to upload the blob.
                Dim blob As CloudBlob = container.GetBlobReference(id & "/" & name)
                Dim sas As String = blob.GetSharedAccessSignature(New SharedAccessPolicy() With { _
                  .Permissions = SharedAccessPermissions.Write, _
                  .SharedAccessStartTime = DateTime.Now.AddMinutes(-1.0), _
                  .SharedAccessExpiryTime = DateTime.Now.AddHours(0.5) _
                })

                ' Create an empty blob, so clients can upload to the correct blob.
                blob.UploadText("")

                ' Modify the original configuration. Add URI without SAS.
                photo.Add(New XAttribute("Uri", blob.Uri.AbsoluteUri))

                ' Add the Photo element to the response, including SAS.
                Dim fullUri As String = blob.Uri.AbsoluteUri & sas
                docResult.Root.Add(New XElement("Photo", New XAttribute("Name", name), New XAttribute("Uri", fullUri)))
            Next

            ' Store the config in blob storage.
            configBlob.UploadText(docSource.ToString())

            Trace.Write("Story configuraion created: " & configBlob.Uri.ToString(), "Information")

            ' Return the success response.
            Return Me.CreateXmlResponse(HttpStatusCode.Created, docResult.ToString())
        Catch generatedExceptionName As XmlException
            Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The request body is not a well formatted xml document.")
        Catch ex As StorageClientException
            Trace.Write("Error dealing with blob: " + ex.Message, "Error")
            Return Me.CreateStringResponse(HttpStatusCode.InternalServerError, "The service is unavailable at the moment. Please try again later.")
        End Try
    End Function

    ''' <summary>
    ''' Update a story resource.
    ''' Currently the only update is to commit the story (indicates we can start to encode the video).
    ''' </summary>
    <WebInvoke(Method:="PUT", UriTemplate:="{id}?commit={commit}")> _
    Public Function Put(request As HttpRequestMessage, id As String, commit As System.Nullable(Of Boolean)) As HttpResponseMessage
        ' Make sure the storage account is ready.
        If Global_asax.StorageAccount Is Nothing Then
            If Not Global_asax.InitializeStorage() Then
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The service is unavailable at the moment. Please try again later.")
            End If
        End If
        If String.IsNullOrEmpty(id) Then
            Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "Required parameter id is missing.")
        End If
        If commit Is Nothing OrElse Not commit.Value Then
            Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "Currently only ""commit=true""  option is supported.")
        End If

        Try
            Dim blobClient As New CloudBlobClient(Global_asax.StorageAccount.BlobEndpoint, Global_asax.StorageAccount.Credentials)
            Dim container As CloudBlobContainer = blobClient.GetContainerReference("videostories")
            Dim configBlob As CloudBlob = container.GetBlobReference(id & ".xml")

            ' We do not actually need those attributes. We simply check if the blob exists or not.
            ' If the blob doesn't exist, a StorageClientException will be thrown, so we jump to the catch block.
            configBlob.FetchAttributes()

            ' Add the job to queue.
            Dim queueClient As New CloudQueueClient(Global_asax.StorageAccount.QueueEndpoint, Global_asax.StorageAccount.Credentials)
            Dim queue As CloudQueue = queueClient.GetQueueReference("videostories")
            queue.AddMessage(New CloudQueueMessage(id))

            ' Return an empty successful message.

            Return Me.CreateStringResponse(HttpStatusCode.NoContent, "")
        Catch ex As StorageClientException
            If ex.StatusCode = HttpStatusCode.NotFound Then
                Return Me.CreateStringResponse(HttpStatusCode.NotFound, "The requested story does not exist.")
            End If

            ' General error, trace and return a genric message.
            Trace.Write("Error dealing with blob: " + ex.Message, "Error")
            Return Me.CreateStringResponse(HttpStatusCode.InternalServerError, "The service is unavailable at the moment. Please try again later.")
        End Try
    End Function

    <WebGet(UriTemplate:="")> _
    Public Function [Get](request As HttpRequestMessage) As HttpResponseMessage
        ' Make sure the storage account is ready.
        If Global_asax.StorageAccount Is Nothing Then
            If Not Global_asax.InitializeStorage() Then
                Return Me.CreateStringResponse(HttpStatusCode.BadRequest, "The service is unavailable at the moment. Please try again later.")
            End If
        End If

        Try
            Dim storyDataContext As New StoryDataContext(Global_asax.StorageAccount.TableEndpoint.AbsoluteUri, Global_asax.StorageAccount.Credentials)

            ' Query the table storage.
            Dim query = From s In storyDataContext.Stories

            ' convert the result to a simplified class that doesn't contain partition/row key.
            Dim stories As New List(Of Story)()
            For Each s As StoryDataModel.Story In query
                stories.Add(New Story() With { _
                  .Name = s.Name, _
                  .VideoUri = s.VideoUri _
                })
            Next
            Dim jsonSerializer As New DataContractJsonSerializer(GetType(List(Of Story)))
            Using stream As New MemoryStream()
                jsonSerializer.WriteObject(stream, stories)
                stream.Position = 0
                Using reader As New StreamReader(stream)
                    Dim result As String = reader.ReadToEnd()
                    Return Me.CreateJsonResponse(HttpStatusCode.OK, result)
                End Using
            End Using
        Catch ex As StorageClientException
            If ex.StatusCode = HttpStatusCode.NotFound Then
                Return Me.CreateStringResponse(HttpStatusCode.NotFound, "The requested story does not exist.")
            End If

            ' General error, trace and return a genric message.
            Trace.Write("Error dealing with table service: " + ex.Message, "Error")
            Return Me.CreateStringResponse(HttpStatusCode.InternalServerError, "The service is unavailable at the moment. Please try again later.")
        Catch ex2 As Data.EvaluateException
            Trace.Write("Error dealing with table service: " + ex2.Message, "Error")
            Return Me.CreateStringResponse(HttpStatusCode.InternalServerError, "The service is unavailable at the moment. Please try again later.")
        End Try
    End Function

    Private Function CreateStringResponse(statusCode As HttpStatusCode, body As String) As HttpResponseMessage
        Dim response As New HttpResponseMessage()
        response.StatusCode = statusCode
        response.Content = New StringContent(body)
        Return response
    End Function

    Private Function CreateXmlResponse(statusCode As HttpStatusCode, body As String) As HttpResponseMessage
        Dim response As New HttpResponseMessage()
        response.StatusCode = statusCode
        response.Content = New StringContent(body, Encoding.UTF8, "text/xml")
        Return response
    End Function

    Private Function CreateJsonResponse(statusCode As HttpStatusCode, body As String) As HttpResponseMessage
        Dim response As New HttpResponseMessage()
        response.StatusCode = statusCode
        response.Content = New StringContent(body, Encoding.UTF8, "application/json")
        Return response
    End Function
End Class
