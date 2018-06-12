'****************************** Module Header ******************************\
'Module Name:  StringValidation.vb
'Project:      VBASPNETSendingEmail
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to send an email with attachments and embedded
'images using SMTP protocol in Asp.net. This is a very common issue in forums, 
'customers always fall into troubles when they try to implement relative APIs,
'that is because they receive many errors or exceptions, so we provide this 
'sample code to show how to send an email with your web application, and this 
'sample also demonstrates how to send emails asynchronously for improving 
'user experience.
'
'This class is used to create an simple string variables validation and email
'string variable validation.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class StringValidation
    ''' <summary>
    ''' Email information validation.
    ''' </summary>
    ''' <param name="model"></param>
    ''' <returns></returns>
    Public Function Validation(ByVal model As EmailModel) As String
        If [String].IsNullOrEmpty(model.SourceAddress) Then
            Return EmailModel.__SourceAddress + " is null"
        End If
        If [String].IsNullOrEmpty(model.SourcePassword) Then
            Return EmailModel.__SourcePassword + " is null"
        End If
        If [String].IsNullOrEmpty(model.TargetAddress) Then
            Return EmailModel.__TargetAddress + " is null"
        End If
        If [String].IsNullOrEmpty(model.SourcetHost) Then
            Return EmailModel.__SourcetHost + " is null"
        End If
        If [String].IsNullOrEmpty(model.Title) Then
            Return EmailModel.__Title + " is null"
        End If
        If [String].IsNullOrEmpty(model.AttachmentUri) Then
            Return EmailModel.__AttachmentUri + " is null"
        End If
        If [String].IsNullOrEmpty(model.ImageUri) Then
            Return EmailModel.__ImageUri + " is null"
        End If
        If [String].IsNullOrEmpty(model.Text) Then
            Return EmailModel.__Text + " is null"
        End If
        If Not ValidEmail(model.SourceAddress) Then
            Return EmailModel.__SourceAddress + " is invalid."
        End If
        If Not ValidEmail(model.TargetAddress) Then
            Return EmailModel.__TargetAddress + " is invalid."
        End If
        Return [String].Empty
    End Function

    ''' <summary>
    ''' Email string variable Regular Expression
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function ValidEmail(ByVal email As String) As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(email, "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" & "|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function

End Class
