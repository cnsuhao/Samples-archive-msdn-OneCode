Imports Client.WCFMailservice
Imports System.IO

Module Module1

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
            Console.WriteLine("The mail has already send.")
        Else
            Console.WriteLine("Sorry, the mail hasn't be sended cause of some issue, please check your user name and password")
        End If

        Console.ReadLine()

    End Sub

End Module
