/****************************** Module Header ******************************\
Module Name:  AdmAccessToken.cs
Project:      CSTranslatorForAzure
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to use Bing translator API when you get it 
from Azure marked place.

This is a Admin Access Token entity class.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;


namespace TranslatorForAzure
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }
}