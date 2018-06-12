'****************************** Module Header ******************************\
'Module Name:  TreeViewExtension.vb
'Project:      TreeView_SelectOnRightClick
'Copyright (c) Microsoft Corporation.

'TreeViewExtension is a class to represent an attached property for TreeView to enable selection on Right click.
'This helps us to have a common code which can be used in any TreeView we create in the application.

'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'All other rights reserved.

'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace TreeView_SelectOnRightClick
    ''' <summary>
    ''' Class which acts as an extension for TreeView to enable selection on right click.
    ''' </summary>
    Public NotInheritable Class TreeViewExtension
        Private Sub New()
        End Sub
        ''' <summary>
        ''' Property for user to set if selection on right click should be enabled or disabled.
        ''' </summary>
        Public Shared ReadOnly SelectItemOnRightClickProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "SelectItemOnRight",
            GetType(Boolean),
            GetType(TreeViewExtension),
            New UIPropertyMetadata(False, AddressOf OnSelectItemOnRightClickChanged))

        Public Shared Function GetSelectItemOnRightClick(d As DependencyObject) As Boolean
            Return CBool(d.GetValue(SelectItemOnRightClickProperty))
        End Function

        Public Shared Sub SetSelectItemOnRightClick(d As DependencyObject, value As Boolean)
            d.SetValue(SelectItemOnRightClickProperty, value)
        End Sub

        Private Shared Sub OnSelectItemOnRightClickChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim selectItemOnRightClick As Boolean = CBool(e.NewValue)

            Dim treeView As TreeView = TryCast(d, TreeView)
            If treeView IsNot Nothing Then
                If selectItemOnRightClick Then
                    AddHandler treeView.PreviewMouseRightButtonDown, AddressOf treeView_PreviewMouseRightButtonDown
                Else
                    RemoveHandler treeView.PreviewMouseRightButtonDown, AddressOf treeView_PreviewMouseRightButtonDown
                End If
            End If
        End Sub

        Private Shared Sub treeView_PreviewMouseRightButtonDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs)
            Dim treeViewItem As TreeViewItem = VisualSearch(TryCast(e.OriginalSource, DependencyObject))

            If treeViewItem IsNot Nothing Then
                treeViewItem.Focus()
                e.Handled = True
            End If
        End Sub

        Private Shared Function VisualSearch(source As DependencyObject) As TreeViewItem
            While source IsNot Nothing AndAlso Not (TypeOf source Is TreeViewItem)
                source = VisualTreeHelper.GetParent(source)
            End While

            Return TryCast(source, TreeViewItem)
        End Function
    End Class
End Namespace
