'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBASPNETCustomizeValidation
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use a Customized Validation control
' to do your own validations with the help of CustomValidator.
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
    ' Sql connection.
    Shared connetionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
    Private conn As New SqlConnection(connetionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs)
        ' Control To Validate: which control to type email
        Dim tb As TextBox = TryCast(Page.FindControl(CustomValidator1.ControlToValidate), TextBox)

        ' Email text
        Dim strEmail As String = tb.Text.Trim()

        ' Flag of exist
        Dim intNum As Integer = 0

        ' Regex for email.
        Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Dim re As New Regex(strRegex)

        ' Verify that whether the email format is valid or not, if valid and then query the database to check
        ' whether the email exists, otherwise set isvalid value to false.
        If re.IsMatch(strEmail) Then
            Dim cmd As New SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "select count(1) from [user] where email=@email"
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = strEmail
            cmd.CommandType = CommandType.Text
            conn.Open()
            intNum = Convert.ToInt32(cmd.ExecuteScalar())
            conn.Close()
        Else
            CustomValidator1.ErrorMessage = "Invalid Email!"
            args.IsValid = False
            Return
        End If

        ' Determine whether it exists or not
        If intNum > 0 Then
            CustomValidator1.ErrorMessage = "Cannot use the email address, because it exists!"
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' If IsValid is true then jump to another page. 
        If IsValid Then
            Response.Redirect("success.aspx")
        End If
    End Sub

End Class