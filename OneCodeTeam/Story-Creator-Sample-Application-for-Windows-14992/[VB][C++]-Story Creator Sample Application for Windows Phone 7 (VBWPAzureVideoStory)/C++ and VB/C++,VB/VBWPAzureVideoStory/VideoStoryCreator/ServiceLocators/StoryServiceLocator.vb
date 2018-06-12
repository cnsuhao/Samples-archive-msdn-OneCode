'********************************* Module Header *********************************\
' Module Name: StoryServiceLocator.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' This doesn't actually implement the service locator pattern.
' But this class encapsulates all logic to access the REST service,
' so UI components no longer have direct dependencies on the service.
' This is kind of dependency injection.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Xml.Linq
Imports System.IO
Imports System.Threading

Public Class StoryServiceLocator
    ' The base URI of our cloud REST service.
    ' Change to your cloud service address if you want to test aginst cloud.
    'private string _baseServiceUri = "http://127.0.0.1:81/stories";
    Private _baseServiceUri As String = "http://storycreator.cloudapp.net/stories"
    Private _storyID As String

    ' The following fileds are used when uploading the photos to blob storage.
    ' We need to wait until all photos are uploaded, and then commit the story.
    Private _allPhotoCount As Integer = 0
    Private _uploadedPhotoCount As Integer = 0
    Private _uploadFailed As Boolean = False
    Private _lockObject As New Object()

    Public Event StoryUploaded As EventHandler

    Public Sub UploadStory()
        ' Create and upload the story configuration file.
        Dim storyConfig As XDocument = PersistenceHelper.SerializeStory()
        Dim webClient As New WebClient()
        AddHandler webClient.UploadStringCompleted, AddressOf UploadConfigCompleted
        webClient.UploadStringAsync(New Uri(Me._baseServiceUri), storyConfig.ToString())
    End Sub

    Private Sub UploadConfigCompleted(sender As Object, e As UploadStringCompletedEventArgs)
        If e.[Error] IsNot Nothing Then
            ' TODO: Log errors...
            MessageBox.Show("Cannot connect to the service at the moment. Please try again later.")
        Else
            Try
                ' The response is an xml document containing the blob SAS for each photo.
                Dim resultXDoc As XDocument = XDocument.Parse(e.Result)
                Me._storyID = resultXDoc.Root.Attribute("ID").Value
                Dim photoElements = resultXDoc.Root.Elements("Photo")

                SyncLock Me._lockObject
                    Me._allPhotoCount = photoElements.Count()
                End SyncLock

                ' Create a background thread, which waits until all photos are uploaded.
                ' Then it commits the story.
                Dim thread As New System.Threading.Thread(New ThreadStart(AddressOf Me.WaitUntilAllPhotosUploaded))
                thread.Start()

                For Each photoElement In photoElements
                    Dim name As String = photoElement.Attribute("Name").Value
                    Dim blobUri As String = photoElement.Attribute("Uri").Value

                    ' Find the photo in the current story.
                    Dim photo As Photo = App.MediaCollection.Where(Function(p) p.Name = name).FirstOrDefault()
                    If photo Is Nothing Then
                        Throw New InvalidOperationException("Cannot find the photo.")
                    End If
                    If photo.ResizedImageStream Is Nothing Then
                        photo.ResizedImageStream = BitmapHelper.GetResizedImage(photo.Name)
                    End If

                    ' Upload the photo to blob.
                    photo.ResizedImageStream.Position = 0

                    Dim policy As New RetryPolicy(blobUri)
                    policy.RequestAddress = blobUri
                    policy.Initialize = New Action(Function()
                                                       policy.Request.Method = "PUT"

                                                   End Function)
                    policy.RequestCallback = New AsyncCallback(Function(requestStreamResult)
                                                                   Dim requestStream As Stream = policy.Request.EndGetRequestStream(requestStreamResult)
                                                                   Dim buffer As Byte() = New Byte(photo.ResizedImageStream.Length - 1) {}
                                                                   photo.ResizedImageStream.Position = 0
                                                                   photo.ResizedImageStream.Read(buffer, 0, buffer.Length)
                                                                   requestStream.Write(buffer, 0, buffer.Length)
                                                                   requestStream.Close()

                                                               End Function)

                    policy.ResponseCallback = New AsyncCallback(Function(responseResult)
                                                                    Dim response As HttpWebResponse = DirectCast(policy.Request.EndGetResponse(responseResult), HttpWebResponse)
                                                                    If response.StatusCode <> HttpStatusCode.Created Then
                                                                        Throw New InvalidOperationException("上传失败")
                                                                    End If
                                                                    SyncLock Me._lockObject
                                                                        Me._uploadedPhotoCount += 1
                                                                    End SyncLock

                                                                End Function)
                    policy.MakeRequest()
                Next
            Catch
                ' TODO: Log errors...

                SyncLock Me._lockObject
                    Me._uploadFailed = True
                End SyncLock
                MessageBox.Show("Cannot upload photos at the moment. Please try again later.")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Should be invoked on a background thread
    ''' Waits until all photos are uploaded.
    ''' Then it commits the story.
    ''' </summary>
    Private Sub WaitUntilAllPhotosUploaded()
        While True
            SyncLock Me._lockObject
                ' All photos have been uploaded or something went wrong. So break the wait.
                If (Me._allPhotoCount = Me._uploadedPhotoCount) OrElse (Me._uploadFailed = True) Then
                    Exit While
                End If
            End SyncLock
            Thread.Sleep(3000)
        End While
        If Not Me._uploadFailed Then
            Dim requestUri As String = Me._baseServiceUri & "/" & Me._storyID & "?commit=true"
            Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUri), HttpWebRequest)
            request.Method = "PUT"
            request.BeginGetRequestStream(Sub(requestStreamResult)
                                              Dim requestStream As Stream = request.EndGetRequestStream(requestStreamResult)

                                              ' No request body is needed.
                                              requestStream.Close()
                                              request.BeginGetResponse(Sub(responseResult)
                                                                           Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(responseResult), HttpWebResponse)
                                                                           If response.StatusCode <> HttpStatusCode.NoContent Then
                                                                               Throw New InvalidOperationException("上传失败.")
                                                                           Else
                                                                               RaiseEvent StoryUploaded(Me, EventArgs.Empty)
                                                                           End If

                                                                       End Sub, Nothing)

                                          End Sub, Nothing)
        End If
    End Sub
End Class
