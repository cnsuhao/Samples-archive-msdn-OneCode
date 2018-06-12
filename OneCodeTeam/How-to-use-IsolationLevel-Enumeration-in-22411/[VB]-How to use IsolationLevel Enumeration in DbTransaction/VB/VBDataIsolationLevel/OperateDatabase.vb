'**************************** Module Header ******************************\
' Module Name:  OperateDatabase.vb
' Project:      VBDataIsolationLevel
' Copyright (c) Microsoft Corporation.
' 
' In this application, we will demonstrate how to use the IsolationLevel 
' Enumeration in DbTransaction.
' This class includes some operations in database.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Data.SqlClient

Namespace VBDataIsolationLevel
    Friend NotInheritable Class OperateDatabase
        ''' <summary>
        '''  If there's no database 'DbDataIsolationLevel', create the database.
        ''' </summary>
        Private Sub New()
        End Sub
        Public Shared Function CreateDatabase(ByVal connString As String) As Boolean
            Using conn As New SqlConnection(connString)
                Dim cmdText As String = "Use Master;" & ControlChars.CrLf & ControlChars.CrLf & "                                     if Db_Id('DbDataIsolationLevel') is null" & ControlChars.CrLf & "                                      create Database [DbDataIsolationLevel];"

                Using command As New SqlCommand(cmdText, conn)
                    conn.Open()

                    command.ExecuteNonQuery()
                End Using

                Console.WriteLine("Create the Database 'DbDataIsolationLevel'")
            End Using

            Return True
        End Function

        ''' <summary>
        ''' If there's no table [dbo].[Products] in DbDataIsolationLevel, create
        ''' the table; or recreate it.
        ''' </summary>
        Public Shared Function CreateTable(ByVal connString As String) As Boolean
            Using conn As New SqlConnection(connString)
                Dim cmdText As String = "Use DbDataIsolationLevel" & ControlChars.CrLf &
                    "  if Object_ID('[dbo].[Products]') is not null" & ControlChars.CrLf &
                    "  drop table [dbo].[Products]" & ControlChars.CrLf &
                    "  Create Table [dbo].[Products]" & ControlChars.CrLf &
                    "  (" & ControlChars.CrLf &
                    "  [ProductId] int IDENTITY(1,1) primary key," & ControlChars.CrLf &
                    "  [ProductName] NVarchar(100) not null," & ControlChars.CrLf &
                    "  [Quantity] int null," & ControlChars.CrLf &
                    "  [Price] money null" & ControlChars.CrLf &
                    "  )"

                Using command As New SqlCommand(cmdText, conn)
                    conn.Open()

                    command.ExecuteNonQuery()
                End Using
            End Using

            Return InsertRows(connString)
        End Function

        ''' <summary>
        ''' Insert some rows into [dbo].[Products] table.
        ''' </summary>
        Public Shared Function InsertRows(ByVal connString As String) As Boolean
            Using conn As New SqlConnection(connString)
                Dim cmdText As String = "Use DbDataIsolationLevel" & ControlChars.CrLf &
                    "  INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Blue Bike', 365,1075.00)" & ControlChars.CrLf &
                    "  INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Red Bike', 159, 1299.00)" & ControlChars.CrLf &
                    "  INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Black Bike', 638, 1159.00)"

                Using command As New SqlCommand(cmdText, conn)
                    conn.Open()

                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True
        End Function

        ''' <summary>
        ''' Turn on or off 'ALLOW_SNAPSHOT_ISOLATION'
        ''' </summary>
        Public Shared Function SetSnapshot(ByVal connString As String, ByVal isOpen As Boolean) As Boolean
            Using conn As New SqlConnection(connString)
                Dim cmdText As String = Nothing

                If isOpen Then
                    cmdText = "ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION ON"
                Else
                    cmdText = "ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION OFF"
                End If


                Using command As New SqlCommand(cmdText, conn)
                    conn.Open()

                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True
        End Function
    End Class
End Namespace
