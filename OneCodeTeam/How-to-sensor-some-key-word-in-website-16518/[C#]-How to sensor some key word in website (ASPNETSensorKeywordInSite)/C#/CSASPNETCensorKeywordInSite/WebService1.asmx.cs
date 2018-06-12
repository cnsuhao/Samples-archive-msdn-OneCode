/****************************** Module Header ******************************\
* Module Name:    WebService1.asmx.cs
* Project:        CSASPNETCensorKeywordInSite
* Copyright (c) Microsoft Corporation
*
* Get word black list dictionary 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CSASPNETCensorKeywordInSite
{
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService()]
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Services.WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        // Sql Connection
        private static SqlConnection conn = 
            new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Sample.mdf;Integrated Security=True;User Instance=True");

        [WebMethod()]
        public string LoadScript()
        {
            // Add your operation implementation here
            string input = "";

            // Query string
            string queryString = "SELECT [Name] FROM [WordBlack]";

            // set query string
            SqlCommand command = new SqlCommand(queryString, conn);

            // Open connection
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    input += "|" + (reader["Name"] as string).Trim();
                }
                input = input.Substring(1);
            }
            reader.Close();
            
            // Close connection
            conn.Close();

            return input;
        }      
    }
}