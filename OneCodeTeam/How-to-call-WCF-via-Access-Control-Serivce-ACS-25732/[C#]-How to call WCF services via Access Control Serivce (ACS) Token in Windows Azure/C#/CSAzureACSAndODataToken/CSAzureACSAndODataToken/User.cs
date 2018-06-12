/****************************** Module Header ******************************\
Module Name:  User.cs
Project:      RESTfulWCFLibrary
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

This is the entity class.

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
using System.Text;
using System.Runtime.Serialization;

namespace RESTfulWCFLibrary
{

    public class User
    {
        [DataMember(Name = "UserId", Order = 1)]
        public string UserId
        {
            get;
            set;
        }

        [DataMember(Name = "FirstName", Order = 2)]
        public string FirstName
        {
            get;
            set;
        }


        [DataMember(Name = "LastName", Order = 3)]
        public string LastName
        {
            get;
            set;
        }

    } 

}
