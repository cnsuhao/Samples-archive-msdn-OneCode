/****************************** Module Header ******************************\
* Module Name:  SubscribePhone.cs
* Project:		CSWP7LivePainter
* Copyright (c) Microsoft Corporation.
* 
* Remove handler will remove phone from the server; 
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;

public class UnregisterPhone : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        Dictionary<Guid, Uri> channelsDict = null;

        // Make sure that channelsDict is existed.
        if (context.Application["channelsDict"] == null)
        {
            channelsDict = new Dictionary<Guid, Uri>();
            context.Application.Add("channelsDict", channelsDict);
        }
        channelsDict = context.Application["channelsDict"] as Dictionary<Guid, Uri>;

        // Get post parameters
        if (context.Request.Form.Count <= 0)
        {
            context.Response.StatusCode = 400;  // bad request
            // context.Response.Write("no parameter");
            return;
        }

        NameValueCollection items = context.Request.Form;

        string guidString = items["id"].ToString();
        Guid id = new Guid(guidString);

        // Remove the closed device channel uri from the channels dictionary
        // so that Relay handle will no long broadcast stroke to this device.
        channelsDict.Remove(id);
        context.Application["channelsDict"] = channelsDict;
    }
}