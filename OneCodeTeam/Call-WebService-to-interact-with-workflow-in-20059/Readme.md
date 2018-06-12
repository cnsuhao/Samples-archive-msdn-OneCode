# Call WebService to interact with workflow in Outlook (CSOutlookCallWCFWFService)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office Development
## Topics
* Outlook
* WebService
* approval workflow
## IsPublished
* True
## ModifiedDate
* 2012-12-25 10:18:51
## Description

<h1>How to call a web service to interact with workflow in outlook 2010(CSOutlookCallWCFWFService)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The sample demonstrates how to call a WCF service to interact workflow in Outlook 2010. Some customers want call the WCF service to interact workflow and approve workflow in outlook.
</span></p>
<p class="MsoNormal"><span style="">The solution has four projects. The DBOperate project is the Linq map to SQL Server database; The CSLeaveWF project is the custom workflow application; The CSWCFService project is the windows communication foundation (WCF)
 application, the project hosts a workflow application; The CSOutlookCallWCFInteractWithWF project is the Outlook client, we can call WCF application to interact with workflow in outlook client.</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span style="">Before you build the sample, you must install Microsoft Office 2010 on your Operation System and be sure that Outlook process is not running.
</span></p>
<p class="MsoNormal"><span style="">You must install Microsoft SQL Server 2008 R2 or SQL Server 2012.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Step1. Open &quot;TestDataBase_BackUp.sql&quot; file in DBOperate project file and connect your SQL Server instance then Click &quot;Execute&quot; button to execute the script.
</span></p>
<p class="MsoNormal"><span style="">Step2. Open CSOutlookCallWCFWFService.sln and modify the connection string to your local configuration of Microsoft SQL Server.
</span></p>
<p class="MsoNormal"><span style="">Step3. Set &quot;CSWCFService&quot; project as startup project to launch WCF service firstly. Then click F5 to run the service.
</span></p>
<p class="MsoNormal"><span style="">Step4. After the WCF service launch successfully, set &quot;CSOutlookCallWCFInteractWithWF&quot; as the Startup project.<span style="">&nbsp;
</span>Then click F5 to run the solution and you should click OK button to choose profile firstly, after load all add-in, you will see the following form:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73515/1/image.png" alt="" width="759" height="204" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step5. Select &quot;Call Workflow&quot; ribbon and click &quot;Leave WorkFlow&quot; button to show the Leave main form.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73516/1/image.png" alt="" width="766" height="425" align="middle">
</span></p>
<p class="MsoNormal"><span style="">Step6. You can input your name and leave days and then click &quot;OK&quot; button to create a leave request, when you create leave request successfully, the request will show in the ListView control of PendingLeaves group
 and you will see &quot;Create Leave request successfully&quot; message. </span></p>
