'********************************* Module Header *********************************\
' Module Name: ComposePhotoViewModel.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A view model used in the compose page.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class ComposePhotoViewModel
    Inherits PhotoViewModel
    Public Property Transition() As ITransition
        Get
            Return m_Transition
        End Get
        Set(value As ITransition)
            m_Transition = value
        End Set
    End Property
    Private m_Transition As ITransition

    Private _transitionDesigner As UserControl
    Public Property TransitionDesigner() As UserControl
        Get
            Return Me._transitionDesigner
        End Get
        Set(value As UserControl)
            If Me._transitionDesigner IsNot value Then
                Me._transitionDesigner = value
                Me.NotifyPropertyChange("TransitionDesigner")
            End If
        End Set
    End Property

    Public ReadOnly Property AvailableTransitions() As List(Of String)
        Get
            Return TransitionFactory.AvailableTransitions
        End Get
    End Property

    ''' <summary>
    ''' Clone this view model.
    ''' </summary>
    ''' <returns>A copy of this view model.</returns>
    Public Function CopyTo() As ComposePhotoViewModel
        Dim copy As New ComposePhotoViewModel() With { _
          .Name = Me.Name, _
          .PhotoDuration = Me.PhotoDuration, _
          .TransitionDuration = Me.TransitionDuration, _
          .MediaStream = Me.MediaStream _
        }
        If Me.Transition IsNot Nothing Then
            copy.Transition = Me.Transition.Clone()
        End If
        Return copy
    End Function

    ''' <summary>
    ''' Update values of this view model from a copy.
    ''' </summary>
    Public Sub CopyFrom(source As ComposePhotoViewModel)
        Me.Name = source.Name
        Me.PhotoDuration = source.PhotoDuration
        Me.TransitionDuration = source.TransitionDuration
        If source.Transition IsNot Nothing Then
            Me.Transition = source.Transition.Clone()
        End If
        Me.MediaStream = source.MediaStream
    End Sub

    ''' <summary>
    ''' Converts a model class to a view model class.
    ''' </summary>
    Public Shared Function CreateFromModel(model As Photo) As ComposePhotoViewModel
        Dim viewModel As New ComposePhotoViewModel() With { _
          .Name = model.Name, _
          .MediaStream = model.ThumbnailStream, _
          .PhotoDuration = CInt(model.PhotoDuration.TotalSeconds) _
        }
        If model.Transition IsNot Nothing Then
            viewModel.Transition = model.Transition
            viewModel.TransitionDuration = CInt(model.Transition.TransitionDuration.TotalSeconds)
        End If
        Return viewModel
    End Function

    ''' <summary>
    ''' Update the model corresponding to this view model.
    ''' </summary>
    Public Sub UpdateModel()
        Dim photoToModify As Photo = App.MediaCollection.Where(Function(p) p.Name = Me.Name).FirstOrDefault()
        If photoToModify IsNot Nothing AndAlso Me.Transition IsNot Nothing Then
            photoToModify.Transition = Me.Transition
            photoToModify.Transition.TransitionDuration = TimeSpan.FromSeconds(Me.TransitionDuration)
            photoToModify.PhotoDuration = TimeSpan.FromSeconds(Me.PhotoDuration)
        End If
    End Sub

    ''' <summary>
    '''  If the view model is removed, we need to remove the corresponding model as well.
    ''' </summary>
    Public Sub RemoveModel()
        Dim model As Photo = App.MediaCollection.Where(Function(p) p.Name = Me.Name).FirstOrDefault()
        If model IsNot Nothing Then
            model.ThumbnailStream.Close()
            App.MediaCollection.Remove(model)
        End If
    End Sub
End Class
