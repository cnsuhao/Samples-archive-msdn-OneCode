'************************** Module Header ******************************\
' Module Name:  ManagedProcess.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' This class represents a managed process. It contains a MDbgProcess field
' and a System.Diagnostics.Process field. When a new instance is initialized,
' it will attach a debugger to the target process, and supplied following 
' features:
' 
' 1. Log the activities of the debuggee. The activities include:
'    a. A thread is created or a thread exits.
'    b. An AppDomain is created or an AppDomain is unloaded.
'    c. An exception is thrown. 
'    d. Other output information like Debugger.Log()
'    e. The process exits. 
'    
'    If there is an unhandled exception in the debuggee, the OperationErrorOccurred
'    event will be raised.
' 2. Check whether a running process is managed.
' 3. Check whether an executable file is managed. 
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

Imports System.ComponentModel
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.Samples.Debugging.CorDebug
Imports Microsoft.Samples.Debugging.CorDebug.NativeApi
Imports Microsoft.Samples.Debugging.MdbgEngine

Namespace Debugger
    <PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust"),
    PermissionSet(SecurityAction.InheritanceDemand, Name:="FullTrust")>
    Partial Public Class ManagedProcess
        Implements IDisposable

        Private _disposed As Boolean = False

        ''' <summary>
        ''' Represents a Process in which code execution context can be controlled.
        ''' </summary>
        Private _mdbgProcess As MDbgProcess
        Public Property MDbgProcess() As MDbgProcess
            Get
                Return _mdbgProcess
            End Get
            Private Set(ByVal value As MDbgProcess)
                _mdbgProcess = value
            End Set
        End Property

        Private _diagnosticsProcess As Process = Nothing

        ''' <summary>
        ''' Get System.Diagnostics.Process using ProcessID.
        ''' </summary>
        Public ReadOnly Property DiagnosticsProcess() As Process
            Get
                Return _diagnosticsProcess
            End Get
        End Property

        ''' <summary>
        ''' The ID of the process. 
        ''' </summary>
        Public ReadOnly Property ProcessID() As Integer
            Get
                Return DiagnosticsProcess.Id
            End Get
        End Property

        ''' <summary>
        ''' The name of the process. 
        ''' </summary>
        Public ReadOnly Property ProcessName() As String
            Get
                Return DiagnosticsProcess.ProcessName
            End Get
        End Property



#Region "Events"

        Public Event OperationErrorOccurred As EventHandler(Of ErrorEventArgs)

        Public Event PostEvent As EventHandler(Of PostEventArgs)

        Public Event ProcessExit As EventHandler

#End Region

#Region "Constructor"

        Friend Sub New(ByVal mdbgProcess As MDbgProcess)
            If mdbgProcess Is Nothing Then
                Throw New ArgumentNullException(
                    "mdbgProcess", "The MDbgProcesscould not be null. ")
            End If

            Me.MDbgProcess = mdbgProcess

            Dim process = System.Diagnostics.Process.GetProcessById(mdbgProcess.CorProcess.Id)
            If process Is Nothing Then
                Throw New ArgumentException(String.Format(
                                            "{0}{1}",
                                            "Cannot find the process with the ID = ",
                                            mdbgProcess.CorProcess.Id))
            End If

            Me._diagnosticsProcess = process
        End Sub

#End Region