<p class="MsoNormal"><span style="">Step7. Select a leave request in ListView control and then click &quot;Approve&quot; or &quot;Reject&quot; button to Approve or Reject Leave request.
</span></p>
<p class="MsoNormal">Step8. To uninstall this Add-in, please close Outlook 2010 at first, then right click CSOutlookCallWCFInteractWithWF project in solution Explorer and click Clean.</p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">Step1. Restore database from &quot;TestDataBase_BackUp.sql&quot; file in DBOperate project file.
</span></p>
<p class="MsoNormal"><span style="">Step2. Create Blank Solution via Visual Studio 2010
</span></p>
<p class="MsoNormal"><span style="">Step3. Create Class Library project and named it &quot;DBOperate&quot;, then add &quot;Linq to SQL classes&quot; item and drag Leave table in Server Explore into designer form.
</span></p>
<p class="MsoNormal"><span style="">Step4. Add Activity Library project to the solution, add DBOperate reference to the project and design the workflow.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Activity mc:Ignorable=&quot;sap sads&quot; x:Class=&quot;CSLeaveWF.LeaveProcess&quot;
 xmlns=&quot;http://schemas.microsoft.com/netfx/2009/xaml/activities&quot;
 xmlns:c=&quot;clr-namespace:DBOperate;assembly=DBOperate&quot;
 xmlns:local=&quot;clr-namespace:CSLeaveWF&quot;
 xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
 xmlns:mv=&quot;clr-namespace:Microsoft.VisualBasic;assembly=System&quot;
 xmlns:mva=&quot;clr-namespace:Microsoft.VisualBasic.Activities;assembly=System.Activities&quot;
 xmlns:s=&quot;clr-namespace:System;assembly=mscorlib&quot;
 xmlns:s1=&quot;clr-namespace:System;assembly=System&quot;
 xmlns:s2=&quot;clr-namespace:System;assembly=System.Xml&quot;
 xmlns:s3=&quot;clr-namespace:System;assembly=System.Core&quot;
 xmlns:s4=&quot;clr-namespace:System;assembly=System.ServiceModel&quot;
 xmlns:sa=&quot;clr-namespace:System.Activities;assembly=System.Activities&quot;
 xmlns:sad=&quot;clr-namespace:System.Activities.Debugger;assembly=System.Activities&quot;
 xmlns:sads=&quot;http://schemas.microsoft.com/netfx/2010/xaml/activities/debugger&quot;
 xmlns:sap=&quot;http://schemas.microsoft.com/netfx/2009/xaml/activities/presentation&quot;
 xmlns:scg=&quot;clr-namespace:System.Collections.Generic;assembly=System&quot;
 xmlns:scg1=&quot;clr-namespace:System.Collections.Generic;assembly=System.ServiceModel&quot;
 xmlns:scg2=&quot;clr-namespace:System.Collections.Generic;assembly=System.Core&quot;
 xmlns:scg3=&quot;clr-namespace:System.Collections.Generic;assembly=mscorlib&quot;
 xmlns:sd=&quot;clr-namespace:System.Data;assembly=System.Data&quot;
 xmlns:sl=&quot;clr-namespace:System.Linq;assembly=System.Core&quot;
 xmlns:st=&quot;clr-namespace:System.Text;assembly=mscorlib&quot;
 xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&gt;
  &lt;x:Members&gt;
    &lt;x:Property Name=&quot;LeaveName&quot; Type=&quot;InArgument(x:String)&quot; /&gt;
    &lt;x:Property Name=&quot;LeaveDay&quot; Type=&quot;InArgument(x:Int32)&quot; /&gt;
  &lt;/x:Members&gt;
  &lt;sap:VirtualizedContainerService.HintSize&gt;262,248&lt;/sap:VirtualizedContainerService.HintSize&gt;
  &lt;mva:VisualBasic.Settings&gt;Assembly references and imported namespaces for internal implementation&lt;/mva:VisualBasic.Settings&gt;
  &lt;Sequence DisplayName=&quot;Leave Process&quot; sad:XamlDebuggerXmlReader.FileName=&quot;D:\OneCode Resources\OffDev\OutLook Sample\CSOutlookCallWCFWFService\CSLeaveWF\LeaveProcess.xaml&quot; sap:VirtualizedContainerService.HintSize=&quot;222,208&quot;&gt;
    &lt;Sequence.Variables&gt;
      &lt;Variable x:TypeArguments=&quot;c:Leave&quot; Name=&quot;ObjLeave&quot; /&gt;
      &lt;Variable x:TypeArguments=&quot;x:String&quot; Name=&quot;Status&quot; /&gt;
    &lt;/Sequence.Variables&gt;
    &lt;sap:WorkflowViewStateService.ViewState&gt;
      &lt;scg3:Dictionary x:TypeArguments=&quot;x:String, x:Object&quot;&gt;
        &lt;x:Boolean x:Key=&quot;IsExpanded&quot;&gt;True&lt;/x:Boolean&gt;
      &lt;/scg3:Dictionary&gt;
    &lt;/sap:WorkflowViewStateService.ViewState&gt;
    &lt;local:CreateLeave Comment=&quot;affair leave&quot; Day=&quot;[LeaveDay]&quot; DisplayName=&quot;Create Leave&quot; sap:VirtualizedContainerService.HintSize=&quot;200,22&quot; Name=&quot;[LeaveName]&quot; ObjLeave=&quot;[ObjLeave]&quot; /&gt;
    &lt;local:ModifyLeave DisplayName=&quot;Update audit State&quot; sap:VirtualizedContainerService.HintSize=&quot;200,22&quot; State=&quot;[Status]&quot; UpdateLeaveInfo=&quot;[ObjLeave]&quot; /&gt;
  &lt;/Sequence&gt;
