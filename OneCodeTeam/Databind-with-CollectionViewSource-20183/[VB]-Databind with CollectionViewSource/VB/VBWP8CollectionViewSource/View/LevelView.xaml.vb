'****************************** Module Header ******************************\
' Module Name:  LevelView.xaml.vb
' Project:      VBWP8CollectionViewSource
' Copyright (c) Microsoft Corporation
'
' This is the view that type is equal to level.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Namespace ViewNamespace
    Partial Public Class LevelView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class

    ''' <summary>
    ''' This is the custom data binding converter
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BoolOpposite
        Implements System.Windows.Data.IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
            Dim b As Boolean = CBool(value)
            Return Not b
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Dim s As String = TryCast(value, String)
            Dim b As Boolean

            If Boolean.TryParse(s, b) Then
                Return Not b
            End If
            Return False
        End Function

    End Class
End Namespace

