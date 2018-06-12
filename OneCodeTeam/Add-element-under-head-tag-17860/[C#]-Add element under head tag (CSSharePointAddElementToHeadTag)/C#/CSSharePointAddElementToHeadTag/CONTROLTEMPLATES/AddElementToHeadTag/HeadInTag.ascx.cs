/****************************** Module Header ******************************\
* Module Name:    HeadInTag.ascx.cs
* Project:        CSSharePointAddElementToHeadTag
* Copyright (c) Microsoft Corporation
*
* The User Control is used to render the custom Meta information.
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Globalization;
using Microsoft.SharePoint.Utilities;

namespace AddElementToHeadTag.CONTROLTEMPLATES.AddElementToHeadTag
{
    public partial class HeadInTag : UserControl
    {
        // You actually must override the Render method, because normally any control in ASP.NET
        // renders additional <span> (or another HTML element) around its contents. 
        // None of these elements are allowed in the <head> section.
        protected override void Render(HtmlTextWriter writer)
        {
            // The default keyword
            string keyword = SPContext.Current.Web.GetProperty("Default-CustomMetaKey") as string;

            // The default description
            string description = SPContext.Current.Web.GetProperty("Default-CustomMetaDescription") as string;

            // Get current page.
            SPFile file = SPContext.Current.File;

            // If the page does not exist or there is no special settings for it, use the default settings.
            // Otherwise, apply the specified configuration.
            if (file != null)
            {
                if (file.Exists)
                {
                    string fileName = file.Name;
                    string strCurrentPageKeyword = SPContext.Current.Web.GetProperty(fileName + "-CustomMetaKey") as string;
                    string strCurrentPageDescription = SPContext.Current.Web.GetProperty(fileName + "-CustomMetaDescription") as string;

                    if (!string.IsNullOrEmpty(strCurrentPageKeyword))
                    {
                        keyword = strCurrentPageKeyword;
                    }
                    if (!string.IsNullOrEmpty(strCurrentPageDescription))
                    {
                        description = strCurrentPageDescription;
                    }
                }
            }

            // Output the value
            writer.Write(String.Format(CultureInfo.CurrentCulture, "<meta name=\"description\" content=\"{0}\" />", description));
            writer.Write(String.Format(CultureInfo.CurrentCulture, "<meta name=\"keywords\" content=\"{0}\" />", keyword));
        }
    }
}
