/****************************** Module Header ******************************\
* Module Name:    AssociationData.cs
* Project:        CSSharePointReplicatorActivity
* Copyright (c) Microsoft Corporation
*
* This class is used to store Association Data.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSSharePointReplicatorActivity.MyWorkflow
{
    [Serializable]
    public class AssociationData
    {
        private Contacts partners = default(Contacts);
        public Contacts Partners
        {
            get
            {
                return this.partners;
            }
            set
            {
                this.partners = value;
            }
        }

        private string description = default(string);
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public void AddContact(string contact)
        {
            if (this.partners == null)
            {
                this.partners = new Contacts();
            }
            this.partners.AddContact(contact);
        }
        public string[] Getpartners()
        {
            return this.partners.ContactList.ToArray();
        }
    }

    [Serializable()]
    public class Contacts
    {
        private List<string> contacts;

        public List<string> ContactList
        {
            get { return contacts; }
            set { contacts = value; }
        }
        public void AddContact(string contact)
        {
            if (this.contacts == null)
            {
                this.contacts = new List<string>();
            }
            this.contacts.Add(contact);
        }

    }
}
