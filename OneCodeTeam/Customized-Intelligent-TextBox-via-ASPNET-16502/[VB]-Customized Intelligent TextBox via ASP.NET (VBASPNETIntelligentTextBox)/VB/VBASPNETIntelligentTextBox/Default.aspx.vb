'****************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETIntelligentTextBox
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to check the spelling written in text box 
' is correct or not. This sample code can checks the user's input word 
' with word dictionary, provides some similar words for user select.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.IO

Partial Public Class _Default
    Inherits System.Web.UI.Page
    ' Define some public variables for load word dictionary event.
    Shared LineList As New ArrayList()
    Public StringNumber As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Use StreamReader to load word dictionary , store them in an ArrayList.
        Dim dictionaryFilePath As String = Page.Server.MapPath("~/Dictionary/WordList.txt")
        Using fileStream As New StreamReader(dictionaryFilePath)
            If fileStream Is Nothing Then
                Return
            End If
            Dim readLine As String = String.Empty
            StringNumber = 0
            While readLine IsNot Nothing
                readLine = fileStream.ReadLine()
                If Not String.IsNullOrEmpty(readLine) Then
                    LineList.Add(readLine.Replace("'", "'"))
                    StringNumber += 1
                End If
            End While
        End Using
        StringNumber = LineList.Count
        Session("LineList") = LineList
    End Sub

    ''' <summary>
    ''' This method is used to call check user's input word and returns some recommended words.
    ''' A JavsScript function will invoke this method to execute server-side code,
    ''' This will bring many benefits, such as when user input words and the application will
    ''' update recommended word list without page refresh, it can provide more responsive.
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    <System.Web.Services.WebMethod()> _
    Public Shared Function ReturnHtmlString(ByVal key As String) As String

        ' Define an ArrayList to retrieve word list, 
        ' the Dictionary use to record similar words.
        Dim list As ArrayList = LineList
        Dim matchEntity As New Dictionary(Of Integer, String())()
        Dim sortID As Integer = 0
        Dim highLevel As Integer = 0
        ' Loop the word dictionary, compare with source word. 
        For i As Integer = 0 To list.Count - 1
            ' Confirm the word length, calculate word's similar level and 
            ' move the cursor to next character.
            Dim source As String = list(i).ToString()
            Dim sourceLength As Integer = list(i).ToString().Length
            Dim keyLength As Integer = key.Length
            Dim matchLength As Integer = (If((sourceLength > keyLength), keyLength, sourceLength))
            Dim matchLevel As Integer = 0
            Dim cursor As Integer = 0
            While cursor < matchLength
                If source(cursor) = key(cursor) Then
                    matchLevel += 1
                    cursor += 1
                ElseIf matchLevel >= 1 Then
                    cursor += 1
                Else
                    matchLevel = 0
                    Exit While
                End If
            End While
            If matchLevel >= 1 Then
                Dim entity As String() = New String(3) {}
                entity(0) = matchLevel.ToString()
                entity(1) = source
                entity(2) = sourceLength.ToString()
                matchEntity.Add(sortID, entity)
                If matchLevel > highLevel Then
                    highLevel = matchLevel
                End If
                sortID += 1
            End If
        Next
        Dim highLevelList = From d In matchEntity Where (d.Value(0) = highLevel.ToString()) Select d


        ' Sort the result with the highest similar level and characters' length.
        ' And we must make sure the recommended word list must include 10 words.
        If highLevelList.ToList().Count <= 10 Then
            Dim listNumber As Integer = highLevelList.ToList().Count
            Dim returnHtml As String = String.Empty
            Dim sortMatchList = From d In highLevelList Order By Convert.ToInt32(d.Value(2)) Select d
            For Each s In sortMatchList
                returnHtml += "<li onclick='getValue(this)'>" + s.Value(1) & "</li>"
                matchEntity.Remove(s.Key)
                listNumber += 1
            Next
            Dim lowLevelList = matchEntity.OrderByDescending(Function(d) d.Value(0))
            Dim number As Integer = 0
            For Each s In lowLevelList
                If number < (10 - listNumber) Then
                    returnHtml += "<li onclick='getValue(this)'>" + s.Value(1) & "</li>"
                    number += 1
                Else
                    Exit For
                End If
            Next
            Return returnHtml
        Else
            Dim listNumber As Integer = 0
            Dim returnHtml As String = String.Empty
            Dim sortMatchList = From d In highLevelList Order By Convert.ToInt32(d.Value(2))  Select d
            For i As Integer = 0 To sortMatchList.ToList().Count - 1
                If listNumber < 10 Then
                    returnHtml += "<li onclick='getValue(this)'>" + sortMatchList.ToList()(i).Value(1) & "</li>"
                    listNumber += 1
                Else
                    Exit For
                End If
            Next
            Return returnHtml
        End If
    End Function

End Class