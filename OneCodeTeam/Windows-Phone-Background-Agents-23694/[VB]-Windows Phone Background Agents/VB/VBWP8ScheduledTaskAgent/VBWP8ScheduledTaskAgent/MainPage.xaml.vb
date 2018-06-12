'/****************************** Module Header ******************************\
'Module Name:  MainPage.xaml.vb
'Project:      VBWP8ScheduledDemo
'Copyright (c) Microsoft Corporation.

'This example demonstrates how to use Scheduled Task in Windows phone.
'It mainly covers 3 parts:

'1.       How to create a scheduled task.
'2.       How to catch the variety errors threw by scheduled task.
'3.       How to set the process safe by class Mutex.

'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'All other rights reserved.

'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Microsoft.Phone.Scheduler
Imports System.IO.IsolatedStorage

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub StartPeriodicTask()
        Dim periodicTask As New PeriodicTask("PeriodicTaskDemo")
        periodicTask.Description = "Are presenting a periodic task"
        Try
            ScheduledActionService.Add(periodicTask)
            ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(3))
            MessageBox.Show("Open the background agent success")
        Catch exception As InvalidOperationException
            If exception.Message.Contains("exists already") Then
                MessageBox.Show("Since then the background agent success is already running")
            End If
            If exception.Message.Contains("BNS Error: The action is disabled") Then
                MessageBox.Show("Background processes for this application has been prohibited")
            End If
            If exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added.") Then
                MessageBox.Show("You open the daemon has exceeded the hardware limitations")
            End If

        Catch generatedExceptionName As SchedulerServiceException
        End Try
    End Sub
    Private Sub StopPeriodicTask()
        Try
            ScheduledActionService.Remove("PeriodicTaskDemo")
            MessageBox.Show("Turn off the background agent successfully")
        Catch exception As InvalidOperationException
            If exception.Message.Contains("doesn't exist") Then
                MessageBox.Show("Since then the background agent success is not running")
            End If

        Catch generatedExceptionName As SchedulerServiceException
        End Try
    End Sub
    Private Sub StartPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
        StartPeriodicTask()
        SetData()
    End Sub
    Private Sub StopPeriodicTask_Click(sender As Object, e As RoutedEventArgs)
        StopPeriodicTask()
    End Sub
    Public Sub SetData()
        Dim mutex As New System.Threading.Mutex(False, "ScheduledAgentData")
        mutex.WaitOne()
        Dim setting As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
        If Not setting.Contains("ScheduledAgentData") Then
            setting.Add("ScheduledAgentData", "Foreground data")
        End If
        mutex.ReleaseMutex()
    End Sub
End Class