&lt;/Activity&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Activity mc:Ignorable=&quot;sap sads&quot; x:Class=&quot;CSLeaveWF.LeaveProcess&quot;
 xmlns=&quot;http://schemas.microsoft.com/netfx/2009/xaml/activities&quot;
 xmlns:c=&quot;clr-namespace:DBOperate;assembly=DBOperate&quot;
 xmlns:local=&quot;clr-namespace:CSLeaveWF&quot;
 xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
 xmlns:mv=&quot;clr-namespace:Microsoft.VisualBasic;assembly=System&quot;
 xmlns:mva=&quot;clr-namespace:Microsoft.VisualBasic.Activities;assembly=System.Activities&quot;
 xmlns:s=&quot;clr-namespace:System;assembly=mscorlib&quot;
 xmlns:s1=&quot;clr-namespace:System;assembly=System&quot;
 xmlns:s2=&quot;clr-namespace:System;assembly=System.Xml&quot;
 xmlns:s3=&quot;clr-namespace:System;assembly=System.Core&quot;
 xmlns:s4=&quot;clr-namespace:System;assembly=System.ServiceModel&quot;
 xmlns:sa=&quot;clr-namespace:System.Activities;assembly=System.Activities&quot;
 xmlns:sad=&quot;clr-namespace:System.Activities.Debugger;assembly=System.Activities&quot;
 xmlns:sads=&quot;http://schemas.microsoft.com/netfx/2010/xaml/activities/debugger&quot;
 xmlns:sap=&quot;http://schemas.microsoft.com/netfx/2009/xaml/activities/presentation&quot;
 xmlns:scg=&quot;clr-namespace:System.Collections.Generic;assembly=System&quot;
 xmlns:scg1=&quot;clr-namespace:System.Collections.Generic;assembly=System.ServiceModel&quot;
 xmlns:scg2=&quot;clr-namespace:System.Collections.Generic;assembly=System.Core&quot;
 xmlns:scg3=&quot;clr-namespace:System.Collections.Generic;assembly=mscorlib&quot;
 xmlns:sd=&quot;clr-namespace:System.Data;assembly=System.Data&quot;
 xmlns:sl=&quot;clr-namespace:System.Linq;assembly=System.Core&quot;
 xmlns:st=&quot;clr-namespace:System.Text;assembly=mscorlib&quot;
 xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&gt;
  &lt;x:Members&gt;
    &lt;x:Property Name=&quot;LeaveName&quot; Type=&quot;InArgument(x:String)&quot; /&gt;
    &lt;x:Property Name=&quot;LeaveDay&quot; Type=&quot;InArgument(x:Int32)&quot; /&gt;
  &lt;/x:Members&gt;
  &lt;sap:VirtualizedContainerService.HintSize&gt;262,248&lt;/sap:VirtualizedContainerService.HintSize&gt;
  &lt;mva:VisualBasic.Settings&gt;Assembly references and imported namespaces for internal implementation&lt;/mva:VisualBasic.Settings&gt;
  &lt;Sequence DisplayName=&quot;Leave Process&quot; sad:XamlDebuggerXmlReader.FileName=&quot;D:\OneCode Resources\OffDev\OutLook Sample\CSOutlookCallWCFWFService\CSLeaveWF\LeaveProcess.xaml&quot; sap:VirtualizedContainerService.HintSize=&quot;222,208&quot;&gt;
    &lt;Sequence.Variables&gt;
      &lt;Variable x:TypeArguments=&quot;c:Leave&quot; Name=&quot;ObjLeave&quot; /&gt;
      &lt;Variable x:TypeArguments=&quot;x:String&quot; Name=&quot;Status&quot; /&gt;
    &lt;/Sequence.Variables&gt;
    &lt;sap:WorkflowViewStateService.ViewState&gt;
      &lt;scg3:Dictionary x:TypeArguments=&quot;x:String, x:Object&quot;&gt;
        &lt;x:Boolean x:Key=&quot;IsExpanded&quot;&gt;True&lt;/x:Boolean&gt;
      &lt;/scg3:Dictionary&gt;
    &lt;/sap:WorkflowViewStateService.ViewState&gt;
    &lt;local:CreateLeave Comment=&quot;affair leave&quot; Day=&quot;[LeaveDay]&quot; DisplayName=&quot;Create Leave&quot; sap:VirtualizedContainerService.HintSize=&quot;200,22&quot; Name=&quot;[LeaveName]&quot; ObjLeave=&quot;[ObjLeave]&quot; /&gt;
    &lt;local:ModifyLeave DisplayName=&quot;Update audit State&quot; sap:VirtualizedContainerService.HintSize=&quot;200,22&quot; State=&quot;[Status]&quot; UpdateLeaveInfo=&quot;[ObjLeave]&quot; /&gt;
  &lt;/Sequence&gt;
