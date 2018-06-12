/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
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
using System.IO;
using System.Collections.Generic;

namespace CSASPNETIntelligentTextBox
{
    public partial class Default : System.Web.UI.Page
    {
        // Define some public variables for load word dictionary event.
        static ArrayList LineList = new ArrayList();
        public int StringNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ////Load Method////

            LineList.Clear();
            // Use StreamReader to load word dictionary , store them in an ArrayList.
            string dictionaryFilePath = Page.Server.MapPath("~/Dictionary/WordList.txt");
            using (StreamReader fileStream = new StreamReader(dictionaryFilePath))
            {
                if (fileStream == null)
                {
                    return;
                }
                string readLine = string.Empty;
                StringNumber = 0;
                while (readLine != null)
                {
                    readLine = fileStream.ReadLine();
                    if (!String.IsNullOrEmpty(readLine))
                    {
                        LineList.Add(readLine.Replace("'", "\'"));
                        StringNumber++;
                    }
                }
            }
            StringNumber = LineList.Count;

            #endregion
        }

        /// <summary>
        /// This method is used to call check user's input word and returns some recommended words.
        /// A JavsScript function will invoke this method to execute server-side code,
        /// This will bring many benefits, such as when user input words and the application will
        /// update recommended word list without page refresh, it can provide more responsive.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string ReturnHtmlString(string key)
        {
            #region ////Match Method////

            // Define an ArrayList to retrieve word list, 
            // the Dictionary use to record similar words.
            ArrayList list = (ArrayList)LineList;
            Dictionary<int, string[]> matchEntity = new Dictionary<int, string[]>();
            int sortID = 0;
            int highLevel = 0;
            // Loop the word dictionary, compare with source word. 
            for (int i = 0; i < list.Count; i++)
            {
                // Confirm the word length, calculate word's similar level and 
                // move the cursor to next character.
                string source = list[i].ToString();
                int sourceLength = list[i].ToString().Length;
                int keyLength = key.Length;
                int matchLength = ((sourceLength > keyLength) ? keyLength : sourceLength);
                int matchLevel = 0;
                int cursor = 0;
                while (cursor < matchLength)
                {
                    if (source[cursor] == key[cursor])
                    {
                        matchLevel++;
                        cursor++;
                    }
                    else if (matchLevel >= 1)
                    {
                        cursor++;
                    }
                    else
                    {
                        matchLevel = 0;
                        break;
                    }
                }
                if (matchLevel >= 1)
                {
                    string[] entity = new string[4];
                    entity[0] = matchLevel.ToString();
                    entity[1] = source;
                    entity[2] = sourceLength.ToString();
                    matchEntity.Add(sortID, entity);
                    if (matchLevel > highLevel)
                        highLevel = matchLevel;
                    sortID++;
                }
            }
            var highLevelList = from d in matchEntity
                                where d.Value[0] == highLevel.ToString()
                                select d;
            #endregion

            #region ////Sort Method////

            // Sort the result with the highest similar level and characters' length.
            // And we must make sure the recommended word list must include 10 words.
            if (highLevelList.ToList().Count <= 10)
            {
                int listNumber = highLevelList.ToList().Count;
                string returnHtml = string.Empty;
                var sortMatchList = from d in highLevelList
                                    orderby Convert.ToInt32(d.Value[2])
                                    select d;
                foreach (var s in sortMatchList)
                {
                    returnHtml += "<li onclick='getValue(this)'>" + s.Value[1] + "</li>";
                    matchEntity.Remove(s.Key);
                    listNumber++;
                }
                var lowLevelList = matchEntity.OrderByDescending(d => d.Value[0]);
                int number = 0;
                foreach (var s in lowLevelList)
                {
                    if (number < (10 - listNumber))
                    {
                        returnHtml += "<li onclick='getValue(this)'>" + s.Value[1] + "</li>";
                        number++;
                    }
                    else
                    {
                        break;
                    }
                }
                return returnHtml;
            }
            else
            {
                int listNumber = 0;
                string returnHtml = string.Empty;
                var sortMatchList = from d in highLevelList
                                    orderby Convert.ToInt32(d.Value[2])
                                    select d;
                for (int i = 0; i < sortMatchList.ToList().Count; i++)
                {
                    if (listNumber < 10)
                    {
                        returnHtml += "<li onclick='getValue(this)'>" + sortMatchList.ToList()[i].Value[1] + "</li>";
                        listNumber++;
                    }
                    else
                    {
                        break;
                    }
                }
                return returnHtml;
            }

            #endregion
        }
    }
}
