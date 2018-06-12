/****************************** Module Header ******************************\
* Module Name:    example.aspx.cs
* Project:        CSASPNETGetDesiredResultByAJAXCalls
* Copyright (c) Microsoft Corporation
*
* This ASPX page is used to handle the ajax request and return data.
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETGetDesiredResultByAJAXCalls
{
    public partial class example : System.Web.UI.Page
    {
        protected override void Render(HtmlTextWriter output)
        {
            // Query String
            string strText = Request.QueryString["str"];
            string type = Request.QueryString["type"];

            // Output String
            string strOutput = string.Empty;

            // Returns the appropriate data type by Query String
            switch (type)
            {
                case "1": // For plain text, "hello world" or some information you have typed.
                    if (string.IsNullOrEmpty(strText))
                    {
                        strText = "hello world";
                    }
                    strOutput = strText;
                    break;
                case "2": // For JSON, {"hello": "world"}                    
                    strOutput = "{\"hello\": \"world\",\"face\": \"smile\"}";
                    break;
                case "3": // For XML, <hello>Hello</hello><world>World</word>
                    strOutput = "<?xml version=\"1.0\" encoding=\"GB2312\"?><root><hello>Hello</hello><world>World</world></root>";
                    break;
                default:
                    break;
            }

            // Set the HTTP MIME type of the output stream
            Response.ContentType = "text/xml";

            // Output stream
            output.Write(strOutput);
        }
    }
}