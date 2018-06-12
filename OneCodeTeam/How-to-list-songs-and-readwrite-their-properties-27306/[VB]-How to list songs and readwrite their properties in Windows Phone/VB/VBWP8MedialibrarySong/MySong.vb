'****************************** Module Header ******************************\
' Module Name:    MySong.vb
' Project:        VBWP8MedialibrarySong
' Copyright (c) Microsoft Corporation
'
' This class is used to store the Song and its Uri.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports Microsoft.Xna.Framework.Media
 
Public Class MySong
    ''' <summary>
    ''' The song which is added by custom app.
    ''' </summary>
    Private _song As Song
    Public Property song() As Song
        Get
            Return _song
        End Get
        Set(value As Song)
            _song = value
        End Set
    End Property

    ''' <summary>
    ''' The path of the song.
    ''' </summary>
    Private m_filePath As Uri
    Public Property FilePath() As Uri
        Get
            Return m_filePath
        End Get
        Set(value As Uri)
            m_filePath = value
        End Set
    End Property

    ''' <summary>
    ''' The original Song name.
    ''' </summary>
    Private m_fileName As String
    Public Property FileName() As String
        Get
            Return m_fileName
        End Get
        Set(value As String)
            m_fileName = value
        End Set
    End Property

    Public Sub New(song As Song, filename As String, fileUri As Uri)
        Me._song = song
        Me.FileName = filename
        Me.FilePath = fileUri
    End Sub
End Class

