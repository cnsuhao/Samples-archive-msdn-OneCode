'************************************* Module Header ***********************\
' Module Name:  Utilities.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
'  Model class for Hardware ID ASHWID storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports Windows.Storage.Streams

Public Class Utilities

    ''' <summary>
    ''' Utility function to convert IBuffer instance to byte array.
    ''' </summary>
    ''' <param name="buf">IBuffer instance</param>
    ''' <returns>byte arrays</returns>
    Public Shared Function ConvertBufferToByteArray(ByVal buf As IBuffer) As Byte()
        If (buf Is Nothing) Then
            Return Nothing
        End If

        Using reader As DataReader = DataReader.FromBuffer(buf)
            Dim buffer As Byte() = New Byte(buf.Length - 1) {}
            reader.ReadBytes(buffer)
            Return buffer
        End Using
    End Function

End Class


