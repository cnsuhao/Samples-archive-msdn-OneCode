/****************************** Module Header ******************************\
* Module Name: WebPageEntity.cs
* Project:     CSASPNETDisplayDataStreamResource
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to display the data stream from Internet resource
* and site resource in a web page. Customers want to know how to display the 
* title, content or other information of web pages. Thus, the sample can search
* the target web page which you input url address in TextBox control and get all
* relative link resources of it. 
* 
* The entity class is used to store web pages' resources. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSASPNETDisplayDataStreamResource
{
    /// <summary>
    /// web page entity class, contain page's basic information,
    /// such as name, content, link, title, body text.
    /// </summary>
    [Serializable]
    public class WebPageEntity
    {
        private string name;
        private string content;
        private List<string> link;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public List<string> Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }
    }
}