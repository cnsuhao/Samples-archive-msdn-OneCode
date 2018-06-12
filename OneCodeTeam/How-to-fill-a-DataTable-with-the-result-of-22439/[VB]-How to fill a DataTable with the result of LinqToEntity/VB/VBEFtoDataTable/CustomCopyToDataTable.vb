'**************************** Module Header ******************************\
' Module Name:  CustomCopyToDataTable.vb
' Project:      VBEFtoDataTable
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to fill a DataTable with the result of the Linq 
' to Entity query.
' This file demonstrates how to implement two custom CopyToDataTable<T> extension 
' methods that accept a generic parameter T of a type other than DataRow.The logic 
' to create a DataTable from an IEnumerable<T> source is contained in the 
' ObjectShredder<T> class, which is then wrapped in two overloaded CopyToDataTable<T> 
' extension methods. 
' 
' This source is subject to the Microsoft Public License
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Namespace VBEFtoDataTable
    Public Module CustomCopyToDataTable
        <System.Runtime.CompilerServices.Extension()> _
        Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
            Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
        End Function

        <System.Runtime.CompilerServices.Extension()> _
        Public Function CopyToDataTable(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options? As LoadOption) As DataTable
            Return New ObjectShredder(Of T)().Shred(source, table, options)
        End Function
    End Module
End Namespace
