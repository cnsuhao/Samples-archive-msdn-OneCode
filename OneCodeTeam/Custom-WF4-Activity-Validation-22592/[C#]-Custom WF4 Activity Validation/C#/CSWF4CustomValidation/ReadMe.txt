=============================================================================
    WF4 APPLICATION : CSWF4CustomValidation
=============================================================================

/////////////////////////////////////////////////////////////////////////////
Summary:

When we trying to create a new Activity.we can also create our own validation
rule. This sample demonstrates two different methods. 
1.Basic Validation
  Basic Validation is usually created for validating the activity itself. 
2.Relation Validation
  This type validation is usually created for validating the relation with 
  other activities. 

/////////////////////////////////////////////////////////////////////////////
Prerequisites:

1. Visual Studio 2010
2. .NET Framework 4.0


/////////////////////////////////////////////////////////////////////////////
Demo:

To run the sample:
1. Open CSWF4CustomValidation.sln with Visual Studio 2010
2. Open Workflow1.xaml. you will see errors. that is the design time validation. 

To see the validation info:
1.Open CSWF4CustomValidation.sln with Visual Studio 2010
2.Open Workflow1.xaml file
3.Add a sequence activity to the workflow, then add a PersonInfo activity into
the Sequence. when you set the Age property to -1. you will see a red point and
error message that tell you age number must larger than 0.
4.Add RelationValidation activity into the Sequence. you will also see a 
validation message which indicates that you should at least add one child 
activity to the RelationValidation activity. 

/////////////////////////////////////////////////////////////////////////////
Code Logic:

1. Create a new Workflow 4.0 project named CSWF4CustomValidation. 
2. Create a new class file named BasicValidation.cs.then, fill the file with 
   following code:
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Activities;

	namespace CSWF4CustomValidation
	{
		public class PersonInfo : NativeActivity
		{
			public string Name { get; set; }
			public int Age { get; set; }

			protected override void CacheMetadata(NativeActivityMetadata metadata)
			{
				base.CacheMetadata(metadata);
				if (Age < 0)
				{
					metadata.AddValidationError("age must larger than 0");
				}
			}

			protected override void Execute(NativeActivityContext context)
			{
				Console.WriteLine(Name + " " + Age);
			}
		}
	}
3. Create a new class named RelationValidation.cs, then fill the file with
   following code:
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Collections.ObjectModel;
	using System.Activities;
	using System.Activities.Validation;

	namespace CSWF4CustomValidation
	{
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
4. Create a Activity Designer to the project named RelationValidationDesigner.xaml
<sap:ActivityDesigner x:Class="CSWF4CustomValidation.RelationValidationDesigner"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:sap="clr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation"
    xmlns:sapv="clr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation">
    <Grid>
        <StackPanel>
            <sap:WorkflowItemsPresenter HintText="Drop Activities Here"
                                        Items="{Binding Path=ModelItem.Branches,Mode=TwoWay}"
                                        >
                <sap:WorkflowItemsPresenter.SpacerTemplate>
                    <DataTemplate>
                        <Path Margin="0,10,0,10" 		                              
                              Stretch="Fill" 
                              StrokeMiterLimit="2.75" 
                              Stroke="#FFA8B3C2" Fill="#FFFFFFFF" 
                              Data="F1 M 675.738,744.979L 665.7,758.492L 655.66,744.979L 675.738,744.979 Z " 
                              Width="16" Height="10" />
                    </DataTemplate>
                </sap:WorkflowItemsPresenter.SpacerTemplate>
                <sap:WorkflowItemsPresenter.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Vertical"/>
                    </ItemsPanelTemplate>
                </sap:WorkflowItemsPresenter.ItemsPanel>
            </sap:WorkflowItemsPresenter>
        </StackPanel>
    </Grid>
</sap:ActivityDesigner>

5.Build the project.
6.Add attribute "[Designer(typeof(RelationValidationDesigner))]"
before the class RelationValidation.
7.Build the project.

/////////////////////////////////////////////////////////////////////////////
Reference:

Configuring Activity Validation
http://msdn.microsoft.com/en-us/library/ee358728.aspx

/////////////////////////////////////////////////////////////////////////////