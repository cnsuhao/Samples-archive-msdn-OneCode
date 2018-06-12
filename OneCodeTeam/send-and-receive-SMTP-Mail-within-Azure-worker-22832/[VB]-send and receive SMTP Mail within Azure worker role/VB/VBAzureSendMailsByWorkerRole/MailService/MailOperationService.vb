'***************************** Module Header ******************************\
' Module Name:  MailOperationService.vb
' Project:      VBAzureSendMailsByWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' As you know, System.Net.Mail api can't be used in Windows Runtime application, 
' However, we can create a WCF service to consume the api, and hold this service 
' on Azure.
' 
' In this way, we can use this service to send email in Windows Store app. 
' 
' This class contains the core function "SendMail".
' 
' The SendMail method first saves the attachment file to local temp folder, and 
' then deletes the the temp folder once the e-mail has been sent successfully.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports System.IO
Imports MailService.Model
Imports System.Net.Mail
Imports System.Net
Imports MailService.Interface

Public Class MailOperationService
    Implements IMailOperater
    ''' <summary>
    ''' It will first save the attachment file to local temp folder, and then
    ''' delete the the temp folder once the e-mail has been sent successfully.
    ''' </summary>
    ''' <param name="Model"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendMail(Model As MailModel) As Boolean Implements [Interface].IMailOperater.SendMail

        Dim tempFilePath As String = Nothing
        Dim tempFolderPath As String = Path.GetTempFileName() + Guid.NewGuid().ToString() + "\"
        Dim tempFilesList As New List(Of String)()


        Dim mail As New MailMessage()
        mail.[To].Add(Model.TargetAddress)
        mail.From = New MailAddress(Model.SourceAddress)
        mail.Subject = Model.Title
        mail.Body = Model.Text
        mail.IsBodyHtml = Model.IsBodyHtml


        If Model.Attachments IsNot Nothing AndAlso Model.Attachments.Length > 0 Then
            For Each file In Model.Attachments
                tempFilePath = SaveTempFile(tempFolderPath, file)

                ' Add Attachment to Mail
                Dim attachment As New Attachment(tempFilePath)
                mail.Attachments.Add(attachment)
            Next
        End If

        Try
            Dim smtpClient As New SmtpClient()
            smtpClient.Host = Model.SourceHost
            Dim credential As New NetworkCredential()
            credential.UserName = Model.SourceAddress
            credential.Password = Model.SourcePassword
            smtpClient.Credentials = credential
            smtpClient.EnableSsl = True
            smtpClient.Port = Model.Port
            smtpClient.Send(mail)
        Catch generatedExceptionName As Exception
            ' Failed to send mail
            Return False
        Finally
            mail.Dispose()
            TempFileDispose(tempFolderPath)
        End Try

        ' Send mail successfully.
        Return True


    End Function

    ''' <summary>
    ''' Save File Attachment to server side, and return the file local path.
    ''' </summary>
    ''' <param name="TempFolderPath">Default path for temp folder</param>
    ''' <param name="Attachment">File information</param>
    ''' <returns></returns>
    Private Function SaveTempFile(TempFolderPath As String, Attachment As FileAttachment) As String
        Dim tempFilePath As String = TempFolderPath + Attachment.Info.Name
        If Not Directory.Exists(TempFolderPath) Then
            Directory.CreateDirectory(TempFolderPath)
        End If
        Try
            Using fs As New FileStream(tempFilePath, FileMode.Create)
                Dim bytes As Byte() = Attachment.FileContentByteArray
                fs.Write(bytes, 0, bytes.Length)
                fs.Close()
            End Using
        Catch
            Return Nothing
        End Try

        Return tempFilePath
    End Function

    ''' <summary>
    ''' Delete the temp folder and all sub files.
    ''' </summary>
    ''' <param name="TempFolderPath">The temp folder path</param>
    Private Sub TempFileDispose(TempFolderPath As String)
        If Directory.Exists(TempFolderPath) Then
            Directory.Delete(TempFolderPath, True)
        End If
    End Sub


End Class


