'***************************** Module Header ******************************\
'* Module Name:    MainPage.xaml.vb
'* Project:        VBWP8ProgressIndicator
'* Copyright (c) Microsoft Corporation
'*
'* This sample will demo how to work with ProgressIndicator in WP8 and 
'  hide it after the event.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************
Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.ComponentModel

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    Dim strMsg As String = String.Empty  ' Message of result.

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnWork_Click(sender As Object, e As RoutedEventArgs)
        ' Sample code to localize the ApplicationBar
        Dim prog As New ProgressIndicator()
        prog.IsVisible = True
        prog.IsIndeterminate = True
        prog.Text = "Working..."
        SystemTray.SetProgressIndicator(Me, prog)

        Deployment.Current.Dispatcher.BeginInvoke(Function()
                                                      btnWork.Visibility = Visibility.Collapsed
                                                      tbMessage.Text = "The work process begins, please wait for 5 seconds."
                                                      Return Nothing
                                                  End Function)

        RunProcessAsync(DateTime.Now)
    End Sub

    ''' <summary>
    ''' Run Process
    ''' </summary>
    ''' <param name="dumpDate"></param>
    Public Sub RunProcessAsync(dumpDate As DateTime)
        Dim worker As New BackgroundWorker()
        AddHandler worker.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf worker_RunWorkerCompleted)
        AddHandler worker.DoWork, New DoWorkEventHandler(AddressOf worker_DoWork)
        worker.RunWorkerAsync(dumpDate)
    End Sub

    ''' <summary>
    ''' Handler for DoWork
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub worker_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim worker As New BackgroundWorker()
        ' Do Work here
        Thread.Sleep(5 * 1000) ' 5 seconds

        Dim result = Await worker.RunWorkerTaskAsync()
    End Sub

    ''' <summary>
    ''' This is on the main thread, so we can update a UI Element or anything.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)
        RemoveHandler worker.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf worker_RunWorkerCompleted)
        RemoveHandler worker.DoWork, New DoWorkEventHandler(AddressOf worker_DoWork)

        Deployment.Current.Dispatcher.BeginInvoke(Function()
                                                      tbMessage.Text = "Work is complete."
                                                      Return Nothing
                                                  End Function)

        SystemTray.ProgressIndicator.IsVisible = False
    End Sub

End Class
