/****************************** Module Header ******************************\
* Module Name:	RetryPolicy.cs
* Project: StoryCreatorWebRole
* Copyright (c) Microsoft Corporation.
* 
* A simple retry policy used to access services.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Net;
using System.Threading;

namespace VideoStoryCreator.Helpers
{
    public class RetryPolicy
    {
        public HttpWebRequest Request { get; private set; }
        public Action Initialize { get; set; }
        public AsyncCallback RequestCallback;
        public AsyncCallback ResponseCallback;
        public string RequestAddress { get; set; }
        public TimeSpan WaitTime { get; set; }
        public int RetryNumber { get; set; }

        private int retriedTimes = 0;

        public RetryPolicy(string requestAddress)
        {
            this.Request = (HttpWebRequest)HttpWebRequest.Create(requestAddress);
            this.WaitTime = TimeSpan.FromSeconds(10d);
            this.RetryNumber = 3;
        }

        /// <summary>
        /// Start to make the request.
        /// </summary>
        public void MakeRequest()
        {
            this.Request = (HttpWebRequest)HttpWebRequest.Create(this.RequestAddress);
            for (int i = 0; i < this.RetryNumber; i++)
            {
                try
                {
                    this.Initialize();
                    this.Request.BeginGetRequestStream(this.GetRequestStreamCallback, null);
                    break;
                }
                catch
                {
                    Thread.Sleep(this.WaitTime);
                }
            }
        }

        /// <summary>
        /// Invoke the get request stream callback.
        /// </summary>
        public void GetRequestStreamCallback(IAsyncResult result)
        {
            this.RequestCallback(result);
            this.Request.BeginGetResponse(this.GetResponseCallback, null);
        }

        /// <summary>
        /// Invoke the get response callback.
        /// </summary>
        public void GetResponseCallback(IAsyncResult result)
        {
            try
            {
                this.retriedTimes++;
                this.ResponseCallback(result);
            }
            catch
            {
                if (this.retriedTimes < this.RetryNumber)
                {
                    // Something went wrong. Retry the request.
                    Thread.Sleep(this.WaitTime);
                    this.MakeRequest();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
