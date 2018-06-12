'***************************** Module Header ******************************\
' Module Name:  Customer.vb
' Project:      VBWindowsStoreAppAdaptToResolutionGridView
' Copyright (c) Microsoft Corporation.
'  
' This is the demo data
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

Public Class Customer
    Public Property Name() As String

    Public Property Age() As Integer

    Public Property Sex() As Boolean

    Public Property FavouriteSport() As Sport

End Class

Public Enum Sport
    Football
    Basketball
    Baseball
    Swimming
End Enum