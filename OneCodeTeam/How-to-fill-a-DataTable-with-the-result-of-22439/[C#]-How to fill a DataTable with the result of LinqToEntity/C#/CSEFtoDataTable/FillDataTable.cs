/****************************** Module Header ******************************\
Module Name:  FillDataTable.cs
Project:      CSEFtoDataTable
Copyright (c) Microsoft Corporation.

This sample demonstrates how to fill a DataTable with the result of the Linq 
to Entity query.
This file demonstrates how to use the connection string and query string to
fill a DataTable. First, we get the connection string, query string and the parameters 
from the Linq to Entity. Then we use the SqlDataAdapter to fill a DataTable and 
return it. 

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace CSEFtoDataTable
{
    public static class FillDataTable
    {
        /// <summary>
        /// Get the connection string, query string and the parameters from the 
        /// Linq to Entity, and then return the DataTable.
        /// </summary>
        /// <typeparam name="T">the type parameter of the IQueryable</typeparam>
        /// <param name="result">the query of the Linq to Entity</param>
        /// <param name="context">DbContext or ObjectContext</param>
        /// <returns>the result of the DataTable</returns>
        public static DataTable EFtoDataTable<T>(IQueryable<T> result, object context)
        {
            string queryString = null;
            string connectionString = null;
            SqlParameter[] parameters = null;

            try
            {
                if (context is DbContext)
                {
                    DbQuery<T> query = result as DbQuery<T>;

                    // Get the query string.
                    queryString = query.ToString();

                    // Because the DeQuery doesn't support the parameters collection, we use 
                    // the reflection to get the ObjectQuery, and then get the parameters collection.
                    ObjectQuery objectQuery = GetObjectQuery(query);
                    parameters = GetSqlParameters(objectQuery.Parameters);

                    // Get the collection string.
                    connectionString = (context as DbContext).Database.Connection.ConnectionString;
                }
                else if (context is ObjectContext)
                {
                    ObjectQuery query = result as ObjectQuery;

                    // Get the query string.
                    queryString = query.ToTraceString();

                    // Get the parameters collection.
                    parameters = GetSqlParameters(query.Parameters);

                    // Get the connection string.
                    EntityConnection connection = (context as ObjectContext).Connection as EntityConnection;
                    connectionString = connection.StoreConnection.ConnectionString;
                }
            }
            catch
            {
                throw;
            }

            if (string.IsNullOrEmpty(queryString) || string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException();
            }

            // Get and return the DataTable.
            return EFtoDatatable(queryString, connectionString, parameters);
        }

        /// <summary>
        ///  Use the SqlDataAdapter to fill the DataTable.
        /// </summary>
        /// <param name="queryString">the query string</param>
        /// <param name="connectionString">the connection string</param>
        /// <param name="parameters">the parameter collection</param>
        /// <returns>the result of the DataTable</returns>
        private static DataTable EFtoDatatable(string queryString, string connectionString,SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection SQLCon = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand(queryString, SQLCon))
                    {
                        // Add the parameter collection.
                        Cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transform the ObjectParameterCollection to the SqlParameter array.
        /// </summary>
        /// <param name="objectParameters">the ObjectParameter collection</param>
        /// <returns>the SqlParameter array</returns>
        private static SqlParameter[] GetSqlParameters(ObjectParameterCollection objectParameters)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach(ObjectParameter parameter in objectParameters)
            {
                parameters.Add(new SqlParameter(parameter.Name,parameter.Value));
            }

            return parameters.ToArray();
        }

        /// <summary>
        /// Use reflection to get the ObjectQuery from the DbQuery.
        /// </summary>
        /// <param name="query">the DbQuery</param>
        /// <returns>the ObjectQuery</returns>
        private static ObjectQuery GetObjectQuery(DbQuery query)
        {
            // Get the InternalQuery of the DbQuery.
            PropertyInfo internalProperty = query.GetType().GetProperty("InternalQuery",BindingFlags.NonPublic | BindingFlags.Instance);
            object internalValue = internalProperty.GetValue(query, null);

            // Get the ObjectQuery of the InternalQuery.
            PropertyInfo objectQueryProperty = internalValue.GetType().GetProperty("ObjectQuery", BindingFlags.Public | BindingFlags.Instance);
            object objectQuery = objectQueryProperty.GetValue(internalValue, null);

            return objectQuery as ObjectQuery;
        }

    }
}
