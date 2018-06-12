'**************************** Module Header ******************************\
' Module Name:  YearCourse.vb
' Project:      VBEFStoreXmlFiles
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to import/export the XML into/from database using 
' Code First in EF.
' This file defines the YearCourse class as the Entity type.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.ComponentModel.DataAnnotations.Schema

Namespace VBEFStoreXmlFiles
    Public Class YearCourse
        Public Property YearCourseId() As Int32
        Public Property Year() As Int32

        ' The XmlColumn type in the SqlServer will be mapped as the String type 
        ' in the EntityFramework.
        <Column(TypeName:="xml")>
        Public Property XmlValues() As String

        ' EntityFramework can't map the XDcoument type into the SqlServer type, 
        ' so we set NotMapped.
        ' We use Xml Values to store and get the Xml document in the database. 
        ' And then we use the Courses property to convert the XDocument with 
        ' String and access the Xml document. 
        <NotMapped()>
        Public Property Courses() As XDocument
            Get
                Return XDocument.Parse(XmlValues)
            End Get
            Set(ByVal value As XDocument)
                XmlValues = value.ToString()
            End Set
        End Property
    End Class
End Namespace
