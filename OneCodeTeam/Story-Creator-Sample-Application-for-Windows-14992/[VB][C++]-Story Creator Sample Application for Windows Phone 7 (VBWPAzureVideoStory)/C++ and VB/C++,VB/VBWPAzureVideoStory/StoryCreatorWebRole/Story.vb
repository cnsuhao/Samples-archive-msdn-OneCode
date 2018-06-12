'****************************** Module Header ******************************\
' Module Name:	Story.vb
' Project: StoryCreatorWebRole
' Copyright (c) Microsoft Corporation.
' 
' A model class representing a story.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class Story
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property VideoUri() As String
        Get
            Return m_VideoUri
        End Get
        Set(value As String)
            m_VideoUri = value
        End Set
    End Property
    Private m_VideoUri As String
End Class
