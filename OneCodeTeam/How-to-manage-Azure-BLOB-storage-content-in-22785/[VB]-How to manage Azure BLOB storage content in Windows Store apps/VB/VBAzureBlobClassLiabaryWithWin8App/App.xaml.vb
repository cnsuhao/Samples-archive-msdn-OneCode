﻿'**************************** Module Header ******************************\
' Module Name:	App.xaml.vb
' Project:		VBAzureBlobClassLiabaryWithWin8App
' Copyright (c) Microsoft Corporation.
' 
' Windows Azure storage class library now supports windows store app.
' This sample will show you how to operate Azure blob storage in your store app, 
' including upload/download/delete file from blob storage.
'
' App.xaml.vb
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Blob

' The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

''' <summary>
''' Provides application-specific behavior to supplement the default Application class.
''' </summary>
NotInheritable Class App
    Inherits Application
    Private Shared ReadOnly cred As New StorageCredentials("[Your Azure Storage Account Name]", "[ Your Azure Storage Account Key]")
    Public Shared ReadOnly container As New CloudBlobContainer(New Uri("http://[ Your Azure Storage Account Name].blob.core.windows.net/imagescontianer/"), cred)
    ''' <summary>
    ''' Invoked when the application is launched normally by the end user.  Other entry points
    ''' will be used when the application is launched to open a specific file, to display
    ''' search results, and so forth.
    ''' </summary>
    ''' <param name="args">Details about the launch request and process.</param>
    Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
        Dim rootFrame As Frame = Window.Current.Content

        ' Do not repeat app initialization when the Window already has content,
        ' just ensure that the window is active

        If rootFrame Is Nothing Then
            ' Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = New Frame()
            If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' TODO: Load state from previously suspended application
            End If
            ' Place the frame in the current Window
            Window.Current.Content = rootFrame
        End If
        If rootFrame.Content Is Nothing Then
            ' When the navigation stack isn't restored navigate to the first page,
            ' configuring the new page by passing required information as a navigation
            ' parameter
            If Not rootFrame.Navigate(GetType(MainPage), args.Arguments) Then
                Throw New Exception("Failed to create initial page")
            End If
        End If

        ' Ensure the current window is active
        Window.Current.Activate()
    End Sub

    ''' <summary>
    ''' Invoked when application execution is being suspended.  Application state is saved
    ''' without knowing whether the application will be terminated or resumed with the contents
    ''' of memory still intact.
    ''' </summary>
    ''' <param name="sender">The source of the suspend request.</param>
    ''' <param name="e">Details about the suspend request.</param>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        ' TODO: Save application state and stop any background activity
        deferral.Complete()
    End Sub

End Class
