/****************************** Module Header ******************************\
 * Module Name:  Program.cs
 * Project:      CSTFSUpdateHTMLFieldsWorkItem
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample shows how to bulk update the HTML field (e.g. ReproSteps) for TFS workitems. 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

namespace WorkItemEdit
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Common;

    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using System.Collections.ObjectModel;
    using System.Data.OleDb;
    using System.Data;

    class WorkItemEdit
    {
        #region Methods

        static void Main(string[] args)
        {
            // Get the Uri to the project collection to use
            var collectionUri = Helper.GetCollectionUri(args);

            // NOTE: You may need to modify the project name.
            string tfsProjectName = "TestProj";
            string tfsWorkItemType = "Bug";

            try
            {
                // Get the work item store from the TeamFoundationServer
                Console.WriteLine("Connecting to {0}...", collectionUri);

                // Get a reference to the team project collection
                using (var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri))
                {
                    // NOTE: You have to replace the file path with yours.
                    string excelpath = @"C:\UpdateBug\BugWI.xlsx";

                    OleDbConnection Con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelpath + ";Extended Properties=Excel 8.0");
                    Con.Open();
                    try
                    {
                        DataSet myDataSet = new DataSet();
                        OleDbDataAdapter myCommand = new OleDbDataAdapter(" SELECT * FROM [Sheet1$]", Con);
                        myCommand.Fill(myDataSet);

                        for (int i = 2; i <= myDataSet.Tables[0].Rows.Count; i++)
                        {
                            WorkItemStore wit = (WorkItemStore)projectCollection.GetService(typeof(WorkItemStore));
                            WorkItemCollection result = wit.Query(String.Format("SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.WorkItemType] = '{1}'", tfsProjectName, tfsWorkItemType));
                            List<WorkItem> affectedWorkItems = new List<WorkItem>();

                            int witid = int.Parse(myDataSet.Tables[0].Rows[i][0].ToString());
                            WorkItem bug = wit.GetWorkItem(12);

                            Field newReproSteps = bug.Fields["Microsoft.VSTS.CMMI.StepsToReproduce"];

                            Field reproSteps = bug.Fields["Microsoft.VSTS.TCM.ReproSteps"];
                            reproSteps.Value = newReproSteps.Value;
                            bug.Save();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                    finally
                    {
                        Con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
        #endregion Methods
    }
}