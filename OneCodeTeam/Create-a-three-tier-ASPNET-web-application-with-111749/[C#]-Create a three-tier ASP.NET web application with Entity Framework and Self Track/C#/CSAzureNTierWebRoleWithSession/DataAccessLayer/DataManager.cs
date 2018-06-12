/****************************** Module Header ******************************\
Module Name:  DataManager.cs
Project:      DataAccessLayer
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
This sample also shows how to implement a User Session Handling (With Azure Cache Service).

This class is used to retrieve data from Entity Framework (SQL Azure database).

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DataManager
    {
        public TestDBEntities context;
        public DataManager()
        {
            context = new TestDBEntities();
        }

        /// <summary>
        /// Get all data of TestTable table of SQL Azure.
        /// </summary>
        /// <returns></returns>
        public List<TestTable> GetAllTable()
        {
            List<TestTable> list = new List<TestTable>();
            list = context.TestTable.ToList<TestTable>();
            return list;
        }
    }
}
