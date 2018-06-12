'**************************** Module Header ******************************\
' Module Name:  Employee.vb
' Project:      VBDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' The class is used to demonstrate the deep clone.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Namespace VBDeepCloneObject
    Friend Class Employee
        Private idOfEmployee As Integer
        Private nameOfEmployee As String
        Private addressOfEmployee As Address

        ''' <summary>
        ''' Get the shallow clone of the Employee.
        ''' </summary>
        ''' <returns>Return the shallow clone.</returns>
        Public Function ShallowCopy() As Employee
            Return TryCast(Me.MemberwiseClone(), Employee)
        End Function

        Public Property Id() As Integer
            Get
                Return idOfEmployee
            End Get
            Set(ByVal value As Integer)
                idOfEmployee = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return nameOfEmployee
            End Get
            Set(ByVal value As String)
                nameOfEmployee = value
            End Set
        End Property

        Public Property Address() As Address
            Get
                Return addressOfEmployee
            End Get
            Set(ByVal value As Address)
                addressOfEmployee = value
            End Set
        End Property
    End Class
End Namespace
