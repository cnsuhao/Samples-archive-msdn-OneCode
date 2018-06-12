'****************************** Module Header ******************************\
' Module Name:  StateUtilities.vb
' Project:      VBWP8CollectionViewSource
' Copyright (c) Microsoft Corporation
'
' This is a utility class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Public Class StateUtilities
    Private Sub New()
    End Sub

    ' This property is used to track if the user has started a new instance of the app.
    Private Shared m_isLaunching As [Boolean]

    Public Shared Property IsLaunching() As [Boolean]
        Get
            Return m_isLaunching
        End Get
        Set(value As [Boolean])
            m_isLaunching = value
        End Set
    End Property
End Class
