'/****************************** Module Header ******************************\
' Module Name:  LeaveService.vb
' Project:      VBWCFService
' Copyright (c) Microsoft Corporation.
' 
' This class inherits the ILeaveService class and implement the methods. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports DBOperate
Imports VBLeaveWF

Public Class LeaveService
    Implements ILeaveService

    ''' <summary>
    ''' Get Pending list
    ''' </summary>
    ''' <returns></returns>
    Public Function GetLeaveList() As List(Of Leave) Implements ILeaveService.GetLeaveList
        Using dc As New LeaveDataContext()
            Dim leaves As List(Of Leave) = dc.Leaves.Where(Function(p) p.Status = "Pending").ToList()
            Return leaves
        End Using
    End Function

    ''' <summary>
    ''' Create Leave
    ''' </summary>
    ''' <param name="name">The Name of Leave</param>
    ''' <param name="day">The Day of Leave</param>
    Public Sub CreateLeave(name As String, day As String) Implements ILeaveService.CreateLeave
        WorkFlowProcess.CreateAndRun(name, Integer.Parse(day))
    End Sub

    ''' <summary>
    ''' Audit Leave
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="comment"></param>
    Public Sub AuditingLeave(id As String, comment As String) Implements ILeaveService.AuditingLeave
        WorkFlowProcess.RunInstance(Guid.Parse(id), comment)
    End Sub
End Class
