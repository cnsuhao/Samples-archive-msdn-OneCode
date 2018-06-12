'***************************** Module Header ******************************\
' Module Name: MainModule.vb
' Project:     Client
' Copyright (c) Microsoft Corporation.
' 
' This is the client side programe. It's used to invoke the WCF service on 
' Azure workrole. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ***************************************************************************/
Imports Client.WCFMailservice
Imports System.IO

Module MainModule

    Sub Main()
        Dim mailModel As New WCFMailservice.MailModel()
        Dim FilePath As String = "YOUR_FILE_PATH"
        mailModel.SourceAddress = "YOU_MAIL_ADDRESS"
        mailModel.SourcePassword = "YOU_MAIL_PASSWORD"
        mailModel.Title = "MAIL TITILE"
        mailModel.TargetAddress = "TARGET_ADDRESS"
        mailModel.Text = "This is text file"
        mailModel.IsBodyHtml = False
        Dim AllFileAttachment As New List(Of FileAttachment)()

        Dim fileAttachment As New WCFMailservice.FileAttachment()
        fileAttachment.Info = New FileInfo(FilePath)
        fileAttachment.FileContentByteArray = File.ReadAllBytes(FilePath)

        AllFileAttachment.Add(fileAttachment)
        mailModel.Attachments = AllFileAttachment.ToArray()

        mailModel.SourceHost = "smtp.live.com"
        mailModel.Port = 587

        Dim client As New MailServiceClient()
        If client.SendMail(mailModel) Then
            Console.WriteLine("The e-mail has been sent successfully.")
        Else
            Console.WriteLine("Sorry, failed to send the e-mail. Please check your user name and password.")
        End If

        Console.ReadLine()

    End Sub

End Module
