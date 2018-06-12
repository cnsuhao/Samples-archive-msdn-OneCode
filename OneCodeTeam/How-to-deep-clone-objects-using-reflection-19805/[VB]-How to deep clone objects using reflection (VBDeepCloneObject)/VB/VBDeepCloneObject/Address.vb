'**************************** Module Header ******************************\
' Module Name:  Address.vb
' Project:      VBDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' The class contains the address information.
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
    Friend Class Address
        Private addressLineOfAddress As String
        Private cityOfAddress As String
        Private postalCodeOfAddress As String

        Public Property AddressLine() As String
            Get
                Return addressLineOfAddress
            End Get
            Set(ByVal value As String)
                addressLineOfAddress = value
            End Set
        End Property

        Public Property City() As String
            Get
                Return cityOfAddress
            End Get
            Set(ByVal value As String)
                cityOfAddress = value
            End Set
        End Property

        Public Property PostalCode() As String
            Get
                Return postalCodeOfAddress
            End Get
            Set(ByVal value As String)
                postalCodeOfAddress = value
            End Set
        End Property
    End Class
End Namespace
