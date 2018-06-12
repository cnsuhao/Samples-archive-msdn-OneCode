/****************************** Module Header ******************************\
* Module Name:  Relay.cs
* Project:		CSASPNETWP7LivePainterServer
* Copyright (c) Microsoft Corporation.
* 
* Relay handler will receive the whiteboard points info and send to target 
* phones by Notification service.
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
using System.Net;
using System.Text;
using System.IO;

/// <summary>
/// The class functions as stroke relay,receive stroke info and broadcast 
/// stroke info to all other registered devices.
/// </summary>
public class Relay : IHttpHandler, IRequiresSessionState
{
    public bool IsReusable
    {
        get { return true; }
    }
    
    /// <summary>
    /// Handle the relay http request. 
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        Dictionary<Guid, Uri> channelsDict = null;
        // Make sure that channels dictionary object is existed.
        if (context.Application["channelsDict"] == null)
        {
            channelsDict = new Dictionary<Guid, Uri>();
            context.Application.Add("channelsDict", channelsDict);
        }
        channelsDict = context.Application["channelsDict"] as Dictionary<Guid, Uri>;

        // Get http post parameters.
        if (context.Request.Form.Count <= 0)
        {
            context.Response.StatusCode = 400;//bad request
            return;
        }

        NameValueCollection items = context.Request.Form;

        string senderId = items["id"].ToString();
        string strokeString = items["strokeString"].ToString();

        if (channelsDict.Count == 0) return;

        // Broadcast stroke info to all other devices.
        var keys = channelsDict.Keys;
        foreach (var key in keys)
        {
            SendStringToDevice(channelsDict[key], strokeString);
        }
    }

    /// <summary>
    /// This method will actually send stroke information back to devices.
    /// </summary>
    /// <param name="deviceUri"></param>
    /// <param name="content"></param>
    private void SendStringToDevice(Uri deviceUri,string content)
    {
        int contentLength = content.Length;
        HttpWebRequest sendNotificationRequest=(HttpWebRequest)WebRequest.Create(deviceUri);
        sendNotificationRequest.Method = "POST";
        System.Text.UTF8Encoding encoder = new UTF8Encoding();
        byte[] notificationMessage = encoder.GetBytes(content);

        sendNotificationRequest.ContentLength = notificationMessage.Length;
        sendNotificationRequest.ContentType = "text/plain";
        sendNotificationRequest.Headers.Add("X-NotificationClass", "3");

        using (Stream requestStream = sendNotificationRequest.GetRequestStream())
        {
            requestStream.Write(notificationMessage, 0, notificationMessage.Length);
        }
        
        sendNotificationRequest.GetResponse();
    }
}