/****************************** Module Header ******************************\
* Module Name:    Province.cs
* Project:        CSASPNETJqueryFilterLoadDynamicContent
* Copyright (c) Microsoft Corporation
*
* Province data.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
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

namespace CSASPNETJqueryFilterLoadDynamicContent
{   
    public class Province
    {
        public string ProvinceName { get; set; }
        public string PinYin { get; set; }
        public string countryID { get; set; }
    }
}
