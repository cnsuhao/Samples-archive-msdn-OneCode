/****************************** Module Header ******************************\
Module Name:  IUserService.cs
Project:      RESTfulWCFLibrary
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

This is the interface of WCF service.

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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web; 

namespace RESTfulWCFLibrary
{
    [ServiceContract]
    interface IUserService
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "/users",
        ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<User> GetAllUsers();

        /// <summary>
        /// Add a new user instance
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/users",
                   Method = "POST",
                   RequestFormat = WebMessageFormat.Xml,
                   ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool AddNewUser(User u);

        /// <summary>
        /// Get user info by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "/users/{userId}",
                ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        User GetUser(string userId);
    }
}
