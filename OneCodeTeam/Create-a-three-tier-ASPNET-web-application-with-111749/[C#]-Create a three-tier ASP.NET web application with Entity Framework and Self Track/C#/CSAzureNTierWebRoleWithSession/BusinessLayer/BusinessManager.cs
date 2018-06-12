/****************************** Module Header ******************************\
Module Name:  BusinessManager.cs
Project:      BusinessLayer
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
which uses Entity Framework (SQL Azure database) as the Data Access Layer.
And Business layer can call DAL class instances and methods, web role application
will call BLL method to load the data come from database. This sample also shows
how to implement a User Session Handling (With Azure Cache Service).

This class is used to retrieve data from DAL.

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
using DataAccessLayer;

namespace BusinessLayer
{
    public class BusinessManager
    {
        private DataManager dataManager;
        public BusinessManager()
        {
            dataManager = new DataManager();
        }

        public List<TestTable> GetData()
        {
           return dataManager.GetAllTable();
        }
    }
}
