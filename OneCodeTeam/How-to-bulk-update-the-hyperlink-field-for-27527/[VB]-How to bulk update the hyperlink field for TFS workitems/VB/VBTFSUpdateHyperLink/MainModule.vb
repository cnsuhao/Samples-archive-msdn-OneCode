'****************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBTFSUpdateHyperLink
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to bulk update the hyperlink field for TFS workitems 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.WorkItemTracking.Client

Module UpdateHyperLinkVB
    Class Program
        Public Shared Sub Main(args As String())

            ' Get the Uri to the project collection to use
            Dim collectionUri = UpdateHyperLink.Helper.GetCollectionUri(args)

            ' Get the old server information and new server information for replacing
            Dim oldText As String = args(1)
            Dim newText As String = args(2)

            Try
                ' Get the work item store from the TeamFoundationServer
                Console.WriteLine("Connecting to {0}...", collectionUri)

                ' Get a reference to the team project collection
                Using projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri)
                    ' Get a reference to the work item tracking service
                    Dim workItemStore = projectCollection.GetService(Of WorkItemStore)()

                    If workItemStore.Projects.Count <= 0 Then
                        Throw New ApplicationException("There are no projects in this server")
                    End If

                    Dim hyperWic As WorkItemCollection = workItemStore.Query("select [system.id] from workitems where [System.HyperLinkCount] > 0")


                    For Each wi As WorkItem In hyperWic
                        'Copy the references to the links to another collection, enumerate over that collection, do your remove and add to the wi.Links collection.

                        Dim tempForEmenuration As New List(Of LinkCollection)()

                        For Each link As Link In wi.Links
                            If link.BaseType = BaseLinkType.Hyperlink Then
                                tempForEmenuration.Add(wi.Links)
                            End If
                        Next
                        For Each temp As LinkCollection In tempForEmenuration
                            For Each tempLink As Link In temp
                                Dim hyper As Hyperlink = DirectCast(tempLink, Hyperlink)
                                If hyper.Location.Contains(oldText) Then
                                    Dim comment As String = hyper.Comment
                                    Dim newLinkAfterChange As String = hyper.Location.Replace(oldText, newText)
                                    temp.Remove(tempLink)
                                    Dim newHyper As New Hyperlink(newLinkAfterChange)
                                    newHyper.Comment = comment
                                    wi.Links.Add(newHyper)
                                    wi.Save()
                                    Exit For
                                End If
                            Next
                        Next

                    Next
                End Using

            Catch e As Exception
                Console.WriteLine("Error: {0}", e.StackTrace)
            End Try
        End Sub
    End Class
End Module

