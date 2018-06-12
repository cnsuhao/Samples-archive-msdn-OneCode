'************************** Module Header ******************************\
' Module Name:  ManagedDebugger.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' This class represents a managed debugger. It can debug a running managed 
' process, or launch a managed application to debug.
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
Imports Microsoft.Samples.Debugging.MdbgEngine

Namespace Debugger
    <PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")>
    Public Class ManagedDebugger

        ' Only one ManagedDebugger instance.
        Private Shared _locker As New Object()

        Private Shared _instance As ManagedDebugger = Nothing

        Public Shared ReadOnly Property Instance() As ManagedDebugger
            Get
                If _instance Is Nothing Then
                    SyncLock _locker
                        If _instance Is Nothing Then
                            _instance = New ManagedDebugger()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        Private _debugger As MDbgEngine = Nothing

        ''' <summary>
        ''' The MDbgEngine instance.
        ''' </summary>
        Public ReadOnly Property Debugger() As MDbgEngine
            Get
                If _debugger Is Nothing Then
                    _debugger = New MDbgEngine()
                    _debugger.Options.StopOnUnhandledException = False
                End If
                Return _debugger
            End Get
        End Property

        ''' <summary>
        ''' ManagedDebugger cannot be Instantiated.
        ''' </summary>
        Private Sub New()
        End Sub

        ''' <summary>
        ''' Attach debugger to a running process.
        ''' </summary>
        ''' <returns>
        ''' A ManagedProcess instance.
        ''' </returns>
        Public Function AttachTo(ByVal processID As Integer) As ManagedProcess

            ' Cannot attach to current process itself.
            Dim currentProcessID As Integer = Process.GetCurrentProcess().Id
            If currentProcessID = processID Then
                Throw New ArgumentException("Cannot attach to the debugger itself.")
            End If

            ' Determine whether the target is a managed process.
            Dim isManaged As Boolean = ManagedProcess.IsManagedProcess(processID)
            If Not isManaged Then
                Throw New ArgumentException("It is not a managed application.")
            End If

            Try

                ' Get the runtime version of the target process.
                Dim version As String = MdbgVersionPolicy.GetDefaultAttachVersion(processID)

                ' Attach to the target process.
                Dim mdbgProcess = Me.Debugger.Attach(processID, version)

                ' Instantiate a ManagedProcess instance.
                Dim managedProcess = New ManagedProcess(mdbgProcess)

                ' Initialize the ManagedProcess instance.
                managedProcess.Initialize()

                Return managedProcess
            Catch ex As Exception
                Throw New ApplicationException("Error in AttachProcess.", ex)
            End Try
        End Function

        ''' <summary>
        ''' Launch a managed application to debug.
        ''' </summary>
        Public Function CreateProcess(ByVal applicationPath As String) As ManagedProcess
            Dim version As String = Nothing

            ' Determine whether the target is a managed application. If so, 
            ' get the runtime version.
            Dim isManaged As Boolean = ManagedProcess.IsManagedExecutableFile(
                applicationPath, version)

            If Not isManaged Then
                Throw New ArgumentException("It is not a managed application.")
            End If

            Try

                ' Launch a managed application to debug.
                Dim mdbgProcess = Me.Debugger.CreateProcess(
                    applicationPath, String.Empty, DebugModeFlag.Debug, version)

                Dim managedProcess = New ManagedProcess(mdbgProcess)

                managedProcess.Initialize()

                Return managedProcess
            Catch ex As Exception
                Throw New ApplicationException("Error in CreateProcess.", ex)
            End Try
        End Function
    End Class
End Namespace
