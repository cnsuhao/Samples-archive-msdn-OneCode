'****************************** Module Header ******************************\
' Module Name:    MainModule.vb
' Project:        VBSSharePointCSVReaderForUserProfile
' Copyright (c) Microsoft Corporation
'
' The sample will demo you how to populate SharePoint 2010 User Profile with data 
' from a CSV file.
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
Imports Microsoft.Office.Server.UserProfiles
Imports System.IO

Module MainModule

    Sub Main()
        ' Get data from CSV file and populate to List 
        Dim csvData As List(Of String()) = parseCSV("..\..\sample.csv")

        ' Temp index
        Dim dis_index As Integer = 0, given_index As Integer = 0, home_index As Integer = 0, mobile_index As Integer = 0
        Console.WriteLine("Required")

        ' Open your site
        Using site As New SPSite("http://[PLACE_YOUR_SHAREPOINT_SITE_URL_HERE]/")
            ' Get the ServiceContext
            Dim context As SPServiceContext = SPServiceContext.GetContext(site)

            ' Create a ProfileSubtypeManager instance
            Dim psm As ProfileSubtypeManager = ProfileSubtypeManager.[Get](context)

            ' Choose default user profile subtype as the subtype
            Dim subtypeName As String = ProfileSubtypeManager.GetDefaultProfileName(ProfileType.User)

            Dim subType As ProfileSubtype = psm.GetProfileSubtype(subtypeName)

            Dim upm As New UserProfileManager(context)
            ' Traversal List data and output.
            For i As Integer = 0 To csvData.Count - 1

                ' Header row
                If i = 0 Then
                    Dim colLength As Integer = csvData(0).Length
                    For j As Integer = 0 To colLength - 1
                        If Not String.IsNullOrEmpty(csvData(0)(j)) Then
                            If csvData(0)(j).Equals("displayName", StringComparison.OrdinalIgnoreCase) Then
                                dis_index = j
                            ElseIf csvData(0)(j).Equals("givenName", StringComparison.OrdinalIgnoreCase) Then
                                given_index = j
                            ElseIf csvData(0)(j).Equals("homePhone", StringComparison.OrdinalIgnoreCase) Then
                                home_index = j
                            ElseIf csvData(0)(j).Equals("mobile", StringComparison.OrdinalIgnoreCase) Then
                                mobile_index = j
                            End If
                        End If

                    Next
                End If
                Console.WriteLine(((csvData(i)(dis_index) + vbTab & " ---  " + csvData(i)(given_index) & vbTab & " ---  ") + csvData(i)(home_index) & vbTab & " ---  ") + csvData(i)(mobile_index) & vbTab & " ---  ")

                ' DataRow
                If i <> 0 Then
                    Dim userid As String = "contoso:" + csvData(i)(dis_index)

                    ' If the UserProfile does not exist then submit the current data.
                    If Not upm.UserExists(userid) Then
                        Dim newProfile As UserProfile = upm.CreateUserProfile(userid)
                        newProfile.DisplayName = csvData(i)(dis_index)
                        newProfile.ProfileSubtype = subType
                        newProfile(PropertyConstants.FirstName).Value = csvData(i)(dis_index)
                        newProfile(PropertyConstants.LastName).Value = csvData(i)(given_index)
                        newProfile(PropertyConstants.HomePhone).Value = csvData(i)(home_index)
                        newProfile(PropertyConstants.CellPhone).Value = csvData(i)(mobile_index)
                        newProfile.Commit()
                    End If

                End If
            Next
        End Using
        Console.ReadKey()

    End Sub

    ''' <summary>
    ''' Parse CSV file's Data to list
    ''' </summary>
    ''' <param name="path">CSV file's Path</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function parseCSV(path As String) As List(Of String())
        ' A list to store the parsed data
        Dim parsedData As New List(Of String())()
        Try
            ' Using StreamReader to read the CSV file
            Using readFile As New StreamReader(path)
                Dim line As String = String.Empty
                Dim row As String(), temp As String(), parsedrow As String()
                Dim first_line As Boolean = True

                While (InlineAssignHelper(line, readFile.ReadLine())) IsNot Nothing
                    ' A list to store data row
                    Dim final As New List(Of String)()

                    ' based on quotes interception into an array
                    row = line.Split(""""c)

                    If first_line Then
                        row = line.Split(","c)
                        parsedData.Add(row)
                        first_line = False
                        Continue While
                    End If

                    ' Loop above array and the effective cell data will be added to the corresponding array.
                    ' If corresponding row starts with comma,remove the comma at the end of a row,
                    ' and then split the remaining contents into a array based on comma.
                    For i As Integer = 0 To row.Length - 1
                        If row(i).StartsWith(",") Then
                            If i <> row.Length - 1 Then
                                row(i) = row(i).Remove(row(i).Length - 1)
                            End If

                            temp = row(i).Split(","c)

                            For j As Integer = 1 To temp.Length - 1
                                final.Add(temp(j))
                            Next
                        ElseIf row(i) <> "" Then
                            final.Add(row(i))
                        End If
                    Next
                    If final.Count = 0 Then
                        Continue While
                    End If

                    parsedrow = final.ToArray()
                    ' The corresponding data of row is added to the list of the final recording.
                    parsedData.Add(parsedrow)
                End While
            End Using
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        Return parsedData
    End Function

    Private Function InlineAssignHelper(Of T)(ByRef result As T, ByVal value As T) As T
        result = value
        Return value
    End Function
End Module
