'*************************************** Module Header *****************************'
' Module Name:  MyControl.xaml.vb
' Project:      VBVSPackageStatusBar
' Copyright (c) Microsoft Corporation.
' 
' In this sample, we will demo:
' 1. Write highlighted text in feedback region
' 2. Read text from feedback region
' 3. Show progress bar in status bar
' 4. Show animation in the status bar
' 5. Write row, column and char to designer region
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************************'

Imports Microsoft.VisualStudio.Shell.Interop
Imports System.Windows

'''<summary>
'''  Interaction logic for MyControl.xaml
'''</summary>
Partial Public Class MyControl
    Inherits System.Windows.Controls.UserControl

    Public Property SvcStatusBar() As IVsStatusbar

    Private Sub btnWriteFeedback_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnWriteFeedback.Click
        ' Checks to see if the status bar is frozen 
        ' by calling the IsFrozen method.
        Dim frozen As Integer
        SvcStatusBar.IsFrozen(frozen)
        If frozen = 0 Then
            ' SetColorText only displays white text on a 
            ' dark blue background.
            SvcStatusBar.SetColorText("Here's some highlighted text", 0, 0)
            MessageBox.Show("Pause")
            SvcStatusBar.SetText("Done")
        End If
    End Sub

    Private Sub btnReadFeedback_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnReadFeedback.Click
        ' Retrieve the status bar text.
        Dim text As String
        SvcStatusBar.GetText(text)
        MessageBox.Show(text)

        ' Clear the status bar text.
        SvcStatusBar.FreezeOutput(0)
        SvcStatusBar.Clear()
    End Sub

    Private Sub btnShowProgressBar_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnShowProgressBar.Click
        Dim cookie As UInteger = 0
        Dim label As String = "Progress bar label..."

        ' Initialize the progress bar.
        SvcStatusBar.Progress(cookie, 1, "", 0, 0)

        Dim i As UInteger = 0
        Dim total As UInteger = 100
        Do While i <= total
            ' Display incremental progress.
            SvcStatusBar.Progress(cookie, 1, label, i, total)
            System.Threading.Thread.Sleep(10)
            i += 1
        Loop

        ' Clear the progress bar.
        SvcStatusBar.Progress(cookie, 0, "", 0, 0)
    End Sub

    Private Sub btnShowAnimation_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnShowAnimation.Click
        Dim icon As Object = CShort(Microsoft.VisualStudio.Shell.Interop.Constants.SBAI_Deploy)

        ' Display the animated Visual Studio icon in the Animation region.
        ' Start the animation by calling the Animation method of the status bar. 
        ' Pass in 1 as the value of the first parameter, and a reference to an 
        ' animated icon as the value of the second parameter.
        SvcStatusBar.Animation(1, icon)

        MessageBox.Show("Click OK to end status bar animation.")

        ' Stop the animation by calling the Animation method of the status bar. 
        ' Pass in 0 as the value of the first parameter, and a reference to the 
        ' animated icon as the value of the second parameter.
        SvcStatusBar.Animation(0, icon)
    End Sub

    Private Sub btnUpdateDesignerRegion_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnUpdateDesignerRegion.Click
        ' Set insert/overstrike mode.
        Dim mode As Object = 1 ' Insert mode
        SvcStatusBar.SetInsMode(mode)

        ' Display Ln ## Col ## Ch ## information.
        Dim ln As Object = "##", col As Object = "##", ch As Object = "##"
        SvcStatusBar.SetLineColChar(ln, col, ch)
    End Sub
End Class