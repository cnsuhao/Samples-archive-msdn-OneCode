'*************************** Module Header ******************************'
' Module Name:  XMLViewerSettings.vb
' Project:	    VBRichTextBoxSyntaxHighlighting
' Copyright (c) Microsoft Corporation.
' 
' This XMLViewerSettings class defines the colors used in the XmlViewer, and some
' constants that specify the color order in the RTF.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Text

Public Class XMLViewerSettings
    Public Const ElementID As Integer = 1
    Public Const ValueID As Integer = 2
    Public Const AttributeKeyID As Integer = 3
    Public Const AttributeValueID As Integer = 4
    Public Const TagID As Integer = 5


    Dim _element As Color

    ''' <summary>
    ''' The color of an Xml element name.
    ''' </summary>
    Public Property Element() As Color
        Get
            Return _element
        End Get
        Set(ByVal value As Color)
            _element = value
        End Set
    End Property


    Dim _value As Color

    ''' <summary>
    ''' The color of an Xml element value.
    ''' </summary>
    Public Property Value() As Color
        Get
            Return _value
        End Get
        Set(ByVal value As Color)
            _value = value
        End Set
    End Property


    Dim _attributeKey As Color

    ''' <summary>
    ''' The color of an Attribute Key in Xml element.
    ''' </summary>
    Public Property AttributeKey() As Color
        Get
            Return _attributeKey
        End Get
        Set(ByVal value As Color)
            _attributeKey = value
        End Set
    End Property


    Dim _attributeValue As Color

    ''' <summary>
    ''' The color of an Attribute Value in Xml element.
    ''' </summary>
    Public Property AttributeValue() As Color
        Get
            Return _attributeValue
        End Get
        Set(ByVal value As Color)
            _attributeValue = value
        End Set
    End Property


    Dim _tag As Color

    ''' <summary>
    ''' The color of the tags and operators like "<,/> and =".
    ''' </summary>
    Public Property Tag() As Color
        Get
            Return _tag
        End Get
        Set(ByVal value As Color)
            _tag = value
        End Set
    End Property

    ''' <summary>
    ''' Convert the settings to Rtf color definitions.
    ''' </summary>
    Public Function ToRtfFormatString() As String
        ' The Rtf color definition format.
        Dim format As String = "\red{0}\green{1}\blue{2};"

        Dim rtfFormatString As New StringBuilder()

        rtfFormatString.AppendFormat(format, Element.R, Element.G, Element.B)
        rtfFormatString.AppendFormat(format, Value.R, Value.G, Value.B)
        rtfFormatString.AppendFormat(format, AttributeKey.R, AttributeKey.G, AttributeKey.B)
        rtfFormatString.AppendFormat(format, AttributeValue.R, AttributeValue.G, AttributeValue.B)
        rtfFormatString.AppendFormat(format, Tag.R, Tag.G, Tag.B)

        Return rtfFormatString.ToString()

    End Function
End Class
