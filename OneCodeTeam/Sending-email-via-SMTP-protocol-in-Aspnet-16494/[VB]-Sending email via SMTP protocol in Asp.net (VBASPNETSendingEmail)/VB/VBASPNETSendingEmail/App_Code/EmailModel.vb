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

    Public Property SourceAddress() As String
        Get
            Return m_SourceAddress
        End Get
        Set(ByVal value As String)
            m_SourceAddress = value
        End Set
    End Property
    Private m_SourceAddress As String

    Public Property SourcePassword() As String
        Get
            Return m_SourcePassword
        End Get
        Set(ByVal value As String)
            m_SourcePassword = value
        End Set
    End Property
    Private m_SourcePassword As String

    Public Property TargetAddress() As String
        Get
            Return m_TargetAddress
        End Get
        Set(ByVal value As String)
            m_TargetAddress = value
        End Set
    End Property
    Private m_TargetAddress As String

    Public Property SourcetHost() As String
        Get
            Return m_SourcetHost
        End Get
        Set(ByVal value As String)
            m_SourcetHost = value
        End Set
    End Property
    Private m_SourcetHost As String

    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(ByVal value As String)
            m_Title = value
        End Set
    End Property
    Private m_Title As String

    Public Property AttachmentUri() As String
        Get
            Return m_AttachmentUri
        End Get
        Set(ByVal value As String)
            m_AttachmentUri = value
        End Set
    End Property
    Private m_AttachmentUri As String

    Public Property ImageUri() As String
        Get
            Return m_ImageUri
        End Get
        Set(ByVal value As String)
            m_ImageUri = value
        End Set
    End Property
    Private m_ImageUri As String

    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
        End Set
    End Property
    Private m_Text As String

End Class
