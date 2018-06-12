'**************************** Module Header ******************************\
' Module Name: RegexMethod.vb
' Project:     VBASPNETDisplayDataStreamResource
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to display the data stream from Internet resource
' and site resource in a web page. Customers want to know how to display the 
' title, content or other information of web pages. Thus, the sample can search
' the target web page which you input url address in TextBox control and get all
' relative link resources of it. 
' 
' The class is used to extract specifically information from HTML resource.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Public Class RegexMethod
 Public Function GetLinks(htmlCode As String, url As String) As List(Of String)
        Dim links As New List(Of String)()
        Dim strRegexLink As String = "(?is)<a .*?>"
        Dim matchList As MatchCollection = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase)
        Dim strbLinkList As New StringBuilder()

        For Each matchSingleLink As Match In matchList
            Dim matchLink As String = "<a[^>]*?href=(['""\s]?)([^'""\s]+)\1[^>]*?>"
            Dim match As Match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase)
            If match.Groups(2).Value = "#" Then
                links.Add(url)
            ElseIf Not match.Groups(2).Value.ToLower().Contains("http://") Then
                links.Add(url + match.Groups(2).Value)
            Else
                links.Add(match.Groups(2).Value)
            End If
        Next
        Return links
    End Function

    Public Shared Function IsUrl(ByVal source As String) As Boolean

        Return Regex.IsMatch(source, "^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase)
    End Function

End Class
