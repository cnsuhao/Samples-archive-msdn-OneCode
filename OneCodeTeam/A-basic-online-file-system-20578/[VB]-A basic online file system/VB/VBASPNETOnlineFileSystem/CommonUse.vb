'****************************** Module Header ******************************\
' Module Name:  CommonUse.vb
' Project:	    VBASPNETOnlineFileSystem
' Copyright (c) Microsoft Corporation.
' 
' Formats a file size to string
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Friend Class CommonUse

    ''' <summary>
    ''' Format the file size
    ''' </summary>
    ''' <param name="fileLength">The file size</param>
    ''' <returns>Formated file size</returns>
    ''' <remarks></remarks>
    Public Shared Function FormatFileSize(ByVal fileLength As Long) As String
        If ((fileLength / &H400) < 1) Then
            Return (fileLength.ToString & " (bytes)")
        End If
        fileLength = (fileLength / &H400)
        If ((fileLength / &H400) < 1) Then
            Return (fileLength.ToString & " KB")
        End If
        fileLength = (fileLength / &H400)
        If ((fileLength / &H400) < 1) Then
            Return (fileLength.ToString & " MB")
        End If
        fileLength = (fileLength / &H400)
        If ((fileLength / &H400) < 1) Then
            Return (fileLength.ToString & " GB")
        End If
        fileLength = (fileLength / &H400)
        Return (fileLength.ToString & " TB")
    End Function

End Class
