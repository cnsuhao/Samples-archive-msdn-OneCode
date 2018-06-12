/****************************** Module Header ******************************\
* Module Name: Person.cs
* Project:     CSASPNETClientTemplateJQueryJSON
* Copyright (c) Microsoft Corporation
*
* This project illustrates how to display a tabular data to users based on 
* some inputs in ASP.NET application. We will see how this can be addressed
* with JQuery and JSON to build a tabular data display in web page. Here we
* use JQuery plug-in JTemplate to make it easy.
* 
* Person entity class. 
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
using System.Web;

namespace CSASPNETClientTemplateJQueryJSON
{
    [Serializable]
    public class Person
    {
        private string name;
        private int age;
        private string country;
        private string address;
        private string mail;
        private string telephone;
        private string comment;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get 
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }

        public string Comment
        {
            get 
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }
    }
}