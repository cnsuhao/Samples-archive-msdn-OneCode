/****************************** Module Header ******************************\
* Module Name:  SubscribePhone.cs
* Project:		CSWP7LivePainter
* Copyright (c) Microsoft Corporation.
* 
* Register handler will keep listening the coming phone request and register 
* the online phone.
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


public class SubscribePhone :IHttpHandler,IRequiresSessionState {

    public bool IsReusable {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context) {
        Dictionary<Guid, Uri> channelsDict = null;

        // Make sure that channelsDict is existed.
        if (context.Application["channelsDict"] == null) {
            channelsDict = new Dictionary<Guid, Uri>();
            context.Application.Add("channelsDict", channelsDict);
        }
        channelsDict =context.Application["channelsDict"] as Dictionary<Guid,Uri>;

        // Get post parameters
        if (context.Request.Form.Count <= 0) {
            context.Response.StatusCode = 400;  // bad request
            return;
        }

        NameValueCollection items = context.Request.Form;

        string guidString = items["id"].ToString();
        Guid id = new Guid(guidString);
        string channelUri = items["channelUri"].ToString();

        // Add channelUri to server devices dictionary.so that Relay handle
        // can send stroke info back to this device. 
        channelsDict.Add(id,new Uri(channelUri));
        context.Application["channelsDict"] = channelsDict;
    }
}