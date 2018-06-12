/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETCensorKeywordInSite
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to filter some indecent words in website.
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;

namespace CSASPNETCensorKeywordInSite
{


    public partial class _Default : System.Web.UI.Page
    {
        // Sql Connection
        private static SqlConnection conn = 
            new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Sample.mdf;Integrated Security=True;User Instance=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            string str = tbText.Text;
            str = str.Trim(); // Remove the spaces and format symbols in the data
            string str1 = str.Replace(" ", "");

            bool isBool = ValidByReg(str1);

            if (isBool)
            {
                ltrMsg.Text = str;
            }
            else
            {
                ltrMsg.Text = ReplacDirty(str);
            }
        }

        // The blacklist such as：dirtyStr1|dirtyStr2|dirtyStr3
        public static string dirtyStr = ""; 

        public string ReplacDirty(string str)
        {
            dirtyStr = ReadDic();
            try
            {
                str = Regex.Replace(str, @"" + dirtyStr + "", @"xxxxx");
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
            return str;
        }


        private string ReadDic()
        {
            String input = "";

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

        public bool ValidByReg(string str)
        {
            dirtyStr = ReadDic();

            // Regular expression used to detect dirty dictionary
            Regex validateReg = 
                new Regex("^((?!" + dirtyStr + ").(?<!" + dirtyStr + "))*$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
       
            return validateReg.IsMatch(str);
        }

    }
}
