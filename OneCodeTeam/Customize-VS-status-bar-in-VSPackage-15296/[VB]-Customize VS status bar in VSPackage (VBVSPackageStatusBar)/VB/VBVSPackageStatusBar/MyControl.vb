'*************************************** Module Header *****************************'
' Module Name:  MyControl.vb
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

Imports System.Security.Permissions
Imports System.Windows.Forms
Imports Microsoft.VisualStudio.Shell.Interop

'''<summary>
'''  Summary description for MyControl.
'''</summary>
Public Class MyControl
    Inherits UserControl

    Private privateSvcStatusBar As IVsStatusbar
    Public Property SvcStatusBar() As IVsStatusbar
        Get
            Return privateSvcStatusBar
        End Get
        Set(ByVal value As IVsStatusbar)
            privateSvcStatusBar = value
        End Set
    End Property

    '''<summary> 
    '''  Let this control process the mnemonics.
    '''</summary>
    <UIPermission(SecurityAction.LinkDemand, Window:=UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogChar(ByVal charCode As Char) As Boolean
        ' If we're the top-level form or control, we need to do the mnemonic handling
        If charCode <> " "c And ProcessMnemonic(charCode) Then
            Return True
        End If
        Return MyBase.ProcessDialogChar(charCode)
    End Function

    '''<summary>
    ''' Enable the IME status handling for this control.
    '''</summary>
    Protected Overrides ReadOnly Property CanEnableIme() As Boolean
        Get
            Return True
        End Get
    End Property


    Private Sub btnWriteFeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteFeedback.Click
        ' Checks to see if the status bar is frozen 
        ' by calling the IsFrozen method.
        Dim frozen As Integer
        SvcStatusBar.IsFrozen(frozen)
        If frozen = 0 Then
            ' SetColorText only displays white text on a 
            ' dark blue background.
            SvcStatusBar.SetColorText("Here's some highlighted text", 0, 0)
            System.Windows.Forms.MessageBox.Show("Pause")
            SvcStatusBar.SetText("Done")
        End If
    End Sub

    Private Sub btnReadFeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadFeedback.Click
        ' Retrieve the status bar text.
        Dim text As String
        SvcStatusBar.GetText(text)
        System.Windows.Forms.MessageBox.Show(text)

        ' Clear the status bar text.
        SvcStatusBar.FreezeOutput(0)
        SvcStatusBar.Clear()
    End Sub

    Private Sub btnShowProgressBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowProgressBar.Click
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

    Private Sub btnShowAnimation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAnimation.Click
        Dim icon As Object = CShort(Microsoft.VisualStudio.Shell.Interop.Constants.SBAI_General)

        ' Display the animated Visual Studio icon in the Animation region.
        ' Start the animation by calling the Animation method of the status bar. 
        ' Pass in 1 as the value of the first parameter, and a reference to an 
        ' animated icon as the value of the second parameter.
        SvcStatusBar.Animation(1, icon)

        System.Windows.Forms.MessageBox.Show("Click OK to end status bar animation.")

        ' Stop the animation by calling the Animation method of the status bar. 
        ' Pass in 0 as the value of the first parameter, and a reference to the 
        ' animated icon as the value of the second parameter.
        SvcStatusBar.Animation(0, icon)
    End Sub

    Private Sub btnUpdateDesignerRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDesignerRegion.Click
        ' Set insert/overstrike mode.
        Dim mode As Object = 1 ' Insert mode
        SvcStatusBar.SetInsMode(mode)

        ' Display Ln ## Col ## Ch ## information.
        Dim ln As Object = "##", col As Object = "##", ch As Object = "##"
        SvcStatusBar.SetLineColChar(ln, col, ch)
    End Sub
End Class