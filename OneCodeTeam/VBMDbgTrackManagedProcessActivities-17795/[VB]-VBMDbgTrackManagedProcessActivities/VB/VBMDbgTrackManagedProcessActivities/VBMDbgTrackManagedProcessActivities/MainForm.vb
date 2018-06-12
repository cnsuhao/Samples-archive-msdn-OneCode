'************************** Module Header ******************************\
' Module Name:  MainForm.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' The MainForm of this application. 
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

Imports VBMDbgTrackManagedProcessActivities.Debugger
Imports Microsoft.Samples.Debugging.MdbgEngine
Imports Microsoft.Samples.Debugging.CorDebug


Partial Public Class MainForm
    Inherits Form

    ' The delegates used in Invoke method.
    Private Delegate Sub ParameterizedDelegate(ByVal parameter As Object)
    Private Delegate Sub VoidDelegate()

    Private _managedProcess As ManagedProcess = Nothing

    ' Specify whether debug a running process or launch an application 
    ' to debug.
    Private _launchApplication As Boolean

    ' The path of the application.
    Private _applicationPath As String

    ' The process ID.
    Private _processID As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load
        ' Launch the ProcessSelector dialog to select a process to debug.
        If SelectProcess() Then

            ' This method should be executed in a MTA thread.
            MTAThreadHelper.RunInMTAThread(AddressOf InitializeManagedProcess)

        End If
    End Sub

    ''' <summary>
    ''' Launch the ProcessSelector dialog to select a process to debug.
    ''' </summary>
    Private Function SelectProcess() As Boolean
        Using selector As New ProcessSelector()
            Dim result = selector.ShowDialog()

            If result <> DialogResult.OK OrElse
                ((Not selector.LaunchApplication) AndAlso selector.ProcessID <= 0) Then
                Application.Exit()
                Return False
            End If

            Me._launchApplication = selector.LaunchApplication
            Me._applicationPath = selector.ApplicationPath
            Me._processID = selector.ProcessID
            Return True
        End Using
    End Function

#Region "MTAThread methods"

    ''' <summary>
    ''' Attach the debugger to the target process.
    ''' This method should be executed in a MTA thread.
    ''' </summary>
    Private Sub InitializeManagedProcess()
        If Me._managedProcess IsNot Nothing Then
            Me._managedProcess.Dispose()
            Me._managedProcess = Nothing
        End If

        Try
            If Me._launchApplication Then
                Me._managedProcess = ManagedDebugger.Instance.CreateProcess(Me._applicationPath)
            Else
                Me._managedProcess = ManagedDebugger.Instance.AttachTo(Me._processID)
            End If

            ' Register the events.
            AddHandler _managedProcess.PostEvent, AddressOf managedProcess_PostEvent
            AddHandler _managedProcess.OperationErrorOccurred, AddressOf managedProcess_OperationErrorOccurred
            AddHandler _managedProcess.ProcessExit, AddressOf managedProcess_ProcessExit

            ' Update the UI.
            Me.Invoke(New ParameterizedDelegate(AddressOf RefreshUI), True)

        Catch ex As Exception
            Me.ErrorOccurredInMTAThread(
                New ErrorEventArgs With
                {.Error = ex,
                 .Ignorable = False,
                 .Message = "Cannot initialize to debug the target process."})
        End Try

    End Sub
#End Region

#Region "Handle managed process events"

    ''' <summary>
    ''' Target process exits.
    ''' </summary>
    Private Sub managedProcess_ProcessExit(ByVal sender As Object, ByVal e As EventArgs)
        If _managedProcess IsNot Nothing Then

            ' This method should be executed in a MTA thread.
            MTAThreadHelper.RunInMTAThread(AddressOf _managedProcess.Dispose)

        End If

        Me.ErrorOccurredInMTAThread(
            New ErrorEventArgs With {
                .Error = New ApplicationException("The debuggee has exited."),
                .Ignorable = False,
                .Message = "The debuggee has exited."})
    End Sub

    ''' <summary>
    ''' There is an activity in the target process.
    ''' </summary>
    Private Sub managedProcess_PostEvent(ByVal sender As Object, ByVal e As PostEventArgs)
        AddActivity(e.EventMessage)
    End Sub

    ''' <summary>
    ''' Log the message.
    ''' </summary>
    Private Sub AddActivity(ByVal message As String)
        Dim timeStamp As String = Date.Now.ToString("HH:mm:ss")
        Dim msg As String = String.Format("{0}{1}{0}{2}{0}",
                                          Environment.NewLine, timeStamp, message)
        Me.Invoke(New ParameterizedDelegate(AddressOf AddActivityHandler), msg)
    End Sub

    ''' <summary>
    ''' Log the message.
    ''' </summary>
    Private Sub AddActivityHandler(ByVal msg As Object)
        Me.tbActivities.AppendText(TryCast(msg, String))
        Me.tbActivities.SelectionStart = tbActivities.Text.Length - 1
    End Sub

    ''' <summary>
    ''' Handle the OperationErrorOccurred event.
    ''' This method will be executed in a MTA thread.
    ''' </summary>
    Private Sub managedProcess_OperationErrorOccurred(ByVal sender As Object,
                                                      ByVal e As ErrorEventArgs)
        Me.ErrorOccurredInMTAThread(e)
    End Sub

    ''' <summary>
    ''' Refresh the UI.
    ''' This method should be executed in the main thread.
    ''' </summary>
    Private Sub RefreshUI(ByVal isProcessRunningParameter As Object)
        Dim isProcessRunning As Boolean = CBool(isProcessRunningParameter)

        If Me._managedProcess Is Nothing Then
            Me.lbProcess.Text = String.Empty
        Else
            Me.lbProcess.Text = String.Format(
                "ProcessID:{0}    Name:{1}",
                Me._managedProcess.ProcessID,
                Me._managedProcess.ProcessName)
        End If
    End Sub

#End Region

#Region "UI event handlers of Stop and Continue."

    ''' <summary>
    ''' Detach the target process.
    ''' </summary>
    Private Sub btnDetach_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles btnDetach.Click
        If _managedProcess IsNot Nothing Then

            ' This method should be executed in a MTA thread.
            MTAThreadHelper.RunInMTAThread(AddressOf _managedProcess.Dispose)

        End If

        ' Launch the ProcessSelector dialog.
        If SelectProcess() Then

            ' This method should be executed in a MTA thread.
            MTAThreadHelper.RunInMTAThread(AddressOf InitializeManagedProcess)

        End If
    End Sub

#End Region

#Region "Error Handler."

    Private Sub ErrorOccurredInMTAThread(ByVal e As ErrorEventArgs)
        Me.Invoke(New ParameterizedDelegate(AddressOf ErrorUIHandler), e)
    End Sub

    Private Sub ErrorUIHandler(ByVal exceptionParameter As Object)
        Dim e As ErrorEventArgs = TryCast(exceptionParameter, ErrorEventArgs)

        If e Is Nothing OrElse e.Error Is Nothing Then
            Return
        End If

        Dim ex As Exception = e.Error
        If e.Ignorable Then
            MessageBox.Show(ex.Message,
                            "Error occurred in the debuggee.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        Else
            Dim result = MessageBox.Show(
                String.Format("{0}" & vbLf & "Do you want to exit debugging?", ex.Message),
                "Exit debugging?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error)

            If result = DialogResult.No AndAlso SelectProcess() Then
                MTAThreadHelper.RunInMTAThread(AddressOf InitializeManagedProcess)
            Else
                Me.Close()
            End If
        End If
    End Sub

#End Region
End Class

