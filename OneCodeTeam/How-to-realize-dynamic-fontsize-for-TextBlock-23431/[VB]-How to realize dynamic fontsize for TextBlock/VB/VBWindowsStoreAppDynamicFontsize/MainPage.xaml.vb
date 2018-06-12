'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppDynamicFontsize
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to set Dynamic Fontsize for TextBlock
'  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Dim originalFontSize As Double
    Dim fixedTextBlockHeight As Double
    Dim fontsizeMultiplier As Double
    Dim previousTextLength As Integer

    Public Sub New()
        Me.InitializeComponent()
        originalFontSize = Me.ContentTextBlock.FontSize
        fixedTextBlockHeight = Me.ContentTextBlock.Height
        previousTextLength = Me.ContentTextBlock.Text.Length
    End Sub

#Region "Common methods"

    ''' <summary>
    ''' The the event handler for the click event of the link in the footer. 
    ''' </summary>
    ''' <param name="sender">
    ''' The sender.
    ''' </param>
    ''' <param name="e">
    ''' The event arguments.
    ''' </param>
    Private Async Sub FooterClick(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Sub

    Public Sub NotifyUser(message As String)
        Me.StatusText.Text = message
    End Sub

#End Region

    Private Sub TextBlock_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        Dim contentTextBlock As TextBlock = TryCast(sender, TextBlock)
        If contentTextBlock IsNot Nothing Then
            Dim height As Double = contentTextBlock.Height
            If Me.ContentTextBlock.ActualHeight > height Then
                ' Compute the factor
                Dim fontsizeMultiplier As Double = Math.Sqrt(height / Me.ContentTextBlock.ActualHeight)

                ' Set the new FontSize
                Me.ContentTextBlock.FontSize = Math.Floor(Me.ContentTextBlock.FontSize * fontsizeMultiplier)
            End If
        End If
    End Sub

    ' When user delete some text, TextBlock_SizeChanged event will not be raised.
    ' In this scenario, we should manually raise it.
    Private Sub ContextText_TextChanged(sender As Object, e As TextChangedEventArgs)
        If previousTextLength > Me.ContentTextBox.Text.Length AndAlso Me.ContentTextBlock.FontSize < originalFontSize Then
            ' By doing this, TextBlock_SizeChanged event may be fired.
            Me.ContentTextBlock.FontSize = originalFontSize
        End If
        previousTextLength = Me.ContentTextBox.Text.Length
    End Sub

End Class
