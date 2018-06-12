/****************************** Module Header ******************************\
Module Name:  NonrepeatableReadThreads.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
In this class, we will demonstrate if the specific transaction allows the Nonrepeatable 
Read behavior.
If the transaction allows the behavior, the threads will operate in the following 
order:
1. In first thread, select the product(ProductId=1);
2. In the second thread, update the Quantity value(ProductId=1);
3. Commit the transaction in second thread;
4. Select the product again.
5. Commit the transaction in first thread;
If the transaction allows the behavior, the two Select operations will get the 
different results; or the two Select operations will get the same result.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data.SqlClient;
using System.Data;

namespace CSDataIsolationLevel
{
    static class NonrepeatableReadThreads
    {
        public static void NonrepeatableReadFirstThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the NonrepeatableReadFirstThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {
                String cmdText = @"Use DbDataIsolationLevel; 

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products
                    where ProductId=1

                    WaitFor Delay '00:00:06';

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products
                    where ProductId=1";

                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction(level, "NonrepeatableReadFirst"))
                {
                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        command.Transaction = tran;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Boolean isFirstReader = true;
                            do
                            {
                                Console.WriteLine("It's the result of {0} read:", isFirstReader ? "first" : "second");
                                TransactionIsolationLevels.DisplayData(reader);
                                isFirstReader = !isFirstReader;
                            } while (reader.NextResult() && !isFirstReader);
                        }
                    }

                    tran.Commit();
                }
            }

            Console.WriteLine("Exit from the NonrepeatableReadFirstThread.....");
        }

        public static void NonrepeatableReadSecondThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the NonrepeatableReadSecondThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {
                String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Update dbo.Products set Quantity=Quantity+100 where ProductId=1;";

                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction(level, "NonrepeatableReadSecond"))
                {
                    using (SqlCommand command = new SqlCommand(cmdText, conn))
                    {
                        command.Transaction = tran;

                        command.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
            }

            Console.WriteLine("Exit from the NonrepeatableReadSecondThread.....");
        }
    }
}
