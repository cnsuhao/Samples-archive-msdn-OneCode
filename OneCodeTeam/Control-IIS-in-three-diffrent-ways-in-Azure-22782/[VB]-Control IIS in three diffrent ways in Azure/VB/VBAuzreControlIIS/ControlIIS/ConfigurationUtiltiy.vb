'***************************** Module Header ******************************\
' Module Name:  ConfigurationUtiltiy.vb
' Project:     ControlIIS
' Copyright (c) Microsoft Corporation.
' 
' As we know, cloud service can full control IIS. If someone want to change IIS, 
' they will probably first think about using startup script, since it has been 
' documented in Azure training kit.
' That's a good way but not the only way.
' Actually we can use site class and Configuration config to achieve that.
' This sample will show you how can we control IIS by two different ways in Azure
' Cloud service.
'
' Use this method to configure specific xml file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports Microsoft.Web.Administration
Public NotInheritable Class ConfigurationUtiltiy
    Private Sub New()
    End Sub

    Public Shared Function FindElement(collection As ConfigurationElementCollection, elementTagName As String, ParamArray keyValues As String()) As ConfigurationElement
        For Each element As ConfigurationElement In collection
            If [String].Equals(element.ElementTagName, elementTagName, StringComparison.OrdinalIgnoreCase) Then
                Dim matches As Boolean = True

                For i As Integer = 0 To keyValues.Length - 1 Step 2
                    Dim o As Object = element.GetAttributeValue(keyValues(i))
                    Dim value As String = Nothing
                    If o IsNot Nothing Then
                        value = o.ToString()
                    End If

                    If Not [String].Equals(value, keyValues(i + 1), StringComparison.OrdinalIgnoreCase) Then
                        matches = False
                        Exit For
                    End If
                Next
                If matches Then
                    Return element
                End If
            End If
        Next
        Return Nothing
    End Function
End Class