#Region "Initialize"

        ''' <summary>
        ''' Initialize the process.
        ''' </summary>
        Public Sub Initialize()
            ' Make the attach operation work.
            Dim result As Boolean = Me.MDbgProcess.Go().WaitOne()

            If Not result Then
                Throw New ApplicationException(
                    String.Format("The process with an ID {0} could not be attached. ",
                                  Me.DiagnosticsProcess.Id))
            End If

            AddHandler Me.MDbgProcess.PostDebugEvent, AddressOf MDbgProcess_PostDebugEvent

            ' After the process is attached, we have to make it continue.
            Me.MDbgProcess.Go()

        End Sub

#End Region


#Region "IDisposable interface"

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            ' Protect from being called multiple times.
            If _disposed Then
                Return
            End If

            If disposing Then
                ' Clean up all managed resources.
                If Me.MDbgProcess IsNot Nothing Then

                    ' Make sure the underlying CorProcess was stopped before 
                    ' detached it.  
                    If Me.MDbgProcess.IsAlive Then

                        Dim waithandler = Me.MDbgProcess.AsyncStop()
                        waithandler.WaitOne()
                        Me.MDbgProcess.Detach()
                    End If

                End If
            End If

            _disposed = True
        End Sub


#End Region


#Region "Raise events"

        ''' <summary>
        ''' Log the activities of the debuggee. The activities include:
        ''' a. A thread is created or a thread exits.
        ''' b. An AppDomain is created or an AppDomain is unloaded.
        ''' c. An exception is thrown. 
        ''' d. Other output information like Debugger.Log()
        ''' e. The process exits. 
        ''' 
        ''' If there is an unhandled exception in the debuggee, the OperationErrorOccurred
        ''' event will be raised.
        ''' </summary>
        Private Sub MDbgProcess_PostDebugEvent(ByVal sender As Object,
                                               ByVal e As CustomPostCallbackEventArgs)
            Try
                Select Case e.CallbackType
                    Case ManagedCallbackType.OnProcessExit
                        Me.OnProcessExit()
                    Case ManagedCallbackType.OnException2
                        Dim exceptionEventArgs = TryCast(e.CallbackArgs, CorException2EventArgs)

                        If exceptionEventArgs IsNot Nothing Then
                            Dim exceptionValue As New MDbgValue(
                                Me.MDbgProcess, exceptionEventArgs.Thread.CurrentException)

                            Dim exceptionType As String = exceptionValue.GetStringValue(False)
                            Dim exceptionMessage As String = exceptionValue.GetField("_message").GetStringValue(True)

                            ' If there is an unhandled exception in the debuggee.
                            If exceptionEventArgs.EventType = CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED Then
                                Me.OnOperationErrorOccurred(New ErrorEventArgs With
                                                            {.Message = "Unhandled exception occurred in the debuggee.",
                                                             .Error = New ApplicationException(
                                                                 String.Format("Unhandled exception occurred in the debuggee.{2}Type:{0}{2}Message:{1}",
                                                                               exceptionType, exceptionMessage, Environment.NewLine)),
                                                             .Ignorable = True})
                            Else
                                AddActivity("Event Type: {0} {3} {1}:{2}",
                                            exceptionEventArgs.EventType,
                                            exceptionType,
                                            exceptionMessage,
                                            Environment.NewLine)

                            End If
                        End If

                        ' Make the process continue.
                        exceptionEventArgs.Continue = True

                    Case ManagedCallbackType.OnCreateThread

                        Dim createThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)

                        If createThreadEventArgs IsNot Nothing Then
                            AddActivity("Create Thread. ThreadID: {0}",
                                        createThreadEventArgs.Thread.Id)
                        End If

                    Case ManagedCallbackType.OnThreadExit
                        Dim threadExitEventArgs As CorThreadEventArgs = TryCast(e.CallbackArgs, CorThreadEventArgs)

                        If threadExitEventArgs IsNot Nothing Then
                            AddActivity("Thread Exit. ThreadID: {0}",
                                        threadExitEventArgs.Thread.Id)
                        End If

                    Case ManagedCallbackType.OnCreateAppDomain
                        Dim createAppDomainEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)

                        If createAppDomainEventArgs IsNot Nothing Then
                            AddActivity("Create AppDomain. DomainID: {0} DomainName: {1}",
                                        createAppDomainEventArgs.AppDomain.Id,
                                        createAppDomainEventArgs.AppDomain.Name)
                        End If

                    Case ManagedCallbackType.OnAppDomainExit
                        Dim appDomainExitEventArgs = TryCast(e.CallbackArgs, CorAppDomainEventArgs)

                        If appDomainExitEventArgs IsNot Nothing Then
                            AddActivity("AppDomain Exit. DomainID: {0} DomainName: {1}",
                                        appDomainExitEventArgs.AppDomain.Id,
                                        appDomainExitEventArgs.AppDomain.Name)
                        End If

                    Case ManagedCallbackType.OnLogMessage
                        Dim logMessageEventArgs = TryCast(e.CallbackArgs, CorLogMessageEventArgs)

                        If logMessageEventArgs IsNot Nothing Then
                            AddActivity("Log Message: {0}", logMessageEventArgs.Message)
                        End If
                    Case Else
                End Select
            Catch
            End Try
        End Sub

        ''' <summary>
        ''' Log the activity.
        ''' </summary>
        Private Sub AddActivity(ByVal format As String, ByVal ParamArray arguments() As Object)
            Dim msg As String = String.Format(format, arguments)
            AddActivity(msg)
        End Sub

        ''' <summary>
        ''' Log the activity.
        ''' </summary>
        Private Sub AddActivity(ByVal msg As String)
            Me.OnPostEvent(New PostEventArgs With {.EventMessage = msg})
        End Sub

        ''' <summary>
        ''' Raise the PostEvent event.
        ''' </summary>
        Protected Overridable Sub OnPostEvent(ByVal e As PostEventArgs)
            RaiseEvent PostEvent(Me, e)
        End Sub

        ''' <summary>
        ''' Raise the ProcessExit event.
        ''' </summary>
        Protected Overridable Sub OnProcessExit()
            RaiseEvent ProcessExit(Me, EventArgs.Empty)
        End Sub

        ''' <summary>
        ''' Raise the OperationErrorOccurred event.
        ''' </summary>
        Protected Overridable Sub OnOperationErrorOccurred(ByVal e As ErrorEventArgs)
            RaiseEvent OperationErrorOccurred(Me, e)
        End Sub

#End Region


#Region "Static Methods"



        ''' <summary>
        ''' Get all the running managed processes.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function EnumManagedProcesses() As List(Of Process)
            Dim currentProcessID As Integer = Process.GetCurrentProcess().Id

            Dim host As New CLRMetaHost()

            Dim managedProcess As New List(Of Process)()

            For Each proc As Process In Process.GetProcesses()
                If proc.Id = currentProcessID Then
                    Continue For
                End If

                Try
                    Dim isManagedProcess As Boolean = Debugger.ManagedProcess.IsManagedProcess(host, proc.Id)

                    If isManagedProcess Then
                        managedProcess.Add(proc)
                    End If
                Catch e1 As Win32Exception
                    Continue For
                Catch e2 As COMException
                    Continue For
                End Try
            Next proc
            Return managedProcess
        End Function

        ''' <summary>
        ''' Determine whether a process is managed.
        ''' If a process loads .NET runtime, it is a managed process.
        ''' </summary>
        Public Shared Function IsManagedProcess(ByVal host As CLRMetaHost,
                                                ByVal processID As Integer) As Boolean
            Dim enumerable As IEnumerable(Of CLRRuntimeInfo) = host.EnumerateLoadedRuntimes(processID)

            Return enumerable.Count() > 0
        End Function

        ''' <summary>
        ''' Determine whether a process is managed.
        ''' If a process loads .NET runtime, it is a managed process.
        ''' <summary>
        Public Shared Function IsManagedProcess(ByVal processID As Integer) As Boolean
            Dim host As New CLRMetaHost()

            Dim enumerable As IEnumerable(Of CLRRuntimeInfo) =
                host.EnumerateLoadedRuntimes(processID)

            Return enumerable.Count() > 0
        End Function

        ''' <summary>
        ''' Determine whether an application is managed.
        ''' </summary>
        Public Shared Function IsManagedExecutableFile(ByVal applicationPath As String,
                                                       ByRef version As String) As Boolean
            version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath)
            Return Not String.IsNullOrEmpty(version)
        End Function


#End Region
    End Class
End Namespace
