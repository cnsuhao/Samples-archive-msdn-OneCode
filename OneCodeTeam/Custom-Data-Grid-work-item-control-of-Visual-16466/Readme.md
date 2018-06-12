# Custom Data Grid work item control of Visual Studio (CSTFSWorkitemDataGridView)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* TFS
## Topics
* DataGrid
* Work Item Control
## IsPublished
* True
## ModifiedDate
* 2012-04-20 12:08:24
## Description

<h1>Custom Data Grid work item control of Visual Studio (<a name="OLE_LINK4"></a><a name="OLE_LINK3"><span style=""></span></a><span class="SpellE"><span style=""><span style=""><span style="">CSTFSWorkItemDataGridControl</span></span></span></span><span style=""></span><span style=""></span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The CSTFSWorkItemDataGridControl</span><span style=""> sample</span><span style=""> demonstrates how to create a Custom Data Grid work item control of Visual
</span><span style="">Studio. </span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Display a Field value in DataGrid </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Save the data in DataGrid to a WorkItem Field
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Support customize the Columns' Name </span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Avoid<span style="">&nbsp; </span>Illegal characters
</span></p>
<h2><span style="">Building</span> the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Team Explorer 2010 is required. And then update following assembly references:
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.Client </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.Common </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.WorkItemTracking.Client
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.WorkItemTracking.Controls
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Copy following items to <u>%USERPROFILE%</u></span><u>
</u><u><span style="">\<span class="SpellE">AppData</span>\Local\Microsoft\Team Foundation\Work Item Tracking\Custom Controls</span></u><span style="">.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span class="SpellE"><span style="">DataGridControl.wicc</span></span><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">CSTFSWorkItemDataGridControl.dll </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">If you want to deploy them to multiple clients, the
<b style="">Team Members</b> component in <a href="http://visualstudiogallery.msdn.microsoft.com/c255a1e4-04ba-4f68-8f4e-cd473d6b971f">
TFS Power Tools</a> is a great tool. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Use <span class="SpellE"><b style="">WitAdmin</b></span>
<span class="SpellE"><b style="">importwitd</b></span> command line to import the
<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style=""><b style="">WIT Controls</b>
</span></a>(WIT Controls.xml) WorkItem Type. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">See <a href="http://msdn.microsoft.com/en-us/library/dd312129.aspx">
http://msdn.microsoft.com/en-us/library/dd312129.aspx</a>. TFS Power Tools also supplies a more convenient approach.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open Team Explorer in Visual <span class="GramE">
Studio,</span> connect to the Team Project to which you import the <b style="">WIT Controls.</b>
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a new <b style="">WIT Controls </b>work item, and you will see
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/56173/1/image.png" alt="" width="741" height="218" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Type the title and data in the <span class="SpellE">
DataGrid</span>, then save the work item. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/56174/1/image.png" alt="" width="734" height="282" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In the history tab, you can see the saved value of
<b style="">Demo.</b></span><b style=""> </b><span class="SpellE"><b style=""><span style="">GridField</span></b></span><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><span style="">&nbsp;</span><span style="">
<img src="/site/view/file/56175/1/image.png" alt="" width="783" height="574" align="middle">
</span></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">The <span class="SpellE">BaseWITControl</span> implements the basic logic of a custom WorkItem control.
</span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style="">A custom WorkItem Control is a Control that implements the
<span class="SpellE"><b style="">IWorkItemControl</b></span> interface. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
#region IWorkItemControl interface




/// &lt;summary&gt;
/// Raise this event after updating WorkItem object with values.
/// When value is changed by a control, work item form asks all controls (except
/// current control) to refresh their display values (by calling 
/// InvalidateDatasource) in case if affects other controls 
/// &lt;/summary&gt;
event EventHandler IWorkItemControl.AfterUpdateDatasource
{
    add
    {
        Events.AddHandler(EventAfterUpdateDatasource, value);
    }
    remove
    {
        Events.RemoveHandler(EventAfterUpdateDatasource, value);
    }
}






/// &lt;summary&gt;
/// Raise this events before updating WorkItem object with values.
/// When value is changed by a control, work item form asks all controls (except
/// current control) to refresh their display values (by calling 
/// InvalidateDatasource) in case if affects other controls 
/// &lt;/summary&gt;
event EventHandler IWorkItemControl.BeforeUpdateDatasource
{
    add
    {
        Events.AddHandler(EventBeforeUpdateDatasource, value);
    }
    remove
    {
        Events.RemoveHandler(EventBeforeUpdateDatasource, value);
    }
}


/// &lt;summary&gt;
/// Control is asked to clear its contents
/// &lt;/summary&gt;
public abstract void Clear();


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// &lt;/summary&gt;
public abstract void FlushToDatasource();


///&lt;summary&gt;
/// Asks control to invalidate the contents and redraw.
/// &lt;/summary&gt;
public abstract void InvalidateDatasource();




///&lt;summary&gt;
/// All attributes specified in work item type definition file for this 
/// control, including custom attributes.
/// &lt;/summary&gt;
public virtual StringDictionary Properties
{
    get
    {
        return properties;
    }
    set
    {
        properties = value;
    }
}


/// &lt;summary&gt;
/// Whether the control is readonly.
/// &lt;/summary&gt;
public virtual bool ReadOnly
{
    get
    {
        return this.readOnly;
    }
    set
    {
        this.SetReadOnly(value);
    }
}


/// &lt;summary&gt;
/// We can use the serviceProvider to get Visual Studio services.
/// &lt;/summary&gt;
/// &lt;param name=&quot;serviceProvider&quot;&gt;&lt;/param&gt;
public virtual void SetSite(IServiceProvider serviceProvider)
{
    this.serviceProvider = serviceProvider;
}


/// &lt;summary&gt;
/// WorkItemDatasource refers to current work item object. 
/// &lt;/summary&gt;
public virtual object WorkItemDatasource
{
    get
    {
        return workItem;
    }
    set
    {
        workItem = (WorkItem)value;
    }
}


/// &lt;summary&gt;
/// The field name which the control is associated with in work item type
/// definition.
///&lt;/summary&gt;
public virtual string WorkItemFieldName
{
    get
    {
        return fieldName;
    }
    set
    {
        fieldName = value;
    }
}


#endregion

</pre>
<pre id="codePreview" class="csharp">
#region IWorkItemControl interface




/// &lt;summary&gt;
/// Raise this event after updating WorkItem object with values.
/// When value is changed by a control, work item form asks all controls (except
/// current control) to refresh their display values (by calling 
/// InvalidateDatasource) in case if affects other controls 
/// &lt;/summary&gt;
event EventHandler IWorkItemControl.AfterUpdateDatasource
{
    add
    {
        Events.AddHandler(EventAfterUpdateDatasource, value);
    }
    remove
    {
        Events.RemoveHandler(EventAfterUpdateDatasource, value);
    }
}






/// &lt;summary&gt;
/// Raise this events before updating WorkItem object with values.
/// When value is changed by a control, work item form asks all controls (except
/// current control) to refresh their display values (by calling 
/// InvalidateDatasource) in case if affects other controls 
/// &lt;/summary&gt;
event EventHandler IWorkItemControl.BeforeUpdateDatasource
{
    add
    {
        Events.AddHandler(EventBeforeUpdateDatasource, value);
    }
    remove
    {
        Events.RemoveHandler(EventBeforeUpdateDatasource, value);
    }
}


/// &lt;summary&gt;
/// Control is asked to clear its contents
/// &lt;/summary&gt;
public abstract void Clear();


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// &lt;/summary&gt;
public abstract void FlushToDatasource();


///&lt;summary&gt;
/// Asks control to invalidate the contents and redraw.
/// &lt;/summary&gt;
public abstract void InvalidateDatasource();




///&lt;summary&gt;
/// All attributes specified in work item type definition file for this 
/// control, including custom attributes.
/// &lt;/summary&gt;
public virtual StringDictionary Properties
{
    get
    {
        return properties;
    }
    set
    {
        properties = value;
    }
}


/// &lt;summary&gt;
/// Whether the control is readonly.
/// &lt;/summary&gt;
public virtual bool ReadOnly
{
    get
    {
        return this.readOnly;
    }
    set
    {
        this.SetReadOnly(value);
    }
}


/// &lt;summary&gt;
/// We can use the serviceProvider to get Visual Studio services.
/// &lt;/summary&gt;
/// &lt;param name=&quot;serviceProvider&quot;&gt;&lt;/param&gt;
public virtual void SetSite(IServiceProvider serviceProvider)
{
    this.serviceProvider = serviceProvider;
}


/// &lt;summary&gt;
/// WorkItemDatasource refers to current work item object. 
/// &lt;/summary&gt;
public virtual object WorkItemDatasource
{
    get
    {
        return workItem;
    }
    set
    {
        workItem = (WorkItem)value;
    }
}


/// &lt;summary&gt;
/// The field name which the control is associated with in work item type
/// definition.
///&lt;/summary&gt;
public virtual string WorkItemFieldName
{
    get
    {
        return fieldName;
    }
    set
    {
        fieldName = value;
    }
}


#endregion

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">The <span class="SpellE">DataGridControl</span> class inherits the
<span class="SpellE">BaseWITControl</span> and it uses a <span class="SpellE">
DataGridView</span> to represent a WorkItem field.<span style=""> </span></span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Use the control attribute to customize the columns definition.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// The pattern to identify the columns from the attribute.
// The attribute should like 
// Column A(FieldA);Column B(FieldB);
const string columnDefinitionPattern = @&quot;(?&lt;display&gt;.&#43;?)\((?&lt;field&gt;.&#43;?)\);&quot;;
       
///&lt;summary&gt;
/// All attributes specified in work item type definition file for this 
/// control, including custom attributes.
/// 
/// We need the &quot;columns&quot; attribute to initialize the columns of DataGridView.
/// &lt;/summary&gt;
public override System.Collections.Specialized.StringDictionary Properties
{
    get
    {
        return base.Properties;
    }
    set
    {
        base.Properties = value;
        UpdateGridViewColumns(base.Properties[&quot;columns&quot;]);
    }
}


/// &lt;summary&gt;
/// Initialize the columns of DataGridView. The attributes should like 
/// Column A(FieldA);Column B(FieldB);
/// &lt;/summary&gt;
/// &lt;param name=&quot;columnsAttribute&quot;&gt;&lt;/param&gt;
void UpdateGridViewColumns(string columnsAttribute)
{
    // The definition of the columns does not change.
    if (string.IsNullOrEmpty(columnsAttribute))
    {
        return;
    }


    // Clear the columns.
    this.gvData.Columns.Clear();


    // Get the new columns definition.
    MatchCollection matches = Regex.Matches(columnsAttribute, columnDefinitionPattern);


    foreach (Match match in matches)
    {
        DataGridViewColumn colum = new DataGridViewTextBoxColumn();
        colum.DataPropertyName = match.Groups[&quot;field&quot;].Value;
        colum.HeaderText = match.Groups[&quot;display&quot;].Value;
        this.gvData.Columns.Add(colum);
    }
}

</pre>
<pre id="codePreview" class="csharp">
// The pattern to identify the columns from the attribute.
// The attribute should like 
// Column A(FieldA);Column B(FieldB);
const string columnDefinitionPattern = @&quot;(?&lt;display&gt;.&#43;?)\((?&lt;field&gt;.&#43;?)\);&quot;;
       
///&lt;summary&gt;
/// All attributes specified in work item type definition file for this 
/// control, including custom attributes.
/// 
/// We need the &quot;columns&quot; attribute to initialize the columns of DataGridView.
/// &lt;/summary&gt;
public override System.Collections.Specialized.StringDictionary Properties
{
    get
    {
        return base.Properties;
    }
    set
    {
        base.Properties = value;
        UpdateGridViewColumns(base.Properties[&quot;columns&quot;]);
    }
}


/// &lt;summary&gt;
/// Initialize the columns of DataGridView. The attributes should like 
/// Column A(FieldA);Column B(FieldB);
/// &lt;/summary&gt;
/// &lt;param name=&quot;columnsAttribute&quot;&gt;&lt;/param&gt;
void UpdateGridViewColumns(string columnsAttribute)
{
    // The definition of the columns does not change.
    if (string.IsNullOrEmpty(columnsAttribute))
    {
        return;
    }


    // Clear the columns.
    this.gvData.Columns.Clear();


    // Get the new columns definition.
    MatchCollection matches = Regex.Matches(columnsAttribute, columnDefinitionPattern);


    foreach (Match match in matches)
    {
        DataGridViewColumn colum = new DataGridViewTextBoxColumn();
        colum.DataPropertyName = match.Groups[&quot;field&quot;].Value;
        colum.HeaderText = match.Groups[&quot;display&quot;].Value;
        this.gvData.Columns.Add(colum);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">The value of the field is stored as<span style="">&nbsp;
</span>XML format. This control will use DataTable to read data from the XML, and write XML to the field when the workitem is saved.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Use DataTable to read the value of this field, and write XML to 
// this field.
private DataTable table;
private BindingSource source;


public DataGridControl()
{
    InitializeComponent();


    this.gvData.AutoGenerateColumns = false;
  
    // Initialize data source.
    this.table = new DataTable(&quot;DataTable&quot;);
    this.source = new BindingSource();
    this.source.DataSource = table;
    this.gvData.DataSource = source;
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Clear the data in the table.
/// &lt;/summary&gt;
public override void Clear()
{
    if (this.table != null)
    {
        this.table.Rows.Clear();
    }
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Write the data in DataTable as XML, and then set the value of current 
/// field to the XML.
/// &lt;/summary&gt;
public override void FlushToDatasource()
{
    if (this.table != null)
    {


        using (StringWriter writer = new StringWriter())
        {
            this.table.WriteXml(writer, XmlWriteMode.WriteSchema);
            this.SetFieldValue(writer.ToString());
        }
    }
    else
    {
        this.SetFieldValue(null);
    }
}


///&lt;summary&gt;
/// Ask control to invalidate the contents and redraw.
/// Read the value (XML) of current field.
/// &lt;/summary&gt;
public override void InvalidateDatasource()
{
    this.Field = null;
    this.Clear();


    if (this.HasValidField)
    {
        try
        {
            this.table.Clear();
            using(StringReader reader = new StringReader(this.Field.Value as string))
            {
                this.table.ReadXml(reader);
            }
        }
        catch
        {
        }


        SetReadOnly(!this.Field.IsEditable);


        // If the columns definition changed, update the DataTable.
        foreach (DataGridViewColumn col in this.gvData.Columns)
        {
            if (!table.Columns.Contains(col.DataPropertyName))
            {
                table.Columns.Add(col.DataPropertyName);
            }
        }                             
    }
}










3.      
Define a new WorkItem Type
to use this control





&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;witd:WITD application=&quot;Work item type editor&quot; version=&quot;1.0&quot; xmlns:witd=&quot;http://schemas.microsoft.com/VisualStudio/2008/workitemtracking/typedef&quot;&gt;
  &lt;WORKITEMTYPE name=&quot;WIT Controls&quot;&gt;
    &lt;DESCRIPTION&gt;&lt;/DESCRIPTION&gt;
    &lt;FIELDS&gt;
      ...
      &lt;FIELD name=&quot;GridField&quot; refname=&quot;Demo.GridField&quot; type=&quot;PlainText&quot; /&gt;
      ...
    &lt;/FIELDS&gt;
    &lt;WORKFLOW&gt;
      ...
    &lt;/WORKFLOW&gt;
    &lt;FORM&gt;
      ...
            &lt;Control FieldName=&quot;Demo.GridField&quot; Type=&quot;DataGridControl&quot; Label=&quot;&quot; LabelPosition=&quot;Top&quot; Dock=&quot;Fill&quot; columns=&quot;Column A(Name);Column B(Age);Column C(Score);&quot;&gt;
              &lt;CustomControlOptions /&gt;
            &lt;/Control&gt;
     ...
    &lt;/FORM&gt;
  &lt;/WORKITEMTYPE&gt;
&lt;/witd:WITD&gt;

</pre>
<pre id="codePreview" class="csharp">
// Use DataTable to read the value of this field, and write XML to 
// this field.
private DataTable table;
private BindingSource source;


public DataGridControl()
{
    InitializeComponent();


    this.gvData.AutoGenerateColumns = false;
  
    // Initialize data source.
    this.table = new DataTable(&quot;DataTable&quot;);
    this.source = new BindingSource();
    this.source.DataSource = table;
    this.gvData.DataSource = source;
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Clear the data in the table.
/// &lt;/summary&gt;
public override void Clear()
{
    if (this.table != null)
    {
        this.table.Rows.Clear();
    }
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Write the data in DataTable as XML, and then set the value of current 
/// field to the XML.
/// &lt;/summary&gt;
public override void FlushToDatasource()
{
    if (this.table != null)
    {


        using (StringWriter writer = new StringWriter())
        {
            this.table.WriteXml(writer, XmlWriteMode.WriteSchema);
            this.SetFieldValue(writer.ToString());
        }
    }
    else
    {
        this.SetFieldValue(null);
    }
}


///&lt;summary&gt;
/// Ask control to invalidate the contents and redraw.
/// Read the value (XML) of current field.
/// &lt;/summary&gt;
public override void InvalidateDatasource()
{
    this.Field = null;
    this.Clear();


    if (this.HasValidField)
    {
        try
        {
            this.table.Clear();
            using(StringReader reader = new StringReader(this.Field.Value as string))
            {
                this.table.ReadXml(reader);
            }
        }
        catch
        {
        }


        SetReadOnly(!this.Field.IsEditable);


        // If the columns definition changed, update the DataTable.
        foreach (DataGridViewColumn col in this.gvData.Columns)
        {
            if (!table.Columns.Contains(col.DataPropertyName))
            {
                table.Columns.Add(col.DataPropertyName);
            }
        }                             
    }
}










3.      
Define a new WorkItem Type
to use this control





&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;witd:WITD application=&quot;Work item type editor&quot; version=&quot;1.0&quot; xmlns:witd=&quot;http://schemas.microsoft.com/VisualStudio/2008/workitemtracking/typedef&quot;&gt;
  &lt;WORKITEMTYPE name=&quot;WIT Controls&quot;&gt;
    &lt;DESCRIPTION&gt;&lt;/DESCRIPTION&gt;
    &lt;FIELDS&gt;
      ...
      &lt;FIELD name=&quot;GridField&quot; refname=&quot;Demo.GridField&quot; type=&quot;PlainText&quot; /&gt;
      ...
    &lt;/FIELDS&gt;
    &lt;WORKFLOW&gt;
      ...
    &lt;/WORKFLOW&gt;
    &lt;FORM&gt;
      ...
            &lt;Control FieldName=&quot;Demo.GridField&quot; Type=&quot;DataGridControl&quot; Label=&quot;&quot; LabelPosition=&quot;Top&quot; Dock=&quot;Fill&quot; columns=&quot;Column A(Name);Column B(Age);Column C(Score);&quot;&gt;
              &lt;CustomControlOptions /&gt;
            &lt;/Control&gt;
     ...
    &lt;/FORM&gt;
  &lt;/WORKITEMTYPE&gt;
&lt;/witd:WITD&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Define a new WorkItem Type to use this control</span></b><b style=""><span style="">
</span></b></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb286959(VS.90).aspx">Work Item Tracking Custom Controls</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.controls.iworkitemcontrol(VS.90).aspx"><span class="SpellE">IWorkItemControl</span> Interface</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
