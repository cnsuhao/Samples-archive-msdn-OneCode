/***************************** Module Header ******************************\
* Module Name:	Product.cs
* Project:		CSAzureACSWithWebAPI
* Copyright (c) Microsoft Corporation.
* 
* Secure Web API is a hot topic in asp.net forum.
* This sample will show you how to use Azure ACS secure the web API.
* It will require you sign in with Live ID/Google/Yahoo/Live connect account 
* first before you use the web API.
*
* Product model
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}