/****************************** Module Header ******************************\
Module Name:  DirtyReadThreads.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
In this class, we will demonstrate if the specific transaction allows the Dirty 
Read behavior.
If the transaction allows the behavior, the threads will operate in the following 
order:
1. In first thread, begin a transaction and add the Quantity value(ProductId=1);
2. In the second thread, read the Quantity value and add the value again;
3. Commit the transaction in second thread;
4. Roll back the transacton in first thread.
If the transaction allows the behavior, the Quantity value will be added twice;
or the Quantity value will be added once.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data;
using System.Data.SqlClient;

namespace CSDataIsolationLevel
{
    static class DirtyReadThreads
    {
        public static void DirtyReadFirstThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the DirtyReadFirstThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {                
                    String cmdText = @"Use DbDataIsolationLevel; 

                    Update dbo.Products set Quantity=Quantity+100 where ProductId=1;
                    WaitFor Delay '00:00:06';";

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction(level, "DirtyReadFirst"))
                    {
                        using (SqlCommand command = new SqlCommand(cmdText, conn))
                        {
                            command.Transaction = tran;

                            command.ExecuteNonQuery();
                        }
                        
                        if (tran != null)
                        {
                            tran.Rollback();
                        }
                    }               
            }

            Console.WriteLine("Exit from the DirtyReadFirstThread.....");
        }

        public static void DirtyReadSecondThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the DirtyReadSecondThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {
                    String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Declare @qty int;
                    select @qty=Quantity from dbo.Products where ProductId=1;

                    Update dbo.Products set Quantity=@qty+100 where ProductId=1;";

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction(level, "DirtyReadSecond"))
                    {
                        using (SqlCommand command = new SqlCommand(cmdText, conn))
                        {
                            command.Transaction = tran;

                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
            }

            Console.WriteLine("Exit from the DirtyReadSecondThread.....");
        }
    }
}
