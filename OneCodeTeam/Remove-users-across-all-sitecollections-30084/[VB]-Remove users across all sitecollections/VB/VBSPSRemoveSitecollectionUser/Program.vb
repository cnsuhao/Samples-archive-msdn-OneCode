'/****************************** Module Header ******************************\
' * Module Name:  Program.vb
' * Project:      VBSPSRemoveSitecollectionUser
' * Copyright (c) Microsoft Corporation.
' * 
' * This sample will show you how to remove users across all sitecollections 
' * within one web application. 
' *
' * This source is subject to the Microsoft Public License.
' * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' * All other rights reserved.
' * 
' * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Administration

Module Program
    ' The list of Users that will be deleted.
    Dim usernameList As String() = {"i:0#.w|ad\seiya", "i:0#.w|ad\allending"}
    ' Your WebApplication Url.
    Dim strApplicationUrl As String = "http://" + System.Environment.MachineName

    Public Sub Main()
        Try
            ' Get the WebApplication by Url.
            Dim webApp As SPWebApplication = SPWebApplication.Lookup(New Uri(strApplicationUrl))
            ' Output the app name.
            Console.WriteLine("Web Application:" + webApp.Name)

            ' Loop all sites from the WebApplication.
            For Each siteColl As SPSite In webApp.Sites
                Console.WriteLine("===============================================")
                Console.WriteLine("Site Collection: " + siteColl.Url)
                Console.WriteLine("===============================================")

                ' Get all subsite of current site.
                Dim collWebsites As SPWebCollection = siteColl.AllWebs
                If collWebsites IsNot Nothing Then
                    ' Loop SPWeb of current web's SiteColection.
                    For Each web As SPWeb In collWebsites
                        Console.WriteLine("Checking Web : " + web.Url)

                        If web.HasUniqueRoleAssignments Then
                            ' Directly remove user list.

                            ' While removing users, writing log or take other actions.
                            'foreach (string user in usernameList)
                            '{
                            '    var l = web.AllUsers.Cast<SPUser>().AsQueryable().Where(usr => usr.LoginName.ToUpper().Equals(user.ToUpper()));
                            '    if (l.Count() > 0)
                            '    {
                            '        web.AllUsers.Remove(user);
                            '        Console.WriteLine("User: " + user + " Successfully removed from Site ");
                            '    }
                            '    else
                            '    {
                            '        Console.WriteLine("User: " + user + " Does not exist on Site ");
                            '    }
                            '}

                            web.Users.RemoveCollection(usernameList)
                        End If
                        Console.WriteLine("=================================================")
                        web.Dispose()
                    Next
                End If
                siteColl.Dispose()
            Next
        Catch ex As Exception
            Console.WriteLine("Error" & ex.Message)
        End Try

        Console.WriteLine("Program completed; please click enter to exit")
        Console.Read()
    End Sub
End Module



