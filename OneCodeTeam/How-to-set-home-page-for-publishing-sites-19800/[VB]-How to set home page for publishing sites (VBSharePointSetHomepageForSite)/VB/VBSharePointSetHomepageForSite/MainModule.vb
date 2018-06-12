'****************************** Module Header ******************************\
' Module Name:    MainModule.vb
' Project:        VBSharePointSetHomepageForSite
' Copyright (c) Microsoft Corporation
'
' This sample shows how to set home page for publishing sites programmatically.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports Microsoft.SharePoint

Module MainModule

    Sub Main()
        ' Url of the PublishingWeb
        Dim strPublishingWebUrl As String = "yourPublishingWebUrl"
        ' Url of the new WelcomePage
        Dim strWelcomePageUrl As String = "yourNewWelcomePageUrl"

        ' Connect to SharePoint Site
        Using oSite = New SPSite(strPublishingWebUrl)
            ' Open SharePoint Site
            Using oWeb = oSite.OpenWeb()
                ' Checks the SPWeb object to verify whether it is a PublishingWeb object.
                If Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb) Then
                    ' Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                    Dim oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb)

                    Try
                        ' Get the new WelcomePage File by the url.
                        Dim oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl)

                        If (oWelcomePageFile.Exists()) Then

                            ' Sets the Welcome page for this PublishingWeb object.
                            oPublishingWeb.DefaultPage = oWelcomePageFile

                            ' Saves changes to the PublishingWeb object
                            oPublishingWeb.Update()
                        End If
                    Catch oException As Exception
                        ' Handle the exception
                        Console.WriteLine(oException.Message)
                    Finally
                        ' Prevent memory leaks by closing the Publishing web
                        oPublishingWeb.Close()
                    End Try
                End If
            End Using
        End Using
    End Sub

End Module
