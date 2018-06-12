'****************************** Module Header ******************************\
'Module Name:  EmailModel.vb
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
'This is an email entity class with basic properties.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class EmailModel
    Public Const __SourceAddress As String = "Your Email Address"

    Public Const __SourcePassword As String = "Your Email Password"

    Public Const __TargetAddress As String = "Target Email Address"

    Public Const __SourcetHost As String = "SMTP server host"

    Public Const __Title As String = "Email Title"

    Public Const __AttachmentUri As String = "Attachment URI"

    Public Const __ImageUri As String = "Image URI"

    Public Const __Text As String = "Email Text"

    Public Property SourceAddress As String

    Public Property SourcePassword As String

    Public Property TargetAddress As String

    Public Property SourcetHost As String

    Public Property Title As String

    Public Property AttachmentUri As String

    Public Property ImageUri As String

    Public Property Text As String
End Class
