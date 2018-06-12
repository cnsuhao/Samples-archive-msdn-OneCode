'***************************** Module Header ******************************\
' Module Name:  MailModel.vb
' Project:      VBAzureSendMailsByWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' As you know, System.Net.Mail api can't be used in Windows Runtime application, 
' However, we can create a WCF service to consume the api, and hold this service 
' on Azure.
' 
' In this way, we can use this service to send email in Windows Store app. 
'
' The Email Modle includes all the necessary message.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Runtime.Serialization


''' <summary>
''' An Email Modle includes all the necessary message.
''' </summary>

<DataContract()>
Public Class MailModel
#Region "Public properties"
    ''' <summary>
    ''' User's Live account Address.
    ''' </summary>
    <DataMember()>
    Public Property SourceAddress() As String
        Get
            Return m_SourceAddress
        End Get
        Set(value As String)
            m_SourceAddress = value
        End Set
    End Property
    Private m_SourceAddress As String

    ''' <summary>
    ''' Password.
    ''' </summary>
    <DataMember()>
    Public Property SourcePassword() As String
        Get
            Return m_SourcePassword
        End Get
        Set(value As String)
            m_SourcePassword = value
        End Set
    End Property
    Private m_SourcePassword As String

    ''' <summary>
    ''' The person's email address which you want to send.<br/>
    ''' If there is multiple persons you need to send change this property to a string array.
    ''' </summary>
    <DataMember()>
    Public Property TargetAddress() As String
        Get
            Return m_TargetAddress
        End Get
        Set(value As String)
            m_TargetAddress = value
        End Set
    End Property
    Private m_TargetAddress As String

    ''' <summary>
    ''' By default use "smtp.live.com" as Source Host in this sample.
    ''' </summary>
    <DataMember()>
    Public Property SourceHost() As String
        Get
            Return m_SourceHost
        End Get
        Set(value As String)
            m_SourceHost = value
        End Set
    End Property
    Private m_SourceHost As String

    ''' <summary>
    ''' Port 587 for Live smtp host.
    ''' </summary>
    <DataMember()>
    Public Property Port() As Integer
        Get
            Return m_Port
        End Get
        Set(value As Integer)
            m_Port = value
        End Set
    End Property
    Private m_Port As Integer

    ''' <summary>
    ''' Email Title.
    ''' </summary>
    <DataMember()>
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = value
        End Set
    End Property
    Private m_Title As String

    ''' <summary>
    ''' Attachement files.
    ''' </summary>
    <DataMember()>
    Public Property Attachments() As FileAttachment()
        Get
            Return m_Attachments
        End Get
        Set(value As FileAttachment())
            m_Attachments = value
        End Set
    End Property
    Private m_Attachments As FileAttachment()

    ''' <summary>
    ''' Email Content.
    ''' </summary>
    <DataMember()>
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
        End Set
    End Property
    Private m_Text As String

    ''' <summary>
    ''' If the email content formate is HTML return true, else
    ''' return false.
    ''' </summary>
    <DataMember()>
    Public Property IsBodyHtml() As Boolean
        Get
            Return m_IsBodyHtml
        End Get
        Set(value As Boolean)
            m_IsBodyHtml = value
        End Set
    End Property
    Private m_IsBodyHtml As Boolean
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Constructs an Email Modle includes all the necessary information.
    ''' </summary>
    ''' <param name="UserEmailAddress">User email address</param>
    ''' <param name="UserPassword">User password</param>
    ''' <param name="TargetAddress">Target </param>
    ''' <param name="Title">Email title</param>
    ''' <param name="Text">Email content</param>
    ''' <param name="IsBodyHtml">Email body's formate</param>
    ''' <param name="FileAttachments">Email attachments</param>
    ''' <param name="SourceHost">Email source host</param>
    ''' <param name="Port">The port for Email source host</param>
    Public Sub New(UserEmailAddress As String, UserPassword As String, TargetAddress As String, Title As String, Text As String, IsBodyHtml As Boolean, _
     FileAttachments As FileAttachment(), Optional SourceHost As String = "smtp.live.com", Optional Port As Integer = 587)
        Me.SourceAddress = UserEmailAddress
        Me.SourcePassword = UserPassword
        Me.TargetAddress = TargetAddress
        Me.Title = Title
        Me.Text = Text
        Me.IsBodyHtml = IsBodyHtml
        Me.Attachments = FileAttachments
        Me.SourceHost = SourceHost
        Me.Port = Port
    End Sub
#End Region
End Class