&lt;/Activity&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Add WCF Service Application to the solution. Then add CSLeaveWF and DBOperate reference to the project. Define three Service functions in interface class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ServiceContract]
    public interface ILeaveService
    {
        /// &lt;summary&gt;
        /// Get checking list
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        List&lt;Leave&gt; GetLeaveList();


        /// &lt;summary&gt;
        /// Create Leave
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;day&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        void CreateLeave(string name, string day);


        /// &lt;summary&gt;
        /// audit Leave
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Leave Id&lt;/param&gt;
        /// &lt;param name=&quot;comment&quot;&gt;Approve or Reject&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        void AuditingLeave(string id, string comment);
    }

</pre>
<pre id="codePreview" class="csharp">
[ServiceContract]
    public interface ILeaveService
    {
        /// &lt;summary&gt;
        /// Get checking list
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        List&lt;Leave&gt; GetLeaveList();


        /// &lt;summary&gt;
        /// Create Leave
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;name&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;day&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        void CreateLeave(string name, string day);


        /// &lt;summary&gt;
        /// audit Leave
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;id&quot;&gt;Leave Id&lt;/param&gt;
        /// &lt;param name=&quot;comment&quot;&gt;Approve or Reject&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        [OperationContract]
        void AuditingLeave(string id, string comment);
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Implement three service functions in LeaveService class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class LeaveService : ILeaveService
   {
       /// &lt;summary&gt;
       /// Get Pending list
       /// &lt;/summary&gt;
       /// &lt;returns&gt;&lt;/returns&gt;
       public List&lt;Leave&gt; GetLeaveList()
       {
           using (LeaveDataContext dc = new LeaveDataContext())
           {
               List&lt;Leave&gt; leaves = dc.Leaves.Where(p =&gt; p.Status == &quot;Pending&quot;).ToList();
               return leaves;
           }
       }


       /// &lt;summary&gt;
       /// Create Leave
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;name&quot;&gt;The Name of Leave&lt;/param&gt;
       /// &lt;param name=&quot;day&quot;&gt;The Day of Leave&lt;/param&gt;
       public void CreateLeave(string name, string day)
       {
           WorkFlowProcess.CreateAndRun(name, int.Parse(day));
       }


       /// &lt;summary&gt;
       /// Audit Leave
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;id&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;comment&quot;&gt;&lt;/param&gt;
       public void AuditingLeave(string id, string comment)
       {
           WorkFlowProcess.RunInstance(Guid.Parse(id), comment);
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class LeaveService : ILeaveService
   {
       /// &lt;summary&gt;
       /// Get Pending list
       /// &lt;/summary&gt;
       /// &lt;returns&gt;&lt;/returns&gt;
       public List&lt;Leave&gt; GetLeaveList()
       {
           using (LeaveDataContext dc = new LeaveDataContext())
           {
               List&lt;Leave&gt; leaves = dc.Leaves.Where(p =&gt; p.Status == &quot;Pending&quot;).ToList();
               return leaves;
           }
       }


       /// &lt;summary&gt;
       /// Create Leave
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;name&quot;&gt;The Name of Leave&lt;/param&gt;
       /// &lt;param name=&quot;day&quot;&gt;The Day of Leave&lt;/param&gt;
       public void CreateLeave(string name, string day)
       {
           WorkFlowProcess.CreateAndRun(name, int.Parse(day));
       }


       /// &lt;summary&gt;
       /// Audit Leave
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;id&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;comment&quot;&gt;&lt;/param&gt;
       public void AuditingLeave(string id, string comment)
       {
           WorkFlowProcess.RunInstance(Guid.Parse(id), comment);
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step7. Add Outlook 2010 Add-in project to the solution and add WCF service reference to the project.</p>
<p class="MsoNormal">Step8. Create custom ribbon in outlook and add ribbonButton to the ribbongroup, you can click ribbonbutton to show the Leave main form.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
        /// Start Leave WorkFlow 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnLeaveWF_Click(object sender, RibbonControlEventArgs e)
        {
            // Show the Leave workflow Main Form
            LeaveMainForm createLeaveForm = new LeaveMainForm();
            createLeaveForm.ShowDialog();
        }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
        /// Start Leave WorkFlow 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnLeaveWF_Click(object sender, RibbonControlEventArgs e)
        {
            // Show the Leave workflow Main Form
            LeaveMainForm createLeaveForm = new LeaveMainForm();
            createLeaveForm.ShowDialog();
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step9. Create custom form in outlook and code behind the form to call WCF service to interact leave workflow.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public partial class LeaveMainForm : Form
    {
        // Initialize a new instance of Service Client 
        LeaveServiceClient leave = new LeaveServiceClient();


        // Constructor function
        public LeaveMainForm()
        {
            InitializeComponent();
            BindListView();
        }


        /// &lt;summary&gt;
        /// Get pending list from database and bind the list to ListView control 
        /// &lt;/summary&gt;
        private void BindListView()
        {
            lstViewPendingLeaves.Items.Clear();
            ListViewItem itemsource = new ListViewItem();
            Leave[] leaves = leave.GetLeaveList();
            foreach (var l in leaves)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(l.LeaveID.ToString());
                item.SubItems.Add(l.LeaveName);
                item.SubItems.Add(l.LeaveDay.ToString());
                item.SubItems.Add(l.Comment);
                item.SubItems.Add(l.Status);
                lstViewPendingLeaves.Items.Add(item);
            }    
        }


        /// &lt;summary&gt;
        /// Create a Leave WorkFlow
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbName.Text)||string.IsNullOrWhiteSpace(tbDay.Text))
            {
                MessageBox.Show(&quot;Name or Day cann't be empty&quot;);
                 return;
            }


            try
            {
                leave.CreateLeave(tbName.Text.Trim(), tbDay.Text.Trim());


                // Clear input argument
                tbName.Clear();
                tbDay.Clear();
                MessageBox.Show(&quot;Create Leave request successfully.&quot;);
                BindListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot; &#43; ex.Message);
            }
        }


        /// &lt;summary&gt;
        /// Approve leave request
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show(&quot;Please select a Leave Request to approve or reject&quot;, &quot;Tip&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, &quot;Yes&quot;);
                MessageBox.Show(&quot;Approve Successfully&quot;);
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot; &#43; ex.Message);
            }
        }


        /// &lt;summary&gt;
        /// Reject leave request
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show(&quot;Please select a Leave Request to approve or reject&quot;, &quot;Tip&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, &quot;No&quot;);
                MessageBox.Show(&quot;Reject Successfully&quot;);
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot;&#43;ex.Message);
            }
        }
    }

