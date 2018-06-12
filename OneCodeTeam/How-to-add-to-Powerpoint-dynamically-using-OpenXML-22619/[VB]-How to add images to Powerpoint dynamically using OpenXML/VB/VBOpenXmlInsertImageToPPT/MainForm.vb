'***************************** Module Header ******************************\
' Module Name:  MainForm.vb
' Project:      VBOpenXmlInsertImageToPPT
' Copyright(c)  Microsoft Corporation.
' 
' This is the main form of this application. 
' It is used to initialize the UI and handle the events.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.IO
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Presentation

Public Class MainForm

    ''' <summary>
    ''' Handle Click events of Open button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOpenPPt_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenPPt.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = "PowerPoint document (*.pptx)|*.pptx"
            dialog.InitialDirectory = Environment.CurrentDirectory

            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbPPtPath.Text = dialog.FileName
            End If
        End Using

    End Sub

    ''' <summary>
    ''' Handle Click events of Select button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSelectImg_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectImg.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Pictures(*.jpg;*.png)|*.jpg;*.png"
            dialog.InitialDirectory = Environment.CurrentDirectory

            ' Retore the directory before closing
            dialog.RestoreDirectory = True
            If dialog.ShowDialog() = DialogResult.OK Then
                Me.txbImagePath.Text = dialog.FileName
            End If
        End Using

    End Sub

    ''' <summary>
    ''' Handle client event of Insert button 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnInsert_Click(sender As System.Object, e As System.EventArgs) Handles btnInsert.Click
        Dim pptFilePath As String = txbPPtPath.Text.Trim()
        Dim imagefilePath As String = txbImagePath.Text.Trim()
        Dim imageExt As String = Path.GetExtension(imagefilePath)
        If imageExt.Equals("jpg", StringComparison.OrdinalIgnoreCase) Then
            imageExt = "image/jpeg"
        Else
            imageExt = "image/png"
        End If
        Dim condition As Boolean = String.IsNullOrEmpty(pptFilePath) OrElse Not File.Exists(pptFilePath) OrElse String.IsNullOrEmpty(imagefilePath) OrElse Not File.Exists(imagefilePath)
        If condition Then
            MessageBox.Show("The PowerPoint or iamge file is invalid,Please select an existing file again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using presentationDocument__1 As PresentationDocument = PresentationDocument.Open(pptFilePath, True)
                ' Get the presentation Part of the presentation document
                Dim presentationPart As PresentationPart = presentationDocument__1.PresentationPart
                Dim slide As Slide = New InsertImage().InsertSlide(presentationPart, "Title Only")
                Dim insertImage As New InsertImage()
                insertImage.InsertImageInLastSlide(slide, imagefilePath, imageExt)
                slide.Save()
                presentationDocument__1.PresentationPart.Presentation.Save()
                MessageBox.Show("Insert Image Successfully,you can check with opening PowerPoint")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub
End Class
