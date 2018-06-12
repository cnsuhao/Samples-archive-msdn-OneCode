'*************************** Module Header ******************************'
' Module Name:  POINT.vb
' Project:	    VBIEExplorerBar
' Copyright (c) Microsoft Corporation.
' 
' The class POINT specifies the screen coordinates for the menu.
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Runtime.InteropServices

Namespace NativeMethods
    <StructLayout(LayoutKind.Sequential)> _
    Public Class POINT

        Dim _x As Integer
        Public Property X() As Integer
            Get
                Return _x
            End Get
            Set(ByVal value As Integer)
                _x = value
            End Set
        End Property

        Dim _y As Integer
        Public Property Y() As Integer
            Get
                Return _y
            End Get
            Set(ByVal value As Integer)
                _y = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.X = x
            Me.Y = y
        End Sub
    End Class
End Namespace
