'****************************** Module Header ******************************\
' Module Name:    MainModule.vb
' Project:        VBSharePointDownloadDocument
' Copyright (c) Microsoft Corporation
'
' This demo will demonstrate how to download the documents from SharePoint
' document libraries across site collection in an easy fashion.
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
Imports System.IO

Module MainModule

    Sub Main()
        ' Path to download the files
        Dim strDownloadPath As String = "C:\MyDownloadFolder\"
        Dim url As String = "http://Site_Url"

        Using oSiteCollection As New SPSite(url)
            Dim collWebsites As SPWebCollection = oSiteCollection.AllWebs
            Console.WriteLine("Websites Count: {0}", collWebsites.Count)
            Console.WriteLine(" ")
            Dim rootwebtitle As String = oSiteCollection.RootWeb.Title
            For Each oWebsite As SPWeb In collWebsites
                Console.WriteLine("Site : " + oWebsite.Title)
                ' Path to download the files
                Dim websiteurl As String = oWebsite.Url
                Dim framedUrl As String = websiteurl.Replace(oSiteCollection.Url, "")
                Dim path As String = strDownloadPath & "\" & rootwebtitle & framedUrl.Replace("/"c, "\"c)
                Directory.CreateDirectory(path)
                DownloadDocs(oWebsite.Url, path)
                oWebsite.Dispose()
                Console.WriteLine("--------------------")
            Next
        End Using
        Console.WriteLine("Please click enter to exit")
        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Add the OOTB document library name to a list, document library in this list will not be downloaded.
    ''' According to the specified url circulation Site list, and then obtain the document
    ''' library and compared with the OOTB document libraries's name list;
    ''' If the document library's name does not exist in the OOTB list, download the document library.
    ''' </summary>
    ''' <param name="siteURL">Site URL</param>
    ''' <param name="sitepath">Site Path</param>
    Private Sub DownloadDocs(siteURL As String, sitepath As String)
        ' List of OOTB document libraries - These doc libraries will not be downloaded
        Dim ootbLib As New List(Of String)()
        ootbLib.Add("Converted Forms")
        ootbLib.Add("Form Templates")
        ootbLib.Add("Images")
        ootbLib.Add("List Template Gallery")
        ootbLib.Add("Master Page Gallery")
        ootbLib.Add("Pages")
        ootbLib.Add("Reporting Templates")
        ootbLib.Add("Site Collection Documents")
        ootbLib.Add("Site Collection Images")
        ootbLib.Add("Site Template Gallery")
        ootbLib.Add("Style Library")
        ootbLib.Add("Web Part Gallery")

        ' Open site
        Using oSite As New SPSite(siteURL)
            ' Open web
            Using oWeb As SPWeb = oSite.OpenWeb()

                ' Loop site lists
                For Each list As SPList In oWeb.Lists
                    ' Storage path
                    Dim actpath As String = (sitepath & "\") + list.Title & "\"

                    ' Obtain the document library by list.BaseType
                    If list.BaseType = SPBaseType.DocumentLibrary Then
                        ' Determine whether the document library is OOTB document library or not
                        If Not ootbLib.Exists(Function(p As String) p.Trim() = list.Title) Then
                            Console.WriteLine("Downloading from Library ::" + list.Title)
                            Directory.CreateDirectory(actpath)
                            TraverseAllListItems(list, actpath)
                        End If
                    End If
                Next
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Traverse all ListItems and download
    ''' </summary>
    ''' <param name="list">List of operation</param>
    ''' <param name="path">Storage path</param>
    Private Sub TraverseAllListItems(list As SPList, path As String)
        Dim qry As New SPQuery()
        qry.ViewAttributes = "Scope=""Recursive"""
        Try
            Dim ic As SPListItemCollection = list.GetItems(qry)

            For Each subitem As SPListItem In ic

                Dim itemurl As String = subitem.Url
                Dim index As Integer = itemurl.IndexOf("/")
                Dim subpath As String = itemurl.Substring(index + 1)
                Dim finalpath As String = path & subpath
                finalpath = finalpath.Replace(subitem.Name, "")
                finalpath = finalpath.Replace("/", "\")
                Console.WriteLine(finalpath)
                Directory.CreateDirectory(finalpath)
                Dim binFile As Byte() = subitem.File.OpenBinary()
                Dim fstream As System.IO.FileStream = System.IO.File.Create((finalpath & "\") + subitem.Name)
                fstream.Write(binFile, 0, binFile.Length)
                fstream.Close()
            Next
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

End Module
