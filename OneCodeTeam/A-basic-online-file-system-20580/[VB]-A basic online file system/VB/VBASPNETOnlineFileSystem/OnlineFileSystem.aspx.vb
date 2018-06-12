'****************************** Module Header ******************************\
' Module Name:  OnlineFileSystem.aspx.vb
' Project:	    VBASPNETOnlineFileSystem
' Copyright (c) Microsoft Corporation.
' 
' This is the main form of this application. It is used to initialize the UI and 
' handle the events.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports System.Configuration
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class OnlineFileSystem

    Inherits System.Web.UI.Page

    'The root path on the server
    Public Shared RootPath As String

    'The current operation path
    Public Shared CurrentLocation As String

    Protected Sub Page_Load(ByVal sender As Object,
                            ByVal e As System.EventArgs) Handles Me.Load
        OnlineFileSystem.RootPath = ConfigurationManager.AppSettings.Item("RootPath")

        If Not Page.IsPostBack Then
            OnlineFileSystem.CurrentLocation = OnlineFileSystem.RootPath
            If Not Directory.Exists(OnlineFileSystem.RootPath) Then
                Directory.CreateDirectory(OnlineFileSystem.RootPath)
            End If
            ShowFolderItems()
        End If

        ShowCurrentLocation()
    End Sub

    Protected Sub gvFileSystem_RowDataBound(ByVal sender As Object,
                                            ByVal e As GridViewRowEventArgs)
        If ((e.Row.RowType = DataControlRowType.DataRow) AndAlso (
            (e.Row.RowState = DataControlRowState.Normal) OrElse (
                e.Row.RowState = DataControlRowState.Alternate))) Then
            DirectCast(e.Row.Cells.Item(4).Controls.Item(0), LinkButton).Attributes.Add(
                "onclick",
                String.Concat(
                    New String() {
                        "javascript:return confirm('Are you sure you want to delete the ",
                        IIf((e.Row.Cells.Item(3).Text = "Folder"), "Folder", "File"),
                        " " & ChrW(65306) & """",
                        DirectCast(e.Row.Cells.Item(0).Controls.Item(0), 
                    LinkButton).Text, """?')"}))
        End If
    End Sub

    Protected Sub gvFileSystem_RowCommand(ByVal sender As Object,
                                          ByVal e As GridViewCommandEventArgs)
        Dim fileExtension As Integer = Convert.ToInt32(e.CommandArgument)
        OnlineFileSystem.CurrentLocation =
            gvFileSystem.DataKeys.Item(0).Values.Item(2).ToString

        lbMessage.Text = ""

        ' Delete the file or folder
        If (e.CommandName = "DeleteFileOrFolder") Then
            If (gvFileSystem.DataKeys.Item(fileExtension).Values.Item(0).ToString =
                "Folder") Then
                lbMessage.Text = OCDIOObject.DeleteFolder(
                    gvFileSystem.DataKeys.Item(fileExtension).Values.Item(1).ToString)
            Else
                lbMessage.Text = OCDIOObject.DeleteFile(
                    gvFileSystem.DataKeys.Item(fileExtension).Values.Item(1).ToString)
            End If

            ShowFolderItems()
            ShowCurrentLocation()
        End If

        ' Open the folder or download the file
        If (e.CommandName = "Open") Then
            If (gvFileSystem.DataKeys.Item(fileExtension).Values.Item(0).ToString =
                "Folder") Then
                OnlineFileSystem.CurrentLocation =
                    (OnlineFileSystem.CurrentLocation & "\" &
                     gvFileSystem.DataKeys.Item(fileExtension).Values.Item(3).ToString)

                ShowFolderItems()
                ShowCurrentLocation()
            Else
                OCDIOObject.DownloadFile(
                    gvFileSystem.DataKeys.Item(fileExtension).Values.Item(1).ToString)
            End If
        End If

        ' Rename the file or folder
        If (e.CommandName = "Rename") Then
            pnlRename.Visible = True
            lbOldName.Text =
                gvFileSystem.DataKeys.Item(fileExtension).Values.Item(3).ToString
            lbOldName.ToolTip =
                gvFileSystem.DataKeys.Item(fileExtension).Values.Item(1).ToString
            pnlRename.ToolTip =
                gvFileSystem.DataKeys.Item(fileExtension).Values.Item(0).ToString
            tbNewName.Focus()
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Extension of the file you want to upload
        Dim fileExtension As String = String.Empty
        ' The full path of the file on server without an extension
        Dim fileName As String = String.Empty
        ' If there is already a file with the same name on the server, the file will be 
        ' upload with a new name.
        Dim newFileName As String = String.Empty
        If Not fuChooseFile.HasFile Then
            lbMessage.Text = "Please choose the file you want to upload. " &
                "Note: The file size cannot be zero."
        Else
            fileExtension = Path.GetExtension(fuChooseFile.FileName)

            fileName = String.Format(
                "{0}\{1}",
                OnlineFileSystem.CurrentLocation, fuChooseFile.FileName)

            If Not (String.IsNullOrEmpty(fileExtension)) Then
                fileName = fileName.Replace(fileExtension, "")
            End If

            If ((fileExtension.ToLower = ".exe") OrElse (
                fileExtension.ToLower = ".msi")) Then
                lbMessage.Text =
                    "The file you want to upload cannot be a .exe or .msi file."
            Else
                newFileName = fileName
                If (fuChooseFile.PostedFile.ContentLength >= &H2800000) Then
                    lbMessage.Text =
                        "The file you want to upload cannot be larger than 40 MB."
                Else
                    Try
                        Dim i As Integer = 0
                        Do While File.Exists((newFileName & fileExtension))
                            i += 1
                            newFileName = String.Format((fileName & "({0})"), i)
                        Loop
                        fuChooseFile.SaveAs((newFileName & fileExtension))
                        lbMessage.Text =
                            String.Format("The file ""{0}{1}"" was uploaded successfully!",
                                          Path.GetFileName(fileName), fileExtension)
                        ShowFolderItems()
                    Catch he As HttpException
                        lbMessage.Text =
                            String.Format(
                                "File {0} upload failed because of the following error:{1}.",
                                fuChooseFile.PostedFile.FileName, he.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Protected Sub btnNewFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (tbNewFolderName.Text = "") Then
            lbMessage.Text = "Please input a folder name!"
        Else
            lbMessage.Text = OCDIOObject.CreateFolder(
                (OnlineFileSystem.CurrentLocation & "\" & tbNewFolderName.Text))
            tbNewFolderName.Text = ""
            ShowFolderItems()
        End If
    End Sub

    Protected Sub lbtnFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        OnlineFileSystem.CurrentLocation =
            DirectCast(sender, LinkButton).ToolTip.Replace(
                "FileServerRoot", OnlineFileSystem.RootPath)
        AddHandler MyBase.Init, New EventHandler(AddressOf lbtnFolder_Click)

        ShowFolderItems()
        ShowCurrentLocation()
    End Sub

    Protected Sub btnCancle_Click(ByVal sender As Object, ByVal e As EventArgs)
        pnlRename.Visible = False
        lbMessage.Text = ""
    End Sub

    Protected Sub btnRename_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (tbNewName.Text = "") Then
            lbMessage.Text = "Please input the new name of the file or folder."
        Else
            If (pnlRename.ToolTip = "Folder") Then
                lbMessage.Text =
                    OCDIOObject.RenameFolder(lbOldName.ToolTip, tbNewName.Text)
            Else
                lbMessage.Text =
                    OCDIOObject.RenameFile(lbOldName.ToolTip, tbNewName.Text)
            End If

            tbNewName.Text = ""
            pnlRename.Visible = False

            ShowFolderItems()
        End If
    End Sub

    Private Sub ShowCurrentLocation()
        Dim strArrayLocation As String() =
            OnlineFileSystem.CurrentLocation.Replace(
                OnlineFileSystem.RootPath, "FileServerRoot").Split(New Char() {"\"c})
        Dim panelCurrentLocation As Panel =
            DirectCast(FindControl("pnlCurrentLocation"), Panel)

        panelCurrentLocation.Controls.Clear()

        Dim i As Integer
        For i = 0 To strArrayLocation.Length - 1
            Dim lbtnFolder As New LinkButton With { _
                .Text = strArrayLocation(i), _
                .ID = ("lbtnFolder" & i.ToString) _
            }
            AddHandler lbtnFolder.Click, New EventHandler(AddressOf lbtnFolder_Click)
            Dim path As String = strArrayLocation(0)
            Dim j As Integer = 1
            Do While (j <= i)
                path = (path & "\" & strArrayLocation(j))
                j += 1
            Loop
            lbtnFolder.ToolTip = path
            panelCurrentLocation.Controls.Add(lbtnFolder)
            Dim lbFolder As New Label With { _
                .Text = " \ " _
            }
            panelCurrentLocation.Controls.Add(lbFolder)
        Next i
    End Sub

    Private Sub ShowFolderItems()
        gvFileSystem.AutoGenerateColumns = False
        gvFileSystem.DataSource =
            OCDIOObject.GetAllItemsInTheDirectory(OnlineFileSystem.CurrentLocation)
        gvFileSystem.DataBind()
    End Sub

End Class
