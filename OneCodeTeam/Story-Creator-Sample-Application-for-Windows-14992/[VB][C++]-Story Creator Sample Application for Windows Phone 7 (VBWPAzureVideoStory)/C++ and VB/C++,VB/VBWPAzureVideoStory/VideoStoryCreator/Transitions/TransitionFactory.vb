'********************************* Module Header *********************************\
' Module Name: TransitionFactory.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A factory class used to create transitions and their designers.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class TransitionFactory
    Private Shared _transitionNameTypes As New Dictionary(Of String, Type)()
    Private Shared _transitionNameDesigners As New Dictionary(Of String, Type)()
    Private Shared _transitionNames As New List(Of String)()

    Shared Sub New()
        _transitionNameTypes.Add("Fade Transition", GetType(FadeTransition))
        _transitionNames.Add("Fade Transition")

        _transitionNameTypes.Add("Fly In Transition", GetType(FlyInTransition))
        _transitionNameDesigners.Add("Fly In Transition", GetType(FlyInTransition_Design))

        ' Register additional transitions here...
        _transitionNames.Add("Fly In Transition")
    End Sub

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Create a transition based on its name.
    ''' </summary>
    ''' <param name="name">The transition's name.</param>
    ''' <returns>An ITransition object.</returns>
    Public Shared Function CreateTransition(name As String) As ITransition
        If _transitionNameTypes.ContainsKey(name) Then
            Dim transitionType As Type = _transitionNameTypes(name)
            Try
                Return TryCast(Activator.CreateInstance(transitionType), ITransition)
                ' TODO: Should we throw the exception or simply return null?
            Catch
            End Try
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' For now, by default we create a fade transition.
    ''' </summary>
    Public Shared Function CreateDefaultTransition() As ITransition
        Return New FadeTransition()
    End Function

    ''' <summary>
    ''' Create a transition designer based on its name.
    ''' </summary>
    ''' <param name="name">The transition's name.</param>
    ''' <returns>UserControl. All designers must inherite from UserControl.</returns>
    Public Shared Function CreateTransitionDesigner(name As String) As UserControl
        If _transitionNameDesigners.ContainsKey(name) AndAlso _transitionNameDesigners(name) IsNot Nothing Then
            Dim transitionDeginerType As Type = _transitionNameDesigners(name)
            Try
                Return TryCast(Activator.CreateInstance(transitionDeginerType), UserControl)
                ' Todo: Should we throw the exception or simply return null?
            Catch
            End Try
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Return a list of transition names.
    ''' </summary>
    Public Shared ReadOnly Property AvailableTransitions() As List(Of String)
        Get
            Return _transitionNames
        End Get
    End Property
End Class
