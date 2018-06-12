/****************************** Module Header ******************************\
* Module Name:    CustomCalendarWebPart.cs
* Project:        CSSharePointCustomCalendar
* Copyright (c) Microsoft Corporation
*
* This sample demonstrates how to use SPCalendarView to develop a custom calendar
* in a visual web part.This is the WebPart. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;

namespace CSSharePointCustomCalendar.CustomCalendarWebPart
{
    [ToolboxItemAttribute(false)]
    public class CustomCalendarWebPart : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/CSSharePointCustomCalendar/CustomCalendarWebPart/CustomCalendarWebPartUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }
    }
}
