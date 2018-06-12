/****************************** Module Header ******************************\
* Module Name: RegexMethod.cs
* Project:     CSASPNETDisplayDataStreamResource
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to display the data stream from Internet resource
* and site resource in a web page. Customers want to know how to display the 
* title, content or other information of web pages. Thus, the sample can search
* the target web page which you input url address in TextBox control and get all
* relative link resources of it. 
* 
* The class is used to extract specific information from HTML resource.
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
using System.Text.RegularExpressions;
using System.Text;

namespace CSASPNETDisplayDataStreamResource
{
    public class RegexMethod
    {
        public List<string> GetLinks(string htmlCode,string url)
        {
            List<string> links=new List<string>();
            string strRegexLink = @"(?is)<a .*?>";
            MatchCollection matchList = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase);
            StringBuilder strbLinkList = new StringBuilder();

            foreach (Match matchSingleLink in matchList)
            {
                string matchLink = @"<a[^>]*?href=(['""\s]?)([^'""\s]+)\1[^>]*?>";
                Match match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase);
                if (match.Groups[2].Value == "#")
                {
                    links.Add(url);
                }
                else if (!match.Groups[2].Value.ToLower().Contains("http://"))
                {
                    links.Add(url + match.Groups[2].Value);
                }
                else
                {
                    links.Add(match.Groups[2].Value);
                }
            }
            return links;
        }

        public static bool IsUrl(string source)
        {

            return Regex.IsMatch(source, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        }

    }
}