'/****************************** Module Header ******************************\
' Module Name:      ModifyLeave.vb
' Project:                  VBLeaveWF
' Copyright(c)          Microsoft Corporation.
' 
' This Class is used to modify the state of Leave request in database.
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

Public Class ModifyLeave
    Inherits CodeActivity

    ' Leave entity 
    Public Property UpdateLeaveInfo() As InArgument(Of Leave)
        Get
            Return m_UpdateLeaveInfo
        End Get
        Set(value As InArgument(Of Leave))
            m_UpdateLeaveInfo = value
        End Set
    End Property
    Private m_UpdateLeaveInfo As InArgument(Of Leave)

    ' The state of workflow
    Public Property State() As InArgument(Of String)
        Get
            Return m_State
        End Get
        Set(value As InArgument(Of String))
            m_State = value
        End Set
    End Property
    Private m_State As InArgument(Of String)

    ' Called by the workflow runtime to execute an activity
    Protected Overrides Sub Execute(context As CodeActivityContext)
        Using dc As New LeaveDataContext()
            Dim info As Leave = dc.Leaves.[Single](Function(p) p.LeaveID = UpdateLeaveInfo.[Get](context).LeaveID)
            State.[Set](context, "Complete")
            info.Status = "Pending"

            ' Update the status of Leave record in database
            dc.SubmitChanges()
        End Using
    End Sub
End Class

