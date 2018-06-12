'***************************** Module Header *******************************\
' Module Name:  CommonUtilities.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' Common Utilities
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Windows.Forms

Namespace Microsoft.OneCode.Utilities

    Friend Class CommonUtilities

        ''' <summary>
        ''' Show warning message box with OneCode caption
        ''' </summary>
        ''' <param name="message"></param>
        ''' <remarks></remarks>
        Friend Shared Sub ShowWarning(ByVal message As String)
            MessageBox.Show(message, UtilityResources.OneCodeCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

        ''' <summary>
        ''' Show error message box with OneCode caption
        ''' </summary>
        ''' <param name="error">Error String</param>
        ''' <remarks></remarks>
        Friend Shared Sub ShowError(ByVal [error] As String)
            MessageBox.Show([error], UtilityResources.OneCodeCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

    End Class

End Namespace

