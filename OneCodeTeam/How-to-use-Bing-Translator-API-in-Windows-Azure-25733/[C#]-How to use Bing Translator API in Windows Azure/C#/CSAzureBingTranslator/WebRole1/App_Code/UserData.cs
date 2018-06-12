/****************************** Module Header ******************************\
Module Name:  UserData.cs
Project:      CSTranslatorForAzure
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to use Bing translator API when you get it 
from Azure marked place.

This class store user's data.
 
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



namespace TranslatorForAzure
{
    public static class UserData
    {
        //This access tokent is only for test.
        //To register your application with Azure DataMarket,visit  
        //https://datamarket.azure.com/developer/applications/ using the LiveID.
        public static string clientID = "DinoBingTranslator";
        public static string clientSecret = "fzdwgtXmhazt/AEkH7BD+U+CZXpAn64xzwHdaUykN7E=";
    }
}