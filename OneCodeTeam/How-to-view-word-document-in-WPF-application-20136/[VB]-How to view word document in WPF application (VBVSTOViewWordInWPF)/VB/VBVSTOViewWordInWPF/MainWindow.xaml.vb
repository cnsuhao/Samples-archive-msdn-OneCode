'***************************** Module Header ******************************\
' Module Name:  MainWindow.xaml.vb
' Project:               VBVSTOViewWordInWPF
' Copyright(c)      Microsoft Corporation.
' 
' This is the main form of this application. It is used to initialize the control 
' and handle the events
' Users must selected existing word document on local machine firstly.
' Second, Click "View  Word Doc" button to load word document into DocumentViewer control 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************

Imports System.IO
Imports System.Windows
Imports System.Windows.Xps.Packaging
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Win32
Imports Word = Microsoft.Office.Interop.Word

Class MainWindow

    ''' <summary>
    '''  Select Word file 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSelectWord_Click(sender As Object, e As RoutedEventArgs)
        ' Initialize an OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()

        ' Set filter and RestoreDirectory
        openFileDialog.RestoreDirectory = True
        openFileDialog.Filter = "Word documents(*.doc;*.docx)|*.doc;*.docx"

        Dim result As System.Nullable(Of Boolean) = openFileDialog.ShowDialog()
        If result = True Then
            If openFileDialog.FileName.Length > 0 Then
                txbSelectedWordFile.Text = openFileDialog.FileName
            End If
        End If
    End Sub

    ''' <summary>
    '''  Convert the word document to xps document
    ''' </summary>
    ''' <param name="wordFilename">Word document Path</param>
    ''' <param name="xpsFilename">Xps document Path</param>
    ''' <returns></returns>
    Private Function ConvertWordToXps(wordFilename As String, xpsFilename As String) As XpsDocument
        ' Create a WordApplication and host word document
        Dim wordApp As Word.Application = New Microsoft.Office.Interop.Word.Application()
        Try
            wordApp.Documents.Open(wordFilename)

            ' To Invisible the word document
            wordApp.Application.Visible = False

            ' Minimize the opened word document
            wordApp.WindowState = WdWindowState.wdWindowStateMinimize

            Dim doc As Document = wordApp.ActiveDocument

            doc.SaveAs(xpsFilename, WdSaveFormat.wdFormatXPS)

            Dim xpsDocument As New XpsDocument(xpsFilename, FileAccess.Read)
            Return xpsDocument
        Catch ex As Exception
            MessageBox.Show("Error occurs, The error message is  " & ex.ToString())
            Return Nothing
        Finally
            wordApp.Documents.Close()
            DirectCast(wordApp, _Application).Quit(WdSaveOptions.wdDoNotSaveChanges)
        End Try
    End Function

    ''' <summary>
    '''  View Word Document in WPF DocumentView Control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnViewDoc_Click(sender As Object, e As RoutedEventArgs)
        Dim wordDocument As String = txbSelectedWordFile.Text
        If String.IsNullOrEmpty(wordDocument) OrElse Not File.Exists(wordDocument) Then
            MessageBox.Show("The file is invalid. Please select an existing file again.")
        Else
            Dim convertedXpsDoc As String = String.Concat(Path.GetTempPath(), "\", Guid.NewGuid().ToString(), ".xps")
            Dim xpsDocument As XpsDocument = ConvertWordToXps(wordDocument, convertedXpsDoc)
            If xpsDocument Is Nothing Then
                Return
            End If

            documentviewWord.Document = xpsDocument.GetFixedDocumentSequence()
        End If
    End Sub

End Class
