/****************************** Module Header ******************************\
* Module Name:    myWorkflow.cs
* Project:        CSSharePointTaskWithContentTypeWorkflow
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to Use CreateTaskWithContentType in SharePoint Visual Studio Workflow
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;

namespace MyWorkflow.Workflow
{
    public sealed partial class myWorkflow : SequentialWorkflowActivity
    {
        public myWorkflow()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void createTask1Invoke(object sender, EventArgs e)
        {
            task1Properties = new SPWorkflowTaskProperties();
            task1Properties.Title = string.Format("Please approval:【{0}】", this.workflowProperties.Item.DisplayName);
            task1Guid = Guid.NewGuid();
            //This is the Content type which is used by the workFlow
            task1ContentTypeId = "0x01080100FFbc98c2529347a5886b8d2576b954e3";
        }

        //ContentTypeId of CreateTaskWithContentType
        public static DependencyProperty task1ContentTypeIdProperty = DependencyProperty.Register("task1ContentTypeId", typeof(System.String), typeof(MyWorkflow.Workflow.myWorkflow));

        public String task1ContentTypeId
        {
            get
            {
                return ((string)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1ContentTypeIdProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1ContentTypeIdProperty, value);
            }
        }

        //TaskId of CreateTaskWithContentType
        public static DependencyProperty task1GuidProperty = DependencyProperty.Register("task1Guid", typeof(System.Guid), typeof(MyWorkflow.Workflow.myWorkflow));

        public Guid task1Guid
        {
            get
            {
                return ((System.Guid)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1GuidProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1GuidProperty, value);
            }
        }

        //TaskProperties of CreateTaskWithContentType
        public static DependencyProperty task1PropertiesProperty = DependencyProperty.Register("task1Properties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.myWorkflow));

        public SPWorkflowTaskProperties task1Properties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1PropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1PropertiesProperty, value);
            }
        }

        //AfterProperties of OnTaskChanged
        public static DependencyProperty task1Changed1_AfterPropertiesProperty = DependencyProperty.Register("task1Changed1_AfterProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.myWorkflow));

        public SPWorkflowTaskProperties task1Changed1_AfterProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1Changed1_AfterPropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1Changed1_AfterPropertiesProperty, value);
            }
        }

        //BeforeProperties of OnTaskChanged
        public static DependencyProperty task1Changed1_BeforePropertiesProperty = DependencyProperty.Register("task1Changed1_BeforeProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(MyWorkflow.Workflow.myWorkflow));

        public SPWorkflowTaskProperties task1Changed1_BeforeProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1Changed1_BeforePropertiesProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1Changed1_BeforePropertiesProperty, value);
            }
        }

        private bool isFinished = false;

        //Handler of OnTaskChanged
        private void task1Changed1Invoke(object sender, ExternalDataEventArgs e)
        {
            //isFinished = task1Changed1_AfterProperties.PercentComplete == 1F;
            isFinished = (task1Changed1_AfterProperties.ExtendedProperties[SPBuiltInFieldId.TaskStatus].ToString() == "Completed");         
        }

        private void while1Invoke(object sender, ConditionalEventArgs e)
        {
            e.Result = !isFinished;
        }

        //TaskOutcome of CompleteTask
        public static DependencyProperty task1OutcomeProperty = DependencyProperty.Register("task1Outcome", typeof(System.String), typeof(MyWorkflow.Workflow.myWorkflow));

        public String task1Outcome
        {
            get
            {
                return ((string)(base.GetValue(MyWorkflow.Workflow.myWorkflow.task1OutcomeProperty)));
            }
            set
            {
                base.SetValue(MyWorkflow.Workflow.myWorkflow.task1OutcomeProperty, value);
            }
        }

    }
}
