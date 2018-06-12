/****************************** Module Header ******************************\
* Module Name:  Default.aspx.cs
* Project:		CSASPNETWP7LivePainterServer
* Copyright (c) Microsoft Corporation.
* 
* Server part(CSASPNETWP7LivePainterServer): there will be 3 httphandlers. 
* Register handler will keep listening the coming phone request and register 
* the online phone; Remove handler will remove phone from the server; Relay 
* handler will receive the whiteboard points info and send to target phones 
* by Notification service.
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CSASPNETWP7LivePainterServer
{
    /// <summary>
    /// This page is for monitoring the register devices, and you can clear
    /// the channel dictionary as you like. 
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<Guid, Uri> channelsDict = 
                Application["channelsDict"] as Dictionary<Guid, Uri>;
            StringBuilder sb = new StringBuilder();
            var keys = channelsDict.Keys;
            if (keys.Count == 0)
            {
                label_msg.Text = "no phone";
                return;
            }

            foreach (var key in keys)
            {
                sb.Append(key.ToString());
                sb.Append(" ");
                sb.Append(channelsDict[key].ToString());
                sb.Append("\r\n");
            }
            label_msg.Text = sb.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<Guid, Uri> channelsDict = 
                Application["channelsDict"] as Dictionary<Guid, Uri>;
            channelsDict.Clear();
            Application["channelsDict"] = channelsDict;
        }
    }
}
