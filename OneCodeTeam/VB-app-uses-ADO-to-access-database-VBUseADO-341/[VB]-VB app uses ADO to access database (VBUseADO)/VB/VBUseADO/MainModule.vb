'********************************* Module Header **************************************\
' Module Name:  MainModule.vb
' Project:      VBUseADO
' Copyright (c) Microsoft Corporation.
'
' The VBUseADO sample demonstrates the Microsoft ActiveX Data Objects(ADO) technology to 
' access databases using Visual Basic. It shows the basic structure of connecting to a data 
' source, issuing SQL commands, using the Recordset object and performing the cleanup.  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************************

Imports System

Module MainModule

    Sub Main()

        Dim conn As ADODB.Connection = Nothing
        Dim rs As ADODB.Recordset = Nothing

        Try

            '///////////////////////////////////////////////////////////////////////////////
            ' Connect to the data source.
            ' 

            Console.WriteLine("Connecting to the database ...")

            ' Get the connection string		
            Dim connStr As String = String.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI", _
                                                  ".\sqlexpress", "SQLServer2005DB")

            ' Open the connection
            conn = New ADODB.Connection()
            conn.Open(connStr, Nothing, Nothing, 0)

            '///////////////////////////////////////////////////////////////////////////////
            ' Build and Execute an ADO Command.
            ' It can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored 
            ' procedure call. Here is the sample of an INSERT command.
            ' 

            Console.WriteLine("Inserting a record to the CountryRegion table...")

            ' 1. Create a command object
            Dim cmdInsert As New ADODB.Command()

            ' 2. Assign the connection to the command
            cmdInsert.ActiveConnection = conn

            ' 3. Set the command text
            ' SQL statement or the name of the stored procedure 
            cmdInsert.CommandText = "INSERT INTO CountryRegion(CountryRegionCode, Name, ModifiedDate) VALUES (?, ?, ?)"

            ' 4. Set the command type
            ' ADODB.CommandTypeEnum.adCmdText for oridinary SQL statements; 
            ' ADODB.CommandTypeEnum.adCmdStoredProc for stored procedures.
            cmdInsert.CommandType = ADODB.CommandTypeEnum.adCmdText

            ' 5. Append the parameters

            ' Append the parameter for CountryRegionCode (nvarchar(20)
            ' Parameter name
            ' Parameter type (nvarchar(20))
            ' Parameter direction
            ' Max size of value in bytes
            Dim paramCode As ADODB.Parameter = cmdInsert.CreateParameter( _
            "CountryRegionCode", _
            ADODB.DataTypeEnum.adVarChar, _
            ADODB.ParameterDirectionEnum.adParamInput, _
            20, _
            "ZZ" & DateTime.Now.Millisecond)


            ' Parameter value
            cmdInsert.Parameters.Append(paramCode)

            ' Append the parameter for Name (nvarchar(200))
            ' Parameter name
            ' Parameter type (nvarchar(200))
            ' Parameter direction
            ' Max size of value in bytes
            Dim paramName As ADODB.Parameter = cmdInsert.CreateParameter( _
            "Name", _
            ADODB.DataTypeEnum.adVarChar, _
            ADODB.ParameterDirectionEnum.adParamInput, _
            200, _
            "Test Region Name")

            ' Parameter value
            cmdInsert.Parameters.Append(paramName)

            ' Append the parameter for ModifiedDate (datetime)
            ' Parameter name
            ' Parameter type (datetime)
            ' Parameter direction
            ' Max size (ignored for datetime)
            Dim paramModifiedDate As ADODB.Parameter = cmdInsert.CreateParameter( _
            "ModifiedDate", _
            ADODB.DataTypeEnum.adDate, _
            ADODB.ParameterDirectionEnum.adParamInput, _
            -1, _
            DateTime.Now)

            ' Parameter value
            cmdInsert.Parameters.Append(paramModifiedDate)

            ' 6. Execute the command
            Dim nRecordsAffected As Object = Type.Missing
            Dim oParams As Object = Type.Missing
            cmdInsert.Execute(nRecordsAffected, oParams, CInt(ADODB.ExecuteOptionEnum.adExecuteNoRecords))


            '///////////////////////////////////////////////////////////////////////////////
            ' Use the Recordset Object.
            ' http://msdn.microsoft.com/en-us/library/ms681510.aspx
            ' Recordset represents the entire set of records from a base table or the 
            ' results of an executed command. At any time, the Recordset object refers to 
            ' only a single record within the set as the current record.
            ' 

            Console.WriteLine("Enumerating the records in the CountryRegion table")

            ' 1. Create a Recordset object
            rs = New ADODB.Recordset()

            ' 2. Open the Recordset object
            Dim strSelectCmd As String = "SELECT * FROM CountryRegion" ' WHERE ...

            ' SQL statement / table,view name /
            ' stored procedure call / file name
            ' Connection / connection string
            ' Cursor type. (forward-only cursor)
            ' Lock type. (locking records only 
            ' when you call the Update method.
            ' Evaluate the first parameter as
            ' a SQL command or stored procedure.

            rs.Open(strSelectCmd, _
                    conn, _
                    ADODB.CursorTypeEnum.adOpenForwardOnly, _
                    ADODB.LockTypeEnum.adLockOptimistic, _
                    CInt(ADODB.CommandTypeEnum.adCmdText))

            ' 3. Enumerate the records by moving the cursor forward
            rs.MoveFirst()
            ' Move to the first record in the Recordset
            While (Not rs.EOF)

                ' When dumping a SQL-Nullable field in the table, need to test it for 
                ' DBNull.Value.
                Dim code As String = If(rs.Fields("CountryRegionCode").Value Is DBNull.Value, _
                                        "(DBNull)", rs.Fields("CountryRegionCode").Value.ToString())

                Dim name As String = If(rs.Fields("Name").Value Is DBNull.Value, _
                                        "(DBNull)", rs.Fields("Name").Value.ToString())

                Dim modifiedDate As Date = If(rs.Fields("ModifiedDate").Value Is DBNull.Value, _
                                              Date.MinValue, CDate(rs.Fields("ModifiedDate").Value))


                Console.WriteLine(" {2} " & vbTab & "{0}" & vbTab & "{1}", code, name, modifiedDate.ToString("yyyy-MM-dd"))

                ' Move to the next record
                rs.MoveNext()
            End While

        Catch ex As Exception

            Console.WriteLine("The application throws the error: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Console.WriteLine("Description: " & ex.InnerException.Message)
            End If

        Finally

            '///////////////////////////////////////////////////////////////////////////////
            ' Clean up objects before exit.
            ' 

            Console.WriteLine("Closing the connections ...")

            ' Close the record set if it is open
            If rs IsNot Nothing AndAlso rs.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
                rs.Close()
            End If

            ' Close the connection to the database if it is open
            If conn IsNot Nothing AndAlso conn.State = CInt(ADODB.ObjectStateEnum.adStateOpen) Then
                conn.Close()
            End If

        End Try

    End Sub

End Module
