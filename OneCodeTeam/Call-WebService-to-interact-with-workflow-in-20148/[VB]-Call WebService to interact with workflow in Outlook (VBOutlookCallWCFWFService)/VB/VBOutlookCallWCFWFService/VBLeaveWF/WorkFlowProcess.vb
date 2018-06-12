'/****************************** Module Header ******************************\
' Module Name:  WorkFlowProcess.vb
' Project:      VBLeaveWF
' Copyright(c)  Microsoft Corporation.
' 
' This Class is used to create workflow application, run it and update the 
' changes to database.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports System.Activities
Imports DBOperate

Public Class WorkFlowProcess

    ''' <summary>
    ''' Creates a workflow application, binds parameters run it.
    ''' </summary>
    ''' <param name="leaveName">The Name of leave </param>
    ''' <param name="leaveDay">The Day of leave</param>
    Public Shared Sub CreateAndRun(leaveName As String, leaveDay As Integer)
        ' Initialize input argument
        Dim input As IDictionary(Of String, Object) = New Dictionary(Of String, Object)() From { _
         {"LeaveName", leaveName}, _
         {"LeaveDay", leaveDay} _
        }

        ' Initialize a host for the instance of workflow
        Dim application As New WorkflowApplication(New VBLeaveWF.LeaveProcess(), input)
        Dim id As Guid = application.Id

        ' Begins the execution of a workflow instance
        application.Run()
    End Sub

    ''' <summary>
    ''' Approve or Reject Leave request
    ''' </summary>
    ''' <param name="iD">Leave ID</param>
    ''' <param name="comment">Approve or Reject</param>
    Public Shared Sub RunInstance(iD As Guid, comment As String)
        Using dc As New LeaveDataContext()
            Dim info As Leave = dc.Leaves.[Single](Function(p) p.LeaveID = iD)
            If Not [String].IsNullOrEmpty(comment) Then
                If comment.Equals("Yes", StringComparison.OrdinalIgnoreCase) Then
                    info.Status = "Approval"
                ElseIf comment.Equals("No", StringComparison.OrdinalIgnoreCase) Then
                    info.Status = "Reject"
                Else
                    info.Status = "Pending"
                End If

                ' Submit Changes to Database 
                dc.SubmitChanges()
            Else
                Throw New ArgumentNullException("comment", "comment can not be null!")
            End If
        End Using
    End Sub

End Class
