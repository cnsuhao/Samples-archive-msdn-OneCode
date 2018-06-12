'****************************** Module Header ******************************\
'Module Name:  Default.aspx.vb
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
'This web form page shows a form with input controls and can send e-mails by 
'SMTP client.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Net.Mail
Imports System.Net
Imports System.Net.Mime
Imports System.ComponentModel

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Sending e-mail message.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
        Dim model As New EmailModel()
        Dim validation As New StringValidation()
        model.SourceAddress = tbEmailAddress.Text.Trim()
        model.SourcePassword = tbEmailPassword.Text.Trim()
        model.TargetAddress = tbTargetEmailAddress.Text.Trim()
        model.SourcetHost = tbSourceHost.Text.Trim()
        model.Title = tbTitle.Text.Trim()
        model.AttachmentUri = fupAttachment.PostedFile.FileName
        model.ImageUri = fupImage.PostedFile.FileName
        model.Text = tbText.Text
        Dim result As String = validation.Validation(model)
        If result.Equals([String].Empty) Then
            ' Collect basic messages of Page and make simple validation.
            Dim mail As New MailMessage()
            mail.[To].Add(model.TargetAddress)
            mail.From = New MailAddress(model.SourceAddress)
            mail.Subject = model.Title
            mail.Body = model.Text
            mail.IsBodyHtml = True
            Dim attachment As New Attachment(model.AttachmentUri)
            mail.Attachments.Add(attachment)
            mail.Body += [String].Format("<p><img src='{0}' /></p>", "cid:imgEmbed")
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(mail.Body, Nothing, "text/html")
            Dim resources As New LinkedResource(model.ImageUri, "image/jpg")
            resources.ContentId = "imgEmbed"
            resources.TransferEncoding = TransferEncoding.Base64
            htmlView.LinkedResources.Add(resources)
            mail.AlternateViews.Add(htmlView)

            Dim client As New SmtpClient()
            Dim state As Object = mail.Subject
            client.Host = model.SourcetHost
            Dim credential As New NetworkCredential()
            credential.UserName = model.SourceAddress
            credential.Password = model.SourcePassword
            client.Credentials = credential
            client.EnableSsl = True
            client.Port = 587

            ' Send email asynchronously or not.
            If Page.IsAsync Then
                AddHandler client.SendCompleted, AddressOf SendCompleted
                client.SendAsync(mail, state)
            Else
                client.Send(mail)
                lbMessage.Text = [String].Format("E-mail-{0} has been sent!", mail.Subject)
            End If
        Else
            lbMessage.Text = result
        End If
    End Sub

    ''' <summary>
    ''' Reset all controls' value
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub tbReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        For Each control As Control In form1.Controls
            If TypeOf control Is TextBox Then
                TryCast(control, TextBox).Text = String.Empty
            End If
        Next
    End Sub


    ''' <summary>
    ''' Asynchronous e-mail send complete operation event. 
    ''' You can create your own exception handing methods base on this method.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="e"></param>
    Public Sub SendCompleted(ByVal obj As Object, ByVal e As AsyncCompletedEventArgs)
        Dim mailTitle As String = TryCast(e.UserState, String)
        If e.Cancelled Then
            lbMessage.Text = [String].Format("Send e-mail canceled: Email Title-{0}", mailTitle)
        End If
        If e.[Error] IsNot Nothing Then
            lbMessage.Text = [String].Format("Send e-mail error of {0}: {1}", mailTitle, e.[Error].ToString())
        Else
            lbMessage.Text = [String].Format("E-mail-{0} has been sent!", mailTitle)
        End If
    End Sub
End Class