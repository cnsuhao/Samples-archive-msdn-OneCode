'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBASPNETCensorKeywordInSite
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to filter some indecent words in website.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Data.SqlClient

Partial Public Class _Default
    Inherits System.Web.UI.Page

    ' Sql Connection
    Private Shared conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sample.mdf;Integrated Security=True;User Instance=True")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


    End Sub

    Protected Sub btnEnter_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String = tbText.Text
        str = str.Trim()
        ' Remove the spaces and format symbols in the data
        Dim str1 As String = str.Replace(" ", "")

        Dim isBool As Boolean = ValidByReg(str1)

        If isBool Then
            ltrMsg.Text = str
        Else
            ltrMsg.Text = ReplacDirty(str)
        End If
    End Sub

    ' The list of KeyBlack，such as：dirtyStr1|dirtyStr2|dirtyStr3
    Public Shared dirtyStr As String = ""

    Public Function ReplacDirty(ByVal str As String) As String
        dirtyStr = ReadDic()
        Try
            str = Regex.Replace(str, "" & dirtyStr & "", "xxxxx")
            ' Syntax error in the regular expression
        Catch ex As ArgumentException
        End Try
        Return str
    End Function


    Private Function ReadDic() As String
        Dim input As [String] = ""

        ' Query string
        Dim queryString As String = "SELECT [Name] FROM [WordBlack]"

        ' set query string
        Dim command As New SqlCommand(queryString, conn)

        ' Open connection
        conn.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                input += "|" & TryCast(reader("Name"), String).Trim()
            End While
            input = input.Substring(1)
        End If
        reader.Close()

        ' Close connection
        conn.Close()
        Return input

    End Function

    Public Function ValidByReg(ByVal str As String) As Boolean
        dirtyStr = ReadDic()
        ' Regular expression used to detect dirty dictionary
        Dim validateReg As New Regex("^((?!" & dirtyStr & ").(?<!" & dirtyStr & "))*$", RegexOptions.Compiled Or RegexOptions.ExplicitCapture)

        Return validateReg.IsMatch(str)
    End Function

End Class