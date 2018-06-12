/****************************** Module Header ******************************\
* Module Name:  RelationValidation.cs
* Project:		CSWF4CustomValidation
* Copyright (c) Microsoft Corporation.
* 
* This is a composite activity which can validate the relation of its child
* activities. 
*  
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Activities;
using System.Activities.Validation;
using System.ComponentModel;

namespace CSWF4CustomValidation
{
    [Designer(typeof(RelationValidationDesigner))]
    public class RelationValidation:NativeActivity
    {
        public Collection<Activity> Branches { get; set; }
        public Collection<Variable> Variables { get; set; }
        public Variable<int> LastIndexHint { get; set; }
        public RelationValidation() {
            Branches = new Collection<Activity>();
            Variables= new Collection<Variable>();
            LastIndexHint = new Variable<int>();
            this.Constraints.Add(CheckChild());
        }

        public static Constraint CheckChild() {
            DelegateInArgument<RelationValidation> element = 
                new DelegateInArgument<RelationValidation>();
            return new Constraint<RelationValidation> {
                Body = new ActivityAction<RelationValidation, 
                                          ValidationContext> {
                    Argument1 = element,
                    Handler = new AssertValidation {
                        Assertion=
                            new InArgument<bool>
                                (env=>(element.Get(env).Branches.Count!=0)),
                        Message=
                            new InArgument<string>
                                ("please add children activities to this activity")
                    }
                }
            };
        }

        int activityCounter = 0;
        protected override void CacheMetadata(NativeActivityMetadata metadata) {
            metadata.SetChildrenCollection(Branches);
            metadata.SetVariablesCollection(Variables);
            metadata.AddImplementationVariable(this.LastIndexHint);
        }

        protected override void Execute(NativeActivityContext context) {
            ScheduleActivities(context);
        }

        void ScheduleActivities(NativeActivityContext context) {
            if(activityCounter<Branches.Count)
                context.ScheduleActivity(this.Branches[activityCounter++],
                                         OnActivityCompleted);
        }

        void OnActivityCompleted(NativeActivityContext context, 
                                 ActivityInstance completedInstance) {
            ScheduleActivities(context);
        }
    }
}
