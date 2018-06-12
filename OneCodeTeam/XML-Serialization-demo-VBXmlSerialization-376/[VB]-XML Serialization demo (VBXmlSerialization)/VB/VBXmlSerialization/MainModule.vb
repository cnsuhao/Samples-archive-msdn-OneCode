' **************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBXmlSerialization
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to serialize an in-memory object to a local xml file 
' and how to deserialize the xml file back to an in-memory object using 
' VB.NET. The designed MySerializableType includes int, string, generic, as well
' as customized type field and property.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

#Region "Using directives"
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Xml.Serialization
#End Region



Public Module MainModule
    Sub Main()
        '///////////////////////////////////////////////////////////////
        ' Serialize the object to an XML file.
        ' 

        ' Create and initialize a MySerializableType instance.
        Dim instance As New MySerializableType()
        instance.BoolValueProperty = True
        instance.IntValueProperty = 1
        instance.StringValueProperty = "Test String"
        instance.ListValueProperty.Add("List Item 1")
        instance.ListValueProperty.Add("List Item 2")
        instance.ListValueProperty.Add("List Item 3")
        instance.AnotherTypeValueProperty = New AnotherType()
        instance.AnotherTypeValueProperty.IntValueProperty = 2
        instance.AnotherTypeValueProperty.StringValueProperty = "Inner Test String"

        ' Create the serializer
        Dim serializer As New XmlSerializer(GetType(MySerializableType))

        ' Serialize the object to an XML file
        Using streamWriter As StreamWriter = File.CreateText("VBXmlSerialization.xml")
            serializer.Serialize(streamWriter, instance)
        End Using


        '///////////////////////////////////////////////////////////////
        ' Deserialize from a XML file to an object instance.
        ' 

        ' Deserialize the object
        Dim deserializedInstance As MySerializableType
        Using streamReader As StreamReader = File.OpenText("VBXmlSerialization.xml")
            deserializedInstance = TryCast(serializer.Deserialize(streamReader), MySerializableType)
        End Using

        ' Dump the object
        Console.WriteLine("BoolValue: {0}", deserializedInstance.BoolValueProperty)
        Console.WriteLine("IntValue: {0}", deserializedInstance.IntValueProperty)
        Console.WriteLine("StringValue: {0}", deserializedInstance.StringValueProperty)
        Console.WriteLine("AnotherTypeValue.IntValue: {0}", deserializedInstance.AnotherTypeValueProperty.IntValueProperty)
        Console.WriteLine("AnotherTypeValue.StringValue: {0}", deserializedInstance.AnotherTypeValueProperty.StringValueProperty)
        Console.WriteLine("ListValue: ")
        For Each obj As Object In deserializedInstance.ListValueProperty
            Console.WriteLine(obj.ToString())
        Next obj
    End Sub



    ''' <summary>
    ''' Serializable Type Declaration
    ''' </summary>
    <Serializable()> _
    Public Class MySerializableType
        ' String field and property
        Private stringValue As String
        Public Property StringValueProperty() As String
            Get
                Return stringValue
            End Get
            Set(ByVal value As String)
                stringValue = value
            End Set
        End Property

        ' Bool field and property
        Private boolValue As Boolean
        Public Property BoolValueProperty() As Boolean
            Get
                Return boolValue
            End Get
            Set(ByVal value As Boolean)
                boolValue = value
            End Set
        End Property

        ' Int field and property
        Private intValue As Integer
        Public Property IntValueProperty() As Integer
            Get
                Return intValue
            End Get
            Set(ByVal value As Integer)
                intValue = value
            End Set
        End Property

        ' Another type field and property
        Private anotherTypeValue As AnotherType
        Public Property AnotherTypeValueProperty() As AnotherType
            Get
                Return anotherTypeValue
            End Get
            Set(ByVal value As AnotherType)
                anotherTypeValue = value
            End Set
        End Property

        ' Generic type field and property
        Private listValue As New List(Of String)()
        Public Property ListValueProperty() As List(Of String)
            Get
                Return listValue
            End Get
            Set(ByVal value As List(Of String))
                listValue = value
            End Set
        End Property

        ' Ignore a field using NonSerialized attribute
        <NonSerialized()> _
        Private ignoredField As Integer = 1
    End Class

    ''' <summary>
    ''' Another Type Declaration
    ''' </summary>
    <Serializable()> _
    Public Class AnotherType

        Private stringValue As String
        Public Property StringValueProperty() As String
            Get
                Return stringValue
            End Get
            Set(ByVal value As String)
                stringValue = value
            End Set
        End Property


        Private intValue As Integer
        Public Property IntValueProperty() As Integer
            Get
                Return intValue
            End Get
            Set(ByVal value As Integer)
                intValue = value
            End Set
        End Property
    End Class
End Module

