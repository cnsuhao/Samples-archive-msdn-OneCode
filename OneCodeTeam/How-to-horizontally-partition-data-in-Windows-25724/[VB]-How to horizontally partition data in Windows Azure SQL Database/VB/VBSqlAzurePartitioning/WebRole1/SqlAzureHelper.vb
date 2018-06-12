'****************************** Module Header ******************************\
' Module Name:  SqlAzureHelper.vb
' Project:      VBSqlAzurePartitioning
' Copyright (c) Microsoft Corporation.
' 
' This file is from Microsoft SQL Azure team's blog.
' http://blogs.msdn.com/b/sqlazure/archive/2010/05/17/10014011.aspx
' 
' 1. Implements forward read only cursors for performance.
' 2. Support IEnumerable and LINQ
' 3. Disposes of the connection and the data reader when the result set is no longer needed.
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Threading

Friend Delegate Function ExecuteReaderDelegate(sqlConnection As SqlConnection) As SqlDataReader
Friend Delegate Sub ExecuteNonQueryDelegate(sqlConnection As SqlConnection)

NotInheritable Class SQLAzureHelper
    Friend Shared Function ExecuteReader(connectionString As [String], executeDelegate As ExecuteReaderDelegate) As List(Of DbDataRecord)
        Using sqlConnection As New SqlConnection(connectionString)
            ' Open the connection
            Dim result = New List(Of DbDataRecord)
            Using sqlDataReader As SqlDataReader = executeDelegate(sqlConnection)
                For Each dbDataRecord As DbDataRecord In sqlDataReader.Cast(Of DbDataRecord)()
                    result.Add(dbDataRecord)
                Next
            End Using
            Return result
        End Using
    End Function

    Friend Shared Sub ExecuteNonQuery(connectionString As [String], executeDelegate As ExecuteNonQueryDelegate)
        ' This is the retry loop, handling the retries session
        ' is done in the catch for performance reasons
        Dim attempt As Int32 = 1
        While True
            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    ' Open the connection
                    sqlConnection.Open()
                    executeDelegate(sqlConnection)
                End Using
                ' Success Break Out Of Attempt Loop
                Exit Try
            Catch sqlException As SqlException
                ' Increment Trys
                attempt += 1

                ' Find Maximum Trys
                Dim maxRetryCount As Int32 = Int32.Parse(ConfigurationManager.AppSettings("ConnectionRetrys"))

                ' Throw Error if we have reach the maximum number of retries
                If attempt = maxRetryCount Then
                    Throw
                End If

                ' Determine if we should retry or abort.
                If Not SQLAzureHelper.RetryLitmus(sqlException) Then
                    Throw
                Else
                    Thread.Sleep(SQLAzureHelper.ConnectionRetryWaitSeconds(attempt))
                End If
            End Try
        End While
    End Sub

    ''' <summary>
    ''' Number of seconds to wait before retrying the connection
    ''' </summary>
    ''' <param name="attempt"></param>
    ''' <returns></returns>
    Public Shared Function ConnectionRetryWaitSeconds(attempt As Int32) As Int32
        Dim connectionRetryWaitSeconds__1 As Int32 = Int32.Parse(ConfigurationManager.AppSettings("ConnectionRetryWaitSeconds")) * 1000

        ' Back off Throttling, here we slow the retries, based on the Number of 
        ' Attempts
        connectionRetryWaitSeconds__1 = connectionRetryWaitSeconds__1 * Math.Pow(2, attempt)

        Return (connectionRetryWaitSeconds__1)
    End Function

    ''' <summary>
    ''' Determine from the exception if the execution
    ''' of the connection should Be attempted again
    ''' </summary>
    ''' <param name="exception">Generic Exception</param>
    ''' <returns>True if a a retry is needed, false if not</returns>
    Public Shared Function RetryLitmus(sqlException As SqlException) As [Boolean]
        Select Case sqlException.Number
            ' The service has encountered an error
            ' processing your request. Please try again.
            ' Error code %d.
            ' The service is currently busy. Retry
            ' the request after 10 seconds. Code: %d.
            'A transport-level error has occurred when
            ' receiving results from the server. (provider:
            ' TCP Provider, error: 0 - An established connection
            ' was aborted by the software in your host machine.)
            Case 40197, 40549, 10053
                Return (True)
        End Select

        Return (False)
    End Function

    ''' <summary>
    ''' Names of the Databases In Horizontal Partition
    ''' </summary>
    Public Shared ConnectionStringNames As [String]() = {"Database001ConnectionString", "Database002ConnectionString"}

    ''' <summary>
    ''' Connections Strings In the Horizontal Partition
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ConnectionStrings() As List(Of [String])
        Dim result = New List(Of [String])
        For Each connectionStringName As [String] In ConnectionStringNames
            result.Add(ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString)
        Next
        Return result
    End Function

    ''' <summary>
    ''' Return the Index to the Database For the Primary Key
    ''' </summary>
    ''' <param name="primaryKey"></param>
    ''' <returns></returns>
    Private Shared Function DatabaseIndex(primaryKey As Guid) As Integer
        Dim hash As UInteger = 0

        For Each b As Byte In primaryKey.ToByteArray()
            hash += b
            hash += (hash << 10)
            hash = hash Xor (hash >> 6)
        Next

        ' Final avalanche 
        hash += (hash << 3)
        hash = hash Xor (hash >> 11)
        hash += (hash << 15)

        Return CInt(hash Mod 100000000)
    End Function

    ''' <summary>
    ''' Returns the Connection String Name for the Primary Key
    ''' </summary>
    ''' <param name="primaryKey"></param>
    ''' <returns></returns>
    Private Shared Function ConnectionStringName(primaryKey As Guid) As [String]
        Return (ConnectionStringNames(DatabaseIndex(primaryKey) Mod ConnectionStringNames.Length))
    End Function

    ''' <summary>
    ''' Returns the Connection String For the Primary Key
    ''' </summary>
    ''' <param name="primaryKey"></param>
    ''' <returns></returns>
    Public Shared Function ConnectionString(primaryKey As Guid) As [String]
        Return (ConfigurationManager.ConnectionStrings(ConnectionStringName(primaryKey)).ConnectionString)
    End Function
End Class
