'/****************************** Module Header ******************************\
' Module Name:  GetWordPlainText.vb
' Project:      VBOpenXmlGetPlainText
' Copyright(c) Microsoft Corporation.
' 
' The Class is used to read plain text from word document.
' Microsoft Word *.docx is an Open XML document combining texts, stytle,grapyhics 
' and so on into a single ZIP archive. 
' The Class uses Open XML SDK API to read XML element and filter the text. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/



Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging

Public Class GetWordPlainText
    ' Specify whether the instance is disposed.
    Private disposed As Boolean = False

    ' The word package
    Private package As WordprocessingDocument = Nothing

    ''' <summary>
    '''  Get the file name
    ''' </summary>
    Private FileName As String = String.Empty

    ''' <summary>
    '''  Initialize the WordPlainTextManager instance
    ''' </summary>
    ''' <param name="filepath"></param>
    Public Sub New(filepath As String)
        Me.FileName = filepath
        If String.IsNullOrEmpty(filepath) OrElse Not File.Exists(filepath) Then
            Throw New Exception("The file is invalid. Please select an existing file again")
        End If

        Me.package = WordprocessingDocument.Open(filepath, True)
    End Sub

    ''' <summary>
    '''  Read Word Document
    ''' </summary>
    ''' <returns>Plain Text in document </returns>
    Public Function ReadWordDocument() As String
        Dim sb As New StringBuilder()
        Dim element As OpenXmlElement = package.MainDocumentPart.Document.Body
        If element Is Nothing Then
            Return String.Empty
        End If

        sb.Append(GetPlainText(element))
        Return sb.ToString()
    End Function

    ''' <summary>
    '''  Read Plain Text in all XmlElements of word document
    ''' </summary>
    ''' <param name="element">XmlElement in document</param>
    ''' <returns>Plain Text in XmlElement</returns>
    Public Function GetPlainText(element As OpenXmlElement) As String
        Dim PlainTextInWord As New StringBuilder()
        For Each section As OpenXmlElement In element.Elements()
            Select Case section.LocalName
                ' Text
                Case "t"
                    PlainTextInWord.Append(section.InnerText)
                    Exit Select

                    ' Carriage return
                Case "cr", "br"
                    ' Page break
                    PlainTextInWord.Append(Environment.NewLine)
                    Exit Select

                    ' Tab
                Case "tab"
                    PlainTextInWord.Append(vbTab)
                    Exit Select

                    ' Paragraph
                Case "p"
                    PlainTextInWord.Append(GetPlainText(section))
                    PlainTextInWord.AppendLine(Environment.NewLine)
                    Exit Select
                Case Else

                    PlainTextInWord.Append(GetPlainText(section))
                    Exit Select
            End Select
        Next

        Return PlainTextInWord.ToString()
    End Function

#Region "IDisposable interface"

    Public Sub Dispose()
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        ' Protect from being called multiple times.
        If disposed Then
            Return
        End If

        If disposing Then
            ' Clean up all managed resources.
            If Me.package IsNot Nothing Then
                Me.package.Dispose()
            End If
        End If

        disposed = True
    End Sub
#End Region

End Class
