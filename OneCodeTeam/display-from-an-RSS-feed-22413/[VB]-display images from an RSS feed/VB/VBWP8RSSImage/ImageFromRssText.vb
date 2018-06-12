'****************************** Module Header ******************************\
' Module Name:    ImageFromRssText.vb
' Project:        VBWP8RSSImage
' Copyright (c) Microsoft Corporation
'
' This demo shows how to display images from an RSS feed.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Windows.Data
Imports System.Text.RegularExpressions

Public Class ImageFromRssText
    Implements IValueConverter

    ' Get images from each SyndicationItem. 
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        If value Is Nothing Then
            Return Nothing
        End If

        Dim listUri As List(Of ImageItem) = GetHtmlImageUrlList(value.ToString())
        Return listUri
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function

    ''' <summary> 
    ''' Get the URL of the all pictures from the HTML. 
    ''' </summary> 
    ''' <param name="sHtmlText">HTML code</param> 
    ''' <returns>URL list of the all pictures</returns>       
    Public Shared Function GetHtmlImageUrlList(sHtmlText As String) As List(Of ImageItem)
        ' The definition of a regular expression to match img tag. 
        Dim regImg As New Regex("<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase)

        ' The search for a matching string.
        Dim matches As MatchCollection = regImg.Matches(sHtmlText)
        Dim i As Integer = 0
        Dim imgUrlList As New List(Of ImageItem)()

        ' Get a list of matches
        For Each match As Match In matches
            imgUrlList.Add(New ImageItem("img" & i, match.Groups("imgUrl").Value))
            i += 1
        Next
        Return imgUrlList
    End Function

    ''' <summary>
    ''' Image entity
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ImageItem
        Public Sub New(title As String, url As String)
            Me.Title = title
            Me.URL = url
        End Sub

        Public Property Title() As String
            Get
                Return m_Title
            End Get
            Set(value As String)
                m_Title = value
            End Set
        End Property
        Private m_Title As String
        Public Property URL() As String
            Get
                Return m_URL
            End Get
            Set(value As String)
                m_URL = value
            End Set
        End Property
        Private m_URL As String
    End Class
End Class
