'****************************** Module Header ******************************\
' Module Name:  DataView1.xaml.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' This view will demo how to use custom Converter to alternate rows' background.
' In the Converter we will use a custom method to get the index of the data item.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Namespace Views
    Partial Public Class DataView1
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Tap the data item, pop-up the index of the item.
        ''' </summary>
        ''' <param name="sender">Item of Item ItemsControl</param>
        ''' <param name="e">GestureEventArgs</param>
        ''' <remarks></remarks>
        Private Sub tbName_Tap(sender As Object, e As System.Windows.Input.GestureEventArgs)
            Dim intIndex As Integer                               ' index
            Dim element As TextBlock = TryCast(sender, TextBlock) ' current element

            intIndex = Utilities.GetIndexOfUIElement(element)

            MessageBox.Show("The index of the Tap item is:" & intIndex.ToString())
        End Sub
    End Class
End Namespace

