/***************************** Module Header ******************************\
* Module Name:	UserInfo.cs
* Project:		CSASPNETUseJsonString
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to post complex data to MVC server side using json string.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSASPNETUseJsonString.Models
{
    public class UserInfo
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}