</pre>
<pre id="codePreview" class="csharp">
public partial class LeaveMainForm : Form
    {
        // Initialize a new instance of Service Client 
        LeaveServiceClient leave = new LeaveServiceClient();


        // Constructor function
        public LeaveMainForm()
        {
            InitializeComponent();
            BindListView();
        }


        /// &lt;summary&gt;
        /// Get pending list from database and bind the list to ListView control 
        /// &lt;/summary&gt;
        private void BindListView()
        {
            lstViewPendingLeaves.Items.Clear();
            ListViewItem itemsource = new ListViewItem();
            Leave[] leaves = leave.GetLeaveList();
            foreach (var l in leaves)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(l.LeaveID.ToString());
                item.SubItems.Add(l.LeaveName);
                item.SubItems.Add(l.LeaveDay.ToString());
                item.SubItems.Add(l.Comment);
                item.SubItems.Add(l.Status);
                lstViewPendingLeaves.Items.Add(item);
            }    
        }


        /// &lt;summary&gt;
        /// Create a Leave WorkFlow
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbName.Text)||string.IsNullOrWhiteSpace(tbDay.Text))
            {
                MessageBox.Show(&quot;Name or Day cann't be empty&quot;);
                 return;
            }


            try
            {
                leave.CreateLeave(tbName.Text.Trim(), tbDay.Text.Trim());


                // Clear input argument
                tbName.Clear();
                tbDay.Clear();
                MessageBox.Show(&quot;Create Leave request successfully.&quot;);
                BindListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot; &#43; ex.Message);
            }
        }


        /// &lt;summary&gt;
        /// Approve leave request
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show(&quot;Please select a Leave Request to approve or reject&quot;, &quot;Tip&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, &quot;Yes&quot;);
                MessageBox.Show(&quot;Approve Successfully&quot;);
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot; &#43; ex.Message);
            }
        }


        /// &lt;summary&gt;
        /// Reject leave request
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show(&quot;Please select a Leave Request to approve or reject&quot;, &quot;Tip&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, &quot;No&quot;);
                MessageBox.Show(&quot;Reject Successfully&quot;);
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(&quot;Exception occurs, The exception is :&quot;&#43;ex.Message);
            }
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/dd987846.aspx">WorkflowApplication</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.data.linq.datacontext.aspx">DataContext</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/ms735119(v=vs.90).aspx">Windows Communication Foundation</a>
</span></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
