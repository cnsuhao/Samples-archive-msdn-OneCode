/****************************** Module Header ******************************\
* Module Name: WordAddPage.aspx.cs
* Project:     CSASPNETIntelligentTextBox
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to check the spelling written in text box 
* is correct or not. This sample code can check the user's input word 
* with word dictionary, provides some similar words for user select.
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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;

namespace CSASPNETIntelligentTextBox
{
    public partial class WordAddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Add new words
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string validateResult = StringValidate(tbNewWords.Text);
            if (string.IsNullOrEmpty(validateResult))
            {
                string[] words = tbNewWords.Text.Trim().Split(',');
                using (StreamWriter writer = new StreamWriter(Server.MapPath("~/Dictionary/WordList.txt"), true))
                {
                    foreach (string str in words)
                    {
                        writer.WriteLine(str);
                    }
                    lbMessage.Text = "Congratulations, the new word has been added in Word dictionary.";
                }
            }
            else
            {
                lbMessage.Text = validateResult;
            }
        }

        /// <summary>
        /// String variables validation.
        /// </summary>
        /// <param name="strWords"></param>
        /// <returns></returns>
        protected static string StringValidate(string strWords)
        {
            string words = strWords.Trim();
            if (string.IsNullOrEmpty(words))
            {
                return "Words can not be null.";
            }
            else if (StringIncludeNumberic(words))
            {
                return "Words can not include numeral and special characters.";
            }
            else
            {
                return string.Empty;
            }
        }

        protected static bool StringIncludeNumberic(string strWords)
        {
            string strRegex = @"[^a-zA-z,']";
            return Regex.IsMatch(strWords, strRegex);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
