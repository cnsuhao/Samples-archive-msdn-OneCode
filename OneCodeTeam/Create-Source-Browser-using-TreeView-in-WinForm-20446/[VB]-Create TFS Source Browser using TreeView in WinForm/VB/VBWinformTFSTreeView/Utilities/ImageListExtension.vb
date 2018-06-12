'***************************** Module Header *******************************\
' Module Name:  ImageListExtension.vb
' Project:      VBWinformTFSTreeView
' Copyright (c) Microsoft Corporation.
' 
' Utility class for the extensions of ImageList type
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
Imports System.Runtime.CompilerServices

Namespace Microsoft.OneCode.Utilities
    Friend Class ImageListExtension

        ''' <summary>
        ''' Get the ImageList icon index for the usage of TreeView.
        '''  If the icon do not exist, leverage GetSmallIconByFileType utility 
        '''  to retrieve icons associated with the registered file types.
        ''' </summary>
        ''' <param name="imageList">ImageList type to extend</param>
        ''' <param name="fileExtension">
        ''' File extensions, support "unknown", "folder" and other ".*" extensions.
        ''' </param>
        ''' <returns>the icon Index in the ImageList</returns>
        ''' <remarks></remarks>
        Public Shared Function GetImageListIndex(ByVal imageList As ImageList,
                                Optional ByVal fileExtension As String = "") As Integer
            If Not imageList.Images.ContainsKey(fileExtension) Then
                imageList.Images.Add(fileExtension,
                                IconUtilities.GetSmallIconByFileType(fileExtension))
            End If

            Return imageList.Images.IndexOfKey(fileExtension)
        End Function
    End Class
End Namespace
