/****************************** Module Header ******************************\
Module Name:  UserEntity.cs
Project:      AzureNTierWebRoleWithSession_WebRole
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
This sample also shows how to implement a User Session Handling (With Azure Cache Service).

This is a simple User entity class.

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
using System.Web;

namespace AzureNTierWebRoleWithSession_WebRole
{
    public class UserEntity
    {
        public string UserName
        {
            get;
            set;
        }

        public string PassWord
        {
            get;
            set;
        }
    }
}