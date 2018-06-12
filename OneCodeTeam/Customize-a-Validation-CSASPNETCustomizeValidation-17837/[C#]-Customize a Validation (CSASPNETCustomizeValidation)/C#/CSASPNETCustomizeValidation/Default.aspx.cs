/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETCustomizeValidation
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to use a Customized Validation control
* to do your own validations with the help of CustomValidator.
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace CSASPNETCustomizeValidation
{
    public partial class _Default : System.Web.UI.Page
    {
        // Sql connection.
        static string connetionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connetionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Control To Validate: which control to type email
            TextBox tb = Page.FindControl(CustomValidator1.ControlToValidate) as TextBox;

            // Email text
            string strEmail = tb.Text.Trim();

            // Flag of exist
            int intNum = 0;

            // Regex for email.
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);

            // Verify that whether the email format is valid or not, if valid and then query the database to check
            // whether the email exists, otherwise set isvalid value to false.
            if (re.IsMatch(strEmail))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(1) from [user] where email=@email";
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = strEmail;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                intNum = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            else
            {
                CustomValidator1.ErrorMessage = "Invalid Email!";
                args.IsValid = false;
                return;
            }

            // Determine whether it exists or not
            if (intNum > 0)
            {
                CustomValidator1.ErrorMessage = "Cannot use this email address, because it has already been registered!";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }         
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // If IsValid is true then jump to another page. 
            if (IsValid)
            {
                Response.Redirect("success.aspx");
            }          
        }

    }
}
