'****************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBTFSUpdateHTMLFieldsWorkItem
' Copyright (c) Microsoft Corporation.
'
' This sample shows how to bulk update the HTML field (e.g. ReproSteps) for TFS workitems. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Linq
Imports System.Reflection
Imports Common.Common
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.WorkItemTracking.Client
Imports System.Collections.Generic
Imports Microsoft.TeamFoundation.TestManagement.Client
Imports System.Collections.ObjectModel
Imports System.Data.OleDb
Imports System.Data

Module WorkItemEdit

    Class WorkItemEdit

        Public Shared Sub Main(args As String())
            ' Get the Uri to the project collection to use
            Dim collectionUri = Helper.GetCollectionUri(args)

            ' NOTE: You may need to modify the project name.
            Dim tfsProjectName As String = "TestProj"
            Dim tfsWorkItemType As String = "Bug"

            Try
                ' Get the work item store from the TeamFoundationServer
                Console.WriteLine("Connecting to {0}...", collectionUri)

                ' Get a reference to the team project collection
                Using projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri)

                    ' NOTE: You have to replace the file path with yours.
                    Dim excelpath As String = "C:\UpdateBug\BugWI.xlsx"

                    Dim Con As New OleDbConnection((Convert.ToString("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=") & excelpath) + ";Extended Properties=Excel 8.0")
                    Con.Open()
                    Try
                        Dim myDataSet As New DataSet()
                        Dim myCommand As New OleDbDataAdapter(" SELECT * FROM [Sheet1$]", Con)
                        myCommand.Fill(myDataSet)

                        For i As Integer = 2 To myDataSet.Tables(0).Rows.Count
                            Dim wit As WorkItemStore = DirectCast(projectCollection.GetService(GetType(WorkItemStore)), WorkItemStore)
                            Dim result As WorkItemCollection = wit.Query([String].Format("SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.WorkItemType] = '{1}'", tfsProjectName, tfsWorkItemType))
                            Dim affectedWorkItems As New List(Of WorkItem)()

                            Dim witid As Integer = Integer.Parse(myDataSet.Tables(0).Rows(i)(0).ToString())
                            Dim bug As WorkItem = wit.GetWorkItem(12)

                            Dim newReproSteps As Field = bug.Fields("Microsoft.VSTS.CMMI.StepsToReproduce")

                            Dim reproSteps As Field = bug.Fields("Microsoft.VSTS.TCM.ReproSteps")
                            reproSteps.Value = newReproSteps.Value

                            bug.Save()
                        Next
                    Catch e As Exception
                        Console.WriteLine("Error: {0}", e.Message)
                    Finally
                        Con.Close()
                    End Try

                End Using
            Catch e As Exception
                Console.WriteLine("Error: {0}", e.Message)
            End Try
        End Sub

    End Class
End Module


