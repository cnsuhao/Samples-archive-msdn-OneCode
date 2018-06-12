'**************************** Module Header ******************************\
' Module Name:  Course.vb
' Project:      VBDataTableCustomType
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to use the custom type in DataTable.
' This file contains the definition of the custom type.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Text
Imports System.Xml.Serialization

Namespace VBDataTableCustomType
    Public Class Course
        Implements IComparable(Of Course), IComparable, IXmlSerializable
#Region "Properties"
        Public Property CourseId() As String
        Public Property Title() As String
        Public Property Credits() As Int32
#End Region

#Region "Implement the IComparable Interface"
        ''' <summary>
        ''' Implement the generic IComparable interface.
        ''' </summary>
        ''' <param name="other">It's used to compare with this object.</param>
        ''' <returns></returns>
        Public Function CompareTo(ByVal other As Course) As Integer Implements IComparable(Of Course).CompareTo
            If other Is Nothing Then
                Return 1
            Else
                Return Me.CourseId.CompareTo(other.CourseId)
            End If
        End Function

        ''' <summary>
        ''' Implement the IComparable interface. 
        ''' When we set a column as the primary key in DataTable, the DataTable need to make 
        ''' sure that every value in the primary key column is unique. So DataTable will use 
        ''' this method to compare the values.
        ''' And when we sort the DataTable by this type, DataTable will also use this method.
        ''' </summary>
        ''' <param name="obj">It's used to compare with this object.</param>
        ''' <returns></returns>
        Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
            If obj Is Nothing Then
                Return 1
            End If

            Dim other As Course = TryCast(obj, Course)
            If other IsNot Nothing Then
                Return Me.CompareTo(other)
            Else
                Throw New ArgumentException("Object is not a Course")
            End If
        End Function

#End Region

#Region "Implement the IXmlSerializable Interface"
        ' We implement the IXmlSerializable interface to convert this object with Xml. 
        ' It may be a little harder than SerializableAttribute, but we can get more control.

        Public Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function

        ''' <summary>
        ''' Create this object from the Xml.
        ''' </summary>
        ''' <param name="reader"></param>
        Public Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
            If reader Is Nothing Then
                Throw New ArgumentNullException("reader is nothing")
            End If

            ' Because there may be many types of node, we first get the Course node.
            reader.ReadStartElement("Course")

            CourseId = reader.ReadElementString("CourseId")
            Title = reader.ReadElementString("Title")

            Dim CreditsString As String = reader.ReadElementString("Credits")
            Dim credit As Integer = 0
            If Int32.TryParse(CreditsString, credit) Then
                Credits = credit
            Else
                Credits = -1
            End If

            reader.ReadEndElement()
        End Sub

        ''' <summary>
        ''' Write this object into Xml.
        ''' </summary>
        ''' <param name="writer"></param>
        Public Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
            If writer Is Nothing Then
                Throw New ArgumentNullException("writer is nothing")
            End If

            writer.WriteElementString("CourseId", CourseId)
            writer.WriteElementString("Title", Title)
            writer.WriteElementString("Credits", Credits.ToString())
        End Sub
#End Region

        Public Overrides Function ToString() As String
            Return String.Format("CourseId:{0,-10} Title:{1,-15} Credits:{2}", CourseId, Title, Credits)
        End Function
    End Class
End Namespace
