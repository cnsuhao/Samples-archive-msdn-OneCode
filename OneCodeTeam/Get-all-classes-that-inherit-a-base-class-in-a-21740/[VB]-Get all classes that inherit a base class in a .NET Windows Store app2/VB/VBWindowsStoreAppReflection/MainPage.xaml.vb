'*************************** Module Header ******************************'
' Module Name:  MainPage.vb
' Project:	    VBWindowsStoreAppReflection
' Copyright (c) Microsoft Corporation.
' 
' The main UI of this app.
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Navigation

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)

        ' Get current assembly.
        Dim asm As System.Reflection.Assembly = GetType(MainPage).GetTypeInfo().Assembly

        ' Bind all classes under VBWindowsStoreAppReflection.Types to typeCombobox
        typeCombobox.ItemsSource = asm.DefinedTypes.Where(Function(t) t.IsClass AndAlso
                                                              t.Namespace = "VBWindowsStoreAppReflection.Types")

        ' Bind all interfaces under VBWindowsStoreAppReflection.Types to interfaceCombobox
        interfaceCombobox.ItemsSource = asm.DefinedTypes.Where(Function(t) t.IsInterface AndAlso
                                                                   t.Namespace = "VBWindowsStoreAppReflection.Types")

    End Sub

    Private Sub typeCombobox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        If TypeOf sender Is ComboBox AndAlso TypeOf (TryCast(sender, ComboBox)).SelectedItem Is TypeInfo Then

            ' Get the selected type.
            Dim selectedType As TypeInfo = TryCast((TryCast(sender, ComboBox)).SelectedItem, TypeInfo)

            ' Find all the derived classes of the selected type.
            Dim asm As System.Reflection.Assembly = GetType(MainPage).GetTypeInfo().Assembly
            Dim subTypes As IEnumerable(Of TypeInfo) =
                asm.DefinedTypes.Where(Function(t) t.IsClass AndAlso t.IsSubclassOf(selectedType.AsType()))

            Dim result As New StringBuilder()

            If subTypes Is Nothing OrElse subTypes.Count = 0 Then
                result.Append("There is no class that inherits " & selectedType.FullName)
            Else
                result.AppendLine("The following classes inherit from " & selectedType.FullName)
                result.AppendLine()

                For Each subType As TypeInfo In subTypes
                    result.AppendLine(subType.FullName)
                Next subType
            End If

            typeResultText.Text = result.ToString()
        End If
    End Sub

    Private Sub interfaceCombobox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        If TypeOf sender Is ComboBox AndAlso TypeOf (TryCast(sender, ComboBox)).SelectedItem Is TypeInfo Then

            ' Get the selected interface.
            Dim selectedInterface As TypeInfo = TryCast((TryCast(sender, ComboBox)).SelectedItem, TypeInfo)

            ' Get all classes that implement the selected interface 
            Dim asm As System.Reflection.Assembly = GetType(MainPage).GetTypeInfo().Assembly
            Dim subTypes As IEnumerable(Of TypeInfo) =
                asm.DefinedTypes.Where(Function(t) t.IsClass AndAlso
                                           t.ImplementedInterfaces.Any(Function(i) i.Equals(selectedInterface.AsType())))

            Dim result As New StringBuilder()

            If subTypes Is Nothing OrElse subTypes.Count = 0 Then
                result.Append("There is no class that implements " & selectedInterface.FullName)
            Else
                result.AppendLine("The following classes implement " & selectedInterface.FullName)
                result.AppendLine()

                For Each subType As TypeInfo In subTypes
                    result.AppendLine(subType.FullName)
                Next subType
            End If

            interfaceResultText.Text = result.ToString()
        End If
    End Sub


#Region "Common methods"

    Private Async Sub Footer_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Await Windows.System.Launcher.LaunchUriAsync(New Uri((TryCast(sender, HyperlinkButton)).Tag.ToString()))
    End Sub

    Public Sub NotifyUser(ByVal message As String)
        textStatus.Text = message
    End Sub

#End Region
End Class
