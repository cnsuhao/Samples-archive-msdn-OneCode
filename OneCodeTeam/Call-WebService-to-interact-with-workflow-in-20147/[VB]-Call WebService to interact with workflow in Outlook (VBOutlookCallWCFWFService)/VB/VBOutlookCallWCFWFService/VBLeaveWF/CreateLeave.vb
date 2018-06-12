'/****************************** Module Header ******************************\
' Module Name:  CreateLeave.vb
' Project:      VBLeaveWF
' Copyright (c) Microsoft Corporation.
' 
' This Class is used to create a leave request in workflow.
' Here we use Linq to Sql to add record into Sql server. 
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

Public Class CreateLeave
    Inherits CodeActivity

    ' Input Parameters in workflow
    Public Property Name() As InArgument(Of String)
        Get
            Return _name
        End Get
        Set(value As InArgument(Of String))
            _name = value
        End Set
    End Property
    Private _name As InArgument(Of String)
    Public Property Day() As InArgument(Of Integer)
        Get
            Return _day
        End Get
        Set(value As InArgument(Of Integer))
            _day = value
        End Set
    End Property
    Private _day As InArgument(Of Integer)
    Public Property Comment() As InArgument(Of String)
        Get
            Return _comment
        End Get
        Set(value As InArgument(Of String))
            _comment = value
        End Set
    End Property
    Private _comment As InArgument(Of String)

    ' Output parameters in workflow
    ' return a Leave entity
    Public Property ObjLeave() As OutArgument(Of Leave)
        Get
            Return _objLeave
        End Get
        Set(value As OutArgument(Of Leave))
            _objLeave = value
        End Set
    End Property
    Private _objLeave As OutArgument(Of Leave)

    ' Called by the workflow runtime to execute an activity
    Protected Overrides Sub Execute(context As CodeActivityContext)
        Using dc As New LeaveDataContext()
            ' Create leave record to sql server
            Dim info As New Leave()
            info.LeaveID = context.WorkflowInstanceId
            info.LeaveName = Name.[Get](context)
            info.LeaveDay = Day.[Get](context)
            info.Comment = Comment.[Get](context)
            info.Status = "Initialization"

            dc.Leaves.InsertOnSubmit(info)
            dc.SubmitChanges()

            ' Set Output Argument
            ObjLeave.[Set](context, info)
        End Using
    End Sub

End Class
