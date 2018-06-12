'***************************** Module Header ******************************\
' Module Name:  RelationValidation.vb
' Project:		VBWF4CustomValidation
' Copyright (c) Microsoft Corporation.
' 
' This is a composite activity which can validate the relation of its child
' activities. 
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'**************************************************************************/

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Activities
Imports System.Activities.Validation
Imports System.ComponentModel

<Designer(GetType(RelationValidationDesigner))> _
Public Class RelationValidation
    Inherits NativeActivity
    Public Property Branches() As Collection(Of Activity)
        Get
            Return m_Branches
        End Get
        Set(value As Collection(Of Activity))
            m_Branches = value
        End Set
    End Property
    Private m_Branches As Collection(Of Activity)
    Public Property Variables() As Collection(Of Variable)
        Get
            Return m_Variables
        End Get
        Set(value As Collection(Of Variable))
            m_Variables = value
        End Set
    End Property
    Private m_Variables As Collection(Of Variable)
    Public Property LastIndexHint() As Variable(Of Integer)
        Get
            Return m_LastIndexHint
        End Get
        Set(value As Variable(Of Integer))
            m_LastIndexHint = value
        End Set
    End Property
    Private m_LastIndexHint As Variable(Of Integer)
    Public Sub New()
        Branches = New Collection(Of Activity)()
        Variables = New Collection(Of Variable)()
        LastIndexHint = New Variable(Of Integer)()
        Me.Constraints.Add(CheckChild())
    End Sub

    Public Shared Function CheckChild() As Constraint
        Dim element As New DelegateInArgument(Of RelationValidation)()
        Return New Constraint(Of RelationValidation)() With { _
             .Body = New ActivityAction(Of RelationValidation, ValidationContext)() With { _
                 .Argument1 = element, _
                 .Handler = New AssertValidation() With { _
                     .Assertion = New InArgument(Of Boolean)(Function(env) (element.[Get](env).Branches.Count <> 0)), _
                     .Message = New InArgument(Of String)("please add children activities to this activity") _
                } _
            } _
        }
    End Function

    Private activityCounter As Integer = 0
    Protected Overrides Sub CacheMetadata(metadata As NativeActivityMetadata)
        metadata.SetChildrenCollection(Branches)
        metadata.SetVariablesCollection(Variables)
        metadata.AddImplementationVariable(Me.LastIndexHint)
    End Sub

    Protected Overrides Sub Execute(context As NativeActivityContext)
        ScheduleActivities(context)
    End Sub

    Private Sub ScheduleActivities(context As NativeActivityContext)
        If activityCounter < Branches.Count Then
            context.ScheduleActivity(Me.Branches(System.Math.Max(System.Threading.Interlocked.Increment(activityCounter), activityCounter - 1)), AddressOf OnActivityCompleted)
        End If
    End Sub

    Private Sub OnActivityCompleted(context As NativeActivityContext, completedInstance As ActivityInstance)
        ScheduleActivities(context)
    End Sub
End Class
