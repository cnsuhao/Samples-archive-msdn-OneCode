/****************************** Module Header ******************************\
* Module Name: ValidateString.cs
* Project:     CSASPNETOnlineUserListMemberShip
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to show an online user list via Membership.
* In many websites, managers want to collect statistics of online users, 
* The sample can check if the user is online and his(her) last activity
* time, creation time and much useful information.
* 
* This class use to validate string and e-mail string.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
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
using System.Text.RegularExpressions;

namespace CSASPNETOnlineUserList
{
    public class ValidateString
    {
        /// <summary>
        /// E-mail string validation via Regular Expression
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strInfo)
        {
            // Return true if strInfo is in valid e-mail format.
            return Regex.IsMatch(strInfo, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" +
               @"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// Validate e-mail string
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool validateEmailString(string strEmail)
        {
            if (string.IsNullOrEmpty(strEmail))
            {
                return false;
            }
            else if (!IsValidEmail(strEmail))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validate normal string
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        public static bool validateString(string strString)
        {
            if (string.IsNullOrEmpty(strString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}