/****************************** Module Header ******************************\
Module Name:  UserService.cs
Project:      RESTfulWCFLibrary
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

This is the Service class that implements service interface.

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

namespace RESTfulWCFLibrary
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>();

        /// <summary>
        /// Add default users.
        /// </summary>
        public UserService()
        {
            User user = new User();
            user.UserId = "1";
            user.FirstName = "Jim";
            user.LastName = "James";
            User user2 = new User();
            user2.UserId = "2";
            user2.FirstName = "Nancy";
            user2.LastName = "Wang";
            users.Add(user);
            users.Add(user2);
        }

        /// <summary>
        /// Return all users.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return users;
        }

        /// <summary>
        /// Add a new user in user list.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool AddNewUser(User u)
        {
            if (!users.Exists(e => e.UserId == u.UserId))
            {
                users.Add(u);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get user info by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            if (users.Exists(e => e.UserId == userId))
            {
                return users.Find(f => f.UserId == userId);
            }
            else
            {
                User user = new User();
                user.UserId = "";
                return user;    
            }
        }
    }
}
