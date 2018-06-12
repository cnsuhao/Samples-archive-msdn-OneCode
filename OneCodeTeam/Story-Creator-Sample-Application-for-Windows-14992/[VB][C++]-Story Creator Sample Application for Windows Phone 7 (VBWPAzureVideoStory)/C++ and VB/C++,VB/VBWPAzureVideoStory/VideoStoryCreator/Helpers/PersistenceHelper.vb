'********************************* Module Header *********************************\
' Module Name: PersistenceHelper.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A helper class that serializes/deserializes the story to/from xml.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.IO.IsolatedStorage
Imports Microsoft.Xna.Framework.Media
Imports System.IO
Imports System.Xml.Linq


Public NotInheritable Class PersistenceHelper
    ''' <summary>
    ''' Serialize the story to xml, and store it in isolated storage.
    ''' </summary>
    Friend Shared Sub StoreData()
        If Not String.IsNullOrEmpty(App.CurrentStoryName) Then
            Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            Using fileStream As IsolatedStorageFileStream = userStore.CreateFile(App.CurrentStoryName + ".xml")
                ' Serialize the story, and save it.
                SerializeStory().Save(fileStream)
            End Using

            ' Save the current story name.
            Using fileStream As IsolatedStorageFileStream = userStore.OpenFile("CurrentStory.txt", System.IO.FileMode.OpenOrCreate)
                Using writer As New StreamWriter(fileStream)
                    writer.Write(App.CurrentStoryName)
                End Using
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Read the xml file from isolated storage, and deserialize it to a story.
    ''' </summary>
    Friend Shared Sub RestoreData()
        Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()

        ' Read the current story name.
        If userStore.FileExists("CurrentStory.txt") Then
            Using fileStream As IsolatedStorageFileStream = userStore.OpenFile("CurrentStory.txt", System.IO.FileMode.Open)
                Using reader As New StreamReader(fileStream)
                    App.CurrentStoryName = reader.ReadToEnd()
                End Using
            End Using
        End If

        ' If the current story is found, load it.
        If Not String.IsNullOrEmpty(App.CurrentStoryName) AndAlso userStore.FileExists(App.CurrentStoryName + ".xml") Then
            ReadStoryFile(App.CurrentStoryName, userStore)
        End If
    End Sub

    ''' <summary>
    ''' Read the specified story file.
    ''' </summary>
    ''' <param name="storyName">The story name.</param>
    ''' <param name="userStore">If this parameter is null, we will create one.</param>
    Friend Shared Sub ReadStoryFile(storyName As String, Optional userStore As IsolatedStorageFile = Nothing)
        If userStore Is Nothing Then
            userStore = IsolatedStorageFile.GetUserStoreForApplication()
        End If
        Using fileStream As IsolatedStorageFileStream = userStore.OpenFile(storyName & ".xml", System.IO.FileMode.Open)
            Dim xdoc As XDocument = XDocument.Load(fileStream)
            Dim mediaLibrary As New MediaLibrary()
            Dim picturesLibrary = mediaLibrary.Pictures
            App.MediaCollection.Clear()

            ' Load all photos.
            For Each photoElement As XElement In xdoc.Root.Elements()
                Try
                    Dim photo As New Photo() With { _
                      .Name = photoElement.Attribute("Name").Value _
                    }
                    Dim photoDurationString As String = photoElement.Attribute("PhotoDuration").Value
                    Dim photoDuration As Integer = Integer.Parse(photoDurationString)
                    photo.PhotoDuration = TimeSpan.FromSeconds(photoDuration)
                    Dim transitionElement As XElement = photoElement.Element("Transition")
                    If transitionElement IsNot Nothing Then
                        photo.Transition = TransitionBase.Load(photoElement.Element("Transition"))
                    End If
                    Dim picture As Picture = picturesLibrary.Where(Function(p) p.Name = photo.Name).FirstOrDefault()
                    If picture Is Nothing Then
                        ' Cannot find the original photo file. Possibly it has been deleted.
                        ' TODO: Should we log the error? Should we continue with the next photo or throw an excpetion?
                        Continue For
                    End If
                    photo.ThumbnailStream = picture.GetThumbnail()
                    App.MediaCollection.Add(photo)
                Catch
                    ' TODO: Should we log the error? Should we continue with the next photo or throw an excpetion?
                    Continue For
                End Try
            Next
            mediaLibrary.Dispose()
        End Using
    End Sub

    ''' <summary>
    '''  Serializes the current story.
    '''  We only serialize story data, such as each photo's duration.
    '''  We don't serialize the underlying bitmap.
    ''' </summary>
    ''' <returns>An XDocument that describes the current story</returns>
    Friend Shared Function SerializeStory() As XDocument
        Dim xdoc As New XDocument(New XElement("Story", New XAttribute("Name", App.CurrentStoryName), New XAttribute("PhotoCount", App.MediaCollection.Count)))

        ' Save each photo as an xml element.
        For Each photo As Photo In App.MediaCollection
            Dim photoElement As New XElement("Photo")
            photoElement.Add(New XAttribute("Name", photo.Name))
            photoElement.Add(New XAttribute("PhotoDuration", photo.PhotoDuration.TotalSeconds))
            If photo.Transition IsNot Nothing Then
                Dim transitionElement As New XElement("Transition")
                photo.Transition.Save(transitionElement)
                photoElement.Add(transitionElement)
            End If
            xdoc.Root.Add(photoElement)
        Next
        Return xdoc
    End Function

    ''' <summary>
    ''' Enumerate all saved stories, and returns the story names.
    ''' </summary>
    ''' <returns>A list contains the name of each story, without the .xml extension.</returns>
    Friend Shared Function EnumerateStories() As List(Of String)
        Dim userStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Return (From f In userStore.GetFileNames() Where f.EndsWith(".xml") Select f.Substring(0, f.Length - 4)).ToList()
    End Function
End Class
