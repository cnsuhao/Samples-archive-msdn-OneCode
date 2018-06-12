/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSSharePointCSVReaderForUserProfile
* Copyright (c) Microsoft Corporation
*
* The sample will demo you how to importe data from a CSV
* file to SharePoint 2010 User Profiles
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using Microsoft.SharePoint;
using Microsoft.Office.Server.UserProfiles;
using System.IO;
using System.Collections.Generic;
using System;

namespace CSSharePointCSVReaderForUserProfile
{
    class Program
    {
        static void Main(string[] args)
        {

            // Get data from CSV file and populate to List
            List<string[]> csvData = parseCSV(@"..\..\sample.csv");
            // Temp index
            int dis_index = 0, given_index = 0, home_index = 0, mobile_index = 0;

            Console.WriteLine("Required");

            // Open your site
            using (SPSite site = new SPSite("http://[PLACE_YOUR_SHAREPOINT_SITE_URL_HERE]/"))
            {
                // Get the ServiceContext
                SPServiceContext context = SPServiceContext.GetContext(site);

                // Create a ProfileSubtypeManager instance
                ProfileSubtypeManager psm = ProfileSubtypeManager.Get(context);

                // Choose default user profile subtype as the subtype
                string subtypeName = ProfileSubtypeManager.GetDefaultProfileName(ProfileType.User);

                ProfileSubtype subType = psm.GetProfileSubtype(subtypeName);
                UserProfileManager upm = new UserProfileManager(context);

                // Traversal List data and output.
                for (int i = 0; i < csvData.Count; i++)
                {
                    // Header row
                    if (i == 0)
                    {
                        int colLength = csvData[0].Length;
                        for (int j = 0; j < colLength; j++)
                        {
                            if (!string.IsNullOrEmpty(csvData[0][j]))
                            {
                                if (csvData[0][j].Equals("displayName", StringComparison.OrdinalIgnoreCase))
                                {
                                    dis_index = j;
                                }
                                else if (csvData[0][j].Equals("givenName", StringComparison.OrdinalIgnoreCase))
                                {
                                    given_index = j;
                                }
                                else if (csvData[0][j].Equals("homePhone", StringComparison.OrdinalIgnoreCase))
                                {
                                    home_index = j;
                                }
                                else if (csvData[0][j].Equals("mobile", StringComparison.OrdinalIgnoreCase))
                                {
                                    mobile_index = j;
                                }
                            }
                        }
                    }

                    Console.WriteLine(csvData[i][dis_index] + "\t ---  " + csvData[i][given_index] + "\t ---  " + csvData[i][home_index] + "\t ---  " + csvData[i][mobile_index] + "\t ---  ");

                    // DataRow
                    if (i != 0)
                    {
                        string userid = "contoso:" + csvData[i][dis_index];

                        // If the UserProfile does not exist then to submit the current data.
                        if (!upm.UserExists(userid))
                        {
                            UserProfile newProfile = upm.CreateUserProfile(userid);
                            newProfile.DisplayName = csvData[i][dis_index];
                            newProfile.ProfileSubtype = subType;
                            newProfile[PropertyConstants.FirstName].Value = csvData[i][dis_index];
                            newProfile[PropertyConstants.LastName].Value = csvData[i][given_index];
                            newProfile[PropertyConstants.HomePhone].Value = csvData[i][home_index];
                            newProfile[PropertyConstants.CellPhone].Value = csvData[i][mobile_index];
                            newProfile.Commit();
                        }
                    }
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Parse CSV file's Data to list
        /// </summary>
        /// <param name="path">CSV file's Path</param>
        /// <returns></returns>
        public static List<string[]> parseCSV(string path)
        {
            // A list to store the parsed data
            List<string[]> parsedData = new List<string[]>();

            try
            {
                // Using StreamReader to read the CSV file
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row, temp, parsedrow;
                    bool first_line = true;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        // A list to store data row
                        List<string> final = new List<string>();

                        // based on quotes interception into an array
                        row = line.Split('"');
                        if (first_line)
                        {
                            row = line.Split(',');
                            parsedData.Add(row);
                            first_line = false;
                            continue;
                        }

                        // Loop above array and the effective cell data will be added to the corresponding array.
                        // If corresponding row starts with comma,remove the comma at the end of a row,
                        // and then split the remaining contents into a array based on comma.
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (row[i].StartsWith(","))
                            {
                                if (i != row.Length - 1)
                                    row[i] = row[i].Remove(row[i].Length - 1);

                                temp = row[i].Split(',');

                                for (int j = 1; j < temp.Length; j++)
                                    final.Add(temp[j]);
                            }
                            else if (row[i] != "")
                            {
                                final.Add(row[i]);
                            }
                        }
                        if (final.Count == 0)
                            continue;

                        parsedrow = final.ToArray();
                        // The corresponding data of row is added to the list of the final recording.
                        parsedData.Add(parsedrow);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return parsedData;
        }
    }
}
