'**************************** Module Header ******************************\
' Module Name:  FillDataTable.vb
' Project:      VBEFtoDataTable
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to fill a DataTable with the result of the Linq 
' to Entity query.
' This file demonstrates how to use the connection string and query string to
' fill a DataTable. First, we get the connection string, query string and the parameters 
' from the Linq to Entity. Then we use the SqlDataAdapter to fill a DataTable and 
' return it. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports System.Data.Entity
Imports System.Data.Objects
Imports System.Data.EntityClient
Imports System.Data.SqlClient
Imports System.Data.Entity.Infrastructure
Imports System.Collections
Imports System.Reflection

Namespace VBEFtoDataTable
    Public NotInheritable Class FillDataTable
 
        ''' <summary>
        ''' Get the connection string, query string and the parameters from the 
        ''' Linq to Entity, and then return the DataTable.
        ''' </summary>
        ''' <typeparam name="T">the type parameter of the IQueryable</typeparam>
        ''' <param name="result">the query of the Linq to Entity</param>
        ''' <param name="context">DbContext or ObjectContext</param>
        ''' <returns>the result of the DataTable</returns>
        Public Shared Function EFtoDataTable(Of T)(ByVal result As IQueryable(Of T), ByVal context As Object) As DataTable
            Dim queryString As String = Nothing
            Dim connectionString As String = Nothing
            Dim parameters() As SqlParameter = Nothing

            Try
                If TypeOf context Is DbContext Then
                    Dim query As DbQuery(Of T) = TryCast(result, DbQuery(Of T))

                    ' Get the query string.
                    queryString = query.ToString()

                    ' Because the DeQuery doesn't support the parameters collection, we use 
                    ' the reflection to get the ObjectQuery, and then get the parameters collection.
                    Dim objectQuery As ObjectQuery = GetObjectQuery(query)
                    parameters = GetSqlParameters(objectQuery.Parameters)

                    ' Get the collection string.
                    connectionString = (TryCast(context, DbContext)).Database.Connection.ConnectionString
                ElseIf TypeOf context Is ObjectContext Then
                    Dim query As ObjectQuery = TryCast(result, ObjectQuery)

                    ' Get the query string.
                    queryString = query.ToTraceString()

                    ' Get the parameters collection.
                    parameters = GetSqlParameters(query.Parameters)

                    ' Get the connection string.
                    Dim connection As EntityConnection = TryCast((TryCast(context, ObjectContext)).Connection, EntityConnection)
                    connectionString = connection.StoreConnection.ConnectionString
                End If
            Catch
                Throw
            End Try

            If String.IsNullOrEmpty(queryString) OrElse String.IsNullOrEmpty(connectionString) Then
                Throw New ArgumentException()
            End If

            ' Get and return the DataTable.
            Return EFtoDatatable_Renamed(queryString, connectionString, parameters)
        End Function

        ''' <summary>
        '''  Use the SqlDataAdapter to fill the DataTable.
        ''' </summary>
        ''' <param name="queryString">the query string</param>
        ''' <param name="connectionString">the connection string</param>
        ''' <param name="parameters">the parameter collection</param>
        ''' <returns>the result of the DataTable</returns>
        Private Shared Function EFtoDatatable_Renamed(ByVal queryString As String, ByVal connectionString As String, ByVal parameters() As SqlParameter) As DataTable
            Try
                Using SQLCon As New SqlConnection(connectionString)
                    Using Cmd As New SqlCommand(queryString, SQLCon)
                        ' Add the parameter collection.
                        Cmd.Parameters.AddRange(parameters)

                        Using da As New SqlDataAdapter(Cmd)
                            Using dt As New DataTable()
                                da.Fill(dt)
                                Return dt
                            End Using
                        End Using
                    End Using
                End Using
            Catch e1 As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' Transform the ObjectParameterCollection to the SqlParameter array.
        ''' </summary>
        ''' <param name="objectParameters">the ObjectParameter collection</param>
        ''' <returns>the SqlParameter array</returns>
        Private Shared Function GetSqlParameters(ByVal objectParameters As ObjectParameterCollection) As SqlParameter()
            Dim parameters As New List(Of SqlParameter)()
            For Each parameter As ObjectParameter In objectParameters
                parameters.Add(New SqlParameter(parameter.Name, parameter.Value))
            Next parameter

            Return parameters.ToArray()
        End Function

        ''' <summary>
        ''' Use reflection to get the ObjectQuery from the DbQuery.
        ''' </summary>
        ''' <param name="query">the DbQuery</param>
        ''' <returns>the ObjectQuery</returns>
        Private Shared Function GetObjectQuery(ByVal query As DbQuery) As ObjectQuery
            ' Get the InternalQuery of the DbQuery.
            Dim internalProperty As PropertyInfo = query.GetType().GetProperty("InternalQuery", BindingFlags.NonPublic Or BindingFlags.Instance)
            Dim internalValue As Object = internalProperty.GetValue(query, Nothing)

            ' Get the ObjectQuery of the InternalQuery.
            Dim objectQueryProperty As PropertyInfo = internalValue.GetType().GetProperty("ObjectQuery", BindingFlags.Public Or BindingFlags.Instance)
            Dim objectQuery As Object = objectQueryProperty.GetValue(internalValue, Nothing)

            Return TryCast(objectQuery, ObjectQuery)
        End Function

    End Class
End Namespace
