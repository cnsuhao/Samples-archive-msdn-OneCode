/***************************** Module Header ******************************\
* Module Name:	ValuesController.cs
* Project:		CSAzureACSWithWebAPI
* Copyright (c) Microsoft Corporation.
* 
* Secure Web API is a hot topic in asp.net forum.
* This sample will show you how to use Azure ACS secure the web API.
* It will require you sign in with Live ID/Google/Yahoo/Live connect account 
* first before you use the web API.
*
* ValuesController is an example WebAPI controller.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}