'**************************** Module Header ******************************\
' Module Name:  TransactionIsolationLevels.vb
' Project:      VBDataIsolationLevel
' Copyright (c) Microsoft Corporation.
' 
' In this application, we will demonstrate how to use the IsolationLevel 
' Enumeration in DbTransaction.
' We will show you which of the following behaviors are allowed in the different 
' isolation levels.
' 1. Dirty reads;
' 2. Non-repeatable reads;
' 3. Phantoms.
' The Serializable and Snapshot transactions get the same result in the following up
' behaviors. In this file, we will show the difference between them.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Threading
Imports System.Data.SqlClient
Imports System.Threading.Tasks

Namespace VBDataIsolationLevel
    ' Use the delegate to call the different threads.
    Public Delegate Sub AsyncAccessDatabase(ByVal connString As String, ByVal level As IsolationLevel)

    Friend NotInheritable Class TransactionIsolationLevels
        ''' <summary>
        ''' In this method, we will demonstrate if the specific transaction allows the 
        ''' following behaviors:
        ''' 1. Dirty reads;
        ''' 2. Non-repeatable reads;
        ''' 3. Phantoms.
        ''' </summary>
        Private Sub New()
        End Sub
        Public Shared Sub DemonstrateIsolationLevel(ByVal connString As String, ByVal level As IsolationLevel)
            ' Before connect the database, recreate the table.
            OperateDatabase.CreateTable(connString)
            DemonstrateIsolationLevel(connString, level, AddressOf DirtyReadThreads.DirtyReadFirstThread,
                                      AddressOf DirtyReadThreads.DirtyReadSecondThread)
            DisplayData(connString)
            Console.WriteLine()

            OperateDatabase.CreateTable(connString)
            DemonstrateIsolationLevel(connString, level,
                                      AddressOf NonrepeatableReadThreads.NonrepeatableReadFirstThread,
                                      AddressOf NonrepeatableReadThreads.NonrepeatableReadSecondThread)
            Console.WriteLine()

            OperateDatabase.CreateTable(connString)
            DemonstrateIsolationLevel(connString, level, AddressOf PhantomReadThreads.PhantomReadFirstThread,
                                      AddressOf PhantomReadThreads.PhantomReadSecondThread)
            Console.WriteLine()
        End Sub

        ''' <summary>
        ''' In this method, we will demonstrate if the specific transaction allows the 
        ''' specific behaviors.
        ''' </summary>
        Public Shared Sub DemonstrateIsolationLevel(ByVal connString As String, ByVal level As IsolationLevel,
                                                    ByVal firstThread As AsyncAccessDatabase,
                                                    ByVal secondThread As AsyncAccessDatabase)
            Dim tasks() As Task = {
                Task.Factory.StartNew(Sub() firstThread(connString, level)),
                Task.Factory.StartNew(Sub() secondThread(connString, level))
                               }

            Task.WaitAll(tasks)
        End Sub

        ''' <summary>
        ''' In thie method, we will demonstrate the difference between the Serializable 
        ''' and Snapshot transaction
        ''' </summary>
        Public Shared Sub DemonstrateBetweenSnapshotAndSerializable(ByVal connString As String)
            OperateDatabase.CreateTable(connString)

            Console.WriteLine("Exchange Vaules in the Snapshot transaction:")
            DemonstrateIsolationLevel(connString, IsolationLevel.Snapshot,
                                      AddressOf ExchangeValuesThreads.ExchangeValuesFirstThread,
                                      AddressOf ExchangeValuesThreads.ExchangeValuesSecondThread)
            DisplayData(connString)
            Console.WriteLine()

            Console.WriteLine("Cannot Exchange Vaules in the Serializable transaction:")
            OperateDatabase.CreateTable(connString)
            DemonstrateIsolationLevel(connString, IsolationLevel.Serializable,
                                      AddressOf ExchangeValuesThreads.ExchangeValuesFirstThread,
                                      AddressOf ExchangeValuesThreads.ExchangeValuesSecondThread)
            DisplayData(connString)
        End Sub

        Public Shared Sub DisplayData(ByVal connString As String)
            Using conn As New SqlConnection(connString)
                Dim cmdText As String = "Use DbDataIsolationLevel; " & ControlChars.CrLf &
                    "Select ProductId,ProductName,Quantity,Price" & ControlChars.CrLf &
                    "from dbo.Products"

                conn.Open()

                Using command As New SqlCommand(cmdText, conn)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        DisplayData(reader)
                    End Using
                End Using
            End Using
        End Sub

        Public Shared Sub DisplayData(ByVal reader As SqlDataReader)
            Dim isFirst As Boolean = True

            Do While reader.Read()
                If isFirst Then
                    isFirst = False

                    For i As Integer = 0 To reader.FieldCount - 1
                        Console.Write("{0,-12}   ", reader.GetName(i))
                    Next i
                    Console.WriteLine()
                End If

                For i As Integer = 0 To reader.FieldCount - 1
                    Console.Write("{0,-12}   ", reader(i))
                Next i
                Console.WriteLine()
            Loop
        End Sub
    End Class
End Namespace
