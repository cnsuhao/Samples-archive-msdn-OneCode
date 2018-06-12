/****************************** Module Header ******************************\
* Module Name:  AsyncHttpGet.cs
* Project:		CSWF4AsyncHttpGetActivity
* Copyright (c) Microsoft Corporation.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System.Activities;
using System;
using System.Net;
using System.IO;

namespace CSWF4AsyncHttpGetActivity
{
    public class AsyncHttpGetActivity : AsyncCodeActivity<string>
    {
        public InArgument<string> Uri { get; set; }
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context,
                                                     AsyncCallback callback,
                                                     object state)
        {
            WebRequest request = HttpWebRequest.Create(this.Uri.Get(context));
            context.UserState = request;
            return request.BeginGetResponse(callback, state);
        }

        protected override string EndExecute(AsyncCodeActivityContext context,
                                             IAsyncResult result)
        {

            WebRequest request = context.UserState as WebRequest;
            using (WebResponse response = request.EndGetResponse(result))
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
