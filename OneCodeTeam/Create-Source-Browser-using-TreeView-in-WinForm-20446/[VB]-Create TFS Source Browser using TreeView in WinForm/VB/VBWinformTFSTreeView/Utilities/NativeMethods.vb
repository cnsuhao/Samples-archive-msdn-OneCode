'***************************** Module Header *******************************\
' Module Name:  NativeMethods.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' Utility class to include all P/Invoke methods
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System
Imports System.Runtime.InteropServices

Namespace Microsoft.OneCode.Utilities

    ''' <summary>
    ''' P/Invoke methods
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NativeMethods

        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Friend Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Integer
        End Function

        <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Friend Shared Function ExtractIconEx(ByVal szFileName As String, ByVal nIconIndex As Integer, ByVal phiconLarge As IntPtr(), ByVal phiconSmall As IntPtr(), ByVal nIcons As UInt32) As Integer
        End Function


    End Class
End Namespace

