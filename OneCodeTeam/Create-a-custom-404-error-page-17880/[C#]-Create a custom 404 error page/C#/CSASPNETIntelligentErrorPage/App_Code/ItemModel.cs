/****************************** Module Header ******************************\
Module Name:  ItemModel.cs
Project:      CSASPNETIntelligentErrorPage
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to create the intelligent error page in 
Asp.net application. In this sample, we add a custom 404 error page and find 
the similar local resources, then display them in error page. In this way, 
we will improve the user-experience, since users don’t need to face a boring 
and helpless error page any more.

This class is the model of url path.
 
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

namespace CSASPNETIntelligentErrorPage
{
    public class ItemModel
    {
        public string Name
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}
