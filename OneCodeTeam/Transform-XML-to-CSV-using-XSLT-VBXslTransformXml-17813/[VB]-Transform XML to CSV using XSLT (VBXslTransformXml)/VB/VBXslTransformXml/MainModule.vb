'****************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBXslTransformXml
' Copyright (c) Microsoft Corporation.
' 
' This sample project shows how to use XslCompiledTransform to transform an 
' XML data file to .csv file using an XSLT style sheet.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

#Region "Imports directives"

Imports System.Xml.Xsl

#End Region


Module MainModule

    Sub Main()
        ' Initialize an XslCompiledTransform instance.
        Dim transform As New XslCompiledTransform()

        ' Call transform.Load() to load the XSLT style sheet Books.xslt.
        transform.Load("Books.xslt")

        ' Call transform.Transform() to transform the source XML file 
        ' to a csv file using the XSLT style sheet.
        transform.Transform("Books.xml", "Books.csv")
    End Sub

End Module
