'********************************* Module Header *********************************\
' Module Name: FlyInTransition.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' An interface reprerents a transition. 
' Most code interacts with this interface rather a concrete transition class.
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

Public Interface ITransition
    ReadOnly Property Name() As String
    Property TransitionDuration() As TimeSpan
    ReadOnly Property ImageZIndexModified() As Boolean

    ' Foreground/BackgroundElement can be either Image or MediaElement.
    ' Set these properties in the PreviewPage.
    Property ForegroundElement() As FrameworkElement
    Property BackgroundElement() As FrameworkElement

    Event TransitionCompleted As EventHandler

    Function Clone() As ITransition

    ' Start/stop the transition.
    Sub Begin()
    Sub [Stop]()

    ' Serilaize/deserialize the transition.
    Sub Save(transitionElement As XElement)
End Interface
