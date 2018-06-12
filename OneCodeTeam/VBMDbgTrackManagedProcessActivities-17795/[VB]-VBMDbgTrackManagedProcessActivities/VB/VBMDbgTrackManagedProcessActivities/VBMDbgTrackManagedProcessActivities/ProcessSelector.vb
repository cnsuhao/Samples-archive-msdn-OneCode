'************************** Module Header ******************************\
' Module Name:  ManagedThread.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' This dialog is used to select the target process to debug. 
' 
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports System.Security.Permissions
Imports VBMDbgTrackManagedProcessActivities.Debugger


<PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust"),
 PermissionSet(SecurityAction.InheritanceDemand, Name:="FullTrust")>
Partial Public Class ProcessSelector
    Inherits Form

    ''' <summary>
    ''' Specify whether debug a running process or launch an application to debug.
    ''' </summary>
    Public ReadOnly Property LaunchApplication() As Boolean
        Get
            Return radLaunchApplication.Checked
        End Get
    End Property

    ''' <summary>
    ''' The path of the application.
    ''' </summary>
    Public ReadOnly Property ApplicationPath() As String
        Get
            If LaunchApplication Then
                Return Me.tbApplicationPath.Text
            Else
                Return String.Empty
            End If
        End Get
    End Property

    ''' <summary>
    ''' The process ID.
    ''' </summary>
    Public ReadOnly Property ProcessID() As Integer
        Get
            If (Not LaunchApplication) AndAlso lstProcess.SelectedItem IsNot Nothing Then
                Dim process As Process = TryCast(lstProcess.SelectedItem, Process)
                If process IsNot Nothing AndAlso (Not process.HasExited) Then
                    Return process.Id
                End If
            End If
            Return 0
        End Get
    End Property


    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ProcessSelector_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load
        tbApplicationPath.Text = Environment.CurrentDirectory & "\VBMDbgTargetApp.exe"
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnRefresh.Click
        RefreshManagedProcess()
    End Sub

    Private Sub RefreshManagedProcess()

        Dim processes = ManagedProcess.EnumManagedProcesses()

        lstProcess.DataSource = processes

        If lstProcess.Items.Count > 0 Then
            lstProcess.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnBrowse.Click
        Using dialog As New OpenFileDialog()
            Dim result = dialog.ShowDialog()

            If result = DialogResult.OK Then
                Me.tbApplicationPath.Text = dialog.FileName
            End If
        End Using
    End Sub


End Class
