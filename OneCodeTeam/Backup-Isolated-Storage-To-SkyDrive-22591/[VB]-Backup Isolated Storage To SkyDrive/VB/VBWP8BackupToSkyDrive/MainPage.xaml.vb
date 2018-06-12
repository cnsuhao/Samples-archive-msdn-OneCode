'***************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8BackupToSkyDrive
' Copyright (c) Microsoft Corporation
'
' This demo shows how you can save Isolated Storage's files to SkyDrive.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Tasks
Imports System.Collections.Generic
Imports Microsoft.Live
Imports Microsoft.Live.Controls
Imports System.IO
Imports System.IO.IsolatedStorage

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Private cameraCaputreTask As CameraCaptureTask = Nothing         'CameraCaptureTask instance.
    Private client As LiveConnectClient = Nothing
    Private session As LiveConnectSession = Nothing
    Private strSkyDriveFolderName As String = "IsolatedStorageFolder" ' The folder name for backups
    Private strSkyDriveFolderID As String = String.Empty              ' The id of the folder name for backups
    Private fileID As String = Nothing                                ' The file id of your backup file
    Private readStream As IsolatedStorageFileStream = Nothing         ' The stream for restoring data 
    Private fileName As String = "MyAppBackup.jpg"                    ' Backup name for the capture image. 

    ' Constructor
    Public Sub New()
        InitializeComponent()

        ' SignIn button
        btnSignIn.ClientId = "00000000480E7666"
        btnSignIn.Scopes = "wl.basic wl.signin wl.offline_access wl.skydrive_update"
        btnSignIn.Branding = BrandingType.Windows
        btnSignIn.TextType = ButtonTextType.SignIn
        AddHandler btnSignIn.SessionChanged, AddressOf btnSignIn_SessionChanged

        ' CameraCaptureTask
        cameraCaputreTask = New CameraCaptureTask()
        AddHandler cameraCaputreTask.Completed, AddressOf cameraCaputreTask_Completed
    End Sub

    ''' <summary>
    ''' Show the camera application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnShowCamera_Click(sender As Object, e As RoutedEventArgs)
        cameraCaputreTask.Show()
    End Sub

    ''' <summary>
    ''' Processing when the chooser task is completed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cameraCaputreTask_Completed(sender As Object, e As PhotoResult)
        If e.TaskResult = TaskResult.OK Then
            Try
                ' Create a BitmapImage.
                Dim bitmap As New BitmapImage()
                bitmap.SetSource(e.ChosenPhoto)
                ' Display the image.
                cameraImage.Source = bitmap

                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, "Captured image available, saving picture.")

                ' Save picture as JPEG to isolated storage.
                Using isStore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                    Dim uri As New Uri(fileName, UriKind.Relative)
                    Dim strTempFile As String = uri.ToString()

                    If isStore.FileExists(strTempFile) Then
                        isStore.DeleteFile(strTempFile)
                    End If

                    Using targetStream As IsolatedStorageFileStream = isStore.OpenFile(strTempFile, FileMode.Create, FileAccess.Write)
                        Dim wb As New WriteableBitmap(bitmap)
                        ' Encode WriteableBitmap object to a JPEG stream.
                        Extensions.SaveJpeg(wb, targetStream, wb.PixelWidth, wb.PixelHeight, 0, 85)
                    End Using
                End Using

                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, "Picture has been saved to isolated storage.")
            Finally
                ' Close image stream
                e.ChosenPhoto.Close()
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Write message to the UI thread.
    ''' </summary>
    ''' <param name="textBlock">The control to update.</param>
    ''' <param name="strTip">The message to show.</param>
    Private Sub UpdateUIThread(textBlock As TextBlock, strTip As String)
        Deployment.Current.Dispatcher.BeginInvoke(Sub() textBlock.Text = strTip)
    End Sub

    ''' <summary>
    ''' Event triggered when Skydrive sign in status is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSignIn_SessionChanged(sender As Object, e As LiveConnectSessionChangedEventArgs)
        ' If the user is signed in.
        If e.Status = LiveConnectSessionStatus.Connected Then
            session = e.Session
            client = New LiveConnectClient(e.Session)
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Accessing SkyDrive...")

            ' Get the folders in their skydrive.
            AddHandler client.GetCompleted, New EventHandler(Of LiveOperationCompletedEventArgs)(AddressOf btnSignin_GetCompleted)
            client.GetAsync("me/skydrive/files?filter=folders,albums")
        Else
            ' Otherwise the user isn't signed in.
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Not signed in.")
            client = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Event for if the user just logged in.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSignin_GetCompleted(sender As Object, e As LiveOperationCompletedEventArgs)
        If e.[Error] Is Nothing Then
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Loading folder...")

            ' Check all the folders in user's skydrive.
            Dim folderData As Dictionary(Of String, Object) = DirectCast(e.Result, Dictionary(Of String, Object))
            Dim folders As List(Of Object) = DirectCast(folderData("data"), List(Of Object))

            ' Loop all folders to check if the isolatedstoragefolder exists.
            For Each item As Object In folders
                Dim folder As Dictionary(Of String, Object) = DirectCast(item, Dictionary(Of String, Object))
                If folder("name").ToString() = strSkyDriveFolderName Then
                    strSkyDriveFolderID = folder("id").ToString()
                End If
            Next

            ' If the IsolatedStorageFolder does not exist, create it.
            If strSkyDriveFolderID = String.Empty Then
                Dim skyDriveFolderData As New Dictionary(Of String, Object)()
                skyDriveFolderData.Add("name", strSkyDriveFolderName)
                AddHandler client.PostCompleted, New EventHandler(Of LiveOperationCompletedEventArgs)(AddressOf CreateFolder_Completed)
                ' To create the IsolatedStorageFolder in Skydrive.
                client.PostAsync("me/skydrive", skyDriveFolderData)

                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, "Creating folder...")
            Else
                ' Check if the backup file is in the IsolatedStorageFile
                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, "Ready to backup.")
                UpdateUIThread(tbDate, "Checking for previous backups...")
                btnBackup.IsEnabled = True

                ' Get the files' ID if they exists.
                client = New LiveConnectClient(session)
                AddHandler client.GetCompleted, New EventHandler(Of LiveOperationCompletedEventArgs)(AddressOf getFiles_GetCompleted)
                ' Get the file in the folder.
                client.GetAsync(strSkyDriveFolderID & "/files")
            End If
        Else
            MessageBox.Show(e.[Error].Message)
        End If
    End Sub

    ''' <summary>
    ''' Backup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBackup_Click(sender As Object, e As RoutedEventArgs)
        If client Is Nothing OrElse client.Session Is Nothing Then
            MessageBox.Show("You must sign in first.")
        Else
            If MessageBox.Show("Are you sure you want to backup? This will overwrite your old backup file!", "Backup?", MessageBoxButton.OKCancel) = MessageBoxResult.OK Then
                UploadFile()
            End If
        End If
    End Sub

    ''' <summary>
    ''' The IsolatedStorageData folder have been created.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CreateFolder_Completed(sender As Object, e As LiveOperationCompletedEventArgs)
        If e.[Error] Is Nothing Then
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Ready to backup.")
            UpdateUIThread(tbDate, "No previous backup available.")

            Dim folder As Dictionary(Of String, Object) = DirectCast(e.Result, Dictionary(Of String, Object))
            ' Get the folder ID.
            strSkyDriveFolderID = folder("id").ToString()
            btnBackup.IsEnabled = True
        Else
            MessageBox.Show(e.[Error].Message)
        End If
    End Sub

    ''' <summary>
    ''' Upload Files.
    ''' </summary>
    Public Sub UploadFile()
        ' The folder must exist, it should have already been created.
        If strSkyDriveFolderID <> String.Empty Then
            AddHandler Me.client.UploadCompleted, New EventHandler(Of LiveOperationCompletedEventArgs)(AddressOf IsFile_UploadCompleted)

            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Uploading backup...")
            UpdateUIThread(tbDate, "")

            Try
                Using iso As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
                    ' Upload many files.
                    For Each itemName As String In iso.GetFileNames()
                        fileName = itemName
                        readStream = iso.OpenFile(fileName, FileMode.Open, FileAccess.Read)
                        client.UploadAsync(strSkyDriveFolderID, fileName, readStream, OverwriteOption.Overwrite, Nothing)

                        ' [-or-]

                        ' Upload one file.
                        'readStream = iso.OpenFile(fileName, FileMode.Open, FileAccess.Read);
                        'client.UploadAsync(strSkyDriveFolderID, fileName, readStream, OverwriteOption.Overwrite, null);
                    Next
                End Using
            Catch ex As Exception
                MessageBox.Show("Error accessing IsolatedStorage. Please close the app and re-open it, and then try backing up again!", "Backup Failed", MessageBoxButton.OK)

                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, ex.Message & ".Close the app and start again.")
                UpdateUIThread(tbDate, "")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Check if the backup have finished.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    Private Sub IsFile_UploadCompleted(sender As Object, args As LiveOperationCompletedEventArgs)
        If args.[Error] Is Nothing Then
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Backup complete.")
            ' In order to prevent the crash when user click the backup button again, dispose the readStream.
            readStream.Dispose()
            ' Write message to the UI thread.
            UpdateUIThread(tbDate, "Checking for new backup...")

            ' Get the newly created fileID's (it will update the time too, and enable restoring).
            client = New LiveConnectClient(session)
            AddHandler client.GetCompleted, New EventHandler(Of LiveOperationCompletedEventArgs)(AddressOf getFiles_GetCompleted)
            client.GetAsync(strSkyDriveFolderID & "/files")
        Else
            ' Write message to the UI thread.
            UpdateUIThread(tbDebug, "Error uploading file: " & args.[Error].ToString())
        End If
    End Sub

    ''' <summary>
    ''' Check whether the backup file exists in the folder.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub getFiles_GetCompleted(sender As Object, e As LiveOperationCompletedEventArgs)
        Dim data As List(Of Object) = DirectCast(e.Result("data"), List(Of Object))

        ' Write message to the UI thread.
        UpdateUIThread(tbDate, " Getting previous backup...")
        Dim [date] As DateTimeOffset = DateTimeOffset.MinValue

        For Each content As IDictionary(Of String, Object) In data
            If DirectCast(content("name"), String).Equals(fileName) Then
                fileID = DirectCast(content("id"), String)
                Try
                    [date] = DateTimeOffset.Parse(DirectCast(content("updated_time"), String).Substring(0, 19))
                Catch ex As Exception
                    ' Write message to the UI thread.
                    UpdateUIThread(tbDebug, ex.Message)
                End Try

                Exit For
            End If
        Next

        If fileID IsNot Nothing Then
            Try
                Dim strTemp As String = If(([date] <> DateTimeOffset.MinValue), "Last backup on " & [date].Add([date].Offset).DateTime, "Last backup on: unknown")

                UpdateUIThread(tbDate, strTemp)
            Catch ex As Exception
                ' Write message to the UI thread.
                UpdateUIThread(tbDebug, ex.Message)
                UpdateUIThread(tbDate, "Last backup on: unknown")
            End Try
        Else
            UpdateUIThread(tbDate, "No previous backup available")
        End If
    End Sub
End Class