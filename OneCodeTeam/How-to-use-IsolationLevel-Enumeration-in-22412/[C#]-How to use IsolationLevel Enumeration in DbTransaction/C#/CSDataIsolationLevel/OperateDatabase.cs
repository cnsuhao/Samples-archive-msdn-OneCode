/****************************** Module Header ******************************\
Module Name:  OperateDatabase.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
This class includes some operations in database.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data.SqlClient;

namespace CSDataIsolationLevel
{
    static class OperateDatabase
    {
        /// <summary>
        ///  If there's no database 'DbDataIsolationLevel', create the database.
        /// </summary>
        public static Boolean CreateDatabase(String connString)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    String cmdText = @"Use Master;

                                     if Db_Id('DbDataIsolationLevel') is null
                                      create Database [DbDataIsolationLevel];";

                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        conn.Open();

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Create the Database 'DbDataIsolationLevel'");
                }

            return true;
        }

        /// <summary>
        /// If there's no table [dbo].[Products] in DbDataIsolationLevel, create
        /// the table; or recreate it.
        /// </summary>
        public static Boolean CreateTable(String connString)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    String cmdText = @"Use DbDataIsolationLevel

                                    if Object_ID('[dbo].[Products]') is not null
                                    drop table [dbo].[Products]

                                    Create Table [dbo].[Products]
                                    (
                                    [ProductId] int IDENTITY(1,1) primary key,
                                    [ProductName] NVarchar(100) not null,
                                    [Quantity] int null,
                                    [Price] money null
                                    )";

                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                }

                return InsertRows(connString);            
        }

        /// <summary>
        /// Insert some rows into [dbo].[Products] table.
        /// </summary>
        public static Boolean InsertRows(String connString)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    String cmdText = @"Use DbDataIsolationLevel

                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Blue Bike', 365,1075.00)
                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Red Bike', 159, 1299.00)
                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Black Bike', 638, 1159.00)";

                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                }
            
            return true;
        }

        /// <summary>
        /// Turn on or off 'ALLOW_SNAPSHOT_ISOLATION'
        /// </summary>
        public static Boolean SetSnapshot(String connString,Boolean isOpen)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    String cmdText=null;

                    if (isOpen)
                    {
                        cmdText = @"ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION ON";
                    }
                    else
                    {
                        cmdText = @"ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION OFF";
                    }


                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                }
            
            return true;
        }
    }
}
