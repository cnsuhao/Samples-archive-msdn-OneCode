'*************************** Module Header ******************************\
' Module Name:    ExecuteOptions.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to define ExecuteOptions enum
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace CustomService
    <Flags()> _
    Public Enum ExecuteOptions
        None = &H0
        AsProcess = &H1
        Async = &H2
    End Enum
End Namespace

