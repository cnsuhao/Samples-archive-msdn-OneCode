'***************************** Module Header ******************************\
' Module Name:  ObjectSerializer.vb
' Project:      VBWindowsStoreAppSaveCollection
' Copyright (c) Microsoft Corporation.
'  
' This class is used for serializing/deserializing objects to/from xml.
'   
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Xml.Serialization
Imports System.Xml
Imports System.Text

Friend NotInheritable Class ObjectSerializer(Of T)
    Private Sub New()
    End Sub
    ' Serialize to xml
    Public Shared Function ToXml(value As T) As String
        Dim serializer As New XmlSerializer(GetType(T))
        Dim stringBuilder As New StringBuilder()
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.OmitXmlDeclaration = True

        Using _xmlWriter As XmlWriter = XmlWriter.Create(stringBuilder, settings)
            serializer.Serialize(_xmlWriter, value)
        End Using
        Return stringBuilder.ToString()
    End Function

    ' Deserialize from xml
    Public Shared Function FromXml(xml As String) As T
        Dim serializer As New XmlSerializer(GetType(T))
        Dim value As T
        Using _stringReader As New StringReader(xml)
            Dim deserialized As Object = serializer.Deserialize(_stringReader)
            value = DirectCast(deserialized, T)
        End Using

        Return value
    End Function
End Class

