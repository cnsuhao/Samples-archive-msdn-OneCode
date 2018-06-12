'**************************** Module Header ******************************\
' Module Name: WordAddPage.aspx.vb
' Project:     VBASPNETIntelligentTextBox
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to check the spelling written in text box 
' is correct or not. This sample code can check the user's input word 
' with word dictionary, provides some similar words for user select.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Imports System.IO

Public Class WordAddPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' Add new words
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim validateResult As String = StringValidate(tbNewWords.Text)
        If String.IsNullOrEmpty(validateResult) Then
            Dim words As String() = tbNewWords.Text.Trim().Split(","c)
            Using writer As New StreamWriter(Server.MapPath("~/Dictionary/WordList.txt"), True)
                For Each str As String In words
                    writer.WriteLine(str)
                Next
                lbMessage.Text = "Congratulations, the new word has been added in Word dictionary."
            End Using
        Else
            lbMessage.Text = validateResult
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        Response.Redirect("~/Default.aspx")
    End Sub
    ''' <summary>
    ''' String variables validation.
    ''' </summary>
    ''' <param name="strWords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function StringValidate(ByVal strWords As String) As String
        Dim words As String = strWords.Trim()
        If String.IsNullOrEmpty(words) Then
            Return "Words can not be null."
        ElseIf StringIncludeNumberic(words) Then
            Return "Words can not include numeral and special characters."
        Else
            Return String.Empty
        End If
    End Function

    Protected Shared Function StringIncludeNumberic(ByVal strWords As String) As Boolean
        Dim strRegex As String = "[^a-zA-z,']"
        Return Regex.IsMatch(strWords, strRegex)
    End Function
End Class