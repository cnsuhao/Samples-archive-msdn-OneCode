Imports Microsoft.Phone.Scheduler
Imports Microsoft.Phone.Shell
Imports System.IO.IsolatedStorage

Public Class ScheduledAgent
    Inherits ScheduledTaskAgent

    Private Shared _classInitialized As Boolean

    ''' <remarks>
    ''' ScheduledAgent constructor, initializes the UnhandledException handler
    ''' </remarks>
    Public Sub ScheduledAgent()

        If Not _classInitialized Then
            _classInitialized = True
            ' Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(
            Sub()
                AddHandler Application.Current.UnhandledException, AddressOf ScheduledAgent_UnhandledException
            End Sub)
        End If

    End Sub

    ''' Code to execute on Unhandled Exceptions
    Private Sub ScheduledAgent_UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs)

        If System.Diagnostics.Debugger.IsAttached Then
            ' An unhandled exception has occurred break into the debugger
            System.Diagnostics.Debugger.Break()
        End If

    End Sub

    ''' <summary>
    ''' Agent that runs a scheduled task
    ''' </summary>
    ''' <param name="task">
    ''' The invoked task
    ''' </param>
    ''' <remarks>
    ''' This method is called when a periodic or resource intensive task is invoked
    ''' </remarks>
    Protected Overrides Sub OnInvoke(Task As ScheduledTask)

        If Task.Name = "PeriodicTaskDemo" Then
            Dim toast As New ShellToast()
            Dim mutex As New System.Threading.Mutex(True, "ScheduledAgentData")
            mutex.WaitOne()
            Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
            toast.Title = setting("ScheduledAgentData").ToString()
            mutex.ReleaseMutex()
            toast.Content = "Task Running"
            toast.Show()
        End If
        ScheduledActionService.LaunchForTest(Task.Name, TimeSpan.FromSeconds(3))
        NotifyComplete()

    End Sub
End Class